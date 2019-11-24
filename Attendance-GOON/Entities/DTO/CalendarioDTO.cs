using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO
{
    public class CalendarioDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int NumeroDia { get; set; }

    }
}
