using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class PacienteRepository : IPacienteRepository
    {
        private SistemaContext context;
        
        public PacienteRepository()
        {
            context = new SistemaContext();
        }
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
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return paciente.Id;
        }

        public List<Paciente> ObterPacientesPeloIdCidade(int IdCidade)
        {
            throw new NotImplementedException();
        }

        public Paciente ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
