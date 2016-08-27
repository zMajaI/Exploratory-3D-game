using System.IO;
using System.Linq;
using UnityEngine;
using zm.Questioning;
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

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Initialize LevelsModel, populate all levels data.
		/// </summary>
		public void Initialize()
		{
			using (StreamReader reader = new StreamReader(LevelsPath))
			{
				levels = JsonUtility.FromJson<LevelsCollection>(reader.ReadToEnd());
			}

			if (CurrentLevel == null)
			{
				CurrentLevel = Levels.Collection.First();
			}
		}

		/// <summary>
		/// Loads all necessary data for current level.
		/// This is done before scene is loaded, so all data will be prepared for populating scene.
		/// </summary>
		public void LoadCurrentLevel()
		{
			CurrentLevel.InitializeQuestions(QuestionsModel.Instance.GetQuestions(CurrentLevel.Categories));
			
		}

		#endregion Public Methods
	}
}