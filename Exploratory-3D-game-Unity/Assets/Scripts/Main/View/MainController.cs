using UnityEngine;
using zm.Common;

namespace zm.Main
{
	public class MainController : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private MainUI UI;

        private static MainModel Model
        {
            get { return MainModel.Instance; }
        }

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		// Use this for initialization
		private void Start() {}

		#endregion MonoBehaviour Methods

		#region Event Handlers

		public void OnClickBtnLeaderboards() {}

		public void OnClickBtnSettings() {}

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

        }

        /// <summary>
        /// Handler for logging into question screen.
        /// </summary>
        public void OnClickBtnLogin()
        {
            if (Model.IsPasswordValid(UI.PasswordComponent.Password))
            {
                UI.ClosePasswordComponent();
                SceneNavigation.LoadQuestions();
            }
            else
            {
                // Display information that password is not valid
            }
        }

        /// <summary>
        /// Handler for closing Password component without validation.
        /// </summary>
        public void OnClickBtnClosePasswordComponent()
        {
            UI.ClosePasswordComponent();
        }

		#endregion  Event Handlers
	}
}