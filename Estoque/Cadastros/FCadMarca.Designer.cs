namespace Estoque.Cadastros
{
    partial class TFCadMarca
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
            System.Windows.Forms.Label cd_MarcaStringLabel;
            System.Windows.Forms.Label ds_MarcaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMarca));
            this.BS_CadMarca = new System.Windows.Forms.BindingSource(this.components);
            this.Cd_Marca = new Componentes.EditDefault(this.components);
            this.Ds_Marca = new Componentes.EditDefault(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdMarcaStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            cd_MarcaStringLabel = new System.Windows.Forms.Label();
            ds_MarcaLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(ds_MarcaLabel);
            this.pDados.Controls.Add(this.Ds_Marca);
            this.pDados.Controls.Add(cd_MarcaStringLabel);
            this.pDados.Controls.Add(this.Cd_Marca);
            this.pDados.Size = new System.Drawing.Size(586, 92);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(598, 322);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(590, 296);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // cd_MarcaStringLabel
            // 
            cd_MarcaStringLabel.AutoSize = true;
            cd_MarcaStringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_MarcaStringLabel.Location = new System.Drawing.Point(4, 14);
            cd_MarcaStringLabel.Name = "cd_MarcaStringLabel";
            cd_MarcaStringLabel.Size = new System.Drawing.Size(72, 13);
            cd_MarcaStringLabel.TabIndex = 0;
            cd_MarcaStringLabel.Text = "Cód.Marca:";
            // 
            // ds_MarcaLabel
            // 
            ds_MarcaLabel.AutoSize = true;
            ds_MarcaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_MarcaLabel.Location = new System.Drawing.Point(30, 40);
            ds_MarcaLabel.Name = "ds_MarcaLabel";
            ds_MarcaLabel.Size = new System.Drawing.Size(46, 13);
            ds_MarcaLabel.TabIndex = 2;
            ds_MarcaLabel.Text = "Marca:";
            // 
            // BS_CadMarca
            // 
            this.BS_CadMarca.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadMarca);
            // 
            // Cd_Marca
            // 
            this.Cd_Marca.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_Marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_Marca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadMarca, "Cd_MarcaString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cd_Marca.Enabled = false;
            this.Cd_Marca.Location = new System.Drawing.Point(82, 11);
            this.Cd_Marca.MaxLength = 5;
            this.Cd_Marca.Name = "Cd_Marca";
            this.Cd_Marca.NM_Alias = "";
            this.Cd_Marca.NM_Campo = "CD_MARCA";
            this.Cd_Marca.NM_CampoBusca = "CD_MARCA";
            this.Cd_Marca.NM_Param = "@P_CD_MARCA";
            this.Cd_Marca.QTD_Zero = 0;
            this.Cd_Marca.Size = new System.Drawing.Size(70, 20);
            this.Cd_Marca.ST_AutoInc = false;
            this.Cd_Marca.ST_DisableAuto = true;
            this.Cd_Marca.ST_Float = false;
            this.Cd_Marca.ST_Gravar = true;
            this.Cd_Marca.ST_Int = true;
            this.Cd_Marca.ST_LimpaCampo = true;
            this.Cd_Marca.ST_NotNull = true;
            this.Cd_Marca.ST_PrimaryKey = true;
            this.Cd_Marca.TabIndex = 1;
            // 
            // Ds_Marca
            // 
            this.Ds_Marca.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Marca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadMarca, "Ds_Marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Marca.Enabled = false;
            this.Ds_Marca.Location = new System.Drawing.Point(82, 37);
            this.Ds_Marca.MaxLength = 255;
            this.Ds_Marca.Name = "Ds_Marca";
            this.Ds_Marca.NM_Alias = "";
            this.Ds_Marca.NM_Campo = "";
            this.Ds_Marca.NM_CampoBusca = "";
            this.Ds_Marca.NM_Param = "";
            this.Ds_Marca.QTD_Zero = 0;
            this.Ds_Marca.Size = new System.Drawing.Size(457, 20);
            this.Ds_Marca.ST_AutoInc = false;
            this.Ds_Marca.ST_DisableAuto = false;
            this.Ds_Marca.ST_Float = false;
            this.Ds_Marca.ST_Gravar = true;
            this.Ds_Marca.ST_Int = false;
            this.Ds_Marca.ST_LimpaCampo = true;
            this.Ds_Marca.ST_NotNull = true;
            this.Ds_Marca.ST_PrimaryKey = false;
            this.Ds_Marca.TabIndex = 3;
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
            this.cdMarcaStringDataGridViewTextBoxColumn,
            this.dsMarcaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.BS_CadMarca;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 92);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(586, 175);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdMarcaStringDataGridViewTextBoxColumn
            // 
            this.cdMarcaStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdMarcaStringDataGridViewTextBoxColumn.DataPropertyName = "Cd_MarcaString";
            this.cdMarcaStringDataGridViewTextBoxColumn.HeaderText = "Cód.Marca";
            this.cdMarcaStringDataGridViewTextBoxColumn.Name = "cdMarcaStringDataGridViewTextBoxColumn";
            this.cdMarcaStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdMarcaStringDataGridViewTextBoxColumn.Width = 84;
            // 
            // dsMarcaDataGridViewTextBoxColumn
            // 
            this.dsMarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsMarcaDataGridViewTextBoxColumn.DataPropertyName = "Ds_Marca";
            this.dsMarcaDataGridViewTextBoxColumn.HeaderText = "Desc.Marca";
            this.dsMarcaDataGridViewTextBoxColumn.Name = "dsMarcaDataGridViewTextBoxColumn";
            this.dsMarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsMarcaDataGridViewTextBoxColumn.Width = 90;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.BS_CadMarca;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
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
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 267);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(586, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // TFCadMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(598, 365);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFCadMarca";
            this.Text = "Cadastro de Marcas";
            this.Load += new System.EventHandler(this.TFCadMarca_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadMarca;
        private Componentes.EditDefault Ds_Marca;
        private Componentes.EditDefault Cd_Marca;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdMarcaStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsMarcaDataGridViewTextBoxColumn;
    }
}
