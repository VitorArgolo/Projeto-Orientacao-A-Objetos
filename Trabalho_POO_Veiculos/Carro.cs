using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_POO_Veiculos
{
	class Carro : VeiculoLimpador
	{
		private int quantidadeDePortas;

		public int QuantidadeDePortas { get => quantidadeDePortas; set => quantidadeDePortas = value; }

		public List<Modelo> listaModelo()
		{
			List<Modelo> l = new List<Modelo>();
			modelo = new Modelo(1, "Gol", new Marca(1, "VW"));
			l.Add(Modelo);
			modelo = new Modelo(2, "Celta", new Marca(2, "GM"));
			l.Add(Modelo);
			return l;
		}

		Modelo modelo = new Modelo();
		
		public override void Limpador()
		{
			if (StatusLimpador == true)
				MensagemLimpador = "Limpador do veículo carro ligado. ";
			else
				MensagemLimpador = "Limpador do veículo carro desligado. ";
		}

		public override void LimpadorLigado()
		{
			MensagemLimpador = "Limpador do veículo carro ligado. ";
			StatusLimpador = true;
		}


		public override void LimpadorDesligado()
		{
			MensagemLimpador = "Limpador do veículo carro desligado. ";
			StatusLimpador = false;
		}
		public override double PagarPedagio()
		{
			return 7;
		}
		public override string ToString()
		{
			return base.ToString() + " | Portas: " + QuantidadeDePortas;
		}
		public Carro()
		{

			

		}

		public Carro(string identificacao, Modelo modelo, int velocidade, int passageiros, bool limpador, int portas)
		{
			Identificacao = identificacao;
			Modelo = modelo;
			VelocidadeAtual = velocidade;
			CapacidadeDePassageiros = passageiros;
			StatusLimpador = limpador;
			Limpador();
			QuantidadeDePortas = portas;

		}
	}
}

