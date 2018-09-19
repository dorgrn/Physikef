using System.Collections.Generic;
using System.Threading.Tasks;
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
                new Exercise(){ Question = "Where will the ball reach?", Answers = new List<string> {"20m", "50m", "100m"}, CorrectAnswerIndex = 0, SceneName = "BallOnRamp" });
            sceneQuestions.Add("Pendulum",
                new Exercise() {
                    Question = "Given the length of the rope L=150cm and the gravity is 9.8m/s^2 what would be the oscillation period in seconds?",
                    Answers = new List<string> {"1.2", "1.6", "5.2", "5.7"}, CorrectAnswerIndex = 1, SceneName = "Pendulum"
                });

            sceneQuestions.Add("Balance",
                new Exercise()
                {
                    Question = "Given the length of the rope L=150cm and the gravity is 9.8m/s^2 what would be the oscillation period in seconds?",
                    Answers = new List<string> { "1.2", "1.6", "5.2", "5.7" },
                    CorrectAnswerIndex = 1,
                    SceneName = "Pendulum"
                });
        }


        public void AddQuestionForScene(Exercise exercise, string sceneName)
        {
            sceneQuestions.Add(sceneName, exercise);
        }

        public Task<Exercise> GetExerciseForScene(string sceneName)
        {
            return null;
        }
    }
}