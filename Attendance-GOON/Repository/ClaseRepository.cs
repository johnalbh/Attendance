using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClaseRepository: RepositoryBase<Clase>, IClasesRepository
    {
        public ClaseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Clase>> GetAllClases()
        {
            var respon =   await RepositoryContext.Clase.AsNoTracking()
                .Include(c => c.IdFechaNavigation)
                .Include(c => c.IdNavigation)
                    .ThenInclude(x => x.IdGrupoNavigation)
                        .ThenInclude(z => z.IdMateriaNavigation)
                .Include(x => x.IdNavigation)
                    .ThenInclude(pro => pro.IdGrupoNavigation)
                    .ThenInclude(profe => profe.Profesor)
                    .ThenInclude(persona => persona.Persona)
                .Include(x => x.IdNavigation)
                .ThenInclude(horario => horario.IdHorarioNavigation)

                .ToListAsync();

            return respon;

        }

        public async Task<IEnumerable<Clase>> GetClaseByProfesor(string TipoIdentificacion, string  NumeroIdentificacion)
        {
            return await FindByCondition(profesor =>
                profesor.IdNavigation.IdGrupoNavigation.Profesor.TipoIdentificacion.Equals(TipoIdentificacion) &&
                profesor.IdNavigation.IdGrupoNavigation.Profesor.NumeroIdentificacion.Equals(NumeroIdentificacion)
            ).Include(c => c.IdFechaNavigation)
                .Include(c => c.IdNavigation)
                .ThenInclude(x => x.IdGrupoNavigation)
                .ThenInclude(z => z.IdMateriaNavigation)
                .Include(x => x.IdNavigation)
                .ThenInclude(pro => pro.IdGrupoNavigation)
                .ThenInclude(profe => profe.Profesor)
                .ThenInclude(persona => persona.Persona)
                .Include(x => x.IdNavigation)
                .ThenInclude(horario => horario.IdHorarioNavigation)

                .ToListAsync();
        }

        public async Task<Clase> GetClaseById(int IdClase)
        {
            return await FindByCondition(clase => clase.Id == IdClase)
                .Include(c => c.IdFechaNavigation)
                .Include(c => c.IdNavigation)
                .ThenInclude(x => x.IdGrupoNavigation)
                .ThenInclude(z => z.IdMateriaNavigation)
                .Include(x => x.IdNavigation)
                .ThenInclude(pro => pro.IdGrupoNavigation)
                .ThenInclude(profe => profe.Profesor)
                .ThenInclude(persona => persona.Persona)
                .Include(x => x.IdNavigation)
                .ThenInclude(horario => horario.IdHorarioNavigation)
                .FirstOrDefaultAsync();
        }

        public void UpdateClase(Clase clase)
        {
            Update(clase);
        }
    }
}
