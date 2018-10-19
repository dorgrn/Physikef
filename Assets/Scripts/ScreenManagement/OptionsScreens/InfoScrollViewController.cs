using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Physikef.ScreenManagement.OptionsScreens
{
    public class InfoScrollViewController : MonoBehaviour
    {
        [SerializeField] Text m_InfoText;

        // update stats based on the type of it
        public async Task UpdateInfoTextAsync(AbstractInputTextSupplier supplier, string identifier)
        {
            m_InfoText.text = string.Empty;
            string output = null;
            if (m_InfoText == null)
            {
                return;
            }

            if (supplier is StudentInputTextSupplier)
            {
                output = await StatsController.GetStudentStatsAnalysisAsync(identifier);
            }
            else if (supplier is ExerciseInputTextSupplier)
            {
                output = await StatsController.GetExeStatsAnalysisAsync(identifier);
            }

            m_InfoText.text = output ?? string.Empty;
        }
    }
}