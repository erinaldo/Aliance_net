namespace PostoCombustivel
{
    partial class TFIntervencaoTecnica
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFIntervencaoTecnica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.nr_cnpjintervencao = new Componentes.EditDefault(this.components);
            this.bsIntervencao = new System.Windows.Forms.BindingSource(this.components);
            this.ds_motivo = new Componentes.EditDefault(this.components);
            this.dt_intervencao = new Componentes.EditData(this.components);
            this.nr_intervencao = new Componentes.EditDefault(this.components);
            this.cpftecnico = new Componentes.EditMask(this.components);
            this.nm_tecnico = new Componentes.EditDefault(this.components);
            this.nm_cliforintervencao = new Componentes.EditDefault(this.components);
            this.bb_cliforintervencao = new System.Windows.Forms.Button();
            this.cd_cliforintervencao = new Componentes.EditDefault(this.components);
            this.bb_bomba = new System.Windows.Forms.Button();
            this.id_bomba = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDetalhe = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.enderecofisicobicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_encerrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBico = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pEncerrante = new Componentes.PanelDados(this.components);
            this.bb_avancar = new System.Windows.Forms.Button();
            this.bb_voltar = new System.Windows.Forms.Button();
            this.encerrante = new Componentes.EditFloat(this.components);
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.tlpDetalhe.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pEncerrante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encerrante)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(34, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 13);
            label2.TabIndex = 80;
            label2.Text = "Empresa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(568, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(43, 13);
            label1.TabIndex = 84;
            label1.Text = "Bomba:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(21, 35);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 13);
            label3.TabIndex = 87;
            label3.Text = "Fornecedor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(36, 60);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 13);
            label4.TabIndex = 90;
            label4.Text = "Tecnico:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(526, 60);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(30, 13);
            label5.TabIndex = 91;
            label5.Text = "CPF:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(3, 86);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(82, 13);
            label6.TabIndex = 94;
            label6.Text = "Nº Intervenção:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(285, 86);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(93, 13);
            label7.TabIndex = 95;
            label7.Text = "Data Intervenção:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(43, 112);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(42, 13);
            label8.TabIndex = 98;
            label8.Text = "Motivo:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(37, 45);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(137, 20);
            label9.TabIndex = 96;
            label9.Text = "Qtd. Encerrante";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(713, 43);
            this.barraMenu.TabIndex = 15;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.nr_cnpjintervencao);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.ds_motivo);
            this.pDados.Controls.Add(this.dt_intervencao);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.nr_intervencao);
            this.pDados.Controls.Add(this.cpftecnico);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.nm_tecnico);
            this.pDados.Controls.Add(this.nm_cliforintervencao);
            this.pDados.Controls.Add(this.bb_cliforintervencao);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.cd_cliforintervencao);
            this.pDados.Controls.Add(this.bb_bomba);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.id_bomba);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 5);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(703, 138);
            this.pDados.TabIndex = 16;
            // 
            // nr_cnpjintervencao
            // 
            this.nr_cnpjintervencao.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cnpjintervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cnpjintervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nr_cnpjintervencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cnpjintervencao.Enabled = false;
            this.nr_cnpjintervencao.Location = new System.Drawing.Point(522, 31);
            this.nr_cnpjintervencao.Name = "nr_cnpjintervencao";
            this.nr_cnpjintervencao.NM_Campo = "nr_cgc";
            this.nr_cnpjintervencao.NM_CampoBusca = "nr_cgc";
            this.nr_cnpjintervencao.NM_Param = "@P_NM_CLIFOR";
            this.nr_cnpjintervencao.QTD_Zero = 0;
            this.nr_cnpjintervencao.Size = new System.Drawing.Size(172, 20);
            this.nr_cnpjintervencao.ST_AutoInc = false;
            this.nr_cnpjintervencao.ST_DisableAuto = false;
            this.nr_cnpjintervencao.ST_Float = false;
            this.nr_cnpjintervencao.ST_Gravar = false;
            this.nr_cnpjintervencao.ST_Int = false;
            this.nr_cnpjintervencao.ST_LimpaCampo = true;
            this.nr_cnpjintervencao.ST_NotNull = false;
            this.nr_cnpjintervencao.ST_PrimaryKey = false;
            this.nr_cnpjintervencao.TabIndex = 99;
            // 
            // bsIntervencao
            // 
            this.bsIntervencao.DataSource = typeof(CamadaDados.PostoCombustivel.TList_IntervencaoTecnica);
            // 
            // ds_motivo
            // 
            this.ds_motivo.BackColor = System.Drawing.Color.White;
            this.ds_motivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Ds_motivo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motivo.Location = new System.Drawing.Point(91, 109);
            this.ds_motivo.Name = "ds_motivo";
            this.ds_motivo.NM_Param = "@P_CD_EMPRESA";
            this.ds_motivo.QTD_Zero = 0;
            this.ds_motivo.Size = new System.Drawing.Size(603, 20);
            this.ds_motivo.ST_AutoInc = false;
            this.ds_motivo.ST_DisableAuto = false;
            this.ds_motivo.ST_Float = false;
            this.ds_motivo.ST_Gravar = true;
            this.ds_motivo.ST_Int = false;
            this.ds_motivo.ST_LimpaCampo = true;
            this.ds_motivo.ST_NotNull = false;
            this.ds_motivo.ST_PrimaryKey = false;
            this.ds_motivo.TabIndex = 10;
            // 
            // dt_intervencao
            // 
            this.dt_intervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Dt_intervencaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_intervencao.Location = new System.Drawing.Point(384, 83);
            this.dt_intervencao.Mask = "00/00/0000";
            this.dt_intervencao.Name = "dt_intervencao";
            this.dt_intervencao.Size = new System.Drawing.Size(100, 20);
            this.dt_intervencao.ST_Gravar = true;
            this.dt_intervencao.ST_LimpaCampo = true;
            this.dt_intervencao.ST_NotNull = true;
            this.dt_intervencao.ST_PrimaryKey = false;
            this.dt_intervencao.TabIndex = 9;
            // 
            // nr_intervencao
            // 
            this.nr_intervencao.BackColor = System.Drawing.Color.White;
            this.nr_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_intervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nr_intervencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_intervencao.Location = new System.Drawing.Point(91, 83);
            this.nr_intervencao.Name = "nr_intervencao";
            this.nr_intervencao.NM_Param = "@P_CD_EMPRESA";
            this.nr_intervencao.QTD_Zero = 0;
            this.nr_intervencao.Size = new System.Drawing.Size(188, 20);
            this.nr_intervencao.ST_AutoInc = false;
            this.nr_intervencao.ST_DisableAuto = false;
            this.nr_intervencao.ST_Float = false;
            this.nr_intervencao.ST_Gravar = true;
            this.nr_intervencao.ST_Int = false;
            this.nr_intervencao.ST_LimpaCampo = true;
            this.nr_intervencao.ST_NotNull = true;
            this.nr_intervencao.ST_PrimaryKey = false;
            this.nr_intervencao.TabIndex = 8;
            // 
            // cpftecnico
            // 
            this.cpftecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Cpf_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cpftecnico.Location = new System.Drawing.Point(562, 57);
            this.cpftecnico.Mask = "000.000.000-00";
            this.cpftecnico.Name = "cpftecnico";
            this.cpftecnico.Size = new System.Drawing.Size(132, 20);
            this.cpftecnico.ST_Gravar = true;
            this.cpftecnico.ST_LimpaCampo = true;
            this.cpftecnico.ST_NotNull = false;
            this.cpftecnico.ST_PrimaryKey = false;
            this.cpftecnico.TabIndex = 7;
            // 
            // nm_tecnico
            // 
            this.nm_tecnico.BackColor = System.Drawing.Color.White;
            this.nm_tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_tecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nm_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_tecnico.Location = new System.Drawing.Point(91, 57);
            this.nm_tecnico.Name = "nm_tecnico";
            this.nm_tecnico.NM_Param = "@P_CD_EMPRESA";
            this.nm_tecnico.QTD_Zero = 0;
            this.nm_tecnico.Size = new System.Drawing.Size(429, 20);
            this.nm_tecnico.ST_AutoInc = false;
            this.nm_tecnico.ST_DisableAuto = false;
            this.nm_tecnico.ST_Float = false;
            this.nm_tecnico.ST_Gravar = true;
            this.nm_tecnico.ST_Int = false;
            this.nm_tecnico.ST_LimpaCampo = true;
            this.nm_tecnico.ST_NotNull = true;
            this.nm_tecnico.ST_PrimaryKey = false;
            this.nm_tecnico.TabIndex = 6;
            // 
            // nm_cliforintervencao
            // 
            this.nm_cliforintervencao.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforintervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforintervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nm_cliforintervencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_cliforintervencao.Enabled = false;
            this.nm_cliforintervencao.Location = new System.Drawing.Point(214, 31);
            this.nm_cliforintervencao.Name = "nm_cliforintervencao";
            this.nm_cliforintervencao.NM_Campo = "nm_clifor";
            this.nm_cliforintervencao.NM_CampoBusca = "nm_clifor";
            this.nm_cliforintervencao.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforintervencao.QTD_Zero = 0;
            this.nm_cliforintervencao.Size = new System.Drawing.Size(306, 20);
            this.nm_cliforintervencao.ST_AutoInc = false;
            this.nm_cliforintervencao.ST_DisableAuto = false;
            this.nm_cliforintervencao.ST_Float = false;
            this.nm_cliforintervencao.ST_Gravar = false;
            this.nm_cliforintervencao.ST_Int = false;
            this.nm_cliforintervencao.ST_LimpaCampo = true;
            this.nm_cliforintervencao.ST_NotNull = false;
            this.nm_cliforintervencao.ST_PrimaryKey = false;
            this.nm_cliforintervencao.TabIndex = 88;
            // 
            // bb_cliforintervencao
            // 
            this.bb_cliforintervencao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cliforintervencao.Image = ((System.Drawing.Image)(resources.GetObject("bb_cliforintervencao.Image")));
            this.bb_cliforintervencao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cliforintervencao.Location = new System.Drawing.Point(180, 31);
            this.bb_cliforintervencao.Name = "bb_cliforintervencao";
            this.bb_cliforintervencao.Size = new System.Drawing.Size(28, 20);
            this.bb_cliforintervencao.TabIndex = 5;
            this.bb_cliforintervencao.UseVisualStyleBackColor = false;
            this.bb_cliforintervencao.Click += new System.EventHandler(this.bb_cliforintervencao_Click);
            // 
            // cd_cliforintervencao
            // 
            this.cd_cliforintervencao.BackColor = System.Drawing.Color.White;
            this.cd_cliforintervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cliforintervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Cd_cliforintervencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_cliforintervencao.Location = new System.Drawing.Point(91, 32);
            this.cd_cliforintervencao.Name = "cd_cliforintervencao";
            this.cd_cliforintervencao.NM_Campo = "cd_clifor";
            this.cd_cliforintervencao.NM_CampoBusca = "cd_clifor";
            this.cd_cliforintervencao.NM_Param = "@P_CD_EMPRESA";
            this.cd_cliforintervencao.QTD_Zero = 0;
            this.cd_cliforintervencao.Size = new System.Drawing.Size(88, 20);
            this.cd_cliforintervencao.ST_AutoInc = false;
            this.cd_cliforintervencao.ST_DisableAuto = false;
            this.cd_cliforintervencao.ST_Float = false;
            this.cd_cliforintervencao.ST_Gravar = true;
            this.cd_cliforintervencao.ST_Int = true;
            this.cd_cliforintervencao.ST_LimpaCampo = true;
            this.cd_cliforintervencao.ST_NotNull = true;
            this.cd_cliforintervencao.ST_PrimaryKey = false;
            this.cd_cliforintervencao.TabIndex = 4;
            this.cd_cliforintervencao.Leave += new System.EventHandler(this.cd_cliforintervencao_Leave);
            // 
            // bb_bomba
            // 
            this.bb_bomba.BackColor = System.Drawing.SystemColors.Control;
            this.bb_bomba.Image = ((System.Drawing.Image)(resources.GetObject("bb_bomba.Image")));
            this.bb_bomba.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bomba.Location = new System.Drawing.Point(666, 4);
            this.bb_bomba.Name = "bb_bomba";
            this.bb_bomba.Size = new System.Drawing.Size(28, 20);
            this.bb_bomba.TabIndex = 3;
            this.bb_bomba.UseVisualStyleBackColor = false;
            this.bb_bomba.Click += new System.EventHandler(this.bb_bomba_Click);
            // 
            // id_bomba
            // 
            this.id_bomba.BackColor = System.Drawing.Color.White;
            this.id_bomba.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_bomba.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Id_bombastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_bomba.Location = new System.Drawing.Point(617, 5);
            this.id_bomba.Name = "id_bomba";
            this.id_bomba.NM_Campo = "id_bomba";
            this.id_bomba.NM_CampoBusca = "id_bomba";
            this.id_bomba.NM_Param = "@P_CD_EMPRESA";
            this.id_bomba.QTD_Zero = 0;
            this.id_bomba.Size = new System.Drawing.Size(47, 20);
            this.id_bomba.ST_AutoInc = false;
            this.id_bomba.ST_DisableAuto = false;
            this.id_bomba.ST_Float = false;
            this.id_bomba.ST_Gravar = true;
            this.id_bomba.ST_Int = true;
            this.id_bomba.ST_LimpaCampo = true;
            this.id_bomba.ST_NotNull = true;
            this.id_bomba.ST_PrimaryKey = false;
            this.id_bomba.TabIndex = 2;
            this.id_bomba.Leave += new System.EventHandler(this.id_bomba_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(214, 5);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_CLIFOR";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(348, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 81;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(180, 5);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(91, 6);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(88, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.tlpDetalhe, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tlpCentral.Size = new System.Drawing.Size(713, 336);
            this.tlpCentral.TabIndex = 17;
            // 
            // tlpDetalhe
            // 
            this.tlpDetalhe.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpDetalhe.ColumnCount = 2;
            this.tlpDetalhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tlpDetalhe.Controls.Add(this.pGrid, 0, 0);
            this.tlpDetalhe.Controls.Add(this.pEncerrante, 1, 0);
            this.tlpDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalhe.Location = new System.Drawing.Point(5, 151);
            this.tlpDetalhe.Name = "tlpDetalhe";
            this.tlpDetalhe.RowCount = 1;
            this.tlpDetalhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhe.Size = new System.Drawing.Size(703, 180);
            this.tlpDetalhe.TabIndex = 17;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.dataGridDefault1);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 5);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(472, 170);
            this.pGrid.TabIndex = 0;
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
            this.enderecofisicobicoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.Qtd_encerrante});
            this.dataGridDefault1.DataSource = this.bsBico;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(468, 141);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // enderecofisicobicoDataGridViewTextBoxColumn
            // 
            this.enderecofisicobicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enderecofisicobicoDataGridViewTextBoxColumn.DataPropertyName = "Enderecofisicobico";
            this.enderecofisicobicoDataGridViewTextBoxColumn.HeaderText = "Id. Bico";
            this.enderecofisicobicoDataGridViewTextBoxColumn.Name = "enderecofisicobicoDataGridViewTextBoxColumn";
            this.enderecofisicobicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.enderecofisicobicoDataGridViewTextBoxColumn.Width = 68;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 89;
            // 
            // Qtd_encerrante
            // 
            this.Qtd_encerrante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_encerrante.DataPropertyName = "Qtd_encerrante";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.Qtd_encerrante.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qtd_encerrante.HeaderText = "Qtd. Encerrante";
            this.Qtd_encerrante.Name = "Qtd_encerrante";
            this.Qtd_encerrante.ReadOnly = true;
            this.Qtd_encerrante.Width = 98;
            // 
            // bsBico
            // 
            this.bsBico.DataMember = "lBico";
            this.bsBico.DataSource = this.bsIntervencao;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsBico;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 141);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(468, 25);
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
            // pEncerrante
            // 
            this.pEncerrante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pEncerrante.Controls.Add(this.bb_avancar);
            this.pEncerrante.Controls.Add(this.bb_voltar);
            this.pEncerrante.Controls.Add(this.encerrante);
            this.pEncerrante.Controls.Add(label9);
            this.pEncerrante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEncerrante.Location = new System.Drawing.Point(485, 5);
            this.pEncerrante.Name = "pEncerrante";
            this.pEncerrante.Size = new System.Drawing.Size(213, 170);
            this.pEncerrante.TabIndex = 1;
            // 
            // bb_avancar
            // 
            this.bb_avancar.Location = new System.Drawing.Point(108, 100);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(75, 23);
            this.bb_avancar.TabIndex = 99;
            this.bb_avancar.Text = "Avançar>>";
            this.bb_avancar.UseVisualStyleBackColor = true;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // bb_voltar
            // 
            this.bb_voltar.Location = new System.Drawing.Point(27, 100);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(75, 23);
            this.bb_voltar.TabIndex = 98;
            this.bb_voltar.Text = "<<Voltar";
            this.bb_voltar.UseVisualStyleBackColor = true;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // encerrante
            // 
            this.encerrante.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBico, "Qtd_encerrante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.encerrante.DecimalPlaces = 3;
            this.encerrante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerrante.Location = new System.Drawing.Point(41, 68);
            this.encerrante.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerrante.Name = "encerrante";
            this.encerrante.Size = new System.Drawing.Size(133, 26);
            this.encerrante.ST_AutoInc = false;
            this.encerrante.ST_DisableAuto = false;
            this.encerrante.ST_Gravar = false;
            this.encerrante.ST_LimparCampo = true;
            this.encerrante.ST_NotNull = false;
            this.encerrante.ST_PrimaryKey = false;
            this.encerrante.TabIndex = 97;
            this.encerrante.ThousandsSeparator = true;
            // 
            // TFIntervencaoTecnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 379);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFIntervencaoTecnica";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Intervenção Tecnica";
            this.Load += new System.EventHandler(this.TFIntervencaoTecnica_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFIntervencaoTecnica_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFIntervencaoTecnica_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.tlpDetalhe.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pEncerrante.ResumeLayout(false);
            this.pEncerrante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.encerrante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_tecnico;
        private Componentes.EditDefault nm_cliforintervencao;
        private System.Windows.Forms.Button bb_cliforintervencao;
        private Componentes.EditDefault cd_cliforintervencao;
        private System.Windows.Forms.Button bb_bomba;
        private Componentes.EditDefault id_bomba;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault ds_motivo;
        private Componentes.EditData dt_intervencao;
        private Componentes.EditDefault nr_intervencao;
        private Componentes.EditMask cpftecnico;
        private System.Windows.Forms.BindingSource bsIntervencao;
        private Componentes.EditDefault nr_cnpjintervencao;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.TableLayoutPanel tlpDetalhe;
        private Componentes.PanelDados pGrid;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsBico;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecofisicobicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_encerrante;
        private Componentes.PanelDados pEncerrante;
        private Componentes.EditFloat encerrante;
        private System.Windows.Forms.Button bb_avancar;
        private System.Windows.Forms.Button bb_voltar;
    }
}