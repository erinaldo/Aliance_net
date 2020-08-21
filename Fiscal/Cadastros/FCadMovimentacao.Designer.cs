namespace Fiscal.Cadastros
{
    partial class TFCadMovimentacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMovimentacao));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.vCd_movimentacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_dadosAdicionais_dentroestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_dadosAdicionais_foraestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_dadosAdicionais_internacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdhistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpmovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bs_CadMovimentacao = new System.Windows.Forms.BindingSource(this.components);
            this.LB_CD_Movimentacao = new System.Windows.Forms.Label();
            this.LB_DS_Movimentacao = new System.Windows.Forms.Label();
            this.LB_CD_Historico = new System.Windows.Forms.Label();
            this.DS_Movimentacao = new Componentes.EditDefault(this.components);
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.ds_DadosAdicdentroestado = new Componentes.EditDefault(this.components);
            this.BB_DadosAdic_DentroEstado = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CD_DadosAdic_DentroEstado = new Componentes.EditDefault(this.components);
            this.ds_obsfiscaldentroestado = new Componentes.EditDefault(this.components);
            this.bb_obsFisDentro = new System.Windows.Forms.Button();
            this.LB_CD_ObsFiscal_DentroEstado = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_DentroEstado = new Componentes.EditDefault(this.components);
            this.bn_CadMovimentacao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cd_movimentacao = new Componentes.EditDefault(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_DadosAdicForaestado = new Componentes.EditDefault(this.components);
            this.BB_DadosAdic_ForaEstado = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_DadosAdic_ForaEstado = new Componentes.EditDefault(this.components);
            this.ds_obsfiscalforaestado = new Componentes.EditDefault(this.components);
            this.bb_obsFisFora = new System.Windows.Forms.Button();
            this.LB_CD_ObsFiscal_ForaEstado = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_ForaEstado = new Componentes.EditDefault(this.components);
            this.ds_DadosAdicInternacional = new Componentes.EditDefault(this.components);
            this.BB_DadosAdic_Internacional = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CD_DadosAdic_Internacional = new Componentes.EditDefault(this.components);
            this.ds_obsfiscalinternacional = new Componentes.EditDefault(this.components);
            this.BB_Internacional = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_Internacional = new Componentes.EditDefault(this.components);
            this.st_gerarspedpiscofins = new Componentes.CheckBoxDefault(this.components);
            this.ds_centroresultado = new Componentes.EditDefault(this.components);
            this.bb_centroresult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_centroresult = new Componentes.EditDefault(this.components);
            this.st_vendaconsumidor = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadMovimentacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadMovimentacao)).BeginInit();
            this.bn_CadMovimentacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_vendaconsumidor);
            this.pDados.Controls.Add(this.ds_centroresultado);
            this.pDados.Controls.Add(this.bb_centroresult);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_centroresult);
            this.pDados.Controls.Add(this.ds_DadosAdicInternacional);
            this.pDados.Controls.Add(this.ds_DadosAdicForaestado);
            this.pDados.Controls.Add(this.BB_DadosAdic_Internacional);
            this.pDados.Controls.Add(this.ds_DadosAdicdentroestado);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.BB_DadosAdic_ForaEstado);
            this.pDados.Controls.Add(this.CD_DadosAdic_Internacional);
            this.pDados.Controls.Add(this.st_gerarspedpiscofins);
            this.pDados.Controls.Add(this.ds_obsfiscalinternacional);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.BB_Internacional);
            this.pDados.Controls.Add(this.BB_DadosAdic_DentroEstado);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.CD_ObsFiscal_Internacional);
            this.pDados.Controls.Add(this.CD_DadosAdic_ForaEstado);
            this.pDados.Controls.Add(this.ds_obsfiscalforaestado);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.bb_obsFisFora);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.LB_CD_ObsFiscal_ForaEstado);
            this.pDados.Controls.Add(this.CD_ObsFiscal_ForaEstado);
            this.pDados.Controls.Add(this.CD_DadosAdic_DentroEstado);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(this.ds_obsfiscaldentroestado);
            this.pDados.Controls.Add(this.cd_movimentacao);
            this.pDados.Controls.Add(this.bb_obsFisDentro);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.LB_CD_ObsFiscal_DentroEstado);
            this.pDados.Controls.Add(this.CD_ObsFiscal_DentroEstado);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.LB_CD_Movimentacao);
            this.pDados.Controls.Add(this.LB_DS_Movimentacao);
            this.pDados.Controls.Add(this.LB_CD_Historico);
            this.pDados.Controls.Add(this.DS_Movimentacao);
            this.pDados.Controls.Add(this.CD_Historico);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_MOVIMENTACAO";
            this.pDados.NM_ProcGravar = "IA_FIS_MOVIMENTACAO";
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bn_CadMovimentacao);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadMovimentacao, 0);
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
            this.vCd_movimentacao,
            this.dsmovimentacaoDataGridViewTextBoxColumn,
            this.cd_dadosAdicionais_dentroestado,
            this.cd_dadosAdicionais_foraestado,
            this.cd_dadosAdicionais_internacional,
            this.cdhistoricoDataGridViewTextBoxColumn,
            this.tpmovimentoDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bs_CadMovimentacao;
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
            // 
            // vCd_movimentacao
            // 
            this.vCd_movimentacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vCd_movimentacao.DataPropertyName = "Cd_movimentacao";
            resources.ApplyResources(this.vCd_movimentacao, "vCd_movimentacao");
            this.vCd_movimentacao.Name = "vCd_movimentacao";
            this.vCd_movimentacao.ReadOnly = true;
            // 
            // dsmovimentacaoDataGridViewTextBoxColumn
            // 
            this.dsmovimentacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "ds_movimentacao";
            resources.ApplyResources(this.dsmovimentacaoDataGridViewTextBoxColumn, "dsmovimentacaoDataGridViewTextBoxColumn");
            this.dsmovimentacaoDataGridViewTextBoxColumn.Name = "dsmovimentacaoDataGridViewTextBoxColumn";
            this.dsmovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cd_dadosAdicionais_dentroestado
            // 
            this.cd_dadosAdicionais_dentroestado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cd_dadosAdicionais_dentroestado.DataPropertyName = "cd_dadosAdicionais_dentroestado";
            resources.ApplyResources(this.cd_dadosAdicionais_dentroestado, "cd_dadosAdicionais_dentroestado");
            this.cd_dadosAdicionais_dentroestado.Name = "cd_dadosAdicionais_dentroestado";
            this.cd_dadosAdicionais_dentroestado.ReadOnly = true;
            // 
            // cd_dadosAdicionais_foraestado
            // 
            this.cd_dadosAdicionais_foraestado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cd_dadosAdicionais_foraestado.DataPropertyName = "cd_dadosAdicionais_foraestado";
            resources.ApplyResources(this.cd_dadosAdicionais_foraestado, "cd_dadosAdicionais_foraestado");
            this.cd_dadosAdicionais_foraestado.Name = "cd_dadosAdicionais_foraestado";
            this.cd_dadosAdicionais_foraestado.ReadOnly = true;
            // 
            // cd_dadosAdicionais_internacional
            // 
            this.cd_dadosAdicionais_internacional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cd_dadosAdicionais_internacional.DataPropertyName = "cd_dadosAdicionais_internacional";
            resources.ApplyResources(this.cd_dadosAdicionais_internacional, "cd_dadosAdicionais_internacional");
            this.cd_dadosAdicionais_internacional.Name = "cd_dadosAdicionais_internacional";
            this.cd_dadosAdicionais_internacional.ReadOnly = true;
            // 
            // cdhistoricoDataGridViewTextBoxColumn
            // 
            this.cdhistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdhistoricoDataGridViewTextBoxColumn.DataPropertyName = "cd_historico";
            resources.ApplyResources(this.cdhistoricoDataGridViewTextBoxColumn, "cdhistoricoDataGridViewTextBoxColumn");
            this.cdhistoricoDataGridViewTextBoxColumn.Name = "cdhistoricoDataGridViewTextBoxColumn";
            this.cdhistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpmovimentoDataGridViewTextBoxColumn
            // 
            this.tpmovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpmovimentoDataGridViewTextBoxColumn.DataPropertyName = "tp_movimento";
            resources.ApplyResources(this.tpmovimentoDataGridViewTextBoxColumn, "tpmovimentoDataGridViewTextBoxColumn");
            this.tpmovimentoDataGridViewTextBoxColumn.Name = "tpmovimentoDataGridViewTextBoxColumn";
            this.tpmovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bs_CadMovimentacao
            // 
            this.bs_CadMovimentacao.DataSource = typeof(CamadaDados.Fiscal.TList_CadMovimentacao);
            // 
            // LB_CD_Movimentacao
            // 
            resources.ApplyResources(this.LB_CD_Movimentacao, "LB_CD_Movimentacao");
            this.LB_CD_Movimentacao.Name = "LB_CD_Movimentacao";
            // 
            // LB_DS_Movimentacao
            // 
            resources.ApplyResources(this.LB_DS_Movimentacao, "LB_DS_Movimentacao");
            this.LB_DS_Movimentacao.Name = "LB_DS_Movimentacao";
            // 
            // LB_CD_Historico
            // 
            resources.ApplyResources(this.LB_CD_Historico, "LB_CD_Historico");
            this.LB_CD_Historico.Name = "LB_CD_Historico";
            // 
            // DS_Movimentacao
            // 
            this.DS_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Movimentacao, "DS_Movimentacao");
            this.DS_Movimentacao.Name = "DS_Movimentacao";
            this.DS_Movimentacao.NM_Alias = "";
            this.DS_Movimentacao.NM_Campo = "DS_Movimentacao";
            this.DS_Movimentacao.NM_CampoBusca = "DS_Movimentacao";
            this.DS_Movimentacao.NM_Param = "@P_DS_MOVIMENTACAO";
            this.DS_Movimentacao.QTD_Zero = 0;
            this.DS_Movimentacao.ST_AutoInc = false;
            this.DS_Movimentacao.ST_DisableAuto = false;
            this.DS_Movimentacao.ST_Float = false;
            this.DS_Movimentacao.ST_Gravar = true;
            this.DS_Movimentacao.ST_Int = false;
            this.DS_Movimentacao.ST_LimpaCampo = true;
            this.DS_Movimentacao.ST_NotNull = true;
            this.DS_Movimentacao.ST_PrimaryKey = false;
            this.DS_Movimentacao.TextOld = null;
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Historico, "CD_Historico");
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "a";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = false;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TextOld = null;
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // bb_historico
            // 
            resources.ApplyResources(this.bb_historico, "bb_historico");
            this.bb_historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.UseVisualStyleBackColor = true;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_historico, "ds_historico");
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.ReadOnly = true;
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TextOld = null;
            // 
            // ds_DadosAdicdentroestado
            // 
            this.ds_DadosAdicdentroestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicdentroestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicdentroestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicdentroestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_dadosAdicionais_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_DadosAdicdentroestado, "ds_DadosAdicdentroestado");
            this.ds_DadosAdicdentroestado.Name = "ds_DadosAdicdentroestado";
            this.ds_DadosAdicdentroestado.NM_Alias = "";
            this.ds_DadosAdicdentroestado.NM_Campo = "ds_dadosadic_dentroestado";
            this.ds_DadosAdicdentroestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicdentroestado.NM_Param = "@P_DS_DADOSADIC_DENTROESTADO";
            this.ds_DadosAdicdentroestado.QTD_Zero = 0;
            this.ds_DadosAdicdentroestado.ReadOnly = true;
            this.ds_DadosAdicdentroestado.ST_AutoInc = false;
            this.ds_DadosAdicdentroestado.ST_DisableAuto = false;
            this.ds_DadosAdicdentroestado.ST_Float = false;
            this.ds_DadosAdicdentroestado.ST_Gravar = false;
            this.ds_DadosAdicdentroestado.ST_Int = false;
            this.ds_DadosAdicdentroestado.ST_LimpaCampo = true;
            this.ds_DadosAdicdentroestado.ST_NotNull = false;
            this.ds_DadosAdicdentroestado.ST_PrimaryKey = false;
            this.ds_DadosAdicdentroestado.TextOld = null;
            // 
            // BB_DadosAdic_DentroEstado
            // 
            resources.ApplyResources(this.BB_DadosAdic_DentroEstado, "BB_DadosAdic_DentroEstado");
            this.BB_DadosAdic_DentroEstado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_DentroEstado.Name = "BB_DadosAdic_DentroEstado";
            this.BB_DadosAdic_DentroEstado.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_DentroEstado.Click += new System.EventHandler(this.BB_DadosAdic_DentroEstado_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // CD_DadosAdic_DentroEstado
            // 
            this.CD_DadosAdic_DentroEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_DentroEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_DentroEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_DentroEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_dadosAdicionais_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_DadosAdic_DentroEstado, "CD_DadosAdic_DentroEstado");
            this.CD_DadosAdic_DentroEstado.Name = "CD_DadosAdic_DentroEstado";
            this.CD_DadosAdic_DentroEstado.NM_Alias = "a";
            this.CD_DadosAdic_DentroEstado.NM_Campo = "CD_Dadosadic_DentroEstado";
            this.CD_DadosAdic_DentroEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_DentroEstado.NM_Param = "@P_CD_DADOSADIC_DENTROESTADO";
            this.CD_DadosAdic_DentroEstado.QTD_Zero = 0;
            this.CD_DadosAdic_DentroEstado.ST_AutoInc = false;
            this.CD_DadosAdic_DentroEstado.ST_DisableAuto = false;
            this.CD_DadosAdic_DentroEstado.ST_Float = false;
            this.CD_DadosAdic_DentroEstado.ST_Gravar = true;
            this.CD_DadosAdic_DentroEstado.ST_Int = false;
            this.CD_DadosAdic_DentroEstado.ST_LimpaCampo = true;
            this.CD_DadosAdic_DentroEstado.ST_NotNull = false;
            this.CD_DadosAdic_DentroEstado.ST_PrimaryKey = false;
            this.CD_DadosAdic_DentroEstado.TextOld = null;
            this.CD_DadosAdic_DentroEstado.Leave += new System.EventHandler(this.CD_DadosAdic_DentroEstado_Leave);
            // 
            // ds_obsfiscaldentroestado
            // 
            this.ds_obsfiscaldentroestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscaldentroestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscaldentroestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscaldentroestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_obsfiscaldentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_obsfiscaldentroestado, "ds_obsfiscaldentroestado");
            this.ds_obsfiscaldentroestado.Name = "ds_obsfiscaldentroestado";
            this.ds_obsfiscaldentroestado.NM_Alias = "";
            this.ds_obsfiscaldentroestado.NM_Campo = "ds_obsfiscaldentroestado";
            this.ds_obsfiscaldentroestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscaldentroestado.NM_Param = "";
            this.ds_obsfiscaldentroestado.QTD_Zero = 0;
            this.ds_obsfiscaldentroestado.ReadOnly = true;
            this.ds_obsfiscaldentroestado.ST_AutoInc = false;
            this.ds_obsfiscaldentroestado.ST_DisableAuto = false;
            this.ds_obsfiscaldentroestado.ST_Float = false;
            this.ds_obsfiscaldentroestado.ST_Gravar = false;
            this.ds_obsfiscaldentroestado.ST_Int = false;
            this.ds_obsfiscaldentroestado.ST_LimpaCampo = true;
            this.ds_obsfiscaldentroestado.ST_NotNull = false;
            this.ds_obsfiscaldentroestado.ST_PrimaryKey = false;
            this.ds_obsfiscaldentroestado.TextOld = null;
            // 
            // bb_obsFisDentro
            // 
            resources.ApplyResources(this.bb_obsFisDentro, "bb_obsFisDentro");
            this.bb_obsFisDentro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_obsFisDentro.Name = "bb_obsFisDentro";
            this.bb_obsFisDentro.UseVisualStyleBackColor = true;
            this.bb_obsFisDentro.Click += new System.EventHandler(this.bb_obsFisDentro_Click);
            // 
            // LB_CD_ObsFiscal_DentroEstado
            // 
            resources.ApplyResources(this.LB_CD_ObsFiscal_DentroEstado, "LB_CD_ObsFiscal_DentroEstado");
            this.LB_CD_ObsFiscal_DentroEstado.BackColor = System.Drawing.Color.Transparent;
            this.LB_CD_ObsFiscal_DentroEstado.Name = "LB_CD_ObsFiscal_DentroEstado";
            // 
            // CD_ObsFiscal_DentroEstado
            // 
            this.CD_ObsFiscal_DentroEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_DentroEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_DentroEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_DentroEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_obsfiscal_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_ObsFiscal_DentroEstado, "CD_ObsFiscal_DentroEstado");
            this.CD_ObsFiscal_DentroEstado.Name = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_DentroEstado.NM_Alias = "a";
            this.CD_ObsFiscal_DentroEstado.NM_Campo = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_DentroEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_DentroEstado.NM_Param = "@P_CD_OBSFISCAL_DENTROESTADO";
            this.CD_ObsFiscal_DentroEstado.QTD_Zero = 0;
            this.CD_ObsFiscal_DentroEstado.ST_AutoInc = false;
            this.CD_ObsFiscal_DentroEstado.ST_DisableAuto = false;
            this.CD_ObsFiscal_DentroEstado.ST_Float = false;
            this.CD_ObsFiscal_DentroEstado.ST_Gravar = true;
            this.CD_ObsFiscal_DentroEstado.ST_Int = false;
            this.CD_ObsFiscal_DentroEstado.ST_LimpaCampo = true;
            this.CD_ObsFiscal_DentroEstado.ST_NotNull = false;
            this.CD_ObsFiscal_DentroEstado.ST_PrimaryKey = false;
            this.CD_ObsFiscal_DentroEstado.TextOld = null;
            this.CD_ObsFiscal_DentroEstado.Leave += new System.EventHandler(this.CD_ObsFiscal_DentroEstado_Leave);
            // 
            // bn_CadMovimentacao
            // 
            this.bn_CadMovimentacao.AddNewItem = null;
            this.bn_CadMovimentacao.BindingSource = this.bs_CadMovimentacao;
            this.bn_CadMovimentacao.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadMovimentacao.DeleteItem = null;
            resources.ApplyResources(this.bn_CadMovimentacao, "bn_CadMovimentacao");
            this.bn_CadMovimentacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadMovimentacao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadMovimentacao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadMovimentacao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadMovimentacao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadMovimentacao.Name = "bn_CadMovimentacao";
            this.bn_CadMovimentacao.PositionItem = this.bindingNavigatorPositionItem;
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
            // cd_movimentacao
            // 
            this.cd_movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "Cd_movimentacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_movimentacao, "cd_movimentacao");
            this.cd_movimentacao.Name = "cd_movimentacao";
            this.cd_movimentacao.NM_Alias = "a";
            this.cd_movimentacao.NM_Campo = "cd_movimentacao";
            this.cd_movimentacao.NM_CampoBusca = "cd_movimentacao";
            this.cd_movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_movimentacao.QTD_Zero = 0;
            this.cd_movimentacao.ST_AutoInc = false;
            this.cd_movimentacao.ST_DisableAuto = true;
            this.cd_movimentacao.ST_Float = false;
            this.cd_movimentacao.ST_Gravar = true;
            this.cd_movimentacao.ST_Int = false;
            this.cd_movimentacao.ST_LimpaCampo = true;
            this.cd_movimentacao.ST_NotNull = true;
            this.cd_movimentacao.ST_PrimaryKey = true;
            this.cd_movimentacao.TextOld = null;
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bs_CadMovimentacao, "tp_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_movimento, "tp_movimento");
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "a";
            this.tp_movimento.NM_Campo = "tp_movimento";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.SelectedIndexChanged += new System.EventHandler(this.tp_movimento_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ds_DadosAdicForaestado
            // 
            this.ds_DadosAdicForaestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicForaestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicForaestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicForaestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_dadosAdicionais_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_DadosAdicForaestado, "ds_DadosAdicForaestado");
            this.ds_DadosAdicForaestado.Name = "ds_DadosAdicForaestado";
            this.ds_DadosAdicForaestado.NM_Alias = "";
            this.ds_DadosAdicForaestado.NM_Campo = "ds_dadosadic_foraestado";
            this.ds_DadosAdicForaestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicForaestado.NM_Param = "@P_DS_DADOSADIC_FORAESTADO";
            this.ds_DadosAdicForaestado.QTD_Zero = 0;
            this.ds_DadosAdicForaestado.ReadOnly = true;
            this.ds_DadosAdicForaestado.ST_AutoInc = false;
            this.ds_DadosAdicForaestado.ST_DisableAuto = false;
            this.ds_DadosAdicForaestado.ST_Float = false;
            this.ds_DadosAdicForaestado.ST_Gravar = false;
            this.ds_DadosAdicForaestado.ST_Int = false;
            this.ds_DadosAdicForaestado.ST_LimpaCampo = true;
            this.ds_DadosAdicForaestado.ST_NotNull = false;
            this.ds_DadosAdicForaestado.ST_PrimaryKey = false;
            this.ds_DadosAdicForaestado.TextOld = null;
            // 
            // BB_DadosAdic_ForaEstado
            // 
            resources.ApplyResources(this.BB_DadosAdic_ForaEstado, "BB_DadosAdic_ForaEstado");
            this.BB_DadosAdic_ForaEstado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_ForaEstado.Name = "BB_DadosAdic_ForaEstado";
            this.BB_DadosAdic_ForaEstado.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_ForaEstado.Click += new System.EventHandler(this.BB_DadosAdic_ForaEstado_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // CD_DadosAdic_ForaEstado
            // 
            this.CD_DadosAdic_ForaEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_ForaEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_ForaEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_ForaEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_dadosAdicionais_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_DadosAdic_ForaEstado, "CD_DadosAdic_ForaEstado");
            this.CD_DadosAdic_ForaEstado.Name = "CD_DadosAdic_ForaEstado";
            this.CD_DadosAdic_ForaEstado.NM_Alias = "a";
            this.CD_DadosAdic_ForaEstado.NM_Campo = "CD_DadosAdic_ForaEstado";
            this.CD_DadosAdic_ForaEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_ForaEstado.NM_Param = "@P_CD_DADOSADIC_FORAESTADO";
            this.CD_DadosAdic_ForaEstado.QTD_Zero = 0;
            this.CD_DadosAdic_ForaEstado.ST_AutoInc = false;
            this.CD_DadosAdic_ForaEstado.ST_DisableAuto = false;
            this.CD_DadosAdic_ForaEstado.ST_Float = false;
            this.CD_DadosAdic_ForaEstado.ST_Gravar = true;
            this.CD_DadosAdic_ForaEstado.ST_Int = false;
            this.CD_DadosAdic_ForaEstado.ST_LimpaCampo = true;
            this.CD_DadosAdic_ForaEstado.ST_NotNull = false;
            this.CD_DadosAdic_ForaEstado.ST_PrimaryKey = false;
            this.CD_DadosAdic_ForaEstado.TextOld = null;
            this.CD_DadosAdic_ForaEstado.Leave += new System.EventHandler(this.CD_DadosAdic_ForaEstado_Leave);
            // 
            // ds_obsfiscalforaestado
            // 
            this.ds_obsfiscalforaestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscalforaestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscalforaestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscalforaestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_obsfiscalforaestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_obsfiscalforaestado, "ds_obsfiscalforaestado");
            this.ds_obsfiscalforaestado.Name = "ds_obsfiscalforaestado";
            this.ds_obsfiscalforaestado.NM_Alias = "";
            this.ds_obsfiscalforaestado.NM_Campo = "ds_obsfiscalforaestado";
            this.ds_obsfiscalforaestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscalforaestado.NM_Param = "";
            this.ds_obsfiscalforaestado.QTD_Zero = 0;
            this.ds_obsfiscalforaestado.ReadOnly = true;
            this.ds_obsfiscalforaestado.ST_AutoInc = false;
            this.ds_obsfiscalforaestado.ST_DisableAuto = false;
            this.ds_obsfiscalforaestado.ST_Float = false;
            this.ds_obsfiscalforaestado.ST_Gravar = false;
            this.ds_obsfiscalforaestado.ST_Int = false;
            this.ds_obsfiscalforaestado.ST_LimpaCampo = true;
            this.ds_obsfiscalforaestado.ST_NotNull = false;
            this.ds_obsfiscalforaestado.ST_PrimaryKey = false;
            this.ds_obsfiscalforaestado.TextOld = null;
            // 
            // bb_obsFisFora
            // 
            resources.ApplyResources(this.bb_obsFisFora, "bb_obsFisFora");
            this.bb_obsFisFora.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_obsFisFora.Name = "bb_obsFisFora";
            this.bb_obsFisFora.UseVisualStyleBackColor = true;
            this.bb_obsFisFora.Click += new System.EventHandler(this.bb_obsFisFora_Click);
            // 
            // LB_CD_ObsFiscal_ForaEstado
            // 
            resources.ApplyResources(this.LB_CD_ObsFiscal_ForaEstado, "LB_CD_ObsFiscal_ForaEstado");
            this.LB_CD_ObsFiscal_ForaEstado.BackColor = System.Drawing.Color.Transparent;
            this.LB_CD_ObsFiscal_ForaEstado.Name = "LB_CD_ObsFiscal_ForaEstado";
            // 
            // CD_ObsFiscal_ForaEstado
            // 
            this.CD_ObsFiscal_ForaEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_ForaEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_ForaEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_ForaEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_obsfiscal_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_ObsFiscal_ForaEstado, "CD_ObsFiscal_ForaEstado");
            this.CD_ObsFiscal_ForaEstado.Name = "CD_ObsFiscal_ForaEstado";
            this.CD_ObsFiscal_ForaEstado.NM_Alias = "a";
            this.CD_ObsFiscal_ForaEstado.NM_Campo = "CD_ObsFiscal_ForaEstado";
            this.CD_ObsFiscal_ForaEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_ForaEstado.NM_Param = "@P_CD_OBSFISCAL_FORAESTADO";
            this.CD_ObsFiscal_ForaEstado.QTD_Zero = 0;
            this.CD_ObsFiscal_ForaEstado.ST_AutoInc = false;
            this.CD_ObsFiscal_ForaEstado.ST_DisableAuto = false;
            this.CD_ObsFiscal_ForaEstado.ST_Float = false;
            this.CD_ObsFiscal_ForaEstado.ST_Gravar = true;
            this.CD_ObsFiscal_ForaEstado.ST_Int = false;
            this.CD_ObsFiscal_ForaEstado.ST_LimpaCampo = true;
            this.CD_ObsFiscal_ForaEstado.ST_NotNull = false;
            this.CD_ObsFiscal_ForaEstado.ST_PrimaryKey = false;
            this.CD_ObsFiscal_ForaEstado.TextOld = null;
            this.CD_ObsFiscal_ForaEstado.Leave += new System.EventHandler(this.CD_ObsFiscal_ForaEstado_Leave);
            // 
            // ds_DadosAdicInternacional
            // 
            this.ds_DadosAdicInternacional.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicInternacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicInternacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicInternacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_dadosAdicionais_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_DadosAdicInternacional, "ds_DadosAdicInternacional");
            this.ds_DadosAdicInternacional.Name = "ds_DadosAdicInternacional";
            this.ds_DadosAdicInternacional.NM_Alias = "";
            this.ds_DadosAdicInternacional.NM_Campo = "ds_dadosadic_internacional";
            this.ds_DadosAdicInternacional.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicInternacional.NM_Param = "@P_DS_DADOSADIC_INTERNACIONAL";
            this.ds_DadosAdicInternacional.QTD_Zero = 0;
            this.ds_DadosAdicInternacional.ReadOnly = true;
            this.ds_DadosAdicInternacional.ST_AutoInc = false;
            this.ds_DadosAdicInternacional.ST_DisableAuto = false;
            this.ds_DadosAdicInternacional.ST_Float = false;
            this.ds_DadosAdicInternacional.ST_Gravar = false;
            this.ds_DadosAdicInternacional.ST_Int = false;
            this.ds_DadosAdicInternacional.ST_LimpaCampo = true;
            this.ds_DadosAdicInternacional.ST_NotNull = false;
            this.ds_DadosAdicInternacional.ST_PrimaryKey = false;
            this.ds_DadosAdicInternacional.TextOld = null;
            // 
            // BB_DadosAdic_Internacional
            // 
            resources.ApplyResources(this.BB_DadosAdic_Internacional, "BB_DadosAdic_Internacional");
            this.BB_DadosAdic_Internacional.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_Internacional.Name = "BB_DadosAdic_Internacional";
            this.BB_DadosAdic_Internacional.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_Internacional.Click += new System.EventHandler(this.BB_DadosAdic_Internacional_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // CD_DadosAdic_Internacional
            // 
            this.CD_DadosAdic_Internacional.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_Internacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_Internacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_Internacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_dadosAdicionais_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_DadosAdic_Internacional, "CD_DadosAdic_Internacional");
            this.CD_DadosAdic_Internacional.Name = "CD_DadosAdic_Internacional";
            this.CD_DadosAdic_Internacional.NM_Alias = "a";
            this.CD_DadosAdic_Internacional.NM_Campo = "CD_DadosAdic_Internacional";
            this.CD_DadosAdic_Internacional.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_Internacional.NM_Param = "@P_CD_DADOSADIC_INTERNACIONAL";
            this.CD_DadosAdic_Internacional.QTD_Zero = 0;
            this.CD_DadosAdic_Internacional.ST_AutoInc = false;
            this.CD_DadosAdic_Internacional.ST_DisableAuto = false;
            this.CD_DadosAdic_Internacional.ST_Float = false;
            this.CD_DadosAdic_Internacional.ST_Gravar = true;
            this.CD_DadosAdic_Internacional.ST_Int = false;
            this.CD_DadosAdic_Internacional.ST_LimpaCampo = true;
            this.CD_DadosAdic_Internacional.ST_NotNull = false;
            this.CD_DadosAdic_Internacional.ST_PrimaryKey = false;
            this.CD_DadosAdic_Internacional.TextOld = null;
            this.CD_DadosAdic_Internacional.Leave += new System.EventHandler(this.CD_DadosAdic_Internacional_Leave);
            // 
            // ds_obsfiscalinternacional
            // 
            this.ds_obsfiscalinternacional.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscalinternacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscalinternacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscalinternacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "ds_obsfiscalinternacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_obsfiscalinternacional, "ds_obsfiscalinternacional");
            this.ds_obsfiscalinternacional.Name = "ds_obsfiscalinternacional";
            this.ds_obsfiscalinternacional.NM_Alias = "";
            this.ds_obsfiscalinternacional.NM_Campo = "ds_obsfiscalinternacional";
            this.ds_obsfiscalinternacional.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscalinternacional.NM_Param = "";
            this.ds_obsfiscalinternacional.QTD_Zero = 0;
            this.ds_obsfiscalinternacional.ReadOnly = true;
            this.ds_obsfiscalinternacional.ST_AutoInc = false;
            this.ds_obsfiscalinternacional.ST_DisableAuto = false;
            this.ds_obsfiscalinternacional.ST_Float = false;
            this.ds_obsfiscalinternacional.ST_Gravar = false;
            this.ds_obsfiscalinternacional.ST_Int = false;
            this.ds_obsfiscalinternacional.ST_LimpaCampo = true;
            this.ds_obsfiscalinternacional.ST_NotNull = false;
            this.ds_obsfiscalinternacional.ST_PrimaryKey = false;
            this.ds_obsfiscalinternacional.TextOld = null;
            // 
            // BB_Internacional
            // 
            resources.ApplyResources(this.BB_Internacional, "BB_Internacional");
            this.BB_Internacional.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Internacional.Name = "BB_Internacional";
            this.BB_Internacional.UseVisualStyleBackColor = true;
            this.BB_Internacional.Click += new System.EventHandler(this.BB_Internacional_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // CD_ObsFiscal_Internacional
            // 
            this.CD_ObsFiscal_Internacional.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_Internacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_Internacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_Internacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "cd_obsfiscal_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_ObsFiscal_Internacional, "CD_ObsFiscal_Internacional");
            this.CD_ObsFiscal_Internacional.Name = "CD_ObsFiscal_Internacional";
            this.CD_ObsFiscal_Internacional.NM_Alias = "a";
            this.CD_ObsFiscal_Internacional.NM_Campo = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_Internacional.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_Internacional.NM_Param = "@P_CD_OBSFISCAL_INTERNACIONAL";
            this.CD_ObsFiscal_Internacional.QTD_Zero = 0;
            this.CD_ObsFiscal_Internacional.ST_AutoInc = false;
            this.CD_ObsFiscal_Internacional.ST_DisableAuto = false;
            this.CD_ObsFiscal_Internacional.ST_Float = false;
            this.CD_ObsFiscal_Internacional.ST_Gravar = true;
            this.CD_ObsFiscal_Internacional.ST_Int = false;
            this.CD_ObsFiscal_Internacional.ST_LimpaCampo = true;
            this.CD_ObsFiscal_Internacional.ST_NotNull = false;
            this.CD_ObsFiscal_Internacional.ST_PrimaryKey = false;
            this.CD_ObsFiscal_Internacional.TextOld = null;
            this.CD_ObsFiscal_Internacional.Leave += new System.EventHandler(this.CD_ObsFiscal_Internacional_Leave);
            // 
            // st_gerarspedpiscofins
            // 
            resources.ApplyResources(this.st_gerarspedpiscofins, "st_gerarspedpiscofins");
            this.st_gerarspedpiscofins.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_CadMovimentacao, "St_gerarspedpiscofinsbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerarspedpiscofins.Name = "st_gerarspedpiscofins";
            this.st_gerarspedpiscofins.NM_Alias = "";
            this.st_gerarspedpiscofins.NM_Campo = "";
            this.st_gerarspedpiscofins.NM_Param = "";
            this.st_gerarspedpiscofins.ST_Gravar = true;
            this.st_gerarspedpiscofins.ST_LimparCampo = true;
            this.st_gerarspedpiscofins.ST_NotNull = false;
            this.st_gerarspedpiscofins.UseVisualStyleBackColor = true;
            this.st_gerarspedpiscofins.Vl_False = "";
            this.st_gerarspedpiscofins.Vl_True = "";
            // 
            // ds_centroresultado
            // 
            this.ds_centroresultado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "Ds_centroresultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_centroresultado, "ds_centroresultado");
            this.ds_centroresultado.Name = "ds_centroresultado";
            this.ds_centroresultado.NM_Alias = "";
            this.ds_centroresultado.NM_Campo = "ds_centroresultado";
            this.ds_centroresultado.NM_CampoBusca = "ds_centroresultado";
            this.ds_centroresultado.NM_Param = "@P_DS_GRUPOCF";
            this.ds_centroresultado.QTD_Zero = 0;
            this.ds_centroresultado.ReadOnly = true;
            this.ds_centroresultado.ST_AutoInc = false;
            this.ds_centroresultado.ST_DisableAuto = false;
            this.ds_centroresultado.ST_Float = false;
            this.ds_centroresultado.ST_Gravar = false;
            this.ds_centroresultado.ST_Int = false;
            this.ds_centroresultado.ST_LimpaCampo = true;
            this.ds_centroresultado.ST_NotNull = false;
            this.ds_centroresultado.ST_PrimaryKey = false;
            this.ds_centroresultado.TextOld = null;
            // 
            // bb_centroresult
            // 
            resources.ApplyResources(this.bb_centroresult, "bb_centroresult");
            this.bb_centroresult.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresult.Name = "bb_centroresult";
            this.bb_centroresult.UseVisualStyleBackColor = true;
            this.bb_centroresult.Click += new System.EventHandler(this.bb_centroresult_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cd_centroresult
            // 
            this.cd_centroresult.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresult.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadMovimentacao, "Cd_centroresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_centroresult, "cd_centroresult");
            this.cd_centroresult.Name = "cd_centroresult";
            this.cd_centroresult.NM_Alias = "a";
            this.cd_centroresult.NM_Campo = "cd_centroresult";
            this.cd_centroresult.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresult.NM_Param = "@P_CD_HISTORICO";
            this.cd_centroresult.QTD_Zero = 0;
            this.cd_centroresult.ST_AutoInc = false;
            this.cd_centroresult.ST_DisableAuto = false;
            this.cd_centroresult.ST_Float = false;
            this.cd_centroresult.ST_Gravar = true;
            this.cd_centroresult.ST_Int = false;
            this.cd_centroresult.ST_LimpaCampo = true;
            this.cd_centroresult.ST_NotNull = false;
            this.cd_centroresult.ST_PrimaryKey = false;
            this.cd_centroresult.TextOld = null;
            this.cd_centroresult.Leave += new System.EventHandler(this.cd_centroresult_Leave);
            // 
            // st_vendaconsumidor
            // 
            resources.ApplyResources(this.st_vendaconsumidor, "st_vendaconsumidor");
            this.st_vendaconsumidor.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_CadMovimentacao, "St_vendaconsumidorbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_vendaconsumidor.Name = "st_vendaconsumidor";
            this.st_vendaconsumidor.NM_Alias = "";
            this.st_vendaconsumidor.NM_Campo = "";
            this.st_vendaconsumidor.NM_Param = "";
            this.st_vendaconsumidor.ST_Gravar = true;
            this.st_vendaconsumidor.ST_LimparCampo = true;
            this.st_vendaconsumidor.ST_NotNull = false;
            this.st_vendaconsumidor.UseVisualStyleBackColor = true;
            this.st_vendaconsumidor.Vl_False = "";
            this.st_vendaconsumidor.Vl_True = "";
            // 
            // TFCadMovimentacao
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadMovimentacao";
            this.Load += new System.EventHandler(this.TFCadMovimentacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadMovimentacao_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadMovimentacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadMovimentacao)).EndInit();
            this.bn_CadMovimentacao.ResumeLayout(false);
            this.bn_CadMovimentacao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_Movimentacao;
        private System.Windows.Forms.Label LB_DS_Movimentacao;
        private System.Windows.Forms.Label LB_CD_Historico;
        private Componentes.EditDefault DS_Movimentacao;
        private Componentes.EditDefault CD_Historico;
        public System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.BindingNavigator bn_CadMovimentacao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bs_CadMovimentacao;
        private Componentes.EditDefault cd_movimentacao;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.EditDefault ds_DadosAdicForaestado;
        public System.Windows.Forms.Button BB_DadosAdic_ForaEstado;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault CD_DadosAdic_ForaEstado;
        private Componentes.EditDefault ds_obsfiscalforaestado;
        public System.Windows.Forms.Button bb_obsFisFora;
        private System.Windows.Forms.Label LB_CD_ObsFiscal_ForaEstado;
        private Componentes.EditDefault CD_ObsFiscal_ForaEstado;
        private Componentes.EditDefault ds_DadosAdicInternacional;
        public System.Windows.Forms.Button BB_DadosAdic_Internacional;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault CD_DadosAdic_Internacional;
        private Componentes.EditDefault ds_obsfiscalinternacional;
        public System.Windows.Forms.Button BB_Internacional;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault CD_ObsFiscal_Internacional;
        private Componentes.EditDefault ds_DadosAdicdentroestado;
        public System.Windows.Forms.Button BB_DadosAdic_DentroEstado;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault CD_DadosAdic_DentroEstado;
        private Componentes.EditDefault ds_obsfiscaldentroestado;
        public System.Windows.Forms.Button bb_obsFisDentro;
        private System.Windows.Forms.Label LB_CD_ObsFiscal_DentroEstado;
        private Componentes.EditDefault CD_ObsFiscal_DentroEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdobsfiscaldentroestadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdobsfiscalforaestadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdobsfiscalinternacionalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcfopdentroestadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcfopforaestadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcfopinternacionalDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault st_gerarspedpiscofins;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCd_movimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_dadosAdicionais_dentroestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_dadosAdicionais_foraestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_dadosAdicionais_internacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdhistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpmovimentoDataGridViewTextBoxColumn;
        private Componentes.EditDefault ds_centroresultado;
        public System.Windows.Forms.Button bb_centroresult;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_centroresult;
        private Componentes.CheckBoxDefault st_vendaconsumidor;
    }
}
