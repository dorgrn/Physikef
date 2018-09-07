using System;
using System.Collections.Generic;
using Exercises;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Attributes
{
    public class SceneController : MonoBehaviour
    {
        [Inject] private ApplicationManager m_ApplicationManager;
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private GameObject[] m_AttributeHolders;

        void Start()
        {
            List<Exercise> exercisesForScene =
                m_ExercisePublisher.GetExercisesForScene(m_ApplicationManager.ChosenScene);
            Exercise exercise = exercisesForScene.Find(e => e.Name.Equals(m_ApplicationManager.ChosenExercise));
            List<Attribute> attributesForScene = exercise.Attributes;

            if (attributesForScene.Count > m_AttributeHolders.Length)
            {
                throw new Exception(
                    string.Format("There are less attribute holders {0} than attributes {1} in exercise {2}",
                        m_AttributeHolders.Length, attributesForScene.Count, m_ApplicationManager.ChosenExercise));
            }

            for (var i = 0; i < attributesForScene.Count; i++)
            {
                GameObject currentAttribute = m_AttributeHolders[i];
                Text attributeLabel = currentAttribute.GetComponentInChildren<Text>();
                Attribute attribute = attributesForScene[i];
                attributeLabel.text =
                    string.Format("{0}: {1:0.00}{2}", attribute.Name, attribute.Value, attribute.Unit);
                currentAttribute.SetActive(true);
            }
        }
    }
}