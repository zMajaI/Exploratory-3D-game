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
	}
}