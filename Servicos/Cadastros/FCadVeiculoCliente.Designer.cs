namespace Servicos.Cadastros
{
    partial class TFCadVeiculoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadVeiculoCliente));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placaveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsveiculoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anofabricDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVeiculoCliente = new System.Windows.Forms.BindingSource(this.components);
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
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ds_marca = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.anofabric = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.st_registro = new Componentes.CheckBoxDefault(this.components);
            this.placaveiculo = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.bb_Clifor = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculoCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anofabric)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.bb_Clifor);
            this.pDados.Controls.Add(this.label);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.placaveiculo);
            this.pDados.Controls.Add(this.st_registro);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.anofabric);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_marca);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(765, 154);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(777, 469);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(769, 443);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
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
            this.Status,
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.placaveiculoDataGridViewTextBoxColumn,
            this.dsveiculoDataGridViewTextBoxColumn,
            this.dsmarcaDataGridViewTextBoxColumn,
            this.anofabricDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsVeiculoCliente;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 154);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(765, 260);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Ativo";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 37;
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Cd. Cliente";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcliforDataGridViewTextBoxColumn.Width = 83;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 64;
            // 
            // placaveiculoDataGridViewTextBoxColumn
            // 
            this.placaveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.placaveiculoDataGridViewTextBoxColumn.DataPropertyName = "Placaveiculo";
            this.placaveiculoDataGridViewTextBoxColumn.HeaderText = "Placa Veiculo";
            this.placaveiculoDataGridViewTextBoxColumn.Name = "placaveiculoDataGridViewTextBoxColumn";
            this.placaveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.placaveiculoDataGridViewTextBoxColumn.Width = 97;
            // 
            // dsveiculoDataGridViewTextBoxColumn
            // 
            this.dsveiculoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsveiculoDataGridViewTextBoxColumn.DataPropertyName = "Ds_veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.HeaderText = "Veiculo";
            this.dsveiculoDataGridViewTextBoxColumn.Name = "dsveiculoDataGridViewTextBoxColumn";
            this.dsveiculoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsveiculoDataGridViewTextBoxColumn.Width = 67;
            // 
            // dsmarcaDataGridViewTextBoxColumn
            // 
            this.dsmarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmarcaDataGridViewTextBoxColumn.DataPropertyName = "Ds_marca";
            this.dsmarcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.dsmarcaDataGridViewTextBoxColumn.Name = "dsmarcaDataGridViewTextBoxColumn";
            this.dsmarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmarcaDataGridViewTextBoxColumn.Width = 62;
            // 
            // anofabricDataGridViewTextBoxColumn
            // 
            this.anofabricDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.anofabricDataGridViewTextBoxColumn.DataPropertyName = "Anofabric";
            this.anofabricDataGridViewTextBoxColumn.HeaderText = "Ano Fabricação";
            this.anofabricDataGridViewTextBoxColumn.Name = "anofabricDataGridViewTextBoxColumn";
            this.anofabricDataGridViewTextBoxColumn.ReadOnly = true;
            this.anofabricDataGridViewTextBoxColumn.Width = 98;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            this.dsobservacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobservacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsVeiculoCliente
            // 
            this.bsVeiculoCliente.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_VeiculoCliente);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsVeiculoCliente;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 414);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(765, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 256;
            this.label1.Text = "Placa:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(241, 6);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "";
            this.ds_veiculo.NM_CampoBusca = "";
            this.ds_veiculo.NM_Param = "";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(269, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = true;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 3;
            this.ds_veiculo.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(161, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 258;
            this.label2.Text = "Veiculo/Moto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 259;
            this.label3.Text = "Marca:";
            // 
            // ds_marca
            // 
            this.ds_marca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_marca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Ds_marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_marca.Enabled = false;
            this.ds_marca.Location = new System.Drawing.Point(52, 58);
            this.ds_marca.Name = "ds_marca";
            this.ds_marca.NM_Alias = "";
            this.ds_marca.NM_Campo = "";
            this.ds_marca.NM_CampoBusca = "";
            this.ds_marca.NM_Param = "";
            this.ds_marca.QTD_Zero = 0;
            this.ds_marca.Size = new System.Drawing.Size(183, 20);
            this.ds_marca.ST_AutoInc = false;
            this.ds_marca.ST_DisableAuto = false;
            this.ds_marca.ST_Float = false;
            this.ds_marca.ST_Gravar = true;
            this.ds_marca.ST_Int = false;
            this.ds_marca.ST_LimpaCampo = true;
            this.ds_marca.ST_NotNull = false;
            this.ds_marca.ST_PrimaryKey = false;
            this.ds_marca.TabIndex = 4;
            this.ds_marca.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(241, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 261;
            this.label4.Text = "Ano Fabricação:";
            // 
            // anofabric
            // 
            this.anofabric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsVeiculoCliente, "Anofabric", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.anofabric.Enabled = false;
            this.anofabric.Location = new System.Drawing.Point(332, 58);
            this.anofabric.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.anofabric.Name = "anofabric";
            this.anofabric.NM_Alias = "";
            this.anofabric.NM_Campo = "";
            this.anofabric.NM_Param = "";
            this.anofabric.Operador = "";
            this.anofabric.Size = new System.Drawing.Size(91, 20);
            this.anofabric.ST_AutoInc = false;
            this.anofabric.ST_DisableAuto = false;
            this.anofabric.ST_Gravar = true;
            this.anofabric.ST_LimparCampo = true;
            this.anofabric.ST_NotNull = false;
            this.anofabric.ST_PrimaryKey = false;
            this.anofabric.TabIndex = 5;
            this.anofabric.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(14, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 263;
            this.label5.Text = "Obs.:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Enabled = false;
            this.ds_observacao.Location = new System.Drawing.Point(52, 84);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(458, 62);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 7;
            this.ds_observacao.TextOld = null;
            // 
            // st_registro
            // 
            this.st_registro.AutoSize = true;
            this.st_registro.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsVeiculoCliente, "Status", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_registro.Enabled = false;
            this.st_registro.Location = new System.Drawing.Point(460, 60);
            this.st_registro.Name = "st_registro";
            this.st_registro.NM_Alias = "";
            this.st_registro.NM_Campo = "";
            this.st_registro.NM_Param = "";
            this.st_registro.Size = new System.Drawing.Size(50, 17);
            this.st_registro.ST_Gravar = true;
            this.st_registro.ST_LimparCampo = true;
            this.st_registro.ST_NotNull = false;
            this.st_registro.TabIndex = 6;
            this.st_registro.Text = "Ativo";
            this.st_registro.UseVisualStyleBackColor = true;
            this.st_registro.Vl_False = "";
            this.st_registro.Vl_True = "";
            // 
            // placaveiculo
            // 
            this.placaveiculo.BackColor = System.Drawing.SystemColors.Window;
            this.placaveiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placaveiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placaveiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Placaveiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placaveiculo.Enabled = false;
            this.placaveiculo.Location = new System.Drawing.Point(52, 6);
            this.placaveiculo.Name = "placaveiculo";
            this.placaveiculo.NM_Alias = "";
            this.placaveiculo.NM_Campo = "";
            this.placaveiculo.NM_CampoBusca = "";
            this.placaveiculo.NM_Param = "";
            this.placaveiculo.QTD_Zero = 0;
            this.placaveiculo.Size = new System.Drawing.Size(103, 20);
            this.placaveiculo.ST_AutoInc = false;
            this.placaveiculo.ST_DisableAuto = false;
            this.placaveiculo.ST_Float = false;
            this.placaveiculo.ST_Gravar = true;
            this.placaveiculo.ST_Int = false;
            this.placaveiculo.ST_LimpaCampo = true;
            this.placaveiculo.ST_NotNull = true;
            this.placaveiculo.ST_PrimaryKey = true;
            this.placaveiculo.TabIndex = 2;
            this.placaveiculo.TextOld = null;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Location = new System.Drawing.Point(160, 32);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_CLIFOR";
            this.NM_Clifor.NM_CampoBusca = "NM_CLIFOR";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(350, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 267;
            this.NM_Clifor.TextOld = null;
            // 
            // bb_Clifor
            // 
            this.bb_Clifor.Enabled = false;
            this.bb_Clifor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_Clifor.Image")));
            this.bb_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Clifor.Location = new System.Drawing.Point(124, 33);
            this.bb_Clifor.Name = "bb_Clifor";
            this.bb_Clifor.Size = new System.Drawing.Size(30, 19);
            this.bb_Clifor.TabIndex = 265;
            this.bb_Clifor.UseVisualStyleBackColor = true;
            this.bb_Clifor.Click += new System.EventHandler(this.bb_Clifor_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label.Location = new System.Drawing.Point(9, 32);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(42, 13);
            this.label.TabIndex = 266;
            this.label.Text = "Cliente:";
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsVeiculoCliente, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Enabled = false;
            this.CD_Clifor.Location = new System.Drawing.Point(52, 32);
            this.CD_Clifor.MaxLength = 10;
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "a";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(69, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 264;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // TFCadVeiculoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(777, 512);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadVeiculoCliente";
            this.Text = "Cadastro Veiculo Cliente";
            this.Load += new System.EventHandler(this.TFCadVeiculoCliente_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadVeiculoCliente_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVeiculoCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anofabric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bsVeiculoCliente;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placaveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsveiculoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anofabricDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
        private Componentes.EditFloat anofabric;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_marca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault st_registro;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault placaveiculo;
        private Componentes.EditDefault NM_Clifor;
        public System.Windows.Forms.Button bb_Clifor;
        private System.Windows.Forms.Label label;
        public Componentes.EditDefault CD_Clifor;
    }
}
