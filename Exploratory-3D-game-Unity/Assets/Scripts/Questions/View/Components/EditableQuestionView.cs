using UnityEngine;
using UnityEngine.UI;
using zm.Util;

namespace zm.Questioning
{
	public class EditableQuestionView : MonoBehaviour
	{
		#region Fields and Properties

		/// <summary>
		/// Populates view for passed question.
		/// </summary>
		public Question Question
		{
			set
			{
				//lblQuestionCategory.text = "Category: " + value.Category.ToText();
				//lblQuestionPoints.text = "Points: " + value.Points;
				//lblQuestionTime.text = "Time: " + value.TimeLimit;
				//lblQuestionContent.text = value.Text;

				//// remove all children
				//lstAnswers.transform.Clear();

				//for (int i = 0; i < value.Answers.Count; i++)
				//{
				//	AnswerRenderer answerRenderer = Instantiate(answerRendererPrefab);
				//	answerRenderer.Answer = value.Answers[i];
				//	answerRenderer.transform.SetParent(lstAnswers.transform, false);
				//}
			}
		}

		[SerializeField]
		private Text lblQuestionContent;

		[SerializeField]
		private Text lblQuestionPoints;

		[SerializeField]
		private Text lblQuestionTime;

		[SerializeField]
		private Text lblQuestionCategory;

		[SerializeField]
		private VerticalLayoutGroup lstAnswers;

		#region Prefabs

		[SerializeField]
		private AnswerRenderer answerRendererPrefab;

		#endregion Prefabs

		#endregion Fields and Properties
	}
}
