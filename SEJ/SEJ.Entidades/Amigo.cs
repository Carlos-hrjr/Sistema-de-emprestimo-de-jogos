using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Entidades
{
    [Table("amigos")]
    public class Amigo
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("nome")]
        [Required]
        public string Nome { get; set; }
        [Column("idade")]
        public int? Idade { get; set; }
        [Column("endereco")]
        public string Endereco { get; set; }
        [Column("bairro")]
        public string Bairro { get; set; }
        [Column("numero")]
        public string Numero { get; set; }
        [Column("ativo")]
        public bool Ativo { get; set; }

    }
}
