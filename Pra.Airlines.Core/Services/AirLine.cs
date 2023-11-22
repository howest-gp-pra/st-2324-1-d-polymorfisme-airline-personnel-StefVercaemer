using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Airlines.Core.Entities;

namespace Pra.Airlines.Core.Services
{
    public class AirLine
    {
        public List<Pilot> Pilots { get; set; }

        public List<CabinCrew> CabinCrewMembers { get; set; }

        public AirLine()
        {
            CreatePersonnel();
        }

        private void CreatePersonnel()
        {
            Pilots = new List<Pilot>
            {
                new Pilot("Chantal", 6000),
                new Pilot("George", 7300),
                new Pilot("Barbara", 500),
                new Pilot("Theodore"),
                new Pilot("Eleonore", 2999),
                new Pilot("François", 100),
            };

            CabinCrewMembers  = new List<CabinCrew>
            {
                new CabinCrew("Enrico"),
                new CabinCrew("Kees", 15),
                new CabinCrew("Fritz", 25),
                new CabinCrew("Georges", 18),
                new CabinCrew("Juan")
            };
        }
    }
}
