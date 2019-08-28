using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table ("atendimentos_partes_corpo_sintomas")]
    public class AtendimentoParteCorpoSintoma
    {
        [Key, Column ("id")]
        public int Id { get; set; }

        [Column ("id_atendimento")]
        public int IdAtendimento { get; set; }

        [ForeignKey ("IdAtendimento")]
        public AtendimentoParteCorpoSintoma Atendimento { get; set; }

        [Column ("id_parte_corpo")]
        public int IdParteCorpo { get; set; }

        [ForeignKey ("IdParteCorpo")]
        public ParteCorpo ParteCorpo { get; set; }

        [Column ("nivel_dor")]
        public int NiverDor { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }
    }
}
