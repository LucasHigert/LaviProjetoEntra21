using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("funcionarios")]
    public class Funcionario
    {
        [Key, Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        [ForeignKey("id_posto")]
        public Posto IdPosto { get; set; }

        [ForeignKey("id_cargo")]
        public Cargo IdCargo { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }
    }
}
