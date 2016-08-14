using UnityEngine.SceneManagement;

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
	}
}