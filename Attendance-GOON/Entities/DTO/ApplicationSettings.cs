using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ApplicationSettings
    {
        public string JWTSecret { get; set; }
        public string Client_URL { get; set; }
    }
}
