using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.SystemStaff
{
    public class SystemStaffForCreateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool StaffStatus { get; set; }
        public string StaffNumber { get; set; }
    }
}
