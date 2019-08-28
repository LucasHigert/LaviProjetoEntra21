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
            var pacienteOriginal = context.Pacientes.FirstOrDefault(x => x.Id == paciente.Id);

            if (pacienteOriginal == null)
                return false;

            pacienteOriginal.Nome = paciente.Nome;
            pacienteOriginal.Cpf = paciente.Cpf;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;
        }

        public bool Apagar(int id)
        {
            var paciente = context.Pacientes.FirstOrDefault(x => x.Id == id);
            //Caso específico em que somente a linha abaixo do if/else pertence à condiição
            /*if (paciente == null)
                return false;
            paciente.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();
            return quantidadeAfetada == 1;*/

            if (paciente == null)
            {
                return false;
            }

            paciente.RegistroAtivo = false;
            int quantidadeAfetada = context.SaveChanges();

            return quantidadeAfetada == 1;
        }

        public int Inserir(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return paciente.Id;
        }

        public List<Paciente> ObterPacientesPeloIdCidade(int idCidade)
        {

            return context.Pacientes
        .Where(x => x.IdCidade == idCidade
            && x.RegistroAtivo)
        .ToList();
        }

        public Paciente ObterPeloId(int id)
        {
            var paciente = context.Pacientes.FirstOrDefault(x => x.Id == id);
            return paciente;
        }
    }
}
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
        private SistemaContext context = new SistemaContext();

        public bool Alterar(Paciente paciente)
        {
            var pacienteOriginal = context.Paciente.Where(x => x.Id == paciente.Id && x.RegistroAtivo == true).FirstOrDefault();
            if (pacienteOriginal == null )
            {
                return false;
            }
            else
            {
                pacienteOriginal.Cidade.Id = paciente.Cidade.Id;
                pacienteOriginal.Nome = paciente.Nome;
                pacienteOriginal.Cep = paciente.Cep;
                pacienteOriginal.Sexo = paciente.Sexo;
                pacienteOriginal.Altura = paciente.Altura;
                pacienteOriginal.Peso = paciente.Peso;
                pacienteOriginal.Cpf = paciente.Cpf;
                pacienteOriginal.Rne = paciente.Rne;
                pacienteOriginal.Passaporte = paciente.Passaporte;
                pacienteOriginal.Endereco = paciente.Endereco;
                pacienteOriginal.Telefone = paciente.Telefone;
                paciente.RegistroAtivo = true;

                var rowsAffected = context.SaveChanges();

                return rowsAffected == 1;
            }
        }

        public bool Apagar(int id)
        {
            var pacienteOriginal = context.Paciente.Where(x => x.Id == id && x.RegistroAtivo == true).FirstOrDefault();
            if (pacienteOriginal == null)
            {
                return false;
            }
            else
            {
                pacienteOriginal.RegistroAtivo = false;
                int rowsAffected = context.SaveChanges();
                return rowsAffected == 1;
            }

        }

        public int Inserir(Paciente paciente)
        {
            paciente.RegistroAtivo = true;
            context.Paciente.Add(paciente);
            context.SaveChanges();
            return paciente.Id;
        }

        public Paciente ObterPeloId(int id)
        {
            return context.Paciente.Where(x => x.Id == id && x.RegistroAtivo == true).FirstOrDefault();
            
        }

        public List<Paciente> ObterTodos()
        {
            return context.Paciente.Where(x => x.RegistroAtivo == true).ToList();
        }
    }
}
