using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
	class Caminhao : VeiculoPesado
	{
		private double pesoCarregado;
		private double capacidadeMaxima;
		
		public double PesoCarregado { get => pesoCarregado; set => pesoCarregado = value; }
		public double CapacidadeMaxima { get => capacidadeMaxima; set => capacidadeMaxima = value; }
		

		public virtual void Carregar(double peso)
		{
			PesoCarregado += peso;
		}

		public void Descarregar()
		{
			PesoCarregado = 0;
		}

		public override void Limpador()
		{
			if (StatusLimpador == true)
				MensagemLimpador = "Limpador do veículo caminhão ligado.";
			else
				MensagemLimpador = "Limpador do veículo caminhão desligado.";
		}

		public override void LimpadorLigado()
		{
			MensagemLimpador = "Limpador do veículo caminhão ligado.";
			StatusLimpador = true;
		}


		public override void LimpadorDesligado()
		{
			MensagemLimpador = "Limpador do veículo caminhão desligado.";
			StatusLimpador = false;
		}
		public override void Acelera()
		{
			if (PesoCarregado < CapacidadeMaxima)
			{
				base.Acelera();
			}
			else
				throw new Exception("O veiculo não pode acelerar.");
		}

		public override string ToString()
		{
			return base.ToString() + " | Peso: " + pesoCarregado +"kg"+ " | Quantidade de Eixos: " + QuantidadeDeEixos + " | Carga Maxima: " + capacidadeMaxima+"kg";
		}
		public Caminhao()
		{
			if (pesoCarregado >= CapacidadeMaxima)
				VelocidadeAtual = 0;
			
				
		}
		public Caminhao(string identificacao, Modelo modelo, int velocidade, int passageiros, bool limpador, int peso, int quantidadeEixos, double cargamaxima)
		{
			Identificacao = identificacao;
			Modelo = modelo;
			if (pesoCarregado >= CapacidadeMaxima)
				VelocidadeAtual = 0;
			else
				VelocidadeAtual = velocidade;
			CapacidadeDePassageiros = passageiros;
			StatusLimpador = limpador;
			Limpador();
			PesoCarregado = peso;
			QuantidadeDeEixos = quantidadeEixos;
			CapacidadeMaxima = cargamaxima;
		}
	}
}
