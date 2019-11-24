using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace Contracts
{
    public interface IHorarioConDiasRepository
    {
        IEnumerable<HorarioConDiaDTO> GetAllHorarios();
    }
}
