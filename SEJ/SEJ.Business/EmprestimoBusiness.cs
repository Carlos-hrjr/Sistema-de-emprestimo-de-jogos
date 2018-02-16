using SEJ.Data;
using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Business
{
    public class EmprestimoBusiness
    {
        EmprestimosData data = new EmprestimosData();

        public IList<Emprestimo> CarregarTodos()
        {
            return data.CarregarTodos();
        }

        public IList<Emprestimo> CarregarHistorico()
        {
            return data.CarregarHistorico();
        }

        public Emprestimo CarregarPorId(int id)
        {
            return data.CarregarPorId(id);
        }

        public IList<Emprestimo> CarregarPorAmigo(int id)
        {
            return data.CarregarPorAmigo(id);
        }

        public IList<Emprestimo> CarregarPorJogo(int id)
        {
            return data.CarregarPorJogo(id);
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            data.Cadastrar(emprestimo);
        }

        public void Excluir(int id)
        {
            data.Excluir(id);
        }

        public void Devolver(int id)
        {
            data.Devolver(id);
        }
    }
}
