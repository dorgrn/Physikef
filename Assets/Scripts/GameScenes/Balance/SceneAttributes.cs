using Attributes;

namespace GameScenes.Balance
{
    public class SceneAttributes
    {
        public Attribute LeftWeight { get; set; }
        public Attribute RightWeight { get; set; }
        public Attribute RightDistance { get; set; }


        public SceneAttributes()
        {
            LeftWeight = new Attribute("left weight", "kg");
            RightWeight = new Attribute("right weight", "kg");
            RightDistance = new Attribute("right distance from pivot", "m");
        }
    }
}