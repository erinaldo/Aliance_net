namespace Fiscal.Cadastros
{
    partial class TFCadAjusteIPI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadAjusteIPI));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdajusteIPIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_natureza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsajusteIPIDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAjusteIPI = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_ajusteipi = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_ajusteipi = new Componentes.EditDefault(this.components);
            this.tp_natureza = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_finalidade = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bb_imposto = new System.Windows.Forms.Button();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAjusteIPI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.ds_finalidade);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_natureza);
            this.pDados.Controls.Add(this.ds_ajusteipi);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_ajusteipi);
            this.pDados.Size = new System.Drawing.Size(659, 176);
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
            this.cdajusteIPIDataGridViewTextBoxColumn,
            this.Tipo_natureza,
            this.Cd_impostostr,
            this.dataGridViewTextBoxColumn1,
            this.dsajusteIPIDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2});
            this.dataGridDefault1.DataSource = this.bsAjusteIPI;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 176);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 159);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdajusteIPIDataGridViewTextBoxColumn
            // 
            this.cdajusteIPIDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdajusteIPIDataGridViewTextBoxColumn.DataPropertyName = "Cd_ajusteIPI";
            this.cdajusteIPIDataGridViewTextBoxColumn.HeaderText = "Cd. Ajuste";
            this.cdajusteIPIDataGridViewTextBoxColumn.Name = "cdajusteIPIDataGridViewTextBoxColumn";
            this.cdajusteIPIDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdajusteIPIDataGridViewTextBoxColumn.Width = 80;
            // 
            // Tipo_natureza
            // 
            this.Tipo_natureza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_natureza.DataPropertyName = "Tipo_natureza";
            this.Tipo_natureza.HeaderText = "Natureza";
            this.Tipo_natureza.Name = "Tipo_natureza";
            this.Tipo_natureza.ReadOnly = true;
            this.Tipo_natureza.Width = 75;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            this.Cd_impostostr.HeaderText = "Cd. Imposto";
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            this.Cd_impostostr.Width = 88;
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
            // dsajusteIPIDataGridViewTextBoxColumn
            // 
            this.dsajusteIPIDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsajusteIPIDataGridViewTextBoxColumn.DataPropertyName = "Ds_ajusteIPI";
            this.dsajusteIPIDataGridViewTextBoxColumn.HeaderText = "Ajuste IPI";
            this.dsajusteIPIDataGridViewTextBoxColumn.Name = "dsajusteIPIDataGridViewTextBoxColumn";
            this.dsajusteIPIDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsajusteIPIDataGridViewTextBoxColumn.Width = 77;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_finalidade";
            this.dataGridViewTextBoxColumn2.HeaderText = "Finalidade";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // bsAjusteIPI
            // 
            this.bsAjusteIPI.DataSource = typeof(CamadaDados.Fiscal.TList_AjusteIPI);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsAjusteIPI;
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
            // cd_ajusteipi
            // 
            this.cd_ajusteipi.BackColor = System.Drawing.SystemColors.Window;
            this.cd_ajusteipi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ajusteipi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteIPI, "Cd_ajusteIPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ajusteipi.Enabled = false;
            this.cd_ajusteipi.Location = new System.Drawing.Point(68, 4);
            this.cd_ajusteipi.Name = "cd_ajusteipi";
            this.cd_ajusteipi.NM_Alias = "";
            this.cd_ajusteipi.NM_Campo = "";
            this.cd_ajusteipi.NM_CampoBusca = "";
            this.cd_ajusteipi.NM_Param = "";
            this.cd_ajusteipi.QTD_Zero = 0;
            this.cd_ajusteipi.Size = new System.Drawing.Size(100, 20);
            this.cd_ajusteipi.ST_AutoInc = false;
            this.cd_ajusteipi.ST_DisableAuto = false;
            this.cd_ajusteipi.ST_Float = false;
            this.cd_ajusteipi.ST_Gravar = true;
            this.cd_ajusteipi.ST_Int = false;
            this.cd_ajusteipi.ST_LimpaCampo = true;
            this.cd_ajusteipi.ST_NotNull = true;
            this.cd_ajusteipi.ST_PrimaryKey = true;
            this.cd_ajusteipi.TabIndex = 0;
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
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ajuste IPI:";
            // 
            // ds_ajusteipi
            // 
            this.ds_ajusteipi.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ajusteipi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ajusteipi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteIPI, "Ds_ajusteIPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ajusteipi.Enabled = false;
            this.ds_ajusteipi.Location = new System.Drawing.Point(68, 30);
            this.ds_ajusteipi.Multiline = true;
            this.ds_ajusteipi.Name = "ds_ajusteipi";
            this.ds_ajusteipi.NM_Alias = "";
            this.ds_ajusteipi.NM_Campo = "";
            this.ds_ajusteipi.NM_CampoBusca = "";
            this.ds_ajusteipi.NM_Param = "";
            this.ds_ajusteipi.QTD_Zero = 0;
            this.ds_ajusteipi.Size = new System.Drawing.Size(583, 38);
            this.ds_ajusteipi.ST_AutoInc = false;
            this.ds_ajusteipi.ST_DisableAuto = false;
            this.ds_ajusteipi.ST_Float = false;
            this.ds_ajusteipi.ST_Gravar = true;
            this.ds_ajusteipi.ST_Int = false;
            this.ds_ajusteipi.ST_LimpaCampo = true;
            this.ds_ajusteipi.ST_NotNull = true;
            this.ds_ajusteipi.ST_PrimaryKey = false;
            this.ds_ajusteipi.TabIndex = 1;
            // 
            // tp_natureza
            // 
            this.tp_natureza.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsAjusteIPI, "Tp_natureza", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_natureza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_natureza.Enabled = false;
            this.tp_natureza.FormattingEnabled = true;
            this.tp_natureza.Location = new System.Drawing.Point(68, 74);
            this.tp_natureza.Name = "tp_natureza";
            this.tp_natureza.NM_Alias = "";
            this.tp_natureza.NM_Campo = "";
            this.tp_natureza.NM_Param = "";
            this.tp_natureza.Size = new System.Drawing.Size(149, 21);
            this.tp_natureza.ST_Gravar = true;
            this.tp_natureza.ST_LimparCampo = true;
            this.tp_natureza.ST_NotNull = true;
            this.tp_natureza.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Natureza:";
            // 
            // ds_finalidade
            // 
            this.ds_finalidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_finalidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_finalidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteIPI, "Ds_finalidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_finalidade.Enabled = false;
            this.ds_finalidade.Location = new System.Drawing.Point(68, 101);
            this.ds_finalidade.Multiline = true;
            this.ds_finalidade.Name = "ds_finalidade";
            this.ds_finalidade.NM_Alias = "";
            this.ds_finalidade.NM_Campo = "";
            this.ds_finalidade.NM_CampoBusca = "";
            this.ds_finalidade.NM_Param = "";
            this.ds_finalidade.QTD_Zero = 0;
            this.ds_finalidade.Size = new System.Drawing.Size(583, 38);
            this.ds_finalidade.ST_AutoInc = false;
            this.ds_finalidade.ST_DisableAuto = false;
            this.ds_finalidade.ST_Float = false;
            this.ds_finalidade.ST_Gravar = true;
            this.ds_finalidade.ST_Int = false;
            this.ds_finalidade.ST_LimpaCampo = true;
            this.ds_finalidade.ST_NotNull = true;
            this.ds_finalidade.ST_PrimaryKey = false;
            this.ds_finalidade.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Finalidade:";
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteIPI, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(178, 145);
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
            this.ds_imposto.TabIndex = 152;
            // 
            // bb_imposto
            // 
            this.bb_imposto.Enabled = false;
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(142, 145);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 20);
            this.bb_imposto.TabIndex = 5;
            this.bb_imposto.UseVisualStyleBackColor = true;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAjusteIPI, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_imposto.Enabled = false;
            this.cd_imposto.Location = new System.Drawing.Point(68, 145);
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
            this.cd_imposto.TabIndex = 4;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(15, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "Imposto:";
            // 
            // TFCadAjusteIPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadAjusteIPI";
            this.Text = "Cadastro Ajuste IPI";
            this.Load += new System.EventHandler(this.TFCadAjusteIPI_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadAjusteIPI_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAjusteIPI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.EditDefault ds_ajusteipi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_ajusteipi;
        private System.Windows.Forms.BindingSource bsAjusteIPI;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_finalidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_natureza;
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Button bb_imposto;
        private Componentes.EditDefault cd_imposto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdajusteIPIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_natureza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsajusteIPIDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
