namespace Almoxarifado
{
    partial class TFMovRequisicao
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMovRequisicao));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pRequisicao = new Componentes.PanelDados(this.components);
            this.gRequisicao = new Componentes.DataGridDefault(this.components);
            this.idrequisicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtrequisicaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdaprovadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_almox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sd_retirar_almox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforrequisitanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRequisicao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.bb_requisitante = new System.Windows.Forms.Button();
            this.cd_requisitante = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.id_requisicao = new Componentes.EditDefault(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.pRequisicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(33, 33);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 7;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(209, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 15;
            label2.Text = "Produto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(187, 33);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(69, 13);
            label3.TabIndex = 18;
            label3.Text = "Requisitante:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(397, 7);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 13);
            label5.TabIndex = 20;
            label5.Text = "Dt. Ini.:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(397, 33);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 13);
            label6.TabIndex = 22;
            label6.Text = "Dt. Fin.:";
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pRequisicao, 0, 1);
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 39);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1019, 536);
            this.tlpCentral.TabIndex = 0;
            // 
            // pRequisicao
            // 
            this.pRequisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pRequisicao.Controls.Add(this.gRequisicao);
            this.pRequisicao.Controls.Add(this.bindingNavigator1);
            this.pRequisicao.Controls.Add(this.label4);
            this.pRequisicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRequisicao.Location = new System.Drawing.Point(5, 69);
            this.pRequisicao.Name = "pRequisicao";
            this.pRequisicao.NM_ProcDeletar = "";
            this.pRequisicao.NM_ProcGravar = "";
            this.pRequisicao.Size = new System.Drawing.Size(1009, 462);
            this.pRequisicao.TabIndex = 0;
            // 
            // gRequisicao
            // 
            this.gRequisicao.AllowUserToAddRows = false;
            this.gRequisicao.AllowUserToDeleteRows = false;
            this.gRequisicao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gRequisicao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gRequisicao.AutoGenerateColumns = false;
            this.gRequisicao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gRequisicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gRequisicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRequisicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gRequisicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gRequisicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idrequisicaoDataGridViewTextBoxColumn,
            this.dtrequisicaostrDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.qtdaprovadaDataGridViewTextBoxColumn,
            this.Qtd_almox,
            this.Sd_retirar_almox,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.nmcliforrequisitanteDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gRequisicao.DataSource = this.bsRequisicao;
            this.gRequisicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRequisicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gRequisicao.Location = new System.Drawing.Point(0, 20);
            this.gRequisicao.Name = "gRequisicao";
            this.gRequisicao.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gRequisicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gRequisicao.RowHeadersWidth = 23;
            this.gRequisicao.Size = new System.Drawing.Size(1007, 415);
            this.gRequisicao.TabIndex = 6;
            this.gRequisicao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gRequisicao_ColumnHeaderMouseClick);
            this.gRequisicao.DoubleClick += new System.EventHandler(this.gRequisicao_DoubleClick);
            // 
            // idrequisicaoDataGridViewTextBoxColumn
            // 
            this.idrequisicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idrequisicaoDataGridViewTextBoxColumn.DataPropertyName = "Id_requisicao";
            this.idrequisicaoDataGridViewTextBoxColumn.HeaderText = "Id. Requisição";
            this.idrequisicaoDataGridViewTextBoxColumn.Name = "idrequisicaoDataGridViewTextBoxColumn";
            this.idrequisicaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtrequisicaostrDataGridViewTextBoxColumn
            // 
            this.dtrequisicaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtrequisicaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_requisicaostr";
            this.dtrequisicaostrDataGridViewTextBoxColumn.HeaderText = "Dt. Requisição";
            this.dtrequisicaostrDataGridViewTextBoxColumn.Name = "dtrequisicaostrDataGridViewTextBoxColumn";
            this.dtrequisicaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtrequisicaostrDataGridViewTextBoxColumn.Width = 102;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // qtdaprovadaDataGridViewTextBoxColumn
            // 
            this.qtdaprovadaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdaprovadaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_aprovada";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.qtdaprovadaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtdaprovadaDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.qtdaprovadaDataGridViewTextBoxColumn.Name = "qtdaprovadaDataGridViewTextBoxColumn";
            this.qtdaprovadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdaprovadaDataGridViewTextBoxColumn.Width = 87;
            // 
            // Qtd_almox
            // 
            this.Qtd_almox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qtd_almox.DataPropertyName = "Qtd_almox";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.Qtd_almox.DefaultCellStyle = dataGridViewCellStyle4;
            this.Qtd_almox.HeaderText = "Qtd. Retirada";
            this.Qtd_almox.Name = "Qtd_almox";
            this.Qtd_almox.ReadOnly = true;
            this.Qtd_almox.Width = 95;
            // 
            // Sd_retirar_almox
            // 
            this.Sd_retirar_almox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sd_retirar_almox.DataPropertyName = "Sd_retirar_almox";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = "0";
            this.Sd_retirar_almox.DefaultCellStyle = dataGridViewCellStyle5;
            this.Sd_retirar_almox.HeaderText = "Saldo Retirar";
            this.Sd_retirar_almox.Name = "Sd_retirar_almox";
            this.Sd_retirar_almox.ReadOnly = true;
            this.Sd_retirar_almox.Width = 93;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.HeaderText = "UND";
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaunidadeDataGridViewTextBoxColumn.Width = 56;
            // 
            // nmcliforrequisitanteDataGridViewTextBoxColumn
            // 
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor_requisitante";
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.HeaderText = "Requisitante";
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.Name = "nmcliforrequisitanteDataGridViewTextBoxColumn";
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforrequisitanteDataGridViewTextBoxColumn.Width = 91;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
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
            // bsRequisicao
            // 
            this.bsRequisicao.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_Requisicao);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsRequisicao;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 435);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1007, 25);
            this.bindingNavigator1.TabIndex = 7;
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
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1007, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "REQUISIÇÕES DISPONIVEIS - (DUPLO CLICK PARA PROCESSAR REQUISIÇÃO)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(label6);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(label5);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.bb_requisitante);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.cd_requisitante);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.id_requisicao);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1009, 56);
            this.pFiltro.TabIndex = 1;
            // 
            // dt_fin
            // 
            this.dt_fin.Location = new System.Drawing.Point(444, 30);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(72, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 8;
            // 
            // dt_ini
            // 
            this.dt_ini.Location = new System.Drawing.Point(444, 4);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(72, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 7;
            // 
            // bb_requisitante
            // 
            this.bb_requisitante.BackColor = System.Drawing.SystemColors.Control;
            this.bb_requisitante.Image = ((System.Drawing.Image)(resources.GetObject("bb_requisitante.Image")));
            this.bb_requisitante.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_requisitante.Location = new System.Drawing.Point(363, 30);
            this.bb_requisitante.Name = "bb_requisitante";
            this.bb_requisitante.Size = new System.Drawing.Size(28, 19);
            this.bb_requisitante.TabIndex = 6;
            this.bb_requisitante.UseVisualStyleBackColor = false;
            this.bb_requisitante.Click += new System.EventHandler(this.bb_requisitante_Click);
            // 
            // cd_requisitante
            // 
            this.cd_requisitante.BackColor = System.Drawing.SystemColors.Window;
            this.cd_requisitante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_requisitante.Location = new System.Drawing.Point(262, 30);
            this.cd_requisitante.Name = "cd_requisitante";
            this.cd_requisitante.NM_Alias = "";
            this.cd_requisitante.NM_Campo = "cd_clifor";
            this.cd_requisitante.NM_CampoBusca = "cd_clifor";
            this.cd_requisitante.NM_Param = "@P_CD_EMPRESA";
            this.cd_requisitante.QTD_Zero = 0;
            this.cd_requisitante.Size = new System.Drawing.Size(100, 20);
            this.cd_requisitante.ST_AutoInc = false;
            this.cd_requisitante.ST_DisableAuto = false;
            this.cd_requisitante.ST_Float = false;
            this.cd_requisitante.ST_Gravar = true;
            this.cd_requisitante.ST_Int = false;
            this.cd_requisitante.ST_LimpaCampo = true;
            this.cd_requisitante.ST_NotNull = true;
            this.cd_requisitante.ST_PrimaryKey = false;
            this.cd_requisitante.TabIndex = 5;
            this.cd_requisitante.Leave += new System.EventHandler(this.cd_requisitante_Leave);
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(363, 4);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 4;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Location = new System.Drawing.Point(262, 4);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(100, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 3;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(153, 30);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 2;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(90, 30);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(61, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 1;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Requisição:";
            // 
            // id_requisicao
            // 
            this.id_requisicao.BackColor = System.Drawing.SystemColors.Window;
            this.id_requisicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_requisicao.Location = new System.Drawing.Point(90, 4);
            this.id_requisicao.Name = "id_requisicao";
            this.id_requisicao.NM_Alias = "";
            this.id_requisicao.NM_Campo = "";
            this.id_requisicao.NM_CampoBusca = "";
            this.id_requisicao.NM_Param = "";
            this.id_requisicao.QTD_Zero = 0;
            this.id_requisicao.Size = new System.Drawing.Size(91, 20);
            this.id_requisicao.ST_AutoInc = false;
            this.id_requisicao.ST_DisableAuto = false;
            this.id_requisicao.ST_Float = false;
            this.id_requisicao.ST_Gravar = false;
            this.id_requisicao.ST_Int = false;
            this.id_requisicao.ST_LimpaCampo = true;
            this.id_requisicao.ST_NotNull = false;
            this.id_requisicao.ST_PrimaryKey = false;
            this.id_requisicao.TabIndex = 0;
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1019, 39);
            this.barraMenu.TabIndex = 13;
            // 
            // BB_Buscar
            // 
            this.BB_Buscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(84, 36);
            this.BB_Buscar.Text = "(F7)\r\n Buscar";
            this.BB_Buscar.ToolTipText = "Buscar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 36);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // TFMovRequisicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 575);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFMovRequisicao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisiçoes retirada material Almoxarifado";
            this.Load += new System.EventHandler(this.TFMovRequisicao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFMovRequisicao_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFMovRequisicao_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pRequisicao.ResumeLayout(false);
            this.pRequisicao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pRequisicao;
        private System.Windows.Forms.Label label4;
        private Componentes.DataGridDefault gRequisicao;
        private System.Windows.Forms.BindingSource bsRequisicao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pFiltro;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_requisicao;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_requisitante;
        private Componentes.EditDefault cd_requisitante;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditData dt_fin;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrequisicaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtrequisicaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdaprovadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_almox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sd_retirar_almox;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforrequisitanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
    }
}