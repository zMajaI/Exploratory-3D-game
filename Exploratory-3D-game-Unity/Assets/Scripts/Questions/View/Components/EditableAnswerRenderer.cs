using UnityEngine;
using UnityEngine.UI;

namespace zm.Questioning
{
	public class EditableAnswerRenderer : MonoBehaviour
	{
		#region Public Methods

		/// <summary>
		/// Records all changes from the view to Answer
		/// </summary>
		public void RecordAnswer()
		{
			answer.Text = inputAnswerText.text;
			answer.IsCorrect = toggleIsCorrect.isOn;
		}

		#endregion Public Methods

		#region Fields and Properties

		private Answer answer;

		public Answer Answer
		{
			set
			{
				answer = value;
				inputAnswerText.text = value.Text;
				toggleIsCorrect.isOn = value.IsCorrect;
			}

			get { return answer; }
		}

		[SerializeField]
		private InputField inputAnswerText;

		[SerializeField]
		private Toggle toggleIsCorrect;

		#endregion Fields and Properties
	}
}