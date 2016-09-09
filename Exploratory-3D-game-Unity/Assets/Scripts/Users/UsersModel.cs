using UnityEngine;
using System.Collections;
using zm.Util;
using System.IO;
using System.Collections.Generic;

namespace zm.Users
{
    public class UsersModel : GenericSingleton<UsersModel>
    {
        #region Constants

        /// <summary>
        /// Path of directory that holds all serialized users as individual file.
        /// </summary>
        public static readonly string UsersPath = Application.streamingAssetsPath + "/users.txt";

        #endregion Constants

        #region Fields and Properties

        /// <summary>
        /// Collection of all users in this game.
        /// </summary>
        private UsersCollection users;

        /// <summary>
        /// Flag indicating if this model is initialized.
        /// </summary>
        private bool initialized;

        #endregion Fields and Properties

        #region Public Methods

        public override void Initialize()
        {
            if (initialized) { return; }

            initialized = true;
            using (StreamReader reader = new StreamReader(UsersPath))
            {
                users = JsonUtility.FromJson<UsersCollection>(reader.ReadToEnd());
            }
        }

        public User GetUser(string name)
        {
            for (int i = 0; i < users.Collection.Count; i++)
            {
                if (users.Collection[i].Name.Equals(name))
                {
                    return users.Collection[i];
                }
            }

            User user = new User(name);
            users.Collection.Add(user);
            return user;
        }

        /// <summary>
        /// Returns list of best results per user, for passed level name.
        /// </summary>
        public List<UserResult> GetResultsForLevel(string levelName)
        {
            List<UserResult> results = new List<UserResult>();
            for (int i = 0; i < users.Collection.Count; i++)
            {
                UserResult result = users.Collection[i].GetBestResult(levelName);
                if (result != null)
                {
                    results.Add(result);
                }
            }

            return results;
        }


        /// <summary>
        /// Add this result to user. 
        /// Serialize all users from collection. To ensure that new users will be saved.
        /// </summary>
        public void SaveUserResult(UserResult userResult)
        {
            GetUser(userResult.UserName).results.Collection.Add(userResult);
            string s = JsonUtility.ToJson(users, true);
            using (StreamWriter writer = new StreamWriter(UsersPath, false))
            {
                writer.Write(s);
            }
        }

        #endregion Public Methods
    }
}