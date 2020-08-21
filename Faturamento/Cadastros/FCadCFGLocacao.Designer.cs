namespace Faturamento.Cadastros
{
    partial class TFCadCFGLocacao
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFGLocacao));
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bsCFGLocacao = new System.Windows.Forms.BindingSource(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.pc_multa = new Componentes.EditFloat(this.components);
            this.cb_tp_multa = new Componentes.ComboBoxDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtabelaprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstabelaprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdlocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dslocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtddiasdevolucaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcmultaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpmultaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd_diasdevolucao = new Componentes.EditFloat(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGLocacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_multa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_diasdevolucao)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.qtd_diasdevolucao);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.cb_tp_multa);
            this.pDados.Controls.Add(this.pc_multa);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.cd_tabelapreco);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Size = new System.Drawing.Size(662, 152);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(674, 421);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(666, 395);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(31, 7);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 40;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(22, 83);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(60, 13);
            label1.TabIndex = 44;
            label1.Text = " Tb Preço :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(35, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 48;
            label2.Text = "Produto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(46, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 52;
            label3.Text = "Local:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(235, 109);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(90, 13);
            label4.TabIndex = 56;
            label4.Text = "Percentual Multa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(4, 107);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 13);
            label5.TabIndex = 57;
            label5.Text = "Tipo de Multa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(464, 109);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(106, 13);
            label6.TabIndex = 59;
            label6.Text = "Qtd.Dias Devolução:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(90, 4);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsCFGLocacao
            // 
            this.bsCFGLocacao.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CFGLocacao);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(193, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(442, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 41;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(160, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.BackColor = System.Drawing.Color.White;
            this.cd_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco.Enabled = false;
            this.cd_tabelapreco.Location = new System.Drawing.Point(90, 79);
            this.cd_tabelapreco.MaxLength = 4;
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_CD_TABELAPRECO";
            this.cd_tabelapreco.QTD_Zero = 0;
            this.cd_tabelapreco.Size = new System.Drawing.Size(67, 20);
            this.cd_tabelapreco.ST_AutoInc = false;
            this.cd_tabelapreco.ST_DisableAuto = false;
            this.cd_tabelapreco.ST_Float = false;
            this.cd_tabelapreco.ST_Gravar = true;
            this.cd_tabelapreco.ST_Int = false;
            this.cd_tabelapreco.ST_LimpaCampo = true;
            this.cd_tabelapreco.ST_NotNull = false;
            this.cd_tabelapreco.ST_PrimaryKey = false;
            this.cd_tabelapreco.TabIndex = 6;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Location = new System.Drawing.Point(193, 79);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(441, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 45;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(90, 28);
            this.cd_produto.MaxLength = 4;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(67, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(193, 29);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(442, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 49;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Enabled = false;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(160, 28);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.Color.White;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Enabled = false;
            this.cd_local.Location = new System.Drawing.Point(90, 54);
            this.cd_local.MaxLength = 4;
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_LOCAL";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(67, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = true;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 4;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(193, 53);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_LOCAL";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(442, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 53;
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            this.bb_local.Enabled = false;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(160, 54);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 5;
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // pc_multa
            // 
            this.pc_multa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCFGLocacao, "Pc_multa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_multa.DecimalPlaces = 2;
            this.pc_multa.Enabled = false;
            this.pc_multa.Location = new System.Drawing.Point(331, 105);
            this.pc_multa.Name = "pc_multa";
            this.pc_multa.NM_Alias = "";
            this.pc_multa.NM_Campo = "";
            this.pc_multa.NM_Param = "";
            this.pc_multa.Operador = "";
            this.pc_multa.Size = new System.Drawing.Size(68, 20);
            this.pc_multa.ST_AutoInc = false;
            this.pc_multa.ST_DisableAuto = false;
            this.pc_multa.ST_Gravar = true;
            this.pc_multa.ST_LimparCampo = true;
            this.pc_multa.ST_NotNull = false;
            this.pc_multa.ST_PrimaryKey = false;
            this.pc_multa.TabIndex = 9;
            this.pc_multa.ThousandsSeparator = true;
            // 
            // cb_tp_multa
            // 
            this.cb_tp_multa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCFGLocacao, "Tp_multa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_tp_multa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tp_multa.Enabled = false;
            this.cb_tp_multa.FormattingEnabled = true;
            this.cb_tp_multa.Location = new System.Drawing.Point(90, 104);
            this.cb_tp_multa.Name = "cb_tp_multa";
            this.cb_tp_multa.NM_Alias = "";
            this.cb_tp_multa.NM_Campo = "";
            this.cb_tp_multa.NM_Param = "";
            this.cb_tp_multa.Size = new System.Drawing.Size(106, 21);
            this.cb_tp_multa.ST_Gravar = true;
            this.cb_tp_multa.ST_LimparCampo = true;
            this.cb_tp_multa.ST_NotNull = false;
            this.cb_tp_multa.TabIndex = 8;
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
            this.cdtabelaprecoDataGridViewTextBoxColumn,
            this.dstabelaprecoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.cdlocalDataGridViewTextBoxColumn,
            this.dslocalDataGridViewTextBoxColumn,
            this.qtddiasdevolucaoDataGridViewTextBoxColumn,
            this.pcmultaDataGridViewTextBoxColumn,
            this.tpmultaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCFGLocacao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 152);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(662, 239);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd.Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdtabelaprecoDataGridViewTextBoxColumn
            // 
            this.cdtabelaprecoDataGridViewTextBoxColumn.DataPropertyName = "Cd_tabelapreco";
            this.cdtabelaprecoDataGridViewTextBoxColumn.HeaderText = "Cd.Tab Preço";
            this.cdtabelaprecoDataGridViewTextBoxColumn.Name = "cdtabelaprecoDataGridViewTextBoxColumn";
            this.cdtabelaprecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstabelaprecoDataGridViewTextBoxColumn
            // 
            this.dstabelaprecoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tabelapreco";
            this.dstabelaprecoDataGridViewTextBoxColumn.HeaderText = "Tab Preço";
            this.dstabelaprecoDataGridViewTextBoxColumn.Name = "dstabelaprecoDataGridViewTextBoxColumn";
            this.dstabelaprecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd.Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdlocalDataGridViewTextBoxColumn
            // 
            this.cdlocalDataGridViewTextBoxColumn.DataPropertyName = "Cd_local";
            this.cdlocalDataGridViewTextBoxColumn.HeaderText = "Cd.Local";
            this.cdlocalDataGridViewTextBoxColumn.Name = "cdlocalDataGridViewTextBoxColumn";
            this.cdlocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dslocalDataGridViewTextBoxColumn
            // 
            this.dslocalDataGridViewTextBoxColumn.DataPropertyName = "Ds_local";
            this.dslocalDataGridViewTextBoxColumn.HeaderText = "Local";
            this.dslocalDataGridViewTextBoxColumn.Name = "dslocalDataGridViewTextBoxColumn";
            this.dslocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtddiasdevolucaoDataGridViewTextBoxColumn
            // 
            this.qtddiasdevolucaoDataGridViewTextBoxColumn.DataPropertyName = "Qtd_diasdevolucao";
            this.qtddiasdevolucaoDataGridViewTextBoxColumn.HeaderText = "Qtd. Dias Devolucao";
            this.qtddiasdevolucaoDataGridViewTextBoxColumn.Name = "qtddiasdevolucaoDataGridViewTextBoxColumn";
            this.qtddiasdevolucaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pcmultaDataGridViewTextBoxColumn
            // 
            this.pcmultaDataGridViewTextBoxColumn.DataPropertyName = "Pc_multa";
            this.pcmultaDataGridViewTextBoxColumn.HeaderText = "Percentual Multa";
            this.pcmultaDataGridViewTextBoxColumn.Name = "pcmultaDataGridViewTextBoxColumn";
            this.pcmultaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpmultaDataGridViewTextBoxColumn
            // 
            this.tpmultaDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.tpmultaDataGridViewTextBoxColumn.HeaderText = "Tipo Multa";
            this.tpmultaDataGridViewTextBoxColumn.Name = "tpmultaDataGridViewTextBoxColumn";
            this.tpmultaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtd_diasdevolucao
            // 
            this.qtd_diasdevolucao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCFGLocacao, "Qtd_diasdevolucao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_diasdevolucao.Enabled = false;
            this.qtd_diasdevolucao.Location = new System.Drawing.Point(576, 104);
            this.qtd_diasdevolucao.Name = "qtd_diasdevolucao";
            this.qtd_diasdevolucao.NM_Alias = "";
            this.qtd_diasdevolucao.NM_Campo = "";
            this.qtd_diasdevolucao.NM_Param = "";
            this.qtd_diasdevolucao.Operador = "";
            this.qtd_diasdevolucao.Size = new System.Drawing.Size(58, 20);
            this.qtd_diasdevolucao.ST_AutoInc = false;
            this.qtd_diasdevolucao.ST_DisableAuto = false;
            this.qtd_diasdevolucao.ST_Gravar = true;
            this.qtd_diasdevolucao.ST_LimparCampo = true;
            this.qtd_diasdevolucao.ST_NotNull = false;
            this.qtd_diasdevolucao.ST_PrimaryKey = false;
            this.qtd_diasdevolucao.TabIndex = 10;
            this.qtd_diasdevolucao.ThousandsSeparator = true;
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tabelapreco.Enabled = false;
            this.bb_tabelapreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelapreco.Image")));
            this.bb_tabelapreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelapreco.Location = new System.Drawing.Point(160, 80);
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.Size = new System.Drawing.Size(28, 19);
            this.bb_tabelapreco.TabIndex = 7;
            this.bb_tabelapreco.UseVisualStyleBackColor = false;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // TFCadCFGLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 464);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCFGLocacao";
            this.Text = "Configuração de Locação";
            this.Load += new System.EventHandler(this.TFCadCFGLocacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCFGLocacao_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGLocacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_multa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_diasdevolucao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_tabelapreco;
        private Componentes.EditDefault ds_tabelapreco;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.ComboBoxDefault cb_tp_multa;
        private Componentes.EditFloat pc_multa;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCFGLocacao;
        private Componentes.EditFloat qtd_diasdevolucao;
        private System.Windows.Forms.Button bb_tabelapreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtabelaprecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstabelaprecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtddiasdevolucaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcmultaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpmultaDataGridViewTextBoxColumn;
    }
}