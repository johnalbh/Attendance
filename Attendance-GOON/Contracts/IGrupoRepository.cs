using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IGrupoRepository : IRepositoryBase<Grupo> { 
    Task<IEnumerable<Grupo>> GetAllGrupos();
    Task<Grupo> GetGrupoById(int GrupoId);
    void CreateGrupo(Grupo grupo);
    void UpdateGrupo(Grupo grupo);

    }
    public interface IGrupoHorarioRepository : IRepositoryBase<GrupoHorario>
    {
        void CreateGrupoHorario(GrupoHorario grupoHorario);
        GrupoHorario GetGrupoHorarioById(int IdGrupo, int IdHorario);

    }
}

