using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IParteCorpoRepository
    {
        bool Inserir(ParteCorpo parteCorpo);

        bool Alterar(ParteCorpo parteCorpo);

        List<ParteCorpo> ObterTodos();

        bool Apagar(int id);

        ParteCorpo ObterPeloId(int id);
    }
}
