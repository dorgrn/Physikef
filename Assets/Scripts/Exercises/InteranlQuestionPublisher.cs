using System.Collections.Generic;
using Exercises;

namespace Questions
{
    public class InternalExercisePublisher : IExercisePublisher
    {
        private readonly Dictionary<string, Exercise> sceneQuestions = new Dictionary<string, Exercise>();

        protected InternalExercisePublisher()
        {
            addInitalQuestions();
        }

        private void addInitalQuestions()
        {
            sceneQuestions.Add("BallOnRamp",
                new Exercise("Where will the ball reach?", new List<string> {"20m", "50m", "100m"}, "20m"));
            sceneQuestions.Add("Pendulum",
                new Exercise(
                    "Given the length of the rope L=2m and the gravity is 9.8m/s^2 what would be the oscillation period in seconds?",
                    new List<string> {"2.8", "1.6", "5.2", "5.7"}, "2.8"));
        }


        public void AddQuestionForScene(Exercise exercise, string sceneName)
        {
            sceneQuestions.Add(sceneName, exercise);
        }

        public Exercise GetExerciseForScene(string sceneName)
        {
            return sceneQuestions[sceneName];
        }
    }
}