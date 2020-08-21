namespace Locacao.Cadastros
{
    partial class TFCadTabPreco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTabPreco));
            this.ds_tabpreco = new Componentes.EditDefault(this.components);
            this.bsTabPreco = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tp_tabpreco = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.gTabPreco = new Componentes.DataGridDefault(this.components);
            this.idtabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipotabelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BN_CadTabPreco = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_organizar = new System.Windows.Forms.ToolStripButton();
            this.cbxCancelado = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTabPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gTabPreco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTabPreco)).BeginInit();
            this.BN_CadTabPreco.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cbxCancelado);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.tp_tabpreco);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_tabpreco);
            this.pDados.Size = new System.Drawing.Size(648, 70);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(660, 407);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.BN_CadTabPreco);
            this.tpPadrao.Controls.Add(this.gTabPreco);
            this.tpPadrao.Size = new System.Drawing.Size(652, 381);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTabPreco, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadTabPreco, 0);
            // 
            // ds_tabpreco
            // 
            this.ds_tabpreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabpreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabpreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabpreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTabPreco, "Ds_tabela", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabpreco.Enabled = false;
            this.ds_tabpreco.Location = new System.Drawing.Point(108, 14);
            this.ds_tabpreco.Name = "ds_tabpreco";
            this.ds_tabpreco.NM_Alias = "";
            this.ds_tabpreco.NM_Campo = "";
            this.ds_tabpreco.NM_CampoBusca = "";
            this.ds_tabpreco.NM_Param = "";
            this.ds_tabpreco.QTD_Zero = 0;
            this.ds_tabpreco.Size = new System.Drawing.Size(466, 20);
            this.ds_tabpreco.ST_AutoInc = false;
            this.ds_tabpreco.ST_DisableAuto = false;
            this.ds_tabpreco.ST_Float = false;
            this.ds_tabpreco.ST_Gravar = true;
            this.ds_tabpreco.ST_Int = false;
            this.ds_tabpreco.ST_LimpaCampo = true;
            this.ds_tabpreco.ST_NotNull = true;
            this.ds_tabpreco.ST_PrimaryKey = false;
            this.ds_tabpreco.TabIndex = 0;
            this.ds_tabpreco.TextOld = null;
            // 
            // bsTabPreco
            // 
            this.bsTabPreco.DataSource = typeof(CamadaDados.Locacao.Cadastros.TList_CadTabPreco);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabela Preço:";
            // 
            // tp_tabpreco
            // 
            this.tp_tabpreco.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTabPreco, "Tp_tabela", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_tabpreco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_tabpreco.Enabled = false;
            this.tp_tabpreco.FormattingEnabled = true;
            this.tp_tabpreco.Location = new System.Drawing.Point(108, 40);
            this.tp_tabpreco.Name = "tp_tabpreco";
            this.tp_tabpreco.NM_Alias = "";
            this.tp_tabpreco.NM_Campo = "";
            this.tp_tabpreco.NM_Param = "";
            this.tp_tabpreco.Size = new System.Drawing.Size(183, 21);
            this.tp_tabpreco.ST_Gravar = true;
            this.tp_tabpreco.ST_LimparCampo = true;
            this.tp_tabpreco.ST_NotNull = true;
            this.tp_tabpreco.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipo Tabela:";
            // 
            // gTabPreco
            // 
            this.gTabPreco.AllowUserToAddRows = false;
            this.gTabPreco.AllowUserToDeleteRows = false;
            this.gTabPreco.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTabPreco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gTabPreco.AutoGenerateColumns = false;
            this.gTabPreco.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTabPreco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTabPreco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTabPreco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gTabPreco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTabPreco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtabelaDataGridViewTextBoxColumn,
            this.dstabelaDataGridViewTextBoxColumn,
            this.tipotabelaDataGridViewTextBoxColumn});
            this.gTabPreco.DataSource = this.bsTabPreco;
            this.gTabPreco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTabPreco.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTabPreco.Location = new System.Drawing.Point(0, 70);
            this.gTabPreco.Name = "gTabPreco";
            this.gTabPreco.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTabPreco.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gTabPreco.RowHeadersWidth = 23;
            this.gTabPreco.Size = new System.Drawing.Size(648, 307);
            this.gTabPreco.TabIndex = 1;
            // 
            // idtabelaDataGridViewTextBoxColumn
            // 
            this.idtabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtabelaDataGridViewTextBoxColumn.DataPropertyName = "Id_tabela";
            this.idtabelaDataGridViewTextBoxColumn.HeaderText = "Id.Tabela Preço";
            this.idtabelaDataGridViewTextBoxColumn.Name = "idtabelaDataGridViewTextBoxColumn";
            this.idtabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtabelaDataGridViewTextBoxColumn.Width = 99;
            // 
            // dstabelaDataGridViewTextBoxColumn
            // 
            this.dstabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstabelaDataGridViewTextBoxColumn.DataPropertyName = "Ds_tabela";
            this.dstabelaDataGridViewTextBoxColumn.HeaderText = "Tabela Preço";
            this.dstabelaDataGridViewTextBoxColumn.Name = "dstabelaDataGridViewTextBoxColumn";
            this.dstabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstabelaDataGridViewTextBoxColumn.Width = 88;
            // 
            // tipotabelaDataGridViewTextBoxColumn
            // 
            this.tipotabelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipotabelaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_tabela";
            this.tipotabelaDataGridViewTextBoxColumn.HeaderText = "Tipo Tabela Preço";
            this.tipotabelaDataGridViewTextBoxColumn.Name = "tipotabelaDataGridViewTextBoxColumn";
            this.tipotabelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipotabelaDataGridViewTextBoxColumn.Width = 110;
            // 
            // BN_CadTabPreco
            // 
            this.BN_CadTabPreco.AddNewItem = null;
            this.BN_CadTabPreco.BindingSource = this.bsTabPreco;
            this.BN_CadTabPreco.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadTabPreco.DeleteItem = null;
            this.BN_CadTabPreco.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadTabPreco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bb_organizar});
            this.BN_CadTabPreco.Location = new System.Drawing.Point(0, 352);
            this.BN_CadTabPreco.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadTabPreco.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadTabPreco.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadTabPreco.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadTabPreco.Name = "BN_CadTabPreco";
            this.BN_CadTabPreco.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadTabPreco.Size = new System.Drawing.Size(648, 25);
            this.BN_CadTabPreco.TabIndex = 4;
            this.BN_CadTabPreco.Text = "bindingNavigator1";
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
            // bb_organizar
            // 
            this.bb_organizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_organizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_organizar.ForeColor = System.Drawing.Color.Blue;
            this.bb_organizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_organizar.Name = "bb_organizar";
            this.bb_organizar.Size = new System.Drawing.Size(23, 22);
            // 
            // cbxCancelado
            // 
            this.cbxCancelado.AutoSize = true;
            this.cbxCancelado.Enabled = false;
            this.cbxCancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCancelado.ForeColor = System.Drawing.Color.Red;
            this.cbxCancelado.Location = new System.Drawing.Point(466, 42);
            this.cbxCancelado.Name = "cbxCancelado";
            this.cbxCancelado.NM_Alias = "";
            this.cbxCancelado.NM_Campo = "";
            this.cbxCancelado.NM_Param = "";
            this.cbxCancelado.Size = new System.Drawing.Size(108, 17);
            this.cbxCancelado.ST_Gravar = true;
            this.cbxCancelado.ST_LimparCampo = true;
            this.cbxCancelado.ST_NotNull = false;
            this.cbxCancelado.TabIndex = 4;
            this.cbxCancelado.Text = "CANCELADOS";
            this.cbxCancelado.UseVisualStyleBackColor = true;
            this.cbxCancelado.Vl_False = "";
            this.cbxCancelado.Vl_True = "";
            // 
            // TFCadTabPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTabPreco";
            this.Text = "Cadastro de Tabela Preço";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTabPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gTabPreco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTabPreco)).EndInit();
            this.BN_CadTabPreco.ResumeLayout(false);
            this.BN_CadTabPreco.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_tabpreco;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault tp_tabpreco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsTabPreco;
        private Componentes.DataGridDefault gTabPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipotabelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator BN_CadTabPreco;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bb_organizar;
        private Componentes.CheckBoxDefault cbxCancelado;
    }
}