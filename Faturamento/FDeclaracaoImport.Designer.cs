namespace Faturamento
{
    partial class TFDeclaracaoImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDeclaracaoImport));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pdados = new Componentes.PanelDados(this.components);
            this.nSeqAdicao = new Componentes.EditDefault(this.components);
            this.BS_DI = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.Nr_adicao = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.TP_intermedio = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.Vl_AFRMM = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.TP_ViaTransp = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.xLocDesemb = new Componentes.EditDefault(this.components);
            this.cd_ufdesemb = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dt_di = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nr_di = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_desemb = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pdados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_DI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_AFRMM)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(511, 43);
            this.barraMenu.TabIndex = 11;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // pdados
            // 
            this.pdados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pdados.Controls.Add(this.nSeqAdicao);
            this.pdados.Controls.Add(this.label10);
            this.pdados.Controls.Add(this.Nr_adicao);
            this.pdados.Controls.Add(this.label9);
            this.pdados.Controls.Add(this.TP_intermedio);
            this.pdados.Controls.Add(this.label8);
            this.pdados.Controls.Add(this.Vl_AFRMM);
            this.pdados.Controls.Add(this.label7);
            this.pdados.Controls.Add(this.TP_ViaTransp);
            this.pdados.Controls.Add(this.label6);
            this.pdados.Controls.Add(this.xLocDesemb);
            this.pdados.Controls.Add(this.cd_ufdesemb);
            this.pdados.Controls.Add(this.label1);
            this.pdados.Controls.Add(this.dt_di);
            this.pdados.Controls.Add(this.label5);
            this.pdados.Controls.Add(this.nr_di);
            this.pdados.Controls.Add(this.label4);
            this.pdados.Controls.Add(this.dt_desemb);
            this.pdados.Controls.Add(this.label3);
            this.pdados.Controls.Add(this.label2);
            this.pdados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdados.Location = new System.Drawing.Point(0, 43);
            this.pdados.Name = "pdados";
            this.pdados.NM_ProcDeletar = "";
            this.pdados.NM_ProcGravar = "";
            this.pdados.Size = new System.Drawing.Size(511, 180);
            this.pdados.TabIndex = 12;
            // 
            // nSeqAdicao
            // 
            this.nSeqAdicao.BackColor = System.Drawing.SystemColors.Window;
            this.nSeqAdicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nSeqAdicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nSeqAdicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "nSeqAdic", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nSeqAdicao.Location = new System.Drawing.Point(426, 145);
            this.nSeqAdicao.Name = "nSeqAdicao";
            this.nSeqAdicao.NM_Alias = "";
            this.nSeqAdicao.NM_Campo = "Nº Sequência";
            this.nSeqAdicao.NM_CampoBusca = "Nº Sequência";
            this.nSeqAdicao.NM_Param = "@P_Nº SEQUÊNCIA";
            this.nSeqAdicao.QTD_Zero = 0;
            this.nSeqAdicao.Size = new System.Drawing.Size(72, 20);
            this.nSeqAdicao.ST_AutoInc = false;
            this.nSeqAdicao.ST_DisableAuto = false;
            this.nSeqAdicao.ST_Float = false;
            this.nSeqAdicao.ST_Gravar = true;
            this.nSeqAdicao.ST_Int = false;
            this.nSeqAdicao.ST_LimpaCampo = true;
            this.nSeqAdicao.ST_NotNull = true;
            this.nSeqAdicao.ST_PrimaryKey = false;
            this.nSeqAdicao.TabIndex = 9;
            this.nSeqAdicao.TextOld = null;
            // 
            // BS_DI
            // 
            this.BS_DI.DataSource = typeof(CamadaDados.Faturamento.NotaFiscal.TList_DeclaracaoImport);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(347, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Nº Sequência:";
            // 
            // Nr_adicao
            // 
            this.Nr_adicao.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_adicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_adicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_adicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "Nr_adicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nr_adicao.Location = new System.Drawing.Point(269, 145);
            this.Nr_adicao.Name = "Nr_adicao";
            this.Nr_adicao.NM_Alias = "";
            this.Nr_adicao.NM_Campo = "Nº Adição";
            this.Nr_adicao.NM_CampoBusca = "Nº Adição:";
            this.Nr_adicao.NM_Param = "@P_Nº ADIÇÃO:";
            this.Nr_adicao.QTD_Zero = 0;
            this.Nr_adicao.Size = new System.Drawing.Size(75, 20);
            this.Nr_adicao.ST_AutoInc = false;
            this.Nr_adicao.ST_DisableAuto = false;
            this.Nr_adicao.ST_Float = false;
            this.Nr_adicao.ST_Gravar = true;
            this.Nr_adicao.ST_Int = false;
            this.Nr_adicao.ST_LimpaCampo = true;
            this.Nr_adicao.ST_NotNull = true;
            this.Nr_adicao.ST_PrimaryKey = false;
            this.Nr_adicao.TabIndex = 8;
            this.Nr_adicao.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Nº Adição:";
            // 
            // TP_intermedio
            // 
            this.TP_intermedio.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_DI, "Tp_intermedio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_intermedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TP_intermedio.FormattingEnabled = true;
            this.TP_intermedio.Location = new System.Drawing.Point(118, 31);
            this.TP_intermedio.Name = "TP_intermedio";
            this.TP_intermedio.NM_Alias = "";
            this.TP_intermedio.NM_Campo = "Tipo Desembarque";
            this.TP_intermedio.NM_Param = "@P_TIPO DESEMBARQUE";
            this.TP_intermedio.Size = new System.Drawing.Size(380, 21);
            this.TP_intermedio.ST_Gravar = true;
            this.TP_intermedio.ST_LimparCampo = true;
            this.TP_intermedio.ST_NotNull = true;
            this.TP_intermedio.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tipo Desembarque:";
            // 
            // Vl_AFRMM
            // 
            this.Vl_AFRMM.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_DI, "Vl_AFRMM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_AFRMM.DecimalPlaces = 2;
            this.Vl_AFRMM.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Vl_AFRMM.Location = new System.Drawing.Point(118, 145);
            this.Vl_AFRMM.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.Vl_AFRMM.Name = "Vl_AFRMM";
            this.Vl_AFRMM.NM_Alias = "";
            this.Vl_AFRMM.NM_Campo = "Valor";
            this.Vl_AFRMM.NM_Param = "@P_VALOR";
            this.Vl_AFRMM.Operador = "";
            this.Vl_AFRMM.Size = new System.Drawing.Size(84, 20);
            this.Vl_AFRMM.ST_AutoInc = false;
            this.Vl_AFRMM.ST_DisableAuto = false;
            this.Vl_AFRMM.ST_Gravar = true;
            this.Vl_AFRMM.ST_LimparCampo = true;
            this.Vl_AFRMM.ST_NotNull = false;
            this.Vl_AFRMM.ST_PrimaryKey = false;
            this.Vl_AFRMM.TabIndex = 7;
            this.Vl_AFRMM.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Valor:";
            // 
            // TP_ViaTransp
            // 
            this.TP_ViaTransp.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_DI, "Tp_viatransp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_ViaTransp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TP_ViaTransp.FormattingEnabled = true;
            this.TP_ViaTransp.Location = new System.Drawing.Point(118, 58);
            this.TP_ViaTransp.Name = "TP_ViaTransp";
            this.TP_ViaTransp.NM_Alias = "";
            this.TP_ViaTransp.NM_Campo = "Tipo Transporte";
            this.TP_ViaTransp.NM_Param = "@P_TIPO TRANSPORTE";
            this.TP_ViaTransp.Size = new System.Drawing.Size(380, 21);
            this.TP_ViaTransp.ST_Gravar = true;
            this.TP_ViaTransp.ST_LimparCampo = true;
            this.TP_ViaTransp.ST_NotNull = true;
            this.TP_ViaTransp.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tipo Transporte:";
            // 
            // xLocDesemb
            // 
            this.xLocDesemb.BackColor = System.Drawing.SystemColors.Window;
            this.xLocDesemb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xLocDesemb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.xLocDesemb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "xLocDesemb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.xLocDesemb.Location = new System.Drawing.Point(118, 117);
            this.xLocDesemb.Name = "xLocDesemb";
            this.xLocDesemb.NM_Alias = "";
            this.xLocDesemb.NM_Campo = "Local Desembarque";
            this.xLocDesemb.NM_CampoBusca = "Local Desembarque";
            this.xLocDesemb.NM_Param = "@P_LOCAL DESEMBARQUE";
            this.xLocDesemb.QTD_Zero = 0;
            this.xLocDesemb.Size = new System.Drawing.Size(380, 20);
            this.xLocDesemb.ST_AutoInc = false;
            this.xLocDesemb.ST_DisableAuto = false;
            this.xLocDesemb.ST_Float = false;
            this.xLocDesemb.ST_Gravar = true;
            this.xLocDesemb.ST_Int = false;
            this.xLocDesemb.ST_LimpaCampo = true;
            this.xLocDesemb.ST_NotNull = true;
            this.xLocDesemb.ST_PrimaryKey = false;
            this.xLocDesemb.TabIndex = 6;
            this.xLocDesemb.TextOld = null;
            // 
            // cd_ufdesemb
            // 
            this.cd_ufdesemb.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_DI, "Cd_ufdesemb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ufdesemb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cd_ufdesemb.FormattingEnabled = true;
            this.cd_ufdesemb.Location = new System.Drawing.Point(118, 3);
            this.cd_ufdesemb.Name = "cd_ufdesemb";
            this.cd_ufdesemb.NM_Alias = "";
            this.cd_ufdesemb.NM_Campo = "UF Desembarque";
            this.cd_ufdesemb.NM_Param = "@P_UF DESEMBARQUE";
            this.cd_ufdesemb.Size = new System.Drawing.Size(165, 21);
            this.cd_ufdesemb.ST_Gravar = true;
            this.cd_ufdesemb.ST_LimparCampo = true;
            this.cd_ufdesemb.ST_NotNull = true;
            this.cd_ufdesemb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Local Desembarque:";
            // 
            // dt_di
            // 
            this.dt_di.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_di.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "Dt_di", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_di.Location = new System.Drawing.Point(398, 89);
            this.dt_di.Mask = "00/00/0000";
            this.dt_di.Name = "dt_di";
            this.dt_di.NM_Alias = "";
            this.dt_di.NM_Campo = "Data Importação";
            this.dt_di.NM_CampoBusca = "Data Importação";
            this.dt_di.NM_Param = "@P_DATA IMPORTAÇÃO";
            this.dt_di.Operador = "";
            this.dt_di.Size = new System.Drawing.Size(100, 20);
            this.dt_di.ST_Gravar = true;
            this.dt_di.ST_LimpaCampo = true;
            this.dt_di.ST_NotNull = true;
            this.dt_di.ST_PrimaryKey = false;
            this.dt_di.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Data Importação:";
            // 
            // nr_di
            // 
            this.nr_di.BackColor = System.Drawing.SystemColors.Window;
            this.nr_di.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_di.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_di.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "Nr_di", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_di.Location = new System.Drawing.Point(118, 89);
            this.nr_di.Name = "nr_di";
            this.nr_di.NM_Alias = "";
            this.nr_di.NM_Campo = "Numero Importação";
            this.nr_di.NM_CampoBusca = "";
            this.nr_di.NM_Param = "";
            this.nr_di.QTD_Zero = 0;
            this.nr_di.Size = new System.Drawing.Size(178, 20);
            this.nr_di.ST_AutoInc = false;
            this.nr_di.ST_DisableAuto = false;
            this.nr_di.ST_Float = false;
            this.nr_di.ST_Gravar = true;
            this.nr_di.ST_Int = false;
            this.nr_di.ST_LimpaCampo = true;
            this.nr_di.ST_NotNull = true;
            this.nr_di.ST_PrimaryKey = false;
            this.nr_di.TabIndex = 4;
            this.nr_di.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Numero Importação:";
            // 
            // dt_desemb
            // 
            this.dt_desemb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_desemb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_DI, "Dt_desembstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_desemb.Location = new System.Drawing.Point(398, 4);
            this.dt_desemb.Mask = "00/00/0000";
            this.dt_desemb.Name = "dt_desemb";
            this.dt_desemb.NM_Alias = "";
            this.dt_desemb.NM_Campo = "Data Desembarque";
            this.dt_desemb.NM_CampoBusca = "Data Desembarque";
            this.dt_desemb.NM_Param = "@P_DATA DESEMBARQUE";
            this.dt_desemb.Operador = "";
            this.dt_desemb.Size = new System.Drawing.Size(100, 20);
            this.dt_desemb.ST_Gravar = true;
            this.dt_desemb.ST_LimpaCampo = true;
            this.dt_desemb.ST_NotNull = true;
            this.dt_desemb.ST_PrimaryKey = false;
            this.dt_desemb.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Desembarque:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 6);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "UF Desembarque:";
            // 
            // TFDeclaracaoImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 223);
            this.Controls.Add(this.pdados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDeclaracaoImport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Declaraçao de Importaçao - DI";
            this.Load += new System.EventHandler(this.TFDeclaracaoImport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDeclaracaoImport_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pdados.ResumeLayout(false);
            this.pdados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_DI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_AFRMM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pdados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditData dt_desemb;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault nr_di;
        private Componentes.EditData dt_di;
        private System.Windows.Forms.Label label5;
        private Componentes.ComboBoxDefault cd_ufdesemb;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault xLocDesemb;
        private System.Windows.Forms.Label label6;
        private Componentes.ComboBoxDefault TP_ViaTransp;
        private Componentes.EditFloat Vl_AFRMM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault TP_intermedio;
        private System.Windows.Forms.BindingSource BS_DI;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault Nr_adicao;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault nSeqAdicao;
    }
}