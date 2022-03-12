using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
    class Modelo
    {
        private int codigo;
        private string descricao;
        private Marca marca;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        internal Marca Marca { get => marca; set => marca = value; }
        public Modelo()
        {

        }
        public Modelo(int codigo, string descricao,Marca marca)
        {
            Codigo = codigo;
            Descricao = descricao;
            Marca = marca;
        }
    }
}
