using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.SystemStaff
{
    public class SystemStaffForRegisterDto : IDto
    {
        public int UserId { get; set; }
        public bool StaffStatus { get; set; }
        public string StaffNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
