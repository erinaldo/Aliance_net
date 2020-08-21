namespace Almoxarifado.Cadastros
{
    partial class TFCadLocal
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
            System.Windows.Forms.Label ds_almoxarifadoLabel;
            System.Windows.Forms.Label id_almoxLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadLocal));
            this.BS_CadLocal = new System.Windows.Forms.BindingSource(this.components);
            this.Nm_Almox = new Componentes.EditDefault(this.components);
            this.Id_Almox = new Componentes.EditFloat(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.BN_CadLocal = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.idalmoxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsalmoxarifadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ds_almoxarifadoLabel = new System.Windows.Forms.Label();
            id_almoxLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_Almox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocal)).BeginInit();
            this.BN_CadLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(id_almoxLabel);
            this.pDados.Controls.Add(this.Id_Almox);
            this.pDados.Controls.Add(ds_almoxarifadoLabel);
            this.pDados.Controls.Add(this.Nm_Almox);
            this.pDados.Size = new System.Drawing.Size(623, 57);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(635, 285);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.BN_CadLocal);
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(627, 259);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadLocal, 0);
            // 
            // ds_almoxarifadoLabel
            // 
            ds_almoxarifadoLabel.AutoSize = true;
            ds_almoxarifadoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_almoxarifadoLabel.Location = new System.Drawing.Point(0, 33);
            ds_almoxarifadoLabel.Name = "ds_almoxarifadoLabel";
            ds_almoxarifadoLabel.Size = new System.Drawing.Size(119, 13);
            ds_almoxarifadoLabel.TabIndex = 2;
            ds_almoxarifadoLabel.Text = "Nome Almoxarifado:";
            // 
            // id_almoxLabel
            // 
            id_almoxLabel.AutoSize = true;
            id_almoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_almoxLabel.Location = new System.Drawing.Point(67, 11);
            id_almoxLabel.Name = "id_almoxLabel";
            id_almoxLabel.Size = new System.Drawing.Size(52, 13);
            id_almoxLabel.TabIndex = 4;
            id_almoxLabel.Text = "Almox. :";
            // 
            // BS_CadLocal
            // 
            this.BS_CadLocal.DataSource = typeof(CamadaDados.Almoxarifado.TRegistro_CadLocal);
            // 
            // Nm_Almox
            // 
            this.Nm_Almox.BackColor = System.Drawing.SystemColors.Window;
            this.Nm_Almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nm_Almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadLocal, "Ds_almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nm_Almox.Enabled = false;
            this.Nm_Almox.Location = new System.Drawing.Point(125, 28);
            this.Nm_Almox.MaxLength = 20;
            this.Nm_Almox.Name = "Nm_Almox";
            this.Nm_Almox.NM_Alias = "";
            this.Nm_Almox.NM_Campo = "";
            this.Nm_Almox.NM_CampoBusca = "";
            this.Nm_Almox.NM_Param = "";
            this.Nm_Almox.QTD_Zero = 0;
            this.Nm_Almox.Size = new System.Drawing.Size(471, 20);
            this.Nm_Almox.ST_AutoInc = false;
            this.Nm_Almox.ST_DisableAuto = false;
            this.Nm_Almox.ST_Float = false;
            this.Nm_Almox.ST_Gravar = true;
            this.Nm_Almox.ST_Int = false;
            this.Nm_Almox.ST_LimpaCampo = true;
            this.Nm_Almox.ST_NotNull = true;
            this.Nm_Almox.ST_PrimaryKey = false;
            this.Nm_Almox.TabIndex = 1;
            // 
            // Id_Almox
            // 
            this.Id_Almox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CadLocal, "Id_almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Almox.Enabled = false;
            this.Id_Almox.Location = new System.Drawing.Point(125, 6);
            this.Id_Almox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Id_Almox.Name = "Id_Almox";
            this.Id_Almox.NM_Alias = "";
            this.Id_Almox.NM_Campo = "";
            this.Id_Almox.NM_Param = "";
            this.Id_Almox.Operador = "";
            this.Id_Almox.Size = new System.Drawing.Size(64, 20);
            this.Id_Almox.ST_AutoInc = false;
            this.Id_Almox.ST_DisableAuto = false;
            this.Id_Almox.ST_Gravar = true;
            this.Id_Almox.ST_LimparCampo = true;
            this.Id_Almox.ST_NotNull = true;
            this.Id_Almox.ST_PrimaryKey = true;
            this.Id_Almox.TabIndex = 0;
            this.Id_Almox.ThousandsSeparator = true;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idalmoxDataGridViewTextBoxColumn,
            this.dsalmoxarifadoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.BS_CadLocal;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 57);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(623, 198);
            this.dataGridDefault1.TabIndex = 1;
            this.dataGridDefault1.TabStop = false;
            // 
            // BN_CadLocal
            // 
            this.BN_CadLocal.AddNewItem = null;
            this.BN_CadLocal.BindingSource = this.BS_CadLocal;
            this.BN_CadLocal.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadLocal.DeleteItem = null;
            this.BN_CadLocal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.BN_CadLocal.Location = new System.Drawing.Point(0, 230);
            this.BN_CadLocal.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadLocal.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadLocal.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadLocal.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadLocal.Name = "BN_CadLocal";
            this.BN_CadLocal.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadLocal.Size = new System.Drawing.Size(623, 25);
            this.BN_CadLocal.TabIndex = 2;
            this.BN_CadLocal.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // idalmoxDataGridViewTextBoxColumn
            // 
            this.idalmoxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idalmoxDataGridViewTextBoxColumn.DataPropertyName = "Id_almox";
            this.idalmoxDataGridViewTextBoxColumn.HeaderText = "Id.Almoxarifado";
            this.idalmoxDataGridViewTextBoxColumn.Name = "idalmoxDataGridViewTextBoxColumn";
            this.idalmoxDataGridViewTextBoxColumn.ReadOnly = true;
            this.idalmoxDataGridViewTextBoxColumn.Width = 104;
            // 
            // dsalmoxarifadoDataGridViewTextBoxColumn
            // 
            this.dsalmoxarifadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsalmoxarifadoDataGridViewTextBoxColumn.DataPropertyName = "Ds_almoxarifado";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.HeaderText = "Desc.Almoxarifado";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.Name = "dsalmoxarifadoDataGridViewTextBoxColumn";
            this.dsalmoxarifadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsalmoxarifadoDataGridViewTextBoxColumn.Width = 120;
            // 
            // TFCadLocal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(635, 328);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadLocal";
            this.Text = "Cadastro de Local Almoxarifado";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Id_Almox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadLocal)).EndInit();
            this.BN_CadLocal.ResumeLayout(false);
            this.BN_CadLocal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadLocal;
        private Componentes.EditFloat Id_Almox;
        private Componentes.EditDefault Nm_Almox;
        private System.Windows.Forms.BindingNavigator BN_CadLocal;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idalmoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsalmoxarifadoDataGridViewTextBoxColumn;
    }
}
