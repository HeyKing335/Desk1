using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class FormChamadosPendentes : Form
    {
        private DataGridView dgvPendentes;
        private Button button1;

        public FormChamadosPendentes()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Fundo cinza
            CriarInterface();
            LoadDadosPendentes();
        }

        private void CriarInterface()
        {
            this.Text = "Chamados Pendentes";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            // Painel principal
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panel.Padding = new Padding(20);
            this.Controls.Add(panel);

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "CHAMADOS PENDENTES";
            lblTitulo.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            panel.Controls.Add(lblTitulo);

            // Seção
            Panel secao = new Panel();
            secao.Width = 1100;
            secao.Height = 350;
            secao.BorderStyle = BorderStyle.FixedSingle;
            secao.Padding = new Padding(10);
            secao.BackColor = Color.White;
            secao.Top = 80;
            panel.Controls.Add(secao);

            // Título da seção
            Label lblSecao = new Label();
            lblSecao.Text = "Pendentes";
            lblSecao.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblSecao.ForeColor = Color.FromArgb(0, 120, 215);
            lblSecao.Dock = DockStyle.Top;
            lblSecao.Height = 40;
            secao.Controls.Add(lblSecao);

            // Tabela
            dgvPendentes = new DataGridView();
            dgvPendentes.Dock = DockStyle.Fill;
            dgvPendentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendentes.AllowUserToAddRows = false;
            dgvPendentes.RowHeadersVisible = false;
            dgvPendentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendentes.BackgroundColor = Color.White;

            dgvPendentes.Columns.Add("Id", "ID");
            dgvPendentes.Columns.Add("Titulo", "Título");
            dgvPendentes.Columns.Add("Cliente", "Cliente");
            dgvPendentes.Columns.Add("Status", "Status");

            secao.Controls.Add(dgvPendentes);

            // ------- Botão HOME -------
            button1 = new Button();
            button1.Text = "🏠"; // ícone de casa
            button1.Font = new Font("Segoe UI Emoji", 18, FontStyle.Bold);
            button1.Size = new Size(60, 60);
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            // posição ao lado do painel lateral
            button1.Location = new Point(panelLateral.Width + 10, 10);

            button1.Click += button1_Click;

            this.Controls.Add(button1);
            button1.BringToFront(); // garantir que ele apareça
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SizeF telaChamados = new SizeF();
            telaChamados.WindowState = FormWindowState.Maximized;
            telaChamados.Show();
        }

        private void LoadDadosPendentes()
        {
            dgvPendentes.Rows.Add(1, "Erro no Sistema", "Cliente A", "Pendente");
            dgvPendentes.Rows.Add(2, "Não Consigo Logar", "Cliente B", "Pendente");
        }
    }
}