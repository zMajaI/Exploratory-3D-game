using System;
using UnityEngine;
using UnityEngine.UI;
using zm.Levels;
using zm.Users;
using zm.Util;

namespace zm.Main
{
	public class MainUI : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private HorizontalLayoutGroup lstLevels;

		[SerializeField]
		private PasswordComponent passwordComponent;

		#region Prefabs

		[SerializeField]
		private LevelPreviewRenderer levelPreviewRendererPrefab;

		[SerializeField]
		private InputField inputUsername;

		#endregion Prefabs

		/// <summary>
		/// Returns password that user entered in password component.
		/// </summary>
		public string Password
		{
			get { return passwordComponent.Password; }
		}

		/// <summary>
		/// Returns UserName that was entered in textField.
		/// </summary>
		public string UserName
		{
			get { return inputUsername.text; }
		}

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Method used for initialization Main Scene, It's triggered when ever we enter Main scene.
		/// </summary>
		public void Initialize(LevelsCollection levels, Action<LevelPreviewRenderer> onClickHandlerLevelRendere, Level currentlySelectedLevel,
								User currentUser)
		{
			// Initialize list with levels
			lstLevels.transform.Clear();
			foreach (Level level in levels.Collection)
			{
				LevelPreviewRenderer levelRenderer = Instantiate(levelPreviewRendererPrefab);
				levelRenderer.Initialize(level, onClickHandlerLevelRendere);
				levelRenderer.transform.SetParent(lstLevels.transform, false);
			}

			SelectLevel(currentlySelectedLevel);

			// Initialize UserName
			if (currentUser != null)
			{
				inputUsername.text = currentUser.Name;
			}
		}

		/// <summary>
		/// Method deselects previously selected level and marks passed level as selected.
		/// </summary>
		/// <param name="level"></param>
		public void SelectLevel(Level level)
		{
			foreach (Transform levelRendererTransform in lstLevels.transform)
			{
				LevelPreviewRenderer levelRenderer = levelRendererTransform.gameObject.GetComponent<LevelPreviewRenderer>();
				levelRenderer.Selected = levelRenderer.Level == level;
			}
		}

		/// <summary>
		/// Displays Password component.
		/// </summary>
		public void ShowPasswordComponent()
		{
			passwordComponent.gameObject.SetActive(true);
		}

		/// <summary>
		/// Hides Password Component.
		/// </summary>
		public void ClosePasswordComponent()
		{
			passwordComponent.gameObject.SetActive(false);
		}

		#endregion Public Methods
	}
}