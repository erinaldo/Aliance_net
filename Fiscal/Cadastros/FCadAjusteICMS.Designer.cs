namespace Fiscal.Cadastros
{
    partial class TFCadAjusteICMS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadAjusteICMS));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdajusteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsajusteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAjusteICMS = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_ajuste = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_ajuste = new Componentes.EditDefault(this.components);
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bb_imposto = new System.Windows.Forms.Button();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAjusteICMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_ajuste);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_ajuste);
            this.pDados.Size = new System.Drawing.Size(659, 111);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdajusteDataGridViewTextBoxColumn,
            this.dsajusteDataGridViewTextBoxColumn,
            this.Cd_impostostr,
            this.dataGridViewTextBoxColumn1});
            this.dataGridDefault1.DataSource = this.bsAjusteICMS;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 111);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 224);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdajusteDataGridViewTextBoxColumn
            // 
            this.cdajusteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdajusteDataGridViewTextBoxColumn.DataPropertyName = "Cd_ajuste";
            this.cdajusteDataGridViewTextBoxColumn.HeaderText = "Cd. Ajuste";
            this.cdajusteDataGridViewTextBoxColumn.Name = "cdajusteDataGridViewTextBoxColumn";
            this.cdajusteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdajusteDataGridViewTextBoxColumn.Width = 80;
            // 
            // dsajusteDataGridViewTextBoxColumn
            // 
            this.dsajusteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsajusteDataGridViewTextBoxColumn.DataPropertyName = "Ds_ajuste";
            this.dsajusteDataGridViewTextBoxColumn.HeaderText = "Descrição Ajuste";
            this.dsajusteDataGridViewTextBoxColumn.Name = "dsajusteDataGridViewTextBoxColumn";
            this.dsajusteDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsajusteDataGridViewTextBoxColumn.Width = 103;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            this.Cd_impostostr.HeaderText = "Cd. Imposto";
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            this.Cd_impostostr.Width = 81;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_imposto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Imposto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // bsAjusteICMS
            // 
            this.bsAjusteICMS.DataSource = typeof(CamadaDados.Fiscal.TList_AjusteICMS);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsAjusteICMS;
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total  Registros";
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
            this.bindingNavigatorPositionItem.ToolTipText = "Registro  Corrente";
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
            // cd_ajuste
            // 
            this.cd_ajuste.BackColor = System.Drawing.SystemColors.Window;
            this.cd_ajuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ajuste.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteICMS, "Cd_ajuste", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ajuste.Enabled = false;
            this.cd_ajuste.Location = new System.Drawing.Point(68, 4);
            this.cd_ajuste.MaxLength = 8;
            this.cd_ajuste.Name = "cd_ajuste";
            this.cd_ajuste.NM_Alias = "";
            this.cd_ajuste.NM_Campo = "";
            this.cd_ajuste.NM_CampoBusca = "";
            this.cd_ajuste.NM_Param = "";
            this.cd_ajuste.QTD_Zero = 0;
            this.cd_ajuste.Size = new System.Drawing.Size(113, 20);
            this.cd_ajuste.ST_AutoInc = false;
            this.cd_ajuste.ST_DisableAuto = false;
            this.cd_ajuste.ST_Float = false;
            this.cd_ajuste.ST_Gravar = true;
            this.cd_ajuste.ST_Int = false;
            this.cd_ajuste.ST_LimpaCampo = true;
            this.cd_ajuste.ST_NotNull = true;
            this.cd_ajuste.ST_PrimaryKey = true;
            this.cd_ajuste.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cd. Ajuste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ajuste:";
            // 
            // ds_ajuste
            // 
            this.ds_ajuste.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ajuste.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ajuste.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteICMS, "Ds_ajuste", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ajuste.Enabled = false;
            this.ds_ajuste.Location = new System.Drawing.Point(68, 30);
            this.ds_ajuste.MaxLength = 255;
            this.ds_ajuste.Multiline = true;
            this.ds_ajuste.Name = "ds_ajuste";
            this.ds_ajuste.NM_Alias = "";
            this.ds_ajuste.NM_Campo = "";
            this.ds_ajuste.NM_CampoBusca = "";
            this.ds_ajuste.NM_Param = "";
            this.ds_ajuste.QTD_Zero = 0;
            this.ds_ajuste.Size = new System.Drawing.Size(583, 47);
            this.ds_ajuste.ST_AutoInc = false;
            this.ds_ajuste.ST_DisableAuto = false;
            this.ds_ajuste.ST_Float = false;
            this.ds_ajuste.ST_Gravar = true;
            this.ds_ajuste.ST_Int = false;
            this.ds_ajuste.ST_LimpaCampo = true;
            this.ds_ajuste.ST_NotNull = true;
            this.ds_ajuste.ST_PrimaryKey = false;
            this.ds_ajuste.TabIndex = 1;
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteICMS, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(178, 83);
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_NM_EMPRESA";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.Size = new System.Drawing.Size(473, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 148;
            // 
            // bb_imposto
            // 
            this.bb_imposto.Enabled = false;
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(142, 83);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 20);
            this.bb_imposto.TabIndex = 3;
            this.bb_imposto.UseVisualStyleBackColor = true;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteICMS, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_imposto.Enabled = false;
            this.cd_imposto.Location = new System.Drawing.Point(68, 83);
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_EMPRESA";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.Size = new System.Drawing.Size(73, 20);
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = false;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = false;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = false;
            this.cd_imposto.TabIndex = 2;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Imposto:";
            // 
            // TFCadAjusteICMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadAjusteICMS";
            this.Text = "Cadastro Tabela Ajuste ICMS";
            this.Load += new System.EventHandler(this.TFCadAjusteICMS_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadAjusteICMS_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAjusteICMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_ajuste;
        private System.Windows.Forms.BindingSource bsAjusteICMS;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_ajuste;
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
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Button bb_imposto;
        private Componentes.EditDefault cd_imposto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdajusteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsajusteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
