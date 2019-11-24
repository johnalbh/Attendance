using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class PeriodoLectivo
    {
        public int Id { get; set; }
        public int AnioInicio { get; set; }
        public int AnioFin { get; set; }
        public string Descripcion { get; set; }
        public bool AnioActivo { get; set; }
        public DateTime FechaInicioPeriodo { get; set; }
        public DateTime FechaFinPeriodo { get; set; }
    }
}
