namespace Balanca
{
    partial class TFItensNfPesagem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensNfPesagem));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cd_unidest = new Componentes.EditDefault(this.components);
            this.bsNFItens = new System.Windows.Forms.BindingSource(this.components);
            this.sigla_unidvalor = new Componentes.EditDefault(this.components);
            this.bb_unidade = new System.Windows.Forms.Button();
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.cd_unidade = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_produto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nr_pedido = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_pedidoitem = new System.Windows.Forms.Button();
            this.ID_PedidoItem = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.sigla_unidvalor1 = new Componentes.EditDefault(this.components);
            this.vl_basecalc = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.vl_icms = new Componentes.EditFloat(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.qtd_nota = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNFItens)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basecalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_nota)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cd_unidest);
            this.pDados.Controls.Add(this.sigla_unidvalor);
            this.pDados.Controls.Add(this.bb_unidade);
            this.pDados.Controls.Add(this.ds_unidade);
            this.pDados.Controls.Add(this.cd_unidade);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nr_pedido);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_pedidoitem);
            this.pDados.Controls.Add(this.ID_PedidoItem);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Font = null;
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            // 
            // cd_unidest
            // 
            this.cd_unidest.AccessibleDescription = null;
            this.cd_unidest.AccessibleName = null;
            resources.ApplyResources(this.cd_unidest, "cd_unidest");
            this.cd_unidest.BackColor = System.Drawing.Color.White;
            this.cd_unidest.BackgroundImage = null;
            this.cd_unidest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Cd_UnidEstoque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidest.Font = null;
            this.cd_unidest.Name = "cd_unidest";
            this.cd_unidest.NM_Alias = "a";
            this.cd_unidest.NM_Campo = "cd_unidade";
            this.cd_unidest.NM_CampoBusca = "cd_unidade";
            this.cd_unidest.NM_Param = "@P_NR_PEDIDO";
            this.cd_unidest.QTD_Zero = 0;
            this.cd_unidest.ST_AutoInc = false;
            this.cd_unidest.ST_DisableAuto = false;
            this.cd_unidest.ST_Float = false;
            this.cd_unidest.ST_Gravar = false;
            this.cd_unidest.ST_Int = false;
            this.cd_unidest.ST_LimpaCampo = true;
            this.cd_unidest.ST_NotNull = false;
            this.cd_unidest.ST_PrimaryKey = false;
            // 
            // bsNFItens
            // 
            this.bsNFItens.DataSource = typeof(CamadaDados.Balanca.TList_RegLanPesagemProduto);
            // 
            // sigla_unidvalor
            // 
            this.sigla_unidvalor.AccessibleDescription = null;
            this.sigla_unidvalor.AccessibleName = null;
            resources.ApplyResources(this.sigla_unidvalor, "sigla_unidvalor");
            this.sigla_unidvalor.BackColor = System.Drawing.Color.White;
            this.sigla_unidvalor.BackgroundImage = null;
            this.sigla_unidvalor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidvalor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Sigla_unidvalor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidvalor.Font = null;
            this.sigla_unidvalor.Name = "sigla_unidvalor";
            this.sigla_unidvalor.NM_Alias = "a";
            this.sigla_unidvalor.NM_Campo = "sigla_unidade";
            this.sigla_unidvalor.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidvalor.NM_Param = "@P_NR_PEDIDO";
            this.sigla_unidvalor.QTD_Zero = 0;
            this.sigla_unidvalor.ST_AutoInc = false;
            this.sigla_unidvalor.ST_DisableAuto = false;
            this.sigla_unidvalor.ST_Float = false;
            this.sigla_unidvalor.ST_Gravar = false;
            this.sigla_unidvalor.ST_Int = false;
            this.sigla_unidvalor.ST_LimpaCampo = true;
            this.sigla_unidvalor.ST_NotNull = false;
            this.sigla_unidvalor.ST_PrimaryKey = false;
            // 
            // bb_unidade
            // 
            this.bb_unidade.AccessibleDescription = null;
            this.bb_unidade.AccessibleName = null;
            resources.ApplyResources(this.bb_unidade, "bb_unidade");
            this.bb_unidade.BackColor = System.Drawing.SystemColors.Control;
            this.bb_unidade.BackgroundImage = null;
            this.bb_unidade.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_unidade.Font = null;
            this.bb_unidade.Name = "bb_unidade";
            this.bb_unidade.UseVisualStyleBackColor = false;
            this.bb_unidade.Click += new System.EventHandler(this.bb_unidade_Click);
            // 
            // ds_unidade
            // 
            this.ds_unidade.AccessibleDescription = null;
            this.ds_unidade.AccessibleName = null;
            resources.ApplyResources(this.ds_unidade, "ds_unidade");
            this.ds_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade.BackgroundImage = null;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Ds_unidvalor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidade.Font = null;
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "a";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_DS_PRODUTO";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            // 
            // cd_unidade
            // 
            this.cd_unidade.AccessibleDescription = null;
            this.cd_unidade.AccessibleName = null;
            resources.ApplyResources(this.cd_unidade, "cd_unidade");
            this.cd_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade.BackgroundImage = null;
            this.cd_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Cd_UnidValor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidade.Font = null;
            this.cd_unidade.Name = "cd_unidade";
            this.cd_unidade.NM_Alias = "a";
            this.cd_unidade.NM_Campo = "cd_unidade";
            this.cd_unidade.NM_CampoBusca = "cd_unidade";
            this.cd_unidade.NM_Param = "@P_CD_PRODUTO";
            this.cd_unidade.QTD_Zero = 0;
            this.cd_unidade.ST_AutoInc = false;
            this.cd_unidade.ST_DisableAuto = false;
            this.cd_unidade.ST_Float = false;
            this.cd_unidade.ST_Gravar = true;
            this.cd_unidade.ST_Int = false;
            this.cd_unidade.ST_LimpaCampo = true;
            this.cd_unidade.ST_NotNull = true;
            this.cd_unidade.ST_PrimaryKey = false;
            this.cd_unidade.Leave += new System.EventHandler(this.cd_unidade_Leave);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // bb_produto
            // 
            this.bb_produto.AccessibleDescription = null;
            this.bb_produto.AccessibleName = null;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.BackgroundImage = null;
            this.bb_produto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_produto.Font = null;
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // nr_pedido
            // 
            this.nr_pedido.AccessibleDescription = null;
            this.nr_pedido.AccessibleName = null;
            resources.ApplyResources(this.nr_pedido, "nr_pedido");
            this.nr_pedido.BackColor = System.Drawing.Color.White;
            this.nr_pedido.BackgroundImage = null;
            this.nr_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Nr_pedidostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_pedido.Font = null;
            this.nr_pedido.Name = "nr_pedido";
            this.nr_pedido.NM_Alias = "a";
            this.nr_pedido.NM_Campo = "NR_Pedido";
            this.nr_pedido.NM_CampoBusca = "NR_Pedido";
            this.nr_pedido.NM_Param = "@P_NR_PEDIDO";
            this.nr_pedido.QTD_Zero = 0;
            this.nr_pedido.ST_AutoInc = false;
            this.nr_pedido.ST_DisableAuto = false;
            this.nr_pedido.ST_Float = false;
            this.nr_pedido.ST_Gravar = false;
            this.nr_pedido.ST_Int = false;
            this.nr_pedido.ST_LimpaCampo = true;
            this.nr_pedido.ST_NotNull = false;
            this.nr_pedido.ST_PrimaryKey = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Font = null;
            this.label3.Name = "label3";
            // 
            // bb_pedidoitem
            // 
            this.bb_pedidoitem.AccessibleDescription = null;
            this.bb_pedidoitem.AccessibleName = null;
            resources.ApplyResources(this.bb_pedidoitem, "bb_pedidoitem");
            this.bb_pedidoitem.BackColor = System.Drawing.SystemColors.Control;
            this.bb_pedidoitem.BackgroundImage = null;
            this.bb_pedidoitem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_pedidoitem.Font = null;
            this.bb_pedidoitem.Name = "bb_pedidoitem";
            this.bb_pedidoitem.UseVisualStyleBackColor = false;
            this.bb_pedidoitem.Click += new System.EventHandler(this.bb_pedidoitem_Click);
            // 
            // ID_PedidoItem
            // 
            this.ID_PedidoItem.AccessibleDescription = null;
            this.ID_PedidoItem.AccessibleName = null;
            resources.ApplyResources(this.ID_PedidoItem, "ID_PedidoItem");
            this.ID_PedidoItem.BackColor = System.Drawing.Color.White;
            this.ID_PedidoItem.BackgroundImage = null;
            this.ID_PedidoItem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_PedidoItem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Id_PedidoItemStr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_PedidoItem.Font = null;
            this.ID_PedidoItem.Name = "ID_PedidoItem";
            this.ID_PedidoItem.NM_Alias = "a";
            this.ID_PedidoItem.NM_Campo = "ID_PedidoItem";
            this.ID_PedidoItem.NM_CampoBusca = "ID_PedidoItem";
            this.ID_PedidoItem.NM_Param = "@P_ID_PEDIDOITEM";
            this.ID_PedidoItem.QTD_Zero = 0;
            this.ID_PedidoItem.ST_AutoInc = false;
            this.ID_PedidoItem.ST_DisableAuto = false;
            this.ID_PedidoItem.ST_Float = false;
            this.ID_PedidoItem.ST_Gravar = true;
            this.ID_PedidoItem.ST_Int = false;
            this.ID_PedidoItem.ST_LimpaCampo = true;
            this.ID_PedidoItem.ST_NotNull = false;
            this.ID_PedidoItem.ST_PrimaryKey = false;
            this.ID_PedidoItem.Leave += new System.EventHandler(this.ID_PedidoItem_Leave);
            // 
            // ds_produto
            // 
            this.ds_produto.AccessibleDescription = null;
            this.ds_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BackgroundImage = null;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Font = null;
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "a";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // cd_produto
            // 
            this.cd_produto.AccessibleDescription = null;
            this.cd_produto.AccessibleName = null;
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BackgroundImage = null;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = null;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "b";
            this.cd_produto.NM_Campo = "CD_Produto";
            this.cd_produto.NM_CampoBusca = "CD_Produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // label14
            // 
            this.label14.AccessibleDescription = null;
            this.label14.AccessibleName = null;
            resources.ApplyResources(this.label14, "label14");
            this.label14.Font = null;
            this.label14.Name = "label14";
            // 
            // panelDados1
            // 
            this.panelDados1.AccessibleDescription = null;
            this.panelDados1.AccessibleName = null;
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BackgroundImage = null;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.sigla_unidvalor1);
            this.panelDados1.Controls.Add(this.vl_basecalc);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.vl_unitario);
            this.panelDados1.Controls.Add(this.vl_icms);
            this.panelDados1.Controls.Add(this.vl_subtotal);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.qtd_nota);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // sigla_unidvalor1
            // 
            this.sigla_unidvalor1.AccessibleDescription = null;
            this.sigla_unidvalor1.AccessibleName = null;
            resources.ApplyResources(this.sigla_unidvalor1, "sigla_unidvalor1");
            this.sigla_unidvalor1.BackColor = System.Drawing.Color.White;
            this.sigla_unidvalor1.BackgroundImage = null;
            this.sigla_unidvalor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidvalor1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsNFItens, "Sigla_unidvalor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidvalor1.Font = null;
            this.sigla_unidvalor1.Name = "sigla_unidvalor1";
            this.sigla_unidvalor1.NM_Alias = "a";
            this.sigla_unidvalor1.NM_Campo = "sigla_unidade";
            this.sigla_unidvalor1.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidvalor1.NM_Param = "@P_NR_PEDIDO";
            this.sigla_unidvalor1.QTD_Zero = 0;
            this.sigla_unidvalor1.ST_AutoInc = false;
            this.sigla_unidvalor1.ST_DisableAuto = false;
            this.sigla_unidvalor1.ST_Float = false;
            this.sigla_unidvalor1.ST_Gravar = false;
            this.sigla_unidvalor1.ST_Int = false;
            this.sigla_unidvalor1.ST_LimpaCampo = true;
            this.sigla_unidvalor1.ST_NotNull = false;
            this.sigla_unidvalor1.ST_PrimaryKey = false;
            // 
            // vl_basecalc
            // 
            this.vl_basecalc.AccessibleDescription = null;
            this.vl_basecalc.AccessibleName = null;
            resources.ApplyResources(this.vl_basecalc, "vl_basecalc");
            this.vl_basecalc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsNFItens, "Vl_basecalc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_basecalc.DecimalPlaces = 2;
            this.vl_basecalc.Font = null;
            this.vl_basecalc.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_basecalc.Name = "vl_basecalc";
            this.vl_basecalc.NM_Alias = "a";
            this.vl_basecalc.NM_Campo = "vl_basecalc";
            this.vl_basecalc.NM_Param = "@P_VL_BASECALC";
            this.vl_basecalc.Operador = "";
            this.vl_basecalc.ST_AutoInc = false;
            this.vl_basecalc.ST_DisableAuto = false;
            this.vl_basecalc.ST_Gravar = true;
            this.vl_basecalc.ST_LimparCampo = true;
            this.vl_basecalc.ST_NotNull = false;
            this.vl_basecalc.ST_PrimaryKey = false;
            // 
            // label8
            // 
            this.label8.AccessibleDescription = null;
            this.label8.AccessibleName = null;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // vl_unitario
            // 
            this.vl_unitario.AccessibleDescription = null;
            this.vl_unitario.AccessibleName = null;
            resources.ApplyResources(this.vl_unitario, "vl_unitario");
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsNFItens, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 5;
            this.vl_unitario.Font = null;
            this.vl_unitario.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "a";
            this.vl_unitario.NM_Campo = "vl_unitario";
            this.vl_unitario.NM_Param = "@P_VL_UNITARIO";
            this.vl_unitario.Operador = "";
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = true;
            this.vl_unitario.ST_PrimaryKey = false;
            // 
            // vl_icms
            // 
            this.vl_icms.AccessibleDescription = null;
            this.vl_icms.AccessibleName = null;
            resources.ApplyResources(this.vl_icms, "vl_icms");
            this.vl_icms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsNFItens, "Vl_icms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_icms.DecimalPlaces = 2;
            this.vl_icms.Font = null;
            this.vl_icms.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_icms.Name = "vl_icms";
            this.vl_icms.NM_Alias = "a";
            this.vl_icms.NM_Campo = "vl_icms";
            this.vl_icms.NM_Param = "@P_VL_ICMS";
            this.vl_icms.Operador = "";
            this.vl_icms.ST_AutoInc = false;
            this.vl_icms.ST_DisableAuto = false;
            this.vl_icms.ST_Gravar = true;
            this.vl_icms.ST_LimparCampo = true;
            this.vl_icms.ST_NotNull = false;
            this.vl_icms.ST_PrimaryKey = false;
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.AccessibleDescription = null;
            this.vl_subtotal.AccessibleName = null;
            resources.ApplyResources(this.vl_subtotal, "vl_subtotal");
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsNFItens, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Font = null;
            this.vl_subtotal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "a";
            this.vl_subtotal.NM_Campo = "vl_subtotal";
            this.vl_subtotal.NM_Param = "@P_VL_SUBTOTAL";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // qtd_nota
            // 
            this.qtd_nota.AccessibleDescription = null;
            this.qtd_nota.AccessibleName = null;
            resources.ApplyResources(this.qtd_nota, "qtd_nota");
            this.qtd_nota.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsNFItens, "Qtd_nota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_nota.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.qtd_nota.Name = "qtd_nota";
            this.qtd_nota.NM_Alias = "a";
            this.qtd_nota.NM_Campo = "qtd_nota";
            this.qtd_nota.NM_Param = "@P_QTD_NOTA";
            this.qtd_nota.Operador = "";
            this.qtd_nota.ST_AutoInc = false;
            this.qtd_nota.ST_DisableAuto = false;
            this.qtd_nota.ST_Gravar = true;
            this.qtd_nota.ST_LimparCampo = true;
            this.qtd_nota.ST_NotNull = false;
            this.qtd_nota.ST_PrimaryKey = false;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // TFItensNfPesagem
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensNfPesagem";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFItensNfPesagem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensNfPesagem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsNFItens)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basecalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_icms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_nota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_basecalc;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat vl_unitario;
        private Componentes.EditFloat vl_icms;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat qtd_nota;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bsNFItens;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nr_pedido;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ID_PedidoItem;
        private System.Windows.Forms.Button bb_pedidoitem;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault sigla_unidvalor1;
        private System.Windows.Forms.Button bb_unidade;
        private Componentes.EditDefault ds_unidade;
        private Componentes.EditDefault cd_unidade;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault sigla_unidvalor;
        private Componentes.EditDefault cd_unidest;
    }
}