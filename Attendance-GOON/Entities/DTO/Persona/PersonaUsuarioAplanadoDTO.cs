using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DTO.Persona
{
    public class PersonaUsuarioAplanadoDTO
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string userName { get; set; }
        public string email { get; set; }

        public string NombreCompleto { get; set; }
    }
}
