using System;
using System.Collections.Generic;
using Exercises;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace GameScenes.Pendulum
{
    public class QuestionTextController : MonoBehaviour
    {
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private TextMeshProUGUI m_QuestionText;
        [SerializeField] private Text[] m_ChoicesLabels;

        void Start()
        {
            // TODO: temp implementation assuming 1 exercise for scene
            Exercise exercise = m_ExercisePublisher.GetExercisesForScene(SceneManager.GetActiveScene().name)[0];
            initExercises(exercise);
        }

        private void initExercises(Exercise exercise)
        {
            m_QuestionText.text = exercise.Body;

            if (m_ChoicesLabels.Length != exercise.Choices.Count)
            {
                throw new Exception("Question choices and actual text labels differ in size!");
            }

            for (var i = 0; i < m_ChoicesLabels.Length; i++)
            {
                m_ChoicesLabels[i].text = exercise.Choices[i];
            }
        }
    }
}