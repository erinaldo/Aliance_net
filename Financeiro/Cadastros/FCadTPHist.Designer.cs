namespace Financeiro.Cadastros
{
    partial class TFCadTPHist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTPHist));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.tphistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstphistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_caixagerencialbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_financeirobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_quitacoesbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_faturamentobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsTpHist = new System.Windows.Forms.BindingSource(this.components);
            this.LB_Tp_Hist = new System.Windows.Forms.Label();
            this.Tp_Hist = new Componentes.EditDefault(this.components);
            this.DS_TpHist = new Componentes.EditDefault(this.components);
            this.ST_CaixaGerencial = new Componentes.CheckBoxDefault(this.components);
            this.ST_Financeiro = new Componentes.CheckBoxDefault(this.components);
            this.ST_Quitacoes = new Componentes.CheckBoxDefault(this.components);
            this.ST_Faturamento = new Componentes.CheckBoxDefault(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.LB_DS_TpHist = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpHist)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.LB_Tp_Hist);
            this.pDados.Controls.Add(this.LB_DS_TpHist);
            this.pDados.Controls.Add(this.Tp_Hist);
            this.pDados.Controls.Add(this.DS_TpHist);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_TPHIST";
            this.pDados.NM_ProcGravar = "IA_FIN_TPHIST";
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
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
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
            this.tphistDataGridViewTextBoxColumn,
            this.dstphistDataGridViewTextBoxColumn,
            this.St_caixagerencialbool,
            this.St_financeirobool,
            this.St_quitacoesbool,
            this.St_faturamentobool});
            this.gCadastro.DataSource = this.bsTpHist;
            this.gCadastro.Font = null;
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
            // 
            // tphistDataGridViewTextBoxColumn
            // 
            this.tphistDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tphistDataGridViewTextBoxColumn.DataPropertyName = "Tp_hist";
            resources.ApplyResources(this.tphistDataGridViewTextBoxColumn, "tphistDataGridViewTextBoxColumn");
            this.tphistDataGridViewTextBoxColumn.Name = "tphistDataGridViewTextBoxColumn";
            this.tphistDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dstphistDataGridViewTextBoxColumn
            // 
            this.dstphistDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstphistDataGridViewTextBoxColumn.DataPropertyName = "Ds_tphist";
            resources.ApplyResources(this.dstphistDataGridViewTextBoxColumn, "dstphistDataGridViewTextBoxColumn");
            this.dstphistDataGridViewTextBoxColumn.Name = "dstphistDataGridViewTextBoxColumn";
            this.dstphistDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // St_caixagerencialbool
            // 
            this.St_caixagerencialbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_caixagerencialbool.DataPropertyName = "St_caixagerencialbool";
            resources.ApplyResources(this.St_caixagerencialbool, "St_caixagerencialbool");
            this.St_caixagerencialbool.Name = "St_caixagerencialbool";
            this.St_caixagerencialbool.ReadOnly = true;
            // 
            // St_financeirobool
            // 
            this.St_financeirobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_financeirobool.DataPropertyName = "St_financeirobool";
            resources.ApplyResources(this.St_financeirobool, "St_financeirobool");
            this.St_financeirobool.Name = "St_financeirobool";
            this.St_financeirobool.ReadOnly = true;
            // 
            // St_quitacoesbool
            // 
            this.St_quitacoesbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_quitacoesbool.DataPropertyName = "St_quitacoesbool";
            resources.ApplyResources(this.St_quitacoesbool, "St_quitacoesbool");
            this.St_quitacoesbool.Name = "St_quitacoesbool";
            this.St_quitacoesbool.ReadOnly = true;
            // 
            // St_faturamentobool
            // 
            this.St_faturamentobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_faturamentobool.DataPropertyName = "St_faturamentobool";
            resources.ApplyResources(this.St_faturamentobool, "St_faturamentobool");
            this.St_faturamentobool.Name = "St_faturamentobool";
            this.St_faturamentobool.ReadOnly = true;
            // 
            // bsTpHist
            // 
            this.bsTpHist.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_TPHist);
            // 
            // LB_Tp_Hist
            // 
            this.LB_Tp_Hist.AccessibleDescription = null;
            this.LB_Tp_Hist.AccessibleName = null;
            resources.ApplyResources(this.LB_Tp_Hist, "LB_Tp_Hist");
            this.LB_Tp_Hist.Name = "LB_Tp_Hist";
            // 
            // Tp_Hist
            // 
            this.Tp_Hist.AccessibleDescription = null;
            this.Tp_Hist.AccessibleName = null;
            resources.ApplyResources(this.Tp_Hist, "Tp_Hist");
            this.Tp_Hist.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_Hist.BackgroundImage = null;
            this.Tp_Hist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_Hist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpHist, "Tp_hist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Tp_Hist.Font = null;
            this.Tp_Hist.Name = "Tp_Hist";
            this.Tp_Hist.NM_Alias = "";
            this.Tp_Hist.NM_Campo = "Tp_Hist";
            this.Tp_Hist.NM_CampoBusca = "Tp_Hist";
            this.Tp_Hist.NM_Param = "@P_TP_HIST";
            this.Tp_Hist.QTD_Zero = 0;
            this.Tp_Hist.ST_AutoInc = false;
            this.Tp_Hist.ST_DisableAuto = true;
            this.Tp_Hist.ST_Float = false;
            this.Tp_Hist.ST_Gravar = true;
            this.Tp_Hist.ST_Int = true;
            this.Tp_Hist.ST_LimpaCampo = true;
            this.Tp_Hist.ST_NotNull = true;
            this.Tp_Hist.ST_PrimaryKey = true;
            // 
            // DS_TpHist
            // 
            this.DS_TpHist.AccessibleDescription = null;
            this.DS_TpHist.AccessibleName = null;
            resources.ApplyResources(this.DS_TpHist, "DS_TpHist");
            this.DS_TpHist.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TpHist.BackgroundImage = null;
            this.DS_TpHist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TpHist.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpHist, "Ds_tphist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_TpHist.Font = null;
            this.DS_TpHist.Name = "DS_TpHist";
            this.DS_TpHist.NM_Alias = "";
            this.DS_TpHist.NM_Campo = "DS_TpHist";
            this.DS_TpHist.NM_CampoBusca = "DS_TpHist";
            this.DS_TpHist.NM_Param = "@P_DS_TPHIST";
            this.DS_TpHist.QTD_Zero = 0;
            this.DS_TpHist.ST_AutoInc = false;
            this.DS_TpHist.ST_DisableAuto = false;
            this.DS_TpHist.ST_Float = false;
            this.DS_TpHist.ST_Gravar = true;
            this.DS_TpHist.ST_Int = false;
            this.DS_TpHist.ST_LimpaCampo = true;
            this.DS_TpHist.ST_NotNull = false;
            this.DS_TpHist.ST_PrimaryKey = false;
            // 
            // ST_CaixaGerencial
            // 
            this.ST_CaixaGerencial.AccessibleDescription = null;
            this.ST_CaixaGerencial.AccessibleName = null;
            resources.ApplyResources(this.ST_CaixaGerencial, "ST_CaixaGerencial");
            this.ST_CaixaGerencial.BackgroundImage = null;
            this.ST_CaixaGerencial.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpHist, "St_caixagerencialbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_CaixaGerencial.Name = "ST_CaixaGerencial";
            this.ST_CaixaGerencial.NM_Alias = "";
            this.ST_CaixaGerencial.NM_Campo = "ST_CaixaGerencial";
            this.ST_CaixaGerencial.NM_Param = "@P_ST_CAIXAGERENCIAL";
            this.ST_CaixaGerencial.ST_Gravar = true;
            this.ST_CaixaGerencial.ST_LimparCampo = true;
            this.ST_CaixaGerencial.ST_NotNull = false;
            this.ST_CaixaGerencial.UseVisualStyleBackColor = true;
            this.ST_CaixaGerencial.Vl_False = "N";
            this.ST_CaixaGerencial.Vl_True = "S";
            // 
            // ST_Financeiro
            // 
            this.ST_Financeiro.AccessibleDescription = null;
            this.ST_Financeiro.AccessibleName = null;
            resources.ApplyResources(this.ST_Financeiro, "ST_Financeiro");
            this.ST_Financeiro.BackgroundImage = null;
            this.ST_Financeiro.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpHist, "St_financeirobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Financeiro.Name = "ST_Financeiro";
            this.ST_Financeiro.NM_Alias = "";
            this.ST_Financeiro.NM_Campo = "ST_Financeiro";
            this.ST_Financeiro.NM_Param = "@P_ST_FINANCEIRO";
            this.ST_Financeiro.ST_Gravar = true;
            this.ST_Financeiro.ST_LimparCampo = true;
            this.ST_Financeiro.ST_NotNull = false;
            this.ST_Financeiro.UseVisualStyleBackColor = true;
            this.ST_Financeiro.Vl_False = "N";
            this.ST_Financeiro.Vl_True = "S";
            // 
            // ST_Quitacoes
            // 
            this.ST_Quitacoes.AccessibleDescription = null;
            this.ST_Quitacoes.AccessibleName = null;
            resources.ApplyResources(this.ST_Quitacoes, "ST_Quitacoes");
            this.ST_Quitacoes.BackgroundImage = null;
            this.ST_Quitacoes.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpHist, "St_quitacoesbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Quitacoes.Name = "ST_Quitacoes";
            this.ST_Quitacoes.NM_Alias = "";
            this.ST_Quitacoes.NM_Campo = "ST_Quitacoes";
            this.ST_Quitacoes.NM_Param = "@P_ST_QUITACOES";
            this.ST_Quitacoes.ST_Gravar = true;
            this.ST_Quitacoes.ST_LimparCampo = true;
            this.ST_Quitacoes.ST_NotNull = false;
            this.ST_Quitacoes.UseVisualStyleBackColor = true;
            this.ST_Quitacoes.Vl_False = "N";
            this.ST_Quitacoes.Vl_True = "S";
            // 
            // ST_Faturamento
            // 
            this.ST_Faturamento.AccessibleDescription = null;
            this.ST_Faturamento.AccessibleName = null;
            resources.ApplyResources(this.ST_Faturamento, "ST_Faturamento");
            this.ST_Faturamento.BackgroundImage = null;
            this.ST_Faturamento.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsTpHist, "St_faturamentobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Faturamento.Name = "ST_Faturamento";
            this.ST_Faturamento.NM_Alias = "";
            this.ST_Faturamento.NM_Campo = "ST_Faturamento";
            this.ST_Faturamento.NM_Param = "@P_ST_FATURAMENTO";
            this.ST_Faturamento.ST_Gravar = true;
            this.ST_Faturamento.ST_LimparCampo = true;
            this.ST_Faturamento.ST_NotNull = false;
            this.ST_Faturamento.UseVisualStyleBackColor = true;
            this.ST_Faturamento.Vl_False = "N";
            this.ST_Faturamento.Vl_True = "S";
            // 
            // radioGroup1
            // 
            this.radioGroup1.AccessibleDescription = null;
            this.radioGroup1.AccessibleName = null;
            resources.ApplyResources(this.radioGroup1, "radioGroup1");
            this.radioGroup1.BackgroundImage = null;
            this.radioGroup1.Controls.Add(this.panelDados1);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabStop = false;
            // 
            // panelDados1
            // 
            this.panelDados1.AccessibleDescription = null;
            this.panelDados1.AccessibleName = null;
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BackgroundImage = null;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.ST_CaixaGerencial);
            this.panelDados1.Controls.Add(this.ST_Faturamento);
            this.panelDados1.Controls.Add(this.ST_Financeiro);
            this.panelDados1.Controls.Add(this.ST_Quitacoes);
            this.panelDados1.Font = null;
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // LB_DS_TpHist
            // 
            this.LB_DS_TpHist.AccessibleDescription = null;
            this.LB_DS_TpHist.AccessibleName = null;
            resources.ApplyResources(this.LB_DS_TpHist, "LB_DS_TpHist");
            this.LB_DS_TpHist.Name = "LB_DS_TpHist";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsTpHist;
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
            // TFCadTPHist
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadTPHist";
            this.Load += new System.EventHandler(this.TFCadTPHist_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadTPHist_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpHist)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_Tp_Hist;



        private Componentes.EditDefault Tp_Hist;
        private Componentes.EditDefault DS_TpHist;
        private Componentes.CheckBoxDefault ST_CaixaGerencial;
        private Componentes.CheckBoxDefault ST_Financeiro;
        private Componentes.CheckBoxDefault ST_Quitacoes;
        private Componentes.CheckBoxDefault ST_Faturamento;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label LB_DS_TpHist;
        private System.Windows.Forms.BindingSource bsTpHist;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tphistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstphistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_caixagerencialbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_financeirobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_quitacoesbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_faturamentobool;






    }
}
