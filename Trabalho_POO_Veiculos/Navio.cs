using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
    class Navio : Veiculo
    {
        public string Atracar()
        {

            if (VelocidadeAtual >0)
            {
                VelocidadeAtual = 0;
                return "O Navio atracou.";
            }
            else
                return "O Navio está parado.";
        }
        public override string ToString()
        {
            return "Identificação: " + Identificacao + " | Modelo: " + Modelo.Descricao + " | Marca: " + Modelo.Marca.Descricao + " | Velocidade: " + VelocidadeAtual+"km/h" + " | Capacidade de passageiros: " + CapacidadeDePassageiros;
        }
        public Navio()
        {

        }
        public Navio(string identificacao, Modelo modelo, int velocidade, int passageiros)
        {
            Identificacao = identificacao;
            Modelo = modelo;
            VelocidadeAtual = velocidade;
            CapacidadeDePassageiros = passageiros;
                        
        }
    }
}
