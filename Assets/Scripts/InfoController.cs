using System.Collections.Generic;
using System.Text;
using Attributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InfoController : MonoBehaviour
{
    [Inject] private ApplicationManager appManager;
    private AttributContainer attributContainer;
    [SerializeField] private Text infoText;

    void Awake()
    {
        attributContainer = appManager.GetAttributeContainer();
    }

    void Start()
    {
        List<Attribute> attributes = attributContainer.GetAllAttributes();

        StringBuilder text = new StringBuilder();
        attributes.ForEach(
            attribute => text.AppendFormat("{0}: {1}{2}\n", attribute.Name, attribute.Value, attribute.Unit)
        );

        infoText.text = text.ToString();
    }
}