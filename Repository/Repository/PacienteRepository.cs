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

            pacienteOriginal.IdPosto = paciente.IdPosto;
            pacienteOriginal.Nome = paciente.Nome;
            pacienteOriginal.Idade = paciente.Idade;
            pacienteOriginal.Cpf = paciente.Cpf;
            pacienteOriginal.Rne = paciente.Rne;
            pacienteOriginal.Passaporte = paciente.Passaporte;
            pacienteOriginal.Endereco = paciente.Endereco;
            pacienteOriginal.Telefone = paciente.Telefone;
            pacienteOriginal.Cep = paciente.Cep;
            pacienteOriginal.Lingua = paciente.Lingua;
            pacienteOriginal.Sexo = paciente.Sexo;
            pacienteOriginal.Altura = paciente.Altura;
            pacienteOriginal.Peso = paciente.Peso;
            pacienteOriginal.Pressao = paciente.Pressao;
            pacienteOriginal.Temperatura = paciente.Temperatura;

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

        public bool Inserir(Paciente paciente)
        {
            paciente.RegistroAtivo = true;
            context.Pacientes.Add(paciente);
            int rows = context.SaveChanges();
            return rows == 1;
        }

        //Tela atendimento especial busca o nome do paciente estrangeiro
        public List<Paciente> ObterEstrangeiroNome(string nome, int posto)
        {
            List<Paciente> lista = context.Pacientes
                            .Where(x => x.Nome.Contains(nome) && x.IdPosto == posto && x.Lingua != 1)
                            .ToList();
            return lista;
        }

        public Paciente ObterPeloId(int id)
        {
            var paciente = context.Pacientes.FirstOrDefault(x => x.Id == id);
            return paciente;
        }

        //Tela de documentos
        public List<Paciente> ObterPeloNome(string nome, int posto)
        {
            List<Paciente> lista = context.Pacientes
                .Where(x => x.Nome.Contains(nome) && x.IdPosto == posto)
                .ToList();
            return lista;
        }
        public List<Paciente>ObterValores(string nome, string posto, string cidade)
        {
            return context.Pacientes
                .Include("Posto")
                .Include("Cidade")
           
                .Where(x => x.RegistroAtivo == true)
                .ToList();
        }
        public List<Paciente> ObterTodos()
        {
            return context.Pacientes
               .Include("Posto")
               .Where(x => x.RegistroAtivo == true)
               .ToList();
        }

        //Tela index de paciente mostrar os pacientes do posto da pessoa logada
        public List<Paciente> ObterTodosPosto(int posto)
        {
            return context.Pacientes
            .Include("Posto")
            .Where(x => x.RegistroAtivo == true && x.IdPosto == posto)
            .ToList();
        }
    }
}