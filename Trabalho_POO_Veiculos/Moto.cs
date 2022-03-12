using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
    class Moto : Veiculo
    {
        public string mensagemEmpinar = "Não empinado...";
        public void Empinar()
        {
            mensagemEmpinar = "Enpinando...";
        }
        public void Desempinar()
        {
            mensagemEmpinar = "Não empinado...";
        }
        public override double PagarPedagio()
        {
            return 3;
        }
        public override string ToString()
        {
            return "Identificação: " + Identificacao + " | Modelo: " + Modelo.Descricao + " | Marca: " + Modelo.Marca.Descricao + " | Velocidade: " + VelocidadeAtual+"km/h" + " | Capacidade de passageiros: " + CapacidadeDePassageiros + " | "+mensagemEmpinar;
        }
        public Moto()
        {

        }
        public Moto(string identificacao, Modelo modelo, int velocidade, int passageiros, bool limpador)
        {
            Identificacao = identificacao;
            Modelo = modelo;
            VelocidadeAtual = velocidade;
            CapacidadeDePassageiros = passageiros;
           
        }
    }
}
