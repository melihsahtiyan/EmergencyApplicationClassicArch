using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Contact : Entity
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public string ContactRelation { get; set; }
        public virtual User User { get; set; }
        public virtual User ContactUser { get; set; }

        public Contact()
        {
        }

        public Contact(int id,int userId, int contactId, string contactRelation):base()
        {
            Id = id;
            UserId = userId;
            ContactId = contactId;
            ContactRelation = contactRelation;
        }
    }
}
