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
                Id = 1,
                Nome = "Acre",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 2,
                Nome = "Alagoas",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 3,
                Nome = "Amazonas",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 4,
                Nome = "Amapá",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 5,
                Nome = "Bahia",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 6,
                Nome = "Ceará",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 7,
                Nome = "Distrito Federal",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 8,
                Nome = "Espírito Santo",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 9,
                Nome = "Goiás",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 10,
                Nome = "Maranhão",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 11,
                Nome = "Minas Gerais",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 12,
                Nome = "Mato Grosso do Sul",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 13,
                Nome = "Mato Grosso",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 14,
                Nome = "Pará",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 15,
                Nome = "Paraía",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 16,
                Nome = "Pernambuco",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 17,
                Nome = "Piauí",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 18,
                Nome = "Paraná",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 19,
                Nome = "Rio de Janeiro",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 20,
                Nome = "Rio Grande",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 21,
                Nome = "Rondônia",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 22,
                Nome = "Roraima",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 23,
                Nome = "Rio Grande",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 24,
                Nome = "Santa Catarina",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 25,
                Nome = "Sergipe",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 26,
                Nome = "São Paulo",
                RegistroAtivo = true
            });
            estados.Add(new Estado()
            {
                Id = 27,
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
                Id = 1,
                IdEstado = 24,
                Nome = "Blumenau",
                RegistroAtivo = true
            });
            cidades.Add(new Cidade()
            {
                Id = 2,
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
                Id = 1,
                IdCidade = 1,
                Nome = "Velha Centro",
                Cep = "89046-231",
                RegistroAtivo = true
            });
            postos.Add(new Posto()
            {
                Id = 2,
                IdCidade = 2,
                Nome = "ESF Walter Reiter",
                Cep = "89095-535",
                RegistroAtivo = true
            });
            postos.Add(new Posto()
            {
                Id = 3,
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
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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
            
            #region cargos
            var cargo = new List<Cargo>();
            #region CargosAdicionar
            cargo.Add(new Cargo()
            {
                Id = 1,
                Nome = "Atendente",
                RegistroAtivo = true,
                NivelPermissao = 1
            });
            cargo.Add(new Cargo()
            {
                Id = 2,
                Nome = "Médico",
                RegistroAtivo = true,
                NivelPermissao = 3
            });
            cargo.Add(new Cargo()
            {
                Id = 3,
                Nome = "Enfermeiro",
                RegistroAtivo = true,
                NivelPermissao = 2
            });
            cargo.Add(new Cargo()
            {
                Id = 4,
                Nome = "Administrador",
                RegistroAtivo = true,
                NivelPermissao = 4
            });
            #endregion
            context.Cargos.AddRange(cargo);
            #endregion

            #region funcionários 
            var funcionario = new List<Funcionario>();
            #region FuncionáriosAdicinonar
            funcionario.Add(new Funcionario()
            {
                Id = 1,
                IdPosto = 1,
                IdCargo = 1,
                Nome = "Tiffany Carlene",
                Login = "TiffanyCarlene",
                Senha = "carlezinha123",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 2,
                IdPosto = 1,
                IdCargo = 2,
                Nome = "Roberto Francisco Sagaz",
                Login = "RobertoSagaz",
                Senha = "medicotop",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 3,
                IdPosto = 1,
                IdCargo = 3,
                Nome = "Vanessa Revineia",
                Login = "Revineia",
                Senha = "triagemboa",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 4,
                IdPosto = 1,
                IdCargo = 4,
                Nome = "Josefina Carla",
                Login = "Josefa",
                Senha = "amomeufilho",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 5,
                IdPosto = 2,
                IdCargo = 2,
                Nome = "Marilene Peixes",
                Login = "MarilenePeixe",
                Senha = "olamarilene",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 6,
                IdPosto = 2,
                IdCargo = 3,
                Nome = "Gabriel Tirone",
                Login = "Tirone",
                Senha = "deusefiel",
                RegistroAtivo = true
            });
            funcionario.Add(new Funcionario()
            {
                Id = 7,
                IdPosto = 2,
                IdCargo = 4,
                Nome = "Lavi Adm",
                Login = "Lavi",
                Senha = "entra21",
                RegistroAtivo = true
            });
            #endregion
            context.Funcionarios.AddRange(funcionario);
            #endregion

            #region partesCorpo
            var parteCorpo = new List<ParteCorpo>();
            #region PartesCorpoAdicionar
            parteCorpo.Add(new ParteCorpo()
            {
                Id = 1,
                Nome = "Cabeça",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 2,
                Nome = "Rosto",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 3,
                Nome = "Dedo",
                RegistroAtivo = true
            });
            parteCorpo.Add(new ParteCorpo()
            {
                Id = 4,
                Nome = "Braço",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Estomago",
                RegistroAtivo = true
            });
            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Barriga",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Estomago",
                RegistroAtivo = true
            });
            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Perna",
                RegistroAtivo = true
            });
            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Genitalia",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Pé",
                RegistroAtivo = true
            });

            parteCorpo.Add(new ParteCorpo()
            {
                Id = 5,
                Nome = "Dedo Pé",
                RegistroAtivo = true
            });

            context.PartesCorpo.AddRange(parteCorpo);
            #endregion

            #endregion

            #region Sintomas
            var sintomas = new List<Sintoma>();
            sintomas.Add(new Sintoma()
            {
                IdParteCorpo = 1,
                Nome = "Dor de cabeça",
                TraducaoCriolo = "Maltèt",
                TraducaoFrances = "Mal de tête",
                RegistroAtivo = true


            });
            sintomas.Add(new Sintoma()
            {
                IdParteCorpo = 2,
                Nome = "Dor nos olhos",
                TraducaoCriolo = "Doulè nan je",
                TraducaoFrances = "Douleur oculaire",
                RegistroAtivo = true

            });
            context.Sintomas.AddRange(sintomas);
            #endregion
            base.Seed(context);
        }
    }
}