using UnityEngine;
using UnityEngine.UI;
using zm.Users;

namespace zm.Leaderboards
{
	public class UserRenderer : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private Text lblPosition;

		[SerializeField]
		private Text lblUserName;

		[SerializeField]
		private Text lblPoints;

		public void Initialize(User user, int position)
		{
			lblUserName.text = user.Name;
			lblPoints.text = user.Points.ToString();
			lblPosition.text = position.ToString();
		}

		#endregion Fields and Properties
	}
}