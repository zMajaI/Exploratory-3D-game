using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using zm.Common;
using zm.Questioning;
using zm.Users;
using zm.Util;

namespace zm.Levels
{
	public class LevelsUI : MonoBehaviour
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

		[SerializeField]
		private GameObject Wand;

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
		public MainAlertPopup MainAlerPopup;

		[SerializeField]
		private QuestionableObjectView questionableObjectViewPrefab;

		/// <summary>
		/// Dictionary holding all questions mapped by id.
		/// </summary>
		private readonly Dictionary<int, QuestionableObjectView> questionableObjectViews = new Dictionary<int, QuestionableObjectView>();

		#endregion Question

		/// <summary>
		/// Flag indicating if pause menu is displayed.
		/// </summary>
		public bool PauseMenuShown
		{
			get { return pauseMenu.gameObject.activeInHierarchy; }
		}

		#region End Game

		[SerializeField]
		private Text lblUserNameEndGame;

		[SerializeField]
		private Text lblPointsEndGame;

		[SerializeField]
		private GameObject endGameComponent;

		#endregion End Game

		#endregion Fields and Properties

		#region Public Methods

        public void Initialize(Level level, UserResult userResult)
		{
            UpdateUser(level, userResult);
			for (int i = 0; i < level.MaxNumQuestions; i++)
			{
				AddQuestion(level.GetQuestion());
			}
		}

		public void UpdateUser(Level level, UserResult userResult)
		{
            lblUserName.text = userResult.UserName;
            lblPoints.text = userResult.Points.ToString();
            lblNumOfQuestions.text = userResult.NumOfAnsweredQuestions + "/" + level.NumOfQuestions;
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
			UpdateTime(question.TimeLimit);
			ShowCursor();
		}

		public void UpdateTime(float time)
		{
			lblTimer.text = (Math.Round(time) < 0 ? 0 : Math.Round(time)).ToString();
		}

		public void HideQuestion()
		{
			questionComponent.gameObject.SetActive(false);
			HideCursor();
		}

		public void AddQuestion(Question question)
		{
			QuestionableObjectView view = Instantiate(questionableObjectViewPrefab);
			view.Initialize(question);
			view.transform.position = question.Position;
			questionableObjectViews.Add(question.Id, view);
		}

		public void RemoveQuestion(Question question)
		{
			QuestionableObjectView view = questionableObjectViews[question.Id];
			questionableObjectViews.Remove(question.Id);
			Destroy(view.gameObject);
		}

		/// <summary>
		/// Returns Question that was hit. If no question is hit - it will return null.
		/// Also if question is not triggered hit will be treated as miss.
		/// </summary>
		/// <returns></returns>
		public Question GetHitQuestion()
		{
			Question question = null;

			RaycastHit hit;
			Ray ray = new Ray(Wand.transform.position, Wand.transform.TransformDirection(Vector3.forward));

			if (Physics.Raycast(ray, out hit, int.MaxValue))
			{
				if (hit.collider != null && hit.transform.gameObject.tag.Equals(QuestionableObjectView.QuestionsTag))
				{
					QuestionableObjectView view = hit.transform.gameObject.GetComponent<QuestionableObjectView>();
					if (view == null)
					{
						view = hit.transform.gameObject.GetComponentInParent<QuestionableObjectView>();
					}

					if (view.IsTriggered)
					{
						question = view.Question;
					}
				}
			}

			return question;
		}

		/// <summary>
		/// Display end game component with basic information from last game.
		/// </summary>
		public void ShowEndGame(UserResult userResult, Level level)
		{
            lblUserNameEndGame.text = userResult.UserName;
            lblPointsEndGame.text = "Points: " + userResult.Points + "/" + level.MaxPoints;
			endGameComponent.gameObject.SetActive(true);
			ShowCursor();
		}

		#endregion Public Methods

		#region Private Methods

		/// <summary>
		/// Unlocks cursor and disables player controller.
		/// </summary>
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