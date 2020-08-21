namespace PostoCombustivel
{
    partial class TFLanEncerranteBico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanEncerranteBico));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.st_intervencao = new Componentes.CheckBoxDefault(this.components);
            this.st_fechamento = new Componentes.CheckBoxDefault(this.components);
            this.st_abertura = new Componentes.CheckBoxDefault(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bb_bico = new System.Windows.Forms.Button();
            this.dt_fin = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.id_bico = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gEncerrante = new Componentes.DataGridDefault(this.components);
            this.idencerrantestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbicostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labelbico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtencerrantestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoencerranteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdencerranteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEncerrante = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_combustivel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cd_combustivel = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.id_encerrante = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEncerrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEncerrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(965, 43);
            this.barraMenu.TabIndex = 5;
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
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)\r\nAlterar";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(100, 40);
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
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(965, 510);
            this.tlpCentral.TabIndex = 6;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bb_combustivel);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.cd_combustivel);
            this.pFiltro.Controls.Add(this.st_intervencao);
            this.pFiltro.Controls.Add(this.st_fechamento);
            this.pFiltro.Controls.Add(this.st_abertura);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.label9);
            this.pFiltro.Controls.Add(this.label8);
            this.pFiltro.Controls.Add(this.bb_bico);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.id_bico);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.id_encerrante);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(955, 55);
            this.pFiltro.TabIndex = 2;
            // 
            // st_intervencao
            // 
            this.st_intervencao.AutoSize = true;
            this.st_intervencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_intervencao.Location = new System.Drawing.Point(581, 6);
            this.st_intervencao.Name = "st_intervencao";
            this.st_intervencao.NM_Alias = "";
            this.st_intervencao.NM_Campo = "";
            this.st_intervencao.NM_Param = "";
            this.st_intervencao.Size = new System.Drawing.Size(144, 17);
            this.st_intervencao.ST_Gravar = false;
            this.st_intervencao.ST_LimparCampo = true;
            this.st_intervencao.ST_NotNull = false;
            this.st_intervencao.TabIndex = 9;
            this.st_intervencao.Text = "Intervenção Tecnica";
            this.st_intervencao.UseVisualStyleBackColor = true;
            this.st_intervencao.Vl_False = "";
            this.st_intervencao.Vl_True = "";
            // 
            // st_fechamento
            // 
            this.st_fechamento.AutoSize = true;
            this.st_fechamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_fechamento.Location = new System.Drawing.Point(480, 28);
            this.st_fechamento.Name = "st_fechamento";
            this.st_fechamento.NM_Alias = "";
            this.st_fechamento.NM_Campo = "";
            this.st_fechamento.NM_Param = "";
            this.st_fechamento.Size = new System.Drawing.Size(95, 17);
            this.st_fechamento.ST_Gravar = false;
            this.st_fechamento.ST_LimparCampo = true;
            this.st_fechamento.ST_NotNull = false;
            this.st_fechamento.TabIndex = 8;
            this.st_fechamento.Text = "Fechamento";
            this.st_fechamento.UseVisualStyleBackColor = true;
            this.st_fechamento.Vl_False = "";
            this.st_fechamento.Vl_True = "";
            // 
            // st_abertura
            // 
            this.st_abertura.AutoSize = true;
            this.st_abertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_abertura.Location = new System.Drawing.Point(480, 5);
            this.st_abertura.Name = "st_abertura";
            this.st_abertura.NM_Alias = "";
            this.st_abertura.NM_Campo = "";
            this.st_abertura.NM_Param = "";
            this.st_abertura.Size = new System.Drawing.Size(74, 17);
            this.st_abertura.ST_Gravar = false;
            this.st_abertura.ST_LimparCampo = true;
            this.st_abertura.ST_NotNull = false;
            this.st_abertura.TabIndex = 7;
            this.st_abertura.Text = "Abertura";
            this.st_abertura.UseVisualStyleBackColor = true;
            this.st_abertura.Vl_False = "";
            this.st_abertura.Vl_True = "";
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(401, 3);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(73, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Data Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Data Inicial";
            // 
            // bb_bico
            // 
            this.bb_bico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_bico.Image = ((System.Drawing.Image)(resources.GetObject("bb_bico.Image")));
            this.bb_bico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bico.Location = new System.Drawing.Point(133, 29);
            this.bb_bico.Name = "bb_bico";
            this.bb_bico.Size = new System.Drawing.Size(28, 19);
            this.bb_bico.TabIndex = 2;
            this.bb_bico.UseVisualStyleBackColor = false;
            this.bb_bico.Click += new System.EventHandler(this.bb_bico_Click);
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(401, 29);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(73, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bico:";
            // 
            // id_bico
            // 
            this.id_bico.BackColor = System.Drawing.SystemColors.Window;
            this.id_bico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_bico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_bico.Location = new System.Drawing.Point(89, 29);
            this.id_bico.Name = "id_bico";
            this.id_bico.NM_Alias = "";
            this.id_bico.NM_Campo = "id_bico";
            this.id_bico.NM_CampoBusca = "id_bico";
            this.id_bico.NM_Param = "@P_ID_BOMBA";
            this.id_bico.QTD_Zero = 0;
            this.id_bico.Size = new System.Drawing.Size(44, 20);
            this.id_bico.ST_AutoInc = false;
            this.id_bico.ST_DisableAuto = false;
            this.id_bico.ST_Float = false;
            this.id_bico.ST_Gravar = false;
            this.id_bico.ST_Int = true;
            this.id_bico.ST_LimpaCampo = true;
            this.id_bico.ST_NotNull = false;
            this.id_bico.ST_PrimaryKey = false;
            this.id_bico.TabIndex = 1;
            this.id_bico.TextOld = null;
            this.id_bico.Leave += new System.EventHandler(this.id_bico_Leave);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.gEncerrante);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 68);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(955, 437);
            this.panelDados1.TabIndex = 0;
            // 
            // gEncerrante
            // 
            this.gEncerrante.AllowUserToAddRows = false;
            this.gEncerrante.AllowUserToDeleteRows = false;
            this.gEncerrante.AllowUserToOrderColumns = true;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEncerrante.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.gEncerrante.AutoGenerateColumns = false;
            this.gEncerrante.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEncerrante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEncerrante.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEncerrante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.gEncerrante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEncerrante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idencerrantestrDataGridViewTextBoxColumn,
            this.idbicostrDataGridViewTextBoxColumn,
            this.Labelbico,
            this.dtencerrantestrDataGridViewTextBoxColumn,
            this.tipoencerranteDataGridViewTextBoxColumn,
            this.qtdencerranteDataGridViewTextBoxColumn,
            this.Cd_empresa,
            this.Nm_empresa,
            this.Cd_produto,
            this.Ds_produto});
            this.gEncerrante.DataSource = this.bsEncerrante;
            this.gEncerrante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEncerrante.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEncerrante.Location = new System.Drawing.Point(0, 0);
            this.gEncerrante.Name = "gEncerrante";
            this.gEncerrante.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEncerrante.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.gEncerrante.RowHeadersWidth = 23;
            this.gEncerrante.Size = new System.Drawing.Size(951, 408);
            this.gEncerrante.TabIndex = 0;
            this.gEncerrante.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEncerrante_ColumnHeaderMouseClick);
            // 
            // idencerrantestrDataGridViewTextBoxColumn
            // 
            this.idencerrantestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idencerrantestrDataGridViewTextBoxColumn.DataPropertyName = "Id_encerrantestr";
            this.idencerrantestrDataGridViewTextBoxColumn.HeaderText = "Id. Encerrante";
            this.idencerrantestrDataGridViewTextBoxColumn.Name = "idencerrantestrDataGridViewTextBoxColumn";
            this.idencerrantestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idencerrantestrDataGridViewTextBoxColumn.Width = 99;
            // 
            // idbicostrDataGridViewTextBoxColumn
            // 
            this.idbicostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idbicostrDataGridViewTextBoxColumn.DataPropertyName = "Id_bicostr";
            this.idbicostrDataGridViewTextBoxColumn.HeaderText = "Id. Bico";
            this.idbicostrDataGridViewTextBoxColumn.Name = "idbicostrDataGridViewTextBoxColumn";
            this.idbicostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idbicostrDataGridViewTextBoxColumn.Width = 68;
            // 
            // Labelbico
            // 
            this.Labelbico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Labelbico.DataPropertyName = "Labelbico";
            this.Labelbico.HeaderText = "Label Bico";
            this.Labelbico.Name = "Labelbico";
            this.Labelbico.ReadOnly = true;
            this.Labelbico.Width = 82;
            // 
            // dtencerrantestrDataGridViewTextBoxColumn
            // 
            this.dtencerrantestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtencerrantestrDataGridViewTextBoxColumn.DataPropertyName = "Dt_encerrante";
            this.dtencerrantestrDataGridViewTextBoxColumn.HeaderText = "Dt. Encerrante";
            this.dtencerrantestrDataGridViewTextBoxColumn.Name = "dtencerrantestrDataGridViewTextBoxColumn";
            this.dtencerrantestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtencerrantestrDataGridViewTextBoxColumn.Width = 101;
            // 
            // tipoencerranteDataGridViewTextBoxColumn
            // 
            this.tipoencerranteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoencerranteDataGridViewTextBoxColumn.DataPropertyName = "Tipo_encerrante";
            this.tipoencerranteDataGridViewTextBoxColumn.HeaderText = "Tipo Lançamento";
            this.tipoencerranteDataGridViewTextBoxColumn.Name = "tipoencerranteDataGridViewTextBoxColumn";
            this.tipoencerranteDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoencerranteDataGridViewTextBoxColumn.Width = 106;
            // 
            // qtdencerranteDataGridViewTextBoxColumn
            // 
            this.qtdencerranteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdencerranteDataGridViewTextBoxColumn.DataPropertyName = "Qtd_encerrante";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "N3";
            dataGridViewCellStyle19.NullValue = "0";
            this.qtdencerranteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.qtdencerranteDataGridViewTextBoxColumn.HeaderText = "Qtd. Encerrante";
            this.qtdencerranteDataGridViewTextBoxColumn.Name = "qtdencerranteDataGridViewTextBoxColumn";
            this.qtdencerranteDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdencerranteDataGridViewTextBoxColumn.Width = 98;
            // 
            // Cd_empresa
            // 
            this.Cd_empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_empresa.DataPropertyName = "Cd_empresa";
            this.Cd_empresa.HeaderText = "Cd. Empresa";
            this.Cd_empresa.Name = "Cd_empresa";
            this.Cd_empresa.ReadOnly = true;
            this.Cd_empresa.Width = 85;
            // 
            // Nm_empresa
            // 
            this.Nm_empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_empresa.DataPropertyName = "Nm_empresa";
            this.Nm_empresa.HeaderText = "Empresa";
            this.Nm_empresa.Name = "Nm_empresa";
            this.Nm_empresa.ReadOnly = true;
            this.Nm_empresa.Width = 73;
            // 
            // Cd_produto
            // 
            this.Cd_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_produto.DataPropertyName = "Cd_produto";
            this.Cd_produto.HeaderText = "Cd. Combustivel";
            this.Cd_produto.Name = "Cd_produto";
            this.Cd_produto.ReadOnly = true;
            this.Cd_produto.Width = 99;
            // 
            // Ds_produto
            // 
            this.Ds_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_produto.DataPropertyName = "Ds_produto";
            this.Ds_produto.HeaderText = "Combustivel";
            this.Ds_produto.Name = "Ds_produto";
            this.Ds_produto.ReadOnly = true;
            this.Ds_produto.Width = 89;
            // 
            // bsEncerrante
            // 
            this.bsEncerrante.DataSource = typeof(CamadaDados.PostoCombustivel.TList_EncerranteBico);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsEncerrante;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 408);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(951, 25);
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
            // bb_combustivel
            // 
            this.bb_combustivel.BackColor = System.Drawing.SystemColors.Control;
            this.bb_combustivel.Image = ((System.Drawing.Image)(resources.GetObject("bb_combustivel.Image")));
            this.bb_combustivel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_combustivel.Location = new System.Drawing.Point(303, 4);
            this.bb_combustivel.Name = "bb_combustivel";
            this.bb_combustivel.Size = new System.Drawing.Size(28, 19);
            this.bb_combustivel.TabIndex = 4;
            this.bb_combustivel.UseVisualStyleBackColor = false;
            this.bb_combustivel.Click += new System.EventHandler(this.bb_combustivel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Combustivel:";
            // 
            // cd_combustivel
            // 
            this.cd_combustivel.BackColor = System.Drawing.SystemColors.Window;
            this.cd_combustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_combustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_combustivel.Location = new System.Drawing.Point(240, 4);
            this.cd_combustivel.Name = "cd_combustivel";
            this.cd_combustivel.NM_Alias = "";
            this.cd_combustivel.NM_Campo = "cd_produto";
            this.cd_combustivel.NM_CampoBusca = "cd_produto";
            this.cd_combustivel.NM_Param = "@P_ID_BOMBA";
            this.cd_combustivel.QTD_Zero = 0;
            this.cd_combustivel.Size = new System.Drawing.Size(62, 20);
            this.cd_combustivel.ST_AutoInc = false;
            this.cd_combustivel.ST_DisableAuto = false;
            this.cd_combustivel.ST_Float = false;
            this.cd_combustivel.ST_Gravar = false;
            this.cd_combustivel.ST_Int = true;
            this.cd_combustivel.ST_LimpaCampo = true;
            this.cd_combustivel.ST_NotNull = false;
            this.cd_combustivel.ST_PrimaryKey = false;
            this.cd_combustivel.TabIndex = 3;
            this.cd_combustivel.TextOld = null;
            this.cd_combustivel.Leave += new System.EventHandler(this.cd_combustivel_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Id. Encerrante:";
            // 
            // id_encerrante
            // 
            this.id_encerrante.BackColor = System.Drawing.SystemColors.Window;
            this.id_encerrante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_encerrante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_encerrante.Location = new System.Drawing.Point(89, 3);
            this.id_encerrante.Name = "id_encerrante";
            this.id_encerrante.NM_Alias = "";
            this.id_encerrante.NM_Campo = "";
            this.id_encerrante.NM_CampoBusca = "";
            this.id_encerrante.NM_Param = "";
            this.id_encerrante.QTD_Zero = 0;
            this.id_encerrante.Size = new System.Drawing.Size(72, 20);
            this.id_encerrante.ST_AutoInc = false;
            this.id_encerrante.ST_DisableAuto = false;
            this.id_encerrante.ST_Float = false;
            this.id_encerrante.ST_Gravar = false;
            this.id_encerrante.ST_Int = true;
            this.id_encerrante.ST_LimpaCampo = true;
            this.id_encerrante.ST_NotNull = false;
            this.id_encerrante.ST_PrimaryKey = false;
            this.id_encerrante.TabIndex = 0;
            this.id_encerrante.TextOld = null;
            // 
            // TFLanEncerranteBico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 553);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFLanEncerranteBico";
            this.ShowInTaskbar = false;
            this.Text = "Leitura Encerrante dos Bicos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanEncerranteBico_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanEncerranteBico_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanEncerranteBico_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEncerrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEncerrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gEncerrante;
        private System.Windows.Forms.BindingSource bsEncerrante;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Button bb_bico;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_bico;
        private Componentes.CheckBoxDefault st_intervencao;
        private Componentes.CheckBoxDefault st_fechamento;
        private Componentes.CheckBoxDefault st_abertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn idencerrantestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbicostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labelbico;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtencerrantestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoencerranteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdencerranteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_produto;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.Button bb_combustivel;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_combustivel;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_encerrante;
    }
}