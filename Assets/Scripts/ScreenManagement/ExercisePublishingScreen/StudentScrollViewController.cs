using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenManagement.ExercisePublishingScreen
{
    public class StudentScrollViewController : MonoBehaviour
    {
        [SerializeField] private Toggle m_TogglePrefab;
        [SerializeField] private GameObject m_TogglesHolder;
        [SerializeField] private InfoScrollViewController m_InfoScrollViewController;

        async void Start()
        {
            IEnumerable<User> students =
                (await ServicesManager.GetDataAccessLayer().GetAllUsers()).Where(user => user.usertype == "Student");
            foreach (User student in students)
            {
                AddToggleToContent(student.userid);
            }
        }

        public IEnumerable<string> GetCheckedStudentsId()
        {
            return m_TogglesHolder.GetComponentsInChildren<Toggle>().Where(toggle => toggle.isOn)
                .Select(toggle => toggle.GetComponentInChildren<Text>().text);
        }

        public void AddToggleToContent(string toggleText)
        {
            Toggle toggle = Instantiate(m_TogglePrefab);
            toggle.group = m_TogglesHolder.GetComponent<ToggleGroup>();
            toggle.GetComponentInChildren<Text>().text = toggleText;
            toggle.transform.SetParent(m_TogglesHolder.transform, false);

            if (m_InfoScrollViewController != null)
            {
                toggle.onValueChanged.AddListener(async delegate
                {
                    if (!toggle.isOn)
                    {
                        return;
                    }

                    string checkedStudentId = GetCheckedStudentsId().FirstOrDefault();
                    await m_InfoScrollViewController.UpdateInfoTextAsync(checkedStudentId);
                });
            }
        }
    }
}