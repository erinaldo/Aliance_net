namespace Financeiro
{
    partial class TFFolha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFolha));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.cdfuncionarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfuncionarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlpagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.cbSomenteFuncEmpresa = new Componentes.CheckBoxDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_marcartodos = new Componentes.CheckBoxDefault(this.components);
            this.gFuncionario = new Componentes.DataGridDefault(this.components);
            this.stgerarpagamentoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdfuncionarioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfuncionarioDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsalarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsaldoadtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vladtodevolverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFuncionario = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tot_pagar = new System.Windows.Forms.ToolStripTextBox();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_adtodevolver = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.vl_saldoadto = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_voltar = new System.Windows.Forms.Button();
            this.bb_avancar = new System.Windows.Forms.Button();
            this.st_gerarpagamento = new Componentes.CheckBoxDefault(this.components);
            this.vl_salario = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nm_funcionario = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFuncionario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFuncionario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_adtodevolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldoadto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_salario)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(1011, 43);
            this.barraMenu.TabIndex = 10;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 2);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tlpCentral.Size = new System.Drawing.Size(1011, 575);
            this.tlpCentral.TabIndex = 11;
            // 
            // cdfuncionarioDataGridViewTextBoxColumn
            // 
            this.cdfuncionarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfuncionarioDataGridViewTextBoxColumn.DataPropertyName = "Cd_funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn.HeaderText = "Cd. Funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn.Name = "cdfuncionarioDataGridViewTextBoxColumn";
            this.cdfuncionarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfuncionarioDataGridViewTextBoxColumn
            // 
            this.nmfuncionarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfuncionarioDataGridViewTextBoxColumn.DataPropertyName = "Nm_funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn.HeaderText = "Nome Funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn.Name = "nmfuncionarioDataGridViewTextBoxColumn";
            this.nmfuncionarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlpagamentoDataGridViewTextBoxColumn
            // 
            this.vlpagamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlpagamentoDataGridViewTextBoxColumn.DataPropertyName = "Vl_pagamento";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlpagamentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vlpagamentoDataGridViewTextBoxColumn.HeaderText = "Valor Pagamento";
            this.vlpagamentoDataGridViewTextBoxColumn.Name = "vlpagamentoDataGridViewTextBoxColumn";
            this.vlpagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrlanctoDataGridViewTextBoxColumn
            // 
            this.nrlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctoDataGridViewTextBoxColumn.DataPropertyName = "Nr_lancto";
            this.nrlanctoDataGridViewTextBoxColumn.HeaderText = "Nº Lancto Duplicata";
            this.nrlanctoDataGridViewTextBoxColumn.Name = "nrlanctoDataGridViewTextBoxColumn";
            this.nrlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.cbSomenteFuncEmpresa);
            this.pFiltro.Controls.Add(this.NM_Empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1001, 27);
            this.pFiltro.TabIndex = 0;
            // 
            // cbSomenteFuncEmpresa
            // 
            this.cbSomenteFuncEmpresa.AutoSize = true;
            this.cbSomenteFuncEmpresa.Checked = true;
            this.cbSomenteFuncEmpresa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSomenteFuncEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSomenteFuncEmpresa.Location = new System.Drawing.Point(623, 4);
            this.cbSomenteFuncEmpresa.Name = "cbSomenteFuncEmpresa";
            this.cbSomenteFuncEmpresa.NM_Alias = "";
            this.cbSomenteFuncEmpresa.NM_Campo = "";
            this.cbSomenteFuncEmpresa.NM_Param = "";
            this.cbSomenteFuncEmpresa.Size = new System.Drawing.Size(221, 17);
            this.cbSomenteFuncEmpresa.ST_Gravar = false;
            this.cbSomenteFuncEmpresa.ST_LimparCampo = true;
            this.cbSomenteFuncEmpresa.ST_NotNull = false;
            this.cbSomenteFuncEmpresa.TabIndex = 26;
            this.cbSomenteFuncEmpresa.Text = "Somente Funcionarios da Empresa";
            this.cbSomenteFuncEmpresa.UseVisualStyleBackColor = true;
            this.cbSomenteFuncEmpresa.Vl_False = "";
            this.cbSomenteFuncEmpresa.Vl_True = "";
            this.cbSomenteFuncEmpresa.Click += new System.EventHandler(this.cbSomenteFuncEmpresa_Click);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(141, 2);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(476, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 25;
            this.NM_Empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(63, 2);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(75, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 23;
            this.CD_Empresa.TextOld = null;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.st_marcartodos);
            this.pDados.Controls.Add(this.gFuncionario);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 40);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(1001, 479);
            this.pDados.TabIndex = 1;
            // 
            // st_marcartodos
            // 
            this.st_marcartodos.AutoSize = true;
            this.st_marcartodos.Location = new System.Drawing.Point(7, 11);
            this.st_marcartodos.Name = "st_marcartodos";
            this.st_marcartodos.NM_Alias = "";
            this.st_marcartodos.NM_Campo = "";
            this.st_marcartodos.NM_Param = "";
            this.st_marcartodos.Size = new System.Drawing.Size(15, 14);
            this.st_marcartodos.ST_Gravar = false;
            this.st_marcartodos.ST_LimparCampo = true;
            this.st_marcartodos.ST_NotNull = false;
            this.st_marcartodos.TabIndex = 9;
            this.st_marcartodos.UseVisualStyleBackColor = true;
            this.st_marcartodos.Vl_False = "";
            this.st_marcartodos.Vl_True = "";
            this.st_marcartodos.Click += new System.EventHandler(this.st_marcartodos_Click);
            // 
            // gFuncionario
            // 
            this.gFuncionario.AllowUserToAddRows = false;
            this.gFuncionario.AllowUserToDeleteRows = false;
            this.gFuncionario.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gFuncionario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gFuncionario.AutoGenerateColumns = false;
            this.gFuncionario.BackgroundColor = System.Drawing.Color.LightGray;
            this.gFuncionario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gFuncionario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gFuncionario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gFuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gFuncionario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stgerarpagamentoDataGridViewCheckBoxColumn,
            this.cdfuncionarioDataGridViewTextBoxColumn1,
            this.nmfuncionarioDataGridViewTextBoxColumn1,
            this.vlsalarioDataGridViewTextBoxColumn,
            this.vlsaldoadtoDataGridViewTextBoxColumn,
            this.vladtodevolverDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn});
            this.gFuncionario.DataSource = this.bsFuncionario;
            this.gFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gFuncionario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gFuncionario.Location = new System.Drawing.Point(0, 0);
            this.gFuncionario.Name = "gFuncionario";
            this.gFuncionario.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gFuncionario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gFuncionario.RowHeadersWidth = 23;
            this.gFuncionario.Size = new System.Drawing.Size(997, 450);
            this.gFuncionario.TabIndex = 8;
            this.gFuncionario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gFuncionario_CellClick);
            // 
            // stgerarpagamentoDataGridViewCheckBoxColumn
            // 
            this.stgerarpagamentoDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stgerarpagamentoDataGridViewCheckBoxColumn.DataPropertyName = "St_gerarpagamento";
            this.stgerarpagamentoDataGridViewCheckBoxColumn.HeaderText = "Gerar Pagamento";
            this.stgerarpagamentoDataGridViewCheckBoxColumn.Name = "stgerarpagamentoDataGridViewCheckBoxColumn";
            this.stgerarpagamentoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stgerarpagamentoDataGridViewCheckBoxColumn.Width = 87;
            // 
            // cdfuncionarioDataGridViewTextBoxColumn1
            // 
            this.cdfuncionarioDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfuncionarioDataGridViewTextBoxColumn1.DataPropertyName = "Cd_funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn1.HeaderText = "Cd. Funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn1.Name = "cdfuncionarioDataGridViewTextBoxColumn1";
            this.cdfuncionarioDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cdfuncionarioDataGridViewTextBoxColumn1.Width = 97;
            // 
            // nmfuncionarioDataGridViewTextBoxColumn1
            // 
            this.nmfuncionarioDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfuncionarioDataGridViewTextBoxColumn1.DataPropertyName = "Nm_funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn1.HeaderText = "Nome Funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn1.Name = "nmfuncionarioDataGridViewTextBoxColumn1";
            this.nmfuncionarioDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nmfuncionarioDataGridViewTextBoxColumn1.Width = 108;
            // 
            // vlsalarioDataGridViewTextBoxColumn
            // 
            this.vlsalarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsalarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_salario";
            this.vlsalarioDataGridViewTextBoxColumn.HeaderText = "Vl. Salario";
            this.vlsalarioDataGridViewTextBoxColumn.Name = "vlsalarioDataGridViewTextBoxColumn";
            this.vlsalarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlsalarioDataGridViewTextBoxColumn.Width = 73;
            // 
            // vlsaldoadtoDataGridViewTextBoxColumn
            // 
            this.vlsaldoadtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsaldoadtoDataGridViewTextBoxColumn.DataPropertyName = "Vl_saldoadto";
            this.vlsaldoadtoDataGridViewTextBoxColumn.HeaderText = "Vl. Saldo Adto";
            this.vlsaldoadtoDataGridViewTextBoxColumn.Name = "vlsaldoadtoDataGridViewTextBoxColumn";
            this.vlsaldoadtoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlsaldoadtoDataGridViewTextBoxColumn.Width = 91;
            // 
            // vladtodevolverDataGridViewTextBoxColumn
            // 
            this.vladtodevolverDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vladtodevolverDataGridViewTextBoxColumn.DataPropertyName = "Vl_adtodevolver";
            this.vladtodevolverDataGridViewTextBoxColumn.HeaderText = "Vl. Adto Devolver";
            this.vladtodevolverDataGridViewTextBoxColumn.Name = "vladtodevolverDataGridViewTextBoxColumn";
            this.vladtodevolverDataGridViewTextBoxColumn.ReadOnly = true;
            this.vladtodevolverDataGridViewTextBoxColumn.Width = 106;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 85;
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
            // bsFuncionario
            // 
            this.bsFuncionario.DataSource = typeof(CamadaDados.Financeiro.Folha_Pagamento.TList_PagamentoFolha);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsFuncionario;
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tot_pagar});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 450);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(997, 25);
            this.bindingNavigator1.TabIndex = 7;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(117, 22);
            this.toolStripLabel1.Text = "Total Salario Pagar:";
            // 
            // tot_pagar
            // 
            this.tot_pagar.Enabled = false;
            this.tot_pagar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_pagar.Name = "tot_pagar";
            this.tot_pagar.Size = new System.Drawing.Size(100, 25);
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.vl_adtodevolver);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.vl_saldoadto);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.bb_voltar);
            this.panelDados1.Controls.Add(this.bb_avancar);
            this.panelDados1.Controls.Add(this.st_gerarpagamento);
            this.panelDados1.Controls.Add(this.vl_salario);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.nm_funcionario);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cd_funcionario);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 527);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1001, 43);
            this.panelDados1.TabIndex = 0;
            // 
            // vl_adtodevolver
            // 
            this.vl_adtodevolver.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Vl_adtodevolver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_adtodevolver.DecimalPlaces = 2;
            this.vl_adtodevolver.Location = new System.Drawing.Point(672, 17);
            this.vl_adtodevolver.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_adtodevolver.Name = "vl_adtodevolver";
            this.vl_adtodevolver.NM_Alias = "";
            this.vl_adtodevolver.NM_Campo = "";
            this.vl_adtodevolver.NM_Param = "";
            this.vl_adtodevolver.Operador = "";
            this.vl_adtodevolver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_adtodevolver.Size = new System.Drawing.Size(120, 20);
            this.vl_adtodevolver.ST_AutoInc = false;
            this.vl_adtodevolver.ST_DisableAuto = false;
            this.vl_adtodevolver.ST_Gravar = false;
            this.vl_adtodevolver.ST_LimparCampo = true;
            this.vl_adtodevolver.ST_NotNull = false;
            this.vl_adtodevolver.ST_PrimaryKey = false;
            this.vl_adtodevolver.TabIndex = 32;
            this.vl_adtodevolver.ThousandsSeparator = true;
            this.vl_adtodevolver.Leave += new System.EventHandler(this.vl_adtodevolver_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(669, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Adto Devolver";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // vl_saldoadto
            // 
            this.vl_saldoadto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Vl_saldoadto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_saldoadto.DecimalPlaces = 2;
            this.vl_saldoadto.Enabled = false;
            this.vl_saldoadto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_saldoadto.Location = new System.Drawing.Point(567, 17);
            this.vl_saldoadto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldoadto.Name = "vl_saldoadto";
            this.vl_saldoadto.NM_Alias = "";
            this.vl_saldoadto.NM_Campo = "";
            this.vl_saldoadto.NM_Param = "";
            this.vl_saldoadto.Operador = "";
            this.vl_saldoadto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_saldoadto.Size = new System.Drawing.Size(99, 20);
            this.vl_saldoadto.ST_AutoInc = false;
            this.vl_saldoadto.ST_DisableAuto = false;
            this.vl_saldoadto.ST_Gravar = false;
            this.vl_saldoadto.ST_LimparCampo = true;
            this.vl_saldoadto.ST_NotNull = false;
            this.vl_saldoadto.ST_PrimaryKey = false;
            this.vl_saldoadto.TabIndex = 30;
            this.vl_saldoadto.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(564, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Saldo Adiantamento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_voltar
            // 
            this.bb_voltar.BackColor = System.Drawing.SystemColors.Control;
            this.bb_voltar.Location = new System.Drawing.Point(893, 21);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(100, 19);
            this.bb_voltar.TabIndex = 3;
            this.bb_voltar.Text = "<<<VOLTAR";
            this.bb_voltar.UseVisualStyleBackColor = false;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // bb_avancar
            // 
            this.bb_avancar.BackColor = System.Drawing.SystemColors.Control;
            this.bb_avancar.Location = new System.Drawing.Point(893, 1);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(100, 19);
            this.bb_avancar.TabIndex = 2;
            this.bb_avancar.Text = "AVANCAR >>>";
            this.bb_avancar.UseVisualStyleBackColor = false;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // st_gerarpagamento
            // 
            this.st_gerarpagamento.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsFuncionario, "St_gerarpagamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerarpagamento.Location = new System.Drawing.Point(798, 3);
            this.st_gerarpagamento.Name = "st_gerarpagamento";
            this.st_gerarpagamento.NM_Alias = "";
            this.st_gerarpagamento.NM_Campo = "";
            this.st_gerarpagamento.NM_Param = "";
            this.st_gerarpagamento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.st_gerarpagamento.Size = new System.Drawing.Size(89, 34);
            this.st_gerarpagamento.ST_Gravar = false;
            this.st_gerarpagamento.ST_LimparCampo = true;
            this.st_gerarpagamento.ST_NotNull = false;
            this.st_gerarpagamento.TabIndex = 1;
            this.st_gerarpagamento.Text = "Gerar Pagamento";
            this.st_gerarpagamento.UseVisualStyleBackColor = true;
            this.st_gerarpagamento.Vl_False = "";
            this.st_gerarpagamento.Vl_True = "";
            // 
            // vl_salario
            // 
            this.vl_salario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Vl_salario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_salario.DecimalPlaces = 2;
            this.vl_salario.Location = new System.Drawing.Point(441, 17);
            this.vl_salario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_salario.Name = "vl_salario";
            this.vl_salario.NM_Alias = "";
            this.vl_salario.NM_Campo = "";
            this.vl_salario.NM_Param = "";
            this.vl_salario.Operador = "";
            this.vl_salario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_salario.Size = new System.Drawing.Size(120, 20);
            this.vl_salario.ST_AutoInc = false;
            this.vl_salario.ST_DisableAuto = false;
            this.vl_salario.ST_Gravar = false;
            this.vl_salario.ST_LimparCampo = true;
            this.vl_salario.ST_NotNull = false;
            this.vl_salario.ST_PrimaryKey = false;
            this.vl_salario.TabIndex = 0;
            this.vl_salario.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(438, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Vl. Salario";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_funcionario
            // 
            this.nm_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.nm_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFuncionario, "Nm_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_funcionario.Enabled = false;
            this.nm_funcionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_funcionario.Location = new System.Drawing.Point(87, 17);
            this.nm_funcionario.Name = "nm_funcionario";
            this.nm_funcionario.NM_Alias = "";
            this.nm_funcionario.NM_Campo = "NM_Empresa";
            this.nm_funcionario.NM_CampoBusca = "NM_Empresa";
            this.nm_funcionario.NM_Param = "";
            this.nm_funcionario.QTD_Zero = 0;
            this.nm_funcionario.ReadOnly = true;
            this.nm_funcionario.Size = new System.Drawing.Size(348, 20);
            this.nm_funcionario.ST_AutoInc = false;
            this.nm_funcionario.ST_DisableAuto = false;
            this.nm_funcionario.ST_Float = false;
            this.nm_funcionario.ST_Gravar = false;
            this.nm_funcionario.ST_Int = false;
            this.nm_funcionario.ST_LimpaCampo = true;
            this.nm_funcionario.ST_NotNull = false;
            this.nm_funcionario.ST_PrimaryKey = false;
            this.nm_funcionario.TabIndex = 28;
            this.nm_funcionario.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Funcionario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFuncionario, "Cd_funcionario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_funcionario.Enabled = false;
            this.cd_funcionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_funcionario.Location = new System.Drawing.Point(9, 17);
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "CD_Empresa";
            this.cd_funcionario.NM_CampoBusca = "CD_Empresa";
            this.cd_funcionario.NM_Param = "@P_CD_EMPRESA";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(75, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = true;
            this.cd_funcionario.ST_Int = true;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = true;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 26;
            this.cd_funcionario.TextOld = null;
            // 
            // TFFolha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 618);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFolha";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir Funcionarios";
            this.Load += new System.EventHandler(this.TFFolha_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFFolha_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFolha_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFuncionario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFuncionario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_adtodevolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldoadto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_salario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.CheckBoxDefault cbSomenteFuncEmpresa;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfuncionarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfuncionarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlpagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gFuncionario;
        private System.Windows.Forms.BindingSource bsFuncionario;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_salario;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nm_funcionario;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_funcionario;
        private Componentes.CheckBoxDefault st_gerarpagamento;
        private Componentes.CheckBoxDefault st_marcartodos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tot_pagar;
        private System.Windows.Forms.Button bb_avancar;
        private System.Windows.Forms.Button bb_voltar;
        private Componentes.EditFloat vl_adtodevolver;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat vl_saldoadto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stgerarpagamentoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfuncionarioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfuncionarioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsalarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsaldoadtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vladtodevolverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
    }
}