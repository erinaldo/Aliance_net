namespace Fiscal.Cadastros
{
    partial class TFCadCMI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCMI));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdcmiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscmiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpmovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stmestraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stdevolucaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stcomplementarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stgeraestoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.stsimplesremessaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_retornobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BS_CMI = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_CMI = new System.Windows.Forms.Label();
            this.LB_TP_Duplicata = new System.Windows.Forms.Label();
            this.LB_Tp_Docto = new System.Windows.Forms.Label();
            this.LB_DS_CMI = new System.Windows.Forms.Label();
            this.LB_CD_CondPGTO = new System.Windows.Forms.Label();
            this.CD_CMI = new Componentes.EditDefault(this.components);
            this.TP_Duplicata = new Componentes.EditDefault(this.components);
            this.Tp_Docto = new Componentes.EditDefault(this.components);
            this.DS_CMI = new Componentes.EditDefault(this.components);
            this.ST_Mestra = new Componentes.CheckBoxDefault(this.components);
            this.ST_Devolucao = new Componentes.CheckBoxDefault(this.components);
            this.ST_Complementar = new Componentes.CheckBoxDefault(this.components);
            this.ST_GeraEstoque = new Componentes.CheckBoxDefault(this.components);
            this.ST_SimplesRemessa = new Componentes.CheckBoxDefault(this.components);
            this.CD_CondPGTO = new Componentes.EditDefault(this.components);
            this.bb_duplicata = new System.Windows.Forms.Button();
            this.bbDocto = new System.Windows.Forms.Button();
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.ds_tpDocto = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.st_retorno = new Componentes.CheckBoxDefault(this.components);
            this.st_compdevimposto = new Componentes.CheckBoxDefault(this.components);
            this.BN_CMI = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CMI)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.panelDados3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CMI)).BeginInit();
            this.BN_CMI.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.ds_tpDocto);
            this.pDados.Controls.Add(this.bbDocto);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(this.bb_duplicata);
            this.pDados.Controls.Add(this.LB_CD_CMI);
            this.pDados.Controls.Add(this.LB_TP_Duplicata);
            this.pDados.Controls.Add(this.LB_Tp_Docto);
            this.pDados.Controls.Add(this.LB_DS_CMI);
            this.pDados.Controls.Add(this.LB_CD_CondPGTO);
            this.pDados.Controls.Add(this.CD_CMI);
            this.pDados.Controls.Add(this.TP_Duplicata);
            this.pDados.Controls.Add(this.Tp_Docto);
            this.pDados.Controls.Add(this.DS_CMI);
            this.pDados.Controls.Add(this.CD_CondPGTO);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_CMI";
            this.pDados.NM_ProcGravar = "IA_FIS_CMI";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.BN_CMI);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.BN_CMI, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcmiDataGridViewTextBoxColumn,
            this.dscmiDataGridViewTextBoxColumn,
            this.tpduplicataDataGridViewTextBoxColumn,
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.tpdoctoDataGridViewTextBoxColumn,
            this.tpmovimentoDataGridViewTextBoxColumn,
            this.stmestraDataGridViewTextBoxColumn,
            this.stdevolucaoDataGridViewTextBoxColumn,
            this.stcomplementarDataGridViewTextBoxColumn,
            this.stgeraestoqueDataGridViewTextBoxColumn,
            this.stsimplesremessaDataGridViewTextBoxColumn,
            this.St_retornobool});
            this.gCadastro.DataSource = this.BS_CMI;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gCadastro.TabStop = false;
            this.gCadastro.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gCadastro_ColumnHeaderMouseClick);
            // 
            // cdcmiDataGridViewTextBoxColumn
            // 
            this.cdcmiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcmiDataGridViewTextBoxColumn.DataPropertyName = "Cd_cmi";
            resources.ApplyResources(this.cdcmiDataGridViewTextBoxColumn, "cdcmiDataGridViewTextBoxColumn");
            this.cdcmiDataGridViewTextBoxColumn.Name = "cdcmiDataGridViewTextBoxColumn";
            this.cdcmiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dscmiDataGridViewTextBoxColumn
            // 
            this.dscmiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscmiDataGridViewTextBoxColumn.DataPropertyName = "Ds_cmi";
            resources.ApplyResources(this.dscmiDataGridViewTextBoxColumn, "dscmiDataGridViewTextBoxColumn");
            this.dscmiDataGridViewTextBoxColumn.Name = "dscmiDataGridViewTextBoxColumn";
            this.dscmiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpduplicataDataGridViewTextBoxColumn
            // 
            this.tpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Tp_duplicata";
            resources.ApplyResources(this.tpduplicataDataGridViewTextBoxColumn, "tpduplicataDataGridViewTextBoxColumn");
            this.tpduplicataDataGridViewTextBoxColumn.Name = "tpduplicataDataGridViewTextBoxColumn";
            this.tpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.cdcondpgtoDataGridViewTextBoxColumn, "cdcondpgtoDataGridViewTextBoxColumn");
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpdoctoDataGridViewTextBoxColumn
            // 
            this.tpdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpdoctoDataGridViewTextBoxColumn.DataPropertyName = "Tp_docto";
            resources.ApplyResources(this.tpdoctoDataGridViewTextBoxColumn, "tpdoctoDataGridViewTextBoxColumn");
            this.tpdoctoDataGridViewTextBoxColumn.Name = "tpdoctoDataGridViewTextBoxColumn";
            this.tpdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpmovimentoDataGridViewTextBoxColumn
            // 
            this.tpmovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpmovimentoDataGridViewTextBoxColumn.DataPropertyName = "Tp_movimento";
            resources.ApplyResources(this.tpmovimentoDataGridViewTextBoxColumn, "tpmovimentoDataGridViewTextBoxColumn");
            this.tpmovimentoDataGridViewTextBoxColumn.Name = "tpmovimentoDataGridViewTextBoxColumn";
            this.tpmovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stmestraDataGridViewTextBoxColumn
            // 
            this.stmestraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stmestraDataGridViewTextBoxColumn.DataPropertyName = "St_mestrabool";
            resources.ApplyResources(this.stmestraDataGridViewTextBoxColumn, "stmestraDataGridViewTextBoxColumn");
            this.stmestraDataGridViewTextBoxColumn.Name = "stmestraDataGridViewTextBoxColumn";
            this.stmestraDataGridViewTextBoxColumn.ReadOnly = true;
            this.stmestraDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stmestraDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // stdevolucaoDataGridViewTextBoxColumn
            // 
            this.stdevolucaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdevolucaoDataGridViewTextBoxColumn.DataPropertyName = "St_devolucaobool";
            resources.ApplyResources(this.stdevolucaoDataGridViewTextBoxColumn, "stdevolucaoDataGridViewTextBoxColumn");
            this.stdevolucaoDataGridViewTextBoxColumn.Name = "stdevolucaoDataGridViewTextBoxColumn";
            this.stdevolucaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.stdevolucaoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stdevolucaoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // stcomplementarDataGridViewTextBoxColumn
            // 
            this.stcomplementarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stcomplementarDataGridViewTextBoxColumn.DataPropertyName = "St_complementarbool";
            resources.ApplyResources(this.stcomplementarDataGridViewTextBoxColumn, "stcomplementarDataGridViewTextBoxColumn");
            this.stcomplementarDataGridViewTextBoxColumn.Name = "stcomplementarDataGridViewTextBoxColumn";
            this.stcomplementarDataGridViewTextBoxColumn.ReadOnly = true;
            this.stcomplementarDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stcomplementarDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // stgeraestoqueDataGridViewTextBoxColumn
            // 
            this.stgeraestoqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stgeraestoqueDataGridViewTextBoxColumn.DataPropertyName = "St_geraestoquebool";
            resources.ApplyResources(this.stgeraestoqueDataGridViewTextBoxColumn, "stgeraestoqueDataGridViewTextBoxColumn");
            this.stgeraestoqueDataGridViewTextBoxColumn.Name = "stgeraestoqueDataGridViewTextBoxColumn";
            this.stgeraestoqueDataGridViewTextBoxColumn.ReadOnly = true;
            this.stgeraestoqueDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stgeraestoqueDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // stsimplesremessaDataGridViewTextBoxColumn
            // 
            this.stsimplesremessaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stsimplesremessaDataGridViewTextBoxColumn.DataPropertyName = "St_simplesremessabool";
            resources.ApplyResources(this.stsimplesremessaDataGridViewTextBoxColumn, "stsimplesremessaDataGridViewTextBoxColumn");
            this.stsimplesremessaDataGridViewTextBoxColumn.Name = "stsimplesremessaDataGridViewTextBoxColumn";
            this.stsimplesremessaDataGridViewTextBoxColumn.ReadOnly = true;
            this.stsimplesremessaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.stsimplesremessaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // St_retornobool
            // 
            this.St_retornobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_retornobool.DataPropertyName = "St_retornobool";
            resources.ApplyResources(this.St_retornobool, "St_retornobool");
            this.St_retornobool.Name = "St_retornobool";
            this.St_retornobool.ReadOnly = true;
            // 
            // BS_CMI
            // 
            this.BS_CMI.DataSource = typeof(CamadaDados.Fiscal.TList_CadCMI);
            // 
            // LB_CD_CMI
            // 
            resources.ApplyResources(this.LB_CD_CMI, "LB_CD_CMI");
            this.LB_CD_CMI.Name = "LB_CD_CMI";
            // 
            // LB_TP_Duplicata
            // 
            resources.ApplyResources(this.LB_TP_Duplicata, "LB_TP_Duplicata");
            this.LB_TP_Duplicata.Name = "LB_TP_Duplicata";
            // 
            // LB_Tp_Docto
            // 
            resources.ApplyResources(this.LB_Tp_Docto, "LB_Tp_Docto");
            this.LB_Tp_Docto.Name = "LB_Tp_Docto";
            // 
            // LB_DS_CMI
            // 
            resources.ApplyResources(this.LB_DS_CMI, "LB_DS_CMI");
            this.LB_DS_CMI.Name = "LB_DS_CMI";
            // 
            // LB_CD_CondPGTO
            // 
            resources.ApplyResources(this.LB_CD_CondPGTO, "LB_CD_CondPGTO");
            this.LB_CD_CondPGTO.Name = "LB_CD_CondPGTO";
            // 
            // CD_CMI
            // 
            this.CD_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "Cd_cmiString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_CMI, "CD_CMI");
            this.CD_CMI.Name = "CD_CMI";
            this.CD_CMI.NM_Alias = "";
            this.CD_CMI.NM_Campo = "CD_CMI";
            this.CD_CMI.NM_CampoBusca = "CD_CMI";
            this.CD_CMI.NM_Param = "@P_CD_CMI";
            this.CD_CMI.QTD_Zero = 0;
            this.CD_CMI.ST_AutoInc = false;
            this.CD_CMI.ST_DisableAuto = true;
            this.CD_CMI.ST_Float = false;
            this.CD_CMI.ST_Gravar = true;
            this.CD_CMI.ST_Int = true;
            this.CD_CMI.ST_LimpaCampo = true;
            this.CD_CMI.ST_NotNull = true;
            this.CD_CMI.ST_PrimaryKey = true;
            this.CD_CMI.TextOld = null;
            // 
            // TP_Duplicata
            // 
            this.TP_Duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.TP_Duplicata, "TP_Duplicata");
            this.TP_Duplicata.Name = "TP_Duplicata";
            this.TP_Duplicata.NM_Alias = "a";
            this.TP_Duplicata.NM_Campo = "TP_Duplicata";
            this.TP_Duplicata.NM_CampoBusca = "TP_Duplicata";
            this.TP_Duplicata.NM_Param = "@P_TP_DUPLICATA";
            this.TP_Duplicata.QTD_Zero = 0;
            this.TP_Duplicata.ST_AutoInc = false;
            this.TP_Duplicata.ST_DisableAuto = false;
            this.TP_Duplicata.ST_Float = false;
            this.TP_Duplicata.ST_Gravar = true;
            this.TP_Duplicata.ST_Int = true;
            this.TP_Duplicata.ST_LimpaCampo = true;
            this.TP_Duplicata.ST_NotNull = false;
            this.TP_Duplicata.ST_PrimaryKey = false;
            this.TP_Duplicata.TextOld = null;
            this.TP_Duplicata.Leave += new System.EventHandler(this.TP_Duplicata_Leave);
            // 
            // Tp_Docto
            // 
            this.Tp_Docto.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_Docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tp_Docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_Docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "Tp_doctostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Tp_Docto, "Tp_Docto");
            this.Tp_Docto.Name = "Tp_Docto";
            this.Tp_Docto.NM_Alias = "a";
            this.Tp_Docto.NM_Campo = "Tp_Docto";
            this.Tp_Docto.NM_CampoBusca = "Tp_Docto";
            this.Tp_Docto.NM_Param = "@P_TP_DOCTO";
            this.Tp_Docto.QTD_Zero = 0;
            this.Tp_Docto.ST_AutoInc = false;
            this.Tp_Docto.ST_DisableAuto = false;
            this.Tp_Docto.ST_Float = false;
            this.Tp_Docto.ST_Gravar = true;
            this.Tp_Docto.ST_Int = true;
            this.Tp_Docto.ST_LimpaCampo = true;
            this.Tp_Docto.ST_NotNull = false;
            this.Tp_Docto.ST_PrimaryKey = false;
            this.Tp_Docto.TextOld = null;
            this.Tp_Docto.Leave += new System.EventHandler(this.Tp_Docto_Leave);
            // 
            // DS_CMI
            // 
            this.DS_CMI.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_CMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CMI.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "Ds_cmi", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_CMI, "DS_CMI");
            this.DS_CMI.Name = "DS_CMI";
            this.DS_CMI.NM_Alias = "";
            this.DS_CMI.NM_Campo = "DS_CMI";
            this.DS_CMI.NM_CampoBusca = "DS_CMI";
            this.DS_CMI.NM_Param = "@P_DS_CMI";
            this.DS_CMI.QTD_Zero = 0;
            this.DS_CMI.ST_AutoInc = false;
            this.DS_CMI.ST_DisableAuto = false;
            this.DS_CMI.ST_Float = false;
            this.DS_CMI.ST_Gravar = true;
            this.DS_CMI.ST_Int = false;
            this.DS_CMI.ST_LimpaCampo = true;
            this.DS_CMI.ST_NotNull = true;
            this.DS_CMI.ST_PrimaryKey = false;
            this.DS_CMI.TextOld = null;
            // 
            // ST_Mestra
            // 
            resources.ApplyResources(this.ST_Mestra, "ST_Mestra");
            this.ST_Mestra.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_mestrabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Mestra.Name = "ST_Mestra";
            this.ST_Mestra.NM_Alias = "";
            this.ST_Mestra.NM_Campo = "ST_Mestra";
            this.ST_Mestra.NM_Param = "@P_ST_MESTRA";
            this.ST_Mestra.ST_Gravar = true;
            this.ST_Mestra.ST_LimparCampo = true;
            this.ST_Mestra.ST_NotNull = false;
            this.ST_Mestra.UseVisualStyleBackColor = true;
            this.ST_Mestra.Vl_False = "N";
            this.ST_Mestra.Vl_True = "S";
            this.ST_Mestra.CheckedChanged += new System.EventHandler(this.ST_Mestra_CheckedChanged);
            // 
            // ST_Devolucao
            // 
            resources.ApplyResources(this.ST_Devolucao, "ST_Devolucao");
            this.ST_Devolucao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_devolucaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Devolucao.Name = "ST_Devolucao";
            this.ST_Devolucao.NM_Alias = "";
            this.ST_Devolucao.NM_Campo = "ST_Devolucao";
            this.ST_Devolucao.NM_Param = "@P_ST_DEVOLUCAO";
            this.ST_Devolucao.ST_Gravar = true;
            this.ST_Devolucao.ST_LimparCampo = true;
            this.ST_Devolucao.ST_NotNull = false;
            this.ST_Devolucao.UseVisualStyleBackColor = true;
            this.ST_Devolucao.Vl_False = "N";
            this.ST_Devolucao.Vl_True = "S";
            this.ST_Devolucao.CheckedChanged += new System.EventHandler(this.ST_Devolucao_CheckedChanged);
            // 
            // ST_Complementar
            // 
            resources.ApplyResources(this.ST_Complementar, "ST_Complementar");
            this.ST_Complementar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_complementarbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Complementar.Name = "ST_Complementar";
            this.ST_Complementar.NM_Alias = "";
            this.ST_Complementar.NM_Campo = "ST_Complementar";
            this.ST_Complementar.NM_Param = "@P_ST_COMPLEMENTAR";
            this.ST_Complementar.ST_Gravar = true;
            this.ST_Complementar.ST_LimparCampo = true;
            this.ST_Complementar.ST_NotNull = false;
            this.ST_Complementar.UseVisualStyleBackColor = true;
            this.ST_Complementar.Vl_False = "N";
            this.ST_Complementar.Vl_True = "S";
            this.ST_Complementar.CheckedChanged += new System.EventHandler(this.ST_Complementar_CheckedChanged);
            // 
            // ST_GeraEstoque
            // 
            resources.ApplyResources(this.ST_GeraEstoque, "ST_GeraEstoque");
            this.ST_GeraEstoque.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_geraestoquebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_GeraEstoque.Name = "ST_GeraEstoque";
            this.ST_GeraEstoque.NM_Alias = "";
            this.ST_GeraEstoque.NM_Campo = "ST_GeraEstoque";
            this.ST_GeraEstoque.NM_Param = "@P_ST_GERAESTOQUE";
            this.ST_GeraEstoque.ST_Gravar = true;
            this.ST_GeraEstoque.ST_LimparCampo = true;
            this.ST_GeraEstoque.ST_NotNull = false;
            this.ST_GeraEstoque.UseVisualStyleBackColor = true;
            this.ST_GeraEstoque.Vl_False = "N";
            this.ST_GeraEstoque.Vl_True = "S";
            // 
            // ST_SimplesRemessa
            // 
            resources.ApplyResources(this.ST_SimplesRemessa, "ST_SimplesRemessa");
            this.ST_SimplesRemessa.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_simplesremessabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_SimplesRemessa.Name = "ST_SimplesRemessa";
            this.ST_SimplesRemessa.NM_Alias = "";
            this.ST_SimplesRemessa.NM_Campo = "ST_SimplesRemessa";
            this.ST_SimplesRemessa.NM_Param = "@P_ST_SIMPLESREMESSA";
            this.ST_SimplesRemessa.ST_Gravar = true;
            this.ST_SimplesRemessa.ST_LimparCampo = true;
            this.ST_SimplesRemessa.ST_NotNull = false;
            this.ST_SimplesRemessa.UseVisualStyleBackColor = true;
            this.ST_SimplesRemessa.Vl_False = "N";
            this.ST_SimplesRemessa.Vl_True = "S";
            this.ST_SimplesRemessa.CheckedChanged += new System.EventHandler(this.ST_SimplesRemessa_CheckedChanged);
            // 
            // CD_CondPGTO
            // 
            this.CD_CondPGTO.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondPGTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CondPGTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondPGTO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "Cd_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_CondPGTO, "CD_CondPGTO");
            this.CD_CondPGTO.Name = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Alias = "a";
            this.CD_CondPGTO.NM_Campo = "CD_CondPGTO";
            this.CD_CondPGTO.NM_CampoBusca = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Param = "@P_CD_CONDPGTO";
            this.CD_CondPGTO.QTD_Zero = 0;
            this.CD_CondPGTO.ST_AutoInc = false;
            this.CD_CondPGTO.ST_DisableAuto = false;
            this.CD_CondPGTO.ST_Float = false;
            this.CD_CondPGTO.ST_Gravar = true;
            this.CD_CondPGTO.ST_Int = true;
            this.CD_CondPGTO.ST_LimpaCampo = true;
            this.CD_CondPGTO.ST_NotNull = false;
            this.CD_CondPGTO.ST_PrimaryKey = false;
            this.CD_CondPGTO.TextOld = null;
            this.CD_CondPGTO.Leave += new System.EventHandler(this.CD_CondPGTO_Leave);
            // 
            // bb_duplicata
            // 
            resources.ApplyResources(this.bb_duplicata, "bb_duplicata");
            this.bb_duplicata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_duplicata.Name = "bb_duplicata";
            this.bb_duplicata.UseVisualStyleBackColor = true;
            this.bb_duplicata.Click += new System.EventHandler(this.bb_duplicata_Click);
            // 
            // bbDocto
            // 
            resources.ApplyResources(this.bbDocto, "bbDocto");
            this.bbDocto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bbDocto.Name = "bbDocto";
            this.bbDocto.UseVisualStyleBackColor = true;
            this.bbDocto.Click += new System.EventHandler(this.bbDocto_Click);
            // 
            // bb_condpgto
            // 
            resources.ApplyResources(this.bb_condpgto, "bb_condpgto");
            this.bb_condpgto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.UseVisualStyleBackColor = true;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // ds_tpDocto
            // 
            this.ds_tpDocto.BackColor = System.Drawing.Color.White;
            this.ds_tpDocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpDocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpDocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_tpDocto, "ds_tpDocto");
            this.ds_tpDocto.Name = "ds_tpDocto";
            this.ds_tpDocto.NM_Alias = "";
            this.ds_tpDocto.NM_Campo = "ds_tpdocto";
            this.ds_tpDocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpDocto.NM_Param = "";
            this.ds_tpDocto.QTD_Zero = 0;
            this.ds_tpDocto.ReadOnly = true;
            this.ds_tpDocto.ST_AutoInc = false;
            this.ds_tpDocto.ST_DisableAuto = false;
            this.ds_tpDocto.ST_Float = false;
            this.ds_tpDocto.ST_Gravar = false;
            this.ds_tpDocto.ST_Int = false;
            this.ds_tpDocto.ST_LimpaCampo = true;
            this.ds_tpDocto.ST_NotNull = false;
            this.ds_tpDocto.ST_PrimaryKey = false;
            this.ds_tpDocto.TextOld = null;
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.Color.White;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_tpduplicata, "ds_tpduplicata");
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.ReadOnly = true;
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TextOld = null;
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.Color.White;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CMI, "ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_condpgto, "ds_condpgto");
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "ds_condpgto";
            this.ds_condpgto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpgto.NM_Param = "";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.ReadOnly = true;
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TextOld = null;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.panelDados3);
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabStop = false;
            // 
            // panelDados3
            // 
            this.panelDados3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelDados3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados3.Controls.Add(this.st_retorno);
            this.panelDados3.Controls.Add(this.st_compdevimposto);
            this.panelDados3.Controls.Add(this.ST_Mestra);
            this.panelDados3.Controls.Add(this.ST_Devolucao);
            this.panelDados3.Controls.Add(this.ST_Complementar);
            this.panelDados3.Controls.Add(this.ST_SimplesRemessa);
            this.panelDados3.Controls.Add(this.ST_GeraEstoque);
            resources.ApplyResources(this.panelDados3, "panelDados3");
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            // 
            // st_retorno
            // 
            resources.ApplyResources(this.st_retorno, "st_retorno");
            this.st_retorno.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_retornobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_retorno.Name = "st_retorno";
            this.st_retorno.NM_Alias = "";
            this.st_retorno.NM_Campo = "st_retorno";
            this.st_retorno.NM_Param = "@P_ST_GERAESTOQUE";
            this.st_retorno.ST_Gravar = true;
            this.st_retorno.ST_LimparCampo = true;
            this.st_retorno.ST_NotNull = false;
            this.st_retorno.UseVisualStyleBackColor = true;
            this.st_retorno.Vl_False = "N";
            this.st_retorno.Vl_True = "S";
            this.st_retorno.CheckedChanged += new System.EventHandler(this.st_retorno_CheckedChanged);
            // 
            // st_compdevimposto
            // 
            resources.ApplyResources(this.st_compdevimposto, "st_compdevimposto");
            this.st_compdevimposto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CMI, "St_compdevimpostobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_compdevimposto.Name = "st_compdevimposto";
            this.st_compdevimposto.NM_Alias = "";
            this.st_compdevimposto.NM_Campo = "ST_CompDevImposto";
            this.st_compdevimposto.NM_Param = "@P_ST_MESTRA";
            this.st_compdevimposto.ST_Gravar = true;
            this.st_compdevimposto.ST_LimparCampo = true;
            this.st_compdevimposto.ST_NotNull = false;
            this.st_compdevimposto.UseVisualStyleBackColor = true;
            this.st_compdevimposto.Vl_False = "N";
            this.st_compdevimposto.Vl_True = "S";
            this.st_compdevimposto.CheckedChanged += new System.EventHandler(this.st_compdevimposto_CheckedChanged);
            // 
            // BN_CMI
            // 
            this.BN_CMI.AddNewItem = null;
            this.BN_CMI.BindingSource = this.BS_CMI;
            this.BN_CMI.CountItem = this.bindingNavigatorCountItem;
            this.BN_CMI.CountItemFormat = "de {0}";
            this.BN_CMI.DeleteItem = null;
            resources.ApplyResources(this.BN_CMI, "BN_CMI");
            this.BN_CMI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CMI.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CMI.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CMI.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CMI.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CMI.Name = "BN_CMI";
            this.BN_CMI.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
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
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_CMI, "Tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            resources.ApplyResources(this.tp_movimento, "tp_movimento");
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.SelectedIndexChanged += new System.EventHandler(this.tp_movimento_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TFCadCMI
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadCMI";
            this.Load += new System.EventHandler(this.TFCadCMI_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCMI_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CMI)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CMI)).EndInit();
            this.BN_CMI.ResumeLayout(false);
            this.BN_CMI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_CMI;
        private System.Windows.Forms.Label LB_TP_Duplicata;
        private System.Windows.Forms.Label LB_Tp_Docto;
        private System.Windows.Forms.Label LB_DS_CMI;
        private System.Windows.Forms.Label LB_CD_CondPGTO;




        private Componentes.EditDefault CD_CMI;
        private Componentes.EditDefault TP_Duplicata;
        private Componentes.EditDefault Tp_Docto;
        private Componentes.EditDefault DS_CMI;
        private Componentes.CheckBoxDefault ST_Mestra;
        private Componentes.CheckBoxDefault ST_Devolucao;
        private Componentes.CheckBoxDefault ST_Complementar;
        private Componentes.CheckBoxDefault ST_GeraEstoque;
        private Componentes.CheckBoxDefault ST_SimplesRemessa;
        private Componentes.EditDefault CD_CondPGTO;
        public System.Windows.Forms.Button bb_duplicata;
        public System.Windows.Forms.Button bbDocto;
        public System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault ds_tpDocto;
        private Componentes.EditDefault ds_condpgto;
        private Componentes.EditDefault ds_tpduplicata;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados3;
        private System.Windows.Forms.BindingSource BS_CMI;
        private System.Windows.Forms.BindingNavigator BN_CMI;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stgeralivrosfiscaisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stcontabilidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdepositoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stpedidonfDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.CheckBoxDefault st_compdevimposto;
        private Componentes.CheckBoxDefault st_retorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcmiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscmiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpmovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stmestraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdevolucaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stcomplementarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stgeraestoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stsimplesremessaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_retornobool;




    }
}
