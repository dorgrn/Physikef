namespace Exercises
{
    public interface IExercisePublisher
    {
        Exercise GetExerciseForScene(string sceneName);
    }
}