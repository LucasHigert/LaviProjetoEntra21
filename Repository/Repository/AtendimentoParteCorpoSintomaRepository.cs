using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class AtendimentoParteCorpoSintomaRepository : IAtendimentoParteCorpoSintomaRepository
    {
        public SistemaContext context;

        public AtendimentoParteCorpoSintomaRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(AtendimentoParteCorpoSintoma atendimentoParteCorpoSintoma)
        {
            var atendimentoParteCorpoSintomaAnterior = context.AtendimentosPartesCorpoSintomas.FirstOrDefault(x => x.Id == atendimentoParteCorpoSintoma.Id);
            if (atendimentoParteCorpoSintoma == null)
            {
                return false;
            }

            atendimentoParteCorpoSintomaAnterior.IdAtendimento = atendimentoParteCorpoSintoma.IdAtendimento;
            atendimentoParteCorpoSintomaAnterior.IdParteCorpo = atendimentoParteCorpoSintoma.IdParteCorpo;
            atendimentoParteCorpoSintomaAnterior.NiverDor = atendimentoParteCorpoSintoma.NiverDor;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var atendimentoParteCorpoSintoma = context.AtendimentosPartesCorpoSintomas.FirstOrDefault(x => x.Id == id);
            if (atendimentoParteCorpoSintoma == null)
            {
                return false;
            }

            atendimentoParteCorpoSintoma.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(AtendimentoParteCorpoSintoma atendimentoParteCorpoSintoma)
        {
            atendimentoParteCorpoSintoma.RegistroAtivo = true;
            context.AtendimentosPartesCorpoSintomas.Add(atendimentoParteCorpoSintoma);
            context.SaveChanges();
            return atendimentoParteCorpoSintoma.Id;
        }

        public AtendimentoParteCorpoSintoma ObterPeloIdAtentimento(int id)
        {
            return context.AtendimentosPartesCorpoSintomas.Include("Atendimento").FirstOrDefault(x => x.Id == id);
        }

        public AtendimentoParteCorpoSintoma ObterPeloIdParteCorpo(int id)
        {
            return context.AtendimentosPartesCorpoSintomas.Include("ParteCorpo").FirstOrDefault(x => x.Id == id);
        }

        public List<AtendimentoParteCorpoSintoma> ObterTodos()
        {
            return context.AtendimentosPartesCorpoSintomas.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
