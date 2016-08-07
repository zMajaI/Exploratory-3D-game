namespace zm.Questioning
{
    /// <summary>
    /// Class wrapping all data needed for one answer. 
    /// </summary>
    public class Answer
    {
        #region Fields and Properties

        /// <summary>
        /// Answer body, holding text that should be displayed.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Flag indicating if this answer is correct for question where it belongs.
        /// </summary>
        public bool IsCorrect { get; private set; }

        /// <summary>
        /// Unique id for answer, relative to question.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Path to Audio source for this answer.
        /// </summary>
        public string AudioPath { get; private set; }

        #endregion Fields and Properities
    }

}
