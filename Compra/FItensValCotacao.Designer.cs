namespace Compra
{
    partial class TFItensValCotacao
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
            this.pc_icms = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_icmssubst = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_ipi = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_unitCotado = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblConfirma = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_icms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icmssubst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ipi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitCotado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.LightGray;
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.pc_icms);
            this.pTotal.Controls.Add(this.label4);
            this.pTotal.Controls.Add(this.vl_icmssubst);
            this.pTotal.Controls.Add(this.label3);
            this.pTotal.Controls.Add(this.vl_ipi);
            this.pTotal.Controls.Add(this.label2);
            this.pTotal.Controls.Add(this.vl_unitCotado);
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Controls.Add(this.lblCancela);
            this.pTotal.Controls.Add(this.lblConfirma);
            this.pTotal.Controls.Add(this.quantidade);
            this.pTotal.Controls.Add(this.label6);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(0, 0);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(340, 150);
            this.pTotal.TabIndex = 6;
            // 
            // pc_icms
            // 
            this.pc_icms.DecimalPlaces = 2;
            this.pc_icms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pc_icms.Location = new System.Drawing.Point(238, 84);
            this.pc_icms.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_icms.Name = "pc_icms";
            this.pc_icms.NM_Alias = "";
            this.pc_icms.NM_Campo = "";
            this.pc_icms.NM_Param = "";
            this.pc_icms.Operador = "";
            this.pc_icms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_icms.Size = new System.Drawing.Size(77, 20);
            this.pc_icms.ST_AutoInc = false;
            this.pc_icms.ST_DisableAuto = false;
            this.pc_icms.ST_Gravar = false;
            this.pc_icms.ST_LimparCampo = true;
            this.pc_icms.ST_NotNull = false;
            this.pc_icms.ST_PrimaryKey = false;
            this.pc_icms.TabIndex = 4;
            this.pc_icms.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(235, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "% ICMS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_icmssubst
            // 
            this.vl_icmssubst.DecimalPlaces = 2;
            this.vl_icmssubst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_icmssubst.Location = new System.Drawing.Point(109, 84);
            this.vl_icmssubst.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_icmssubst.Name = "vl_icmssubst";
            this.vl_icmssubst.NM_Alias = "";
            this.vl_icmssubst.NM_Campo = "";
            this.vl_icmssubst.NM_Param = "";
            this.vl_icmssubst.Operador = "";
            this.vl_icmssubst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_icmssubst.Size = new System.Drawing.Size(94, 20);
            this.vl_icmssubst.ST_AutoInc = false;
            this.vl_icmssubst.ST_DisableAuto = false;
            this.vl_icmssubst.ST_Gravar = false;
            this.vl_icmssubst.ST_LimparCampo = true;
            this.vl_icmssubst.ST_NotNull = false;
            this.vl_icmssubst.ST_PrimaryKey = false;
            this.vl_icmssubst.TabIndex = 3;
            this.vl_icmssubst.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(106, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Total ST";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_ipi
            // 
            this.vl_ipi.DecimalPlaces = 2;
            this.vl_ipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_ipi.Location = new System.Drawing.Point(14, 84);
            this.vl_ipi.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_ipi.Name = "vl_ipi";
            this.vl_ipi.NM_Alias = "";
            this.vl_ipi.NM_Campo = "";
            this.vl_ipi.NM_Param = "";
            this.vl_ipi.Operador = "";
            this.vl_ipi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_ipi.Size = new System.Drawing.Size(89, 20);
            this.vl_ipi.ST_AutoInc = false;
            this.vl_ipi.ST_DisableAuto = false;
            this.vl_ipi.ST_Gravar = false;
            this.vl_ipi.ST_LimparCampo = true;
            this.vl_ipi.ST_NotNull = false;
            this.vl_ipi.ST_PrimaryKey = false;
            this.vl_ipi.TabIndex = 2;
            this.vl_ipi.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Total IPI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_unitCotado
            // 
            this.vl_unitCotado.DecimalPlaces = 5;
            this.vl_unitCotado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_unitCotado.Location = new System.Drawing.Point(183, 36);
            this.vl_unitCotado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitCotado.Name = "vl_unitCotado";
            this.vl_unitCotado.NM_Alias = "";
            this.vl_unitCotado.NM_Campo = "";
            this.vl_unitCotado.NM_Param = "";
            this.vl_unitCotado.Operador = "";
            this.vl_unitCotado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_unitCotado.Size = new System.Drawing.Size(132, 29);
            this.vl_unitCotado.ST_AutoInc = false;
            this.vl_unitCotado.ST_DisableAuto = false;
            this.vl_unitCotado.ST_Gravar = false;
            this.vl_unitCotado.ST_LimparCampo = true;
            this.vl_unitCotado.ST_NotNull = false;
            this.vl_unitCotado.ST_PrimaryKey = false;
            this.vl_unitCotado.TabIndex = 1;
            this.vl_unitCotado.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Vl. Unit. Cotado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCancela
            // 
            this.lblCancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancela.ForeColor = System.Drawing.Color.Green;
            this.lblCancela.Location = new System.Drawing.Point(192, 114);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(143, 18);
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
            this.lblConfirma.Location = new System.Drawing.Point(10, 113);
            this.lblConfirma.Name = "lblConfirma";
            this.lblConfirma.Size = new System.Drawing.Size(176, 19);
            this.lblConfirma.TabIndex = 59;
            this.lblConfirma.Text = "<ENTER> Confirmar";
            this.lblConfirma.MouseLeave += new System.EventHandler(this.lblConfirma_MouseLeave);
            this.lblConfirma.Click += new System.EventHandler(this.lblConfirma_Click);
            this.lblConfirma.MouseEnter += new System.EventHandler(this.lblConfirma_MouseEnter);
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
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "QTD.Atendida";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFItensValCotacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 150);
            this.Controls.Add(this.pTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFItensValCotacao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FItensValCotacao";
            this.Load += new System.EventHandler(this.TFItensValCotacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensValCotacao_KeyDown);
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_icms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icmssubst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ipi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitCotado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pTotal;
        private Componentes.EditFloat vl_unitCotado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblConfirma;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat pc_icms;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_icmssubst;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat vl_ipi;
        private System.Windows.Forms.Label label2;
    }
}