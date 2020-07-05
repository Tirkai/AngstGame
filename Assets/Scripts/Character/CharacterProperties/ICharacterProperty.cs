using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.CharacterProperties
{
    public interface ICharacterProperty
    {
        float Value { get; set; }
        float MinValue { get; }
        float MaxValue { get; set; }
    }
}
