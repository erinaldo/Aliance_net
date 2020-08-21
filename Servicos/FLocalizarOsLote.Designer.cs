namespace Servicos
{
    partial class FLocalizarOsLote
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
            System.Windows.Forms.Label cd_EmpresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLocalizarOsLote));
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.dataGridDefault3 = new Componentes.DataGridDefault(this.components);
            this.St_Lote = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsOs = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inic = new Componentes.EditData(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BB_Clifor_Busca = new System.Windows.Forms.Button();
            this.CD_Clifor_Busca = new Componentes.EditDefault(this.components);
            this.label42 = new System.Windows.Forms.Label();
            this.BB_Produto_Busca = new System.Windows.Forms.Button();
            this.CD_Produto_Busca = new Componentes.EditDefault(this.components);
            this.label39 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_tpordem = new System.Windows.Forms.Button();
            this.tp_ordem = new Componentes.EditDefault(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            cd_EmpresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tlpCentral.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cd_EmpresaLabel
            // 
            cd_EmpresaLabel.AccessibleDescription = null;
            cd_EmpresaLabel.AccessibleName = null;
            resources.ApplyResources(cd_EmpresaLabel, "cd_EmpresaLabel");
            cd_EmpresaLabel.Name = "cd_EmpresaLabel";
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pGrid, 0, 1);
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
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
            this.pGrid.Controls.Add(this.dataGridDefault3);
            this.pGrid.Controls.Add(this.bindingNavigator1);
            this.pGrid.Font = null;
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            // 
            // dataGridDefault3
            // 
            this.dataGridDefault3.AccessibleDescription = null;
            this.dataGridDefault3.AccessibleName = null;
            this.dataGridDefault3.AllowUserToAddRows = false;
            this.dataGridDefault3.AllowUserToDeleteRows = false;
            this.dataGridDefault3.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridDefault3, "dataGridDefault3");
            this.dataGridDefault3.AutoGenerateColumns = false;
            this.dataGridDefault3.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault3.BackgroundImage = null;
            this.dataGridDefault3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_Lote,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.dataGridDefault3.DataSource = this.bsOs;
            this.dataGridDefault3.Font = null;
            this.dataGridDefault3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault3.Name = "dataGridDefault3";
            this.dataGridDefault3.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault3.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault3_CellClick);
            // 
            // St_Lote
            // 
            this.St_Lote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_Lote.DataPropertyName = "St_Lote";
            resources.ApplyResources(this.St_Lote, "St_Lote");
            this.St_Lote.Name = "St_Lote";
            this.St_Lote.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id_os";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nr_serial";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CD_ProdutoOS";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DS_ProdutoOS";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "DS_Equipamento";
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DS_Modelo";
            resources.ApplyResources(this.dataGridViewTextBoxColumn15, "dataGridViewTextBoxColumn15");
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "ST_EquipamentoGarantia_Bool";
            resources.ApplyResources(this.dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Nr_osorigem";
            resources.ApplyResources(this.dataGridViewTextBoxColumn16, "dataGridViewTextBoxColumn16");
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Ds_defeitocliente";
            resources.ApplyResources(this.dataGridViewTextBoxColumn17, "dataGridViewTextBoxColumn17");
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // bsOs
            // 
            this.bsOs.DataSource = typeof(CamadaDados.Servicos.TList_LanServico);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsOs;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // pFiltro
            // 
            this.pFiltro.AccessibleDescription = null;
            this.pFiltro.AccessibleName = null;
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.BackgroundImage = null;
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.panelDados6);
            this.pFiltro.Controls.Add(this.BB_Clifor_Busca);
            this.pFiltro.Controls.Add(this.CD_Clifor_Busca);
            this.pFiltro.Controls.Add(this.label42);
            this.pFiltro.Controls.Add(this.BB_Produto_Busca);
            this.pFiltro.Controls.Add(this.CD_Produto_Busca);
            this.pFiltro.Controls.Add(this.label39);
            this.pFiltro.Controls.Add(this.nm_empresa);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.bb_tpordem);
            this.pFiltro.Controls.Add(cd_EmpresaLabel);
            this.pFiltro.Controls.Add(this.tp_ordem);
            this.pFiltro.Font = null;
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // panelDados6
            // 
            this.panelDados6.AccessibleDescription = null;
            this.panelDados6.AccessibleName = null;
            resources.ApplyResources(this.panelDados6, "panelDados6");
            this.panelDados6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados6.BackgroundImage = null;
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados6.Controls.Add(this.DT_Final);
            this.panelDados6.Controls.Add(this.DT_Inic);
            this.panelDados6.Controls.Add(this.label13);
            this.panelDados6.Controls.Add(this.label15);
            this.panelDados6.Font = null;
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            // 
            // DT_Final
            // 
            this.DT_Final.AccessibleDescription = null;
            this.DT_Final.AccessibleName = null;
            resources.ApplyResources(this.DT_Final, "DT_Final");
            this.DT_Final.BackgroundImage = null;
            this.DT_Final.Font = null;
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "DT_NascFirma";
            this.DT_Final.NM_CampoBusca = "DT_NascFirma";
            this.DT_Final.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Final.Operador = "";
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            // 
            // DT_Inic
            // 
            this.DT_Inic.AccessibleDescription = null;
            this.DT_Inic.AccessibleName = null;
            resources.ApplyResources(this.DT_Inic, "DT_Inic");
            this.DT_Inic.BackgroundImage = null;
            this.DT_Inic.Font = null;
            this.DT_Inic.Name = "DT_Inic";
            this.DT_Inic.NM_Alias = "";
            this.DT_Inic.NM_Campo = "DT_NascFirma";
            this.DT_Inic.NM_CampoBusca = "DT_NascFirma";
            this.DT_Inic.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Inic.Operador = "";
            this.DT_Inic.ST_Gravar = true;
            this.DT_Inic.ST_LimpaCampo = true;
            this.DT_Inic.ST_NotNull = false;
            this.DT_Inic.ST_PrimaryKey = false;
            // 
            // label13
            // 
            this.label13.AccessibleDescription = null;
            this.label13.AccessibleName = null;
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label15
            // 
            this.label15.AccessibleDescription = null;
            this.label15.AccessibleName = null;
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // BB_Clifor_Busca
            // 
            this.BB_Clifor_Busca.AccessibleDescription = null;
            this.BB_Clifor_Busca.AccessibleName = null;
            resources.ApplyResources(this.BB_Clifor_Busca, "BB_Clifor_Busca");
            this.BB_Clifor_Busca.BackgroundImage = null;
            this.BB_Clifor_Busca.Font = null;
            this.BB_Clifor_Busca.Name = "BB_Clifor_Busca";
            this.BB_Clifor_Busca.UseVisualStyleBackColor = true;
            this.BB_Clifor_Busca.Click += new System.EventHandler(this.BB_Clifor_Busca_Click);
            // 
            // CD_Clifor_Busca
            // 
            this.CD_Clifor_Busca.AccessibleDescription = null;
            this.CD_Clifor_Busca.AccessibleName = null;
            resources.ApplyResources(this.CD_Clifor_Busca, "CD_Clifor_Busca");
            this.CD_Clifor_Busca.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor_Busca.BackgroundImage = null;
            this.CD_Clifor_Busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor_Busca.Name = "CD_Clifor_Busca";
            this.CD_Clifor_Busca.NM_Alias = "";
            this.CD_Clifor_Busca.NM_Campo = "CD_Clifor";
            this.CD_Clifor_Busca.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor_Busca.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor_Busca.QTD_Zero = 0;
            this.CD_Clifor_Busca.ST_AutoInc = false;
            this.CD_Clifor_Busca.ST_DisableAuto = false;
            this.CD_Clifor_Busca.ST_Float = false;
            this.CD_Clifor_Busca.ST_Gravar = true;
            this.CD_Clifor_Busca.ST_Int = true;
            this.CD_Clifor_Busca.ST_LimpaCampo = true;
            this.CD_Clifor_Busca.ST_NotNull = false;
            this.CD_Clifor_Busca.ST_PrimaryKey = false;
            this.CD_Clifor_Busca.Leave += new System.EventHandler(this.CD_Clifor_Busca_Leave);
            // 
            // label42
            // 
            this.label42.AccessibleDescription = null;
            this.label42.AccessibleName = null;
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // BB_Produto_Busca
            // 
            this.BB_Produto_Busca.AccessibleDescription = null;
            this.BB_Produto_Busca.AccessibleName = null;
            resources.ApplyResources(this.BB_Produto_Busca, "BB_Produto_Busca");
            this.BB_Produto_Busca.BackgroundImage = null;
            this.BB_Produto_Busca.Font = null;
            this.BB_Produto_Busca.Name = "BB_Produto_Busca";
            this.BB_Produto_Busca.UseVisualStyleBackColor = true;
            this.BB_Produto_Busca.Click += new System.EventHandler(this.BB_Produto_Busca_Click);
            // 
            // CD_Produto_Busca
            // 
            this.CD_Produto_Busca.AccessibleDescription = null;
            this.CD_Produto_Busca.AccessibleName = null;
            resources.ApplyResources(this.CD_Produto_Busca, "CD_Produto_Busca");
            this.CD_Produto_Busca.BackColor = System.Drawing.Color.White;
            this.CD_Produto_Busca.BackgroundImage = null;
            this.CD_Produto_Busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto_Busca.Name = "CD_Produto_Busca";
            this.CD_Produto_Busca.NM_Alias = "";
            this.CD_Produto_Busca.NM_Campo = "CD_Produto";
            this.CD_Produto_Busca.NM_CampoBusca = "CD_Produto";
            this.CD_Produto_Busca.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto_Busca.QTD_Zero = 0;
            this.CD_Produto_Busca.ST_AutoInc = false;
            this.CD_Produto_Busca.ST_DisableAuto = false;
            this.CD_Produto_Busca.ST_Float = false;
            this.CD_Produto_Busca.ST_Gravar = true;
            this.CD_Produto_Busca.ST_Int = true;
            this.CD_Produto_Busca.ST_LimpaCampo = true;
            this.CD_Produto_Busca.ST_NotNull = false;
            this.CD_Produto_Busca.ST_PrimaryKey = false;
            this.CD_Produto_Busca.Leave += new System.EventHandler(this.CD_Produto_Busca_Leave);
            // 
            // label39
            // 
            this.label39.AccessibleDescription = null;
            this.label39.AccessibleName = null;
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // nm_empresa
            // 
            this.nm_empresa.AccessibleDescription = null;
            this.nm_empresa.AccessibleName = null;
            resources.ApplyResources(this.nm_empresa, "nm_empresa");
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BackgroundImage = null;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Font = null;
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "ds_tipoordem";
            this.nm_empresa.NM_CampoBusca = "ds_tipoordem";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            // 
            // cd_empresa
            // 
            this.cd_empresa.AccessibleDescription = null;
            this.cd_empresa.AccessibleName = null;
            resources.ApplyResources(this.cd_empresa, "cd_empresa");
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BackgroundImage = null;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = null;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "tp_ordem";
            this.cd_empresa.NM_CampoBusca = "tp_ordem";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            // 
            // bb_tpordem
            // 
            this.bb_tpordem.AccessibleDescription = null;
            this.bb_tpordem.AccessibleName = null;
            resources.ApplyResources(this.bb_tpordem, "bb_tpordem");
            this.bb_tpordem.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpordem.BackgroundImage = null;
            this.bb_tpordem.Font = null;
            this.bb_tpordem.Name = "bb_tpordem";
            this.bb_tpordem.UseVisualStyleBackColor = false;
            this.bb_tpordem.Click += new System.EventHandler(this.bb_tpordem_Click);
            // 
            // tp_ordem
            // 
            this.tp_ordem.AccessibleDescription = null;
            this.tp_ordem.AccessibleName = null;
            resources.ApplyResources(this.tp_ordem, "tp_ordem");
            this.tp_ordem.BackColor = System.Drawing.Color.White;
            this.tp_ordem.BackgroundImage = null;
            this.tp_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_ordem.Font = null;
            this.tp_ordem.Name = "tp_ordem";
            this.tp_ordem.NM_Alias = "";
            this.tp_ordem.NM_Campo = "tp_ordem";
            this.tp_ordem.NM_CampoBusca = "tp_ordem";
            this.tp_ordem.NM_Param = "@P_CD_EMPRESA";
            this.tp_ordem.QTD_Zero = 0;
            this.tp_ordem.ST_AutoInc = false;
            this.tp_ordem.ST_DisableAuto = false;
            this.tp_ordem.ST_Float = false;
            this.tp_ordem.ST_Gravar = true;
            this.tp_ordem.ST_Int = true;
            this.tp_ordem.ST_LimpaCampo = true;
            this.tp_ordem.ST_NotNull = true;
            this.tp_ordem.ST_PrimaryKey = false;
            this.tp_ordem.Leave += new System.EventHandler(this.tp_ordem_Leave);
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.BB_Buscar});
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
            // BB_Buscar
            // 
            this.BB_Buscar.AccessibleDescription = null;
            this.BB_Buscar.AccessibleName = null;
            resources.ApplyResources(this.BB_Buscar, "BB_Buscar");
            this.BB_Buscar.BackgroundImage = null;
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // FLocalizarOsLote
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
            this.Name = "FLocalizarOsLote";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FLocalizarOsLote_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLocalizarOsLote_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FLocalizarOsLote_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pGrid;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bsOs;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.DataGridDefault dataGridDefault3;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Button bb_tpordem;
        private Componentes.EditDefault tp_ordem;
        private Componentes.EditDefault nm_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button BB_Produto_Busca;
        private Componentes.EditDefault CD_Produto_Busca;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button BB_Clifor_Busca;
        private Componentes.EditDefault CD_Clifor_Busca;
        private System.Windows.Forms.Label label42;
        private Componentes.PanelDados panelDados6;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_Lote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    }
}