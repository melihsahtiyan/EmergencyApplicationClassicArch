using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Entity.Concrete
{
    public class SystemStaff : User
    {
        public int UserId { get; set; }
        public bool StaffStatus { get; set; }
        public string StaffNumber { get; set; }

        public SystemStaff()
        {
        }

        public SystemStaff(int id, int userId, bool staffStatus, string staffNumber, string email, string firstName,
            string lastName, byte[] passwordHash, byte[] passwordSalt, DateTime date, bool status) : this()

        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            BirthDate = date;
            Status = status;
            UserId = userId;
            StaffStatus = staffStatus;
            StaffNumber = staffNumber;
        }
    }
}
