namespace Faturamento.Cadastros
{
    partial class FCadCFGComissao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadCFGComissao));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCFGComissao = new System.Windows.Forms.BindingSource(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdhistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dshistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.bb_duplicata = new System.Windows.Forms.Button();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_docto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGComissao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.cd_condpgto);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(this.tp_docto);
            this.pDados.Controls.Add(this.ds_tpdocto);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.bb_docto);
            this.pDados.Controls.Add(this.tp_duplicata);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.bb_duplicata);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Size = new System.Drawing.Size(842, 132);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(852, 438);
            // 
            // tpPadrao
            // 
            this.tpPadrao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(844, 412);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.tpduplicataDataGridViewTextBoxColumn,
            this.dstpduplicataDataGridViewTextBoxColumn,
            this.tpdoctoDataGridViewTextBoxColumn,
            this.dstpdoctoDataGridViewTextBoxColumn,
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.dscondpgtoDataGridViewTextBoxColumn,
            this.cdhistoricoDataGridViewTextBoxColumn,
            this.dshistoricoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsCFGComissao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 132);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(842, 253);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsCFGComissao
            // 
            this.bsCFGComissao.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_CFGComissao);
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
            // tpduplicataDataGridViewTextBoxColumn
            // 
            this.tpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Tp_duplicata";
            this.tpduplicataDataGridViewTextBoxColumn.HeaderText = "TP. Duplicata";
            this.tpduplicataDataGridViewTextBoxColumn.Name = "tpduplicataDataGridViewTextBoxColumn";
            this.tpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpduplicataDataGridViewTextBoxColumn.Width = 97;
            // 
            // dstpduplicataDataGridViewTextBoxColumn
            // 
            this.dstpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpduplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.HeaderText = "Tipo Duplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.Name = "dstpduplicataDataGridViewTextBoxColumn";
            this.dstpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpduplicataDataGridViewTextBoxColumn.Width = 101;
            // 
            // tpdoctoDataGridViewTextBoxColumn
            // 
            this.tpdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Tp_docto";
            this.tpdoctoDataGridViewTextBoxColumn.HeaderText = "TP. Docto";
            this.tpdoctoDataGridViewTextBoxColumn.Name = "tpdoctoDataGridViewTextBoxColumn";
            this.tpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpdoctoDataGridViewTextBoxColumn.Width = 81;
            // 
            // dstpdoctoDataGridViewTextBoxColumn
            // 
            this.dstpdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpdocto";
            this.dstpdoctoDataGridViewTextBoxColumn.HeaderText = "Tipo Documento";
            this.dstpdoctoDataGridViewTextBoxColumn.Name = "dstpdoctoDataGridViewTextBoxColumn";
            this.dstpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpdoctoDataGridViewTextBoxColumn.Width = 102;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            this.cdcondpgtoDataGridViewTextBoxColumn.HeaderText = "Cd. CondPgto";
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcondpgtoDataGridViewTextBoxColumn.Width = 90;
            // 
            // dscondpgtoDataGridViewTextBoxColumn
            // 
            this.dscondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Ds_condpgto";
            this.dscondpgtoDataGridViewTextBoxColumn.HeaderText = "Condição Pagamento";
            this.dscondpgtoDataGridViewTextBoxColumn.Name = "dscondpgtoDataGridViewTextBoxColumn";
            this.dscondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscondpgtoDataGridViewTextBoxColumn.Width = 123;
            // 
            // cdhistoricoDataGridViewTextBoxColumn
            // 
            this.cdhistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricoDataGridViewTextBoxColumn.DataPropertyName = "Cd_historico";
            this.cdhistoricoDataGridViewTextBoxColumn.HeaderText = "Cd. Historico";
            this.cdhistoricoDataGridViewTextBoxColumn.Name = "cdhistoricoDataGridViewTextBoxColumn";
            this.cdhistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdhistoricoDataGridViewTextBoxColumn.Width = 85;
            // 
            // dshistoricoDataGridViewTextBoxColumn
            // 
            this.dshistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dshistoricoDataGridViewTextBoxColumn.DataPropertyName = "Ds_historico";
            this.dshistoricoDataGridViewTextBoxColumn.HeaderText = "Historico";
            this.dshistoricoDataGridViewTextBoxColumn.Name = "dshistoricoDataGridViewTextBoxColumn";
            this.dshistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dshistoricoDataGridViewTextBoxColumn.Width = 73;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCFGComissao;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 385);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(842, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(107, 3);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(210, 2);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(442, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 45;
            this.nm_empresa.TextOld = null;
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(50, 6);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 44;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(177, 2);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.Color.White;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Enabled = false;
            this.tp_duplicata.Location = new System.Drawing.Point(107, 29);
            this.tp_duplicata.MaxLength = 4;
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CD_EMPRESA";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(67, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = false;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = true;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 2;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Location = new System.Drawing.Point(210, 28);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.Size = new System.Drawing.Size(442, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 49;
            this.ds_tpduplicata.TextOld = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(22, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(79, 13);
            label1.TabIndex = 48;
            label1.Text = "Tipo Duplicata:";
            // 
            // bb_duplicata
            // 
            this.bb_duplicata.BackColor = System.Drawing.SystemColors.Control;
            this.bb_duplicata.Enabled = false;
            this.bb_duplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_duplicata.Image")));
            this.bb_duplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_duplicata.Location = new System.Drawing.Point(177, 28);
            this.bb_duplicata.Name = "bb_duplicata";
            this.bb_duplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_duplicata.TabIndex = 3;
            this.bb_duplicata.UseVisualStyleBackColor = false;
            this.bb_duplicata.Click += new System.EventHandler(this.bb_duplicata_Click);
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.Color.White;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Tp_doctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Enabled = false;
            this.tp_docto.Location = new System.Drawing.Point(107, 55);
            this.tp_docto.MaxLength = 4;
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "";
            this.tp_docto.NM_Campo = "tp_docto";
            this.tp_docto.NM_CampoBusca = "tp_docto";
            this.tp_docto.NM_Param = "@P_CD_EMPRESA";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(67, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = false;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = true;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 4;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Location = new System.Drawing.Point(210, 54);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_NM_EMPRESA";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.Size = new System.Drawing.Size(442, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 53;
            this.ds_tpdocto.TextOld = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(12, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 52;
            label2.Text = "Tipo Documento:";
            // 
            // bb_docto
            // 
            this.bb_docto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_docto.Enabled = false;
            this.bb_docto.Image = ((System.Drawing.Image)(resources.GetObject("bb_docto.Image")));
            this.bb_docto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_docto.Location = new System.Drawing.Point(177, 54);
            this.bb_docto.Name = "bb_docto";
            this.bb_docto.Size = new System.Drawing.Size(28, 19);
            this.bb_docto.TabIndex = 5;
            this.bb_docto.UseVisualStyleBackColor = false;
            this.bb_docto.Click += new System.EventHandler(this.bb_docto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.Color.White;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_condpgto.Enabled = false;
            this.cd_condpgto.Location = new System.Drawing.Point(107, 81);
            this.cd_condpgto.MaxLength = 4;
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_EMPRESA";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.Size = new System.Drawing.Size(67, 20);
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = false;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = true;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TabIndex = 6;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Location = new System.Drawing.Point(210, 80);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "@P_NM_EMPRESA";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.Size = new System.Drawing.Size(442, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 57;
            this.ds_condpgto.TextOld = null;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(6, 84);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(95, 13);
            label3.TabIndex = 56;
            label3.Text = "Cond. Pagamento:";
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_condpgto.Enabled = false;
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(177, 80);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(28, 19);
            this.bb_condpgto.TabIndex = 7;
            this.bb_condpgto.UseVisualStyleBackColor = false;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.Color.White;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Enabled = false;
            this.cd_historico.Location = new System.Drawing.Point(107, 107);
            this.cd_historico.MaxLength = 4;
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_EMPRESA";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(67, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 8;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGComissao, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(210, 106);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_NM_EMPRESA";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(442, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 61;
            this.ds_historico.TextOld = null;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(50, 110);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 13);
            label4.TabIndex = 60;
            label4.Text = "Historico:";
            // 
            // bb_historico
            // 
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.Enabled = false;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(177, 106);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(28, 19);
            this.bb_historico.TabIndex = 9;
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // FCadCFGComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(852, 481);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadCFGComissao";
            this.Load += new System.EventHandler(this.FCadCFGComissao_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGComissao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCFGComissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dshistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault tp_duplicata;
        private Componentes.EditDefault ds_tpduplicata;
        private System.Windows.Forms.Button bb_duplicata;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_historico;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault cd_condpgto;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault tp_docto;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_docto;
    }
}
