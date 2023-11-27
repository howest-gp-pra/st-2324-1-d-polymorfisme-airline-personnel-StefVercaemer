using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Airlines.Core.Enums;

namespace Pra.Airlines.Core.Entities
{
    public class Pilot : Personnel
    {

        const string FlyingHoursZeroOrLessException = "Geef een getal van meer dan nul voor de vlieguren";

        private int flyingHours;

        public int FlyingHours
        {
            get { return flyingHours; }
            private set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(FlyingHoursZeroOrLessException);
                flyingHours = value; 
            }
        }

        public override Experience Experience 
        { 
            get
            {
                if (FlyingHours < 5000)
                    return Experience.junior;
                else
                    return Experience.skilled;
            }
        }

        public Pilot(string name, Guid? id = null, int flyingHours = 0) : base(name, id) 
        {
            FlyingHours = flyingHours;
        }

        internal void AddFlyingHours(uint hours)
        {
            FlyingHours += (int)hours; 
        }

        public override string ToString()
        {
            return $"{base.ToString()} ({Experience})\n\t{FlyingHours} u." ;
        }
    }
}
