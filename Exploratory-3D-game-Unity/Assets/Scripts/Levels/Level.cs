using UnityEngine;
using System.Collections.Generic;
using zm.Questioning;
using zm.Util;

namespace zm.Levels
{
    public class Level
    {
        #region Fields and Properties

        /// <summary>
        /// Used for generating unique ids for this class.
        /// </summary>
        private static int IdGen = 0;

        public int Id { get; private set; }

        /// <summary>
        /// All question that user can answer in this level.
        /// </summary>
        public QuestionsCollection Questions { get; private set; }

        #endregion Fields and Properties

        #region Constructor

        public Level(QuestionsCollection questions)
        {
            this.Questions = questions;
            this.Id = ++IdGen;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Returns random question for passed category.
        /// </summary>
        public Question GetQuestion(QuestionCategory category)
        {
            return Questions.GetQuestions(category).GetRandom();
        }

        #endregion Public Methods
    }
}
