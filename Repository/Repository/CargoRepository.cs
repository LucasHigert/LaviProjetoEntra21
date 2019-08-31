using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private SistemaContext context;
        public CargoRepository()
        {
            context = new SistemaContext();
        }

        public Cargo ObterPeloId(int id)
        {
            var cargo = context.Cargos.FirstOrDefault(x => x.Id == id);
            return cargo;
        }

        public List<Cargo> ObterTodos()
        {
            return context.Cargos.Where(x => x.RegistroAtivo == true).OrderBy(x => x.Id).ToList();
        }
    }
}
