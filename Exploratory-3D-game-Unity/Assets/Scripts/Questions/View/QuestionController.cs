using UnityEngine;

namespace zm.Questioning
{
	/// <summary>
	/// Class used for populating Questions scene and communicating with QuestionsModel.
	/// </summary>
	public class QuestionController : MonoBehaviour
	{

		#region Fields and Properties

		private QuestionsModel Model
		{
			get
			{
				return QuestionsModel.Instance;
			}
		}

		[SerializeField]
		private QuestionsUI UI;

		#endregion Fields and Properties

		#region Event Handlers

		public void OnClickBtnAdd()
		{
			
		}

		public void OnClickBtnRemove()
		{
			
		}

		public void OnClickBtnChange()
		{
			
		}

		public void OnClickBtnBack()
		{
			
		}

		public void OnValueChangedCategory(int newValue)
		{
			
		}

		public void OnValueChangedQuestion(int newValue)
		{
			
		}

		#endregion Event Handlers

		#region MonoBehaviour Methods

		private void Start()
		{
			UI.InitializeView();			
		}

		#endregion MonoBehaviour Methods
	}
}
