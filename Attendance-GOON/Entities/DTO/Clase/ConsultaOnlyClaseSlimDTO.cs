﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO.Grupo;
using Entities.Models;

namespace Entities.DTO.Clase
{
    public class ConsultaOnlyClaseSlimDTO
    {
        public int IdClase { get; set; }
        public bool? Asistencia { get; set; }
        public virtual DateTime FechaClase { get; set; }
        public virtual string Materia { get; set; }
        public virtual TimeSpan HoraInicio { get; set; }
        public virtual TimeSpan HoraFin { get; set; }
        public virtual ConsultarGrupoHorarioGrupoSlimDTO Grupo { get; set; }
    }
}
