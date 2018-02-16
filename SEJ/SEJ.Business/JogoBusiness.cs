using SEJ.Data;
using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Business
{
    public class JogoBusiness
    {
        JogosData data = new JogosData();

        public void Cadastrar(Jogo jogo)
        {
            data.Cadastrar(jogo);
        }

        public void Alterar(Jogo jogo)
        {
            data.Alterar(jogo);
        }

        public void Excluir(int id)
        {

            var jogo = data.CarregarJogosEmprestados(id);

            if (jogo == null)
            {
                data.Excluir(id);
            }
            else
            {
                throw new Exception();
            }
        }

        public IList<Jogo> CarregarTodos()
        {
            return data.CarregarTodos();
        }

        public Jogo CarregarPorId(int id)
        {
            return data.CarregarPorId(id);
        }

        public IList<Jogo> CarregarNaoEmprestados()
        {
            return data.CarregarNaoEmprestados();
        }
    }
}
