using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Materia;

namespace Entities.DTO.Grupo
{
    public class ConsultaGrupoMateriaDTO
    {
        public int Id { get; set; }
        public int NumGrupo { get; set; }
        public int IdMateria { get; set; }
        public string TipoIdentificacionEmpleado { get; set; }
        public string NumeroIdentificacionEmpleado { get; set; }
        public virtual ConsultarMateriaSlimDTO IdMateriaNavigation { get; set; }
    }
}
