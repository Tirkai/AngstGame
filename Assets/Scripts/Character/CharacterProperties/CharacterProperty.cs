using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Character.CharacterModifiers;

namespace Character.CharacterProperties
{
    public class CharacterProperty
    {
        public CharacterPropertyType Type { get; }

        float baseAmount;

        public float BaseAmount { get => baseAmount; set => baseAmount = value; }

        float minAmount = 0;
        public float MinAmount { get => minAmount; }

        float maxAmount = float.PositiveInfinity;
        public float MaxAmount { get => maxAmount; set => maxAmount = value; }

        float amount = 0;
        public float Amount {
            get => amount;
            set {
                if (value >= MinAmount)
                {
                    if (value <= MaxAmount) amount = value;
                    else amount = MaxAmount;
                }
                else amount = MinAmount;
            }
        }

        public CharacterProperty(CharacterPropertyType type, float baseAmount)
        {
            Type = type;
            BaseAmount = baseAmount;
            Amount = BaseAmount;
        }

    }
}
