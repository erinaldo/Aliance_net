namespace Commoditties
{
    partial class TFLan_Taxa
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
            System.Windows.Forms.Label tipo_lanctoLabel;
            System.Windows.Forms.Label vl_TaxaLabel;
            System.Windows.Forms.Label ps_TaxaLabel;
            System.Windows.Forms.Label dt_lanctostrLabel;
            System.Windows.Forms.Label id_TaxaLabel;
            System.Windows.Forms.Label nr_ContratoLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLan_Taxa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.bsTaxaDeposito = new System.Windows.Forms.BindingSource(this.components);
            this.pCabecalho = new Componentes.PanelDados(this.components);
            this.nr_contrato = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.nr_pedido = new Componentes.EditDefault(this.components);
            this.tp_lancto = new Componentes.EditDefault(this.components);
            this.vl_taxa = new Componentes.EditFloat(this.components);
            this.ps_taxa = new Componentes.EditFloat(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.id_reg = new Componentes.EditDefault(this.components);
            this.ds_taxa = new Componentes.EditDefault(this.components);
            this.bb_taxa = new System.Windows.Forms.Button();
            this.id_taxa = new Componentes.EditDefault(this.components);
            tipo_lanctoLabel = new System.Windows.Forms.Label();
            vl_TaxaLabel = new System.Windows.Forms.Label();
            ps_TaxaLabel = new System.Windows.Forms.Label();
            dt_lanctostrLabel = new System.Windows.Forms.Label();
            id_TaxaLabel = new System.Windows.Forms.Label();
            nr_ContratoLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxaDeposito)).BeginInit();
            this.pCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ps_taxa)).BeginInit();
            this.SuspendLayout();
            // 
            // tipo_lanctoLabel
            // 
            tipo_lanctoLabel.AutoSize = true;
            tipo_lanctoLabel.Location = new System.Drawing.Point(1, 124);
            tipo_lanctoLabel.Name = "tipo_lanctoLabel";
            tipo_lanctoLabel.Size = new System.Drawing.Size(69, 13);
            tipo_lanctoLabel.TabIndex = 15;
            tipo_lanctoLabel.Text = "Lançamento:";
            // 
            // vl_TaxaLabel
            // 
            vl_TaxaLabel.AutoSize = true;
            vl_TaxaLabel.Location = new System.Drawing.Point(319, 97);
            vl_TaxaLabel.Name = "vl_TaxaLabel";
            vl_TaxaLabel.Size = new System.Drawing.Size(61, 13);
            vl_TaxaLabel.TabIndex = 11;
            vl_TaxaLabel.Text = "Valor Taxa:";
            // 
            // ps_TaxaLabel
            // 
            ps_TaxaLabel.AutoSize = true;
            ps_TaxaLabel.Location = new System.Drawing.Point(154, 97);
            ps_TaxaLabel.Name = "ps_TaxaLabel";
            ps_TaxaLabel.Size = new System.Drawing.Size(61, 13);
            ps_TaxaLabel.TabIndex = 10;
            ps_TaxaLabel.Text = "Peso Taxa:";
            // 
            // dt_lanctostrLabel
            // 
            dt_lanctostrLabel.AutoSize = true;
            dt_lanctostrLabel.Location = new System.Drawing.Point(10, 97);
            dt_lanctostrLabel.Name = "dt_lanctostrLabel";
            dt_lanctostrLabel.Size = new System.Drawing.Size(60, 13);
            dt_lanctostrLabel.TabIndex = 8;
            dt_lanctostrLabel.Text = "Dt. Lancto:";
            // 
            // id_TaxaLabel
            // 
            id_TaxaLabel.AutoSize = true;
            id_TaxaLabel.Location = new System.Drawing.Point(36, 71);
            id_TaxaLabel.Name = "id_TaxaLabel";
            id_TaxaLabel.Size = new System.Drawing.Size(34, 13);
            id_TaxaLabel.TabIndex = 2;
            id_TaxaLabel.Text = "Taxa:";
            // 
            // nr_ContratoLabel
            // 
            nr_ContratoLabel.AutoSize = true;
            nr_ContratoLabel.Location = new System.Drawing.Point(18, 11);
            nr_ContratoLabel.Name = "nr_ContratoLabel";
            nr_ContratoLabel.Size = new System.Drawing.Size(50, 13);
            nr_ContratoLabel.TabIndex = 0;
            nr_ContratoLabel.Text = "Contrato:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(180, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 17;
            label2.Text = "Pedido:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 19;
            label3.Text = "Produto:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(469, 43);
            this.barraMenu.TabIndex = 7;
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
            this.BB_Gravar.Text = " (F4)\n Gravar";
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
            this.BB_Cancelar.Text = "(F6)\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.pCabecalho);
            this.pDados.Controls.Add(tipo_lanctoLabel);
            this.pDados.Controls.Add(this.tp_lancto);
            this.pDados.Controls.Add(vl_TaxaLabel);
            this.pDados.Controls.Add(this.vl_taxa);
            this.pDados.Controls.Add(ps_TaxaLabel);
            this.pDados.Controls.Add(this.ps_taxa);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(dt_lanctostrLabel);
            this.pDados.Controls.Add(this.id_reg);
            this.pDados.Controls.Add(this.ds_taxa);
            this.pDados.Controls.Add(this.bb_taxa);
            this.pDados.Controls.Add(this.id_taxa);
            this.pDados.Controls.Add(id_TaxaLabel);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(469, 150);
            this.pDados.TabIndex = 8;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Sigla_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(282, 95);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "";
            this.sigla_unidade.NM_CampoBusca = "";
            this.sigla_unidade.NM_Param = "";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(33, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 23;
            // 
            // bsTaxaDeposito
            // 
            this.bsTaxaDeposito.DataSource = typeof(CamadaDados.Graos.TRegistro_TaxaDeposito);
            // 
            // pCabecalho
            // 
            this.pCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCabecalho.Controls.Add(this.nr_contrato);
            this.pCabecalho.Controls.Add(this.ds_produto);
            this.pCabecalho.Controls.Add(nr_ContratoLabel);
            this.pCabecalho.Controls.Add(this.cd_produto);
            this.pCabecalho.Controls.Add(label2);
            this.pCabecalho.Controls.Add(label3);
            this.pCabecalho.Controls.Add(this.nr_pedido);
            this.pCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pCabecalho.Location = new System.Drawing.Point(0, 0);
            this.pCabecalho.Name = "pCabecalho";
            this.pCabecalho.NM_ProcDeletar = "";
            this.pCabecalho.NM_ProcGravar = "";
            this.pCabecalho.Size = new System.Drawing.Size(465, 62);
            this.pCabecalho.TabIndex = 22;
            // 
            // nr_contrato
            // 
            this.nr_contrato.BackColor = System.Drawing.SystemColors.Window;
            this.nr_contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_contrato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Nr_Contrato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_contrato.Enabled = false;
            this.nr_contrato.Location = new System.Drawing.Point(74, 8);
            this.nr_contrato.Name = "nr_contrato";
            this.nr_contrato.NM_Alias = "";
            this.nr_contrato.NM_Campo = "";
            this.nr_contrato.NM_CampoBusca = "";
            this.nr_contrato.NM_Param = "";
            this.nr_contrato.QTD_Zero = 0;
            this.nr_contrato.Size = new System.Drawing.Size(100, 20);
            this.nr_contrato.ST_AutoInc = false;
            this.nr_contrato.ST_DisableAuto = false;
            this.nr_contrato.ST_Float = false;
            this.nr_contrato.ST_Gravar = false;
            this.nr_contrato.ST_Int = false;
            this.nr_contrato.ST_LimpaCampo = true;
            this.nr_contrato.ST_NotNull = false;
            this.nr_contrato.ST_PrimaryKey = false;
            this.nr_contrato.TabIndex = 2;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(175, 34);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "";
            this.ds_produto.NM_CampoBusca = "";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(283, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 21;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(74, 34);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "";
            this.cd_produto.NM_CampoBusca = "";
            this.cd_produto.NM_Param = "";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(100, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 20;
            // 
            // nr_pedido
            // 
            this.nr_pedido.BackColor = System.Drawing.SystemColors.Window;
            this.nr_pedido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_pedido.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Nr_pedido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_pedido.Enabled = false;
            this.nr_pedido.Location = new System.Drawing.Point(229, 8);
            this.nr_pedido.Name = "nr_pedido";
            this.nr_pedido.NM_Alias = "";
            this.nr_pedido.NM_Campo = "";
            this.nr_pedido.NM_CampoBusca = "";
            this.nr_pedido.NM_Param = "";
            this.nr_pedido.QTD_Zero = 0;
            this.nr_pedido.Size = new System.Drawing.Size(100, 20);
            this.nr_pedido.ST_AutoInc = false;
            this.nr_pedido.ST_DisableAuto = false;
            this.nr_pedido.ST_Float = false;
            this.nr_pedido.ST_Gravar = false;
            this.nr_pedido.ST_Int = false;
            this.nr_pedido.ST_LimpaCampo = true;
            this.nr_pedido.ST_NotNull = false;
            this.nr_pedido.ST_PrimaryKey = false;
            this.nr_pedido.TabIndex = 18;
            // 
            // tp_lancto
            // 
            this.tp_lancto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_lancto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Tipo_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_lancto.Enabled = false;
            this.tp_lancto.Location = new System.Drawing.Point(76, 121);
            this.tp_lancto.Name = "tp_lancto";
            this.tp_lancto.NM_Alias = "";
            this.tp_lancto.NM_Campo = "";
            this.tp_lancto.NM_CampoBusca = "";
            this.tp_lancto.NM_Param = "";
            this.tp_lancto.QTD_Zero = 0;
            this.tp_lancto.Size = new System.Drawing.Size(384, 20);
            this.tp_lancto.ST_AutoInc = false;
            this.tp_lancto.ST_DisableAuto = false;
            this.tp_lancto.ST_Float = false;
            this.tp_lancto.ST_Gravar = false;
            this.tp_lancto.ST_Int = false;
            this.tp_lancto.ST_LimpaCampo = true;
            this.tp_lancto.ST_NotNull = false;
            this.tp_lancto.ST_PrimaryKey = false;
            this.tp_lancto.TabIndex = 16;
            // 
            // vl_taxa
            // 
            this.vl_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxaDeposito, "Vl_Taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_taxa.DecimalPlaces = 2;
            this.vl_taxa.Location = new System.Drawing.Point(381, 95);
            this.vl_taxa.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_taxa.Name = "vl_taxa";
            this.vl_taxa.NM_Alias = "";
            this.vl_taxa.NM_Campo = "";
            this.vl_taxa.NM_Param = "";
            this.vl_taxa.Operador = "";
            this.vl_taxa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_taxa.Size = new System.Drawing.Size(79, 20);
            this.vl_taxa.ST_AutoInc = false;
            this.vl_taxa.ST_DisableAuto = false;
            this.vl_taxa.ST_Gravar = false;
            this.vl_taxa.ST_LimparCampo = true;
            this.vl_taxa.ST_NotNull = false;
            this.vl_taxa.ST_PrimaryKey = false;
            this.vl_taxa.TabIndex = 4;
            this.vl_taxa.ThousandsSeparator = true;
            // 
            // ps_taxa
            // 
            this.ps_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTaxaDeposito, "Ps_Taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ps_taxa.Location = new System.Drawing.Point(215, 95);
            this.ps_taxa.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.ps_taxa.Name = "ps_taxa";
            this.ps_taxa.NM_Alias = "";
            this.ps_taxa.NM_Campo = "";
            this.ps_taxa.NM_Param = "";
            this.ps_taxa.Operador = "";
            this.ps_taxa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ps_taxa.Size = new System.Drawing.Size(65, 20);
            this.ps_taxa.ST_AutoInc = false;
            this.ps_taxa.ST_DisableAuto = false;
            this.ps_taxa.ST_Gravar = false;
            this.ps_taxa.ST_LimparCampo = true;
            this.ps_taxa.ST_NotNull = false;
            this.ps_taxa.ST_PrimaryKey = false;
            this.ps_taxa.TabIndex = 3;
            this.ps_taxa.ThousandsSeparator = true;
            // 
            // dt_lancto
            // 
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Location = new System.Drawing.Point(76, 94);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(72, 20);
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = false;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 2;
            // 
            // id_reg
            // 
            this.id_reg.BackColor = System.Drawing.SystemColors.Window;
            this.id_reg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_reg.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Id_regstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_reg.Enabled = false;
            this.id_reg.Location = new System.Drawing.Point(409, 68);
            this.id_reg.Name = "id_reg";
            this.id_reg.NM_Alias = "a";
            this.id_reg.NM_Campo = "id_reg";
            this.id_reg.NM_CampoBusca = "id_reg";
            this.id_reg.NM_Param = "@P_ID_REG";
            this.id_reg.QTD_Zero = 0;
            this.id_reg.Size = new System.Drawing.Size(51, 20);
            this.id_reg.ST_AutoInc = false;
            this.id_reg.ST_DisableAuto = false;
            this.id_reg.ST_Float = false;
            this.id_reg.ST_Gravar = false;
            this.id_reg.ST_Int = false;
            this.id_reg.ST_LimpaCampo = true;
            this.id_reg.ST_NotNull = false;
            this.id_reg.ST_PrimaryKey = false;
            this.id_reg.TabIndex = 8;
            // 
            // ds_taxa
            // 
            this.ds_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Ds_taxa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_taxa.Enabled = false;
            this.ds_taxa.Location = new System.Drawing.Point(185, 68);
            this.ds_taxa.Name = "ds_taxa";
            this.ds_taxa.NM_Alias = "a";
            this.ds_taxa.NM_Campo = "ds_taxa";
            this.ds_taxa.NM_CampoBusca = "ds_taxa";
            this.ds_taxa.NM_Param = "@P_DS_TAXA";
            this.ds_taxa.QTD_Zero = 0;
            this.ds_taxa.Size = new System.Drawing.Size(222, 20);
            this.ds_taxa.ST_AutoInc = false;
            this.ds_taxa.ST_DisableAuto = false;
            this.ds_taxa.ST_Float = false;
            this.ds_taxa.ST_Gravar = false;
            this.ds_taxa.ST_Int = false;
            this.ds_taxa.ST_LimpaCampo = true;
            this.ds_taxa.ST_NotNull = false;
            this.ds_taxa.ST_PrimaryKey = false;
            this.ds_taxa.TabIndex = 6;
            // 
            // bb_taxa
            // 
            this.bb_taxa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_taxa.Image = ((System.Drawing.Image)(resources.GetObject("bb_taxa.Image")));
            this.bb_taxa.Location = new System.Drawing.Point(149, 68);
            this.bb_taxa.Name = "bb_taxa";
            this.bb_taxa.Size = new System.Drawing.Size(30, 20);
            this.bb_taxa.TabIndex = 1;
            this.bb_taxa.UseVisualStyleBackColor = true;
            this.bb_taxa.Click += new System.EventHandler(this.bb_taxa_Click);
            // 
            // id_taxa
            // 
            this.id_taxa.BackColor = System.Drawing.SystemColors.Window;
            this.id_taxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_taxa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTaxaDeposito, "Id_taxastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_taxa.Location = new System.Drawing.Point(76, 68);
            this.id_taxa.Name = "id_taxa";
            this.id_taxa.NM_Alias = "a";
            this.id_taxa.NM_Campo = "id_taxa";
            this.id_taxa.NM_CampoBusca = "id_taxa";
            this.id_taxa.NM_Param = "@P_ID_TAXA";
            this.id_taxa.QTD_Zero = 0;
            this.id_taxa.Size = new System.Drawing.Size(72, 20);
            this.id_taxa.ST_AutoInc = false;
            this.id_taxa.ST_DisableAuto = false;
            this.id_taxa.ST_Float = false;
            this.id_taxa.ST_Gravar = true;
            this.id_taxa.ST_Int = true;
            this.id_taxa.ST_LimpaCampo = true;
            this.id_taxa.ST_NotNull = false;
            this.id_taxa.ST_PrimaryKey = false;
            this.id_taxa.TabIndex = 0;
            this.id_taxa.Leave += new System.EventHandler(this.id_taxa_Leave);
            // 
            // TFLan_Taxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 193);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLan_Taxa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taxas de Deposito";
            this.Load += new System.EventHandler(this.TFLan_Taxa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLan_Taxa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxaDeposito)).EndInit();
            this.pCabecalho.ResumeLayout(false);
            this.pCabecalho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_taxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ps_taxa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault id_taxa;
        private Componentes.EditDefault nr_contrato;
        private System.Windows.Forms.Button bb_taxa;
        private Componentes.EditDefault ds_taxa;
        private Componentes.EditDefault id_reg;
        private Componentes.EditData dt_lancto;
        private Componentes.EditFloat vl_taxa;
        private Componentes.EditFloat ps_taxa;
        private Componentes.EditDefault tp_lancto;
        public System.Windows.Forms.BindingSource bsTaxaDeposito;
        private Componentes.EditDefault nr_pedido;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.PanelDados pCabecalho;
        private Componentes.EditDefault sigla_unidade;
    }
}