using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Materia;
using Entities.Models;

namespace Entities.DTO
{
    public class ConsultaGrupoDTO
    {
        public int Id { get; set; }
        public int NumGrupo { get; set; }
        public int IdMateria { get; set; }
        public string TipoIdentificacionEmpleado { get; set; }
        public string NumeroIdentificacionEmpleado { get; set; }
        public virtual ConsultarMateriaSlimDTO Materia { get; set; }
        public virtual ProfesorDTO Profesor { get; set; }

    }
}
