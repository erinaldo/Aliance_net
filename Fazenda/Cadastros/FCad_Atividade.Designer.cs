namespace Fazenda.Cadastros
{
    partial class TFCad_Atividade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Atividade));
            this.gAtividade = new Componentes.DataGridDefault(this.components);
            this.idatividadestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsatividadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAtividade = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_atividade = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_atividade = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAtividade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_atividade);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_atividade);
            this.pDados.Size = new System.Drawing.Size(659, 60);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gAtividade);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gAtividade, 0);
            // 
            // gAtividade
            // 
            this.gAtividade.AllowUserToAddRows = false;
            this.gAtividade.AllowUserToDeleteRows = false;
            this.gAtividade.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAtividade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gAtividade.AutoGenerateColumns = false;
            this.gAtividade.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAtividade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAtividade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAtividade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gAtividade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAtividade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idatividadestrDataGridViewTextBoxColumn,
            this.dsatividadeDataGridViewTextBoxColumn});
            this.gAtividade.DataSource = this.bsAtividade;
            this.gAtividade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAtividade.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAtividade.Location = new System.Drawing.Point(0, 60);
            this.gAtividade.Name = "gAtividade";
            this.gAtividade.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAtividade.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gAtividade.RowHeadersWidth = 23;
            this.gAtividade.Size = new System.Drawing.Size(659, 275);
            this.gAtividade.TabIndex = 1;
            // 
            // idatividadestrDataGridViewTextBoxColumn
            // 
            this.idatividadestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idatividadestrDataGridViewTextBoxColumn.DataPropertyName = "Id_atividadestr";
            this.idatividadestrDataGridViewTextBoxColumn.HeaderText = "Id. Atividade";
            this.idatividadestrDataGridViewTextBoxColumn.Name = "idatividadestrDataGridViewTextBoxColumn";
            this.idatividadestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idatividadestrDataGridViewTextBoxColumn.Width = 91;
            // 
            // dsatividadeDataGridViewTextBoxColumn
            // 
            this.dsatividadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsatividadeDataGridViewTextBoxColumn.DataPropertyName = "Ds_atividade";
            this.dsatividadeDataGridViewTextBoxColumn.HeaderText = "Atividade";
            this.dsatividadeDataGridViewTextBoxColumn.Name = "dsatividadeDataGridViewTextBoxColumn";
            this.dsatividadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsatividadeDataGridViewTextBoxColumn.Width = 76;
            // 
            // bsAtividade
            // 
            this.bsAtividade.DataSource = typeof(CamadaDados.Fazenda.Cadastros.TList_Atividade);
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
            // id_atividade
            // 
            this.id_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.id_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Id_atividadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_atividade.Enabled = false;
            this.id_atividade.Location = new System.Drawing.Point(79, 5);
            this.id_atividade.Name = "id_atividade";
            this.id_atividade.NM_Alias = "";
            this.id_atividade.NM_Campo = "id_atividade";
            this.id_atividade.NM_CampoBusca = "id_atividade";
            this.id_atividade.NM_Param = "@P_ID_ATIVIDADE";
            this.id_atividade.QTD_Zero = 0;
            this.id_atividade.Size = new System.Drawing.Size(100, 20);
            this.id_atividade.ST_AutoInc = false;
            this.id_atividade.ST_DisableAuto = true;
            this.id_atividade.ST_Float = false;
            this.id_atividade.ST_Gravar = true;
            this.id_atividade.ST_Int = true;
            this.id_atividade.ST_LimpaCampo = true;
            this.id_atividade.ST_NotNull = true;
            this.id_atividade.ST_PrimaryKey = true;
            this.id_atividade.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Atividade:";
            // 
            // ds_atividade
            // 
            this.ds_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_atividade.Enabled = false;
            this.ds_atividade.Location = new System.Drawing.Point(79, 31);
            this.ds_atividade.Name = "ds_atividade";
            this.ds_atividade.NM_Alias = "";
            this.ds_atividade.NM_Campo = "ds_atividade";
            this.ds_atividade.NM_CampoBusca = "ds_atividade";
            this.ds_atividade.NM_Param = "@P_DS_ATIVIDADE";
            this.ds_atividade.QTD_Zero = 0;
            this.ds_atividade.Size = new System.Drawing.Size(572, 20);
            this.ds_atividade.ST_AutoInc = false;
            this.ds_atividade.ST_DisableAuto = false;
            this.ds_atividade.ST_Float = false;
            this.ds_atividade.ST_Gravar = true;
            this.ds_atividade.ST_Int = false;
            this.ds_atividade.ST_LimpaCampo = true;
            this.ds_atividade.ST_NotNull = true;
            this.ds_atividade.ST_PrimaryKey = false;
            this.ds_atividade.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Atividade:";
            // 
            // TFCad_Atividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_Atividade";
            this.Text = "Cadastro Atividades";
            this.Load += new System.EventHandler(this.TFCad_Atividade_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAtividade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gAtividade;
        private System.Windows.Forms.DataGridViewTextBoxColumn idatividadestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsatividadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsAtividade;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_atividade;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_atividade;
    }
}
