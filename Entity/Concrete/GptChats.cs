using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class GptChats : Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string ResponseId { get; set; }
        public string Model { get; set; }
        public string Usage { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public string SentBy { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
        public GptChats()
        {

        }

        public GptChats(int userId, string responseId, string model,
            string usage, string message, bool status, User user)
        {
            UserId = userId;
            ResponseId = responseId;
            Model = model;
            Usage = usage;
            Message = message;
            Status = status;
            User = user;
        }
    }
}
