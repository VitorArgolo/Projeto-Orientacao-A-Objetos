using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
    class AviaoDeGuerra : VeiculoDeGuerra
    {
        private bool statusDeVoo;
        private string mensagemDeVoo = "Voando";
        public bool StatusDeVoo { get => statusDeVoo; set => statusDeVoo = value; }
        public string MensagemDeVoo { get => mensagemDeVoo; set => mensagemDeVoo = value; }

        public void Pousar()
        {

            if (StatusDeVoo == true)
            {
                VelocidadeAtual = 0;
                StatusDeVoo = false;
                StatusDeGuerra = false;
                StatusDeAtaque();
                MensagemDeVoo = "O avião pousou.";

            }
            else
                MensagemDeVoo = "O avião está parado.";
        }
        public void Arremeter()
        {
            if (StatusDeVoo == false)
            {
                Acelera();
                StatusDeVoo = true;

                MensagemDeVoo = "O avião retomou voo.";
            }
            else
                MensagemDeVoo = "O avião já está em voo.";
        }
        public void Decolar()
        {
            if (StatusDeVoo == false)
            {
                Acelera();
                StatusDeVoo = true;
                MensagemDeVoo = "O avião decolou.";
            }
            else
                MensagemDeVoo = "O avião já está em voo.";
        }

        public void Ejetar()
        {

            StatusDeGuerra = false;
            StatusDeAtaque();
            MensagemDeVoo = "O tripulante ejetou";


        }
        public AviaoDeGuerra()
        {

        }
        public override string ToString()
        {
            return "Identificação: " + Identificacao + " | Modelo: " + Modelo.Descricao + " | Marca: " + Modelo.Marca.Descricao + " | Velocidade: " + VelocidadeAtual + "km/h" + " | Capacidade de passageiros: " + CapacidadeDePassageiros + " - Status de Voo: " + MensagemDeVoo + " - Status de Guerra: " + MensagemDeGuerra;
        }
        public AviaoDeGuerra(string identificacao, Modelo modelo, int velocidade, int passageiros)
        {
            Identificacao = identificacao;
            Modelo = modelo;
            VelocidadeAtual = velocidade;
            CapacidadeDePassageiros = passageiros;
        }
    }
}
