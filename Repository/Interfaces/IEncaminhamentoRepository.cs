using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IEncaminhamentoRepository
    {
        int Inserir(Encaminhamento encaminhamento);

        bool Alterar(Encaminhamento encaminhamento);

        List<Encaminhamento> ObterTodosPeloStatus(int status);

        bool Apagar(int id);

        Encaminhamento ObterPeloId(int id);
        
    }
}
