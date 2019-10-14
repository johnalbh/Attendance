﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IPersonaRepository Persona { get; }
        IMateriaRepository Materia { get; }
        void save();
    }
}
