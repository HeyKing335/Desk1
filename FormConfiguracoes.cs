using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class FormConfiguracoes : Form
    {
        // Variáveis para controle da animação
        bool sidebarExpand = false;

        public string IdiomaAtual { get; private set; }

        public FormConfiguracoes()
        {
            InitializeComponent();

            this.Text = "Configurações";
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized; // Tela cheia também

            this.Load += new System.EventHandler(this.FormConfiguracoes_Load);
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);


            // ---------------------------
            //  CRIAR LABEL DE VERSÃO
            // ---------------------------
            Label lblVersao = new Label();
            lblVersao.Text = "Versão 1.0.0";
            lblVersao.ForeColor = Color.White;
            lblVersao.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblVersao.AutoSize = true;

            // Jogar para a parte inferior
            lblVersao.Dock = DockStyle.Bottom;
            lblVersao.Padding = new Padding(10);

            // Adicionar na barra lateral
            panelLateral.Controls.Add(lblVersao);

        }

        // --- Botão que aciona o menu lateral ---
        private void btnMenu_Click(object sender, EventArgs e)
        {
            timerLateral.Start();
        }

        // --- Timer responsável pela animação ---
        private void timerLateral_Tick(object sender, EventArgs e)
        {
            // Quando expandir
            if (sidebarExpand == false)
            {
                panelLateral.Width += 10; // Velocidade da animação

                if (panelLateral.Width >= 200) // tamanho expandido
                {
                    timerLateral.Stop();
                    sidebarExpand = true;
                }
            }
            else
            {
                // Quando recolher
                panelLateral.Width -= 10;

                if (panelLateral.Width <= 60) // tamanho recolhido
                {
                    timerLateral.Stop();
                    sidebarExpand = false;
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Fecha a tela de configurações
            this.Hide();

            // Reabre os chamados
            SizeF chamados = new SizeF();
            chamados.WindowState = FormWindowState.Maximized;
            chamados.Show();
        }

        private void FormConfiguracoes_Load(object sender, EventArgs e)
        {
            // Carrega o idioma salvo anteriormente (se existir)
            string idiomaSalvo = Properties.Settings.Default.Idioma;

            if (!string.IsNullOrEmpty(idiomaSalvo))
            {
                cmbIdioma.SelectedItem = idiomaSalvo;
            }
            else
            {
                cmbIdioma.SelectedIndex = 0; // Português por padrão
            }

            AplicarIdioma();
        }
        private void CmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idioma = cmbIdioma.SelectedItem.ToString();

            // Salva o idioma nas configurações
            Properties.Settings.Default.Idioma = idioma;
            Properties.Settings.Default.Save();

            MessageBox.Show($"Idioma alterado para: {idioma}",
                "Idioma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbIdioma_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void AplicarIdioma()
        {
            foreach (Control c in this.Controls)
            {
                TraduzirControle(c);
            }
        }

        private void TraduzirControle(Control c)
        {
            if (c.Tag != null)
            {
                string key = c.Tag.ToString();
                c.Text = LanguageManager.T(key);
            }

            // traduz controles dentro de painéis/panels
            foreach (Control child in c.Controls)
                TraduzirControle(child);
        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIdioma.SelectedIndex == 0)
                LanguageManager.IdiomaAtual = "pt";
            else
                LanguageManager.IdiomaAtual = "en";

            // Aplica idioma na tela atual
            AplicarIdioma();

        }
    }
}
