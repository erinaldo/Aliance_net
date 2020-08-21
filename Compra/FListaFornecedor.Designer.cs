namespace Compra
{
    partial class TFListaFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaFornecedor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.gItens = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cdfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarionegociadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdporcompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdmincompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailvendedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneFaxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNm_contato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrdiasvigenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.bnItens = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.pMotivo = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_motivoaprovarreprovar = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnItens)).BeginInit();
            this.bnItens.SuspendLayout();
            this.pMotivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AccessibleDescription = null;
            this.BB_Gravar.AccessibleName = null;
            resources.ApplyResources(this.BB_Gravar, "BB_Gravar");
            this.BB_Gravar.BackgroundImage = null;
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AccessibleDescription = null;
            this.BB_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.BB_Cancelar, "BB_Cancelar");
            this.BB_Cancelar.BackgroundImage = null;
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pGrid, 0, 0);
            this.tlpCentral.Controls.Add(this.pMotivo, 0, 1);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pGrid
            // 
            this.pGrid.AccessibleDescription = null;
            this.pGrid.AccessibleName = null;
            resources.ApplyResources(this.pGrid, "pGrid");
            this.pGrid.BackgroundImage = null;
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.gItens);
            this.pGrid.Controls.Add(this.bnItens);
            this.pGrid.Font = null;
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            // 
            // gItens
            // 
            this.gItens.AccessibleDescription = null;
            this.gItens.AccessibleName = null;
            this.gItens.AllowUserToAddRows = false;
            this.gItens.AllowUserToDeleteRows = false;
            this.gItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gItens, "gItens");
            this.gItens.AutoGenerateColumns = false;
            this.gItens.BackgroundColor = System.Drawing.Color.LightGray;
            this.gItens.BackgroundImage = null;
            this.gItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.cdfornecedorDataGridViewTextBoxColumn,
            this.nmfornecedorDataGridViewTextBoxColumn,
            this.vlunitarionegociadoDataGridViewTextBoxColumn,
            this.qtdporcompraDataGridViewTextBoxColumn,
            this.qtdmincompraDataGridViewTextBoxColumn,
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.dscondpgtoDataGridViewTextBoxColumn,
            this.nmvendedorDataGridViewTextBoxColumn,
            this.emailvendedorDataGridViewTextBoxColumn,
            this.foneFaxDataGridViewTextBoxColumn,
            this.pNm_contato,
            this.nrdiasvigenciaDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn1});
            this.gItens.DataSource = this.bsItens;
            this.gItens.Font = null;
            this.gItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItens.Name = "gItens";
            this.gItens.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gItens.DoubleClick += new System.EventHandler(this.gItens_DoubleClick);
            this.gItens.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gItens_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            resources.ApplyResources(this.St_processar, "St_processar");
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            // 
            // cdfornecedorDataGridViewTextBoxColumn
            // 
            this.cdfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.cdfornecedorDataGridViewTextBoxColumn, "cdfornecedorDataGridViewTextBoxColumn");
            this.cdfornecedorDataGridViewTextBoxColumn.Name = "cdfornecedorDataGridViewTextBoxColumn";
            this.cdfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmfornecedorDataGridViewTextBoxColumn
            // 
            this.nmfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.nmfornecedorDataGridViewTextBoxColumn, "nmfornecedorDataGridViewTextBoxColumn");
            this.nmfornecedorDataGridViewTextBoxColumn.Name = "nmfornecedorDataGridViewTextBoxColumn";
            this.nmfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarionegociadoDataGridViewTextBoxColumn
            // 
            this.vlunitarionegociadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarionegociadoDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario_negociado";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlunitarionegociadoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.vlunitarionegociadoDataGridViewTextBoxColumn, "vlunitarionegociadoDataGridViewTextBoxColumn");
            this.vlunitarionegociadoDataGridViewTextBoxColumn.Name = "vlunitarionegociadoDataGridViewTextBoxColumn";
            this.vlunitarionegociadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdporcompraDataGridViewTextBoxColumn
            // 
            this.qtdporcompraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdporcompraDataGridViewTextBoxColumn.DataPropertyName = "Qtd_porcompra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.qtdporcompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.qtdporcompraDataGridViewTextBoxColumn, "qtdporcompraDataGridViewTextBoxColumn");
            this.qtdporcompraDataGridViewTextBoxColumn.Name = "qtdporcompraDataGridViewTextBoxColumn";
            this.qtdporcompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdmincompraDataGridViewTextBoxColumn
            // 
            this.qtdmincompraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdmincompraDataGridViewTextBoxColumn.DataPropertyName = "Qtd_min_compra";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.qtdmincompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.qtdmincompraDataGridViewTextBoxColumn, "qtdmincompraDataGridViewTextBoxColumn");
            this.qtdmincompraDataGridViewTextBoxColumn.Name = "qtdmincompraDataGridViewTextBoxColumn";
            this.qtdmincompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.cdcondpgtoDataGridViewTextBoxColumn, "cdcondpgtoDataGridViewTextBoxColumn");
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscondpgtoDataGridViewTextBoxColumn
            // 
            this.dscondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Ds_condpgto";
            resources.ApplyResources(this.dscondpgtoDataGridViewTextBoxColumn, "dscondpgtoDataGridViewTextBoxColumn");
            this.dscondpgtoDataGridViewTextBoxColumn.Name = "dscondpgtoDataGridViewTextBoxColumn";
            this.dscondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nmvendedorDataGridViewTextBoxColumn
            // 
            this.nmvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmvendedorDataGridViewTextBoxColumn.DataPropertyName = "Nm_vendedor";
            resources.ApplyResources(this.nmvendedorDataGridViewTextBoxColumn, "nmvendedorDataGridViewTextBoxColumn");
            this.nmvendedorDataGridViewTextBoxColumn.Name = "nmvendedorDataGridViewTextBoxColumn";
            this.nmvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailvendedorDataGridViewTextBoxColumn
            // 
            this.emailvendedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.emailvendedorDataGridViewTextBoxColumn.DataPropertyName = "Email_vendedor";
            resources.ApplyResources(this.emailvendedorDataGridViewTextBoxColumn, "emailvendedorDataGridViewTextBoxColumn");
            this.emailvendedorDataGridViewTextBoxColumn.Name = "emailvendedorDataGridViewTextBoxColumn";
            this.emailvendedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foneFaxDataGridViewTextBoxColumn
            // 
            this.foneFaxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneFaxDataGridViewTextBoxColumn.DataPropertyName = "FoneFax";
            resources.ApplyResources(this.foneFaxDataGridViewTextBoxColumn, "foneFaxDataGridViewTextBoxColumn");
            this.foneFaxDataGridViewTextBoxColumn.Name = "foneFaxDataGridViewTextBoxColumn";
            this.foneFaxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pNm_contato
            // 
            this.pNm_contato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pNm_contato.DataPropertyName = "Nm_contato";
            resources.ApplyResources(this.pNm_contato, "pNm_contato");
            this.pNm_contato.Name = "pNm_contato";
            this.pNm_contato.ReadOnly = true;
            // 
            // nrdiasvigenciaDataGridViewTextBoxColumn
            // 
            this.nrdiasvigenciaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrdiasvigenciaDataGridViewTextBoxColumn.DataPropertyName = "Nr_diasvigencia";
            resources.ApplyResources(this.nrdiasvigenciaDataGridViewTextBoxColumn, "nrdiasvigenciaDataGridViewTextBoxColumn");
            this.nrdiasvigenciaDataGridViewTextBoxColumn.Name = "nrdiasvigenciaDataGridViewTextBoxColumn";
            this.nrdiasvigenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn1
            // 
            this.dsobservacaoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn1, "dsobservacaoDataGridViewTextBoxColumn1");
            this.dsobservacaoDataGridViewTextBoxColumn1.Name = "dsobservacaoDataGridViewTextBoxColumn1";
            this.dsobservacaoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bsItens
            // 
            this.bsItens.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_NegociacaoItem);
            // 
            // bnItens
            // 
            this.bnItens.AccessibleDescription = null;
            this.bnItens.AccessibleName = null;
            this.bnItens.AddNewItem = null;
            resources.ApplyResources(this.bnItens, "bnItens");
            this.bnItens.BackgroundImage = null;
            this.bnItens.BindingSource = this.bsItens;
            this.bnItens.CountItem = this.bindingNavigatorCountItem1;
            this.bnItens.DeleteItem = null;
            this.bnItens.Font = null;
            this.bnItens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.bnItens.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bnItens.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bnItens.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bnItens.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bnItens.Name = "bnItens";
            this.bnItens.PositionItem = this.bindingNavigatorPositionItem1;
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.AccessibleDescription = null;
            this.bindingNavigatorCountItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem1, "bindingNavigatorCountItem1");
            this.bindingNavigatorCountItem1.BackgroundImage = null;
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem1, "bindingNavigatorMoveFirstItem1");
            this.bindingNavigatorMoveFirstItem1.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem1, "bindingNavigatorMovePreviousItem1");
            this.bindingNavigatorMovePreviousItem1.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.AccessibleDescription = null;
            this.bindingNavigatorSeparator2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem1, "bindingNavigatorPositionItem1");
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.AccessibleDescription = null;
            this.bindingNavigatorSeparator3.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator3, "bindingNavigatorSeparator3");
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem1, "bindingNavigatorMoveNextItem1");
            this.bindingNavigatorMoveNextItem1.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem1, "bindingNavigatorMoveLastItem1");
            this.bindingNavigatorMoveLastItem1.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            // 
            // pMotivo
            // 
            this.pMotivo.AccessibleDescription = null;
            this.pMotivo.AccessibleName = null;
            resources.ApplyResources(this.pMotivo, "pMotivo");
            this.pMotivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pMotivo.BackgroundImage = null;
            this.pMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMotivo.Controls.Add(this.label1);
            this.pMotivo.Controls.Add(this.ds_motivoaprovarreprovar);
            this.pMotivo.Font = null;
            this.pMotivo.Name = "pMotivo";
            this.pMotivo.NM_ProcDeletar = "";
            this.pMotivo.NM_ProcGravar = "";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ds_motivoaprovarreprovar
            // 
            this.ds_motivoaprovarreprovar.AccessibleDescription = null;
            this.ds_motivoaprovarreprovar.AccessibleName = null;
            resources.ApplyResources(this.ds_motivoaprovarreprovar, "ds_motivoaprovarreprovar");
            this.ds_motivoaprovarreprovar.BackColor = System.Drawing.SystemColors.Window;
            this.ds_motivoaprovarreprovar.BackgroundImage = null;
            this.ds_motivoaprovarreprovar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_motivoaprovarreprovar.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItens, "Ds_aprovarreprovar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_motivoaprovarreprovar.Font = null;
            this.ds_motivoaprovarreprovar.Name = "ds_motivoaprovarreprovar";
            this.ds_motivoaprovarreprovar.NM_Alias = "";
            this.ds_motivoaprovarreprovar.NM_Campo = "";
            this.ds_motivoaprovarreprovar.NM_CampoBusca = "";
            this.ds_motivoaprovarreprovar.NM_Param = "";
            this.ds_motivoaprovarreprovar.QTD_Zero = 0;
            this.ds_motivoaprovarreprovar.ST_AutoInc = false;
            this.ds_motivoaprovarreprovar.ST_DisableAuto = false;
            this.ds_motivoaprovarreprovar.ST_Float = false;
            this.ds_motivoaprovarreprovar.ST_Gravar = true;
            this.ds_motivoaprovarreprovar.ST_Int = false;
            this.ds_motivoaprovarreprovar.ST_LimpaCampo = true;
            this.ds_motivoaprovarreprovar.ST_NotNull = false;
            this.ds_motivoaprovarreprovar.ST_PrimaryKey = false;
            // 
            // TFListaFornecedor
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaFornecedor";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFListaFornecedor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFListaFornecedor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaFornecedor_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnItens)).EndInit();
            this.bnItens.ResumeLayout(false);
            this.bnItens.PerformLayout();
            this.pMotivo.ResumeLayout(false);
            this.pMotivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private System.Windows.Forms.BindingSource bsItens;
        private Componentes.DataGridDefault gItens;
        private System.Windows.Forms.BindingNavigator bnItens;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipofreteDataGridViewTextBoxColumn;
        private Componentes.PanelDados pMotivo;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_motivoaprovarreprovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn prazoentregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarionegociadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdporcompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdmincompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneFaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNm_contato;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdiasvigenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn1;
    }
}