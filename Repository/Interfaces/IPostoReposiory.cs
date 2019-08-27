using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPostoReposiory
    {
        List<Posto> ObterTodos();

        Posto ObterPeloId(int id);
    }
}
