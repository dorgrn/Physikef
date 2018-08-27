using System.Collections.Generic;

namespace PhysikeffirebaseBE
{
    public class Exercise
    {
        public string SceneName { get; set; }
        public string Question { get; set; }
        public IEnumerable<string> Choices { get; set; }
        public int CorrectChoiceIndex { get; set; }
    }
}
