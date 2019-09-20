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

        [Column("id_posto")]
        public int IdPosto { get; set; }

        [ForeignKey("IdPosto")]
        public Posto Posto { get; set; }

        //parte da recepção
        [Column("nome")]
        public string Nome { get; set; }

        [Column("idade")]
        public int Idade { get; set; }

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

        [Column("cep")]
        public string Cep { get; set; }

        [Column("lingua")]
        public int Lingua { get; set; }

        //parte triagem
        [Column("sexo")]
        public bool Sexo { get; set; }

        [Column("altura")]
        public double Altura { get; set; }

        [Column("peso")]
        public double Peso { get; set; }

        [Column("pressao")]
        public string Pressao { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }

        [Column("temperatura")]
        public double Temperatura { get; set; }
    }
}
