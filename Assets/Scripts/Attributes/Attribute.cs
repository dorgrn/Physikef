using System;

namespace Attributes
{
    public class Attribute
    {
        public string Name { get; set; }

        public float Value { get; set; }

        public string Unit { get; set; }

        public Attribute(string name, string unit, float value = 0f)
        {
            Name = name;
            Unit = unit;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1:0.00}{2}", Name, Value, Unit);
        }
    }
}