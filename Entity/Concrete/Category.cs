using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Category : Entity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostTemplate> PostTemplates { get; set; }

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
