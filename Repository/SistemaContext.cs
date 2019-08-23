using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SistemaContext: DbContext
    {
        public SistemaContext() : base("SqlServerConnection") { }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
    }
}
