using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPersonaRepository: IRepositoryBase<Persona>
    {
        Task<IEnumerable<Persona>> GetAllOwnersAsync();
        Task<Persona> GetOwnerByIdAsync(Guid ownerId);

    }
}
