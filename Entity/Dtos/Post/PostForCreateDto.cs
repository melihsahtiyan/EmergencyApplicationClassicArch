using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Post
{
    public class PostForCreateDto:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set;}
        public int CategoryId { get; set; }
    }
}
