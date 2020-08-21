namespace Commoditties
{
    partial class TFItensContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensContrato));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pPedido = new Componentes.PanelDados(this.components);
            this.cd_unidestoque = new Componentes.EditDefault(this.components);
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.bsPedido = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.Sub_Total = new Componentes.EditFloat(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.Vl_Unitario = new Componentes.EditFloat(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.SG_UniQTD = new Componentes.EditDefault(this.components);
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.DS_Variedade = new Componentes.EditDefault(this.components);
            this.BB_Variedade = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.CD_Variedade = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.rg_frete = new Componentes.RadioGroup(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.label68 = new System.Windows.Forms.Label();
            this.Vl_Frete = new Componentes.EditFloat(this.components);
            this.rgFretePorConta = new Componentes.RadioGroup(this.components);
            this.rbDestinatario = new Componentes.RadioButtonDefault(this.components);
            this.rbEmitente = new Componentes.RadioButtonDefault(this.components);
            this.Sigla_Moeda = new Componentes.EditDefault(this.components);
            this.DS_Moeda = new Componentes.EditDefault(this.components);
            this.BB_Moeda = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.CD_Moeda = new Componentes.EditDefault(this.components);
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.TP_Mov = new Componentes.EditDefault(this.components);
            this.DS_CFGPedido = new Componentes.EditDefault(this.components);
            this.BB_CFGPedido = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.CFG_Pedido = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.Nr_PedidoOrigem = new Componentes.EditDefault(this.components);
            this.DT_Pedido = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).BeginInit();
            this.panelDados3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.rg_frete.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Frete)).BeginInit();
            this.rgFretePorConta.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pPedido
            // 
            this.pPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPedido.Controls.Add(this.cd_unidestoque);
            this.pPedido.Controls.Add(this.panelDados3);
            this.pPedido.Controls.Add(this.DS_Local);
            this.pPedido.Controls.Add(this.BB_Local);
            this.pPedido.Controls.Add(this.label4);
            this.pPedido.Controls.Add(this.CD_Local);
            this.pPedido.Controls.Add(this.DS_Unidade);
            this.pPedido.Controls.Add(this.BB_Unidade);
            this.pPedido.Controls.Add(this.label57);
            this.pPedido.Controls.Add(this.CD_Unidade);
            this.pPedido.Controls.Add(this.DS_Variedade);
            this.pPedido.Controls.Add(this.BB_Variedade);
            this.pPedido.Controls.Add(this.label56);
            this.pPedido.Controls.Add(this.CD_Variedade);
            this.pPedido.Controls.Add(this.DS_Produto);
            this.pPedido.Controls.Add(this.BB_Produto);
            this.pPedido.Controls.Add(this.label55);
            this.pPedido.Controls.Add(this.CD_Produto);
            this.pPedido.Controls.Add(this.rg_frete);
            this.pPedido.Controls.Add(this.Sigla_Moeda);
            this.pPedido.Controls.Add(this.DS_Moeda);
            this.pPedido.Controls.Add(this.BB_Moeda);
            this.pPedido.Controls.Add(this.label30);
            this.pPedido.Controls.Add(this.CD_Moeda);
            this.pPedido.Controls.Add(this.DS_Endereco);
            this.pPedido.Controls.Add(this.label3);
            this.pPedido.Controls.Add(this.CD_Endereco);
            this.pPedido.Controls.Add(this.NM_Clifor);
            this.pPedido.Controls.Add(this.label2);
            this.pPedido.Controls.Add(this.CD_Clifor);
            this.pPedido.Controls.Add(this.TP_Mov);
            this.pPedido.Controls.Add(this.DS_CFGPedido);
            this.pPedido.Controls.Add(this.BB_CFGPedido);
            this.pPedido.Controls.Add(this.label7);
            this.pPedido.Controls.Add(this.CFG_Pedido);
            this.pPedido.Controls.Add(this.label6);
            this.pPedido.Controls.Add(this.Nr_PedidoOrigem);
            this.pPedido.Controls.Add(this.DT_Pedido);
            this.pPedido.Controls.Add(this.label8);
            this.pPedido.Controls.Add(this.NM_Empresa);
            this.pPedido.Controls.Add(this.label1);
            this.pPedido.Controls.Add(this.CD_Empresa);
            resources.ApplyResources(this.pPedido, "pPedido");
            this.pPedido.Name = "pPedido";
            this.pPedido.NM_ProcDeletar = "";
            this.pPedido.NM_ProcGravar = "";
            // 
            // cd_unidestoque
            // 
            this.cd_unidestoque.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidestoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidestoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidestoque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_unidade_est", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_unidestoque, "cd_unidestoque");
            this.cd_unidestoque.Name = "cd_unidestoque";
            this.cd_unidestoque.NM_Alias = "";
            this.cd_unidestoque.NM_Campo = "cd_unidade";
            this.cd_unidestoque.NM_CampoBusca = "cd_unidade";
            this.cd_unidestoque.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.cd_unidestoque.QTD_Zero = 0;
            this.cd_unidestoque.ReadOnly = true;
            this.cd_unidestoque.ST_AutoInc = false;
            this.cd_unidestoque.ST_DisableAuto = false;
            this.cd_unidestoque.ST_Float = false;
            this.cd_unidestoque.ST_Gravar = false;
            this.cd_unidestoque.ST_Int = false;
            this.cd_unidestoque.ST_LimpaCampo = true;
            this.cd_unidestoque.ST_NotNull = false;
            this.cd_unidestoque.ST_PrimaryKey = false;
            this.cd_unidestoque.TextOld = null;
            // 
            // bsItens
            // 
            this.bsItens.DataMember = "Pedido_Itens";
            this.bsItens.DataSource = this.bsPedido;
            // 
            // bsPedido
            // 
            this.bsPedido.DataSource = typeof(CamadaDados.Faturamento.Pedido.TList_Pedido);
            // 
            // panelDados3
            // 
            this.panelDados3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.label5);
            this.panelDados3.Controls.Add(this.SG_Unidade_Estoque);
            this.panelDados3.Controls.Add(this.label9);
            this.panelDados3.Controls.Add(this.Sub_Total);
            this.panelDados3.Controls.Add(this.label13);
            this.panelDados3.Controls.Add(this.Vl_Unitario);
            this.panelDados3.Controls.Add(this.Quantidade);
            this.panelDados3.Controls.Add(this.label58);
            this.panelDados3.Controls.Add(this.label59);
            this.panelDados3.Controls.Add(this.SG_UniQTD);
            resources.ApplyResources(this.panelDados3, "panelDados3");
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // SG_Unidade_Estoque
            // 
            this.SG_Unidade_Estoque.BackColor = System.Drawing.SystemColors.Window;
            this.SG_Unidade_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_Unidade_Estoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_Unidade_Estoque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Sg_unidade_est", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.SG_Unidade_Estoque, "SG_Unidade_Estoque");
            this.SG_Unidade_Estoque.Name = "SG_Unidade_Estoque";
            this.SG_Unidade_Estoque.NM_Alias = "";
            this.SG_Unidade_Estoque.NM_Campo = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_CampoBusca = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_Unidade_Estoque.QTD_Zero = 0;
            this.SG_Unidade_Estoque.ReadOnly = true;
            this.SG_Unidade_Estoque.ST_AutoInc = false;
            this.SG_Unidade_Estoque.ST_DisableAuto = false;
            this.SG_Unidade_Estoque.ST_Float = false;
            this.SG_Unidade_Estoque.ST_Gravar = false;
            this.SG_Unidade_Estoque.ST_Int = false;
            this.SG_Unidade_Estoque.ST_LimpaCampo = true;
            this.SG_Unidade_Estoque.ST_NotNull = false;
            this.SG_Unidade_Estoque.ST_PrimaryKey = false;
            this.SG_Unidade_Estoque.TextOld = null;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // Sub_Total
            // 
            this.Sub_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sub_Total.DecimalPlaces = 2;
            resources.ApplyResources(this.Sub_Total, "Sub_Total");
            this.Sub_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Sub_Total.Name = "Sub_Total";
            this.Sub_Total.NM_Alias = "";
            this.Sub_Total.NM_Campo = "Vl_Unitario";
            this.Sub_Total.NM_Param = "@P_VL_UNITARIO";
            this.Sub_Total.Operador = "";
            this.Sub_Total.ST_AutoInc = false;
            this.Sub_Total.ST_DisableAuto = false;
            this.Sub_Total.ST_Gravar = true;
            this.Sub_Total.ST_LimparCampo = true;
            this.Sub_Total.ST_NotNull = false;
            this.Sub_Total.ST_PrimaryKey = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // Vl_Unitario
            // 
            this.Vl_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_Unitario.DecimalPlaces = 7;
            resources.ApplyResources(this.Vl_Unitario, "Vl_Unitario");
            this.Vl_Unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Unitario.Name = "Vl_Unitario";
            this.Vl_Unitario.NM_Alias = "";
            this.Vl_Unitario.NM_Campo = "Vl_Unitario";
            this.Vl_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.Vl_Unitario.Operador = "";
            this.Vl_Unitario.ST_AutoInc = false;
            this.Vl_Unitario.ST_DisableAuto = false;
            this.Vl_Unitario.ST_Gravar = true;
            this.Vl_Unitario.ST_LimparCampo = true;
            this.Vl_Unitario.ST_NotNull = true;
            this.Vl_Unitario.ST_PrimaryKey = false;
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsItens, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 2;
            resources.ApplyResources(this.Quantidade, "Quantidade");
            this.Quantidade.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "Quantidade";
            this.Quantidade.NM_Param = "@P_QUANTIDADE";
            this.Quantidade.Operador = "";
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = false;
            this.Quantidade.ST_PrimaryKey = false;
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.Name = "label58";
            // 
            // label59
            // 
            resources.ApplyResources(this.label59, "label59");
            this.label59.Name = "label59";
            // 
            // SG_UniQTD
            // 
            this.SG_UniQTD.BackColor = System.Drawing.SystemColors.Window;
            this.SG_UniQTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_UniQTD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_UniQTD.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Sg_unidade_valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.SG_UniQTD, "SG_UniQTD");
            this.SG_UniQTD.Name = "SG_UniQTD";
            this.SG_UniQTD.NM_Alias = "";
            this.SG_UniQTD.NM_Campo = "Sigla_Unidade";
            this.SG_UniQTD.NM_CampoBusca = "Sigla_Unidade";
            this.SG_UniQTD.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_UniQTD.QTD_Zero = 0;
            this.SG_UniQTD.ReadOnly = true;
            this.SG_UniQTD.ST_AutoInc = false;
            this.SG_UniQTD.ST_DisableAuto = false;
            this.SG_UniQTD.ST_Float = false;
            this.SG_UniQTD.ST_Gravar = false;
            this.SG_UniQTD.ST_Int = false;
            this.SG_UniQTD.ST_LimpaCampo = true;
            this.SG_UniQTD.ST_NotNull = false;
            this.SG_UniQTD.ST_PrimaryKey = false;
            this.SG_UniQTD.TextOld = null;
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Local, "DS_Local");
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_UNIDADE";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ReadOnly = true;
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TextOld = null;
            // 
            // BB_Local
            // 
            resources.ApplyResources(this.BB_Local, "BB_Local");
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Local, "CD_Local");
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_UNIDADE";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_unidade_valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Unidade, "DS_Unidade");
            this.DS_Unidade.Name = "DS_Unidade";
            this.DS_Unidade.NM_Alias = "";
            this.DS_Unidade.NM_Campo = "DS_Unidade";
            this.DS_Unidade.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade.NM_Param = "@P_DS_UNIDADE";
            this.DS_Unidade.QTD_Zero = 0;
            this.DS_Unidade.ReadOnly = true;
            this.DS_Unidade.ST_AutoInc = false;
            this.DS_Unidade.ST_DisableAuto = false;
            this.DS_Unidade.ST_Float = false;
            this.DS_Unidade.ST_Gravar = false;
            this.DS_Unidade.ST_Int = false;
            this.DS_Unidade.ST_LimpaCampo = true;
            this.DS_Unidade.ST_NotNull = false;
            this.DS_Unidade.ST_PrimaryKey = false;
            this.DS_Unidade.TextOld = null;
            // 
            // BB_Unidade
            // 
            resources.ApplyResources(this.BB_Unidade, "BB_Unidade");
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.UseVisualStyleBackColor = true;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // label57
            // 
            resources.ApplyResources(this.label57, "label57");
            this.label57.Name = "label57";
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_unidade_valor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Unidade, "CD_Unidade");
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // DS_Variedade
            // 
            this.DS_Variedade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Variedade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Variedade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Variedade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_variedade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Variedade, "DS_Variedade");
            this.DS_Variedade.Name = "DS_Variedade";
            this.DS_Variedade.NM_Alias = "";
            this.DS_Variedade.NM_Campo = "DS_Variedade";
            this.DS_Variedade.NM_CampoBusca = "DS_Variedade";
            this.DS_Variedade.NM_Param = "@P_DS_VARIEDADE";
            this.DS_Variedade.QTD_Zero = 0;
            this.DS_Variedade.ReadOnly = true;
            this.DS_Variedade.ST_AutoInc = false;
            this.DS_Variedade.ST_DisableAuto = false;
            this.DS_Variedade.ST_Float = false;
            this.DS_Variedade.ST_Gravar = false;
            this.DS_Variedade.ST_Int = false;
            this.DS_Variedade.ST_LimpaCampo = true;
            this.DS_Variedade.ST_NotNull = false;
            this.DS_Variedade.ST_PrimaryKey = false;
            this.DS_Variedade.TextOld = null;
            // 
            // BB_Variedade
            // 
            resources.ApplyResources(this.BB_Variedade, "BB_Variedade");
            this.BB_Variedade.Name = "BB_Variedade";
            this.BB_Variedade.UseVisualStyleBackColor = true;
            this.BB_Variedade.Click += new System.EventHandler(this.BB_Variedade_Click);
            // 
            // label56
            // 
            resources.ApplyResources(this.label56, "label56");
            this.label56.Name = "label56";
            // 
            // CD_Variedade
            // 
            this.CD_Variedade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Variedade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Variedade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Variedade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_variedade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Variedade, "CD_Variedade");
            this.CD_Variedade.Name = "CD_Variedade";
            this.CD_Variedade.NM_Alias = "";
            this.CD_Variedade.NM_Campo = "CD_Variedade";
            this.CD_Variedade.NM_CampoBusca = "CD_Variedade";
            this.CD_Variedade.NM_Param = "@P_CD_VARIEDADE";
            this.CD_Variedade.QTD_Zero = 0;
            this.CD_Variedade.ST_AutoInc = false;
            this.CD_Variedade.ST_DisableAuto = false;
            this.CD_Variedade.ST_Float = false;
            this.CD_Variedade.ST_Gravar = true;
            this.CD_Variedade.ST_Int = false;
            this.CD_Variedade.ST_LimpaCampo = true;
            this.CD_Variedade.ST_NotNull = false;
            this.CD_Variedade.ST_PrimaryKey = false;
            this.CD_Variedade.TextOld = null;
            this.CD_Variedade.Leave += new System.EventHandler(this.CD_Variedade_Leave);
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Produto, "DS_Produto");
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TextOld = null;
            // 
            // BB_Produto
            // 
            resources.ApplyResources(this.BB_Produto, "BB_Produto");
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.UseVisualStyleBackColor = true;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // rg_frete
            // 
            this.rg_frete.Controls.Add(this.panelDados2);
            resources.ApplyResources(this.rg_frete, "rg_frete");
            this.rg_frete.Name = "rg_frete";
            this.rg_frete.NM_Alias = "a";
            this.rg_frete.NM_Campo = "TP_Movimento";
            this.rg_frete.NM_Param = "@P_TP_MOVIMENTO";
            this.rg_frete.NM_Valor = "";
            this.rg_frete.ST_Gravar = false;
            this.rg_frete.ST_NotNull = false;
            this.rg_frete.TabStop = false;
            // 
            // panelDados2
            // 
            this.panelDados2.BackColor = System.Drawing.SystemColors.Control;
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.label68);
            this.panelDados2.Controls.Add(this.Vl_Frete);
            this.panelDados2.Controls.Add(this.rgFretePorConta);
            resources.ApplyResources(this.panelDados2, "panelDados2");
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            // 
            // label68
            // 
            resources.ApplyResources(this.label68, "label68");
            this.label68.Name = "label68";
            // 
            // Vl_Frete
            // 
            this.Vl_Frete.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPedido, "Vl_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_Frete.DecimalPlaces = 2;
            resources.ApplyResources(this.Vl_Frete, "Vl_Frete");
            this.Vl_Frete.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.Vl_Frete.Name = "Vl_Frete";
            this.Vl_Frete.NM_Alias = "";
            this.Vl_Frete.NM_Campo = "";
            this.Vl_Frete.NM_Param = "";
            this.Vl_Frete.Operador = "";
            this.Vl_Frete.ST_AutoInc = false;
            this.Vl_Frete.ST_DisableAuto = false;
            this.Vl_Frete.ST_Gravar = true;
            this.Vl_Frete.ST_LimparCampo = true;
            this.Vl_Frete.ST_NotNull = false;
            this.Vl_Frete.ST_PrimaryKey = false;
            // 
            // rgFretePorConta
            // 
            this.rgFretePorConta.BackColor = System.Drawing.SystemColors.Control;
            this.rgFretePorConta.Controls.Add(this.rbDestinatario);
            this.rgFretePorConta.Controls.Add(this.rbEmitente);
            this.rgFretePorConta.DataBindings.Add(new System.Windows.Forms.Binding("NM_Valor", this.bsPedido, "Tp_frete", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.rgFretePorConta, "rgFretePorConta");
            this.rgFretePorConta.Name = "rgFretePorConta";
            this.rgFretePorConta.NM_Alias = "";
            this.rgFretePorConta.NM_Campo = "";
            this.rgFretePorConta.NM_Param = "";
            this.rgFretePorConta.NM_Valor = "2";
            this.rgFretePorConta.ST_Gravar = true;
            this.rgFretePorConta.ST_NotNull = false;
            this.rgFretePorConta.TabStop = false;
            // 
            // rbDestinatario
            // 
            resources.ApplyResources(this.rbDestinatario, "rbDestinatario");
            this.rbDestinatario.Checked = true;
            this.rbDestinatario.Name = "rbDestinatario";
            this.rbDestinatario.TabStop = true;
            this.rbDestinatario.UseVisualStyleBackColor = true;
            this.rbDestinatario.Valor = "2";
            // 
            // rbEmitente
            // 
            resources.ApplyResources(this.rbEmitente, "rbEmitente");
            this.rbEmitente.Name = "rbEmitente";
            this.rbEmitente.UseVisualStyleBackColor = true;
            this.rbEmitente.Valor = "1";
            // 
            // Sigla_Moeda
            // 
            this.Sigla_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla_Moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sigla_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla_Moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Sigla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Sigla_Moeda, "Sigla_Moeda");
            this.Sigla_Moeda.Name = "Sigla_Moeda";
            this.Sigla_Moeda.NM_Alias = "";
            this.Sigla_Moeda.NM_Campo = "Sigla";
            this.Sigla_Moeda.NM_CampoBusca = "Sigla";
            this.Sigla_Moeda.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.Sigla_Moeda.QTD_Zero = 0;
            this.Sigla_Moeda.ReadOnly = true;
            this.Sigla_Moeda.ST_AutoInc = false;
            this.Sigla_Moeda.ST_DisableAuto = false;
            this.Sigla_Moeda.ST_Float = false;
            this.Sigla_Moeda.ST_Gravar = false;
            this.Sigla_Moeda.ST_Int = false;
            this.Sigla_Moeda.ST_LimpaCampo = true;
            this.Sigla_Moeda.ST_NotNull = false;
            this.Sigla_Moeda.ST_PrimaryKey = false;
            this.Sigla_Moeda.TextOld = null;
            // 
            // DS_Moeda
            // 
            this.DS_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Ds_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Moeda, "DS_Moeda");
            this.DS_Moeda.Name = "DS_Moeda";
            this.DS_Moeda.NM_Alias = "";
            this.DS_Moeda.NM_Campo = "DS_Moeda_Singular";
            this.DS_Moeda.NM_CampoBusca = "DS_Moeda_Singular";
            this.DS_Moeda.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.DS_Moeda.QTD_Zero = 0;
            this.DS_Moeda.ReadOnly = true;
            this.DS_Moeda.ST_AutoInc = false;
            this.DS_Moeda.ST_DisableAuto = false;
            this.DS_Moeda.ST_Float = false;
            this.DS_Moeda.ST_Gravar = false;
            this.DS_Moeda.ST_Int = false;
            this.DS_Moeda.ST_LimpaCampo = true;
            this.DS_Moeda.ST_NotNull = false;
            this.DS_Moeda.ST_PrimaryKey = false;
            this.DS_Moeda.TextOld = null;
            // 
            // BB_Moeda
            // 
            resources.ApplyResources(this.BB_Moeda, "BB_Moeda");
            this.BB_Moeda.Name = "BB_Moeda";
            this.BB_Moeda.UseVisualStyleBackColor = true;
            this.BB_Moeda.Click += new System.EventHandler(this.BB_Moeda_Click);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // CD_Moeda
            // 
            this.CD_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Cd_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Moeda, "CD_Moeda");
            this.CD_Moeda.Name = "CD_Moeda";
            this.CD_Moeda.NM_Alias = "";
            this.CD_Moeda.NM_Campo = "CD_Moeda";
            this.CD_Moeda.NM_CampoBusca = "CD_Moeda";
            this.CD_Moeda.NM_Param = "@P_CD_MOEDA";
            this.CD_Moeda.QTD_Zero = 0;
            this.CD_Moeda.ST_AutoInc = false;
            this.CD_Moeda.ST_DisableAuto = false;
            this.CD_Moeda.ST_Float = false;
            this.CD_Moeda.ST_Gravar = true;
            this.CD_Moeda.ST_Int = true;
            this.CD_Moeda.ST_LimpaCampo = true;
            this.CD_Moeda.ST_NotNull = true;
            this.CD_Moeda.ST_PrimaryKey = false;
            this.CD_Moeda.TextOld = null;
            this.CD_Moeda.Leave += new System.EventHandler(this.CD_Moeda_Leave);
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "DS_Endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Endereco, "DS_Endereco");
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "DS_Endereco";
            this.DS_Endereco.NM_CampoBusca = "DS_Endereco";
            this.DS_Endereco.NM_Param = "@P_DS_ENDERECO";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = true;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "CD_Endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Endereco, "CD_Endereco");
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "CD_Endereco";
            this.CD_Endereco.NM_CampoBusca = "CD_Endereco";
            this.CD_Endereco.NM_Param = "@P_CD_ENDERECO";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = true;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = false;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TextOld = null;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "NM_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Clifor, "NM_Clifor");
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = true;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "CD_Clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Clifor, "CD_Clifor");
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TextOld = null;
            // 
            // TP_Mov
            // 
            this.TP_Mov.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Mov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Mov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Mov.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "TP_Movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.TP_Mov, "TP_Mov");
            this.TP_Mov.Name = "TP_Mov";
            this.TP_Mov.NM_Alias = "";
            this.TP_Mov.NM_Campo = "TP_Movimento";
            this.TP_Mov.NM_CampoBusca = "TP_Movimento";
            this.TP_Mov.NM_Param = "";
            this.TP_Mov.QTD_Zero = 0;
            this.TP_Mov.ReadOnly = true;
            this.TP_Mov.ST_AutoInc = false;
            this.TP_Mov.ST_DisableAuto = false;
            this.TP_Mov.ST_Float = false;
            this.TP_Mov.ST_Gravar = false;
            this.TP_Mov.ST_Int = false;
            this.TP_Mov.ST_LimpaCampo = true;
            this.TP_Mov.ST_NotNull = false;
            this.TP_Mov.ST_PrimaryKey = false;
            this.TP_Mov.TextOld = null;
            // 
            // DS_CFGPedido
            // 
            this.DS_CFGPedido.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CFGPedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_CFGPedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CFGPedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "DS_CFG_Pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_CFGPedido, "DS_CFGPedido");
            this.DS_CFGPedido.Name = "DS_CFGPedido";
            this.DS_CFGPedido.NM_Alias = "";
            this.DS_CFGPedido.NM_Campo = "DS_TipoPedido";
            this.DS_CFGPedido.NM_CampoBusca = "DS_TipoPedido";
            this.DS_CFGPedido.NM_Param = "@P_DS_TIPOPEDIDO";
            this.DS_CFGPedido.QTD_Zero = 0;
            this.DS_CFGPedido.ReadOnly = true;
            this.DS_CFGPedido.ST_AutoInc = false;
            this.DS_CFGPedido.ST_DisableAuto = false;
            this.DS_CFGPedido.ST_Float = false;
            this.DS_CFGPedido.ST_Gravar = false;
            this.DS_CFGPedido.ST_Int = false;
            this.DS_CFGPedido.ST_LimpaCampo = true;
            this.DS_CFGPedido.ST_NotNull = false;
            this.DS_CFGPedido.ST_PrimaryKey = false;
            this.DS_CFGPedido.TextOld = null;
            // 
            // BB_CFGPedido
            // 
            resources.ApplyResources(this.BB_CFGPedido, "BB_CFGPedido");
            this.BB_CFGPedido.Name = "BB_CFGPedido";
            this.BB_CFGPedido.UseVisualStyleBackColor = true;
            this.BB_CFGPedido.Click += new System.EventHandler(this.BB_CFGPedido_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // CFG_Pedido
            // 
            this.CFG_Pedido.BackColor = System.Drawing.SystemColors.Window;
            this.CFG_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CFG_Pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CFG_Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "CFG_Pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CFG_Pedido, "CFG_Pedido");
            this.CFG_Pedido.Name = "CFG_Pedido";
            this.CFG_Pedido.NM_Alias = "";
            this.CFG_Pedido.NM_Campo = "CFG_Pedido";
            this.CFG_Pedido.NM_CampoBusca = "CFG_Pedido";
            this.CFG_Pedido.NM_Param = "@P_CFG_PEDIDO";
            this.CFG_Pedido.QTD_Zero = 0;
            this.CFG_Pedido.ST_AutoInc = false;
            this.CFG_Pedido.ST_DisableAuto = false;
            this.CFG_Pedido.ST_Float = false;
            this.CFG_Pedido.ST_Gravar = true;
            this.CFG_Pedido.ST_Int = true;
            this.CFG_Pedido.ST_LimpaCampo = true;
            this.CFG_Pedido.ST_NotNull = true;
            this.CFG_Pedido.ST_PrimaryKey = false;
            this.CFG_Pedido.TextOld = null;
            this.CFG_Pedido.Leave += new System.EventHandler(this.CFG_Pedido_Leave);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // Nr_PedidoOrigem
            // 
            this.Nr_PedidoOrigem.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_PedidoOrigem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_PedidoOrigem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_PedidoOrigem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Nr_PedidoOrigem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Nr_PedidoOrigem, "Nr_PedidoOrigem");
            this.Nr_PedidoOrigem.Name = "Nr_PedidoOrigem";
            this.Nr_PedidoOrigem.NM_Alias = "";
            this.Nr_PedidoOrigem.NM_Campo = "";
            this.Nr_PedidoOrigem.NM_CampoBusca = "";
            this.Nr_PedidoOrigem.NM_Param = "";
            this.Nr_PedidoOrigem.QTD_Zero = 0;
            this.Nr_PedidoOrigem.ST_AutoInc = false;
            this.Nr_PedidoOrigem.ST_DisableAuto = false;
            this.Nr_PedidoOrigem.ST_Float = false;
            this.Nr_PedidoOrigem.ST_Gravar = true;
            this.Nr_PedidoOrigem.ST_Int = false;
            this.Nr_PedidoOrigem.ST_LimpaCampo = true;
            this.Nr_PedidoOrigem.ST_NotNull = false;
            this.Nr_PedidoOrigem.ST_PrimaryKey = false;
            this.Nr_PedidoOrigem.TextOld = null;
            // 
            // DT_Pedido
            // 
            this.DT_Pedido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Pedido.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "DT_Pedido_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DT_Pedido, "DT_Pedido");
            this.DT_Pedido.Name = "DT_Pedido";
            this.DT_Pedido.NM_Alias = "";
            this.DT_Pedido.NM_Campo = "";
            this.DT_Pedido.NM_CampoBusca = "";
            this.DT_Pedido.NM_Param = "";
            this.DT_Pedido.Operador = "";
            this.DT_Pedido.ST_Gravar = false;
            this.DT_Pedido.ST_LimpaCampo = true;
            this.DT_Pedido.ST_NotNull = false;
            this.DT_Pedido.ST_PrimaryKey = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Nm_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NM_Empresa, "NM_Empresa");
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TextOld = null;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "CD_Empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Empresa, "CD_Empresa");
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TextOld = null;
            // 
            // TFItensContrato
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pPedido);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensContrato";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFItensContrato_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensContrato_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pPedido.ResumeLayout(false);
            this.pPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).EndInit();
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.rg_frete.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Frete)).EndInit();
            this.rgFretePorConta.ResumeLayout(false);
            this.rgFretePorConta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pPedido;
        private Componentes.EditData DT_Pedido;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault TP_Mov;
        private Componentes.EditDefault DS_CFGPedido;
        private System.Windows.Forms.Button BB_CFGPedido;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault CFG_Pedido;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault Nr_PedidoOrigem;
        private Componentes.EditDefault DS_Endereco;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault CD_Endereco;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault CD_Clifor;
        private Componentes.EditDefault Sigla_Moeda;
        private Componentes.EditDefault DS_Moeda;
        private System.Windows.Forms.Button BB_Moeda;
        private System.Windows.Forms.Label label30;
        private Componentes.EditDefault CD_Moeda;
        private Componentes.RadioGroup rg_frete;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.Label label68;
        private Componentes.EditFloat Vl_Frete;
        private Componentes.RadioGroup rgFretePorConta;
        private Componentes.RadioButtonDefault rbDestinatario;
        private Componentes.RadioButtonDefault rbEmitente;
        public Componentes.EditDefault DS_Produto;
        public System.Windows.Forms.Button BB_Produto;
        private System.Windows.Forms.Label label55;
        public Componentes.EditDefault CD_Produto;
        public Componentes.EditDefault DS_Variedade;
        private System.Windows.Forms.Button BB_Variedade;
        private System.Windows.Forms.Label label56;
        public Componentes.EditDefault CD_Variedade;
        public Componentes.EditDefault DS_Unidade;
        private System.Windows.Forms.Button BB_Unidade;
        private System.Windows.Forms.Label label57;
        public Componentes.EditDefault CD_Unidade;
        public Componentes.EditDefault DS_Local;
        private System.Windows.Forms.Button BB_Local;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault CD_Local;
        private Componentes.PanelDados panelDados3;
        private System.Windows.Forms.Label label5;
        public Componentes.EditDefault SG_Unidade_Estoque;
        private System.Windows.Forms.Label label9;
        public Componentes.EditFloat Sub_Total;
        private System.Windows.Forms.Label label13;
        public Componentes.EditFloat Vl_Unitario;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        public Componentes.EditDefault SG_UniQTD;
        private System.Windows.Forms.BindingSource bsPedido;
        private System.Windows.Forms.BindingSource bsItens;
        private Componentes.EditDefault cd_unidestoque;
    }
}