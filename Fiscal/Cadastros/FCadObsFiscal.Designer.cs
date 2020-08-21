namespace Fiscal.Cadastros
{
    partial class TFCadObsFiscal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadObsFiscal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdobservacaofiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssobreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaofiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bs_cadObFiscal = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_CMI = new System.Windows.Forms.Label();
            this.LB_DS_CMI = new System.Windows.Forms.Label();
            this.cd_observacao = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DS_Sobre = new Componentes.EditDefault(this.components);
            this.bn_CadObFiscal = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cadObFiscal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadObFiscal)).BeginInit();
            this.bn_CadObFiscal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.DS_Sobre);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.cd_observacao);
            this.pDados.Controls.Add(this.LB_CD_CMI);
            this.pDados.Controls.Add(this.LB_DS_CMI);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_OBSERVACAOFISCAL";
            this.pDados.NM_ProcGravar = "IA_FIS_OBSERVACAOFISCAL";
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
            this.tpPadrao.Controls.Add(this.bn_CadObFiscal);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadObFiscal, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
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
            this.cdobservacaofiscalDataGridViewTextBoxColumn,
            this.dssobreDataGridViewTextBoxColumn,
            this.dsobservacaofiscalDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bs_cadObFiscal;
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
            // cdobservacaofiscalDataGridViewTextBoxColumn
            // 
            this.cdobservacaofiscalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdobservacaofiscalDataGridViewTextBoxColumn.DataPropertyName = "Cd_observacaofiscal";
            resources.ApplyResources(this.cdobservacaofiscalDataGridViewTextBoxColumn, "cdobservacaofiscalDataGridViewTextBoxColumn");
            this.cdobservacaofiscalDataGridViewTextBoxColumn.Name = "cdobservacaofiscalDataGridViewTextBoxColumn";
            this.cdobservacaofiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dssobreDataGridViewTextBoxColumn
            // 
            this.dssobreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssobreDataGridViewTextBoxColumn.DataPropertyName = "Ds_sobre";
            resources.ApplyResources(this.dssobreDataGridViewTextBoxColumn, "dssobreDataGridViewTextBoxColumn");
            this.dssobreDataGridViewTextBoxColumn.Name = "dssobreDataGridViewTextBoxColumn";
            this.dssobreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaofiscalDataGridViewTextBoxColumn
            // 
            this.dsobservacaofiscalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaofiscalDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacaofiscal";
            resources.ApplyResources(this.dsobservacaofiscalDataGridViewTextBoxColumn, "dsobservacaofiscalDataGridViewTextBoxColumn");
            this.dsobservacaofiscalDataGridViewTextBoxColumn.Name = "dsobservacaofiscalDataGridViewTextBoxColumn";
            this.dsobservacaofiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bs_cadObFiscal
            // 
            this.bs_cadObFiscal.DataSource = typeof(CamadaDados.Fiscal.TList_CadObservacaoFiscal);
            // 
            // LB_CD_CMI
            // 
            this.LB_CD_CMI.AccessibleDescription = null;
            this.LB_CD_CMI.AccessibleName = null;
            resources.ApplyResources(this.LB_CD_CMI, "LB_CD_CMI");
            this.LB_CD_CMI.Name = "LB_CD_CMI";
            // 
            // LB_DS_CMI
            // 
            this.LB_DS_CMI.AccessibleDescription = null;
            this.LB_DS_CMI.AccessibleName = null;
            resources.ApplyResources(this.LB_DS_CMI, "LB_DS_CMI");
            this.LB_DS_CMI.Name = "LB_DS_CMI";
            // 
            // cd_observacao
            // 
            this.cd_observacao.AccessibleDescription = null;
            this.cd_observacao.AccessibleName = null;
            resources.ApplyResources(this.cd_observacao, "cd_observacao");
            this.cd_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_observacao.BackgroundImage = null;
            this.cd_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cadObFiscal, "Cd_observacaofiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_observacao.Name = "cd_observacao";
            this.cd_observacao.NM_Alias = "";
            this.cd_observacao.NM_Campo = "cd_observacaofiscal";
            this.cd_observacao.NM_CampoBusca = "cd_observacaofiscal";
            this.cd_observacao.NM_Param = "@P_CD_OBSERVACAOFISCAL";
            this.cd_observacao.QTD_Zero = 0;
            this.cd_observacao.ST_AutoInc = false;
            this.cd_observacao.ST_DisableAuto = true;
            this.cd_observacao.ST_Float = false;
            this.cd_observacao.ST_Gravar = true;
            this.cd_observacao.ST_Int = false;
            this.cd_observacao.ST_LimpaCampo = true;
            this.cd_observacao.ST_NotNull = true;
            this.cd_observacao.ST_PrimaryKey = true;
            // 
            // ds_observacao
            // 
            this.ds_observacao.AccessibleDescription = null;
            this.ds_observacao.AccessibleName = null;
            resources.ApplyResources(this.ds_observacao, "ds_observacao");
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BackgroundImage = null;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cadObFiscal, "Ds_observacaofiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "ds_observacaofiscal";
            this.ds_observacao.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_observacao.NM_Param = "@P_DS_OBSERVACAOFISCAL";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = true;
            this.ds_observacao.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DS_Sobre
            // 
            this.DS_Sobre.AccessibleDescription = null;
            this.DS_Sobre.AccessibleName = null;
            resources.ApplyResources(this.DS_Sobre, "DS_Sobre");
            this.DS_Sobre.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Sobre.BackgroundImage = null;
            this.DS_Sobre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Sobre.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cadObFiscal, "Ds_sobre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Sobre.Font = null;
            this.DS_Sobre.Name = "DS_Sobre";
            this.DS_Sobre.NM_Alias = "";
            this.DS_Sobre.NM_Campo = "DS_Sobre";
            this.DS_Sobre.NM_CampoBusca = "DS_Sobre";
            this.DS_Sobre.NM_Param = "@P_DS_SOBRE";
            this.DS_Sobre.QTD_Zero = 0;
            this.DS_Sobre.ST_AutoInc = false;
            this.DS_Sobre.ST_DisableAuto = false;
            this.DS_Sobre.ST_Float = false;
            this.DS_Sobre.ST_Gravar = true;
            this.DS_Sobre.ST_Int = false;
            this.DS_Sobre.ST_LimpaCampo = true;
            this.DS_Sobre.ST_NotNull = true;
            this.DS_Sobre.ST_PrimaryKey = false;
            // 
            // bn_CadObFiscal
            // 
            this.bn_CadObFiscal.AccessibleDescription = null;
            this.bn_CadObFiscal.AccessibleName = null;
            this.bn_CadObFiscal.AddNewItem = null;
            resources.ApplyResources(this.bn_CadObFiscal, "bn_CadObFiscal");
            this.bn_CadObFiscal.BackgroundImage = null;
            this.bn_CadObFiscal.BindingSource = this.bs_cadObFiscal;
            this.bn_CadObFiscal.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadObFiscal.DeleteItem = null;
            this.bn_CadObFiscal.Font = null;
            this.bn_CadObFiscal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadObFiscal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadObFiscal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadObFiscal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadObFiscal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadObFiscal.Name = "bn_CadObFiscal";
            this.bn_CadObFiscal.PositionItem = this.bindingNavigatorPositionItem;
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
            // TFCadObsFiscal
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadObsFiscal";
            this.Load += new System.EventHandler(this.TFCadObsFiscal_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadObsFiscal_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cadObFiscal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadObFiscal)).EndInit();
            this.bn_CadObFiscal.ResumeLayout(false);
            this.bn_CadObFiscal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_CMI;
        private System.Windows.Forms.Label LB_DS_CMI;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault cd_observacao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DS_Sobre;
        private System.Windows.Forms.BindingNavigator bn_CadObFiscal;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bs_cadObFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdobservacaofiscalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssobreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaofiscalDataGridViewTextBoxColumn;
    }
}
