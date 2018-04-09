using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PropertyController : MonoBehaviour
{
    public Button ButtonUp;

    public Button ButtonDown;

    public InputField Field;

    public float InitVal;

    private float m_Value;

    public int Precision;

    public float Offset;

    public float MaxVal;

    public float MinVal;

    public float Value
    {
        get
        {
            return m_Value;
        }
    }

    // Use this for initialization
    void Start()
    {
        m_Value = InitVal;
        ButtonUp.onClick.AddListener(OnButtonUpClick);
        ButtonDown.onClick.AddListener(OnButtonDownClick);
    }

    // Update is called once per frame
    void Update()
    {
        Field.text = m_Value.ToString("0.##");
    }

    void OnButtonUpClick()
    {
        if (m_Value < MaxVal)
        {
            m_Value += Offset;
        }
    }
    
    void OnButtonDownClick()
    {
        if (m_Value > MinVal )
        {
            m_Value -= Offset;
        }
    }

}
