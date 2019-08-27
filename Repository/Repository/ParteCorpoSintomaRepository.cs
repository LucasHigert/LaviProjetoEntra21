using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ParteCorpoSintomaRepository : IParteCorpoSintomaRepository
    {
        public SistemaContext context;

        public ParteCorpoSintomaRepository()
        {
            context = new SistemaContext();
        }


        public ParteCorpoSintoma ObterPeloId(int id)
        {
            var parteCorpoSintoma = context.PartesCorpoSintomas.FirstOrDefault(x => x.Id == id);
            return parteCorpoSintoma;
        }

        public List<ParteCorpoSintoma> ObterTodos()
        {
            return context.PartesCorpoSintomas.Where(x => x.RegistroAtivo == true).OrderBy(x => x.Id).ToList();
        }
    }
}
