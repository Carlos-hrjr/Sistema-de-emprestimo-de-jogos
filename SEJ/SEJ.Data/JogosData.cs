using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Data
{
    public class JogosData
    {
        public IList<Jogo> CarregarTodos()
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Jogos.Where(x => x.Ativo).OrderBy(x => x.Id).ToList();
            }
        }

        public void Cadastrar(Jogo jogo)
        {
            using(var ctx = new SEJContext())
            {
                jogo.Emprestado = false;
                jogo.Ativo = true;
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Alterar(Jogo jogo)
        {
            using(var ctx = new SEJContext())
            {
                var alterado = ctx.Jogos.Single(x => x.Id == jogo.Id);
                alterado.Descricao = jogo.Descricao;
                alterado.Distribuidora = jogo.Distribuidora;
                alterado.Valor = jogo.Valor;

                ctx.SaveChanges();
            }
        }

        public IList<Jogo> CarregarNaoEmprestados()
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Jogos.Where(x => !x.Emprestado && x.Ativo).ToList();
            }
        }

        public Jogo CarregarPorId(int? id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Jogos.Single(x => x.Id == id && x.Ativo);
            }
        }

        public Emprestimo CarregarJogosEmprestados(int id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Emprestimos.SingleOrDefault(x => x.IdJogo == id && !x.Devolvido);
            }
        }

        public void Excluir(int id)
        {
            using(var ctx = new SEJContext())
            {
                var removido = ctx.Jogos.Single(x => x.Id == id);
                removido.Ativo = false;
                ctx.SaveChanges();
            }
        }
    }
}
