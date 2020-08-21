namespace Consulta.Cadastro
{
    partial class TFCad_ParamClasse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_ParamClasse));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelNMCampoFormat = new System.Windows.Forms.Label();
            this.BS_ParamClasse = new System.Windows.Forms.BindingSource(this.components);
            this.labelIDParamClasse = new System.Windows.Forms.Label();
            this.labelNMParam = new System.Windows.Forms.Label();
            this.ID_ParamClasse = new Componentes.EditDefault(this.components);
            this.NM_Param = new Componentes.EditDefault(this.components);
            this.labelTPDado = new System.Windows.Forms.Label();
            this.labelCodigoCMP = new System.Windows.Forms.Label();
            this.CodigoCMP = new Componentes.EditDefault(this.components);
            this.labelDSCMP = new System.Windows.Forms.Label();
            this.NomeCMP = new Componentes.EditDefault(this.components);
            this.labelCondBusca = new System.Windows.Forms.Label();
            this.CondicaoBusca = new Componentes.EditDefault(this.components);
            this.labelNMDLL = new System.Windows.Forms.Label();
            this.labelNMClasse = new System.Windows.Forms.Label();
            this.cb_TP_Dado = new Componentes.ComboBoxDefault(this.components);
            this.groupBoxBusca = new System.Windows.Forms.GroupBox();
            this.BN_ParamClasse = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.grid_ParamClasse = new Componentes.DataGridDefault(this.components);
            this.iDParamClasseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMParamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMCampoFormatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMClasseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tPDadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoCMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeCMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMDLLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Obrigatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_Null = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NM_CampoFormat = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cb_NMClasse = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Valor = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Descricao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.RadioCheckGroup = new Componentes.EditDefault(this.components);
            this.Add = new System.Windows.Forms.Button();
            this.cb_STObrigatorio = new Componentes.CheckBoxDefault(this.components);
            this.cb_Null = new Componentes.CheckBoxDefault(this.components);
            this.bb_Limpar = new System.Windows.Forms.Button();
            this.cbNMDLL = new Componentes.ComboBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_ParamClasse)).BeginInit();
            this.groupBoxBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BN_ParamClasse)).BeginInit();
            this.BN_ParamClasse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ParamClasse)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.cbNMDLL);
            this.pDados.Controls.Add(this.bb_Limpar);
            this.pDados.Controls.Add(this.cb_Null);
            this.pDados.Controls.Add(this.cb_STObrigatorio);
            this.pDados.Controls.Add(this.Add);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.RadioCheckGroup);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Descricao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.Valor);
            this.pDados.Controls.Add(this.cb_NMClasse);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.groupBoxBusca);
            this.pDados.Controls.Add(this.cb_TP_Dado);
            this.pDados.Controls.Add(this.labelNMClasse);
            this.pDados.Controls.Add(this.labelNMDLL);
            this.pDados.Controls.Add(this.labelTPDado);
            this.pDados.Controls.Add(this.labelNMCampoFormat);
            this.pDados.Controls.Add(this.NM_CampoFormat);
            this.pDados.Controls.Add(this.labelIDParamClasse);
            this.pDados.Controls.Add(this.labelNMParam);
            this.pDados.Controls.Add(this.ID_ParamClasse);
            this.pDados.Controls.Add(this.NM_Param);
            this.pDados.Font = null;
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.grid_ParamClasse);
            this.tpPadrao.Controls.Add(this.BN_ParamClasse);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.BN_ParamClasse, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.grid_ParamClasse, 0);
            // 
            // labelNMCampoFormat
            // 
            this.labelNMCampoFormat.AccessibleDescription = null;
            this.labelNMCampoFormat.AccessibleName = null;
            resources.ApplyResources(this.labelNMCampoFormat, "labelNMCampoFormat");
            this.labelNMCampoFormat.Name = "labelNMCampoFormat";
            // 
            // BS_ParamClasse
            // 
            this.BS_ParamClasse.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_ParamClasse);
            // 
            // labelIDParamClasse
            // 
            this.labelIDParamClasse.AccessibleDescription = null;
            this.labelIDParamClasse.AccessibleName = null;
            resources.ApplyResources(this.labelIDParamClasse, "labelIDParamClasse");
            this.labelIDParamClasse.Name = "labelIDParamClasse";
            // 
            // labelNMParam
            // 
            this.labelNMParam.AccessibleDescription = null;
            this.labelNMParam.AccessibleName = null;
            resources.ApplyResources(this.labelNMParam, "labelNMParam");
            this.labelNMParam.Name = "labelNMParam";
            // 
            // ID_ParamClasse
            // 
            this.ID_ParamClasse.AccessibleDescription = null;
            this.ID_ParamClasse.AccessibleName = null;
            resources.ApplyResources(this.ID_ParamClasse, "ID_ParamClasse");
            this.ID_ParamClasse.BackColor = System.Drawing.SystemColors.Window;
            this.ID_ParamClasse.BackgroundImage = null;
            this.ID_ParamClasse.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.ID_ParamClasse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "ID_ParamClasse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_ParamClasse.Name = "ID_ParamClasse";
            this.ID_ParamClasse.NM_Alias = "";
            this.ID_ParamClasse.NM_Campo = "";
            this.ID_ParamClasse.NM_CampoBusca = "";
            this.ID_ParamClasse.NM_Param = "";
            this.ID_ParamClasse.QTD_Zero = 3;
            this.ID_ParamClasse.ST_AutoInc = false;
            this.ID_ParamClasse.ST_DisableAuto = false;
            this.ID_ParamClasse.ST_Float = false;
            this.ID_ParamClasse.ST_Gravar = true;
            this.ID_ParamClasse.ST_Int = false;
            this.ID_ParamClasse.ST_LimpaCampo = true;
            this.ID_ParamClasse.ST_NotNull = true;
            this.ID_ParamClasse.ST_PrimaryKey = true;
            // 
            // NM_Param
            // 
            this.NM_Param.AccessibleDescription = null;
            this.NM_Param.AccessibleName = null;
            resources.ApplyResources(this.NM_Param, "NM_Param");
            this.NM_Param.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Param.BackgroundImage = null;
            this.NM_Param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Param.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "NM_Param", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Param.Name = "NM_Param";
            this.NM_Param.NM_Alias = "";
            this.NM_Param.NM_Campo = "NM_Param";
            this.NM_Param.NM_CampoBusca = "NM_Param";
            this.NM_Param.NM_Param = "@P_NM_PARAM";
            this.NM_Param.QTD_Zero = 0;
            this.NM_Param.ST_AutoInc = false;
            this.NM_Param.ST_DisableAuto = false;
            this.NM_Param.ST_Float = false;
            this.NM_Param.ST_Gravar = true;
            this.NM_Param.ST_Int = false;
            this.NM_Param.ST_LimpaCampo = true;
            this.NM_Param.ST_NotNull = true;
            this.NM_Param.ST_PrimaryKey = false;
            // 
            // labelTPDado
            // 
            this.labelTPDado.AccessibleDescription = null;
            this.labelTPDado.AccessibleName = null;
            resources.ApplyResources(this.labelTPDado, "labelTPDado");
            this.labelTPDado.Name = "labelTPDado";
            // 
            // labelCodigoCMP
            // 
            this.labelCodigoCMP.AccessibleDescription = null;
            this.labelCodigoCMP.AccessibleName = null;
            resources.ApplyResources(this.labelCodigoCMP, "labelCodigoCMP");
            this.labelCodigoCMP.Name = "labelCodigoCMP";
            // 
            // CodigoCMP
            // 
            this.CodigoCMP.AccessibleDescription = null;
            this.CodigoCMP.AccessibleName = null;
            resources.ApplyResources(this.CodigoCMP, "CodigoCMP");
            this.CodigoCMP.BackColor = System.Drawing.SystemColors.Window;
            this.CodigoCMP.BackgroundImage = null;
            this.CodigoCMP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodigoCMP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "CodigoCMP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CodigoCMP.Name = "CodigoCMP";
            this.CodigoCMP.NM_Alias = "";
            this.CodigoCMP.NM_Campo = "";
            this.CodigoCMP.NM_CampoBusca = "";
            this.CodigoCMP.NM_Param = "";
            this.CodigoCMP.QTD_Zero = 0;
            this.CodigoCMP.ST_AutoInc = false;
            this.CodigoCMP.ST_DisableAuto = true;
            this.CodigoCMP.ST_Float = false;
            this.CodigoCMP.ST_Gravar = true;
            this.CodigoCMP.ST_Int = false;
            this.CodigoCMP.ST_LimpaCampo = true;
            this.CodigoCMP.ST_NotNull = false;
            this.CodigoCMP.ST_PrimaryKey = false;
            // 
            // labelDSCMP
            // 
            this.labelDSCMP.AccessibleDescription = null;
            this.labelDSCMP.AccessibleName = null;
            resources.ApplyResources(this.labelDSCMP, "labelDSCMP");
            this.labelDSCMP.Name = "labelDSCMP";
            // 
            // NomeCMP
            // 
            this.NomeCMP.AccessibleDescription = null;
            this.NomeCMP.AccessibleName = null;
            resources.ApplyResources(this.NomeCMP, "NomeCMP");
            this.NomeCMP.BackColor = System.Drawing.SystemColors.Window;
            this.NomeCMP.BackgroundImage = null;
            this.NomeCMP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NomeCMP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "NomeCMP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NomeCMP.Name = "NomeCMP";
            this.NomeCMP.NM_Alias = "";
            this.NomeCMP.NM_Campo = "";
            this.NomeCMP.NM_CampoBusca = "";
            this.NomeCMP.NM_Param = "";
            this.NomeCMP.QTD_Zero = 0;
            this.NomeCMP.ST_AutoInc = false;
            this.NomeCMP.ST_DisableAuto = true;
            this.NomeCMP.ST_Float = false;
            this.NomeCMP.ST_Gravar = true;
            this.NomeCMP.ST_Int = false;
            this.NomeCMP.ST_LimpaCampo = true;
            this.NomeCMP.ST_NotNull = false;
            this.NomeCMP.ST_PrimaryKey = false;
            // 
            // labelCondBusca
            // 
            this.labelCondBusca.AccessibleDescription = null;
            this.labelCondBusca.AccessibleName = null;
            resources.ApplyResources(this.labelCondBusca, "labelCondBusca");
            this.labelCondBusca.Name = "labelCondBusca";
            // 
            // CondicaoBusca
            // 
            this.CondicaoBusca.AccessibleDescription = null;
            this.CondicaoBusca.AccessibleName = null;
            resources.ApplyResources(this.CondicaoBusca, "CondicaoBusca");
            this.CondicaoBusca.BackColor = System.Drawing.SystemColors.Window;
            this.CondicaoBusca.BackgroundImage = null;
            this.CondicaoBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CondicaoBusca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "CondicaoBusca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CondicaoBusca.Name = "CondicaoBusca";
            this.CondicaoBusca.NM_Alias = "";
            this.CondicaoBusca.NM_Campo = "";
            this.CondicaoBusca.NM_CampoBusca = "";
            this.CondicaoBusca.NM_Param = "";
            this.CondicaoBusca.QTD_Zero = 0;
            this.CondicaoBusca.ST_AutoInc = false;
            this.CondicaoBusca.ST_DisableAuto = true;
            this.CondicaoBusca.ST_Float = false;
            this.CondicaoBusca.ST_Gravar = true;
            this.CondicaoBusca.ST_Int = false;
            this.CondicaoBusca.ST_LimpaCampo = true;
            this.CondicaoBusca.ST_NotNull = false;
            this.CondicaoBusca.ST_PrimaryKey = false;
            // 
            // labelNMDLL
            // 
            this.labelNMDLL.AccessibleDescription = null;
            this.labelNMDLL.AccessibleName = null;
            resources.ApplyResources(this.labelNMDLL, "labelNMDLL");
            this.labelNMDLL.Name = "labelNMDLL";
            // 
            // labelNMClasse
            // 
            this.labelNMClasse.AccessibleDescription = null;
            this.labelNMClasse.AccessibleName = null;
            resources.ApplyResources(this.labelNMClasse, "labelNMClasse");
            this.labelNMClasse.Name = "labelNMClasse";
            // 
            // cb_TP_Dado
            // 
            this.cb_TP_Dado.AccessibleDescription = null;
            this.cb_TP_Dado.AccessibleName = null;
            resources.ApplyResources(this.cb_TP_Dado, "cb_TP_Dado");
            this.cb_TP_Dado.BackgroundImage = null;
            this.cb_TP_Dado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "TP_Dado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_TP_Dado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_TP_Dado.Font = null;
            this.cb_TP_Dado.FormattingEnabled = true;
            this.cb_TP_Dado.Items.AddRange(new object[] {
            resources.GetString("cb_TP_Dado.Items"),
            resources.GetString("cb_TP_Dado.Items1"),
            resources.GetString("cb_TP_Dado.Items2"),
            resources.GetString("cb_TP_Dado.Items3"),
            resources.GetString("cb_TP_Dado.Items4"),
            resources.GetString("cb_TP_Dado.Items5"),
            resources.GetString("cb_TP_Dado.Items6"),
            resources.GetString("cb_TP_Dado.Items7"),
            resources.GetString("cb_TP_Dado.Items8"),
            resources.GetString("cb_TP_Dado.Items9")});
            this.cb_TP_Dado.Name = "cb_TP_Dado";
            this.cb_TP_Dado.NM_Alias = "";
            this.cb_TP_Dado.NM_Campo = "";
            this.cb_TP_Dado.NM_Param = "";
            this.cb_TP_Dado.ST_Gravar = false;
            this.cb_TP_Dado.ST_LimparCampo = true;
            this.cb_TP_Dado.ST_NotNull = false;
            this.cb_TP_Dado.SelectedIndexChanged += new System.EventHandler(this.cb_TP_Dado_SelectedIndexChanged);
            // 
            // groupBoxBusca
            // 
            this.groupBoxBusca.AccessibleDescription = null;
            this.groupBoxBusca.AccessibleName = null;
            resources.ApplyResources(this.groupBoxBusca, "groupBoxBusca");
            this.groupBoxBusca.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxBusca.BackgroundImage = null;
            this.groupBoxBusca.Controls.Add(this.CodigoCMP);
            this.groupBoxBusca.Controls.Add(this.labelCodigoCMP);
            this.groupBoxBusca.Controls.Add(this.NomeCMP);
            this.groupBoxBusca.Controls.Add(this.labelDSCMP);
            this.groupBoxBusca.Controls.Add(this.CondicaoBusca);
            this.groupBoxBusca.Controls.Add(this.labelCondBusca);
            this.groupBoxBusca.Font = null;
            this.groupBoxBusca.Name = "groupBoxBusca";
            this.groupBoxBusca.TabStop = false;
            // 
            // BN_ParamClasse
            // 
            this.BN_ParamClasse.AccessibleDescription = null;
            this.BN_ParamClasse.AccessibleName = null;
            this.BN_ParamClasse.AddNewItem = null;
            resources.ApplyResources(this.BN_ParamClasse, "BN_ParamClasse");
            this.BN_ParamClasse.BackgroundImage = null;
            this.BN_ParamClasse.BindingSource = this.BS_ParamClasse;
            this.BN_ParamClasse.CountItem = this.bindingNavigatorCountItem;
            this.BN_ParamClasse.DeleteItem = null;
            this.BN_ParamClasse.Font = null;
            this.BN_ParamClasse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_ParamClasse.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_ParamClasse.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_ParamClasse.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_ParamClasse.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_ParamClasse.Name = "BN_ParamClasse";
            this.BN_ParamClasse.PositionItem = this.bindingNavigatorPositionItem;
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
            // grid_ParamClasse
            // 
            this.grid_ParamClasse.AccessibleDescription = null;
            this.grid_ParamClasse.AccessibleName = null;
            this.grid_ParamClasse.AllowUserToAddRows = false;
            this.grid_ParamClasse.AllowUserToDeleteRows = false;
            this.grid_ParamClasse.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_ParamClasse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.grid_ParamClasse, "grid_ParamClasse");
            this.grid_ParamClasse.AutoGenerateColumns = false;
            this.grid_ParamClasse.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_ParamClasse.BackgroundImage = null;
            this.grid_ParamClasse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_ParamClasse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_ParamClasse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_ParamClasse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_ParamClasse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDParamClasseDataGridViewTextBoxColumn,
            this.nMParamDataGridViewTextBoxColumn,
            this.nMCampoFormatDataGridViewTextBoxColumn,
            this.nMClasseDataGridViewTextBoxColumn,
            this.tPDadoDataGridViewTextBoxColumn,
            this.codigoCMPDataGridViewTextBoxColumn,
            this.nomeCMPDataGridViewTextBoxColumn,
            this.nMDLLDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.Status_Obrigatorio,
            this.Status_Null});
            this.grid_ParamClasse.DataSource = this.BS_ParamClasse;
            this.grid_ParamClasse.Font = null;
            this.grid_ParamClasse.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_ParamClasse.Name = "grid_ParamClasse";
            this.grid_ParamClasse.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_ParamClasse.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_ParamClasse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // iDParamClasseDataGridViewTextBoxColumn
            // 
            this.iDParamClasseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iDParamClasseDataGridViewTextBoxColumn.DataPropertyName = "ID_ParamClasse";
            resources.ApplyResources(this.iDParamClasseDataGridViewTextBoxColumn, "iDParamClasseDataGridViewTextBoxColumn");
            this.iDParamClasseDataGridViewTextBoxColumn.Name = "iDParamClasseDataGridViewTextBoxColumn";
            this.iDParamClasseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMParamDataGridViewTextBoxColumn
            // 
            this.nMParamDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMParamDataGridViewTextBoxColumn.DataPropertyName = "NM_Param";
            resources.ApplyResources(this.nMParamDataGridViewTextBoxColumn, "nMParamDataGridViewTextBoxColumn");
            this.nMParamDataGridViewTextBoxColumn.Name = "nMParamDataGridViewTextBoxColumn";
            this.nMParamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMCampoFormatDataGridViewTextBoxColumn
            // 
            this.nMCampoFormatDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMCampoFormatDataGridViewTextBoxColumn.DataPropertyName = "NM_CampoFormat";
            resources.ApplyResources(this.nMCampoFormatDataGridViewTextBoxColumn, "nMCampoFormatDataGridViewTextBoxColumn");
            this.nMCampoFormatDataGridViewTextBoxColumn.Name = "nMCampoFormatDataGridViewTextBoxColumn";
            this.nMCampoFormatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMClasseDataGridViewTextBoxColumn
            // 
            this.nMClasseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMClasseDataGridViewTextBoxColumn.DataPropertyName = "NM_Classe";
            resources.ApplyResources(this.nMClasseDataGridViewTextBoxColumn, "nMClasseDataGridViewTextBoxColumn");
            this.nMClasseDataGridViewTextBoxColumn.Name = "nMClasseDataGridViewTextBoxColumn";
            this.nMClasseDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tPDadoDataGridViewTextBoxColumn
            // 
            this.tPDadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tPDadoDataGridViewTextBoxColumn.DataPropertyName = "TP_Dado";
            resources.ApplyResources(this.tPDadoDataGridViewTextBoxColumn, "tPDadoDataGridViewTextBoxColumn");
            this.tPDadoDataGridViewTextBoxColumn.Name = "tPDadoDataGridViewTextBoxColumn";
            this.tPDadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoCMPDataGridViewTextBoxColumn
            // 
            this.codigoCMPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codigoCMPDataGridViewTextBoxColumn.DataPropertyName = "CodigoCMP";
            resources.ApplyResources(this.codigoCMPDataGridViewTextBoxColumn, "codigoCMPDataGridViewTextBoxColumn");
            this.codigoCMPDataGridViewTextBoxColumn.Name = "codigoCMPDataGridViewTextBoxColumn";
            this.codigoCMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeCMPDataGridViewTextBoxColumn
            // 
            this.nomeCMPDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomeCMPDataGridViewTextBoxColumn.DataPropertyName = "NomeCMP";
            resources.ApplyResources(this.nomeCMPDataGridViewTextBoxColumn, "nomeCMPDataGridViewTextBoxColumn");
            this.nomeCMPDataGridViewTextBoxColumn.Name = "nomeCMPDataGridViewTextBoxColumn";
            this.nomeCMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nMDLLDataGridViewTextBoxColumn
            // 
            this.nMDLLDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMDLLDataGridViewTextBoxColumn.DataPropertyName = "NM_DLL";
            resources.ApplyResources(this.nMDLLDataGridViewTextBoxColumn, "nMDLLDataGridViewTextBoxColumn");
            this.nMDLLDataGridViewTextBoxColumn.Name = "nMDLLDataGridViewTextBoxColumn";
            this.nMDLLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RadioCheckGroup";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Status_Obrigatorio
            // 
            this.Status_Obrigatorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status_Obrigatorio.DataPropertyName = "Status_Obrigatorio";
            resources.ApplyResources(this.Status_Obrigatorio, "Status_Obrigatorio");
            this.Status_Obrigatorio.Name = "Status_Obrigatorio";
            this.Status_Obrigatorio.ReadOnly = true;
            // 
            // Status_Null
            // 
            this.Status_Null.DataPropertyName = "Status_Null";
            resources.ApplyResources(this.Status_Null, "Status_Null");
            this.Status_Null.Name = "Status_Null";
            this.Status_Null.ReadOnly = true;
            // 
            // NM_CampoFormat
            // 
            this.NM_CampoFormat.AccessibleDescription = null;
            this.NM_CampoFormat.AccessibleName = null;
            resources.ApplyResources(this.NM_CampoFormat, "NM_CampoFormat");
            this.NM_CampoFormat.BackColor = System.Drawing.SystemColors.Window;
            this.NM_CampoFormat.BackgroundImage = null;
            this.NM_CampoFormat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_CampoFormat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "NM_CampoFormat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_CampoFormat.Name = "NM_CampoFormat";
            this.NM_CampoFormat.NM_Alias = "";
            this.NM_CampoFormat.NM_Campo = "";
            this.NM_CampoFormat.NM_CampoBusca = "";
            this.NM_CampoFormat.NM_Param = "";
            this.NM_CampoFormat.QTD_Zero = 0;
            this.NM_CampoFormat.ST_AutoInc = false;
            this.NM_CampoFormat.ST_DisableAuto = false;
            this.NM_CampoFormat.ST_Float = false;
            this.NM_CampoFormat.ST_Gravar = true;
            this.NM_CampoFormat.ST_Int = false;
            this.NM_CampoFormat.ST_LimpaCampo = true;
            this.NM_CampoFormat.ST_NotNull = true;
            this.NM_CampoFormat.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cb_NMClasse
            // 
            this.cb_NMClasse.AccessibleDescription = null;
            this.cb_NMClasse.AccessibleName = null;
            resources.ApplyResources(this.cb_NMClasse, "cb_NMClasse");
            this.cb_NMClasse.BackgroundImage = null;
            this.cb_NMClasse.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_ParamClasse, "NM_Classe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_NMClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_NMClasse.Font = null;
            this.cb_NMClasse.FormattingEnabled = true;
            this.cb_NMClasse.Items.AddRange(new object[] {
            resources.GetString("cb_NMClasse.Items"),
            resources.GetString("cb_NMClasse.Items1")});
            this.cb_NMClasse.Name = "cb_NMClasse";
            this.cb_NMClasse.NM_Alias = "";
            this.cb_NMClasse.NM_Campo = "";
            this.cb_NMClasse.NM_Param = "";
            this.cb_NMClasse.ST_Gravar = false;
            this.cb_NMClasse.ST_LimparCampo = true;
            this.cb_NMClasse.ST_NotNull = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Valor
            // 
            this.Valor.AccessibleDescription = null;
            this.Valor.AccessibleName = null;
            resources.ApplyResources(this.Valor, "Valor");
            this.Valor.BackColor = System.Drawing.SystemColors.Window;
            this.Valor.BackgroundImage = null;
            this.Valor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Valor.Name = "Valor";
            this.Valor.NM_Alias = "";
            this.Valor.NM_Campo = "NM_Param";
            this.Valor.NM_CampoBusca = "NM_Param";
            this.Valor.NM_Param = "@P_NM_PARAM";
            this.Valor.QTD_Zero = 0;
            this.Valor.ST_AutoInc = false;
            this.Valor.ST_DisableAuto = false;
            this.Valor.ST_Float = false;
            this.Valor.ST_Gravar = true;
            this.Valor.ST_Int = false;
            this.Valor.ST_LimpaCampo = true;
            this.Valor.ST_NotNull = false;
            this.Valor.ST_PrimaryKey = false;
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Descricao
            // 
            this.Descricao.AccessibleDescription = null;
            this.Descricao.AccessibleName = null;
            resources.ApplyResources(this.Descricao, "Descricao");
            this.Descricao.BackColor = System.Drawing.SystemColors.Window;
            this.Descricao.BackgroundImage = null;
            this.Descricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Descricao.Name = "Descricao";
            this.Descricao.NM_Alias = "";
            this.Descricao.NM_Campo = "NM_Param";
            this.Descricao.NM_CampoBusca = "NM_Param";
            this.Descricao.NM_Param = "@P_NM_PARAM";
            this.Descricao.QTD_Zero = 0;
            this.Descricao.ST_AutoInc = false;
            this.Descricao.ST_DisableAuto = false;
            this.Descricao.ST_Float = false;
            this.Descricao.ST_Gravar = true;
            this.Descricao.ST_Int = false;
            this.Descricao.ST_LimpaCampo = true;
            this.Descricao.ST_NotNull = false;
            this.Descricao.ST_PrimaryKey = false;
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // RadioCheckGroup
            // 
            this.RadioCheckGroup.AccessibleDescription = null;
            this.RadioCheckGroup.AccessibleName = null;
            resources.ApplyResources(this.RadioCheckGroup, "RadioCheckGroup");
            this.RadioCheckGroup.BackColor = System.Drawing.SystemColors.Window;
            this.RadioCheckGroup.BackgroundImage = null;
            this.RadioCheckGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RadioCheckGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "RadioCheckGroup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RadioCheckGroup.Name = "RadioCheckGroup";
            this.RadioCheckGroup.NM_Alias = "";
            this.RadioCheckGroup.NM_Campo = "NM_Param";
            this.RadioCheckGroup.NM_CampoBusca = "NM_Param";
            this.RadioCheckGroup.NM_Param = "@P_NM_PARAM";
            this.RadioCheckGroup.QTD_Zero = 0;
            this.RadioCheckGroup.ReadOnly = true;
            this.RadioCheckGroup.ST_AutoInc = false;
            this.RadioCheckGroup.ST_DisableAuto = false;
            this.RadioCheckGroup.ST_Float = false;
            this.RadioCheckGroup.ST_Gravar = true;
            this.RadioCheckGroup.ST_Int = false;
            this.RadioCheckGroup.ST_LimpaCampo = true;
            this.RadioCheckGroup.ST_NotNull = false;
            this.RadioCheckGroup.ST_PrimaryKey = false;
            // 
            // Add
            // 
            this.Add.AccessibleDescription = null;
            this.Add.AccessibleName = null;
            resources.ApplyResources(this.Add, "Add");
            this.Add.BackgroundImage = null;
            this.Add.Font = null;
            this.Add.Name = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // cb_STObrigatorio
            // 
            this.cb_STObrigatorio.AccessibleDescription = null;
            this.cb_STObrigatorio.AccessibleName = null;
            resources.ApplyResources(this.cb_STObrigatorio, "cb_STObrigatorio");
            this.cb_STObrigatorio.BackgroundImage = null;
            this.cb_STObrigatorio.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_ParamClasse, "St_ObrigatorioBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_STObrigatorio.Name = "cb_STObrigatorio";
            this.cb_STObrigatorio.NM_Alias = "";
            this.cb_STObrigatorio.NM_Campo = "";
            this.cb_STObrigatorio.NM_Param = "";
            this.cb_STObrigatorio.ST_Gravar = false;
            this.cb_STObrigatorio.ST_LimparCampo = true;
            this.cb_STObrigatorio.ST_NotNull = false;
            this.cb_STObrigatorio.UseVisualStyleBackColor = true;
            this.cb_STObrigatorio.Vl_False = "N";
            this.cb_STObrigatorio.Vl_True = "S";
            // 
            // cb_Null
            // 
            this.cb_Null.AccessibleDescription = null;
            this.cb_Null.AccessibleName = null;
            resources.ApplyResources(this.cb_Null, "cb_Null");
            this.cb_Null.BackgroundImage = null;
            this.cb_Null.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_ParamClasse, "St_NullBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_Null.Name = "cb_Null";
            this.cb_Null.NM_Alias = "";
            this.cb_Null.NM_Campo = "";
            this.cb_Null.NM_Param = "";
            this.cb_Null.ST_Gravar = false;
            this.cb_Null.ST_LimparCampo = true;
            this.cb_Null.ST_NotNull = false;
            this.cb_Null.UseVisualStyleBackColor = true;
            this.cb_Null.Vl_False = "N";
            this.cb_Null.Vl_True = "S";
            // 
            // bb_Limpar
            // 
            this.bb_Limpar.AccessibleDescription = null;
            this.bb_Limpar.AccessibleName = null;
            resources.ApplyResources(this.bb_Limpar, "bb_Limpar");
            this.bb_Limpar.BackgroundImage = null;
            this.bb_Limpar.Font = null;
            this.bb_Limpar.Name = "bb_Limpar";
            this.bb_Limpar.UseVisualStyleBackColor = true;
            this.bb_Limpar.Click += new System.EventHandler(this.bb_Limpar_Click);
            // 
            // cbNMDLL
            // 
            this.cbNMDLL.AccessibleDescription = null;
            this.cbNMDLL.AccessibleName = null;
            resources.ApplyResources(this.cbNMDLL, "cbNMDLL");
            this.cbNMDLL.BackgroundImage = null;
            this.cbNMDLL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_ParamClasse, "NM_DLL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbNMDLL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNMDLL.Font = null;
            this.cbNMDLL.FormattingEnabled = true;
            this.cbNMDLL.Name = "cbNMDLL";
            this.cbNMDLL.NM_Alias = "";
            this.cbNMDLL.NM_Campo = "";
            this.cbNMDLL.NM_Param = "";
            this.cbNMDLL.ST_Gravar = false;
            this.cbNMDLL.ST_LimparCampo = true;
            this.cbNMDLL.ST_NotNull = false;
            this.cbNMDLL.SelectedIndexChanged += new System.EventHandler(this.cbNMDLL_SelectedIndexChanged);
            // 
            // TFCad_ParamClasse
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_ParamClasse";
            this.Load += new System.EventHandler(this.TFCad_ParamClasse_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_ParamClasse_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_ParamClasse)).EndInit();
            this.groupBoxBusca.ResumeLayout(false);
            this.groupBoxBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BN_ParamClasse)).EndInit();
            this.BN_ParamClasse.ResumeLayout(false);
            this.BN_ParamClasse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_ParamClasse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNMCampoFormat;
        private System.Windows.Forms.Label labelIDParamClasse;
        private System.Windows.Forms.Label labelNMParam;
        private Componentes.EditDefault ID_ParamClasse;
        private Componentes.EditDefault NM_Param;
        private System.Windows.Forms.Label labelCodigoCMP;
        private Componentes.EditDefault CodigoCMP;
        private System.Windows.Forms.Label labelTPDado;
        private System.Windows.Forms.Label labelNMDLL;
        private System.Windows.Forms.Label labelCondBusca;
        private Componentes.EditDefault CondicaoBusca;
        private System.Windows.Forms.Label labelDSCMP;
        private Componentes.EditDefault NomeCMP;
        private Componentes.ComboBoxDefault cb_TP_Dado;
        private System.Windows.Forms.Label labelNMClasse;
        private System.Windows.Forms.GroupBox groupBoxBusca;
        private Componentes.DataGridDefault grid_ParamClasse;
        private System.Windows.Forms.BindingSource BS_ParamClasse;
        private System.Windows.Forms.BindingNavigator BN_ParamClasse;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault NM_CampoFormat;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cb_NMClasse;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Descricao;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Valor;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault RadioCheckGroup;
        private System.Windows.Forms.Button Add;
        private Componentes.CheckBoxDefault cb_STObrigatorio;
        private Componentes.CheckBoxDefault cb_Null;
        private System.Windows.Forms.Button bb_Limpar;
        private Componentes.ComboBoxDefault cbNMDLL;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDParamClasseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMParamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMCampoFormatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMClasseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tPDadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoCMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMDLLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Obrigatorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status_Null;
    }
}
