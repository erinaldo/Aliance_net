namespace Fiscal.Cadastros
{
    partial class TFCadMovimentacao_X_Produto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMovimentacao_X_Produto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.bsMovimentacao = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Movimentacao = new System.Windows.Forms.Label();
            this.LB_CD_Produto = new System.Windows.Forms.Label();
            this.CD_Movimentacao = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.ds_Movimentacao = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.bb_Movimentacao = new System.Windows.Forms.Button();
            this.bb_produto = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cdmovimentacaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.ds_Movimentacao);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.bb_Movimentacao);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.LB_CD_Movimentacao);
            this.pDados.Controls.Add(this.LB_CD_Produto);
            this.pDados.Controls.Add(this.CD_Movimentacao);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_MOVIMENTACAO_X_PRODUTO";
            this.pDados.NM_ProcGravar = "IA_FIS_MOVIMENTACAO_X_PRODUTO";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdmovimentacaostrDataGridViewTextBoxColumn,
            this.dsmovimentacaoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bsMovimentacao;
            this.gCadastro.Font = null;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.TabStop = false;
            // 
            // bsMovimentacao
            // 
            this.bsMovimentacao.DataSource = typeof(CamadaDados.Fiscal.TList_Mov_X_Produto);
            // 
            // LB_CD_Movimentacao
            // 
            this.LB_CD_Movimentacao.AccessibleDescription = null;
            this.LB_CD_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_Movimentacao, "LB_CD_Movimentacao");
            this.LB_CD_Movimentacao.Font = null;
            this.LB_CD_Movimentacao.Name = "LB_CD_Movimentacao";
            // 
            // LB_CD_Produto
            // 
            this.LB_CD_Produto.AccessibleDescription = null;
            this.LB_CD_Produto.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_Produto, "LB_CD_Produto");
            this.LB_CD_Produto.Font = null;
            this.LB_CD_Produto.Name = "LB_CD_Produto";
            // 
            // CD_Movimentacao
            // 
            this.CD_Movimentacao.AccessibleDescription = null;
            this.CD_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.CD_Movimentacao, "CD_Movimentacao");
            this.CD_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Movimentacao.BackgroundImage = null;
            this.CD_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_movimentacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Movimentacao.Name = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Alias = "a";
            this.CD_Movimentacao.NM_Campo = "CD_Movimentacao";
            this.CD_Movimentacao.NM_CampoBusca = "CD_Movimentacao";
            this.CD_Movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.CD_Movimentacao.QTD_Zero = 0;
            this.CD_Movimentacao.ST_AutoInc = false;
            this.CD_Movimentacao.ST_DisableAuto = false;
            this.CD_Movimentacao.ST_Float = false;
            this.CD_Movimentacao.ST_Gravar = true;
            this.CD_Movimentacao.ST_Int = false;
            this.CD_Movimentacao.ST_LimpaCampo = true;
            this.CD_Movimentacao.ST_NotNull = true;
            this.CD_Movimentacao.ST_PrimaryKey = true;
            this.CD_Movimentacao.Leave += new System.EventHandler(this.CD_Movimentacao_Leave);
            // 
            // CD_Produto
            // 
            this.CD_Produto.AccessibleDescription = null;
            this.CD_Produto.AccessibleName = null;
            resources.ApplyResources(this.CD_Produto, "CD_Produto");
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BackgroundImage = null;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "a";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = true;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // ds_Movimentacao
            // 
            this.ds_Movimentacao.AccessibleDescription = null;
            this.ds_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.ds_Movimentacao, "ds_Movimentacao");
            this.ds_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_Movimentacao.BackgroundImage = null;
            this.ds_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_Movimentacao.Name = "ds_Movimentacao";
            this.ds_Movimentacao.NM_Alias = "";
            this.ds_Movimentacao.NM_Campo = "DS_Movimentacao";
            this.ds_Movimentacao.NM_CampoBusca = "DS_Movimentacao";
            this.ds_Movimentacao.NM_Param = "@P_DS_MOVIMENTACAO";
            this.ds_Movimentacao.QTD_Zero = 0;
            this.ds_Movimentacao.ReadOnly = true;
            this.ds_Movimentacao.ST_AutoInc = false;
            this.ds_Movimentacao.ST_DisableAuto = false;
            this.ds_Movimentacao.ST_Float = false;
            this.ds_Movimentacao.ST_Gravar = false;
            this.ds_Movimentacao.ST_Int = false;
            this.ds_Movimentacao.ST_LimpaCampo = true;
            this.ds_Movimentacao.ST_NotNull = false;
            this.ds_Movimentacao.ST_PrimaryKey = false;
            // 
            // ds_produto
            // 
            this.ds_produto.AccessibleDescription = null;
            this.ds_produto.AccessibleName = null;
            resources.ApplyResources(this.ds_produto, "ds_produto");
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BackgroundImage = null;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            // 
            // bb_Movimentacao
            // 
            this.bb_Movimentacao.AccessibleDescription = null;
            this.bb_Movimentacao.AccessibleName = null;
            resources.ApplyResources(this.bb_Movimentacao, "bb_Movimentacao");
            this.bb_Movimentacao.BackgroundImage = null;
            this.bb_Movimentacao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Movimentacao.Name = "bb_Movimentacao";
            this.bb_Movimentacao.UseVisualStyleBackColor = true;
            this.bb_Movimentacao.Click += new System.EventHandler(this.bb_Movimentacao_Click);
            // 
            // bb_produto
            // 
            this.bb_produto.AccessibleDescription = null;
            this.bb_produto.AccessibleName = null;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.BackgroundImage = null;
            this.bb_produto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsMovimentacao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // cdmovimentacaostrDataGridViewTextBoxColumn
            // 
            this.cdmovimentacaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmovimentacaostrDataGridViewTextBoxColumn.DataPropertyName = "Cd_movimentacaostr";
            resources.ApplyResources(this.cdmovimentacaostrDataGridViewTextBoxColumn, "cdmovimentacaostrDataGridViewTextBoxColumn");
            this.cdmovimentacaostrDataGridViewTextBoxColumn.Name = "cdmovimentacaostrDataGridViewTextBoxColumn";
            this.cdmovimentacaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsmovimentacaoDataGridViewTextBoxColumn
            // 
            this.dsmovimentacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_movimentacao";
            resources.ApplyResources(this.dsmovimentacaoDataGridViewTextBoxColumn, "dsmovimentacaoDataGridViewTextBoxColumn");
            this.dsmovimentacaoDataGridViewTextBoxColumn.Name = "dsmovimentacaoDataGridViewTextBoxColumn";
            this.dsmovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            resources.ApplyResources(this.cdprodutoDataGridViewTextBoxColumn, "cdprodutoDataGridViewTextBoxColumn");
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            resources.ApplyResources(this.dsprodutoDataGridViewTextBoxColumn, "dsprodutoDataGridViewTextBoxColumn");
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadMovimentacao_X_Produto
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadMovimentacao_X_Produto";
            this.Load += new System.EventHandler(this.TFCadMovimentacao_X_Produto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_Movimentacao;
        private System.Windows.Forms.Label LB_CD_Produto;



        private Componentes.EditDefault CD_Movimentacao;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault ds_Movimentacao;
        private Componentes.EditDefault ds_produto;
        public System.Windows.Forms.Button bb_Movimentacao;
        public System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bsMovimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmovimentacaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;



    }
}
