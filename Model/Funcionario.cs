﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("funcioarios")]
    public class Funcionario
    {
        [Key, Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        [Column("id_posto")]
        public int IdPosto { get; set; }

        [Column("id_cargo")]
        public int IdCargo { get; set; }

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
