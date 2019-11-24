using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class GrupoHorarioRepository : RepositoryBase<GrupoHorario>, IGrupoHorarioRepository
    {
        public GrupoHorarioRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public void CreateGrupoHorario(GrupoHorario grupoHorario)
        {
            Create(grupoHorario);
        }


        public GrupoHorario GetGrupoHorarioById(int IdGrupo, int IdHorario)
        {
            return FindByCondition(grupoHorario => grupoHorario.IdGrupo == IdGrupo && grupoHorario.IdHorario == IdHorario)
                .FirstOrDefault();
        }
    }
}
