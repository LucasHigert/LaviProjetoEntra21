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
                
        public Posto ObterPeloId(int id)
        {
            var posto = context.Postos.FirstOrDefault(x => x.Id == id);
            return posto;
        }

        
        public List<Posto> ObterTodos()
        {
            return context.Postos.Where(x => x.RegistroAtivo == true).OrderBy(x => x.Id).ToList();
        }
    }
}
