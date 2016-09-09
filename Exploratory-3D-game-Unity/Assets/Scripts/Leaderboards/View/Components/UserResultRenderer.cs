using UnityEngine;
using UnityEngine.UI;
using zm.Users;

namespace zm.Leaderboards
{
	public class UserResultRenderer : MonoBehaviour
	{
		#region Fields and Properties

		[SerializeField]
		private Text lblPosition;

		[SerializeField]
		private Text lblUserName;

		[SerializeField]
		private Text lblPoints;

		public void Initialize(UserResult userResult, int position)
		{
            lblUserName.text = userResult.UserName;
            lblPoints.text = userResult.Points.ToString();
			lblPosition.text = position.ToString();
		}

		#endregion Fields and Properties
	}
}