using System;
using System.Collections.Generic;
using zm.Common;
using zm.Questioning;
using zm.Users;
using zm.Util;

namespace zm.Levels
{
	[Serializable]
	public class Level
	{
		#region Constants

		private static readonly string ImgsPath = "Sprites/Levels/";

		#endregion Constants

		#region Constructor

		public Level()
		{
			Id = ++IdGen;
		}

		#endregion Constructor

		#region Fields and Properties

		/// <summary>
		/// Used for generating unique ids for this class.
		/// </summary>
		private static int IdGen;

		public int Id { get; private set; }

		/// <summary>
		/// All question that user can answer in this level.
		/// Mapped by category: Category --> List<Questions>
		/// </summary>
		private Dictionary<QuestionCategory, List<Question>> questions;

		/// <summary>
		/// List of all possible positions for this level.
		/// </summary>
		public Vector3Collection Positions;

		/// <summary>
		/// Maximal number of questions that can be active in one moment in game.
		/// </summary>
		public int MaxNumQuestions;

		/// <summary>
		/// All categories from which we can take questions.
		/// </summary>
		public QuestionCategory[] Categories;

		/// <summary>
		/// Name that will be displayed for this level.
		/// </summary>
		public string Name;

		/// <summary>
		/// Return path for image that represents this level.
		/// </summary>
		public string ImgPath
		{
			get { return ImgsPath + Name; }
		}

		/// <summary>
		/// Holds collection of all users that played this level. 
		/// </summary>
		public UsersCollection Users;
 
		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Returns random question for passed category.
		/// </summary>
		public Question GetQuestion(QuestionCategory category)
		{
			return questions[category].GetRandom();
		}

		/// <summary>
		/// Initialize all questions for this level.
		/// </summary>
		/// <param name="questions"></param>
		public void InitializeQuestions(Dictionary<QuestionCategory, List<Question>> questions)
		{
			this.questions = questions;
		}

		#endregion Public Methods
	}
}