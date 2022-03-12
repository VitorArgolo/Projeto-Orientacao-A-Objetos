using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
	class Aviao : VeiculoLimpador
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
				MensagemDeVoo = "O avião pousou.";
			}
			else
				MensagemDeVoo = "O avião está parado.";
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

		public override void Limpador()
		{
			if (StatusLimpador == true)
				MensagemLimpador = "Limpador do veículo avião ligado.";
			else
				MensagemLimpador = "Limpador do veículo avião desligado.";
		}

		public override void LimpadorLigado()
		{
			MensagemLimpador = "Limpador do veículo avião ligado.";
			StatusLimpador = true;
		}


        public override void LimpadorDesligado()
		{
			MensagemLimpador = "Limpador do veículo avião desligado";
			StatusLimpador = false;
		}

        public override string ToString()
        {
            return base.ToString()+" - Status de Voo: "+MensagemDeVoo;
        }
        public Aviao()
		{

		}
		public Aviao(string identificacao, Modelo modelo, int velocidade, int passageiros, bool limpador)
		{
			Identificacao = identificacao;
			Modelo = modelo;
			VelocidadeAtual = velocidade;
			CapacidadeDePassageiros = passageiros;
			StatusLimpador = false;
			Limpador();
		}
	}
}
