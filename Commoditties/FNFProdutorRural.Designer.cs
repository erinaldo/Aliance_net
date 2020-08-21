namespace Commoditties
{
    partial class TFNFProdutorRural
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFNFProdutorRural));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pNfProdutor = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dt_venctonfprodutor = new Componentes.EditData(this.components);
            this.nm_contratante = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nr_contrato = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.vl_nfprodutor = new Componentes.EditFloat(this.components);
            this.label33 = new System.Windows.Forms.Label();
            this.qt_nfprodutor = new Componentes.EditFloat(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.dt_emissaonfprodutor = new Componentes.EditData(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.nr_notaprodutor = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.id_ticket = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pNfProdutor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nfprodutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_nfprodutor)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(576, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pNfProdutor
            // 
            this.pNfProdutor.BackColor = System.Drawing.SystemColors.Control;
            this.pNfProdutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNfProdutor.Controls.Add(this.id_ticket);
            this.pNfProdutor.Controls.Add(this.label4);
            this.pNfProdutor.Controls.Add(this.label3);
            this.pNfProdutor.Controls.Add(this.dt_venctonfprodutor);
            this.pNfProdutor.Controls.Add(this.nm_contratante);
            this.pNfProdutor.Controls.Add(this.label2);
            this.pNfProdutor.Controls.Add(this.nr_contrato);
            this.pNfProdutor.Controls.Add(this.label1);
            this.pNfProdutor.Controls.Add(this.label42);
            this.pNfProdutor.Controls.Add(this.vl_nfprodutor);
            this.pNfProdutor.Controls.Add(this.label33);
            this.pNfProdutor.Controls.Add(this.qt_nfprodutor);
            this.pNfProdutor.Controls.Add(this.label22);
            this.pNfProdutor.Controls.Add(this.dt_emissaonfprodutor);
            this.pNfProdutor.Controls.Add(this.label21);
            this.pNfProdutor.Controls.Add(this.nr_notaprodutor);
            this.pNfProdutor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNfProdutor.Location = new System.Drawing.Point(0, 43);
            this.pNfProdutor.Name = "pNfProdutor";
            this.pNfProdutor.NM_ProcDeletar = "";
            this.pNfProdutor.NM_ProcGravar = "";
            this.pNfProdutor.Size = new System.Drawing.Size(576, 85);
            this.pNfProdutor.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(215, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Data Vencimento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dt_venctonfprodutor
            // 
            this.dt_venctonfprodutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_venctonfprodutor.Location = new System.Drawing.Point(218, 59);
            this.dt_venctonfprodutor.Mask = "00/00/0000";
            this.dt_venctonfprodutor.Name = "dt_venctonfprodutor";
            this.dt_venctonfprodutor.NM_Alias = "";
            this.dt_venctonfprodutor.NM_Campo = "";
            this.dt_venctonfprodutor.NM_CampoBusca = "";
            this.dt_venctonfprodutor.NM_Param = "";
            this.dt_venctonfprodutor.Operador = "";
            this.dt_venctonfprodutor.Size = new System.Drawing.Size(100, 20);
            this.dt_venctonfprodutor.ST_Gravar = true;
            this.dt_venctonfprodutor.ST_LimpaCampo = true;
            this.dt_venctonfprodutor.ST_NotNull = false;
            this.dt_venctonfprodutor.ST_PrimaryKey = false;
            this.dt_venctonfprodutor.TabIndex = 4;
            // 
            // nm_contratante
            // 
            this.nm_contratante.BackColor = System.Drawing.SystemColors.Window;
            this.nm_contratante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_contratante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_contratante.Enabled = false;
            this.nm_contratante.Location = new System.Drawing.Point(112, 20);
            this.nm_contratante.Name = "nm_contratante";
            this.nm_contratante.NM_Alias = "";
            this.nm_contratante.NM_Campo = "";
            this.nm_contratante.NM_CampoBusca = "";
            this.nm_contratante.NM_Param = "";
            this.nm_contratante.QTD_Zero = 0;
            this.nm_contratante.Size = new System.Drawing.Size(332, 20);
            this.nm_contratante.ST_AutoInc = false;
            this.nm_contratante.ST_DisableAuto = false;
            this.nm_contratante.ST_Float = false;
            this.nm_contratante.ST_Gravar = false;
            this.nm_contratante.ST_Int = false;
            this.nm_contratante.ST_LimpaCampo = true;
            this.nm_contratante.ST_NotNull = false;
            this.nm_contratante.ST_PrimaryKey = false;
            this.nm_contratante.TabIndex = 1;
            this.nm_contratante.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contratante";
            // 
            // nr_contrato
            // 
            this.nr_contrato.BackColor = System.Drawing.SystemColors.Window;
            this.nr_contrato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_contrato.Enabled = false;
            this.nr_contrato.Location = new System.Drawing.Point(6, 20);
            this.nr_contrato.Name = "nr_contrato";
            this.nr_contrato.NM_Alias = "";
            this.nr_contrato.NM_Campo = "";
            this.nr_contrato.NM_CampoBusca = "";
            this.nr_contrato.NM_Param = "";
            this.nr_contrato.QTD_Zero = 0;
            this.nr_contrato.Size = new System.Drawing.Size(100, 20);
            this.nr_contrato.ST_AutoInc = false;
            this.nr_contrato.ST_DisableAuto = false;
            this.nr_contrato.ST_Float = false;
            this.nr_contrato.ST_Gravar = false;
            this.nr_contrato.ST_Int = false;
            this.nr_contrato.ST_LimpaCampo = true;
            this.nr_contrato.ST_NotNull = false;
            this.nr_contrato.ST_PrimaryKey = false;
            this.nr_contrato.TabIndex = 0;
            this.nr_contrato.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nº Contrato";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(447, 43);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 13);
            this.label42.TabIndex = 16;
            this.label42.Text = "Valor NF";
            this.label42.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // vl_nfprodutor
            // 
            this.vl_nfprodutor.DecimalPlaces = 2;
            this.vl_nfprodutor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_nfprodutor.Location = new System.Drawing.Point(450, 59);
            this.vl_nfprodutor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_nfprodutor.Name = "vl_nfprodutor";
            this.vl_nfprodutor.NM_Alias = "";
            this.vl_nfprodutor.NM_Campo = "";
            this.vl_nfprodutor.NM_Param = "";
            this.vl_nfprodutor.Operador = "";
            this.vl_nfprodutor.Size = new System.Drawing.Size(120, 20);
            this.vl_nfprodutor.ST_AutoInc = false;
            this.vl_nfprodutor.ST_DisableAuto = false;
            this.vl_nfprodutor.ST_Gravar = true;
            this.vl_nfprodutor.ST_LimparCampo = true;
            this.vl_nfprodutor.ST_NotNull = false;
            this.vl_nfprodutor.ST_PrimaryKey = false;
            this.vl_nfprodutor.TabIndex = 6;
            this.vl_nfprodutor.ThousandsSeparator = true;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(321, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(79, 13);
            this.label33.TabIndex = 14;
            this.label33.Text = "Quantidade NF";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // qt_nfprodutor
            // 
            this.qt_nfprodutor.DecimalPlaces = 3;
            this.qt_nfprodutor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qt_nfprodutor.Location = new System.Drawing.Point(324, 59);
            this.qt_nfprodutor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qt_nfprodutor.Name = "qt_nfprodutor";
            this.qt_nfprodutor.NM_Alias = "";
            this.qt_nfprodutor.NM_Campo = "";
            this.qt_nfprodutor.NM_Param = "";
            this.qt_nfprodutor.Operador = "";
            this.qt_nfprodutor.Size = new System.Drawing.Size(120, 20);
            this.qt_nfprodutor.ST_AutoInc = false;
            this.qt_nfprodutor.ST_DisableAuto = false;
            this.qt_nfprodutor.ST_Gravar = true;
            this.qt_nfprodutor.ST_LimparCampo = true;
            this.qt_nfprodutor.ST_NotNull = false;
            this.qt_nfprodutor.ST_PrimaryKey = false;
            this.qt_nfprodutor.TabIndex = 5;
            this.qt_nfprodutor.ThousandsSeparator = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(109, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Data Emissão";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dt_emissaonfprodutor
            // 
            this.dt_emissaonfprodutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emissaonfprodutor.Location = new System.Drawing.Point(112, 59);
            this.dt_emissaonfprodutor.Mask = "00/00/0000";
            this.dt_emissaonfprodutor.Name = "dt_emissaonfprodutor";
            this.dt_emissaonfprodutor.NM_Alias = "";
            this.dt_emissaonfprodutor.NM_Campo = "";
            this.dt_emissaonfprodutor.NM_CampoBusca = "";
            this.dt_emissaonfprodutor.NM_Param = "";
            this.dt_emissaonfprodutor.Operador = "";
            this.dt_emissaonfprodutor.Size = new System.Drawing.Size(100, 20);
            this.dt_emissaonfprodutor.ST_Gravar = true;
            this.dt_emissaonfprodutor.ST_LimpaCampo = true;
            this.dt_emissaonfprodutor.ST_NotNull = false;
            this.dt_emissaonfprodutor.ST_PrimaryKey = false;
            this.dt_emissaonfprodutor.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(3, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Nº Nota Fiscal";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nr_notaprodutor
            // 
            this.nr_notaprodutor.BackColor = System.Drawing.SystemColors.Window;
            this.nr_notaprodutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_notaprodutor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_notaprodutor.Location = new System.Drawing.Point(6, 59);
            this.nr_notaprodutor.Name = "nr_notaprodutor";
            this.nr_notaprodutor.NM_Alias = "";
            this.nr_notaprodutor.NM_Campo = "";
            this.nr_notaprodutor.NM_CampoBusca = "";
            this.nr_notaprodutor.NM_Param = "";
            this.nr_notaprodutor.QTD_Zero = 0;
            this.nr_notaprodutor.Size = new System.Drawing.Size(100, 20);
            this.nr_notaprodutor.ST_AutoInc = false;
            this.nr_notaprodutor.ST_DisableAuto = false;
            this.nr_notaprodutor.ST_Float = false;
            this.nr_notaprodutor.ST_Gravar = true;
            this.nr_notaprodutor.ST_Int = false;
            this.nr_notaprodutor.ST_LimpaCampo = true;
            this.nr_notaprodutor.ST_NotNull = false;
            this.nr_notaprodutor.ST_PrimaryKey = false;
            this.nr_notaprodutor.TabIndex = 2;
            this.nr_notaprodutor.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Nº Ticket";
            // 
            // id_ticket
            // 
            this.id_ticket.BackColor = System.Drawing.SystemColors.Window;
            this.id_ticket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_ticket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_ticket.Enabled = false;
            this.id_ticket.Location = new System.Drawing.Point(450, 20);
            this.id_ticket.Name = "id_ticket";
            this.id_ticket.NM_Alias = "";
            this.id_ticket.NM_Campo = "";
            this.id_ticket.NM_CampoBusca = "";
            this.id_ticket.NM_Param = "";
            this.id_ticket.QTD_Zero = 0;
            this.id_ticket.Size = new System.Drawing.Size(120, 20);
            this.id_ticket.ST_AutoInc = false;
            this.id_ticket.ST_DisableAuto = false;
            this.id_ticket.ST_Float = false;
            this.id_ticket.ST_Gravar = false;
            this.id_ticket.ST_Int = false;
            this.id_ticket.ST_LimpaCampo = true;
            this.id_ticket.ST_NotNull = false;
            this.id_ticket.ST_PrimaryKey = false;
            this.id_ticket.TabIndex = 24;
            this.id_ticket.TextOld = null;
            // 
            // TFNFProdutorRural
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 128);
            this.Controls.Add(this.pNfProdutor);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFNFProdutorRural";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados Nota Produtor Rural";
            this.Load += new System.EventHandler(this.TFNFProdutorRural_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFNFProdutorRural_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pNfProdutor.ResumeLayout(false);
            this.pNfProdutor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nfprodutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qt_nfprodutor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pNfProdutor;
        private System.Windows.Forms.Label label42;
        private Componentes.EditFloat vl_nfprodutor;
        private System.Windows.Forms.Label label33;
        private Componentes.EditFloat qt_nfprodutor;
        private System.Windows.Forms.Label label22;
        private Componentes.EditData dt_emissaonfprodutor;
        private System.Windows.Forms.Label label21;
        private Componentes.EditDefault nr_notaprodutor;
        private Componentes.EditDefault nm_contratante;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nr_contrato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData dt_venctonfprodutor;
        private Componentes.EditDefault id_ticket;
        private System.Windows.Forms.Label label4;
    }
}