using System;
using System.Collections.Generic;
using zm.Util;

namespace zm.Questioning
{
    /// <summary>
    /// Holding collection of questions, used as wrapper to enable serializing/deserializing list of questions by using JSon.
    /// All fields have to be public to be serialized by JsonUtil.
    /// </summary>
    [Serializable]
    public class QuestionsCollection : GenericSerializableCollection<Question>
    {
        #region Public Methods

        /// <summary>
        /// Returns list of questions for passed category.
        /// </summary>
        public List<Question> GetQuestions(QuestionCategory category)
        {
            List<Question> questionsForCategory = new List<Question>();
            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].Category == category)
                {
                    questionsForCategory.Add(Collection[i]);
                }
            }

            questionsForCategory.Sort((a, b) => string.Compare(a.Text, b.Text, StringComparison.OrdinalIgnoreCase));

            return questionsForCategory;
        }

        /// <summary>
        /// Returns dictionary of questions mapped by passed categories.
        /// </summary>
        public Dictionary<QuestionCategory, List<Question>> GetQuestions(QuestionCategory[] categories)
        {
            Dictionary<QuestionCategory, List<Question>> retQuestions = new Dictionary<QuestionCategory, List<Question>>();
            for (int i = 0; i < categories.Length; i++)
            {
                retQuestions.Add(categories[i], GetQuestions(categories[i]));
            }
            return retQuestions;
        }

        #endregion Public Methods
    }
}