using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.Post
{
    public class PostDetailDto : IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public int Age { get; set; }
        public string[]? Allergies { get; set; }
        public string[]? Diseases { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public string Title { get; set; }
    }
}
