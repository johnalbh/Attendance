using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IMateriaRepository: IRepositoryBase<Materia>
    {
        Task<IEnumerable<Materia>> GetAllMaterias();
        Task<int> CountAllMaterias();
        Task<Materia> GetMateriaById(int Id_Materia);
        Task CrearMateria(Materia materia);
        Task UpdateMateria(Materia dbMateria, Materia materia);



    }
}
