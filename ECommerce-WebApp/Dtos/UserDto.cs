using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Dtos
{
    public class UserDto :BaseDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
       

        public string email { get; set; }

        public string Role { get; set; } = "User";
        public string password { get; set; }

    }
}
