using Pra.Airlines.Core.Enums;
using System;

namespace Pra.Airlines.Core.Entities
{
    public class CabinCrew
    {
        const int LengthOfNameLow = 4;
        const int LengthOfNameHigh = 30;
        const string NameLengthLowException = "Minimumlengte van de naam: ";
        const string NameLengthHighException = "Maximumlengte van de naam: ";

        private string name;

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

        public Guid Id { get; }

        public int Flights { get; set; }

        public Experience Experience
        {
            get
            {
                if (Flights < 25)
                    return Experience.junior;
                else
                    return Experience.skilled;
            }
        }

        public CabinCrew(string name, int flights = 0, Guid? id = null)
        {
            Id = id == null ? Guid.NewGuid() : (Guid)id;
            Name = name;
            Flights = flights;
        }

        public void AddFlight()
        {
            Flights++;
        }

        public override string ToString()
        {
            return $"{Name} ({Experience})\n\tVluchten: {Flights}" ;
        }
    }
}
