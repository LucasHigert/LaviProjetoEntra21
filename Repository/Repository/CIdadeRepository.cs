using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        private SistemaContext context;
        public CidadeRepository()
        {
            context = new SistemaContext();
        }

        public int Inserir(Cidade cidade)
        {
            cidade.RegistroAtivo = true;
            context.Cidades.Add(cidade);
            context.SaveChanges();
            return cidade.Id;
        }

        public bool Alterar(Cidade cidade)
        {
            var cidadeOriginal = context.Cidades.FirstOrDefault(x => x.Id == cidade.Id);
            if (cidadeOriginal == null)
                return false;

            cidadeOriginal.Nome = cidade.Nome;
             
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public Cidade ObterPeloId(int id)
        {
            return context.Cidades.FirstOrDefault(x => x.Id == id);
        }

        public List<Cidade> ObterTodos()
        {
            return context.Cidades
                .Include("Estado")
                .Where(x => x.RegistroAtivo == true)
                .ToList();
        }

        public bool Apagar(int id)
        {
            var cidade = context.Cidades
                .FirstOrDefault(x => x.Id == id);
            if (cidade == null)
                return false;
            cidade.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }
    }
}
