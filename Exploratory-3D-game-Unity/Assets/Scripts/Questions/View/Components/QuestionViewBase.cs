using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace zm.Questioning
{
    public abstract class QuestionViewBase : MonoBehaviour
    {

        #region Fields and Properties

        private Question question;

        /// <summary>
        /// Populates view for passed question.
        /// </summary>
        public virtual Question Question
        {
            set
            {
                question = value;
            }
            get
            {
                return question;
            }
        }

        [SerializeField]
        protected VerticalLayoutGroup lstAnswers;

        [SerializeField]
        protected Text lblQuestionCategory;

        #region Prefabs

        [SerializeField]
        protected AnswerRendererBase answerRendererPrefab;

        #endregion Prefabs

        #endregion Fields and Properties
    }
}