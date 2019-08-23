using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    class PacienteRepository : IPacienteRepository
    {
        public bool Alterar(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> ObterPacientesPeloIdCidade(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public Paciente ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
