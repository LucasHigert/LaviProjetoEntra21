using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("pacientes")]
    public class Paciente
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("id_cidade")]
        public int IdCidade { get; set; }

        [ForeignKey("IdCidade")]
        public Cidade Cidade { get; set; }

        [Column("id_cidade")]
        public int IdCidade { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("sexo")]
        public bool Sexo { get; set; }

        [Column("altura")]
        public decimal Altura { get; set; }

        [Column("peso")]
        public decimal Peso { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }


        [Column("rne")]
        public string Rne { get; set; }

        [Column("passaporte")]
        public string Passaporte { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("telefone")]
        public string Telefone { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }

    }
}
