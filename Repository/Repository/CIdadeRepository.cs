using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    class CidadeRepository : IEstadoRepository
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

        public List<Cidade> ObterCidadesPeloIdEstado(int idEstado)
        {
            throw new NotImplementedException();
        }

        public Estado ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Estado> ObterTodos()
        {
            throw new NotImplementedException();
        }

        Cidade IEstadoRepository.ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
