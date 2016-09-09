using System;

namespace zm.Users
{
	[Serializable]
	public class UserResult
	{
		#region Constructor

		public UserResult(string userName, string levelName, int points = 0)
		{
            UserName = userName;
			LevelName = levelName;
			Points = points;
		}

		#endregion Constructor

		#region Public Methods

		public void AddPoints(int points)
		{
			Points += points;
		}

		#endregion Public Methods

		#region Fields and Properties

		/// <summary>
		/// Amount of points that user collected.
		/// </summary>
		public int Points;

        /// <summary>
        /// User to whom these results are 
        /// </summary>
        public string UserName;

		/// <summary>
		/// Level for which we created this user.
		/// </summary>
		public string LevelName;

		/// <summary>
		/// Number of questions that user had opportunity to answer.
		/// </summary>
		public int NumOfAnsweredQuestions;

		#endregion Fields and Properties
	}
}