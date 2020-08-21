namespace PDV
{
    partial class TFFecharVendaPDV
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
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_duplicata = new System.Windows.Forms.Button();
            this.bb_gerarcredito = new System.Windows.Forms.Button();
            this.bb_dinheiro = new System.Windows.Forms.Button();
            this.bb_cartaodebito = new System.Windows.Forms.Button();
            this.bb_cheque = new System.Windows.Forms.Button();
            this.bb_cartaocredito = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.VL_DESCONTO = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.vl_receber = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vl_pago = new Componentes.EditFloat(this.components);
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.LabelSaldo = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_DESCONTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_receber)).BeginInit();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_pago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpCentral.Size = new System.Drawing.Size(536, 310);
            this.tlpCentral.TabIndex = 6;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.bb_duplicata);
            this.panelDados1.Controls.Add(this.bb_gerarcredito);
            this.panelDados1.Controls.Add(this.bb_dinheiro);
            this.panelDados1.Controls.Add(this.bb_cartaodebito);
            this.panelDados1.Controls.Add(this.bb_cheque);
            this.panelDados1.Controls.Add(this.bb_cartaocredito);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 4);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(528, 161);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_duplicata
            // 
            this.bb_duplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_duplicata.ForeColor = System.Drawing.Color.Green;
            this.bb_duplicata.Location = new System.Drawing.Point(353, 3);
            this.bb_duplicata.Name = "bb_duplicata";
            this.bb_duplicata.Size = new System.Drawing.Size(166, 73);
            this.bb_duplicata.TabIndex = 5;
            this.bb_duplicata.TabStop = false;
            this.bb_duplicata.Text = "(F3) \r\nNOTAS A COBRAR";
            this.bb_duplicata.UseVisualStyleBackColor = true;
            this.bb_duplicata.Click += new System.EventHandler(this.bb_duplicata_Click);
            // 
            // bb_gerarcredito
            // 
            this.bb_gerarcredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gerarcredito.ForeColor = System.Drawing.Color.Green;
            this.bb_gerarcredito.Location = new System.Drawing.Point(353, 82);
            this.bb_gerarcredito.Name = "bb_gerarcredito";
            this.bb_gerarcredito.Size = new System.Drawing.Size(166, 73);
            this.bb_gerarcredito.TabIndex = 4;
            this.bb_gerarcredito.TabStop = false;
            this.bb_gerarcredito.Text = "(F6) \r\nDEVOLUÇÃO\r\n CRÉDITO";
            this.bb_gerarcredito.UseVisualStyleBackColor = true;
            this.bb_gerarcredito.Click += new System.EventHandler(this.bb_gerarcredito_Click);
            // 
            // bb_dinheiro
            // 
            this.bb_dinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_dinheiro.ForeColor = System.Drawing.Color.Green;
            this.bb_dinheiro.Location = new System.Drawing.Point(9, 3);
            this.bb_dinheiro.Name = "bb_dinheiro";
            this.bb_dinheiro.Size = new System.Drawing.Size(166, 73);
            this.bb_dinheiro.TabIndex = 0;
            this.bb_dinheiro.TabStop = false;
            this.bb_dinheiro.Text = "(F1) \r\nDINHEIRO";
            this.bb_dinheiro.UseVisualStyleBackColor = true;
            this.bb_dinheiro.Click += new System.EventHandler(this.bb_dinheiro_Click);
            // 
            // bb_cartaodebito
            // 
            this.bb_cartaodebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartaodebito.ForeColor = System.Drawing.Color.Green;
            this.bb_cartaodebito.Location = new System.Drawing.Point(181, 82);
            this.bb_cartaodebito.Name = "bb_cartaodebito";
            this.bb_cartaodebito.Size = new System.Drawing.Size(166, 73);
            this.bb_cartaodebito.TabIndex = 3;
            this.bb_cartaodebito.TabStop = false;
            this.bb_cartaodebito.Text = "(F5) \r\nCARTÃO DÉBITO";
            this.bb_cartaodebito.UseVisualStyleBackColor = true;
            this.bb_cartaodebito.Click += new System.EventHandler(this.bb_cartaodebito_Click);
            // 
            // bb_cheque
            // 
            this.bb_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cheque.ForeColor = System.Drawing.Color.Green;
            this.bb_cheque.Location = new System.Drawing.Point(181, 3);
            this.bb_cheque.Name = "bb_cheque";
            this.bb_cheque.Size = new System.Drawing.Size(166, 73);
            this.bb_cheque.TabIndex = 1;
            this.bb_cheque.TabStop = false;
            this.bb_cheque.Text = "(F2) \r\nCHEQUE";
            this.bb_cheque.UseVisualStyleBackColor = true;
            this.bb_cheque.Click += new System.EventHandler(this.bb_cheque_Click);
            // 
            // bb_cartaocredito
            // 
            this.bb_cartaocredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cartaocredito.ForeColor = System.Drawing.Color.Green;
            this.bb_cartaocredito.Location = new System.Drawing.Point(9, 82);
            this.bb_cartaocredito.Name = "bb_cartaocredito";
            this.bb_cartaocredito.Size = new System.Drawing.Size(166, 73);
            this.bb_cartaocredito.TabIndex = 2;
            this.bb_cartaocredito.TabStop = false;
            this.bb_cartaocredito.Text = "(F4) \r\nCARTÃO CRÉDITO";
            this.bb_cartaocredito.UseVisualStyleBackColor = true;
            this.bb_cartaocredito.Click += new System.EventHandler(this.bb_cartaocredito_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.3093F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.6907F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 172);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 134);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelDados3
            // 
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.VL_DESCONTO);
            this.panelDados3.Controls.Add(this.label5);
            this.panelDados3.Controls.Add(this.vl_receber);
            this.panelDados3.Controls.Add(this.label3);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(4, 4);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(158, 126);
            this.panelDados3.TabIndex = 2;
            // 
            // VL_DESCONTO
            // 
            this.VL_DESCONTO.DecimalPlaces = 2;
            this.VL_DESCONTO.Enabled = false;
            this.VL_DESCONTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VL_DESCONTO.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VL_DESCONTO.Location = new System.Drawing.Point(10, 81);
            this.VL_DESCONTO.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.VL_DESCONTO.Name = "VL_DESCONTO";
            this.VL_DESCONTO.NM_Alias = "";
            this.VL_DESCONTO.NM_Campo = "";
            this.VL_DESCONTO.NM_Param = "";
            this.VL_DESCONTO.Operador = "";
            this.VL_DESCONTO.Size = new System.Drawing.Size(140, 29);
            this.VL_DESCONTO.ST_AutoInc = false;
            this.VL_DESCONTO.ST_DisableAuto = false;
            this.VL_DESCONTO.ST_Gravar = false;
            this.VL_DESCONTO.ST_LimparCampo = true;
            this.VL_DESCONTO.ST_NotNull = false;
            this.VL_DESCONTO.ST_PrimaryKey = false;
            this.VL_DESCONTO.TabIndex = 9;
            this.VL_DESCONTO.ThousandsSeparator = true;
            this.VL_DESCONTO.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(1, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "VL. DESCONTO";
            // 
            // vl_receber
            // 
            this.vl_receber.DecimalPlaces = 2;
            this.vl_receber.Enabled = false;
            this.vl_receber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_receber.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_receber.Location = new System.Drawing.Point(11, 29);
            this.vl_receber.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_receber.Name = "vl_receber";
            this.vl_receber.NM_Alias = "";
            this.vl_receber.NM_Campo = "";
            this.vl_receber.NM_Param = "";
            this.vl_receber.Operador = "";
            this.vl_receber.Size = new System.Drawing.Size(140, 29);
            this.vl_receber.ST_AutoInc = false;
            this.vl_receber.ST_DisableAuto = false;
            this.vl_receber.ST_Gravar = false;
            this.vl_receber.ST_LimparCampo = true;
            this.vl_receber.ST_NotNull = false;
            this.vl_receber.ST_PrimaryKey = false;
            this.vl_receber.TabIndex = 7;
            this.vl_receber.ThousandsSeparator = true;
            this.vl_receber.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(7, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "VL. RECEBER";
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.label4);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Controls.Add(this.vl_pago);
            this.panelDados2.Controls.Add(this.vl_saldo);
            this.panelDados2.Controls.Add(this.LabelSaldo);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(169, 4);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(355, 126);
            this.panelDados2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(67, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "(F7) Desconto";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(194, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "<ESC> CANCELAR";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "VL. PAGO";
            // 
            // vl_pago
            // 
            this.vl_pago.DecimalPlaces = 2;
            this.vl_pago.Enabled = false;
            this.vl_pago.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_pago.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_pago.Location = new System.Drawing.Point(7, 39);
            this.vl_pago.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_pago.Name = "vl_pago";
            this.vl_pago.NM_Alias = "";
            this.vl_pago.NM_Campo = "";
            this.vl_pago.NM_Param = "";
            this.vl_pago.Operador = "";
            this.vl_pago.Size = new System.Drawing.Size(154, 29);
            this.vl_pago.ST_AutoInc = false;
            this.vl_pago.ST_DisableAuto = false;
            this.vl_pago.ST_Gravar = false;
            this.vl_pago.ST_LimparCampo = true;
            this.vl_pago.ST_NotNull = false;
            this.vl_pago.ST_PrimaryKey = false;
            this.vl_pago.TabIndex = 5;
            this.vl_pago.ThousandsSeparator = true;
            this.vl_pago.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vl_saldo
            // 
            this.vl_saldo.DecimalPlaces = 2;
            this.vl_saldo.Enabled = false;
            this.vl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_saldo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_saldo.Location = new System.Drawing.Point(184, 39);
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
            this.vl_saldo.Size = new System.Drawing.Size(159, 29);
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = false;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabIndex = 7;
            this.vl_saldo.ThousandsSeparator = true;
            this.vl_saldo.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // LabelSaldo
            // 
            this.LabelSaldo.AutoSize = true;
            this.LabelSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSaldo.ForeColor = System.Drawing.Color.Green;
            this.LabelSaldo.Location = new System.Drawing.Point(180, 12);
            this.LabelSaldo.Name = "LabelSaldo";
            this.LabelSaldo.Size = new System.Drawing.Size(115, 24);
            this.LabelSaldo.TabIndex = 6;
            this.LabelSaldo.Text = "VL. SALDO";
            // 
            // TFFecharVendaPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 310);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFFecharVendaPDV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFFecharVendaPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFecharVendaPDV_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_DESCONTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_receber)).EndInit();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_pago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Button bb_dinheiro;
        private System.Windows.Forms.Button bb_cartaodebito;
        private System.Windows.Forms.Button bb_cheque;
        private System.Windows.Forms.Button bb_cartaocredito;
        private System.Windows.Forms.Button bb_duplicata;
        private System.Windows.Forms.Button bb_gerarcredito;
        private Componentes.PanelDados panelDados3;
        private Componentes.EditFloat vl_receber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.EditFloat vl_saldo;
        private System.Windows.Forms.Label LabelSaldo;
        private Componentes.EditFloat vl_pago;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat VL_DESCONTO;
        private System.Windows.Forms.Label label5;
    }
}