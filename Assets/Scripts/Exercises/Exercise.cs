using System.Collections.Generic;
using Attributes;

namespace Exercises
{
    public class Exercise
    {
        public string Name { get; private set; }

        public List<Attribute> Attributes { get; private set; }

        public string Body { get; private set; }

        public List<string> Choices { get; private set; }

        public string Answer { get; private set; }

        public Exercise(string name, string body, List<string> choices, string answer, List<Attribute> attributes)
        {
            Name = name;
            Body = body;
            Choices = choices;
            Answer = answer;
            Attributes = attributes;
        }
    }
}