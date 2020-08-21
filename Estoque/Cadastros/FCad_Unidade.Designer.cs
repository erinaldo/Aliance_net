namespace Estoque.Cadastros
{
    partial class TFCad_Unidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Unidade));
            this.g_CadUnidade = new Componentes.DataGridDefault(this.components);
            this.cDUnidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSUnidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaUnidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CadUnidade = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Sigla_Unidade = new Componentes.EditDefault(this.components);
            this.BN_CadUnidade = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tp_unidade = new Componentes.ComboBoxDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadUnidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadUnidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadUnidade)).BeginInit();
            this.BN_CadUnidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.tp_unidade);
            this.pDados.Controls.Add(this.Sigla_Unidade);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_Unidade);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.CD_Unidade);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_CadUnidade);
            this.tpPadrao.Controls.Add(this.BN_CadUnidade);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadUnidade, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadUnidade, 0);
            // 
            // g_CadUnidade
            // 
            this.g_CadUnidade.AllowUserToAddRows = false;
            this.g_CadUnidade.AllowUserToDeleteRows = false;
            this.g_CadUnidade.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadUnidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_CadUnidade.AutoGenerateColumns = false;
            this.g_CadUnidade.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadUnidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadUnidade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadUnidade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadUnidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadUnidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDUnidadeDataGridViewTextBoxColumn,
            this.dSUnidadeDataGridViewTextBoxColumn,
            this.siglaUnidadeDataGridViewTextBoxColumn,
            this.Tipo_tipo});
            this.g_CadUnidade.DataSource = this.BS_CadUnidade;
            resources.ApplyResources(this.g_CadUnidade, "g_CadUnidade");
            this.g_CadUnidade.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadUnidade.Name = "g_CadUnidade";
            this.g_CadUnidade.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadUnidade.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_CadUnidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadUnidade.TabStop = false;
            this.g_CadUnidade.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.g_CadUnidade_ColumnHeaderMouseClick);
            // 
            // cDUnidadeDataGridViewTextBoxColumn
            // 
            this.cDUnidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDUnidadeDataGridViewTextBoxColumn.DataPropertyName = "CD_Unidade";
            resources.ApplyResources(this.cDUnidadeDataGridViewTextBoxColumn, "cDUnidadeDataGridViewTextBoxColumn");
            this.cDUnidadeDataGridViewTextBoxColumn.Name = "cDUnidadeDataGridViewTextBoxColumn";
            this.cDUnidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSUnidadeDataGridViewTextBoxColumn
            // 
            this.dSUnidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSUnidadeDataGridViewTextBoxColumn.DataPropertyName = "DS_Unidade";
            resources.ApplyResources(this.dSUnidadeDataGridViewTextBoxColumn, "dSUnidadeDataGridViewTextBoxColumn");
            this.dSUnidadeDataGridViewTextBoxColumn.Name = "dSUnidadeDataGridViewTextBoxColumn";
            this.dSUnidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaUnidadeDataGridViewTextBoxColumn
            // 
            this.siglaUnidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaUnidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_Unidade";
            resources.ApplyResources(this.siglaUnidadeDataGridViewTextBoxColumn, "siglaUnidadeDataGridViewTextBoxColumn");
            this.siglaUnidadeDataGridViewTextBoxColumn.Name = "siglaUnidadeDataGridViewTextBoxColumn";
            this.siglaUnidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Tipo_tipo
            // 
            this.Tipo_tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_tipo.DataPropertyName = "Tipo_tipo";
            resources.ApplyResources(this.Tipo_tipo, "Tipo_tipo");
            this.Tipo_tipo.Name = "Tipo_tipo";
            this.Tipo_tipo.ReadOnly = true;
            // 
            // BS_CadUnidade
            // 
            this.BS_CadUnidade.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadUnidade);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUnidade, "CD_Unidade", true));
            resources.ApplyResources(this.CD_Unidade, "CD_Unidade");
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "a";
            this.CD_Unidade.NM_Campo = "Cód. Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = true;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = true;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = false;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TextOld = null;
            this.CD_Unidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CD_Unidade_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUnidade, "DS_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Unidade, "DS_Unidade");
            this.DS_Unidade.Name = "DS_Unidade";
            this.DS_Unidade.NM_Alias = "";
            this.DS_Unidade.NM_Campo = "Unidade";
            this.DS_Unidade.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade.NM_Param = "@P_DS_UNIDADE";
            this.DS_Unidade.QTD_Zero = 0;
            this.DS_Unidade.ST_AutoInc = false;
            this.DS_Unidade.ST_DisableAuto = false;
            this.DS_Unidade.ST_Float = false;
            this.DS_Unidade.ST_Gravar = true;
            this.DS_Unidade.ST_Int = false;
            this.DS_Unidade.ST_LimpaCampo = true;
            this.DS_Unidade.ST_NotNull = true;
            this.DS_Unidade.ST_PrimaryKey = false;
            this.DS_Unidade.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Sigla_Unidade
            // 
            this.Sigla_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla_Unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sigla_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUnidade, "Sigla_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Sigla_Unidade, "Sigla_Unidade");
            this.Sigla_Unidade.Name = "Sigla_Unidade";
            this.Sigla_Unidade.NM_Alias = "";
            this.Sigla_Unidade.NM_Campo = "Sigla";
            this.Sigla_Unidade.NM_CampoBusca = "Sigla";
            this.Sigla_Unidade.NM_Param = "@P_SIGLA";
            this.Sigla_Unidade.QTD_Zero = 0;
            this.Sigla_Unidade.ST_AutoInc = false;
            this.Sigla_Unidade.ST_DisableAuto = false;
            this.Sigla_Unidade.ST_Float = false;
            this.Sigla_Unidade.ST_Gravar = true;
            this.Sigla_Unidade.ST_Int = false;
            this.Sigla_Unidade.ST_LimpaCampo = true;
            this.Sigla_Unidade.ST_NotNull = true;
            this.Sigla_Unidade.ST_PrimaryKey = false;
            this.Sigla_Unidade.TextOld = null;
            // 
            // BN_CadUnidade
            // 
            this.BN_CadUnidade.AddNewItem = null;
            this.BN_CadUnidade.BindingSource = this.BS_CadUnidade;
            this.BN_CadUnidade.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadUnidade.CountItemFormat = "de {0}";
            this.BN_CadUnidade.DeleteItem = null;
            resources.ApplyResources(this.BN_CadUnidade, "BN_CadUnidade");
            this.BN_CadUnidade.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadUnidade.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadUnidade.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadUnidade.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadUnidade.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadUnidade.Name = "BN_CadUnidade";
            this.BN_CadUnidade.PositionItem = this.bindingNavigatorPositionItem;
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // tp_unidade
            // 
            this.tp_unidade.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_CadUnidade, "Tp_tipo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_unidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_unidade.FormattingEnabled = true;
            resources.ApplyResources(this.tp_unidade, "tp_unidade");
            this.tp_unidade.Name = "tp_unidade";
            this.tp_unidade.NM_Alias = "";
            this.tp_unidade.NM_Campo = "";
            this.tp_unidade.NM_Param = "";
            this.tp_unidade.ST_Gravar = true;
            this.tp_unidade.ST_LimparCampo = true;
            this.tp_unidade.ST_NotNull = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CadUnidade, "CasasDecimais", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.editFloat1, "editFloat1");
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = true;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            // 
            // TFCad_Unidade
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_Unidade";
            this.Load += new System.EventHandler(this.TFCad_Unidade_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadUnidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadUnidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadUnidade)).EndInit();
            this.BN_CadUnidade.ResumeLayout(false);
            this.BN_CadUnidade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_CadUnidade;
        private System.Windows.Forms.BindingSource BS_CadUnidade;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Unidade;
        private Componentes.EditDefault Sigla_Unidade;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault DS_Unidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingNavigator BN_CadUnidade;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label5;
        private Componentes.ComboBoxDefault tp_unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDUnidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSUnidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaUnidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_tipo;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label4;
    }
}