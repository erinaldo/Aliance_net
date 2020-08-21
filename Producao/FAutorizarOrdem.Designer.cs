namespace Producao
{
    partial class TFAutorizarOrdem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAutorizarOrdem));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsOrdemProducao = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_formulacao = new System.Windows.Forms.Button();
            this.dt_ordem = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_formula = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.id_formulacao = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.sg_unidade = new Componentes.EditDefault(this.components);
            this.qtd_programada = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_prevproducao = new Componentes.EditData(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.ds_unidade = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cd_unidade = new Componentes.EditDefault(this.components);
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemProducao)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_programada)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(562, 43);
            this.barraMenu.TabIndex = 10;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // bsOrdemProducao
            // 
            this.bsOrdemProducao.DataSource = typeof(CamadaDados.Producao.Producao.TList_OrdemProducao);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.bb_formulacao);
            this.pDados.Controls.Add(this.dt_ordem);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_formula);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.id_formulacao);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.sg_unidade);
            this.pDados.Controls.Add(this.qtd_programada);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.dt_prevproducao);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.ds_unidade);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_unidade);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(562, 206);
            this.pDados.TabIndex = 11;
            // 
            // bb_formulacao
            // 
            this.bb_formulacao.Image = ((System.Drawing.Image)(resources.GetObject("bb_formulacao.Image")));
            this.bb_formulacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_formulacao.Location = new System.Drawing.Point(128, 81);
            this.bb_formulacao.Name = "bb_formulacao";
            this.bb_formulacao.Size = new System.Drawing.Size(28, 19);
            this.bb_formulacao.TabIndex = 48;
            this.bb_formulacao.UseVisualStyleBackColor = true;
            this.bb_formulacao.Click += new System.EventHandler(this.bb_formulacao_Click);
            // 
            // dt_ordem
            // 
            this.dt_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Dt_ordemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_ordem.Enabled = false;
            this.dt_ordem.Location = new System.Drawing.Point(81, 107);
            this.dt_ordem.Mask = "00/00/0000";
            this.dt_ordem.Name = "dt_ordem";
            this.dt_ordem.NM_Alias = "";
            this.dt_ordem.NM_Campo = "";
            this.dt_ordem.NM_CampoBusca = "";
            this.dt_ordem.NM_Param = "";
            this.dt_ordem.Operador = "";
            this.dt_ordem.Size = new System.Drawing.Size(70, 20);
            this.dt_ordem.ST_Gravar = true;
            this.dt_ordem.ST_LimpaCampo = true;
            this.dt_ordem.ST_NotNull = false;
            this.dt_ordem.ST_PrimaryKey = false;
            this.dt_ordem.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(17, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Dt. Ordem:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_formula
            // 
            this.ds_formula.BackColor = System.Drawing.SystemColors.Window;
            this.ds_formula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_formula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_formula.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Ds_formula", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_formula.Enabled = false;
            this.ds_formula.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_formula.Location = new System.Drawing.Point(159, 81);
            this.ds_formula.Name = "ds_formula";
            this.ds_formula.NM_Alias = "";
            this.ds_formula.NM_Campo = "ds_formula";
            this.ds_formula.NM_CampoBusca = "ds_formula";
            this.ds_formula.NM_Param = "@P_DS_FORMULA";
            this.ds_formula.QTD_Zero = 0;
            this.ds_formula.ReadOnly = true;
            this.ds_formula.Size = new System.Drawing.Size(392, 20);
            this.ds_formula.ST_AutoInc = false;
            this.ds_formula.ST_DisableAuto = false;
            this.ds_formula.ST_Float = false;
            this.ds_formula.ST_Gravar = false;
            this.ds_formula.ST_Int = false;
            this.ds_formula.ST_LimpaCampo = true;
            this.ds_formula.ST_NotNull = false;
            this.ds_formula.ST_PrimaryKey = false;
            this.ds_formula.TabIndex = 46;
            this.ds_formula.TextOld = null;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(28, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Formula:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // id_formulacao
            // 
            this.id_formulacao.BackColor = System.Drawing.SystemColors.Window;
            this.id_formulacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_formulacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_formulacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Id_formulacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_formulacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_formulacao.Location = new System.Drawing.Point(81, 81);
            this.id_formulacao.Name = "id_formulacao";
            this.id_formulacao.NM_Alias = "";
            this.id_formulacao.NM_Campo = "id_formulacao";
            this.id_formulacao.NM_CampoBusca = "id_formulacao";
            this.id_formulacao.NM_Param = "@P_CD_EMPRESA";
            this.id_formulacao.QTD_Zero = 0;
            this.id_formulacao.Size = new System.Drawing.Size(50, 20);
            this.id_formulacao.ST_AutoInc = false;
            this.id_formulacao.ST_DisableAuto = false;
            this.id_formulacao.ST_Float = false;
            this.id_formulacao.ST_Gravar = true;
            this.id_formulacao.ST_Int = true;
            this.id_formulacao.ST_LimpaCampo = true;
            this.id_formulacao.ST_NotNull = true;
            this.id_formulacao.ST_PrimaryKey = false;
            this.id_formulacao.TabIndex = 6;
            this.id_formulacao.TextOld = null;
            this.id_formulacao.Leave += new System.EventHandler(this.id_formulacao_Leave);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(81, 134);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(470, 61);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 11;
            this.ds_observacao.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(7, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Observação:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sg_unidade
            // 
            this.sg_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sg_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sg_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sg_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sg_unidade.Enabled = false;
            this.sg_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sg_unidade.Location = new System.Drawing.Point(528, 108);
            this.sg_unidade.Name = "sg_unidade";
            this.sg_unidade.NM_Alias = "";
            this.sg_unidade.NM_Campo = "sigla_unidade";
            this.sg_unidade.NM_CampoBusca = "sigla_unidade";
            this.sg_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sg_unidade.QTD_Zero = 0;
            this.sg_unidade.ReadOnly = true;
            this.sg_unidade.Size = new System.Drawing.Size(23, 20);
            this.sg_unidade.ST_AutoInc = false;
            this.sg_unidade.ST_DisableAuto = false;
            this.sg_unidade.ST_Float = false;
            this.sg_unidade.ST_Gravar = false;
            this.sg_unidade.ST_Int = false;
            this.sg_unidade.ST_LimpaCampo = true;
            this.sg_unidade.ST_NotNull = false;
            this.sg_unidade.ST_PrimaryKey = false;
            this.sg_unidade.TabIndex = 40;
            this.sg_unidade.TextOld = null;
            // 
            // qtd_programada
            // 
            this.qtd_programada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsOrdemProducao, "Qtd_programada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_programada.DecimalPlaces = 3;
            this.qtd_programada.Enabled = false;
            this.qtd_programada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_programada.Location = new System.Drawing.Point(448, 108);
            this.qtd_programada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_programada.Name = "qtd_programada";
            this.qtd_programada.NM_Alias = "";
            this.qtd_programada.NM_Campo = "";
            this.qtd_programada.NM_Param = "";
            this.qtd_programada.Operador = "";
            this.qtd_programada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_programada.Size = new System.Drawing.Size(77, 20);
            this.qtd_programada.ST_AutoInc = false;
            this.qtd_programada.ST_DisableAuto = false;
            this.qtd_programada.ST_Gravar = true;
            this.qtd_programada.ST_LimparCampo = true;
            this.qtd_programada.ST_NotNull = true;
            this.qtd_programada.ST_PrimaryKey = false;
            this.qtd_programada.TabIndex = 10;
            this.qtd_programada.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(352, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Qtd. Programada:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_prevproducao
            // 
            this.dt_prevproducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_prevproducao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Dt_prevproducaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_prevproducao.Location = new System.Drawing.Point(276, 107);
            this.dt_prevproducao.Mask = "00/00/0000";
            this.dt_prevproducao.Name = "dt_prevproducao";
            this.dt_prevproducao.NM_Alias = "";
            this.dt_prevproducao.NM_Campo = "";
            this.dt_prevproducao.NM_CampoBusca = "";
            this.dt_prevproducao.NM_Param = "";
            this.dt_prevproducao.Operador = "";
            this.dt_prevproducao.Size = new System.Drawing.Size(70, 20);
            this.dt_prevproducao.ST_Gravar = true;
            this.dt_prevproducao.ST_LimpaCampo = true;
            this.dt_prevproducao.ST_NotNull = true;
            this.dt_prevproducao.ST_PrimaryKey = false;
            this.dt_prevproducao.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(156, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Dt. Prevista Produção:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sigla_unidade.Location = new System.Drawing.Point(528, 55);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.ReadOnly = true;
            this.sigla_unidade.Size = new System.Drawing.Size(23, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 35;
            this.sigla_unidade.TextOld = null;
            // 
            // ds_unidade
            // 
            this.ds_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Ds_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_unidade.Enabled = false;
            this.ds_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_unidade.Location = new System.Drawing.Point(133, 55);
            this.ds_unidade.Name = "ds_unidade";
            this.ds_unidade.NM_Alias = "";
            this.ds_unidade.NM_Campo = "ds_Unidade";
            this.ds_unidade.NM_CampoBusca = "ds_unidade";
            this.ds_unidade.NM_Param = "@P_DS_UNIDADE";
            this.ds_unidade.QTD_Zero = 0;
            this.ds_unidade.ReadOnly = true;
            this.ds_unidade.Size = new System.Drawing.Size(392, 20);
            this.ds_unidade.ST_AutoInc = false;
            this.ds_unidade.ST_DisableAuto = false;
            this.ds_unidade.ST_Float = false;
            this.ds_unidade.ST_Gravar = false;
            this.ds_unidade.ST_Int = false;
            this.ds_unidade.ST_LimpaCampo = true;
            this.ds_unidade.ST_NotNull = false;
            this.ds_unidade.ST_PrimaryKey = false;
            this.ds_unidade.TabIndex = 34;
            this.ds_unidade.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(25, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Unidade:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_unidade
            // 
            this.cd_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Cd_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_unidade.Enabled = false;
            this.cd_unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_unidade.Location = new System.Drawing.Point(81, 55);
            this.cd_unidade.Name = "cd_unidade";
            this.cd_unidade.NM_Alias = "";
            this.cd_unidade.NM_Campo = "cd_unidade";
            this.cd_unidade.NM_CampoBusca = "cd_unidade";
            this.cd_unidade.NM_Param = "@P_CD_EMPRESA";
            this.cd_unidade.QTD_Zero = 0;
            this.cd_unidade.Size = new System.Drawing.Size(50, 20);
            this.cd_unidade.ST_AutoInc = false;
            this.cd_unidade.ST_DisableAuto = false;
            this.cd_unidade.ST_Float = false;
            this.cd_unidade.ST_Gravar = true;
            this.cd_unidade.ST_Int = true;
            this.cd_unidade.ST_LimpaCampo = true;
            this.cd_unidade.ST_NotNull = true;
            this.cd_unidade.ST_PrimaryKey = false;
            this.cd_unidade.TabIndex = 4;
            this.cd_unidade.TextOld = null;
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produto.Location = new System.Drawing.Point(159, 29);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_PRODUTO";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.ReadOnly = true;
            this.ds_produto.Size = new System.Drawing.Size(392, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 30;
            this.ds_produto.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(28, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Produto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(81, 29);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(75, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 2;
            this.cd_produto.TextOld = null;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(159, 3);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(392, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 26;
            this.NM_Empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsOrdemProducao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(81, 3);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(75, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            this.CD_Empresa.TextOld = null;
            // 
            // TFAutorizarOrdem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 249);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFAutorizarOrdem";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizar Ordem Produção";
            this.Load += new System.EventHandler(this.TFAutorizarOrdem_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAutorizarOrdem_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrdemProducao)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_programada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsOrdemProducao;
        private Componentes.PanelDados pDados;
        private Componentes.EditData dt_ordem;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_formula;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault id_formulacao;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault sg_unidade;
        private Componentes.EditFloat qtd_programada;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_prevproducao;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault sigla_unidade;
        private Componentes.EditDefault ds_unidade;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_unidade;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Button bb_formulacao;
    }
}