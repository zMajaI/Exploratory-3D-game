using System;
using System.Collections.Generic;
using UnityEngine;
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

		#region Private Methods

		/// <summary>
		/// Returns random position that is available.
		/// </summary>
		/// <returns></returns>
		private Vector3 GetPosition()
		{
			Vector3 position = availablePositions.GetRandom();
			availablePositions.Remove(position);
			return position;
		}

		#endregion Private Methods

		#region Fields and Properties

		/// <summary>
		/// Used for generating unique ids for this class.
		/// </summary>
		private static int IdGen;

		public int Id { get; private set; }

		/// <summary>
		/// All question that user can answer in this level.
		/// </summary>
		private List<Question> questions;

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

		/// <summary>
		/// Number of questions for this level.
		/// </summary>
		public int NumOfQuestions { get; private set; }

		/// <summary>
		/// Represents maximal number of points that user can gain during this level.
		/// </summary>
		public int MaxPoints { get; private set; }

		/// <summary>
		/// Available positions for questions on this level.
		/// </summary>
		private List<Vector3> availablePositions;

		#endregion Fields and Properties

		#region Public Methods

		/// <summary>
		/// Returns random question.
		/// If there is no more questions in queue, it will return null.
		/// </summary>
		public Question GetQuestion()
		{
			Question question = null;
			if (!questions.IsEmpty())
			{
				question = questions.GetRandom();
				questions.Remove(question);
				question.Position = GetPosition();
			}
			return question;
		}

		/// <summary>
		/// Initialize all questions for this level.
		/// </summary>
		/// <param name="questions"></param>
		public void InitializeQuestions(List<Question> questions)
		{
			this.questions = questions;
			NumOfQuestions = questions.Count;
			MaxPoints = 0;
			foreach (Question question in questions)
			{
				MaxPoints += question.Points;
			}
			availablePositions = new List<Vector3>(Positions.Collection);
		}

		/// <summary>
		/// Returns used position to available positions.
		/// </summary>
		/// <param name="position"></param>
		public void ReturnPosition(Vector3 position)
		{
			availablePositions.Add(position);
		}

		#endregion Public Methods

	}
}