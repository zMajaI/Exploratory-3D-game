using UnityEngine;
using zm.Common;
using zm.Levels;
using zm.Main;

namespace zm.End
{
	public class EndController : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private EndUI UI;

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		public void Start()
		{
			UI.Initialize(MainModel.Instance.CurrentUser, LevelsModel.Instance.CurrentLevel);
		}

		#endregion MonoBehaviour Methods

		#region Event Handlers

		/// <summary>
		/// Handler that will be triggered when user clicks on button for Main Menu.
		/// </summary>
		public void OnClickBtnMainMenu()
		{
			SceneNavigation.LoadMain();
		}

		/// <summary>
		/// Handler that will be trigger if user clicks on replay button.
		/// </summary>
		public void OnClickBtnReplay() {}

		#endregion Event Handlers
	}
}