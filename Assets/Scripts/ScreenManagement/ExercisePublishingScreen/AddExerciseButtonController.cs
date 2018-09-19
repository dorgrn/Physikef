using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;
using UnityEngine.UI;

public class AddExerciseButtonController : MonoBehaviour
{
    [SerializeField] private InputField m_ExerciseNameInput;
    [SerializeField] private InputField m_QuestionInput;
    [SerializeField] private GameObject m_AnswersHolder;
    private Tuple<Toggle, InputField>[] m_AnswersInputToggles;
    private ToggleGroup m_RadioToggleGroup;

    void Start()
    {
        populateAnswerInputToggles();
        m_RadioToggleGroup = m_AnswersHolder.GetComponent<ToggleGroup>();
    }

    bool isValidForm()
    {
        return !m_ExerciseNameInput.text.IsEmpty()
               && !m_QuestionInput.text.IsEmpty()
               && !m_RadioToggleGroup.ActiveToggles().IsEmpty()
               && m_AnswersInputToggles.All(answerTuple => !answerTuple.Item2.text.IsEmpty());
    }

    public async void AddExerciseButton_OnClick()
    {
        if (!isValidForm())
        {
            throw new Exception("Form isn't valid!");
        }

        // assume on toggle is singular since its part of a toggle group
        Toggle onToggle = m_RadioToggleGroup.ActiveToggles().First();
        int? correctAnswerIndex = findCorrectIndexInAnswerInputToggles(m_AnswersInputToggles, onToggle);

        var exerciseToAdd = new Exercise()
        {
            SceneName = m_ExerciseNameInput.text,
            Answers = m_AnswersInputToggles.Select(answerWithToggle => answerWithToggle.Item2.text),
            Question = m_QuestionInput.text,
            CorrectAnswerIndex = correctAnswerIndex.Value // checked in isValidForm
        };

        await ServicesManager.GetDataAccessLayer().AddExerciseAsync(exerciseToAdd);
    }

    private int? findCorrectIndexInAnswerInputToggles(Tuple<Toggle, InputField>[] answersInputToggles, Toggle onToggle)
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
}