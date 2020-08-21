namespace Locacao
{
    partial class TFMedicao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMedicao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtmedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dt_medicao = new Componentes.EditData(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbPatrimonio = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gGrade = new System.Windows.Forms.DataGridView();
            this.cdprodutoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtmedidaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProdutoItens = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGrade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProdutoItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(793, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(793, 432);
            this.tlpCentral.TabIndex = 15;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enderecoDataGridViewTextBoxColumn
            // 
            this.enderecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enderecoDataGridViewTextBoxColumn.DataPropertyName = "Endereco";
            this.enderecoDataGridViewTextBoxColumn.HeaderText = "Endereco";
            this.enderecoDataGridViewTextBoxColumn.Name = "enderecoDataGridViewTextBoxColumn";
            this.enderecoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtmedidaDataGridViewTextBoxColumn
            // 
            this.qtmedidaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtmedidaDataGridViewTextBoxColumn.DataPropertyName = "Qt_medida";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "0";
            this.qtmedidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtmedidaDataGridViewTextBoxColumn.HeaderText = "Qtd. Medição";
            this.qtmedidaDataGridViewTextBoxColumn.Name = "qtmedidaDataGridViewTextBoxColumn";
            this.qtmedidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dt_medicao);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cbPatrimonio);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.cbEmpresa);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(787, 35);
            this.panelDados1.TabIndex = 0;
            // 
            // dt_medicao
            // 
            this.dt_medicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_medicao.Location = new System.Drawing.Point(713, 8);
            this.dt_medicao.Mask = "00/00/0000";
            this.dt_medicao.Name = "dt_medicao";
            this.dt_medicao.NM_Alias = "";
            this.dt_medicao.NM_Campo = "";
            this.dt_medicao.NM_CampoBusca = "";
            this.dt_medicao.NM_Param = "";
            this.dt_medicao.Operador = "";
            this.dt_medicao.Size = new System.Drawing.Size(69, 20);
            this.dt_medicao.ST_Gravar = false;
            this.dt_medicao.ST_LimpaCampo = true;
            this.dt_medicao.ST_NotNull = false;
            this.dt_medicao.ST_PrimaryKey = false;
            this.dt_medicao.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(639, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 162;
            this.label2.Text = "Dt. Medição:";
            // 
            // cbPatrimonio
            // 
            this.cbPatrimonio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatrimonio.FormattingEnabled = true;
            this.cbPatrimonio.Location = new System.Drawing.Point(401, 7);
            this.cbPatrimonio.Name = "cbPatrimonio";
            this.cbPatrimonio.NM_Alias = "";
            this.cbPatrimonio.NM_Campo = "";
            this.cbPatrimonio.NM_Param = "";
            this.cbPatrimonio.Size = new System.Drawing.Size(232, 21);
            this.cbPatrimonio.ST_Gravar = false;
            this.cbPatrimonio.ST_LimparCampo = true;
            this.cbPatrimonio.ST_NotNull = false;
            this.cbPatrimonio.TabIndex = 1;
            this.cbPatrimonio.SelectedIndexChanged += new System.EventHandler(this.cbPatrimonio_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(336, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "Patrimonio:";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(66, 7);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(264, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 0;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(9, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 158;
            this.label8.Text = "Empresa:";
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.gGrade);
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 44);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(787, 385);
            this.panelDados2.TabIndex = 1;
            // 
            // gGrade
            // 
            this.gGrade.AllowUserToAddRows = false;
            this.gGrade.AllowUserToDeleteRows = false;
            this.gGrade.AllowUserToOrderColumns = true;
            this.gGrade.AutoGenerateColumns = false;
            this.gGrade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gGrade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.gGrade.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.gGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprodutoDataGridViewTextBoxColumn1,
            this.dsprodutoDataGridViewTextBoxColumn1,
            this.enderecoDataGridViewTextBoxColumn1,
            this.qtmedidaDataGridViewTextBoxColumn1});
            this.gGrade.DataSource = this.bsProdutoItens;
            this.gGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gGrade.Location = new System.Drawing.Point(0, 0);
            this.gGrade.MultiSelect = false;
            this.gGrade.Name = "gGrade";
            this.gGrade.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gGrade.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gGrade.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gGrade.Size = new System.Drawing.Size(787, 360);
            this.gGrade.TabIndex = 4;
            this.gGrade.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gGrade_DataError);
            this.gGrade.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gGrade_EditingControlShowing);
            // 
            // cdprodutoDataGridViewTextBoxColumn1
            // 
            this.cdprodutoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn1.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn1.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn1.Name = "cdprodutoDataGridViewTextBoxColumn1";
            this.cdprodutoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn1.Width = 88;
            // 
            // dsprodutoDataGridViewTextBoxColumn1
            // 
            this.dsprodutoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn1.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn1.Name = "dsprodutoDataGridViewTextBoxColumn1";
            this.dsprodutoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn1.Width = 69;
            // 
            // enderecoDataGridViewTextBoxColumn1
            // 
            this.enderecoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enderecoDataGridViewTextBoxColumn1.DataPropertyName = "Endereco";
            this.enderecoDataGridViewTextBoxColumn1.HeaderText = "Endereco";
            this.enderecoDataGridViewTextBoxColumn1.Name = "enderecoDataGridViewTextBoxColumn1";
            this.enderecoDataGridViewTextBoxColumn1.ReadOnly = true;
            this.enderecoDataGridViewTextBoxColumn1.Width = 78;
            // 
            // qtmedidaDataGridViewTextBoxColumn1
            // 
            this.qtmedidaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtmedidaDataGridViewTextBoxColumn1.DataPropertyName = "Qt_medida";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.qtmedidaDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.qtmedidaDataGridViewTextBoxColumn1.HeaderText = "Qtd. Medição";
            this.qtmedidaDataGridViewTextBoxColumn1.Name = "qtmedidaDataGridViewTextBoxColumn1";
            this.qtmedidaDataGridViewTextBoxColumn1.Width = 96;
            // 
            // bsProdutoItens
            // 
            this.bsProdutoItens.DataSource = typeof(CamadaDados.Locacao.TList_ProdutoItens);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsProdutoItens;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 360);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(787, 25);
            this.bindingNavigator1.TabIndex = 3;
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
            // TFMedicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 475);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMedicao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medição Produtos";
            this.Load += new System.EventHandler(this.TFMedicao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMedicao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGrade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProdutoItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.ComboBoxDefault cbPatrimonio;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label8;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtmedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsProdutoItens;
        private System.Windows.Forms.DataGridView gGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtmedidaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_medicao;
    }
}