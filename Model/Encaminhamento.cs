using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("encaminhamentos")]
    public class Encaminhamento
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("id_posto")]
        public int IdPosto { get; set; }

        [ForeignKey("IdPosto")]
        public Posto Posto { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("traducao_criolo")]
        public string TraducaoCriolo { get; set; }

        [Column("traducao_frances")]
        public string TraducaoFrances { get; set; }

        [Column("local")]
        public string Local { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }

    }
}
