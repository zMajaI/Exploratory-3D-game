using UnityEngine.SceneManagement;
using zm.Levels;

namespace zm.Common
{
	public static class SceneNavigation
	{
		public static void LoadMain()
		{
			SceneManager.LoadScene("Main");
		}

		public static void LoadQuestions()
		{
			SceneManager.LoadScene("Questions");
		}

		public static void LoadLevel()
		{
			LevelsModel.Instance.LoadCurrentLevel();
			SceneManager.LoadScene("Level");
		}

		public static void LoadEnd()
		{
			SceneManager.LoadScene("End");
		}

		public static void LoadLeaderboards()
		{
			SceneManager.LoadScene("Leaderboards");
		}
	}
}