namespace Commoditties.Cadastros
{
    partial class TFCad_Safra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Safra));
            this.g_CadastroSafra = new Componentes.DataGridDefault(this.components);
            this.anoSafraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSSafraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_finsafra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CadSafra = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.AnoSafra = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DS_Safra = new Componentes.EditDefault(this.components);
            this.BN_CadSafra = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_inisafra = new Componentes.EditData(this.components);
            this.editData1 = new Componentes.EditData(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadastroSafra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadSafra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadSafra)).BeginInit();
            this.BN_CadSafra.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editData1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.dt_inisafra);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_Safra);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.AnoSafra);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_CadastroSafra);
            this.tpPadrao.Controls.Add(this.BN_CadSafra);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadSafra, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadastroSafra, 0);
            // 
            // g_CadastroSafra
            // 
            this.g_CadastroSafra.AllowUserToAddRows = false;
            this.g_CadastroSafra.AllowUserToDeleteRows = false;
            this.g_CadastroSafra.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadastroSafra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_CadastroSafra.AutoGenerateColumns = false;
            this.g_CadastroSafra.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadastroSafra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadastroSafra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadastroSafra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadastroSafra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadastroSafra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.anoSafraDataGridViewTextBoxColumn,
            this.dSSafraDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.Dt_finsafra});
            this.g_CadastroSafra.DataSource = this.BS_CadSafra;
            resources.ApplyResources(this.g_CadastroSafra, "g_CadastroSafra");
            this.g_CadastroSafra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadastroSafra.Name = "g_CadastroSafra";
            this.g_CadastroSafra.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadastroSafra.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.g_CadastroSafra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // anoSafraDataGridViewTextBoxColumn
            // 
            this.anoSafraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.anoSafraDataGridViewTextBoxColumn.DataPropertyName = "AnoSafra";
            resources.ApplyResources(this.anoSafraDataGridViewTextBoxColumn, "anoSafraDataGridViewTextBoxColumn");
            this.anoSafraDataGridViewTextBoxColumn.Name = "anoSafraDataGridViewTextBoxColumn";
            this.anoSafraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSSafraDataGridViewTextBoxColumn
            // 
            this.dSSafraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSSafraDataGridViewTextBoxColumn.DataPropertyName = "DS_Safra";
            resources.ApplyResources(this.dSSafraDataGridViewTextBoxColumn, "dSSafraDataGridViewTextBoxColumn");
            this.dSSafraDataGridViewTextBoxColumn.Name = "dSSafraDataGridViewTextBoxColumn";
            this.dSSafraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Dt_inisafra";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Dt_finsafra
            // 
            this.Dt_finsafra.DataPropertyName = "Dt_finsafra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Dt_finsafra.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Dt_finsafra, "Dt_finsafra");
            this.Dt_finsafra.Name = "Dt_finsafra";
            this.Dt_finsafra.ReadOnly = true;
            // 
            // BS_CadSafra
            // 
            this.BS_CadSafra.DataSource = typeof(CamadaDados.Graos.TList_CadSafra);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // AnoSafra
            // 
            this.AnoSafra.BackColor = System.Drawing.SystemColors.Window;
            this.AnoSafra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnoSafra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AnoSafra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSafra, "AnoSafra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.AnoSafra, "AnoSafra");
            this.AnoSafra.Name = "AnoSafra";
            this.AnoSafra.NM_Alias = "a";
            this.AnoSafra.NM_Campo = "Ano Safra";
            this.AnoSafra.NM_CampoBusca = "AnoSafra";
            this.AnoSafra.NM_Param = "@P_ANOSAFRA";
            this.AnoSafra.QTD_Zero = 4;
            this.AnoSafra.ST_AutoInc = false;
            this.AnoSafra.ST_DisableAuto = true;
            this.AnoSafra.ST_Float = false;
            this.AnoSafra.ST_Gravar = true;
            this.AnoSafra.ST_Int = true;
            this.AnoSafra.ST_LimpaCampo = true;
            this.AnoSafra.ST_NotNull = true;
            this.AnoSafra.ST_PrimaryKey = true;
            this.AnoSafra.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // DS_Safra
            // 
            this.DS_Safra.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Safra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Safra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Safra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSafra, "DS_Safra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Safra, "DS_Safra");
            this.DS_Safra.Name = "DS_Safra";
            this.DS_Safra.NM_Alias = "a";
            this.DS_Safra.NM_Campo = "DS_Safra";
            this.DS_Safra.NM_CampoBusca = "DS_Safra";
            this.DS_Safra.NM_Param = "@P_DS_SAFRA";
            this.DS_Safra.QTD_Zero = 0;
            this.DS_Safra.ST_AutoInc = false;
            this.DS_Safra.ST_DisableAuto = false;
            this.DS_Safra.ST_Float = false;
            this.DS_Safra.ST_Gravar = true;
            this.DS_Safra.ST_Int = false;
            this.DS_Safra.ST_LimpaCampo = true;
            this.DS_Safra.ST_NotNull = false;
            this.DS_Safra.ST_PrimaryKey = false;
            this.DS_Safra.TextOld = null;
            // 
            // BN_CadSafra
            // 
            this.BN_CadSafra.AddNewItem = null;
            this.BN_CadSafra.BindingSource = this.BS_CadSafra;
            this.BN_CadSafra.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadSafra.CountItemFormat = "de {0}";
            this.BN_CadSafra.DeleteItem = null;
            resources.ApplyResources(this.BN_CadSafra, "BN_CadSafra");
            this.BN_CadSafra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadSafra.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadSafra.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadSafra.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadSafra.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadSafra.Name = "BN_CadSafra";
            this.BN_CadSafra.PositionItem = this.bindingNavigatorPositionItem;
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
            // dt_inisafra
            // 
            this.dt_inisafra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_inisafra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSafra, "Dt_inisafrastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_inisafra, "dt_inisafra");
            this.dt_inisafra.Name = "dt_inisafra";
            this.dt_inisafra.NM_Alias = "";
            this.dt_inisafra.NM_Campo = "";
            this.dt_inisafra.NM_CampoBusca = "";
            this.dt_inisafra.NM_Param = "";
            this.dt_inisafra.Operador = "";
            this.dt_inisafra.ST_Gravar = true;
            this.dt_inisafra.ST_LimpaCampo = true;
            this.dt_inisafra.ST_NotNull = false;
            this.dt_inisafra.ST_PrimaryKey = false;
            // 
            // editData1
            // 
            this.editData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editData1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSafra, "Dt_finsafrastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.editData1, "editData1");
            this.editData1.Name = "editData1";
            this.editData1.NM_Alias = "";
            this.editData1.NM_Campo = "";
            this.editData1.NM_CampoBusca = "";
            this.editData1.NM_Param = "";
            this.editData1.Operador = "";
            this.editData1.ST_Gravar = true;
            this.editData1.ST_LimpaCampo = true;
            this.editData1.ST_NotNull = false;
            this.editData1.ST_PrimaryKey = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // TFCad_Safra
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "TFCad_Safra";
            this.Load += new System.EventHandler(this.TFCad_Safra_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadastroSafra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadSafra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadSafra)).EndInit();
            this.BN_CadSafra.ResumeLayout(false);
            this.BN_CadSafra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault g_CadastroSafra;
        private Componentes.EditDefault AnoSafra;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DS_Safra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource BS_CadSafra;
        private System.Windows.Forms.BindingNavigator BN_CadSafra;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditData dt_inisafra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoSafraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSSafraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_finsafra;
        private Componentes.EditData editData1;
        private System.Windows.Forms.Label label4;
    }
}