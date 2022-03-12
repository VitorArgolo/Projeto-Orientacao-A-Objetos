using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
    class NavioDeGuerra : VeiculoDeGuerra
    {
        private string mensagemAtracado;
        private bool statusAtracado;

        public string MensagemAtracado { get => mensagemAtracado; set => mensagemAtracado = value; }
        public bool StatusAtracado { get => statusAtracado; set => statusAtracado = value; }

        public void Atracar()
        {

            if (VelocidadeAtual > 0)
            {
                StatusAtracado = true;
                VelocidadeAtual = 0;
                MensagemAtracado = "O Navio atracou.";
            }
            else
            {
                MensagemAtracado = "O Navio está parado.";
                StatusAtracado = false;
            }
        }
        public override string ToString()
        {
            return "Identificação: " + Identificacao + " | Modelo: " + Modelo.Descricao + " | Marca: " + Modelo.Marca.Descricao + " | Velocidade: " + VelocidadeAtual + "km/h" + " | Capacidade de passageiros: " + CapacidadeDePassageiros+" - Status de Guerra: " + MensagemDeGuerra;
        }
        public NavioDeGuerra()
        {

        }
        public NavioDeGuerra(string identificacao, Modelo modelo, int velocidade, int passageiros)
        {
            Identificacao = identificacao;
            Modelo = modelo;
            VelocidadeAtual = velocidade;
            CapacidadeDePassageiros = passageiros;
            
        }
    }
}
