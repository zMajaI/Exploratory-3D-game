using zm.Levels;
using zm.Users;
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

		#region Fields and Properties

		/// <summary>
		/// User Result that is currently active in the game.
		/// </summary>
		public UserResult CurrentUserResult;

        public User CurrentUser
        {
            get
            {
                if (CurrentUserResult != null)
                {
                    return UsersModel.Instance.GetUser(CurrentUserResult.UserName);
                }

                return null;
            }
        }
		/// <summary>
		/// Returns collection of all available levels.
		/// </summary>
		public LevelsCollection Levels
		{
			get { return LevelsModel.Instance.Levels; }
		}

		/// <summary>
		/// Returns currently selected Level.
		/// </summary>
		public Level CurrentlySelectedLevel
		{
			get { return LevelsModel.Instance.CurrentLevel; }
			set { LevelsModel.Instance.CurrentLevel = value; }
		}

		/// <summary>
		/// Flag indicating if this model is initialized.
		/// </summary>
		private bool initialized;

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Returns true if password is valid.
		/// </summary>
		public bool IsPasswordValid(string password)
		{
			return password.Equals(Password);
		}

		/// <summary>
		/// Initialize all necessary data for Main Scene. This includes initialization of other models: LevelsModel.
		/// </summary>
        public override void Initialize()
		{
			if(initialized) return;

			initialized = true;
            UsersModel.Instance.Initialize();
			LevelsModel.Instance.Initialize();
		}

		/// <summary>
		/// Creates user with passed user-name for currently selected level.
		/// </summary>
		/// <param name="userName"></param>
		public void CreateUserResult(string userName, string levelName)
		{
            CurrentUserResult = new UserResult(userName, levelName);
		}

		#endregion Public Methods
	}
}