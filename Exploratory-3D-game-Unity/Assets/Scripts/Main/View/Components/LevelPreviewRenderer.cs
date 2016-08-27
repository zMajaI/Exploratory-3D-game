using System;
using UnityEngine;
using UnityEngine.UI;
using zm.Levels;

namespace zm.Main
{
	public class LevelPreviewRenderer : MonoBehaviour
	{
		#region Constants

		/// <summary>
		/// Color that will be used for sprites when this renderer is not selected in list.
		/// </summary>
		private static readonly Color NotSelectedColor = new Color(1f, 1f, 1f, 0.65f);

		/// <summary>
		/// Color that will be used for sprites when this renderer is selected in list.
		/// </summary>
		private static readonly Color SelectedColor = Color.white;

		#endregion Constans

		#region Fields and Properties

		[SerializeField]
		private Image img;

		[SerializeField]
		private Text lblName;

		/// <summary>
		/// Handler that should be trigger when we detect mouse click on this renderer.
		/// </summary>
		private Action<LevelPreviewRenderer> onClickHandler;

		/// <summary>
		/// Flag indicating if this level is currently selected in the list.
		/// </summary>
		public bool Selected
		{
			set
			{
				if (value)
				{
					img.color = SelectedColor;
				}
				else
				{
					img.color = NotSelectedColor;
				}
			}
		}

		public Level Level { get; private set; }

		#endregion Fields and Properties

		#region Public Methos

		/// <summary>
		/// Initialize level and populate view.
		/// </summary>
		public void Initialize(Level level, Action<LevelPreviewRenderer> handler)
		{
			img.sprite = Resources.Load<Sprite>(level.ImgPath);
			lblName.text = level.Name;
			onClickHandler = handler;
			Level = level;
		}

		/// <summary>
		/// Handler that will be triggered when user clicks on this item in the list. 
		/// </summary>
		public void OnClickRenderer()
		{
			onClickHandler(this);
		}

		#endregion Public Methods
	}
}