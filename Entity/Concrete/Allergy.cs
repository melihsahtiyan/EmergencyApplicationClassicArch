using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Allergy : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserAllergies> UserAllergies { get; set; }

        public Allergy()
        {
        }

        public Allergy(int id, string name, string description) : base()
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
