using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Airlines.Core.Enums;

namespace Pra.Airlines.Core.Entities
{
    public class Pilot
    {
        const int LengthOfNameLow = 4;
        const int LengthOfNameHigh = 30;
        const string NameLengthLowException = "Minimumlengte van de naam: ";
        const string NameLengthHighException = "Maximumlengte van de naam: ";
        const string FlyingHoursZeroOrLessException = "Geef een getal van meer dan nul voor de vlieguren";

        private string name;
        private int flyingHours;

        public string Name
        {
            get { return name; }
            set
            {
                value = value.Trim();
                if (value.Length < LengthOfNameLow)
                    throw new ArgumentException(NameLengthLowException);
                if (value.Length > LengthOfNameHigh)
                    throw new ArgumentException(NameLengthHighException);
                name = value;
            }
        }

        public int FlyingHours
        {
            get { return flyingHours; }
            set 
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(FlyingHoursZeroOrLessException);
                flyingHours = value; 
            }
        }

        public Experience Experience 
        { 
            get
            {
                if (FlyingHours < 5000)
                    return Experience.junior;
                else
                    return Experience.skilled;
            }
        }

        public Guid Id { get; }

        public Pilot(string name, int flyingHours = 0, Guid? id = null) 
        {
            Id = id == null ? Guid.NewGuid() : (Guid)id;
            Name = name;
            FlyingHours = flyingHours;
        }

        public override string ToString()
        {
            return $"{Name} ({Experience})\n\t{FlyingHours} u." ;
        }
    }
}
