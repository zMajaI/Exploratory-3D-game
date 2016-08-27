using UnityEngine;
using UnityEngine.UI;

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

		#endregion Fields and Properties

		#region Public Methods

		public void Initialize(Level level) {}

		/// <summary>
		/// Display pause menu.
		/// </summary>
		public void ShowPauseMenu()
		{
			pauseMenu.gameObject.SetActive(true);
		}

		/// <summary>
		/// Hide pause menu.
		/// </summary>
		public void ClosePauseMenu()
		{
			pauseMenu.gameObject.SetActive(false);
		}

		#endregion Public Methods
	}
}