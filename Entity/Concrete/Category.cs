using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostTemplates> PostTemplates { get; set; }

        public Category()
        {
            
        }

        public Category(int id,string categoryName):this()
        {
            Id = id;
            CategoryName = categoryName;
        }
    }
}
