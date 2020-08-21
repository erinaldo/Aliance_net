namespace Almoxarifado.Cadastros
{
    partial class FCadFornec_X_GrupoItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadFornec_X_GrupoItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bb_grupo = new System.Windows.Forms.Button();
            this.bb_clifor = new System.Windows.Forms.Button();
            this.ds_grupo = new Componentes.EditDefault(this.components);
            this.bs_cliforGrupo = new System.Windows.Forms.BindingSource(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.bn_cliforGrupo = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.gPesquisa = new Componentes.DataGridDefault(this.components);
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cliforGrupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_cliforGrupo)).BeginInit();
            this.bn_cliforGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pDados.Controls.Add(this.bb_grupo);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.ds_grupo);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_grupo);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Size = new System.Drawing.Size(659, 63);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gPesquisa);
            this.tpPadrao.Controls.Add(this.bn_cliforGrupo);
            this.tpPadrao.Controls.SetChildIndex(this.bn_cliforGrupo, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gPesquisa, 0);
            // 
            // bb_grupo
            // 
            this.bb_grupo.BackColor = System.Drawing.SystemColors.Control;
            this.bb_grupo.Enabled = false;
            this.bb_grupo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_grupo.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupo.Image")));
            this.bb_grupo.Location = new System.Drawing.Point(174, 29);
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.Size = new System.Drawing.Size(37, 20);
            this.bb_grupo.TabIndex = 15;
            this.bb_grupo.UseVisualStyleBackColor = false;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Enabled = false;
            this.bb_clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.Location = new System.Drawing.Point(174, 8);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(37, 20);
            this.bb_clifor.TabIndex = 14;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // ds_grupo
            // 
            this.ds_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cliforGrupo, "Ds_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_grupo.Enabled = false;
            this.ds_grupo.Location = new System.Drawing.Point(212, 29);
            this.ds_grupo.Name = "ds_grupo";
            this.ds_grupo.NM_Alias = "";
            this.ds_grupo.NM_Campo = "ds_grupo";
            this.ds_grupo.NM_CampoBusca = "ds_grupo";
            this.ds_grupo.NM_Param = "@P_DS_GRUPO";
            this.ds_grupo.QTD_Zero = 0;
            this.ds_grupo.Size = new System.Drawing.Size(439, 20);
            this.ds_grupo.ST_AutoInc = false;
            this.ds_grupo.ST_DisableAuto = false;
            this.ds_grupo.ST_Float = false;
            this.ds_grupo.ST_Gravar = false;
            this.ds_grupo.ST_Int = false;
            this.ds_grupo.ST_LimpaCampo = true;
            this.ds_grupo.ST_NotNull = false;
            this.ds_grupo.ST_PrimaryKey = false;
            this.ds_grupo.TabIndex = 13;
            // 
            // bs_cliforGrupo
            // 
            this.bs_cliforGrupo.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadFornec_X_GrupoItem);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cliforGrupo, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(212, 8);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(439, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cód. Grupo.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Cód. Clifor.:";
            // 
            // cd_grupo
            // 
            this.cd_grupo.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cliforGrupo, "Cd_grupo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_grupo.Enabled = false;
            this.cd_grupo.Location = new System.Drawing.Point(89, 29);
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "a";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_GRUPO";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.Size = new System.Drawing.Size(84, 20);
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = true;
            this.cd_grupo.ST_Int = false;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = true;
            this.cd_grupo.ST_PrimaryKey = true;
            this.cd_grupo.TabIndex = 9;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            this.cd_grupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cd_grupo_KeyPress);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_cliforGrupo, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Enabled = false;
            this.cd_clifor.Location = new System.Drawing.Point(89, 8);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "a";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(84, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = true;
            this.cd_clifor.TabIndex = 8;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            this.cd_clifor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cd_clifor_KeyPress);
            // 
            // bn_cliforGrupo
            // 
            this.bn_cliforGrupo.AddNewItem = null;
            this.bn_cliforGrupo.CountItem = this.bindingNavigatorCountItem;
            this.bn_cliforGrupo.DeleteItem = null;
            this.bn_cliforGrupo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bn_cliforGrupo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_cliforGrupo.Location = new System.Drawing.Point(0, 335);
            this.bn_cliforGrupo.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_cliforGrupo.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_cliforGrupo.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_cliforGrupo.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_cliforGrupo.Name = "bn_cliforGrupo";
            this.bn_cliforGrupo.PositionItem = this.bindingNavigatorPositionItem;
            this.bn_cliforGrupo.Size = new System.Drawing.Size(659, 25);
            this.bn_cliforGrupo.TabIndex = 1;
            this.bn_cliforGrupo.Text = "bindingNavigator1";
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
            // gPesquisa
            // 
            this.gPesquisa.AllowUserToAddRows = false;
            this.gPesquisa.AllowUserToDeleteRows = false;
            this.gPesquisa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gPesquisa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gPesquisa.AutoGenerateColumns = false;
            this.gPesquisa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gPesquisa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.cdgrupoDataGridViewTextBoxColumn,
            this.dsgrupoDataGridViewTextBoxColumn});
            this.gPesquisa.DataSource = this.bs_cliforGrupo;
            this.gPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gPesquisa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gPesquisa.Location = new System.Drawing.Point(0, 63);
            this.gPesquisa.Name = "gPesquisa";
            this.gPesquisa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gPesquisa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gPesquisa.RowHeadersWidth = 23;
            this.gPesquisa.Size = new System.Drawing.Size(659, 272);
            this.gPesquisa.TabIndex = 2;
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Código Cliente Fornecedor";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcliforDataGridViewTextBoxColumn.Width = 143;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Nome Cliente Fornecedor";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 139;
            // 
            // cdgrupoDataGridViewTextBoxColumn
            // 
            this.cdgrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdgrupoDataGridViewTextBoxColumn.DataPropertyName = "Cd_grupo";
            this.cdgrupoDataGridViewTextBoxColumn.HeaderText = "Código Grupo";
            this.cdgrupoDataGridViewTextBoxColumn.Name = "cdgrupoDataGridViewTextBoxColumn";
            this.cdgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdgrupoDataGridViewTextBoxColumn.Width = 89;
            // 
            // dsgrupoDataGridViewTextBoxColumn
            // 
            this.dsgrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsgrupoDataGridViewTextBoxColumn.DataPropertyName = "Ds_grupo";
            this.dsgrupoDataGridViewTextBoxColumn.HeaderText = "Descrição Grupo";
            this.dsgrupoDataGridViewTextBoxColumn.Name = "dsgrupoDataGridViewTextBoxColumn";
            this.dsgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsgrupoDataGridViewTextBoxColumn.Width = 103;
            // 
            // FCadFornec_X_GrupoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadFornec_X_GrupoItem";
            this.Text = "Cadastro Fornecedor por Grupo Item";
            this.Load += new System.EventHandler(this.FCadFornec_X_GrupoItem_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_cliforGrupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_cliforGrupo)).EndInit();
            this.bn_cliforGrupo.ResumeLayout(false);
            this.bn_cliforGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button bb_grupo;
        public System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault ds_grupo;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_grupo;
        private Componentes.EditDefault cd_clifor;
        private Componentes.DataGridDefault gPesquisa;
        private System.Windows.Forms.BindingNavigator bn_cliforGrupo;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bs_cliforGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdgrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgrupoDataGridViewTextBoxColumn;
    }
}
