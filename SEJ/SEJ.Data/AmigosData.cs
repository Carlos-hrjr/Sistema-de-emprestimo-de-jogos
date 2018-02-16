using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Data
{
    public class AmigosData
    {
        public IList<Amigo> CarregarTodos()
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Amigos.Where(x => x.Ativo).ToList();
            }
        }

        public Amigo CarregarPorId(int id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Amigos.Single(x => x.Id == id);
            }
        }

        public void Cadastrar(Amigo amigo)
        {
            using(var ctx = new SEJContext())
            {
                amigo.Ativo = true;
                ctx.Amigos.Add(amigo);

                ctx.SaveChanges();
            }
        }

        public void Alterar(Amigo amigo)
        {
            using(var ctx = new SEJContext())
            {
                var alterado = ctx.Amigos.Single(x => x.Id == amigo.Id);
                alterado.Nome = amigo.Nome;
                alterado.Idade = amigo.Idade;
                alterado.Endereco = amigo.Endereco;

                ctx.SaveChanges();
            }
        }

        public Emprestimo CarregarListaAmigosComEmprestimo(int id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Emprestimos.SingleOrDefault(x => x.IdAmigo == id && !x.Devolvido);
            }
        }

        public void Excluir(int id)
        {
            using(var ctx = new SEJContext())
            {
                var excluido = ctx.Amigos.Single(x => x.Id == id);
                
                    excluido.Ativo = false;

                    ctx.SaveChanges();
             }
        }
    }
}
