using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using zm.Util;

namespace zm.Questioning
{
	/// <summary>
	/// This class is responsible for loading/storing QuestionsCollection from file. And providing all available QuestionsCollection.
	/// </summary>
	public class QuestionsModel : GenericSingleton<QuestionsModel>
	{
		#region Constants

		private static readonly string QuestionsPath = Application.streamingAssetsPath + "/questions.txt";

		#endregion Constants

		#region Private Methods

		/// <summary>
		/// Saves all existing QuestionsCollection from collection to file QuestionsPath.
		/// </summary>
		/// <param name="questions"></param>
		private void SaveQuestions()
		{
			string s = JsonUtility.ToJson(questionsCollection, true);
			using (StreamWriter writer = new StreamWriter(QuestionsPath, false))
			{
				writer.Write(s);
			}
		}

		#endregion Private Methods

		#region Fields and Properties

		/// <summary>
		/// Wrapper holding collection of all QuestionsCollection.
		/// </summary>
		private QuestionsCollection questionsCollection = new QuestionsCollection();

		/// <summary>
		/// List of all QuestionsCollection in the system.
		/// </summary>
		public List<Question> Questions
		{
			get { return questionsCollection.Collection; }
		}

		/// <summary>
		/// List of all available categories for QuestionsCollection.
		/// </summary>
		public List<string> Categories { get; private set; }

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Loads all QuestionsCollection from a file that is stored in QuestionsPath.
		/// All QuestionsCollection are serialized using JSon format.
		/// </summary>
		public void Initialize()
		{
			using (StreamReader reader = new StreamReader(QuestionsPath))
			{
				questionsCollection = JsonUtility.FromJson<QuestionsCollection>(reader.ReadToEnd());
			}

			Categories = new List<string>(Enum.GetNames(typeof(QuestionCategory)));
		}

		/// <summary>
		/// Adds new question to existing pool.
		/// All needed resources will be moved to proper location: audio clip.
		/// </summary>
		public void AddQuestion(Question question)
		{
			questionsCollection.Collection.Add(question);
			SaveQuestions();
		}

		/// <summary>
		/// Changes existing question that has passed Id with data from new question.
		/// </summary>
		public void ChangeQuestion(Question question)
		{
			SaveQuestions();
		}

		/// <summary>
		/// Removes question with passed Id.
		/// </summary>
		public void RemoveQuestion(Question question)
		{
			questionsCollection.Collection.Remove(question);
			SaveQuestions();
		}

		/// <summary>
		/// Returns list of Questions for passed category. Questions are sorted by text, ignoring cases.
		/// </summary>
		public List<Question> GetQuestions(QuestionCategory category)
		{
			List<Question> questionsForCategory = new List<Question>();
			for (int i = 0; i < Questions.Count; i++)
			{
				if (Questions[i].Category == category)
				{
					questionsForCategory.Add(Questions[i]);
				}
			}

			questionsForCategory.Sort((a, b) => string.Compare(a.Text, b.Text, StringComparison.OrdinalIgnoreCase));

			return questionsForCategory;
		}

		#endregion Public Methods
	}
}