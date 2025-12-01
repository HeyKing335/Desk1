namespace HelpFastDesktop
{
    partial class FormTodosChamados
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::HelpFastDesktop.Properties.Resources.Design_sem_nome__2_;
            this.button1.Location = new System.Drawing.Point(70, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 94);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormTodosChamados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.button1);
            this.Name = "FormTodosChamados";
            this.Text = "Todos os Chamados";
            this.Load += new System.EventHandler(this.FormTodosChamados_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button button1;
    }
}
