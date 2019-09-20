using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAtendimentoParteCorpoSintomaRepository
    {
        int Inserir(AtendimentoParteCorpoSintoma atendimentoParteCorpoSintoma);

        bool Alterar(AtendimentoParteCorpoSintoma atendimentoParteCorpoSintoma);

        List<AtendimentoParteCorpoSintoma> ObterTodos();

        bool Apagar(int idSintoma,int idAtendimento);

        List<AtendimentoParteCorpoSintoma> ObterPeloIdAtentimento(int id);

        AtendimentoParteCorpoSintoma ObterPeloIdParteCorpo(int id);
    }
}
