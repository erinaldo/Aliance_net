namespace Financeiro.Cadastros
{
    partial class TFCadCidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCidade));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_CD_Cidade = new System.Windows.Forms.Label();
            this.LB_DS_Cidade = new System.Windows.Forms.Label();
            this.LB_UF = new System.Windows.Forms.Label();
            this.CD_Cidade = new Componentes.EditDefault(this.components);
            this.bsCidade = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Cidade = new Componentes.EditDefault(this.components);
            this.UF = new Componentes.EditDefault(this.components);
            this.ds_uf = new Componentes.EditDefault(this.components);
            this.bb_uf = new System.Windows.Forms.Button();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.BS_Navigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.cdcidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distritoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcidadeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscidadeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distritoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gCidade = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_uf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).BeginInit();
            this.BS_Navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCidade)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_uf);
            this.pDados.Controls.Add(this.ds_uf);
            this.pDados.Controls.Add(this.LB_CD_Cidade);
            this.pDados.Controls.Add(this.LB_DS_Cidade);
            this.pDados.Controls.Add(this.LB_UF);
            this.pDados.Controls.Add(this.CD_Cidade);
            this.pDados.Controls.Add(this.DS_Cidade);
            this.pDados.Controls.Add(this.UF);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_CIDADE";
            this.pDados.NM_ProcGravar = "IA_FIN_CIDADE";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.Add(this.gCidade);
            this.tpPadrao.Controls.Add(this.BS_Navigator);
            this.tpPadrao.Controls.SetChildIndex(this.BS_Navigator, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCidade, 0);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "Cd_cidade";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_cidade";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Distrito";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Uf";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // LB_CD_Cidade
            // 
            resources.ApplyResources(this.LB_CD_Cidade, "LB_CD_Cidade");
            this.LB_CD_Cidade.Name = "LB_CD_Cidade";
            // 
            // LB_DS_Cidade
            // 
            resources.ApplyResources(this.LB_DS_Cidade, "LB_DS_Cidade");
            this.LB_DS_Cidade.Name = "LB_DS_Cidade";
            // 
            // LB_UF
            // 
            resources.ApplyResources(this.LB_UF, "LB_UF");
            this.LB_UF.Name = "LB_UF";
            // 
            // CD_Cidade
            // 
            this.CD_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCidade, "Cd_cidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Cidade, "CD_Cidade");
            this.CD_Cidade.Name = "CD_Cidade";
            this.CD_Cidade.NM_Alias = "";
            this.CD_Cidade.NM_Campo = "CD_Cidade";
            this.CD_Cidade.NM_CampoBusca = "CD_Cidade";
            this.CD_Cidade.NM_Param = "@P_CD_CIDADE";
            this.CD_Cidade.QTD_Zero = 0;
            this.CD_Cidade.ST_AutoInc = false;
            this.CD_Cidade.ST_DisableAuto = true;
            this.CD_Cidade.ST_Float = false;
            this.CD_Cidade.ST_Gravar = true;
            this.CD_Cidade.ST_Int = false;
            this.CD_Cidade.ST_LimpaCampo = true;
            this.CD_Cidade.ST_NotNull = true;
            this.CD_Cidade.ST_PrimaryKey = true;
            this.CD_Cidade.TextOld = null;
            // 
            // bsCidade
            // 
            this.bsCidade.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TRegistro_CadCidade);
            // 
            // DS_Cidade
            // 
            this.DS_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCidade, "Ds_cidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Cidade, "DS_Cidade");
            this.DS_Cidade.Name = "DS_Cidade";
            this.DS_Cidade.NM_Alias = "";
            this.DS_Cidade.NM_Campo = "DS_Cidade";
            this.DS_Cidade.NM_CampoBusca = "DS_Cidade";
            this.DS_Cidade.NM_Param = "@P_DS_CIDADE";
            this.DS_Cidade.QTD_Zero = 0;
            this.DS_Cidade.ST_AutoInc = false;
            this.DS_Cidade.ST_DisableAuto = false;
            this.DS_Cidade.ST_Float = false;
            this.DS_Cidade.ST_Gravar = true;
            this.DS_Cidade.ST_Int = false;
            this.DS_Cidade.ST_LimpaCampo = true;
            this.DS_Cidade.ST_NotNull = true;
            this.DS_Cidade.ST_PrimaryKey = false;
            this.DS_Cidade.TextOld = null;
            // 
            // UF
            // 
            this.UF.BackColor = System.Drawing.SystemColors.Window;
            this.UF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCidade, "Cd_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.UF, "UF");
            this.UF.Name = "UF";
            this.UF.NM_Alias = "a";
            this.UF.NM_Campo = "CD_UF";
            this.UF.NM_CampoBusca = "CD_UF";
            this.UF.NM_Param = "@P_CD_UF";
            this.UF.QTD_Zero = 0;
            this.UF.ST_AutoInc = false;
            this.UF.ST_DisableAuto = false;
            this.UF.ST_Float = false;
            this.UF.ST_Gravar = true;
            this.UF.ST_Int = false;
            this.UF.ST_LimpaCampo = true;
            this.UF.ST_NotNull = false;
            this.UF.ST_PrimaryKey = false;
            this.UF.TextOld = null;
            this.UF.Leave += new System.EventHandler(this.UF_Leave);
            // 
            // ds_uf
            // 
            this.ds_uf.BackColor = System.Drawing.Color.White;
            this.ds_uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCidade, "Ds_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_uf, "ds_uf");
            this.ds_uf.Name = "ds_uf";
            this.ds_uf.NM_Alias = "";
            this.ds_uf.NM_Campo = "DS_UF";
            this.ds_uf.NM_CampoBusca = "DS_UF";
            this.ds_uf.NM_Param = "@P_UF";
            this.ds_uf.QTD_Zero = 0;
            this.ds_uf.ST_AutoInc = false;
            this.ds_uf.ST_DisableAuto = false;
            this.ds_uf.ST_Float = false;
            this.ds_uf.ST_Gravar = false;
            this.ds_uf.ST_Int = false;
            this.ds_uf.ST_LimpaCampo = true;
            this.ds_uf.ST_NotNull = false;
            this.ds_uf.ST_PrimaryKey = false;
            this.ds_uf.TextOld = null;
            // 
            // bb_uf
            // 
            resources.ApplyResources(this.bb_uf, "bb_uf");
            this.bb_uf.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_uf.Name = "bb_uf";
            this.bb_uf.UseVisualStyleBackColor = true;
            this.bb_uf.Click += new System.EventHandler(this.bb_uf_Click);
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // BS_Navigator
            // 
            this.BS_Navigator.AddNewItem = null;
            this.BS_Navigator.BindingSource = this.bsCidade;
            this.BS_Navigator.CountItem = this.bindingNavigatorCountItem;
            this.BS_Navigator.CountItemFormat = "de {0}";
            this.BS_Navigator.DeleteItem = null;
            resources.ApplyResources(this.BS_Navigator, "BS_Navigator");
            this.BS_Navigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BS_Navigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BS_Navigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BS_Navigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BS_Navigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BS_Navigator.Name = "BS_Navigator";
            this.BS_Navigator.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // cdcidadeDataGridViewTextBoxColumn
            // 
            this.cdcidadeDataGridViewTextBoxColumn.DataPropertyName = "Cd_cidade";
            resources.ApplyResources(this.cdcidadeDataGridViewTextBoxColumn, "cdcidadeDataGridViewTextBoxColumn");
            this.cdcidadeDataGridViewTextBoxColumn.Name = "cdcidadeDataGridViewTextBoxColumn";
            this.cdcidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscidadeDataGridViewTextBoxColumn
            // 
            this.dscidadeDataGridViewTextBoxColumn.DataPropertyName = "Ds_cidade";
            resources.ApplyResources(this.dscidadeDataGridViewTextBoxColumn, "dscidadeDataGridViewTextBoxColumn");
            this.dscidadeDataGridViewTextBoxColumn.Name = "dscidadeDataGridViewTextBoxColumn";
            this.dscidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distritoDataGridViewTextBoxColumn
            // 
            this.distritoDataGridViewTextBoxColumn.DataPropertyName = "Distrito";
            resources.ApplyResources(this.distritoDataGridViewTextBoxColumn, "distritoDataGridViewTextBoxColumn");
            this.distritoDataGridViewTextBoxColumn.Name = "distritoDataGridViewTextBoxColumn";
            this.distritoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stregistroDataGridViewTextBoxColumn
            // 
            this.stregistroDataGridViewTextBoxColumn.DataPropertyName = "St_registro";
            resources.ApplyResources(this.stregistroDataGridViewTextBoxColumn, "stregistroDataGridViewTextBoxColumn");
            this.stregistroDataGridViewTextBoxColumn.Name = "stregistroDataGridViewTextBoxColumn";
            this.stregistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ufDataGridViewTextBoxColumn
            // 
            this.ufDataGridViewTextBoxColumn.DataPropertyName = "Uf";
            resources.ApplyResources(this.ufDataGridViewTextBoxColumn, "ufDataGridViewTextBoxColumn");
            this.ufDataGridViewTextBoxColumn.Name = "ufDataGridViewTextBoxColumn";
            this.ufDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcidadeDataGridViewTextBoxColumn1
            // 
            this.cdcidadeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcidadeDataGridViewTextBoxColumn1.DataPropertyName = "Cd_cidade";
            resources.ApplyResources(this.cdcidadeDataGridViewTextBoxColumn1, "cdcidadeDataGridViewTextBoxColumn1");
            this.cdcidadeDataGridViewTextBoxColumn1.Name = "cdcidadeDataGridViewTextBoxColumn1";
            this.cdcidadeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dscidadeDataGridViewTextBoxColumn1
            // 
            this.dscidadeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscidadeDataGridViewTextBoxColumn1.DataPropertyName = "Ds_cidade";
            resources.ApplyResources(this.dscidadeDataGridViewTextBoxColumn1, "dscidadeDataGridViewTextBoxColumn1");
            this.dscidadeDataGridViewTextBoxColumn1.Name = "dscidadeDataGridViewTextBoxColumn1";
            this.dscidadeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // distritoDataGridViewTextBoxColumn1
            // 
            this.distritoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.distritoDataGridViewTextBoxColumn1.DataPropertyName = "Distrito";
            resources.ApplyResources(this.distritoDataGridViewTextBoxColumn1, "distritoDataGridViewTextBoxColumn1");
            this.distritoDataGridViewTextBoxColumn1.Name = "distritoDataGridViewTextBoxColumn1";
            this.distritoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // ufDataGridViewTextBoxColumn1
            // 
            this.ufDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ufDataGridViewTextBoxColumn1.DataPropertyName = "Uf";
            resources.ApplyResources(this.ufDataGridViewTextBoxColumn1, "ufDataGridViewTextBoxColumn1");
            this.ufDataGridViewTextBoxColumn1.Name = "ufDataGridViewTextBoxColumn1";
            this.ufDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // gCidade
            // 
            this.gCidade.AllowUserToAddRows = false;
            this.gCidade.AllowUserToDeleteRows = false;
            this.gCidade.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCidade.AutoGenerateColumns = false;
            this.gCidade.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCidade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCidade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.Cd_uf,
            this.dataGridViewTextBoxColumn7});
            this.gCidade.DataSource = this.bsCidade;
            resources.ApplyResources(this.gCidade, "gCidade");
            this.gCidade.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCidade.Name = "gCidade";
            this.gCidade.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCidade.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCidade.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gCidade_ColumnHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Cd_cidade";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ds_cidade";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Cd_uf
            // 
            this.Cd_uf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_uf.DataPropertyName = "Cd_uf";
            resources.ApplyResources(this.Cd_uf, "Cd_uf");
            this.Cd_uf.Name = "Cd_uf";
            this.Cd_uf.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Ds_uf";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // TFCadCidade
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadCidade";
            this.Load += new System.EventHandler(this.TFCadCidade_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCidade_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).EndInit();
            this.BS_Navigator.ResumeLayout(false);
            this.BS_Navigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        //- 
        private System.Windows.Forms.Label LB_CD_Cidade;
        private System.Windows.Forms.Label LB_DS_Cidade;
        private System.Windows.Forms.Label LB_UF;




        ////- 
        private Componentes.EditDefault CD_Cidade;
        private Componentes.EditDefault DS_Cidade;
        private Componentes.EditDefault UF;
        private Componentes.EditDefault ds_uf;
        public System.Windows.Forms.Button bb_uf;
        private System.Windows.Forms.BindingNavigator BS_Navigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distritoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcidadeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscidadeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn distritoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufDataGridViewTextBoxColumn1;
        private Componentes.DataGridDefault gCidade;
        private System.Windows.Forms.BindingSource bsCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_uf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;




        //- 
    }
}
