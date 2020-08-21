namespace Financeiro.Cadastros
{
    partial class TFDescontoVendedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDescontoVendedor));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_desconto = new Componentes.ComboBoxDefault(this.components);
            this.bsDescontoVendedor = new System.Windows.Forms.BindingSource(this.components);
            this.pc_max_desconto = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Grupo = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDescontoVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_max_desconto)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(578, 43);
            this.barraMenu.TabIndex = 538;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_desconto);
            this.pDados.Controls.Add(this.pc_max_desconto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(this.cd_tabelapreco);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Grupo);
            this.pDados.Controls.Add(this.LB_CD_Grupo);
            this.pDados.Controls.Add(this.DS_Grupo);
            this.pDados.Controls.Add(this.bb_grupo);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(578, 171);
            this.pDados.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(127, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Tipo Desconto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tp_desconto
            // 
            this.tp_desconto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDescontoVendedor, "Tp_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_desconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_desconto.FormattingEnabled = true;
            this.tp_desconto.Location = new System.Drawing.Point(130, 137);
            this.tp_desconto.Name = "tp_desconto";
            this.tp_desconto.NM_Alias = "";
            this.tp_desconto.NM_Campo = "";
            this.tp_desconto.NM_Param = "";
            this.tp_desconto.Size = new System.Drawing.Size(121, 21);
            this.tp_desconto.ST_Gravar = true;
            this.tp_desconto.ST_LimparCampo = true;
            this.tp_desconto.ST_NotNull = true;
            this.tp_desconto.TabIndex = 7;
            // 
            // bsDescontoVendedor
            // 
            this.bsDescontoVendedor.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_DescontoVendedor);
            // 
            // pc_max_desconto
            // 
            this.pc_max_desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDescontoVendedor, "Pc_max_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_max_desconto.DecimalPlaces = 5;
            this.pc_max_desconto.Location = new System.Drawing.Point(11, 137);
            this.pc_max_desconto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_max_desconto.Name = "pc_max_desconto";
            this.pc_max_desconto.NM_Alias = "";
            this.pc_max_desconto.NM_Campo = "";
            this.pc_max_desconto.NM_Param = "";
            this.pc_max_desconto.Operador = "";
            this.pc_max_desconto.Size = new System.Drawing.Size(113, 20);
            this.pc_max_desconto.ST_AutoInc = false;
            this.pc_max_desconto.ST_DisableAuto = false;
            this.pc_max_desconto.ST_Gravar = true;
            this.pc_max_desconto.ST_LimparCampo = true;
            this.pc_max_desconto.ST_NotNull = true;
            this.pc_max_desconto.ST_PrimaryKey = false;
            this.pc_max_desconto.TabIndex = 6;
            this.pc_max_desconto.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Max. Desconto";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tabelapreco.Location = new System.Drawing.Point(130, 98);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_NM_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(434, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 85;
            this.ds_tabelapreco.TextOld = null;
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelapreco.Image")));
            this.bb_tabelapreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelapreco.Location = new System.Drawing.Point(94, 98);
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.Size = new System.Drawing.Size(30, 20);
            this.bb_tabelapreco.TabIndex = 5;
            this.bb_tabelapreco.UseVisualStyleBackColor = true;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Cd_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_tabelapreco.Location = new System.Drawing.Point(11, 98);
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "a";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.cd_tabelapreco.QTD_Zero = 0;
            this.cd_tabelapreco.Size = new System.Drawing.Size(82, 20);
            this.cd_tabelapreco.ST_AutoInc = false;
            this.cd_tabelapreco.ST_DisableAuto = false;
            this.cd_tabelapreco.ST_Float = false;
            this.cd_tabelapreco.ST_Gravar = true;
            this.cd_tabelapreco.ST_Int = true;
            this.cd_tabelapreco.ST_LimpaCampo = true;
            this.cd_tabelapreco.ST_NotNull = false;
            this.cd_tabelapreco.ST_PrimaryKey = false;
            this.cd_tabelapreco.TabIndex = 4;
            this.cd_tabelapreco.TextOld = null;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Tabela Preço";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(11, 59);
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
            this.CD_Grupo.ST_NotNull = false;
            this.CD_Grupo.ST_PrimaryKey = false;
            this.CD_Grupo.TabIndex = 2;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(8, 43);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(76, 13);
            this.LB_CD_Grupo.TabIndex = 80;
            this.LB_CD_Grupo.Text = "Grupo Produto";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Grupo
            // 
            this.DS_Grupo.BackColor = System.Drawing.Color.White;
            this.DS_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Grupo.Enabled = false;
            this.DS_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Grupo.Location = new System.Drawing.Point(106, 59);
            this.DS_Grupo.Name = "DS_Grupo";
            this.DS_Grupo.NM_Alias = "a";
            this.DS_Grupo.NM_Campo = "ds_grupo";
            this.DS_Grupo.NM_CampoBusca = "ds_grupo";
            this.DS_Grupo.NM_Param = "";
            this.DS_Grupo.QTD_Zero = 0;
            this.DS_Grupo.ReadOnly = true;
            this.DS_Grupo.Size = new System.Drawing.Size(458, 20);
            this.DS_Grupo.ST_AutoInc = false;
            this.DS_Grupo.ST_DisableAuto = false;
            this.DS_Grupo.ST_Float = false;
            this.DS_Grupo.ST_Gravar = false;
            this.DS_Grupo.ST_Int = false;
            this.DS_Grupo.ST_LimpaCampo = true;
            this.DS_Grupo.ST_NotNull = false;
            this.DS_Grupo.ST_PrimaryKey = false;
            this.DS_Grupo.TabIndex = 81;
            this.DS_Grupo.TextOld = null;
            // 
            // bb_grupo
            // 
            this.bb_grupo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupo.Location = new System.Drawing.Point(71, 59);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(30, 20);
            this.bb_grupo.TabIndex = 3;
            this.bb_grupo.UseVisualStyleBackColor = true;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(130, 20);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(434, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 77;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(94, 20);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(30, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDescontoVendedor, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(11, 20);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "a";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(82, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(8, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 76;
            this.label10.Text = "Empresa";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TFDescontoVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 214);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDescontoVendedor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desconto Vendedor";
            this.Load += new System.EventHandler(this.TFDescontoVendedor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDescontoVendedor_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDescontoVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_max_desconto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label10;
        private Componentes.EditDefault CD_Grupo;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Grupo;
        private Componentes.EditFloat pc_max_desconto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_tabelapreco;
        private System.Windows.Forms.Button bb_tabelapreco;
        private Componentes.EditDefault cd_tabelapreco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsDescontoVendedor;
        private System.Windows.Forms.Button bb_grupo;
        private Componentes.ComboBoxDefault tp_desconto;
        private System.Windows.Forms.Label label3;
    }
}