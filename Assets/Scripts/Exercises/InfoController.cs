using System.Collections.Generic;
using System.Text;
using Attributes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InfoController : MonoBehaviour
{
    [Inject] private ApplicationManager appManager;
    [SerializeField] private Text infoText;

    void Awake()
    {
    }

    void Start()
    {
    }
}