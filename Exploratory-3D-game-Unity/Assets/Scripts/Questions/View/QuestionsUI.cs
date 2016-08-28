using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using zm.Util;

namespace zm.Questioning
{
	/// <summary>
	/// Class responsible for holding all UI components in QuestionsCollection scene.
	/// </summary>
	public class QuestionsUI : MonoBehaviour
	{
		#region Private Methods

		/// <summary>
		/// Populate categories dropdown. And set selection on first category.
		/// </summary>
		private void UpdateCategoriesDropDown(List<string> categories)
		{
			// initialize categories dropdown
			dropdownCategories.ClearOptions();
			dropdownCategories.AddOptions(categories);
		}

		#endregion Private methods

		#region Public Methods

		/// <summary>
		/// Initialize view with selected category and all questions for that category.
		/// </summary>
		public void Initialize(List<Question> questions, List<string> categories, int questionIndex = 0)
		{
			UpdateCategoriesDropDown(categories);

			UpdateQuestionsDropDown(questions);

			UpdateQuestionView(questions.IsEmpty() ? null : questions[0]);
		}

		/// <summary>
		/// Populates question overview with data.
		/// </summary>
		/// <param name="question"></param>
		public void UpdateQuestionView(Question question)
		{
			// initialize questions view
			questionView.Question = question;

			btnRemoveQuestion.interactable = btnChangeQuestion.interactable = question != null;
		}

		/// <summary>
		/// Populate questions list and set selection to first question.
		/// </summary>
		public void UpdateQuestionsDropDown(List<Question> questions)
		{
			// initialize questions dropdown
			dropDownQuestions.ClearOptions();
			List<string> data = new List<string>(questions.Count);

			for (int i = 0; i < questions.Count; i++)
			{
				data.Add(questions[i].Text);
			}

			dropDownQuestions.AddOptions(data);
			dropDownQuestions.interactable = !questions.IsEmpty();
		}

		/// <summary>
		/// Initialized editable question view. If opened for existing question, it will be populated with it's data.
		/// </summary>
		/// <param name="question"></param>
		public void InitializeEditableQuestionView(Question question)
		{
			editableQuestionView.gameObject.SetActive(true);
			editableQuestionView.Question = question;
		}

		/// <summary>
		/// Closes editable question view. 
		/// </summary>
		public void CloseEditableQuestionView()
		{
			editableQuestionView.gameObject.SetActive(false);
		}

		#endregion Public Methods

		#region Fields and Properties

		[SerializeField]
		private Dropdown dropDownQuestions;

		[SerializeField]
		private Dropdown dropdownCategories;

		[SerializeField]
		private QuestionView questionView;

		[SerializeField]
		private EditableQuestionView editableQuestionView;

		[SerializeField]
		private Button btnRemoveQuestion;

		[SerializeField]
		private Button btnChangeQuestion;

		/// <summary>
		/// Gets Category that is currently selected in the view.
		/// </summary>
		public QuestionCategory SelectedCategory
		{
			get { return (QuestionCategory)dropdownCategories.value; }
		}

		/// <summary>
		/// Returns index of currently selected question.
		/// </summary>
		public int SelectedQuestion
		{
			get { return dropDownQuestions.value; }
			set { dropDownQuestions.value = value; }
		}

		/// <summary>
		/// Returns editable view that is used for adding/changing questions.
		/// </summary>
		public EditableQuestionView EditableQuestionView
		{
			get { return editableQuestionView; }
		}

		#endregion Fields and Properties
	}
}