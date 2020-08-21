namespace Frota
{
    partial class TFDevolucaoOutrasReceitas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDevolucaoOutrasReceitas));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_salvar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.VL_Receber = new Componentes.EditFloat(this.components);
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.DT_Lancto = new Componentes.EditData(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ComplHistorico = new Componentes.EditDefault(this.components);
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.DS_ContaGer = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.BB_Historico = new System.Windows.Forms.Button();
            this.BB_ContaGer = new System.Windows.Forms.Button();
            this.CD_ContaGer = new Componentes.EditDefault(this.components);
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Receber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_salvar,
            this.BB_Excluir});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(625, 43);
            this.barraMenu.TabIndex = 7;
            // 
            // bb_salvar
            // 
            this.bb_salvar.AutoSize = false;
            this.bb_salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_salvar.ForeColor = System.Drawing.Color.Green;
            this.bb_salvar.Image = ((System.Drawing.Image)(resources.GetObject("bb_salvar.Image")));
            this.bb_salvar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_salvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_salvar.Name = "bb_salvar";
            this.bb_salvar.Size = new System.Drawing.Size(95, 40);
            this.bb_salvar.Text = "(F4)\r\nGravar";
            this.bb_salvar.ToolTipText = "Inutilizar NF-e";
            this.bb_salvar.Click += new System.EventHandler(this.bb_salvar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(92, 40);
            this.BB_Excluir.Text = "(F5)\r\nCancelar";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.VL_Receber);
            this.panelDados1.Controls.Add(this.label15);
            this.panelDados1.Controls.Add(this.NM_Empresa);
            this.panelDados1.Controls.Add(this.BB_Empresa);
            this.panelDados1.Controls.Add(this.CD_Empresa);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.DT_Lancto);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.ComplHistorico);
            this.panelDados1.Controls.Add(this.DS_Historico);
            this.panelDados1.Controls.Add(this.DS_ContaGer);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.BB_Historico);
            this.panelDados1.Controls.Add(this.BB_ContaGer);
            this.panelDados1.Controls.Add(this.CD_ContaGer);
            this.panelDados1.Controls.Add(this.CD_Historico);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(625, 197);
            this.panelDados1.TabIndex = 8;
            // 
            // VL_Receber
            // 
            this.VL_Receber.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bs, "Vl_RECEBER", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Receber.DecimalPlaces = 2;
            this.VL_Receber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.VL_Receber.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VL_Receber.Location = new System.Drawing.Point(102, 151);
            this.VL_Receber.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.VL_Receber.Minimum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            -2147483648});
            this.VL_Receber.Name = "VL_Receber";
            this.VL_Receber.NM_Alias = "";
            this.VL_Receber.NM_Campo = "VL_Receber";
            this.VL_Receber.NM_Param = "@P_VL_RECEBER";
            this.VL_Receber.Operador = "";
            this.VL_Receber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Receber.Size = new System.Drawing.Size(155, 26);
            this.VL_Receber.ST_AutoInc = false;
            this.VL_Receber.ST_DisableAuto = false;
            this.VL_Receber.ST_Gravar = true;
            this.VL_Receber.ST_LimparCampo = true;
            this.VL_Receber.ST_NotNull = false;
            this.VL_Receber.ST_PrimaryKey = false;
            this.VL_Receber.TabIndex = 160;
            this.VL_Receber.ThousandsSeparator = true;
            // 
            // bs
            // 
            this.bs.DataSource = typeof(CamadaDados.Financeiro.Caixa.TList_LanCaixa);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label15.Location = new System.Drawing.Point(1, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 13);
            this.label15.TabIndex = 161;
            this.label15.Text = "Valor Devolução:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Location = new System.Drawing.Point(207, 9);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(249, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 156;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.BB_Empresa.Location = new System.Drawing.Point(171, 9);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(30, 20);
            this.BB_Empresa.TabIndex = 146;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "Cd_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Location = new System.Drawing.Point(97, 10);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(73, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 145;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label8.Location = new System.Drawing.Point(32, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 159;
            this.label8.Text = "Empresa:";
            // 
            // DT_Lancto
            // 
            this.DT_Lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "Dt_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Lancto.Location = new System.Drawing.Point(505, 9);
            this.DT_Lancto.Mask = "00/00/0000";
            this.DT_Lancto.Name = "DT_Lancto";
            this.DT_Lancto.NM_Alias = "";
            this.DT_Lancto.NM_Campo = "DT_Lancto";
            this.DT_Lancto.NM_CampoBusca = "DT_Lancto";
            this.DT_Lancto.NM_Param = "@P_DT_LANCTO";
            this.DT_Lancto.Operador = "";
            this.DT_Lancto.Size = new System.Drawing.Size(68, 20);
            this.DT_Lancto.ST_Gravar = true;
            this.DT_Lancto.ST_LimpaCampo = true;
            this.DT_Lancto.ST_NotNull = true;
            this.DT_Lancto.ST_PrimaryKey = false;
            this.DT_Lancto.TabIndex = 141;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label7.Location = new System.Drawing.Point(462, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 154;
            this.label7.Text = "Data:";
            // 
            // ComplHistorico
            // 
            this.ComplHistorico.BackColor = System.Drawing.SystemColors.Window;
            this.ComplHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ComplHistorico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ComplHistorico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "ComplHistorico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComplHistorico.Location = new System.Drawing.Point(96, 86);
            this.ComplHistorico.Multiline = true;
            this.ComplHistorico.Name = "ComplHistorico";
            this.ComplHistorico.NM_Alias = "";
            this.ComplHistorico.NM_Campo = "ComplHistorico";
            this.ComplHistorico.NM_CampoBusca = "ComplHistorico";
            this.ComplHistorico.NM_Param = "@P_COMPLHISTORICO";
            this.ComplHistorico.QTD_Zero = 0;
            this.ComplHistorico.Size = new System.Drawing.Size(477, 59);
            this.ComplHistorico.ST_AutoInc = false;
            this.ComplHistorico.ST_DisableAuto = false;
            this.ComplHistorico.ST_Float = false;
            this.ComplHistorico.ST_Gravar = true;
            this.ComplHistorico.ST_Int = false;
            this.ComplHistorico.ST_LimpaCampo = true;
            this.ComplHistorico.ST_NotNull = false;
            this.ComplHistorico.ST_PrimaryKey = false;
            this.ComplHistorico.TabIndex = 151;
            this.ComplHistorico.TextOld = null;
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.Enabled = false;
            this.DS_Historico.Location = new System.Drawing.Point(185, 61);
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = "";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.Size = new System.Drawing.Size(388, 20);
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = false;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = false;
            this.DS_Historico.ST_PrimaryKey = false;
            this.DS_Historico.TabIndex = 143;
            this.DS_Historico.TextOld = null;
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.DS_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.Enabled = false;
            this.DS_ContaGer.Location = new System.Drawing.Point(185, 36);
            this.DS_ContaGer.Name = "DS_ContaGer";
            this.DS_ContaGer.NM_Alias = "";
            this.DS_ContaGer.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer.NM_Param = "@P_DS_CONTAGER";
            this.DS_ContaGer.QTD_Zero = 0;
            this.DS_ContaGer.Size = new System.Drawing.Size(389, 20);
            this.DS_ContaGer.ST_AutoInc = false;
            this.DS_ContaGer.ST_DisableAuto = false;
            this.DS_ContaGer.ST_Float = false;
            this.DS_ContaGer.ST_Gravar = false;
            this.DS_ContaGer.ST_Int = false;
            this.DS_ContaGer.ST_LimpaCampo = true;
            this.DS_ContaGer.ST_NotNull = false;
            this.DS_ContaGer.ST_PrimaryKey = false;
            this.DS_ContaGer.TabIndex = 155;
            this.DS_ContaGer.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label5.Location = new System.Drawing.Point(4, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Complemento:";
            // 
            // BB_Historico
            // 
            this.BB_Historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Historico.Image = ((System.Drawing.Image)(resources.GetObject("BB_Historico.Image")));
            this.BB_Historico.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.BB_Historico.Location = new System.Drawing.Point(149, 62);
            this.BB_Historico.Name = "BB_Historico";
            this.BB_Historico.Size = new System.Drawing.Size(30, 20);
            this.BB_Historico.TabIndex = 148;
            this.BB_Historico.UseVisualStyleBackColor = true;
            this.BB_Historico.Click += new System.EventHandler(this.BB_Historico_Click);
            // 
            // BB_ContaGer
            // 
            this.BB_ContaGer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_ContaGer.Image = ((System.Drawing.Image)(resources.GetObject("BB_ContaGer.Image")));
            this.BB_ContaGer.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.BB_ContaGer.Location = new System.Drawing.Point(149, 36);
            this.BB_ContaGer.Name = "BB_ContaGer";
            this.BB_ContaGer.Size = new System.Drawing.Size(30, 20);
            this.BB_ContaGer.TabIndex = 144;
            this.BB_ContaGer.UseVisualStyleBackColor = true;
            this.BB_ContaGer.Click += new System.EventHandler(this.BB_ContaGer_Click);
            // 
            // CD_ContaGer
            // 
            this.CD_ContaGer.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "Cd_ContaGer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ContaGer.Location = new System.Drawing.Point(97, 36);
            this.CD_ContaGer.Name = "CD_ContaGer";
            this.CD_ContaGer.NM_Alias = "";
            this.CD_ContaGer.NM_Campo = "CD_ContaGer";
            this.CD_ContaGer.NM_CampoBusca = "CD_ContaGer";
            this.CD_ContaGer.NM_Param = "@P_CD_CONTAGER";
            this.CD_ContaGer.QTD_Zero = 0;
            this.CD_ContaGer.Size = new System.Drawing.Size(52, 20);
            this.CD_ContaGer.ST_AutoInc = false;
            this.CD_ContaGer.ST_DisableAuto = false;
            this.CD_ContaGer.ST_Float = false;
            this.CD_ContaGer.ST_Gravar = true;
            this.CD_ContaGer.ST_Int = false;
            this.CD_ContaGer.ST_LimpaCampo = true;
            this.CD_ContaGer.ST_NotNull = true;
            this.CD_ContaGer.ST_PrimaryKey = false;
            this.CD_ContaGer.TabIndex = 142;
            this.CD_ContaGer.TextOld = null;
            this.CD_ContaGer.Leave += new System.EventHandler(this.CD_ContaGer_Leave);
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs, "Cd_Historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Historico.Location = new System.Drawing.Point(97, 61);
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.Size = new System.Drawing.Size(52, 20);
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = true;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TabIndex = 147;
            this.CD_Historico.TextOld = null;
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label6.Location = new System.Drawing.Point(23, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 158;
            this.label6.Text = "Conta Ger:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.label3.Location = new System.Drawing.Point(29, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 152;
            this.label3.Text = "Histórico:";
            // 
            // TFDevolucaoOutrasReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 240);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFDevolucaoOutrasReceitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução Outras Receitas";
            this.Load += new System.EventHandler(this.TFDevolucaoOutrasReceitas_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Receber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton bb_salvar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault NM_Empresa;
        public System.Windows.Forms.Button BB_Empresa;
        public Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        public Componentes.EditData DT_Lancto;
        private System.Windows.Forms.Label label7;
        public Componentes.EditDefault ComplHistorico;
        private Componentes.EditDefault DS_Historico;
        private Componentes.EditDefault DS_ContaGer;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button BB_Historico;
        public System.Windows.Forms.Button BB_ContaGer;
        public Componentes.EditDefault CD_ContaGer;
        public Componentes.EditDefault CD_Historico;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        public Componentes.EditFloat VL_Receber;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.BindingSource bs;
    }
}