using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.CharacterProperties
{
    public class BaseCharacterProperty  
    {
        public virtual float Value { get; set; }
        public virtual float MinValue { get; set; }
        public virtual float MaxValue { get; set; }
    }
}
