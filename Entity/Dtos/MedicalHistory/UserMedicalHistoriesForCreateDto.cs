using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.MedicalHistory
{
    public class UserMedicalHistoriesForCreateDto : IDto
    {
        public int Id { get; set; }
        public int MedicalHistoryId { get; set; }
        public int UserId { get; set; }
    }
}
