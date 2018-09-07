using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercises
{
    public class ExternalExercisePublisher : IExercisePublisher
    {
        public async Task<Exercise> GetExerciseForScene(string sceneName)
        {
            IEnumerable<Exercise> exercises = await ServicesManager.GetDataAccessLayer().GetExercisesAsync(sceneName);
            // assuming first
            var result = exercises.First();
            if (result == null)
            {
                throw new Exception(string.Format("Exercise for scene {0} wasn't found", sceneName));
            }

            return result;
        }
    }
}