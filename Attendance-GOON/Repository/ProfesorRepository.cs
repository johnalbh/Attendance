using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Repository
{
    public class ProfesorRepository: RepositoryBase<Profesor>, IProfesorRepository
    {
        public ProfesorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Profesor>> GetAllProfesores()
        {
            // var result = await FindAll().OrderBy(profesor => profesor.Persona.PrimerApellido).ToListAsync();
            return await RepositoryContext.Profesor.AsNoTracking().Include(persona => persona.Persona).Include(x => x.Persona.Profesor).ToListAsync();
        }
    }
}
