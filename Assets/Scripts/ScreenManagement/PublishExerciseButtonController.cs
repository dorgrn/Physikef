using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ScreenManagement.ExercisePublishingScreen;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ScreenManagement
{
    public class PublishExerciseButtonController : MonoBehaviour
    {
        [Inject] private ApplicationManager m_ApplicationManager;
        [SerializeField] private InputField m_HomeworkNameInput;
        [SerializeField] private Dropdown m_ExerciseDropdown;
        [SerializeField] private StudentScrollViewController m_ScrollViewController;

        private bool IsFormValid()
        {
            return !m_ExerciseDropdown.captionText.text.Equals("Empty")
                   && !m_HomeworkNameInput.text.IsEmpty()
                   && !m_ScrollViewController.GetCheckedStudentsId().IsEmpty();
        }

        public async void PublishButton_OnClick()
        {
            if (!IsFormValid())
            {
                throw new Exception("Form wasn't filled correctly!");
            }

            IEnumerable<string> studentsToPublishTo = m_ScrollViewController.GetCheckedStudentsId();

            await ServicesManager.GetDataAccessLayer().AddHomeworkAsync(new HomeWork()
            {
                SceneName = m_ExerciseDropdown.captionText.text,
                CreatorName = m_ApplicationManager.CurrentUser.userid,
                Name = m_HomeworkNameInput.text,
                Students = studentsToPublishTo
            });
        }
    }
}