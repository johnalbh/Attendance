using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Clase
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int IdHorario { get; set; }
        public int IdFecha { get; set; }

        public virtual Calendario IdFechaNavigation { get; set; }
        public virtual GrupoHorario IdNavigation { get; set; }
    }
}
