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
    public class ParametrosRepository: RepositoryBase<Parametro>, IParametrosRepository
    {
        public ParametrosRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Parametro>> GetAllParametros()
        {
            return await FindAll().OrderBy(para => para.Codigo).ToListAsync();
        }

        public async Task<Parametro> GetParametroByCodigo(int codigo)
        {
            return await FindByCondition(parametro => parametro.Codigo == codigo)
                .FirstOrDefaultAsync();
        }
    }
}
