using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Persona;
using Entities.Models;

namespace Entities.DTO
{
    public class ProfesorDTO
    {

        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ConsultarPersonaDTO Persona { get; set; }
    }
}
