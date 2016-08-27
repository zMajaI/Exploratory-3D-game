using System.Linq;
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
		/// User that is currently active in the game.
		/// </summary>
		public User CurrentUser;

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
		public void Initialize()
		{
			LevelsModel.Instance.Initialize();
		}

		/// <summary>
		/// Creates user with passed username for currently selected level.
		/// </summary>
		/// <param name="userName"></param>
		public void CreateUser(string userName)
		{
			CurrentUser = new User(userName, CurrentlySelectedLevel.Name);
		}

		#endregion Public Methods
	}
}