namespace Parametros.Diversos
{
    partial class TFCadTpVeiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpVeiculo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_tpveiculo = new Componentes.EditDefault(this.components);
            this.BS_TipoVeiculo = new System.Windows.Forms.BindingSource(this.components);
            this.DS_TpVeiculo = new Componentes.EditDefault(this.components);
            this.g_tpveiculo = new Componentes.DataGridDefault(this.components);
            this.cDTpVeiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTpVeiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_veiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTipo_rodado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_TipoVeiculo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tp_veiculo = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tp_rodado = new Componentes.ComboBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TipoVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_tpveiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TipoVeiculo)).BeginInit();
            this.BN_TipoVeiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.tp_rodado);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_TpVeiculo);
            this.pDados.Controls.Add(this.cd_tpveiculo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_veiculo);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_DIV_TPVEICULO";
            this.pDados.NM_ProcGravar = "IA_DIV_TPVEICULO";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_tpveiculo);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_tpveiculo, 0);
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
            // cd_tpveiculo
            // 
            this.cd_tpveiculo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tpveiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tpveiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tpveiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TipoVeiculo, "CD_TpVeiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_tpveiculo, "cd_tpveiculo");
            this.cd_tpveiculo.Name = "cd_tpveiculo";
            this.cd_tpveiculo.NM_Alias = "";
            this.cd_tpveiculo.NM_Campo = "cd_tpveiculo";
            this.cd_tpveiculo.NM_CampoBusca = "cd_tpveiculo";
            this.cd_tpveiculo.NM_Param = "@P_CD_TPVEICULO";
            this.cd_tpveiculo.QTD_Zero = 3;
            this.cd_tpveiculo.ST_AutoInc = false;
            this.cd_tpveiculo.ST_DisableAuto = true;
            this.cd_tpveiculo.ST_Float = false;
            this.cd_tpveiculo.ST_Gravar = true;
            this.cd_tpveiculo.ST_Int = true;
            this.cd_tpveiculo.ST_LimpaCampo = true;
            this.cd_tpveiculo.ST_NotNull = true;
            this.cd_tpveiculo.ST_PrimaryKey = true;
            this.cd_tpveiculo.TextOld = null;
            // 
            // BS_TipoVeiculo
            // 
            this.BS_TipoVeiculo.DataSource = typeof(CamadaDados.Diversos.TList_CadTpVeiculo);
            // 
            // DS_TpVeiculo
            // 
            this.DS_TpVeiculo.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TpVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TpVeiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TpVeiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TipoVeiculo, "DS_TpVeiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TpVeiculo, "DS_TpVeiculo");
            this.DS_TpVeiculo.Name = "DS_TpVeiculo";
            this.DS_TpVeiculo.NM_Alias = "";
            this.DS_TpVeiculo.NM_Campo = "DS_TpVeiculo";
            this.DS_TpVeiculo.NM_CampoBusca = "DS_TpVeiculo";
            this.DS_TpVeiculo.NM_Param = "@P_DS_TPVEICULO";
            this.DS_TpVeiculo.QTD_Zero = 0;
            this.DS_TpVeiculo.ST_AutoInc = false;
            this.DS_TpVeiculo.ST_DisableAuto = false;
            this.DS_TpVeiculo.ST_Float = false;
            this.DS_TpVeiculo.ST_Gravar = true;
            this.DS_TpVeiculo.ST_Int = false;
            this.DS_TpVeiculo.ST_LimpaCampo = true;
            this.DS_TpVeiculo.ST_NotNull = true;
            this.DS_TpVeiculo.ST_PrimaryKey = false;
            this.DS_TpVeiculo.TextOld = null;
            // 
            // g_tpveiculo
            // 
            this.g_tpveiculo.AllowUserToAddRows = false;
            this.g_tpveiculo.AllowUserToDeleteRows = false;
            this.g_tpveiculo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.g_tpveiculo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_tpveiculo.AutoGenerateColumns = false;
            this.g_tpveiculo.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_tpveiculo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_tpveiculo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_tpveiculo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_tpveiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_tpveiculo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDTpVeiculoDataGridViewTextBoxColumn,
            this.dSTpVeiculoDataGridViewTextBoxColumn,
            this.Tipo_veiculo,
            this.pTipo_rodado});
            this.g_tpveiculo.DataSource = this.BS_TipoVeiculo;
            resources.ApplyResources(this.g_tpveiculo, "g_tpveiculo");
            this.g_tpveiculo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_tpveiculo.Name = "g_tpveiculo";
            this.g_tpveiculo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_tpveiculo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_tpveiculo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_tpveiculo.TabStop = false;
            // 
            // cDTpVeiculoDataGridViewTextBoxColumn
            // 
            this.cDTpVeiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDTpVeiculoDataGridViewTextBoxColumn.DataPropertyName = "CD_TpVeiculo";
            resources.ApplyResources(this.cDTpVeiculoDataGridViewTextBoxColumn, "cDTpVeiculoDataGridViewTextBoxColumn");
            this.cDTpVeiculoDataGridViewTextBoxColumn.Name = "cDTpVeiculoDataGridViewTextBoxColumn";
            this.cDTpVeiculoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSTpVeiculoDataGridViewTextBoxColumn
            // 
            this.dSTpVeiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTpVeiculoDataGridViewTextBoxColumn.DataPropertyName = "DS_TpVeiculo";
            resources.ApplyResources(this.dSTpVeiculoDataGridViewTextBoxColumn, "dSTpVeiculoDataGridViewTextBoxColumn");
            this.dSTpVeiculoDataGridViewTextBoxColumn.Name = "dSTpVeiculoDataGridViewTextBoxColumn";
            this.dSTpVeiculoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Tipo_veiculo
            // 
            this.Tipo_veiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_veiculo.DataPropertyName = "Tipo_veiculo";
            resources.ApplyResources(this.Tipo_veiculo, "Tipo_veiculo");
            this.Tipo_veiculo.Name = "Tipo_veiculo";
            this.Tipo_veiculo.ReadOnly = true;
            // 
            // pTipo_rodado
            // 
            this.pTipo_rodado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pTipo_rodado.DataPropertyName = "Tipo_rodado";
            resources.ApplyResources(this.pTipo_rodado, "pTipo_rodado");
            this.pTipo_rodado.Name = "pTipo_rodado";
            this.pTipo_rodado.ReadOnly = true;
            // 
            // BN_TipoVeiculo
            // 
            this.BN_TipoVeiculo.AddNewItem = null;
            this.BN_TipoVeiculo.BindingSource = this.BS_TipoVeiculo;
            this.BN_TipoVeiculo.CountItem = this.bindingNavigatorCountItem;
            this.BN_TipoVeiculo.CountItemFormat = "de {0}";
            this.BN_TipoVeiculo.DeleteItem = null;
            resources.ApplyResources(this.BN_TipoVeiculo, "BN_TipoVeiculo");
            this.BN_TipoVeiculo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TipoVeiculo.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TipoVeiculo.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TipoVeiculo.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TipoVeiculo.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TipoVeiculo.Name = "BN_TipoVeiculo";
            this.BN_TipoVeiculo.PositionItem = this.bindingNavigatorPositionItem;
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tp_veiculo
            // 
            this.tp_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_TipoVeiculo, "Tp_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_veiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_veiculo, "tp_veiculo");
            this.tp_veiculo.FormattingEnabled = true;
            this.tp_veiculo.Name = "tp_veiculo";
            this.tp_veiculo.NM_Alias = "";
            this.tp_veiculo.NM_Campo = "";
            this.tp_veiculo.NM_Param = "";
            this.tp_veiculo.ST_Gravar = true;
            this.tp_veiculo.ST_LimparCampo = true;
            this.tp_veiculo.ST_NotNull = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // tp_rodado
            // 
            this.tp_rodado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_TipoVeiculo, "Tp_rodado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_rodado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_rodado, "tp_rodado");
            this.tp_rodado.FormattingEnabled = true;
            this.tp_rodado.Name = "tp_rodado";
            this.tp_rodado.NM_Alias = "";
            this.tp_rodado.NM_Campo = "";
            this.tp_rodado.NM_Param = "";
            this.tp_rodado.ST_Gravar = true;
            this.tp_rodado.ST_LimparCampo = true;
            this.tp_rodado.ST_NotNull = true;
            // 
            // TFCadTpVeiculo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.BN_TipoVeiculo);
            this.Name = "TFCadTpVeiculo";
            this.Load += new System.EventHandler(this.TFCadTpVeiculo_Load);
            this.Controls.SetChildIndex(this.BN_TipoVeiculo, 0);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_TipoVeiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_tpveiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TipoVeiculo)).EndInit();
            this.BN_TipoVeiculo.ResumeLayout(false);
            this.BN_TipoVeiculo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault DS_TpVeiculo;
        private Componentes.EditDefault cd_tpveiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault g_tpveiculo;
        private System.Windows.Forms.BindingSource BS_TipoVeiculo;
        private System.Windows.Forms.BindingNavigator BN_TipoVeiculo;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.ComboBoxDefault tp_veiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault tp_rodado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDTpVeiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTpVeiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_veiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn pTipo_rodado;
    }
}
