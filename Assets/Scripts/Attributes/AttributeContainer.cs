using System.Collections.Generic;

namespace Attributes
{
    public class AttributContainer
    {
        private Dictionary<AttributeEnum, Attribute> attributeByEnum;

        public enum AttributeEnum
        {
            Height,
            Gravity,
            Friction,
            Velocity,
            angularDragMult,
            Mass
        }

        public AttributContainer()
        {
            attributeByEnum = new Dictionary<AttributeEnum, Attribute>();
            initContainer();
        }

        private void initContainer()
        {
            attributeByEnum.Add(AttributeEnum.Height, new Attribute("height", "m"));
            attributeByEnum.Add(AttributeEnum.Gravity, new Attribute("gravity", ""));
            attributeByEnum.Add(AttributeEnum.Friction, new Attribute("friction", ""));
            attributeByEnum.Add(AttributeEnum.Mass, new Attribute("mass", "kg"));
            attributeByEnum.Add(AttributeEnum.Velocity, new Attribute("velocity", "m/s"));
            attributeByEnum.Add(AttributeEnum.angularDragMult, new Attribute("angularDragMult", ""));
        }

        public Attribute GetAttributeFromEnum(AttributeEnum attributeEnum)
        {
            return attributeByEnum[attributeEnum];
        }

        public void ChangeAttribute(AttributeEnum attribute, float delta)
        {
            // TODO: security check
            Attribute attributeInstance = GetAttributeFromEnum(attribute);
            if (delta < 0 && attributeInstance.Value <= 0)
            {
                return;
            }

            attributeInstance.Value += delta;
        }

        public string GetAttributeName(AttributeEnum attribute)
        {
            return GetAttributeFromEnum(attribute).Name;
        }

        public float GetAttributeValue(AttributeEnum attribute)
        {
            return GetAttributeFromEnum(attribute).Value;
        }

        public string GetAttributeUnit(AttributeEnum attribute)
        {
            return GetAttributeFromEnum(attribute).Unit;
        }

        public List<Attribute> GetAllAttributes()
        {
            return new List<Attribute>(attributeByEnum.Values);
        }
    }
}