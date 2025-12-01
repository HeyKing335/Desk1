using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelpFastDesktop
{
    public partial class FormTodosChamados : Form
    {
        private DataGridView dgvTodos;
        private Label lblTitulo;

        public FormTodosChamados()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Fundo cinza
            // NOTA: não chamamos SetupForm aqui se você preferir usar o Designer.
            // Chamaremos no Load para garantir que o Designer já tenha inicializado os componentes.
        }

        private void FormTodosChamados_Load(object sender, EventArgs e)
        {
            // Monta a interface dinâmica (ou complementa controles criados no Designer)
            SetupForm();
            LoadDummyData();

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
            // Fecha a tela atual
            this.Hide();

            // Reabre a tela de CHAMADOS em tela cheia
            SizeF chamados = new SizeF();
            chamados.WindowState = FormWindowState.Maximized;
            chamados.Show();
        }

        private void SetupForm()
        {
            this.Text = "Todos os Chamados";
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Título (se não existir no Designer)
            if (this.Controls["lblTituloTodos"] == null)
            {
                lblTitulo = new Label();
                lblTitulo.Name = "lblTituloTodos";
                lblTitulo.Text = "TODOS OS CHAMADOS";
                lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                lblTitulo.ForeColor = Color.FromArgb(44, 62, 80);
                lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
                lblTitulo.Dock = DockStyle.Top;
                lblTitulo.Height = 60;
                this.Controls.Add(lblTitulo);
                lblTitulo.BringToFront();
            }

            // Painel principal — se já existir no Designer, use-o
            Control panelMain = this.Controls["panelMainTodos"];
            if (panelMain == null)
            {
                FlowLayoutPanel p = new FlowLayoutPanel();
                p.Name = "panelMainTodos";
                p.Dock = DockStyle.Fill;
                p.AutoScroll = true;
                p.FlowDirection = FlowDirection.TopDown;
                p.WrapContents = false;
                p.Padding = new Padding(20);
                p.BackColor = Color.White;
                this.Controls.Add(p);
                panelMain = p;
                panelMain.BringToFront();
            }

            // Seção única: Todos os Chamados
            Panel section = CreateSection("Todos os Chamados", out dgvTodos, false);
            section.Width = Math.Max(section.Width, 940);
            ((FlowLayoutPanel)panelMain).Controls.Add(section);
        }

        private Panel CreateSection(string title, out DataGridView dgv, bool withButton)
        {
            Panel sectionPanel = new Panel();
            sectionPanel.Width = 940;
            sectionPanel.Height = 320;
            sectionPanel.BackColor = Color.White;
            sectionPanel.Padding = new Padding(10);
            sectionPanel.Margin = new Padding(0, 0, 0, 20);
            sectionPanel.BorderStyle = BorderStyle.FixedSingle;

            Label lblSection = new Label();
            lblSection.Text = title;
            lblSection.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblSection.ForeColor = Color.FromArgb(0, 120, 215);
            lblSection.Dock = DockStyle.Top;
            lblSection.Height = 40;
            sectionPanel.Controls.Add(lblSection);

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

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 240, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.Columns.Add("Id", "ID");
            dgv.Columns.Add("Titulo", "Título");
            dgv.Columns.Add("Cliente", "Cliente");
            dgv.Columns.Add("Status", "Status");

            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);

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

        // Eventos copy/paste do seu FormChamados (simples mensagens)
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var chamadoId = dgv.Rows[e.RowIndex].Cells["Id"].Value;
                MessageBox.Show($"Chamado {chamadoId} está sendo atendido!", "Atender Chamado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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

        private void LoadDummyData()
        {
            if (dgvTodos != null)
            {
                dgvTodos.Rows.Clear();
                dgvTodos.Rows.Add(1, "Erro no Sistema", "Cliente A", "Pendente");
                dgvTodos.Rows.Add(2, "Não Consigo Logar", "Cliente B", "Pendente");
                dgvTodos.Rows.Add(3, "Problema no Banco de Dados", "Cliente C", "Em Análise");
                dgvTodos.Rows.Add(4, "Ajuste de Relatório", "Cliente D", "Concluído");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Fecha a tela atual
            this.Hide();

            // Reabre a tela de CHAMADOS em tela cheia
            SizeF chamados = new SizeF();
            chamados.WindowState = FormWindowState.Maximized;
            chamados.Show();
        }
    }
}
