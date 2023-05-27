using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class UserOngoingDisease : Entity
    {
        public int UserId { get; set; }
        public int OngoingDiseaseId { get; set; }
        public virtual OngoingDisease OngoingDisease { get; set; }
        public virtual User User { get; set; }
        
        public UserOngoingDisease()
        {
        }

        public UserOngoingDisease(int id, int userId, int allergyId) : base()
        {
            Id = id;
            UserId = userId;
        }
    }
}
