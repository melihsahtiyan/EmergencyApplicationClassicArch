using System;
using System.Collections.Generic;
using System.Text;
using Entity.Abstract;

namespace Core.Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
