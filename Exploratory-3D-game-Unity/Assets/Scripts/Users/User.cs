using UnityEngine;
using System.Collections;

namespace zm.Users
{
    public class User
    {
        #region Fields and Properties

        /// <summary>
        /// Amount of points that user collected.
        /// </summary>
        public int Points;

        /// <summary>
        /// User name that will be displayed during the game.
        /// </summary>
        public string Name;

        /// <summary>
        /// Level for which we created this user.
        /// </summary>
        public string LevelName;

        #endregion Fields and Properties

        #region Constructor

        public User(string name, string levelName, int points = 0)
        {
            this.Name = name;
            this.LevelName = levelName;
            this.Points = points;
        }

        public User() : this(string.Empty, string.Empty, 0)
        {
        }

        #endregion Constructor
    }
}