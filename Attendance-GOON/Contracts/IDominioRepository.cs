using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDominioRepository: IRepositoryBase<Dominio>
    {
        Task<IEnumerable<Dominio>> GetAllDominios();
        Task<Dominio> GetOneDominio(string dominio, string valor);
        void CreateDominio(Dominio dominio);
        Task<IEnumerable<Dominio>> GetDiasSemana();
        Task<IEnumerable<Dominio>> GetTipoIdentificacion();

    }
}
