using System.Collections.Generic;

namespace Questioning
{
    /// <summary>
    /// Wrapped all data needed for one Question. Contains list of answers, where only one answer could be correct.
    /// Each question must have at least two answers.
    /// </summary>
    public class Question
    {
        #region Fields and Properties

        /// <summary>
        /// Category to which this question belongs.
        /// </summary>
        public QuestionCategory Category { get; private set; }

        /// <summary>
        /// Time limit  for this question, in milliseconds.
        /// </summary>
        public long TimeLimit { get; private set; }

        /// <summary>
        /// Text represents body of question.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// List of answers, where only one is correct.
        /// </summary>
        public List<Answer> Answers { get; private set; }

        /// <summary>
        /// Each question has unique id. It's used for load/store operations.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Path to Audio source for this question.
        /// </summary>
        public string AudioPath { get; private set; }

        /// <summary>
        /// Number of points that will user get if he answers correctly.
        /// </summary>
        public int Points { get; private set; }

        #endregion Field and Properties
    }

    public enum QuestionCategory
    {
        Fruits = 0,
        Vegetables
    }

}
