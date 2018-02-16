using SEJ.Data;
using SEJ.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEJ.Business
{
    public class AmigoBusiness
    {
        public IList<Amigo> CarregarTodos()
        {
            var data = new AmigosData();
            return data.CarregarTodos();
        }

        public Amigo CarregarPorId(int id)
        {
            var data = new AmigosData();
            return data.CarregarPorId(id);
        }
        
        public void Cadastrar(Amigo amigo)
        {
            var data = new AmigosData();
            data.Cadastrar(amigo);
        }

        public void Alterar(Amigo amigo)
        {
            var data = new AmigosData();
            data.Alterar(amigo); 
        }

        public void Excluir(int id)
        {
            var data = new AmigosData();

            var amigo = data.CarregarListaAmigosComEmprestimo(id);
            

            if (amigo == null)
            {
                data.Excluir(id);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
