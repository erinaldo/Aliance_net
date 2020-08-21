namespace Compra.Cadastros
{
    partial class TFCadTpRequisicao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpRequisicao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gTpRequisicao = new Componentes.DataGridDefault(this.components);
            this.idtprequisicaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstprequisicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiporequisicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTpRequisicao = new System.Windows.Forms.BindingSource(this.components);
            this.id_tprequisicao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_tprequisicao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_requisicao = new Componentes.ComboBoxDefault(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dsgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsGrupoProd = new System.Windows.Forms.BindingSource(this.components);
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_Inserir_Item = new System.Windows.Forms.ToolStripButton();
            this.btn_Deleta_Item = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpRequisicao)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoProd)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_requisicao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_tprequisicao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_tprequisicao);
            this.pDados.Size = new System.Drawing.Size(749, 83);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(761, 390);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.tableLayoutPanel1);
            this.tpPadrao.Size = new System.Drawing.Size(753, 364);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // gTpRequisicao
            // 
            this.gTpRequisicao.AllowUserToAddRows = false;
            this.gTpRequisicao.AllowUserToDeleteRows = false;
            this.gTpRequisicao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTpRequisicao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.gTpRequisicao.AutoGenerateColumns = false;
            this.gTpRequisicao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTpRequisicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTpRequisicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpRequisicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.gTpRequisicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTpRequisicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtprequisicaostrDataGridViewTextBoxColumn,
            this.dstprequisicaoDataGridViewTextBoxColumn,
            this.tiporequisicaoDataGridViewTextBoxColumn});
            this.gTpRequisicao.DataSource = this.bsTpRequisicao;
            this.gTpRequisicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTpRequisicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTpRequisicao.Location = new System.Drawing.Point(0, 0);
            this.gTpRequisicao.Name = "gTpRequisicao";
            this.gTpRequisicao.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpRequisicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.gTpRequisicao.RowHeadersWidth = 23;
            this.gTpRequisicao.Size = new System.Drawing.Size(493, 271);
            this.gTpRequisicao.TabIndex = 1;
            this.gTpRequisicao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTpRequisicao_ColumnHeaderMouseClick);
            // 
            // idtprequisicaostrDataGridViewTextBoxColumn
            // 
            this.idtprequisicaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtprequisicaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_tprequisicaostr";
            this.idtprequisicaostrDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idtprequisicaostrDataGridViewTextBoxColumn.Name = "idtprequisicaostrDataGridViewTextBoxColumn";
            this.idtprequisicaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtprequisicaostrDataGridViewTextBoxColumn.Width = 65;
            // 
            // dstprequisicaoDataGridViewTextBoxColumn
            // 
            this.dstprequisicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstprequisicaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tprequisicao";
            this.dstprequisicaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.dstprequisicaoDataGridViewTextBoxColumn.Name = "dstprequisicaoDataGridViewTextBoxColumn";
            this.dstprequisicaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstprequisicaoDataGridViewTextBoxColumn.Width = 80;
            // 
            // tiporequisicaoDataGridViewTextBoxColumn
            // 
            this.tiporequisicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tiporequisicaoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_requisicao";
            this.tiporequisicaoDataGridViewTextBoxColumn.HeaderText = "Tipo Requisição";
            this.tiporequisicaoDataGridViewTextBoxColumn.Name = "tiporequisicaoDataGridViewTextBoxColumn";
            this.tiporequisicaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsTpRequisicao
            // 
            this.bsTpRequisicao.DataSource = typeof(CamadaDados.Compra.TList_TpRequisicao);
            this.bsTpRequisicao.PositionChanged += new System.EventHandler(this.bsTpRequisicao_PositionChanged);
            // 
            // id_tprequisicao
            // 
            this.id_tprequisicao.BackColor = System.Drawing.SystemColors.Window;
            this.id_tprequisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tprequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tprequisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpRequisicao, "Id_tprequisicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tprequisicao.Enabled = false;
            this.id_tprequisicao.Location = new System.Drawing.Point(68, 3);
            this.id_tprequisicao.Name = "id_tprequisicao";
            this.id_tprequisicao.NM_Alias = "";
            this.id_tprequisicao.NM_Campo = "id_tprequisicao";
            this.id_tprequisicao.NM_CampoBusca = "id_tprequisicao";
            this.id_tprequisicao.NM_Param = "@P_ID_TPREQUISICAO";
            this.id_tprequisicao.QTD_Zero = 0;
            this.id_tprequisicao.Size = new System.Drawing.Size(58, 20);
            this.id_tprequisicao.ST_AutoInc = false;
            this.id_tprequisicao.ST_DisableAuto = true;
            this.id_tprequisicao.ST_Float = false;
            this.id_tprequisicao.ST_Gravar = true;
            this.id_tprequisicao.ST_Int = true;
            this.id_tprequisicao.ST_LimpaCampo = true;
            this.id_tprequisicao.ST_NotNull = true;
            this.id_tprequisicao.ST_PrimaryKey = true;
            this.id_tprequisicao.TabIndex = 0;
            this.id_tprequisicao.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // ds_tprequisicao
            // 
            this.ds_tprequisicao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tprequisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tprequisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tprequisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpRequisicao, "Ds_tprequisicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tprequisicao.Enabled = false;
            this.ds_tprequisicao.Location = new System.Drawing.Point(68, 29);
            this.ds_tprequisicao.Name = "ds_tprequisicao";
            this.ds_tprequisicao.NM_Alias = "";
            this.ds_tprequisicao.NM_Campo = "";
            this.ds_tprequisicao.NM_CampoBusca = "";
            this.ds_tprequisicao.NM_Param = "";
            this.ds_tprequisicao.QTD_Zero = 0;
            this.ds_tprequisicao.Size = new System.Drawing.Size(583, 20);
            this.ds_tprequisicao.ST_AutoInc = false;
            this.ds_tprequisicao.ST_DisableAuto = false;
            this.ds_tprequisicao.ST_Float = false;
            this.ds_tprequisicao.ST_Gravar = true;
            this.ds_tprequisicao.ST_Int = false;
            this.ds_tprequisicao.ST_LimpaCampo = true;
            this.ds_tprequisicao.ST_NotNull = true;
            this.ds_tprequisicao.ST_PrimaryKey = false;
            this.ds_tprequisicao.TabIndex = 1;
            this.ds_tprequisicao.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo:";
            // 
            // tp_requisicao
            // 
            this.tp_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTpRequisicao, "Tp_requisicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_requisicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_requisicao.Enabled = false;
            this.tp_requisicao.FormattingEnabled = true;
            this.tp_requisicao.Location = new System.Drawing.Point(68, 55);
            this.tp_requisicao.Name = "tp_requisicao";
            this.tp_requisicao.NM_Alias = "";
            this.tp_requisicao.NM_Campo = "";
            this.tp_requisicao.NM_Param = "";
            this.tp_requisicao.Size = new System.Drawing.Size(134, 21);
            this.tp_requisicao.ST_Gravar = true;
            this.tp_requisicao.ST_LimparCampo = true;
            this.tp_requisicao.ST_NotNull = true;
            this.tp_requisicao.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(749, 277);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Controls.Add(this.gTpRequisicao);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(493, 271);
            this.panelDados1.TabIndex = 0;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTpRequisicao;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 246);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(493, 25);
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
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.dataGridDefault1);
            this.panelDados2.Controls.Add(this.TS_ItensPedido);
            this.panelDados2.Controls.Add(this.bindingNavigator2);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(502, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(244, 271);
            this.panelDados2.TabIndex = 1;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dsgrupoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsGrupoProd;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 25);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(244, 221);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // dsgrupoDataGridViewTextBoxColumn
            // 
            this.dsgrupoDataGridViewTextBoxColumn.DataPropertyName = "Ds_grupo";
            this.dsgrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.dsgrupoDataGridViewTextBoxColumn.Name = "dsgrupoDataGridViewTextBoxColumn";
            this.dsgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsGrupoProd
            // 
            this.bsGrupoProd.DataMember = "lGrupoProd";
            this.bsGrupoProd.DataSource = this.bsTpRequisicao;
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Enabled = false;
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Inserir_Item,
            this.btn_Deleta_Item});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(244, 25);
            this.TS_ItensPedido.TabIndex = 5;
            // 
            // btn_Inserir_Item
            // 
            this.btn_Inserir_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Inserir_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_Inserir_Item.Image")));
            this.btn_Inserir_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Inserir_Item.Name = "btn_Inserir_Item";
            this.btn_Inserir_Item.Size = new System.Drawing.Size(65, 22);
            this.btn_Inserir_Item.Text = "Inserir";
            this.btn_Inserir_Item.ToolTipText = "Inserir Novo Item Pedido";
            this.btn_Inserir_Item.Click += new System.EventHandler(this.btn_Inserir_Item_Click);
            // 
            // btn_Deleta_Item
            // 
            this.btn_Deleta_Item.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Deleta_Item.Image = ((System.Drawing.Image)(resources.GetObject("btn_Deleta_Item.Image")));
            this.btn_Deleta_Item.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Deleta_Item.Name = "btn_Deleta_Item";
            this.btn_Deleta_Item.Size = new System.Drawing.Size(64, 22);
            this.btn_Deleta_Item.Text = "Excluir";
            this.btn_Deleta_Item.ToolTipText = "Excluir Item Pedido";
            this.btn_Deleta_Item.Click += new System.EventHandler(this.btn_Deleta_Item_Click);
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.BindingSource = this.bsTpRequisicao;
            this.bindingNavigator2.CountItem = this.toolStripLabel1;
            this.bindingNavigator2.CountItemFormat = "de {0}";
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 246);
            this.bindingNavigator2.MoveFirstItem = this.toolStripButton1;
            this.bindingNavigator2.MoveLastItem = this.toolStripButton4;
            this.bindingNavigator2.MoveNextItem = this.toolStripButton3;
            this.bindingNavigator2.MovePreviousItem = this.toolStripButton2;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator2.Size = new System.Drawing.Size(244, 25);
            this.bindingNavigator2.TabIndex = 4;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Total Registros";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Primeiro Registro";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Registro Anterior";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Proximo Registro";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Ultimo Registro";
            // 
            // TFCadTpRequisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(761, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTpRequisicao";
            this.Text = "Cadastro Tipo Requisição";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gTpRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpRequisicao)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoProd)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_tprequisicao;
        private Componentes.DataGridDefault gTpRequisicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtprequisicaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstprequisicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiporequisicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsTpRequisicao;
        private Componentes.ComboBoxDefault tp_requisicao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_tprequisicao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_Inserir_Item;
        private System.Windows.Forms.ToolStripButton btn_Deleta_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsGrupoProd;
    }
}
