using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBuilder2.Common;
using UnityEngine;
using UnityEngine.UI;

namespace ScreenManagement.ExercisePublishingScreen
{
    public class StudentScrollViewController : MonoBehaviour
    {
        [SerializeField] private Toggle m_TogglePrefab;
        [SerializeField] private GameObject m_TogglesHolder;
        [SerializeField] private Text m_InfoText;
        [SerializeField] private InfoScrollViewController m_InfoScrollViewController;
        private List<Toggle> m_Toggles = new List<Toggle>();

        async void Start()
        {
            await initStudentLayoutAsync();
        }

        public async void InitStudentLayout()
        {
            await initStudentLayoutAsync();
        }

        public async void InitExeLayout()
        {
            await initExeLayoutAsync();
        }

        private async Task initStudentLayoutAsync()
        {
            clearView();
            IEnumerable<User> students =
                (await ServicesManager.GetDataAccessLayer().GetAllUsersAsync()).Where(
                    user => user.usertype == "Student");
            foreach (var student in students)
            {
                AddToggleToContent(student.userid);
            }
        }

        private async Task initExeLayoutAsync()
        {
            clearView();
            IEnumerable<StudentExerciseResult> exerciseResults =
                await ServicesManager.GetDataAccessLayer().GetAllStudentStatisticsAsync();
            foreach (var exerciseResult in exerciseResults)
            {
                AddToggleToContent(exerciseResult.Question);
            }
        }

        public IEnumerable<string> GetCheckedToggle()
        {
            return m_TogglesHolder.GetComponentsInChildren<Toggle>().Where(toggle => toggle.isOn)
                .Select(toggle => toggle.GetComponentInChildren<Text>().text);
        }

        public void AddToggleToContent(string toggleText)
        {
            Toggle toggle = Instantiate(m_TogglePrefab);
            m_Toggles.Add(toggle);
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

                    string checkedStudentId = GetCheckedToggle().FirstOrDefault();
                    await m_InfoScrollViewController.UpdateInfoTextAsync(checkedStudentId);
                });
            }
        }

        private void clearView()
        {
            m_InfoText.text = string.Empty;
            foreach (var toggle in m_Toggles)
            {
                GameObject.Destroy(toggle.gameObject);
            }

            m_Toggles.Clear();
        }
    }
}