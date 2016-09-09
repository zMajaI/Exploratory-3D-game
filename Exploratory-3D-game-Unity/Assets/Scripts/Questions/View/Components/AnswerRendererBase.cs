using UnityEngine;
using System.Collections;

namespace zm.Questioning
{
    public class AnswerRendererBase : MonoBehaviour
    {

        #region Fields and Properties

        protected Answer answer;

        public virtual Answer Answer
        {
            set
            {
                answer = value;
            }

            get
            {
                return answer;
            }
        }

        #endregion Fields and Properties
    }
}