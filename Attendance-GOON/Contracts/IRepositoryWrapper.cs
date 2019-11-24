using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPersonaRepository Persona { get; }
        IMateriaRepository Materia { get; }
        IProfesorRepository Profesor { get; }
        IGrupoRepository Grupo { get;  }
        IDominioRepository Dominio { get; }
        IParametrosRepository Parametro { get; }
        IHorarioRepository Horario { get; }
        IHorarioConDiasRepository Horarios { get; }
        IClasesRepository Clases { get;  }

        IGrupoHorarioRepository GrupoHorario { get;  }
        Task SaveAsync();
    }
}
