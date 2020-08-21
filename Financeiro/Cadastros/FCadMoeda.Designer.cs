namespace Financeiro.Cadastros
{
    partial class TFCadMoeda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMoeda));
            this.gMoeda = new Componentes.DataGridDefault(this.components);
            this.cdmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedasingularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsMoeda = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_moeda = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_moeda_singular = new Componentes.EditDefault(this.components);
            this.ds_moeda_plural = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.sigla = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gMoeda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMoeda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.sigla);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_moeda_plural);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_moeda_singular);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_moeda);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(659, 106);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gMoeda);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gMoeda, 0);
            // 
            // gMoeda
            // 
            this.gMoeda.AllowUserToAddRows = false;
            this.gMoeda.AllowUserToDeleteRows = false;
            this.gMoeda.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gMoeda.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gMoeda.AutoGenerateColumns = false;
            this.gMoeda.BackgroundColor = System.Drawing.Color.LightGray;
            this.gMoeda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gMoeda.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gMoeda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gMoeda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gMoeda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdmoedaDataGridViewTextBoxColumn,
            this.dsmoedasingularDataGridViewTextBoxColumn,
            this.siglaDataGridViewTextBoxColumn});
            this.gMoeda.DataSource = this.bsMoeda;
            this.gMoeda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMoeda.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gMoeda.Location = new System.Drawing.Point(0, 106);
            this.gMoeda.Name = "gMoeda";
            this.gMoeda.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gMoeda.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gMoeda.RowHeadersWidth = 23;
            this.gMoeda.Size = new System.Drawing.Size(659, 229);
            this.gMoeda.TabIndex = 1;
            this.gMoeda.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gMoeda_ColumnHeaderMouseClick);
            // 
            // cdmoedaDataGridViewTextBoxColumn
            // 
            this.cdmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmoedaDataGridViewTextBoxColumn.DataPropertyName = "Cd_moeda";
            this.cdmoedaDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.cdmoedaDataGridViewTextBoxColumn.Name = "cdmoedaDataGridViewTextBoxColumn";
            this.cdmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdmoedaDataGridViewTextBoxColumn.Width = 65;
            // 
            // dsmoedasingularDataGridViewTextBoxColumn
            // 
            this.dsmoedasingularDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmoedasingularDataGridViewTextBoxColumn.DataPropertyName = "Ds_moeda_singular";
            this.dsmoedasingularDataGridViewTextBoxColumn.HeaderText = "Moeda";
            this.dsmoedasingularDataGridViewTextBoxColumn.Name = "dsmoedasingularDataGridViewTextBoxColumn";
            this.dsmoedasingularDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmoedasingularDataGridViewTextBoxColumn.Width = 65;
            // 
            // siglaDataGridViewTextBoxColumn
            // 
            this.siglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn.DataPropertyName = "Sigla";
            this.siglaDataGridViewTextBoxColumn.HeaderText = "Sigla";
            this.siglaDataGridViewTextBoxColumn.Name = "siglaDataGridViewTextBoxColumn";
            this.siglaDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaDataGridViewTextBoxColumn.Width = 55;
            // 
            // bsMoeda
            // 
            this.bsMoeda.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_Moeda);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // cd_moeda
            // 
            this.cd_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.cd_moeda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_moeda.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMoeda, "Cd_moeda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_moeda.Enabled = false;
            this.cd_moeda.Location = new System.Drawing.Point(91, 3);
            this.cd_moeda.Name = "cd_moeda";
            this.cd_moeda.NM_Alias = "";
            this.cd_moeda.NM_Campo = "cd_moeda";
            this.cd_moeda.NM_CampoBusca = "cd_moeda";
            this.cd_moeda.NM_Param = "@P_CD_MOEDA";
            this.cd_moeda.QTD_Zero = 0;
            this.cd_moeda.Size = new System.Drawing.Size(60, 20);
            this.cd_moeda.ST_AutoInc = false;
            this.cd_moeda.ST_DisableAuto = true;
            this.cd_moeda.ST_Float = false;
            this.cd_moeda.ST_Gravar = true;
            this.cd_moeda.ST_Int = true;
            this.cd_moeda.ST_LimpaCampo = true;
            this.cd_moeda.ST_NotNull = true;
            this.cd_moeda.ST_PrimaryKey = true;
            this.cd_moeda.TabIndex = 0;
            this.cd_moeda.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Moeda Singular:";
            // 
            // ds_moeda_singular
            // 
            this.ds_moeda_singular.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda_singular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_moeda_singular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda_singular.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMoeda, "Ds_moeda_singular", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_moeda_singular.Enabled = false;
            this.ds_moeda_singular.Location = new System.Drawing.Point(91, 29);
            this.ds_moeda_singular.Name = "ds_moeda_singular";
            this.ds_moeda_singular.NM_Alias = "";
            this.ds_moeda_singular.NM_Campo = "ds_moeda_singular";
            this.ds_moeda_singular.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moeda_singular.NM_Param = "@P_DS_MOEDA_SINGULAR";
            this.ds_moeda_singular.QTD_Zero = 0;
            this.ds_moeda_singular.Size = new System.Drawing.Size(561, 20);
            this.ds_moeda_singular.ST_AutoInc = false;
            this.ds_moeda_singular.ST_DisableAuto = false;
            this.ds_moeda_singular.ST_Float = false;
            this.ds_moeda_singular.ST_Gravar = true;
            this.ds_moeda_singular.ST_Int = false;
            this.ds_moeda_singular.ST_LimpaCampo = true;
            this.ds_moeda_singular.ST_NotNull = true;
            this.ds_moeda_singular.ST_PrimaryKey = false;
            this.ds_moeda_singular.TabIndex = 1;
            this.ds_moeda_singular.TextOld = null;
            // 
            // ds_moeda_plural
            // 
            this.ds_moeda_plural.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda_plural.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_moeda_plural.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda_plural.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMoeda, "Ds_moeda_plural", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_moeda_plural.Enabled = false;
            this.ds_moeda_plural.Location = new System.Drawing.Point(91, 55);
            this.ds_moeda_plural.Name = "ds_moeda_plural";
            this.ds_moeda_plural.NM_Alias = "";
            this.ds_moeda_plural.NM_Campo = "ds_moeda_plural";
            this.ds_moeda_plural.NM_CampoBusca = "ds_moeda_plural";
            this.ds_moeda_plural.NM_Param = "@P_DS_MOEDA_PLURAL";
            this.ds_moeda_plural.QTD_Zero = 0;
            this.ds_moeda_plural.Size = new System.Drawing.Size(561, 20);
            this.ds_moeda_plural.ST_AutoInc = false;
            this.ds_moeda_plural.ST_DisableAuto = false;
            this.ds_moeda_plural.ST_Float = false;
            this.ds_moeda_plural.ST_Gravar = true;
            this.ds_moeda_plural.ST_Int = false;
            this.ds_moeda_plural.ST_LimpaCampo = true;
            this.ds_moeda_plural.ST_NotNull = false;
            this.ds_moeda_plural.ST_PrimaryKey = false;
            this.ds_moeda_plural.TabIndex = 2;
            this.ds_moeda_plural.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Moeda Plural:";
            // 
            // sigla
            // 
            this.sigla.BackColor = System.Drawing.SystemColors.Window;
            this.sigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMoeda, "Sigla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla.Enabled = false;
            this.sigla.Location = new System.Drawing.Point(91, 81);
            this.sigla.Name = "sigla";
            this.sigla.NM_Alias = "";
            this.sigla.NM_Campo = "sigla";
            this.sigla.NM_CampoBusca = "sigla";
            this.sigla.NM_Param = "@P_SIGLA";
            this.sigla.QTD_Zero = 0;
            this.sigla.Size = new System.Drawing.Size(60, 20);
            this.sigla.ST_AutoInc = false;
            this.sigla.ST_DisableAuto = false;
            this.sigla.ST_Float = false;
            this.sigla.ST_Gravar = true;
            this.sigla.ST_Int = false;
            this.sigla.ST_LimpaCampo = true;
            this.sigla.ST_NotNull = true;
            this.sigla.ST_PrimaryKey = false;
            this.sigla.TabIndex = 3;
            this.sigla.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sigla:";
            // 
            // TFCadMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadMoeda";
            this.Text = "";
            this.Load += new System.EventHandler(this.FCadMoeda_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FCadMoeda_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gMoeda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMoeda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gMoeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedasingularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsMoeda;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault sigla;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_moeda_plural;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault ds_moeda_singular;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_moeda;
        private System.Windows.Forms.Label label1;
    }
}
