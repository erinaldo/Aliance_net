namespace Fiscal.Cadastros
{
    partial class FCadMovimentacaoComercial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadMovimentacaoComercial));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_centroresultado = new Componentes.EditDefault(this.components);
            this.bsMovimentacao = new System.Windows.Forms.BindingSource(this.components);
            this.bb_centroresult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_centroresult = new Componentes.EditDefault(this.components);
            this.ds_DadosAdicInternacional = new Componentes.EditDefault(this.components);
            this.ds_DadosAdicForaestado = new Componentes.EditDefault(this.components);
            this.BB_DadosAdic_Internacional = new System.Windows.Forms.Button();
            this.ds_DadosAdicdentroestado = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.BB_DadosAdic_ForaEstado = new System.Windows.Forms.Button();
            this.CD_DadosAdic_Internacional = new Componentes.EditDefault(this.components);
            this.st_gerarspedpiscofins = new Componentes.CheckBoxDefault(this.components);
            this.ds_obsfiscalinternacional = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.BB_Internacional = new System.Windows.Forms.Button();
            this.BB_DadosAdic_DentroEstado = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_Internacional = new Componentes.EditDefault(this.components);
            this.CD_DadosAdic_ForaEstado = new Componentes.EditDefault(this.components);
            this.ds_obsfiscalforaestado = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bb_obsFisFora = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_CD_ObsFiscal_ForaEstado = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_ForaEstado = new Componentes.EditDefault(this.components);
            this.CD_DadosAdic_DentroEstado = new Componentes.EditDefault(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.ds_obsfiscaldentroestado = new Componentes.EditDefault(this.components);
            this.cd_movimentacao = new Componentes.EditDefault(this.components);
            this.bb_obsFisDentro = new System.Windows.Forms.Button();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.LB_CD_ObsFiscal_DentroEstado = new System.Windows.Forms.Label();
            this.CD_ObsFiscal_DentroEstado = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.LB_CD_Movimentacao = new System.Windows.Forms.Label();
            this.LB_DS_Movimentacao = new System.Windows.Forms.Label();
            this.LB_CD_Historico = new System.Windows.Forms.Label();
            this.DS_Movimentacao = new Componentes.EditDefault(this.components);
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.st_vendaconsumidor = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(761, 43);
            this.barraMenu.TabIndex = 11;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.st_vendaconsumidor);
            this.panelDados1.Controls.Add(this.ds_centroresultado);
            this.panelDados1.Controls.Add(this.bb_centroresult);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.cd_centroresult);
            this.panelDados1.Controls.Add(this.ds_DadosAdicInternacional);
            this.panelDados1.Controls.Add(this.ds_DadosAdicForaestado);
            this.panelDados1.Controls.Add(this.BB_DadosAdic_Internacional);
            this.panelDados1.Controls.Add(this.ds_DadosAdicdentroestado);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.BB_DadosAdic_ForaEstado);
            this.panelDados1.Controls.Add(this.CD_DadosAdic_Internacional);
            this.panelDados1.Controls.Add(this.st_gerarspedpiscofins);
            this.panelDados1.Controls.Add(this.ds_obsfiscalinternacional);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.BB_Internacional);
            this.panelDados1.Controls.Add(this.BB_DadosAdic_DentroEstado);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.CD_ObsFiscal_Internacional);
            this.panelDados1.Controls.Add(this.CD_DadosAdic_ForaEstado);
            this.panelDados1.Controls.Add(this.ds_obsfiscalforaestado);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.bb_obsFisFora);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.LB_CD_ObsFiscal_ForaEstado);
            this.panelDados1.Controls.Add(this.CD_ObsFiscal_ForaEstado);
            this.panelDados1.Controls.Add(this.CD_DadosAdic_DentroEstado);
            this.panelDados1.Controls.Add(this.tp_movimento);
            this.panelDados1.Controls.Add(this.ds_obsfiscaldentroestado);
            this.panelDados1.Controls.Add(this.cd_movimentacao);
            this.panelDados1.Controls.Add(this.bb_obsFisDentro);
            this.panelDados1.Controls.Add(this.ds_historico);
            this.panelDados1.Controls.Add(this.LB_CD_ObsFiscal_DentroEstado);
            this.panelDados1.Controls.Add(this.CD_ObsFiscal_DentroEstado);
            this.panelDados1.Controls.Add(this.bb_historico);
            this.panelDados1.Controls.Add(this.LB_CD_Movimentacao);
            this.panelDados1.Controls.Add(this.LB_DS_Movimentacao);
            this.panelDados1.Controls.Add(this.LB_CD_Historico);
            this.panelDados1.Controls.Add(this.DS_Movimentacao);
            this.panelDados1.Controls.Add(this.CD_Historico);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(761, 283);
            this.panelDados1.TabIndex = 12;
            // 
            // ds_centroresultado
            // 
            this.ds_centroresultado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Ds_centroresultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultado.Enabled = false;
            this.ds_centroresultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_centroresultado.Location = new System.Drawing.Point(259, 88);
            this.ds_centroresultado.Name = "ds_centroresultado";
            this.ds_centroresultado.NM_Alias = "";
            this.ds_centroresultado.NM_Campo = "ds_centroresultado";
            this.ds_centroresultado.NM_CampoBusca = "ds_centroresultado";
            this.ds_centroresultado.NM_Param = "@P_DS_GRUPOCF";
            this.ds_centroresultado.QTD_Zero = 0;
            this.ds_centroresultado.ReadOnly = true;
            this.ds_centroresultado.Size = new System.Drawing.Size(357, 20);
            this.ds_centroresultado.ST_AutoInc = false;
            this.ds_centroresultado.ST_DisableAuto = false;
            this.ds_centroresultado.ST_Float = false;
            this.ds_centroresultado.ST_Gravar = false;
            this.ds_centroresultado.ST_Int = false;
            this.ds_centroresultado.ST_LimpaCampo = true;
            this.ds_centroresultado.ST_NotNull = false;
            this.ds_centroresultado.ST_PrimaryKey = false;
            this.ds_centroresultado.TabIndex = 81;
            this.ds_centroresultado.TextOld = null;
            // 
            // bsMovimentacao
            // 
            this.bsMovimentacao.DataSource = typeof(CamadaDados.Fiscal.TList_CadMovimentacao);
            // 
            // bb_centroresult
            // 
            this.bb_centroresult.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bb_centroresult.Image = ((System.Drawing.Image)(resources.GetObject("bb_centroresult.Image")));
            this.bb_centroresult.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_centroresult.Location = new System.Drawing.Point(224, 88);
            this.bb_centroresult.Name = "bb_centroresult";
            this.bb_centroresult.Size = new System.Drawing.Size(30, 20);
            this.bb_centroresult.TabIndex = 57;
            this.bb_centroresult.UseVisualStyleBackColor = true;
            this.bb_centroresult.Click += new System.EventHandler(this.bb_centroresult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(39, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Centro Result. CMV:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_centroresult
            // 
            this.cd_centroresult.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresult.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_centroresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_centroresult.Location = new System.Drawing.Point(148, 88);
            this.cd_centroresult.Name = "cd_centroresult";
            this.cd_centroresult.NM_Alias = "a";
            this.cd_centroresult.NM_Campo = "cd_centroresult";
            this.cd_centroresult.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresult.NM_Param = "@P_CD_HISTORICO";
            this.cd_centroresult.QTD_Zero = 0;
            this.cd_centroresult.Size = new System.Drawing.Size(73, 20);
            this.cd_centroresult.ST_AutoInc = false;
            this.cd_centroresult.ST_DisableAuto = false;
            this.cd_centroresult.ST_Float = false;
            this.cd_centroresult.ST_Gravar = true;
            this.cd_centroresult.ST_Int = false;
            this.cd_centroresult.ST_LimpaCampo = true;
            this.cd_centroresult.ST_NotNull = false;
            this.cd_centroresult.ST_PrimaryKey = false;
            this.cd_centroresult.TabIndex = 56;
            this.cd_centroresult.TextOld = null;
            this.cd_centroresult.Leave += new System.EventHandler(this.cd_centroresult_Leave);
            // 
            // ds_DadosAdicInternacional
            // 
            this.ds_DadosAdicInternacional.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicInternacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicInternacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicInternacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_dadosAdicionais_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_DadosAdicInternacional.Enabled = false;
            this.ds_DadosAdicInternacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_DadosAdicInternacional.Location = new System.Drawing.Point(243, 239);
            this.ds_DadosAdicInternacional.Name = "ds_DadosAdicInternacional";
            this.ds_DadosAdicInternacional.NM_Alias = "";
            this.ds_DadosAdicInternacional.NM_Campo = "ds_dadosadic_internacional";
            this.ds_DadosAdicInternacional.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicInternacional.NM_Param = "@P_DS_DADOSADIC_INTERNACIONAL";
            this.ds_DadosAdicInternacional.QTD_Zero = 0;
            this.ds_DadosAdicInternacional.ReadOnly = true;
            this.ds_DadosAdicInternacional.Size = new System.Drawing.Size(475, 20);
            this.ds_DadosAdicInternacional.ST_AutoInc = false;
            this.ds_DadosAdicInternacional.ST_DisableAuto = false;
            this.ds_DadosAdicInternacional.ST_Float = false;
            this.ds_DadosAdicInternacional.ST_Gravar = false;
            this.ds_DadosAdicInternacional.ST_Int = false;
            this.ds_DadosAdicInternacional.ST_LimpaCampo = true;
            this.ds_DadosAdicInternacional.ST_NotNull = false;
            this.ds_DadosAdicInternacional.ST_PrimaryKey = false;
            this.ds_DadosAdicInternacional.TabIndex = 59;
            this.ds_DadosAdicInternacional.TextOld = null;
            // 
            // ds_DadosAdicForaestado
            // 
            this.ds_DadosAdicForaestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicForaestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicForaestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicForaestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_dadosAdicionais_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_DadosAdicForaestado.Enabled = false;
            this.ds_DadosAdicForaestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_DadosAdicForaestado.Location = new System.Drawing.Point(243, 187);
            this.ds_DadosAdicForaestado.Name = "ds_DadosAdicForaestado";
            this.ds_DadosAdicForaestado.NM_Alias = "";
            this.ds_DadosAdicForaestado.NM_Campo = "ds_dadosadic_foraestado";
            this.ds_DadosAdicForaestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicForaestado.NM_Param = "@P_DS_DADOSADIC_FORAESTADO";
            this.ds_DadosAdicForaestado.QTD_Zero = 0;
            this.ds_DadosAdicForaestado.ReadOnly = true;
            this.ds_DadosAdicForaestado.Size = new System.Drawing.Size(475, 20);
            this.ds_DadosAdicForaestado.ST_AutoInc = false;
            this.ds_DadosAdicForaestado.ST_DisableAuto = false;
            this.ds_DadosAdicForaestado.ST_Float = false;
            this.ds_DadosAdicForaestado.ST_Gravar = false;
            this.ds_DadosAdicForaestado.ST_Int = false;
            this.ds_DadosAdicForaestado.ST_LimpaCampo = true;
            this.ds_DadosAdicForaestado.ST_NotNull = false;
            this.ds_DadosAdicForaestado.ST_PrimaryKey = false;
            this.ds_DadosAdicForaestado.TabIndex = 62;
            this.ds_DadosAdicForaestado.TextOld = null;
            // 
            // BB_DadosAdic_Internacional
            // 
            this.BB_DadosAdic_Internacional.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_Internacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BB_DadosAdic_Internacional.Image = ((System.Drawing.Image)(resources.GetObject("BB_DadosAdic_Internacional.Image")));
            this.BB_DadosAdic_Internacional.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_DadosAdic_Internacional.Location = new System.Drawing.Point(212, 239);
            this.BB_DadosAdic_Internacional.Name = "BB_DadosAdic_Internacional";
            this.BB_DadosAdic_Internacional.Size = new System.Drawing.Size(30, 20);
            this.BB_DadosAdic_Internacional.TabIndex = 75;
            this.BB_DadosAdic_Internacional.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_Internacional.Click += new System.EventHandler(this.BB_DadosAdic_Internacional_Click);
            // 
            // ds_DadosAdicdentroestado
            // 
            this.ds_DadosAdicdentroestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_DadosAdicdentroestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_DadosAdicdentroestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_DadosAdicdentroestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_dadosAdicionais_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_DadosAdicdentroestado.Enabled = false;
            this.ds_DadosAdicdentroestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_DadosAdicdentroestado.Location = new System.Drawing.Point(243, 137);
            this.ds_DadosAdicdentroestado.Name = "ds_DadosAdicdentroestado";
            this.ds_DadosAdicdentroestado.NM_Alias = "";
            this.ds_DadosAdicdentroestado.NM_Campo = "ds_dadosadic_dentroestado";
            this.ds_DadosAdicdentroestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_DadosAdicdentroestado.NM_Param = "@P_DS_DADOSADIC_DENTROESTADO";
            this.ds_DadosAdicdentroestado.QTD_Zero = 0;
            this.ds_DadosAdicdentroestado.ReadOnly = true;
            this.ds_DadosAdicdentroestado.Size = new System.Drawing.Size(475, 20);
            this.ds_DadosAdicdentroestado.ST_AutoInc = false;
            this.ds_DadosAdicdentroestado.ST_DisableAuto = false;
            this.ds_DadosAdicdentroestado.ST_Float = false;
            this.ds_DadosAdicdentroestado.ST_Gravar = false;
            this.ds_DadosAdicdentroestado.ST_Int = false;
            this.ds_DadosAdicdentroestado.ST_LimpaCampo = true;
            this.ds_DadosAdicdentroestado.ST_NotNull = false;
            this.ds_DadosAdicdentroestado.ST_PrimaryKey = false;
            this.ds_DadosAdicdentroestado.TabIndex = 61;
            this.ds_DadosAdicdentroestado.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 80;
            this.label5.Text = "Dados Adic. Internacional:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_DadosAdic_ForaEstado
            // 
            this.BB_DadosAdic_ForaEstado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_ForaEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BB_DadosAdic_ForaEstado.Image = ((System.Drawing.Image)(resources.GetObject("BB_DadosAdic_ForaEstado.Image")));
            this.BB_DadosAdic_ForaEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_DadosAdic_ForaEstado.Location = new System.Drawing.Point(212, 187);
            this.BB_DadosAdic_ForaEstado.Name = "BB_DadosAdic_ForaEstado";
            this.BB_DadosAdic_ForaEstado.Size = new System.Drawing.Size(30, 20);
            this.BB_DadosAdic_ForaEstado.TabIndex = 70;
            this.BB_DadosAdic_ForaEstado.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_ForaEstado.Click += new System.EventHandler(this.BB_DadosAdic_ForaEstado_Click);
            // 
            // CD_DadosAdic_Internacional
            // 
            this.CD_DadosAdic_Internacional.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_Internacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_Internacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_Internacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_dadosAdicionais_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_DadosAdic_Internacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_DadosAdic_Internacional.Location = new System.Drawing.Point(148, 240);
            this.CD_DadosAdic_Internacional.Name = "CD_DadosAdic_Internacional";
            this.CD_DadosAdic_Internacional.NM_Alias = "a";
            this.CD_DadosAdic_Internacional.NM_Campo = "CD_DadosAdic_Internacional";
            this.CD_DadosAdic_Internacional.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_Internacional.NM_Param = "@P_CD_DADOSADIC_INTERNACIONAL";
            this.CD_DadosAdic_Internacional.QTD_Zero = 0;
            this.CD_DadosAdic_Internacional.Size = new System.Drawing.Size(57, 20);
            this.CD_DadosAdic_Internacional.ST_AutoInc = false;
            this.CD_DadosAdic_Internacional.ST_DisableAuto = false;
            this.CD_DadosAdic_Internacional.ST_Float = false;
            this.CD_DadosAdic_Internacional.ST_Gravar = true;
            this.CD_DadosAdic_Internacional.ST_Int = false;
            this.CD_DadosAdic_Internacional.ST_LimpaCampo = true;
            this.CD_DadosAdic_Internacional.ST_NotNull = false;
            this.CD_DadosAdic_Internacional.ST_PrimaryKey = false;
            this.CD_DadosAdic_Internacional.TabIndex = 73;
            this.CD_DadosAdic_Internacional.TextOld = null;
            this.CD_DadosAdic_Internacional.Leave += new System.EventHandler(this.CD_DadosAdic_Internacional_Leave);
            // 
            // st_gerarspedpiscofins
            // 
            this.st_gerarspedpiscofins.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_gerarspedpiscofins.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsMovimentacao, "St_gerarspedpiscofinsbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerarspedpiscofins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.st_gerarspedpiscofins.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_gerarspedpiscofins.Location = new System.Drawing.Point(622, 11);
            this.st_gerarspedpiscofins.Name = "st_gerarspedpiscofins";
            this.st_gerarspedpiscofins.NM_Alias = "";
            this.st_gerarspedpiscofins.NM_Campo = "";
            this.st_gerarspedpiscofins.NM_Param = "";
            this.st_gerarspedpiscofins.Size = new System.Drawing.Size(96, 46);
            this.st_gerarspedpiscofins.ST_Gravar = true;
            this.st_gerarspedpiscofins.ST_LimparCampo = true;
            this.st_gerarspedpiscofins.ST_NotNull = false;
            this.st_gerarspedpiscofins.TabIndex = 48;
            this.st_gerarspedpiscofins.Text = "Gerar Sped Pis/Cofins";
            this.st_gerarspedpiscofins.UseVisualStyleBackColor = true;
            this.st_gerarspedpiscofins.Vl_False = "";
            this.st_gerarspedpiscofins.Vl_True = "";
            // 
            // ds_obsfiscalinternacional
            // 
            this.ds_obsfiscalinternacional.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscalinternacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscalinternacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscalinternacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_dadosAdicionais_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_obsfiscalinternacional.Enabled = false;
            this.ds_obsfiscalinternacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_obsfiscalinternacional.Location = new System.Drawing.Point(243, 213);
            this.ds_obsfiscalinternacional.Name = "ds_obsfiscalinternacional";
            this.ds_obsfiscalinternacional.NM_Alias = "";
            this.ds_obsfiscalinternacional.NM_Campo = "ds_obsfiscalinternacional";
            this.ds_obsfiscalinternacional.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscalinternacional.NM_Param = "";
            this.ds_obsfiscalinternacional.QTD_Zero = 0;
            this.ds_obsfiscalinternacional.ReadOnly = true;
            this.ds_obsfiscalinternacional.Size = new System.Drawing.Size(475, 20);
            this.ds_obsfiscalinternacional.ST_AutoInc = false;
            this.ds_obsfiscalinternacional.ST_DisableAuto = false;
            this.ds_obsfiscalinternacional.ST_Float = false;
            this.ds_obsfiscalinternacional.ST_Gravar = false;
            this.ds_obsfiscalinternacional.ST_Int = false;
            this.ds_obsfiscalinternacional.ST_LimpaCampo = true;
            this.ds_obsfiscalinternacional.ST_NotNull = false;
            this.ds_obsfiscalinternacional.ST_PrimaryKey = false;
            this.ds_obsfiscalinternacional.TabIndex = 51;
            this.ds_obsfiscalinternacional.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(14, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Dados Adic. Fora Estado:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_Internacional
            // 
            this.BB_Internacional.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Internacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BB_Internacional.Image = ((System.Drawing.Image)(resources.GetObject("BB_Internacional.Image")));
            this.BB_Internacional.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Internacional.Location = new System.Drawing.Point(212, 213);
            this.BB_Internacional.Name = "BB_Internacional";
            this.BB_Internacional.Size = new System.Drawing.Size(30, 20);
            this.BB_Internacional.TabIndex = 72;
            this.BB_Internacional.UseVisualStyleBackColor = true;
            this.BB_Internacional.Click += new System.EventHandler(this.BB_Internacional_Click);
            // 
            // BB_DadosAdic_DentroEstado
            // 
            this.BB_DadosAdic_DentroEstado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_DadosAdic_DentroEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BB_DadosAdic_DentroEstado.Image = ((System.Drawing.Image)(resources.GetObject("BB_DadosAdic_DentroEstado.Image")));
            this.BB_DadosAdic_DentroEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_DadosAdic_DentroEstado.Location = new System.Drawing.Point(212, 137);
            this.BB_DadosAdic_DentroEstado.Name = "BB_DadosAdic_DentroEstado";
            this.BB_DadosAdic_DentroEstado.Size = new System.Drawing.Size(30, 20);
            this.BB_DadosAdic_DentroEstado.TabIndex = 65;
            this.BB_DadosAdic_DentroEstado.UseVisualStyleBackColor = true;
            this.BB_DadosAdic_DentroEstado.Click += new System.EventHandler(this.BB_DadosAdic_DentroEstado_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(19, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Obs.Fiscal Internacional:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_ObsFiscal_Internacional
            // 
            this.CD_ObsFiscal_Internacional.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_Internacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_Internacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_Internacional.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_obsfiscal_internacional", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ObsFiscal_Internacional.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_ObsFiscal_Internacional.Location = new System.Drawing.Point(148, 214);
            this.CD_ObsFiscal_Internacional.Name = "CD_ObsFiscal_Internacional";
            this.CD_ObsFiscal_Internacional.NM_Alias = "a";
            this.CD_ObsFiscal_Internacional.NM_Campo = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_Internacional.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_Internacional.NM_Param = "@P_CD_OBSFISCAL_INTERNACIONAL";
            this.CD_ObsFiscal_Internacional.QTD_Zero = 0;
            this.CD_ObsFiscal_Internacional.Size = new System.Drawing.Size(57, 20);
            this.CD_ObsFiscal_Internacional.ST_AutoInc = false;
            this.CD_ObsFiscal_Internacional.ST_DisableAuto = false;
            this.CD_ObsFiscal_Internacional.ST_Float = false;
            this.CD_ObsFiscal_Internacional.ST_Gravar = true;
            this.CD_ObsFiscal_Internacional.ST_Int = false;
            this.CD_ObsFiscal_Internacional.ST_LimpaCampo = true;
            this.CD_ObsFiscal_Internacional.ST_NotNull = false;
            this.CD_ObsFiscal_Internacional.ST_PrimaryKey = false;
            this.CD_ObsFiscal_Internacional.TabIndex = 71;
            this.CD_ObsFiscal_Internacional.TextOld = null;
            this.CD_ObsFiscal_Internacional.Leave += new System.EventHandler(this.CD_ObsFiscal_Internacional_Leave);
            // 
            // CD_DadosAdic_ForaEstado
            // 
            this.CD_DadosAdic_ForaEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_ForaEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_ForaEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_ForaEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_dadosAdicionais_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_DadosAdic_ForaEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_DadosAdic_ForaEstado.Location = new System.Drawing.Point(148, 187);
            this.CD_DadosAdic_ForaEstado.Name = "CD_DadosAdic_ForaEstado";
            this.CD_DadosAdic_ForaEstado.NM_Alias = "a";
            this.CD_DadosAdic_ForaEstado.NM_Campo = "CD_DadosAdic_ForaEstado";
            this.CD_DadosAdic_ForaEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_ForaEstado.NM_Param = "@P_CD_DADOSADIC_FORAESTADO";
            this.CD_DadosAdic_ForaEstado.QTD_Zero = 0;
            this.CD_DadosAdic_ForaEstado.Size = new System.Drawing.Size(57, 20);
            this.CD_DadosAdic_ForaEstado.ST_AutoInc = false;
            this.CD_DadosAdic_ForaEstado.ST_DisableAuto = false;
            this.CD_DadosAdic_ForaEstado.ST_Float = false;
            this.CD_DadosAdic_ForaEstado.ST_Gravar = true;
            this.CD_DadosAdic_ForaEstado.ST_Int = false;
            this.CD_DadosAdic_ForaEstado.ST_LimpaCampo = true;
            this.CD_DadosAdic_ForaEstado.ST_NotNull = false;
            this.CD_DadosAdic_ForaEstado.ST_PrimaryKey = false;
            this.CD_DadosAdic_ForaEstado.TabIndex = 69;
            this.CD_DadosAdic_ForaEstado.TextOld = null;
            this.CD_DadosAdic_ForaEstado.Leave += new System.EventHandler(this.CD_DadosAdic_ForaEstado_Leave);
            // 
            // ds_obsfiscalforaestado
            // 
            this.ds_obsfiscalforaestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscalforaestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscalforaestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscalforaestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_obsfiscalforaestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_obsfiscalforaestado.Enabled = false;
            this.ds_obsfiscalforaestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_obsfiscalforaestado.Location = new System.Drawing.Point(243, 163);
            this.ds_obsfiscalforaestado.Name = "ds_obsfiscalforaestado";
            this.ds_obsfiscalforaestado.NM_Alias = "";
            this.ds_obsfiscalforaestado.NM_Campo = "ds_obsfiscalforaestado";
            this.ds_obsfiscalforaestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscalforaestado.NM_Param = "";
            this.ds_obsfiscalforaestado.QTD_Zero = 0;
            this.ds_obsfiscalforaestado.ReadOnly = true;
            this.ds_obsfiscalforaestado.Size = new System.Drawing.Size(475, 20);
            this.ds_obsfiscalforaestado.ST_AutoInc = false;
            this.ds_obsfiscalforaestado.ST_DisableAuto = false;
            this.ds_obsfiscalforaestado.ST_Float = false;
            this.ds_obsfiscalforaestado.ST_Gravar = false;
            this.ds_obsfiscalforaestado.ST_Int = false;
            this.ds_obsfiscalforaestado.ST_LimpaCampo = true;
            this.ds_obsfiscalforaestado.ST_NotNull = false;
            this.ds_obsfiscalforaestado.ST_PrimaryKey = false;
            this.ds_obsfiscalforaestado.TabIndex = 53;
            this.ds_obsfiscalforaestado.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Dados Adic. Dentro Estado:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_obsFisFora
            // 
            this.bb_obsFisFora.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_obsFisFora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bb_obsFisFora.Image = ((System.Drawing.Image)(resources.GetObject("bb_obsFisFora.Image")));
            this.bb_obsFisFora.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_obsFisFora.Location = new System.Drawing.Point(212, 163);
            this.bb_obsFisFora.Name = "bb_obsFisFora";
            this.bb_obsFisFora.Size = new System.Drawing.Size(30, 20);
            this.bb_obsFisFora.TabIndex = 67;
            this.bb_obsFisFora.UseVisualStyleBackColor = true;
            this.bb_obsFisFora.Click += new System.EventHandler(this.bb_obsFisFora_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(497, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Tipo de Movimento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_CD_ObsFiscal_ForaEstado
            // 
            this.LB_CD_ObsFiscal_ForaEstado.AutoSize = true;
            this.LB_CD_ObsFiscal_ForaEstado.BackColor = System.Drawing.Color.Transparent;
            this.LB_CD_ObsFiscal_ForaEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_ObsFiscal_ForaEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_ObsFiscal_ForaEstado.Location = new System.Drawing.Point(23, 167);
            this.LB_CD_ObsFiscal_ForaEstado.Name = "LB_CD_ObsFiscal_ForaEstado";
            this.LB_CD_ObsFiscal_ForaEstado.Size = new System.Drawing.Size(119, 13);
            this.LB_CD_ObsFiscal_ForaEstado.TabIndex = 74;
            this.LB_CD_ObsFiscal_ForaEstado.Text = "Obs.Fiscal Fora Estado:";
            this.LB_CD_ObsFiscal_ForaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_ObsFiscal_ForaEstado
            // 
            this.CD_ObsFiscal_ForaEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_ForaEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_ForaEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_ForaEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_obsfiscal_foraestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ObsFiscal_ForaEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_ObsFiscal_ForaEstado.Location = new System.Drawing.Point(148, 163);
            this.CD_ObsFiscal_ForaEstado.Name = "CD_ObsFiscal_ForaEstado";
            this.CD_ObsFiscal_ForaEstado.NM_Alias = "a";
            this.CD_ObsFiscal_ForaEstado.NM_Campo = "CD_ObsFiscal_ForaEstado";
            this.CD_ObsFiscal_ForaEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_ForaEstado.NM_Param = "@P_CD_OBSFISCAL_FORAESTADO";
            this.CD_ObsFiscal_ForaEstado.QTD_Zero = 0;
            this.CD_ObsFiscal_ForaEstado.Size = new System.Drawing.Size(57, 20);
            this.CD_ObsFiscal_ForaEstado.ST_AutoInc = false;
            this.CD_ObsFiscal_ForaEstado.ST_DisableAuto = false;
            this.CD_ObsFiscal_ForaEstado.ST_Float = false;
            this.CD_ObsFiscal_ForaEstado.ST_Gravar = true;
            this.CD_ObsFiscal_ForaEstado.ST_Int = false;
            this.CD_ObsFiscal_ForaEstado.ST_LimpaCampo = true;
            this.CD_ObsFiscal_ForaEstado.ST_NotNull = false;
            this.CD_ObsFiscal_ForaEstado.ST_PrimaryKey = false;
            this.CD_ObsFiscal_ForaEstado.TabIndex = 66;
            this.CD_ObsFiscal_ForaEstado.TextOld = null;
            this.CD_ObsFiscal_ForaEstado.LocationChanged += new System.EventHandler(this.CD_ObsFiscal_ForaEstado_LocationChanged);
            this.CD_ObsFiscal_ForaEstado.Leave += new System.EventHandler(this.CD_ObsFiscal_ForaEstado_Leave);
            // 
            // CD_DadosAdic_DentroEstado
            // 
            this.CD_DadosAdic_DentroEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_DadosAdic_DentroEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_DadosAdic_DentroEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_DadosAdic_DentroEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_dadosAdicionais_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_DadosAdic_DentroEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_DadosAdic_DentroEstado.Location = new System.Drawing.Point(148, 137);
            this.CD_DadosAdic_DentroEstado.Name = "CD_DadosAdic_DentroEstado";
            this.CD_DadosAdic_DentroEstado.NM_Alias = "a";
            this.CD_DadosAdic_DentroEstado.NM_Campo = "CD_Dadosadic_DentroEstado";
            this.CD_DadosAdic_DentroEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_DadosAdic_DentroEstado.NM_Param = "@P_CD_DADOSADIC_DENTROESTADO";
            this.CD_DadosAdic_DentroEstado.QTD_Zero = 0;
            this.CD_DadosAdic_DentroEstado.Size = new System.Drawing.Size(57, 20);
            this.CD_DadosAdic_DentroEstado.ST_AutoInc = false;
            this.CD_DadosAdic_DentroEstado.ST_DisableAuto = false;
            this.CD_DadosAdic_DentroEstado.ST_Float = false;
            this.CD_DadosAdic_DentroEstado.ST_Gravar = true;
            this.CD_DadosAdic_DentroEstado.ST_Int = false;
            this.CD_DadosAdic_DentroEstado.ST_LimpaCampo = true;
            this.CD_DadosAdic_DentroEstado.ST_NotNull = false;
            this.CD_DadosAdic_DentroEstado.ST_PrimaryKey = false;
            this.CD_DadosAdic_DentroEstado.TabIndex = 64;
            this.CD_DadosAdic_DentroEstado.TextOld = null;
            this.CD_DadosAdic_DentroEstado.Leave += new System.EventHandler(this.CD_DadosAdic_DentroEstado_Leave);
            // 
            // tp_movimento
            // 
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsMovimentacao, "tp_movimento", true));
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Location = new System.Drawing.Point(500, 36);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "a";
            this.tp_movimento.NM_Campo = "tp_movimento";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(116, 21);
            this.tp_movimento.ST_Gravar = true;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = true;
            this.tp_movimento.TabIndex = 47;
            // 
            // ds_obsfiscaldentroestado
            // 
            this.ds_obsfiscaldentroestado.BackColor = System.Drawing.SystemColors.Window;
            this.ds_obsfiscaldentroestado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_obsfiscaldentroestado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_obsfiscaldentroestado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_obsfiscaldentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_obsfiscaldentroestado.Enabled = false;
            this.ds_obsfiscaldentroestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_obsfiscaldentroestado.Location = new System.Drawing.Point(243, 114);
            this.ds_obsfiscaldentroestado.Name = "ds_obsfiscaldentroestado";
            this.ds_obsfiscaldentroestado.NM_Alias = "";
            this.ds_obsfiscaldentroestado.NM_Campo = "ds_obsfiscaldentroestado";
            this.ds_obsfiscaldentroestado.NM_CampoBusca = "ds_observacaofiscal";
            this.ds_obsfiscaldentroestado.NM_Param = "";
            this.ds_obsfiscaldentroestado.QTD_Zero = 0;
            this.ds_obsfiscaldentroestado.ReadOnly = true;
            this.ds_obsfiscaldentroestado.Size = new System.Drawing.Size(475, 20);
            this.ds_obsfiscaldentroestado.ST_AutoInc = false;
            this.ds_obsfiscaldentroestado.ST_DisableAuto = false;
            this.ds_obsfiscaldentroestado.ST_Float = false;
            this.ds_obsfiscaldentroestado.ST_Gravar = false;
            this.ds_obsfiscaldentroestado.ST_Int = false;
            this.ds_obsfiscaldentroestado.ST_LimpaCampo = true;
            this.ds_obsfiscaldentroestado.ST_NotNull = false;
            this.ds_obsfiscaldentroestado.ST_PrimaryKey = false;
            this.ds_obsfiscaldentroestado.TabIndex = 54;
            this.ds_obsfiscaldentroestado.TextOld = null;
            // 
            // cd_movimentacao
            // 
            this.cd_movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.cd_movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "Cd_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_movimentacao.Enabled = false;
            this.cd_movimentacao.Location = new System.Drawing.Point(148, 11);
            this.cd_movimentacao.Name = "cd_movimentacao";
            this.cd_movimentacao.NM_Alias = "a";
            this.cd_movimentacao.NM_Campo = "cd_movimentacao";
            this.cd_movimentacao.NM_CampoBusca = "cd_movimentacao";
            this.cd_movimentacao.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_movimentacao.QTD_Zero = 0;
            this.cd_movimentacao.Size = new System.Drawing.Size(104, 20);
            this.cd_movimentacao.ST_AutoInc = false;
            this.cd_movimentacao.ST_DisableAuto = true;
            this.cd_movimentacao.ST_Float = false;
            this.cd_movimentacao.ST_Gravar = true;
            this.cd_movimentacao.ST_Int = false;
            this.cd_movimentacao.ST_LimpaCampo = true;
            this.cd_movimentacao.ST_NotNull = true;
            this.cd_movimentacao.ST_PrimaryKey = true;
            this.cd_movimentacao.TabIndex = 44;
            this.cd_movimentacao.TextOld = null;
            // 
            // bb_obsFisDentro
            // 
            this.bb_obsFisDentro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_obsFisDentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bb_obsFisDentro.Image = ((System.Drawing.Image)(resources.GetObject("bb_obsFisDentro.Image")));
            this.bb_obsFisDentro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_obsFisDentro.Location = new System.Drawing.Point(211, 114);
            this.bb_obsFisDentro.Name = "bb_obsFisDentro";
            this.bb_obsFisDentro.Size = new System.Drawing.Size(30, 20);
            this.bb_obsFisDentro.TabIndex = 63;
            this.bb_obsFisDentro.UseVisualStyleBackColor = true;
            this.bb_obsFisDentro.Click += new System.EventHandler(this.bb_obsFisDentro_Click);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_historico.Location = new System.Drawing.Point(259, 62);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.ReadOnly = true;
            this.ds_historico.Size = new System.Drawing.Size(357, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 52;
            this.ds_historico.TextOld = null;
            // 
            // LB_CD_ObsFiscal_DentroEstado
            // 
            this.LB_CD_ObsFiscal_DentroEstado.AutoSize = true;
            this.LB_CD_ObsFiscal_DentroEstado.BackColor = System.Drawing.Color.Transparent;
            this.LB_CD_ObsFiscal_DentroEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_ObsFiscal_DentroEstado.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_ObsFiscal_DentroEstado.Location = new System.Drawing.Point(12, 117);
            this.LB_CD_ObsFiscal_DentroEstado.Name = "LB_CD_ObsFiscal_DentroEstado";
            this.LB_CD_ObsFiscal_DentroEstado.Size = new System.Drawing.Size(130, 13);
            this.LB_CD_ObsFiscal_DentroEstado.TabIndex = 68;
            this.LB_CD_ObsFiscal_DentroEstado.Text = "Obs.Fiscal Dentro Estado:";
            this.LB_CD_ObsFiscal_DentroEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_ObsFiscal_DentroEstado
            // 
            this.CD_ObsFiscal_DentroEstado.BackColor = System.Drawing.SystemColors.Window;
            this.CD_ObsFiscal_DentroEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_ObsFiscal_DentroEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_ObsFiscal_DentroEstado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_obsfiscal_dentroestado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_ObsFiscal_DentroEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_ObsFiscal_DentroEstado.Location = new System.Drawing.Point(148, 114);
            this.CD_ObsFiscal_DentroEstado.Name = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_DentroEstado.NM_Alias = "a";
            this.CD_ObsFiscal_DentroEstado.NM_Campo = "CD_ObsFiscal_DentroEstado";
            this.CD_ObsFiscal_DentroEstado.NM_CampoBusca = "cd_observacaofiscal";
            this.CD_ObsFiscal_DentroEstado.NM_Param = "@P_CD_OBSFISCAL_DENTROESTADO";
            this.CD_ObsFiscal_DentroEstado.QTD_Zero = 0;
            this.CD_ObsFiscal_DentroEstado.Size = new System.Drawing.Size(57, 20);
            this.CD_ObsFiscal_DentroEstado.ST_AutoInc = false;
            this.CD_ObsFiscal_DentroEstado.ST_DisableAuto = false;
            this.CD_ObsFiscal_DentroEstado.ST_Float = false;
            this.CD_ObsFiscal_DentroEstado.ST_Gravar = true;
            this.CD_ObsFiscal_DentroEstado.ST_Int = false;
            this.CD_ObsFiscal_DentroEstado.ST_LimpaCampo = true;
            this.CD_ObsFiscal_DentroEstado.ST_NotNull = false;
            this.CD_ObsFiscal_DentroEstado.ST_PrimaryKey = false;
            this.CD_ObsFiscal_DentroEstado.TabIndex = 58;
            this.CD_ObsFiscal_DentroEstado.TextOld = null;
            this.CD_ObsFiscal_DentroEstado.Leave += new System.EventHandler(this.CD_ObsFiscal_DentroEstado_Leave);
            // 
            // bb_historico
            // 
            this.bb_historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(224, 62);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(30, 20);
            this.bb_historico.TabIndex = 55;
            this.bb_historico.UseVisualStyleBackColor = true;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // LB_CD_Movimentacao
            // 
            this.LB_CD_Movimentacao.AutoSize = true;
            this.LB_CD_Movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Movimentacao.Location = new System.Drawing.Point(99, 14);
            this.LB_CD_Movimentacao.Name = "LB_CD_Movimentacao";
            this.LB_CD_Movimentacao.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Movimentacao.TabIndex = 45;
            this.LB_CD_Movimentacao.Text = "Código:";
            this.LB_CD_Movimentacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_DS_Movimentacao
            // 
            this.LB_DS_Movimentacao.AutoSize = true;
            this.LB_DS_Movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Movimentacao.Location = new System.Drawing.Point(62, 40);
            this.LB_DS_Movimentacao.Name = "LB_DS_Movimentacao";
            this.LB_DS_Movimentacao.Size = new System.Drawing.Size(80, 13);
            this.LB_DS_Movimentacao.TabIndex = 49;
            this.LB_DS_Movimentacao.Text = "Movimentação:";
            this.LB_DS_Movimentacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LB_CD_Historico
            // 
            this.LB_CD_Historico.AutoSize = true;
            this.LB_CD_Historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Historico.Location = new System.Drawing.Point(91, 65);
            this.LB_CD_Historico.Name = "LB_CD_Historico";
            this.LB_CD_Historico.Size = new System.Drawing.Size(51, 13);
            this.LB_CD_Historico.TabIndex = 60;
            this.LB_CD_Historico.Text = "Histórico:";
            this.LB_CD_Historico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS_Movimentacao
            // 
            this.DS_Movimentacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Movimentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Movimentacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Movimentacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "ds_movimentacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Movimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Movimentacao.Location = new System.Drawing.Point(148, 37);
            this.DS_Movimentacao.Name = "DS_Movimentacao";
            this.DS_Movimentacao.NM_Alias = "";
            this.DS_Movimentacao.NM_Campo = "DS_Movimentacao";
            this.DS_Movimentacao.NM_CampoBusca = "DS_Movimentacao";
            this.DS_Movimentacao.NM_Param = "@P_DS_MOVIMENTACAO";
            this.DS_Movimentacao.QTD_Zero = 0;
            this.DS_Movimentacao.Size = new System.Drawing.Size(328, 20);
            this.DS_Movimentacao.ST_AutoInc = false;
            this.DS_Movimentacao.ST_DisableAuto = false;
            this.DS_Movimentacao.ST_Float = false;
            this.DS_Movimentacao.ST_Gravar = true;
            this.DS_Movimentacao.ST_Int = false;
            this.DS_Movimentacao.ST_LimpaCampo = true;
            this.DS_Movimentacao.ST_NotNull = true;
            this.DS_Movimentacao.ST_PrimaryKey = false;
            this.DS_Movimentacao.TabIndex = 46;
            this.DS_Movimentacao.TextOld = null;
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMovimentacao, "cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Historico.Location = new System.Drawing.Point(148, 62);
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "a";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.Size = new System.Drawing.Size(73, 20);
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = false;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TabIndex = 50;
            this.CD_Historico.TextOld = null;
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // st_vendaconsumidor
            // 
            this.st_vendaconsumidor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_vendaconsumidor.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsMovimentacao, "St_vendaconsumidorbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_vendaconsumidor.Enabled = false;
            this.st_vendaconsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.st_vendaconsumidor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_vendaconsumidor.Location = new System.Drawing.Point(622, 61);
            this.st_vendaconsumidor.Name = "st_vendaconsumidor";
            this.st_vendaconsumidor.NM_Alias = "";
            this.st_vendaconsumidor.NM_Campo = "";
            this.st_vendaconsumidor.NM_Param = "";
            this.st_vendaconsumidor.Size = new System.Drawing.Size(96, 47);
            this.st_vendaconsumidor.ST_Gravar = true;
            this.st_vendaconsumidor.ST_LimparCampo = true;
            this.st_vendaconsumidor.ST_NotNull = false;
            this.st_vendaconsumidor.TabIndex = 83;
            this.st_vendaconsumidor.Text = "Venda Consumidor Final";
            this.st_vendaconsumidor.UseVisualStyleBackColor = true;
            this.st_vendaconsumidor.Vl_False = "";
            this.st_vendaconsumidor.Vl_True = "";
            // 
            // FCadMovimentacaoComercial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 326);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FCadMovimentacaoComercial";
            this.Text = "Cadastro de Movimentação Fiscal";
            this.Load += new System.EventHandler(this.FCadMovimentacaoComercial_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMovimentacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault ds_centroresultado;
        public System.Windows.Forms.Button bb_centroresult;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_centroresult;
        private Componentes.EditDefault ds_DadosAdicInternacional;
        private Componentes.EditDefault ds_DadosAdicForaestado;
        public System.Windows.Forms.Button BB_DadosAdic_Internacional;
        private Componentes.EditDefault ds_DadosAdicdentroestado;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button BB_DadosAdic_ForaEstado;
        private Componentes.EditDefault CD_DadosAdic_Internacional;
        private Componentes.CheckBoxDefault st_gerarspedpiscofins;
        private Componentes.EditDefault ds_obsfiscalinternacional;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button BB_Internacional;
        public System.Windows.Forms.Button BB_DadosAdic_DentroEstado;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault CD_ObsFiscal_Internacional;
        private Componentes.EditDefault CD_DadosAdic_ForaEstado;
        private Componentes.EditDefault ds_obsfiscalforaestado;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button bb_obsFisFora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_CD_ObsFiscal_ForaEstado;
        private Componentes.EditDefault CD_ObsFiscal_ForaEstado;
        private Componentes.EditDefault CD_DadosAdic_DentroEstado;
        private Componentes.ComboBoxDefault tp_movimento;
        private Componentes.EditDefault ds_obsfiscaldentroestado;
        private Componentes.EditDefault cd_movimentacao;
        public System.Windows.Forms.Button bb_obsFisDentro;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Label LB_CD_ObsFiscal_DentroEstado;
        private Componentes.EditDefault CD_ObsFiscal_DentroEstado;
        public System.Windows.Forms.Button bb_historico;
        private System.Windows.Forms.Label LB_CD_Movimentacao;
        private System.Windows.Forms.Label LB_DS_Movimentacao;
        private System.Windows.Forms.Label LB_CD_Historico;
        private Componentes.EditDefault DS_Movimentacao;
        private Componentes.EditDefault CD_Historico;
        private System.Windows.Forms.BindingSource bsMovimentacao;
        private Componentes.CheckBoxDefault st_vendaconsumidor;
    }
}