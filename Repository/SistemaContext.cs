using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SistemaContext : DbContext
    {
        public SistemaContext() : base("SqlServerConnection") { }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Sintoma> Sintomas { get; set; }
        public DbSet<ParteCorpo> PartesCorpo { get; set; }
        public DbSet<ParteCorpoSintoma> PartesCorpoSintomas { get; set; }
        public DbSet<AtendimentoParteCorpoSintoma> AtendimentosPartesCorpoSintomas { get; set; }
    }
}
