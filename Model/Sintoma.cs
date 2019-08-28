using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("sintomas")]
    public class Sintoma
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("id_parte_corpo")]
        public int IdParteCorpo { get; set; }

        [ForeignKey("IdParteCorpo")]
        public ParteCorpo ParteCorpo { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("traducao_criolo")]
        public string TraducaoCriolo { get; set; }

        [Column("traducao_frances")]
        public string TraducaoFrances { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }
    }
}
