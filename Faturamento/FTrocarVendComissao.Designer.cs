namespace Faturamento
{
    partial class TFTrocarVendComissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTrocarVendComissao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditData(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditData(this.components);
            this.BB_CompVend = new System.Windows.Forms.Button();
            this.CD_CompVend = new Componentes.EditDefault(this.components);
            this.lblAgente = new System.Windows.Forms.Label();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gComissao = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idcomissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlbasecalcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pccomissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlcomissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocomissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrnotafiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcupomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrpedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsComissao = new System.Windows.Forms.BindingSource(this.components);
            this.bbBuscar = new System.Windows.Forms.Button();
            this.cbProcessarPed = new Componentes.CheckBoxDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbVendTransf = new Componentes.ComboBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gComissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(980, 43);
            this.barraMenu.TabIndex = 6;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(95, 40);
            this.BB_Gravar.Text = "(F4)\r\nConfirma";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 2);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCentral.Size = new System.Drawing.Size(980, 465);
            this.tlpCentral.TabIndex = 7;
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bbBuscar);
            this.pFiltro.Controls.Add(this.label10);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label9);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.BB_CompVend);
            this.pFiltro.Controls.Add(this.CD_CompVend);
            this.pFiltro.Controls.Add(this.lblAgente);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(974, 30);
            this.pFiltro.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(551, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 397;
            this.label10.Text = "Dt. Final:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(616, 4);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(76, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(397, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 396;
            this.label9.Text = "Dt. Inicial:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(469, 4);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(76, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 4;
            // 
            // BB_CompVend
            // 
            this.BB_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_CompVend.Image = ((System.Drawing.Image)(resources.GetObject("BB_CompVend.Image")));
            this.BB_CompVend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CompVend.Location = new System.Drawing.Point(363, 4);
            this.BB_CompVend.Name = "BB_CompVend";
            this.BB_CompVend.Size = new System.Drawing.Size(28, 19);
            this.BB_CompVend.TabIndex = 3;
            this.BB_CompVend.UseVisualStyleBackColor = true;
            this.BB_CompVend.Click += new System.EventHandler(this.BB_CompVend_Click);
            // 
            // CD_CompVend
            // 
            this.CD_CompVend.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CompVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CompVend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CompVend.Location = new System.Drawing.Point(272, 4);
            this.CD_CompVend.Name = "CD_CompVend";
            this.CD_CompVend.NM_Alias = "";
            this.CD_CompVend.NM_Campo = "cd_clifor";
            this.CD_CompVend.NM_CampoBusca = "cd_clifor";
            this.CD_CompVend.NM_Param = "@P_CD_CLIFOR";
            this.CD_CompVend.QTD_Zero = 0;
            this.CD_CompVend.Size = new System.Drawing.Size(87, 20);
            this.CD_CompVend.ST_AutoInc = false;
            this.CD_CompVend.ST_DisableAuto = false;
            this.CD_CompVend.ST_Float = false;
            this.CD_CompVend.ST_Gravar = true;
            this.CD_CompVend.ST_Int = true;
            this.CD_CompVend.ST_LimpaCampo = true;
            this.CD_CompVend.ST_NotNull = false;
            this.CD_CompVend.ST_PrimaryKey = false;
            this.CD_CompVend.TabIndex = 2;
            this.CD_CompVend.TextOld = null;
            this.CD_CompVend.Leave += new System.EventHandler(this.CD_CompVend_Leave);
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSize = true;
            this.lblAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAgente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAgente.Location = new System.Drawing.Point(201, 7);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(65, 13);
            this.lblAgente.TabIndex = 387;
            this.lblAgente.Text = "Vendedor:";
            this.lblAgente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(167, 4);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 386;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(76, 4);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(87, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbProcessarPed);
            this.panelDados1.Controls.Add(this.gComissao);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 39);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(974, 381);
            this.panelDados1.TabIndex = 3;
            // 
            // gComissao
            // 
            this.gComissao.AllowUserToAddRows = false;
            this.gComissao.AllowUserToDeleteRows = false;
            this.gComissao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gComissao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gComissao.AutoGenerateColumns = false;
            this.gComissao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gComissao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gComissao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gComissao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gComissao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gComissao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.idcomissaoDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdvendedorDataGridViewTextBoxColumn,
            this.nmvendedorDataGridViewTextBoxColumn,
            this.dtlanctoDataGridViewTextBoxColumn,
            this.vlbasecalcDataGridViewTextBoxColumn,
            this.pccomissaoDataGridViewTextBoxColumn,
            this.vlcomissaoDataGridViewTextBoxColumn,
            this.tipocomissaoDataGridViewTextBoxColumn,
            this.nrnotafiscalDataGridViewTextBoxColumn,
            this.idcupomDataGridViewTextBoxColumn,
            this.idosDataGridViewTextBoxColumn,
            this.nrpedidoDataGridViewTextBoxColumn});
            this.gComissao.DataSource = this.bsComissao;
            this.gComissao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gComissao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gComissao.Location = new System.Drawing.Point(0, 0);
            this.gComissao.Name = "gComissao";
            this.gComissao.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gComissao.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gComissao.RowHeadersWidth = 23;
            this.gComissao.Size = new System.Drawing.Size(974, 356);
            this.gComissao.TabIndex = 0;
            this.gComissao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gComissao_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Marcar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 46;
            // 
            // idcomissaoDataGridViewTextBoxColumn
            // 
            this.idcomissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcomissaoDataGridViewTextBoxColumn.DataPropertyName = "Id_comissao";
            this.idcomissaoDataGridViewTextBoxColumn.HeaderText = "Id. Comissão";
            this.idcomissaoDataGridViewTextBoxColumn.Name = "idcomissaoDataGridViewTextBoxColumn";
            this.idcomissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcomissaoDataGridViewTextBoxColumn.Width = 92;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // cdvendedorDataGridViewTextBoxColumn
            // 
            this.cdvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdvendedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_vendedor";
            this.cdvendedorDataGridViewTextBoxColumn.HeaderText = "Cd. Vendedor";
            this.cdvendedorDataGridViewTextBoxColumn.Name = "cdvendedorDataGridViewTextBoxColumn";
            this.cdvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdvendedorDataGridViewTextBoxColumn.Width = 97;
            // 
            // nmvendedorDataGridViewTextBoxColumn
            // 
            this.nmvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmvendedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_vendedor";
            this.nmvendedorDataGridViewTextBoxColumn.HeaderText = "Vendedor";
            this.nmvendedorDataGridViewTextBoxColumn.Name = "nmvendedorDataGridViewTextBoxColumn";
            this.nmvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmvendedorDataGridViewTextBoxColumn.Width = 78;
            // 
            // dtlanctoDataGridViewTextBoxColumn
            // 
            this.dtlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_lancto";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "d";
            dataGridViewCellStyle10.NullValue = null;
            this.dtlanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtlanctoDataGridViewTextBoxColumn.HeaderText = "Dt. Comissão";
            this.dtlanctoDataGridViewTextBoxColumn.Name = "dtlanctoDataGridViewTextBoxColumn";
            this.dtlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctoDataGridViewTextBoxColumn.Width = 94;
            // 
            // vlbasecalcDataGridViewTextBoxColumn
            // 
            this.vlbasecalcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlbasecalcDataGridViewTextBoxColumn.DataPropertyName = "Vl_basecalc";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.vlbasecalcDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.vlbasecalcDataGridViewTextBoxColumn.HeaderText = "Vl. Base Calc.";
            this.vlbasecalcDataGridViewTextBoxColumn.Name = "vlbasecalcDataGridViewTextBoxColumn";
            this.vlbasecalcDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlbasecalcDataGridViewTextBoxColumn.Width = 98;
            // 
            // pccomissaoDataGridViewTextBoxColumn
            // 
            this.pccomissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pccomissaoDataGridViewTextBoxColumn.DataPropertyName = "Pc_comissao";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.pccomissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.pccomissaoDataGridViewTextBoxColumn.HeaderText = "% Comissão";
            this.pccomissaoDataGridViewTextBoxColumn.Name = "pccomissaoDataGridViewTextBoxColumn";
            this.pccomissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pccomissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlcomissaoDataGridViewTextBoxColumn
            // 
            this.vlcomissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlcomissaoDataGridViewTextBoxColumn.DataPropertyName = "Vl_comissao";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.vlcomissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.vlcomissaoDataGridViewTextBoxColumn.HeaderText = "Vl. Comissão";
            this.vlcomissaoDataGridViewTextBoxColumn.Name = "vlcomissaoDataGridViewTextBoxColumn";
            this.vlcomissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlcomissaoDataGridViewTextBoxColumn.Width = 92;
            // 
            // tipocomissaoDataGridViewTextBoxColumn
            // 
            this.tipocomissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipocomissaoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_comissao";
            this.tipocomissaoDataGridViewTextBoxColumn.HeaderText = "TP. Comissão";
            this.tipocomissaoDataGridViewTextBoxColumn.Name = "tipocomissaoDataGridViewTextBoxColumn";
            this.tipocomissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipocomissaoDataGridViewTextBoxColumn.Width = 97;
            // 
            // nrnotafiscalDataGridViewTextBoxColumn
            // 
            this.nrnotafiscalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrnotafiscalDataGridViewTextBoxColumn.DataPropertyName = "Nr_notafiscal";
            this.nrnotafiscalDataGridViewTextBoxColumn.HeaderText = "Nº Nota Fiscal";
            this.nrnotafiscalDataGridViewTextBoxColumn.Name = "nrnotafiscalDataGridViewTextBoxColumn";
            this.nrnotafiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcupomDataGridViewTextBoxColumn
            // 
            this.idcupomDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcupomDataGridViewTextBoxColumn.DataPropertyName = "Id_cupom";
            this.idcupomDataGridViewTextBoxColumn.HeaderText = "Id. Venda";
            this.idcupomDataGridViewTextBoxColumn.Name = "idcupomDataGridViewTextBoxColumn";
            this.idcupomDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcupomDataGridViewTextBoxColumn.Width = 78;
            // 
            // idosDataGridViewTextBoxColumn
            // 
            this.idosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idosDataGridViewTextBoxColumn.DataPropertyName = "Id_os";
            this.idosDataGridViewTextBoxColumn.HeaderText = "Id. OS";
            this.idosDataGridViewTextBoxColumn.Name = "idosDataGridViewTextBoxColumn";
            this.idosDataGridViewTextBoxColumn.ReadOnly = true;
            this.idosDataGridViewTextBoxColumn.Width = 62;
            // 
            // nrpedidoDataGridViewTextBoxColumn
            // 
            this.nrpedidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrpedidoDataGridViewTextBoxColumn.DataPropertyName = "Nr_pedido";
            this.nrpedidoDataGridViewTextBoxColumn.HeaderText = "Nº Pedido";
            this.nrpedidoDataGridViewTextBoxColumn.Name = "nrpedidoDataGridViewTextBoxColumn";
            this.nrpedidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrpedidoDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsComissao
            // 
            this.bsComissao.DataSource = typeof(CamadaDados.Faturamento.Comissao.TList_Fechamento_Comissao);
            // 
            // bbBuscar
            // 
            this.bbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbBuscar.ForeColor = System.Drawing.Color.Green;
            this.bbBuscar.Image = ((System.Drawing.Image)(resources.GetObject("bbBuscar.Image")));
            this.bbBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bbBuscar.Location = new System.Drawing.Point(698, 0);
            this.bbBuscar.Name = "bbBuscar";
            this.bbBuscar.Size = new System.Drawing.Size(99, 29);
            this.bbBuscar.TabIndex = 6;
            this.bbBuscar.Text = "Buscar";
            this.bbBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bbBuscar.UseVisualStyleBackColor = true;
            this.bbBuscar.Click += new System.EventHandler(this.bbBuscar_Click);
            // 
            // cbProcessarPed
            // 
            this.cbProcessarPed.AutoSize = true;
            this.cbProcessarPed.Location = new System.Drawing.Point(7, 5);
            this.cbProcessarPed.Name = "cbProcessarPed";
            this.cbProcessarPed.NM_Alias = "";
            this.cbProcessarPed.NM_Campo = "";
            this.cbProcessarPed.NM_Param = "";
            this.cbProcessarPed.Size = new System.Drawing.Size(15, 14);
            this.cbProcessarPed.ST_Gravar = false;
            this.cbProcessarPed.ST_LimparCampo = true;
            this.cbProcessarPed.ST_NotNull = false;
            this.cbProcessarPed.TabIndex = 4;
            this.cbProcessarPed.UseVisualStyleBackColor = true;
            this.cbProcessarPed.Vl_False = "";
            this.cbProcessarPed.Vl_True = "";
            this.cbProcessarPed.Click += new System.EventHandler(this.cbProcessarPed_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsComissao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 356);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(974, 25);
            this.bindingNavigator1.TabIndex = 5;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.cbVendTransf);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 426);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(974, 36);
            this.panelDados2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(377, 20);
            this.label2.TabIndex = 388;
            this.label2.Text = "Selecione Vendedor para Receber Comissões";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbVendTransf
            // 
            this.cbVendTransf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendTransf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVendTransf.FormattingEnabled = true;
            this.cbVendTransf.Location = new System.Drawing.Point(391, 3);
            this.cbVendTransf.Name = "cbVendTransf";
            this.cbVendTransf.NM_Alias = "";
            this.cbVendTransf.NM_Campo = "";
            this.cbVendTransf.NM_Param = "";
            this.cbVendTransf.Size = new System.Drawing.Size(573, 28);
            this.cbVendTransf.ST_Gravar = false;
            this.cbVendTransf.ST_LimparCampo = true;
            this.cbVendTransf.ST_NotNull = false;
            this.cbVendTransf.TabIndex = 389;
            // 
            // TFTrocarVendComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 508);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTrocarVendComissao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trocar Vendedor Comissão";
            this.Load += new System.EventHandler(this.TFTrocarVendComissao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTrocarVendComissao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gComissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsComissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Label label10;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Label label9;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Button BB_CompVend;
        private Componentes.EditDefault CD_CompVend;
        private System.Windows.Forms.Label lblAgente;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gComissao;
        private System.Windows.Forms.BindingSource bsComissao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlbasecalcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pccomissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlcomissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocomissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrnotafiscalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcupomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrpedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bbBuscar;
        private Componentes.CheckBoxDefault cbProcessarPed;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados panelDados2;
        private Componentes.ComboBoxDefault cbVendTransf;
        private System.Windows.Forms.Label label2;
    }
}