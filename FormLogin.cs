using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class FormLogin : Form
    {
        public string IdiomaAtual { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string caminhoLogo = Path.Combine(Application.StartupPath, "Images", "logo.png");

                if (File.Exists(caminhoLogo))
                {
                    logoPictureBox.Image = Image.FromFile(caminhoLogo);
                }
                else
                {
                    MessageBox.Show($"Imagem não encontrada!\n{caminhoLogo}",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar logo: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AplicarIdioma();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (usuario == "admin" && senha == "1234")
            {
                SizeF chamados = new SizeF();
                _ = new FormChamados();
                chamados.WindowState = FormWindowState.Maximized;
                chamados.Show(); // Abre a tela de chamados

                this.Hide(); // Oculta o FormLogin
            }
            else
            {
                lblErro.Text = "Usuário ou senha incorretos!";
            }
        }

        public void AplicarIdioma()
        {
            lblUsuario.Text = (IdiomaAtual == "pt") ? "Usuário:" : "User:";
            lblSenha.Text = (IdiomaAtual == "pt") ? "Senha:" : "Password:";
            btnEntrar.Text = (IdiomaAtual == "pt") ? "Entrar" : "Login";
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
    }
}
