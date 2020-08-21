namespace Faturamento.Cadastros
{
    partial class TFCadEmissorCF
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadEmissorCF));
            this.gEmissorCF = new Componentes.DataGridDefault(this.components);
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idequipamentostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_pdvstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrserieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porta_impressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_matricialbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_truncarbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsEmissorCF = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_equipamento = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_equipamento = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.nr_serie = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.tp_marca = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.portaimp = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bb_pdv = new System.Windows.Forms.Button();
            this.id_pdv = new Componentes.EditDefault(this.components);
            this.ds_pdv = new Componentes.EditDefault(this.components);
            this.st_portausb = new Componentes.CheckBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_modelo = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.st_registro = new Componentes.ComboBoxDefault(this.components);
            this.st_truncar = new Componentes.CheckBoxDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.tp_confdivida = new Componentes.ComboBoxDefault(this.components);
            this.st_calccooinifin = new Componentes.CheckBoxDefault(this.components);
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEmissorCF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmissorCF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portaimp)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_calccooinifin);
            this.pDados.Controls.Add(this.tp_confdivida);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.st_truncar);
            this.pDados.Controls.Add(this.st_registro);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_modelo);
            this.pDados.Controls.Add(this.st_portausb);
            this.pDados.Controls.Add(this.bb_pdv);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.id_pdv);
            this.pDados.Controls.Add(this.ds_pdv);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.portaimp);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.tp_marca);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.nr_serie);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_equipamento);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_equipamento);
            this.pDados.Size = new System.Drawing.Size(861, 182);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(873, 507);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gEmissorCF);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(865, 481);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gEmissorCF, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(59, 58);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(32, 13);
            cd_empresaLabel.TabIndex = 28;
            cd_empresaLabel.Text = "PDV:";
            // 
            // gEmissorCF
            // 
            this.gEmissorCF.AllowUserToAddRows = false;
            this.gEmissorCF.AllowUserToDeleteRows = false;
            this.gEmissorCF.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEmissorCF.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gEmissorCF.AutoGenerateColumns = false;
            this.gEmissorCF.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEmissorCF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEmissorCF.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEmissorCF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gEmissorCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEmissorCF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.idequipamentostrDataGridViewTextBoxColumn,
            this.dsequipamentoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Id_pdvstr,
            this.dataGridViewTextBoxColumn3,
            this.nrserieDataGridViewTextBoxColumn,
            this.tipomarcaDataGridViewTextBoxColumn,
            this.Porta_impressao,
            this.St_matricialbool,
            this.St_truncarbool});
            this.gEmissorCF.DataSource = this.bsEmissorCF;
            this.gEmissorCF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEmissorCF.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEmissorCF.Location = new System.Drawing.Point(0, 182);
            this.gEmissorCF.Name = "gEmissorCF";
            this.gEmissorCF.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEmissorCF.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gEmissorCF.RowHeadersWidth = 23;
            this.gEmissorCF.Size = new System.Drawing.Size(861, 270);
            this.gEmissorCF.TabIndex = 1;
            this.gEmissorCF.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEmissorCF_ColumnHeaderMouseClick);
            this.gEmissorCF.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gEmissorCF_CellFormatting);
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // idequipamentostrDataGridViewTextBoxColumn
            // 
            this.idequipamentostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idequipamentostrDataGridViewTextBoxColumn.DataPropertyName = "Id_equipamentostr";
            this.idequipamentostrDataGridViewTextBoxColumn.HeaderText = "Id. Equipamento";
            this.idequipamentostrDataGridViewTextBoxColumn.Name = "idequipamentostrDataGridViewTextBoxColumn";
            this.idequipamentostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsequipamentoDataGridViewTextBoxColumn
            // 
            this.dsequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Ds_equipamento";
            this.dsequipamentoDataGridViewTextBoxColumn.HeaderText = "Equipamento";
            this.dsequipamentoDataGridViewTextBoxColumn.Name = "dsequipamentoDataGridViewTextBoxColumn";
            this.dsequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsequipamentoDataGridViewTextBoxColumn.Width = 94;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_empresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Empresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nm_empresa";
            this.dataGridViewTextBoxColumn2.HeaderText = "Empresa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 73;
            // 
            // Id_pdvstr
            // 
            this.Id_pdvstr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_pdvstr.DataPropertyName = "Id_pdvstr";
            this.Id_pdvstr.HeaderText = "Id. PDV";
            this.Id_pdvstr.Name = "Id_pdvstr";
            this.Id_pdvstr.ReadOnly = true;
            this.Id_pdvstr.Width = 64;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ds_pdv";
            this.dataGridViewTextBoxColumn3.HeaderText = "Ponto Venda";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 87;
            // 
            // nrserieDataGridViewTextBoxColumn
            // 
            this.nrserieDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrserieDataGridViewTextBoxColumn.DataPropertyName = "Nr_serie";
            this.nrserieDataGridViewTextBoxColumn.HeaderText = "Nº Serie";
            this.nrserieDataGridViewTextBoxColumn.Name = "nrserieDataGridViewTextBoxColumn";
            this.nrserieDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrserieDataGridViewTextBoxColumn.Width = 66;
            // 
            // tipomarcaDataGridViewTextBoxColumn
            // 
            this.tipomarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipomarcaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_marca";
            this.tipomarcaDataGridViewTextBoxColumn.HeaderText = "Fabricante";
            this.tipomarcaDataGridViewTextBoxColumn.Name = "tipomarcaDataGridViewTextBoxColumn";
            this.tipomarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipomarcaDataGridViewTextBoxColumn.Width = 82;
            // 
            // Porta_impressao
            // 
            this.Porta_impressao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Porta_impressao.DataPropertyName = "Porta_impressao";
            this.Porta_impressao.HeaderText = "Porta Impressão";
            this.Porta_impressao.Name = "Porta_impressao";
            this.Porta_impressao.ReadOnly = true;
            this.Porta_impressao.Width = 99;
            // 
            // St_matricialbool
            // 
            this.St_matricialbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_matricialbool.DataPropertyName = "St_portausbbool";
            this.St_matricialbool.HeaderText = "Comunicação USB";
            this.St_matricialbool.Name = "St_matricialbool";
            this.St_matricialbool.ReadOnly = true;
            this.St_matricialbool.Width = 93;
            // 
            // St_truncarbool
            // 
            this.St_truncarbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_truncarbool.DataPropertyName = "St_truncarbool";
            this.St_truncarbool.HeaderText = "Truncar Valor";
            this.St_truncarbool.Name = "St_truncarbool";
            this.St_truncarbool.ReadOnly = true;
            this.St_truncarbool.Width = 69;
            // 
            // bsEmissorCF
            // 
            this.bsEmissorCF.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_EmissorCF);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsEmissorCF;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 452);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(861, 25);
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
            // id_equipamento
            // 
            this.id_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.id_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Id_equipamentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_equipamento.Enabled = false;
            this.id_equipamento.Location = new System.Drawing.Point(97, 3);
            this.id_equipamento.Name = "id_equipamento";
            this.id_equipamento.NM_Alias = "";
            this.id_equipamento.NM_Campo = "";
            this.id_equipamento.NM_CampoBusca = "";
            this.id_equipamento.NM_Param = "";
            this.id_equipamento.QTD_Zero = 0;
            this.id_equipamento.Size = new System.Drawing.Size(52, 20);
            this.id_equipamento.ST_AutoInc = false;
            this.id_equipamento.ST_DisableAuto = false;
            this.id_equipamento.ST_Float = false;
            this.id_equipamento.ST_Gravar = true;
            this.id_equipamento.ST_Int = true;
            this.id_equipamento.ST_LimpaCampo = true;
            this.id_equipamento.ST_NotNull = true;
            this.id_equipamento.ST_PrimaryKey = true;
            this.id_equipamento.TabIndex = 0;
            this.id_equipamento.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Equipamento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Equipamento:";
            // 
            // ds_equipamento
            // 
            this.ds_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Ds_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_equipamento.Enabled = false;
            this.ds_equipamento.Location = new System.Drawing.Point(97, 29);
            this.ds_equipamento.Name = "ds_equipamento";
            this.ds_equipamento.NM_Alias = "";
            this.ds_equipamento.NM_Campo = "";
            this.ds_equipamento.NM_CampoBusca = "";
            this.ds_equipamento.NM_Param = "";
            this.ds_equipamento.QTD_Zero = 0;
            this.ds_equipamento.Size = new System.Drawing.Size(554, 20);
            this.ds_equipamento.ST_AutoInc = false;
            this.ds_equipamento.ST_DisableAuto = false;
            this.ds_equipamento.ST_Float = false;
            this.ds_equipamento.ST_Gravar = true;
            this.ds_equipamento.ST_Int = false;
            this.ds_equipamento.ST_LimpaCampo = true;
            this.ds_equipamento.ST_NotNull = false;
            this.ds_equipamento.ST_PrimaryKey = false;
            this.ds_equipamento.TabIndex = 1;
            this.ds_equipamento.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nº Serie:";
            // 
            // nr_serie
            // 
            this.nr_serie.BackColor = System.Drawing.SystemColors.Window;
            this.nr_serie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_serie.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Nr_serie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_serie.Enabled = false;
            this.nr_serie.Location = new System.Drawing.Point(97, 81);
            this.nr_serie.Name = "nr_serie";
            this.nr_serie.NM_Alias = "";
            this.nr_serie.NM_Campo = "";
            this.nr_serie.NM_CampoBusca = "";
            this.nr_serie.NM_Param = "";
            this.nr_serie.QTD_Zero = 0;
            this.nr_serie.Size = new System.Drawing.Size(265, 20);
            this.nr_serie.ST_AutoInc = false;
            this.nr_serie.ST_DisableAuto = false;
            this.nr_serie.ST_Float = false;
            this.nr_serie.ST_Gravar = true;
            this.nr_serie.ST_Int = false;
            this.nr_serie.ST_LimpaCampo = true;
            this.nr_serie.ST_NotNull = true;
            this.nr_serie.ST_PrimaryKey = false;
            this.nr_serie.TabIndex = 6;
            this.nr_serie.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fabricante:";
            // 
            // tp_marca
            // 
            this.tp_marca.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEmissorCF, "Tp_marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_marca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_marca.Enabled = false;
            this.tp_marca.FormattingEnabled = true;
            this.tp_marca.Location = new System.Drawing.Point(434, 81);
            this.tp_marca.Name = "tp_marca";
            this.tp_marca.NM_Alias = "";
            this.tp_marca.NM_Campo = "";
            this.tp_marca.NM_Param = "";
            this.tp_marca.Size = new System.Drawing.Size(217, 21);
            this.tp_marca.ST_Gravar = true;
            this.tp_marca.ST_LimparCampo = true;
            this.tp_marca.ST_NotNull = true;
            this.tp_marca.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Porta Impressão:";
            // 
            // portaimp
            // 
            this.portaimp.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmissorCF, "PortaImp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.portaimp.Enabled = false;
            this.portaimp.Location = new System.Drawing.Point(125, 107);
            this.portaimp.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.portaimp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portaimp.Name = "portaimp";
            this.portaimp.NM_Alias = "";
            this.portaimp.NM_Campo = "";
            this.portaimp.NM_Param = "";
            this.portaimp.Operador = "";
            this.portaimp.Size = new System.Drawing.Size(41, 20);
            this.portaimp.ST_AutoInc = false;
            this.portaimp.ST_DisableAuto = false;
            this.portaimp.ST_Gravar = true;
            this.portaimp.ST_LimparCampo = true;
            this.portaimp.ST_NotNull = false;
            this.portaimp.ST_PrimaryKey = false;
            this.portaimp.TabIndex = 8;
            this.portaimp.ThousandsSeparator = true;
            this.portaimp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "COM";
            // 
            // bb_pdv
            // 
            this.bb_pdv.Enabled = false;
            this.bb_pdv.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_pdv.Image = ((System.Drawing.Image)(resources.GetObject("bb_pdv.Image")));
            this.bb_pdv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_pdv.Location = new System.Drawing.Point(157, 55);
            this.bb_pdv.Name = "bb_pdv";
            this.bb_pdv.Size = new System.Drawing.Size(30, 20);
            this.bb_pdv.TabIndex = 5;
            this.bb_pdv.UseVisualStyleBackColor = true;
            this.bb_pdv.Click += new System.EventHandler(this.bb_pdv_Click);
            // 
            // id_pdv
            // 
            this.id_pdv.BackColor = System.Drawing.SystemColors.Window;
            this.id_pdv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_pdv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_pdv.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Id_pdvstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_pdv.Enabled = false;
            this.id_pdv.Location = new System.Drawing.Point(97, 55);
            this.id_pdv.MaxLength = 4;
            this.id_pdv.Name = "id_pdv";
            this.id_pdv.NM_Alias = "";
            this.id_pdv.NM_Campo = "id_pdv";
            this.id_pdv.NM_CampoBusca = "id_pdv";
            this.id_pdv.NM_Param = "@P_CD_TERMINAL";
            this.id_pdv.QTD_Zero = 0;
            this.id_pdv.Size = new System.Drawing.Size(60, 20);
            this.id_pdv.ST_AutoInc = false;
            this.id_pdv.ST_DisableAuto = false;
            this.id_pdv.ST_Float = false;
            this.id_pdv.ST_Gravar = true;
            this.id_pdv.ST_Int = true;
            this.id_pdv.ST_LimpaCampo = true;
            this.id_pdv.ST_NotNull = true;
            this.id_pdv.ST_PrimaryKey = false;
            this.id_pdv.TabIndex = 4;
            this.id_pdv.TextOld = null;
            this.id_pdv.Leave += new System.EventHandler(this.id_pdv_Leave);
            // 
            // ds_pdv
            // 
            this.ds_pdv.BackColor = System.Drawing.SystemColors.Window;
            this.ds_pdv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_pdv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_pdv.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Ds_pdv", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_pdv.Enabled = false;
            this.ds_pdv.Location = new System.Drawing.Point(193, 55);
            this.ds_pdv.Name = "ds_pdv";
            this.ds_pdv.NM_Alias = "";
            this.ds_pdv.NM_Campo = "ds_pdv";
            this.ds_pdv.NM_CampoBusca = "ds_pdv";
            this.ds_pdv.NM_Param = "@P_NM_TERMINAL";
            this.ds_pdv.QTD_Zero = 0;
            this.ds_pdv.Size = new System.Drawing.Size(458, 20);
            this.ds_pdv.ST_AutoInc = false;
            this.ds_pdv.ST_DisableAuto = false;
            this.ds_pdv.ST_Float = false;
            this.ds_pdv.ST_Gravar = false;
            this.ds_pdv.ST_Int = false;
            this.ds_pdv.ST_LimpaCampo = true;
            this.ds_pdv.ST_NotNull = false;
            this.ds_pdv.ST_PrimaryKey = false;
            this.ds_pdv.TabIndex = 29;
            this.ds_pdv.TextOld = null;
            // 
            // st_portausb
            // 
            this.st_portausb.AutoSize = true;
            this.st_portausb.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEmissorCF, "St_portausbbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_portausb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_portausb.Location = new System.Drawing.Point(172, 110);
            this.st_portausb.Name = "st_portausb";
            this.st_portausb.NM_Alias = "";
            this.st_portausb.NM_Campo = "";
            this.st_portausb.NM_Param = "";
            this.st_portausb.Size = new System.Drawing.Size(131, 17);
            this.st_portausb.ST_Gravar = true;
            this.st_portausb.ST_LimparCampo = true;
            this.st_portausb.ST_NotNull = false;
            this.st_portausb.TabIndex = 9;
            this.st_portausb.Text = "Comunicação USB";
            this.st_portausb.UseVisualStyleBackColor = true;
            this.st_portausb.Vl_False = "";
            this.st_portausb.Vl_True = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Modelo:";
            // 
            // ds_modelo
            // 
            this.ds_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_modelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_modelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_modelo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmissorCF, "Ds_modelo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_modelo.Enabled = false;
            this.ds_modelo.Location = new System.Drawing.Point(496, 106);
            this.ds_modelo.Name = "ds_modelo";
            this.ds_modelo.NM_Alias = "";
            this.ds_modelo.NM_Campo = "";
            this.ds_modelo.NM_CampoBusca = "";
            this.ds_modelo.NM_Param = "";
            this.ds_modelo.QTD_Zero = 0;
            this.ds_modelo.Size = new System.Drawing.Size(155, 20);
            this.ds_modelo.ST_AutoInc = false;
            this.ds_modelo.ST_DisableAuto = false;
            this.ds_modelo.ST_Float = false;
            this.ds_modelo.ST_Gravar = true;
            this.ds_modelo.ST_Int = false;
            this.ds_modelo.ST_LimpaCampo = true;
            this.ds_modelo.ST_NotNull = false;
            this.ds_modelo.ST_PrimaryKey = false;
            this.ds_modelo.TabIndex = 10;
            this.ds_modelo.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Status:";
            // 
            // st_registro
            // 
            this.st_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEmissorCF, "St_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_registro.Enabled = false;
            this.st_registro.FormattingEnabled = true;
            this.st_registro.Location = new System.Drawing.Point(496, 132);
            this.st_registro.Name = "st_registro";
            this.st_registro.NM_Alias = "";
            this.st_registro.NM_Campo = "";
            this.st_registro.NM_Param = "";
            this.st_registro.Size = new System.Drawing.Size(155, 21);
            this.st_registro.ST_Gravar = true;
            this.st_registro.ST_LimparCampo = true;
            this.st_registro.ST_NotNull = false;
            this.st_registro.TabIndex = 11;
            // 
            // st_truncar
            // 
            this.st_truncar.AutoSize = true;
            this.st_truncar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEmissorCF, "St_truncarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_truncar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_truncar.Location = new System.Drawing.Point(325, 110);
            this.st_truncar.Name = "st_truncar";
            this.st_truncar.NM_Alias = "";
            this.st_truncar.NM_Campo = "";
            this.st_truncar.NM_Param = "";
            this.st_truncar.Size = new System.Drawing.Size(103, 17);
            this.st_truncar.ST_Gravar = true;
            this.st_truncar.ST_LimparCampo = true;
            this.st_truncar.ST_NotNull = false;
            this.st_truncar.TabIndex = 39;
            this.st_truncar.Text = "Truncar Valor";
            this.st_truncar.UseVisualStyleBackColor = true;
            this.st_truncar.Vl_False = "";
            this.st_truncar.Vl_True = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Conf. Divida:";
            // 
            // tp_confdivida
            // 
            this.tp_confdivida.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEmissorCF, "Tp_confdivida", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_confdivida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_confdivida.Enabled = false;
            this.tp_confdivida.FormattingEnabled = true;
            this.tp_confdivida.Location = new System.Drawing.Point(97, 132);
            this.tp_confdivida.Name = "tp_confdivida";
            this.tp_confdivida.NM_Alias = "";
            this.tp_confdivida.NM_Campo = "";
            this.tp_confdivida.NM_Param = "";
            this.tp_confdivida.Size = new System.Drawing.Size(265, 21);
            this.tp_confdivida.ST_Gravar = true;
            this.tp_confdivida.ST_LimparCampo = true;
            this.tp_confdivida.ST_NotNull = false;
            this.tp_confdivida.TabIndex = 41;
            // 
            // st_calccooinifin
            // 
            this.st_calccooinifin.AutoSize = true;
            this.st_calccooinifin.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEmissorCF, "St_calccooinifinbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_calccooinifin.Enabled = false;
            this.st_calccooinifin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_calccooinifin.Location = new System.Drawing.Point(97, 159);
            this.st_calccooinifin.Name = "st_calccooinifin";
            this.st_calccooinifin.NM_Alias = "";
            this.st_calccooinifin.NM_Campo = "";
            this.st_calccooinifin.NM_Param = "";
            this.st_calccooinifin.Size = new System.Drawing.Size(173, 17);
            this.st_calccooinifin.ST_Gravar = true;
            this.st_calccooinifin.ST_LimparCampo = true;
            this.st_calccooinifin.ST_NotNull = false;
            this.st_calccooinifin.TabIndex = 42;
            this.st_calccooinifin.Text = "Calcular COO Inicial/Final";
            this.st_calccooinifin.UseVisualStyleBackColor = true;
            this.st_calccooinifin.Vl_False = "";
            this.st_calccooinifin.Vl_True = "";
            // 
            // TFCadEmissorCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(873, 550);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadEmissorCF";
            this.Text = "Cadastro Emissor Cupom Fiscal - ECF";
            this.Load += new System.EventHandler(this.TFCadEmissorCF_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadEmissorCF_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEmissorCF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmissorCF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portaimp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gEmissorCF;
        private System.Windows.Forms.BindingSource bsEmissorCF;
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
        private Componentes.EditDefault ds_equipamento;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_equipamento;
        private Componentes.ComboBoxDefault tp_marca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_serie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat portaimp;
        private System.Windows.Forms.Button bb_pdv;
        private Componentes.EditDefault id_pdv;
        private Componentes.EditDefault ds_pdv;
        private Componentes.CheckBoxDefault st_portausb;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_modelo;
        private Componentes.ComboBoxDefault st_registro;
        private System.Windows.Forms.Label label9;
        private Componentes.CheckBoxDefault st_truncar;
        private System.Windows.Forms.Label label10;
        private Componentes.ComboBoxDefault tp_confdivida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn idequipamentostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_pdvstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrserieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porta_impressao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_matricialbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_truncarbool;
        private Componentes.CheckBoxDefault st_calccooinifin;
    }
}
