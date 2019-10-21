using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ApplicationUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
