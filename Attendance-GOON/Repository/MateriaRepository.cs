using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

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

                .Include(grupoProfesor => grupoProfesor.Grupo)
                .ThenInclude(profesor => profesor.Profesor)
                .ThenInclude(persona => persona.Persona)
                .Include(grupoHorario => grupoHorario.Grupo)
                .ThenInclude(grupoHorario => grupoHorario.GrupoHorario)
                .ThenInclude(horario => horario.IdHorarioNavigation)

                .ToListAsync();
        }

        public async Task<int> CountAllMaterias()
        {
            var prueba = await FindAll().OrderBy(materia => materia.Nombre).ToListAsync();
            return  prueba.Count();
        }

        public async Task<Materia> GetMateriaById(int Id_Materia)
        {
            return await FindByCondition(materia => materia.Id == Id_Materia)
                .Include(grupoProfesor => grupoProfesor.Grupo)
                .ThenInclude(profesor => profesor.Profesor)
                .ThenInclude(persona => persona.Persona)
                .Include(grupoHorario => grupoHorario.Grupo)
                .ThenInclude(grupoHorario => grupoHorario.GrupoHorario)
                .ThenInclude(horario => horario.IdHorarioNavigation)
                .FirstOrDefaultAsync();
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
