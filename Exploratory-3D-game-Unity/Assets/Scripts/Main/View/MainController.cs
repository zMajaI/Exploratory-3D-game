using UnityEngine;
using zm.Common;

namespace zm.Main
{
	public class MainController : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private MainUI UI;

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
			//TODO display passwor shit
			SceneNavigation.LoadQuestions();
		}

		#endregion  Event Handlers
	}
}