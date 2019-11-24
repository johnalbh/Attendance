using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    class HorarioDiasRepository : RepositoryBase<HorarioConDiaDTO>, IHorarioConDiasRepository
    {
        public HorarioDiasRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<HorarioConDiaDTO> GetAllHorarios()
        {
            var results = RepositoryContext.Query<HorarioConDiaDTO>()
                .FromSql("SP_ConsultarDiaSemanaHorario")
                .ToList();
            return results;
        }
    }
}
