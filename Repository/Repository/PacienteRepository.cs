﻿using Model;
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
            pacienteOriginal.Pressao = paciente.Pressao;
            pacienteOriginal.Idade = paciente.Idade;
            pacienteOriginal.Sexo = paciente.Sexo;
            pacienteOriginal.Altura = paciente.Altura;
            pacienteOriginal.Peso = paciente.Peso;
            pacienteOriginal.Telefone = paciente.Passaporte;
            pacienteOriginal.Rne = paciente.Rne;
            pacienteOriginal.Endereco = paciente.Endereco;
            pacienteOriginal.Posto = paciente.Posto;
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

        public int Inserir(Paciente paciente)
        {
            paciente.RegistroAtivo = true;
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return paciente.Id;
        }

    

        //public List<Paciente> ObterPacientesPeloIdPosto(int idPosto)
        //{
        //    return context.Pacientes.Where(x => x.IdPosto == idPosto && x.RegistroAtivo).ToList();
        //}

        public Paciente ObterPeloId(int id)
        {
            var paciente = context.Pacientes.FirstOrDefault(x => x.Id == id);
            return paciente;
        }

        public List<Paciente> ObterTodos()
        {
            return context.Pacientes
               .Include("Posto")
               .Where(x => x.RegistroAtivo == true)
               .ToList();
        }
    }
}