using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MateriaRepository: RepositoryBase<Materia>, IMateriaRepository
    {
        public MateriaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Materia>> GetAllMaterias()
        {
            return await FindAll()
                .OrderBy(materia => materia.Nombre)
                .ToListAsync();
        }
    }
}
