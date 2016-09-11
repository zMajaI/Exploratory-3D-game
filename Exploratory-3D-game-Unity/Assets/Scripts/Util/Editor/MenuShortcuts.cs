using System.Collections.Generic;
using UnityEditor;
using zm.Questioning;
using zm.Levels;
using UnityEngine;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace zm.Util.EditorTools
{
	public static class MenuShortcuts
	{
		#region Menu Items

		[MenuItem("zm.QuestionsCollection/Serialize")]
		public static void SerializeQuestions()
		{
            //QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Spells, 1000L, "pitanje",
            //                new List<Answer> {new Answer("pitanje 1", true, 1, "bla"), new Answer("pitanje 1", true, 1, "bla")}, 1, "audio", 100));

            //QuestionsModel.Instance.AddQuestion(new Question(QuestionCategory.Spells, 1000L, "pitanje",
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
	        GameObject[] allGameObject = GameObject.FindGameObjectsWithTag("Positions");
			foreach (var gO in allGameObject)
	        {
		         v3c.Collection.Add(gO.transform.position);
	        }
            level.Positions = v3c;
            level.MaxNumQuestions = 100;
	        level.Name = "Harry Potter";
            level.Categories = new []{QuestionCategory.Spells, QuestionCategory.Potions, QuestionCategory.Hogwarts};
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

        [MenuItem("zm/A")]
        public static void Nesto()
        {

        }

		#endregion Menu Items
	}
}