using System.Windows.Forms.DataVisualization.Charting;

namespace HelpFastDesktop
{
    partial class FormRelatorios
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTotalChamados;
        private System.Windows.Forms.Label lblPercentualFinalizados;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPizza;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBarras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTotalChamados = new System.Windows.Forms.Label();
            this.lblPercentualFinalizados = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.chartPizza = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBarras = new System.Windows.Forms.DataVisualization.Charting.Chart();

            ((System.ComponentModel.ISupportInitialize)(this.chartPizza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).BeginInit();
            this.SuspendLayout();

            // LABEL TÍTULO
            this.lblTitulo.Text = "RELATÓRIOS DE CHAMADOS";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(350, 20);

            // TOTAL CHAMADOS
            this.lblTotalChamados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblTotalChamados.AutoSize = true;
            this.lblTotalChamados.Location = new System.Drawing.Point(50, 90);

            // PERCENTUAL FINALIZADOS
            this.lblPercentualFinalizados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblPercentualFinalizados.AutoSize = true;
            this.lblPercentualFinalizados.Location = new System.Drawing.Point(50, 120);

            // GRÁFICO DE PIZZA
            this.chartPizza.Location = new System.Drawing.Point(50, 170);
            this.chartPizza.Size = new System.Drawing.Size(450, 350);

            ChartArea areaPizza = new ChartArea("AreaPizza");
            this.chartPizza.ChartAreas.Add(areaPizza);

            // GRÁFICO DE BARRAS
            this.chartBarras.Location = new System.Drawing.Point(550, 170);
            this.chartBarras.Size = new System.Drawing.Size(550, 350);

            ChartArea areaBarras = new ChartArea("AreaBarras");
            this.chartBarras.ChartAreas.Add(areaBarras);

            // BOTÃO VOLTAR
            this.btnVoltar.Text = "🏠 Home";
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.Size = new System.Drawing.Size(120, 40);
            this.btnVoltar.Location = new System.Drawing.Point(20, 20);
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);

            // FORM
            this.ClientSize = new System.Drawing.Size(1150, 600);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTotalChamados);
            this.Controls.Add(this.lblPercentualFinalizados);
            this.Controls.Add(this.chartPizza);
            this.Controls.Add(this.chartBarras);
            this.Controls.Add(this.btnVoltar);
            this.Name = "FormRelatorios";
            this.Text = "Relatórios";

            ((System.ComponentModel.ISupportInitialize)(this.chartPizza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
