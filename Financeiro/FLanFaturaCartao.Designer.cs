namespace Financeiro
{
    partial class TFLanFaturaCartao
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
            System.Windows.Forms.Label vl_tituloLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanFaturaCartao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.Tipo_cartao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFaturaCartao = new System.Windows.Forms.BindingSource(this.components);
            this.bsBandeiraCartao = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.rbCredito = new Componentes.RadioButtonDefault(this.components);
            this.rbDebito = new Componentes.RadioButtonDefault(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.bb_contager = new System.Windows.Forms.Button();
            this.cd_contager = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.gBandeiraCartao = new Componentes.DataGridDefault(this.components);
            this.imagemDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dSBandeiraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_nominal = new Componentes.EditFloat(this.components);
            this.dt_fatura = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nr_autorizacao = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            vl_tituloLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFaturaCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandeiraCartao)).BeginInit();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBandeiraCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nominal)).BeginInit();
            this.SuspendLayout();
            // 
            // vl_tituloLabel
            // 
            vl_tituloLabel.AutoSize = true;
            vl_tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            vl_tituloLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            vl_tituloLabel.Location = new System.Drawing.Point(162, 356);
            vl_tituloLabel.Name = "vl_tituloLabel";
            vl_tituloLabel.Size = new System.Drawing.Size(80, 13);
            vl_tituloLabel.TabIndex = 572;
            vl_tituloLabel.Text = "Valor Fatura:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(737, 43);
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
            // Tipo_cartao
            // 
            this.Tipo_cartao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_cartao.DataPropertyName = "Tipo_cartao";
            this.Tipo_cartao.HeaderText = "Tipo Cartão";
            this.Tipo_cartao.Name = "Tipo_cartao";
            this.Tipo_cartao.ReadOnly = true;
            // 
            // bsFaturaCartao
            // 
            this.bsFaturaCartao.DataSource = typeof(CamadaDados.Financeiro.Cartao.TList_FaturaCartao);
            // 
            // bsBandeiraCartao
            // 
            this.bsBandeiraCartao.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_contager);
            this.pDados.Controls.Add(this.bb_contager);
            this.pDados.Controls.Add(this.cd_contager);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.gBandeiraCartao);
            this.pDados.Controls.Add(this.vl_nominal);
            this.pDados.Controls.Add(vl_tituloLabel);
            this.pDados.Controls.Add(this.dt_fatura);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nr_autorizacao);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(737, 381);
            this.pDados.TabIndex = 12;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.rbCredito);
            this.radioGroup1.Controls.Add(this.rbDebito);
            this.radioGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Location = new System.Drawing.Point(577, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(147, 40);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 4;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Tipo Cartão";
            // 
            // rbCredito
            // 
            this.rbCredito.AutoSize = true;
            this.rbCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCredito.Location = new System.Drawing.Point(68, 17);
            this.rbCredito.Name = "rbCredito";
            this.rbCredito.Size = new System.Drawing.Size(58, 17);
            this.rbCredito.TabIndex = 1;
            this.rbCredito.Text = "Credito";
            this.rbCredito.UseVisualStyleBackColor = true;
            this.rbCredito.Valor = "";
            // 
            // rbDebito
            // 
            this.rbDebito.AutoSize = true;
            this.rbDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDebito.Location = new System.Drawing.Point(6, 17);
            this.rbDebito.Name = "rbDebito";
            this.rbDebito.Size = new System.Drawing.Size(56, 17);
            this.rbDebito.TabIndex = 0;
            this.rbDebito.Text = "Debito";
            this.rbDebito.UseVisualStyleBackColor = true;
            this.rbDebito.Valor = "";
            this.rbDebito.CheckedChanged += new System.EventHandler(this.rbDebito_CheckedChanged);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(203, 327);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_CD_EMPRESA";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(521, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = true;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = true;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 581;
            this.ds_historico.TextOld = null;
            // 
            // bb_historico
            // 
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(169, 326);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(28, 21);
            this.bb_historico.TabIndex = 9;
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFaturaCartao, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Location = new System.Drawing.Point(89, 327);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_EMPRESA";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(79, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = true;
            this.cd_historico.TabIndex = 8;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(22, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 580;
            this.label4.Text = "Historico:";
            // 
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.Enabled = false;
            this.ds_contager.Location = new System.Drawing.Point(203, 301);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_CD_EMPRESA";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(521, 20);
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = true;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = true;
            this.ds_contager.ST_PrimaryKey = false;
            this.ds_contager.TabIndex = 577;
            this.ds_contager.TextOld = null;
            // 
            // bb_contager
            // 
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager.Image")));
            this.bb_contager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contager.Location = new System.Drawing.Point(169, 300);
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.Size = new System.Drawing.Size(28, 21);
            this.bb_contager.TabIndex = 7;
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // cd_contager
            // 
            this.cd_contager.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFaturaCartao, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Location = new System.Drawing.Point(89, 301);
            this.cd_contager.Name = "cd_contager";
            this.cd_contager.NM_Alias = "";
            this.cd_contager.NM_Campo = "cd_contager";
            this.cd_contager.NM_CampoBusca = "cd_contager";
            this.cd_contager.NM_Param = "@P_CD_EMPRESA";
            this.cd_contager.QTD_Zero = 0;
            this.cd_contager.Size = new System.Drawing.Size(79, 20);
            this.cd_contager.ST_AutoInc = false;
            this.cd_contager.ST_DisableAuto = false;
            this.cd_contager.ST_Float = false;
            this.cd_contager.ST_Gravar = true;
            this.cd_contager.ST_Int = false;
            this.cd_contager.ST_LimpaCampo = true;
            this.cd_contager.ST_NotNull = true;
            this.cd_contager.ST_PrimaryKey = true;
            this.cd_contager.TabIndex = 6;
            this.cd_contager.TextOld = null;
            this.cd_contager.Leave += new System.EventHandler(this.cd_contager_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(11, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 576;
            this.label3.Text = "Conta Ger.:";
            // 
            // gBandeiraCartao
            // 
            this.gBandeiraCartao.AllowUserToAddRows = false;
            this.gBandeiraCartao.AllowUserToDeleteRows = false;
            this.gBandeiraCartao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBandeiraCartao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBandeiraCartao.AutoGenerateColumns = false;
            this.gBandeiraCartao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gBandeiraCartao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBandeiraCartao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBandeiraCartao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBandeiraCartao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBandeiraCartao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBandeiraCartao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imagemDataGridViewImageColumn,
            this.dSBandeiraDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
            this.gBandeiraCartao.DataSource = this.bsBandeiraCartao;
            this.gBandeiraCartao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBandeiraCartao.Location = new System.Drawing.Point(89, 51);
            this.gBandeiraCartao.MultiSelect = false;
            this.gBandeiraCartao.Name = "gBandeiraCartao";
            this.gBandeiraCartao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBandeiraCartao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gBandeiraCartao.RowHeadersWidth = 23;
            this.gBandeiraCartao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gBandeiraCartao.Size = new System.Drawing.Size(635, 244);
            this.gBandeiraCartao.TabIndex = 5;
            this.gBandeiraCartao.TabStop = false;
            // 
            // imagemDataGridViewImageColumn
            // 
            this.imagemDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.imagemDataGridViewImageColumn.DataPropertyName = "Imagem";
            this.imagemDataGridViewImageColumn.HeaderText = "Icone";
            this.imagemDataGridViewImageColumn.Name = "imagemDataGridViewImageColumn";
            this.imagemDataGridViewImageColumn.ReadOnly = true;
            this.imagemDataGridViewImageColumn.Width = 40;
            // 
            // dSBandeiraDataGridViewTextBoxColumn
            // 
            this.dSBandeiraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dSBandeiraDataGridViewTextBoxColumn.DataPropertyName = "DS_Bandeira";
            this.dSBandeiraDataGridViewTextBoxColumn.HeaderText = "Bandeira Cartão";
            this.dSBandeiraDataGridViewTextBoxColumn.Name = "dSBandeiraDataGridViewTextBoxColumn";
            this.dSBandeiraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tipo_cartao";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo Cartão";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // vl_nominal
            // 
            this.vl_nominal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFaturaCartao, "Vl_nominal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_nominal.DecimalPlaces = 2;
            this.vl_nominal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_nominal.Location = new System.Drawing.Point(248, 353);
            this.vl_nominal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_nominal.Name = "vl_nominal";
            this.vl_nominal.NM_Alias = "";
            this.vl_nominal.NM_Campo = "";
            this.vl_nominal.NM_Param = "";
            this.vl_nominal.Operador = "";
            this.vl_nominal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_nominal.Size = new System.Drawing.Size(115, 20);
            this.vl_nominal.ST_AutoInc = false;
            this.vl_nominal.ST_DisableAuto = false;
            this.vl_nominal.ST_Gravar = true;
            this.vl_nominal.ST_LimparCampo = true;
            this.vl_nominal.ST_NotNull = true;
            this.vl_nominal.ST_PrimaryKey = false;
            this.vl_nominal.TabIndex = 11;
            this.vl_nominal.ThousandsSeparator = true;
            // 
            // dt_fatura
            // 
            this.dt_fatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fatura.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFaturaCartao, "Dt_faturastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_fatura.Location = new System.Drawing.Point(89, 353);
            this.dt_fatura.Mask = "00/00/0000";
            this.dt_fatura.Name = "dt_fatura";
            this.dt_fatura.NM_Alias = "";
            this.dt_fatura.NM_Campo = "";
            this.dt_fatura.NM_CampoBusca = "";
            this.dt_fatura.NM_Param = "";
            this.dt_fatura.Operador = "";
            this.dt_fatura.Size = new System.Drawing.Size(67, 20);
            this.dt_fatura.ST_Gravar = true;
            this.dt_fatura.ST_LimpaCampo = true;
            this.dt_fatura.ST_NotNull = true;
            this.dt_fatura.ST_PrimaryKey = false;
            this.dt_fatura.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(15, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 571;
            this.label8.Text = "Dt. Fatura:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 567;
            this.label2.Text = "Bandeira:";
            // 
            // nr_autorizacao
            // 
            this.nr_autorizacao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_autorizacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_autorizacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_autorizacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFaturaCartao, "Nr_autorizacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_autorizacao.Location = new System.Drawing.Point(411, 25);
            this.nr_autorizacao.Name = "nr_autorizacao";
            this.nr_autorizacao.NM_Alias = "";
            this.nr_autorizacao.NM_Campo = "nr_cartao";
            this.nr_autorizacao.NM_CampoBusca = "nr_cartao";
            this.nr_autorizacao.NM_Param = "@P_CD_EMPRESA";
            this.nr_autorizacao.QTD_Zero = 0;
            this.nr_autorizacao.Size = new System.Drawing.Size(160, 20);
            this.nr_autorizacao.ST_AutoInc = false;
            this.nr_autorizacao.ST_DisableAuto = false;
            this.nr_autorizacao.ST_Float = false;
            this.nr_autorizacao.ST_Gravar = true;
            this.nr_autorizacao.ST_Int = false;
            this.nr_autorizacao.ST_LimpaCampo = true;
            this.nr_autorizacao.ST_NotNull = false;
            this.nr_autorizacao.ST_PrimaryKey = false;
            this.nr_autorizacao.TabIndex = 3;
            this.nr_autorizacao.TextOld = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(408, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 13);
            this.label14.TabIndex = 566;
            this.label14.Text = "Nº Autorização";
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsFaturaCartao, "Tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(203, 24);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(202, 21);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(200, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 565;
            this.label11.Text = "Tipo Movimento";
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(169, 24);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 20);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFaturaCartao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Location = new System.Drawing.Point(89, 24);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(79, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 564;
            this.label1.Text = "Empresa:";
            // 
            // TFLanFaturaCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 424);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanFaturaCartao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incluir Fatura Cartão Débito/Crédito";
            this.Load += new System.EventHandler(this.TFLanFaturaCartao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanFaturaCartao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFaturaCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandeiraCartao)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBandeiraCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_nominal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_cartao;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nr_autorizacao;
        private System.Windows.Forms.Label label14;
        private Componentes.ComboBoxDefault tp_movimento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_nominal;
        private Componentes.EditData dt_fatura;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource bsBandeiraCartao;
        private Componentes.DataGridDefault gBandeiraCartao;
        private System.Windows.Forms.DataGridViewImageColumn imagemDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSBandeiraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault cd_contager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bsFaturaCartao;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault cd_historico;
        private System.Windows.Forms.Label label4;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.RadioButtonDefault rbCredito;
        private Componentes.RadioButtonDefault rbDebito;
    }
}