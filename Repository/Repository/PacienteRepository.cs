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
