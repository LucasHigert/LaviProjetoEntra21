using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class EncaminhamentoRepository : IEncaminhamentoRepository
    {
        public SistemaContext context;

        public EncaminhamentoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Encaminhamento encaminhamento)
        {
            var encaminhamentoAnterior = context.Encaminhamentos.FirstOrDefault(x => x.Id == encaminhamento.Id);
            if(encaminhamento == null)
            {
                return false;
            }

            encaminhamentoAnterior.IdPosto = encaminhamento.IdPosto;
            encaminhamentoAnterior.Descricao = encaminhamento.Descricao;
            encaminhamentoAnterior.Local = encaminhamento.Local;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var encaminhamento = context.Encaminhamentos.FirstOrDefault(x => x.Id == id);
            if(encaminhamento == null)
            {
                return false;
            }
            encaminhamento.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;


        }

        public int Inserir(Encaminhamento encaminhamento)
        {
            throw new NotImplementedException();
        }

        public Encaminhamento ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Encaminhamento> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
