using Physikef.ScreenManagement.TeachersOptionsScreen;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class PublishExerciseButtonController : MonoBehaviour
    {
        [SerializeField] private InputField m_HomeworkNameInput;
        [SerializeField] private Dropdown m_ExerciseDropdown;
        [SerializeField] private ScrollViewToggleFiller m_ScrollViewToggleFiller;
        private string m_CurrentUser;
        private Text m_ErrorText;

        private void Start()
        {
            m_ErrorText = GameObject.FindGameObjectWithTag("ErrorText").GetComponent<Text>();
            m_CurrentUser = ServicesManager.GetAuthManager().GetCurrentUserEmail();
            clearForm();
        }

        private bool IsFormValid(IEnumerable<string> studentsToPublishTo)
        {
            return !m_ExerciseDropdown.captionText.text.Equals("Empty")
                   && !string.IsNullOrEmpty(m_HomeworkNameInput.text)
                   && studentsToPublishTo.Any();
        }

        public async void PublishButton_OnClick()
        {
            m_ErrorText.text = string.Empty;
            var studentsToPublishTo = m_ScrollViewToggleFiller.GetCheckedToggles().ToArray();

            if (!IsFormValid(studentsToPublishTo))
            {
                m_ErrorText.color = Color.red;
                m_ErrorText.text = "Form wasn't filled correctly!";
            }

            await ServicesManager.GetDataAccessLayer().AddHomeworkAsync(new HomeWork()
            {
                SceneName = m_ExerciseDropdown.captionText.text,
                CreatorName = m_CurrentUser,
                Name = m_HomeworkNameInput.text,
                Students = studentsToPublishTo
            });

            m_ErrorText.color = Color.green;
            m_ErrorText.text = "Exercise published successfully";
        }

        void clearForm()
        {
            m_ErrorText.text = string.Empty;
        }
    }
}