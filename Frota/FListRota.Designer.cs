namespace Frota
{
    partial class TFListRota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListRota));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bsRotaFrete = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gRotaFrete = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsrotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscidadeorigemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uf_origem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscidadedestinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uf_destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanciaKMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlfreteFixoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlpedagiosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsunidadefreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlfreteUnidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaFrete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRotaFrete)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(899, 43);
            this.barraMenu.TabIndex = 16;
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
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsRotaFrete;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 542);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(899, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bsRotaFrete
            // 
            this.bsRotaFrete.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_RotaFrete);
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
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(8, 54);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 0;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // gRotaFrete
            // 
            this.gRotaFrete.AllowUserToAddRows = false;
            this.gRotaFrete.AllowUserToDeleteRows = false;
            this.gRotaFrete.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gRotaFrete.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.gRotaFrete.AutoGenerateColumns = false;
            this.gRotaFrete.BackgroundColor = System.Drawing.Color.LightGray;
            this.gRotaFrete.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gRotaFrete.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRotaFrete.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gRotaFrete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRotaFrete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.dsrotaDataGridViewTextBoxColumn,
            this.dscidadeorigemDataGridViewTextBoxColumn,
            this.Uf_origem,
            this.dscidadedestinoDataGridViewTextBoxColumn,
            this.Uf_destino,
            this.distanciaKMDataGridViewTextBoxColumn,
            this.vlfreteFixoDataGridViewTextBoxColumn,
            this.vlpedagiosDataGridViewTextBoxColumn,
            this.dsunidadefreteDataGridViewTextBoxColumn,
            this.vlfreteUnidadeDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gRotaFrete.DataSource = this.bsRotaFrete;
            this.gRotaFrete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRotaFrete.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gRotaFrete.Location = new System.Drawing.Point(0, 43);
            this.gRotaFrete.Name = "gRotaFrete";
            this.gRotaFrete.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRotaFrete.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.gRotaFrete.RowHeadersWidth = 23;
            this.gRotaFrete.Size = new System.Drawing.Size(899, 499);
            this.gRotaFrete.TabIndex = 18;
            this.gRotaFrete.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gRotaFrete_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Selecionar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 63;
            // 
            // dsrotaDataGridViewTextBoxColumn
            // 
            this.dsrotaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsrotaDataGridViewTextBoxColumn.DataPropertyName = "Ds_rota";
            this.dsrotaDataGridViewTextBoxColumn.HeaderText = "Rota";
            this.dsrotaDataGridViewTextBoxColumn.Name = "dsrotaDataGridViewTextBoxColumn";
            this.dsrotaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsrotaDataGridViewTextBoxColumn.Width = 55;
            // 
            // dscidadeorigemDataGridViewTextBoxColumn
            // 
            this.dscidadeorigemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscidadeorigemDataGridViewTextBoxColumn.DataPropertyName = "Ds_cidade_origem";
            this.dscidadeorigemDataGridViewTextBoxColumn.HeaderText = "Cidade Origem";
            this.dscidadeorigemDataGridViewTextBoxColumn.Name = "dscidadeorigemDataGridViewTextBoxColumn";
            this.dscidadeorigemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscidadeorigemDataGridViewTextBoxColumn.Width = 101;
            // 
            // Uf_origem
            // 
            this.Uf_origem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Uf_origem.DataPropertyName = "Uf_origem";
            this.Uf_origem.HeaderText = "UF Origem";
            this.Uf_origem.Name = "Uf_origem";
            this.Uf_origem.ReadOnly = true;
            this.Uf_origem.Width = 82;
            // 
            // dscidadedestinoDataGridViewTextBoxColumn
            // 
            this.dscidadedestinoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscidadedestinoDataGridViewTextBoxColumn.DataPropertyName = "Ds_cidade_destino";
            this.dscidadedestinoDataGridViewTextBoxColumn.HeaderText = "Cidade Destino";
            this.dscidadedestinoDataGridViewTextBoxColumn.Name = "dscidadedestinoDataGridViewTextBoxColumn";
            this.dscidadedestinoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscidadedestinoDataGridViewTextBoxColumn.Width = 96;
            // 
            // Uf_destino
            // 
            this.Uf_destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Uf_destino.DataPropertyName = "Uf_destino";
            this.Uf_destino.HeaderText = "UF Destino";
            this.Uf_destino.Name = "Uf_destino";
            this.Uf_destino.ReadOnly = true;
            this.Uf_destino.Width = 79;
            // 
            // distanciaKMDataGridViewTextBoxColumn
            // 
            this.distanciaKMDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.distanciaKMDataGridViewTextBoxColumn.DataPropertyName = "Distancia_KM";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N3";
            dataGridViewCellStyle10.NullValue = "0";
            this.distanciaKMDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.distanciaKMDataGridViewTextBoxColumn.HeaderText = "Distancia KM";
            this.distanciaKMDataGridViewTextBoxColumn.Name = "distanciaKMDataGridViewTextBoxColumn";
            this.distanciaKMDataGridViewTextBoxColumn.ReadOnly = true;
            this.distanciaKMDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlfreteFixoDataGridViewTextBoxColumn
            // 
            this.vlfreteFixoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlfreteFixoDataGridViewTextBoxColumn.DataPropertyName = "Vl_freteFixo";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.vlfreteFixoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.vlfreteFixoDataGridViewTextBoxColumn.HeaderText = "Vl.Frete Fixo";
            this.vlfreteFixoDataGridViewTextBoxColumn.Name = "vlfreteFixoDataGridViewTextBoxColumn";
            this.vlfreteFixoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlfreteFixoDataGridViewTextBoxColumn.Width = 83;
            // 
            // vlpedagiosDataGridViewTextBoxColumn
            // 
            this.vlpedagiosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlpedagiosDataGridViewTextBoxColumn.DataPropertyName = "Vl_pedagios";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = "0";
            this.vlpedagiosDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.vlpedagiosDataGridViewTextBoxColumn.HeaderText = "Vl.Pedagios";
            this.vlpedagiosDataGridViewTextBoxColumn.Name = "vlpedagiosDataGridViewTextBoxColumn";
            this.vlpedagiosDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlpedagiosDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsunidadefreteDataGridViewTextBoxColumn
            // 
            this.dsunidadefreteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsunidadefreteDataGridViewTextBoxColumn.DataPropertyName = "Ds_unidade_frete";
            this.dsunidadefreteDataGridViewTextBoxColumn.HeaderText = "Unidade Frete";
            this.dsunidadefreteDataGridViewTextBoxColumn.Name = "dsunidadefreteDataGridViewTextBoxColumn";
            this.dsunidadefreteDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsunidadefreteDataGridViewTextBoxColumn.Width = 91;
            // 
            // vlfreteUnidadeDataGridViewTextBoxColumn
            // 
            this.vlfreteUnidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlfreteUnidadeDataGridViewTextBoxColumn.DataPropertyName = "Vl_freteUnidade";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.vlfreteUnidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.vlfreteUnidadeDataGridViewTextBoxColumn.HeaderText = "Vl.Frete Unidade";
            this.vlfreteUnidadeDataGridViewTextBoxColumn.Name = "vlfreteUnidadeDataGridViewTextBoxColumn";
            this.vlfreteUnidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlfreteUnidadeDataGridViewTextBoxColumn.Width = 102;
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
            // TFListRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 567);
            this.Controls.Add(this.cbTodos);
            this.Controls.Add(this.gRotaFrete);
            this.Controls.Add(this.barraMenu);
            this.Controls.Add(this.bindingNavigator1);
            this.KeyPreview = true;
            this.Name = "TFListRota";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Rotas";
            this.Load += new System.EventHandler(this.TFListRota_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFListRota_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListRota_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRotaFrete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRotaFrete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gRotaFrete;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.BindingSource bsRotaFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsrotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscidadeorigemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uf_origem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscidadedestinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uf_destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanciaKMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteFixoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlpedagiosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsunidadefreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteUnidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}