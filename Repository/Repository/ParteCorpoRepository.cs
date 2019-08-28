using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ParteCorpoRepository : IParteCorpoRepository
    {
        public SistemaContext context;

        public ParteCorpoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(ParteCorpo parteCorpo)
        {
            var parteCorpoAnterior = context.PartesCorpo.FirstOrDefault(x => x.Id == parteCorpo.Id);

            if (parteCorpo == null)
            {
                return false;
            }

            parteCorpoAnterior.Nome = parteCorpo.Nome;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var parteCorpo = context.PartesCorpo.FirstOrDefault(x => x.Id == id);

            if (parteCorpo == null)
            {
                return false;
            }

            parteCorpo.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();

            return quantidadeAfetada == 1;
        }

        public bool Inserir(ParteCorpo parteCorpo)
        {
            // irá buscar o banco se já tem um registro com aquele nome, caso não irá cadastrar
            var parteOriginal = context.PartesCorpo.Where(x => x.Nome == parteCorpo.Nome).FirstOrDefault();
            if (parteOriginal == null)
            {
                context.PartesCorpo.Add(parteCorpo);
                context.SaveChanges();
                return parteCorpo.Id == 1;
            }
            else
            {
                return false;
            }
        }

        public ParteCorpo ObterPeloId(int id)
        {
            var parteCorpo = context.PartesCorpo.FirstOrDefault(x => x.Id == id && x.RegistroAtivo == true);
            return parteCorpo;
        }

        public List<ParteCorpo> ObterTodos()
        {
            return context.PartesCorpo.Where(x => x.RegistroAtivo == true).OrderBy(x => x.Id).ToList();
        }
    }
}
