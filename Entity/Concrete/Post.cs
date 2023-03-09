using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;  
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Source> Sources { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }

        public Post()
        {

        }

        public Post(int id, int categoryId, int userId, string description, DateTime date, double latitude,
            double longitude, string title) : this()

        {
            Id = id;
            CategoryId = categoryId;
            UserId = userId;
            Description = description;
            Date = date;
            Latitude = latitude;
            Longitude = longitude;
            Title = title;
        }
    }
}