using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Entity.Concrete
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string IdentityNumber { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual SystemStaff SystemStaff { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Contact> ContactUsers { get; set; }
        public virtual ICollection<GptChats> GptChats { get; set; }

        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
        }


        public User(int id, string email, string firstName, string lastName, string identityNumber, byte[] passwordHash,
            byte[] passwordSalt, DateTime birthDate, bool status) : this()
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IdentityNumber = identityNumber;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            BirthDate = birthDate;
            Status = status;
        }
    }


}
