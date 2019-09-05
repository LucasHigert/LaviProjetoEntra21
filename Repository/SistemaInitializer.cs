using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository
{
    internal class SistemaInitializer : DropCreateDatabaseAlways<SistemaContext>
    //internal class SistemaInitializer : CreateDatabaseIfNotExists<SistemaContext>
    {

        protected override void Seed(SistemaContext context)
        {
            #region estados 
            var estados = new List<Estado>();

            #region EstadosAdicionar
            estados.Add(new Estado()
            {
                Nome = "Acre",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Alagoas",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Amazonas",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Amapá",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Bahia",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Ceará",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Distrito Federal",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Espírito Santo",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Goiás",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Maranhão",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Minas Gerais",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Mato Grosso do Sul",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Mato Grosso",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Pará",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Paraía",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Pernambuco",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Piauí",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Paraná",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Rio de Janeiro",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Rio Grande",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Rondônia",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Roraima",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Rio Grande",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Santa Catarina",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Sergipe",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "São Paulo",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Nome = "Tocantins",
                RegistroAtivo = true
            });

            #endregion
            context.Estados.AddRange(estados);
            #endregion

            #region cidades
            var cidades = new List<Cidade>();
            #region CidadeAdicionar
            cidades.Add(new Cidade()
            {
                IdEstado = 24,
                Nome = "Blumenau",
                RegistroAtivo = true
            });
            cidades.Add(new Cidade()
            {
                IdEstado = 24,
                Nome = "Gaspar",
                RegistroAtivo = true
            });
            #endregion
            context.Cidades.AddRange(cidades);
            #endregion

            #region postos
            var postos = new List<Posto>();
            #region PostoAdicionar
            postos.Add(new Posto()
            {
                IdCidade = 1,
                Nome = "Salto do Norte",
                Cep = "89027-031",
                RegistroAtivo = true
            });
            postos.Add(new Posto()
            {
                IdCidade = 1,
                Nome = "Velha Centro",
                Cep = "89046-231",
                RegistroAtivo = true
            });
            postos.Add(new Posto()
            {
                IdCidade = 2,
                Nome = "ESF Walter Reiter",
                Cep = "89095-535",
                RegistroAtivo = true
            });
            postos.Add(new Posto()
            {
                IdCidade = 1,
                Nome = "Garcia",
                Cep = "89037-690",
                RegistroAtivo = true
            });
            #endregion
            context.Postos.AddRange(postos);
            #endregion

            #region pacientes
            var paciente = new List<Paciente>();
            #region PacienteAdicionar

            paciente.Add(new Paciente()
            {
                IdPosto = 1,
                Nome = "Leticia Rodriguez Garcia",
                Endereco = "Rua Anna Fischer 80",
                Cep = "89068-022",
                Idade = 35,
                Sexo = false,
                Altura = 1.74,
                Peso = 63.2,
                Cpf = "963.842.780-90",
                Rne = "V565371-S",
                Passaporte = " ",
                Telefone = "4798856-0458",
                RegistroAtivo = true
            });
            paciente.Add(new Paciente()
            {
                IdPosto = 1,
                Nome = "Maiara Ilinoi Cardoso",
                Endereco = "Rua Noel Rosa 10",
                Cep = "89057-420",
                Idade = 18,
                Sexo = false,
                Altura = 1.50,
                Peso = 50.2,
                Cpf = "267.450.960-05",
                Rne = "K568371-F",
                Passaporte = " ",
                Telefone = "4799241-5064",
                RegistroAtivo = true
            });
            paciente.Add(new Paciente()
            {
                IdPosto = 2,
                Nome = "Pedro Alexandre Madeiro",
                Endereco = "Rua Curitiba 55",
                Cep = "89012-412",
                Idade = 42,
                Sexo = true,
                Altura = 1.82,
                Peso = 82,
                Cpf = "769.127.850-00",
                Rne = "R5653971-J",
                Passaporte = " ",
                Telefone = " ",
                RegistroAtivo = true
            });
            #endregion
            context.Pacientes.AddRange(paciente);
            #endregion

            base.Seed(context);
        }
    }
}