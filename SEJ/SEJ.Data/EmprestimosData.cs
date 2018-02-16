using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SEJ.Data
{
    public class EmprestimosData
    {
        public IList<Emprestimo> CarregarTodos()
        {
            using(var ctx = new SEJContext())
            {
                var emprestimos = ctx.Emprestimos
                    .Include(x => x.Jogo)
                    .Include(x => x.Amigo)
                    .Where(x => !x.Devolvido).OrderByDescending(x => x.Id).ToList();

                return emprestimos;
            }
        }

        public IList<Emprestimo> CarregarHistorico()
        {
            using(var ctx = new SEJContext())
            {
                var emprestimos = ctx.Emprestimos
                    .Include(x => x.Jogo)
                    .Include(x => x.Amigo)
                    .OrderByDescending(x => x.DataEmprestimo).ToList();

                return emprestimos;
            }
        }

        public Emprestimo CarregarPorId(int id)
        {
            using (var ctx = new SEJContext())
            {
                return ctx.Emprestimos
                    .Include(x => x.Jogo)
                    .Include(x => x.Amigo)
                    .Single(x => x.Id == id);
            }
        }

        public IList<Emprestimo> CarregarPorAmigo(int id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Emprestimos
                    .Include(x => x.Jogo)
                    .Include(x => x.Amigo)
                    .Where(x => x.IdAmigo == id).ToList();
            }
        }

        public IList<Emprestimo> CarregarPorJogo(int id)
        {
            using(var ctx = new SEJContext())
            {
                return ctx.Emprestimos
                    .Include(x => x.Jogo)
                    .Include(x => x.Amigo)
                    .Where(x => x.IdJogo == id).ToList();
            }
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            using(var ctx = new SEJContext())
            {
                emprestimo.Devolvido = false;
                var emprestado = ctx.Jogos.Single(x => x.Id == emprestimo.IdJogo);
                emprestado.Emprestado = true;
                ctx.Emprestimos.Add(emprestimo);

                ctx.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using(var ctx = new SEJContext())
            {
                var excluido = ctx.Emprestimos.Single(x => x.Id == id);

                ctx.Emprestimos.Remove(excluido);

                ctx.SaveChanges();
            }
        }

        public void Devolver(int id)
        {
            using(var ctx = new SEJContext())
            {
                var devolvido = ctx.Emprestimos.Single(x => x.Id == id);
                var jogo = ctx.Jogos.Single(x => x.Id == devolvido.IdJogo);
                jogo.Emprestado = false;
                devolvido.Devolvido = true;
                devolvido.DataDevolucao = DateTime.Now;

                ctx.SaveChanges();
            }
        }
    }
}
