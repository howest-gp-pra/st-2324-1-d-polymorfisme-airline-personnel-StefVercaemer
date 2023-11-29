using Pra.Airlines.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Airlines.Core.Entities
{

    public abstract class Personnel
    {
        public const int LengthOfNameLow = 4;
        public const int LengthOfNameHigh = 30;
        public const string NameLengthLowException = "Minimumlengte van de naam: ";
        public const string NameLengthHighException = "Maximumlengte van de naam: ";

        static Random random = new Random();

        protected decimal salary;

        public string Career 
        { get
            {
                string info = "";
                info = $"{Name}";
                if(salary >= 3000)
                {
                    info += " (Big Shot)";
                }
                else
                {
                    info += " (Regular)";
                }
                return info;
            }
        }



        protected string name;

        public virtual string Name
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

        public abstract Experience Experience { get; }


        public Guid Id { get; }

        public Personnel(string name, Guid? id)
        {
            Name = name;
            if (id != null)
                Id = (Guid)id;
            else
                Id = Guid.NewGuid();
            salary = random.Next(2500, 3501);
        }

        public static bool CollectionContainsName(IEnumerable<Personnel> workers, string name)
        {
            bool nameIsFound = false;
            foreach (Personnel worker in workers)
            {
                if (worker.Name.ToUpper() == name.ToUpper())
                {
                    nameIsFound = true;
                    break;
                }
            }
            return nameIsFound;
        }

        public static bool IsExistingObject
            (IEnumerable<Personnel> workers, Personnel toCheck)
        {
            bool isExisting = false;
            if (CollectionContainsName(workers, toCheck.Name))
                isExisting = true;
            return isExisting;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
