using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.Category
{
    public class CategoryForCreateDto : IDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
