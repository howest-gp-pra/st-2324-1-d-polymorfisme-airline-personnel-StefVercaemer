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
        public const string ObjectNullException = "Geef geen leeg object door";
        public const string DoubleNameException = ": deze naam komt reeds voor in de lijst";
        public const string UnknownObjectException = ": deze naam komt niet voor in de lijst";

        #region Listing area
        private List<Personnel> personnelMembers;

        public IEnumerable<Personnel> PersonnelMembers
        {
            get { return personnelMembers.AsReadOnly(); }
        }

        public IEnumerable<Pilot> Pilots
        {
            get
            {
                List<Pilot> pilots = new List<Pilot>();
                foreach (Personnel personnel in PersonnelMembers)
                {
                    if (personnel is Pilot)
                    {
                        Pilot pilot = (Pilot)personnel;
                        pilots.Add(pilot);
                    }
                }
                return pilots.AsReadOnly();
            }

        }

        public IEnumerable<CabinCrew> CabinCrewMembers
        {
            get
            {
                List<CabinCrew> cabinCrewMembers = new List<CabinCrew>();
                foreach (Personnel personnel in PersonnelMembers)
                {
                    if (personnel is  CabinCrew)
                    {
                        CabinCrew cabinCrew = (CabinCrew)personnel;
                        cabinCrewMembers.Add(cabinCrew);
                    }
                }
                return cabinCrewMembers.AsReadOnly();
            }
        }

        #endregion
        public AirLineService()
        {
            personnelMembers = new List<Personnel>();
            CreatePersonnel();
        }

        #region CRUD-operations
        public void Add(Personnel toAdd)
        {
            if (toAdd == null)
                throw new Exception(ObjectNullException);
            else if(toAdd is Pilot &&
                Personnel.CollectionContainsName(Pilots, toAdd.Name))
                throw new Exception($"{toAdd.Name}{DoubleNameException} met piloten");
            else if (toAdd is CabinCrew && 
                Personnel.CollectionContainsName(CabinCrewMembers, toAdd.Name))
                throw new Exception($"{toAdd.Name}{DoubleNameException} met cabinepersoneel");
            else personnelMembers.Add(toAdd);
        }

        public void Update(Personnel toUpdate, Personnel updated)
        {
            if (toUpdate == null || updated == null)
                throw new Exception(ObjectNullException);
            else if (updated is Pilot &&
                Personnel.CollectionContainsName(Pilots, updated.Name))
                throw new Exception($"{updated.Name}{DoubleNameException} met piloten");
            else if (updated is CabinCrew &&
                Personnel.CollectionContainsName(CabinCrewMembers, updated.Name))
                throw new Exception($"{updated.Name}{DoubleNameException} met cabinepersoneel");
            else
            {
                toUpdate.Name = updated.Name;
            }
        }

        public void Delete(Personnel toRemove)
        {
            if (toRemove == null)
                throw new Exception(ObjectNullException);
            else if (!Personnel.IsExistingObject(PersonnelMembers, toRemove))
                throw new Exception($"{toRemove.Name}{UnknownObjectException}");
            else
                personnelMembers.Remove(toRemove);
        }

        #endregion

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
