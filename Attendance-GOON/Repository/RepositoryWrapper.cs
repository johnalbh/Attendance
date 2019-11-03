using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IPersonaRepository _persona;
        private IMateriaRepository _materia;
        private IProfesorRepository _profesor;

        public IPersonaRepository Persona
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaRepository(_repoContext);
                }

                return _persona;
            }
        }

        public IMateriaRepository Materia
        {
            get
            {
                if (_materia == null)
                {
                    _materia = new MateriaRepository(_repoContext);
                }

                return _materia;
            }
        }

        public IProfesorRepository Profesor
        {
            get
            {
                if (_profesor == null)
                {
                    _profesor = new ProfesorRepository(_repoContext);
                }

                return _profesor;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void save()
        {
            _repoContext.SaveChanges();
        }
    }
}
