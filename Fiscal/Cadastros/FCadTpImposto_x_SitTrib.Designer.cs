namespace Fiscal.Cadastros
{
    partial class TFCadTpImposto_x_SitTrib
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpImposto_x_SitTrib));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BS_TpImposto = new System.Windows.Forms.BindingSource(this.components);
            this.cd_st = new Componentes.EditDefault(this.components);
            this.bb_st = new System.Windows.Forms.Button();
            this.ds_situacao = new Componentes.EditDefault(this.components);
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.tpimpostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssituacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDs_imposto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBox_tpImposto = new Componentes.ComboBoxDefault(this.components);
            this.BN_TpImposto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bb_imposto = new System.Windows.Forms.Button();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TpImposto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpImposto)).BeginInit();
            this.BN_TpImposto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.SystemColors.Control;
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cBox_tpImposto);
            this.pDados.Controls.Add(this.ds_situacao);
            this.pDados.Controls.Add(this.bb_st);
            this.pDados.Controls.Add(this.cd_st);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Controls.Add(this.BN_TpImposto);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_TpImposto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BS_TpImposto
            // 
            this.BS_TpImposto.DataSource = typeof(CamadaDados.Fiscal.TList_CadTpImposto_x_SitTrib);
            // 
            // cd_st
            // 
            this.cd_st.BackColor = System.Drawing.SystemColors.Window;
            this.cd_st.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_st.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpImposto, "Cd_st", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_st, "cd_st");
            this.cd_st.Name = "cd_st";
            this.cd_st.NM_Alias = "a";
            this.cd_st.NM_Campo = "cd_st";
            this.cd_st.NM_CampoBusca = "cd_st";
            this.cd_st.NM_Param = "@P_CD_SITTRIB";
            this.cd_st.QTD_Zero = 0;
            this.cd_st.ST_AutoInc = false;
            this.cd_st.ST_DisableAuto = false;
            this.cd_st.ST_Float = false;
            this.cd_st.ST_Gravar = true;
            this.cd_st.ST_Int = false;
            this.cd_st.ST_LimpaCampo = true;
            this.cd_st.ST_NotNull = true;
            this.cd_st.ST_PrimaryKey = true;
            this.cd_st.Leave += new System.EventHandler(this.id_st_Leave);
            // 
            // bb_st
            // 
            this.bb_st.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_st, "bb_st");
            this.bb_st.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_st.Name = "bb_st";
            this.bb_st.UseVisualStyleBackColor = false;
            this.bb_st.Click += new System.EventHandler(this.bb_st_Click);
            // 
            // ds_situacao
            // 
            this.ds_situacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_situacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_situacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpImposto, "Ds_situacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_situacao, "ds_situacao");
            this.ds_situacao.Name = "ds_situacao";
            this.ds_situacao.NM_Alias = "";
            this.ds_situacao.NM_Campo = "ds_situacao";
            this.ds_situacao.NM_CampoBusca = "ds_situacao";
            this.ds_situacao.NM_Param = "@P_DS_SITTRIB";
            this.ds_situacao.QTD_Zero = 0;
            this.ds_situacao.ST_AutoInc = false;
            this.ds_situacao.ST_DisableAuto = false;
            this.ds_situacao.ST_Float = false;
            this.ds_situacao.ST_Gravar = false;
            this.ds_situacao.ST_Int = false;
            this.ds_situacao.ST_LimpaCampo = true;
            this.ds_situacao.ST_NotNull = false;
            this.ds_situacao.ST_PrimaryKey = false;
            // 
            // gPesquisa
            // 
            this.gPesquisa.AllowUserToAddRows = false;
            this.gPesquisa.AllowUserToDeleteRows = false;
            this.gPesquisa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPesquisa.AutoGenerateColumns = false;
            this.gPesquisa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpimpostoDataGridViewTextBoxColumn,
            this.cdstDataGridViewTextBoxColumn,
            this.dssituacaoDataGridViewTextBoxColumn,
            this.Cd_impostostr,
            this.cDs_imposto});
            this.gPesquisa.DataSource = this.BS_TpImposto;
            resources.ApplyResources(this.gPesquisa, "gPesquisa");
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Name = "gPesquisa";
            this.gPesquisa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gPesquisa.TabStop = false;
            // 
            // tpimpostoDataGridViewTextBoxColumn
            // 
            this.tpimpostoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpimpostoDataGridViewTextBoxColumn.DataPropertyName = "Tp_imposto";
            resources.ApplyResources(this.tpimpostoDataGridViewTextBoxColumn, "tpimpostoDataGridViewTextBoxColumn");
            this.tpimpostoDataGridViewTextBoxColumn.Name = "tpimpostoDataGridViewTextBoxColumn";
            this.tpimpostoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdstDataGridViewTextBoxColumn
            // 
            this.cdstDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdstDataGridViewTextBoxColumn.DataPropertyName = "Cd_st";
            resources.ApplyResources(this.cdstDataGridViewTextBoxColumn, "cdstDataGridViewTextBoxColumn");
            this.cdstDataGridViewTextBoxColumn.Name = "cdstDataGridViewTextBoxColumn";
            this.cdstDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dssituacaoDataGridViewTextBoxColumn
            // 
            this.dssituacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssituacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_situacao";
            resources.ApplyResources(this.dssituacaoDataGridViewTextBoxColumn, "dssituacaoDataGridViewTextBoxColumn");
            this.dssituacaoDataGridViewTextBoxColumn.Name = "dssituacaoDataGridViewTextBoxColumn";
            this.dssituacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            resources.ApplyResources(this.Cd_impostostr, "Cd_impostostr");
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            // 
            // cDs_imposto
            // 
            this.cDs_imposto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDs_imposto.DataPropertyName = "Ds_imposto";
            resources.ApplyResources(this.cDs_imposto, "cDs_imposto");
            this.cDs_imposto.Name = "cDs_imposto";
            this.cDs_imposto.ReadOnly = true;
            // 
            // cBox_tpImposto
            // 
            this.cBox_tpImposto.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_TpImposto, "Tp_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cBox_tpImposto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cBox_tpImposto, "cBox_tpImposto");
            this.cBox_tpImposto.FormattingEnabled = true;
            this.cBox_tpImposto.Items.AddRange(new object[] {
            resources.GetString("cBox_tpImposto.Items"),
            resources.GetString("cBox_tpImposto.Items1"),
            resources.GetString("cBox_tpImposto.Items2"),
            resources.GetString("cBox_tpImposto.Items3")});
            this.cBox_tpImposto.Name = "cBox_tpImposto";
            this.cBox_tpImposto.NM_Alias = "a";
            this.cBox_tpImposto.NM_Campo = "TP_Imposto";
            this.cBox_tpImposto.NM_Param = "@P_TP_IMPOSTO";
            this.cBox_tpImposto.ST_Gravar = true;
            this.cBox_tpImposto.ST_LimparCampo = true;
            this.cBox_tpImposto.ST_NotNull = true;
            // 
            // BN_TpImposto
            // 
            this.BN_TpImposto.AddNewItem = null;
            this.BN_TpImposto.CountItem = this.bindingNavigatorCountItem;
            this.BN_TpImposto.DeleteItem = null;
            resources.ApplyResources(this.BN_TpImposto, "BN_TpImposto");
            this.BN_TpImposto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TpImposto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TpImposto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TpImposto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TpImposto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TpImposto.Name = "BN_TpImposto";
            this.BN_TpImposto.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpImposto, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_imposto, "ds_imposto");
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_DS_SITTRIB";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            // 
            // bb_imposto
            // 
            this.bb_imposto.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.bb_imposto, "bb_imposto");
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.UseVisualStyleBackColor = false;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TpImposto, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_imposto, "cd_imposto");
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "a";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_SITTRIB";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = false;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = false;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = true;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TFCadTpImposto_x_SitTrib
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadTpImposto_x_SitTrib";
            this.Load += new System.EventHandler(this.TFCadTpImposto_x_SitTrib_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadTpImposto_x_SitTrib_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TpImposto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TpImposto)).EndInit();
            this.BN_TpImposto.ResumeLayout(false);
            this.BN_TpImposto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_st;
        private Componentes.EditDefault ds_situacao;
        private Componentes.DataGridDefault gPesquisa;
        private System.Windows.Forms.BindingSource BS_TpImposto;
        private Componentes.ComboBoxDefault cBox_tpImposto;
        private System.Windows.Forms.BindingNavigator BN_TpImposto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdsitTribDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bb_st;
        private System.Windows.Forms.DataGridViewTextBoxColumn idststrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impostoDataGridViewTextBoxColumn;
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Button bb_imposto;
        private Componentes.EditDefault cd_imposto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpimpostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssituacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDs_imposto;
    }
}
