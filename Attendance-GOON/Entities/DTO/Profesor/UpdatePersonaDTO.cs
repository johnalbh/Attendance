using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Profesor
{
    public class UpdatePersonaDTO
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string UrlFoto { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
