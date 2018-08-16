using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Questions
{
    public class InternalQuestionPublisher : IQuestionPublisher
    {
        private readonly Dictionary<string, Question> sceneQuestions = new Dictionary<string, Question>();

        protected InternalQuestionPublisher()
        {
            addInitalQuestions();
            Debug.Log(sceneQuestions);
        }

        private void addInitalQuestions()
        {
            sceneQuestions.Add("BallOnRamp",
                new Question("Where will the ball reach?", new List<string> {"20m", "50m", "100m"}, "20m"));
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