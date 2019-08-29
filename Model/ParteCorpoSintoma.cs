using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("partes_corpo_sintomas")]
    public class ParteCorpoSintoma
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("id_sintomas")]
        public int IdSintoma { get; set; }

        [ForeignKey("IdSintoma")]
        public Sintoma Sintoma { get; set; }

        [Column("id_parte_corpo_sintoma")]
        public int IdParteCorpoSintoma { get; set; }

        [ForeignKey("IdParteCorpoSintoma")]
        public AtendimentoParteCorpoSintoma AtendimentoParteCorpoSintoma { get; set; }

        [Column("registro_ativo")]
        public bool RegistroAtivo { get; set; }
    }
}
