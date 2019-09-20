using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPacienteRepository
    {

        bool Inserir(Paciente paciente);

        bool Alterar(Paciente paciente);

        //List<Paciente> ObterPacientesPeloIdPosto(int idPosto);

        bool Apagar(int id);

        List<Paciente> ObterPeloNome(string nome);

        List<Paciente> ObterTodos();

        Paciente ObterPeloId(int id);
    }
}
