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

        int Inserir(Paciente paciente);

        bool Alterar(Paciente paciente);

        List<Paciente> ObterPacientesPeloIdCidade(int IdCidade);

        bool Apagar(int id);


        List<Paciente> ObterTodos();

        Paciente ObterPeloId(int id);
    }
}
