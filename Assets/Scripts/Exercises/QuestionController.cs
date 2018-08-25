using System.Collections.Generic;
using Exercises;
using Questions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class QuestionController : MonoBehaviour
{
    [Inject] private IExercisePublisher m_exercisePublisher;
    [SerializeField] private Text questionText;
    [SerializeField] private List<Text> choices;
    private Exercise m_sceneExercise;

    private void Awake()
    {
        m_sceneExercise = m_exercisePublisher.GetExerciseForScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        // set question body in scene
        questionText.text = m_sceneExercise.Body;

        // set question answers in scene
        for (var i = 0; i < choices.Count; i++)
        {
            var textContainer = choices[i].GetComponent<Text>();
            textContainer.text = m_sceneExercise.Choices[i];
        }
    }
}