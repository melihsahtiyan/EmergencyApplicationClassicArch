using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.GptChats
{
    public class GptChatsForCreateDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string ResponseId { get; set; }
        public string Model { get; set; }
        public string Usage { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public Entity.Concrete.User User { get; set; }
    }
}
