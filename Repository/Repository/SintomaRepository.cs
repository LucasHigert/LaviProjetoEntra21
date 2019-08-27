using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SintomaRepository : ISintomaRepository
    {
        public SistemaContext context;

        public SintomaRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Sintoma sintoma)
        {
            var sintomaAnterior
                = context.Sintomas.FirstOrDefault(x => x.Id == sintoma.Id);
            if (sintoma == null)
                return false;

            sintomaAnterior.IdParteCorpo = sintoma.IdParteCorpo;
            sintomaAnterior.Nome = sintoma.Nome;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var sintoma = context.Sintomas.FirstOrDefault(x => x.Id == id);
            if (sintoma == null)
                return false;

            sintoma.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Sintoma sintoma)
        {
            sintoma.RegistroAtivo = true;
            context.Sintomas.Add(sintoma);
            context.SaveChanges();
            return sintoma.Id;
        }

        public Sintoma ObterPeloId(int id)
        {
            return context.Sintomas.Include("ParteCorpo").FirstOrDefault(x => x.Id == id);
        }

        public List<Sintoma> ObterTodos()
        {
            return context.Sintomas.Where(x => x.RegistroAtivo).ToList();
        }
    }
}
