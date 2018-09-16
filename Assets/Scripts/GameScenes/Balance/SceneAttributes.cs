using Attributes;

namespace GameScenes.Balance
{
    public class SceneAttributes
    {
        private Attribute leftWeight;
        private Attribute rightWeight;

        public Attribute LeftWeight
        {
            get { return leftWeight; }
            set { leftWeight = value; }
        }

        public Attribute RightWeight
        {
            get { return rightWeight; }
            set { rightWeight = value; }
        }
    }
}