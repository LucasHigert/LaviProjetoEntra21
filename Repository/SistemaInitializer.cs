using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Repository
{
    //internal class SistemaInitializer : DropCreateDatabaseAlways<SistemaContext>
    internal class SistemaInitializer : DropCreateDatabaseAlways<SistemaContext>
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



            base.Seed(context);
        }
    }
}