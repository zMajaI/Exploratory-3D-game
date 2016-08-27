using UnityEngine;
using System.Collections.Generic;
using zm.Util;
using System.IO;
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
        public LevelsCollection levels; //TODO swith this to be private

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
        }


        public void LoadLevel(int id)
        {
            for (int i = 0; i < levels.Collection.Count; i++)
            {
                Level level = levels.Collection[i];
                if (level.Id == id)
                {
                    levels.Collection[i].InitializeQuestions(Questioning.QuestionsModel.Instance.GetQuestions(level.Categories));
                }
            }
        }

        #endregion Public Methods

    }
}