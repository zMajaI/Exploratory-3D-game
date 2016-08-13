using System;

namespace zm.Questioning
{
    /// <summary>
    /// Class wrapping all data needed for one answer. 
    /// All fields have to be public to be serialized by JsonUtil.
    /// </summary>
    [Serializable]
    public class Answer
	{
		#region Constructor

		public Answer(string text, bool isCorrect, int id, string audioPath)
	    {
		    Text = text;
		    IsCorrect = isCorrect;
		    Id = id;
		    AudioPath = audioPath;
	    }

		#endregion Constructor

		#region Fields and Properties

		/// <summary>
	    /// Answer body, holding text that should be displayed.
	    /// </summary>
	    public string Text;

	    /// <summary>
	    /// Flag indicating if this answer is correct for question where it belongs.
	    /// </summary>
	    public bool IsCorrect;

	    /// <summary>
	    /// Unique id for answer, relative to question.
	    /// </summary>
	    public int Id;

	    /// <summary>
	    /// Path to Audio source for this answer.
	    /// </summary>
	    public string AudioPath;

	    #endregion Fields and Properities
	}

}
