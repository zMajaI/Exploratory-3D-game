using UnityEngine;
using zm.Common;
using zm.Main;
using zm.Questioning;
using zm.Users;
using zm.Util;

namespace zm.Levels
{
	public class LevelsController : MonoBehaviour
	{
		#region Private Methods

		private void CloseAnswerInfo()
		{
			MainModel.Instance.CurrentUserResult.NumOfAnsweredQuestions++;

			UI.HideQuestion();

			// Remove this question
			UI.RemoveQuestion(currentQuestion);
			UI.UpdateUser(Model.CurrentLevel, MainModel.Instance.CurrentUserResult);

			Question newQuestion = Model.CurrentLevel.GetQuestion();

			// If there is more question, add new question 
			if (newQuestion != null)
			{
				UI.AddQuestion(newQuestion);
			}

			//Return position from previous question
			Model.CurrentLevel.ReturnPosition(currentQuestion.Position);

			//Check if this is end game
			if (MainModel.Instance.CurrentUserResult.NumOfAnsweredQuestions == Model.CurrentLevel.NumOfQuestions)
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
            UsersModel.Instance.SaveUserResult(MainModel.Instance.CurrentUserResult);
            UI.ShowEndGame(MainModel.Instance.CurrentUserResult, Model.CurrentLevel);
		}

		#endregion Private Methods

		#region Fields and Properties

		private LevelsModel Model
		{
			get { return LevelsModel.Instance; }
		}

		[SerializeField]
		private LevelsUI UI;

		[SerializeField]
		private Timer timer;

		private Question currentQuestion;

        /// <summary>
        /// Flag indicating if user is currently in pause mode.
        /// </summary>
        private bool pause;

        /// <summary>
        /// Flag indicating if user is currently in questioning mode.
        /// </summary>
        private bool questioning;

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		// Use this for initialization
		private void Start()
		{
			UI.Initialize(Model.CurrentLevel, MainModel.Instance.CurrentUserResult);
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
			if (Input.GetKeyUp("p") && currentQuestion == null)
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
            if (Input.GetMouseButtonUp(0) && !UI.PauseMenuShown)
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
                UI.MainAlerPopup.Show("Well done!\n" + currentQuestion.Points + " points for Gryffindor!", CloseAnswerInfo);
				MainModel.Instance.CurrentUserResult.AddPoints(currentQuestion.Points);
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
            MainModel.Instance.CreateUserResult(MainModel.Instance.CurrentUser.Name, Model.CurrentLevel.Name);
			SceneNavigation.LoadLevel();
		}

		#endregion  Event Handlers
	}
}