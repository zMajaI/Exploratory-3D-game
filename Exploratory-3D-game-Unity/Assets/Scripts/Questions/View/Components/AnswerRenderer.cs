using UnityEngine;
using UnityEngine.UI;

namespace zm.Questioning
{
    public class AnswerRenderer : AnswerRendererBase
	{
		#region Fields and Properties

		public override Answer Answer
		{
			set
			{
				lblAnswerText.text = value.Text;
				lblAnswerCorrect.text = value.IsCorrect ? "Correct" : "Wrong";
			}
		}

		[SerializeField]
		private Text lblAnswerText;

		[SerializeField]
		private Text lblAnswerCorrect;

		#endregion Fields and Properties

	}
}