using System;
using System.Collections.Generic;

namespace zm.Questioning
{
	/// <summary>
	/// Holding collection of questions, used as wrapper to enable serializing/deserializing list of questions by using JSon.
	/// All fields have to be public to be serialized by JsonUtil.
	/// </summary>
	[Serializable]
	public class QuestionsCollection
	{
		#region Fields and Properties

		public List<Question> Collection;

		#endregion Fields and Properties

		#region Constructor

		public QuestionsCollection()
		{
			Collection = new List<Question>();
		}

		#endregion Constructor

        #region Public Methods

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

        #endregion Public Methods
    }
}