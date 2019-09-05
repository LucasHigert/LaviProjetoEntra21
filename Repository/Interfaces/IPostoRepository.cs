using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPostoRepository
    {
        List<Posto> ObterTodos();

        Posto ObterPeloId(int id);

        bool Apagar(int id);

        bool Alterar(Posto posto);

        int Inserir(Posto posto);
    }
}
