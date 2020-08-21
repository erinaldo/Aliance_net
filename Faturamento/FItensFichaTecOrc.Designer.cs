namespace Faturamento
{
    partial class TFItensFichaTecOrc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItensFichaTecOrc));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.subtotal = new Componentes.EditFloat(this.components);
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.Vl_Unitario = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SG_Unidade_Estoque = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.vl_custo = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(746, 43);
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
            this.pDados.Controls.Add(this.vl_custo);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.subtotal);
            this.pDados.Controls.Add(this.Vl_Unitario);
            this.pDados.Controls.Add(this.label2);
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
            this.pDados.Size = new System.Drawing.Size(746, 54);
            this.pDados.TabIndex = 3;
            // 
            // subtotal
            // 
            this.subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_Subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subtotal.DecimalPlaces = 2;
            this.subtotal.Enabled = false;
            this.subtotal.Location = new System.Drawing.Point(635, 29);
            this.subtotal.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.subtotal.Name = "subtotal";
            this.subtotal.NM_Alias = "";
            this.subtotal.NM_Campo = "";
            this.subtotal.NM_Param = "";
            this.subtotal.Operador = "";
            this.subtotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.subtotal.Size = new System.Drawing.Size(103, 20);
            this.subtotal.ST_AutoInc = false;
            this.subtotal.ST_DisableAuto = false;
            this.subtotal.ST_Gravar = true;
            this.subtotal.ST_LimparCampo = true;
            this.subtotal.ST_NotNull = true;
            this.subtotal.ST_PrimaryKey = false;
            this.subtotal.TabIndex = 5;
            this.subtotal.ThousandsSeparator = true;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Faturamento.Orcamento.TList_FichaTecOrcItem);
            // 
            // Vl_Unitario
            // 
            this.Vl_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_Unitario.DecimalPlaces = 2;
            this.Vl_Unitario.Enabled = false;
            this.Vl_Unitario.Location = new System.Drawing.Point(311, 29);
            this.Vl_Unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Unitario.Name = "Vl_Unitario";
            this.Vl_Unitario.NM_Alias = "";
            this.Vl_Unitario.NM_Campo = "";
            this.Vl_Unitario.NM_Param = "";
            this.Vl_Unitario.Operador = "";
            this.Vl_Unitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Unitario.Size = new System.Drawing.Size(104, 20);
            this.Vl_Unitario.ST_AutoInc = false;
            this.Vl_Unitario.ST_DisableAuto = false;
            this.Vl_Unitario.ST_Gravar = true;
            this.Vl_Unitario.ST_LimparCampo = true;
            this.Vl_Unitario.ST_NotNull = false;
            this.Vl_Unitario.ST_PrimaryKey = false;
            this.Vl_Unitario.TabIndex = 3;
            this.Vl_Unitario.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(582, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 119;
            this.label2.Text = "SubTotal:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(237, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 117;
            this.label1.Text = "Valor Unitário:";
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
            this.DS_Produto.Size = new System.Drawing.Size(532, 20);
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
            // vl_custo
            // 
            this.vl_custo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_custo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_custo.DecimalPlaces = 2;
            this.vl_custo.Enabled = false;
            this.vl_custo.Location = new System.Drawing.Point(476, 29);
            this.vl_custo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_custo.Name = "vl_custo";
            this.vl_custo.NM_Alias = "";
            this.vl_custo.NM_Campo = "";
            this.vl_custo.NM_Param = "";
            this.vl_custo.Operador = "";
            this.vl_custo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_custo.Size = new System.Drawing.Size(90, 20);
            this.vl_custo.ST_AutoInc = false;
            this.vl_custo.ST_DisableAuto = false;
            this.vl_custo.ST_Gravar = true;
            this.vl_custo.ST_LimparCampo = true;
            this.vl_custo.ST_NotNull = false;
            this.vl_custo.ST_PrimaryKey = false;
            this.vl_custo.TabIndex = 4;
            this.vl_custo.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(423, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Vl. Custo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFItensFichaTecOrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 97);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItensFichaTecOrc";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itens Ficha Tecnica Orcamento";
            this.Load += new System.EventHandler(this.TFItensFichaTecOrc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItensFichaTecOrc_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).EndInit();
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
        public Componentes.EditDefault SG_Unidade_Estoque;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        public Componentes.EditDefault DS_Produto;
        public System.Windows.Forms.Button BB_Produto;
        private System.Windows.Forms.Label label55;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.BindingSource bsFichaTec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat Vl_Unitario;
        private Componentes.EditFloat subtotal;
        private Componentes.EditFloat vl_custo;
        private System.Windows.Forms.Label label3;
    }
}