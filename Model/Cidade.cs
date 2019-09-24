﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("cidades")]
    public class Cidade
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [StringLength(22, ErrorMessage = "O nome deve ser menor que {12} caracteres.")]
        [Column("nome")]
        public string Nome { get; set; }

        [Column ("id_estado")]
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }
    }
}
