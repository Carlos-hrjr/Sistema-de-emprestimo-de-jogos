using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEJ.Entidades;

namespace SEJ.Data
{
    public class SEJContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }

        public DbSet<Amigo> Amigos { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        public SEJContext() : base("Banco1")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
