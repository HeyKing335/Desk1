using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class FormChamadosNovos : Form
    {
        private DataGridView dgvChamadosNovos;
        private Button btnHome;
        private Label lblTitulo;
        private Button button1;

        public FormChamadosNovos()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Fundo cinza
            SetupInterface();

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "FormChamadosNovos";
            this.ClientSize = new System.Drawing.Size(800, 450);
        }

        private void SetupInterface()
        {
            this.Text = "Chamados Novos";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            // ------- Título -------
            lblTitulo = new Label();
            lblTitulo.Text = "CHAMADOS NOVOS";
            lblTitulo.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 70;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblTitulo);

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


            // ------- Painel da seção -------
            Panel panel = new Panel();
            panel.Width = this.Width - 80;
            panel.Height = this.Height - 180;
            panel.Location = new Point(40, 120);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(panel);

            // ------- DataGridView -------
            dgvChamadosNovos = new DataGridView();
            dgvChamadosNovos.Dock = DockStyle.Fill;
            dgvChamadosNovos.AllowUserToAddRows = false;
            dgvChamadosNovos.RowHeadersVisible = false;
            dgvChamadosNovos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvChamadosNovos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);
            dgvChamadosNovos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvChamadosNovos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvChamadosNovos.EnableHeadersVisualStyles = false;

            dgvChamadosNovos.Columns.Add("Id", "ID");
            dgvChamadosNovos.Columns.Add("Titulo", "Título");
            dgvChamadosNovos.Columns.Add("Cliente", "Cliente");
            dgvChamadosNovos.Columns.Add("Status", "Status");

            // Dados de exemplo
            dgvChamadosNovos.Rows.Add(1, "Nova Solicitação", "Cliente XPTO", "Novo");
            dgvChamadosNovos.Rows.Add(2, "Primeiro Acesso", "Cliente Z", "Novo");

            panel.Controls.Add(dgvChamadosNovos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SizeF chamados = new SizeF();
            chamados.WindowState = FormWindowState.Maximized;
            chamados.Show();

            this.Hide();
        }
    }
}
