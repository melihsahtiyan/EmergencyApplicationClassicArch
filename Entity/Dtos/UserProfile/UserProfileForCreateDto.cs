using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.UserProfile
{
    public class UserProfileForCreateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public string BloodType { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Gender { get; set; }
    }
}
