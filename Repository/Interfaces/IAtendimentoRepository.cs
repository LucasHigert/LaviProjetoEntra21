using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAtendimentoRepository
    {
        bool Inserir(Atendimento atendimento);

        bool Alerar(Atendimento atendimento);

        bool Apagar(int id);

        List<Atendimento> ObterTodosPeloCargo(int NumeroCargo);

       Atendimento ObterPeloId(int id);
    }
}
