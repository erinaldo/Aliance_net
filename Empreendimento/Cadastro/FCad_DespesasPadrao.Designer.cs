namespace Empreendimento.Cadastro
{
    partial class TFCad_DespesasPadrao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_DespesasPadrao));
            this.gDespesa = new Componentes.DataGridDefault(this.components);
            this.iddespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDs_unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla_unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCadDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.cd_unidade = new Componentes.EditDefault(this.components);
            this.bbUnidade = new System.Windows.Forms.Button();
            this.sg_unidade = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.sg_unidade);
            this.pDados.Controls.Add(this.ds_unidade);
            this.pDados.Controls.Add(this.cd_unidade);
            this.pDados.Controls.Add(this.bbUnidade);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_despesa);
            this.pDados.Controls.Add(this.id_despesa);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(659, 84);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gDespesa);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gDespesa, 0);
            // 
            // gDespesa
            // 
            this.gDespesa.AllowUserToAddRows = false;
            this.gDespesa.AllowUserToDeleteRows = false;
            this.gDespesa.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gDespesa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gDespesa.AutoGenerateColumns = false;
            this.gDespesa.BackgroundColor = System.Drawing.Color.LightGray;
            this.gDespesa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gDespesa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDespesa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gDespesa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gDespesa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddespesaDataGridViewTextBoxColumn,
            this.dsdespesaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.cDs_unidade,
            this.Sigla_unidade});
            this.gDespesa.DataSource = this.bsCadDespesa;
            this.gDespesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gDespesa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gDespesa.Location = new System.Drawing.Point(0, 84);
            this.gDespesa.Name = "gDespesa";
            this.gDespesa.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDespesa.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gDespesa.RowHeadersWidth = 23;
            this.gDespesa.Size = new System.Drawing.Size(659, 251);
            this.gDespesa.TabIndex = 1;
            // 
            // iddespesaDataGridViewTextBoxColumn
            // 
            this.iddespesaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iddespesaDataGridViewTextBoxColumn.DataPropertyName = "Id_despesa";
            this.iddespesaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.iddespesaDataGridViewTextBoxColumn.Name = "iddespesaDataGridViewTextBoxColumn";
            this.iddespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddespesaDataGridViewTextBoxColumn.Width = 65;
            // 
            // dsdespesaDataGridViewTextBoxColumn
            // 
            this.dsdespesaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsdespesaDataGridViewTextBoxColumn.DataPropertyName = "Ds_despesa";
            this.dsdespesaDataGridViewTextBoxColumn.HeaderText = "Despesa";
            this.dsdespesaDataGridViewTextBoxColumn.Name = "dsdespesaDataGridViewTextBoxColumn";
            this.dsdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsdespesaDataGridViewTextBoxColumn.Width = 74;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_unidade";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Unidade";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 91;
            // 
            // cDs_unidade
            // 
            this.cDs_unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDs_unidade.DataPropertyName = "Ds_unidade";
            this.cDs_unidade.HeaderText = "Unidade";
            this.cDs_unidade.Name = "cDs_unidade";
            this.cDs_unidade.ReadOnly = true;
            this.cDs_unidade.Width = 72;
            // 
            // Sigla_unidade
            // 
            this.Sigla_unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sigla_unidade.DataPropertyName = "Sigla_unidade";
            this.Sigla_unidade.HeaderText = "UND";
            this.Sigla_unidade.Name = "Sigla_unidade";
            this.Sigla_unidade.ReadOnly = true;
            this.Sigla_unidade.Width = 56;
            // 
            // bsCadDespesa
            // 
            this.bsCadDespesa.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadDespesa);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Despesa:";
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Enabled = false;
            this.id_despesa.Location = new System.Drawing.Point(69, 3);
            this.id_despesa.Name = "id_despesa";
            this.id_despesa.NM_Alias = "";
            this.id_despesa.NM_Campo = "id_depesa";
            this.id_despesa.NM_CampoBusca = "id_despesa";
            this.id_despesa.NM_Param = "@P_ID_DEPESA";
            this.id_despesa.QTD_Zero = 0;
            this.id_despesa.Size = new System.Drawing.Size(68, 20);
            this.id_despesa.ST_AutoInc = false;
            this.id_despesa.ST_DisableAuto = false;
            this.id_despesa.ST_Float = false;
            this.id_despesa.ST_Gravar = true;
            this.id_despesa.ST_Int = false;
            this.id_despesa.ST_LimpaCampo = true;
            this.id_despesa.ST_NotNull = true;
            this.id_despesa.ST_PrimaryKey = true;
            this.id_despesa.TabIndex = 2;
            this.id_despesa.TextOld = null;
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(69, 29);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_DS_DESPESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(582, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = true;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = true;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 3;
            this.ds_despesa.TextOld = null;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCadDespesa;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unidade:";
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Ds_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidade.Enabled = false;
            this.ds_unidade.Location = new System.Drawing.Point(149, 55);
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "";
            this.ds_unidade.NM_Campo = "ds_unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_NM_EMPRESA";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.Size = new System.Drawing.Size(467, 20);
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TabIndex = 32;
            this.ds_unidade.TextOld = null;
            // 
            // cd_unidade
            // 
            this.cd_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Cd_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidade.Enabled = false;
            this.cd_unidade.Location = new System.Drawing.Point(69, 55);
            this.cd_unidade.Name = "cd_unidade";
            this.cd_unidade.NM_Alias = "";
            this.cd_unidade.NM_Campo = "cd_unidade";
            this.cd_unidade.NM_CampoBusca = "cd_unidade";
            this.cd_unidade.NM_Param = "@P_DS_PDV";
            this.cd_unidade.QTD_Zero = 0;
            this.cd_unidade.Size = new System.Drawing.Size(45, 20);
            this.cd_unidade.ST_AutoInc = false;
            this.cd_unidade.ST_DisableAuto = false;
            this.cd_unidade.ST_Float = false;
            this.cd_unidade.ST_Gravar = true;
            this.cd_unidade.ST_Int = false;
            this.cd_unidade.ST_LimpaCampo = true;
            this.cd_unidade.ST_NotNull = true;
            this.cd_unidade.ST_PrimaryKey = false;
            this.cd_unidade.TabIndex = 30;
            this.cd_unidade.TextOld = null;
            this.cd_unidade.Leave += new System.EventHandler(this.cd_unidade_Leave);
            // 
            // bbUnidade
            // 
            this.bbUnidade.Enabled = false;
            this.bbUnidade.Image = ((System.Drawing.Image)(resources.GetObject("bbUnidade.Image")));
            this.bbUnidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbUnidade.Location = new System.Drawing.Point(115, 55);
            this.bbUnidade.Name = "bbUnidade";
            this.bbUnidade.Size = new System.Drawing.Size(28, 20);
            this.bbUnidade.TabIndex = 31;
            this.bbUnidade.UseVisualStyleBackColor = true;
            this.bbUnidade.Click += new System.EventHandler(this.bbUnidade_Click);
            // 
            // sg_unidade
            // 
            this.sg_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sg_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sg_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sg_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadDespesa, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sg_unidade.Enabled = false;
            this.sg_unidade.Location = new System.Drawing.Point(622, 55);
            this.sg_unidade.Name = "sg_unidade";
            this.sg_unidade.NM_Alias = "";
            this.sg_unidade.NM_Campo = "sigla_unidade";
            this.sg_unidade.NM_CampoBusca = "sigla_unidade";
            this.sg_unidade.NM_Param = "@P_NM_EMPRESA";
            this.sg_unidade.QTD_Zero = 0;
            this.sg_unidade.Size = new System.Drawing.Size(29, 20);
            this.sg_unidade.ST_AutoInc = false;
            this.sg_unidade.ST_DisableAuto = false;
            this.sg_unidade.ST_Float = false;
            this.sg_unidade.ST_Gravar = false;
            this.sg_unidade.ST_Int = false;
            this.sg_unidade.ST_LimpaCampo = true;
            this.sg_unidade.ST_NotNull = false;
            this.sg_unidade.ST_PrimaryKey = false;
            this.sg_unidade.TabIndex = 33;
            this.sg_unidade.TextOld = null;
            // 
            // TFCad_DespesasPadrao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_DespesasPadrao";
            this.Text = "Cadastro Despesas Padrão";
            this.Load += new System.EventHandler(this.TFCad_DespesasPadrao_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gDespesa;
        private System.Windows.Forms.BindingSource bsCadDespesa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_despesa;
        private Componentes.EditDefault id_despesa;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault sg_unidade;
        private Componentes.EditDefault ds_unidade;
        private Componentes.EditDefault cd_unidade;
        private System.Windows.Forms.Button bbUnidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDs_unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla_unidade;
    }
}
