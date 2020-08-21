namespace Empreendimento
{
    partial class FServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServico));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dsCidade = new Componentes.EditDefault(this.components);
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.cd_cidade = new Componentes.EditDefault(this.components);
            this.bbCidade = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total_orc_i = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.vl_execucao_pc = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.valor_execucao = new Componentes.EditFloat(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.Saldo_Faturar_i = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tot_orc = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.valor_nota = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.saldo_faturar = new Componentes.EditFloat(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bsOrcamento = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_orc_i)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_execucao_pc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_execucao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saldo_Faturar_i)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_nota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_faturar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(462, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Green;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 40);
            this.toolStripButton1.Text = "(F4)\r\nConfirmar";
            this.toolStripButton1.ToolTipText = "Confirmar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            this.panelDados1.Controls.Add(this.dsCidade);
            this.panelDados1.Controls.Add(this.cd_cidade);
            this.panelDados1.Controls.Add(this.bbCidade);
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.label6);
            this.panelDados1.Controls.Add(this.total_orc_i);
            this.panelDados1.Controls.Add(this.label7);
            this.panelDados1.Controls.Add(this.vl_execucao_pc);
            this.panelDados1.Controls.Add(this.label8);
            this.panelDados1.Controls.Add(this.valor_execucao);
            this.panelDados1.Controls.Add(this.label9);
            this.panelDados1.Controls.Add(this.Saldo_Faturar_i);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.tot_orc);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.valor_nota);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.saldo_faturar);
            this.panelDados1.Controls.Add(this.editDefault2);
            this.panelDados1.Controls.Add(this.editDefault1);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(462, 181);
            this.panelDados1.TabIndex = 0;
            // 
            // dsCidade
            // 
            this.dsCidade.BackColor = System.Drawing.SystemColors.Window;
            this.dsCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dsCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dsCidade.Location = new System.Drawing.Point(107, 66);
            this.dsCidade.Name = "dsCidade";
            this.dsCidade.NM_Alias = "";
            this.dsCidade.NM_Campo = "ds_cidade";
            this.dsCidade.NM_CampoBusca = "ds_cidade";
            this.dsCidade.NM_Param = "@P_DS_CIDADE";
            this.dsCidade.QTD_Zero = 0;
            this.dsCidade.ReadOnly = true;
            this.dsCidade.Size = new System.Drawing.Size(343, 20);
            this.dsCidade.ST_AutoInc = false;
            this.dsCidade.ST_DisableAuto = false;
            this.dsCidade.ST_Float = false;
            this.dsCidade.ST_Gravar = false;
            this.dsCidade.ST_Int = false;
            this.dsCidade.ST_LimpaCampo = true;
            this.dsCidade.ST_NotNull = false;
            this.dsCidade.ST_PrimaryKey = false;
            this.dsCidade.TabIndex = 28;
            this.dsCidade.TextOld = null;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Empreendimento.TList_FichaTec);
            // 
            // cd_cidade
            // 
            this.cd_cidade.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cidade.Location = new System.Drawing.Point(12, 66);
            this.cd_cidade.Name = "cd_cidade";
            this.cd_cidade.NM_Alias = "";
            this.cd_cidade.NM_Campo = "cd_cidade";
            this.cd_cidade.NM_CampoBusca = "cd_cidade";
            this.cd_cidade.NM_Param = "@P_DS_PDV";
            this.cd_cidade.QTD_Zero = 0;
            this.cd_cidade.Size = new System.Drawing.Size(58, 20);
            this.cd_cidade.ST_AutoInc = false;
            this.cd_cidade.ST_DisableAuto = false;
            this.cd_cidade.ST_Float = false;
            this.cd_cidade.ST_Gravar = true;
            this.cd_cidade.ST_Int = false;
            this.cd_cidade.ST_LimpaCampo = true;
            this.cd_cidade.ST_NotNull = false;
            this.cd_cidade.ST_PrimaryKey = false;
            this.cd_cidade.TabIndex = 0;
            this.cd_cidade.TextOld = null;
            this.cd_cidade.Leave += new System.EventHandler(this.cd_cidade_Leave);
            // 
            // bbCidade
            // 
            this.bbCidade.Image = ((System.Drawing.Image)(resources.GetObject("bbCidade.Image")));
            this.bbCidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbCidade.Location = new System.Drawing.Point(73, 66);
            this.bbCidade.Name = "bbCidade";
            this.bbCidade.Size = new System.Drawing.Size(28, 20);
            this.bbCidade.TabIndex = 1;
            this.bbCidade.UseVisualStyleBackColor = true;
            this.bbCidade.Click += new System.EventHandler(this.bbCidade_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Municipio Exec. Serviço";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total do orçamento";
            // 
            // total_orc_i
            // 
            this.total_orc_i.DecimalPlaces = 2;
            this.total_orc_i.Enabled = false;
            this.total_orc_i.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_orc_i.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.total_orc_i.Location = new System.Drawing.Point(303, 154);
            this.total_orc_i.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.total_orc_i.Name = "total_orc_i";
            this.total_orc_i.NM_Alias = "";
            this.total_orc_i.NM_Campo = "";
            this.total_orc_i.NM_Param = "";
            this.total_orc_i.Operador = "";
            this.total_orc_i.Size = new System.Drawing.Size(93, 24);
            this.total_orc_i.ST_AutoInc = false;
            this.total_orc_i.ST_DisableAuto = false;
            this.total_orc_i.ST_Gravar = false;
            this.total_orc_i.ST_LimparCampo = true;
            this.total_orc_i.ST_NotNull = false;
            this.total_orc_i.ST_PrimaryKey = false;
            this.total_orc_i.TabIndex = 6;
            this.total_orc_i.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.total_orc_i.ThousandsSeparator = true;
            this.total_orc_i.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "% do valor";
            // 
            // vl_execucao_pc
            // 
            this.vl_execucao_pc.DecimalPlaces = 2;
            this.vl_execucao_pc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_execucao_pc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_execucao_pc.Location = new System.Drawing.Point(216, 135);
            this.vl_execucao_pc.Name = "vl_execucao_pc";
            this.vl_execucao_pc.NM_Alias = "";
            this.vl_execucao_pc.NM_Campo = "";
            this.vl_execucao_pc.NM_Param = "";
            this.vl_execucao_pc.Operador = "";
            this.vl_execucao_pc.Size = new System.Drawing.Size(81, 24);
            this.vl_execucao_pc.ST_AutoInc = false;
            this.vl_execucao_pc.ST_DisableAuto = false;
            this.vl_execucao_pc.ST_Gravar = false;
            this.vl_execucao_pc.ST_LimparCampo = true;
            this.vl_execucao_pc.ST_NotNull = false;
            this.vl_execucao_pc.ST_PrimaryKey = false;
            this.vl_execucao_pc.TabIndex = 4;
            this.vl_execucao_pc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.vl_execucao_pc.ThousandsSeparator = true;
            this.vl_execucao_pc.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_execucao_pc.ValueChanged += new System.EventHandler(this.vl_execucao_pc_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Vl. Execução";
            // 
            // valor_execucao
            // 
            this.valor_execucao.DecimalPlaces = 2;
            this.valor_execucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valor_execucao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_execucao.Location = new System.Drawing.Point(117, 154);
            this.valor_execucao.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.valor_execucao.Name = "valor_execucao";
            this.valor_execucao.NM_Alias = "";
            this.valor_execucao.NM_Campo = "";
            this.valor_execucao.NM_Param = "";
            this.valor_execucao.Operador = "";
            this.valor_execucao.Size = new System.Drawing.Size(93, 24);
            this.valor_execucao.ST_AutoInc = false;
            this.valor_execucao.ST_DisableAuto = false;
            this.valor_execucao.ST_Gravar = false;
            this.valor_execucao.ST_LimparCampo = true;
            this.valor_execucao.ST_NotNull = false;
            this.valor_execucao.ST_PrimaryKey = false;
            this.valor_execucao.TabIndex = 5;
            this.valor_execucao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valor_execucao.ThousandsSeparator = true;
            this.valor_execucao.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_execucao.ValueChanged += new System.EventHandler(this.valor_execucao_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Saldo a faturar";
            // 
            // Saldo_Faturar_i
            // 
            this.Saldo_Faturar_i.DecimalPlaces = 2;
            this.Saldo_Faturar_i.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Saldo_Faturar_i.Location = new System.Drawing.Point(12, 154);
            this.Saldo_Faturar_i.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.Saldo_Faturar_i.Name = "Saldo_Faturar_i";
            this.Saldo_Faturar_i.NM_Alias = "";
            this.Saldo_Faturar_i.NM_Campo = "";
            this.Saldo_Faturar_i.NM_Param = "";
            this.Saldo_Faturar_i.Operador = "";
            this.Saldo_Faturar_i.ReadOnly = true;
            this.Saldo_Faturar_i.Size = new System.Drawing.Size(99, 20);
            this.Saldo_Faturar_i.ST_AutoInc = false;
            this.Saldo_Faturar_i.ST_DisableAuto = false;
            this.Saldo_Faturar_i.ST_Gravar = false;
            this.Saldo_Faturar_i.ST_LimparCampo = true;
            this.Saldo_Faturar_i.ST_NotNull = false;
            this.Saldo_Faturar_i.ST_PrimaryKey = false;
            this.Saldo_Faturar_i.TabIndex = 12;
            this.Saldo_Faturar_i.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Saldo_Faturar_i.ThousandsSeparator = true;
            this.Saldo_Faturar_i.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total do orçamento nota";
            // 
            // tot_orc
            // 
            this.tot_orc.DecimalPlaces = 2;
            this.tot_orc.Enabled = false;
            this.tot_orc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_orc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_orc.Location = new System.Drawing.Point(303, 107);
            this.tot_orc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_orc.Name = "tot_orc";
            this.tot_orc.NM_Alias = "";
            this.tot_orc.NM_Campo = "";
            this.tot_orc.NM_Param = "";
            this.tot_orc.Operador = "";
            this.tot_orc.Size = new System.Drawing.Size(93, 24);
            this.tot_orc.ST_AutoInc = false;
            this.tot_orc.ST_DisableAuto = false;
            this.tot_orc.ST_Gravar = false;
            this.tot_orc.ST_LimparCampo = true;
            this.tot_orc.ST_NotNull = false;
            this.tot_orc.ST_PrimaryKey = false;
            this.tot_orc.TabIndex = 3;
            this.tot_orc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tot_orc.ThousandsSeparator = true;
            this.tot_orc.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Valor nota";
            // 
            // valor_nota
            // 
            this.valor_nota.DecimalPlaces = 2;
            this.valor_nota.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valor_nota.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_nota.Location = new System.Drawing.Point(117, 107);
            this.valor_nota.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.valor_nota.Name = "valor_nota";
            this.valor_nota.NM_Alias = "";
            this.valor_nota.NM_Campo = "";
            this.valor_nota.NM_Param = "";
            this.valor_nota.Operador = "";
            this.valor_nota.Size = new System.Drawing.Size(93, 24);
            this.valor_nota.ST_AutoInc = false;
            this.valor_nota.ST_DisableAuto = false;
            this.valor_nota.ST_Gravar = false;
            this.valor_nota.ST_LimparCampo = true;
            this.valor_nota.ST_NotNull = false;
            this.valor_nota.ST_PrimaryKey = false;
            this.valor_nota.TabIndex = 2;
            this.valor_nota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valor_nota.ThousandsSeparator = true;
            this.valor_nota.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valor_nota.ValueChanged += new System.EventHandler(this.valor_nota_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saldo a faturar nota";
            // 
            // saldo_faturar
            // 
            this.saldo_faturar.DecimalPlaces = 2;
            this.saldo_faturar.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.saldo_faturar.Location = new System.Drawing.Point(12, 107);
            this.saldo_faturar.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.saldo_faturar.Name = "saldo_faturar";
            this.saldo_faturar.NM_Alias = "";
            this.saldo_faturar.NM_Campo = "";
            this.saldo_faturar.NM_Param = "";
            this.saldo_faturar.Operador = "";
            this.saldo_faturar.ReadOnly = true;
            this.saldo_faturar.Size = new System.Drawing.Size(99, 20);
            this.saldo_faturar.ST_AutoInc = false;
            this.saldo_faturar.ST_DisableAuto = false;
            this.saldo_faturar.ST_Gravar = false;
            this.saldo_faturar.ST_LimparCampo = true;
            this.saldo_faturar.ST_NotNull = false;
            this.saldo_faturar.ST_PrimaryKey = false;
            this.saldo_faturar.TabIndex = 3;
            this.saldo_faturar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.saldo_faturar.ThousandsSeparator = true;
            this.saldo_faturar.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Location = new System.Drawing.Point(76, 27);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.ReadOnly = true;
            this.editDefault2.Size = new System.Drawing.Size(374, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 2;
            this.editDefault2.TextOld = null;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(12, 27);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ReadOnly = true;
            this.editDefault1.Size = new System.Drawing.Size(58, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            this.editDefault1.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // bsOrcamento
            // 
            this.bsOrcamento.DataSource = typeof(CamadaDados.Empreendimento.TList_Orcamento);
            // 
            // FServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 224);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FServico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valor Nota Fiscal";
            this.Load += new System.EventHandler(this.FServico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FServico_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_orc_i)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_execucao_pc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_execucao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saldo_Faturar_i)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_orc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valor_nota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saldo_faturar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOrcamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.BindingSource bsFichaTec;
        private Componentes.EditDefault editDefault2;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat saldo_faturar;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat valor_nota;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat tot_orc;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat total_orc_i;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat vl_execucao_pc;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat valor_execucao;
        private System.Windows.Forms.Label label9;
        private Componentes.EditFloat Saldo_Faturar_i;
        private System.Windows.Forms.BindingSource bsOrcamento;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault dsCidade;
        private Componentes.EditDefault cd_cidade;
        private System.Windows.Forms.Button bbCidade;
    }
}