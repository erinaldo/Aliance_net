namespace Financeiro.Cadastros
{
    partial class TFHistorico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFHistorico));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bsHistorico = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.st_transferencia = new Componentes.CheckBoxDefault(this.components);
            this.Ds_aplicacao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_grupocf_juro = new Componentes.EditDefault(this.components);
            this.bb_grupocf_juro = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_grupocf_juro = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_mov = new Componentes.ComboBoxDefault(this.components);
            this.DS_Historico_Quitacao = new Componentes.EditDefault(this.components);
            this.BB_Historico_Quitacao = new System.Windows.Forms.Button();
            this.CD_Historico_Quitacao = new Componentes.EditDefault(this.components);
            this.LB_DS_Historico = new System.Windows.Forms.Label();
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsHistorico)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(638, 43);
            this.barraMenu.TabIndex = 540;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.Ds_aplicacao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_grupocf_juro);
            this.pDados.Controls.Add(this.bb_grupocf_juro);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cd_grupocf_juro);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.tp_mov);
            this.pDados.Controls.Add(this.DS_Historico_Quitacao);
            this.pDados.Controls.Add(this.BB_Historico_Quitacao);
            this.pDados.Controls.Add(this.CD_Historico_Quitacao);
            this.pDados.Controls.Add(this.LB_DS_Historico);
            this.pDados.Controls.Add(this.DS_Historico);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(638, 173);
            this.pDados.TabIndex = 0;
            // 
            // bsHistorico
            // 
            this.bsHistorico.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadHistorico);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 427;
            this.label1.Text = "Histórico de Quitação:";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.st_transferencia);
            this.panelDados1.Location = new System.Drawing.Point(484, 46);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(149, 32);
            this.panelDados1.TabIndex = 8;
            // 
            // st_transferencia
            // 
            this.st_transferencia.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsHistorico, "St_transferenciabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_transferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.st_transferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.st_transferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_transferencia.Location = new System.Drawing.Point(0, 0);
            this.st_transferencia.Name = "st_transferencia";
            this.st_transferencia.NM_Alias = "";
            this.st_transferencia.NM_Campo = "";
            this.st_transferencia.NM_Param = "";
            this.st_transferencia.Size = new System.Drawing.Size(147, 30);
            this.st_transferencia.ST_Gravar = true;
            this.st_transferencia.ST_LimparCampo = true;
            this.st_transferencia.ST_NotNull = false;
            this.st_transferencia.TabIndex = 0;
            this.st_transferencia.Text = "Transferencia entre contas gerencias";
            this.st_transferencia.UseVisualStyleBackColor = true;
            this.st_transferencia.Vl_False = "";
            this.st_transferencia.Vl_True = "";
            // 
            // Ds_aplicacao
            // 
            this.Ds_aplicacao.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_aplicacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_aplicacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_aplicacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_aplicacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_aplicacao.Location = new System.Drawing.Point(124, 84);
            this.Ds_aplicacao.Multiline = true;
            this.Ds_aplicacao.Name = "Ds_aplicacao";
            this.Ds_aplicacao.NM_Alias = "";
            this.Ds_aplicacao.NM_Campo = "";
            this.Ds_aplicacao.NM_CampoBusca = "";
            this.Ds_aplicacao.NM_Param = "";
            this.Ds_aplicacao.QTD_Zero = 0;
            this.Ds_aplicacao.Size = new System.Drawing.Size(509, 81);
            this.Ds_aplicacao.ST_AutoInc = false;
            this.Ds_aplicacao.ST_DisableAuto = false;
            this.Ds_aplicacao.ST_Float = false;
            this.Ds_aplicacao.ST_Gravar = true;
            this.Ds_aplicacao.ST_Int = false;
            this.Ds_aplicacao.ST_LimpaCampo = true;
            this.Ds_aplicacao.ST_NotNull = false;
            this.Ds_aplicacao.ST_PrimaryKey = false;
            this.Ds_aplicacao.TabIndex = 8;
            this.Ds_aplicacao.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(61, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 425;
            this.label2.Text = "Aplicação:";
            // 
            // ds_grupocf_juro
            // 
            this.ds_grupocf_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_grupocf_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_grupocf_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_grupocf_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_grupoCF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_grupocf_juro.Enabled = false;
            this.ds_grupocf_juro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_grupocf_juro.Location = new System.Drawing.Point(234, 58);
            this.ds_grupocf_juro.Name = "ds_grupocf_juro";
            this.ds_grupocf_juro.NM_Alias = "";
            this.ds_grupocf_juro.NM_Campo = "ds_grupocf";
            this.ds_grupocf_juro.NM_CampoBusca = "ds_grupocf";
            this.ds_grupocf_juro.NM_Param = "@P_DS_HISTORICO_DESCONTO";
            this.ds_grupocf_juro.QTD_Zero = 0;
            this.ds_grupocf_juro.ReadOnly = true;
            this.ds_grupocf_juro.Size = new System.Drawing.Size(244, 20);
            this.ds_grupocf_juro.ST_AutoInc = false;
            this.ds_grupocf_juro.ST_DisableAuto = false;
            this.ds_grupocf_juro.ST_Float = false;
            this.ds_grupocf_juro.ST_Gravar = false;
            this.ds_grupocf_juro.ST_Int = false;
            this.ds_grupocf_juro.ST_LimpaCampo = true;
            this.ds_grupocf_juro.ST_NotNull = false;
            this.ds_grupocf_juro.ST_PrimaryKey = false;
            this.ds_grupocf_juro.TabIndex = 424;
            this.ds_grupocf_juro.TextOld = null;
            // 
            // bb_grupocf_juro
            // 
            this.bb_grupocf_juro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_grupocf_juro.Image = ((System.Drawing.Image)(resources.GetObject("bb_grupocf_juro.Image")));
            this.bb_grupocf_juro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_grupocf_juro.Location = new System.Drawing.Point(201, 58);
            this.bb_grupocf_juro.Name = "bb_grupocf_juro";
            this.bb_grupocf_juro.Size = new System.Drawing.Size(30, 20);
            this.bb_grupocf_juro.TabIndex = 5;
            this.bb_grupocf_juro.UseVisualStyleBackColor = true;
            this.bb_grupocf_juro.Click += new System.EventHandler(this.bb_grupocf_juro_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(34, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 423;
            this.label7.Text = "Despesas Fixas:";
            // 
            // cd_grupocf_juro
            // 
            this.cd_grupocf_juro.BackColor = System.Drawing.SystemColors.Window;
            this.cd_grupocf_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_grupocf_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_grupocf_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Cd_grupoCF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_grupocf_juro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_grupocf_juro.Location = new System.Drawing.Point(124, 58);
            this.cd_grupocf_juro.Name = "cd_grupocf_juro";
            this.cd_grupocf_juro.NM_Alias = "a";
            this.cd_grupocf_juro.NM_Campo = "cd_grupocf";
            this.cd_grupocf_juro.NM_CampoBusca = "cd_grupocf";
            this.cd_grupocf_juro.NM_Param = "@P_CD_HISTORICO_DCAMB_PASSIVA";
            this.cd_grupocf_juro.QTD_Zero = 0;
            this.cd_grupocf_juro.Size = new System.Drawing.Size(76, 20);
            this.cd_grupocf_juro.ST_AutoInc = false;
            this.cd_grupocf_juro.ST_DisableAuto = false;
            this.cd_grupocf_juro.ST_Float = false;
            this.cd_grupocf_juro.ST_Gravar = true;
            this.cd_grupocf_juro.ST_Int = false;
            this.cd_grupocf_juro.ST_LimpaCampo = true;
            this.cd_grupocf_juro.ST_NotNull = false;
            this.cd_grupocf_juro.ST_PrimaryKey = false;
            this.cd_grupocf_juro.TabIndex = 4;
            this.cd_grupocf_juro.TextOld = null;
            this.cd_grupocf_juro.Leave += new System.EventHandler(this.cd_grupocf_juro_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(483, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 422;
            this.label3.Text = "Movimento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tp_mov
            // 
            this.tp_mov.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsHistorico, "Tp_mov", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_mov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_mov.FormattingEnabled = true;
            this.tp_mov.Location = new System.Drawing.Point(486, 19);
            this.tp_mov.Name = "tp_mov";
            this.tp_mov.NM_Alias = "a";
            this.tp_mov.NM_Campo = "tp_mov";
            this.tp_mov.NM_Param = "@P_TP_MOV";
            this.tp_mov.Size = new System.Drawing.Size(147, 21);
            this.tp_mov.ST_Gravar = true;
            this.tp_mov.ST_LimparCampo = true;
            this.tp_mov.ST_NotNull = true;
            this.tp_mov.TabIndex = 3;
            // 
            // DS_Historico_Quitacao
            // 
            this.DS_Historico_Quitacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico_Quitacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico_Quitacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico_Quitacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "DS_Historico_Quitacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Historico_Quitacao.Enabled = false;
            this.DS_Historico_Quitacao.Location = new System.Drawing.Point(233, 32);
            this.DS_Historico_Quitacao.Name = "DS_Historico_Quitacao";
            this.DS_Historico_Quitacao.NM_Alias = "";
            this.DS_Historico_Quitacao.NM_Campo = "DS_Historico_Quitacao";
            this.DS_Historico_Quitacao.NM_CampoBusca = "DS_Historico";
            this.DS_Historico_Quitacao.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico_Quitacao.QTD_Zero = 0;
            this.DS_Historico_Quitacao.ReadOnly = true;
            this.DS_Historico_Quitacao.Size = new System.Drawing.Size(245, 20);
            this.DS_Historico_Quitacao.ST_AutoInc = false;
            this.DS_Historico_Quitacao.ST_DisableAuto = false;
            this.DS_Historico_Quitacao.ST_Float = false;
            this.DS_Historico_Quitacao.ST_Gravar = false;
            this.DS_Historico_Quitacao.ST_Int = false;
            this.DS_Historico_Quitacao.ST_LimpaCampo = true;
            this.DS_Historico_Quitacao.ST_NotNull = false;
            this.DS_Historico_Quitacao.ST_PrimaryKey = false;
            this.DS_Historico_Quitacao.TabIndex = 420;
            this.DS_Historico_Quitacao.TextOld = null;
            // 
            // BB_Historico_Quitacao
            // 
            this.BB_Historico_Quitacao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Historico_Quitacao.Image = ((System.Drawing.Image)(resources.GetObject("BB_Historico_Quitacao.Image")));
            this.BB_Historico_Quitacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Historico_Quitacao.Location = new System.Drawing.Point(201, 32);
            this.BB_Historico_Quitacao.Name = "BB_Historico_Quitacao";
            this.BB_Historico_Quitacao.Size = new System.Drawing.Size(30, 20);
            this.BB_Historico_Quitacao.TabIndex = 2;
            this.BB_Historico_Quitacao.UseVisualStyleBackColor = true;
            this.BB_Historico_Quitacao.Click += new System.EventHandler(this.BB_Historico_Quitacao_Click);
            // 
            // CD_Historico_Quitacao
            // 
            this.CD_Historico_Quitacao.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico_Quitacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico_Quitacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico_Quitacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "CD_Historico_Quitacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Historico_Quitacao.Location = new System.Drawing.Point(124, 32);
            this.CD_Historico_Quitacao.Name = "CD_Historico_Quitacao";
            this.CD_Historico_Quitacao.NM_Alias = "a";
            this.CD_Historico_Quitacao.NM_Campo = "CD_Historico_Quitacao";
            this.CD_Historico_Quitacao.NM_CampoBusca = "CD_Historico";
            this.CD_Historico_Quitacao.NM_Param = "@P_CD_HISTORICO_QUITACAO";
            this.CD_Historico_Quitacao.QTD_Zero = 0;
            this.CD_Historico_Quitacao.Size = new System.Drawing.Size(76, 20);
            this.CD_Historico_Quitacao.ST_AutoInc = false;
            this.CD_Historico_Quitacao.ST_DisableAuto = false;
            this.CD_Historico_Quitacao.ST_Float = false;
            this.CD_Historico_Quitacao.ST_Gravar = true;
            this.CD_Historico_Quitacao.ST_Int = false;
            this.CD_Historico_Quitacao.ST_LimpaCampo = true;
            this.CD_Historico_Quitacao.ST_NotNull = false;
            this.CD_Historico_Quitacao.ST_PrimaryKey = false;
            this.CD_Historico_Quitacao.TabIndex = 1;
            this.CD_Historico_Quitacao.TextOld = null;
            this.CD_Historico_Quitacao.Leave += new System.EventHandler(this.CD_Historico_Quitacao_Leave);
            // 
            // LB_DS_Historico
            // 
            this.LB_DS_Historico.AutoSize = true;
            this.LB_DS_Historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Historico.Location = new System.Drawing.Point(67, 8);
            this.LB_DS_Historico.Name = "LB_DS_Historico";
            this.LB_DS_Historico.Size = new System.Drawing.Size(51, 13);
            this.LB_DS_Historico.TabIndex = 411;
            this.LB_DS_Historico.Text = "Histórico:";
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsHistorico, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Historico.Location = new System.Drawing.Point(124, 5);
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = "a";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.Size = new System.Drawing.Size(354, 20);
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = true;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = true;
            this.DS_Historico.ST_PrimaryKey = false;
            this.DS_Historico.TabIndex = 0;
            this.DS_Historico.TextOld = null;
            // 
            // TFHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 216);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFHistorico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Históricos Financeiros";
            this.Load += new System.EventHandler(this.TFHistorico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFHistorico_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsHistorico)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault Ds_aplicacao;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_grupocf_juro;
        private System.Windows.Forms.Button bb_grupocf_juro;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_grupocf_juro;
        private System.Windows.Forms.Label label3;
        private Componentes.ComboBoxDefault tp_mov;
        private Componentes.EditDefault DS_Historico_Quitacao;
        public System.Windows.Forms.Button BB_Historico_Quitacao;
        private Componentes.EditDefault CD_Historico_Quitacao;
        private System.Windows.Forms.Label LB_DS_Historico;
        private Componentes.EditDefault DS_Historico;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault st_transferencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bsHistorico;
    }
}