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
        Paciente ObterPeloId(int id);

        int Inserir(Paciente paciente);

        bool Alterar(Paciente paciente);

        bool Apagar(int id);

        List<Paciente> ObterPacientesPeloIdCidade(int idPaciente);


    }

}
