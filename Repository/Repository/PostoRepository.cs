using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    class PostoRepository : IPostoRepository
    {         
        private SistemaContext context;
        public PostoRepository()
        {
            context = new SistemaContext();
        }

        Posto IPostoRepository.ObterPeloId(int id)
        {
            var posto = context.Postos.FirstOrDefault(x => x.IdPosto == id);
            return posto;
        }

        List<Posto> IPostoRepository.ObterTodos()
        {
            return context.Postos.Where(x => x.RegistroAtivo == true).OrderBy(x => x.IdPosto).ToList();
        }
    }
}
