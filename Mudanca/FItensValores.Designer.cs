namespace Mudanca
{
    partial class TFItensValores
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
            this.pTotal = new Componentes.PanelDados(this.components);
            this.vl_seguro = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.tot_seguro = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_seguro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.LightGray;
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.vl_seguro);
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Controls.Add(this.lblCancela);
            this.pTotal.Controls.Add(this.lblConfirma);
            this.pTotal.Controls.Add(this.tot_seguro);
            this.pTotal.Controls.Add(this.label5);
            this.pTotal.Controls.Add(this.quantidade);
            this.pTotal.Controls.Add(this.label6);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(0, 0);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(434, 101);
            this.pTotal.TabIndex = 5;
            // 
            // vl_seguro
            // 
            this.vl_seguro.DecimalPlaces = 2;
            this.vl_seguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_seguro.Location = new System.Drawing.Point(152, 36);
            this.vl_seguro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_seguro.Name = "vl_seguro";
            this.vl_seguro.NM_Alias = "";
            this.vl_seguro.NM_Campo = "";
            this.vl_seguro.NM_Param = "";
            this.vl_seguro.Operador = "";
            this.vl_seguro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_seguro.Size = new System.Drawing.Size(132, 29);
            this.vl_seguro.ST_AutoInc = false;
            this.vl_seguro.ST_DisableAuto = false;
            this.vl_seguro.ST_Gravar = false;
            this.vl_seguro.ST_LimparCampo = true;
            this.vl_seguro.ST_NotNull = false;
            this.vl_seguro.ST_PrimaryKey = false;
            this.vl_seguro.TabIndex = 1;
            this.vl_seguro.ThousandsSeparator = true;
            this.vl_seguro.Leave += new System.EventHandler(this.vl_seguro_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(149, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Vl. Unit. Seguro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancela
            // 
            this.lblCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancela.ForeColor = System.Drawing.Color.Green;
            this.lblCancela.Location = new System.Drawing.Point(260, 72);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(162, 18);
            this.lblCancela.TabIndex = 60;
            this.lblCancela.Text = "<ESC> Sair";
            this.lblCancela.MouseLeave += new System.EventHandler(this.lblCancela_MouseLeave);
            this.lblCancela.Click += new System.EventHandler(this.lblCancela_Click);
            this.lblCancela.MouseEnter += new System.EventHandler(this.lblCancela_MouseEnter);
            // 
            // lblConfirma
            // 
            this.lblConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirma.ForeColor = System.Drawing.Color.Green;
            this.lblConfirma.Location = new System.Drawing.Point(10, 71);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(176, 19);
            this.lblConfirma.TabIndex = 59;
            this.lblConfirma.Text = "<ENTER> Confirmar";
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
            // 
            // tot_seguro
            // 
            this.tot_seguro.DecimalPlaces = 2;
            this.tot_seguro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_seguro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_seguro.Location = new System.Drawing.Point(290, 36);
            this.tot_seguro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_seguro.Name = "tot_seguro";
            this.tot_seguro.NM_Alias = "";
            this.tot_seguro.NM_Campo = "";
            this.tot_seguro.NM_Param = "";
            this.tot_seguro.Operador = "";
            this.tot_seguro.ReadOnly = true;
            this.tot_seguro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tot_seguro.Size = new System.Drawing.Size(132, 29);
            this.tot_seguro.ST_AutoInc = false;
            this.tot_seguro.ST_DisableAuto = false;
            this.tot_seguro.ST_Gravar = false;
            this.tot_seguro.ST_LimparCampo = true;
            this.tot_seguro.ST_NotNull = false;
            this.tot_seguro.ST_PrimaryKey = false;
            this.tot_seguro.TabIndex = 2;
            this.tot_seguro.TabStop = false;
            this.tot_seguro.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(298, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Total Seguro";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // quantidade
            // 
            this.quantidade.DecimalPlaces = 2;
            this.quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantidade.Location = new System.Drawing.Point(14, 36);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.quantidade.Size = new System.Drawing.Size(132, 29);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 0;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.Leave += new System.EventHandler(this.quantidade_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(11, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Quantidade";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFItensValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 101);
            this.Controls.Add(this.pTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFItensValores";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFItensValores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensValores_KeyDown);
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_seguro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_seguro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTotal;
        private Componentes.EditFloat tot_seguro;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblConfirma;
        private Componentes.EditFloat vl_seguro;
        private System.Windows.Forms.Label label1;
    }
}