using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.GptChats
{
    public class GptChatsForListDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string ResponseId { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
