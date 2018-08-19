using System.Collections.Generic;

namespace Questions
{
    public class InternalQuestionPublisher : IQuestionPublisher
    {
        private readonly Dictionary<string, Question> sceneQuestions = new Dictionary<string, Question>();

        protected InternalQuestionPublisher()
        {
            addInitalQuestions();
        }

        private void addInitalQuestions()
        {
            sceneQuestions.Add("BallOnRamp",
                new Question("Where will the ball reach?", new List<string> {"20m", "50m", "100m"}, "20m"));
            sceneQuestions.Add("Pendulum",
                new Question(
                    "Given the length of the rope L=70cm and the gravity is 9.8m/s^2 what would be the oscillation period in seconds?",
                    new List<string> {"1.6", "1.4", "5.2"}, "1.6"));
        }


        public void AddQuestionForScene(Question question, string sceneName)
        {
            sceneQuestions.Add(sceneName, question);
        }

        public Question GetQuestionForScene(string sceneName)
        {
            return sceneQuestions[sceneName];
        }
    }
}