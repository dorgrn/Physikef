using System.Collections.Generic;
using System.Text;
using Attributes;
using Exercises;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InfoController : MonoBehaviour
{
    [Inject] private ApplicationManager m_AppManager;
    [Inject] private IExercisePublisher m_ExercisePublisher;
    [SerializeField] private Text m_InfoText;

    private List<Attribute> m_Attributes;

    void Awake()
    {
        m_Attributes =
            m_ExercisePublisher.GetAttributesForExercise(m_AppManager.ChosenScene, m_AppManager.ChosenExercise);
    }

    void Start()
    {
        StringBuilder text = new StringBuilder();
        m_Attributes.ForEach(
            attribute => text.AppendFormat("{0}: {1}{2}\n", attribute.Name, attribute.Value, attribute.Unit)
        );

        m_InfoText.text = text.ToString();
    }
}