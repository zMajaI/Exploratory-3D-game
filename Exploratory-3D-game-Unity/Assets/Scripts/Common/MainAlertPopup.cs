using System;
using UnityEngine;
using UnityEngine.UI;

namespace zm.Common
{
	public class MainAlertPopup : MonoBehaviour
	{
		#region Public Methods

		public void Show(string text, Action onClickBtnClose = null)
		{
			gameObject.SetActive(true);
			this.text.text = text;
			this.onClickBtnClose = onClickBtnClose;
		}

		#endregion Public Methods

		#region Event Handler

		public void OnClickBtnClose()
		{
			if (onClickBtnClose != null)
			{
				onClickBtnClose();
			}

			gameObject.SetActive(false);
		}

		#endregion Event Handlers

		#region Fields and Properties

		[SerializeField]
		private Text text;

		private Action onClickBtnClose;

		#endregion Fields and Properties
	}
}