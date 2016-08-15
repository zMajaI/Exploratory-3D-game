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
        public int Points { get; private set; }

        /// <summary>
        /// User name that will be displayed during the game.
        /// </summary>
        public string Name { get; private set; }

        #endregion Fields and Properties

        #region Constructor

        public User(string name, int points = 0)
        {
            this.Name = name;
            this.Points = points;
        }

        #endregion Constructor

    }
}