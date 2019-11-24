using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Grupo;

namespace Entities.DTO.Materia
{
    public class ConsultarMateriaGrupoSlimDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ConsultaGrupoSinMateriaDTO> Grupo { get; set; }
    }
}
