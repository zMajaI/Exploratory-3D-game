using UnityEngine;
using System.Collections.Generic;

namespace zm.Users
{
    public class PlayerPrefUsersList
    {
        #region Constants

        private const string ListPrefix = "_list";
        private const string ListPrefixCount = "__list_count";

        #endregion Constants

        #region Fields and Properties

        /// <summary>
        /// Name which will be used for identifying player prefs for this list.
        /// </summary>
        private string name;

        private int count;

        /// <summary>
        /// List of all users that are saved in prefs.
        /// </summary>
        private List<User> users;

        #endregion Fields and Properties

        #region Constructor

        public PlayerPrefUsersList(string name)
        {
            this.name = name;

            // Create list of users - if this list already exists in prefs, read count
            if (PlayerPrefs.HasKey(ListPrefixCount + this.name))
            {
                this.count = PlayerPrefs.GetInt(ListPrefixCount + this.name);
                this.users = new List<User>(this.count);

                // read all users
            }
            else
            {
                // list doesn't exist so we should just initialize count to 0
                this.count = 0;
                PlayerPrefs.SetInt(ListPrefixCount + this.name, this.count);
                this.users = new List<User>(this.count);
            }
            

        }

        #endregion Constructor

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        #endregion Private methods
    }
}