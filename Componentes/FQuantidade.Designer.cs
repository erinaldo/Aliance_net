namespace Componentes
{
    partial class TFQuantidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFQuantidade));
            this.valor = new Componentes.EditFloat(this.components);
            this.lblQtde = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.valor)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // valor
            // 
            this.valor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.valor.DecimalPlaces = 3;
            this.valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valor.Location = new System.Drawing.Point(58, 96);
            this.valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor.Name = "valor";
            this.valor.NM_Alias = "";
            this.valor.NM_Campo = "";
            this.valor.NM_Param = "";
            this.valor.Operador = "";
            this.valor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valor.Size = new System.Drawing.Size(168, 31);
            this.valor.ST_AutoInc = false;
            this.valor.ST_DisableAuto = false;
            this.valor.ST_Gravar = false;
            this.valor.ST_LimparCampo = true;
            this.valor.ST_NotNull = false;
            this.valor.ST_PrimaryKey = false;
            this.valor.TabIndex = 0;
            this.valor.ThousandsSeparator = true;
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.Location = new System.Drawing.Point(46, 52);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(148, 29);
            this.lblQtde.TabIndex = 1;
            this.lblQtde.Text = "Quantidade";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelDados1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDados1.BackgroundImage")));
            this.panelDados1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.lblSaldo);
            this.panelDados1.Controls.Add(this.lblCancela);
            this.panelDados1.Controls.Add(this.lblConfirma);
            this.panelDados1.Controls.Add(this.lblQtde);
            this.panelDados1.Controls.Add(this.valor);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(284, 227);
            this.panelDados1.TabIndex = 2;
            // 
            // lblCancela
            // 
            this.lblCancela.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancela.Location = new System.Drawing.Point(53, 181);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(176, 18);
            this.lblCancela.TabIndex = 3;
            this.lblCancela.Text = "<ESC> Sair";
            this.lblCancela.MouseLeave += new System.EventHandler(this.lblCancela_MouseLeave);
            this.lblCancela.Click += new System.EventHandler(this.lblCancela_Click);
            this.lblCancela.MouseEnter += new System.EventHandler(this.lblCancela_MouseEnter);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.Location = new System.Drawing.Point(53, 152);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(176, 19);
            this.lblConfirma.TabIndex = 2;
            this.lblConfirma.Text = "<ENTER> Confirmar";
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(11, 8);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(88, 29);
            this.lblSaldo.TabIndex = 4;
            this.lblSaldo.Text = "Saldo:";
            // 
            // TFQuantidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFQuantidade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.TFQuantidade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFQuantidade_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.valor)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.EditFloat valor;
        private System.Windows.Forms.Label lblQtde;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblConfirma;
        private System.Windows.Forms.Label lblSaldo;
    }
}