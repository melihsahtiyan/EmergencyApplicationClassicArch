using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class UserProfile : Entity
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public virtual User User { get; set; }

        public UserProfile()
        {
        }

        public UserProfile(int id, int userId, string phoneNumber, string address,
            string profilePicture) : base()

        {
            Id = id;
            UserId = userId;
            PhoneNumber = phoneNumber;
            Address = address;
            ProfilePicture = profilePicture;
        }
    }
}
