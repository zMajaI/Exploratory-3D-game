using System;

namespace zm.Users
{
    [Serializable]
    public class User
    {
        #region Constructor

        public User(string name, string levelName = "", int points = 0)
        {
            Name = name;
            results = new UserResultsCollection();
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Returns best results for passed level. If user didn't play level - it will return null.
        /// </summary>
        public UserResult GetBestResult(string levelName)
        {
            UserResult bestResult = null;
            for (int i = 0; i < results.Collection.Count; i++)
            {
                if (results.Collection[i].LevelName.Equals(levelName) && (bestResult == null || bestResult.Points < results.Collection[i].Points))
                {
                    bestResult = results.Collection[i];
                }
            }

            return bestResult;
        }

        #endregion Public Methods

        #region Fields and Properties

        /// <summary>
        /// User name that will be displayed during the game.
        /// </summary>
        public string Name;

        /// <summary>
        /// List of all results for this user, each holds level name.
        /// </summary>
        public UserResultsCollection results;

        #endregion Fields and Properties
    }
}