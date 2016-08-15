using System;
using System.Collections.Generic;

namespace zm.Questioning
{
	/// <summary>
	/// Wrapped all data needed for one Question. Contains list of answers, where only one answer could be correct.
	/// Each question must have at least two answers.
	/// All fields have to be public to be serialized by JsonUtil.
	/// </summary>
	[Serializable]
	public class Question
	{
		#region Constructor

		private Question(QuestionCategory category, long timeLimit, string text, List<Answer> answers, string audioPath, int points)
		{
			Category = category;
			TimeLimit = timeLimit;
			Text = text;
			Answers = answers;
			Id = ++IdGen;
			AudioPath = audioPath;
			Points = points;
		}

		public Question(QuestionCategory category)
			: this(category, 0L, "", new List<Answer>(), "", 0) {}

		#endregion Constructor

		#region Fields and Properties

        /// <summary>
        /// Used for generating unique ids for this class.
        /// </summary>
        private static int IdGen = 0;

		/// <summary>
		/// Category to which this question belongs.
		/// </summary>
		public QuestionCategory Category;

		/// <summary>
		/// Time limit  for this question, in milliseconds.
		/// </summary>
		public long TimeLimit;

		/// <summary>
		/// Text represents body of question.
		/// </summary>
		public string Text;

		/// <summary>
		/// List of answers, where only one is correct.
		/// </summary>
		public List<Answer> Answers;

		/// <summary>
		/// Each question has unique id. It's used for load/store operations.
		/// </summary>
		public int Id;

		/// <summary>
		/// Path to Audio source for this question.
		/// </summary>
		public string AudioPath;

		/// <summary>
		/// Number of points that will user get if he answers correctly.
		/// </summary>
		public int Points;

		#endregion Field and Properties
	}

	public enum QuestionCategory
	{
		Fruits = 0,
		Vegetables,
		PizdaMaterina
	}
}