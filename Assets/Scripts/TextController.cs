using Attributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TextController : MonoBehaviour
{
    [Inject] private ApplicationManager applicationManager;
    private AttributContainer attributeContainer;
    private AttributContainer.AttributeEnum attribute;
    [SerializeField] private Text labelText;

    // Use this for initialization
    void Start()
    {
//        attributeContainer = applicationManager.GetAttributeContainer();
        var parentScript = GetComponentInParent<AttributeEnumInstance>();
        attribute = parentScript.AttributeEnum;
        InvokeRepeating("updateLabel", 0f, 1f);
    }

    private void updateLabel()
    {
        labelText.text = string.Format("{0}: {1}{2}", attributeContainer.GetAttributeName(attribute),
            attributeContainer.GetAttributeValue(attribute), attributeContainer.GetAttributeUnit(attribute));
    }
}