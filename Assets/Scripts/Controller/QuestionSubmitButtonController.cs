using TMPro;

namespace Physikef.Controller
{
    public class QuestionSubmitButtonController : AbstractButtonAction
    {
        protected override async void DoAction()
        {
            TextMeshProUGUI label = GetComponentInChildren<TextMeshProUGUI>();
            await m_SceneController.SubmitAnswer(label.text);
        }
    }
}