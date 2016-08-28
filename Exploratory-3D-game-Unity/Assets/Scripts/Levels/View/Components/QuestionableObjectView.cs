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
		}

		#endregion Public Methods

		#region Fields and Properties

		[SerializeField]
		private readonly float rotateSpeed = 50f;

		private GameObject prefab;

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
			if (IsTriggered)
			{
				prefab.transform.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f));
			}
			else
			{
				prefab.transform.rotation = Quaternion.Euler(Vector3.zero);
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