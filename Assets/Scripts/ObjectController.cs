using UnityEngine;

namespace Attributes
{
    public class ObjectController : MonoBehaviour
    {
        private AttributContainer attributContainer;
        [SerializeField] private int delta = 1;
        private AttributContainer.AttributeEnum attribute;
        private new Renderer renderer;
        private readonly Color gazedAtColor = Color.cyan;
        private readonly Color notGzedAtColor = Color.white;
        private bool gazedAt;


        private void Start()
        {
//            attributContainer = applicationManager.GetAttributeContainer();
            var parentScript = GetComponentInParent<AttributeEnumInstance>();
            attribute = parentScript.AttributeEnum;
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
            attributContainer.ChangeAttribute(attribute, delta);
            Debug.Log("changing value of " + attribute + " with: " + delta);
        }
    }
}