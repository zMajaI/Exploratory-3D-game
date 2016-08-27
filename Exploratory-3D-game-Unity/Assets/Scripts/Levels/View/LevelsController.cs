using UnityEngine;
using zm.Common;
using zm.Questioning;

namespace zm.Levels
{
	public class LevelsController : MonoBehaviour
	{
		#region Fields and Properties

		private LevelsModel Model
		{
			get { return LevelsModel.Instance; }
		}

		[SerializeField]
		private LeveslUI UI;

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		// Use this for initialization
		private void Start() {}

		// Update is called once per frame
		private void Update()
		{
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
		} //TODO check if this will be needed for time countdown

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
			//TODO load end screen
			SceneNavigation.LoadMain();
		}

		/// <summary>
		/// Handler for click on answer in question menu.
		/// </summary>
		public void OnClickAnswer(Answer answer) {}

		#endregion  Event Handlers
	}
}