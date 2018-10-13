using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    // This class is used to fill a scrollview with toggles with text from an AbstractTextInputSupplier
    public class ScrollViewToggleFiller : MonoBehaviour
    {
        [SerializeField] private GameObject m_TogglesHolder;
        [SerializeField] private AbstractInputTextSupplier m_TextInputSupplier;
        [SerializeField] private Toggle m_TogglePrefab;
        [SerializeField] private InfoScrollViewController m_CallBackHolder; // can be null

        private ToggleGroup m_ToggleGroup;

        async void Start()
        {
            m_ToggleGroup = GetComponent<ToggleGroup>();
            await InitToggleLayoutAsync(m_TextInputSupplier);
        }

        public async Task InitToggleLayoutAsync(AbstractInputTextSupplier abstractInputTextSupplier)
        {
            clearView();
            m_TextInputSupplier = abstractInputTextSupplier;
            var toggleTexts = await abstractInputTextSupplier.GetInputTextsAsync();
            foreach (var text in toggleTexts)
            {
                AddTextAsToggleToContent(text);
            }
        }

        public void AddTextAsToggleToContent(string toggleText)
        {
            Toggle toggle = Instantiate(m_TogglePrefab);
            if (m_ToggleGroup != null)
            {
                toggle.group = m_ToggleGroup;
            }

            // update a cbHolder with the inforamtion changed
            if (m_CallBackHolder != null)
            {
                toggle.onValueChanged.AddListener(async delegate
                {
                    if (toggle.isOn)
                    {
                        await m_CallBackHolder.UpdateInfoTextAsync(m_TextInputSupplier, toggleText);
                    }
                });
            }

            toggle.GetComponentInChildren<Text>().text = toggleText;
            toggle.transform.SetParent(m_TogglesHolder.transform, false);
        }

        public IEnumerable<string> GetCheckedToggles()
        {
            return m_TogglesHolder.GetComponentsInChildren<Toggle>().Where(toggle => toggle.isOn)
                .Select(toggle => toggle.GetComponentInChildren<Text>())
                .Select(toggleText => toggleText.text);
        }

        private void clearView()
        {
            var toggles = m_TogglesHolder.GetComponentsInChildren<Toggle>();
            foreach (var toggle in toggles)
            {
                GameObject.Destroy(toggle.gameObject);
            }
        }
    }
}