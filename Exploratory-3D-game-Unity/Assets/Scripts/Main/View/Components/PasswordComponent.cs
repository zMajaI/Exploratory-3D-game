using UnityEngine;
using UnityEngine.UI;

namespace zm.Main
{
    public class PasswordComponent : MonoBehaviour
    {

        #region Fields and Properties

        [SerializeField]
        private InputField inputPassword;

        public string Password
        {
            get
            {
                return inputPassword.text;
            }
        }

        #endregion Fields and Properties
    }
}