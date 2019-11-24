using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        private IGrupoRepository _grupo;
        private IDominioRepository _dominio;
        private IParametrosRepository _parametro;
        private IHorarioRepository _horario;
        private IHorarioConDiasRepository _horarioDias;
        private IClasesRepository _clases;
        private IGrupoHorarioRepository _grupoHorario;

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

        public IGrupoRepository Grupo
        {
            get
            {
                if (_grupo == null)
                {
                    _grupo = new GrupoRepository(_repoContext);
                }

                return _grupo;

            }
        }

        public IDominioRepository Dominio
        {
            get
            {
                if (_dominio == null)
                {
                    _dominio = new DominioRepository(_repoContext);
                }

                return _dominio;

            }
        }

        public IParametrosRepository Parametro
        {
            get
            {
                if (_parametro == null)
                {
                    _parametro = new ParametrosRepository(_repoContext);
                }

                return _parametro;

            }
        }

        public IHorarioRepository Horario
        {
            get
            {
                if (_horario == null)
                {
                    _horario = new HorarioRepository(_repoContext);
                }

                return _horario;

            }
        }

        public IHorarioConDiasRepository Horarios
        {
            get
            {
                if (_horarioDias == null)
                {
                    _horarioDias = new HorarioDiasRepository(_repoContext);
                }

                return _horarioDias;

            }
        }

        public IClasesRepository Clases
        {
            get
            {
                if (_clases == null)
                {
                    _clases = new ClaseRepository(_repoContext);
                }

                return _clases;

            }
        }

        public IGrupoHorarioRepository GrupoHorario
        {
            get
            {
                if (_grupoHorario == null)
                {
                    _grupoHorario = new GrupoHorarioRepository(_repoContext);
                }

                return _grupoHorario;

            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
