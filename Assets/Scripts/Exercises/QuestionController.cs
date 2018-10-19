using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private List<Text> choices;
    private Exercise m_sceneExercise;

    void Start()
    {
        // set question body in scene
        questionText.text = m_sceneExercise.Question;

        // set question
        // in scene
        for (var i = 0; i < choices.Count; i++)
        {
            var textContainer = choices[i].GetComponent<Text>();
            textContainer.text = m_sceneExercise.Answers.ToList()[i];
        }
    }
}