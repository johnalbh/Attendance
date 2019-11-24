using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace Entities.Models
{
    public class ConsultaMateriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ConsultaGrupoDTO> Grupo { get; set; }
    }
}
