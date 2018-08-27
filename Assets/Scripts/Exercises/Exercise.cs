using System.Collections.Generic;

namespace Exercises
{
    public class Exercise
    {
        private string body;
        private List<string> choices;
        private string answer;

        public string Body
        {
            get { return body; }
        }

        public List<string> Choices
        {
            get { return choices; }
        }

        public string Answer
        {
            get { return answer; }
        }

        public Exercise(string body, List<string> choices, string answer)
        {
            this.body = body;
            this.choices = choices;
            this.answer = answer;
        }
    }
}