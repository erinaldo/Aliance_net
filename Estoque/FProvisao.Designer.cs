namespace Estoque
{
    partial class TFProvisao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProvisao));
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label25;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsProvisao = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.VL_Unitario = new Componentes.EditFloat(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ds_provisao = new Componentes.EditDefault(this.components);
            label17 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisao)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(615, 43);
            this.barraMenu.TabIndex = 2;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // bsProvisao
            // 
            this.bsProvisao.DataSource = typeof(CamadaDados.Estoque.TList_Lan_Provisao_Estoque);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.VL_Unitario);
            this.pDados.Controls.Add(label17);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(label23);
            this.pDados.Controls.Add(this.BB_Produto);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(label25);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_provisao);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(615, 134);
            this.pDados.TabIndex = 3;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sigla_unidade.Location = new System.Drawing.Point(166, 108);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_NM_EMPRESA";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(39, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 147;
            // 
            // VL_Unitario
            // 
            this.VL_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProvisao, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Unitario.DecimalPlaces = 5;
            this.VL_Unitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.VL_Unitario.Location = new System.Drawing.Point(278, 108);
            this.VL_Unitario.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.VL_Unitario.Name = "VL_Unitario";
            this.VL_Unitario.NM_Alias = "";
            this.VL_Unitario.NM_Campo = "VL_Unitario";
            this.VL_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.VL_Unitario.Operador = "";
            this.VL_Unitario.Size = new System.Drawing.Size(95, 20);
            this.VL_Unitario.ST_AutoInc = false;
            this.VL_Unitario.ST_DisableAuto = false;
            this.VL_Unitario.ST_Gravar = true;
            this.VL_Unitario.ST_LimparCampo = true;
            this.VL_Unitario.ST_NotNull = true;
            this.VL_Unitario.ST_PrimaryKey = false;
            this.VL_Unitario.TabIndex = 9;
            this.VL_Unitario.ThousandsSeparator = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label17.Location = new System.Drawing.Point(211, 112);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(61, 13);
            label17.TabIndex = 146;
            label17.Text = "Vl. Unitário:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(28, 110);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 13);
            label3.TabIndex = 144;
            label3.Text = "Qtde:";
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsProvisao, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.quantidade.Location = new System.Drawing.Point(67, 108);
            this.quantidade.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(101, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = true;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = true;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 8;
            this.quantidade.ThousandsSeparator = true;
            // 
            // BB_Local
            // 
            this.BB_Local.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Local.Image = ((System.Drawing.Image)(resources.GetObject("BB_Local.Image")));
            this.BB_Local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Local.Location = new System.Drawing.Point(139, 82);
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.Size = new System.Drawing.Size(28, 19);
            this.BB_Local.TabIndex = 7;
            this.BB_Local.UseVisualStyleBackColor = false;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Local.Enabled = false;
            this.DS_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Local.Location = new System.Drawing.Point(173, 82);
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "ds_local";
            this.DS_Local.NM_CampoBusca = "ds_local";
            this.DS_Local.NM_Param = "@P_NM_EMPRESA";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.Size = new System.Drawing.Size(436, 20);
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TabIndex = 142;
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Local.Location = new System.Drawing.Point(67, 82);
            this.CD_Local.MaxLength = 4;
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "cd_local";
            this.CD_Local.NM_CampoBusca = "cd_local";
            this.CD_Local.NM_Param = "@P_CD_EMPRESA";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.Size = new System.Drawing.Size(69, 20);
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TabIndex = 6;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label23.Location = new System.Drawing.Point(24, 85);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(36, 13);
            label23.TabIndex = 141;
            label23.Text = "Local:";
            // 
            // BB_Produto
            // 
            this.BB_Produto.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Produto.Image = ((System.Drawing.Image)(resources.GetObject("BB_Produto.Image")));
            this.BB_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Produto.Location = new System.Drawing.Point(139, 56);
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.Size = new System.Drawing.Size(28, 19);
            this.BB_Produto.TabIndex = 5;
            this.BB_Produto.UseVisualStyleBackColor = false;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Ds_produto_prov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(173, 56);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "ds_produto";
            this.DS_Produto.NM_CampoBusca = "ds_produto";
            this.DS_Produto.NM_Param = "@P_NM_EMPRESA";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(436, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 138;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Cd_produto_prov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(67, 56);
            this.cd_produto.MaxLength = 4;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_Produto";
            this.cd_produto.NM_CampoBusca = "cd_Produto";
            this.cd_produto.NM_Param = "@P_CD_";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(69, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 4;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label25.Location = new System.Drawing.Point(14, 59);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(47, 13);
            label25.TabIndex = 137;
            label25.Text = "Produto:";
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Nm_empresa_prov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(173, 30);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(436, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 94;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(139, 31);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 3;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(9, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 93;
            this.label13.Text = "Empresa:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Cd_empresa_prov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(67, 30);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(69, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 2;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // dt_lancto
            // 
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Location = new System.Drawing.Point(538, 4);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(71, 20);
            this.dt_lancto.ST_Gravar = false;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = true;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Provisão:";
            // 
            // ds_provisao
            // 
            this.ds_provisao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_provisao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_provisao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsProvisao, "Ds_provisao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_provisao.Location = new System.Drawing.Point(67, 4);
            this.ds_provisao.Name = "ds_provisao";
            this.ds_provisao.NM_Alias = "";
            this.ds_provisao.NM_Campo = "";
            this.ds_provisao.NM_CampoBusca = "";
            this.ds_provisao.NM_Param = "";
            this.ds_provisao.QTD_Zero = 0;
            this.ds_provisao.Size = new System.Drawing.Size(426, 20);
            this.ds_provisao.ST_AutoInc = false;
            this.ds_provisao.ST_DisableAuto = false;
            this.ds_provisao.ST_Float = false;
            this.ds_provisao.ST_Gravar = false;
            this.ds_provisao.ST_Int = false;
            this.ds_provisao.ST_LimpaCampo = true;
            this.ds_provisao.ST_NotNull = false;
            this.ds_provisao.ST_PrimaryKey = false;
            this.ds_provisao.TabIndex = 0;
            // 
            // TFProvisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 177);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFProvisao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Provisão Estoque";
            this.Load += new System.EventHandler(this.TFProvisao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProvisao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisao)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.BindingSource bsProvisao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_provisao;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault DS_Produto;
        public System.Windows.Forms.Button BB_Local;
        private Componentes.EditDefault DS_Local;
        public Componentes.EditDefault CD_Local;
        private System.Windows.Forms.Button BB_Produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditFloat quantidade;
        private Componentes.EditFloat VL_Unitario;
        private Componentes.EditDefault sigla_unidade;
    }
}