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
    public class PersonaRepository: RepositoryBase<Persona>, IPersonaRepository
    {
        public PersonaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Persona>> GetAllOwnersAsync()
        {
            return await FindAll()
                .OrderBy(x => x.NumeroIdentificacion
                )
                .ToListAsync();
        }

        public Task<Persona> GetOwnerByIdAsync(Guid ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
