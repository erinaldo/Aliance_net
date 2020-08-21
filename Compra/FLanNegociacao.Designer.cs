namespace Compra
{
    partial class TFLanNegociacao
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
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanNegociacao));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_EnviarLote = new System.Windows.Forms.ToolStripButton();
            this.bb_encerrar = new System.Windows.Forms.ToolStripButton();
            this.bb_aprovar = new System.Windows.Forms.ToolStripButton();
            this.bb_negfornec = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.pFiltroData = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.rbNegociacao = new Componentes.RadioButtonDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbDtProcessamento = new Componentes.RadioButtonDefault(this.components);
            this.pFiltroValor = new Componentes.PanelDados(this.components);
            this.cbAprovada = new Componentes.CheckBoxDefault(this.components);
            this.cbFechada = new Componentes.CheckBoxDefault(this.components);
            this.cbProcessado = new Componentes.CheckBoxDefault(this.components);
            this.cbCancelado = new Componentes.CheckBoxDefault(this.components);
            this.CB_Abertas = new Componentes.CheckBoxDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.bb_fornecedor = new System.Windows.Forms.Button();
            this.cd_fornecedor = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.bb_grupo = new System.Windows.Forms.Button();
            this.cd_grupo = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.id_negociacao = new Componentes.EditDefault(this.components);
            this.pNegociacao = new Componentes.PanelDados(this.components);
            this.gNegociacao = new Componentes.DataGridDefault(this.components);
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idnegociacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtnegociacaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_fechnegociacaostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsnegociacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsNegociacao = new System.Windows.Forms.BindingSource(this.components);
            this.bnNegociacao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.tlpDetalhe = new System.Windows.Forms.TableLayoutPanel();
            this.gItens = new Componentes.DataGridDefault(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdendfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsendfornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmoedaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsobservacaoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsaprovarreprovarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prazoentregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nm_transportadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPrazoEntrega = new System.Windows.Forms.BindingSource(this.components);
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.btn_Inserir_Item = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar_Item = new System.Windows.Forms.ToolStripButton();
            this.btn_Deleta_Item = new System.Windows.Forms.ToolStripButton();
            this.bnItens = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pFiltroData.SuspendLayout();
            this.pFiltroValor.SuspendLayout();
            this.pNegociacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gNegociacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNegociacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnNegociacao)).BeginInit();
            this.bnNegociacao.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            this.tlpDetalhe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrazoEntrega)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnItens)).BeginInit();
            this.bnItens.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // barraMenu
            // 
            this.barraMenu.AccessibleDescription = null;
            this.barraMenu.AccessibleName = null;
            resources.ApplyResources(this.barraMenu, "barraMenu");
            this.barraMenu.BackgroundImage = null;
            this.barraMenu.Font = null;
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.BB_EnviarLote,
            this.bb_encerrar,
            this.bb_aprovar,
            this.bb_negfornec,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Name = "barraMenu";
            // 
            // BB_Novo
            // 
            this.BB_Novo.AccessibleDescription = null;
            this.BB_Novo.AccessibleName = null;
            resources.ApplyResources(this.BB_Novo, "BB_Novo");
            this.BB_Novo.BackgroundImage = null;
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.AccessibleDescription = null;
            this.BB_Alterar.AccessibleName = null;
            resources.ApplyResources(this.BB_Alterar, "BB_Alterar");
            this.BB_Alterar.BackgroundImage = null;
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AccessibleDescription = null;
            this.BB_Excluir.AccessibleName = null;
            resources.ApplyResources(this.BB_Excluir, "BB_Excluir");
            this.BB_Excluir.BackgroundImage = null;
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
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
            // BB_EnviarLote
            // 
            this.BB_EnviarLote.AccessibleDescription = null;
            this.BB_EnviarLote.AccessibleName = null;
            resources.ApplyResources(this.BB_EnviarLote, "BB_EnviarLote");
            this.BB_EnviarLote.BackgroundImage = null;
            this.BB_EnviarLote.ForeColor = System.Drawing.Color.Green;
            this.BB_EnviarLote.Name = "BB_EnviarLote";
            this.BB_EnviarLote.Click += new System.EventHandler(this.BB_EnviarLote_Click);
            // 
            // bb_encerrar
            // 
            this.bb_encerrar.AccessibleDescription = null;
            this.bb_encerrar.AccessibleName = null;
            resources.ApplyResources(this.bb_encerrar, "bb_encerrar");
            this.bb_encerrar.BackgroundImage = null;
            this.bb_encerrar.ForeColor = System.Drawing.Color.Green;
            this.bb_encerrar.Name = "bb_encerrar";
            this.bb_encerrar.Click += new System.EventHandler(this.bb_encerrar_Click);
            // 
            // bb_aprovar
            // 
            this.bb_aprovar.AccessibleDescription = null;
            this.bb_aprovar.AccessibleName = null;
            resources.ApplyResources(this.bb_aprovar, "bb_aprovar");
            this.bb_aprovar.BackgroundImage = null;
            this.bb_aprovar.ForeColor = System.Drawing.Color.Green;
            this.bb_aprovar.Name = "bb_aprovar";
            this.bb_aprovar.Click += new System.EventHandler(this.bb_aprovar_Click);
            // 
            // bb_negfornec
            // 
            this.bb_negfornec.AccessibleDescription = null;
            this.bb_negfornec.AccessibleName = null;
            resources.ApplyResources(this.bb_negfornec, "bb_negfornec");
            this.bb_negfornec.BackgroundImage = null;
            this.bb_negfornec.ForeColor = System.Drawing.Color.Green;
            this.bb_negfornec.Name = "bb_negfornec";
            this.bb_negfornec.Click += new System.EventHandler(this.bb_negfornec_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.AccessibleDescription = null;
            this.BB_Fechar.AccessibleName = null;
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.BackgroundImage = null;
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.AccessibleDescription = null;
            this.tlpCentral.AccessibleName = null;
            resources.ApplyResources(this.tlpCentral, "tlpCentral");
            this.tlpCentral.BackgroundImage = null;
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pNegociacao, 0, 1);
            this.tlpCentral.Controls.Add(this.pDetalhes, 0, 2);
            this.tlpCentral.Font = null;
            this.tlpCentral.Name = "tlpCentral";
            // 
            // pFiltro
            // 
            this.pFiltro.AccessibleDescription = null;
            this.pFiltro.AccessibleName = null;
            resources.ApplyResources(this.pFiltro, "pFiltro");
            this.pFiltro.BackgroundImage = null;
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.pFiltroData);
            this.pFiltro.Controls.Add(this.pFiltroValor);
            this.pFiltro.Controls.Add(this.label7);
            this.pFiltro.Controls.Add(this.ds_observacao);
            this.pFiltro.Controls.Add(this.bb_condpgto);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.cd_condpgto);
            this.pFiltro.Controls.Add(this.bb_fornecedor);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.cd_fornecedor);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.bb_grupo);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.cd_grupo);
            this.pFiltro.Controls.Add(this.label9);
            this.pFiltro.Controls.Add(this.id_negociacao);
            this.pFiltro.Font = null;
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            // 
            // pFiltroData
            // 
            this.pFiltroData.AccessibleDescription = null;
            this.pFiltroData.AccessibleName = null;
            resources.ApplyResources(this.pFiltroData, "pFiltroData");
            this.pFiltroData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pFiltroData.BackgroundImage = null;
            this.pFiltroData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltroData.Controls.Add(this.DT_Final);
            this.pFiltroData.Controls.Add(this.DT_Inicial);
            this.pFiltroData.Controls.Add(this.rbNegociacao);
            this.pFiltroData.Controls.Add(this.label5);
            this.pFiltroData.Controls.Add(this.label6);
            this.pFiltroData.Controls.Add(this.rbDtProcessamento);
            this.pFiltroData.Font = null;
            this.pFiltroData.Name = "pFiltroData";
            this.pFiltroData.NM_ProcDeletar = "";
            this.pFiltroData.NM_ProcGravar = "";
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
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.AccessibleDescription = null;
            this.DT_Inicial.AccessibleName = null;
            resources.ApplyResources(this.DT_Inicial, "DT_Inicial");
            this.DT_Inicial.BackgroundImage = null;
            this.DT_Inicial.Font = null;
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.NM_Alias = "";
            this.DT_Inicial.NM_Campo = "";
            this.DT_Inicial.NM_CampoBusca = "";
            this.DT_Inicial.NM_Param = "";
            this.DT_Inicial.Operador = "";
            this.DT_Inicial.ST_Gravar = false;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = false;
            this.DT_Inicial.ST_PrimaryKey = false;
            // 
            // rbNegociacao
            // 
            this.rbNegociacao.AccessibleDescription = null;
            this.rbNegociacao.AccessibleName = null;
            resources.ApplyResources(this.rbNegociacao, "rbNegociacao");
            this.rbNegociacao.BackgroundImage = null;
            this.rbNegociacao.Checked = true;
            this.rbNegociacao.Font = null;
            this.rbNegociacao.Name = "rbNegociacao";
            this.rbNegociacao.TabStop = true;
            this.rbNegociacao.UseVisualStyleBackColor = true;
            this.rbNegociacao.Valor = "A";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Font = null;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Font = null;
            this.label6.Name = "label6";
            // 
            // rbDtProcessamento
            // 
            this.rbDtProcessamento.AccessibleDescription = null;
            this.rbDtProcessamento.AccessibleName = null;
            resources.ApplyResources(this.rbDtProcessamento, "rbDtProcessamento");
            this.rbDtProcessamento.BackgroundImage = null;
            this.rbDtProcessamento.Font = null;
            this.rbDtProcessamento.Name = "rbDtProcessamento";
            this.rbDtProcessamento.UseVisualStyleBackColor = true;
            this.rbDtProcessamento.Valor = "P";
            // 
            // pFiltroValor
            // 
            this.pFiltroValor.AccessibleDescription = null;
            this.pFiltroValor.AccessibleName = null;
            resources.ApplyResources(this.pFiltroValor, "pFiltroValor");
            this.pFiltroValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pFiltroValor.BackgroundImage = null;
            this.pFiltroValor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFiltroValor.Controls.Add(this.cbAprovada);
            this.pFiltroValor.Controls.Add(this.cbFechada);
            this.pFiltroValor.Controls.Add(this.cbProcessado);
            this.pFiltroValor.Controls.Add(this.cbCancelado);
            this.pFiltroValor.Controls.Add(this.CB_Abertas);
            this.pFiltroValor.Font = null;
            this.pFiltroValor.Name = "pFiltroValor";
            this.pFiltroValor.NM_ProcDeletar = "";
            this.pFiltroValor.NM_ProcGravar = "";
            // 
            // cbAprovada
            // 
            this.cbAprovada.AccessibleDescription = null;
            this.cbAprovada.AccessibleName = null;
            resources.ApplyResources(this.cbAprovada, "cbAprovada");
            this.cbAprovada.BackgroundImage = null;
            this.cbAprovada.ForeColor = System.Drawing.Color.Blue;
            this.cbAprovada.Name = "cbAprovada";
            this.cbAprovada.NM_Alias = "";
            this.cbAprovada.NM_Campo = "";
            this.cbAprovada.NM_Param = "";
            this.cbAprovada.ST_Gravar = false;
            this.cbAprovada.ST_LimparCampo = true;
            this.cbAprovada.ST_NotNull = false;
            this.cbAprovada.UseMnemonic = false;
            this.cbAprovada.UseVisualStyleBackColor = true;
            this.cbAprovada.Vl_False = "";
            this.cbAprovada.Vl_True = "";
            // 
            // cbFechada
            // 
            this.cbFechada.AccessibleDescription = null;
            this.cbFechada.AccessibleName = null;
            resources.ApplyResources(this.cbFechada, "cbFechada");
            this.cbFechada.BackgroundImage = null;
            this.cbFechada.ForeColor = System.Drawing.Color.Maroon;
            this.cbFechada.Name = "cbFechada";
            this.cbFechada.NM_Alias = "";
            this.cbFechada.NM_Campo = "";
            this.cbFechada.NM_Param = "";
            this.cbFechada.ST_Gravar = false;
            this.cbFechada.ST_LimparCampo = true;
            this.cbFechada.ST_NotNull = false;
            this.cbFechada.UseMnemonic = false;
            this.cbFechada.UseVisualStyleBackColor = true;
            this.cbFechada.Vl_False = "";
            this.cbFechada.Vl_True = "";
            // 
            // cbProcessado
            // 
            this.cbProcessado.AccessibleDescription = null;
            this.cbProcessado.AccessibleName = null;
            resources.ApplyResources(this.cbProcessado, "cbProcessado");
            this.cbProcessado.BackgroundImage = null;
            this.cbProcessado.ForeColor = System.Drawing.Color.Green;
            this.cbProcessado.Name = "cbProcessado";
            this.cbProcessado.NM_Alias = "";
            this.cbProcessado.NM_Campo = "";
            this.cbProcessado.NM_Param = "";
            this.cbProcessado.ST_Gravar = false;
            this.cbProcessado.ST_LimparCampo = true;
            this.cbProcessado.ST_NotNull = false;
            this.cbProcessado.UseMnemonic = false;
            this.cbProcessado.UseVisualStyleBackColor = true;
            this.cbProcessado.Vl_False = "";
            this.cbProcessado.Vl_True = "";
            // 
            // cbCancelado
            // 
            this.cbCancelado.AccessibleDescription = null;
            this.cbCancelado.AccessibleName = null;
            resources.ApplyResources(this.cbCancelado, "cbCancelado");
            this.cbCancelado.BackgroundImage = null;
            this.cbCancelado.ForeColor = System.Drawing.Color.Red;
            this.cbCancelado.Name = "cbCancelado";
            this.cbCancelado.NM_Alias = "";
            this.cbCancelado.NM_Campo = "";
            this.cbCancelado.NM_Param = "";
            this.cbCancelado.ST_Gravar = false;
            this.cbCancelado.ST_LimparCampo = true;
            this.cbCancelado.ST_NotNull = false;
            this.cbCancelado.UseMnemonic = false;
            this.cbCancelado.UseVisualStyleBackColor = true;
            this.cbCancelado.Vl_False = "";
            this.cbCancelado.Vl_True = "";
            // 
            // CB_Abertas
            // 
            this.CB_Abertas.AccessibleDescription = null;
            this.CB_Abertas.AccessibleName = null;
            resources.ApplyResources(this.CB_Abertas, "CB_Abertas");
            this.CB_Abertas.BackgroundImage = null;
            this.CB_Abertas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Abertas.Name = "CB_Abertas";
            this.CB_Abertas.NM_Alias = "";
            this.CB_Abertas.NM_Campo = "";
            this.CB_Abertas.NM_Param = "";
            this.CB_Abertas.ST_Gravar = false;
            this.CB_Abertas.ST_LimparCampo = true;
            this.CB_Abertas.ST_NotNull = false;
            this.CB_Abertas.UseMnemonic = false;
            this.CB_Abertas.UseVisualStyleBackColor = true;
            this.CB_Abertas.Vl_False = "";
            this.CB_Abertas.Vl_True = "";
            // 
            // label7
            // 
            this.label7.AccessibleDescription = null;
            this.label7.AccessibleName = null;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Font = null;
            this.label7.Name = "label7";
            // 
            // ds_observacao
            // 
            this.ds_observacao.AccessibleDescription = null;
            this.ds_observacao.AccessibleName = null;
            resources.ApplyResources(this.ds_observacao, "ds_observacao");
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BackgroundImage = null;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.Font = null;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.AccessibleDescription = null;
            this.bb_condpgto.AccessibleName = null;
            resources.ApplyResources(this.bb_condpgto, "bb_condpgto");
            this.bb_condpgto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_condpgto.BackgroundImage = null;
            this.bb_condpgto.Font = null;
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.UseVisualStyleBackColor = false;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.AccessibleDescription = null;
            this.cd_condpgto.AccessibleName = null;
            resources.ApplyResources(this.cd_condpgto, "cd_condpgto");
            this.cd_condpgto.BackColor = System.Drawing.Color.White;
            this.cd_condpgto.BackgroundImage = null;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.Font = null;
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "cd_condpgto";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_EMPRESA";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = false;
            this.cd_condpgto.ST_Int = true;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = false;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // bb_fornecedor
            // 
            this.bb_fornecedor.AccessibleDescription = null;
            this.bb_fornecedor.AccessibleName = null;
            resources.ApplyResources(this.bb_fornecedor, "bb_fornecedor");
            this.bb_fornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_fornecedor.BackgroundImage = null;
            this.bb_fornecedor.Font = null;
            this.bb_fornecedor.Name = "bb_fornecedor";
            this.bb_fornecedor.UseVisualStyleBackColor = false;
            this.bb_fornecedor.Click += new System.EventHandler(this.bb_fornecedor_Click);
            // 
            // cd_fornecedor
            // 
            this.cd_fornecedor.AccessibleDescription = null;
            this.cd_fornecedor.AccessibleName = null;
            resources.ApplyResources(this.cd_fornecedor, "cd_fornecedor");
            this.cd_fornecedor.BackColor = System.Drawing.Color.White;
            this.cd_fornecedor.BackgroundImage = null;
            this.cd_fornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_fornecedor.Font = null;
            this.cd_fornecedor.Name = "cd_fornecedor";
            this.cd_fornecedor.NM_Alias = "";
            this.cd_fornecedor.NM_Campo = "cd_clifor";
            this.cd_fornecedor.NM_CampoBusca = "cd_clifor";
            this.cd_fornecedor.NM_Param = "@P_CD_EMPRESA";
            this.cd_fornecedor.QTD_Zero = 0;
            this.cd_fornecedor.ST_AutoInc = false;
            this.cd_fornecedor.ST_DisableAuto = false;
            this.cd_fornecedor.ST_Float = false;
            this.cd_fornecedor.ST_Gravar = false;
            this.cd_fornecedor.ST_Int = true;
            this.cd_fornecedor.ST_LimpaCampo = true;
            this.cd_fornecedor.ST_NotNull = false;
            this.cd_fornecedor.ST_PrimaryKey = false;
            this.cd_fornecedor.Leave += new System.EventHandler(this.cd_fornecedor_Leave);
            // 
            // bb_produto
            // 
            this.bb_produto.AccessibleDescription = null;
            this.bb_produto.AccessibleName = null;
            resources.ApplyResources(this.bb_produto, "bb_produto");
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.BackgroundImage = null;
            this.bb_produto.Font = null;
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.AccessibleDescription = null;
            this.cd_produto.AccessibleName = null;
            resources.ApplyResources(this.cd_produto, "cd_produto");
            this.cd_produto.BackColor = System.Drawing.Color.White;
            this.cd_produto.BackgroundImage = null;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = null;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = false;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // bb_grupo
            // 
            this.bb_grupo.AccessibleDescription = null;
            this.bb_grupo.AccessibleName = null;
            resources.ApplyResources(this.bb_grupo, "bb_grupo");
            this.bb_grupo.BackColor = System.Drawing.SystemColors.Control;
            this.bb_grupo.BackgroundImage = null;
            this.bb_grupo.Font = null;
            this.bb_grupo.Name = "bb_grupo";
            this.bb_grupo.UseVisualStyleBackColor = false;
            this.bb_grupo.Click += new System.EventHandler(this.bb_grupo_Click);
            // 
            // cd_grupo
            // 
            this.cd_grupo.AccessibleDescription = null;
            this.cd_grupo.AccessibleName = null;
            resources.ApplyResources(this.cd_grupo, "cd_grupo");
            this.cd_grupo.BackColor = System.Drawing.Color.White;
            this.cd_grupo.BackgroundImage = null;
            this.cd_grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupo.Font = null;
            this.cd_grupo.Name = "cd_grupo";
            this.cd_grupo.NM_Alias = "";
            this.cd_grupo.NM_Campo = "cd_grupo";
            this.cd_grupo.NM_CampoBusca = "cd_grupo";
            this.cd_grupo.NM_Param = "@P_CD_EMPRESA";
            this.cd_grupo.QTD_Zero = 0;
            this.cd_grupo.ST_AutoInc = false;
            this.cd_grupo.ST_DisableAuto = false;
            this.cd_grupo.ST_Float = false;
            this.cd_grupo.ST_Gravar = false;
            this.cd_grupo.ST_Int = true;
            this.cd_grupo.ST_LimpaCampo = true;
            this.cd_grupo.ST_NotNull = false;
            this.cd_grupo.ST_PrimaryKey = false;
            this.cd_grupo.Leave += new System.EventHandler(this.cd_grupo_Leave);
            // 
            // label9
            // 
            this.label9.AccessibleDescription = null;
            this.label9.AccessibleName = null;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Font = null;
            this.label9.Name = "label9";
            // 
            // id_negociacao
            // 
            this.id_negociacao.AccessibleDescription = null;
            this.id_negociacao.AccessibleName = null;
            resources.ApplyResources(this.id_negociacao, "id_negociacao");
            this.id_negociacao.BackColor = System.Drawing.SystemColors.Window;
            this.id_negociacao.BackgroundImage = null;
            this.id_negociacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_negociacao.Font = null;
            this.id_negociacao.Name = "id_negociacao";
            this.id_negociacao.NM_Alias = "";
            this.id_negociacao.NM_Campo = "";
            this.id_negociacao.NM_CampoBusca = "";
            this.id_negociacao.NM_Param = "";
            this.id_negociacao.QTD_Zero = 0;
            this.id_negociacao.ST_AutoInc = false;
            this.id_negociacao.ST_DisableAuto = false;
            this.id_negociacao.ST_Float = false;
            this.id_negociacao.ST_Gravar = false;
            this.id_negociacao.ST_Int = true;
            this.id_negociacao.ST_LimpaCampo = true;
            this.id_negociacao.ST_NotNull = false;
            this.id_negociacao.ST_PrimaryKey = false;
            // 
            // pNegociacao
            // 
            this.pNegociacao.AccessibleDescription = null;
            this.pNegociacao.AccessibleName = null;
            resources.ApplyResources(this.pNegociacao, "pNegociacao");
            this.pNegociacao.BackgroundImage = null;
            this.pNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pNegociacao.Controls.Add(this.gNegociacao);
            this.pNegociacao.Controls.Add(this.bnNegociacao);
            this.pNegociacao.Font = null;
            this.pNegociacao.Name = "pNegociacao";
            this.pNegociacao.NM_ProcDeletar = "";
            this.pNegociacao.NM_ProcGravar = "";
            // 
            // gNegociacao
            // 
            this.gNegociacao.AccessibleDescription = null;
            this.gNegociacao.AccessibleName = null;
            this.gNegociacao.AllowUserToAddRows = false;
            this.gNegociacao.AllowUserToDeleteRows = false;
            this.gNegociacao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gNegociacao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gNegociacao, "gNegociacao");
            this.gNegociacao.AutoGenerateColumns = false;
            this.gNegociacao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gNegociacao.BackgroundImage = null;
            this.gNegociacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gNegociacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNegociacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gNegociacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gNegociacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.idnegociacaoDataGridViewTextBoxColumn,
            this.dtnegociacaostrDataGridViewTextBoxColumn,
            this.Dt_fechnegociacaostr,
            this.cdgrupoDataGridViewTextBoxColumn,
            this.dsgrupoDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.dsnegociacaoDataGridViewTextBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn});
            this.gNegociacao.DataSource = this.bsNegociacao;
            this.gNegociacao.Font = null;
            this.gNegociacao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gNegociacao.Name = "gNegociacao";
            this.gNegociacao.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gNegociacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gNegociacao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gNegociacao_CellFormatting);
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            resources.ApplyResources(this.Status, "Status");
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // idnegociacaoDataGridViewTextBoxColumn
            // 
            this.idnegociacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idnegociacaoDataGridViewTextBoxColumn.DataPropertyName = "Id_negociacao";
            resources.ApplyResources(this.idnegociacaoDataGridViewTextBoxColumn, "idnegociacaoDataGridViewTextBoxColumn");
            this.idnegociacaoDataGridViewTextBoxColumn.Name = "idnegociacaoDataGridViewTextBoxColumn";
            this.idnegociacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtnegociacaostrDataGridViewTextBoxColumn
            // 
            this.dtnegociacaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtnegociacaostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_negociacaostr";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtnegociacaostrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dtnegociacaostrDataGridViewTextBoxColumn, "dtnegociacaostrDataGridViewTextBoxColumn");
            this.dtnegociacaostrDataGridViewTextBoxColumn.Name = "dtnegociacaostrDataGridViewTextBoxColumn";
            this.dtnegociacaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Dt_fechnegociacaostr
            // 
            this.Dt_fechnegociacaostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_fechnegociacaostr.DataPropertyName = "Dt_fechnegociacaostr";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.Dt_fechnegociacaostr.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.Dt_fechnegociacaostr, "Dt_fechnegociacaostr");
            this.Dt_fechnegociacaostr.Name = "Dt_fechnegociacaostr";
            this.Dt_fechnegociacaostr.ReadOnly = true;
            // 
            // cdgrupoDataGridViewTextBoxColumn
            // 
            this.cdgrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdgrupoDataGridViewTextBoxColumn.DataPropertyName = "Cd_grupo";
            resources.ApplyResources(this.cdgrupoDataGridViewTextBoxColumn, "cdgrupoDataGridViewTextBoxColumn");
            this.cdgrupoDataGridViewTextBoxColumn.Name = "cdgrupoDataGridViewTextBoxColumn";
            this.cdgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsgrupoDataGridViewTextBoxColumn
            // 
            this.dsgrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsgrupoDataGridViewTextBoxColumn.DataPropertyName = "Ds_grupo";
            resources.ApplyResources(this.dsgrupoDataGridViewTextBoxColumn, "dsgrupoDataGridViewTextBoxColumn");
            this.dsgrupoDataGridViewTextBoxColumn.Name = "dsgrupoDataGridViewTextBoxColumn";
            this.dsgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            resources.ApplyResources(this.cdprodutoDataGridViewTextBoxColumn, "cdprodutoDataGridViewTextBoxColumn");
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            resources.ApplyResources(this.dsprodutoDataGridViewTextBoxColumn, "dsprodutoDataGridViewTextBoxColumn");
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            resources.ApplyResources(this.siglaunidadeDataGridViewTextBoxColumn, "siglaunidadeDataGridViewTextBoxColumn");
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsnegociacaoDataGridViewTextBoxColumn
            // 
            this.dsnegociacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsnegociacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_negociacao";
            resources.ApplyResources(this.dsnegociacaoDataGridViewTextBoxColumn, "dsnegociacaoDataGridViewTextBoxColumn");
            this.dsnegociacaoDataGridViewTextBoxColumn.Name = "dsnegociacaoDataGridViewTextBoxColumn";
            this.dsnegociacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn
            // 
            this.dsobservacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn, "dsobservacaoDataGridViewTextBoxColumn");
            this.dsobservacaoDataGridViewTextBoxColumn.Name = "dsobservacaoDataGridViewTextBoxColumn";
            this.dsobservacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsNegociacao
            // 
            this.bsNegociacao.DataSource = typeof(CamadaDados.Compra.Lancamento.TList_Negociacao);
            this.bsNegociacao.PositionChanged += new System.EventHandler(this.bsNegociacao_PositionChanged);
            // 
            // bnNegociacao
            // 
            this.bnNegociacao.AccessibleDescription = null;
            this.bnNegociacao.AccessibleName = null;
            this.bnNegociacao.AddNewItem = null;
            resources.ApplyResources(this.bnNegociacao, "bnNegociacao");
            this.bnNegociacao.BackgroundImage = null;
            this.bnNegociacao.BindingSource = this.bsNegociacao;
            this.bnNegociacao.CountItem = this.bindingNavigatorCountItem;
            this.bnNegociacao.DeleteItem = null;
            this.bnNegociacao.Font = null;
            this.bnNegociacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnNegociacao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnNegociacao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnNegociacao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnNegociacao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnNegociacao.Name = "bnNegociacao";
            this.bnNegociacao.PositionItem = this.bindingNavigatorPositionItem;
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
            // pDetalhes
            // 
            this.pDetalhes.AccessibleDescription = null;
            this.pDetalhes.AccessibleName = null;
            resources.ApplyResources(this.pDetalhes, "pDetalhes");
            this.pDetalhes.BackgroundImage = null;
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDetalhes.Controls.Add(this.tlpDetalhe);
            this.pDetalhes.Controls.Add(this.TS_ItensPedido);
            this.pDetalhes.Controls.Add(this.bnItens);
            this.pDetalhes.Font = null;
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            // 
            // tlpDetalhe
            // 
            this.tlpDetalhe.AccessibleDescription = null;
            this.tlpDetalhe.AccessibleName = null;
            resources.ApplyResources(this.tlpDetalhe, "tlpDetalhe");
            this.tlpDetalhe.BackgroundImage = null;
            this.tlpDetalhe.Controls.Add(this.gItens, 0, 0);
            this.tlpDetalhe.Controls.Add(this.panelDados1, 1, 0);
            this.tlpDetalhe.Font = null;
            this.tlpDetalhe.Name = "tlpDetalhe";
            // 
            // gItens
            // 
            this.gItens.AccessibleDescription = null;
            this.gItens.AccessibleName = null;
            this.gItens.AllowUserToAddRows = false;
            this.gItens.AllowUserToDeleteRows = false;
            this.gItens.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.gItens, "gItens");
            this.gItens.AutoGenerateColumns = false;
            this.gItens.BackgroundColor = System.Drawing.Color.LightGray;
            this.gItens.BackgroundImage = null;
            this.gItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItens.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.siglaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.cdendfornecedorDataGridViewTextBoxColumn,
            this.dsendfornecedorDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn14,
            this.cdmoedaDataGridViewTextBoxColumn,
            this.dsmoedaDataGridViewTextBoxColumn,
            this.cdportadorDataGridViewTextBoxColumn,
            this.dsportadorDataGridViewTextBoxColumn,
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn,
            this.dsobservacaoDataGridViewTextBoxColumn2,
            this.dsaprovarreprovarDataGridViewTextBoxColumn});
            this.gItens.DataSource = this.bsItens;
            this.gItens.Font = null;
            this.gItens.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItens.Name = "gItens";
            this.gItens.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItens.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gItens.DoubleClick += new System.EventHandler(this.gItens_DoubleClick);
            this.gItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gItens_CellFormatting);
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_fornecedor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Nm_fornecedor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Qtd_porcompra";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dataGridViewTextBoxColumn11, "dataGridViewTextBoxColumn11");
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Qtd_min_compra";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = "0";
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle9;
            resources.ApplyResources(this.dataGridViewTextBoxColumn12, "dataGridViewTextBoxColumn12");
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Vl_unitario_negociado";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle10;
            resources.ApplyResources(this.dataGridViewTextBoxColumn13, "dataGridViewTextBoxColumn13");
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // siglaDataGridViewTextBoxColumn
            // 
            this.siglaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaDataGridViewTextBoxColumn.DataPropertyName = "Sigla";
            resources.ApplyResources(this.siglaDataGridViewTextBoxColumn, "siglaDataGridViewTextBoxColumn");
            this.siglaDataGridViewTextBoxColumn.Name = "siglaDataGridViewTextBoxColumn";
            this.siglaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Cd_condpgto";
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Ds_condpgto";
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // cdendfornecedorDataGridViewTextBoxColumn
            // 
            this.cdendfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdendfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Cd_endfornecedor";
            resources.ApplyResources(this.cdendfornecedorDataGridViewTextBoxColumn, "cdendfornecedorDataGridViewTextBoxColumn");
            this.cdendfornecedorDataGridViewTextBoxColumn.Name = "cdendfornecedorDataGridViewTextBoxColumn";
            this.cdendfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsendfornecedorDataGridViewTextBoxColumn
            // 
            this.dsendfornecedorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsendfornecedorDataGridViewTextBoxColumn.DataPropertyName = "Ds_endfornecedor";
            resources.ApplyResources(this.dsendfornecedorDataGridViewTextBoxColumn, "dsendfornecedorDataGridViewTextBoxColumn");
            this.dsendfornecedorDataGridViewTextBoxColumn.Name = "dsendfornecedorDataGridViewTextBoxColumn";
            this.dsendfornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Nm_vendedor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Email_vendedor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FoneFax";
            resources.ApplyResources(this.dataGridViewTextBoxColumn10, "dataGridViewTextBoxColumn10");
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Nr_diasvigencia";
            resources.ApplyResources(this.dataGridViewTextBoxColumn14, "dataGridViewTextBoxColumn14");
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // cdmoedaDataGridViewTextBoxColumn
            // 
            this.cdmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdmoedaDataGridViewTextBoxColumn.DataPropertyName = "Cd_moeda";
            resources.ApplyResources(this.cdmoedaDataGridViewTextBoxColumn, "cdmoedaDataGridViewTextBoxColumn");
            this.cdmoedaDataGridViewTextBoxColumn.Name = "cdmoedaDataGridViewTextBoxColumn";
            this.cdmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsmoedaDataGridViewTextBoxColumn
            // 
            this.dsmoedaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmoedaDataGridViewTextBoxColumn.DataPropertyName = "Ds_moeda";
            resources.ApplyResources(this.dsmoedaDataGridViewTextBoxColumn, "dsmoedaDataGridViewTextBoxColumn");
            this.dsmoedaDataGridViewTextBoxColumn.Name = "dsmoedaDataGridViewTextBoxColumn";
            this.dsmoedaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdportadorDataGridViewTextBoxColumn
            // 
            this.cdportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.cdportadorDataGridViewTextBoxColumn, "cdportadorDataGridViewTextBoxColumn");
            this.cdportadorDataGridViewTextBoxColumn.Name = "cdportadorDataGridViewTextBoxColumn";
            this.cdportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dsportadorDataGridViewTextBoxColumn, "dsportadorDataGridViewTextBoxColumn");
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stdepositarpagtoboolDataGridViewCheckBoxColumn
            // 
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_depositarpagtobool";
            resources.ApplyResources(this.stdepositarpagtoboolDataGridViewCheckBoxColumn, "stdepositarpagtoboolDataGridViewCheckBoxColumn");
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.Name = "stdepositarpagtoboolDataGridViewCheckBoxColumn";
            this.stdepositarpagtoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dsobservacaoDataGridViewTextBoxColumn2
            // 
            this.dsobservacaoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobservacaoDataGridViewTextBoxColumn2.DataPropertyName = "Ds_observacao";
            resources.ApplyResources(this.dsobservacaoDataGridViewTextBoxColumn2, "dsobservacaoDataGridViewTextBoxColumn2");
            this.dsobservacaoDataGridViewTextBoxColumn2.Name = "dsobservacaoDataGridViewTextBoxColumn2";
            this.dsobservacaoDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dsaprovarreprovarDataGridViewTextBoxColumn
            // 
            this.dsaprovarreprovarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsaprovarreprovarDataGridViewTextBoxColumn.DataPropertyName = "Ds_aprovarreprovar";
            resources.ApplyResources(this.dsaprovarreprovarDataGridViewTextBoxColumn, "dsaprovarreprovarDataGridViewTextBoxColumn");
            this.dsaprovarreprovarDataGridViewTextBoxColumn.Name = "dsaprovarreprovarDataGridViewTextBoxColumn";
            this.dsaprovarreprovarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsItens
            // 
            this.bsItens.DataMember = "lItens";
            this.bsItens.DataSource = this.bsNegociacao;
            this.bsItens.PositionChanged += new System.EventHandler(this.bsItens_PositionChanged);
            // 
            // panelDados1
            // 
            this.panelDados1.AccessibleDescription = null;
            this.panelDados1.AccessibleName = null;
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.BackgroundImage = null;
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.lblConciliacao);
            this.panelDados1.Font = null;
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AccessibleDescription = null;
            this.dataGridDefault1.AccessibleName = null;
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.dataGridDefault1, "dataGridDefault1");
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BackgroundImage = null;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.prazoentregaDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn9,
            this.Nm_transportadora});
            this.dataGridDefault1.DataSource = this.bsPrazoEntrega;
            this.dataGridDefault1.Font = null;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Cd_empresa";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // prazoentregaDataGridViewTextBoxColumn
            // 
            this.prazoentregaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prazoentregaDataGridViewTextBoxColumn.DataPropertyName = "Prazo_entrega";
            resources.ApplyResources(this.prazoentregaDataGridViewTextBoxColumn, "prazoentregaDataGridViewTextBoxColumn");
            this.prazoentregaDataGridViewTextBoxColumn.Name = "prazoentregaDataGridViewTextBoxColumn";
            this.prazoentregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Tipo_frete";
            resources.ApplyResources(this.dataGridViewTextBoxColumn9, "dataGridViewTextBoxColumn9");
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // Nm_transportadora
            // 
            this.Nm_transportadora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nm_transportadora.DataPropertyName = "Nm_transportadora";
            resources.ApplyResources(this.Nm_transportadora, "Nm_transportadora");
            this.Nm_transportadora.Name = "Nm_transportadora";
            this.Nm_transportadora.ReadOnly = true;
            // 
            // bsPrazoEntrega
            // 
            this.bsPrazoEntrega.DataMember = "lPrazoEntrega";
            this.bsPrazoEntrega.DataSource = this.bsItens;
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.AccessibleDescription = null;
            this.lblConciliacao.AccessibleName = null;
            resources.ApplyResources(this.lblConciliacao, "lblConciliacao");
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.Name = "lblConciliacao";
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.AccessibleDescription = null;
            this.TS_ItensPedido.AccessibleName = null;
            resources.ApplyResources(this.TS_ItensPedido, "TS_ItensPedido");
            this.TS_ItensPedido.BackgroundImage = null;
            this.TS_ItensPedido.Font = null;
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Inserir_Item,
            this.BB_Alterar_Item,
            this.btn_Deleta_Item});
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            // 
            // btn_Inserir_Item
            // 
            this.btn_Inserir_Item.AccessibleDescription = null;
            this.btn_Inserir_Item.AccessibleName = null;
            resources.ApplyResources(this.btn_Inserir_Item, "btn_Inserir_Item");
            this.btn_Inserir_Item.BackgroundImage = null;
            this.btn_Inserir_Item.Name = "btn_Inserir_Item";
            this.btn_Inserir_Item.Click += new System.EventHandler(this.btn_Inserir_Item_Click);
            // 
            // BB_Alterar_Item
            // 
            this.BB_Alterar_Item.AccessibleDescription = null;
            this.BB_Alterar_Item.AccessibleName = null;
            resources.ApplyResources(this.BB_Alterar_Item, "BB_Alterar_Item");
            this.BB_Alterar_Item.BackgroundImage = null;
            this.BB_Alterar_Item.Name = "BB_Alterar_Item";
            this.BB_Alterar_Item.Click += new System.EventHandler(this.BB_Alterar_Item_Click);
            // 
            // btn_Deleta_Item
            // 
            this.btn_Deleta_Item.AccessibleDescription = null;
            this.btn_Deleta_Item.AccessibleName = null;
            resources.ApplyResources(this.btn_Deleta_Item, "btn_Deleta_Item");
            this.btn_Deleta_Item.BackgroundImage = null;
            this.btn_Deleta_Item.Name = "btn_Deleta_Item";
            this.btn_Deleta_Item.Click += new System.EventHandler(this.btn_Deleta_Item_Click);
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
            // TFLanNegociacao
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.Font = null;
            this.Icon = null;
            this.KeyPreview = true;
            this.Name = "TFLanNegociacao";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanNegociacao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanNegociacao_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanNegociacao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pFiltroData.ResumeLayout(false);
            this.pFiltroData.PerformLayout();
            this.pFiltroValor.ResumeLayout(false);
            this.pFiltroValor.PerformLayout();
            this.pNegociacao.ResumeLayout(false);
            this.pNegociacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gNegociacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsNegociacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnNegociacao)).EndInit();
            this.bnNegociacao.ResumeLayout(false);
            this.bnNegociacao.PerformLayout();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            this.tlpDetalhe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPrazoEntrega)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnItens)).EndInit();
            this.bnItens.ResumeLayout(false);
            this.bnItens.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_EnviarLote;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pNegociacao;
        private Componentes.PanelDados pDetalhes;
        private Componentes.DataGridDefault gNegociacao;
        private System.Windows.Forms.BindingSource bsNegociacao;
        private System.Windows.Forms.BindingNavigator bnNegociacao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gItens;
        private System.Windows.Forms.BindingSource bsItens;
        private System.Windows.Forms.BindingNavigator bnItens;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault id_negociacao;
        private System.Windows.Forms.Button bb_fornecedor;
        private Componentes.EditDefault cd_fornecedor;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button bb_grupo;
        private Componentes.EditDefault cd_grupo;
        private System.Windows.Forms.Button bb_condpgto;
        private Componentes.EditDefault cd_condpgto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault ds_observacao;
        private Componentes.PanelDados pFiltroValor;
        private Componentes.CheckBoxDefault cbProcessado;
        private Componentes.CheckBoxDefault cbCancelado;
        private Componentes.CheckBoxDefault CB_Abertas;
        private Componentes.PanelDados pFiltroData;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicial;
        private Componentes.RadioButtonDefault rbNegociacao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Componentes.RadioButtonDefault rbDtProcessamento;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton btn_Inserir_Item;
        private System.Windows.Forms.ToolStripButton BB_Alterar_Item;
        private System.Windows.Forms.ToolStripButton btn_Deleta_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdporcompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdmincompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarionegociadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdiasvigenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailvendedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneFaxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipofreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripButton bb_encerrar;
        private Componentes.CheckBoxDefault cbFechada;
        private System.Windows.Forms.TableLayoutPanel tlpDetalhe;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdendtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsendtransportadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsPrazoEntrega;
        private System.Windows.Forms.ToolStripButton bb_aprovar;
        private Componentes.CheckBoxDefault cbAprovada;
        private System.Windows.Forms.ToolStripButton bb_negfornec;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label lblConciliacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn idnegociacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtnegociacaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_fechnegociacaostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdgrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsnegociacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdendfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsendfornecedorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmoedaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stdepositarpagtoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobservacaoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsaprovarreprovarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn prazoentregaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nm_transportadora;
    }
}