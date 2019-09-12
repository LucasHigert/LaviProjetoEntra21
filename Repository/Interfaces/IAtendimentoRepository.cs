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

        List<Atendimento> ObterTodosPeloCargoPosto(int NumeroCargo,int IdPosto);

       Atendimento ObterPeloId(int id);

        List<Atendimento> ObterTodosPosto(int posto);
    }
}
