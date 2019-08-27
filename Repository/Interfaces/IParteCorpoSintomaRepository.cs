﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IParteCorpoSintomaRepository
    {
        List<ParteCorpoSintoma> ObterTodos();

        ParteCorpoSintoma ObterPeloId(int id);
    }
}
