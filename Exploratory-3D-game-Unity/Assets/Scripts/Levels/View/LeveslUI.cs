using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

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


		[SerializeField]
		private FirstPersonController fpController;

		/// <summary>
		/// Flag indicating if pause menu is displayed.
		/// </summary>
		public bool PauseMenuShown
		{
			get { return pauseMenu.gameObject.activeInHierarchy; }
		}

		#endregion Fields and Properties

		#region Public Methods

		public void Initialize(Level level) {}

		/// <summary>
		/// Display pause menu.
		/// </summary>
		public void ShowPauseMenu()
		{
			pauseMenu.gameObject.SetActive(true);
			fpController.enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			fpController.m_MouseLook.lockCursor = false;
		}

		/// <summary>
		/// Hide pause menu.
		/// </summary>
		public void ClosePauseMenu()
		{
			pauseMenu.gameObject.SetActive(false);
			fpController.enabled = true;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			fpController.m_MouseLook.lockCursor = true;
		}

		#endregion Public Methods
	}
}