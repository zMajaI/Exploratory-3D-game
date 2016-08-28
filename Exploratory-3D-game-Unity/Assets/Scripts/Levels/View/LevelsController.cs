using UnityEngine;
using zm.Common;
using zm.Main;
using zm.Questioning;
using zm.Util;

namespace zm.Levels
{
	public class LevelsController : MonoBehaviour
	{
		#region Private Methods

		private void CloseAnswerInfo()
		{
			MainModel.Instance.CurrentUser.NumOfAnsweredQuestions++;

			UI.HideQuestion();

			// Remove this question
			UI.RemoveQuestion(currentQuestion);
			UI.UpdateUser(Model.CurrentLevel, MainModel.Instance.CurrentUser);

			Question newQuestion = Model.CurrentLevel.GetQuestion();

			// If there is more question, add new question 
			if (newQuestion != null)
			{
				UI.AddQuestion(newQuestion);
			}

			//Return position from previous question
			Model.CurrentLevel.ReturnPosition(currentQuestion.Position);

			//Check if this is end game
			if (MainModel.Instance.CurrentUser.NumOfAnsweredQuestions == Model.CurrentLevel.NumOfQuestions)
			{
				EndGame();
			}

			currentQuestion = null;
		}

		/// <summary>
		/// Finish this game, either by answering all questions or by quitting. 
		/// </summary>
		private void EndGame()
		{
			Model.AddUser(MainModel.Instance.CurrentUser);
			UI.ShowEndGame(MainModel.Instance.CurrentUser, Model.CurrentLevel);
		}

		#endregion Private Methods

		#region Fields and Properties

		private LevelsModel Model
		{
			get { return LevelsModel.Instance; }
		}

		[SerializeField]
		private LeveslUI UI;

		[SerializeField]
		private Timer timer;

		private Question currentQuestion;

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		// Use this for initialization
		private void Start()
		{
			UI.Initialize(Model.CurrentLevel, MainModel.Instance.CurrentUser);
		}

		// Update is called once per frame
		private void LateUpdate()
		{
			// If user is currently answering some question we should skip all activities. :)
			if (currentQuestion != null)
			{
				UI.UpdateTime(timer.TimeLeft);
				return;
			}

			// Handle Key input for pause menu
			if (Input.GetKeyUp("p"))
			{
				if (UI.PauseMenuShown)
				{
					UI.ClosePauseMenu();
				}
				else
				{
					UI.ShowPauseMenu();
				}
			}

			// Handle mouse click for opening question view
			if (Input.GetMouseButtonUp(0))
			{
				currentQuestion = UI.GetHitQuestion();
				if (currentQuestion != null)
				{
					timer.StartTicking(currentQuestion.TimeLimit, () => OnClickAnswer(null));
					UI.ShowQuestion(currentQuestion, OnClickAnswer);
				}
			}
		}

		#endregion MonoBehaviour Methods

		#region  Event Handlers

		/// <summary>
		/// Handler for click on resume button in Pause Menu.
		/// </summary>
		public void OnClickBtnResume()
		{
			UI.ClosePauseMenu();
		}

		/// <summary>
		/// Handler for click on quit button in Pause Menu.
		/// </summary>
		public void OnClickBtnQuit()
		{
			EndGame();
		}

		/// <summary>
		/// Handler for click on answer in question menu.
		/// </summary>
		public void OnClickAnswer(Answer answer)
		{
			timer.StopTicking();

			if (answer == null)
			{
				UI.MainAlerPopup.Show("Time is up!\nHurry up next time!", CloseAnswerInfo);
			}
			else if (answer.IsCorrect)
			{
				UI.MainAlerPopup.Show("Correct!\nYou gained " + currentQuestion.Points + " points!", CloseAnswerInfo);
				MainModel.Instance.CurrentUser.AddPoints(currentQuestion.Points);
			}
			else
			{
				UI.MainAlerPopup.Show("Wrong!\nYour answer wasn't correct!", CloseAnswerInfo);
			}
		}

		/// <summary>
		/// Handler for click on button Main Menu in end game component. 
		/// </summary>
		public void OnClickBtnMainMenu()
		{
			SceneNavigation.LoadMain();
		}

		/// <summary>
		/// Handler for click on button Replay in end game component.
		/// </summary>
		public void OnBtnClickReplay()
		{
			MainModel.Instance.CreateUser(MainModel.Instance.CurrentUser.Name);
			SceneNavigation.LoadLevel();
		}

		#endregion  Event Handlers
	}
}