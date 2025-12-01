using HelpFastDesktop;
using Microsoft.VisualStudio.Services.Profile;
using Microsoft.VisualStudio.Services.Users;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class SizeF : Form
    {
        private DataGridView dgvPendentes;
        private DataGridView dgvAnalise;
        private DataGridView dgvConcluidos;
        private Label lblTitulo;

        public string IdiomaAtual { get; private set; }

        public SizeF()
        {
            InitializeComponent(); // Chamado do Designer
            SetupForm();           // Layout personalizado
        }

        // -----------------------------
        // Configuração do Formulário
        // -----------------------------
        private void SetupForm()
        {
            this.Text = "Chamados";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Título central
            lblTitulo = new Label();
            lblTitulo.Text = "CHAMADOS";
            lblTitulo.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Height = 60;
            this.Controls.Add(lblTitulo);

            // Painel principal
            FlowLayoutPanel panelMain = new FlowLayoutPanel();
            panelMain.Dock = DockStyle.Fill;
            panelMain.AutoScroll = true;
            panelMain.FlowDirection = FlowDirection.TopDown;
            panelMain.WrapContents = false;
            panelMain.Padding = new Padding(20);
            panelMain.BackColor = Color.White;
            this.Controls.Add(panelMain);

            // Seções
            panelMain.Controls.Add(CreateSection("Pendentes", out dgvPendentes, true));
            panelMain.Controls.Add(CreateSection("Em Análise", out dgvAnalise, false));
            panelMain.Controls.Add(CreateSection("Concluídos", out dgvConcluidos, false));

            // Dados de exemplo
            LoadDummyData();
        }

        // -----------------------------
        // Criação de cada seção
        // -----------------------------
        private Panel CreateSection(string title, out DataGridView dgv, bool withButton)
        {
            Panel sectionPanel = new Panel();
            sectionPanel.Width = 940;
            sectionPanel.Height = 200;
            sectionPanel.BackColor = Color.White;
            sectionPanel.Padding = new Padding(10);
            sectionPanel.Margin = new Padding(0, 0, 0, 20);
            sectionPanel.BorderStyle = BorderStyle.FixedSingle;

            // Título da seção
            Label lblSection = new Label();
            lblSection.Text = title;
            lblSection.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblSection.ForeColor = Color.FromArgb(0, 120, 215);
            lblSection.Dock = DockStyle.Top;
            lblSection.Height = 40;
            sectionPanel.Controls.Add(lblSection);

            // DataGridView
            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.LightGray;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Cabeçalho
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Colunas
            dgv.Columns.Add("Id", "ID");
            dgv.Columns.Add("Titulo", "Título");
            dgv.Columns.Add("Cliente", "Cliente");
            dgv.Columns.Add("Status", "Status");

            // Linhas alternadas
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);

            // Botão atender
            if (withButton)
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = "";
                btnColumn.Text = "Atender";
                btnColumn.UseColumnTextForButtonValue = true;
                btnColumn.FlatStyle = FlatStyle.Flat;
                btnColumn.DefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69);
                btnColumn.DefaultCellStyle.ForeColor = Color.White;
                btnColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgv.Columns.Add(btnColumn);

                dgv.CellClick += Dgv_CellClick;
                dgv.CellMouseEnter += Dgv_CellMouseEnter;
                dgv.CellMouseLeave += Dgv_CellMouseLeave;
            }

            sectionPanel.Controls.Add(dgv);
            return sectionPanel;
        }

        // -----------------------------
        // Evento clique no botão Atender
        // -----------------------------
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var chamadoId = dgv.Rows[e.RowIndex].Cells["Id"].Value;
                MessageBox.Show($"Chamado {chamadoId} está sendo atendido!", "Atender Chamado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -----------------------------
        // Hover do botão Atender
        // -----------------------------
        private void Dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(0, 90, 158);
        }

        private void Dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(40, 167, 69);
        }

        // -----------------------------
        // Dados de exemplo
        // -----------------------------
        private void LoadDummyData()
        {
            dgvPendentes.Rows.Add(1, "Erro no Sistema", "Cliente A", "Pendente");
            dgvPendentes.Rows.Add(2, "Não Consigo Logar", "Cliente B", "Pendente");

            dgvAnalise.Rows.Add(3, "Problema no Banco de Dados", "Cliente C", "Em Análise");

            dgvConcluidos.Rows.Add(4, "Ajuste de Relatório", "Cliente D", "Concluído");
            dgvConcluidos.Rows.Add(5, "Instalação de Impressora", "Cliente E", "Concluído"); // ← Novo exemplo!
        }

        private void FormChamados_Load(object sender, EventArgs e)
        {


        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Hide(); // Esconde a tela de chamados

            FormLogin login = new FormLogin();
            login.Show(); // Mostra a tela de login novamente
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTodosChamados_Click(object sender, EventArgs e)
        {
            FormTodosChamados todos = new FormTodosChamados();
            todos.WindowState = FormWindowState.Maximized; // Deixa em tela cheia
            todos.Show();
            this.Hide(); // Esconde a tela de chamados
        }


        private void btnNovos_Click(object sender, EventArgs e)
        {
            this.Hide(); // esconde CHAMADOS

            FormChamadosNovos novos = new FormChamadosNovos();
            novos.Show(); // abre a nova tela
        }

        private void btnPendentes_Click(object sender, EventArgs e)
        {
            FormChamadosPendentes pendentes = new FormChamadosPendentes();
            pendentes.WindowState = FormWindowState.Maximized;
            pendentes.Show();
            this.Hide();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            var frm = new FormRelatorios();
            frm.WindowState = FormWindowState.Maximized; // abre tela cheia
            frm.Show();
            this.Hide(); // esconde a tela de Chamados
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormConfiguracoes cfg = new FormConfiguracoes();
            cfg.Show();        // abre a tela de configurações
            this.Hide();       // Esconde a tela de chamados
        }
    }
}