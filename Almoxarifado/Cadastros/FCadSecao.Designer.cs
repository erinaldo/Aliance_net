namespace Almoxarifado.Cadastros
{
    partial class TFCadSecao
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
            System.Windows.Forms.Label id_secaoLabel;
            System.Windows.Forms.Label id_ruaLabel;
            System.Windows.Forms.Label ds_secaoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadSecao));
            this.BS_CadSecao = new System.Windows.Forms.BindingSource(this.components);
            this.gSecao = new Componentes.DataGridDefault(this.components);
            this.idsecaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssecaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idruaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_Rua = new System.Windows.Forms.Button();
            this.Id_Rua = new Componentes.EditDefault(this.components);
            this.Ds_Rua = new Componentes.EditDefault(this.components);
            this.ds_secao = new Componentes.EditDefault(this.components);
            this.BN_CadSecao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_secao = new Componentes.EditDefault(this.components);
            id_secaoLabel = new System.Windows.Forms.Label();
            id_ruaLabel = new System.Windows.Forms.Label();
            ds_secaoLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadSecao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSecao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadSecao)).BeginInit();
            this.BN_CadSecao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.id_secao);
            this.pDados.Controls.Add(this.Id_Rua);
            this.pDados.Controls.Add(this.Ds_Rua);
            this.pDados.Controls.Add(this.bb_Rua);
            this.pDados.Controls.Add(ds_secaoLabel);
            this.pDados.Controls.Add(this.ds_secao);
            this.pDados.Controls.Add(id_ruaLabel);
            this.pDados.Controls.Add(id_secaoLabel);
            this.pDados.Size = new System.Drawing.Size(603, 82);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(615, 301);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gSecao);
            this.tpPadrao.Controls.Add(this.BN_CadSecao);
            this.tpPadrao.Size = new System.Drawing.Size(607, 275);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadSecao, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gSecao, 0);
            // 
            // id_secaoLabel
            // 
            id_secaoLabel.AutoSize = true;
            id_secaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_secaoLabel.Location = new System.Drawing.Point(6, 31);
            id_secaoLabel.Name = "id_secaoLabel";
            id_secaoLabel.Size = new System.Drawing.Size(62, 13);
            id_secaoLabel.TabIndex = 1;
            id_secaoLabel.Text = "Id.Seção:";
            // 
            // id_ruaLabel
            // 
            id_ruaLabel.AutoSize = true;
            id_ruaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_ruaLabel.Location = new System.Drawing.Point(34, 6);
            id_ruaLabel.Name = "id_ruaLabel";
            id_ruaLabel.Size = new System.Drawing.Size(34, 13);
            id_ruaLabel.TabIndex = 2;
            id_ruaLabel.Text = "Rua:";
            // 
            // ds_secaoLabel
            // 
            ds_secaoLabel.AutoSize = true;
            ds_secaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_secaoLabel.Location = new System.Drawing.Point(21, 58);
            ds_secaoLabel.Name = "ds_secaoLabel";
            ds_secaoLabel.Size = new System.Drawing.Size(47, 13);
            ds_secaoLabel.TabIndex = 4;
            ds_secaoLabel.Text = "Seção:";
            // 
            // BS_CadSecao
            // 
            this.BS_CadSecao.DataSource = typeof(CamadaDados.Almoxarifado.TRegistro_CadSecao);
            // 
            // gSecao
            // 
            this.gSecao.AllowUserToAddRows = false;
            this.gSecao.AllowUserToDeleteRows = false;
            this.gSecao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gSecao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gSecao.AutoGenerateColumns = false;
            this.gSecao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gSecao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gSecao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSecao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gSecao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gSecao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idsecaoDataGridViewTextBoxColumn,
            this.dssecaoDataGridViewTextBoxColumn,
            this.idruaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2});
            this.gSecao.DataSource = this.BS_CadSecao;
            this.gSecao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSecao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gSecao.Location = new System.Drawing.Point(0, 82);
            this.gSecao.Name = "gSecao";
            this.gSecao.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSecao.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gSecao.RowHeadersWidth = 23;
            this.gSecao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gSecao.Size = new System.Drawing.Size(603, 164);
            this.gSecao.TabIndex = 1;
            this.gSecao.TabStop = false;
            this.gSecao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gSecao_ColumnHeaderMouseClick);
            // 
            // idsecaoDataGridViewTextBoxColumn
            // 
            this.idsecaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idsecaoDataGridViewTextBoxColumn.DataPropertyName = "Id_secao";
            this.idsecaoDataGridViewTextBoxColumn.HeaderText = "Id. Seção";
            this.idsecaoDataGridViewTextBoxColumn.Name = "idsecaoDataGridViewTextBoxColumn";
            this.idsecaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idsecaoDataGridViewTextBoxColumn.Width = 78;
            // 
            // dssecaoDataGridViewTextBoxColumn
            // 
            this.dssecaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssecaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_secao";
            this.dssecaoDataGridViewTextBoxColumn.HeaderText = "Descrição Seção";
            this.dssecaoDataGridViewTextBoxColumn.Name = "dssecaoDataGridViewTextBoxColumn";
            this.dssecaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dssecaoDataGridViewTextBoxColumn.Width = 105;
            // 
            // idruaDataGridViewTextBoxColumn
            // 
            this.idruaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idruaDataGridViewTextBoxColumn.DataPropertyName = "Id_rua";
            this.idruaDataGridViewTextBoxColumn.HeaderText = "Id. Rua";
            this.idruaDataGridViewTextBoxColumn.Name = "idruaDataGridViewTextBoxColumn";
            this.idruaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idruaDataGridViewTextBoxColumn.Width = 62;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_rua";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição Rua";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 95;
            // 
            // bb_Rua
            // 
            this.bb_Rua.Enabled = false;
            this.bb_Rua.Image = ((System.Drawing.Image)(resources.GetObject("bb_Rua.Image")));
            this.bb_Rua.Location = new System.Drawing.Point(146, 2);
            this.bb_Rua.Name = "bb_Rua";
            this.bb_Rua.Size = new System.Drawing.Size(30, 20);
            this.bb_Rua.TabIndex = 1;
            this.bb_Rua.UseVisualStyleBackColor = true;
            this.bb_Rua.Click += new System.EventHandler(this.bb_Rua_Click);
            // 
            // Id_Rua
            // 
            this.Id_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSecao, "Id_ruastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Rua.Enabled = false;
            this.Id_Rua.Location = new System.Drawing.Point(74, 3);
            this.Id_Rua.MaxLength = 9999;
            this.Id_Rua.Name = "Id_Rua";
            this.Id_Rua.NM_Alias = "";
            this.Id_Rua.NM_Campo = "id_rua";
            this.Id_Rua.NM_CampoBusca = "id_rua";
            this.Id_Rua.NM_Param = "@P_ID_RUA";
            this.Id_Rua.QTD_Zero = 0;
            this.Id_Rua.Size = new System.Drawing.Size(66, 20);
            this.Id_Rua.ST_AutoInc = false;
            this.Id_Rua.ST_DisableAuto = false;
            this.Id_Rua.ST_Float = false;
            this.Id_Rua.ST_Gravar = true;
            this.Id_Rua.ST_Int = true;
            this.Id_Rua.ST_LimpaCampo = true;
            this.Id_Rua.ST_NotNull = true;
            this.Id_Rua.ST_PrimaryKey = true;
            this.Id_Rua.TabIndex = 0;
            this.Id_Rua.Leave += new System.EventHandler(this.Id_Rua_Leave);
            // 
            // Ds_Rua
            // 
            this.Ds_Rua.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Rua.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Rua.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSecao, "Ds_rua", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Rua.Enabled = false;
            this.Ds_Rua.Location = new System.Drawing.Point(182, 3);
            this.Ds_Rua.Name = "Ds_Rua";
            this.Ds_Rua.NM_Alias = "";
            this.Ds_Rua.NM_Campo = "ds_rua";
            this.Ds_Rua.NM_CampoBusca = "ds_rua";
            this.Ds_Rua.NM_Param = "@P_DS_RUA";
            this.Ds_Rua.QTD_Zero = 0;
            this.Ds_Rua.Size = new System.Drawing.Size(415, 20);
            this.Ds_Rua.ST_AutoInc = false;
            this.Ds_Rua.ST_DisableAuto = false;
            this.Ds_Rua.ST_Float = false;
            this.Ds_Rua.ST_Gravar = false;
            this.Ds_Rua.ST_Int = false;
            this.Ds_Rua.ST_LimpaCampo = true;
            this.Ds_Rua.ST_NotNull = false;
            this.Ds_Rua.ST_PrimaryKey = false;
            this.Ds_Rua.TabIndex = 4;
            // 
            // ds_secao
            // 
            this.ds_secao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSecao, "Ds_secao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_secao.Enabled = false;
            this.ds_secao.Location = new System.Drawing.Point(74, 55);
            this.ds_secao.MaxLength = 20;
            this.ds_secao.Name = "ds_secao";
            this.ds_secao.NM_Alias = "";
            this.ds_secao.NM_Campo = "";
            this.ds_secao.NM_CampoBusca = "";
            this.ds_secao.NM_Param = "";
            this.ds_secao.QTD_Zero = 0;
            this.ds_secao.Size = new System.Drawing.Size(523, 20);
            this.ds_secao.ST_AutoInc = false;
            this.ds_secao.ST_DisableAuto = false;
            this.ds_secao.ST_Float = false;
            this.ds_secao.ST_Gravar = true;
            this.ds_secao.ST_Int = false;
            this.ds_secao.ST_LimpaCampo = true;
            this.ds_secao.ST_NotNull = true;
            this.ds_secao.ST_PrimaryKey = false;
            this.ds_secao.TabIndex = 3;
            // 
            // BN_CadSecao
            // 
            this.BN_CadSecao.AddNewItem = null;
            this.BN_CadSecao.BindingSource = this.BS_CadSecao;
            this.BN_CadSecao.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadSecao.DeleteItem = null;
            this.BN_CadSecao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadSecao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadSecao.Location = new System.Drawing.Point(0, 246);
            this.BN_CadSecao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadSecao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadSecao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadSecao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadSecao.Name = "BN_CadSecao";
            this.BN_CadSecao.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadSecao.Size = new System.Drawing.Size(603, 25);
            this.BN_CadSecao.TabIndex = 2;
            this.BN_CadSecao.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // id_secao
            // 
            this.id_secao.BackColor = System.Drawing.SystemColors.Window;
            this.id_secao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_secao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadSecao, "Id_secaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_secao.Enabled = false;
            this.id_secao.Location = new System.Drawing.Point(74, 29);
            this.id_secao.Name = "id_secao";
            this.id_secao.NM_Alias = "";
            this.id_secao.NM_Campo = "id_secao";
            this.id_secao.NM_CampoBusca = "id_secao";
            this.id_secao.NM_Param = "@P_ID_SECAO";
            this.id_secao.QTD_Zero = 0;
            this.id_secao.Size = new System.Drawing.Size(66, 20);
            this.id_secao.ST_AutoInc = false;
            this.id_secao.ST_DisableAuto = true;
            this.id_secao.ST_Float = false;
            this.id_secao.ST_Gravar = true;
            this.id_secao.ST_Int = true;
            this.id_secao.ST_LimpaCampo = true;
            this.id_secao.ST_NotNull = true;
            this.id_secao.ST_PrimaryKey = true;
            this.id_secao.TabIndex = 2;
            // 
            // TFCadSecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(615, 344);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadSecao";
            this.Text = "Cadastro de  Seção de Armazenagem";
            this.Load += new System.EventHandler(this.TFCadSecao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadSecao_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadSecao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gSecao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadSecao)).EndInit();
            this.BN_CadSecao.ResumeLayout(false);
            this.BN_CadSecao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadSecao;
        private Componentes.DataGridDefault gSecao;
        private System.Windows.Forms.Button bb_Rua;
        private Componentes.EditDefault Id_Rua;
        private Componentes.EditDefault Ds_Rua;
        private Componentes.EditDefault ds_secao;
        private System.Windows.Forms.BindingNavigator BN_CadSecao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Componentes.EditDefault id_secao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsecaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssecaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idruaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
