using Questions;

namespace Exercises
{
    public interface IExercisePublisher
    {
        Exercise GetExerciseForScene(string sceneName);
    }
}