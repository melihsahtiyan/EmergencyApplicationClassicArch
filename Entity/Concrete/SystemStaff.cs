using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class SystemStaff : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool StaffStatus { get; set; }
        public string StaffNumber { get; set; }
        public virtual User User { get; set; }

        public SystemStaff()
        {
        }

        public SystemStaff(int id, int userId, bool staffStatus, string staffNumber) : this()

        {
            Id = id;
            UserId = userId;
            StaffStatus = staffStatus;
            StaffNumber = staffNumber;
        }
    }
}
