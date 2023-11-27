using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Airlines.Core.Entities;

namespace Pra.Airlines.Core.Services
{
    public class AirLineService
    {
        private List<Personnel> personnelMembers;

        public IEnumerable<Personnel> PersonnelMembers
        {
            get { return personnelMembers.AsReadOnly(); }
        }

        public List<Pilot> Pilots { get; set; }

        public List<CabinCrew> CabinCrewMembers { get; set; }

        public AirLineService()
        {
            personnelMembers = new List<Personnel>();
            CreatePersonnel();
        }

        private void CreatePersonnel()
        {
            List<Pilot>  pilots = new List<Pilot>
            {
                new Pilot("Chantal", flyingHours: 6000),
                new Pilot("George", flyingHours: 7300),
                new Pilot("Barbara", flyingHours: 500),
                new Pilot("Theodore"),
                new Pilot("Eleonore", flyingHours: 2999),
                new Pilot("François", flyingHours: 100),
            };

            personnelMembers.AddRange(pilots);

            Guid existingId = Guid.Parse("b8f64f9e-6980-4864-af57-9a3066907984");
            List<CabinCrew> cabinCrewMembers  = new List<CabinCrew>
            {
                new CabinCrew("Enrico", null),
                new CabinCrew("Kees", existingId, 15),
                new CabinCrew("Fritz", null, 25),
                new CabinCrew("Georges", null, 18),
                new CabinCrew("Juan", null)
            };

            personnelMembers.AddRange(cabinCrewMembers);
        }
    }
}
