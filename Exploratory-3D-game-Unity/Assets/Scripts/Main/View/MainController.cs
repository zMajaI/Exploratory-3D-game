using UnityEngine;
using zm.Common;

namespace zm.Main
{
    public class MainController : MonoBehaviour
    {
        #region MonoBehaviour Methods

        private void Start()
        {
            PlayerPrefs.DeleteAll();
            Application.targetFrameRate = 90;
            Model.Initialize();
            UI.Initialize(Model.Levels, OnClickLevelRenderer, Model.CurrentlySelectedLevel, Model.CurrentUser);
        }

        #endregion MonoBehaviour Methods

        #region Fields and Properties

        [SerializeField]
        private MainUI UI;

        private static MainModel Model
        {
            get { return MainModel.Instance; }
        }

        #endregion Fields and Properties

        #region Event Handlers

        /// <summary>
        /// Handler for click on Leaderboards button.
        /// </summary>
        public void OnClickBtnLeaderboards()
        {
            SceneNavigation.LoadLeaderboards();
        }

        /// <summary>
        /// Handler for click on questions button.
        /// </summary>
        public void OnClickBtnQuestions()
        {
            UI.ShowPasswordComponent();
        }

        /// <summary>
        /// Handler for starting game. Loads selected level.
        /// </summary>
        public void OnClickBtnStart()
        {
            Model.CreateUserResult(UI.UserName, Model.CurrentlySelectedLevel.Name);
            SceneNavigation.LoadLevel();
        }

        /// <summary>
        /// Handler for logging into question screen.
        /// </summary>
        public void OnClickBtnLogin()
        {
            if (Model.IsPasswordValid(UI.Password))
            {
                UI.ClosePasswordComponent();
                SceneNavigation.LoadQuestions();
            }
            else
            {
                UI.MainAlerPopup.Show("Wrong Password!\nTry again!");
            }
        }

        /// <summary>
        /// Handler for closing Password component without validation.
        /// </summary>
        public void OnClickBtnClosePasswordComponent()
        {
            UI.ClosePasswordComponent();
        }

        /// <summary>
        /// Handler that should be triggered when
        /// </summary>
        /// <param name="renderer"></param>
        private void OnClickLevelRenderer(LevelPreviewRenderer renderer)
        {
            if (renderer.Level != Model.CurrentlySelectedLevel)
            {
                Model.CurrentlySelectedLevel = renderer.Level;
                UI.SelectLevel(Model.CurrentlySelectedLevel);
            }
        }

        /// <summary>
        /// Handler that will be triggered when ever user changes his/her name in input component.
        /// </summary>
        public void OnEditEndUserNameInput()
        {
            Model.CreateUserResult(UI.UserName, Model.CurrentlySelectedLevel.Name);
        }

        #endregion  Event Handlers
    }
}