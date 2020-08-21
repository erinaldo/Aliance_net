namespace Financeiro.Cadastros
{
    partial class TFCadPais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadPais));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.NM_PAIS = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_PAIS = new Componentes.EditDefault(this.components);
            this.g_Pais = new Componentes.DataGridDefault(this.components);
            this.nPais = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BS_Pais = new System.Windows.Forms.BindingSource(this.components);
            this.cdpaisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmpaisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_Pais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPais)).BeginInit();
            this.nPais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Pais)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.NM_PAIS);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_PAIS);
            this.pDados.Font = null;
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
            this.tpPadrao.Controls.Add(this.g_Pais);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_Pais, 0);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NM_PAIS
            // 
            this.NM_PAIS.AccessibleDescription = null;
            this.NM_PAIS.AccessibleName = null;
            resources.ApplyResources(this.NM_PAIS, "NM_PAIS");
            this.NM_PAIS.BackColor = System.Drawing.SystemColors.Window;
            this.NM_PAIS.BackgroundImage = null;
            this.NM_PAIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_PAIS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pais, "Nm_pais", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_PAIS.Font = null;
            this.NM_PAIS.Name = "NM_PAIS";
            this.NM_PAIS.NM_Alias = "";
            this.NM_PAIS.NM_Campo = "NM_PAIS";
            this.NM_PAIS.NM_CampoBusca = "NM_PAIS";
            this.NM_PAIS.NM_Param = "@P_NM_PAIS";
            this.NM_PAIS.QTD_Zero = 0;
            this.NM_PAIS.ST_AutoInc = false;
            this.NM_PAIS.ST_DisableAuto = false;
            this.NM_PAIS.ST_Float = false;
            this.NM_PAIS.ST_Gravar = true;
            this.NM_PAIS.ST_Int = false;
            this.NM_PAIS.ST_LimpaCampo = true;
            this.NM_PAIS.ST_NotNull = false;
            this.NM_PAIS.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // CD_PAIS
            // 
            this.CD_PAIS.AccessibleDescription = null;
            this.CD_PAIS.AccessibleName = null;
            resources.ApplyResources(this.CD_PAIS, "CD_PAIS");
            this.CD_PAIS.BackColor = System.Drawing.SystemColors.Window;
            this.CD_PAIS.BackgroundImage = null;
            this.CD_PAIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_PAIS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pais, "Cd_pais", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_PAIS.Font = null;
            this.CD_PAIS.Name = "CD_PAIS";
            this.CD_PAIS.NM_Alias = "";
            this.CD_PAIS.NM_Campo = "CD_PAIS";
            this.CD_PAIS.NM_CampoBusca = "CD_PAIS";
            this.CD_PAIS.NM_Param = "@P_CD_PAIS";
            this.CD_PAIS.QTD_Zero = 0;
            this.CD_PAIS.ST_AutoInc = false;
            this.CD_PAIS.ST_DisableAuto = false;
            this.CD_PAIS.ST_Float = false;
            this.CD_PAIS.ST_Gravar = true;
            this.CD_PAIS.ST_Int = false;
            this.CD_PAIS.ST_LimpaCampo = true;
            this.CD_PAIS.ST_NotNull = true;
            this.CD_PAIS.ST_PrimaryKey = true;
            // 
            // g_Pais
            // 
            this.g_Pais.AccessibleDescription = null;
            this.g_Pais.AccessibleName = null;
            this.g_Pais.AllowUserToAddRows = false;
            this.g_Pais.AllowUserToDeleteRows = false;
            this.g_Pais.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_Pais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.g_Pais, "g_Pais");
            this.g_Pais.AutoGenerateColumns = false;
            this.g_Pais.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_Pais.BackgroundImage = null;
            this.g_Pais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_Pais.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Pais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_Pais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Pais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdpaisDataGridViewTextBoxColumn,
            this.nmpaisDataGridViewTextBoxColumn});
            this.g_Pais.DataSource = this.BS_Pais;
            this.g_Pais.Font = null;
            this.g_Pais.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_Pais.Name = "g_Pais";
            this.g_Pais.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Pais.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_Pais.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.g_Pais_CellContentClick);
            // 
            // nPais
            // 
            this.nPais.AccessibleDescription = null;
            this.nPais.AccessibleName = null;
            this.nPais.AddNewItem = null;
            resources.ApplyResources(this.nPais, "nPais");
            this.nPais.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nPais.BackgroundImage = null;
            this.nPais.BindingSource = this.BS_Pais;
            this.nPais.CountItem = this.bindingNavigatorCountItem;
            this.nPais.CountItemFormat = "de {0}";
            this.nPais.DeleteItem = null;
            this.nPais.Font = null;
            this.nPais.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.nPais.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nPais.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nPais.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nPais.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nPais.Name = "nPais";
            this.nPais.PositionItem = this.bindingNavigatorPositionItem;
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
            // BS_Pais
            // 
            this.BS_Pais.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadPais);
            // 
            // cdpaisDataGridViewTextBoxColumn
            // 
            this.cdpaisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdpaisDataGridViewTextBoxColumn.DataPropertyName = "Cd_pais";
            resources.ApplyResources(this.cdpaisDataGridViewTextBoxColumn, "cdpaisDataGridViewTextBoxColumn");
            this.cdpaisDataGridViewTextBoxColumn.Name = "cdpaisDataGridViewTextBoxColumn";
            this.cdpaisDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmpaisDataGridViewTextBoxColumn
            // 
            this.nmpaisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmpaisDataGridViewTextBoxColumn.DataPropertyName = "Nm_pais";
            resources.ApplyResources(this.nmpaisDataGridViewTextBoxColumn, "nmpaisDataGridViewTextBoxColumn");
            this.nmpaisDataGridViewTextBoxColumn.Name = "nmpaisDataGridViewTextBoxColumn";
            this.nmpaisDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCadPais
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.nPais);
            this.Font = null;
            this.Name = "TFCadPais";
            this.Load += new System.EventHandler(this.TFCadPais_Load);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.Controls.SetChildIndex(this.nPais, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.g_Pais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPais)).EndInit();
            this.nPais.ResumeLayout(false);
            this.nPais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Pais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_Pais;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault NM_PAIS;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_PAIS;
        private Componentes.DataGridDefault g_Pais;
        private System.Windows.Forms.BindingNavigator nPais;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdpaisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmpaisDataGridViewTextBoxColumn;
    }
}