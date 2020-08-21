namespace Faturamento
{
    partial class TFAcessorioItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAcessorioItem));
            this.pDados = new Componentes.PanelDados(this.components);
            this.DS_Local = new Componentes.EditDefault(this.components);
            this.bsAcessorioItem = new System.Windows.Forms.BindingSource(this.components);
            this.BB_Local = new System.Windows.Forms.Button();
            this.CD_Local = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label58 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label55 = new System.Windows.Forms.Label();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcessorioItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.DS_Local);
            this.pDados.Controls.Add(this.BB_Local);
            this.pDados.Controls.Add(this.CD_Local);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.DS_Observacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.Quantidade);
            this.pDados.Controls.Add(this.label58);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(this.label55);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(588, 213);
            this.pDados.TabIndex = 0;
            // 
            // DS_Local
            // 
            this.DS_Local.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAcessorioItem, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Local.Enabled = false;
            this.DS_Local.Location = new System.Drawing.Point(187, 78);
            this.DS_Local.Name = "DS_Local";
            this.DS_Local.NM_Alias = "";
            this.DS_Local.NM_Campo = "DS_Local";
            this.DS_Local.NM_CampoBusca = "DS_Local";
            this.DS_Local.NM_Param = "@P_DS_UNIDADE";
            this.DS_Local.QTD_Zero = 0;
            this.DS_Local.ReadOnly = true;
            this.DS_Local.Size = new System.Drawing.Size(396, 20);
            this.DS_Local.ST_AutoInc = false;
            this.DS_Local.ST_DisableAuto = false;
            this.DS_Local.ST_Float = false;
            this.DS_Local.ST_Gravar = false;
            this.DS_Local.ST_Int = false;
            this.DS_Local.ST_LimpaCampo = true;
            this.DS_Local.ST_NotNull = false;
            this.DS_Local.ST_PrimaryKey = false;
            this.DS_Local.TabIndex = 122;
            this.DS_Local.TextOld = null;
            // 
            // bsAcessorioItem
            // 
            this.bsAcessorioItem.DataSource = typeof(CamadaDados.Faturamento.Pedido.TList_AcessoriosPed);
            // 
            // BB_Local
            // 
            this.BB_Local.Image = ((System.Drawing.Image)(resources.GetObject("BB_Local.Image")));
            this.BB_Local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Local.Location = new System.Drawing.Point(153, 78);
            this.BB_Local.Name = "BB_Local";
            this.BB_Local.Size = new System.Drawing.Size(28, 19);
            this.BB_Local.TabIndex = 2;
            this.BB_Local.UseVisualStyleBackColor = true;
            this.BB_Local.Click += new System.EventHandler(this.BB_Local_Click);
            // 
            // CD_Local
            // 
            this.CD_Local.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAcessorioItem, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local.Location = new System.Drawing.Point(85, 78);
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
            this.CD_Local.ST_NotNull = false;
            this.CD_Local.ST_PrimaryKey = false;
            this.CD_Local.TabIndex = 1;
            this.CD_Local.TextOld = null;
            this.CD_Local.Leave += new System.EventHandler(this.CD_Local_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(40, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 123;
            this.label1.Text = "Local:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAcessorioItem, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Location = new System.Drawing.Point(85, 130);
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "";
            this.DS_Observacao.NM_Campo = "CD_Unidade";
            this.DS_Observacao.NM_CampoBusca = "CD_Unidade";
            this.DS_Observacao.NM_Param = "@P_CD_UNIDADE";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.Size = new System.Drawing.Size(498, 72);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 4;
            this.DS_Observacao.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(5, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "Observação:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAcessorioItem, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Location = new System.Drawing.Point(85, 52);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.ReadOnly = true;
            this.DS_Produto.Size = new System.Drawing.Size(498, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 117;
            this.DS_Produto.TextOld = null;
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAcessorioItem, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.Location = new System.Drawing.Point(85, 104);
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
            this.Quantidade.Size = new System.Drawing.Size(91, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 3;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label58.Location = new System.Drawing.Point(5, 106);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(76, 13);
            this.label58.TabIndex = 116;
            this.label58.Text = "Quantidade:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(83, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(452, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Localiza produto por codigo interno, codigo de barras, codigo referencia ou parte" +
    " da descrição";
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAcessorioItem, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CD_Produto.Location = new System.Drawing.Point(85, 21);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(498, 29);
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
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(24, 31);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(55, 13);
            this.label55.TabIndex = 113;
            this.label55.Text = "Produto:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(588, 43);
            this.barraMenu.TabIndex = 13;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // TFAcessorioItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 256);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAcessorioItem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acessórios Item";
            this.Load += new System.EventHandler(this.TFAcessorioItem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAcessorioItem_KeyDown);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcessorioItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pDados;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label55;
        public Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.BindingSource bsAcessorioItem;
        public Componentes.EditDefault DS_Produto;
        public Componentes.EditDefault DS_Observacao;
        private System.Windows.Forms.Label label3;
        public Componentes.EditDefault DS_Local;
        private System.Windows.Forms.Button BB_Local;
        public Componentes.EditDefault CD_Local;
        private System.Windows.Forms.Label label1;
    }
}