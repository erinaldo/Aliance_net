namespace Locacao.Cadastros
{
    partial class TFAtualizaPreco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtualizaPreco));
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.bsPrecoItem = new System.Windows.Forms.BindingSource(this.components);
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.Nr_patrimonio = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cd_prodbusca = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.ds_prodbusca = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_tabpreco = new System.Windows.Forms.Button();
            this.cd_tabpreco = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.pProduto = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gAtualiza = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dstabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.pValor = new Componentes.PanelDados(this.components);
            this.vl_novopreco = new Componentes.EditFloat(this.components);
            this.bb_gravar = new System.Windows.Forms.Button();
            this.vl_precovenda = new Componentes.EditFloat(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrecoItem)).BeginInit();
            this.pFiltro.SuspendLayout();
            this.pProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAtualiza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pValor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_novopreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(984, 43);
            this.barraMenu.TabIndex = 5;
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
            this.tlpCentral.Controls.Add(this.pProduto, 0, 1);
            this.tlpCentral.Controls.Add(this.pValor, 0, 2);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tlpCentral.Size = new System.Drawing.Size(984, 492);
            this.tlpCentral.TabIndex = 6;
            // 
            // bsPrecoItem
            // 
            this.bsPrecoItem.DataSource = typeof(CamadaDados.Locacao.Cadastros.TList_CadPrecoItens);
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.Nr_patrimonio);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.cd_prodbusca);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(this.ds_prodbusca);
            this.pFiltro.Controls.Add(label7);
            this.pFiltro.Controls.Add(this.bb_grupo);
            this.pFiltro.Controls.Add(this.cd_grupo);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.ds_tabelapreco);
            this.pFiltro.Controls.Add(this.nm_empresa);
            this.pFiltro.Controls.Add(this.bb_tabpreco);
            this.pFiltro.Controls.Add(this.cd_tabpreco);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(974, 56);
            this.pFiltro.TabIndex = 0;
            // 
            // Nr_patrimonio
            // 
            this.Nr_patrimonio.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_patrimonio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_patrimonio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_patrimonio.Location = new System.Drawing.Point(830, 30);
            this.Nr_patrimonio.Name = "Nr_patrimonio";
            this.Nr_patrimonio.NM_Alias = "";
            this.Nr_patrimonio.NM_Campo = "";
            this.Nr_patrimonio.NM_CampoBusca = "";
            this.Nr_patrimonio.NM_Param = "";
            this.Nr_patrimonio.QTD_Zero = 0;
            this.Nr_patrimonio.Size = new System.Drawing.Size(127, 20);
            this.Nr_patrimonio.ST_AutoInc = false;
            this.Nr_patrimonio.ST_DisableAuto = true;
            this.Nr_patrimonio.ST_Float = false;
            this.Nr_patrimonio.ST_Gravar = true;
            this.Nr_patrimonio.ST_Int = false;
            this.Nr_patrimonio.ST_LimpaCampo = true;
            this.Nr_patrimonio.ST_NotNull = false;
            this.Nr_patrimonio.ST_PrimaryKey = false;
            this.Nr_patrimonio.TabIndex = 133;
            this.Nr_patrimonio.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(753, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 132;
            this.label6.Text = "Nº Patrimônio:";
            // 
            // cd_prodbusca
            // 
            this.cd_prodbusca.BackColor = System.Drawing.Color.White;
            this.cd_prodbusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_prodbusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_prodbusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_prodbusca.Location = new System.Drawing.Point(223, 29);
            this.cd_prodbusca.MaxLength = 4;
            this.cd_prodbusca.Name = "cd_prodbusca";
            this.cd_prodbusca.NM_Alias = "";
            this.cd_prodbusca.NM_Campo = "cd_produto";
            this.cd_prodbusca.NM_CampoBusca = "cd_produto";
            this.cd_prodbusca.NM_Param = "@P_CD_EMPRESA";
            this.cd_prodbusca.QTD_Zero = 0;
            this.cd_prodbusca.Size = new System.Drawing.Size(67, 20);
            this.cd_prodbusca.ST_AutoInc = false;
            this.cd_prodbusca.ST_DisableAuto = false;
            this.cd_prodbusca.ST_Float = false;
            this.cd_prodbusca.ST_Gravar = true;
            this.cd_prodbusca.ST_Int = false;
            this.cd_prodbusca.ST_LimpaCampo = true;
            this.cd_prodbusca.ST_NotNull = false;
            this.cd_prodbusca.ST_PrimaryKey = false;
            this.cd_prodbusca.TabIndex = 131;
            this.cd_prodbusca.TextOld = null;
            this.cd_prodbusca.Leave += new System.EventHandler(this.cd_prodbusca_Leave);
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(290, 30);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 130;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // ds_prodbusca
            // 
            this.ds_prodbusca.BackColor = System.Drawing.Color.White;
            this.ds_prodbusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_prodbusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_prodbusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_prodbusca.Location = new System.Drawing.Point(320, 29);
            this.ds_prodbusca.Name = "ds_prodbusca";
            this.ds_prodbusca.NM_Alias = "";
            this.ds_prodbusca.NM_Campo = "ds_produto";
            this.ds_prodbusca.NM_CampoBusca = "ds_produto";
            this.ds_prodbusca.NM_Param = "@P_CD_EMPRESA";
            this.ds_prodbusca.QTD_Zero = 0;
            this.ds_prodbusca.Size = new System.Drawing.Size(427, 20);
            this.ds_prodbusca.ST_AutoInc = false;
            this.ds_prodbusca.ST_DisableAuto = false;
            this.ds_prodbusca.ST_Float = false;
            this.ds_prodbusca.ST_Gravar = true;
            this.ds_prodbusca.ST_Int = false;
            this.ds_prodbusca.ST_LimpaCampo = true;
            this.ds_prodbusca.ST_NotNull = false;
            this.ds_prodbusca.ST_PrimaryKey = false;
            this.ds_prodbusca.TabIndex = 10;
            this.ds_prodbusca.TextOld = null;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(176, 32);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(47, 13);
            label7.TabIndex = 123;
            label7.Text = "Produto:";
            // 
            // bb_grupo
            // 
            this.bb_grupo.BackColor = System.Drawing.SystemColors.Control;
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(131, 29);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(28, 19);
            this.bb_grupo.TabIndex = 5;
            this.bb_grupo.UseVisualStyleBackColor = false;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.Color.White;
            this.cd_grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupo.Location = new System.Drawing.Point(63, 29);
            this.cd_grupo.MaxLength = 4;
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_EMPRESA";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(67, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = false;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.TabIndex = 4;
            this.cd_grupo.TextOld = null;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(18, 32);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 13);
            label4.TabIndex = 119;
            label4.Text = "Grupo:";
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Location = new System.Drawing.Point(692, 3);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabela";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabela";
            this.ds_tabelapreco.NM_Param = "@P_NM_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(265, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 116;
            this.ds_tabelapreco.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(165, 3);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(350, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 115;
            this.nm_empresa.TextOld = null;
            // 
            // bb_tabpreco
            // 
            this.bb_tabpreco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tabpreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabpreco.Image")));
            this.bb_tabpreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabpreco.Location = new System.Drawing.Point(658, 3);
            this.bb_tabpreco.Name = "bb_tabpreco";
            this.bb_tabpreco.Size = new System.Drawing.Size(28, 19);
            this.bb_tabpreco.TabIndex = 3;
            this.bb_tabpreco.UseVisualStyleBackColor = false;
            this.bb_tabpreco.Click += new System.EventHandler(this.bb_tabpreco_Click);
            // 
            // cd_tabpreco
            // 
            this.cd_tabpreco.BackColor = System.Drawing.Color.White;
            this.cd_tabpreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabpreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabpreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_tabpreco.Location = new System.Drawing.Point(590, 3);
            this.cd_tabpreco.MaxLength = 4;
            this.cd_tabpreco.Name = "cd_tabpreco";
            this.cd_tabpreco.NM_Alias = "";
            this.cd_tabpreco.NM_Campo = "id_tabela";
            this.cd_tabpreco.NM_CampoBusca = "id_tabela";
            this.cd_tabpreco.NM_Param = "@P_CD_EMPRESA";
            this.cd_tabpreco.QTD_Zero = 0;
            this.cd_tabpreco.Size = new System.Drawing.Size(67, 20);
            this.cd_tabpreco.ST_AutoInc = false;
            this.cd_tabpreco.ST_DisableAuto = false;
            this.cd_tabpreco.ST_Float = false;
            this.cd_tabpreco.ST_Gravar = true;
            this.cd_tabpreco.ST_Int = false;
            this.cd_tabpreco.ST_LimpaCampo = true;
            this.cd_tabpreco.ST_NotNull = false;
            this.cd_tabpreco.ST_PrimaryKey = false;
            this.cd_tabpreco.TabIndex = 2;
            this.cd_tabpreco.TextOld = null;
            this.cd_tabpreco.Leave += new System.EventHandler(this.cd_tabpreco_Leave);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(521, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 114;
            label1.Text = "Tab. Preço:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(131, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(63, 3);
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
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(6, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 111;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // pProduto
            // 
            this.pProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pProduto.Controls.Add(this.cbTodos);
            this.pProduto.Controls.Add(this.gAtualiza);
            this.pProduto.Controls.Add(this.bindingNavigator1);
            this.pProduto.Controls.Add(this.lblConciliacao);
            this.pProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pProduto.Location = new System.Drawing.Point(5, 69);
            this.pProduto.Name = "pProduto";
            this.pProduto.NM_ProcDeletar = "";
            this.pProduto.NM_ProcGravar = "";
            this.pProduto.Size = new System.Drawing.Size(974, 337);
            this.pProduto.TabIndex = 1;
            // 
            // cbTodos
            // 
            this.cbTodos.AutoSize = true;
            this.cbTodos.Location = new System.Drawing.Point(6, 23);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 69;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // gAtualiza
            // 
            this.gAtualiza.AllowUserToAddRows = false;
            this.gAtualiza.AllowUserToDeleteRows = false;
            this.gAtualiza.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAtualiza.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gAtualiza.AutoGenerateColumns = false;
            this.gAtualiza.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAtualiza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAtualiza.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAtualiza.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gAtualiza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAtualiza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.dstabelaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.vlprecoDataGridViewTextBoxColumn});
            this.gAtualiza.DataSource = this.bsPrecoItem;
            this.gAtualiza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAtualiza.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAtualiza.Location = new System.Drawing.Point(0, 19);
            this.gAtualiza.Name = "gAtualiza";
            this.gAtualiza.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAtualiza.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gAtualiza.RowHeadersWidth = 23;
            this.gAtualiza.Size = new System.Drawing.Size(970, 289);
            this.gAtualiza.TabIndex = 68;
            this.gAtualiza.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gAtualiza_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Selecionar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 63;
            // 
            // dstabelaDataGridViewTextBoxColumn
            // 
            this.dstabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstabelaDataGridViewTextBoxColumn.DataPropertyName = "Ds_tabela";
            this.dstabelaDataGridViewTextBoxColumn.HeaderText = "Tabela";
            this.dstabelaDataGridViewTextBoxColumn.Name = "dstabelaDataGridViewTextBoxColumn";
            this.dstabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstabelaDataGridViewTextBoxColumn.Width = 65;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nr_patrimonio";
            this.dataGridViewTextBoxColumn1.HeaderText = "Nº Patrimônio";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 96;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd.Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 85;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // vlprecoDataGridViewTextBoxColumn
            // 
            this.vlprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlprecoDataGridViewTextBoxColumn.DataPropertyName = "Vl_preco";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlprecoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vlprecoDataGridViewTextBoxColumn.HeaderText = "Vl.Preço";
            this.vlprecoDataGridViewTextBoxColumn.Name = "vlprecoDataGridViewTextBoxColumn";
            this.vlprecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlprecoDataGridViewTextBoxColumn.Width = 72;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsPrecoItem;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 308);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(970, 25);
            this.bindingNavigator1.TabIndex = 67;
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
            // lblConciliacao
            // 
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConciliacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConciliacao.Location = new System.Drawing.Point(0, 0);
            this.lblConciliacao.Name = "lblConciliacao";
            this.lblConciliacao.Size = new System.Drawing.Size(970, 19);
            this.lblConciliacao.TabIndex = 65;
            this.lblConciliacao.Text = "PRODUTOS COM PREÇO PARA ATUALIZAR";
            this.lblConciliacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pValor
            // 
            this.pValor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pValor.Controls.Add(this.vl_novopreco);
            this.pValor.Controls.Add(label5);
            this.pValor.Controls.Add(this.bb_gravar);
            this.pValor.Controls.Add(this.vl_precovenda);
            this.pValor.Controls.Add(label3);
            this.pValor.Controls.Add(this.ds_produto);
            this.pValor.Controls.Add(label2);
            this.pValor.Controls.Add(this.cd_produto);
            this.pValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pValor.Location = new System.Drawing.Point(5, 414);
            this.pValor.Name = "pValor";
            this.pValor.NM_ProcDeletar = "";
            this.pValor.NM_ProcGravar = "";
            this.pValor.Size = new System.Drawing.Size(974, 73);
            this.pValor.TabIndex = 0;
            // 
            // vl_novopreco
            // 
            this.vl_novopreco.DecimalPlaces = 3;
            this.vl_novopreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_novopreco.Location = new System.Drawing.Point(168, 40);
            this.vl_novopreco.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_novopreco.Name = "vl_novopreco";
            this.vl_novopreco.NM_Alias = "";
            this.vl_novopreco.NM_Campo = "";
            this.vl_novopreco.NM_Param = "";
            this.vl_novopreco.Operador = "";
            this.vl_novopreco.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_novopreco.Size = new System.Drawing.Size(108, 26);
            this.vl_novopreco.ST_AutoInc = false;
            this.vl_novopreco.ST_DisableAuto = false;
            this.vl_novopreco.ST_Gravar = true;
            this.vl_novopreco.ST_LimparCampo = true;
            this.vl_novopreco.ST_NotNull = false;
            this.vl_novopreco.ST_PrimaryKey = false;
            this.vl_novopreco.TabIndex = 120;
            this.vl_novopreco.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(165, 24);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.TabIndex = 121;
            label5.Text = "Novo Preço:";
            // 
            // bb_gravar
            // 
            this.bb_gravar.BackColor = System.Drawing.SystemColors.Control;
            this.bb_gravar.Location = new System.Drawing.Point(282, 28);
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(81, 37);
            this.bb_gravar.TabIndex = 1;
            this.bb_gravar.Text = "GRAVAR";
            this.bb_gravar.UseVisualStyleBackColor = false;
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // vl_precovenda
            // 
            this.vl_precovenda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPrecoItem, "Vl_preco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_precovenda.DecimalPlaces = 3;
            this.vl_precovenda.Enabled = false;
            this.vl_precovenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_precovenda.Location = new System.Drawing.Point(63, 45);
            this.vl_precovenda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_precovenda.Name = "vl_precovenda";
            this.vl_precovenda.NM_Alias = "";
            this.vl_precovenda.NM_Campo = "";
            this.vl_precovenda.NM_Param = "";
            this.vl_precovenda.Operador = "";
            this.vl_precovenda.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_precovenda.Size = new System.Drawing.Size(97, 20);
            this.vl_precovenda.ST_AutoInc = false;
            this.vl_precovenda.ST_DisableAuto = false;
            this.vl_precovenda.ST_Gravar = false;
            this.vl_precovenda.ST_LimparCampo = true;
            this.vl_precovenda.ST_NotNull = false;
            this.vl_precovenda.ST_PrimaryKey = false;
            this.vl_precovenda.TabIndex = 0;
            this.vl_precovenda.ThousandsSeparator = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(60, 29);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 13);
            label3.TabIndex = 119;
            label3.Text = "Preço Atual";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoItem, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(159, 3);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "nm_empresa";
            this.ds_produto.NM_CampoBusca = "nm_empresa";
            this.ds_produto.NM_Param = "@P_NM_EMPRESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(466, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 118;
            this.ds_produto.TextOld = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(8, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 117;
            label2.Text = "Produto:";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPrecoItem, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(61, 3);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "nm_empresa";
            this.cd_produto.NM_CampoBusca = "nm_empresa";
            this.cd_produto.NM_Param = "@P_NM_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(96, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 116;
            this.cd_produto.TextOld = null;
            // 
            // TFAtualizaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 535);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFAtualizaPreco";
            this.ShowInTaskbar = false;
            this.Text = "Atualização de Preço";
            this.Load += new System.EventHandler(this.TFAtualizaPreco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtualizaPreco_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPrecoItem)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pProduto.ResumeLayout(false);
            this.pProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAtualiza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pValor.ResumeLayout(false);
            this.pValor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_novopreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.EditDefault cd_prodbusca;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault ds_prodbusca;
        private System.Windows.Forms.Button bb_grupo;
        private Componentes.EditDefault cd_grupo;
        private Componentes.EditDefault ds_tabelapreco;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_tabpreco;
        private Componentes.EditDefault cd_tabpreco;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.PanelDados pProduto;
        private Componentes.DataGridDefault gAtualiza;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label lblConciliacao;
        private Componentes.PanelDados pValor;
        private Componentes.EditFloat vl_novopreco;
        private System.Windows.Forms.Button bb_gravar;
        private Componentes.EditFloat vl_precovenda;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.BindingSource bsPrecoItem;
        private Componentes.CheckBoxDefault cbTodos;
        private Componentes.EditDefault Nr_patrimonio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlprecoDataGridViewTextBoxColumn;
    }
}