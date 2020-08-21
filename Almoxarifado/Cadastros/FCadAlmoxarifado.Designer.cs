namespace Almoxarifado.Cadastros
{
    partial class TFCadAlmoxarifado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadAlmoxarifado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Nm_Almox = new Componentes.EditDefault(this.components);
            this.BS_CadAlmoxarifado = new System.Windows.Forms.BindingSource(this.components);
            this.BN_CadAlmoxarifado = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.gAlmoxarif = new Componentes.DataGridDefault(this.components);
            this.idalmoxStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_almoxarif = new Componentes.EditDefault(this.components);
            ds_almoxarifadoLabel = new System.Windows.Forms.Label();
            id_almoxLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadAlmoxarifado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadAlmoxarifado)).BeginInit();
            this.BN_CadAlmoxarifado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAlmoxarif)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.id_almoxarif);
            this.pDados.Controls.Add(id_almoxLabel);
            this.pDados.Controls.Add(ds_almoxarifadoLabel);
            this.pDados.Controls.Add(this.Nm_Almox);
            this.pDados.Size = new System.Drawing.Size(623, 60);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(635, 285);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gAlmoxarif);
            this.tpPadrao.Controls.Add(this.BN_CadAlmoxarifado);
            this.tpPadrao.Size = new System.Drawing.Size(627, 259);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadAlmoxarifado, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gAlmoxarif, 0);
            // 
            // ds_almoxarifadoLabel
            // 
            ds_almoxarifadoLabel.AutoSize = true;
            ds_almoxarifadoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_almoxarifadoLabel.Location = new System.Drawing.Point(4, 33);
            ds_almoxarifadoLabel.Name = "ds_almoxarifadoLabel";
            ds_almoxarifadoLabel.Size = new System.Drawing.Size(83, 13);
            ds_almoxarifadoLabel.TabIndex = 2;
            ds_almoxarifadoLabel.Text = "Almoxarifado:";
            // 
            // id_almoxLabel
            // 
            id_almoxLabel.AutoSize = true;
            id_almoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            id_almoxLabel.Location = new System.Drawing.Point(37, 7);
            id_almoxLabel.Name = "id_almoxLabel";
            id_almoxLabel.Size = new System.Drawing.Size(50, 13);
            id_almoxLabel.TabIndex = 4;
            id_almoxLabel.Text = "Codigo:";
            // 
            // Nm_Almox
            // 
            this.Nm_Almox.BackColor = System.Drawing.SystemColors.Window;
            this.Nm_Almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nm_Almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadAlmoxarifado, "Ds_almoxarifado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Nm_Almox.Enabled = false;
            this.Nm_Almox.Location = new System.Drawing.Point(93, 30);
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
            // BS_CadAlmoxarifado
            // 
            this.BS_CadAlmoxarifado.DataSource = typeof(CamadaDados.Almoxarifado.TList_CadAlmoxarifado);
            // 
            // BN_CadAlmoxarifado
            // 
            this.BN_CadAlmoxarifado.AddNewItem = null;
            this.BN_CadAlmoxarifado.BindingSource = this.BS_CadAlmoxarifado;
            this.BN_CadAlmoxarifado.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadAlmoxarifado.CountItemFormat = "de {0}";
            this.BN_CadAlmoxarifado.DeleteItem = null;
            this.BN_CadAlmoxarifado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadAlmoxarifado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadAlmoxarifado.Location = new System.Drawing.Point(0, 230);
            this.BN_CadAlmoxarifado.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadAlmoxarifado.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadAlmoxarifado.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadAlmoxarifado.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadAlmoxarifado.Name = "BN_CadAlmoxarifado";
            this.BN_CadAlmoxarifado.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadAlmoxarifado.Size = new System.Drawing.Size(623, 25);
            this.BN_CadAlmoxarifado.TabIndex = 2;
            this.BN_CadAlmoxarifado.Text = "bindingNavigator1";
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
            // gAlmoxarif
            // 
            this.gAlmoxarif.AllowUserToAddRows = false;
            this.gAlmoxarif.AllowUserToDeleteRows = false;
            this.gAlmoxarif.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAlmoxarif.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gAlmoxarif.AutoGenerateColumns = false;
            this.gAlmoxarif.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAlmoxarif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAlmoxarif.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAlmoxarif.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gAlmoxarif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAlmoxarif.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idalmoxStringDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2});
            this.gAlmoxarif.DataSource = this.BS_CadAlmoxarifado;
            this.gAlmoxarif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAlmoxarif.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAlmoxarif.Location = new System.Drawing.Point(0, 60);
            this.gAlmoxarif.Name = "gAlmoxarif";
            this.gAlmoxarif.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAlmoxarif.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gAlmoxarif.RowHeadersWidth = 23;
            this.gAlmoxarif.Size = new System.Drawing.Size(623, 170);
            this.gAlmoxarif.TabIndex = 5;
            this.gAlmoxarif.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gAlmoxarif_ColumnHeaderMouseClick);
            // 
            // idalmoxStringDataGridViewTextBoxColumn
            // 
            this.idalmoxStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idalmoxStringDataGridViewTextBoxColumn.DataPropertyName = "Id_almoxString";
            this.idalmoxStringDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idalmoxStringDataGridViewTextBoxColumn.Name = "idalmoxStringDataGridViewTextBoxColumn";
            this.idalmoxStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.idalmoxStringDataGridViewTextBoxColumn.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_almoxarifado";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // id_almoxarif
            // 
            this.id_almoxarif.BackColor = System.Drawing.SystemColors.Window;
            this.id_almoxarif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almoxarif.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadAlmoxarifado, "Id_almoxString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almoxarif.Enabled = false;
            this.id_almoxarif.Location = new System.Drawing.Point(93, 4);
            this.id_almoxarif.MaxLength = 20;
            this.id_almoxarif.Name = "id_almoxarif";
            this.id_almoxarif.NM_Alias = "";
            this.id_almoxarif.NM_Campo = "ID_ALMOX";
            this.id_almoxarif.NM_CampoBusca = "ID_ALMOX";
            this.id_almoxarif.NM_Param = "@P_ID_ALMOX";
            this.id_almoxarif.QTD_Zero = 0;
            this.id_almoxarif.Size = new System.Drawing.Size(48, 20);
            this.id_almoxarif.ST_AutoInc = false;
            this.id_almoxarif.ST_DisableAuto = true;
            this.id_almoxarif.ST_Float = false;
            this.id_almoxarif.ST_Gravar = true;
            this.id_almoxarif.ST_Int = true;
            this.id_almoxarif.ST_LimpaCampo = true;
            this.id_almoxarif.ST_NotNull = true;
            this.id_almoxarif.ST_PrimaryKey = true;
            this.id_almoxarif.TabIndex = 0;
            // 
            // TFCadAlmoxarifado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(635, 328);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadAlmoxarifado";
            this.Text = "Cadastro de Local Almoxarifado";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadAlmoxarifado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadAlmoxarifado)).EndInit();
            this.BN_CadAlmoxarifado.ResumeLayout(false);
            this.BN_CadAlmoxarifado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAlmoxarif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault Nm_Almox;
        private System.Windows.Forms.BindingNavigator BN_CadAlmoxarifado;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idalmoxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsalmoxarifadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource BS_CadAlmoxarifado;
        private Componentes.DataGridDefault gAlmoxarif;
        private Componentes.EditDefault id_almoxarif;
        private System.Windows.Forms.DataGridViewTextBoxColumn idalmoxStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
