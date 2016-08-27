using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using zm.Common;
using zm.Questioning;
using zm.Users;
using zm.Util;

namespace zm.Levels
{
	public class LeveslUI : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private Text lblUserName;

		[SerializeField]
		private Text lblPoints;

		[SerializeField]
		private Text lblNumOfQuestions;

		[SerializeField]
		private GameObject pauseMenu;

		[SerializeField]
		private FirstPersonController fpController;

		#region Question

		[SerializeField]
		private GameObject questionComponent;

		[SerializeField]
		private Text lblQuestion;

		[SerializeField]
		private Text lblTimer;

		[SerializeField]
		private VerticalLayoutGroup lstAnswers;

		[SerializeField]
		private AnswerRenderer answerRendererPrefab;

		[SerializeField]
		public MainAlerPopup MainAlerPopup;

		#endregion Question

		/// <summary>
		/// Flag indicating if pause menu is displayed.
		/// </summary>
		public bool PauseMenuShown
		{
			get { return pauseMenu.gameObject.activeInHierarchy; }
		}

		#endregion Fields and Properties

		#region Public Methods

		public void Initialize(Level level, User user)
		{
			lblUserName.text = user.Name;
			lblPoints.text = user.Points.ToString();
			lblNumOfQuestions.text = user.NumOfAnsweredQuestions + "/" + level.MaxNumQuestions;
		}

		/// <summary>
		/// Display pause menu.
		/// </summary>
		public void ShowPauseMenu()
		{
			pauseMenu.gameObject.SetActive(true);
			ShowCursor();
		}

		/// <summary>
		/// Hide pause menu.
		/// </summary>
		public void ClosePauseMenu()
		{
			pauseMenu.gameObject.SetActive(false);
			HideCursor();
		}

		/// <summary>
		/// Display component for passed question. Second parameter represents callback that should be triggered when user clicks on any
		/// answer.
		/// </summary>
		public void ShowQuestion(Question question, Action<Answer> onClickAnswerHandler)
		{
			questionComponent.gameObject.SetActive(true);

			lblQuestion.text = question.Text;
			// Initialize list with levels
			lstAnswers.transform.Clear();
			foreach (Answer answer in question.Answers)
			{
				AnswerRenderer answerRenderer = Instantiate(answerRendererPrefab);
				answerRenderer.Initialize(answer, onClickAnswerHandler);
				answerRenderer.transform.SetParent(lstAnswers.transform, false);
			}

			ShowCursor();
		}

		public void HideQuestion()
		{
			questionComponent.gameObject.SetActive(false);
			HideCursor();
		}

		#endregion Public Methods

		#region Private Methods

		private void ShowCursor()
		{
			fpController.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			fpController.m_MouseLook.lockCursor = false;
		}

		private void HideCursor()
		{
			fpController.enabled = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			fpController.m_MouseLook.lockCursor = true;
		}

		#endregion Private Methoids
	}
}