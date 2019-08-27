using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISintomaRepository
    {
        int Inserir(Sintoma sintoma);

        bool Alterar(Sintoma sintoma);

        List<Sintoma> ObterTodos();

        bool Apagar(int id);

        Sintoma ObterPeloId(int id);
    }
}
