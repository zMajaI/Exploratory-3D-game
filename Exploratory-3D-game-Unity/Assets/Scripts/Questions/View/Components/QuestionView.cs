using UnityEngine;
using UnityEngine.UI;
using zm.Util;

namespace zm.Questioning
{
    public class QuestionView : QuestionViewBase
    {
        #region Fields and Properties

        /// <summary>
        /// Populates view for passed question.
        /// </summary>
        public override Question Question
        {
            set
            {
                if (value == null)
                {
                    lblQuestionCategory.text = "Category: " + "";
                    lblQuestionPoints.text = "Points: " + "";
                    lblQuestionTime.text = "Time: " + "";
                    lblQuestionContent.text = "";

                    // remove all children
                    lstAnswers.transform.Clear();
                }
                else
                {

                    lblQuestionCategory.text = "Category: " + value.Category.ToText();
                    lblQuestionPoints.text = "Points: " + value.Points;
                    lblQuestionTime.text = "Time: " + value.TimeLimit;
                    lblQuestionContent.text = value.Text;

                    // remove all children
                    lstAnswers.transform.Clear();

                    for (int i = 0; i < value.Answers.Count; i++)
                    {
                        AnswerRenderer answerRenderer = Instantiate(answerRendererPrefab) as AnswerRenderer;
                        answerRenderer.Answer = value.Answers[i];
                        answerRenderer.transform.SetParent(lstAnswers.transform, false);
                    }
                }
            }
        }

        [SerializeField]
        private Text lblQuestionContent;

        [SerializeField]
        private Text lblQuestionPoints;

        [SerializeField]
        private Text lblQuestionTime;

        #endregion Fields and Properties
    }
}