using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Physikef.ScreenManagement.TeachersOptionsScreen
{
    public class ExerciseInputTextSupplier : AbstractInputTextSupplier
    {
        public override async Task<IEnumerable<string>> GetInputTextsAsync()
        {
            var exercises = await ServicesManager.GetDataAccessLayer().GetAllExercisesAsync();
            return exercises.Select(ex => ex.Question);
        }
    }
}