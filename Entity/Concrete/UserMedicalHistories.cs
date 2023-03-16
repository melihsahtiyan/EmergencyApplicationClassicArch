using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class UserMedicalHistories : Entity
    {
        public int UserId { get; set; }
        public int MedicalHistoryId { get; set; }
        public virtual MedicalHistory MedicalHistory { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        
        public UserMedicalHistories()
        {
        }

        public UserMedicalHistories(int id, int userId, int allergyId) : base()
        {
            Id = id;
            UserId = userId;
        }
    }
}
