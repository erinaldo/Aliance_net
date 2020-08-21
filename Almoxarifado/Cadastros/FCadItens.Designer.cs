namespace Almoxarifado.Cadastros
{
    partial class TFCadItens
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadItens));
            this.label2 = new System.Windows.Forms.Label();
            this.BS_CadItens = new System.Windows.Forms.BindingSource(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.id_rua = new Componentes.EditDefault(this.components);
            this.id_secao = new Componentes.EditDefault(this.components);
            this.id_celula = new Componentes.EditDefault(this.components);
            this.ds_almox = new Componentes.EditDefault(this.components);
            this.ds_rua = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.ds_celula = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bb_almox = new System.Windows.Forms.Button();
            this.bb_rua = new System.Windows.Forms.Button();
            this.bb_secao = new System.Windows.Forms.Button();
            this.bb_celula = new System.Windows.Forms.Button();
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idalmoxStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsalmoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idruaStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsruaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idsecaoStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssecaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcelulastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscelulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadItens = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_cdProduto = new System.Windows.Forms.Button();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadItens)).BeginInit();
            this.BN_CadItens.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.SystemColors.Control;
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_cdProduto);
            this.pDados.Controls.Add(this.bb_celula);
            this.pDados.Controls.Add(this.bb_secao);
            this.pDados.Controls.Add(this.bb_rua);
            this.pDados.Controls.Add(this.bb_almox);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_celula);
            this.pDados.Controls.Add(this.ds_secao);
            this.pDados.Controls.Add(this.ds_rua);
            this.pDados.Controls.Add(this.ds_almox);
            this.pDados.Controls.Add(this.id_celula);
            this.pDados.Controls.Add(this.id_secao);
            this.pDados.Controls.Add(this.id_rua);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Size = new System.Drawing.Size(659, 148);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Controls.Add(this.BN_CadItens);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadItens, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Produto:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BS_CadItens
            // 
            this.BS_CadItens.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadItens);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(95, 4);
            this.cd_produto.MaxLength = 7;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "a";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(55, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = true;
            this.cd_produto.TabIndex = 1;
            this.cd_produto.TextOld = null;
            this.cd_produto.TextChanged += new System.EventHandler(this.cd_produto_TextChanged);
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_almoxString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Enabled = false;
            this.id_almox.Location = new System.Drawing.Point(95, 27);
            this.id_almox.MaxLength = 5;
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "a";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_ID_ALMOX";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(55, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = true;
            this.id_almox.ST_Int = true;
            this.id_almox.ST_LimpaCampo = true;
            this.id_almox.ST_NotNull = true;
            this.id_almox.ST_PrimaryKey = true;
            this.id_almox.TabIndex = 3;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // id_rua
            // 
            this.id_rua.BackColor = System.Drawing.SystemColors.Window;
            this.id_rua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_ruaString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_rua.Enabled = false;
            this.id_rua.Location = new System.Drawing.Point(95, 48);
            this.id_rua.MaxLength = 5;
            this.id_rua.Name = "id_rua";
            this.id_rua.NM_Alias = "a";
            this.id_rua.NM_Campo = "id_rua";
            this.id_rua.NM_CampoBusca = "id_rua";
            this.id_rua.NM_Param = "@P_ID_RUA";
            this.id_rua.QTD_Zero = 0;
            this.id_rua.Size = new System.Drawing.Size(55, 20);
            this.id_rua.ST_AutoInc = false;
            this.id_rua.ST_DisableAuto = false;
            this.id_rua.ST_Float = false;
            this.id_rua.ST_Gravar = true;
            this.id_rua.ST_Int = true;
            this.id_rua.ST_LimpaCampo = true;
            this.id_rua.ST_NotNull = false;
            this.id_rua.ST_PrimaryKey = false;
            this.id_rua.TabIndex = 5;
            this.id_rua.TextOld = null;
            this.id_rua.Leave += new System.EventHandler(this.id_rua_Leave);
            // 
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_secaoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(95, 69);
            this.id_secao.MaxLength = 5;
            this.id_secao.Name = "id_secao";
            this.id_secao.NM_Alias = "a";
            this.id_secao.NM_Campo = "id_secao";
            this.id_secao.NM_CampoBusca = "id_secao";
            this.id_secao.NM_Param = "@P_ID_SECAO";
            this.id_secao.QTD_Zero = 0;
            this.id_secao.Size = new System.Drawing.Size(55, 20);
            this.id_secao.ST_AutoInc = false;
            this.id_secao.ST_DisableAuto = false;
            this.id_secao.ST_Float = false;
            this.id_secao.ST_Gravar = true;
            this.id_secao.ST_Int = true;
            this.id_secao.ST_LimpaCampo = true;
            this.id_secao.ST_NotNull = false;
            this.id_secao.ST_PrimaryKey = false;
            this.id_secao.TabIndex = 7;
            this.id_secao.TextOld = null;
            this.id_secao.Leave += new System.EventHandler(this.id_secao_Leave);
            // 
            // id_celula
            // 
            this.id_celula.BackColor = System.Drawing.SystemColors.Window;
            this.id_celula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_celulastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_celula.Enabled = false;
            this.id_celula.Location = new System.Drawing.Point(95, 90);
            this.id_celula.MaxLength = 5;
            this.id_celula.Name = "id_celula";
            this.id_celula.NM_Alias = "a";
            this.id_celula.NM_Campo = "id_celula";
            this.id_celula.NM_CampoBusca = "id_celula";
            this.id_celula.NM_Param = "@P_ID_NIVEL";
            this.id_celula.QTD_Zero = 0;
            this.id_celula.Size = new System.Drawing.Size(55, 20);
            this.id_celula.ST_AutoInc = false;
            this.id_celula.ST_DisableAuto = false;
            this.id_celula.ST_Float = false;
            this.id_celula.ST_Gravar = true;
            this.id_celula.ST_Int = true;
            this.id_celula.ST_LimpaCampo = true;
            this.id_celula.ST_NotNull = false;
            this.id_celula.ST_PrimaryKey = false;
            this.id_celula.TabIndex = 9;
            this.id_celula.TextOld = null;
            this.id_celula.Leave += new System.EventHandler(this.id_celula_Leave);
            // 
            // ds_almox
            // 
            this.ds_almox.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_almox.Enabled = false;
            this.ds_almox.Location = new System.Drawing.Point(185, 27);
            this.ds_almox.MaxLength = 20;
            this.ds_almox.Name = "ds_almox";
            this.ds_almox.NM_Alias = "";
            this.ds_almox.NM_Campo = "ds_almoxarifado";
            this.ds_almox.NM_CampoBusca = "ds_almoxarifado";
            this.ds_almox.NM_Param = "";
            this.ds_almox.QTD_Zero = 0;
            this.ds_almox.Size = new System.Drawing.Size(447, 20);
            this.ds_almox.ST_AutoInc = false;
            this.ds_almox.ST_DisableAuto = false;
            this.ds_almox.ST_Float = false;
            this.ds_almox.ST_Gravar = false;
            this.ds_almox.ST_Int = false;
            this.ds_almox.ST_LimpaCampo = true;
            this.ds_almox.ST_NotNull = false;
            this.ds_almox.ST_PrimaryKey = false;
            this.ds_almox.TabIndex = 7;
            this.ds_almox.TextOld = null;
            // 
            // ds_rua
            // 
            this.ds_rua.BackColor = System.Drawing.SystemColors.Window;
            this.ds_rua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_rua.Enabled = false;
            this.ds_rua.Location = new System.Drawing.Point(185, 48);
            this.ds_rua.MaxLength = 20;
            this.ds_rua.Name = "ds_rua";
            this.ds_rua.NM_Alias = "b";
            this.ds_rua.NM_Campo = "ds_rua";
            this.ds_rua.NM_CampoBusca = "ds_rua";
            this.ds_rua.NM_Param = "";
            this.ds_rua.QTD_Zero = 0;
            this.ds_rua.Size = new System.Drawing.Size(447, 20);
            this.ds_rua.ST_AutoInc = false;
            this.ds_rua.ST_DisableAuto = false;
            this.ds_rua.ST_Float = false;
            this.ds_rua.ST_Gravar = false;
            this.ds_rua.ST_Int = false;
            this.ds_rua.ST_LimpaCampo = true;
            this.ds_rua.ST_NotNull = false;
            this.ds_rua.ST_PrimaryKey = false;
            this.ds_rua.TabIndex = 10;
            this.ds_rua.TextOld = null;
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_secao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(185, 69);
            this.ds_secao.MaxLength = 20;
            this.ds_secao.Name = "ds_secao";
            this.ds_secao.NM_Alias = "";
            this.ds_secao.NM_Campo = "ds_secao";
            this.ds_secao.NM_CampoBusca = "ds_secao";
            this.ds_secao.NM_Param = "@P_DS_SECAO";
            this.ds_secao.QTD_Zero = 0;
            this.ds_secao.Size = new System.Drawing.Size(447, 20);
            this.ds_secao.ST_AutoInc = false;
            this.ds_secao.ST_DisableAuto = false;
            this.ds_secao.ST_Float = false;
            this.ds_secao.ST_Gravar = false;
            this.ds_secao.ST_Int = false;
            this.ds_secao.ST_LimpaCampo = true;
            this.ds_secao.ST_NotNull = false;
            this.ds_secao.ST_PrimaryKey = false;
            this.ds_secao.TabIndex = 13;
            this.ds_secao.TextOld = null;
            // 
            // ds_celula
            // 
            this.ds_celula.BackColor = System.Drawing.SystemColors.Window;
            this.ds_celula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_celula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_celula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Ds_celula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_celula.Enabled = false;
            this.ds_celula.Location = new System.Drawing.Point(185, 90);
            this.ds_celula.MaxLength = 20;
            this.ds_celula.Name = "ds_celula";
            this.ds_celula.NM_Alias = "";
            this.ds_celula.NM_Campo = "ds_celula";
            this.ds_celula.NM_CampoBusca = "ds_celula";
            this.ds_celula.NM_Param = "@P_DS_CELULA";
            this.ds_celula.QTD_Zero = 0;
            this.ds_celula.Size = new System.Drawing.Size(447, 20);
            this.ds_celula.ST_AutoInc = false;
            this.ds_celula.ST_DisableAuto = false;
            this.ds_celula.ST_Float = false;
            this.ds_celula.ST_Gravar = false;
            this.ds_celula.ST_Int = false;
            this.ds_celula.ST_LimpaCampo = true;
            this.ds_celula.ST_NotNull = false;
            this.ds_celula.ST_PrimaryKey = false;
            this.ds_celula.TabIndex = 16;
            this.ds_celula.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Almoxarifado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Rua:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Seção:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(43, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Celula:";
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Enabled = false;
            this.bb_almox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.Location = new System.Drawing.Point(151, 27);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(32, 20);
            this.bb_almox.TabIndex = 4;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // bb_rua
            // 
            this.bb_rua.BackColor = System.Drawing.SystemColors.Control;
            this.bb_rua.Enabled = false;
            this.bb_rua.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_rua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_rua.Image = ((System.Drawing.Image)(resources.GetObject("bb_rua.Image")));
            this.bb_rua.Location = new System.Drawing.Point(151, 48);
            this.bb_rua.Name = "bb_rua";
            this.bb_rua.Size = new System.Drawing.Size(32, 20);
            this.bb_rua.TabIndex = 6;
            this.bb_rua.UseVisualStyleBackColor = false;
            this.bb_rua.Click += new System.EventHandler(this.bb_rua_Click);
            // 
            // bb_secao
            // 
            this.bb_secao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_secao.Enabled = false;
            this.bb_secao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_secao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_secao.Image = ((System.Drawing.Image)(resources.GetObject("bb_secao.Image")));
            this.bb_secao.Location = new System.Drawing.Point(151, 69);
            this.bb_secao.Name = "bb_secao";
            this.bb_secao.Size = new System.Drawing.Size(32, 20);
            this.bb_secao.TabIndex = 8;
            this.bb_secao.UseVisualStyleBackColor = false;
            this.bb_secao.Click += new System.EventHandler(this.bb_secao_Click);
            // 
            // bb_celula
            // 
            this.bb_celula.BackColor = System.Drawing.SystemColors.Control;
            this.bb_celula.Enabled = false;
            this.bb_celula.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_celula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_celula.Image = ((System.Drawing.Image)(resources.GetObject("bb_celula.Image")));
            this.bb_celula.Location = new System.Drawing.Point(151, 90);
            this.bb_celula.Name = "bb_celula";
            this.bb_celula.Size = new System.Drawing.Size(32, 20);
            this.bb_celula.TabIndex = 10;
            this.bb_celula.UseVisualStyleBackColor = false;
            this.bb_celula.Click += new System.EventHandler(this.bb_celula_Click);
            // 
            // gPesquisa
            // 
            this.gPesquisa.AllowUserToAddRows = false;
            this.gPesquisa.AllowUserToDeleteRows = false;
            this.gPesquisa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPesquisa.AutoGenerateColumns = false;
            this.gPesquisa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsProdutoDataGridViewTextBoxColumn,
            this.idalmoxStringDataGridViewTextBoxColumn,
            this.dsalmoxDataGridViewTextBoxColumn,
            this.idruaStringDataGridViewTextBoxColumn,
            this.dsruaDataGridViewTextBoxColumn,
            this.idsecaoStringDataGridViewTextBoxColumn,
            this.dssecaoDataGridViewTextBoxColumn,
            this.idcelulastrDataGridViewTextBoxColumn,
            this.dscelulaDataGridViewTextBoxColumn});
            this.gPesquisa.DataSource = this.BS_CadItens;
            this.gPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Location = new System.Drawing.Point(0, 148);
            this.gPesquisa.Name = "gPesquisa";
            this.gPesquisa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPesquisa.RowHeadersWidth = 23;
            this.gPesquisa.Size = new System.Drawing.Size(659, 187);
            this.gPesquisa.TabIndex = 1;
            this.gPesquisa.TabStop = false;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsProdutoDataGridViewTextBoxColumn
            // 
            this.dsProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsProdutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_Produto";
            this.dsProdutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsProdutoDataGridViewTextBoxColumn.Name = "dsProdutoDataGridViewTextBoxColumn";
            this.dsProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsProdutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // idalmoxStringDataGridViewTextBoxColumn
            // 
            this.idalmoxStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idalmoxStringDataGridViewTextBoxColumn.DataPropertyName = "Id_almoxString";
            this.idalmoxStringDataGridViewTextBoxColumn.HeaderText = "Id. Almox.";
            this.idalmoxStringDataGridViewTextBoxColumn.Name = "idalmoxStringDataGridViewTextBoxColumn";
            this.idalmoxStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.idalmoxStringDataGridViewTextBoxColumn.Width = 78;
            // 
            // dsalmoxDataGridViewTextBoxColumn
            // 
            this.dsalmoxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsalmoxDataGridViewTextBoxColumn.DataPropertyName = "Ds_almox";
            this.dsalmoxDataGridViewTextBoxColumn.HeaderText = "Almoxarifado";
            this.dsalmoxDataGridViewTextBoxColumn.Name = "dsalmoxDataGridViewTextBoxColumn";
            this.dsalmoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsalmoxDataGridViewTextBoxColumn.Width = 92;
            // 
            // idruaStringDataGridViewTextBoxColumn
            // 
            this.idruaStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idruaStringDataGridViewTextBoxColumn.DataPropertyName = "Id_ruaString";
            this.idruaStringDataGridViewTextBoxColumn.HeaderText = "Id. Rua";
            this.idruaStringDataGridViewTextBoxColumn.Name = "idruaStringDataGridViewTextBoxColumn";
            this.idruaStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.idruaStringDataGridViewTextBoxColumn.Width = 67;
            // 
            // dsruaDataGridViewTextBoxColumn
            // 
            this.dsruaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsruaDataGridViewTextBoxColumn.DataPropertyName = "Ds_rua";
            this.dsruaDataGridViewTextBoxColumn.HeaderText = "Rua";
            this.dsruaDataGridViewTextBoxColumn.Name = "dsruaDataGridViewTextBoxColumn";
            this.dsruaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsruaDataGridViewTextBoxColumn.Width = 52;
            // 
            // idsecaoStringDataGridViewTextBoxColumn
            // 
            this.idsecaoStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idsecaoStringDataGridViewTextBoxColumn.DataPropertyName = "Id_secaoString";
            this.idsecaoStringDataGridViewTextBoxColumn.HeaderText = "Id. Seção";
            this.idsecaoStringDataGridViewTextBoxColumn.Name = "idsecaoStringDataGridViewTextBoxColumn";
            this.idsecaoStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.idsecaoStringDataGridViewTextBoxColumn.Width = 78;
            // 
            // dssecaoDataGridViewTextBoxColumn
            // 
            this.dssecaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssecaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_secao";
            this.dssecaoDataGridViewTextBoxColumn.HeaderText = "Seção";
            this.dssecaoDataGridViewTextBoxColumn.Name = "dssecaoDataGridViewTextBoxColumn";
            this.dssecaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dssecaoDataGridViewTextBoxColumn.Width = 63;
            // 
            // idcelulastrDataGridViewTextBoxColumn
            // 
            this.idcelulastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcelulastrDataGridViewTextBoxColumn.DataPropertyName = "Id_celulastr";
            this.idcelulastrDataGridViewTextBoxColumn.HeaderText = "Id. Celula";
            this.idcelulastrDataGridViewTextBoxColumn.Name = "idcelulastrDataGridViewTextBoxColumn";
            this.idcelulastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcelulastrDataGridViewTextBoxColumn.Width = 76;
            // 
            // dscelulaDataGridViewTextBoxColumn
            // 
            this.dscelulaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscelulaDataGridViewTextBoxColumn.DataPropertyName = "Ds_celula";
            this.dscelulaDataGridViewTextBoxColumn.HeaderText = "Celula";
            this.dscelulaDataGridViewTextBoxColumn.Name = "dscelulaDataGridViewTextBoxColumn";
            this.dscelulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscelulaDataGridViewTextBoxColumn.Width = 61;
            // 
            // BN_CadItens
            // 
            this.BN_CadItens.AddNewItem = null;
            this.BN_CadItens.BindingSource = this.BS_CadItens;
            this.BN_CadItens.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadItens.DeleteItem = null;
            this.BN_CadItens.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadItens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadItens.Location = new System.Drawing.Point(0, 335);
            this.BN_CadItens.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadItens.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadItens.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadItens.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadItens.Name = "BN_CadItens";
            this.BN_CadItens.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadItens.Size = new System.Drawing.Size(659, 25);
            this.BN_CadItens.TabIndex = 2;
            this.BN_CadItens.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
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
            // bb_cdProduto
            // 
            this.bb_cdProduto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cdProduto.Enabled = false;
            this.bb_cdProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_cdProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cdProduto.Image = ((System.Drawing.Image)(resources.GetObject("bb_cdProduto.Image")));
            this.bb_cdProduto.Location = new System.Drawing.Point(151, 4);
            this.bb_cdProduto.Name = "bb_cdProduto";
            this.bb_cdProduto.Size = new System.Drawing.Size(32, 20);
            this.bb_cdProduto.TabIndex = 2;
            this.bb_cdProduto.UseVisualStyleBackColor = false;
            this.bb_cdProduto.Click += new System.EventHandler(this.bb_cdProduto_Click);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Ds_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(185, 4);
            this.ds_produto.MaxLength = 20;
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(447, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 4;
            this.ds_produto.TextOld = null;
            this.ds_produto.TextChanged += new System.EventHandler(this.ds_produto_TextChanged);
            // 
            // TFCadItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadItens";
            this.Text = "Cadastro de Itens";
            this.Load += new System.EventHandler(this.TFCadItens_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadItens_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadItens)).EndInit();
            this.BN_CadItens.ResumeLayout(false);
            this.BN_CadItens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_celula;
        private Componentes.EditDefault ds_secao;
        private Componentes.EditDefault ds_rua;
        private Componentes.EditDefault ds_almox;
        private Componentes.EditDefault id_celula;
        private Componentes.EditDefault id_secao;
        private Componentes.EditDefault id_rua;
        private Componentes.EditDefault id_almox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button bb_celula;
        public System.Windows.Forms.Button bb_secao;
        public System.Windows.Forms.Button bb_rua;
        public System.Windows.Forms.Button bb_almox;
        private System.Windows.Forms.BindingNavigator BN_CadItens;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gPesquisa;
        private System.Windows.Forms.BindingSource BS_CadItens;
        private Componentes.EditDefault ds_produto;
        public System.Windows.Forms.Button bb_cdProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlanctoStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idalmoxStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsalmoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idruaStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsruaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsecaoStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssecaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcelulastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscelulaDataGridViewTextBoxColumn;
    }
}
