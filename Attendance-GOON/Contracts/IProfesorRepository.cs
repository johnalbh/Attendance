using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface  IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllProfesores();
        Task<Profesor> GetProfesorById(string tipoIdentificacion, string numeroIdentificacion);
        Task<Profesor> GetProfesorByIdWithMaterias(string tipoIdentificacion, string numeroIdentificacion);
        void CreateProfesor(Profesor profesor);
        void UpdateProfesor(Profesor profesor);

    }
}
    