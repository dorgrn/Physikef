using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class AddExerciseButtonController : MonoBehaviour
    {
        private const string EMPTY = "Empty";
        [SerializeField] private Dropdown m_SceneNameDropdown;
        [SerializeField] private InputField m_ExerciseNameInput;
        [SerializeField] private InputField m_QuestionInput;
        [SerializeField] private GameObject m_AnswersHolder;
        private Tuple<Toggle, InputField>[] m_AnswersInputToggles;
        private ToggleGroup m_RadioToggleGroup;

        void Start()
        {
            populateAnswerInputToggles();
            m_RadioToggleGroup = m_AnswersHolder.GetComponent<ToggleGroup>();
            clearForm();
        }

        bool isValidForm()
        {
            return m_SceneNameDropdown.captionText.text != EMPTY &&
                   !string.IsNullOrEmpty(m_ExerciseNameInput.text) &&
                   !string.IsNullOrEmpty(m_QuestionInput.text) &&
                   m_RadioToggleGroup.ActiveToggles().Any() &&
                   m_AnswersInputToggles.All(answerTuple => !string.IsNullOrEmpty(answerTuple.Item2.text));
        }

        public async void AddExerciseButton_OnClick()
        {
            if (!isValidForm())
            {
                ScreenManagementGeneral.LogError("Form isn't valid!");
            }

            // assume on toggle is singular since its part of a toggle group
            Toggle onToggle = m_RadioToggleGroup.ActiveToggles().First();
            int? correctAnswerIndex = findCorrectIndexInAnswerInputToggles(m_AnswersInputToggles, onToggle);

            var exerciseToAdd = new Exercise()
            {
                SceneName = m_SceneNameDropdown.captionText.text,
                ExerciseName = m_ExerciseNameInput.text,
                Answers = m_AnswersInputToggles.Select(answerWithToggle => answerWithToggle.Item2.text),
                Question = m_QuestionInput.text,
                CorrectAnswerIndex = correctAnswerIndex.Value // checked in isValidForm
            };

            await ServicesManager.GetDataAccessLayer().AddExerciseAsync(exerciseToAdd);
            clearForm();
            ScreenManagementGeneral.LogSuccess("Exercise added successfully");
        }

        private int? findCorrectIndexInAnswerInputToggles(Tuple<Toggle, InputField>[] answersInputToggles,
            Toggle onToggle)
        {
            for (int i = 0; i < answersInputToggles.Length; i++)
            {
                if (answersInputToggles[i].Item1.Equals(onToggle))
                {
                    return i;
                }
            }

            return null;
        }


        void populateAnswerInputToggles()
        {
            Toggle[] toggles = m_AnswersHolder.GetComponentsInChildren<Toggle>();
            InputField[] inputs = m_AnswersHolder.GetComponentsInChildren<InputField>();
            m_AnswersInputToggles = new Tuple<Toggle, InputField>[toggles.Length];

            for (int i = 0; i < toggles.Length; i++)
            {
                m_AnswersInputToggles[i] = new Tuple<Toggle, InputField>(toggles[i], inputs[i]);
            }
        }

        void clearForm()
        {
            m_SceneNameDropdown.options = new List<Dropdown.OptionData>()
            {
                new Dropdown.OptionData(EMPTY)
            };

            m_ExerciseNameInput.text = string.Empty;
            m_QuestionInput.text = string.Empty;
            m_RadioToggleGroup.SetAllTogglesOff();

            foreach (InputField field in m_AnswersHolder.GetComponents<InputField>())
            {
                field.text = string.Empty;
            }
        }
    }
}