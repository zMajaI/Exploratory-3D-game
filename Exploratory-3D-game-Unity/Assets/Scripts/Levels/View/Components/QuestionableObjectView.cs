using System.Collections.Generic;
using UnityEngine;
using zm.Questioning;

namespace zm.Levels
{
	public class QuestionableObjectView : MonoBehaviour
	{
		#region Public Methods

		public void Initialize(Question question)
		{
			Question = question;
			prefab =  Instantiate(QuestionPrefabsProvider.Instance.GetPrefab(question.Category));
			prefab.transform.parent = transform;
			prefab.transform.localPosition = Vector3.zero;
            animations.AddRange(gameObject.GetComponentsInChildren<Animation>());
		}

		#endregion Public Methods

		#region Fields and Properties

		private GameObject prefab;

        private List<Animation> animations = new List<Animation>();

		public Question Question { get; private set; }

		/// <summary>
		/// Flag indicating if user is in range to interact with this object.
		/// </summary>
		public bool IsTriggered { get; private set; }

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		// Update is called once per frame
		private void Update()
		{
            for (int i = 0; i < animations.Count; i++)
            {
                animations[i].enabled = IsTriggered;
            }
		}

		public void OnTriggerEnter()
		{
			IsTriggered = true;
		}

		public void OnTriggerExit()
		{
			IsTriggered = false;
		}

		#endregion MonoBehaviour Methods

		#region Constants

		public const string QuestionsTag = "Questions";

		#endregion Constants
	}
}