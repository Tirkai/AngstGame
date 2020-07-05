using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Character.CharacterProperties;

namespace Character.CharacterModifiers
{
    public class SimplePropertyModifier
    {
        public CharacterPropertyType PropertyType { get; }
        public float Value { get; set; }

        public CharacterModifierType ModifierType { get; set; }

        public SimplePropertyModifier(CharacterPropertyType propertyType, CharacterModifierType modifierType, float value)
        {
            PropertyType = propertyType;
            ModifierType = modifierType;
            Value = value;
        }
    }
}
