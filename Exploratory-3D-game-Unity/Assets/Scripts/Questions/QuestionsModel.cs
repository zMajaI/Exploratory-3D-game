using System.Collections.Generic;
using UnityEngine;

namespace Questioning
{
    /// <summary>
    /// This class is responsible for loading/storing questions.
    /// Question format in file:
    /// start_question Id
    /// Category
    /// TimeLimit
    /// AudioPath
    /// Text
    /// Points
    /// start_answer Id
    /// Text
    /// IsCorrect
    /// AudioPath
    /// end_answer Id
    /// end_question Id
    /// </summary>
    public class QuestionsModel
    {
        #region Constants

        private static string QuestionsPath = Application.streamingAssetsPath + "/questions.txt";

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Loads all questions from a file that is stored in QuestionsPath.
        /// If file doesn't exist or we don't have permissions to read it, exception will be thrown.
        /// Also if questions are not in good format exception will occur. 
        /// </summary>
        public List<Question> LoadQuestions()
        {
            List<Question> questions = new List<Question>();

            return questions;
        }

        /// <summary>
        /// Adds new question to existing pool. 
        /// All needed resources will be moved to proper location: audio clip.
        /// </summary>
        public void AddQuestion(Question question)
        {

        }

        /// <summary>
        /// Changes existing question that has passed Id with data from new question.
        /// </summary>
        public void ChangeQuestion(Question question, int id)
        {

        }

        /// <summary>
        /// Removes question with passed Id. 
        /// </summary>
        public void RemoveQuestion(int id)
        {

        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
