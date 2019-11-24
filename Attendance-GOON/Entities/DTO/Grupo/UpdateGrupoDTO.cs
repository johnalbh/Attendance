using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Entities.DTO.Grupo
{
    public class UpdateGrupoDTO
    {
        public int IdMateria { get; set; }
        public string TipoIdentificacionEmpleado { get; set; }
        public string NumeroIdentificacionEmpleado { get; set; }

    }
}
