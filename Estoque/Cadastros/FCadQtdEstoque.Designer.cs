namespace Estoque.Cadastros
{
    partial class TFCadQtdEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadQtdEstoque));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.bsQtdEstoque = new System.Windows.Forms.BindingSource(this.components);
            this.qtd_max_estoque = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.qtd_min_estoque = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsQtdEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_max_estoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_min_estoque)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(574, 43);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.qtd_max_estoque);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.SG_Unidade_Estoque);
            this.pDados.Controls.Add(this.qtd_min_estoque);
            this.pDados.Controls.Add(this.label58);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(574, 63);
            this.pDados.TabIndex = 3;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsQtdEstoque, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(461, 32);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "Sigla_Unidade";
            this.editDefault1.NM_CampoBusca = "Sigla_Unidade";
            this.editDefault1.NM_Param = "@P_SIGLA_UNIDADE";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ReadOnly = true;
            this.editDefault1.Size = new System.Drawing.Size(42, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 124;
            // 
            // bsQtdEstoque
            // 
            this.bsQtdEstoque.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_Produto_QtdEstoque);
            // 
            // qtd_max_estoque
            // 
            this.qtd_max_estoque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsQtdEstoque, "Qt_max_estoque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_max_estoque.DecimalPlaces = 3;
            this.qtd_max_estoque.Location = new System.Drawing.Point(355, 32);
            this.qtd_max_estoque.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.qtd_max_estoque.Name = "qtd_max_estoque";
            this.qtd_max_estoque.NM_Alias = "";
            this.qtd_max_estoque.NM_Campo = "Quantidade";
            this.qtd_max_estoque.NM_Param = "@P_QUANTIDADE";
            this.qtd_max_estoque.Operador = "";
            this.qtd_max_estoque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_max_estoque.Size = new System.Drawing.Size(104, 20);
            this.qtd_max_estoque.ST_AutoInc = false;
            this.qtd_max_estoque.ST_DisableAuto = false;
            this.qtd_max_estoque.ST_Gravar = true;
            this.qtd_max_estoque.ST_LimparCampo = true;
            this.qtd_max_estoque.ST_NotNull = false;
            this.qtd_max_estoque.ST_PrimaryKey = false;
            this.qtd_max_estoque.TabIndex = 3;
            this.qtd_max_estoque.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(254, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "Qtd. Max. Estoque:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SG_Unidade_Estoque
            // 
            this.SG_Unidade_Estoque.BackColor = System.Drawing.SystemColors.Window;
            this.SG_Unidade_Estoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_Unidade_Estoque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsQtdEstoque, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SG_Unidade_Estoque.Enabled = false;
            this.SG_Unidade_Estoque.Location = new System.Drawing.Point(206, 33);
            this.SG_Unidade_Estoque.Name = "SG_Unidade_Estoque";
            this.SG_Unidade_Estoque.NM_Alias = "";
            this.SG_Unidade_Estoque.NM_Campo = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_CampoBusca = "Sigla_Unidade";
            this.SG_Unidade_Estoque.NM_Param = "@P_SIGLA_UNIDADE";
            this.SG_Unidade_Estoque.QTD_Zero = 0;
            this.SG_Unidade_Estoque.ReadOnly = true;
            this.SG_Unidade_Estoque.Size = new System.Drawing.Size(42, 20);
            this.SG_Unidade_Estoque.ST_AutoInc = false;
            this.SG_Unidade_Estoque.ST_DisableAuto = false;
            this.SG_Unidade_Estoque.ST_Float = false;
            this.SG_Unidade_Estoque.ST_Gravar = false;
            this.SG_Unidade_Estoque.ST_Int = false;
            this.SG_Unidade_Estoque.ST_LimpaCampo = true;
            this.SG_Unidade_Estoque.ST_NotNull = false;
            this.SG_Unidade_Estoque.ST_PrimaryKey = false;
            this.SG_Unidade_Estoque.TabIndex = 121;
            // 
            // qtd_min_estoque
            // 
            this.qtd_min_estoque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsQtdEstoque, "Qt_min_estoque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_min_estoque.DecimalPlaces = 3;
            this.qtd_min_estoque.Location = new System.Drawing.Point(100, 33);
            this.qtd_min_estoque.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.qtd_min_estoque.Name = "qtd_min_estoque";
            this.qtd_min_estoque.NM_Alias = "";
            this.qtd_min_estoque.NM_Campo = "Quantidade";
            this.qtd_min_estoque.NM_Param = "@P_QUANTIDADE";
            this.qtd_min_estoque.Operador = "";
            this.qtd_min_estoque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_min_estoque.Size = new System.Drawing.Size(104, 20);
            this.qtd_min_estoque.ST_AutoInc = false;
            this.qtd_min_estoque.ST_DisableAuto = false;
            this.qtd_min_estoque.ST_Gravar = true;
            this.qtd_min_estoque.ST_LimparCampo = true;
            this.qtd_min_estoque.ST_NotNull = false;
            this.qtd_min_estoque.ST_PrimaryKey = false;
            this.qtd_min_estoque.TabIndex = 2;
            this.qtd_min_estoque.ThousandsSeparator = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(-1, 36);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(95, 13);
            this.label58.TabIndex = 122;
            this.label58.Text = "Qtd. Min. Estoque:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsQtdEstoque, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(222, 7);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PRODUTO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ReadOnly = true;
            this.nm_empresa.Size = new System.Drawing.Size(345, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 119;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(193, 7);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(43, 10);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(51, 13);
            this.label55.TabIndex = 120;
            this.label55.Text = "Empresa:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsQtdEstoque, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(100, 7);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_PRODUTO";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(90, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TFCadQtdEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 106);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TFCadQtdEstoque";
            this.Text = "Quantidade Produto Estoque";
            this.Load += new System.EventHandler(this.TFCadQtdEstoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCadQtdEstoque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsQtdEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_max_estoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_min_estoque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        public Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label55;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.BindingSource bsQtdEstoque;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault SG_Unidade_Estoque;
        private Componentes.EditFloat qtd_min_estoque;
        private Componentes.EditFloat qtd_max_estoque;
    }
}