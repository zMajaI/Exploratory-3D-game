﻿using System.Collections.Generic;
using UnityEngine;
using zm.Common;
using zm.Util;

namespace zm.Questioning
{
	/// <summary>
	/// Class used for populating QuestionsCollection scene and communicating with QuestionsModel.
	/// </summary>
	public class QuestionController : MonoBehaviour
	{
		#region MonoBehaviour Methods

		private void Start()
		{
			Model.Initialize();
			UI.Initialize(Model.GetQuestions(QuestionCategory.Spells), Model.Categories);
		}

		#endregion MonoBehaviour Methods

		#region Fields and Properties

		private static QuestionsModel Model
		{
			get { return QuestionsModel.Instance; }
		}

		[SerializeField]
		private QuestionsUI UI;

		#endregion Fields and Properties

		#region Event Handlers

		/// <summary>
		/// Handler for adding new question to selected category.
		/// </summary>
		public void OnClickBtnAdd()
		{
			UI.InitializeEditableQuestionView(new Question(UI.SelectedCategory));
		}

		/// <summary>
		/// Handler for click on remove question button.
		/// </summary>
		public void OnClickBtnRemove()
		{
			// remove question
			List<Question> questions = Model.GetQuestions(UI.SelectedCategory);
			Model.RemoveQuestion(questions[UI.SelectedQuestion]);
			UI.SelectedQuestion = 0;
			// repopulate view after 
			OnValueChangedCategory();
		}

		public void OnClickBtnChange()
		{
			List<Question> questions = Model.GetQuestions(UI.SelectedCategory);
			UI.InitializeEditableQuestionView(questions[UI.SelectedQuestion]);
		}

		public void OnClickBtnBack()
		{
			SceneNavigation.LoadMain();
		}

		/// <summary>
		/// Handler for close button on Editable Question View.
		/// </summary>
		public void OnClickBtnCloseEditableQuestion()
		{
			UI.CloseEditableQuestionView();
		}

		/// <summary>
		/// Handler triggered when user changes category in dropdown.
		/// </summary>
		public void OnValueChangedCategory(int newValue = 0)
		{
			List<Question> questions = Model.GetQuestions(UI.SelectedCategory);
			UI.UpdateQuestionsDropDown(questions);
			UI.SelectedQuestion = newValue;
			UI.UpdateQuestionView(questions.IsEmpty() ? null : questions[newValue]);
		}

		/// <summary>
		/// Handler triggered when user changes selected question in dropdown.
		/// </summary>
		public void OnValueChangedQuestion(int newValue = 0)
		{
			List<Question> questions = Model.GetQuestions(UI.SelectedCategory);
			UI.UpdateQuestionView(questions[(questions.Count <= UI.SelectedQuestion) ? 0 : UI.SelectedQuestion]);
		}

		/// <summary>
		/// Handler for mouse click on save button in editable question view.
		/// </summary>
		public void OnClickBtnSaveQuestion()
		{
			List<Question> questions = Model.GetQuestions(UI.SelectedCategory);

			UI.EditableQuestionView.RecordQuestion();

			// If question already exists just trigger update
			if (questions.Contains(UI.EditableQuestionView.Question))
			{
				Model.ChangeQuestion(UI.EditableQuestionView.Question);
			}
			else
			{
				// If this is new question - add it to existing pool
				Model.AddQuestion(UI.EditableQuestionView.Question);
			}

			// Close editable question and update view
			OnClickBtnCloseEditableQuestion();
			OnValueChangedQuestion();
			OnValueChangedCategory((questions.Count <= UI.SelectedQuestion) ? 0 : UI.SelectedQuestion);
		}

		/// <summary>
		/// Handler for mouse click on button for adding new answer to  editable question.
		/// </summary>
		public void OnClickBtnAddAnswer()
		{
			Answer answer = new Answer();
			UI.EditableQuestionView.Question.Answers.Add(answer);
			UI.EditableQuestionView.AddAnswer(answer);
		}

		#endregion Event Handlers
	}
}