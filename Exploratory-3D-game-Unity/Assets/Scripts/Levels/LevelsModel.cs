using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using zm.Questioning;
using zm.Users;
using zm.Util;

namespace zm.Levels
{
	public class LevelsModel : GenericSingleton<LevelsModel>
	{
		#region Constants

		/// <summary>
		/// Path of directory that holds all serialized levels as individual files
		/// </summary>
		public static readonly string LevelsPath = Application.streamingAssetsPath + "/levels.txt"; //TODO: private

		#endregion Constants

		#region Private Methods

		/// <summary>
		/// Serialize all levels from collection. To ensure that new users will be saved.
		/// </summary>
		private void SaveLevels()
		{
			string s = JsonUtility.ToJson(levels, true);
			using (StreamWriter writer = new StreamWriter(LevelsPath, false))
			{
				writer.Write(s);
			}
		}

		#endregion Private Methods

		#region Fields and Properties

		/// <summary>
		/// List of all levels that exist in this game.
		/// </summary>
		public LevelsCollection levels; //TODO switch this to be private

		/// <summary>
		/// Returns Collection of all levels that exist.
		/// </summary>
		public LevelsCollection Levels
		{
			get { return levels; }
		}

		/// <summary>
		/// Level that is currently selected.
		/// </summary>
		public Level CurrentLevel;

		/// <summary>
		/// Flag indicating if this model is initialized.
		/// </summary>
		private bool initialized;

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Initialize LevelsModel, populate all levels data.
		/// </summary>
        public override void Initialize()
		{
			if (initialized) { return; }

			initialized = true;
			using (StreamReader reader = new StreamReader(LevelsPath))
			{
				levels = JsonUtility.FromJson<LevelsCollection>(reader.ReadToEnd());
			}

			CurrentLevel = Levels.Collection.First();
		}

		/// <summary>
		/// Loads all necessary data for current level.
		/// This is done before scene is loaded, so all data will be prepared for populating scene.
		/// </summary>
		public void LoadCurrentLevel()
		{
			QuestionsModel.Instance.Initialize();

			List<Question> questions = new List<Question>();
			foreach (var category in CurrentLevel.Categories)
			{
				questions.AddRange(QuestionsModel.Instance.GetQuestions(category));
			}
			CurrentLevel.InitializeQuestions(questions);
		}

		#endregion Public Methods
	}
}