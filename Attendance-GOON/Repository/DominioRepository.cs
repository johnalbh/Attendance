using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Repository
{
    public class DominioRepository: RepositoryBase<Dominio>, IDominioRepository
    {
        public DominioRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Dominio>> GetAllDominios()
        {
            return await FindAll().OrderBy(dom => dom.Dominio1).ToListAsync();
        }

        public async Task<Dominio> GetOneDominio(string dominio, string valor)
        {
            return await FindByCondition(dominioP => dominioP.Dominio1.Equals(dominio) && dominioP.Valor.Equals(valor))
                .FirstOrDefaultAsync();
        }

        public void CreateDominio(Dominio dominio)
        {
            Create(dominio);
        }

        public async Task<IEnumerable<Dominio>> GetDiasSemana()
        {
            return await FindAll().Where(dom => dom.Dominio1.Equals("DiaSemana")).OrderBy(dom => dom.Dominio1).ToListAsync();
        }

        public async Task<IEnumerable<Dominio>> GetTipoIdentificacion()
        {
            return await FindAll().Where(dom => dom.Dominio1.Equals("TipoDocumento")).OrderBy(dom => dom.Dominio1).ToListAsync();

        }
    }
}
