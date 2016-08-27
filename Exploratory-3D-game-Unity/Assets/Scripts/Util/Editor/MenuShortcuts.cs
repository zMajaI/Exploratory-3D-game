using System.Collections.Generic;
using UnityEditor;
using zm.Questioning;
using zm.Levels;
using UnityEngine;
using System.IO;

namespace zm.Util.EditorTools
{
	public static class MenuShortcuts
	{
		#region Menu Items

		[MenuItem("zm.QuestionsCollection/Serialize")]
		public static void SerializeQuestions()
		{
            //QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Fruits, 1000L, "pitanje",
            //                new List<Answer> {new Answer("pitanje 1", true, 1, "bla"), new Answer("pitanje 1", true, 1, "bla")}, 1, "audio", 100));

            //QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Fruits, 1000L, "pitanje",
            //                new List<Answer> { new Answer("pitanje 1", true, 1, "bla"), new Answer("pitanje 1", true, 1, "bla") }, 1, "audio", 100));
		}

		[MenuItem("zm.QuestionsCollection/Deserialize")]
		public static void DeserializeQuestions()
		{
			QuestionsModel.Instance.Initialize();

		}

        [MenuItem("zm.LevelssCollection/Serialize")]
        public static void SerializeLevel()
        {
            LevelsCollection collection = new LevelsCollection();
            var level = new Level();
            var v3c = new Common.Vector3Collection();
            v3c.Collection.AddRange(new List<Vector3> { Vector3.zero, Vector3.up });
            level.Positions = v3c;
            level.MaxNumQuestions = 10;
	        level.Name = "Nikola";
            level.Categories = new QuestionCategory[]{QuestionCategory.Fruits, QuestionCategory.PizdaMaterina};
            collection.Collection.Add(level);
            LevelsModel.Instance.levels = collection;


            string s = JsonUtility.ToJson(collection, true);
            using (StreamWriter writer = new StreamWriter(LevelsModel.LevelsPath, false))
            {
                writer.Write(s);
            }

        }

        [MenuItem("zm.LevelssCollection/Deserialize")]
        public static void DeserializeLevel()
        {
            LevelsModel.Instance.Initialize();

        }

		#endregion Menu Items
	}
}