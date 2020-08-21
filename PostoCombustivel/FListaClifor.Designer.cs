namespace PostoCombustivel
{
    partial class TFListaClifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaClifor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsClifor = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_FiscalClifor = new System.Windows.Forms.Button();
            this.Cd_CondFiscal_Clifor = new Componentes.EditDefault(this.components);
            this.LB_Cd_CondFiscal_Clifor = new System.Windows.Forms.Label();
            this.bb_clifor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BB_CategoriaClifor = new System.Windows.Forms.Button();
            this.ID_CategoriaClifor = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NR_CPF = new Componentes.EditMask(this.components);
            this.LB_NM_Fantasia = new System.Windows.Forms.Label();
            this.NM_Fantasia = new Componentes.EditDefault(this.components);
            this.NR_CGC = new Componentes.EditMask(this.components);
            this.LB_NR_CGC = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gClifor = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipopessoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcpfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcgcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadocivilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtnascimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stvendedorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stmotoristaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sttecnicoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stfrentistaDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stoperadorcxDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_clifo = new Componentes.EditDefault(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gClifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bsClifor
            // 
            this.bsClifor.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadClifor);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pFiltro, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.barraMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 489);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.cd_clifo);
            this.pFiltro.Controls.Add(this.bb_FiscalClifor);
            this.pFiltro.Controls.Add(this.Cd_CondFiscal_Clifor);
            this.pFiltro.Controls.Add(this.LB_Cd_CondFiscal_Clifor);
            this.pFiltro.Controls.Add(this.bb_clifor);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.BB_CategoriaClifor);
            this.pFiltro.Controls.Add(this.ID_CategoriaClifor);
            this.pFiltro.Controls.Add(this.label10);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.NR_CPF);
            this.pFiltro.Controls.Add(this.LB_NM_Fantasia);
            this.pFiltro.Controls.Add(this.NM_Fantasia);
            this.pFiltro.Controls.Add(this.NR_CGC);
            this.pFiltro.Controls.Add(this.LB_NR_CGC);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 46);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(652, 56);
            this.pFiltro.TabIndex = 22;
            // 
            // bb_FiscalClifor
            // 
            this.bb_FiscalClifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_FiscalClifor.Image")));
            this.bb_FiscalClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_FiscalClifor.Location = new System.Drawing.Point(323, 28);
            this.bb_FiscalClifor.Name = "bb_FiscalClifor";
            this.bb_FiscalClifor.Size = new System.Drawing.Size(30, 20);
            this.bb_FiscalClifor.TabIndex = 99;
            this.bb_FiscalClifor.UseVisualStyleBackColor = true;
            this.bb_FiscalClifor.Click += new System.EventHandler(this.bb_FiscalClifor_Click);
            // 
            // Cd_CondFiscal_Clifor
            // 
            this.Cd_CondFiscal_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_CondFiscal_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_CondFiscal_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_CondFiscal_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cd_CondFiscal_Clifor.Location = new System.Drawing.Point(235, 28);
            this.Cd_CondFiscal_Clifor.Name = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_Alias = "a";
            this.Cd_CondFiscal_Clifor.NM_Campo = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_CampoBusca = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_Param = "@P_CD_CONDFISCAL_CLIFOR";
            this.Cd_CondFiscal_Clifor.QTD_Zero = 0;
            this.Cd_CondFiscal_Clifor.Size = new System.Drawing.Size(86, 20);
            this.Cd_CondFiscal_Clifor.ST_AutoInc = false;
            this.Cd_CondFiscal_Clifor.ST_DisableAuto = false;
            this.Cd_CondFiscal_Clifor.ST_Float = false;
            this.Cd_CondFiscal_Clifor.ST_Gravar = false;
            this.Cd_CondFiscal_Clifor.ST_Int = false;
            this.Cd_CondFiscal_Clifor.ST_LimpaCampo = true;
            this.Cd_CondFiscal_Clifor.ST_NotNull = false;
            this.Cd_CondFiscal_Clifor.ST_PrimaryKey = false;
            this.Cd_CondFiscal_Clifor.TabIndex = 98;
            this.Cd_CondFiscal_Clifor.TextOld = null;
            this.Cd_CondFiscal_Clifor.Leave += new System.EventHandler(this.Cd_CondFiscal_Clifor_Leave);
            // 
            // LB_Cd_CondFiscal_Clifor
            // 
            this.LB_Cd_CondFiscal_Clifor.AutoSize = true;
            this.LB_Cd_CondFiscal_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Cd_CondFiscal_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Cd_CondFiscal_Clifor.Location = new System.Drawing.Point(165, 32);
            this.LB_Cd_CondFiscal_Clifor.Name = "LB_Cd_CondFiscal_Clifor";
            this.LB_Cd_CondFiscal_Clifor.Size = new System.Drawing.Size(68, 13);
            this.LB_Cd_CondFiscal_Clifor.TabIndex = 100;
            this.LB_Cd_CondFiscal_Clifor.Text = "Cond. Fiscal:";
            this.LB_Cd_CondFiscal_Clifor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(134, 2);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 20);
            this.bb_clifor.TabIndex = 96;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(0, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 97;
            this.label6.Text = "Cliente:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_CategoriaClifor
            // 
            this.BB_CategoriaClifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_CategoriaClifor.Image")));
            this.BB_CategoriaClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CategoriaClifor.Location = new System.Drawing.Point(323, 2);
            this.BB_CategoriaClifor.Name = "BB_CategoriaClifor";
            this.BB_CategoriaClifor.Size = new System.Drawing.Size(30, 20);
            this.BB_CategoriaClifor.TabIndex = 6;
            this.BB_CategoriaClifor.UseVisualStyleBackColor = true;
            this.BB_CategoriaClifor.Click += new System.EventHandler(this.BB_CategoriaClifor_Click);
            // 
            // ID_CategoriaClifor
            // 
            this.ID_CategoriaClifor.BackColor = System.Drawing.SystemColors.Window;
            this.ID_CategoriaClifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_CategoriaClifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_CategoriaClifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ID_CategoriaClifor.Location = new System.Drawing.Point(235, 3);
            this.ID_CategoriaClifor.Name = "ID_CategoriaClifor";
            this.ID_CategoriaClifor.NM_Alias = "a";
            this.ID_CategoriaClifor.NM_Campo = "ID_CategoriaClifor";
            this.ID_CategoriaClifor.NM_CampoBusca = "ID_CategoriaClifor";
            this.ID_CategoriaClifor.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.ID_CategoriaClifor.QTD_Zero = 0;
            this.ID_CategoriaClifor.Size = new System.Drawing.Size(86, 20);
            this.ID_CategoriaClifor.ST_AutoInc = false;
            this.ID_CategoriaClifor.ST_DisableAuto = false;
            this.ID_CategoriaClifor.ST_Float = false;
            this.ID_CategoriaClifor.ST_Gravar = false;
            this.ID_CategoriaClifor.ST_Int = true;
            this.ID_CategoriaClifor.ST_LimpaCampo = true;
            this.ID_CategoriaClifor.ST_NotNull = false;
            this.ID_CategoriaClifor.ST_PrimaryKey = false;
            this.ID_CategoriaClifor.TabIndex = 5;
            this.ID_CategoriaClifor.TextOld = null;
            this.ID_CategoriaClifor.Leave += new System.EventHandler(this.ID_CategoriaClifor_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(177, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 79;
            this.label10.Text = "Categoria:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "CPF:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NR_CPF
            // 
            this.NR_CPF.BackColor = System.Drawing.Color.White;
            this.NR_CPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NR_CPF.Location = new System.Drawing.Point(49, 28);
            this.NR_CPF.Mask = "000\\.000\\.000-00";
            this.NR_CPF.Name = "NR_CPF";
            this.NR_CPF.NM_Alias = "a";
            this.NR_CPF.NM_Campo = "NR_CGC_CPF";
            this.NR_CPF.NM_CampoBusca = "NR_CPF";
            this.NR_CPF.NM_Param = "@P_NR_CPF";
            this.NR_CPF.Size = new System.Drawing.Size(112, 20);
            this.NR_CPF.ST_Gravar = false;
            this.NR_CPF.ST_LimpaCampo = true;
            this.NR_CPF.ST_NotNull = false;
            this.NR_CPF.ST_PrimaryKey = false;
            this.NR_CPF.TabIndex = 2;
            // 
            // LB_NM_Fantasia
            // 
            this.LB_NM_Fantasia.AutoSize = true;
            this.LB_NM_Fantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_NM_Fantasia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_NM_Fantasia.Location = new System.Drawing.Point(374, 32);
            this.LB_NM_Fantasia.Name = "LB_NM_Fantasia";
            this.LB_NM_Fantasia.Size = new System.Drawing.Size(50, 13);
            this.LB_NM_Fantasia.TabIndex = 69;
            this.LB_NM_Fantasia.Text = "Fantasia:";
            this.LB_NM_Fantasia.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_Fantasia
            // 
            this.NM_Fantasia.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Fantasia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Fantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Fantasia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Fantasia.Location = new System.Drawing.Point(426, 28);
            this.NM_Fantasia.Name = "NM_Fantasia";
            this.NM_Fantasia.NM_Alias = "";
            this.NM_Fantasia.NM_Campo = "NM_Fantasia";
            this.NM_Fantasia.NM_CampoBusca = "NM_Fantasia";
            this.NM_Fantasia.NM_Param = "@P_NM_FANTASIA";
            this.NM_Fantasia.QTD_Zero = 0;
            this.NM_Fantasia.Size = new System.Drawing.Size(158, 20);
            this.NM_Fantasia.ST_AutoInc = false;
            this.NM_Fantasia.ST_DisableAuto = false;
            this.NM_Fantasia.ST_Float = false;
            this.NM_Fantasia.ST_Gravar = false;
            this.NM_Fantasia.ST_Int = false;
            this.NM_Fantasia.ST_LimpaCampo = true;
            this.NM_Fantasia.ST_NotNull = false;
            this.NM_Fantasia.ST_PrimaryKey = false;
            this.NM_Fantasia.TabIndex = 4;
            this.NM_Fantasia.TextOld = null;
            // 
            // NR_CGC
            // 
            this.NR_CGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NR_CGC.Location = new System.Drawing.Point(426, 3);
            this.NR_CGC.Mask = "00\\.000\\.000/0000-00";
            this.NR_CGC.Name = "NR_CGC";
            this.NR_CGC.NM_Alias = "";
            this.NR_CGC.NM_Campo = "NR_CGC_CPF";
            this.NR_CGC.NM_CampoBusca = "NR_CGC";
            this.NR_CGC.NM_Param = "@P_NR_CGC";
            this.NR_CGC.Size = new System.Drawing.Size(113, 20);
            this.NR_CGC.ST_Gravar = false;
            this.NR_CGC.ST_LimpaCampo = true;
            this.NR_CGC.ST_NotNull = false;
            this.NR_CGC.ST_PrimaryKey = false;
            this.NR_CGC.TabIndex = 1;
            // 
            // LB_NR_CGC
            // 
            this.LB_NR_CGC.AutoSize = true;
            this.LB_NR_CGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_NR_CGC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_NR_CGC.Location = new System.Drawing.Point(387, 9);
            this.LB_NR_CGC.Name = "LB_NR_CGC";
            this.LB_NR_CGC.Size = new System.Drawing.Size(37, 13);
            this.LB_NR_CGC.TabIndex = 52;
            this.LB_NR_CGC.Text = "CNPJ:";
            this.LB_NR_CGC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.BB_Buscar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(658, 43);
            this.barraMenu.TabIndex = 17;
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbTodos);
            this.panelDados1.Controls.Add(this.gClifor);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 108);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(652, 378);
            this.panelDados1.TabIndex = 25;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(7, 10);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 24;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // gClifor
            // 
            this.gClifor.AllowUserToAddRows = false;
            this.gClifor.AllowUserToDeleteRows = false;
            this.gClifor.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gClifor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gClifor.AutoGenerateColumns = false;
            this.gClifor.BackgroundColor = System.Drawing.Color.LightGray;
            this.gClifor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gClifor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gClifor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gClifor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gClifor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.tipopessoaDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.nrcpfDataGridViewTextBoxColumn,
            this.nmfantasiaDataGridViewTextBoxColumn,
            this.nrcgcDataGridViewTextBoxColumn,
            this.estadocivilDataGridViewTextBoxColumn,
            this.dtnascimentoDataGridViewTextBoxColumn,
            this.idcargoDataGridViewTextBoxColumn,
            this.dscargoDataGridViewTextBoxColumn,
            this.stvendedorDataGridViewCheckBoxColumn,
            this.stmotoristaDataGridViewCheckBoxColumn,
            this.sttecnicoDataGridViewCheckBoxColumn,
            this.stfrentistaDataGridViewCheckBoxColumn,
            this.stoperadorcxDataGridViewCheckBoxColumn});
            this.gClifor.DataSource = this.bsClifor;
            this.gClifor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gClifor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gClifor.Location = new System.Drawing.Point(0, 0);
            this.gClifor.Name = "gClifor";
            this.gClifor.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gClifor.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gClifor.RowHeadersWidth = 23;
            this.gClifor.Size = new System.Drawing.Size(652, 353);
            this.gClifor.TabIndex = 23;
            this.gClifor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gClifor_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Processar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Cd. Clifor";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipopessoaDataGridViewTextBoxColumn
            // 
            this.tipopessoaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_pessoa";
            this.tipopessoaDataGridViewTextBoxColumn.HeaderText = "Tipo Pessoa";
            this.tipopessoaDataGridViewTextBoxColumn.Name = "tipopessoaDataGridViewTextBoxColumn";
            this.tipopessoaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrcpfDataGridViewTextBoxColumn
            // 
            this.nrcpfDataGridViewTextBoxColumn.DataPropertyName = "Nr_cpf";
            this.nrcpfDataGridViewTextBoxColumn.HeaderText = "Nr. CPF";
            this.nrcpfDataGridViewTextBoxColumn.Name = "nrcpfDataGridViewTextBoxColumn";
            this.nrcpfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfantasiaDataGridViewTextBoxColumn
            // 
            this.nmfantasiaDataGridViewTextBoxColumn.DataPropertyName = "Nm_fantasia";
            this.nmfantasiaDataGridViewTextBoxColumn.HeaderText = "Nm. Fantasia";
            this.nmfantasiaDataGridViewTextBoxColumn.Name = "nmfantasiaDataGridViewTextBoxColumn";
            this.nmfantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrcgcDataGridViewTextBoxColumn
            // 
            this.nrcgcDataGridViewTextBoxColumn.DataPropertyName = "Nr_cgc";
            this.nrcgcDataGridViewTextBoxColumn.HeaderText = "Nr. CNPJ";
            this.nrcgcDataGridViewTextBoxColumn.Name = "nrcgcDataGridViewTextBoxColumn";
            this.nrcgcDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadocivilDataGridViewTextBoxColumn
            // 
            this.estadocivilDataGridViewTextBoxColumn.DataPropertyName = "Estadocivil";
            this.estadocivilDataGridViewTextBoxColumn.HeaderText = "Estado Civil";
            this.estadocivilDataGridViewTextBoxColumn.Name = "estadocivilDataGridViewTextBoxColumn";
            this.estadocivilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtnascimentoDataGridViewTextBoxColumn
            // 
            this.dtnascimentoDataGridViewTextBoxColumn.DataPropertyName = "Dt_nascimento";
            this.dtnascimentoDataGridViewTextBoxColumn.HeaderText = "Dt. Nascimento";
            this.dtnascimentoDataGridViewTextBoxColumn.Name = "dtnascimentoDataGridViewTextBoxColumn";
            this.dtnascimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcargoDataGridViewTextBoxColumn
            // 
            this.idcargoDataGridViewTextBoxColumn.DataPropertyName = "Id_cargo";
            this.idcargoDataGridViewTextBoxColumn.HeaderText = "Cd. Cargo";
            this.idcargoDataGridViewTextBoxColumn.Name = "idcargoDataGridViewTextBoxColumn";
            this.idcargoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscargoDataGridViewTextBoxColumn
            // 
            this.dscargoDataGridViewTextBoxColumn.DataPropertyName = "Ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.HeaderText = "Ds. Cargo";
            this.dscargoDataGridViewTextBoxColumn.Name = "dscargoDataGridViewTextBoxColumn";
            this.dscargoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stvendedorDataGridViewCheckBoxColumn
            // 
            this.stvendedorDataGridViewCheckBoxColumn.DataPropertyName = "St_vendedor";
            this.stvendedorDataGridViewCheckBoxColumn.HeaderText = "St. Vendedor";
            this.stvendedorDataGridViewCheckBoxColumn.Name = "stvendedorDataGridViewCheckBoxColumn";
            this.stvendedorDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stmotoristaDataGridViewCheckBoxColumn
            // 
            this.stmotoristaDataGridViewCheckBoxColumn.DataPropertyName = "St_motorista";
            this.stmotoristaDataGridViewCheckBoxColumn.HeaderText = "St. Motorista";
            this.stmotoristaDataGridViewCheckBoxColumn.Name = "stmotoristaDataGridViewCheckBoxColumn";
            this.stmotoristaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // sttecnicoDataGridViewCheckBoxColumn
            // 
            this.sttecnicoDataGridViewCheckBoxColumn.DataPropertyName = "St_tecnico";
            this.sttecnicoDataGridViewCheckBoxColumn.HeaderText = "St. Técnico";
            this.sttecnicoDataGridViewCheckBoxColumn.Name = "sttecnicoDataGridViewCheckBoxColumn";
            this.sttecnicoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stfrentistaDataGridViewCheckBoxColumn
            // 
            this.stfrentistaDataGridViewCheckBoxColumn.DataPropertyName = "St_frentista";
            this.stfrentistaDataGridViewCheckBoxColumn.HeaderText = "St. Frentista";
            this.stfrentistaDataGridViewCheckBoxColumn.Name = "stfrentistaDataGridViewCheckBoxColumn";
            this.stfrentistaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // stoperadorcxDataGridViewCheckBoxColumn
            // 
            this.stoperadorcxDataGridViewCheckBoxColumn.DataPropertyName = "St_operadorcx";
            this.stoperadorcxDataGridViewCheckBoxColumn.HeaderText = "St. Operador Caixa";
            this.stoperadorcxDataGridViewCheckBoxColumn.Name = "stoperadorcxDataGridViewCheckBoxColumn";
            this.stoperadorcxDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsClifor;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 353);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(652, 25);
            this.bindingNavigator1.TabIndex = 21;
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
            // cd_clifo
            // 
            this.cd_clifo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifo.Location = new System.Drawing.Point(48, 2);
            this.cd_clifo.Name = "cd_clifo";
            this.cd_clifo.NM_Alias = "";
            this.cd_clifo.NM_Campo = "cd_clifor";
            this.cd_clifo.NM_CampoBusca = "cd_clifor";
            this.cd_clifo.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifo.QTD_Zero = 0;
            this.cd_clifo.Size = new System.Drawing.Size(84, 20);
            this.cd_clifo.ST_AutoInc = false;
            this.cd_clifo.ST_DisableAuto = false;
            this.cd_clifo.ST_Float = false;
            this.cd_clifo.ST_Gravar = false;
            this.cd_clifo.ST_Int = true;
            this.cd_clifo.ST_LimpaCampo = true;
            this.cd_clifo.ST_NotNull = false;
            this.cd_clifo.ST_PrimaryKey = false;
            this.cd_clifo.TabIndex = 101;
            this.cd_clifo.TextOld = null;
            this.cd_clifo.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // TFListaClifor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 489);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TFListaClifor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Clifor";
            this.Load += new System.EventHandler(this.TFListaClifor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gClifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsClifor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
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
        private System.Windows.Forms.Button BB_CategoriaClifor;
        private Componentes.EditDefault ID_CategoriaClifor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private Componentes.EditMask NR_CPF;
        private System.Windows.Forms.Label LB_NM_Fantasia;
        private Componentes.EditDefault NM_Fantasia;
        private Componentes.EditMask NR_CGC;
        private Componentes.DataGridDefault gClifor;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.Button bb_FiscalClifor;
        private Componentes.EditDefault Cd_CondFiscal_Clifor;
        private System.Windows.Forms.Label LB_Cd_CondFiscal_Clifor;
        private System.Windows.Forms.Button bb_clifor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LB_NR_CGC;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipopessoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcpfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcgcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadocivilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtnascimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stvendedorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stmotoristaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sttecnicoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stfrentistaDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stoperadorcxDataGridViewCheckBoxColumn;
        private Componentes.EditDefault cd_clifo;
    }
}