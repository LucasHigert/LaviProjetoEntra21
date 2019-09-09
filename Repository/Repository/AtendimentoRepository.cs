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
            var atendimentoOriginal = context.Atendimentos.Where(x => x.Id == atendimento.Id && x.Status != 2).FirstOrDefault();
            if (atendimentoOriginal == null)
            {
                return false;
            }
            else
            {
                atendimentoOriginal.IdEncaminhamento = atendimento.IdEncaminhamento;
                atendimentoOriginal.IdFuncionario = atendimento.IdFuncionario;
                atendimentoOriginal.IdMedico = atendimento.IdMedico;
                atendimentoOriginal.DataAtendimento = atendimento.DataAtendimento;
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
            context.Atendimentos.Add(atendimento);
            var rows = context.SaveChanges();
            return rows == 1;
        }

        public Atendimento ObterPeloId(int id)
        {
            return context.Atendimentos.Where(x => x.Id == id && x.Status != 2).FirstOrDefault();
        }


        public List<Atendimento> ObterTodosPeloCargo(int NumeroCargo)
        {
            //modificar para buscar o atendimento pelo cargo que esta logado
            return context.Atendimentos.Include("Paciente").Where(x => x.Status != 2).OrderByDescending(x => x.Prioridade).ToList();
        }
    }
}
