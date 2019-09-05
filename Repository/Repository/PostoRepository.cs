using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PostoRepository : IPostoRepository
    {         
        private SistemaContext context;

        public PostoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Posto posto)
        {
            var postoOriginal = context.Postos.FirstOrDefault(x => x.Id == posto.Id);
            if (postoOriginal == null)
                return false;

            postoOriginal.Id = posto.Id;
            postoOriginal.Nome = posto.Nome;
            postoOriginal.IdCidade = posto.IdCidade;
            postoOriginal.Cep = posto.Cep;

            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;


        }

        public bool Apagar(int id)
        {
            var posto = context.Postos
                .FirstOrDefault(x => x.Id == id);
            if (posto == null)
                return false;
            posto.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Posto posto)
        {
            context.Postos.Add(posto);
            context.SaveChanges();
            return posto.Id;
        }

        public Posto ObterPeloId(int id)
        {
            var posto = context.Postos.Include("cidade").FirstOrDefault(x => x.Id == id);
            return posto;
        }

        
        public List<Posto> ObterTodos()
        {
            return context.Postos.Include("cidade").Where(x => x.RegistroAtivo == true).ToList();
        }
    }
}
