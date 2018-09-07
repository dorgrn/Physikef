using System.Collections.Generic;
using Exercises;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Exercises
{
    public class QuestionController : MonoBehaviour
    {
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private Text m_QuestionText;
        [SerializeField] private List<Text> m_Choices;
        private Exercise m_SceneExercise;

        private void Awake()
        {
            // TODO: temp assumption
            m_SceneExercise = m_ExercisePublisher.GetExercisesForScene(SceneManager.GetActiveScene().name)[0];
        }

        void Start()
        {
            // set question body in scene
            m_QuestionText.text = m_SceneExercise.Body;

            // set question answers in scene
            for (var i = 0; i < m_Choices.Count; i++)
            {
                var textContainer = m_Choices[i].GetComponent<Text>();
                textContainer.text = m_SceneExercise.Choices[i];
            }
        }
    }
}