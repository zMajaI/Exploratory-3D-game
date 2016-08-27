using System;
using UnityEngine;
using UnityEngine.UI;
using zm.Questioning;

namespace zm.Levels
{
	public class AnswerRenderer : MonoBehaviour
	{
		#region Public Methods

		/// <summary>
		/// Initialize component and populate view.
		/// </summary>
		public void Initialize(Answer answer, Action<Answer> onClickHandler)
		{
			Answer = answer;
			onClickRenderer = onClickHandler;
			lblAnswer.text = answer.Text;
		}

		#endregion Public Methods

		#region Event Handlers

		/// <summary>
		/// Click handler for this renderer.
		/// </summary>
		public void OnClickHandler()
		{
			onClickRenderer(Answer);
		}

		#endregion Event Handlers

		#region Fields and Properties

		[SerializeField]
		private Text lblAnswer;

		public Answer Answer { get; private set; }

		/// <summary>
		/// Callback that should be triggered when user clicks on answer.
		/// </summary>
		private Action<Answer> onClickRenderer;

		#endregion Fields and Properties
	}
}