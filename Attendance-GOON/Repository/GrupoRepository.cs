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
    public class GrupoRepository: RepositoryBase<Grupo>, IGrupoRepository
    {
        public GrupoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Grupo>> GetAllGrupos()
        {
            return await FindAll().OrderBy(m => m.Id)
                .Include(materia => materia.IdMateriaNavigation)
                .Include(profesor => profesor.Profesor)
                .ThenInclude(persona => persona.Persona)
                .ToListAsync();
        }

        public async Task<Grupo> GetGrupoById(int GrupoId)
        {
            return await FindByCondition(grupo => grupo.Id == GrupoId).FirstOrDefaultAsync();
        }

        public void CreateGrupo(Grupo grupo)
        {
            Create(grupo);
        }

        public void UpdateGrupo(Grupo grupo)
        {
            Update(grupo);
        }
    }

}
