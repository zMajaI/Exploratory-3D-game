using UnityEngine;
using UnityEngine.UI;
using zm.Util;

namespace zm.Questioning
{
	/// <summary>
	/// Component that represents one question that is either newly created or existing but modified.
	/// </summary>
	public class EditableQuestionView : MonoBehaviour
	{
		#region Fields and Properties

		private Question question;

		/// <summary>
		/// Populates view for passed question.
		/// </summary>
		public Question Question
		{
			set
			{
				question = value;
				lblQuestionCategory.text = "Category: " + value.Category.ToText();
				inputQuestionPoints.text = value.Points.ToString();
				inputQuestionTime.text = value.TimeLimit.ToString();
				inputQuestionContent.text = value.Text;

				// remove all children
				lstAnswers.transform.Clear();

				for (int i = 0; i < value.Answers.Count; i++)
				{
					AddAnswer(value.Answers[i]);
				}
			}
			get { return question; }
		}

		[SerializeField]
		private InputField inputQuestionContent;

		[SerializeField]
		private InputField inputQuestionPoints;

		[SerializeField]
		private InputField inputQuestionTime;

		[SerializeField]
		private Text lblQuestionCategory;

		[SerializeField]
		private VerticalLayoutGroup lstAnswers;

		[SerializeField]
		private ToggleGroup toggleGroupAnswers;
		
		#region Prefabs

		[SerializeField]
		private EditableAnswerRenderer answerRendererPrefab;

		#endregion Prefabs

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Records all changes from the view to Question.
		/// </summary>
		public void RecordQuestion()
		{
			question.Text = inputQuestionContent.text;
			question.Points = int.Parse(inputQuestionPoints.text);
			question.TimeLimit = long.Parse(inputQuestionTime.text);

			foreach (Transform answerView in lstAnswers.transform)
			{
				EditableAnswerRenderer answerRenderer = answerView.gameObject.GetComponent<EditableAnswerRenderer>();
				answerRenderer.RecordAnswer();
			}
		}

		/// <summary>
		/// Creates new view for passed answer.
		/// </summary>
		public void AddAnswer(Answer answer)
		{
			EditableAnswerRenderer answerRenderer = Instantiate(answerRendererPrefab);
			answerRenderer.Answer = answer;
			answerRenderer.transform.SetParent(lstAnswers.transform, false);
			answerRenderer.SetToggleGroup(toggleGroupAnswers);
		}

		#endregion Public Methods
	}
}