using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Entidades
{
    [Table("jogos")]
    public class Jogo
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("distribuidora")]
        public string Distribuidora { get; set; }
        [Column("emprestado")]
        public bool Emprestado { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }

    }
}
