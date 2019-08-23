using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{

    class EstadoRepository : IEstadoRepository
    {
        private SistemaContext context;
        public EstadoRepository()
        {
            context = new SistemaContext();
        }

        public Estado ObterPeloId(int id)
        {
            var estado = context.Estados.FirstOrDefault(x => x.Id == id);
            return estado;
        }

        public List<Estado> ObterTodos()
        {
            return context.Estados.Where(x => x.RegistroAtivo == true).OrderBy(x => x.Id).ToList();
        }
    }
}
