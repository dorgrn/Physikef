using System.Collections.Generic;
using Attributes;
using Exercises;
using ProBuilder2.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TextController : MonoBehaviour
{
    [Inject] private ApplicationManager m_ApplicationManager;
    [Inject] private IExercisePublisher m_ExercisePublisher;
    [SerializeField] private Text m_LabelText;
    [SerializeField] private string m_AttributeName;

    private Attribute m_ActualAttribute;

    void Start()
    {
        List<Exercise> exercises = m_ExercisePublisher.GetExercisesForScene(m_ApplicationManager.ChosenScene);
        m_ActualAttribute = exercises.Find(e => e.Name.Equals(m_ApplicationManager.ChosenExercise)).Attributes
            .Find(a => a.Name.Equals(m_AttributeName));
        InvokeRepeating("updateLabel", 0f, 1f);
    }

    private void UpdateLabel()
    {
        m_LabelText.text = string.Format("{0}: {1}{2}",
            m_ActualAttribute.Name,
            m_ActualAttribute.Value,
            m_ActualAttribute.Unit
        );
    }
}