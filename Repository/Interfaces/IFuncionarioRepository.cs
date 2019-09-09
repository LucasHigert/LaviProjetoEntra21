using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        List<Funcionario> ObterFuncionariosPeloIdPosto(int idPosto);

        List<Funcionario> ObterFuncionarioPeloIdCargo(int idCargo);

        Funcionario ObterPeloId(int id);

        int Inserir(Funcionario funcionario);

        bool Alterar(Funcionario funcionario);

        bool Apagar(int id);

        Funcionario BuscarFuncionario(string login, string senha);
        
    }
}
