using System;
using System.Drawing;
using System.Windows.Forms;

namespace projetinholeds
{
    public partial class Form1 : Form
    {
        private Leds leds = new Leds();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Linha LIGA, da esquerda para a direita: bit 7 até bit 0
            Button[] ligar = { button1, button2, button3, button4,
                               button5, button6, button7, button8 };

            // Linha DESLIGA, na ordem em que aparecem na tela (16, 14, 15, 13, 12, 11, 10, 9)
            Button[] desligar = { button16, button14, button15, button13,
                                  button12, button11, button10, button9 };

            for (int i = 0; i < 8; i++)
            {
                int bit = 7 - i;
                ligar[i].Click += (s, ev) => { leds.acender(bit); AtualizarTela(); };
                desligar[i].Click += (s, ev) => { leds.apagar(bit); AtualizarTela(); };
            }

            AtualizarTela();
        }

        private void AtualizarTela()
        {
            byte valor = leds.getStatus();

            label1.Text = "DECIMAL" + Environment.NewLine + valor;
            label2.Text = "HEXADECIMAL" + Environment.NewLine + "0x" + valor.ToString("X2");
            label3.Text = "BINARIO" + Environment.NewLine + Convert.ToString(valor, 2).PadLeft(8, '0');

            // pinta de vermelho o botão LIGA dos bits acesos
            Button[] ligar = { button1, button2, button3, button4,
                               button5, button6, button7, button8 };
            for (int i = 0; i < 8; i++)
                ligar[i].BackColor = leds.getStatus(7 - i) ? Color.Red : SystemColors.Control;
        }
    }
}
