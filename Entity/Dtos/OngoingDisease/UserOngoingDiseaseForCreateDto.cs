using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.OngoingDisease
{
    public class UserOngoingDiseaseForCreateDto : IDto
    {
        public int Id { get; set; }
        public int OngoingDiseaseId { get; set; }
        public int UserId { get; set; }
    }
}
