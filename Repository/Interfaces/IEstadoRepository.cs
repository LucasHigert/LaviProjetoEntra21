using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    interface IEstadoRepository
    {
        List<Estado> ObterTodos();

        Estado ObterPeloId(int id);
    }
}
