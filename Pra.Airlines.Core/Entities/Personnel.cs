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
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
