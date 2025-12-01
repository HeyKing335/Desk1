using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HelpFastDesktop
{
    public partial class FormRelatorios : Form
    {
        public FormRelatorios()
        {
            InitializeComponent();
            this.BackColor = Color.LightGray; // Fundo cinza
            CarregarRelatorios();
        }

        private void CarregarRelatorios()
        {
            // Dados exemplo
            var distribuicao = new List<(string Area, int Valor)>
            {
                ("Financeiro", 25),
                ("RH", 15),
                ("Marketing", 20),
                ("Suporte", 40)
            };

            int totalChamados = 100;
            int chamadosFinalizados = 65;

            lblTotalChamados.Text = $"Total de Chamados: {totalChamados}";
            lblPercentualFinalizados.Text = $"Finalizados: {chamadosFinalizados}%";

            // -------------------------------
            // GRÁFICO DE PIZZA
            // -------------------------------
            chartPizza.Series.Clear();
            Series seriePizza = new Series("Áreas");
            seriePizza.ChartType = SeriesChartType.Pie;

            foreach (var item in distribuicao)
            {
                int p = seriePizza.Points.AddXY(item.Area, item.Valor);
                seriePizza.Points[p].Label = $"{item.Area} ({item.Valor}%)";
            }

            chartPizza.Series.Add(seriePizza);

            // -------------------------------
            // GRÁFICO DE BARRAS
            // -------------------------------
            chartBarras.Series.Clear();
            Series serieBarra = new Series("Status");
            serieBarra.ChartType = SeriesChartType.Column;

            serieBarra.Points.AddXY("Em Andamento", 30);
            serieBarra.Points.AddXY("Concluídos", 50);
            serieBarra.Points.AddXY("Encerrados", 20);

            chartBarras.Series.Add(serieBarra);
        }

        // Botão Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            SizeF chamados = new SizeF();
            chamados.WindowState = FormWindowState.Maximized;
            chamados.Show();
        }
    }
}
