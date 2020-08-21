namespace Parametros.Diversos
{
    partial class TFCadCargoFuncionario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCargoFuncionario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCargoFuncionario = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_cargo = new Componentes.EditDefault(this.components);
            this.st_vendedor = new Componentes.CheckBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_cargo = new Componentes.EditDefault(this.components);
            this.st_tecnico = new Componentes.CheckBoxDefault(this.components);
            this.st_motorista = new Componentes.CheckBoxDefault(this.components);
            this.st_frentista = new Componentes.CheckBoxDefault(this.components);
            this.st_operadorcx = new Componentes.CheckBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.vl_basesalario = new Componentes.EditFloat(this.components);
            this.CargaHorariaMes = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.st_gervenda = new Componentes.CheckBoxDefault(this.components);
            this.idcargostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargahorarioMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stvendedorboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_tecnicobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_motoristabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Frentista = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_operadorcxbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_gervendabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargoFuncionario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basesalario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargaHorariaMes)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_gervenda);
            this.pDados.Controls.Add(this.CargaHorariaMes);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vl_basesalario);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.st_operadorcx);
            this.pDados.Controls.Add(this.st_frentista);
            this.pDados.Controls.Add(this.st_motorista);
            this.pDados.Controls.Add(this.st_tecnico);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_cargo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.st_vendedor);
            this.pDados.Controls.Add(this.id_cargo);
            this.pDados.Size = new System.Drawing.Size(659, 105);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
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
            this.idcargostrDataGridViewTextBoxColumn,
            this.dscargoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.CargahorarioMes,
            this.stvendedorboolDataGridViewCheckBoxColumn,
            this.St_tecnicobool,
            this.St_motoristabool,
            this.Frentista,
            this.St_operadorcxbool,
            this.St_gervendabool});
            this.dataGridDefault1.DataSource = this.bsCargoFuncionario;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDefault1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 105);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 230);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsCargoFuncionario
            // 
            this.bsCargoFuncionario.DataSource = typeof(CamadaDados.Diversos.TList_CargoFuncionario);
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
            // id_cargo
            // 
            this.id_cargo.BackColor = System.Drawing.SystemColors.Window;
            this.id_cargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_cargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_cargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCargoFuncionario, "Id_cargostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_cargo.Enabled = false;
            this.id_cargo.Location = new System.Drawing.Point(63, 4);
            this.id_cargo.Name = "id_cargo";
            this.id_cargo.NM_Alias = "";
            this.id_cargo.NM_Campo = "";
            this.id_cargo.NM_CampoBusca = "";
            this.id_cargo.NM_Param = "";
            this.id_cargo.QTD_Zero = 0;
            this.id_cargo.Size = new System.Drawing.Size(69, 20);
            this.id_cargo.ST_AutoInc = false;
            this.id_cargo.ST_DisableAuto = true;
            this.id_cargo.ST_Float = false;
            this.id_cargo.ST_Gravar = true;
            this.id_cargo.ST_Int = true;
            this.id_cargo.ST_LimpaCampo = true;
            this.id_cargo.ST_NotNull = true;
            this.id_cargo.ST_PrimaryKey = true;
            this.id_cargo.TabIndex = 0;
            this.id_cargo.TextOld = null;
            // 
            // st_vendedor
            // 
            this.st_vendedor.AutoSize = true;
            this.st_vendedor.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_vendedorbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_vendedor.Enabled = false;
            this.st_vendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_vendedor.Location = new System.Drawing.Point(63, 82);
            this.st_vendedor.Name = "st_vendedor";
            this.st_vendedor.NM_Alias = "";
            this.st_vendedor.NM_Campo = "";
            this.st_vendedor.NM_Param = "";
            this.st_vendedor.Size = new System.Drawing.Size(80, 17);
            this.st_vendedor.ST_Gravar = true;
            this.st_vendedor.ST_LimparCampo = true;
            this.st_vendedor.ST_NotNull = false;
            this.st_vendedor.TabIndex = 4;
            this.st_vendedor.Text = "Vendedor";
            this.st_vendedor.UseVisualStyleBackColor = true;
            this.st_vendedor.Vl_False = "";
            this.st_vendedor.Vl_True = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id. Cargo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cargo:";
            // 
            // ds_cargo
            // 
            this.ds_cargo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCargoFuncionario, "Ds_cargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cargo.Enabled = false;
            this.ds_cargo.Location = new System.Drawing.Point(63, 30);
            this.ds_cargo.Name = "ds_cargo";
            this.ds_cargo.NM_Alias = "";
            this.ds_cargo.NM_Campo = "";
            this.ds_cargo.NM_CampoBusca = "";
            this.ds_cargo.NM_Param = "";
            this.ds_cargo.QTD_Zero = 0;
            this.ds_cargo.Size = new System.Drawing.Size(588, 20);
            this.ds_cargo.ST_AutoInc = false;
            this.ds_cargo.ST_DisableAuto = false;
            this.ds_cargo.ST_Float = false;
            this.ds_cargo.ST_Gravar = true;
            this.ds_cargo.ST_Int = false;
            this.ds_cargo.ST_LimpaCampo = true;
            this.ds_cargo.ST_NotNull = true;
            this.ds_cargo.ST_PrimaryKey = false;
            this.ds_cargo.TabIndex = 1;
            this.ds_cargo.TextOld = null;
            // 
            // st_tecnico
            // 
            this.st_tecnico.AutoSize = true;
            this.st_tecnico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_tecnicobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_tecnico.Enabled = false;
            this.st_tecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_tecnico.Location = new System.Drawing.Point(149, 82);
            this.st_tecnico.Name = "st_tecnico";
            this.st_tecnico.NM_Alias = "";
            this.st_tecnico.NM_Campo = "";
            this.st_tecnico.NM_Param = "";
            this.st_tecnico.Size = new System.Drawing.Size(72, 17);
            this.st_tecnico.ST_Gravar = true;
            this.st_tecnico.ST_LimparCampo = true;
            this.st_tecnico.ST_NotNull = false;
            this.st_tecnico.TabIndex = 5;
            this.st_tecnico.Text = "Tecnico";
            this.st_tecnico.UseVisualStyleBackColor = true;
            this.st_tecnico.Vl_False = "";
            this.st_tecnico.Vl_True = "";
            // 
            // st_motorista
            // 
            this.st_motorista.AutoSize = true;
            this.st_motorista.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_motoristabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_motorista.Enabled = false;
            this.st_motorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_motorista.Location = new System.Drawing.Point(227, 82);
            this.st_motorista.Name = "st_motorista";
            this.st_motorista.NM_Alias = "";
            this.st_motorista.NM_Campo = "";
            this.st_motorista.NM_Param = "";
            this.st_motorista.Size = new System.Drawing.Size(78, 17);
            this.st_motorista.ST_Gravar = true;
            this.st_motorista.ST_LimparCampo = true;
            this.st_motorista.ST_NotNull = false;
            this.st_motorista.TabIndex = 6;
            this.st_motorista.Text = "Motorista";
            this.st_motorista.UseVisualStyleBackColor = true;
            this.st_motorista.Vl_False = "";
            this.st_motorista.Vl_True = "";
            // 
            // st_frentista
            // 
            this.st_frentista.AutoSize = true;
            this.st_frentista.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_frentistabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_frentista.Enabled = false;
            this.st_frentista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_frentista.Location = new System.Drawing.Point(311, 82);
            this.st_frentista.Name = "st_frentista";
            this.st_frentista.NM_Alias = "";
            this.st_frentista.NM_Campo = "";
            this.st_frentista.NM_Param = "";
            this.st_frentista.Size = new System.Drawing.Size(75, 17);
            this.st_frentista.ST_Gravar = true;
            this.st_frentista.ST_LimparCampo = true;
            this.st_frentista.ST_NotNull = false;
            this.st_frentista.TabIndex = 7;
            this.st_frentista.Text = "Frentista";
            this.st_frentista.UseVisualStyleBackColor = true;
            this.st_frentista.Vl_False = "";
            this.st_frentista.Vl_True = "";
            // 
            // st_operadorcx
            // 
            this.st_operadorcx.AutoSize = true;
            this.st_operadorcx.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_operadorcxbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_operadorcx.Enabled = false;
            this.st_operadorcx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_operadorcx.Location = new System.Drawing.Point(392, 82);
            this.st_operadorcx.Name = "st_operadorcx";
            this.st_operadorcx.NM_Alias = "";
            this.st_operadorcx.NM_Campo = "";
            this.st_operadorcx.NM_Param = "";
            this.st_operadorcx.Size = new System.Drawing.Size(113, 17);
            this.st_operadorcx.ST_Gravar = true;
            this.st_operadorcx.ST_LimparCampo = true;
            this.st_operadorcx.ST_NotNull = false;
            this.st_operadorcx.TabIndex = 8;
            this.st_operadorcx.Text = "Operador Caixa";
            this.st_operadorcx.UseVisualStyleBackColor = true;
            this.st_operadorcx.Vl_False = "";
            this.st_operadorcx.Vl_True = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Salario Base Mês:";
            // 
            // vl_basesalario
            // 
            this.vl_basesalario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCargoFuncionario, "vl_basesalario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_basesalario.DecimalPlaces = 2;
            this.vl_basesalario.Enabled = false;
            this.vl_basesalario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_basesalario.Location = new System.Drawing.Point(102, 56);
            this.vl_basesalario.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_basesalario.Name = "vl_basesalario";
            this.vl_basesalario.NM_Alias = "";
            this.vl_basesalario.NM_Campo = "";
            this.vl_basesalario.NM_Param = "";
            this.vl_basesalario.Operador = "";
            this.vl_basesalario.Size = new System.Drawing.Size(120, 20);
            this.vl_basesalario.ST_AutoInc = false;
            this.vl_basesalario.ST_DisableAuto = false;
            this.vl_basesalario.ST_Gravar = true;
            this.vl_basesalario.ST_LimparCampo = true;
            this.vl_basesalario.ST_NotNull = false;
            this.vl_basesalario.ST_PrimaryKey = false;
            this.vl_basesalario.TabIndex = 2;
            this.vl_basesalario.ThousandsSeparator = true;
            // 
            // CargaHorariaMes
            // 
            this.CargaHorariaMes.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCargoFuncionario, "CargahorarioMes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CargaHorariaMes.Enabled = false;
            this.CargaHorariaMes.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CargaHorariaMes.Location = new System.Drawing.Point(343, 56);
            this.CargaHorariaMes.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.CargaHorariaMes.Name = "CargaHorariaMes";
            this.CargaHorariaMes.NM_Alias = "";
            this.CargaHorariaMes.NM_Campo = "";
            this.CargaHorariaMes.NM_Param = "";
            this.CargaHorariaMes.Operador = "";
            this.CargaHorariaMes.Size = new System.Drawing.Size(120, 20);
            this.CargaHorariaMes.ST_AutoInc = false;
            this.CargaHorariaMes.ST_DisableAuto = false;
            this.CargaHorariaMes.ST_Gravar = true;
            this.CargaHorariaMes.ST_LimparCampo = true;
            this.CargaHorariaMes.ST_NotNull = false;
            this.CargaHorariaMes.ST_PrimaryKey = false;
            this.CargaHorariaMes.TabIndex = 3;
            this.CargaHorariaMes.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Carga Horaria Mês:";
            // 
            // st_gervenda
            // 
            this.st_gervenda.AutoSize = true;
            this.st_gervenda.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCargoFuncionario, "St_gervendabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gervenda.Enabled = false;
            this.st_gervenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_gervenda.Location = new System.Drawing.Point(511, 82);
            this.st_gervenda.Name = "st_gervenda";
            this.st_gervenda.NM_Alias = "";
            this.st_gervenda.NM_Campo = "";
            this.st_gervenda.NM_Param = "";
            this.st_gervenda.Size = new System.Drawing.Size(117, 17);
            this.st_gervenda.ST_Gravar = true;
            this.st_gervenda.ST_LimparCampo = true;
            this.st_gervenda.ST_NotNull = false;
            this.st_gervenda.TabIndex = 12;
            this.st_gervenda.Text = "Gerente Vendas";
            this.st_gervenda.UseVisualStyleBackColor = true;
            this.st_gervenda.Vl_False = "";
            this.st_gervenda.Vl_True = "";
            // 
            // idcargostrDataGridViewTextBoxColumn
            // 
            this.idcargostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcargostrDataGridViewTextBoxColumn.DataPropertyName = "Id_cargostr";
            this.idcargostrDataGridViewTextBoxColumn.HeaderText = "Id. Cargo";
            this.idcargostrDataGridViewTextBoxColumn.Name = "idcargostrDataGridViewTextBoxColumn";
            this.idcargostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcargostrDataGridViewTextBoxColumn.Width = 75;
            // 
            // dscargoDataGridViewTextBoxColumn
            // 
            this.dscargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscargoDataGridViewTextBoxColumn.DataPropertyName = "Ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.HeaderText = "Cargo";
            this.dscargoDataGridViewTextBoxColumn.Name = "dscargoDataGridViewTextBoxColumn";
            this.dscargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscargoDataGridViewTextBoxColumn.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "vl_basesalario";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Salario Base Mês";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 87;
            // 
            // CargahorarioMes
            // 
            this.CargahorarioMes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CargahorarioMes.DataPropertyName = "CargahorarioMes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.CargahorarioMes.DefaultCellStyle = dataGridViewCellStyle4;
            this.CargahorarioMes.HeaderText = "Carga Horaria Mês";
            this.CargahorarioMes.Name = "CargahorarioMes";
            this.CargahorarioMes.ReadOnly = true;
            this.CargahorarioMes.Width = 92;
            // 
            // stvendedorboolDataGridViewCheckBoxColumn
            // 
            this.stvendedorboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stvendedorboolDataGridViewCheckBoxColumn.DataPropertyName = "St_vendedorbool";
            this.stvendedorboolDataGridViewCheckBoxColumn.HeaderText = "Vendedor";
            this.stvendedorboolDataGridViewCheckBoxColumn.Name = "stvendedorboolDataGridViewCheckBoxColumn";
            this.stvendedorboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stvendedorboolDataGridViewCheckBoxColumn.Width = 59;
            // 
            // St_tecnicobool
            // 
            this.St_tecnicobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_tecnicobool.DataPropertyName = "St_tecnicobool";
            this.St_tecnicobool.HeaderText = "Técnico";
            this.St_tecnicobool.Name = "St_tecnicobool";
            this.St_tecnicobool.ReadOnly = true;
            this.St_tecnicobool.Width = 52;
            // 
            // St_motoristabool
            // 
            this.St_motoristabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_motoristabool.DataPropertyName = "St_motoristabool";
            this.St_motoristabool.HeaderText = "Motorista";
            this.St_motoristabool.Name = "St_motoristabool";
            this.St_motoristabool.ReadOnly = true;
            this.St_motoristabool.Width = 56;
            // 
            // Frentista
            // 
            this.Frentista.DataPropertyName = "St_frentistabool";
            this.Frentista.HeaderText = "Frentista";
            this.Frentista.Name = "Frentista";
            this.Frentista.ReadOnly = true;
            // 
            // St_operadorcxbool
            // 
            this.St_operadorcxbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_operadorcxbool.DataPropertyName = "St_operadorcxbool";
            this.St_operadorcxbool.HeaderText = "Operador Caixa";
            this.St_operadorcxbool.Name = "St_operadorcxbool";
            this.St_operadorcxbool.ReadOnly = true;
            this.St_operadorcxbool.Width = 77;
            // 
            // St_gervendabool
            // 
            this.St_gervendabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_gervendabool.DataPropertyName = "St_gervendabool";
            this.St_gervendabool.HeaderText = "Gerente Vendas";
            this.St_gervendabool.Name = "St_gervendabool";
            this.St_gervendabool.ReadOnly = true;
            this.St_gervendabool.Width = 81;
            // 
            // TFCadCargoFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCargoFuncionario";
            this.Text = "Cadastro de Cargos Funcionarios";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargoFuncionario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_basesalario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CargaHorariaMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCargoFuncionario;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault st_vendedor;
        private Componentes.EditDefault id_cargo;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_cargo;
        private Componentes.CheckBoxDefault st_tecnico;
        private Componentes.CheckBoxDefault st_motorista;
        private Componentes.CheckBoxDefault st_frentista;
        private Componentes.CheckBoxDefault st_operadorcx;
        private Componentes.EditFloat CargaHorariaMes;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_basesalario;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_gervenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcargostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargahorarioMes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stvendedorboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_tecnicobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_motoristabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Frentista;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_operadorcxbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_gervendabool;
    }
}
