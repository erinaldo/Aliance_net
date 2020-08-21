namespace Producao
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
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label55 = new System.Windows.Forms.Label();
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.vl_custo = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(763, 43);
            this.barraMenu.TabIndex = 3;
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
            this.pDados.Controls.Add(this.vl_custo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Controls.Add(this.SG_Unidade_Estoque);
            this.pDados.Controls.Add(this.Quantidade);
            this.pDados.Controls.Add(this.label58);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(763, 132);
            this.pDados.TabIndex = 0;
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Local.Enabled = false;
            this.DS_Local.Location = new System.Drawing.Point(181, 78);
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_UNIDADE";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ReadOnly = true;
            this.DS_Local.Size = new System.Drawing.Size(551, 20);
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TabIndex = 134;
            this.DS_Local.TextOld = null;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Faturamento.Orcamento.TList_FichaTecOrcItem);
            // 
            // BB_Local
            // 
            this.BB_Local.Image = ((System.Drawing.Image)(resources.GetObject("BB_Local.Image")));
            this.BB_Local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Local.Location = new System.Drawing.Point(150, 78);
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.Size = new System.Drawing.Size(28, 19);
            this.BB_Local.TabIndex = 3;
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local.Location = new System.Drawing.Point(84, 78);
            this.CD_Local.Name = "CD_Local";
            this.CD_Local.NM_Alias = "";
            this.CD_Local.NM_Campo = "CD_Local";
            this.CD_Local.NM_CampoBusca = "CD_Local";
            this.CD_Local.NM_Param = "@P_CD_UNIDADE";
            this.CD_Local.QTD_Zero = 0;
            this.CD_Local.Size = new System.Drawing.Size(65, 20);
            this.CD_Local.ST_AutoInc = false;
            this.CD_Local.ST_DisableAuto = false;
            this.CD_Local.ST_Float = false;
            this.CD_Local.ST_Gravar = true;
            this.CD_Local.ST_Int = false;
            this.CD_Local.ST_LimpaCampo = true;
            this.CD_Local.ST_NotNull = true;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TabIndex = 2;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(36, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 135;
            this.label1.Text = "Local:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(82, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Localiza produto por codigo interno, codigo de barras, codigo referencia ou parte" +
    " da descrição";
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CD_Produto.Location = new System.Drawing.Point(84, 17);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(648, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(31, 27);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(47, 13);
            this.label55.TabIndex = 130;
            this.label55.Text = "Produto:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SG_Unidade_Estoque
            // 
            this.SG_Unidade_Estoque.BackColor = System.Drawing.SystemColors.Window;
            this.SG_Unidade_Estoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SG_Unidade_Estoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SG_Unidade_Estoque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Sg_unditem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SG_Unidade_Estoque.Enabled = false;
            this.SG_Unidade_Estoque.Location = new System.Drawing.Point(190, 105);
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
            this.Quantidade.Location = new System.Drawing.Point(84, 105);
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
            this.Quantidade.TabIndex = 4;
            this.Quantidade.ThousandsSeparator = true;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(13, 108);
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
            this.DS_Produto.Location = new System.Drawing.Point(84, 52);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(648, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = true;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 1;
            this.DS_Produto.TextOld = null;
            // 
            // vl_custo
            // 
            this.vl_custo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_custo.DecimalPlaces = 2;
            this.vl_custo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_custo.Location = new System.Drawing.Point(309, 105);
            this.vl_custo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_custo.Name = "vl_custo";
            this.vl_custo.NM_Alias = "";
            this.vl_custo.NM_Campo = "Quantidade";
            this.vl_custo.NM_Param = "@P_QUANTIDADE";
            this.vl_custo.Operador = "";
            this.vl_custo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_custo.Size = new System.Drawing.Size(104, 20);
            this.vl_custo.ST_AutoInc = false;
            this.vl_custo.ST_DisableAuto = false;
            this.vl_custo.ST_Gravar = true;
            this.vl_custo.ST_LimparCampo = true;
            this.vl_custo.ST_NotNull = true;
            this.vl_custo.ST_PrimaryKey = false;
            this.vl_custo.TabIndex = 5;
            this.vl_custo.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(257, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 137;
            this.label2.Text = "Vl.Custo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFItensFichaTec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 175);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensFichaTec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Ficha Técnica";
            this.Load += new System.EventHandler(this.TFItensFichaTec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensFichaTec_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_custo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label55;
        public Componentes.EditDefault SG_Unidade_Estoque;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        public Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.BindingSource bsFichaTec;
        public Componentes.EditDefault DS_Local;
        private System.Windows.Forms.Button BB_Local;
        public Componentes.EditDefault CD_Local;
        private System.Windows.Forms.Label label1;
        public Componentes.EditFloat vl_custo;
        private System.Windows.Forms.Label label2;
    }
}