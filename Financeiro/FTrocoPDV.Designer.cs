namespace Financeiro
{
    partial class TFTrocoPDV
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
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.lblCancelar = new System.Windows.Forms.Label();
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.vl_troco = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_dinheiro = new System.Windows.Forms.Button();
            this.bb_ChTroco = new System.Windows.Forms.Button();
            this.bb_credito = new System.Windows.Forms.Button();
            this.bb_chTerceiro = new System.Windows.Forms.Button();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_troco)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpCentral.Controls.Add(this.panelDados2, 1, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(458, 168);
            this.tlpCentral.TabIndex = 5;
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.lblCancelar);
            this.panelDados2.Controls.Add(this.vl_saldo);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.vl_troco);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(287, 4);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(167, 160);
            this.panelDados2.TabIndex = 1;
            // 
            // lblCancelar
            // 
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.BackColor = System.Drawing.Color.Transparent;
            this.lblCancelar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelar.ForeColor = System.Drawing.Color.Maroon;
            this.lblCancelar.Location = new System.Drawing.Point(8, 137);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(149, 19);
            this.lblCancelar.TabIndex = 8;
            this.lblCancelar.Text = "<ESC> CANCELAR";
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            // 
            // vl_saldo
            // 
            this.vl_saldo.DecimalPlaces = 2;
            this.vl_saldo.Enabled = false;
            this.vl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_saldo.Location = new System.Drawing.Point(7, 105);
            this.vl_saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldo.Name = "vl_saldo";
            this.vl_saldo.NM_Alias = "";
            this.vl_saldo.NM_Campo = "";
            this.vl_saldo.NM_Param = "";
            this.vl_saldo.Operador = "";
            this.vl_saldo.Size = new System.Drawing.Size(154, 29);
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = false;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabIndex = 7;
            this.vl_saldo.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "SALDO TROCO";
            // 
            // vl_troco
            // 
            this.vl_troco.DecimalPlaces = 2;
            this.vl_troco.Enabled = false;
            this.vl_troco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_troco.Location = new System.Drawing.Point(7, 34);
            this.vl_troco.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_troco.Name = "vl_troco";
            this.vl_troco.NM_Alias = "";
            this.vl_troco.NM_Campo = "";
            this.vl_troco.NM_Param = "";
            this.vl_troco.Operador = "";
            this.vl_troco.Size = new System.Drawing.Size(154, 29);
            this.vl_troco.ST_AutoInc = false;
            this.vl_troco.ST_DisableAuto = false;
            this.vl_troco.ST_Gravar = false;
            this.vl_troco.ST_LimparCampo = true;
            this.vl_troco.ST_NotNull = false;
            this.vl_troco.ST_PrimaryKey = false;
            this.vl_troco.TabIndex = 5;
            this.vl_troco.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "VALOR TROCO";
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_dinheiro);
            this.panelDados1.Controls.Add(this.bb_ChTroco);
            this.panelDados1.Controls.Add(this.bb_credito);
            this.panelDados1.Controls.Add(this.bb_chTerceiro);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 4);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(276, 160);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_dinheiro
            // 
            this.bb_dinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_dinheiro.ForeColor = System.Drawing.Color.Green;
            this.bb_dinheiro.Location = new System.Drawing.Point(9, 3);
            this.bb_dinheiro.Name = "bb_dinheiro";
            this.bb_dinheiro.Size = new System.Drawing.Size(128, 73);
            this.bb_dinheiro.TabIndex = 0;
            this.bb_dinheiro.Text = "(F1) \r\nDINHEIRO";
            this.bb_dinheiro.UseVisualStyleBackColor = true;
            this.bb_dinheiro.Click += new System.EventHandler(this.bb_dinheiro_Click);
            // 
            // bb_ChTroco
            // 
            this.bb_ChTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_ChTroco.ForeColor = System.Drawing.Color.Green;
            this.bb_ChTroco.Location = new System.Drawing.Point(143, 82);
            this.bb_ChTroco.Name = "bb_ChTroco";
            this.bb_ChTroco.Size = new System.Drawing.Size(128, 73);
            this.bb_ChTroco.TabIndex = 3;
            this.bb_ChTroco.Text = "(F4) \r\nCH TROCO";
            this.bb_ChTroco.UseVisualStyleBackColor = true;
            this.bb_ChTroco.Click += new System.EventHandler(this.bb_ChTroco_Click);
            // 
            // bb_credito
            // 
            this.bb_credito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_credito.ForeColor = System.Drawing.Color.Green;
            this.bb_credito.Location = new System.Drawing.Point(143, 3);
            this.bb_credito.Name = "bb_credito";
            this.bb_credito.Size = new System.Drawing.Size(128, 73);
            this.bb_credito.TabIndex = 1;
            this.bb_credito.Text = "(F2) \r\nCREDITO";
            this.bb_credito.UseVisualStyleBackColor = true;
            this.bb_credito.Click += new System.EventHandler(this.bb_credito_Click);
            // 
            // bb_chTerceiro
            // 
            this.bb_chTerceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_chTerceiro.ForeColor = System.Drawing.Color.Green;
            this.bb_chTerceiro.Location = new System.Drawing.Point(9, 82);
            this.bb_chTerceiro.Name = "bb_chTerceiro";
            this.bb_chTerceiro.Size = new System.Drawing.Size(128, 73);
            this.bb_chTerceiro.TabIndex = 2;
            this.bb_chTerceiro.Text = "(F3) \r\nCH TERCEIRO";
            this.bb_chTerceiro.UseVisualStyleBackColor = true;
            this.bb_chTerceiro.Click += new System.EventHandler(this.bb_chTerceiro_Click);
            // 
            // TFTrocoPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 168);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFTrocoPDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTrocoPDV";
            this.Load += new System.EventHandler(this.TFTrocoPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTrocoPDV_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_troco)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bb_dinheiro;
        private System.Windows.Forms.Button bb_credito;
        private System.Windows.Forms.Button bb_chTerceiro;
        private System.Windows.Forms.Button bb_ChTroco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditFloat vl_saldo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_troco;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblCancelar;
    }
}