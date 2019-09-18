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
            {
                return false;
            }

            sintomaAnterior.IdParteCorpo = sintoma.IdParteCorpo;
            //sintomaAnterior.TraducaoCriolo = sintoma.TraducaoCriolo;
            //sintomaAnterior.TraducaoFrances = sintoma.TraducaoFrances;
            sintomaAnterior.Nome = sintoma.Nome;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var sintoma = context.Sintomas.FirstOrDefault(x => x.Id == id);
            if (sintoma == null)
            {
                return false;
            }

            sintoma.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Inserir(Sintoma sintoma)
        {
            var sintomaOriginal = context.Sintomas.Where(x => x.Nome == sintoma.Nome && x.RegistroAtivo == true).FirstOrDefault();
            if (sintomaOriginal == null)
            {
                context.Sintomas.Add(sintoma);
                int rows = context.SaveChanges();
                return rows == 1;
            }
            else
            {
                return false;
            }
        }

        public Sintoma ObterPeloId(int id)
        {
            return context.Sintomas.Include("ParteCorpo").FirstOrDefault(x => x.Id == id);
        }

        public List<Sintoma> ObterTodos()
        {
            return context.Sintomas.Include("partecorpo").Where(x => x.RegistroAtivo == true).ToList();
        }
    }
}
