namespace Estoque.Cadastros
{
    partial class TFItensFichaTec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensFichaTec));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.vl_servico = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.vl_custoservico = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_servico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custoservico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(619, 43);
            this.barraMenu.TabIndex = 1;
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
            this.pDados.Controls.Add(this.vl_servico);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.vl_custoservico);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.SG_Unidade_Estoque);
            this.pDados.Controls.Add(this.Quantidade);
            this.pDados.Controls.Add(this.label58);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.BB_Produto);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(619, 56);
            this.pDados.TabIndex = 0;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_FichaTecProduto);
            // 
            // vl_servico
            // 
            this.vl_servico.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_subtotalservico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_servico.DecimalPlaces = 2;
            this.vl_servico.Enabled = false;
            this.vl_servico.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_servico.Location = new System.Drawing.Point(530, 28);
            this.vl_servico.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_servico.Name = "vl_servico";
            this.vl_servico.NM_Alias = "";
            this.vl_servico.NM_Campo = "Quantidade";
            this.vl_servico.NM_Param = "@P_QUANTIDADE";
            this.vl_servico.Operador = "";
            this.vl_servico.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_servico.Size = new System.Drawing.Size(82, 20);
            this.vl_servico.ST_AutoInc = false;
            this.vl_servico.ST_DisableAuto = false;
            this.vl_servico.ST_Gravar = false;
            this.vl_servico.ST_LimparCampo = true;
            this.vl_servico.ST_NotNull = true;
            this.vl_servico.ST_PrimaryKey = false;
            this.vl_servico.TabIndex = 119;
            this.vl_servico.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(463, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 120;
            this.label2.Text = "Vl. Serviço:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Sg_unditem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(415, 30);
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
            this.editDefault1.TabIndex = 118;
            this.editDefault1.TextOld = null;
            // 
            // vl_custoservico
            // 
            this.vl_custoservico.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_custoservico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_custoservico.DecimalPlaces = 5;
            this.vl_custoservico.Enabled = false;
            this.vl_custoservico.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_custoservico.Location = new System.Drawing.Point(330, 30);
            this.vl_custoservico.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_custoservico.Name = "vl_custoservico";
            this.vl_custoservico.NM_Alias = "";
            this.vl_custoservico.NM_Campo = "Quantidade";
            this.vl_custoservico.NM_Param = "@P_QUANTIDADE";
            this.vl_custoservico.Operador = "";
            this.vl_custoservico.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_custoservico.Size = new System.Drawing.Size(82, 20);
            this.vl_custoservico.ST_AutoInc = false;
            this.vl_custoservico.ST_DisableAuto = false;
            this.vl_custoservico.ST_Gravar = true;
            this.vl_custoservico.ST_LimparCampo = true;
            this.vl_custoservico.ST_NotNull = true;
            this.vl_custoservico.ST_PrimaryKey = false;
            this.vl_custoservico.TabIndex = 3;
            this.vl_custoservico.ThousandsSeparator = true;
            this.vl_custoservico.EnabledChanged += new System.EventHandler(this.vl_custoservico_EnabledChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(238, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Vl. Unit. Serviço:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SG_Unidade_Estoque
            // 
            this.SG_Unidade_Estoque.BackColor = System.Drawing.SystemColors.Window;
            this.SG_Unidade_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_Unidade_Estoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_Unidade_Estoque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Sg_unditem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SG_Unidade_Estoque.Enabled = false;
            this.SG_Unidade_Estoque.Location = new System.Drawing.Point(190, 29);
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
            this.SG_Unidade_Estoque.TabIndex = 114;
            this.SG_Unidade_Estoque.TextOld = null;
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.Location = new System.Drawing.Point(84, 29);
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
            this.Quantidade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Quantidade.Size = new System.Drawing.Size(104, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 2;
            this.Quantidade.ThousandsSeparator = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(13, 32);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(65, 13);
            this.label58.TabIndex = 115;
            this.label58.Text = "Quantidade:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Ds_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Location = new System.Drawing.Point(206, 3);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.Size = new System.Drawing.Size(406, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 86;
            this.DS_Produto.TextOld = null;
            // 
            // BB_Produto
            // 
            this.BB_Produto.Image = ((System.Drawing.Image)(resources.GetObject("BB_Produto.Image")));
            this.BB_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Produto.Location = new System.Drawing.Point(177, 3);
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.Size = new System.Drawing.Size(28, 19);
            this.BB_Produto.TabIndex = 1;
            this.BB_Produto.UseVisualStyleBackColor = true;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(31, 6);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(47, 13);
            this.label55.TabIndex = 87;
            this.label55.Text = "Produto:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Location = new System.Drawing.Point(84, 3);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(90, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // TFItensFichaTec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 99);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensFichaTec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Ficha Tecnica";
            this.Load += new System.EventHandler(this.TFItensFichaTec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensFichaTec_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_servico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custoservico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        public Componentes.EditDefault DS_Produto;
        public System.Windows.Forms.Button BB_Produto;
        private System.Windows.Forms.Label label55;
        public Componentes.EditDefault SG_Unidade_Estoque;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.BindingSource bsFichaTec;
        private Componentes.EditDefault CD_Produto;
        public Componentes.EditDefault editDefault1;
        public Componentes.EditFloat vl_custoservico;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vl_servico;
        private System.Windows.Forms.Label label2;
    }
}