using UnityEngine;
using UnityEngine.UI;
using zm.Levels;
using zm.Users;

namespace zm.End
{
	public class EndUI : MonoBehaviour
	{
		#region Public Methods

		/// <summary>
		/// Method used for initialization of End Scene view.
		/// </summary>
		public void Initialize(User user, Level level) {}

		#endregion Public Methods

		#region Fields and Properties

		[SerializeField]
		private Text lblUserName;

		[SerializeField]
		private Text lblPoints;

		[SerializeField]
		private Text lblLeaderboardPosition;

		#endregion Fields and Properties
	}
}