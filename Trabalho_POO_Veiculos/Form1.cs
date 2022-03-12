using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_POO_Veiculos
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Marca m = new Marca();
        Modelo mod = new Modelo();

        List<Marca> dadosMarca = new List<Marca>();
        List<Marca> dadosMarca1 = new List<Marca>();
        List<Modelo> dadosModelo = new List<Modelo>();
        List<Modelo> dadosModelo1 = new List<Modelo>();
        List<Pedagio> dadosPedagio = new List<Pedagio>();
        List<Veiculo> dadosVeiculo = new List<Veiculo>();


        public Form1()
        {
            InitializeComponent();
            SelecoesDeInicio();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoMarca = 0;
                int codigoModelo = 0;
                string c = cbMarcas.Text;
                string d = cbModelo.Text;

                if (d == "AG" || d == "VW" || d == "Marcopolo" || d == "Honda" || d == "Embraer" ||
                    d == "Northrop" || d == "GE" || d == "Maersk" || d == "Ford")
                    codigoMarca = 1;
                else
                    codigoMarca = 2;
                if (c == "Gol" || c == "Agrale 9200" || c == "G7" || c == "Cargo" || c == "Embraer 175" ||
                    c == "Night Hawk" || c == "U20C" || c == "Honam" || c == "CVN78")
                    codigoModelo = 1;
                else
                    codigoModelo = 2;
                Marca marca = new Marca()
                {
                    Codigo = codigoMarca,
                    Descricao = cbMarcas.Text
                };
                dadosMarca1.Add(marca);
                Modelo modelo = new Modelo()
                {
                    Codigo = codigoModelo,
                    Descricao = cbModelo.Text,
                    Marca = dadosMarca1[dadosVeiculo.Count]
                };
                dadosModelo1.Add(modelo);
                if (cbVeiculo.Text == "Carro")
                {
                    Carro carro = new Carro()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = dadosModelo1[dadosVeiculo.Count],
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text),
                        StatusLimpador = cbLimpador.Text == "Ligado",
                        QuantidadeDePortas = Convert.ToInt32(tbPortas.Text)
                    };
                    dadosVeiculo.Add(carro);
                }
                else if (cbVeiculo.Text == "Caminhão")
                {
                    Caminhao caminhao = new Caminhao()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text),
                        StatusLimpador = cbLimpador.Text == "Ligado",
                        PesoCarregado = Convert.ToInt32(tbPesoCarregado.Text),
                        QuantidadeDeEixos = Convert.ToInt32(tbQuantidadeEixosCaminhao.Text),
                        CapacidadeMaxima = Convert.ToDouble(tbCapacidadeMax.Text)
                    };
                    dadosVeiculo.Add(caminhao);
                }
                else if (cbVeiculo.Text == "Ônibus")
                {
                    Onibus onibus = new Onibus()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text),
                        StatusLimpador = cbLimpador.Text == "Ligado",
                        QuantidadeDeEixos = Convert.ToInt32(tbQuantidadeEixosCaminhao.Text),
                        Leito = cbLeito.Text == "Sim"
                    };
                    dadosVeiculo.Add(onibus);
                }
                else if (cbVeiculo.Text == "Moto")
                {
                    Moto moto = new Moto()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text)
                    };
                    dadosVeiculo.Add(moto);
                }
                else if (cbVeiculo.Text == "Avião")
                {
                    Aviao aviao = new Aviao()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text),
                        StatusLimpador = cbLimpador.Text == "Ligado"
                    };
                    dadosVeiculo.Add(aviao);
                }
                else if (cbVeiculo.Text == "Avião de Guerra")
                {
                    AviaoDeGuerra aviaoDeGuerra = new AviaoDeGuerra()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text)
                    };
                    dadosVeiculo.Add(aviaoDeGuerra);
                }
                else if (cbVeiculo.Text == "Trem")
                {
                    Trem trem = new Trem()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text),
                        StatusLimpador = cbLimpador.Text == "Ligado",
                        QuantidadeDeVagoes = Convert.ToInt32(tbVagoes.Text)
                    };
                    dadosVeiculo.Add(trem);
                }
                else if (cbVeiculo.Text == "Navio")
                {
                    Navio navio = new Navio()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text)
                    };
                    dadosVeiculo.Add(navio);
                }
                else if (cbVeiculo.Text == "Navio de Guerra")
                {
                    NavioDeGuerra navioDeGuerra = new NavioDeGuerra()
                    {
                        Identificacao = tbIdentificacao.Text,
                        Modelo = new Modelo(cbModelo.SelectedIndex + 1, cbModelo.Text, new Marca(cbMarcas.SelectedIndex + 1, cbMarcas.Text)),
                        VelocidadeAtual = Convert.ToInt32(tbVelocidade.Text),
                        CapacidadeDePassageiros = Convert.ToInt32(tbPassageiros.Text)
                    };
                    dadosVeiculo.Add(navioDeGuerra);
                }
                GravarArquivo();
                cbIdentificacaoPedagio.DataSource = null;
                cbIdentificacaoPedagio.DataSource = dadosVeiculo;
                cbIdentificacaoPedagio.DisplayMember = "Identificacao";
                cbConsultarVeiculos.DataSource = null;
                cbConsultarVeiculos.DataSource = dadosVeiculo;
                cbConsultarVeiculos.DisplayMember = "Identificacao";
                MessageBox.Show("gravado!");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void cbVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecoesDeVeiculo();
        }
        private void cbMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //carro
            if (cbVeiculo.SelectedIndex == 0 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Gol", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 0 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Celta", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //caminhao
            else if (cbVeiculo.SelectedIndex == 1 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Agrale 9200", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 1 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "FH 540", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //onibus
            else if (cbVeiculo.SelectedIndex == 2 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "G7", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 2 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Benz 710", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //moto
            else if (cbVeiculo.SelectedIndex == 3 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Cargo", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 3 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Fazer", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //aviao 
            else if (cbVeiculo.SelectedIndex == 4 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Embraer 175", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 4 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "a380", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //aviao de guerra
            else if (cbVeiculo.SelectedIndex == 5 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Night Hawk", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 5 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Raptor", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //trem
            else if (cbVeiculo.SelectedIndex == 6 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "U20C", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 6 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "DH10", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //navio
            else if (cbVeiculo.SelectedIndex == 7 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "Honam", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 7 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Prezioza", dadosMarca[1]);
                dadosModelo.Add(mod);
            }
            //navio de guerra
            else if (cbVeiculo.SelectedIndex == 8 && cbMarcas.SelectedIndex == 0)
            {
                dadosModelo.Clear();
                mod = new Modelo(1, "CVN78", dadosMarca[0]);
                dadosModelo.Add(mod);
            }
            else if (cbVeiculo.SelectedIndex == 8 && cbMarcas.SelectedIndex == 1)
            {
                dadosModelo.Clear();
                mod = new Modelo(2, "Yamato", dadosMarca[1]);
                dadosModelo.Add(mod);
            }

            cbModelo.DataSource = null;
            cbModelo.DataSource = dadosModelo;
            cbModelo.DisplayMember = "Descricao";
        }
        private void cbModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            tbResumo.Clear();
            if (dadosVeiculo != null)
                foreach (Veiculo v in dadosVeiculo)
                    tbResumo.Text += v.ToString() + Environment.NewLine + Environment.NewLine;
        }
        private void tbIdentificacao_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnGerarPedagio_Click(object sender, EventArgs e)
        {

            tbResumo.Clear();

            try
            {
                Pedagio p = new Pedagio();
                p.Identificacao = cbIdentificacaoPedagio.Text;

                foreach (Veiculo identificacao in dadosVeiculo)
                {
                    if (identificacao.Identificacao == cbIdentificacaoPedagio.Text)
                    {
                        p.TotalDePedagio(identificacao.PagarPedagio());
                        break;
                    }
                }
                p.Localizacao = cbLocalizacaoPedagio.Text;
                bool valida = false;
                for (int i = 0; i < dadosPedagio.Count; i++)
                {
                    if (dadosPedagio[i].Identificacao == p.Identificacao && dadosPedagio[i].Localizacao == p.Localizacao)
                    {
                        dadosPedagio[i].Saldo += p.Saldo;
                        valida = true;

                        break;
                    }
                }
                dadosPedagio.Add(p);
                if (valida == true)
                    dadosPedagio.RemoveAt(dadosPedagio.Count - 1);

                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                string conteudoPedagio = JsonConvert.SerializeObject(dadosPedagio, settings);
                File.WriteAllText("dadosPedagio.json", conteudoPedagio);
                tbResumo.Clear();
                foreach (Pedagio ped in dadosPedagio)
                {
                    tbResumo.Text += ped.ToString() + Environment.NewLine;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnPagarPedagio_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbPagarTodoPedagio.Checked == true)
                {
                    foreach (Pedagio pedagio in dadosPedagio)
                    {
                        pedagio.Saldo = 0;

                    }
                    MessageBox.Show("Todos os pedagios foram pagos.");
                }
                else
                {
                    foreach (Pedagio p in dadosPedagio)
                    {
                        if (p.Identificacao == cbIdentificacaoPedagio.Text)
                        {

                            if (p.Saldo < Convert.ToDouble(tbPagamentoPedagio.Text))
                            {
                                MessageBox.Show("Seu troco é de" + (Convert.ToDouble(tbPagamentoPedagio.Text) - p.Saldo));
                                p.Receber(Convert.ToDouble(p.Saldo));
                            }
                            if (p.Saldo > Convert.ToDouble(tbPagamentoPedagio.Text))
                            {

                                p.Saldo = p.Saldo - Convert.ToDouble(tbPagamentoPedagio.Text);
                            }
                            else if (p.Saldo == 0)
                            {
                                MessageBox.Show("Pedagio ja foi pago.");
                            }

                        }
                    }
                }
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                string conteudoPedagio = JsonConvert.SerializeObject(dadosPedagio, settings);
                File.WriteAllText("dadosPedagio.json", conteudoPedagio);
                tbResumo.Clear();
                foreach (Pedagio p in dadosPedagio)
                {
                    tbResumo.Text += p.ToString() + Environment.NewLine;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnListarPedagio_Click(object sender, EventArgs e)
        {
            tbResumo.Clear();
            foreach (Pedagio ped in dadosPedagio)
            {
                tbResumo.Text += ped.ToString() + Environment.NewLine;
            }
        }
        private void btnDecolar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is Aviao)
                    {
                        (item as Aviao).Decolar();
                        break;
                    }
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is AviaoDeGuerra)
                    {
                        (item as AviaoDeGuerra).Decolar();
                        break;
                    }
                }
                GravarArquivo();


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregadorDeLayout();

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbAcoes.SelectedIndex == 0)
                {
                    foreach (Veiculo item in dadosVeiculo)
                    {
                        if (item is VeiculoLimpador)
                        {
                            (item as VeiculoLimpador).StatusLimpador = true;
                            (item as VeiculoLimpador).Limpador();
                        }
                    }
                    MessageBox.Show("Todos Limapdores foram LIGADOS.");
                }
                else if (cbAcoes.SelectedIndex == 1)
                {
                    foreach (Veiculo item in dadosVeiculo)
                    {
                        if (item is Navio)
                        {
                            (item as Navio).Atracar();
                        }
                        if (item is NavioDeGuerra)
                        {
                            (item as NavioDeGuerra).Atracar();
                        }
                    }
                    MessageBox.Show("Todos os Navios foram ATRACADOS.");
                }
                else if (cbAcoes.SelectedIndex == 2)
                {
                    foreach (Veiculo item in dadosVeiculo)
                    {
                        if (item is VeiculoDeGuerra)
                        {
                            (item as VeiculoDeGuerra).Atacar();
                        }
                    }
                    MessageBox.Show("Todos Veiculos de Guerra estão ATACANDO.");
                }
                else if (cbAcoes.SelectedIndex == 3)
                {
                    foreach (Veiculo item in dadosVeiculo)
                    {
                        if (item is Moto)
                        {
                            (item as Moto).Empinar();
                        }
                    }
                    MessageBox.Show("Todas Motos estão EMPINANDO.");
                }
                else
                    MessageBox.Show("Opção não selecionada.");
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void btnAtracar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as Navio).Atracar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnAtacar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as VeiculoDeGuerra).Atacar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnEjetar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as AviaoDeGuerra).Ejetar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as Caminhao).Carregar(Convert.ToDouble(tbCarregarCaminhao.Text));
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnDescarregar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as Caminhao).Descarregar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnEmpinar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao)
                    {
                        (item as Moto).Empinar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnArremeter_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is Aviao)
                    {
                        (item as Aviao).Arremeter();
                        break;
                    }
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is AviaoDeGuerra)
                    {
                        (item as AviaoDeGuerra).Arremeter();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnPousar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is Aviao)
                    {
                        (item as Aviao).Pousar();
                        break;
                    }
                    if (cbConsultarVeiculos.Text == item.Identificacao && item is AviaoDeGuerra)
                    {
                        (item as AviaoDeGuerra).Pousar();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnDesenpinar_Click(object sender, EventArgs e)
        {
            foreach (Veiculo item in dadosVeiculo)
            {
                if (item.Identificacao == cbConsultarVeiculos.Text)
                {
                    (item as Moto).Desempinar();
                    break;
                }

            }
            GravarArquivo();
            ReList();
        }
        private void btnDesligarLimpador_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (item.Identificacao == cbConsultarVeiculos.Text && item is VeiculoLimpador)
                    {
                        (item as VeiculoLimpador).StatusLimpador = false;
                        (item as VeiculoLimpador).Limpador();
                        MessageBox.Show((item as VeiculoLimpador).MensagemLimpador);
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch
            {

            }

        }
        private void btnLigarLimpador_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (item.Identificacao == cbConsultarVeiculos.Text && item is VeiculoLimpador)
                    {
                        (item as VeiculoLimpador).StatusLimpador = true;
                        (item as VeiculoLimpador).Limpador();
                        MessageBox.Show((item as VeiculoLimpador).MensagemLimpador);
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch
            {

            }
        }
        private void rbAcoesEspecificas_CheckedChanged(object sender, EventArgs e)
        {
            pAcoesEspecificas.Visible = true;
            pAcoesGerais.Visible = false;
        }
        private void rbAcoesGerais_CheckedChanged(object sender, EventArgs e)
        {
            pAcoesGerais.Visible = true;
            pAcoesEspecificas.Visible = false;
        }

        private void rbGeraPedagio_CheckedChanged(object sender, EventArgs e)
        {

            pDadosPedagio.Visible = true;
            pPagamento.Visible = false;
            btnGerarPedagio.Visible = true;
            cbLocalizacaoPedagio.Enabled = true;

        }

        private void rbPagarPedagio_CheckedChanged(object sender, EventArgs e)
        {
            pDadosPedagio.Visible = true;
            pPagamento.Visible = true;
            btnGerarPedagio.Visible = false;
            cbLocalizacaoPedagio.Enabled = true;
            tbPagamentoPedagio.Enabled = true;
        }

        private void rbPagarTodoPedagio_CheckedChanged(object sender, EventArgs e)
        {
            pDadosPedagio.Visible = false;
            pPagamento.Visible = true;
            btnGerarPedagio.Visible = false;
            cbLocalizacaoPedagio.Enabled = false;
            tbPagamentoPedagio.Enabled = false;
        }
      
        private void btnAcelerar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (item.Identificacao == cbConsultarVeiculos.Text)
                    {
                        item.Acelera();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }
        private void btnDesacelerar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Veiculo item in dadosVeiculo)
                {
                    if (item.Identificacao == cbConsultarVeiculos.Text)
                    {
                        item.Desacelera();
                        break;
                    }
                }
                GravarArquivo();
                ReList();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void cbIdentificacaoPedagio_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDeVeiculo(tbTipoVeiculoPedagio);
        }
        /// <summary>
        /// Carrega as configurações de inicialização.
        /// </summary>
        private void SelecoesDeInicio()
        {
            pIdentificacao.Visible = false;
            pVelocidade.Visible = false;
            pPassageiros.Visible = false;
            pMarcas.Visible = false;
            pLimpador.Visible = false;
            pPesoCarregado.Visible = false;
            pEixos.Visible = false;
            pCapacidadeMaxima.Visible = false;
            pLeito.Visible = false;
            pPortas.Visible = false;
            btnCadastrar.Visible = false;
            pVagoes.Visible = false;
            btnAtracar.Enabled = false;
            btnAtacar.Enabled = false;
            btnEjetar.Enabled = false;
            pCaminhao.Enabled = false;
            pAviao.Enabled = false;
            btnEmpinar.Enabled = false;
            btnDesenpinar.Enabled = false;
            btnDesligarLimpador.Enabled = false;
            btnLigarLimpador.Enabled = false;
            pAcoesEspecificas.Visible = false;
            pAcoesGerais.Visible = false;

            if (File.Exists("dadosveiculo.json"))
                CarregaArquivo();
            cbIdentificacaoPedagio.DataSource = null;
            cbIdentificacaoPedagio.DataSource = dadosVeiculo;
            cbIdentificacaoPedagio.DisplayMember = "Identificacao";

            cbConsultarVeiculos.DataSource = null;
            cbConsultarVeiculos.DataSource = dadosVeiculo;
            cbConsultarVeiculos.DisplayMember = "Identificacao";
        }
        /// <summary>
        /// Carrega as configurações do ComboBox cbVeiculos.
        /// </summary>
        private void SelecoesDeVeiculo()
        {
            if (cbVeiculo.SelectedIndex == 0)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = true;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = true;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;

            }
            else if (cbVeiculo.SelectedIndex == 1)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = true;
                pPesoCarregado.Visible = true;
                pEixos.Visible = true;
                pCapacidadeMaxima.Visible = true;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 2)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = true;
                pPesoCarregado.Visible = false;
                pEixos.Visible = true;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = true;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 3)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = false;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 4)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = true;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 5)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = false;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 6)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = true;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = true;
            }
            else if (cbVeiculo.SelectedIndex == 7)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = false;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }
            else if (cbVeiculo.SelectedIndex == 8)
            {
                pIdentificacao.Visible = true;
                pVelocidade.Visible = true;
                pPassageiros.Visible = true;
                pMarcas.Visible = true;

                pLimpador.Visible = false;
                pPesoCarregado.Visible = false;
                pEixos.Visible = false;
                pCapacidadeMaxima.Visible = false;
                pLeito.Visible = false;
                pPortas.Visible = false;
                btnCadastrar.Visible = true;
                pVagoes.Visible = false;
            }

            if (cbVeiculo.Text == "Carro")
            {
                dadosMarca.Clear();

                m = new Marca(1, "VW");
                dadosMarca.Add(m);

                m = new Marca(2, "GM");
                dadosMarca.Add(m);
            }
            else if (cbVeiculo.Text == "Caminhão")
            {
                dadosMarca.Clear();

                m = new Marca(1, "AG");
                dadosMarca.Add(m);

                m = new Marca(2, "Volvo");
                dadosMarca.Add(m);

            }
            else if (cbVeiculo.Text == "Ônibus")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Marcopolo");
                dadosMarca.Add(m);

                m = new Marca(2, "Mercedes");
                dadosMarca.Add(m);

            }
            else if (cbVeiculo.Text == "Moto")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Honda");
                dadosMarca.Add(m);

                m = new Marca(2, "Yamaha");
                dadosMarca.Add(m);

            }
            else if (cbVeiculo.Text == "Avião")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Embraer");
                dadosMarca.Add(m);

                m = new Marca(2, "Airbus");
                dadosMarca.Add(m);
            }
            else if (cbVeiculo.Text == "Avião de Guerra")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Northrop");
                dadosMarca.Add(m);

                m = new Marca(2, "Lockheed");
                dadosMarca.Add(m);
            }
            else if (cbVeiculo.Text == "Trem")
            {
                dadosMarca.Clear();

                m = new Marca(1, "GE");
                dadosMarca.Add(m);

                m = new Marca(2, "MAXION");
                dadosMarca.Add(m);
            }
            else if (cbVeiculo.Text == "Navio")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Maersk");
                dadosMarca.Add(m);

                m = new Marca(2, "MSC");
                dadosMarca.Add(m);
            }
            else if (cbVeiculo.Text == "Navio de Guerra")
            {
                dadosMarca.Clear();

                m = new Marca(1, "Ford");
                dadosMarca.Add(m);

                m = new Marca(2, "Kure");
                dadosMarca.Add(m);
            }
            cbMarcas.DataSource = null;
            cbMarcas.DataSource = dadosMarca;
            cbMarcas.DisplayMember = "Descricao";
        }
        /// <summary>
        /// Organiza o Layout de acordo com o veiculo escolhido no Combobox cbVeiculos.
        /// </summary>
        public void CarregadorDeLayout()
        {
            Veiculo veiculoAux = null;

            foreach (var identificacao in dadosVeiculo)
            {
                if (cbConsultarVeiculos.Text == identificacao.Identificacao)
                {
                    veiculoAux = identificacao;
                    break;
                }
            }

            if (veiculoAux is Carro)
            {
                btnDesenpinar.Enabled = false;
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = true;
                btnLigarLimpador.Enabled = true;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Carro";
            }
            else if (veiculoAux is Caminhao)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = true;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = true;
                btnLigarLimpador.Enabled = true;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Caminhão";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is Onibus)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = true;
                btnLigarLimpador.Enabled = true;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Ônibus";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is Moto)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = true;
                btnDesligarLimpador.Enabled = false;
                btnLigarLimpador.Enabled = false;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Moto";
                btnDesenpinar.Enabled = true;
            }
            else if (veiculoAux is Aviao)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = true;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = true;
                btnLigarLimpador.Enabled = true;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Avião";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is AviaoDeGuerra)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = true;
                btnEjetar.Enabled = true;
                pCaminhao.Enabled = false;
                pAviao.Enabled = true;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = false;
                btnLigarLimpador.Enabled = false;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Avião de Guerra";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is Trem)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = true;
                btnLigarLimpador.Enabled = true;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Trem";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is Navio)
            {
                btnAtracar.Enabled = true;
                btnAtacar.Enabled = false;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = false;
                btnLigarLimpador.Enabled = false;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Navio";
                btnDesenpinar.Enabled = false;
            }
            else if (veiculoAux is NavioDeGuerra)
            {
                btnAtracar.Enabled = false;
                btnAtacar.Enabled = true;
                btnEjetar.Enabled = false;
                pCaminhao.Enabled = false;
                pAviao.Enabled = false;
                btnEmpinar.Enabled = false;
                btnDesligarLimpador.Enabled = false;
                btnLigarLimpador.Enabled = false;
                tbTipoVeiculoAcoes.Clear();
                tbTipoVeiculoAcoes.Text = "Navio de Guerra";
                btnDesenpinar.Enabled = false;
            }

        }
        /// <summary>
        /// Grava a lista de dados dos veiculos cadastrados em formato Serializado Json. 
        /// </summary>
        private void GravarArquivo()
        {

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string conteudoMarca = JsonConvert.SerializeObject(dadosMarca1, settings);
            File.WriteAllText("dadosMarca.json", conteudoMarca);

            string conteudoModelo = JsonConvert.SerializeObject(dadosModelo1, settings);
            File.WriteAllText("dadosModelo.json", conteudoModelo);

            string conteudo = JsonConvert.SerializeObject(dadosVeiculo, settings);
            File.WriteAllText("dadosveiculo.json", conteudo);
        }
        /// <summary>
        /// Deserializa o arquivo Json e o adiciona a uma lista.
        /// </summary>
        private void CarregaArquivo()
        {


            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            string conteudoMarca = File.ReadAllText("dadosMarca.json");
            dadosMarca1 = JsonConvert.DeserializeObject<List<Marca>>(conteudoMarca, settings);

            string conteudoModelo = File.ReadAllText("dadosModelo.json");
            dadosModelo1 = JsonConvert.DeserializeObject<List<Modelo>>(conteudoModelo, settings);

            string conteudo = File.ReadAllText("dadosveiculo.json");
            dadosVeiculo = JsonConvert.DeserializeObject<List<Veiculo>>(conteudo, settings);
            int i = 0;
            if (dadosVeiculo != null)
                foreach (var item in dadosVeiculo)
                {
                    int codigoMarca = 0;
                    int codigoModelo = 0;
                    string c = dadosModelo1[i].Descricao;
                    string d = dadosMarca1[i].Descricao;
                    if (d == "AG" ||
                        d == "VW" ||
                        d == "Marcopolo" ||
                        d == "Honda" ||
                        d == "Embraer" ||
                        d == "Northrop" ||
                        d == "GE" ||
                        d == "Maersk" ||
                        d == "Ford")
                        codigoMarca = 1;
                    else
                        codigoMarca = 2;
                    if (c == "Gol" ||
                        c == "Agrale 9200" ||
                        c == "G7" ||
                        c == "Cargo" ||
                        c == "Embraer 175" ||
                        c == "Night Hawk" ||
                        c == "U20C" ||
                        c == "Honam" ||
                        c == "CVN78")
                        codigoModelo = 1;
                    else
                        codigoModelo = 2;

                    item.Modelo = new Modelo(codigoModelo, dadosModelo1[i].Descricao, new Marca(codigoMarca, dadosMarca1[i].Descricao));
                    i++;


                }
            string conteudoPedagio = File.ReadAllText("dadosPedagio.json");
            dadosPedagio = JsonConvert.DeserializeObject<List<Pedagio>>(conteudoPedagio, settings);

        }
        /// <summary>
        /// Mostra o tipo de veiculo em uma TextBox em função de uma ComboBox de Identificação do Veiculo.
        /// </summary>
        /// <param name="tbUtilizado"></param>
        private void TipoDeVeiculo(TextBox tbUtilizado)
        {
            Veiculo veiculo = null;
            foreach (var item in dadosVeiculo)
            {
                if (item.Identificacao == cbIdentificacaoPedagio.Text)
                {
                    veiculo = item;
                }
            }
            if (veiculo is Carro)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Carro";
            }
            else if (veiculo is Caminhao)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Caminhão";
            }
            else if (veiculo is Onibus)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Ônibus";
            }
            else if (veiculo is Moto)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Moto";
            }
            else if (veiculo is Aviao)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Avião";
            }
            else if (veiculo is AviaoDeGuerra)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Avião de Guerra";
            }
            else if (veiculo is Trem)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Trem";
            }
            else if (veiculo is Navio)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Navio";
            }
            else if (veiculo is NavioDeGuerra)
            {
                tbUtilizado.Clear();
                tbUtilizado.Text = "Navio de Guerra";
            }
        }
        /// <summary>
        /// Atualiza os dados do TextBox tbResumo em função das ações selecionadas.
        /// </summary>
        private void ReList()
        {
            tbResumo.Clear();
            if (dadosVeiculo != null)
                foreach (Veiculo v in dadosVeiculo)
                    tbResumo.Text += v.ToString() + Environment.NewLine + Environment.NewLine;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}