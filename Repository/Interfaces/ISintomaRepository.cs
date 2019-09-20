﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISintomaRepository
    {
        bool Inserir(Sintoma sintoma);

        bool Alterar(Sintoma sintoma);

        List<Sintoma> ObterTodos();

        List<Sintoma> ObterTodosPeloCorpo(int id);

        bool Apagar(int id);

        Sintoma ObterPeloId(int id);
    }
}
