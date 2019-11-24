using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Persona;
using Entities.Models;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace Entities.DTO.Clase
{
    public class ConsultaClaseSlimDTO
    {
        public int IdClase { get; set; }
        public bool? Asistencia { get; set; }
        public virtual DateTime FechaClase { get; set; }
        public virtual string Materia { get; set; }
        public virtual TimeSpan HoraInicio { get; set; }
        public virtual TimeSpan HoraFin { get; set; }
        public virtual int Grupo { get; set; }
        public virtual ConsultarPersonaSlimDTO profesor { get; set; }
    }
}
