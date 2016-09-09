using UnityEngine;
using zm.Common;
using zm.Levels;
using zm.Users;

namespace zm.Leaderboards
{
	public class LeaderboardsController : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private LeaderboadrsUI UI;

		#endregion Fields and Properties

		#region MonoBehaviour Methods

		public void Start()
		{
            UI.Initialize(LevelsModel.Instance.Levels.Collection, UsersModel.Instance.GetResultsForLevel(LevelsModel.Instance.Levels.Collection[0].Name));
		}

		#endregion MonoBehaviour Methods

		#region Event Handlers

		/// <summary>
		/// Handler triggered when user changes level in dropdown.
		/// </summary>
		public void OnValueChangedLevel(int newValue = 0)
		{
			UI.UpdateUsersList(UsersModel.Instance.GetResultsForLevel(LevelsModel.Instance.Levels.Collection[UI.SelectedLevel].Name));
		}

		/// <summary>
		/// Handler for mouse click on button back - returns to Main scene.
		/// </summary>
		public void OnClickBtnBack()
		{
			SceneNavigation.LoadMain();
		}

		#endregion Event Handlers
	}
}