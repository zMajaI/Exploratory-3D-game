using UnityEngine;
using UnityEngine.UI;

namespace zm.Main
{
	public class MainUI : MonoBehaviour
	{
		#region Public Methods

		public void ShowPasswordComponent() {
            passwordComponent.gameObject.SetActive(true);
        }


        internal void ClosePasswordComponent()
        {
            passwordComponent.gameObject.SetActive(false);
        }

		#endregion Public Methods

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

        public PasswordComponent PasswordComponent
        {
            get
            {
                return passwordComponent;
            }
        }
        #endregion Fields and Properties
    }
}