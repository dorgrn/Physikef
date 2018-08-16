using System.Collections.Generic;
using Questions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class QuestionController : MonoBehaviour
{
    [Inject] private IQuestionPublisher questionPublisher;
    [SerializeField] private Text questionText;
    [SerializeField] private List<Text> choices;
    private Question sceneQuestion;

    private void Awake()
    {
        sceneQuestion = questionPublisher.GetQuestionForScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        // set question body in scene
        questionText.text = sceneQuestion.Body;

        // set question answers in scene
        for (var i = 0; i < choices.Count; i++)
        {
            var textContainer = choices[i].GetComponent<Text>();
            textContainer.text = sceneQuestion.Choices[i];
        }
    }
}