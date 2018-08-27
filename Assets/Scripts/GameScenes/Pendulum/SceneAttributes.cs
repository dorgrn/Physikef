using Attributes;

namespace GameScenes.Pendulum
{
    public class SceneAttributes
    {
        public Attribute RopeLength { get; set; }
        public Attribute Gravity { get; set; }

        public SceneAttributes()
        {
            Gravity = new Attribute("gravity acceleration", "m/s^2", 9.8f);
            RopeLength = new Attribute("rope length", "cm");
        }
    }
}