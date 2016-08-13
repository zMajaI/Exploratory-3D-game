using System.Collections.Generic;
using UnityEditor;
using zm.Questioning;

namespace zm.Util.EditorTools
{
	public static class MenuShortcuts
	{
		#region Menu Items

		[MenuItem("zm.QuestionsCollection/Serialize")]
		public static void SerializeQuestions()
		{
			QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Fruits, 1000L, "pitanje",
							new List<Answer> {new Answer("pitanje 1", true, 1, "bla"), new Answer("pitanje 1", true, 1, "bla")}, 1, "audio", 100));

			QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Fruits, 1000L, "pitanje",
							new List<Answer> { new Answer("pitanje 1", true, 1, "bla"), new Answer("pitanje 1", true, 1, "bla") }, 1, "audio", 100));
		}

		[MenuItem("zm.QuestionsCollection/Deserialize")]
		public static void DeserializeQuestions()
		{
			QuestionsModel.Instance.Initialize();

		}

		#endregion Menu Items
	}
}