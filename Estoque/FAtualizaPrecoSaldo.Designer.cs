namespace Estoque
{
    partial class TFAtualizaPrecoSaldo
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
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtualizaPrecoSaldo));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_novoProd = new System.Windows.Forms.Button();
            this.codBarra = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.radioGroup2 = new Componentes.RadioGroup(this.components);
            this.vl_precovenda = new Componentes.EditFloat(this.components);
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.bb_tabpreco = new System.Windows.Forms.Button();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.total_entrada = new Componentes.EditFloat(this.components);
            this.vl_entrada = new Componentes.EditFloat(this.components);
            this.qtd_entrada = new Componentes.EditFloat(this.components);
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.vl_custo = new Componentes.EditFloat(this.components);
            this.quantidade = new Componentes.EditFloat(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).BeginInit();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.total_entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(19, 91);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(88, 13);
            label8.TabIndex = 138;
            label8.Text = "Codigo de Barras";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(16, 64);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(69, 13);
            label7.TabIndex = 139;
            label7.Text = "Preço Venda";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(14, 25);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 13);
            label6.TabIndex = 137;
            label6.Text = "Tabela Preço";
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(19, 131);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(48, 13);
            cd_empresaLabel.TabIndex = 132;
            cd_empresaLabel.Text = "Empresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(258, 65);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 13);
            label2.TabIndex = 136;
            label2.Text = "Custo Total";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(123, 65);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 13);
            label3.TabIndex = 135;
            label3.Text = "Vl. Custo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(10, 65);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 13);
            label5.TabIndex = 134;
            label5.Text = "Quantidade";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(9, 25);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(103, 13);
            label1.TabIndex = 130;
            label1.Text = "Local Armazenagem";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Excluir,
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(757, 43);
            this.barraMenu.TabIndex = 6;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(80, 40);
            this.BB_Excluir.Text = "(F5)\r\nLimpar";
            this.BB_Excluir.ToolTipText = "Excluir Venda";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.bb_novoProd);
            this.pDados.Controls.Add(this.codBarra);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.radioGroup2);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(757, 319);
            this.pDados.TabIndex = 0;
            // 
            // bb_novoProd
            // 
            this.bb_novoProd.Image = ((System.Drawing.Image)(resources.GetObject("bb_novoProd.Image")));
            this.bb_novoProd.Location = new System.Drawing.Point(682, 27);
            this.bb_novoProd.Name = "bb_novoProd";
            this.bb_novoProd.Size = new System.Drawing.Size(52, 35);
            this.bb_novoProd.TabIndex = 137;
            this.bb_novoProd.UseVisualStyleBackColor = true;
            this.bb_novoProd.Click += new System.EventHandler(this.bb_novoProd_Click);
            // 
            // codBarra
            // 
            this.codBarra.BackColor = System.Drawing.SystemColors.Window;
            this.codBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codBarra.Enabled = false;
            this.codBarra.Location = new System.Drawing.Point(22, 107);
            this.codBarra.Name = "codBarra";
            this.codBarra.NM_Alias = "";
            this.codBarra.NM_Campo = "DS_Produto";
            this.codBarra.NM_CampoBusca = "DS_Produto";
            this.codBarra.NM_Param = "@P_DS_PRODUTO";
            this.codBarra.QTD_Zero = 0;
            this.codBarra.Size = new System.Drawing.Size(712, 20);
            this.codBarra.ST_AutoInc = false;
            this.codBarra.ST_DisableAuto = false;
            this.codBarra.ST_Float = false;
            this.codBarra.ST_Gravar = false;
            this.codBarra.ST_Int = false;
            this.codBarra.ST_LimpaCampo = true;
            this.codBarra.ST_NotNull = false;
            this.codBarra.ST_PrimaryKey = false;
            this.codBarra.TabIndex = 136;
            this.codBarra.TextOld = null;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Location = new System.Drawing.Point(22, 68);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.Size = new System.Drawing.Size(712, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 135;
            this.DS_Produto.TextOld = null;
            // 
            // radioGroup2
            // 
            this.radioGroup2.Controls.Add(label7);
            this.radioGroup2.Controls.Add(this.vl_precovenda);
            this.radioGroup2.Controls.Add(this.ds_tabelapreco);
            this.radioGroup2.Controls.Add(this.bb_tabpreco);
            this.radioGroup2.Controls.Add(this.cd_tabelapreco);
            this.radioGroup2.Controls.Add(label6);
            this.radioGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup2.Location = new System.Drawing.Point(417, 175);
            this.radioGroup2.Name = "radioGroup2";
            this.radioGroup2.NM_Alias = "";
            this.radioGroup2.NM_Campo = "";
            this.radioGroup2.NM_Param = "";
            this.radioGroup2.NM_Valor = "";
            this.radioGroup2.Size = new System.Drawing.Size(321, 118);
            this.radioGroup2.ST_Gravar = false;
            this.radioGroup2.ST_NotNull = false;
            this.radioGroup2.TabIndex = 134;
            this.radioGroup2.TabStop = false;
            this.radioGroup2.Text = "Preço Venda";
            // 
            // vl_precovenda
            // 
            this.vl_precovenda.DecimalPlaces = 2;
            this.vl_precovenda.Enabled = false;
            this.vl_precovenda.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_precovenda.Location = new System.Drawing.Point(18, 79);
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
            this.vl_precovenda.Size = new System.Drawing.Size(107, 21);
            this.vl_precovenda.ST_AutoInc = false;
            this.vl_precovenda.ST_DisableAuto = false;
            this.vl_precovenda.ST_Gravar = false;
            this.vl_precovenda.ST_LimparCampo = true;
            this.vl_precovenda.ST_NotNull = false;
            this.vl_precovenda.ST_PrimaryKey = false;
            this.vl_precovenda.TabIndex = 136;
            this.vl_precovenda.ThousandsSeparator = true;
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Location = new System.Drawing.Point(119, 41);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_NM_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(197, 21);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 138;
            this.ds_tabelapreco.TextOld = null;
            // 
            // bb_tabpreco
            // 
            this.bb_tabpreco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tabpreco.Enabled = false;
            this.bb_tabpreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabpreco.Image")));
            this.bb_tabpreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabpreco.Location = new System.Drawing.Point(85, 41);
            this.bb_tabpreco.Name = "bb_tabpreco";
            this.bb_tabpreco.Size = new System.Drawing.Size(28, 19);
            this.bb_tabpreco.TabIndex = 135;
            this.bb_tabpreco.UseVisualStyleBackColor = false;
            this.bb_tabpreco.Click += new System.EventHandler(this.bb_tabpreco_Click);
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.BackColor = System.Drawing.Color.White;
            this.cd_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.Enabled = false;
            this.cd_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_tabelapreco.Location = new System.Drawing.Point(17, 41);
            this.cd_tabelapreco.MaxLength = 4;
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_CD_EMPRESA";
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
            this.cd_tabelapreco.TabIndex = 134;
            this.cd_tabelapreco.TextOld = null;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(124, 147);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(610, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 133;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(90, 147);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 131;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(22, 147);
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
            this.cd_empresa.TabIndex = 130;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.total_entrada);
            this.radioGroup1.Controls.Add(this.vl_entrada);
            this.radioGroup1.Controls.Add(this.qtd_entrada);
            this.radioGroup1.Controls.Add(this.vl_subtotal);
            this.radioGroup1.Controls.Add(label2);
            this.radioGroup1.Controls.Add(this.vl_custo);
            this.radioGroup1.Controls.Add(label3);
            this.radioGroup1.Controls.Add(this.quantidade);
            this.radioGroup1.Controls.Add(label5);
            this.radioGroup1.Controls.Add(this.ds_local);
            this.radioGroup1.Controls.Add(this.bb_local);
            this.radioGroup1.Controls.Add(this.cd_local);
            this.radioGroup1.Controls.Add(label1);
            this.radioGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Location = new System.Drawing.Point(22, 173);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(379, 138);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Saldo Estoque";
            // 
            // total_entrada
            // 
            this.total_entrada.DecimalPlaces = 2;
            this.total_entrada.Enabled = false;
            this.total_entrada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.total_entrada.Location = new System.Drawing.Point(260, 110);
            this.total_entrada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.total_entrada.Name = "total_entrada";
            this.total_entrada.NM_Alias = "";
            this.total_entrada.NM_Campo = "";
            this.total_entrada.NM_Param = "";
            this.total_entrada.Operador = "";
            this.total_entrada.Size = new System.Drawing.Size(107, 21);
            this.total_entrada.ST_AutoInc = false;
            this.total_entrada.ST_DisableAuto = false;
            this.total_entrada.ST_Gravar = false;
            this.total_entrada.ST_LimparCampo = true;
            this.total_entrada.ST_NotNull = false;
            this.total_entrada.ST_PrimaryKey = false;
            this.total_entrada.TabIndex = 140;
            this.total_entrada.ThousandsSeparator = true;
            // 
            // vl_entrada
            // 
            this.vl_entrada.DecimalPlaces = 5;
            this.vl_entrada.Enabled = false;
            this.vl_entrada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_entrada.Location = new System.Drawing.Point(125, 110);
            this.vl_entrada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_entrada.Name = "vl_entrada";
            this.vl_entrada.NM_Alias = "";
            this.vl_entrada.NM_Campo = "";
            this.vl_entrada.NM_Param = "";
            this.vl_entrada.Operador = "";
            this.vl_entrada.Size = new System.Drawing.Size(107, 21);
            this.vl_entrada.ST_AutoInc = false;
            this.vl_entrada.ST_DisableAuto = false;
            this.vl_entrada.ST_Gravar = false;
            this.vl_entrada.ST_LimparCampo = true;
            this.vl_entrada.ST_NotNull = false;
            this.vl_entrada.ST_PrimaryKey = false;
            this.vl_entrada.TabIndex = 139;
            this.vl_entrada.ThousandsSeparator = true;
            this.vl_entrada.Leave += new System.EventHandler(this.vl_entrada_Leave);
            // 
            // qtd_entrada
            // 
            this.qtd_entrada.DecimalPlaces = 3;
            this.qtd_entrada.Enabled = false;
            this.qtd_entrada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_entrada.Location = new System.Drawing.Point(12, 110);
            this.qtd_entrada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_entrada.Name = "qtd_entrada";
            this.qtd_entrada.NM_Alias = "";
            this.qtd_entrada.NM_Campo = "";
            this.qtd_entrada.NM_Param = "";
            this.qtd_entrada.Operador = "";
            this.qtd_entrada.Size = new System.Drawing.Size(107, 21);
            this.qtd_entrada.ST_AutoInc = false;
            this.qtd_entrada.ST_DisableAuto = false;
            this.qtd_entrada.ST_Gravar = false;
            this.qtd_entrada.ST_LimparCampo = true;
            this.qtd_entrada.ST_NotNull = false;
            this.qtd_entrada.ST_PrimaryKey = false;
            this.qtd_entrada.TabIndex = 138;
            this.qtd_entrada.ThousandsSeparator = true;
            this.qtd_entrada.Leave += new System.EventHandler(this.qtd_entrada_Leave);
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(261, 81);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.Size = new System.Drawing.Size(107, 21);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = false;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 137;
            this.vl_subtotal.ThousandsSeparator = true;
            // 
            // vl_custo
            // 
            this.vl_custo.DecimalPlaces = 5;
            this.vl_custo.Enabled = false;
            this.vl_custo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_custo.Location = new System.Drawing.Point(126, 81);
            this.vl_custo.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            0});
            this.vl_custo.Name = "vl_custo";
            this.vl_custo.NM_Alias = "";
            this.vl_custo.NM_Campo = "";
            this.vl_custo.NM_Param = "";
            this.vl_custo.Operador = "";
            this.vl_custo.Size = new System.Drawing.Size(107, 21);
            this.vl_custo.ST_AutoInc = false;
            this.vl_custo.ST_DisableAuto = false;
            this.vl_custo.ST_Gravar = false;
            this.vl_custo.ST_LimparCampo = true;
            this.vl_custo.ST_NotNull = false;
            this.vl_custo.ST_PrimaryKey = false;
            this.vl_custo.TabIndex = 133;
            this.vl_custo.ThousandsSeparator = true;
            // 
            // quantidade
            // 
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Enabled = false;
            this.quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantidade.Location = new System.Drawing.Point(13, 81);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(107, 21);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 132;
            this.quantidade.ThousandsSeparator = true;
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(114, 41);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "a";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_NM_EMPRESA";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(254, 21);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 131;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            this.bb_local.Enabled = false;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(80, 41);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 127;
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.Color.White;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.Enabled = false;
            this.cd_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_local.Location = new System.Drawing.Point(12, 41);
            this.cd_local.MaxLength = 4;
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "a";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(67, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = false;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 126;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Produto (F12)";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Enabled = false;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_produto.Location = new System.Drawing.Point(22, 27);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(657, 35);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 1;
            this.cd_produto.TextOld = null;
            this.cd_produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_produto_KeyDown);
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // TFAtualizaPrecoSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 362);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAtualizaPrecoSaldo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualização Preço Venda/Custo/Saldo Estoque";
            this.Load += new System.EventHandler(this.TFAtualizaPrecoSaldo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtualizaPrecoSaldo_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup2.ResumeLayout(false);
            this.radioGroup2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_precovenda)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.total_entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pDados;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_produto;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault cd_local;
        private Componentes.RadioGroup radioGroup2;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditFloat vl_subtotal;
        private Componentes.EditFloat vl_custo;
        private Componentes.EditFloat quantidade;
        public Componentes.EditDefault DS_Produto;
        public Componentes.EditDefault codBarra;
        private Componentes.EditFloat vl_precovenda;
        private Componentes.EditDefault ds_tabelapreco;
        private System.Windows.Forms.Button bb_tabpreco;
        private Componentes.EditDefault cd_tabelapreco;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Excluir;
        private Componentes.EditFloat total_entrada;
        private Componentes.EditFloat vl_entrada;
        private Componentes.EditFloat qtd_entrada;
        private System.Windows.Forms.Button bb_novoProd;
    }
}