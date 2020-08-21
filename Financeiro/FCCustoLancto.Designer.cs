namespace Financeiro
{
    partial class TFCCustoLancto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCCustoLancto));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.nr_orcamento = new Componentes.EditDefault(this.components);
            this.bsCCusto = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_orcamento = new System.Windows.Forms.Button();
            this.tp_movimento = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vl_lancto = new Componentes.EditFloat(this.components);
            this.dt_lancto = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_ccusto = new Componentes.EditDefault(this.components);
            this.cd_ccusto = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bb_ccusto = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(549, 43);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.nr_orcamento);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_orcamento);
            this.pDados.Controls.Add(this.tp_movimento);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.vl_lancto);
            this.pDados.Controls.Add(this.dt_lancto);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_ccusto);
            this.pDados.Controls.Add(this.cd_ccusto);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.bb_ccusto);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(549, 215);
            this.pDados.TabIndex = 12;
            // 
            // nr_orcamento
            // 
            this.nr_orcamento.BackColor = System.Drawing.Color.White;
            this.nr_orcamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_orcamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_orcamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Nr_orcamentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_orcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nr_orcamento.Location = new System.Drawing.Point(6, 97);
            this.nr_orcamento.Name = "nr_orcamento";
            this.nr_orcamento.NM_Alias = "";
            this.nr_orcamento.NM_Campo = "nr_orcamento";
            this.nr_orcamento.NM_CampoBusca = "nr_orcamento";
            this.nr_orcamento.NM_Param = "@P_CD_EMPRESA";
            this.nr_orcamento.QTD_Zero = 0;
            this.nr_orcamento.Size = new System.Drawing.Size(79, 20);
            this.nr_orcamento.ST_AutoInc = false;
            this.nr_orcamento.ST_DisableAuto = false;
            this.nr_orcamento.ST_Float = false;
            this.nr_orcamento.ST_Gravar = true;
            this.nr_orcamento.ST_Int = false;
            this.nr_orcamento.ST_LimpaCampo = true;
            this.nr_orcamento.ST_NotNull = false;
            this.nr_orcamento.ST_PrimaryKey = false;
            this.nr_orcamento.TabIndex = 4;
            this.nr_orcamento.TextOld = null;
            this.nr_orcamento.Leave += new System.EventHandler(this.nr_orcamento_Leave);
            // 
            // bsCCusto
            // 
            this.bsCCusto.DataSource = typeof(CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Orçamento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_orcamento
            // 
            this.bb_orcamento.BackColor = System.Drawing.SystemColors.Control;
            this.bb_orcamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_orcamento.Image")));
            this.bb_orcamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_orcamento.Location = new System.Drawing.Point(86, 97);
            this.bb_orcamento.Name = "bb_orcamento";
            this.bb_orcamento.Size = new System.Drawing.Size(28, 20);
            this.bb_orcamento.TabIndex = 5;
            this.bb_orcamento.UseVisualStyleBackColor = false;
            this.bb_orcamento.Click += new System.EventHandler(this.bb_orcamento_Click);
            // 
            // tp_movimento
            // 
            this.tp_movimento.BackColor = System.Drawing.SystemColors.Window;
            this.tp_movimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_movimento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_movimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Tipo_movimento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_movimento.Enabled = false;
            this.tp_movimento.Location = new System.Drawing.Point(463, 59);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "ds_centroresultado";
            this.tp_movimento.NM_CampoBusca = "ds_centroresultado";
            this.tp_movimento.NM_Param = "@P_NR_DOCTO";
            this.tp_movimento.QTD_Zero = 0;
            this.tp_movimento.Size = new System.Drawing.Size(78, 20);
            this.tp_movimento.ST_AutoInc = false;
            this.tp_movimento.ST_DisableAuto = false;
            this.tp_movimento.ST_Float = false;
            this.tp_movimento.ST_Gravar = false;
            this.tp_movimento.ST_Int = false;
            this.tp_movimento.ST_LimpaCampo = true;
            this.tp_movimento.ST_NotNull = false;
            this.tp_movimento.ST_PrimaryKey = false;
            this.tp_movimento.TabIndex = 52;
            this.tp_movimento.TextOld = null;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(6, 136);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(535, 71);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 8;
            this.ds_observacao.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Observação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(202, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Valor";
            // 
            // vl_lancto
            // 
            this.vl_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCCusto, "Vl_lancto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_lancto.DecimalPlaces = 2;
            this.vl_lancto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.vl_lancto.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_lancto.Location = new System.Drawing.Point(205, 97);
            this.vl_lancto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_lancto.Name = "vl_lancto";
            this.vl_lancto.NM_Alias = "";
            this.vl_lancto.NM_Campo = "";
            this.vl_lancto.NM_Param = "";
            this.vl_lancto.Operador = "";
            this.vl_lancto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_lancto.Size = new System.Drawing.Size(103, 20);
            this.vl_lancto.ST_AutoInc = false;
            this.vl_lancto.ST_DisableAuto = false;
            this.vl_lancto.ST_Gravar = true;
            this.vl_lancto.ST_LimparCampo = true;
            this.vl_lancto.ST_NotNull = true;
            this.vl_lancto.ST_PrimaryKey = false;
            this.vl_lancto.TabIndex = 7;
            this.vl_lancto.ThousandsSeparator = true;
            // 
            // dt_lancto
            // 
            this.dt_lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_lancto.Location = new System.Drawing.Point(120, 97);
            this.dt_lancto.Mask = "00/00/0000";
            this.dt_lancto.Name = "dt_lancto";
            this.dt_lancto.NM_Alias = "";
            this.dt_lancto.NM_Campo = "";
            this.dt_lancto.NM_CampoBusca = "";
            this.dt_lancto.NM_Param = "";
            this.dt_lancto.Operador = "";
            this.dt_lancto.Size = new System.Drawing.Size(79, 20);
            this.dt_lancto.ST_Gravar = true;
            this.dt_lancto.ST_LimpaCampo = true;
            this.dt_lancto.ST_NotNull = true;
            this.dt_lancto.ST_PrimaryKey = false;
            this.dt_lancto.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(117, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Data";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(115, 19);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(426, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 46;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(86, 19);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Location = new System.Drawing.Point(6, 19);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_Empresa";
            this.cd_empresa.NM_CampoBusca = "CD_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(79, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Empresa";
            // 
            // ds_ccusto
            // 
            this.ds_ccusto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ccusto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Ds_centroresultado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_ccusto.Enabled = false;
            this.ds_ccusto.Location = new System.Drawing.Point(115, 59);
            this.ds_ccusto.Name = "ds_ccusto";
            this.ds_ccusto.NM_Alias = "";
            this.ds_ccusto.NM_Campo = "ds_centroresultado";
            this.ds_ccusto.NM_CampoBusca = "ds_centroresultado";
            this.ds_ccusto.NM_Param = "@P_NR_DOCTO";
            this.ds_ccusto.QTD_Zero = 0;
            this.ds_ccusto.Size = new System.Drawing.Size(346, 20);
            this.ds_ccusto.ST_AutoInc = false;
            this.ds_ccusto.ST_DisableAuto = false;
            this.ds_ccusto.ST_Float = false;
            this.ds_ccusto.ST_Gravar = false;
            this.ds_ccusto.ST_Int = false;
            this.ds_ccusto.ST_LimpaCampo = true;
            this.ds_ccusto.ST_NotNull = false;
            this.ds_ccusto.ST_PrimaryKey = false;
            this.ds_ccusto.TabIndex = 42;
            this.ds_ccusto.TextOld = null;
            // 
            // cd_ccusto
            // 
            this.cd_ccusto.BackColor = System.Drawing.Color.White;
            this.cd_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ccusto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCCusto, "Cd_centroresult", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_ccusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_ccusto.Location = new System.Drawing.Point(6, 58);
            this.cd_ccusto.Name = "cd_ccusto";
            this.cd_ccusto.NM_Alias = "";
            this.cd_ccusto.NM_Campo = "cd_centroresult";
            this.cd_ccusto.NM_CampoBusca = "cd_centroresult";
            this.cd_ccusto.NM_Param = "@P_CD_EMPRESA";
            this.cd_ccusto.QTD_Zero = 0;
            this.cd_ccusto.Size = new System.Drawing.Size(79, 20);
            this.cd_ccusto.ST_AutoInc = false;
            this.cd_ccusto.ST_DisableAuto = false;
            this.cd_ccusto.ST_Float = false;
            this.cd_ccusto.ST_Gravar = true;
            this.cd_ccusto.ST_Int = false;
            this.cd_ccusto.ST_LimpaCampo = true;
            this.cd_ccusto.ST_NotNull = true;
            this.cd_ccusto.ST_PrimaryKey = false;
            this.cd_ccusto.TabIndex = 2;
            this.cd_ccusto.TextOld = null;
            this.cd_ccusto.Leave += new System.EventHandler(this.cd_ccusto_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Centro Resultado";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_ccusto
            // 
            this.bb_ccusto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_ccusto.Image = ((System.Drawing.Image)(resources.GetObject("bb_ccusto.Image")));
            this.bb_ccusto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ccusto.Location = new System.Drawing.Point(86, 58);
            this.bb_ccusto.Name = "bb_ccusto";
            this.bb_ccusto.Size = new System.Drawing.Size(28, 20);
            this.bb_ccusto.TabIndex = 3;
            this.bb_ccusto.UseVisualStyleBackColor = false;
            this.bb_ccusto.Click += new System.EventHandler(this.bb_ccusto_Click);
            // 
            // TFCCustoLancto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 258);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCCustoLancto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento Centro Resultado";
            this.Load += new System.EventHandler(this.TFCCustoLancto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCCustoLancto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCCusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_lancto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_ccusto;
        private Componentes.EditDefault cd_ccusto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bb_ccusto;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.EditData dt_lancto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat vl_lancto;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault tp_movimento;
        private System.Windows.Forms.BindingSource bsCCusto;
        private Componentes.EditDefault nr_orcamento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_orcamento;
    }
}