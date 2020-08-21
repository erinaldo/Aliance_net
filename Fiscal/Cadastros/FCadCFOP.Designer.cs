namespace Fiscal.Cadastros
{
    partial class TFCadCFOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCFOP));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cDCFOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSCFOPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_bonificacaobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_usoconsumobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_devolucaobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_remessabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_retornobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_combustivelbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CFOP = new System.Windows.Forms.BindingSource(this.components);
            this.cd_cfop = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_cfop = new Componentes.EditDefault(this.components);
            this.editMask1 = new Componentes.EditMask(this.components);
            this.BN_CFOP = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.ds_aplicacao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.st_bonificacao = new Componentes.CheckBoxDefault(this.components);
            this.cbUsoConsumo = new Componentes.CheckBoxDefault(this.components);
            this.st_devolucao = new Componentes.CheckBoxDefault(this.components);
            this.st_retorno = new Componentes.CheckBoxDefault(this.components);
            this.st_remessa = new Componentes.CheckBoxDefault(this.components);
            this.st_combustivel = new Componentes.CheckBoxDefault(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bbSincronizar = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CFOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CFOP)).BeginInit();
            this.BN_CFOP.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_combustivel);
            this.pDados.Controls.Add(this.st_remessa);
            this.pDados.Controls.Add(this.st_retorno);
            this.pDados.Controls.Add(this.st_devolucao);
            this.pDados.Controls.Add(this.cbUsoConsumo);
            this.pDados.Controls.Add(this.st_bonificacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_aplicacao);
            this.pDados.Controls.Add(this.ds_cfop);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_cfop);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_CFOP";
            this.pDados.NM_ProcGravar = "IA_FIS_CFOP";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.BN_CFOP);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.BN_CFOP, 0);
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
            this.cDCFOPDataGridViewTextBoxColumn,
            this.dSCFOPDataGridViewTextBoxColumn,
            this.St_bonificacaobool,
            this.St_usoconsumobool,
            this.St_devolucaobool,
            this.St_remessabool,
            this.St_retornobool,
            this.St_combustivelbool,
            this.dataGridViewTextBoxColumn1});
            this.gCadastro.DataSource = this.BS_CFOP;
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
            this.gCadastro.TabStop = false;
            this.gCadastro.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gCadastro_ColumnHeaderMouseClick);
            // 
            // cDCFOPDataGridViewTextBoxColumn
            // 
            this.cDCFOPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDCFOPDataGridViewTextBoxColumn.DataPropertyName = "CD_CFOP";
            resources.ApplyResources(this.cDCFOPDataGridViewTextBoxColumn, "cDCFOPDataGridViewTextBoxColumn");
            this.cDCFOPDataGridViewTextBoxColumn.Name = "cDCFOPDataGridViewTextBoxColumn";
            this.cDCFOPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSCFOPDataGridViewTextBoxColumn
            // 
            this.dSCFOPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSCFOPDataGridViewTextBoxColumn.DataPropertyName = "DS_CFOP";
            resources.ApplyResources(this.dSCFOPDataGridViewTextBoxColumn, "dSCFOPDataGridViewTextBoxColumn");
            this.dSCFOPDataGridViewTextBoxColumn.Name = "dSCFOPDataGridViewTextBoxColumn";
            this.dSCFOPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // St_bonificacaobool
            // 
            this.St_bonificacaobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_bonificacaobool.DataPropertyName = "St_bonificacaobool";
            resources.ApplyResources(this.St_bonificacaobool, "St_bonificacaobool");
            this.St_bonificacaobool.Name = "St_bonificacaobool";
            this.St_bonificacaobool.ReadOnly = true;
            // 
            // St_usoconsumobool
            // 
            this.St_usoconsumobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_usoconsumobool.DataPropertyName = "St_usoconsumobool";
            resources.ApplyResources(this.St_usoconsumobool, "St_usoconsumobool");
            this.St_usoconsumobool.Name = "St_usoconsumobool";
            this.St_usoconsumobool.ReadOnly = true;
            // 
            // St_devolucaobool
            // 
            this.St_devolucaobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_devolucaobool.DataPropertyName = "St_devolucaobool";
            resources.ApplyResources(this.St_devolucaobool, "St_devolucaobool");
            this.St_devolucaobool.Name = "St_devolucaobool";
            this.St_devolucaobool.ReadOnly = true;
            // 
            // St_remessabool
            // 
            this.St_remessabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_remessabool.DataPropertyName = "St_remessabool";
            resources.ApplyResources(this.St_remessabool, "St_remessabool");
            this.St_remessabool.Name = "St_remessabool";
            this.St_remessabool.ReadOnly = true;
            // 
            // St_retornobool
            // 
            this.St_retornobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_retornobool.DataPropertyName = "St_retornobool";
            resources.ApplyResources(this.St_retornobool, "St_retornobool");
            this.St_retornobool.Name = "St_retornobool";
            this.St_retornobool.ReadOnly = true;
            // 
            // St_combustivelbool
            // 
            this.St_combustivelbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_combustivelbool.DataPropertyName = "St_combustivelbool";
            resources.ApplyResources(this.St_combustivelbool, "St_combustivelbool");
            this.St_combustivelbool.Name = "St_combustivelbool";
            this.St_combustivelbool.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DS_APLICACAO";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // BS_CFOP
            // 
            this.BS_CFOP.DataSource = typeof(CamadaDados.Fiscal.TList_CadCFOP);
            // 
            // cd_cfop
            // 
            this.cd_cfop.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cfop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cfop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "CD_CFOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_cfop, "cd_cfop");
            this.cd_cfop.Name = "cd_cfop";
            this.cd_cfop.NM_Alias = "";
            this.cd_cfop.NM_Campo = "cd_cfop";
            this.cd_cfop.NM_CampoBusca = "cd_cfop";
            this.cd_cfop.NM_Param = "@P_CD_CFOP";
            this.cd_cfop.QTD_Zero = 0;
            this.cd_cfop.ST_AutoInc = false;
            this.cd_cfop.ST_DisableAuto = true;
            this.cd_cfop.ST_Float = false;
            this.cd_cfop.ST_Gravar = true;
            this.cd_cfop.ST_Int = false;
            this.cd_cfop.ST_LimpaCampo = true;
            this.cd_cfop.ST_NotNull = true;
            this.cd_cfop.ST_PrimaryKey = true;
            this.cd_cfop.TextOld = null;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ds_cfop
            // 
            this.ds_cfop.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cfop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cfop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "DS_CFOP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_cfop, "ds_cfop");
            this.ds_cfop.Name = "ds_cfop";
            this.ds_cfop.NM_Alias = "";
            this.ds_cfop.NM_Campo = "ds_cfop";
            this.ds_cfop.NM_CampoBusca = "ds_cfop";
            this.ds_cfop.NM_Param = "@P_DS_CFOP";
            this.ds_cfop.QTD_Zero = 0;
            this.ds_cfop.ST_AutoInc = false;
            this.ds_cfop.ST_DisableAuto = false;
            this.ds_cfop.ST_Float = false;
            this.ds_cfop.ST_Gravar = true;
            this.ds_cfop.ST_Int = false;
            this.ds_cfop.ST_LimpaCampo = true;
            this.ds_cfop.ST_NotNull = true;
            this.ds_cfop.ST_PrimaryKey = false;
            this.ds_cfop.TextOld = null;
            // 
            // editMask1
            // 
            resources.ApplyResources(this.editMask1, "editMask1");
            this.editMask1.Name = "editMask1";
            this.editMask1.NM_Alias = "";
            this.editMask1.NM_Campo = "";
            this.editMask1.NM_CampoBusca = "";
            this.editMask1.NM_Param = "";
            this.editMask1.ST_Gravar = false;
            this.editMask1.ST_LimpaCampo = true;
            this.editMask1.ST_NotNull = false;
            this.editMask1.ST_PrimaryKey = false;
            // 
            // BN_CFOP
            // 
            this.BN_CFOP.AddNewItem = null;
            this.BN_CFOP.BindingSource = this.BS_CFOP;
            this.BN_CFOP.CountItem = this.bindingNavigatorCountItem;
            this.BN_CFOP.CountItemFormat = "de {0}";
            this.BN_CFOP.DeleteItem = null;
            resources.ApplyResources(this.BN_CFOP, "BN_CFOP");
            this.BN_CFOP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.bbSincronizar});
            this.BN_CFOP.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CFOP.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CFOP.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CFOP.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CFOP.Name = "BN_CFOP";
            this.BN_CFOP.PositionItem = this.bindingNavigatorPositionItem;
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
            // ds_aplicacao
            // 
            this.ds_aplicacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_aplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_aplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_aplicacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CFOP, "DS_APLICACAO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_aplicacao, "ds_aplicacao");
            this.ds_aplicacao.Name = "ds_aplicacao";
            this.ds_aplicacao.NM_Alias = "";
            this.ds_aplicacao.NM_Campo = "";
            this.ds_aplicacao.NM_CampoBusca = "";
            this.ds_aplicacao.NM_Param = "";
            this.ds_aplicacao.QTD_Zero = 0;
            this.ds_aplicacao.ST_AutoInc = false;
            this.ds_aplicacao.ST_DisableAuto = false;
            this.ds_aplicacao.ST_Float = false;
            this.ds_aplicacao.ST_Gravar = true;
            this.ds_aplicacao.ST_Int = false;
            this.ds_aplicacao.ST_LimpaCampo = true;
            this.ds_aplicacao.ST_NotNull = false;
            this.ds_aplicacao.ST_PrimaryKey = false;
            this.ds_aplicacao.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // st_bonificacao
            // 
            resources.ApplyResources(this.st_bonificacao, "st_bonificacao");
            this.st_bonificacao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_bonificacaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_bonificacao.Name = "st_bonificacao";
            this.st_bonificacao.NM_Alias = "";
            this.st_bonificacao.NM_Campo = "";
            this.st_bonificacao.NM_Param = "";
            this.st_bonificacao.ST_Gravar = true;
            this.st_bonificacao.ST_LimparCampo = true;
            this.st_bonificacao.ST_NotNull = false;
            this.st_bonificacao.UseVisualStyleBackColor = true;
            this.st_bonificacao.Vl_False = "";
            this.st_bonificacao.Vl_True = "";
            // 
            // cbUsoConsumo
            // 
            resources.ApplyResources(this.cbUsoConsumo, "cbUsoConsumo");
            this.cbUsoConsumo.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_usoconsumobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbUsoConsumo.Name = "cbUsoConsumo";
            this.cbUsoConsumo.NM_Alias = "";
            this.cbUsoConsumo.NM_Campo = "";
            this.cbUsoConsumo.NM_Param = "";
            this.cbUsoConsumo.ST_Gravar = true;
            this.cbUsoConsumo.ST_LimparCampo = true;
            this.cbUsoConsumo.ST_NotNull = false;
            this.cbUsoConsumo.UseVisualStyleBackColor = true;
            this.cbUsoConsumo.Vl_False = "";
            this.cbUsoConsumo.Vl_True = "";
            // 
            // st_devolucao
            // 
            resources.ApplyResources(this.st_devolucao, "st_devolucao");
            this.st_devolucao.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_devolucaobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_devolucao.Name = "st_devolucao";
            this.st_devolucao.NM_Alias = "";
            this.st_devolucao.NM_Campo = "";
            this.st_devolucao.NM_Param = "";
            this.st_devolucao.ST_Gravar = true;
            this.st_devolucao.ST_LimparCampo = true;
            this.st_devolucao.ST_NotNull = false;
            this.st_devolucao.UseVisualStyleBackColor = true;
            this.st_devolucao.Vl_False = "";
            this.st_devolucao.Vl_True = "";
            // 
            // st_retorno
            // 
            resources.ApplyResources(this.st_retorno, "st_retorno");
            this.st_retorno.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_retornobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_retorno.Name = "st_retorno";
            this.st_retorno.NM_Alias = "";
            this.st_retorno.NM_Campo = "";
            this.st_retorno.NM_Param = "";
            this.st_retorno.ST_Gravar = true;
            this.st_retorno.ST_LimparCampo = true;
            this.st_retorno.ST_NotNull = false;
            this.st_retorno.UseVisualStyleBackColor = true;
            this.st_retorno.Vl_False = "";
            this.st_retorno.Vl_True = "";
            // 
            // st_remessa
            // 
            resources.ApplyResources(this.st_remessa, "st_remessa");
            this.st_remessa.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_remessabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_remessa.Name = "st_remessa";
            this.st_remessa.NM_Alias = "";
            this.st_remessa.NM_Campo = "";
            this.st_remessa.NM_Param = "";
            this.st_remessa.ST_Gravar = true;
            this.st_remessa.ST_LimparCampo = true;
            this.st_remessa.ST_NotNull = false;
            this.st_remessa.UseVisualStyleBackColor = true;
            this.st_remessa.Vl_False = "";
            this.st_remessa.Vl_True = "";
            // 
            // st_combustivel
            // 
            resources.ApplyResources(this.st_combustivel, "st_combustivel");
            this.st_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CFOP, "St_combustivelbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_combustivel.Name = "st_combustivel";
            this.st_combustivel.NM_Alias = "";
            this.st_combustivel.NM_Campo = "";
            this.st_combustivel.NM_Param = "";
            this.st_combustivel.ST_Gravar = true;
            this.st_combustivel.ST_LimparCampo = true;
            this.st_combustivel.ST_NotNull = false;
            this.st_combustivel.UseVisualStyleBackColor = true;
            this.st_combustivel.Vl_False = "";
            this.st_combustivel.Vl_True = "";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // bbSincronizar
            // 
            resources.ApplyResources(this.bbSincronizar, "bbSincronizar");
            this.bbSincronizar.Name = "bbSincronizar";
            this.bbSincronizar.Click += new System.EventHandler(this.bbSincronizar_Click);
            // 
            // TFCadCFOP
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadCFOP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCFOP_FormClosing);
            this.Load += new System.EventHandler(this.TFCadCFOP_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CFOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CFOP)).EndInit();
            this.BN_CFOP.ResumeLayout(false);
            this.BN_CFOP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private Componentes.EditDefault ds_cfop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_cfop;
        private Componentes.EditMask editMask1;
        private System.Windows.Forms.BindingSource BS_CFOP;
        private System.Windows.Forms.BindingNavigator BN_CFOP;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_aplicacao;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_bonificacao;
        private Componentes.CheckBoxDefault cbUsoConsumo;
        private Componentes.CheckBoxDefault st_devolucao;
        private Componentes.CheckBoxDefault st_retorno;
        private Componentes.CheckBoxDefault st_remessa;
        private Componentes.CheckBoxDefault st_combustivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDCFOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSCFOPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_bonificacaobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_usoconsumobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_devolucaobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_remessabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_retornobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_combustivelbool;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bbSincronizar;
    }
}
