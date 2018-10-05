using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.TeachersOptionsScreen
{
    public class PublishExerciseButtonController : MonoBehaviour
    {
        [SerializeField] private InputField m_HomeworkNameInput;
        [SerializeField] private Dropdown m_ExerciseDropdown;
        [SerializeField] private ScrollViewToggleFiller m_ScrollViewToggleFiller;
        private string m_CurrentUser;
        private Text m_MessagesText;

        private void Start()
        {
            m_MessagesText = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<Text>();
            m_CurrentUser = ServicesManager.GetAuthManager().GetCurrentUserEmail();
        }

        private bool IsFormValid(IEnumerable<string> studentsToPublishTo)
        {
            return !m_ExerciseDropdown.captionText.text.Equals("Empty")
                   && !string.IsNullOrEmpty(m_HomeworkNameInput.text)
                   && studentsToPublishTo.Any();
        }

        public async void PublishButton_OnClick()
        {
            m_MessagesText.text = string.Empty;
            var studentsToPublishTo = m_ScrollViewToggleFiller.GetCheckedToggles().ToArray();

            if (!IsFormValid(studentsToPublishTo))
            {
                m_MessagesText.color = Color.red;
                m_MessagesText.text = "Form wasn't filled correctly!";
            }

            await ServicesManager.GetDataAccessLayer().AddHomeworkAsync(new HomeWork()
            {
                SceneName = m_ExerciseDropdown.captionText.text,
                CreatorName = m_CurrentUser,
                Name = m_HomeworkNameInput.text,
                Students = studentsToPublishTo
            });

            m_MessagesText.color = Color.green;
            m_MessagesText.text = "Exercise published successfully";
        }
    }
}