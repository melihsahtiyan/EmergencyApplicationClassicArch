using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Abstract;

namespace Entity.Dtos.Medication
{
    public class UserMedicationForCreateDto : IDto
    {
        public int Id { get; set; }
        public int MedicationId { get; set; }
        public int UserId { get; set; }
    }
}
