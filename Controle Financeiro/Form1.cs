using System.Data;
using System.Drawing;

namespace Controle_Financeiro
{
    public partial class Form1 : Form
    {
        public double recebidoTotalConst = 0;
        public double saidaTotalConst = 0;
        public double valorTotalConst = 0;
        public List<Entradas> entradasLista;
        public List<Saidas> saidasLista;
        public Form1()
        {
            InitializeComponent();
            Serializador.EncheLista(ref entradasLista,@"entradas.xml", table);
            Serializador.EncheLista(ref saidasLista, @"saidas.xml", tableSaida);
            Serializador.EncheCarteira(ref valorTotalConst, @"carteira.xml");
            Serializador.EncheRecebidos(ref recebidoTotalConst, @"entradas.xml");
            Serializador.EncheSaidas(ref saidaTotalConst, @"saidas.xml");
            valorAtual.Text = valorTotalConst.ToString("C");
            AtualizaRecebidoTotal();
            AtualizaSaidaTotal();
        }
        public void AtualizaCarteira()
        {
            Serializador.Serializa(valorTotalConst, @"carteira.xml");
            Serializador.EncheCarteira(ref valorTotalConst, @"carteira.xml");
            valorAtual.Text = valorTotalConst.ToString("C");
        }
        public void AtualizaRecebidoTotal()
        {
            Serializador.EncheRecebidos(ref recebidoTotalConst, @"entradas.xml");
            recebidoTotal.Text = recebidoTotalConst.ToString("C");
        }
        public void AtualizaSaidaTotal()
        {
            Serializador.EncheSaidas(ref saidaTotalConst, @"saidas.xml");
            gastosTotais.Text = saidaTotalConst.ToString("C");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(desc.Text != "" && val.MaskCompleted)
            {
                // Objeto
                Entradas entrada = new Entradas(desc.Text, Convert.ToDouble(val.Text));
                entradasLista.Add(entrada);

                // Serializador
                Serializador.Serializa(entradasLista, @"entradas.xml");
                table.Rows.Clear();
                Serializador.EncheLista(ref entradasLista, @"entradas.xml", table);

                // Atualizando o total de recebido
                AtualizaRecebidoTotal();

                // Carteira
                valorTotalConst += entrada.valorEntrada;
                AtualizaCarteira();
                MessageBox.Show("Valor também adicionado a carteira!", "CARTEIRA ATUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Insira valores válidos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (descSaida.Text != "" && valSaida.MaskCompleted && dataSaida.MaskCompleted)
            {
                Saidas saida = new Saidas(descSaida.Text, Convert.ToDouble(valSaida.Text), Convert.ToDateTime(dataSaida.Text + " 00:00:00"));
                saidasLista.Add(saida);

                // Serialização
                Serializador.Serializa(saidasLista, @"saidas.xml");
                tableSaida.Rows.Clear();
                Serializador.EncheLista(ref saidasLista, @"saidas.xml", tableSaida);
                 
                // Atualizando gastos
                AtualizaSaidaTotal();

                // Carteira
                valorTotalConst -= saida.valSaida;
                AtualizaCarteira();
                MessageBox.Show("Valor também subtraído da carteira!", "CARTEIRA ATUALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Insira valores válidos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (valorAdicionado.MaskCompleted)
            {
                valorTotalConst += Convert.ToDouble(valorAdicionado.Text);
                AtualizaCarteira();
            }
            else
                MessageBox.Show("Insira valores válidos.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}