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
            encaminhamentoAnterior.TraducaoCriolo = encaminhamento.TraducaoCriolo;
            encaminhamentoAnterior.TraducaoFrances = encaminhamento.TraducaoFrances;
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
            encaminhamento.Status = 2;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;

          //  var atendimentoOrginal = context.Atendimentos.Where(x => x.Id == id).FirstOrDefault();
          //  if (atendimentoOrginal == null)
          //  {
          //      return false;
          //  }
          //  else
          //  {
          //      atendimentoOrginal.Status = 2;
          //      var rowsAffected = context.SaveChanges();
          //      return rowsAffected == 1;
          //  }
        }

        public int Inserir(Encaminhamento encaminhamento)
        {
            encaminhamento.Status = 0;
            context.Encaminhamentos.Add(encaminhamento);
            context.SaveChanges();
            return encaminhamento.Id;
        }

        public Encaminhamento ObterPeloId(int id)
        {
            return context.Encaminhamentos.Include("Posto").FirstOrDefault(x => x.Id == id);
        }

        public List<Encaminhamento> ObterTodosPeloStatus(int status)
        {
            return context.Encaminhamentos.Include("posto").Where(x => x.Status == status).ToList();
        }
    }
}
