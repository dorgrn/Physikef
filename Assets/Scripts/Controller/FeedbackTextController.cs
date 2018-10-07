using System.Collections;
using TMPro;
using UnityEngine;

namespace Physikef.Controller
{
    public class FeedbackTextController : MonoBehaviour
    {
        private const int SECONDS_DELAY = 1;
        [SerializeField] private TextMeshProUGUI m_Text;

        // Use this for initialization
        void Start()
        {
            m_Text.text = "";
        }

        public IEnumerator ShowCorrect()
        {
            m_Text.faceColor = Color.green;
            m_Text.text = "Correct!";
            yield return new WaitForSeconds(SECONDS_DELAY);
            m_Text.text = "";
        }

        public IEnumerator ShowWrong()
        {
            m_Text.faceColor = Color.red;
            m_Text.text = "Try again!";
            yield return new WaitForSeconds(SECONDS_DELAY);
            m_Text.text = "";
        }
    }
}