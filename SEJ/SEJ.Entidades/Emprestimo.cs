using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Entidades
{
    [Table("emprestimos")]
    public class Emprestimo
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("data_emprestimo")]
        public DateTime DataEmprestimo { get; set; }
        [Column("data_devolucao")]
        public DateTime? DataDevolucao { get; set; }

        [Column("id_jogo")]
        public int IdJogo { get; set; }

        [Column("id_amigo")]
        public int IdAmigo { get; set; }

        [Column("devolvido")]
        public bool Devolvido { get; set; }

        [ForeignKey("IdJogo")]
        public Jogo  Jogo { get; set; }

        [ForeignKey("IdAmigo")]
        public Amigo Amigo { get; set; }
    }
}
