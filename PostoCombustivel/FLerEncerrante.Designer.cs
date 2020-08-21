namespace PostoCombustivel
{
    partial class TFLerEncerrante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLerEncerrante));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pBico = new Componentes.PanelDados(this.components);
            this.st_marcar = new Componentes.CheckBoxDefault(this.components);
            this.gBico = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.enderecofisicobicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_encerrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idbombastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtanquestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBico = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_gravar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral.SuspendLayout();
            this.pBico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pBico, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 39);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 407F));
            this.tlpCentral.Size = new System.Drawing.Size(762, 409);
            this.tlpCentral.TabIndex = 1;
            // 
            // pBico
            // 
            this.pBico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBico.Controls.Add(this.st_marcar);
            this.pBico.Controls.Add(this.gBico);
            this.pBico.Controls.Add(this.bindingNavigator1);
            this.pBico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBico.Location = new System.Drawing.Point(5, 5);
            this.pBico.Name = "pBico";
            this.pBico.NM_ProcDeletar = "";
            this.pBico.NM_ProcGravar = "";
            this.pBico.Size = new System.Drawing.Size(752, 399);
            this.pBico.TabIndex = 0;
            // 
            // st_marcar
            // 
            this.st_marcar.AutoSize = true;
            this.st_marcar.Location = new System.Drawing.Point(7, 12);
            this.st_marcar.Name = "st_marcar";
            this.st_marcar.NM_Alias = "";
            this.st_marcar.NM_Campo = "";
            this.st_marcar.NM_Param = "";
            this.st_marcar.Size = new System.Drawing.Size(15, 14);
            this.st_marcar.ST_Gravar = false;
            this.st_marcar.ST_LimparCampo = true;
            this.st_marcar.ST_NotNull = false;
            this.st_marcar.TabIndex = 2;
            this.st_marcar.UseVisualStyleBackColor = true;
            this.st_marcar.Vl_False = "";
            this.st_marcar.Vl_True = "";
            this.st_marcar.Click += new System.EventHandler(this.st_marcar_Click);
            // 
            // gBico
            // 
            this.gBico.AllowUserToAddRows = false;
            this.gBico.AllowUserToDeleteRows = false;
            this.gBico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBico.AutoGenerateColumns = false;
            this.gBico.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBico.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.enderecofisicobicoDataGridViewTextBoxColumn,
            this.Qtd_encerrante,
            this.idbombastrDataGridViewTextBoxColumn,
            this.idtanquestrDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn});
            this.gBico.DataSource = this.bsBico;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gBico.DefaultCellStyle = dataGridViewCellStyle4;
            this.gBico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBico.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBico.Location = new System.Drawing.Point(0, 0);
            this.gBico.MultiSelect = false;
            this.gBico.Name = "gBico";
            this.gBico.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBico.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gBico.RowHeadersWidth = 23;
            this.gBico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gBico.Size = new System.Drawing.Size(748, 370);
            this.gBico.TabIndex = 0;
            this.gBico.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gBico_ColumnHeaderMouseClick);
            this.gBico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gBico_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Ler";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 28;
            // 
            // enderecofisicobicoDataGridViewTextBoxColumn
            // 
            this.enderecofisicobicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enderecofisicobicoDataGridViewTextBoxColumn.DataPropertyName = "Enderecofisicobico";
            this.enderecofisicobicoDataGridViewTextBoxColumn.HeaderText = "Nº Bico";
            this.enderecofisicobicoDataGridViewTextBoxColumn.Name = "enderecofisicobicoDataGridViewTextBoxColumn";
            this.enderecofisicobicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.enderecofisicobicoDataGridViewTextBoxColumn.Width = 63;
            // 
            // Qtd_encerrante
            // 
            this.Qtd_encerrante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_encerrante.DataPropertyName = "Qtd_encerrante";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Crimson;
            this.Qtd_encerrante.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qtd_encerrante.HeaderText = "Encerrante";
            this.Qtd_encerrante.Name = "Qtd_encerrante";
            this.Qtd_encerrante.ReadOnly = true;
            this.Qtd_encerrante.Width = 84;
            // 
            // idbombastrDataGridViewTextBoxColumn
            // 
            this.idbombastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idbombastrDataGridViewTextBoxColumn.DataPropertyName = "Id_bombastr";
            this.idbombastrDataGridViewTextBoxColumn.HeaderText = "Id. Bomba";
            this.idbombastrDataGridViewTextBoxColumn.Name = "idbombastrDataGridViewTextBoxColumn";
            this.idbombastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idbombastrDataGridViewTextBoxColumn.Width = 74;
            // 
            // idtanquestrDataGridViewTextBoxColumn
            // 
            this.idtanquestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtanquestrDataGridViewTextBoxColumn.DataPropertyName = "Id_tanquestr";
            this.idtanquestrDataGridViewTextBoxColumn.HeaderText = "Id. Tanque";
            this.idtanquestrDataGridViewTextBoxColumn.Name = "idtanquestrDataGridViewTextBoxColumn";
            this.idtanquestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtanquestrDataGridViewTextBoxColumn.Width = 78;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Combustivel";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 99;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 89;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 85;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // bsBico
            // 
            this.bsBico.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsBico;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 370);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(748, 25);
            this.bindingNavigator1.TabIndex = 1;
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
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.bb_gravar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(762, 39);
            this.barraMenu.TabIndex = 12;
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(126, 36);
            this.BB_Buscar.Text = "(F2)\r\nLer Encerrante";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // bb_gravar
            // 
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(81, 36);
            this.bb_gravar.Text = "(F4)\r\nGravar";
            this.bb_gravar.ToolTipText = "Inutilizar NF-e";
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // TFLerEncerrante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 448);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TFLerEncerrante";
            this.Text = "Ler Encerrantes dos Bicos";
            this.Load += new System.EventHandler(this.TFLerEncerrante_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLerEncerrante_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLerEncerrante_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pBico.ResumeLayout(false);
            this.pBico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsBico;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pBico;
        private Componentes.CheckBoxDefault st_marcar;
        private Componentes.DataGridDefault gBico;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gravar;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecofisicobicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_encerrante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbombastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtanquestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
    }
}