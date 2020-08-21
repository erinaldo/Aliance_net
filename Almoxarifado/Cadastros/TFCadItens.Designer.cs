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
            this.label3 = new System.Windows.Forms.Label();
            this.BS_CadItens = new System.Windows.Forms.BindingSource(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.id_lancto = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_lancto = new Componentes.EditData(this.components);
            this.id_almox = new Componentes.EditDefault(this.components);
            this.id_rua = new Componentes.EditDefault(this.components);
            this.id_secao = new Componentes.EditDefault(this.components);
            this.id_nivel = new Componentes.EditDefault(this.components);
            this.ds_almox = new Componentes.EditDefault(this.components);
            this.ds_rua = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.ds_nivel = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bb_id_almox = new System.Windows.Forms.Button();
            this.bb_id_rua = new System.Windows.Forms.Button();
            this.bb_id_secao = new System.Windows.Forms.Button();
            this.bb_id_nivel = new System.Windows.Forms.Button();
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.idlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pDados.Controls.Add(this.bb_id_nivel);
            this.pDados.Controls.Add(this.bb_id_secao);
            this.pDados.Controls.Add(this.bb_id_rua);
            this.pDados.Controls.Add(this.bb_id_almox);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_nivel);
            this.pDados.Controls.Add(this.ds_secao);
            this.pDados.Controls.Add(this.ds_rua);
            this.pDados.Controls.Add(this.ds_almox);
            this.pDados.Controls.Add(this.id_nivel);
            this.pDados.Controls.Add(this.id_secao);
            this.pDados.Controls.Add(this.id_rua);
            this.pDados.Controls.Add(this.id_almox);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.id_lancto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Size = new System.Drawing.Size(659, 163);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.BN_CadItens);
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Size = new System.Drawing.Size(663, 364);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadItens, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cód. Produto.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Id. Lancto.:";
            // 
            // BS_CadItens
            // 
            this.BS_CadItens.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadItens);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(114, 34);
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
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // id_lancto
            // 
            this.id_lancto.BackColor = System.Drawing.SystemColors.Window;
            this.id_lancto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_lanctoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_lancto.Enabled = false;
            this.id_lancto.Location = new System.Drawing.Point(114, 10);
            this.id_lancto.MaxLength = 5;
            this.id_lancto.Name = "id_lancto";
            this.id_lancto.NM_Alias = "a";
            this.id_lancto.NM_Campo = "id_lancto";
            this.id_lancto.NM_CampoBusca = "id_lancto";
            this.id_lancto.NM_Param = "@P_ID_LANCTO";
            this.id_lancto.QTD_Zero = 0;
            this.id_lancto.Size = new System.Drawing.Size(55, 20);
            this.id_lancto.ST_AutoInc = false;
            this.id_lancto.ST_DisableAuto = true;
            this.id_lancto.ST_Float = false;
            this.id_lancto.ST_Gravar = true;
            this.id_lancto.ST_Int = true;
            this.id_lancto.ST_LimpaCampo = true;
            this.id_lancto.ST_NotNull = true;
            this.id_lancto.ST_PrimaryKey = true;
            this.id_lancto.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Lancto.:";
            // 
            // dt_lancto
            // 
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Dt_lanctoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Enabled = false;
            this.dt_lancto.Location = new System.Drawing.Point(283, 8);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "a";
            this.dt_lancto.NM_Campo = "dt_lancto";
            this.dt_lancto.NM_CampoBusca = "dt_lancto";
            this.dt_lancto.NM_Param = "@P_DT_LANCTO";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(100, 20);
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = false;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 1;
            this.dt_lancto.Click += new System.EventHandler(this.dt_lancto_Click);
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.SystemColors.Window;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_almoxString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Enabled = false;
            this.id_almox.Location = new System.Drawing.Point(114, 57);
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
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 5;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // id_rua
            // 
            this.id_rua.BackColor = System.Drawing.SystemColors.Window;
            this.id_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_ruaString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_rua.Enabled = false;
            this.id_rua.Location = new System.Drawing.Point(114, 78);
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
            this.id_rua.ST_NotNull = true;
            this.id_rua.ST_PrimaryKey = false;
            this.id_rua.TabIndex = 8;
            this.id_rua.Leave += new System.EventHandler(this.id_rua_Leave);
            this.id_rua.Enter += new System.EventHandler(this.id_rua_Enter);
            // 
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_secaoString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(114, 99);
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
            this.id_secao.ST_NotNull = true;
            this.id_secao.ST_PrimaryKey = false;
            this.id_secao.TabIndex = 11;
            this.id_secao.Leave += new System.EventHandler(this.id_secao_Leave);
            this.id_secao.Enter += new System.EventHandler(this.id_secao_Enter);
            // 
            // id_nivel
            // 
            this.id_nivel.BackColor = System.Drawing.SystemColors.Window;
            this.id_nivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_nivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Id_nivelString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_nivel.Enabled = false;
            this.id_nivel.Location = new System.Drawing.Point(114, 120);
            this.id_nivel.MaxLength = 5;
            this.id_nivel.Name = "id_nivel";
            this.id_nivel.NM_Alias = "a";
            this.id_nivel.NM_Campo = "id_nivel";
            this.id_nivel.NM_CampoBusca = "id_nivel";
            this.id_nivel.NM_Param = "@P_ID_NIVEL";
            this.id_nivel.QTD_Zero = 0;
            this.id_nivel.Size = new System.Drawing.Size(55, 20);
            this.id_nivel.ST_AutoInc = false;
            this.id_nivel.ST_DisableAuto = false;
            this.id_nivel.ST_Float = false;
            this.id_nivel.ST_Gravar = true;
            this.id_nivel.ST_Int = true;
            this.id_nivel.ST_LimpaCampo = true;
            this.id_nivel.ST_NotNull = true;
            this.id_nivel.ST_PrimaryKey = false;
            this.id_nivel.TabIndex = 14;
            this.id_nivel.Leave += new System.EventHandler(this.id_nivel_Leave);
            // 
            // ds_almox
            // 
            this.ds_almox.BackColor = System.Drawing.SystemColors.Window;
            this.ds_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_almox.Enabled = false;
            this.ds_almox.Location = new System.Drawing.Point(204, 57);
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
            // 
            // ds_rua
            // 
            this.ds_rua.BackColor = System.Drawing.SystemColors.Window;
            this.ds_rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_rua.Enabled = false;
            this.ds_rua.Location = new System.Drawing.Point(204, 78);
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
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(204, 99);
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
            // 
            // ds_nivel
            // 
            this.ds_nivel.BackColor = System.Drawing.SystemColors.Window;
            this.ds_nivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_nivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "ds_nivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_nivel.Enabled = false;
            this.ds_nivel.Location = new System.Drawing.Point(204, 120);
            this.ds_nivel.MaxLength = 20;
            this.ds_nivel.Name = "ds_nivel";
            this.ds_nivel.NM_Alias = "";
            this.ds_nivel.NM_Campo = "ds_nivel";
            this.ds_nivel.NM_CampoBusca = "ds_nivel";
            this.ds_nivel.NM_Param = "";
            this.ds_nivel.QTD_Zero = 0;
            this.ds_nivel.Size = new System.Drawing.Size(447, 20);
            this.ds_nivel.ST_AutoInc = false;
            this.ds_nivel.ST_DisableAuto = false;
            this.ds_nivel.ST_Float = false;
            this.ds_nivel.ST_Gravar = false;
            this.ds_nivel.ST_Int = false;
            this.ds_nivel.ST_LimpaCampo = true;
            this.ds_nivel.ST_NotNull = false;
            this.ds_nivel.ST_PrimaryKey = false;
            this.ds_nivel.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Almoxarifado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(77, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Rua:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Seção:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Nível:";
            // 
            // bb_id_almox
            // 
            this.bb_id_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_id_almox.Enabled = false;
            this.bb_id_almox.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_id_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_id_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_id_almox.Image")));
            this.bb_id_almox.Location = new System.Drawing.Point(170, 57);
            this.bb_id_almox.Name = "bb_id_almox";
            this.bb_id_almox.Size = new System.Drawing.Size(32, 20);
            this.bb_id_almox.TabIndex = 6;
            this.bb_id_almox.UseVisualStyleBackColor = false;
            this.bb_id_almox.Click += new System.EventHandler(this.bb_id_almox_Click);
            // 
            // bb_id_rua
            // 
            this.bb_id_rua.BackColor = System.Drawing.SystemColors.Control;
            this.bb_id_rua.Enabled = false;
            this.bb_id_rua.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_id_rua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_id_rua.Image = ((System.Drawing.Image)(resources.GetObject("bb_id_rua.Image")));
            this.bb_id_rua.Location = new System.Drawing.Point(170, 78);
            this.bb_id_rua.Name = "bb_id_rua";
            this.bb_id_rua.Size = new System.Drawing.Size(32, 20);
            this.bb_id_rua.TabIndex = 9;
            this.bb_id_rua.UseVisualStyleBackColor = false;
            this.bb_id_rua.Click += new System.EventHandler(this.bb_id_rua_Click);
            // 
            // bb_id_secao
            // 
            this.bb_id_secao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_id_secao.Enabled = false;
            this.bb_id_secao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_id_secao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_id_secao.Image = ((System.Drawing.Image)(resources.GetObject("bb_id_secao.Image")));
            this.bb_id_secao.Location = new System.Drawing.Point(170, 99);
            this.bb_id_secao.Name = "bb_id_secao";
            this.bb_id_secao.Size = new System.Drawing.Size(32, 20);
            this.bb_id_secao.TabIndex = 12;
            this.bb_id_secao.UseVisualStyleBackColor = false;
            this.bb_id_secao.Click += new System.EventHandler(this.bb_id_secao_Click);
            // 
            // bb_id_nivel
            // 
            this.bb_id_nivel.BackColor = System.Drawing.SystemColors.Control;
            this.bb_id_nivel.Enabled = false;
            this.bb_id_nivel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_id_nivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_id_nivel.Image = ((System.Drawing.Image)(resources.GetObject("bb_id_nivel.Image")));
            this.bb_id_nivel.Location = new System.Drawing.Point(170, 120);
            this.bb_id_nivel.Name = "bb_id_nivel";
            this.bb_id_nivel.Size = new System.Drawing.Size(32, 20);
            this.bb_id_nivel.TabIndex = 15;
            this.bb_id_nivel.UseVisualStyleBackColor = false;
            this.bb_id_nivel.Click += new System.EventHandler(this.bb_id_nivel_Click);
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
            this.idlanctoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dtlanctoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gPesquisa.DataSource = this.BS_CadItens;
            this.gPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Location = new System.Drawing.Point(0, 163);
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
            this.gPesquisa.Size = new System.Drawing.Size(659, 197);
            this.gPesquisa.TabIndex = 1;
            this.gPesquisa.TabStop = false;
            // 
            // idlanctoDataGridViewTextBoxColumn
            // 
            this.idlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idlanctoDataGridViewTextBoxColumn.DataPropertyName = "Id_lancto";
            this.idlanctoDataGridViewTextBoxColumn.HeaderText = "Id. Lançamento";
            this.idlanctoDataGridViewTextBoxColumn.Name = "idlanctoDataGridViewTextBoxColumn";
            this.idlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idlanctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Código Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 97;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_Produto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dtlanctoDataGridViewTextBoxColumn
            // 
            this.dtlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_lancto";
            this.dtlanctoDataGridViewTextBoxColumn.HeaderText = "Data Lançamento";
            this.dtlanctoDataGridViewTextBoxColumn.Name = "dtlanctoDataGridViewTextBoxColumn";
            this.dtlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctoDataGridViewTextBoxColumn.Width = 107;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ds_almox";
            this.dataGridViewTextBoxColumn2.HeaderText = "Almoxarifado";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 92;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ds_rua";
            this.dataGridViewTextBoxColumn3.HeaderText = "Rua";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 52;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ds_secao";
            this.dataGridViewTextBoxColumn4.HeaderText = "Seção";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 63;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ds_nivel";
            this.dataGridViewTextBoxColumn5.HeaderText = "Nível";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 58;
            // 
            // BN_CadItens
            // 
            this.BN_CadItens.AddNewItem = null;
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bb_cdProduto
            // 
            this.bb_cdProduto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_cdProduto.Enabled = false;
            this.bb_cdProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_cdProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cdProduto.Image = ((System.Drawing.Image)(resources.GetObject("bb_cdProduto.Image")));
            this.bb_cdProduto.Location = new System.Drawing.Point(170, 34);
            this.bb_cdProduto.Name = "bb_cdProduto";
            this.bb_cdProduto.Size = new System.Drawing.Size(32, 20);
            this.bb_cdProduto.TabIndex = 3;
            this.bb_cdProduto.UseVisualStyleBackColor = false;
            this.bb_cdProduto.Click += new System.EventHandler(this.bb_cdProduto_Click);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadItens, "Ds_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(204, 34);
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
            // 
            // TFCadItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFCadItens";
            this.Text = "Cadastro de Itens";
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

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault id_lancto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_nivel;
        private Componentes.EditDefault ds_secao;
        private Componentes.EditDefault ds_rua;
        private Componentes.EditDefault ds_almox;
        private Componentes.EditDefault id_nivel;
        private Componentes.EditDefault id_secao;
        private Componentes.EditDefault id_rua;
        private Componentes.EditDefault id_almox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button bb_id_nivel;
        public System.Windows.Forms.Button bb_id_secao;
        public System.Windows.Forms.Button bb_id_rua;
        public System.Windows.Forms.Button bb_id_almox;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
