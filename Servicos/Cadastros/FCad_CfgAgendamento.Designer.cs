namespace Servicos.Cadastros
{
    partial class TFCad_CfgAgendamento
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label cD_TabelaPrecoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_CfgAgendamento));
            System.Windows.Forms.Label label1;
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsCfgAgendamento = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_tabelapreco = new Componentes.EditDefault(this.components);
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.bb_tabpreco = new System.Windows.Forms.Button();
            this.tp_ordem = new Componentes.EditDefault(this.components);
            this.ds_tipoordem = new Componentes.EditDefault(this.components);
            this.bb_tpordem = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpordemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstipoordemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtabelaprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstabelaprecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cD_TabelaPrecoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgAgendamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.cd_tabelapreco);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.bb_tabpreco);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.tp_ordem);
            this.pDados.Controls.Add(this.ds_tipoordem);
            this.pDados.Controls.Add(this.bb_tpordem);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(cD_TabelaPrecoLabel);
            this.pDados.Size = new System.Drawing.Size(659, 124);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(13, 60);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(63, 13);
            label3.TabIndex = 45;
            label3.Text = "Tab. Preço:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(11, 34);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 13);
            label2.TabIndex = 43;
            label2.Text = "Tipo Ordem:";
            // 
            // cD_TabelaPrecoLabel
            // 
            cD_TabelaPrecoLabel.AutoSize = true;
            cD_TabelaPrecoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            cD_TabelaPrecoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cD_TabelaPrecoLabel.Location = new System.Drawing.Point(25, 8);
            cD_TabelaPrecoLabel.Name = "cD_TabelaPrecoLabel";
            cD_TabelaPrecoLabel.Size = new System.Drawing.Size(51, 13);
            cD_TabelaPrecoLabel.TabIndex = 41;
            cD_TabelaPrecoLabel.Text = "Empresa:";
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
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.tpordemDataGridViewTextBoxColumn,
            this.dstipoordemDataGridViewTextBoxColumn,
            this.cdtabelaprecoDataGridViewTextBoxColumn,
            this.dstabelaprecoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridDefault1.DataSource = this.bsCfgAgendamento;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 124);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 211);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsCfgAgendamento
            // 
            this.bsCfgAgendamento.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_CfgAgendamento);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCfgAgendamento;
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
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Registro Anterior";
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
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Ultimo Registro";
            // 
            // cd_tabelapreco
            // 
            this.cd_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Cd_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_tabelapreco.Enabled = false;
            this.cd_tabelapreco.Location = new System.Drawing.Point(82, 58);
            this.cd_tabelapreco.Name = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Alias = "a";
            this.cd_tabelapreco.NM_Campo = "cd_tabelapreco";
            this.cd_tabelapreco.NM_CampoBusca = "cd_tabelapreco";
            this.cd_tabelapreco.NM_Param = "@P_CD_TABELAPRECO";
            this.cd_tabelapreco.QTD_Zero = 0;
            this.cd_tabelapreco.Size = new System.Drawing.Size(57, 20);
            this.cd_tabelapreco.ST_AutoInc = false;
            this.cd_tabelapreco.ST_DisableAuto = false;
            this.cd_tabelapreco.ST_Float = false;
            this.cd_tabelapreco.ST_Gravar = true;
            this.cd_tabelapreco.ST_Int = true;
            this.cd_tabelapreco.ST_LimpaCampo = true;
            this.cd_tabelapreco.ST_NotNull = false;
            this.cd_tabelapreco.ST_PrimaryKey = false;
            this.cd_tabelapreco.TabIndex = 4;
            this.cd_tabelapreco.TextOld = null;
            this.cd_tabelapreco.Leave += new System.EventHandler(this.cd_tabelapreco_Leave);
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Ds_tabelapreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Location = new System.Drawing.Point(178, 58);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "b";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.Size = new System.Drawing.Size(439, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 46;
            this.ds_tabelapreco.TextOld = null;
            // 
            // bb_tabpreco
            // 
            this.bb_tabpreco.Enabled = false;
            this.bb_tabpreco.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tabpreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabpreco.Image")));
            this.bb_tabpreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabpreco.Location = new System.Drawing.Point(140, 58);
            this.bb_tabpreco.Name = "bb_tabpreco";
            this.bb_tabpreco.Size = new System.Drawing.Size(32, 20);
            this.bb_tabpreco.TabIndex = 5;
            this.bb_tabpreco.UseVisualStyleBackColor = true;
            this.bb_tabpreco.Click += new System.EventHandler(this.bb_tabpreco_Click);
            // 
            // tp_ordem
            // 
            this.tp_ordem.BackColor = System.Drawing.SystemColors.Window;
            this.tp_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Tp_ordemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_ordem.Enabled = false;
            this.tp_ordem.Location = new System.Drawing.Point(82, 32);
            this.tp_ordem.Name = "tp_ordem";
            this.tp_ordem.NM_Alias = "a";
            this.tp_ordem.NM_Campo = "tp_ordem";
            this.tp_ordem.NM_CampoBusca = "tp_ordem";
            this.tp_ordem.NM_Param = "@P_CD_TABELAPRECO";
            this.tp_ordem.QTD_Zero = 0;
            this.tp_ordem.Size = new System.Drawing.Size(57, 20);
            this.tp_ordem.ST_AutoInc = false;
            this.tp_ordem.ST_DisableAuto = false;
            this.tp_ordem.ST_Float = false;
            this.tp_ordem.ST_Gravar = true;
            this.tp_ordem.ST_Int = true;
            this.tp_ordem.ST_LimpaCampo = true;
            this.tp_ordem.ST_NotNull = true;
            this.tp_ordem.ST_PrimaryKey = false;
            this.tp_ordem.TabIndex = 2;
            this.tp_ordem.TextOld = null;
            this.tp_ordem.Leave += new System.EventHandler(this.tp_ordem_Leave);
            // 
            // ds_tipoordem
            // 
            this.ds_tipoordem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipoordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Ds_tipoordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tipoordem.Enabled = false;
            this.ds_tipoordem.Location = new System.Drawing.Point(178, 32);
            this.ds_tipoordem.Name = "ds_tipoordem";
            this.ds_tipoordem.NM_Alias = "b";
            this.ds_tipoordem.NM_Campo = "ds_tipoordem";
            this.ds_tipoordem.NM_CampoBusca = "ds_tipoordem";
            this.ds_tipoordem.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tipoordem.QTD_Zero = 0;
            this.ds_tipoordem.Size = new System.Drawing.Size(439, 20);
            this.ds_tipoordem.ST_AutoInc = false;
            this.ds_tipoordem.ST_DisableAuto = false;
            this.ds_tipoordem.ST_Float = false;
            this.ds_tipoordem.ST_Gravar = false;
            this.ds_tipoordem.ST_Int = false;
            this.ds_tipoordem.ST_LimpaCampo = true;
            this.ds_tipoordem.ST_NotNull = false;
            this.ds_tipoordem.ST_PrimaryKey = false;
            this.ds_tipoordem.TabIndex = 44;
            this.ds_tipoordem.TextOld = null;
            // 
            // bb_tpordem
            // 
            this.bb_tpordem.Enabled = false;
            this.bb_tpordem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpordem.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpordem.Image")));
            this.bb_tpordem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpordem.Location = new System.Drawing.Point(140, 32);
            this.bb_tpordem.Name = "bb_tpordem";
            this.bb_tpordem.Size = new System.Drawing.Size(32, 20);
            this.bb_tpordem.TabIndex = 3;
            this.bb_tpordem.UseVisualStyleBackColor = true;
            this.bb_tpordem.Click += new System.EventHandler(this.bb_tpordem_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(82, 6);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "a";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_TABELAPRECO";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(57, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
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
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(178, 6);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "b";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_TABELAPRECO";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(439, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 42;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Enabled = false;
            this.bb_empresa.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(140, 6);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(32, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.SystemColors.Window;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Enabled = false;
            this.cd_local.Location = new System.Drawing.Point(82, 84);
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "a";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_TABELAPRECO";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(57, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = true;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = false;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 6;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCfgAgendamento, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(178, 84);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "b";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(439, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 50;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.Enabled = false;
            this.bb_local.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(140, 84);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(32, 20);
            this.bb_local.TabIndex = 7;
            this.bb_local.UseVisualStyleBackColor = true;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(13, 86);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 49;
            label1.Text = "Local. Arm.:";
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
            // tpordemDataGridViewTextBoxColumn
            // 
            this.tpordemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpordemDataGridViewTextBoxColumn.DataPropertyName = "Tp_ordem";
            this.tpordemDataGridViewTextBoxColumn.HeaderText = "TP. Ordem";
            this.tpordemDataGridViewTextBoxColumn.Name = "tpordemDataGridViewTextBoxColumn";
            this.tpordemDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpordemDataGridViewTextBoxColumn.Width = 83;
            // 
            // dstipoordemDataGridViewTextBoxColumn
            // 
            this.dstipoordemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstipoordemDataGridViewTextBoxColumn.DataPropertyName = "Ds_tipoordem";
            this.dstipoordemDataGridViewTextBoxColumn.HeaderText = "Tipo Ordem Serviço";
            this.dstipoordemDataGridViewTextBoxColumn.Name = "dstipoordemDataGridViewTextBoxColumn";
            this.dstipoordemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstipoordemDataGridViewTextBoxColumn.Width = 115;
            // 
            // cdtabelaprecoDataGridViewTextBoxColumn
            // 
            this.cdtabelaprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdtabelaprecoDataGridViewTextBoxColumn.DataPropertyName = "Cd_tabelapreco";
            this.cdtabelaprecoDataGridViewTextBoxColumn.HeaderText = "Cd. Tabela Preço";
            this.cdtabelaprecoDataGridViewTextBoxColumn.Name = "cdtabelaprecoDataGridViewTextBoxColumn";
            this.cdtabelaprecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdtabelaprecoDataGridViewTextBoxColumn.Width = 106;
            // 
            // dstabelaprecoDataGridViewTextBoxColumn
            // 
            this.dstabelaprecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstabelaprecoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tabelapreco";
            this.dstabelaprecoDataGridViewTextBoxColumn.HeaderText = "Tabela Preço";
            this.dstabelaprecoDataGridViewTextBoxColumn.Name = "dstabelaprecoDataGridViewTextBoxColumn";
            this.dstabelaprecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstabelaprecoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_local";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Local";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 71;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_local";
            this.dataGridViewTextBoxColumn2.HeaderText = "Local Armazenagem";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 117;
            // 
            // TFCad_CfgAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCad_CfgAgendamento";
            this.Text = "Configuração Agendamento";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCfgAgendamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCfgAgendamento;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault cd_tabelapreco;
        private Componentes.EditDefault ds_tabelapreco;
        private Componentes.EditDefault tp_ordem;
        private Componentes.EditDefault ds_tipoordem;
        private System.Windows.Forms.Button bb_tpordem;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Button bb_tabpreco;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipoordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtabelaprecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstabelaprecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
