using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private SistemaContext context = new SistemaContext();

        public bool Alerar(Atendimento atendimento)
        {
            var atendimentoOriginal = context.Atendimentos.Where(x => x.Id == atendimento.Id && x.Status != 3).FirstOrDefault();
            if (atendimentoOriginal == null)
            {
                return false;
            }
            else
            {
                atendimentoOriginal.IdEncaminhamento = atendimento.IdEncaminhamento;
                atendimentoOriginal.IdMedico = atendimento.IdMedico;
                atendimentoOriginal.Tratamento = atendimento.Tratamento;
                atendimentoOriginal.Prioridade = atendimento.Prioridade;
                atendimentoOriginal.Status = atendimento.Status;
                atendimentoOriginal.Observacao = atendimento.Observacao;
                atendimentoOriginal.Pressao = atendimento.Pressao;

                var rowsAffected = context.SaveChanges();

                return rowsAffected == 1;

            }
        }

        public bool Apagar(int id)
        {
            var atendimentoOrginal = context.Atendimentos.Where(x => x.Id == id).FirstOrDefault();
            if (atendimentoOrginal == null)
            {
                return false;
            }
            else
            {
                atendimentoOrginal.Status = 2;
                var rowsAffected = context.SaveChanges();
                return rowsAffected == 1;
            }

        }

        public bool Inserir(Atendimento atendimento)
        {
            atendimento.DataCriacao = DateTime.Now;
            context.Atendimentos.Add(atendimento);
            var rows = context.SaveChanges();
            return rows == 1;
        }

        public Atendimento ObterPeloId(int id)
        {
            return context.Atendimentos.Include("Paciente").Where(x => x.Id == id).FirstOrDefault();
        }


        public List<Atendimento> ObterTodosPeloCargoPosto(int NumeroCargo,int IdPosto)
        {
            //modificar para buscar o atendimento pelo cargo que esta logado
            return context.Atendimentos.Include("Paciente").Include("funcionario")
                .Where((x => x.Status == NumeroCargo && x.IdPosto == IdPosto))
                .OrderByDescending(x => x.Prioridade)
                .OrderBy(x => x.DataCriacao).ToList();
        }

        public List<Atendimento> ObterTodosPosto(int posto)
        {
            return context.Atendimentos.Include("Paciente").Include("funcionario").Where(x=> x.IdPosto == posto).OrderByDescending(x => x.Prioridade).ToList();
        }
    }
}
