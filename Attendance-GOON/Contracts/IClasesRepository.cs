using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Models;

namespace Contracts
{
    public interface IClasesRepository
    {
        Task<IEnumerable<Clase>> GetAllClases();
        Task<IEnumerable<Clase>> GetClaseByProfesor(string tipoIdentificacion, string numeroIdentificacion);
        Task<Clase> GetClaseById(int IdClase);
        void UpdateClase(Clase clase);
    }
}
