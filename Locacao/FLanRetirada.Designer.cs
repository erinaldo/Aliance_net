namespace Locacao
{
    partial class TFLanRetirada
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanRetirada));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.cd_funcionario = new Componentes.EditDefault(this.components);
            this.bbFuncionario = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bbEmpresa = new System.Windows.Forms.Button();
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsRetirada = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idretiradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtRetiradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_retirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_abastecidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_medidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdfuncionarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfuncionarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdlanctocaixaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetirada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(8, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(77, 13);
            label4.TabIndex = 89;
            label4.Text = "Funcionario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(26, 6);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 13);
            label3.TabIndex = 86;
            label3.Text = "Empresa:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(193, 32);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 13);
            label8.TabIndex = 83;
            label8.Text = "Dt. Fin.:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(196, 6);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 13);
            label6.TabIndex = 82;
            label6.Text = "Dt. Ini.:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Excluir,
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1046, 43);
            this.barraMenu.TabIndex = 8;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(85, 40);
            this.BB_Excluir.Text = "(F5)\r\nExcluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1046, 459);
            this.tlpCentral.TabIndex = 9;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.cd_funcionario);
            this.pFiltro.Controls.Add(this.bbFuncionario);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.bbEmpresa);
            this.pFiltro.Controls.Add(this.DT_Final);
            this.pFiltro.Controls.Add(label8);
            this.pFiltro.Controls.Add(this.DT_Inicial);
            this.pFiltro.Controls.Add(label6);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1040, 54);
            this.pFiltro.TabIndex = 0;
            // 
            // cd_funcionario
            // 
            this.cd_funcionario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_funcionario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_funcionario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_funcionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_funcionario.Location = new System.Drawing.Point(91, 29);
            this.cd_funcionario.MaxLength = 7;
            this.cd_funcionario.Name = "cd_funcionario";
            this.cd_funcionario.NM_Alias = "";
            this.cd_funcionario.NM_Campo = "cd_clifor";
            this.cd_funcionario.NM_CampoBusca = "cd_clifor";
            this.cd_funcionario.NM_Param = "@P_CD_";
            this.cd_funcionario.QTD_Zero = 0;
            this.cd_funcionario.Size = new System.Drawing.Size(67, 20);
            this.cd_funcionario.ST_AutoInc = false;
            this.cd_funcionario.ST_DisableAuto = false;
            this.cd_funcionario.ST_Float = false;
            this.cd_funcionario.ST_Gravar = true;
            this.cd_funcionario.ST_Int = false;
            this.cd_funcionario.ST_LimpaCampo = true;
            this.cd_funcionario.ST_NotNull = false;
            this.cd_funcionario.ST_PrimaryKey = false;
            this.cd_funcionario.TabIndex = 2;
            this.cd_funcionario.TextOld = null;
            this.cd_funcionario.Leave += new System.EventHandler(this.cd_funcionario_Leave);
            // 
            // bbFuncionario
            // 
            this.bbFuncionario.BackColor = System.Drawing.SystemColors.Control;
            this.bbFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("bbFuncionario.Image")));
            this.bbFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbFuncionario.Location = new System.Drawing.Point(159, 29);
            this.bbFuncionario.Name = "bbFuncionario";
            this.bbFuncionario.Size = new System.Drawing.Size(28, 19);
            this.bbFuncionario.TabIndex = 3;
            this.bbFuncionario.UseVisualStyleBackColor = false;
            this.bbFuncionario.Click += new System.EventHandler(this.bbFuncionario_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(91, 3);
            this.cd_empresa.MaxLength = 7;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bbEmpresa
            // 
            this.bbEmpresa.BackColor = System.Drawing.SystemColors.Control;
            this.bbEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("bbEmpresa.Image")));
            this.bbEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbEmpresa.Location = new System.Drawing.Point(159, 3);
            this.bbEmpresa.Name = "bbEmpresa";
            this.bbEmpresa.Size = new System.Drawing.Size(28, 19);
            this.bbEmpresa.TabIndex = 1;
            this.bbEmpresa.UseVisualStyleBackColor = false;
            this.bbEmpresa.Click += new System.EventHandler(this.bbEmpresa_Click);
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Final.Location = new System.Drawing.Point(252, 29);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(71, 20);
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = true;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 8;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BackColor = System.Drawing.Color.White;
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Inicial.Location = new System.Drawing.Point(252, 3);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.Size = new System.Drawing.Size(71, 20);
            this.DT_Inicial.ST_Gravar = true;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = true;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 7;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 63);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1040, 393);
            this.panelDados1.TabIndex = 1;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.idretiradaDataGridViewTextBoxColumn,
            this.dtRetiradaDataGridViewTextBoxColumn,
            this.Vl_retirada,
            this.Vl_abastecidas,
            this.Vl_medidas,
            this.cdfuncionarioDataGridViewTextBoxColumn,
            this.nmfuncionarioDataGridViewTextBoxColumn,
            this.dscontagerDataGridViewTextBoxColumn,
            this.cdlanctocaixaDataGridViewTextBoxColumn,
            this.obsDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsRetirada;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(1040, 368);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsRetirada
            // 
            this.bsRetirada.DataSource = typeof(CamadaDados.Locacao.TList_Retirada);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 368);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1040, 25);
            this.bindingNavigator1.TabIndex = 1;
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
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
            // idretiradaDataGridViewTextBoxColumn
            // 
            this.idretiradaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idretiradaDataGridViewTextBoxColumn.DataPropertyName = "Id_retirada";
            this.idretiradaDataGridViewTextBoxColumn.HeaderText = "Id. Retirada";
            this.idretiradaDataGridViewTextBoxColumn.Name = "idretiradaDataGridViewTextBoxColumn";
            this.idretiradaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idretiradaDataGridViewTextBoxColumn.Width = 87;
            // 
            // dtRetiradaDataGridViewTextBoxColumn
            // 
            this.dtRetiradaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtRetiradaDataGridViewTextBoxColumn.DataPropertyName = "Dt_Retirada";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtRetiradaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtRetiradaDataGridViewTextBoxColumn.HeaderText = "Dt. Retirada";
            this.dtRetiradaDataGridViewTextBoxColumn.Name = "dtRetiradaDataGridViewTextBoxColumn";
            this.dtRetiradaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtRetiradaDataGridViewTextBoxColumn.Width = 89;
            // 
            // Vl_retirada
            // 
            this.Vl_retirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_retirada.DataPropertyName = "Vl_retirada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Vl_retirada.DefaultCellStyle = dataGridViewCellStyle4;
            this.Vl_retirada.HeaderText = "Vl. Retirada";
            this.Vl_retirada.Name = "Vl_retirada";
            this.Vl_retirada.ReadOnly = true;
            this.Vl_retirada.Width = 87;
            // 
            // Vl_abastecidas
            // 
            this.Vl_abastecidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_abastecidas.DataPropertyName = "Vl_abastecidas";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Vl_abastecidas.DefaultCellStyle = dataGridViewCellStyle5;
            this.Vl_abastecidas.HeaderText = "Vl. Abastecidas";
            this.Vl_abastecidas.Name = "Vl_abastecidas";
            this.Vl_abastecidas.ReadOnly = true;
            this.Vl_abastecidas.Width = 96;
            // 
            // Vl_medidas
            // 
            this.Vl_medidas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_medidas.DataPropertyName = "Vl_medidas";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Vl_medidas.DefaultCellStyle = dataGridViewCellStyle6;
            this.Vl_medidas.HeaderText = "Vl. Medidas";
            this.Vl_medidas.Name = "Vl_medidas";
            this.Vl_medidas.ReadOnly = true;
            this.Vl_medidas.Width = 80;
            // 
            // cdfuncionarioDataGridViewTextBoxColumn
            // 
            this.cdfuncionarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfuncionarioDataGridViewTextBoxColumn.DataPropertyName = "Cd_funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn.HeaderText = "Cd. Funcionario";
            this.cdfuncionarioDataGridViewTextBoxColumn.Name = "cdfuncionarioDataGridViewTextBoxColumn";
            this.cdfuncionarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdfuncionarioDataGridViewTextBoxColumn.Width = 97;
            // 
            // nmfuncionarioDataGridViewTextBoxColumn
            // 
            this.nmfuncionarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfuncionarioDataGridViewTextBoxColumn.DataPropertyName = "Nm_funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn.HeaderText = "Funcionario";
            this.nmfuncionarioDataGridViewTextBoxColumn.Name = "nmfuncionarioDataGridViewTextBoxColumn";
            this.nmfuncionarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmfuncionarioDataGridViewTextBoxColumn.Width = 87;
            // 
            // dscontagerDataGridViewTextBoxColumn
            // 
            this.dscontagerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontagerDataGridViewTextBoxColumn.DataPropertyName = "Ds_contager";
            this.dscontagerDataGridViewTextBoxColumn.HeaderText = "Conta Gerencial";
            this.dscontagerDataGridViewTextBoxColumn.Name = "dscontagerDataGridViewTextBoxColumn";
            this.dscontagerDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontagerDataGridViewTextBoxColumn.Width = 99;
            // 
            // cdlanctocaixaDataGridViewTextBoxColumn
            // 
            this.cdlanctocaixaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdlanctocaixaDataGridViewTextBoxColumn.DataPropertyName = "Cd_lanctocaixa";
            this.cdlanctocaixaDataGridViewTextBoxColumn.HeaderText = "Cd. Caixa";
            this.cdlanctocaixaDataGridViewTextBoxColumn.Name = "cdlanctocaixaDataGridViewTextBoxColumn";
            this.cdlanctocaixaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdlanctocaixaDataGridViewTextBoxColumn.Width = 71;
            // 
            // obsDataGridViewTextBoxColumn
            // 
            this.obsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.obsDataGridViewTextBoxColumn.DataPropertyName = "Obs";
            this.obsDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.obsDataGridViewTextBoxColumn.Name = "obsDataGridViewTextBoxColumn";
            this.obsDataGridViewTextBoxColumn.ReadOnly = true;
            this.obsDataGridViewTextBoxColumn.Width = 90;
            // 
            // TFLanRetirada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 502);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFLanRetirada";
            this.ShowInTaskbar = false;
            this.Text = "Retiradas Valores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FLanRetirada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanRetirada_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRetirada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault cd_funcionario;
        private System.Windows.Forms.Button bbFuncionario;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bbEmpresa;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicial;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsRetirada;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idretiradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtRetiradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_retirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_abastecidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_medidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfuncionarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfuncionarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlanctocaixaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsDataGridViewTextBoxColumn;
    }
}