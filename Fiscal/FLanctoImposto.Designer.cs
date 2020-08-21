namespace Fiscal
{
    partial class TFLanctoImposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanctoImposto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.tp_origemIPI = new Componentes.ComboBoxDefault(this.components);
            this.bsLanctoImposto = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ds_ajusteIPI = new Componentes.EditDefault(this.components);
            this.bb_ajusteIPI = new System.Windows.Forms.Button();
            this.cd_ajusteIPI = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_ajuste = new Componentes.EditDefault(this.components);
            this.bb_ajuste = new System.Windows.Forms.Button();
            this.cd_ajuste = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.d_c = new Componentes.EditDefault(this.components);
            this.tp_lancto = new Componentes.ComboBoxDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bb_imposto = new System.Windows.Forms.Button();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdimpostostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsimpostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitocreditoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlotefisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnLanctoImposto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLanctoImposto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnLanctoImposto)).BeginInit();
            this.bnLanctoImposto.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Excluir,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(701, 43);
            this.barraMenu.TabIndex = 16;
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
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(90, 40);
            this.BB_Excluir.Text = " (F5)\r\n Excluir";
            this.BB_Excluir.ToolTipText = "Excluir Fechamento";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.tp_origemIPI);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.ds_ajusteIPI);
            this.pDados.Controls.Add(this.bb_ajusteIPI);
            this.pDados.Controls.Add(this.cd_ajusteIPI);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.ds_ajuste);
            this.pDados.Controls.Add(this.bb_ajuste);
            this.pDados.Controls.Add(this.cd_ajuste);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.d_c);
            this.pDados.Controls.Add(this.tp_lancto);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.vl_lancto);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 220);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(691, 236);
            this.pDados.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(322, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 168;
            this.label10.Text = "Nº Doc. Ajuste IPI:";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Location = new System.Drawing.Point(424, 134);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(100, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 167;
            // 
            // tp_origemIPI
            // 
            this.tp_origemIPI.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLanctoImposto, "Tp_origemIPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_origemIPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_origemIPI.FormattingEnabled = true;
            this.tp_origemIPI.Location = new System.Drawing.Point(102, 134);
            this.tp_origemIPI.Name = "tp_origemIPI";
            this.tp_origemIPI.NM_Alias = "";
            this.tp_origemIPI.NM_Campo = "";
            this.tp_origemIPI.NM_Param = "";
            this.tp_origemIPI.Size = new System.Drawing.Size(214, 21);
            this.tp_origemIPI.ST_Gravar = false;
            this.tp_origemIPI.ST_LimparCampo = true;
            this.tp_origemIPI.ST_NotNull = false;
            this.tp_origemIPI.TabIndex = 165;
            // 
            // bsLanctoImposto
            // 
            this.bsLanctoImposto.DataSource = typeof(CamadaDados.Fiscal.TList_LanctoImposto);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(5, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 166;
            this.label9.Text = "Origem Ajuste IPI:";
            // 
            // ds_ajusteIPI
            // 
            this.ds_ajusteIPI.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ajusteIPI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ajusteIPI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLanctoImposto, "Ds_ajusteIPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ajusteIPI.Enabled = false;
            this.ds_ajusteIPI.Location = new System.Drawing.Point(212, 108);
            this.ds_ajusteIPI.Name = "ds_ajusteIPI";
            this.ds_ajusteIPI.NM_Alias = "";
            this.ds_ajusteIPI.NM_Campo = "ds_ajusteIPI";
            this.ds_ajusteIPI.NM_CampoBusca = "ds_ajusteIPI";
            this.ds_ajusteIPI.NM_Param = "@P_NM_EMPRESA";
            this.ds_ajusteIPI.QTD_Zero = 0;
            this.ds_ajusteIPI.Size = new System.Drawing.Size(470, 20);
            this.ds_ajusteIPI.ST_AutoInc = false;
            this.ds_ajusteIPI.ST_DisableAuto = false;
            this.ds_ajusteIPI.ST_Float = false;
            this.ds_ajusteIPI.ST_Gravar = false;
            this.ds_ajusteIPI.ST_Int = false;
            this.ds_ajusteIPI.ST_LimpaCampo = true;
            this.ds_ajusteIPI.ST_NotNull = false;
            this.ds_ajusteIPI.ST_PrimaryKey = false;
            this.ds_ajusteIPI.TabIndex = 163;
            // 
            // bb_ajusteIPI
            // 
            this.bb_ajusteIPI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_ajusteIPI.Image = ((System.Drawing.Image)(resources.GetObject("bb_ajusteIPI.Image")));
            this.bb_ajusteIPI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ajusteIPI.Location = new System.Drawing.Point(176, 108);
            this.bb_ajusteIPI.Name = "bb_ajusteIPI";
            this.bb_ajusteIPI.Size = new System.Drawing.Size(30, 20);
            this.bb_ajusteIPI.TabIndex = 162;
            this.bb_ajusteIPI.UseVisualStyleBackColor = true;
            this.bb_ajusteIPI.Click += new System.EventHandler(this.bb_ajusteIPI_Click);
            // 
            // cd_ajusteIPI
            // 
            this.cd_ajusteIPI.BackColor = System.Drawing.SystemColors.Window;
            this.cd_ajusteIPI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ajusteIPI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLanctoImposto, "Cd_ajusteIPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ajusteIPI.Location = new System.Drawing.Point(102, 108);
            this.cd_ajusteIPI.Name = "cd_ajusteIPI";
            this.cd_ajusteIPI.NM_Alias = "";
            this.cd_ajusteIPI.NM_Campo = "cd_ajusteIPI";
            this.cd_ajusteIPI.NM_CampoBusca = "cd_ajusteIPI";
            this.cd_ajusteIPI.NM_Param = "@P_CD_EMPRESA";
            this.cd_ajusteIPI.QTD_Zero = 0;
            this.cd_ajusteIPI.Size = new System.Drawing.Size(73, 20);
            this.cd_ajusteIPI.ST_AutoInc = false;
            this.cd_ajusteIPI.ST_DisableAuto = false;
            this.cd_ajusteIPI.ST_Float = false;
            this.cd_ajusteIPI.ST_Gravar = true;
            this.cd_ajusteIPI.ST_Int = false;
            this.cd_ajusteIPI.ST_LimpaCampo = true;
            this.cd_ajusteIPI.ST_NotNull = false;
            this.cd_ajusteIPI.ST_PrimaryKey = false;
            this.cd_ajusteIPI.TabIndex = 161;
            this.cd_ajusteIPI.Leave += new System.EventHandler(this.cd_ajusteIPI_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(27, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 164;
            this.label7.Text = "Ajuste IPI:";
            // 
            // ds_ajuste
            // 
            this.ds_ajuste.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ajuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ajuste.Enabled = false;
            this.ds_ajuste.Location = new System.Drawing.Point(212, 82);
            this.ds_ajuste.Name = "ds_ajuste";
            this.ds_ajuste.NM_Alias = "";
            this.ds_ajuste.NM_Campo = "ds_ajuste";
            this.ds_ajuste.NM_CampoBusca = "ds_ajuste";
            this.ds_ajuste.NM_Param = "@P_NM_EMPRESA";
            this.ds_ajuste.QTD_Zero = 0;
            this.ds_ajuste.Size = new System.Drawing.Size(470, 20);
            this.ds_ajuste.ST_AutoInc = false;
            this.ds_ajuste.ST_DisableAuto = false;
            this.ds_ajuste.ST_Float = false;
            this.ds_ajuste.ST_Gravar = false;
            this.ds_ajuste.ST_Int = false;
            this.ds_ajuste.ST_LimpaCampo = true;
            this.ds_ajuste.ST_NotNull = false;
            this.ds_ajuste.ST_PrimaryKey = false;
            this.ds_ajuste.TabIndex = 159;
            // 
            // bb_ajuste
            // 
            this.bb_ajuste.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_ajuste.Image = ((System.Drawing.Image)(resources.GetObject("bb_ajuste.Image")));
            this.bb_ajuste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ajuste.Location = new System.Drawing.Point(176, 82);
            this.bb_ajuste.Name = "bb_ajuste";
            this.bb_ajuste.Size = new System.Drawing.Size(30, 20);
            this.bb_ajuste.TabIndex = 8;
            this.bb_ajuste.UseVisualStyleBackColor = true;
            this.bb_ajuste.Click += new System.EventHandler(this.bb_ajuste_Click);
            // 
            // cd_ajuste
            // 
            this.cd_ajuste.BackColor = System.Drawing.SystemColors.Window;
            this.cd_ajuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ajuste.Location = new System.Drawing.Point(102, 82);
            this.cd_ajuste.Name = "cd_ajuste";
            this.cd_ajuste.NM_Alias = "";
            this.cd_ajuste.NM_Campo = "cd_ajuste";
            this.cd_ajuste.NM_CampoBusca = "cd_ajuste";
            this.cd_ajuste.NM_Param = "@P_CD_EMPRESA";
            this.cd_ajuste.QTD_Zero = 0;
            this.cd_ajuste.Size = new System.Drawing.Size(73, 20);
            this.cd_ajuste.ST_AutoInc = false;
            this.cd_ajuste.ST_DisableAuto = false;
            this.cd_ajuste.ST_Float = false;
            this.cd_ajuste.ST_Gravar = true;
            this.cd_ajuste.ST_Int = false;
            this.cd_ajuste.ST_LimpaCampo = true;
            this.cd_ajuste.ST_NotNull = false;
            this.cd_ajuste.ST_PrimaryKey = false;
            this.cd_ajuste.TabIndex = 7;
            this.cd_ajuste.Leave += new System.EventHandler(this.cd_ajuste_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 160;
            this.label2.Text = "Ajuste ICMS:";
            // 
            // d_c
            // 
            this.d_c.BackColor = System.Drawing.SystemColors.Window;
            this.d_c.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.d_c.Enabled = false;
            this.d_c.Location = new System.Drawing.Point(322, 56);
            this.d_c.Name = "d_c";
            this.d_c.NM_Alias = "";
            this.d_c.NM_Campo = "";
            this.d_c.NM_CampoBusca = "";
            this.d_c.NM_Param = "";
            this.d_c.QTD_Zero = 0;
            this.d_c.Size = new System.Drawing.Size(100, 20);
            this.d_c.ST_AutoInc = false;
            this.d_c.ST_DisableAuto = false;
            this.d_c.ST_Float = false;
            this.d_c.ST_Gravar = false;
            this.d_c.ST_Int = false;
            this.d_c.ST_LimpaCampo = true;
            this.d_c.ST_NotNull = false;
            this.d_c.ST_PrimaryKey = false;
            this.d_c.TabIndex = 156;
            // 
            // tp_lancto
            // 
            this.tp_lancto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_lancto.FormattingEnabled = true;
            this.tp_lancto.Location = new System.Drawing.Point(102, 55);
            this.tp_lancto.Name = "tp_lancto";
            this.tp_lancto.NM_Alias = "";
            this.tp_lancto.NM_Campo = "";
            this.tp_lancto.NM_Param = "";
            this.tp_lancto.Size = new System.Drawing.Size(214, 21);
            this.tp_lancto.ST_Gravar = false;
            this.tp_lancto.ST_LimparCampo = true;
            this.tp_lancto.ST_NotNull = false;
            this.tp_lancto.TabIndex = 4;
            this.tp_lancto.SelectedIndexChanged += new System.EventHandler(this.tp_lancto_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(27, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 155;
            this.label6.Text = "Lançamento:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.Location = new System.Drawing.Point(102, 161);
            this.ds_observacao.MaxLength = 1024;
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "CD_Empresa";
            this.ds_observacao.NM_CampoBusca = "CD_Empresa";
            this.ds_observacao.NM_Param = "@P_CD_EMPRESA";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(580, 68);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = true;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(28, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Observação:";
            // 
            // vl_lancto
            // 
            this.vl_lancto.DecimalPlaces = 2;
            this.vl_lancto.Location = new System.Drawing.Point(582, 56);
            this.vl_lancto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_lancto.Name = "vl_lancto";
            this.vl_lancto.NM_Alias = "";
            this.vl_lancto.NM_Campo = "";
            this.vl_lancto.NM_Param = "";
            this.vl_lancto.Operador = "";
            this.vl_lancto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_lancto.Size = new System.Drawing.Size(100, 20);
            this.vl_lancto.ST_AutoInc = false;
            this.vl_lancto.ST_DisableAuto = false;
            this.vl_lancto.ST_Gravar = false;
            this.vl_lancto.ST_LimparCampo = true;
            this.vl_lancto.ST_NotNull = true;
            this.vl_lancto.ST_PrimaryKey = false;
            this.vl_lancto.TabIndex = 6;
            this.vl_lancto.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(542, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "Valor:";
            // 
            // dt_lancto
            // 
            this.dt_lancto.Location = new System.Drawing.Point(467, 55);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(69, 20);
            this.dt_lancto.ST_Gravar = false;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = true;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(428, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Data:";
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(212, 29);
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_NM_EMPRESA";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.Size = new System.Drawing.Size(470, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 144;
            // 
            // bb_imposto
            // 
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(176, 29);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 20);
            this.bb_imposto.TabIndex = 3;
            this.bb_imposto.UseVisualStyleBackColor = true;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.Location = new System.Drawing.Point(102, 29);
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_EMPRESA";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.Size = new System.Drawing.Size(73, 20);
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = false;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = false;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = false;
            this.cd_imposto.TabIndex = 2;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 145;
            this.label1.Text = "Imposto:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Location = new System.Drawing.Point(212, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(470, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 140;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(176, 3);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(30, 20);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Location = new System.Drawing.Point(102, 3);
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
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(45, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 141;
            this.label8.Text = "Empresa:";
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.86649F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.13351F));
            this.tlpCentral.Size = new System.Drawing.Size(701, 461);
            this.tlpCentral.TabIndex = 18;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pGrid.Controls.Add(this.dataGridDefault1);
            this.pGrid.Controls.Add(this.bnLanctoImposto);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 5);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(691, 207);
            this.pGrid.TabIndex = 18;
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
            this.cdimpostostrDataGridViewTextBoxColumn,
            this.dsimpostoDataGridViewTextBoxColumn,
            this.dtlanctostrDataGridViewTextBoxColumn,
            this.debitocreditoDataGridViewTextBoxColumn,
            this.vllanctoDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.idlotefisDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsLanctoImposto;
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
            this.dataGridDefault1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDefault1.Size = new System.Drawing.Size(689, 180);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // cdimpostostrDataGridViewTextBoxColumn
            // 
            this.cdimpostostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdimpostostrDataGridViewTextBoxColumn.DataPropertyName = "Cd_impostostr";
            this.cdimpostostrDataGridViewTextBoxColumn.HeaderText = "Cd. Imposto";
            this.cdimpostostrDataGridViewTextBoxColumn.Name = "cdimpostostrDataGridViewTextBoxColumn";
            this.cdimpostostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdimpostostrDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsimpostoDataGridViewTextBoxColumn
            // 
            this.dsimpostoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsimpostoDataGridViewTextBoxColumn.DataPropertyName = "Ds_imposto";
            this.dsimpostoDataGridViewTextBoxColumn.HeaderText = "Imposto";
            this.dsimpostoDataGridViewTextBoxColumn.Name = "dsimpostoDataGridViewTextBoxColumn";
            this.dsimpostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsimpostoDataGridViewTextBoxColumn.Width = 69;
            // 
            // dtlanctostrDataGridViewTextBoxColumn
            // 
            this.dtlanctostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_lanctostr";
            this.dtlanctostrDataGridViewTextBoxColumn.HeaderText = "Dt. Lancto";
            this.dtlanctostrDataGridViewTextBoxColumn.Name = "dtlanctostrDataGridViewTextBoxColumn";
            this.dtlanctostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctostrDataGridViewTextBoxColumn.Width = 82;
            // 
            // debitocreditoDataGridViewTextBoxColumn
            // 
            this.debitocreditoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.debitocreditoDataGridViewTextBoxColumn.DataPropertyName = "Debito_credito";
            this.debitocreditoDataGridViewTextBoxColumn.HeaderText = "Debito/Credito";
            this.debitocreditoDataGridViewTextBoxColumn.Name = "debitocreditoDataGridViewTextBoxColumn";
            this.debitocreditoDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitocreditoDataGridViewTextBoxColumn.Width = 101;
            // 
            // vllanctoDataGridViewTextBoxColumn
            // 
            this.vllanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllanctoDataGridViewTextBoxColumn.DataPropertyName = "Vl_lancto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vllanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vllanctoDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.vllanctoDataGridViewTextBoxColumn.Name = "vllanctoDataGridViewTextBoxColumn";
            this.vllanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllanctoDataGridViewTextBoxColumn.Width = 56;
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
            // idlotefisDataGridViewTextBoxColumn
            // 
            this.idlotefisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idlotefisDataGridViewTextBoxColumn.DataPropertyName = "Id_lotefis";
            this.idlotefisDataGridViewTextBoxColumn.HeaderText = "Lote Fiscal";
            this.idlotefisDataGridViewTextBoxColumn.Name = "idlotefisDataGridViewTextBoxColumn";
            this.idlotefisDataGridViewTextBoxColumn.ReadOnly = true;
            this.idlotefisDataGridViewTextBoxColumn.Width = 83;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            this.dsobservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bnLanctoImposto
            // 
            this.bnLanctoImposto.AddNewItem = null;
            this.bnLanctoImposto.BindingSource = this.bsLanctoImposto;
            this.bnLanctoImposto.CountItem = this.bindingNavigatorCountItem;
            this.bnLanctoImposto.DeleteItem = null;
            this.bnLanctoImposto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnLanctoImposto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnLanctoImposto.Location = new System.Drawing.Point(0, 180);
            this.bnLanctoImposto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnLanctoImposto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnLanctoImposto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnLanctoImposto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnLanctoImposto.Name = "bnLanctoImposto";
            this.bnLanctoImposto.PositionItem = this.bindingNavigatorPositionItem;
            this.bnLanctoImposto.Size = new System.Drawing.Size(689, 25);
            this.bnLanctoImposto.TabIndex = 1;
            this.bnLanctoImposto.Text = "bindingNavigator1";
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
            // TFLanctoImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 504);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanctoImposto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento Ajustes Imposto";
            this.Load += new System.EventHandler(this.TFLanctoImposto_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanctoImposto_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanctoImposto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLanctoImposto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnLanctoImposto)).EndInit();
            this.bnLanctoImposto.ResumeLayout(false);
            this.bnLanctoImposto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat vl_lancto;
        private System.Windows.Forms.Label label4;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Button bb_imposto;
        private Componentes.EditDefault cd_imposto;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bsLanctoImposto;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator bnLanctoImposto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdimpostostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsimpostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitocreditoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stestornoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlotefisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
        private Componentes.EditDefault d_c;
        private Componentes.ComboBoxDefault tp_lancto;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_ajuste;
        private System.Windows.Forms.Button bb_ajuste;
        private Componentes.EditDefault cd_ajuste;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_ajusteIPI;
        private System.Windows.Forms.Button bb_ajusteIPI;
        private Componentes.EditDefault cd_ajusteIPI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault editDefault1;
        private Componentes.ComboBoxDefault tp_origemIPI;
        private System.Windows.Forms.Label label9;
    }
}