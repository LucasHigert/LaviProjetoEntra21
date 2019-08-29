using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private SistemaContext context;

        public FuncionarioRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Funcionario funcionario)
        {
            var funcionarioOriginal = context.Funcionarios.FirstOrDefault(x => x.Id == funcionario.Id);
            if (funcionarioOriginal == null)
                return false;

            funcionarioOriginal.Nome = funcionario.Nome;
            funcionarioOriginal.Login = funcionario.Login;
            funcionarioOriginal.Senha = funcionario.Senha;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var funcionario = context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null) return false;

            funcionario.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Funcionario funcionario)
        {
            funcionario.RegistroAtivo = true;
            context.Funcionarios.Add(funcionario);
            context.SaveChanges();
            return funcionario.Id;
        }

        public List<Funcionario> ObterFuncionarioPeloIdCargo(int idCargo)
        {
            return context.Funcionarios.Where(x => x.IdCargo == idCargo && x.RegistroAtivo).ToList();
        }

        public List<Funcionario> ObterFuncionariosPeloIdPosto(int idPosto)
        {
            return context.Funcionarios.Where(x => x.IdPosto == idPosto && x.RegistroAtivo).ToList();
        }

        public Funcionario ObterPeloId(int id)
        {
            return context.Funcionarios.FirstOrDefault(x => x.Id == id);
        }
    }
}
