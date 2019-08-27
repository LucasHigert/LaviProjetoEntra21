using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface ICidadeRepository
    {
        List<Cidade> ObterCidadesPeloIdEstado(int idEstado);

        Cidade ObterPeloId(int id);

        int Inserir(Cidade cidade);

        bool Alterar(Cidade cidade);

        bool Apagar(int id);
    }
}
