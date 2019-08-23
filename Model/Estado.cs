using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Estado
    {
        [Table("estados")]
        public class Pessoa
        {
            [Key, Column("id")]
            public int Id { get; set; }

            [Column("nome")]
            public string Nome { get; set; }

            [Column("registro_ativo")]
            public bool RegistroAtivo { get; set; }
        }
    }
}
