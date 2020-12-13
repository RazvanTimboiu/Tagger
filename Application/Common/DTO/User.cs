using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Application.DTO
{
    public class User
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
