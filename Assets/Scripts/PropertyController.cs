using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace PropertyController
{
    public abstract class PropertyController : MonoBehaviour
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

        public string ObjectTagToUpdate;

        public string SceneToUpdate;

        protected GameObject m_ObjectToUpdate;

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

            // Find the object to update it's property
            GameObject[] objectsArray = SceneManager.GetSceneByName(SceneToUpdate).GetRootGameObjects();
            if (objectsArray.Length > 0)
            {
                foreach (GameObject currentGameObject in objectsArray)
                {
                    if (currentGameObject.CompareTag(ObjectTagToUpdate))
                    {
                        m_ObjectToUpdate = currentGameObject;
                        break;
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdateProperty();
            Field.text = m_Value.ToString("0.##");
         
        }

        public abstract void UpdateProperty();

        void OnButtonUpClick()
        {
            if (m_Value < MaxVal)
            {
                m_Value += Offset;
            }
        }

        void OnButtonDownClick()
        {
            if (m_Value > MinVal)
            {
                m_Value -= Offset;
            }
        }


    }
}