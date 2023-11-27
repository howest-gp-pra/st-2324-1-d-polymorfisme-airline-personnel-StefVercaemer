using Pra.Airlines.Core.Enums;
using System;

namespace Pra.Airlines.Core.Entities
{
    public class CabinCrew : Personnel
    {
        //public int Flights {  get; private set; }

        private int flights;

        public int Flights
        {
            get { return flights; }
            private set { flights = value; }
        }

        public override Experience Experience
        {
            get
            {
                if (Flights < 25)
                    return Experience.junior;
                else
                    return Experience.skilled;
            }
        }

        public CabinCrew(string name, Guid? id, int flights = 0) : base(name, id)
        {
            Flights = flights;
        }

        internal void AddFlight()
        {
            Flights++;
        }

        public override string ToString()
        {
            return $"{base.ToString()} ({Experience})\n\tVluchten: {Flights}" ;
        }
    }
}
