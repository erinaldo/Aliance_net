namespace Consulta.Cadastro
{
    partial class TFCad_Operador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Operador));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LB_Nr_Serie = new System.Windows.Forms.Label();
            this.LB_DS_SerieNf = new System.Windows.Forms.Label();
            this.ID_Operador = new Componentes.EditDefault(this.components);
            this.BS_Operador = new System.Windows.Forms.BindingSource(this.components);
            this.NM_Operador = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Sigla_Operador = new Componentes.EditDefault(this.components);
            this.grid_Operador = new Componentes.DataGridDefault(this.components);
            this.BN_Operador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.iDOperadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMOperadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaOperadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Operador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Operador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Operador)).BeginInit();
            this.BN_Operador.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.Sigla_Operador);
            this.pDados.Controls.Add(this.LB_Nr_Serie);
            this.pDados.Controls.Add(this.LB_DS_SerieNf);
            this.pDados.Controls.Add(this.ID_Operador);
            this.pDados.Controls.Add(this.NM_Operador);
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
            this.tpPadrao.Controls.Add(this.grid_Operador);
            this.tpPadrao.Controls.Add(this.BN_Operador);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.BN_Operador, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.grid_Operador, 0);
            // 
            // LB_Nr_Serie
            // 
            this.LB_Nr_Serie.AccessibleDescription = null;
            this.LB_Nr_Serie.AccessibleName = null;
            resources.ApplyResources(this.LB_Nr_Serie, "LB_Nr_Serie");
            this.LB_Nr_Serie.Name = "LB_Nr_Serie";
            // 
            // LB_DS_SerieNf
            // 
            this.LB_DS_SerieNf.AccessibleDescription = null;
            this.LB_DS_SerieNf.AccessibleName = null;
            resources.ApplyResources(this.LB_DS_SerieNf, "LB_DS_SerieNf");
            this.LB_DS_SerieNf.Name = "LB_DS_SerieNf";
            // 
            // ID_Operador
            // 
            this.ID_Operador.AccessibleDescription = null;
            this.ID_Operador.AccessibleName = null;
            resources.ApplyResources(this.ID_Operador, "ID_Operador");
            this.ID_Operador.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Operador.BackgroundImage = null;
            this.ID_Operador.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.ID_Operador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Operador, "ID_Operador_str", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Operador.Name = "ID_Operador";
            this.ID_Operador.NM_Alias = "";
            this.ID_Operador.NM_Campo = "";
            this.ID_Operador.NM_CampoBusca = "";
            this.ID_Operador.NM_Param = "";
            this.ID_Operador.QTD_Zero = 0;
            this.ID_Operador.ST_AutoInc = false;
            this.ID_Operador.ST_DisableAuto = false;
            this.ID_Operador.ST_Float = false;
            this.ID_Operador.ST_Gravar = true;
            this.ID_Operador.ST_Int = false;
            this.ID_Operador.ST_LimpaCampo = true;
            this.ID_Operador.ST_NotNull = true;
            this.ID_Operador.ST_PrimaryKey = true;
            // 
            // BS_Operador
            // 
            this.BS_Operador.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_Operador);
            this.BS_Operador.CurrentChanged += new System.EventHandler(this.BS_Operador_CurrentChanged);
            // 
            // NM_Operador
            // 
            this.NM_Operador.AccessibleDescription = null;
            this.NM_Operador.AccessibleName = null;
            resources.ApplyResources(this.NM_Operador, "NM_Operador");
            this.NM_Operador.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Operador.BackgroundImage = null;
            this.NM_Operador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Operador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Operador, "NM_Operador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Operador.Name = "NM_Operador";
            this.NM_Operador.NM_Alias = "";
            this.NM_Operador.NM_Campo = "DS_SerieNf";
            this.NM_Operador.NM_CampoBusca = "DS_SerieNf";
            this.NM_Operador.NM_Param = "@P_DS_SERIENF";
            this.NM_Operador.QTD_Zero = 0;
            this.NM_Operador.ST_AutoInc = false;
            this.NM_Operador.ST_DisableAuto = false;
            this.NM_Operador.ST_Float = false;
            this.NM_Operador.ST_Gravar = true;
            this.NM_Operador.ST_Int = false;
            this.NM_Operador.ST_LimpaCampo = true;
            this.NM_Operador.ST_NotNull = true;
            this.NM_Operador.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Sigla_Operador
            // 
            this.Sigla_Operador.AccessibleDescription = null;
            this.Sigla_Operador.AccessibleName = null;
            resources.ApplyResources(this.Sigla_Operador, "Sigla_Operador");
            this.Sigla_Operador.BackColor = System.Drawing.SystemColors.Window;
            this.Sigla_Operador.BackgroundImage = null;
            this.Sigla_Operador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Sigla_Operador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Operador, "Sigla_Operador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Sigla_Operador.Name = "Sigla_Operador";
            this.Sigla_Operador.NM_Alias = "";
            this.Sigla_Operador.NM_Campo = "";
            this.Sigla_Operador.NM_CampoBusca = "";
            this.Sigla_Operador.NM_Param = "";
            this.Sigla_Operador.QTD_Zero = 0;
            this.Sigla_Operador.ST_AutoInc = false;
            this.Sigla_Operador.ST_DisableAuto = false;
            this.Sigla_Operador.ST_Float = false;
            this.Sigla_Operador.ST_Gravar = true;
            this.Sigla_Operador.ST_Int = false;
            this.Sigla_Operador.ST_LimpaCampo = true;
            this.Sigla_Operador.ST_NotNull = true;
            this.Sigla_Operador.ST_PrimaryKey = false;
            // 
            // grid_Operador
            // 
            this.grid_Operador.AccessibleDescription = null;
            this.grid_Operador.AccessibleName = null;
            this.grid_Operador.AllowUserToAddRows = false;
            this.grid_Operador.AllowUserToDeleteRows = false;
            this.grid_Operador.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_Operador.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.grid_Operador, "grid_Operador");
            this.grid_Operador.AutoGenerateColumns = false;
            this.grid_Operador.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_Operador.BackgroundImage = null;
            this.grid_Operador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_Operador.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Operador.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Operador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Operador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDOperadorDataGridViewTextBoxColumn,
            this.nMOperadorDataGridViewTextBoxColumn,
            this.siglaOperadorDataGridViewTextBoxColumn});
            this.grid_Operador.DataSource = this.BS_Operador;
            this.grid_Operador.Font = null;
            this.grid_Operador.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_Operador.Name = "grid_Operador";
            this.grid_Operador.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Operador.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // BN_Operador
            // 
            this.BN_Operador.AccessibleDescription = null;
            this.BN_Operador.AccessibleName = null;
            this.BN_Operador.AddNewItem = null;
            resources.ApplyResources(this.BN_Operador, "BN_Operador");
            this.BN_Operador.BackgroundImage = null;
            this.BN_Operador.BindingSource = this.BS_Operador;
            this.BN_Operador.CountItem = this.bindingNavigatorCountItem;
            this.BN_Operador.DeleteItem = null;
            this.BN_Operador.Font = null;
            this.BN_Operador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Operador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Operador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Operador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Operador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Operador.Name = "BN_Operador";
            this.BN_Operador.PositionItem = this.bindingNavigatorPositionItem;
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
            // iDOperadorDataGridViewTextBoxColumn
            // 
            this.iDOperadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDOperadorDataGridViewTextBoxColumn.DataPropertyName = "ID_Operador";
            resources.ApplyResources(this.iDOperadorDataGridViewTextBoxColumn, "iDOperadorDataGridViewTextBoxColumn");
            this.iDOperadorDataGridViewTextBoxColumn.Name = "iDOperadorDataGridViewTextBoxColumn";
            this.iDOperadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMOperadorDataGridViewTextBoxColumn
            // 
            this.nMOperadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMOperadorDataGridViewTextBoxColumn.DataPropertyName = "NM_Operador";
            resources.ApplyResources(this.nMOperadorDataGridViewTextBoxColumn, "nMOperadorDataGridViewTextBoxColumn");
            this.nMOperadorDataGridViewTextBoxColumn.Name = "nMOperadorDataGridViewTextBoxColumn";
            this.nMOperadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaOperadorDataGridViewTextBoxColumn
            // 
            this.siglaOperadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaOperadorDataGridViewTextBoxColumn.DataPropertyName = "Sigla_Operador";
            resources.ApplyResources(this.siglaOperadorDataGridViewTextBoxColumn, "siglaOperadorDataGridViewTextBoxColumn");
            this.siglaOperadorDataGridViewTextBoxColumn.Name = "siglaOperadorDataGridViewTextBoxColumn";
            this.siglaOperadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFCad_Operador
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_Operador";
            this.Load += new System.EventHandler(this.TFCad_Operador_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Operador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Operador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Operador)).EndInit();
            this.BN_Operador.ResumeLayout(false);
            this.BN_Operador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_Nr_Serie;
        private System.Windows.Forms.Label LB_DS_SerieNf;
        private Componentes.EditDefault ID_Operador;
        private Componentes.EditDefault NM_Operador;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Sigla_Operador;
        private Componentes.DataGridDefault grid_Operador;
        private System.Windows.Forms.BindingSource BS_Operador;
        private System.Windows.Forms.BindingNavigator BN_Operador;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDOperadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMOperadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaOperadorDataGridViewTextBoxColumn;
    }
}
