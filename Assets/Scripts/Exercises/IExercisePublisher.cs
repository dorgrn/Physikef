using System.Threading.Tasks;

namespace Exercises
{
    public interface IExercisePublisher
    {
        Task<Exercise> GetExerciseForScene(string sceneName);
    }
}