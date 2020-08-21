namespace PostoCombustivel
{
    partial class TFLanIntervencaoTecnica
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanIntervencaoTecnica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.pPeriodo = new Componentes.PanelDados(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditData(this.components);
            this.ds_motivo = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.nm_tecnico = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nr_intervencao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.bb_bomba = new System.Windows.Forms.Button();
            this.bb_cliforintervencao = new System.Windows.Forms.Button();
            this.cd_cliforintervencao = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.id_bomba = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.id_intervencao = new Componentes.EditDefault(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idintervencaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrintervencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtintervencaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforintervencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmotivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtecnicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpftecnicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsIntervencao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.pPeriodo.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(37, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(51, 13);
            label3.TabIndex = 79;
            label3.Text = "Empresa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(225, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 13);
            label4.TabIndex = 82;
            label4.Text = "Empresa Intervenção:";
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
            this.barraMenu.Size = new System.Drawing.Size(980, 43);
            this.barraMenu.TabIndex = 3;
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
            this.BB_Novo.Visible = false;
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
            this.BB_Fechar.AutoSize = false;
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(50, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(980, 552);
            this.tlpCentral.TabIndex = 4;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.radioGroup1);
            this.pFiltro.Controls.Add(this.ds_motivo);
            this.pFiltro.Controls.Add(this.label7);
            this.pFiltro.Controls.Add(this.nm_tecnico);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.nr_intervencao);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.bb_bomba);
            this.pFiltro.Controls.Add(this.bb_cliforintervencao);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.cd_cliforintervencao);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.id_bomba);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.id_intervencao);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.Size = new System.Drawing.Size(970, 107);
            this.pFiltro.TabIndex = 0;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.pPeriodo);
            this.radioGroup1.Location = new System.Drawing.Point(468, 3);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Size = new System.Drawing.Size(116, 98);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 10;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Periodo";
            // 
            // pPeriodo
            // 
            this.pPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pPeriodo.Controls.Add(this.dt_ini);
            this.pPeriodo.Controls.Add(this.label9);
            this.pPeriodo.Controls.Add(this.label8);
            this.pPeriodo.Controls.Add(this.dt_fin);
            this.pPeriodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPeriodo.Location = new System.Drawing.Point(3, 16);
            this.pPeriodo.Name = "pPeriodo";
            this.pPeriodo.Size = new System.Drawing.Size(110, 79);
            this.pPeriodo.TabIndex = 0;
            // 
            // dt_ini
            // 
            this.dt_ini.Location = new System.Drawing.Point(3, 16);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.Size = new System.Drawing.Size(100, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Data Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Data Inicial";
            // 
            // dt_fin
            // 
            this.dt_fin.Location = new System.Drawing.Point(3, 54);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.Size = new System.Drawing.Size(100, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 1;
            // 
            // ds_motivo
            // 
            this.ds_motivo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivo.Location = new System.Drawing.Point(94, 81);
            this.ds_motivo.Name = "ds_motivo";
            this.ds_motivo.QTD_Zero = 0;
            this.ds_motivo.Size = new System.Drawing.Size(368, 20);
            this.ds_motivo.ST_AutoInc = false;
            this.ds_motivo.ST_DisableAuto = false;
            this.ds_motivo.ST_Float = false;
            this.ds_motivo.ST_Gravar = false;
            this.ds_motivo.ST_Int = false;
            this.ds_motivo.ST_LimpaCampo = true;
            this.ds_motivo.ST_NotNull = false;
            this.ds_motivo.ST_PrimaryKey = false;
            this.ds_motivo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Motivo:";
            // 
            // nm_tecnico
            // 
            this.nm_tecnico.BackColor = System.Drawing.SystemColors.Window;
            this.nm_tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_tecnico.Location = new System.Drawing.Point(94, 55);
            this.nm_tecnico.Name = "nm_tecnico";
            this.nm_tecnico.QTD_Zero = 0;
            this.nm_tecnico.Size = new System.Drawing.Size(368, 20);
            this.nm_tecnico.ST_AutoInc = false;
            this.nm_tecnico.ST_DisableAuto = false;
            this.nm_tecnico.ST_Float = false;
            this.nm_tecnico.ST_Gravar = false;
            this.nm_tecnico.ST_Int = false;
            this.nm_tecnico.ST_LimpaCampo = true;
            this.nm_tecnico.ST_NotNull = false;
            this.nm_tecnico.ST_PrimaryKey = false;
            this.nm_tecnico.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "Tecnico:";
            // 
            // nr_intervencao
            // 
            this.nr_intervencao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_intervencao.Location = new System.Drawing.Point(374, 3);
            this.nr_intervencao.Name = "nr_intervencao";
            this.nr_intervencao.QTD_Zero = 0;
            this.nr_intervencao.Size = new System.Drawing.Size(88, 20);
            this.nr_intervencao.ST_AutoInc = false;
            this.nr_intervencao.ST_DisableAuto = false;
            this.nr_intervencao.ST_Float = false;
            this.nr_intervencao.ST_Gravar = false;
            this.nr_intervencao.ST_Int = false;
            this.nr_intervencao.ST_LimpaCampo = true;
            this.nr_intervencao.ST_NotNull = false;
            this.nr_intervencao.ST_PrimaryKey = false;
            this.nr_intervencao.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Nº Intervenção:";
            // 
            // bb_bomba
            // 
            this.bb_bomba.BackColor = System.Drawing.SystemColors.Control;
            this.bb_bomba.Image = ((System.Drawing.Image)(resources.GetObject("bb_bomba.Image")));
            this.bb_bomba.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bomba.Location = new System.Drawing.Point(252, 3);
            this.bb_bomba.Name = "bb_bomba";
            this.bb_bomba.Size = new System.Drawing.Size(28, 19);
            this.bb_bomba.TabIndex = 2;
            this.bb_bomba.UseVisualStyleBackColor = false;
            this.bb_bomba.Click += new System.EventHandler(this.bb_bomba_Click);
            // 
            // bb_cliforintervencao
            // 
            this.bb_cliforintervencao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cliforintervencao.Image = ((System.Drawing.Image)(resources.GetObject("bb_cliforintervencao.Image")));
            this.bb_cliforintervencao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cliforintervencao.Location = new System.Drawing.Point(434, 29);
            this.bb_cliforintervencao.Name = "bb_cliforintervencao";
            this.bb_cliforintervencao.Size = new System.Drawing.Size(28, 19);
            this.bb_cliforintervencao.TabIndex = 7;
            this.bb_cliforintervencao.UseVisualStyleBackColor = false;
            this.bb_cliforintervencao.Click += new System.EventHandler(this.bb_cliforintervencao_Click);
            // 
            // cd_cliforintervencao
            // 
            this.cd_cliforintervencao.BackColor = System.Drawing.Color.White;
            this.cd_cliforintervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforintervencao.Location = new System.Drawing.Point(342, 29);
            this.cd_cliforintervencao.Name = "cd_cliforintervencao";
            this.cd_cliforintervencao.NM_Campo = "cd_clifor";
            this.cd_cliforintervencao.NM_CampoBusca = "cd_clifor";
            this.cd_cliforintervencao.NM_Param = "@P_CD_EMPRESA";
            this.cd_cliforintervencao.QTD_Zero = 0;
            this.cd_cliforintervencao.Size = new System.Drawing.Size(91, 20);
            this.cd_cliforintervencao.ST_AutoInc = false;
            this.cd_cliforintervencao.ST_DisableAuto = false;
            this.cd_cliforintervencao.ST_Float = false;
            this.cd_cliforintervencao.ST_Gravar = true;
            this.cd_cliforintervencao.ST_Int = true;
            this.cd_cliforintervencao.ST_LimpaCampo = true;
            this.cd_cliforintervencao.ST_NotNull = true;
            this.cd_cliforintervencao.ST_PrimaryKey = false;
            this.cd_cliforintervencao.TabIndex = 6;
            this.cd_cliforintervencao.Leave += new System.EventHandler(this.cd_cliforintervencao_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(174, 29);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 5;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(94, 29);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(79, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 4;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bomba:";
            // 
            // id_bomba
            // 
            this.id_bomba.BackColor = System.Drawing.SystemColors.Window;
            this.id_bomba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_bomba.Location = new System.Drawing.Point(208, 3);
            this.id_bomba.Name = "id_bomba";
            this.id_bomba.NM_Campo = "id_bomba";
            this.id_bomba.NM_CampoBusca = "id_bomba";
            this.id_bomba.NM_Param = "@P_ID_BOMBA";
            this.id_bomba.QTD_Zero = 0;
            this.id_bomba.Size = new System.Drawing.Size(44, 20);
            this.id_bomba.ST_AutoInc = false;
            this.id_bomba.ST_DisableAuto = false;
            this.id_bomba.ST_Float = false;
            this.id_bomba.ST_Gravar = false;
            this.id_bomba.ST_Int = true;
            this.id_bomba.ST_LimpaCampo = true;
            this.id_bomba.ST_NotNull = false;
            this.id_bomba.ST_PrimaryKey = false;
            this.id_bomba.TabIndex = 1;
            this.id_bomba.Leave += new System.EventHandler(this.id_bomba_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Intervenção:";
            // 
            // id_intervencao
            // 
            this.id_intervencao.BackColor = System.Drawing.SystemColors.Window;
            this.id_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_intervencao.Location = new System.Drawing.Point(94, 3);
            this.id_intervencao.Name = "id_intervencao";
            this.id_intervencao.QTD_Zero = 0;
            this.id_intervencao.Size = new System.Drawing.Size(59, 20);
            this.id_intervencao.ST_AutoInc = false;
            this.id_intervencao.ST_DisableAuto = false;
            this.id_intervencao.ST_Float = false;
            this.id_intervencao.ST_Gravar = false;
            this.id_intervencao.ST_Int = true;
            this.id_intervencao.ST_LimpaCampo = true;
            this.id_intervencao.ST_NotNull = false;
            this.id_intervencao.ST_PrimaryKey = false;
            this.id_intervencao.TabIndex = 0;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.dataGridDefault1);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 120);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(970, 427);
            this.pDados.TabIndex = 1;
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
            this.idintervencaostrDataGridViewTextBoxColumn,
            this.nrintervencaoDataGridViewTextBoxColumn,
            this.dtintervencaostrDataGridViewTextBoxColumn,
            this.nmcliforintervencaoDataGridViewTextBoxColumn,
            this.dsmotivoDataGridViewTextBoxColumn,
            this.nmtecnicoDataGridViewTextBoxColumn,
            this.cpftecnicoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsIntervencao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(966, 398);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // idintervencaostrDataGridViewTextBoxColumn
            // 
            this.idintervencaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idintervencaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_intervencaostr";
            this.idintervencaostrDataGridViewTextBoxColumn.HeaderText = "Id. Intervenção";
            this.idintervencaostrDataGridViewTextBoxColumn.Name = "idintervencaostrDataGridViewTextBoxColumn";
            this.idintervencaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idintervencaostrDataGridViewTextBoxColumn.Width = 96;
            // 
            // nrintervencaoDataGridViewTextBoxColumn
            // 
            this.nrintervencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrintervencaoDataGridViewTextBoxColumn.DataPropertyName = "Nr_intervencao";
            this.nrintervencaoDataGridViewTextBoxColumn.HeaderText = "Nº Intervenção";
            this.nrintervencaoDataGridViewTextBoxColumn.Name = "nrintervencaoDataGridViewTextBoxColumn";
            this.nrintervencaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrintervencaoDataGridViewTextBoxColumn.Width = 96;
            // 
            // dtintervencaostrDataGridViewTextBoxColumn
            // 
            this.dtintervencaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtintervencaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_intervencaostr";
            this.dtintervencaostrDataGridViewTextBoxColumn.HeaderText = "Dt. Intervenção";
            this.dtintervencaostrDataGridViewTextBoxColumn.Name = "dtintervencaostrDataGridViewTextBoxColumn";
            this.dtintervencaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtintervencaostrDataGridViewTextBoxColumn.Width = 97;
            // 
            // nmcliforintervencaoDataGridViewTextBoxColumn
            // 
            this.nmcliforintervencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforintervencaoDataGridViewTextBoxColumn.DataPropertyName = "Nm_cliforintervencao";
            this.nmcliforintervencaoDataGridViewTextBoxColumn.HeaderText = "Empresa Intervenção";
            this.nmcliforintervencaoDataGridViewTextBoxColumn.Name = "nmcliforintervencaoDataGridViewTextBoxColumn";
            this.nmcliforintervencaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforintervencaoDataGridViewTextBoxColumn.Width = 122;
            // 
            // dsmotivoDataGridViewTextBoxColumn
            // 
            this.dsmotivoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmotivoDataGridViewTextBoxColumn.DataPropertyName = "Ds_motivo";
            this.dsmotivoDataGridViewTextBoxColumn.HeaderText = "Motivo";
            this.dsmotivoDataGridViewTextBoxColumn.Name = "dsmotivoDataGridViewTextBoxColumn";
            this.dsmotivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmotivoDataGridViewTextBoxColumn.Width = 64;
            // 
            // nmtecnicoDataGridViewTextBoxColumn
            // 
            this.nmtecnicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtecnicoDataGridViewTextBoxColumn.DataPropertyName = "Nm_tecnico";
            this.nmtecnicoDataGridViewTextBoxColumn.HeaderText = "Nome Tecnico";
            this.nmtecnicoDataGridViewTextBoxColumn.Name = "nmtecnicoDataGridViewTextBoxColumn";
            this.nmtecnicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmtecnicoDataGridViewTextBoxColumn.Width = 94;
            // 
            // cpftecnicoDataGridViewTextBoxColumn
            // 
            this.cpftecnicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cpftecnicoDataGridViewTextBoxColumn.DataPropertyName = "Cpf_tecnico";
            this.cpftecnicoDataGridViewTextBoxColumn.HeaderText = "CPF Tecnico";
            this.cpftecnicoDataGridViewTextBoxColumn.Name = "cpftecnicoDataGridViewTextBoxColumn";
            this.cpftecnicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cpftecnicoDataGridViewTextBoxColumn.Width = 87;
            // 
            // bsIntervencao
            // 
            this.bsIntervencao.DataSource = typeof(CamadaDados.PostoCombustivel.TList_IntervencaoTecnica);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsIntervencao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 398);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(966, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // TFLanIntervencaoTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 595);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFLanIntervencaoTecnica";
            this.ShowInTaskbar = false;
            this.Text = "Controle Intervenção Tecnica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanIntervencaoTecnica_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanIntervencaoTecnica_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanIntervencaoTecnica_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.pPeriodo.ResumeLayout(false);
            this.pPeriodo.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).EndInit();
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
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pDados;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsIntervencao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idintervencaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrintervencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtintervencaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforintervencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmotivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtecnicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpftecnicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_intervencao;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_bomba;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_bomba;
        private System.Windows.Forms.Button bb_cliforintervencao;
        private Componentes.EditDefault cd_cliforintervencao;
        private Componentes.EditDefault nr_intervencao;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nm_tecnico;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_motivo;
        private System.Windows.Forms.Label label7;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados pPeriodo;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private Componentes.EditData dt_fin;
    }
}