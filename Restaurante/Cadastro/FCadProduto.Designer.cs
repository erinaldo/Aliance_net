namespace Restaurante.Cadastro
{
    partial class FCadProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadProduto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_condfiscal_produto = new Componentes.EditDefault(this.components);
            this.bsProduto = new System.Windows.Forms.BindingSource(this.components);
            this.CD_CondFiscal_Produto = new Componentes.EditDefault(this.components);
            this.BB_CondFiscalProduto = new System.Windows.Forms.Button();
            this.LB_CD_CondFiscal_Produto = new System.Windows.Forms.Label();
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.editFloat2 = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ncm = new Componentes.EditDefault(this.components);
            this.LB_cd_ClassifFiscal = new System.Windows.Forms.Label();
            this.bb_ncm = new System.Windows.Forms.Button();
            this.ds_ncm = new Componentes.EditDefault(this.components);
            this.LB_CD_Produto = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.ds_tpproduto = new Componentes.EditDefault(this.components);
            this.BB_TpProduto = new System.Windows.Forms.Button();
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.LB_CD_Unidade = new System.Windows.Forms.Label();
            this.LB_DS_Produto = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.LB_TP_Produto = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.BB_GrupoProduto = new System.Windows.Forms.Button();
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.TP_Produto = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(610, 43);
            this.barraMenu.TabIndex = 12;
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
            this.bb_inutilizar.ToolTipText = "Gravar";
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.ds_condfiscal_produto);
            this.panelDados1.Controls.Add(this.CD_CondFiscal_Produto);
            this.panelDados1.Controls.Add(this.BB_CondFiscalProduto);
            this.panelDados1.Controls.Add(this.LB_CD_CondFiscal_Produto);
            this.panelDados1.Controls.Add(this.checkBoxDefault1);
            this.panelDados1.Controls.Add(this.editFloat2);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.button1);
            this.panelDados1.Controls.Add(this.editDefault2);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.editFloat1);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.ncm);
            this.panelDados1.Controls.Add(this.LB_cd_ClassifFiscal);
            this.panelDados1.Controls.Add(this.bb_ncm);
            this.panelDados1.Controls.Add(this.ds_ncm);
            this.panelDados1.Controls.Add(this.LB_CD_Produto);
            this.panelDados1.Controls.Add(this.CD_Grupo);
            this.panelDados1.Controls.Add(this.ds_tpproduto);
            this.panelDados1.Controls.Add(this.BB_TpProduto);
            this.panelDados1.Controls.Add(this.LB_CD_Grupo);
            this.panelDados1.Controls.Add(this.DS_Produto);
            this.panelDados1.Controls.Add(this.CD_Unidade);
            this.panelDados1.Controls.Add(this.LB_CD_Unidade);
            this.panelDados1.Controls.Add(this.LB_DS_Produto);
            this.panelDados1.Controls.Add(this.CD_Produto);
            this.panelDados1.Controls.Add(this.LB_TP_Produto);
            this.panelDados1.Controls.Add(this.DS_Grupo);
            this.panelDados1.Controls.Add(this.BB_Unidade);
            this.panelDados1.Controls.Add(this.BB_GrupoProduto);
            this.panelDados1.Controls.Add(this.ds_unidade);
            this.panelDados1.Controls.Add(this.TP_Produto);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(610, 246);
            this.panelDados1.TabIndex = 0;
            // 
            // ds_condfiscal_produto
            // 
            this.ds_condfiscal_produto.BackColor = System.Drawing.Color.White;
            this.ds_condfiscal_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condfiscal_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condfiscal_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_CondFiscal_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condfiscal_produto.Enabled = false;
            this.ds_condfiscal_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_condfiscal_produto.Location = new System.Drawing.Point(178, 60);
            this.ds_condfiscal_produto.Name = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Alias = "";
            this.ds_condfiscal_produto.NM_Campo = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_CampoBusca = "ds_condfiscal_produto";
            this.ds_condfiscal_produto.NM_Param = "";
            this.ds_condfiscal_produto.QTD_Zero = 0;
            this.ds_condfiscal_produto.ReadOnly = true;
            this.ds_condfiscal_produto.Size = new System.Drawing.Size(424, 20);
            this.ds_condfiscal_produto.ST_AutoInc = false;
            this.ds_condfiscal_produto.ST_DisableAuto = false;
            this.ds_condfiscal_produto.ST_Float = false;
            this.ds_condfiscal_produto.ST_Gravar = false;
            this.ds_condfiscal_produto.ST_Int = false;
            this.ds_condfiscal_produto.ST_LimpaCampo = true;
            this.ds_condfiscal_produto.ST_NotNull = false;
            this.ds_condfiscal_produto.ST_PrimaryKey = false;
            this.ds_condfiscal_produto.TabIndex = 918;
            this.ds_condfiscal_produto.TextOld = null;
            // 
            // bsProduto
            // 
            this.bsProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadProduto);
            // 
            // CD_CondFiscal_Produto
            // 
            this.CD_CondFiscal_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondFiscal_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CondFiscal_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondFiscal_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_CondFiscal_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CondFiscal_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CondFiscal_Produto.Location = new System.Drawing.Point(83, 60);
            this.CD_CondFiscal_Produto.Name = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_Alias = "a";
            this.CD_CondFiscal_Produto.NM_Campo = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_CampoBusca = "CD_CondFiscal_Produto";
            this.CD_CondFiscal_Produto.NM_Param = "@P_CD_CONDFISCAL_PRODUTO";
            this.CD_CondFiscal_Produto.QTD_Zero = 0;
            this.CD_CondFiscal_Produto.Size = new System.Drawing.Size(56, 20);
            this.CD_CondFiscal_Produto.ST_AutoInc = false;
            this.CD_CondFiscal_Produto.ST_DisableAuto = false;
            this.CD_CondFiscal_Produto.ST_Float = false;
            this.CD_CondFiscal_Produto.ST_Gravar = true;
            this.CD_CondFiscal_Produto.ST_Int = false;
            this.CD_CondFiscal_Produto.ST_LimpaCampo = true;
            this.CD_CondFiscal_Produto.ST_NotNull = true;
            this.CD_CondFiscal_Produto.ST_PrimaryKey = false;
            this.CD_CondFiscal_Produto.TabIndex = 2;
            this.CD_CondFiscal_Produto.TextOld = null;
            this.CD_CondFiscal_Produto.Leave += new System.EventHandler(this.CD_CondFiscal_Produto_Leave);
            // 
            // BB_CondFiscalProduto
            // 
            this.BB_CondFiscalProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_CondFiscalProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_CondFiscalProduto.Image")));
            this.BB_CondFiscalProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CondFiscalProduto.Location = new System.Drawing.Point(143, 60);
            this.BB_CondFiscalProduto.Name = "BB_CondFiscalProduto";
            this.BB_CondFiscalProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_CondFiscalProduto.TabIndex = 3;
            this.BB_CondFiscalProduto.UseVisualStyleBackColor = true;
            this.BB_CondFiscalProduto.Click += new System.EventHandler(this.BB_CondFiscalProduto_Click);
            // 
            // LB_CD_CondFiscal_Produto
            // 
            this.LB_CD_CondFiscal_Produto.AutoSize = true;
            this.LB_CD_CondFiscal_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_CondFiscal_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_CondFiscal_Produto.Location = new System.Drawing.Point(9, 63);
            this.LB_CD_CondFiscal_Produto.Name = "LB_CD_CondFiscal_Produto";
            this.LB_CD_CondFiscal_Produto.Size = new System.Drawing.Size(68, 13);
            this.LB_CD_CondFiscal_Produto.TabIndex = 919;
            this.LB_CD_CondFiscal_Produto.Text = "Cond. Fiscal:";
            this.LB_CD_CondFiscal_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsProduto, "St_pesarprodbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Location = new System.Drawing.Point(183, 220);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(92, 17);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 16;
            this.checkBoxDefault1.Text = "Pesar produto";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // editFloat2
            // 
            this.editFloat2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProduto, "qt_combsabores", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat2.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat2.Location = new System.Drawing.Point(83, 217);
            this.editFloat2.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.editFloat2.Name = "editFloat2";
            this.editFloat2.NM_Alias = "";
            this.editFloat2.NM_Campo = "";
            this.editFloat2.NM_Param = "";
            this.editFloat2.Operador = "";
            this.editFloat2.Size = new System.Drawing.Size(90, 20);
            this.editFloat2.ST_AutoInc = false;
            this.editFloat2.ST_DisableAuto = false;
            this.editFloat2.ST_Gravar = false;
            this.editFloat2.ST_LimparCampo = true;
            this.editFloat2.ST_NotNull = false;
            this.editFloat2.ST_PrimaryKey = false;
            this.editFloat2.TabIndex = 15;
            this.editFloat2.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 913;
            this.label3.Text = "Qtd. Sabores";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "id_localimp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault1.Location = new System.Drawing.Point(83, 191);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "a";
            this.editDefault1.NM_Campo = "ID_LOCALIMP";
            this.editDefault1.NM_CampoBusca = "ID_LOCALIMP";
            this.editDefault1.NM_Param = "@P_ID_LOCALIMP";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(104, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 13;
            this.editDefault1.TextOld = null;
            this.editDefault1.Leave += new System.EventHandler(this.editDefault1_Leave);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(189, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 20);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.Color.White;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "porta_imp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault2.Location = new System.Drawing.Point(225, 191);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "DS_LOCALIMP";
            this.editDefault2.NM_CampoBusca = "DS_LOCALIMP";
            this.editDefault2.NM_Param = "@P_DS_LOCALIMP";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.ReadOnly = true;
            this.editDefault2.Size = new System.Drawing.Size(247, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 14;
            this.editDefault2.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(22, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 909;
            this.label2.Text = "Porta Imp.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProduto, "Vl_precovenda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(83, 164);
            this.editFloat1.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(90, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 10;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 906;
            this.label1.Text = "Preco venda:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ncm
            // 
            this.ncm.BackColor = System.Drawing.SystemColors.Window;
            this.ncm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ncm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ncm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Ncm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ncm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ncm.Location = new System.Drawing.Point(213, 163);
            this.ncm.Name = "ncm";
            this.ncm.NM_Alias = "a";
            this.ncm.NM_Campo = "ncm";
            this.ncm.NM_CampoBusca = "ncm";
            this.ncm.NM_Param = "@P_CD_CLASSIFFISCAL";
            this.ncm.QTD_Zero = 0;
            this.ncm.Size = new System.Drawing.Size(104, 20);
            this.ncm.ST_AutoInc = false;
            this.ncm.ST_DisableAuto = false;
            this.ncm.ST_Float = false;
            this.ncm.ST_Gravar = true;
            this.ncm.ST_Int = false;
            this.ncm.ST_LimpaCampo = true;
            this.ncm.ST_NotNull = false;
            this.ncm.ST_PrimaryKey = false;
            this.ncm.TabIndex = 11;
            this.ncm.TextOld = null;
            this.ncm.Leave += new System.EventHandler(this.ncm_Leave);
            // 
            // LB_cd_ClassifFiscal
            // 
            this.LB_cd_ClassifFiscal.AutoSize = true;
            this.LB_cd_ClassifFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_cd_ClassifFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_cd_ClassifFiscal.Location = new System.Drawing.Point(174, 166);
            this.LB_cd_ClassifFiscal.Name = "LB_cd_ClassifFiscal";
            this.LB_cd_ClassifFiscal.Size = new System.Drawing.Size(34, 13);
            this.LB_cd_ClassifFiscal.TabIndex = 905;
            this.LB_cd_ClassifFiscal.Text = "NCM:";
            this.LB_cd_ClassifFiscal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bb_ncm
            // 
            this.bb_ncm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_ncm.Image = ((System.Drawing.Image)(resources.GetObject("bb_ncm.Image")));
            this.bb_ncm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ncm.Location = new System.Drawing.Point(319, 163);
            this.bb_ncm.Name = "bb_ncm";
            this.bb_ncm.Size = new System.Drawing.Size(30, 20);
            this.bb_ncm.TabIndex = 12;
            this.bb_ncm.UseVisualStyleBackColor = true;
            this.bb_ncm.Click += new System.EventHandler(this.bb_ncm_Click);
            // 
            // ds_ncm
            // 
            this.ds_ncm.BackColor = System.Drawing.Color.White;
            this.ds_ncm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_ncm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ncm.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "Ds_ncm", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ncm.Enabled = false;
            this.ds_ncm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_ncm.Location = new System.Drawing.Point(355, 163);
            this.ds_ncm.Name = "ds_ncm";
            this.ds_ncm.NM_Alias = "";
            this.ds_ncm.NM_Campo = "ds_ncm";
            this.ds_ncm.NM_CampoBusca = "ds_ncm";
            this.ds_ncm.NM_Param = "@P_DS_NCM";
            this.ds_ncm.QTD_Zero = 0;
            this.ds_ncm.ReadOnly = true;
            this.ds_ncm.Size = new System.Drawing.Size(247, 20);
            this.ds_ncm.ST_AutoInc = false;
            this.ds_ncm.ST_DisableAuto = false;
            this.ds_ncm.ST_Float = false;
            this.ds_ncm.ST_Gravar = false;
            this.ds_ncm.ST_Int = false;
            this.ds_ncm.ST_LimpaCampo = true;
            this.ds_ncm.ST_NotNull = false;
            this.ds_ncm.ST_PrimaryKey = false;
            this.ds_ncm.TabIndex = 902;
            this.ds_ncm.TextOld = null;
            // 
            // LB_CD_Produto
            // 
            this.LB_CD_Produto.AutoSize = true;
            this.LB_CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Produto.Location = new System.Drawing.Point(34, 11);
            this.LB_CD_Produto.Name = "LB_CD_Produto";
            this.LB_CD_Produto.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Produto.TabIndex = 886;
            this.LB_CD_Produto.Text = "Código:";
            this.LB_CD_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(83, 86);
            this.CD_Grupo.Name = "CD_Grupo";
            this.CD_Grupo.NM_Alias = "a";
            this.CD_Grupo.NM_Campo = "CD_Grupo";
            this.CD_Grupo.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo.NM_Param = "@P_CD_GRUPO";
            this.CD_Grupo.QTD_Zero = 0;
            this.CD_Grupo.Size = new System.Drawing.Size(56, 20);
            this.CD_Grupo.ST_AutoInc = false;
            this.CD_Grupo.ST_DisableAuto = false;
            this.CD_Grupo.ST_Float = false;
            this.CD_Grupo.ST_Gravar = true;
            this.CD_Grupo.ST_Int = false;
            this.CD_Grupo.ST_LimpaCampo = true;
            this.CD_Grupo.ST_NotNull = true;
            this.CD_Grupo.ST_PrimaryKey = false;
            this.CD_Grupo.TabIndex = 4;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // ds_tpproduto
            // 
            this.ds_tpproduto.BackColor = System.Drawing.Color.White;
            this.ds_tpproduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpproduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpproduto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_TpProduto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpproduto.Enabled = false;
            this.ds_tpproduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpproduto.Location = new System.Drawing.Point(178, 111);
            this.ds_tpproduto.Name = "ds_tpproduto";
            this.ds_tpproduto.NM_Alias = "";
            this.ds_tpproduto.NM_Campo = "ds_tpproduto";
            this.ds_tpproduto.NM_CampoBusca = "ds_tpproduto";
            this.ds_tpproduto.NM_Param = "";
            this.ds_tpproduto.QTD_Zero = 0;
            this.ds_tpproduto.ReadOnly = true;
            this.ds_tpproduto.Size = new System.Drawing.Size(424, 20);
            this.ds_tpproduto.ST_AutoInc = false;
            this.ds_tpproduto.ST_DisableAuto = false;
            this.ds_tpproduto.ST_Float = false;
            this.ds_tpproduto.ST_Gravar = false;
            this.ds_tpproduto.ST_Int = false;
            this.ds_tpproduto.ST_LimpaCampo = true;
            this.ds_tpproduto.ST_NotNull = false;
            this.ds_tpproduto.ST_PrimaryKey = false;
            this.ds_tpproduto.TabIndex = 899;
            this.ds_tpproduto.TextOld = null;
            // 
            // BB_TpProduto
            // 
            this.BB_TpProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_TpProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_TpProduto.Image")));
            this.BB_TpProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_TpProduto.Location = new System.Drawing.Point(143, 111);
            this.BB_TpProduto.Name = "BB_TpProduto";
            this.BB_TpProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_TpProduto.TabIndex = 7;
            this.BB_TpProduto.UseVisualStyleBackColor = true;
            this.BB_TpProduto.Click += new System.EventHandler(this.BB_TpProduto_Click);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(10, 90);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(67, 13);
            this.LB_CD_Grupo.TabIndex = 893;
            this.LB_CD_Grupo.Text = "Grupo Prod.:";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(83, 34);
            this.DS_Produto.MaxLength = 120;
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "a";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(519, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = true;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 1;
            this.DS_Produto.TextOld = null;
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Unidade.Location = new System.Drawing.Point(83, 137);
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "a";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.Size = new System.Drawing.Size(56, 20);
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TabIndex = 8;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.TextChanged += new System.EventHandler(this.CD_Unidade_TextChanged);
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // LB_CD_Unidade
            // 
            this.LB_CD_Unidade.AutoSize = true;
            this.LB_CD_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Unidade.Location = new System.Drawing.Point(27, 140);
            this.LB_CD_Unidade.Name = "LB_CD_Unidade";
            this.LB_CD_Unidade.Size = new System.Drawing.Size(50, 13);
            this.LB_CD_Unidade.TabIndex = 894;
            this.LB_CD_Unidade.Text = "Unidade:";
            this.LB_CD_Unidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_DS_Produto
            // 
            this.LB_DS_Produto.AutoSize = true;
            this.LB_DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Produto.Location = new System.Drawing.Point(30, 37);
            this.LB_DS_Produto.Name = "LB_DS_Produto";
            this.LB_DS_Produto.Size = new System.Drawing.Size(47, 13);
            this.LB_DS_Produto.TabIndex = 890;
            this.LB_DS_Produto.Text = "Produto:";
            this.LB_DS_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.Color.White;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "CD_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(83, 8);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "a";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(92, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = true;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            // 
            // LB_TP_Produto
            // 
            this.LB_TP_Produto.AutoSize = true;
            this.LB_TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_TP_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_TP_Produto.Location = new System.Drawing.Point(6, 114);
            this.LB_TP_Produto.Name = "LB_TP_Produto";
            this.LB_TP_Produto.Size = new System.Drawing.Size(71, 13);
            this.LB_TP_Produto.TabIndex = 895;
            this.LB_TP_Produto.Text = "Tipo Produto:";
            this.LB_TP_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.Color.White;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Grupo.Enabled = false;
            this.DS_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Grupo.Location = new System.Drawing.Point(178, 86);
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "ds_grupo";
            this.DS_Grupo.NM_CampoBusca = "ds_grupo";
            this.DS_Grupo.NM_Param = "";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ReadOnly = true;
            this.DS_Grupo.Size = new System.Drawing.Size(424, 20);
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = false;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = false;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TabIndex = 892;
            this.DS_Grupo.TextOld = null;
            // 
            // BB_Unidade
            // 
            this.BB_Unidade.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Unidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Unidade.Image")));
            this.BB_Unidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Unidade.Location = new System.Drawing.Point(143, 137);
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.Size = new System.Drawing.Size(30, 20);
            this.BB_Unidade.TabIndex = 9;
            this.BB_Unidade.UseVisualStyleBackColor = true;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // BB_GrupoProduto
            // 
            this.BB_GrupoProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_GrupoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_GrupoProduto.Image")));
            this.BB_GrupoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_GrupoProduto.Location = new System.Drawing.Point(143, 86);
            this.BB_GrupoProduto.Name = "BB_GrupoProduto";
            this.BB_GrupoProduto.Size = new System.Drawing.Size(30, 20);
            this.BB_GrupoProduto.TabIndex = 5;
            this.BB_GrupoProduto.UseVisualStyleBackColor = true;
            this.BB_GrupoProduto.Click += new System.EventHandler(this.BB_GrupoProduto_Click);
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.Color.White;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "DS_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidade.Enabled = false;
            this.ds_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_unidade.Location = new System.Drawing.Point(178, 137);
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_DS_UNIDADE";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.Size = new System.Drawing.Size(424, 20);
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TabIndex = 904;
            this.ds_unidade.TextOld = null;
            // 
            // TP_Produto
            // 
            this.TP_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProduto, "TP_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Produto.Location = new System.Drawing.Point(83, 111);
            this.TP_Produto.Name = "TP_Produto";
            this.TP_Produto.NM_Alias = "a";
            this.TP_Produto.NM_Campo = "TP_Produto";
            this.TP_Produto.NM_CampoBusca = "TP_Produto";
            this.TP_Produto.NM_Param = "@P_TP_PRODUTO";
            this.TP_Produto.QTD_Zero = 0;
            this.TP_Produto.Size = new System.Drawing.Size(56, 20);
            this.TP_Produto.ST_AutoInc = false;
            this.TP_Produto.ST_DisableAuto = false;
            this.TP_Produto.ST_Float = false;
            this.TP_Produto.ST_Gravar = true;
            this.TP_Produto.ST_Int = false;
            this.TP_Produto.ST_LimpaCampo = true;
            this.TP_Produto.ST_NotNull = true;
            this.TP_Produto.ST_PrimaryKey = false;
            this.TP_Produto.TabIndex = 6;
            this.TP_Produto.TextOld = null;
            this.TP_Produto.Leave += new System.EventHandler(this.TP_Produto_Leave);
            // 
            // FCadProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 289);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCadProduto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Produto";
            this.Load += new System.EventHandler(this.FCadProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCadProduto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault ncm;
        private System.Windows.Forms.Label LB_cd_ClassifFiscal;
        private System.Windows.Forms.Button bb_ncm;
        private Componentes.EditDefault ds_ncm;
        private System.Windows.Forms.Label LB_CD_Produto;
        private Componentes.EditDefault CD_Grupo;
        private Componentes.EditDefault ds_tpproduto;
        public System.Windows.Forms.Button BB_TpProduto;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Produto;
        private Componentes.EditDefault CD_Unidade;
        private System.Windows.Forms.Label LB_CD_Unidade;
        private System.Windows.Forms.Label LB_DS_Produto;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label LB_TP_Produto;
        private Componentes.EditDefault DS_Grupo;
        public System.Windows.Forms.Button BB_Unidade;
        public System.Windows.Forms.Button BB_GrupoProduto;
        private Componentes.EditDefault ds_unidade;
        private Componentes.EditDefault TP_Produto;
        private System.Windows.Forms.BindingSource bsProduto;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Button button1;
        private Componentes.EditDefault editDefault2;
        private Componentes.EditFloat editFloat2;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private Componentes.EditDefault ds_condfiscal_produto;
        private Componentes.EditDefault CD_CondFiscal_Produto;
        public System.Windows.Forms.Button BB_CondFiscalProduto;
        private System.Windows.Forms.Label LB_CD_CondFiscal_Produto;
    }
}