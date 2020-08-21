namespace Faturamento
{
    partial class TFIntervencaoTecECF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFIntervencaoTecECF));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.bsIntervencao = new System.Windows.Forms.BindingSource(this.components);
            this.editDefault4 = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.dt_intervencao = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.nr_cro = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.vl_acumulado_gt = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.nr_ose = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.motivo_intervencao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_equipamento = new Componentes.EditDefault(this.components);
            this.bb_equipamento = new System.Windows.Forms.Button();
            this.id_equipamento = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_cro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_acumulado_gt)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(755, 43);
            this.barraMenu.TabIndex = 6;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(105, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.checkBoxDefault1);
            this.pDados.Controls.Add(this.editDefault4);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.editDefault3);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.dt_intervencao);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.nr_cro);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.vl_acumulado_gt);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.nr_ose);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.motivo_intervencao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_equipamento);
            this.pDados.Controls.Add(this.bb_equipamento);
            this.pDados.Controls.Add(this.id_equipamento);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(755, 139);
            this.pDados.TabIndex = 7;
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsIntervencao, "St_perdadadosbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Location = new System.Drawing.Point(654, 57);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(88, 17);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 7;
            this.checkBoxDefault1.Text = "Perda Dados";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // bsIntervencao
            // 
            this.bsIntervencao.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_IntervencaoTec);
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Memoria_fiscal_nova", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault4.Location = new System.Drawing.Point(89, 107);
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "id_equipamento";
            this.editDefault4.NM_CampoBusca = "id_equipamento";
            this.editDefault4.NM_Param = "@P_CD_EMPRESA";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(653, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = true;
            this.editDefault4.ST_Int = false;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = false;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Memoria Nova:";
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Memoria_fiscal_ant", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault3.Location = new System.Drawing.Point(89, 81);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "id_equipamento";
            this.editDefault3.NM_CampoBusca = "id_equipamento";
            this.editDefault3.NM_Param = "@P_CD_EMPRESA";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(653, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = true;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 72;
            this.label7.Text = "Memoria Ant.:";
            // 
            // dt_intervencao
            // 
            this.dt_intervencao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_intervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Dt_intervencaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_intervencao.Location = new System.Drawing.Point(576, 55);
            this.dt_intervencao.Mask = "00/00/0000";
            this.dt_intervencao.Name = "dt_intervencao";
            this.dt_intervencao.NM_Alias = "";
            this.dt_intervencao.NM_Campo = "";
            this.dt_intervencao.NM_CampoBusca = "";
            this.dt_intervencao.NM_Param = "";
            this.dt_intervencao.Operador = "";
            this.dt_intervencao.Size = new System.Drawing.Size(69, 20);
            this.dt_intervencao.ST_Gravar = false;
            this.dt_intervencao.ST_LimpaCampo = true;
            this.dt_intervencao.ST_NotNull = false;
            this.dt_intervencao.ST_PrimaryKey = false;
            this.dt_intervencao.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(487, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Dt. Intervenção:";
            // 
            // nr_cro
            // 
            this.nr_cro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsIntervencao, "Nr_cro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cro.Location = new System.Drawing.Point(429, 55);
            this.nr_cro.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nr_cro.Name = "nr_cro";
            this.nr_cro.NM_Alias = "";
            this.nr_cro.NM_Campo = "";
            this.nr_cro.NM_Param = "";
            this.nr_cro.Operador = "";
            this.nr_cro.Size = new System.Drawing.Size(52, 20);
            this.nr_cro.ST_AutoInc = false;
            this.nr_cro.ST_DisableAuto = false;
            this.nr_cro.ST_Gravar = false;
            this.nr_cro.ST_LimparCampo = true;
            this.nr_cro.ST_NotNull = false;
            this.nr_cro.ST_PrimaryKey = false;
            this.nr_cro.TabIndex = 5;
            this.nr_cro.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Nº CRO:";
            // 
            // vl_acumulado_gt
            // 
            this.vl_acumulado_gt.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsIntervencao, "Vl_acumulado_GT", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_acumulado_gt.DecimalPlaces = 2;
            this.vl_acumulado_gt.Location = new System.Drawing.Point(276, 55);
            this.vl_acumulado_gt.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_acumulado_gt.Name = "vl_acumulado_gt";
            this.vl_acumulado_gt.NM_Alias = "";
            this.vl_acumulado_gt.NM_Campo = "";
            this.vl_acumulado_gt.NM_Param = "";
            this.vl_acumulado_gt.Operador = "";
            this.vl_acumulado_gt.Size = new System.Drawing.Size(93, 20);
            this.vl_acumulado_gt.ST_AutoInc = false;
            this.vl_acumulado_gt.ST_DisableAuto = false;
            this.vl_acumulado_gt.ST_Gravar = false;
            this.vl_acumulado_gt.ST_LimparCampo = true;
            this.vl_acumulado_gt.ST_NotNull = false;
            this.vl_acumulado_gt.ST_PrimaryKey = false;
            this.vl_acumulado_gt.TabIndex = 4;
            this.vl_acumulado_gt.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Vl. Acumulado GT:";
            // 
            // nr_ose
            // 
            this.nr_ose.BackColor = System.Drawing.SystemColors.Window;
            this.nr_ose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_ose.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_ose.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Nr_ose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_ose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nr_ose.Location = new System.Drawing.Point(89, 55);
            this.nr_ose.Name = "nr_ose";
            this.nr_ose.NM_Alias = "";
            this.nr_ose.NM_Campo = "id_equipamento";
            this.nr_ose.NM_CampoBusca = "id_equipamento";
            this.nr_ose.NM_Param = "@P_CD_EMPRESA";
            this.nr_ose.QTD_Zero = 0;
            this.nr_ose.Size = new System.Drawing.Size(79, 20);
            this.nr_ose.ST_AutoInc = false;
            this.nr_ose.ST_DisableAuto = false;
            this.nr_ose.ST_Float = false;
            this.nr_ose.ST_Gravar = true;
            this.nr_ose.ST_Int = false;
            this.nr_ose.ST_LimpaCampo = true;
            this.nr_ose.ST_NotNull = false;
            this.nr_ose.ST_PrimaryKey = false;
            this.nr_ose.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Nº OSE:";
            // 
            // motivo_intervencao
            // 
            this.motivo_intervencao.BackColor = System.Drawing.SystemColors.Window;
            this.motivo_intervencao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.motivo_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.motivo_intervencao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Motivo_intervencao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.motivo_intervencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.motivo_intervencao.Location = new System.Drawing.Point(89, 29);
            this.motivo_intervencao.Name = "motivo_intervencao";
            this.motivo_intervencao.NM_Alias = "";
            this.motivo_intervencao.NM_Campo = "motivo_intervencao";
            this.motivo_intervencao.NM_CampoBusca = "motivo_intervencao";
            this.motivo_intervencao.NM_Param = "@P_CD_EMPRESA";
            this.motivo_intervencao.QTD_Zero = 0;
            this.motivo_intervencao.Size = new System.Drawing.Size(653, 20);
            this.motivo_intervencao.ST_AutoInc = false;
            this.motivo_intervencao.ST_DisableAuto = false;
            this.motivo_intervencao.ST_Float = false;
            this.motivo_intervencao.ST_Gravar = true;
            this.motivo_intervencao.ST_Int = false;
            this.motivo_intervencao.ST_LimpaCampo = true;
            this.motivo_intervencao.ST_NotNull = true;
            this.motivo_intervencao.ST_PrimaryKey = false;
            this.motivo_intervencao.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Motivo:";
            // 
            // ds_equipamento
            // 
            this.ds_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Ds_equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_equipamento.Enabled = false;
            this.ds_equipamento.Location = new System.Drawing.Point(174, 3);
            this.ds_equipamento.Name = "ds_equipamento";
            this.ds_equipamento.NM_Alias = "";
            this.ds_equipamento.NM_Campo = "ds_equipamento";
            this.ds_equipamento.NM_CampoBusca = "ds_equipamento";
            this.ds_equipamento.NM_Param = "@P_DS_EQUIPAMENTO";
            this.ds_equipamento.QTD_Zero = 0;
            this.ds_equipamento.Size = new System.Drawing.Size(568, 20);
            this.ds_equipamento.ST_AutoInc = false;
            this.ds_equipamento.ST_DisableAuto = false;
            this.ds_equipamento.ST_Float = false;
            this.ds_equipamento.ST_Gravar = false;
            this.ds_equipamento.ST_Int = false;
            this.ds_equipamento.ST_LimpaCampo = true;
            this.ds_equipamento.ST_NotNull = false;
            this.ds_equipamento.ST_PrimaryKey = false;
            this.ds_equipamento.TabIndex = 61;
            // 
            // bb_equipamento
            // 
            this.bb_equipamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_equipamento.Image")));
            this.bb_equipamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_equipamento.Location = new System.Drawing.Point(140, 3);
            this.bb_equipamento.Name = "bb_equipamento";
            this.bb_equipamento.Size = new System.Drawing.Size(28, 20);
            this.bb_equipamento.TabIndex = 1;
            this.bb_equipamento.UseVisualStyleBackColor = true;
            this.bb_equipamento.Click += new System.EventHandler(this.bb_equipamento_Click);
            // 
            // id_equipamento
            // 
            this.id_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.id_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsIntervencao, "Id_equipamentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_equipamento.Location = new System.Drawing.Point(89, 3);
            this.id_equipamento.Name = "id_equipamento";
            this.id_equipamento.NM_Alias = "";
            this.id_equipamento.NM_Campo = "id_equipamento";
            this.id_equipamento.NM_CampoBusca = "id_equipamento";
            this.id_equipamento.NM_Param = "@P_CD_EMPRESA";
            this.id_equipamento.QTD_Zero = 0;
            this.id_equipamento.Size = new System.Drawing.Size(48, 20);
            this.id_equipamento.ST_AutoInc = false;
            this.id_equipamento.ST_DisableAuto = false;
            this.id_equipamento.ST_Float = false;
            this.id_equipamento.ST_Gravar = true;
            this.id_equipamento.ST_Int = true;
            this.id_equipamento.ST_LimpaCampo = true;
            this.id_equipamento.ST_NotNull = true;
            this.id_equipamento.ST_PrimaryKey = false;
            this.id_equipamento.TabIndex = 0;
            this.id_equipamento.Leave += new System.EventHandler(this.id_equipamento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Equipamento:";
            // 
            // TFIntervencaoTecECF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 182);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFIntervencaoTecECF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intervenção Tecnica ECF";
            this.Load += new System.EventHandler(this.TFIntervencaoTecECF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFIntervencaoTecECF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_cro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_acumulado_gt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault nr_ose;
        private System.Windows.Forms.BindingSource bsIntervencao;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault motivo_intervencao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_equipamento;
        private System.Windows.Forms.Button bb_equipamento;
        private Componentes.EditDefault id_equipamento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault editDefault3;
        private System.Windows.Forms.Label label7;
        private Componentes.EditData dt_intervencao;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat nr_cro;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat vl_acumulado_gt;
        private System.Windows.Forms.Label label4;
        private Componentes.CheckBoxDefault checkBoxDefault1;
    }
}