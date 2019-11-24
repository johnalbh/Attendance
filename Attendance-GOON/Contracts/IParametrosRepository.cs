using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IParametrosRepository
    {
        Task<IEnumerable<Parametro>> GetAllParametros();
        Task<Parametro> GetParametroByCodigo(int codigo);
    }
}
