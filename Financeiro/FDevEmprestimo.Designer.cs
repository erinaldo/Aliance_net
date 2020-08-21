namespace Financeiro
{
    partial class TFDevEmprestimo
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDevEmprestimo));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.vl_saldo = new Componentes.EditFloat(this.components);
            this.bsEmprestimo = new System.Windows.Forms.BindingSource(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.bb_contager_dev = new System.Windows.Forms.Button();
            this.ds_contager_dev = new Componentes.EditDefault(this.components);
            this.cd_contager_dev = new Componentes.EditDefault(this.components);
            this.dt_devolucao = new System.Windows.Forms.DateTimePicker();
            this.vl_devolver = new Componentes.EditFloat(this.components);
            this.vl_emprestimo = new Componentes.EditFloat(this.components);
            this.tp_emprestimo = new Componentes.ComboBoxDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.cd_contager = new Componentes.EditDefault(this.components);
            this.ds_contager = new Componentes.EditDefault(this.components);
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).BeginInit();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_devolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_emprestimo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(416, 61);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 13);
            label1.TabIndex = 192;
            label1.Text = "Vl. Atual:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(237, 61);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(76, 13);
            label9.TabIndex = 190;
            label9.Text = "Vl. Emprestimo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(6, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 13);
            label3.TabIndex = 194;
            label3.Text = "Dt. Devolução";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(124, 99);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 13);
            label2.TabIndex = 192;
            label2.Text = "Vl. Devolver";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(3, 61);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 13);
            label5.TabIndex = 189;
            label5.Text = "Tipo Emprestimo:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(40, 9);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(51, 13);
            label27.TabIndex = 177;
            label27.Text = "Empresa:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(8, 35);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(83, 13);
            label8.TabIndex = 185;
            label8.Text = "Conta Gerencial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(6, 21);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(47, 13);
            label4.TabIndex = 201;
            label4.Text = "Portador";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(6, 60);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(83, 13);
            label6.TabIndex = 199;
            label6.Text = "Conta Gerencial";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(584, 43);
            this.barraMenu.TabIndex = 12;
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.vl_saldo);
            this.pDados.Controls.Add(label9);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.vl_emprestimo);
            this.pDados.Controls.Add(this.tp_emprestimo);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(label27);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.cd_contager);
            this.pDados.Controls.Add(this.ds_contager);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(584, 234);
            this.pDados.TabIndex = 13;
            // 
            // vl_saldo
            // 
            this.vl_saldo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Vl_atual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_saldo.DecimalPlaces = 2;
            this.vl_saldo.Enabled = false;
            this.vl_saldo.Location = new System.Drawing.Point(471, 59);
            this.vl_saldo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_saldo.Name = "vl_saldo";
            this.vl_saldo.NM_Alias = "";
            this.vl_saldo.NM_Campo = "";
            this.vl_saldo.NM_Param = "";
            this.vl_saldo.Operador = "";
            this.vl_saldo.Size = new System.Drawing.Size(105, 20);
            this.vl_saldo.ST_AutoInc = false;
            this.vl_saldo.ST_DisableAuto = false;
            this.vl_saldo.ST_Gravar = false;
            this.vl_saldo.ST_LimparCampo = true;
            this.vl_saldo.ST_NotNull = true;
            this.vl_saldo.ST_PrimaryKey = false;
            this.vl_saldo.TabIndex = 191;
            this.vl_saldo.ThousandsSeparator = true;
            // 
            // bsEmprestimo
            // 
            this.bsEmprestimo.DataSource = typeof(CamadaDados.Financeiro.Emprestimos.TList_Emprestimos);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.bb_portador);
            this.radioGroup1.Controls.Add(this.ds_portador);
            this.radioGroup1.Controls.Add(this.cd_portador);
            this.radioGroup1.Controls.Add(label4);
            this.radioGroup1.Controls.Add(this.bb_contager_dev);
            this.radioGroup1.Controls.Add(this.ds_contager_dev);
            this.radioGroup1.Controls.Add(this.cd_contager_dev);
            this.radioGroup1.Controls.Add(label6);
            this.radioGroup1.Controls.Add(label3);
            this.radioGroup1.Controls.Add(this.dt_devolucao);
            this.radioGroup1.Controls.Add(label2);
            this.radioGroup1.Controls.Add(this.vl_devolver);
            this.radioGroup1.Location = new System.Drawing.Point(97, 85);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(479, 142);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Devolução";
            // 
            // bb_portador
            // 
            this.bb_portador.BackColor = System.Drawing.SystemColors.Control;
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(93, 37);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(28, 19);
            this.bb_portador.TabIndex = 1;
            this.bb_portador.UseVisualStyleBackColor = false;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_portador_dev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_portador.Location = new System.Drawing.Point(124, 37);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_EMPRESA";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(349, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 202;
            this.ds_portador.TextOld = null;
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.Color.White;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_portador_dev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_portador.Location = new System.Drawing.Point(9, 37);
            this.cd_portador.MaxLength = 4;
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_EMPRESA";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.Size = new System.Drawing.Size(82, 20);
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = true;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = true;
            this.cd_portador.ST_PrimaryKey = false;
            this.cd_portador.TabIndex = 0;
            this.cd_portador.TextOld = null;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // bb_contager_dev
            // 
            this.bb_contager_dev.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager_dev.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager_dev.Image")));
            this.bb_contager_dev.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contager_dev.Location = new System.Drawing.Point(93, 76);
            this.bb_contager_dev.Name = "bb_contager_dev";
            this.bb_contager_dev.Size = new System.Drawing.Size(28, 19);
            this.bb_contager_dev.TabIndex = 3;
            this.bb_contager_dev.UseVisualStyleBackColor = false;
            this.bb_contager_dev.Click += new System.EventHandler(this.bb_contager_dev_Click);
            // 
            // ds_contager_dev
            // 
            this.ds_contager_dev.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager_dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager_dev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager_dev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_contager_dev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager_dev.Enabled = false;
            this.ds_contager_dev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contager_dev.Location = new System.Drawing.Point(124, 76);
            this.ds_contager_dev.Name = "ds_contager_dev";
            this.ds_contager_dev.NM_Alias = "";
            this.ds_contager_dev.NM_Campo = "ds_contager";
            this.ds_contager_dev.NM_CampoBusca = "ds_contager";
            this.ds_contager_dev.NM_Param = "@P_NM_EMPRESA";
            this.ds_contager_dev.QTD_Zero = 0;
            this.ds_contager_dev.Size = new System.Drawing.Size(349, 20);
            this.ds_contager_dev.ST_AutoInc = false;
            this.ds_contager_dev.ST_DisableAuto = false;
            this.ds_contager_dev.ST_Float = false;
            this.ds_contager_dev.ST_Gravar = false;
            this.ds_contager_dev.ST_Int = false;
            this.ds_contager_dev.ST_LimpaCampo = true;
            this.ds_contager_dev.ST_NotNull = false;
            this.ds_contager_dev.ST_PrimaryKey = false;
            this.ds_contager_dev.TabIndex = 200;
            this.ds_contager_dev.TextOld = null;
            // 
            // cd_contager_dev
            // 
            this.cd_contager_dev.BackColor = System.Drawing.Color.White;
            this.cd_contager_dev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager_dev.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager_dev.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_contager_dev", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager_dev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contager_dev.Location = new System.Drawing.Point(9, 76);
            this.cd_contager_dev.MaxLength = 4;
            this.cd_contager_dev.Name = "cd_contager_dev";
            this.cd_contager_dev.NM_Alias = "";
            this.cd_contager_dev.NM_Campo = "cd_contager";
            this.cd_contager_dev.NM_CampoBusca = "cd_contager";
            this.cd_contager_dev.NM_Param = "@P_CD_EMPRESA";
            this.cd_contager_dev.QTD_Zero = 0;
            this.cd_contager_dev.Size = new System.Drawing.Size(82, 20);
            this.cd_contager_dev.ST_AutoInc = false;
            this.cd_contager_dev.ST_DisableAuto = false;
            this.cd_contager_dev.ST_Float = false;
            this.cd_contager_dev.ST_Gravar = true;
            this.cd_contager_dev.ST_Int = true;
            this.cd_contager_dev.ST_LimpaCampo = true;
            this.cd_contager_dev.ST_NotNull = true;
            this.cd_contager_dev.ST_PrimaryKey = false;
            this.cd_contager_dev.TabIndex = 2;
            this.cd_contager_dev.TextOld = null;
            this.cd_contager_dev.Leave += new System.EventHandler(this.cd_contager_dev_Leave);
            // 
            // dt_devolucao
            // 
            this.dt_devolucao.CustomFormat = "";
            this.dt_devolucao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Dt_devolucao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_devolucao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_devolucao.Location = new System.Drawing.Point(9, 115);
            this.dt_devolucao.Name = "dt_devolucao";
            this.dt_devolucao.Size = new System.Drawing.Size(112, 20);
            this.dt_devolucao.TabIndex = 6;
            // 
            // vl_devolver
            // 
            this.vl_devolver.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Vl_devolver", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_devolver.DecimalPlaces = 2;
            this.vl_devolver.Location = new System.Drawing.Point(127, 115);
            this.vl_devolver.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_devolver.Name = "vl_devolver";
            this.vl_devolver.NM_Alias = "";
            this.vl_devolver.NM_Campo = "";
            this.vl_devolver.NM_Param = "";
            this.vl_devolver.Operador = "";
            this.vl_devolver.Size = new System.Drawing.Size(91, 20);
            this.vl_devolver.ST_AutoInc = false;
            this.vl_devolver.ST_DisableAuto = false;
            this.vl_devolver.ST_Gravar = false;
            this.vl_devolver.ST_LimparCampo = true;
            this.vl_devolver.ST_NotNull = true;
            this.vl_devolver.ST_PrimaryKey = false;
            this.vl_devolver.TabIndex = 7;
            this.vl_devolver.ThousandsSeparator = true;
            this.vl_devolver.Leave += new System.EventHandler(this.vl_devolver_Leave);
            // 
            // vl_emprestimo
            // 
            this.vl_emprestimo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Vl_emprestimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_emprestimo.DecimalPlaces = 2;
            this.vl_emprestimo.Enabled = false;
            this.vl_emprestimo.Location = new System.Drawing.Point(319, 59);
            this.vl_emprestimo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_emprestimo.Name = "vl_emprestimo";
            this.vl_emprestimo.NM_Alias = "";
            this.vl_emprestimo.NM_Campo = "";
            this.vl_emprestimo.NM_Param = "";
            this.vl_emprestimo.Operador = "";
            this.vl_emprestimo.Size = new System.Drawing.Size(91, 20);
            this.vl_emprestimo.ST_AutoInc = false;
            this.vl_emprestimo.ST_DisableAuto = false;
            this.vl_emprestimo.ST_Gravar = false;
            this.vl_emprestimo.ST_LimparCampo = true;
            this.vl_emprestimo.ST_NotNull = true;
            this.vl_emprestimo.ST_PrimaryKey = false;
            this.vl_emprestimo.TabIndex = 4;
            this.vl_emprestimo.ThousandsSeparator = true;
            // 
            // tp_emprestimo
            // 
            this.tp_emprestimo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEmprestimo, "Tp_emprestimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_emprestimo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_emprestimo.Enabled = false;
            this.tp_emprestimo.FormattingEnabled = true;
            this.tp_emprestimo.Location = new System.Drawing.Point(97, 58);
            this.tp_emprestimo.Name = "tp_emprestimo";
            this.tp_emprestimo.NM_Alias = "";
            this.tp_emprestimo.NM_Campo = "";
            this.tp_emprestimo.NM_Param = "";
            this.tp_emprestimo.Size = new System.Drawing.Size(134, 21);
            this.tp_emprestimo.ST_Gravar = false;
            this.tp_emprestimo.ST_LimparCampo = true;
            this.tp_emprestimo.ST_NotNull = true;
            this.tp_emprestimo.TabIndex = 9;
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(185, 6);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "nm_empresa";
            this.NM_Empresa.NM_CampoBusca = "nm_empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(391, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 178;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(97, 6);
            this.CD_Empresa.MaxLength = 4;
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "cd_empresa";
            this.CD_Empresa.NM_CampoBusca = "cd_empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(82, 20);
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
            // cd_contager
            // 
            this.cd_contager.BackColor = System.Drawing.Color.White;
            this.cd_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Enabled = false;
            this.cd_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contager.Location = new System.Drawing.Point(97, 32);
            this.cd_contager.MaxLength = 4;
            this.cd_contager.Name = "cd_contager";
            this.cd_contager.NM_Alias = "";
            this.cd_contager.NM_Campo = "cd_contager";
            this.cd_contager.NM_CampoBusca = "cd_contager";
            this.cd_contager.NM_Param = "@P_CD_EMPRESA";
            this.cd_contager.QTD_Zero = 0;
            this.cd_contager.Size = new System.Drawing.Size(82, 20);
            this.cd_contager.ST_AutoInc = false;
            this.cd_contager.ST_DisableAuto = false;
            this.cd_contager.ST_Float = false;
            this.cd_contager.ST_Gravar = true;
            this.cd_contager.ST_Int = true;
            this.cd_contager.ST_LimpaCampo = true;
            this.cd_contager.ST_NotNull = true;
            this.cd_contager.ST_PrimaryKey = false;
            this.cd_contager.TabIndex = 0;
            this.cd_contager.TextOld = null;
            // 
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager.Enabled = false;
            this.ds_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contager.Location = new System.Drawing.Point(185, 32);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_NM_EMPRESA";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(391, 20);
            this.ds_contager.ST_AutoInc = false;
            this.ds_contager.ST_DisableAuto = false;
            this.ds_contager.ST_Float = false;
            this.ds_contager.ST_Gravar = false;
            this.ds_contager.ST_Int = false;
            this.ds_contager.ST_LimpaCampo = true;
            this.ds_contager.ST_NotNull = false;
            this.ds_contager.ST_PrimaryKey = false;
            this.ds_contager.TabIndex = 186;
            this.ds_contager.TextOld = null;
            // 
            // TFDevEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 277);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDevEmprestimo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução Emprestimo Recebido/Concedido";
            this.Load += new System.EventHandler(this.TFDevEmprestimo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDevEmprestimo_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_saldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_devolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_emprestimo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsEmprestimo;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditFloat vl_emprestimo;
        private Componentes.ComboBoxDefault tp_emprestimo;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault cd_contager;
        private Componentes.EditDefault ds_contager;
        private Componentes.EditFloat vl_saldo;
        private Componentes.EditFloat vl_devolver;
        private System.Windows.Forms.DateTimePicker dt_devolucao;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault ds_portador;
        private Componentes.EditDefault cd_portador;
        private System.Windows.Forms.Button bb_contager_dev;
        private Componentes.EditDefault ds_contager_dev;
        private Componentes.EditDefault cd_contager_dev;
    }
}