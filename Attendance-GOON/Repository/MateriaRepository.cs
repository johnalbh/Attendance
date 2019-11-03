using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Extensions;
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

        public async Task<Materia> GetMateriaById(int Id_Materia)
        {
            return await FindByCondition(materia => materia.Id.Equals(Id_Materia)).DefaultIfEmpty(new Materia()).SingleAsync();
        }

        public async Task CrearMateria(Materia materia)
        {
            Create(materia);
            await SaveAsync();
        }

        public async Task UpdateMateria(Materia dbMateria, Materia materia)
        {
            dbMateria.Map(materia);
            Update(dbMateria);
            await SaveAsync();
        }
    }
}
