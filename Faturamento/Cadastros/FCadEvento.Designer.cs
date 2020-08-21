namespace Faturamento.Cadastros
{
    partial class TFCadEvento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadEvento));
            this.gEvento = new Componentes.DataGridDefault(this.components);
            this.cdeventoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dseventoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoeventoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEvento = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_evento = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_evento = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tp_evento = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEvento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_evento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_evento);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_evento);
            this.pDados.Size = new System.Drawing.Size(616, 85);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(628, 387);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gEvento);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(620, 361);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gEvento, 0);
            // 
            // gEvento
            // 
            this.gEvento.AllowUserToAddRows = false;
            this.gEvento.AllowUserToDeleteRows = false;
            this.gEvento.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEvento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gEvento.AutoGenerateColumns = false;
            this.gEvento.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEvento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEvento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEvento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gEvento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEvento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdeventoDataGridViewTextBoxColumn,
            this.dseventoDataGridViewTextBoxColumn,
            this.tipoeventoDataGridViewTextBoxColumn});
            this.gEvento.DataSource = this.bsEvento;
            this.gEvento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEvento.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEvento.Location = new System.Drawing.Point(0, 85);
            this.gEvento.Name = "gEvento";
            this.gEvento.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEvento.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gEvento.RowHeadersWidth = 23;
            this.gEvento.Size = new System.Drawing.Size(616, 247);
            this.gEvento.TabIndex = 1;
            this.gEvento.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEvento_ColumnHeaderMouseClick);
            // 
            // cdeventoDataGridViewTextBoxColumn
            // 
            this.cdeventoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdeventoDataGridViewTextBoxColumn.DataPropertyName = "Cd_evento";
            this.cdeventoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.cdeventoDataGridViewTextBoxColumn.Name = "cdeventoDataGridViewTextBoxColumn";
            this.cdeventoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdeventoDataGridViewTextBoxColumn.Width = 65;
            // 
            // dseventoDataGridViewTextBoxColumn
            // 
            this.dseventoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dseventoDataGridViewTextBoxColumn.DataPropertyName = "Ds_evento";
            this.dseventoDataGridViewTextBoxColumn.HeaderText = "Evento";
            this.dseventoDataGridViewTextBoxColumn.Name = "dseventoDataGridViewTextBoxColumn";
            this.dseventoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dseventoDataGridViewTextBoxColumn.Width = 66;
            // 
            // tipoeventoDataGridViewTextBoxColumn
            // 
            this.tipoeventoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipoeventoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_evento";
            this.tipoeventoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoeventoDataGridViewTextBoxColumn.Name = "tipoeventoDataGridViewTextBoxColumn";
            this.tipoeventoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoeventoDataGridViewTextBoxColumn.Width = 53;
            // 
            // bsEvento
            // 
            this.bsEvento.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_Evento);
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 332);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(616, 25);
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
            // cd_evento
            // 
            this.cd_evento.BackColor = System.Drawing.SystemColors.Window;
            this.cd_evento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_evento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_evento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Cd_eventostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_evento.Enabled = false;
            this.cd_evento.Location = new System.Drawing.Point(57, 6);
            this.cd_evento.Name = "cd_evento";
            this.cd_evento.NM_Alias = "";
            this.cd_evento.NM_Campo = "";
            this.cd_evento.NM_CampoBusca = "";
            this.cd_evento.NM_Param = "";
            this.cd_evento.QTD_Zero = 0;
            this.cd_evento.Size = new System.Drawing.Size(100, 20);
            this.cd_evento.ST_AutoInc = false;
            this.cd_evento.ST_DisableAuto = false;
            this.cd_evento.ST_Float = false;
            this.cd_evento.ST_Gravar = true;
            this.cd_evento.ST_Int = true;
            this.cd_evento.ST_LimpaCampo = true;
            this.cd_evento.ST_NotNull = true;
            this.cd_evento.ST_PrimaryKey = true;
            this.cd_evento.TabIndex = 0;
            this.cd_evento.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // ds_evento
            // 
            this.ds_evento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_evento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_evento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEvento, "Ds_evento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_evento.Enabled = false;
            this.ds_evento.Location = new System.Drawing.Point(57, 32);
            this.ds_evento.Name = "ds_evento";
            this.ds_evento.NM_Alias = "";
            this.ds_evento.NM_Campo = "";
            this.ds_evento.NM_CampoBusca = "";
            this.ds_evento.NM_Param = "";
            this.ds_evento.QTD_Zero = 0;
            this.ds_evento.Size = new System.Drawing.Size(553, 20);
            this.ds_evento.ST_AutoInc = false;
            this.ds_evento.ST_DisableAuto = false;
            this.ds_evento.ST_Float = false;
            this.ds_evento.ST_Gravar = true;
            this.ds_evento.ST_Int = false;
            this.ds_evento.ST_LimpaCampo = true;
            this.ds_evento.ST_NotNull = true;
            this.ds_evento.ST_PrimaryKey = false;
            this.ds_evento.TabIndex = 1;
            this.ds_evento.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Evento:";
            // 
            // tp_evento
            // 
            this.tp_evento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEvento, "Tp_evento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_evento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_evento.Enabled = false;
            this.tp_evento.FormattingEnabled = true;
            this.tp_evento.Location = new System.Drawing.Point(57, 58);
            this.tp_evento.Name = "tp_evento";
            this.tp_evento.NM_Alias = "";
            this.tp_evento.NM_Campo = "";
            this.tp_evento.NM_Param = "";
            this.tp_evento.Size = new System.Drawing.Size(203, 21);
            this.tp_evento.ST_Gravar = true;
            this.tp_evento.ST_LimparCampo = true;
            this.tp_evento.ST_NotNull = true;
            this.tp_evento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo:";
            // 
            // TFCadEvento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(628, 430);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadEvento";
            this.Text = "Cadastro Evento NFe";
            this.Load += new System.EventHandler(this.TFCadEvento_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEvento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gEvento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdeventoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dseventoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoeventoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsEvento;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault cd_evento;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_evento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_evento;
        private System.Windows.Forms.Label label1;
    }
}
