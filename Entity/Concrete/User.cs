using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Enums;


namespace Entity.Concrete
{
    public class User : global::Entity.Concrete.Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

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
