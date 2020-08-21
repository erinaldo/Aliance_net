namespace Balanca.Cadastros
{
    partial class TFCadTpDesdobroEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpDesdobroEspecial));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gTpDesdobro = new Componentes.DataGridDefault(this.components);
            this.bsTpDesdobroEspecial = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.id_tpdesdobro = new Componentes.EditDefault(this.components);
            this.ds_tpdesdobro = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pc_desdobro = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_pesodesdobro = new Componentes.ComboBoxDefault(this.components);
            this.idtpdesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcdesdobroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_pesodesdobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpDesdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpDesdobroEspecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_pesodesdobro);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.pc_desdobro);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_tpdesdobro);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.id_tpdesdobro);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(781, 88);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(793, 386);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gTpDesdobro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(785, 360);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTpDesdobro, 0);
            // 
            // gTpDesdobro
            // 
            this.gTpDesdobro.AllowUserToAddRows = false;
            this.gTpDesdobro.AllowUserToDeleteRows = false;
            this.gTpDesdobro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTpDesdobro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTpDesdobro.AutoGenerateColumns = false;
            this.gTpDesdobro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTpDesdobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTpDesdobro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpDesdobro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTpDesdobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTpDesdobro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtpdesdobroDataGridViewTextBoxColumn,
            this.dstpdesdobroDataGridViewTextBoxColumn,
            this.pcdesdobroDataGridViewTextBoxColumn,
            this.Tipo_pesodesdobro});
            this.gTpDesdobro.DataSource = this.bsTpDesdobroEspecial;
            this.gTpDesdobro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTpDesdobro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTpDesdobro.Location = new System.Drawing.Point(0, 88);
            this.gTpDesdobro.Name = "gTpDesdobro";
            this.gTpDesdobro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpDesdobro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gTpDesdobro.RowHeadersWidth = 23;
            this.gTpDesdobro.Size = new System.Drawing.Size(781, 243);
            this.gTpDesdobro.TabIndex = 1;
            this.gTpDesdobro.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTpDesdobro_ColumnHeaderMouseClick);
            // 
            // bsTpDesdobroEspecial
            // 
            this.bsTpDesdobroEspecial.DataSource = typeof(CamadaDados.Balanca.Cadastros.TList_TpDesdobroEspecial);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTpDesdobroEspecial;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 331);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(781, 25);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TP. Desdobro:";
            // 
            // id_tpdesdobro
            // 
            this.id_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpdesdobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpDesdobroEspecial, "Id_tpdesdobrostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tpdesdobro.Enabled = false;
            this.id_tpdesdobro.Location = new System.Drawing.Point(90, 6);
            this.id_tpdesdobro.Name = "id_tpdesdobro";
            this.id_tpdesdobro.NM_Alias = "";
            this.id_tpdesdobro.NM_Campo = "id_tpdesdobro";
            this.id_tpdesdobro.NM_CampoBusca = "id_tpdesdobro";
            this.id_tpdesdobro.NM_Param = "@P_ID_TPDESDOBRO";
            this.id_tpdesdobro.QTD_Zero = 0;
            this.id_tpdesdobro.Size = new System.Drawing.Size(100, 20);
            this.id_tpdesdobro.ST_AutoInc = false;
            this.id_tpdesdobro.ST_DisableAuto = false;
            this.id_tpdesdobro.ST_Float = false;
            this.id_tpdesdobro.ST_Gravar = true;
            this.id_tpdesdobro.ST_Int = true;
            this.id_tpdesdobro.ST_LimpaCampo = true;
            this.id_tpdesdobro.ST_NotNull = true;
            this.id_tpdesdobro.ST_PrimaryKey = true;
            this.id_tpdesdobro.TabIndex = 0;
            this.id_tpdesdobro.TextOld = null;
            // 
            // ds_tpdesdobro
            // 
            this.ds_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdesdobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpDesdobroEspecial, "Ds_tpdesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdesdobro.Enabled = false;
            this.ds_tpdesdobro.Location = new System.Drawing.Point(90, 32);
            this.ds_tpdesdobro.Name = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Alias = "";
            this.ds_tpdesdobro.NM_Campo = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_CampoBusca = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Param = "@P_ID_TPDESDOBRO";
            this.ds_tpdesdobro.QTD_Zero = 0;
            this.ds_tpdesdobro.Size = new System.Drawing.Size(501, 20);
            this.ds_tpdesdobro.ST_AutoInc = false;
            this.ds_tpdesdobro.ST_DisableAuto = false;
            this.ds_tpdesdobro.ST_Float = false;
            this.ds_tpdesdobro.ST_Gravar = true;
            this.ds_tpdesdobro.ST_Int = false;
            this.ds_tpdesdobro.ST_LimpaCampo = true;
            this.ds_tpdesdobro.ST_NotNull = true;
            this.ds_tpdesdobro.ST_PrimaryKey = false;
            this.ds_tpdesdobro.TabIndex = 1;
            this.ds_tpdesdobro.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo Desdobro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "% Desdobro:";
            // 
            // pc_desdobro
            // 
            this.pc_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTpDesdobroEspecial, "Pc_desdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_desdobro.DecimalPlaces = 2;
            this.pc_desdobro.Enabled = false;
            this.pc_desdobro.Location = new System.Drawing.Point(90, 58);
            this.pc_desdobro.Name = "pc_desdobro";
            this.pc_desdobro.NM_Alias = "";
            this.pc_desdobro.NM_Campo = "pc_desdobro";
            this.pc_desdobro.NM_Param = "";
            this.pc_desdobro.Operador = "";
            this.pc_desdobro.Size = new System.Drawing.Size(103, 20);
            this.pc_desdobro.ST_AutoInc = false;
            this.pc_desdobro.ST_DisableAuto = false;
            this.pc_desdobro.ST_Gravar = true;
            this.pc_desdobro.ST_LimparCampo = true;
            this.pc_desdobro.ST_NotNull = false;
            this.pc_desdobro.ST_PrimaryKey = false;
            this.pc_desdobro.TabIndex = 4;
            this.pc_desdobro.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Aplicar desdobro sobre:";
            // 
            // tp_pesodesdobro
            // 
            this.tp_pesodesdobro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTpDesdobroEspecial, "Tp_pesodesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_pesodesdobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_pesodesdobro.Enabled = false;
            this.tp_pesodesdobro.FormattingEnabled = true;
            this.tp_pesodesdobro.Location = new System.Drawing.Point(323, 58);
            this.tp_pesodesdobro.Name = "tp_pesodesdobro";
            this.tp_pesodesdobro.NM_Alias = "";
            this.tp_pesodesdobro.NM_Campo = "";
            this.tp_pesodesdobro.NM_Param = "";
            this.tp_pesodesdobro.Size = new System.Drawing.Size(268, 21);
            this.tp_pesodesdobro.ST_Gravar = true;
            this.tp_pesodesdobro.ST_LimparCampo = true;
            this.tp_pesodesdobro.ST_NotNull = true;
            this.tp_pesodesdobro.TabIndex = 10;
            // 
            // idtpdesdobroDataGridViewTextBoxColumn
            // 
            this.idtpdesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpdesdobroDataGridViewTextBoxColumn.DataPropertyName = "Id_tpdesdobro";
            this.idtpdesdobroDataGridViewTextBoxColumn.HeaderText = "TP. Desdobro";
            this.idtpdesdobroDataGridViewTextBoxColumn.Name = "idtpdesdobroDataGridViewTextBoxColumn";
            this.idtpdesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtpdesdobroDataGridViewTextBoxColumn.Width = 98;
            // 
            // dstpdesdobroDataGridViewTextBoxColumn
            // 
            this.dstpdesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpdesdobroDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpdesdobro";
            this.dstpdesdobroDataGridViewTextBoxColumn.HeaderText = "Tipo Desdobro";
            this.dstpdesdobroDataGridViewTextBoxColumn.Name = "dstpdesdobroDataGridViewTextBoxColumn";
            this.dstpdesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpdesdobroDataGridViewTextBoxColumn.Width = 102;
            // 
            // pcdesdobroDataGridViewTextBoxColumn
            // 
            this.pcdesdobroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcdesdobroDataGridViewTextBoxColumn.DataPropertyName = "Pc_desdobro";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.pcdesdobroDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pcdesdobroDataGridViewTextBoxColumn.HeaderText = "% Desdobro";
            this.pcdesdobroDataGridViewTextBoxColumn.Name = "pcdesdobroDataGridViewTextBoxColumn";
            this.pcdesdobroDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcdesdobroDataGridViewTextBoxColumn.Width = 89;
            // 
            // Tipo_pesodesdobro
            // 
            this.Tipo_pesodesdobro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_pesodesdobro.DataPropertyName = "Tipo_pesodesdobro";
            this.Tipo_pesodesdobro.HeaderText = "Aplicar desdobro sobre";
            this.Tipo_pesodesdobro.Name = "Tipo_pesodesdobro";
            this.Tipo_pesodesdobro.ReadOnly = true;
            this.Tipo_pesodesdobro.Width = 105;
            // 
            // TFCadTpDesdobroEspecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(793, 429);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTpDesdobroEspecial";
            this.Text = "Cadastro Tipo Desdobro Especial";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpDesdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpDesdobroEspecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gTpDesdobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocalcpesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipolandesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsTpDesdobroEspecial;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault id_tpdesdobro;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_tpdesdobro;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat pc_desdobro;
        private System.Windows.Forms.Label label5;
        private Componentes.ComboBoxDefault tp_pesodesdobro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpdesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcdesdobroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_pesodesdobro;
    }
}
