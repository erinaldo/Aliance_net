namespace Commoditties
{
    partial class TFExcluirTaxasProvisionadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFExcluirTaxasProvisionadas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_marcatodos = new Componentes.CheckBoxDefault(this.components);
            this.gTaxaRealizar = new Componentes.DataGridDefault(this.components);
            this.St_faturar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTaxaRealizar = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator8 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton15 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton16 = new System.Windows.Forms.ToolStripButton();
            this.pTotal = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ps_provisionado = new Componentes.EditFloat(this.components);
            this.vl_provisionado = new Componentes.EditFloat(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTaxaRealizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxaRealizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator8)).BeginInit();
            this.bindingNavigator8.SuspendLayout();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ps_provisionado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_provisionado)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(766, 43);
            this.barraMenu.TabIndex = 12;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Controls.Add(this.pTotal, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpCentral.Size = new System.Drawing.Size(766, 377);
            this.tlpCentral.TabIndex = 13;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.st_marcatodos);
            this.pDados.Controls.Add(this.gTaxaRealizar);
            this.pDados.Controls.Add(this.bindingNavigator8);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 5);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(756, 319);
            this.pDados.TabIndex = 0;
            // 
            // st_marcatodos
            // 
            this.st_marcatodos.AutoSize = true;
            this.st_marcatodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_marcatodos.Location = new System.Drawing.Point(8, 11);
            this.st_marcatodos.Name = "st_marcatodos";
            this.st_marcatodos.NM_Alias = "";
            this.st_marcatodos.NM_Campo = "";
            this.st_marcatodos.NM_Param = "";
            this.st_marcatodos.Size = new System.Drawing.Size(15, 14);
            this.st_marcatodos.ST_Gravar = false;
            this.st_marcatodos.ST_LimparCampo = true;
            this.st_marcatodos.ST_NotNull = false;
            this.st_marcatodos.TabIndex = 9;
            this.st_marcatodos.UseVisualStyleBackColor = true;
            this.st_marcatodos.Vl_False = "";
            this.st_marcatodos.Vl_True = "";
            this.st_marcatodos.Click += new System.EventHandler(this.st_marcatodos_Click);
            // 
            // gTaxaRealizar
            // 
            this.gTaxaRealizar.AllowUserToAddRows = false;
            this.gTaxaRealizar.AllowUserToDeleteRows = false;
            this.gTaxaRealizar.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTaxaRealizar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTaxaRealizar.AutoGenerateColumns = false;
            this.gTaxaRealizar.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTaxaRealizar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTaxaRealizar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTaxaRealizar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTaxaRealizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTaxaRealizar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_faturar,
            this.dataGridViewTextBoxColumn57,
            this.dataGridViewTextBoxColumn58,
            this.dataGridViewTextBoxColumn59,
            this.dataGridViewTextBoxColumn60,
            this.dataGridViewTextBoxColumn61,
            this.dataGridViewTextBoxColumn62,
            this.dataGridViewTextBoxColumn63,
            this.dataGridViewTextBoxColumn64});
            this.gTaxaRealizar.DataSource = this.bsTaxaRealizar;
            this.gTaxaRealizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTaxaRealizar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTaxaRealizar.Location = new System.Drawing.Point(0, 0);
            this.gTaxaRealizar.Name = "gTaxaRealizar";
            this.gTaxaRealizar.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTaxaRealizar.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gTaxaRealizar.RowHeadersWidth = 23;
            this.gTaxaRealizar.Size = new System.Drawing.Size(752, 290);
            this.gTaxaRealizar.TabIndex = 7;
            this.gTaxaRealizar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTaxaRealizar_CellClick);
            // 
            // St_faturar
            // 
            this.St_faturar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_faturar.DataPropertyName = "St_faturar";
            this.St_faturar.HeaderText = "Excluir";
            this.St_faturar.Name = "St_faturar";
            this.St_faturar.ReadOnly = true;
            this.St_faturar.Width = 44;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn57.DataPropertyName = "Id_Taxa";
            this.dataGridViewTextBoxColumn57.HeaderText = "Id. Taxa";
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
            this.dataGridViewTextBoxColumn57.Width = 71;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn58.DataPropertyName = "Ds_taxa";
            this.dataGridViewTextBoxColumn58.HeaderText = "Taxa Deposito";
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.ReadOnly = true;
            this.dataGridViewTextBoxColumn58.Width = 101;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn59.DataPropertyName = "DT_Lancto";
            this.dataGridViewTextBoxColumn59.HeaderText = "Dt. Lancto";
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.ReadOnly = true;
            this.dataGridViewTextBoxColumn59.Width = 82;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn60.DataPropertyName = "Tipo_lancto";
            this.dataGridViewTextBoxColumn60.HeaderText = "Tipo Lançamento";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            this.dataGridViewTextBoxColumn60.Width = 106;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn61.DataPropertyName = "Ps_Taxa";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn61.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn61.HeaderText = "Peso Taxa";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.ReadOnly = true;
            this.dataGridViewTextBoxColumn61.Width = 77;
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn62.DataPropertyName = "Sigla_produto";
            this.dataGridViewTextBoxColumn62.HeaderText = "UND";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.ReadOnly = true;
            this.dataGridViewTextBoxColumn62.Width = 56;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn63.DataPropertyName = "Vl_Taxa";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.dataGridViewTextBoxColumn63.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn63.HeaderText = "Valor Taxa";
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.ReadOnly = true;
            this.dataGridViewTextBoxColumn63.Width = 77;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn64.DataPropertyName = "Debito_credito";
            this.dataGridViewTextBoxColumn64.HeaderText = "Debito/Credito";
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.ReadOnly = true;
            this.dataGridViewTextBoxColumn64.Width = 101;
            // 
            // bsTaxaRealizar
            // 
            this.bsTaxaRealizar.DataSource = typeof(CamadaDados.Graos.TList_TaxaDeposito);
            // 
            // bindingNavigator8
            // 
            this.bindingNavigator8.AddNewItem = null;
            this.bindingNavigator8.BindingSource = this.bsTaxaRealizar;
            this.bindingNavigator8.CountItem = this.toolStripLabel4;
            this.bindingNavigator8.DeleteItem = null;
            this.bindingNavigator8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton13,
            this.toolStripButton14,
            this.toolStripSeparator8,
            this.toolStripTextBox4,
            this.toolStripLabel4,
            this.toolStripSeparator9,
            this.toolStripButton15,
            this.toolStripButton16});
            this.bindingNavigator8.Location = new System.Drawing.Point(0, 290);
            this.bindingNavigator8.MoveFirstItem = this.toolStripButton13;
            this.bindingNavigator8.MoveLastItem = this.toolStripButton16;
            this.bindingNavigator8.MoveNextItem = this.toolStripButton15;
            this.bindingNavigator8.MovePreviousItem = this.toolStripButton14;
            this.bindingNavigator8.Name = "bindingNavigator8";
            this.bindingNavigator8.PositionItem = this.toolStripTextBox4;
            this.bindingNavigator8.Size = new System.Drawing.Size(752, 25);
            this.bindingNavigator8.TabIndex = 8;
            this.bindingNavigator8.Text = "bindingNavigator8";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel4.Text = "de {0}";
            this.toolStripLabel4.ToolTipText = "Total Registros";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.RightToLeftAutoMirrorImage = true;
            this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton13.Text = "Primeiro Registro";
            // 
            // toolStripButton14
            // 
            this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
            this.toolStripButton14.Name = "toolStripButton14";
            this.toolStripButton14.RightToLeftAutoMirrorImage = true;
            this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton14.Text = "Registro Anterior";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.AccessibleName = "Position";
            this.toolStripTextBox4.AutoSize = false;
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(50, 21);
            this.toolStripTextBox4.Text = "0";
            this.toolStripTextBox4.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton15
            // 
            this.toolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton15.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton15.Image")));
            this.toolStripButton15.Name = "toolStripButton15";
            this.toolStripButton15.RightToLeftAutoMirrorImage = true;
            this.toolStripButton15.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton15.Text = "Proximo Registro";
            // 
            // toolStripButton16
            // 
            this.toolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton16.Image")));
            this.toolStripButton16.Name = "toolStripButton16";
            this.toolStripButton16.RightToLeftAutoMirrorImage = true;
            this.toolStripButton16.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton16.Text = "Ultimo Registro";
            // 
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Controls.Add(this.ps_provisionado);
            this.pTotal.Controls.Add(this.vl_provisionado);
            this.pTotal.Controls.Add(this.label14);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(5, 332);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(756, 40);
            this.pTotal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "Valor Taxa:";
            // 
            // ps_provisionado
            // 
            this.ps_provisionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ps_provisionado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ps_provisionado.Location = new System.Drawing.Point(83, 6);
            this.ps_provisionado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.ps_provisionado.Name = "ps_provisionado";
            this.ps_provisionado.NM_Alias = "";
            this.ps_provisionado.NM_Campo = "";
            this.ps_provisionado.NM_Param = "";
            this.ps_provisionado.Operador = "";
            this.ps_provisionado.ReadOnly = true;
            this.ps_provisionado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ps_provisionado.Size = new System.Drawing.Size(133, 26);
            this.ps_provisionado.ST_AutoInc = false;
            this.ps_provisionado.ST_DisableAuto = false;
            this.ps_provisionado.ST_Gravar = false;
            this.ps_provisionado.ST_LimparCampo = true;
            this.ps_provisionado.ST_NotNull = false;
            this.ps_provisionado.ST_PrimaryKey = false;
            this.ps_provisionado.TabIndex = 96;
            this.ps_provisionado.ThousandsSeparator = true;
            // 
            // vl_provisionado
            // 
            this.vl_provisionado.DecimalPlaces = 2;
            this.vl_provisionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_provisionado.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_provisionado.Location = new System.Drawing.Point(300, 6);
            this.vl_provisionado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_provisionado.Name = "vl_provisionado";
            this.vl_provisionado.NM_Alias = "";
            this.vl_provisionado.NM_Campo = "";
            this.vl_provisionado.NM_Param = "";
            this.vl_provisionado.Operador = "";
            this.vl_provisionado.ReadOnly = true;
            this.vl_provisionado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_provisionado.Size = new System.Drawing.Size(132, 26);
            this.vl_provisionado.ST_AutoInc = false;
            this.vl_provisionado.ST_DisableAuto = false;
            this.vl_provisionado.ST_Gravar = false;
            this.vl_provisionado.ST_LimparCampo = true;
            this.vl_provisionado.ST_NotNull = false;
            this.vl_provisionado.ST_PrimaryKey = false;
            this.vl_provisionado.TabIndex = 95;
            this.vl_provisionado.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Peso Taxa:";
            // 
            // TFExcluirTaxasProvisionadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 420);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFExcluirTaxasProvisionadas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excluir Taxas Provisionadas/Manuais";
            this.Load += new System.EventHandler(this.TFExcluirTaxasProvisionadas_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFExcluirTaxasProvisionadas_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFExcluirTaxasProvisionadas_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTaxaRealizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTaxaRealizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator8)).EndInit();
            this.bindingNavigator8.ResumeLayout(false);
            this.bindingNavigator8.PerformLayout();
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ps_provisionado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_provisionado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados pTotal;
        private System.Windows.Forms.BindingSource bsTaxaRealizar;
        private Componentes.DataGridDefault gTaxaRealizar;
        private System.Windows.Forms.BindingNavigator bindingNavigator8;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStripButton toolStripButton14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton toolStripButton15;
        private System.Windows.Forms.ToolStripButton toolStripButton16;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat ps_provisionado;
        private Componentes.EditFloat vl_provisionado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_faturar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private Componentes.CheckBoxDefault st_marcatodos;
    }
}