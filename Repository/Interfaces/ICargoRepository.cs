using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICargoRepository
    {
        List<Cargo> ObterTodos();

        Cargo ObterPeloId(int id);
        
        bool Apagar(int id);

        bool Alterar(Cargo cargo);

        int Inserir(Cargo cargo);
    }
}
