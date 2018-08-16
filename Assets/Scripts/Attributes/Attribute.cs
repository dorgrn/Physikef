using System;

namespace Attributes
{
    public class Attribute
    {
        private string name;
        private float value;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public string Unit { get; set; }

        public Attribute(string name, string unit, float value = 0)
        {
            this.name = name;
            this.Unit = unit;
            this.value = value;
        }
    }
}