namespace Proc_Commoditties
{
    partial class TFNovoLoteAnvisa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFNovoLoteAnvisa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pLote = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.dt_validade = new Componentes.EditData(this.components);
            this.bsLoteAnvisa = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_fabric = new Componentes.EditData(this.components);
            this.nr_lote = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nm_fornecedor = new Componentes.EditDefault(this.components);
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pLote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteAnvisa)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(479, 43);
            this.barraMenu.TabIndex = 537;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(100, 40);
            this.BB_Gravar.Text = " (F4)\r\n Confirmar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pLote
            // 
            this.pLote.Controls.Add(this.label6);
            this.pLote.Controls.Add(this.dt_validade);
            this.pLote.Controls.Add(this.label5);
            this.pLote.Controls.Add(this.dt_fabric);
            this.pLote.Controls.Add(this.nr_lote);
            this.pLote.Controls.Add(this.label4);
            this.pLote.Controls.Add(this.nm_fornecedor);
            this.pLote.Controls.Add(this.cd_fornecedor);
            this.pLote.Controls.Add(this.bb_fornecedor);
            this.pLote.Controls.Add(this.label3);
            this.pLote.Controls.Add(this.ds_produto);
            this.pLote.Controls.Add(this.cd_produto);
            this.pLote.Controls.Add(this.bb_produto);
            this.pLote.Controls.Add(this.label2);
            this.pLote.Controls.Add(this.nm_empresa);
            this.pLote.Controls.Add(this.cd_empresa);
            this.pLote.Controls.Add(this.bb_empresa);
            this.pLote.Controls.Add(this.label1);
            this.pLote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLote.Location = new System.Drawing.Point(0, 43);
            this.pLote.Name = "pLote";
            this.pLote.NM_ProcDeletar = "";
            this.pLote.NM_ProcGravar = "";
            this.pLote.Size = new System.Drawing.Size(479, 165);
            this.pLote.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Dt. Validação";
            // 
            // dt_validade
            // 
            this.dt_validade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_validade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Dt_validadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_validade.Location = new System.Drawing.Point(372, 138);
            this.dt_validade.Mask = "00/00/0000";
            this.dt_validade.Name = "dt_validade";
            this.dt_validade.NM_Alias = "";
            this.dt_validade.NM_Campo = "";
            this.dt_validade.NM_CampoBusca = "";
            this.dt_validade.NM_Param = "";
            this.dt_validade.Operador = "";
            this.dt_validade.Size = new System.Drawing.Size(100, 20);
            this.dt_validade.ST_Gravar = false;
            this.dt_validade.ST_LimpaCampo = true;
            this.dt_validade.ST_NotNull = false;
            this.dt_validade.ST_PrimaryKey = false;
            this.dt_validade.TabIndex = 8;
            // 
            // bsLoteAnvisa
            // 
            this.bsLoteAnvisa.DataSource = typeof(CamadaDados.Faturamento.LoteAnvisa.TList_LoteAnvisa);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(263, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Dt. Fabricação";
            // 
            // dt_fabric
            // 
            this.dt_fabric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fabric.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Dt_fabricstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_fabric.Location = new System.Drawing.Point(266, 138);
            this.dt_fabric.Mask = "00/00/0000";
            this.dt_fabric.Name = "dt_fabric";
            this.dt_fabric.NM_Alias = "";
            this.dt_fabric.NM_Campo = "";
            this.dt_fabric.NM_CampoBusca = "";
            this.dt_fabric.NM_Param = "";
            this.dt_fabric.Operador = "";
            this.dt_fabric.Size = new System.Drawing.Size(100, 20);
            this.dt_fabric.ST_Gravar = false;
            this.dt_fabric.ST_LimpaCampo = true;
            this.dt_fabric.ST_NotNull = false;
            this.dt_fabric.ST_PrimaryKey = false;
            this.dt_fabric.TabIndex = 7;
            // 
            // nr_lote
            // 
            this.nr_lote.BackColor = System.Drawing.SystemColors.Window;
            this.nr_lote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_lote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Nr_lote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_lote.Location = new System.Drawing.Point(6, 138);
            this.nr_lote.Name = "nr_lote";
            this.nr_lote.NM_Alias = "";
            this.nr_lote.NM_Campo = "";
            this.nr_lote.NM_CampoBusca = "";
            this.nr_lote.NM_Param = "";
            this.nr_lote.QTD_Zero = 0;
            this.nr_lote.Size = new System.Drawing.Size(254, 20);
            this.nr_lote.ST_AutoInc = false;
            this.nr_lote.ST_DisableAuto = false;
            this.nr_lote.ST_Float = false;
            this.nr_lote.ST_Gravar = true;
            this.nr_lote.ST_Int = false;
            this.nr_lote.ST_LimpaCampo = true;
            this.nr_lote.ST_NotNull = false;
            this.nr_lote.ST_PrimaryKey = false;
            this.nr_lote.TabIndex = 6;
            this.nr_lote.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nº Lote";
            // 
            // nm_fornecedor
            // 
            this.nm_fornecedor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Nm_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_fornecedor.Enabled = false;
            this.nm_fornecedor.Location = new System.Drawing.Point(108, 99);
            this.nm_fornecedor.Name = "nm_fornecedor";
            this.nm_fornecedor.NM_Alias = "";
            this.nm_fornecedor.NM_Campo = "nm_clifor";
            this.nm_fornecedor.NM_CampoBusca = "nm_clifor";
            this.nm_fornecedor.NM_Param = "@P_NM_CLIFOR";
            this.nm_fornecedor.QTD_Zero = 0;
            this.nm_fornecedor.Size = new System.Drawing.Size(364, 20);
            this.nm_fornecedor.ST_AutoInc = false;
            this.nm_fornecedor.ST_DisableAuto = false;
            this.nm_fornecedor.ST_Float = false;
            this.nm_fornecedor.ST_Gravar = false;
            this.nm_fornecedor.ST_Int = false;
            this.nm_fornecedor.ST_LimpaCampo = true;
            this.nm_fornecedor.ST_NotNull = false;
            this.nm_fornecedor.ST_PrimaryKey = false;
            this.nm_fornecedor.TabIndex = 12;
            this.nm_fornecedor.TextOld = null;
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.BackColor = System.Drawing.Color.White;
            this.cd_fornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Cd_fornecedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_fornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_fornecedor.Location = new System.Drawing.Point(6, 99);
            this.cd_fornecedor.MaxLength = 4;
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_clifor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_EMPRESA";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.Size = new System.Drawing.Size(67, 20);
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = true;
            this.cd_fornecedor.ST_Int = false;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = false;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.TabIndex = 4;
            this.cd_fornecedor.TextOld = null;
            this.cd_fornecedor.Leave += new System.EventHandler(this.cd_fornecedor_Leave);
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_fornecedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_fornecedor.Image")));
            this.bb_fornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_fornecedor.Location = new System.Drawing.Point(74, 99);
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.Size = new System.Drawing.Size(28, 20);
            this.bb_fornecedor.TabIndex = 5;
            this.bb_fornecedor.UseVisualStyleBackColor = false;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fornecedor";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(108, 60);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(364, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 8;
            this.ds_produto.TextOld = null;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(6, 60);
            this.cd_produto.MaxLength = 4;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(67, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(74, 60);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 20);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Produto";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(108, 21);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(364, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 4;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLoteAnvisa, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(6, 21);
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
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(74, 21);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // TFNovoLoteAnvisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 208);
            this.Controls.Add(this.pLote);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFNovoLoteAnvisa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novo Lote Anvisa";
            this.Load += new System.EventHandler(this.FNovoLoteAnvisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FNovoLoteAnvisa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pLote.ResumeLayout(false);
            this.pLote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLoteAnvisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pLote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Componentes.EditData dt_validade;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_fabric;
        private Componentes.EditDefault nr_lote;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault nm_fornecedor;
        private Componentes.EditDefault cd_fornecedor;
        private System.Windows.Forms.Button bb_fornecedor;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.BindingSource bsLoteAnvisa;
    }
}