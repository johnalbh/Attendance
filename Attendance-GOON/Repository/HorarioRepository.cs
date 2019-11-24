using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Repository
{
    public class HorarioRepository : RepositoryBase<Horario>, IHorarioRepository
    {
        public HorarioRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Horario> GetAllHorarios()
        {
            return FindAll()
                .OrderBy(horario => horario.Dia)
                .ToList();
        }

        public IEnumerable<Horario> GetHorarioConDia()
        {
            return RepositoryContext.Horario.FromSql("SP_ConsultarDiaSemanaHorario").ToList();

        }
    }
}

