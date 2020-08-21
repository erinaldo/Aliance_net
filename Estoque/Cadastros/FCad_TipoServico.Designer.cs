namespace Estoque.Cadastros
{
    partial class TFCad_TipoServico
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
            System.Windows.Forms.Label ds_MarcaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TipoServico));
            this.g_Tipo_Servico = new Componentes.DataGridDefault(this.components);
            this.idtpservicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_TipoServico = new System.Windows.Forms.BindingSource(this.components);
            this.BN_TipoServico = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.DS_TPSERVICO = new Componentes.EditDefault(this.components);
            this.idtpservicostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tpservico = new Componentes.EditDefault(this.components);
            this.PC_IBPT = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ds_MarcaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_Tipo_Servico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TipoServico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TipoServico)).BeginInit();
            this.BN_TipoServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_IBPT)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.PC_IBPT);
            this.pDados.Controls.Add(this.id_tpservico);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(ds_MarcaLabel);
            this.pDados.Controls.Add(this.DS_TPSERVICO);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_Tipo_Servico);
            this.tpPadrao.Controls.Add(this.BN_TipoServico);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_TipoServico, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_Tipo_Servico, 0);
            // 
            // ds_MarcaLabel
            // 
            resources.ApplyResources(ds_MarcaLabel, "ds_MarcaLabel");
            ds_MarcaLabel.Name = "ds_MarcaLabel";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // g_Tipo_Servico
            // 
            this.g_Tipo_Servico.AllowUserToAddRows = false;
            this.g_Tipo_Servico.AllowUserToDeleteRows = false;
            this.g_Tipo_Servico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_Tipo_Servico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_Tipo_Servico.AutoGenerateColumns = false;
            this.g_Tipo_Servico.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_Tipo_Servico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_Tipo_Servico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Tipo_Servico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_Tipo_Servico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Tipo_Servico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtpservicoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.g_Tipo_Servico.DataSource = this.BS_TipoServico;
            resources.ApplyResources(this.g_Tipo_Servico, "g_Tipo_Servico");
            this.g_Tipo_Servico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_Tipo_Servico.Name = "g_Tipo_Servico";
            this.g_Tipo_Servico.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Tipo_Servico.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            // 
            // idtpservicoDataGridViewTextBoxColumn
            // 
            this.idtpservicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpservicoDataGridViewTextBoxColumn.DataPropertyName = "Id_tpservico";
            resources.ApplyResources(this.idtpservicoDataGridViewTextBoxColumn, "idtpservicoDataGridViewTextBoxColumn");
            this.idtpservicoDataGridViewTextBoxColumn.Name = "idtpservicoDataGridViewTextBoxColumn";
            this.idtpservicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_tpservico";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PC_IBPT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N5";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // BS_TipoServico
            // 
            this.BS_TipoServico.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadTipoServico);
            // 
            // BN_TipoServico
            // 
            this.BN_TipoServico.AddNewItem = null;
            this.BN_TipoServico.BindingSource = this.BS_TipoServico;
            this.BN_TipoServico.CountItem = this.bindingNavigatorCountItem;
            this.BN_TipoServico.CountItemFormat = "de {0}";
            this.BN_TipoServico.DeleteItem = null;
            resources.ApplyResources(this.BN_TipoServico, "BN_TipoServico");
            this.BN_TipoServico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_TipoServico.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_TipoServico.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_TipoServico.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_TipoServico.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_TipoServico.Name = "BN_TipoServico";
            this.BN_TipoServico.PositionItem = this.bindingNavigatorPositionItem;
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
            // DS_TPSERVICO
            // 
            this.DS_TPSERVICO.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TPSERVICO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TPSERVICO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TPSERVICO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TipoServico, "Ds_tpservico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TPSERVICO, "DS_TPSERVICO");
            this.DS_TPSERVICO.Name = "DS_TPSERVICO";
            this.DS_TPSERVICO.NM_Alias = "";
            this.DS_TPSERVICO.NM_Campo = "";
            this.DS_TPSERVICO.NM_CampoBusca = "";
            this.DS_TPSERVICO.NM_Param = "";
            this.DS_TPSERVICO.QTD_Zero = 0;
            this.DS_TPSERVICO.ST_AutoInc = false;
            this.DS_TPSERVICO.ST_DisableAuto = false;
            this.DS_TPSERVICO.ST_Float = false;
            this.DS_TPSERVICO.ST_Gravar = true;
            this.DS_TPSERVICO.ST_Int = false;
            this.DS_TPSERVICO.ST_LimpaCampo = true;
            this.DS_TPSERVICO.ST_NotNull = true;
            this.DS_TPSERVICO.ST_PrimaryKey = false;
            this.DS_TPSERVICO.TextOld = null;
            // 
            // idtpservicostrDataGridViewTextBoxColumn
            // 
            this.idtpservicostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpservicostrDataGridViewTextBoxColumn.DataPropertyName = "Id_tpservicostr";
            resources.ApplyResources(this.idtpservicostrDataGridViewTextBoxColumn, "idtpservicostrDataGridViewTextBoxColumn");
            this.idtpservicostrDataGridViewTextBoxColumn.Name = "idtpservicostrDataGridViewTextBoxColumn";
            this.idtpservicostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // id_tpservico
            // 
            this.id_tpservico.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpservico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tpservico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpservico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_TipoServico, "Id_tpservico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_tpservico, "id_tpservico");
            this.id_tpservico.Name = "id_tpservico";
            this.id_tpservico.NM_Alias = "";
            this.id_tpservico.NM_Campo = "id_tpservico";
            this.id_tpservico.NM_CampoBusca = "id_tpservico";
            this.id_tpservico.NM_Param = "@P_ID_TPSERVICO";
            this.id_tpservico.QTD_Zero = 0;
            this.id_tpservico.ST_AutoInc = false;
            this.id_tpservico.ST_DisableAuto = false;
            this.id_tpservico.ST_Float = false;
            this.id_tpservico.ST_Gravar = true;
            this.id_tpservico.ST_Int = false;
            this.id_tpservico.ST_LimpaCampo = true;
            this.id_tpservico.ST_NotNull = true;
            this.id_tpservico.ST_PrimaryKey = true;
            this.id_tpservico.TextOld = null;
            // 
            // PC_IBPT
            // 
            this.PC_IBPT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_TipoServico, "PC_IBPT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_IBPT.DecimalPlaces = 5;
            resources.ApplyResources(this.PC_IBPT, "PC_IBPT");
            this.PC_IBPT.Name = "PC_IBPT";
            this.PC_IBPT.NM_Alias = "";
            this.PC_IBPT.NM_Campo = "";
            this.PC_IBPT.NM_Param = "";
            this.PC_IBPT.Operador = "";
            this.PC_IBPT.ST_AutoInc = false;
            this.PC_IBPT.ST_DisableAuto = false;
            this.PC_IBPT.ST_Gravar = true;
            this.PC_IBPT.ST_LimparCampo = true;
            this.PC_IBPT.ST_NotNull = false;
            this.PC_IBPT.ST_PrimaryKey = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TFCad_TipoServico
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_TipoServico";
            this.Load += new System.EventHandler(this.TFCad_TipoServico_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_TipoServico_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_Tipo_Servico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_TipoServico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_TipoServico)).EndInit();
            this.BN_TipoServico.ResumeLayout(false);
            this.BN_TipoServico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_IBPT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_TipoServico;
        private Componentes.DataGridDefault g_Tipo_Servico;
        private System.Windows.Forms.BindingNavigator BN_TipoServico;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault DS_TPSERVICO;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTPSERVICOStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTPSERVICODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTPSERVICOPAIStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTPSERVICOPAIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tIPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpservicostrDataGridViewTextBoxColumn;
        private Componentes.EditDefault id_tpservico;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat PC_IBPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpservicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpservicopaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stsinteticoboolDataGridViewCheckBoxColumn;
    }
}