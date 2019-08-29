﻿using System;
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
        [Key, Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_posto")]
        public Posto IdPosto { get; set; }

<<<<<<< HEAD
        [ForeignKey("IdPosto")]
        public Posto Posto { get; set; }

        [Column("id_cargo")]
        public int IdCargo { get; set; }
=======
        [ForeignKey("id_cargo")]
        public Cargo IdCargo { get; set; }
>>>>>>> 1d45a71ca69d1ea578c5ea124b1106d27d3c07c1

        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

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
