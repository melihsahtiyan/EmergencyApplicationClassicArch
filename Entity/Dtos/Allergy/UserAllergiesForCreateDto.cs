using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.Allergy
{
    public class UserAllergiesForCreateDto : IDto
    {
        public int Id { get; set; }
        public int AllergyId { get; set; }
        public int UserId { get; set; }
    }
}
