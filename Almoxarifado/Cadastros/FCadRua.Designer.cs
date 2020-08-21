namespace Almoxarifado.Cadastros
{
    partial class TFCadRua
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
            System.Windows.Forms.Label id_RuaLabel;
            System.Windows.Forms.Label ds_RuaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadRua));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BS_CadRua = new System.Windows.Forms.BindingSource(this.components);
            this.Ds_Rua = new Componentes.EditDefault(this.components);
            this.dsRuaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadRua = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ID_Rua = new Componentes.EditDefault(this.components);
            this.gRua = new Componentes.DataGridDefault(this.components);
            this.idruastrDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsruaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idruastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            id_RuaLabel = new System.Windows.Forms.Label();
            ds_RuaLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadRua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadRua)).BeginInit();
            this.BN_CadRua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRua)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AutoScroll = true;
            this.pDados.Controls.Add(this.ID_Rua);
            this.pDados.Controls.Add(ds_RuaLabel);
            this.pDados.Controls.Add(this.Ds_Rua);
            this.pDados.Controls.Add(id_RuaLabel);
            this.pDados.Size = new System.Drawing.Size(600, 61);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(612, 314);
            this.tcCentral.TabIndex = 0;
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gRua);
            this.tpPadrao.Controls.Add(this.BN_CadRua);
            this.tpPadrao.Size = new System.Drawing.Size(604, 288);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadRua, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gRua, 0);
            // 
            // id_RuaLabel
            // 
            id_RuaLabel.AutoSize = true;
            id_RuaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_RuaLabel.Location = new System.Drawing.Point(24, 6);
            id_RuaLabel.Name = "id_RuaLabel";
            id_RuaLabel.Size = new System.Drawing.Size(49, 13);
            id_RuaLabel.TabIndex = 0;
            id_RuaLabel.Text = "Id Rua:";
            // 
            // ds_RuaLabel
            // 
            ds_RuaLabel.AutoSize = true;
            ds_RuaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_RuaLabel.Location = new System.Drawing.Point(39, 32);
            ds_RuaLabel.Name = "ds_RuaLabel";
            ds_RuaLabel.Size = new System.Drawing.Size(34, 13);
            ds_RuaLabel.TabIndex = 2;
            ds_RuaLabel.Text = "Rua:";
            // 
            // BS_CadRua
            // 
            this.BS_CadRua.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadRua);
            // 
            // Ds_Rua
            // 
            this.Ds_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadRua, "Ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Rua.Enabled = false;
            this.Ds_Rua.Location = new System.Drawing.Point(79, 29);
            this.Ds_Rua.MaxLength = 20;
            this.Ds_Rua.Name = "Ds_Rua";
            this.Ds_Rua.NM_Alias = "";
            this.Ds_Rua.NM_Campo = "";
            this.Ds_Rua.NM_CampoBusca = "";
            this.Ds_Rua.NM_Param = "";
            this.Ds_Rua.QTD_Zero = 0;
            this.Ds_Rua.Size = new System.Drawing.Size(510, 20);
            this.Ds_Rua.ST_AutoInc = false;
            this.Ds_Rua.ST_DisableAuto = false;
            this.Ds_Rua.ST_Float = false;
            this.Ds_Rua.ST_Gravar = true;
            this.Ds_Rua.ST_Int = false;
            this.Ds_Rua.ST_LimpaCampo = true;
            this.Ds_Rua.ST_NotNull = false;
            this.Ds_Rua.ST_PrimaryKey = false;
            this.Ds_Rua.TabIndex = 1;
            // 
            // dsRuaDataGridViewTextBoxColumn
            // 
            this.dsRuaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsRuaDataGridViewTextBoxColumn.DataPropertyName = "Ds_Rua";
            this.dsRuaDataGridViewTextBoxColumn.HeaderText = "Rua";
            this.dsRuaDataGridViewTextBoxColumn.Name = "dsRuaDataGridViewTextBoxColumn";
            this.dsRuaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BN_CadRua
            // 
            this.BN_CadRua.AddNewItem = null;
            this.BN_CadRua.BindingSource = this.BS_CadRua;
            this.BN_CadRua.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadRua.CountItemFormat = "de {0}";
            this.BN_CadRua.DeleteItem = null;
            this.BN_CadRua.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadRua.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadRua.Location = new System.Drawing.Point(0, 259);
            this.BN_CadRua.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadRua.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadRua.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadRua.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadRua.Name = "BN_CadRua";
            this.BN_CadRua.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadRua.Size = new System.Drawing.Size(600, 25);
            this.BN_CadRua.TabIndex = 2;
            this.BN_CadRua.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // ID_Rua
            // 
            this.ID_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadRua, "Id_ruastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Rua.Enabled = false;
            this.ID_Rua.Location = new System.Drawing.Point(79, 3);
            this.ID_Rua.MaxLength = 5;
            this.ID_Rua.Name = "ID_Rua";
            this.ID_Rua.NM_Alias = "";
            this.ID_Rua.NM_Campo = "ID_Rua";
            this.ID_Rua.NM_CampoBusca = "ID_Rua";
            this.ID_Rua.NM_Param = "@P_ID_RUA";
            this.ID_Rua.QTD_Zero = 0;
            this.ID_Rua.Size = new System.Drawing.Size(60, 20);
            this.ID_Rua.ST_AutoInc = false;
            this.ID_Rua.ST_DisableAuto = true;
            this.ID_Rua.ST_Float = false;
            this.ID_Rua.ST_Gravar = true;
            this.ID_Rua.ST_Int = true;
            this.ID_Rua.ST_LimpaCampo = true;
            this.ID_Rua.ST_NotNull = true;
            this.ID_Rua.ST_PrimaryKey = true;
            this.ID_Rua.TabIndex = 0;
            // 
            // gRua
            // 
            this.gRua.AllowUserToAddRows = false;
            this.gRua.AllowUserToDeleteRows = false;
            this.gRua.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gRua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gRua.AutoGenerateColumns = false;
            this.gRua.BackgroundColor = System.Drawing.Color.LightGray;
            this.gRua.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gRua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gRua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idruastrDataGridViewTextBoxColumn1,
            this.dsruaDataGridViewTextBoxColumn2});
            this.gRua.DataSource = this.BS_CadRua;
            this.gRua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRua.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gRua.Location = new System.Drawing.Point(0, 61);
            this.gRua.Name = "gRua";
            this.gRua.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRua.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gRua.RowHeadersWidth = 23;
            this.gRua.Size = new System.Drawing.Size(600, 198);
            this.gRua.TabIndex = 1;
            this.gRua.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gRua_ColumnHeaderMouseClick);
            // 
            // idruastrDataGridViewTextBoxColumn1
            // 
            this.idruastrDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idruastrDataGridViewTextBoxColumn1.DataPropertyName = "Id_ruastr";
            this.idruastrDataGridViewTextBoxColumn1.HeaderText = "Id. Rua";
            this.idruastrDataGridViewTextBoxColumn1.Name = "idruastrDataGridViewTextBoxColumn1";
            this.idruastrDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idruastrDataGridViewTextBoxColumn1.Width = 67;
            // 
            // dsruaDataGridViewTextBoxColumn2
            // 
            this.dsruaDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsruaDataGridViewTextBoxColumn2.DataPropertyName = "Ds_rua";
            this.dsruaDataGridViewTextBoxColumn2.HeaderText = "Rua";
            this.dsruaDataGridViewTextBoxColumn2.Name = "dsruaDataGridViewTextBoxColumn2";
            this.dsruaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.dsruaDataGridViewTextBoxColumn2.Width = 52;
            // 
            // idruastrDataGridViewTextBoxColumn
            // 
            this.idruastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idruastrDataGridViewTextBoxColumn.DataPropertyName = "Id_ruastr";
            this.idruastrDataGridViewTextBoxColumn.HeaderText = "Id. Rua";
            this.idruastrDataGridViewTextBoxColumn.Name = "idruastrDataGridViewTextBoxColumn";
            // 
            // TFCadRua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(612, 357);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadRua";
            this.Text = "Cadastro de Ruas do Almoxarifado";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadRua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadRua)).EndInit();
            this.BN_CadRua.ResumeLayout(false);
            this.BN_CadRua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault Ds_Rua;
        private System.Windows.Forms.BindingSource BS_CadRua;
        private System.Windows.Forms.BindingNavigator BN_CadRua;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsRuaDataGridViewTextBoxColumn;
        private Componentes.EditDefault ID_Rua;
        private Componentes.DataGridDefault gRua;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsRuaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idruastrDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsruaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idruastrDataGridViewTextBoxColumn;


    }
}
