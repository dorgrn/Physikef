using TMPro;
using UnityEngine;

namespace Controllers
{
    public abstract class InfoTextController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_InfoText;

        protected void UpdateInfoText(string text)
        {
            m_InfoText.text = text;
        }
    }
}