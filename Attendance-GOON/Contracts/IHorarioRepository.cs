using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Models;

namespace Contracts
{
    public interface IHorarioRepository
    {
        IEnumerable<Horario> GetAllHorarios();
        IEnumerable<Horario> GetHorarioConDia();

    }
}
