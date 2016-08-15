using System.Collections;
using zm.Util;

namespace zm.Main
{
    public class MainModel : GenericSingleton<MainModel>
    {
        #region Constants

        /// <summary>
        /// Password needed to login into screen for changing questions.
        /// </summary>
        private const string Password = "__Zlokotlokrpica";

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Returns true if password is valid.
        /// </summary>
        public bool IsPasswordValid(string password)
        {
            return password.Equals(Password);
        }

        #endregion Public Methods
    }
}