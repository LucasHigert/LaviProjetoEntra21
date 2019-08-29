using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("atendimentos")]
    public class Atendimento
    {
        [Key,Column("id")]
        public int Id { get; set; }

        [Column("id_encaminhamento")]
        public int IdEncaminhamento { get; set; }

        [ForeignKey("IdEncaminhamento")]
        public Encaminhamento Encaminhamento { get; set; }

        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }

        [ForeignKey("IdFuncionario")]
        public Funcionario Funcionario { get; set; }

        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [ForeignKey("IdPaciente")]
        public Paciente Paciente { get; set; }

        [Column("id_funcionario_medico")]
        public int IdMedico { get; set; }

        [ForeignKey("IdMedico")]
        public Funcionario Medico { get; set; }

        [Column("data_atendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("tratamento")]
        public string Tratamento { get; set; }

        [Column("prioridade")]
        public int Prioridade { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }

        [Column("pressao")]
        public string Pressao { get; set; }
    }
}
