using System.Xml;
using Exercises;
using UnityEngine;
using Zenject;

namespace Attributes
{
    public class ObjectController : MonoBehaviour
    {
        [Inject] private ApplicationManager m_ApplicationManager;
        [Inject] private IExercisePublisher m_ExercisePublisher;
        [SerializeField] private int delta = 1;
        [SerializeField] private string attributeName;

        private Attribute m_ActualAttribute;
        private Renderer renderer;
        private readonly Color gazedAtColor = Color.cyan;
        private readonly Color notGzedAtColor = Color.white;
        private bool gazedAt;


        private void Start()
        {
            m_ActualAttribute = m_ExercisePublisher.GetExercisesForScene(m_ApplicationManager.ChosenScene)
                .Find(e => e.Name.Equals(attributeName)).Attributes.Find(a => a.Name.Equals(attributeName));
            renderer = GetComponent<Renderer>();
            SetGazedAt(false);
            InvokeRepeating("updateAttribute", 0f, 1f); // update attribute every 1 second
        }

        public void SetGazedAt(bool gazedAt)
        {
            Debug.Log(this.name + " gazed at: " + gazedAt);
            renderer.material.color = gazedAt ? gazedAtColor : notGzedAtColor;
            this.gazedAt = gazedAt;
        }

        private void updateAttribute()
        {
            if (!gazedAt) return;
            m_ActualAttribute.Value += delta;
            Debug.Log("changing value of " + attributeName + " with: " + delta);
        }
    }
}