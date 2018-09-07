using System.Collections.Generic;
using Attributes;
using Questions;

namespace Exercises
{
    public interface IExercisePublisher
    {
        List<Exercise> GetExercisesForScene(string sceneName);
        List<Attribute> GetAttributesForExercise(string sceneName, string exerciseName);

    }
}