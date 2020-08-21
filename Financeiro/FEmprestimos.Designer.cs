namespace Financeiro
{
    partial class TFEmprestimos
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
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEmprestimos));
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label10;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.bsEmprestimo = new System.Windows.Forms.BindingSource(this.components);
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.vl_emprestimo = new Componentes.EditFloat(this.components);
            this.bb_contager = new System.Windows.Forms.Button();
            this.ds_contager = new Componentes.EditDefault(this.components);
            this.cd_contager = new Componentes.EditDefault(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.tp_emprestimo = new Componentes.ComboBoxDefault(this.components);
            this.dt_emprestimo = new Componentes.EditData(this.components);
            this.bb_endereco = new System.Windows.Forms.Button();
            this.CD_Endereco = new Componentes.EditDefault(this.components);
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.nm_clifor = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.bb_juro = new System.Windows.Forms.Button();
            this.cd_juro = new Componentes.EditDefault(this.components);
            this.ds_juro = new Componentes.EditDefault(this.components);
            this.pc_juro = new Componentes.EditFloat(this.components);
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_emprestimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_juro)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(6, 94);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(88, 13);
            label9.TabIndex = 190;
            label9.Text = "Valor Emprestimo";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(6, 55);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(83, 13);
            label8.TabIndex = 185;
            label8.Text = "Conta Gerencial";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(23, 137);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 13);
            label6.TabIndex = 191;
            label6.Text = "Observação:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(176, 86);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 13);
            label5.TabIndex = 189;
            label5.Text = "Tipo Emprestimo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(10, 86);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(81, 13);
            label3.TabIndex = 187;
            label3.Text = "Dt. Emprestimo:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(35, 60);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(56, 13);
            label4.TabIndex = 182;
            label4.Text = "Endereço:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(58, 35);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 13);
            label1.TabIndex = 180;
            label1.Text = "Clifor:";
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(6, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 13);
            label2.TabIndex = 193;
            label2.Text = "Portador";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(602, 43);
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.pc_juro);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.bb_juro);
            this.pDados.Controls.Add(this.cd_juro);
            this.pDados.Controls.Add(this.ds_juro);
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.tp_emprestimo);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.dt_emprestimo);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(label4);
            this.pDados.Controls.Add(this.bb_endereco);
            this.pDados.Controls.Add(this.CD_Endereco);
            this.pDados.Controls.Add(this.DS_Endereco);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.bb_clifor);
            this.pDados.Controls.Add(this.cd_clifor);
            this.pDados.Controls.Add(this.nm_clifor);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(label27);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(602, 355);
            this.pDados.TabIndex = 12;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.bb_portador);
            this.radioGroup1.Controls.Add(this.ds_portador);
            this.radioGroup1.Controls.Add(this.cd_portador);
            this.radioGroup1.Controls.Add(label2);
            this.radioGroup1.Controls.Add(label9);
            this.radioGroup1.Controls.Add(this.vl_emprestimo);
            this.radioGroup1.Controls.Add(this.bb_contager);
            this.radioGroup1.Controls.Add(this.ds_contager);
            this.radioGroup1.Controls.Add(this.cd_contager);
            this.radioGroup1.Controls.Add(label8);
            this.radioGroup1.Location = new System.Drawing.Point(97, 208);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(496, 137);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 11;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Financeiro";
            // 
            // bb_portador
            // 
            this.bb_portador.BackColor = System.Drawing.SystemColors.Control;
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_portador.Location = new System.Drawing.Point(93, 32);
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
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Enabled = false;
            this.ds_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_portador.Location = new System.Drawing.Point(124, 32);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_NM_EMPRESA";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(366, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 194;
            this.ds_portador.TextOld = null;
            // 
            // bsEmprestimo
            // 
            this.bsEmprestimo.DataSource = typeof(CamadaDados.Financeiro.Emprestimos.TList_Emprestimos);
            // 
            // cd_portador
            // 
            this.cd_portador.BackColor = System.Drawing.Color.White;
            this.cd_portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_portador.Location = new System.Drawing.Point(9, 32);
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
            // vl_emprestimo
            // 
            this.vl_emprestimo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Vl_emprestimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_emprestimo.DecimalPlaces = 2;
            this.vl_emprestimo.Location = new System.Drawing.Point(9, 110);
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
            this.vl_emprestimo.Size = new System.Drawing.Size(120, 20);
            this.vl_emprestimo.ST_AutoInc = false;
            this.vl_emprestimo.ST_DisableAuto = false;
            this.vl_emprestimo.ST_Gravar = false;
            this.vl_emprestimo.ST_LimparCampo = true;
            this.vl_emprestimo.ST_NotNull = true;
            this.vl_emprestimo.ST_PrimaryKey = false;
            this.vl_emprestimo.TabIndex = 6;
            this.vl_emprestimo.ThousandsSeparator = true;
            // 
            // bb_contager
            // 
            this.bb_contager.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contager.Image = ((System.Drawing.Image)(resources.GetObject("bb_contager.Image")));
            this.bb_contager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contager.Location = new System.Drawing.Point(93, 71);
            this.bb_contager.Name = "bb_contager";
            this.bb_contager.Size = new System.Drawing.Size(28, 19);
            this.bb_contager.TabIndex = 3;
            this.bb_contager.UseVisualStyleBackColor = false;
            this.bb_contager.Click += new System.EventHandler(this.bb_contager_Click);
            // 
            // ds_contager
            // 
            this.ds_contager.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contager.Enabled = false;
            this.ds_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contager.Location = new System.Drawing.Point(124, 71);
            this.ds_contager.Name = "ds_contager";
            this.ds_contager.NM_Alias = "";
            this.ds_contager.NM_Campo = "ds_contager";
            this.ds_contager.NM_CampoBusca = "ds_contager";
            this.ds_contager.NM_Param = "@P_NM_EMPRESA";
            this.ds_contager.QTD_Zero = 0;
            this.ds_contager.Size = new System.Drawing.Size(366, 20);
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
            // cd_contager
            // 
            this.cd_contager.BackColor = System.Drawing.Color.White;
            this.cd_contager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contager.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contager.Location = new System.Drawing.Point(9, 71);
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
            this.cd_contager.TabIndex = 2;
            this.cd_contager.TextOld = null;
            this.cd_contager.Leave += new System.EventHandler(this.cd_contager_Leave);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(97, 135);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(496, 67);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 10;
            this.ds_observacao.TextOld = null;
            // 
            // tp_emprestimo
            // 
            this.tp_emprestimo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsEmprestimo, "Tp_emprestimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_emprestimo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_emprestimo.FormattingEnabled = true;
            this.tp_emprestimo.Location = new System.Drawing.Point(270, 83);
            this.tp_emprestimo.Name = "tp_emprestimo";
            this.tp_emprestimo.NM_Alias = "";
            this.tp_emprestimo.NM_Campo = "";
            this.tp_emprestimo.NM_Param = "";
            this.tp_emprestimo.Size = new System.Drawing.Size(134, 21);
            this.tp_emprestimo.ST_Gravar = false;
            this.tp_emprestimo.ST_LimparCampo = true;
            this.tp_emprestimo.ST_NotNull = true;
            this.tp_emprestimo.TabIndex = 7;
            // 
            // dt_emprestimo
            // 
            this.dt_emprestimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_emprestimo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Dt_emprestimostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_emprestimo.Location = new System.Drawing.Point(97, 83);
            this.dt_emprestimo.Mask = "00/00/0000";
            this.dt_emprestimo.Name = "dt_emprestimo";
            this.dt_emprestimo.NM_Alias = "";
            this.dt_emprestimo.NM_Campo = "";
            this.dt_emprestimo.NM_CampoBusca = "";
            this.dt_emprestimo.NM_Param = "";
            this.dt_emprestimo.Operador = "";
            this.dt_emprestimo.Size = new System.Drawing.Size(73, 20);
            this.dt_emprestimo.ST_Gravar = false;
            this.dt_emprestimo.ST_LimpaCampo = true;
            this.dt_emprestimo.ST_NotNull = true;
            this.dt_emprestimo.ST_PrimaryKey = false;
            this.dt_emprestimo.TabIndex = 6;
            // 
            // bb_endereco
            // 
            this.bb_endereco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_endereco.Image = ((System.Drawing.Image)(resources.GetObject("bb_endereco.Image")));
            this.bb_endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endereco.Location = new System.Drawing.Point(181, 57);
            this.bb_endereco.Name = "bb_endereco";
            this.bb_endereco.Size = new System.Drawing.Size(28, 19);
            this.bb_endereco.TabIndex = 5;
            this.bb_endereco.UseVisualStyleBackColor = false;
            this.bb_endereco.Click += new System.EventHandler(this.bb_endereco_Click);
            // 
            // CD_Endereco
            // 
            this.CD_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Endereco.Location = new System.Drawing.Point(97, 57);
            this.CD_Endereco.MaxLength = 10;
            this.CD_Endereco.Name = "CD_Endereco";
            this.CD_Endereco.NM_Alias = "";
            this.CD_Endereco.NM_Campo = "cd_endereco";
            this.CD_Endereco.NM_CampoBusca = "cd_endereco";
            this.CD_Endereco.NM_Param = "";
            this.CD_Endereco.QTD_Zero = 0;
            this.CD_Endereco.Size = new System.Drawing.Size(82, 20);
            this.CD_Endereco.ST_AutoInc = false;
            this.CD_Endereco.ST_DisableAuto = false;
            this.CD_Endereco.ST_Float = false;
            this.CD_Endereco.ST_Gravar = true;
            this.CD_Endereco.ST_Int = false;
            this.CD_Endereco.ST_LimpaCampo = true;
            this.CD_Endereco.ST_NotNull = true;
            this.CD_Endereco.ST_PrimaryKey = false;
            this.CD_Endereco.TabIndex = 4;
            this.CD_Endereco.TextOld = null;
            this.CD_Endereco.Leave += new System.EventHandler(this.CD_Endereco_Leave);
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Endereco.Enabled = false;
            this.DS_Endereco.Location = new System.Drawing.Point(212, 57);
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "";
            this.DS_Endereco.NM_Campo = "ds_endereco";
            this.DS_Endereco.NM_CampoBusca = "ds_endereco";
            this.DS_Endereco.NM_Param = "@P_NM_CLIFOR";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.Size = new System.Drawing.Size(381, 20);
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = false;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = false;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TabIndex = 181;
            this.DS_Endereco.TextOld = null;
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(181, 32);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor.TabIndex = 3;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_clifor.Location = new System.Drawing.Point(97, 32);
            this.cd_clifor.MaxLength = 10;
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_CLIFOR";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(82, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 2;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // nm_clifor
            // 
            this.nm_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor.Enabled = false;
            this.nm_clifor.Location = new System.Drawing.Point(212, 32);
            this.nm_clifor.Name = "nm_clifor";
            this.nm_clifor.NM_Alias = "";
            this.nm_clifor.NM_Campo = "nm_clifor";
            this.nm_clifor.NM_CampoBusca = "nm_clifor";
            this.nm_clifor.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor.QTD_Zero = 0;
            this.nm_clifor.Size = new System.Drawing.Size(381, 20);
            this.nm_clifor.ST_AutoInc = false;
            this.nm_clifor.ST_DisableAuto = false;
            this.nm_clifor.ST_Float = false;
            this.nm_clifor.ST_Gravar = false;
            this.nm_clifor.ST_Int = false;
            this.nm_clifor.ST_LimpaCampo = true;
            this.nm_clifor.ST_NotNull = false;
            this.nm_clifor.ST_PrimaryKey = false;
            this.nm_clifor.TabIndex = 179;
            this.nm_clifor.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(181, 6);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(212, 6);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "nm_empresa";
            this.NM_Empresa.NM_CampoBusca = "nm_empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(381, 20);
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
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(61, 112);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(30, 13);
            label7.TabIndex = 195;
            label7.Text = "Juro:";
            // 
            // bb_juro
            // 
            this.bb_juro.BackColor = System.Drawing.SystemColors.Control;
            this.bb_juro.Image = ((System.Drawing.Image)(resources.GetObject("bb_juro.Image")));
            this.bb_juro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_juro.Location = new System.Drawing.Point(138, 109);
            this.bb_juro.Name = "bb_juro";
            this.bb_juro.Size = new System.Drawing.Size(28, 19);
            this.bb_juro.TabIndex = 9;
            this.bb_juro.UseVisualStyleBackColor = false;
            this.bb_juro.Click += new System.EventHandler(this.bb_juro_Click);
            // 
            // cd_juro
            // 
            this.cd_juro.BackColor = System.Drawing.SystemColors.Window;
            this.cd_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Cd_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_juro.Location = new System.Drawing.Point(97, 109);
            this.cd_juro.MaxLength = 10;
            this.cd_juro.Name = "cd_juro";
            this.cd_juro.NM_Alias = "";
            this.cd_juro.NM_Campo = "cd_juro";
            this.cd_juro.NM_CampoBusca = "cd_juro";
            this.cd_juro.NM_Param = "@P_CD_JURO";
            this.cd_juro.QTD_Zero = 0;
            this.cd_juro.Size = new System.Drawing.Size(38, 20);
            this.cd_juro.ST_AutoInc = false;
            this.cd_juro.ST_DisableAuto = false;
            this.cd_juro.ST_Float = false;
            this.cd_juro.ST_Gravar = true;
            this.cd_juro.ST_Int = false;
            this.cd_juro.ST_LimpaCampo = true;
            this.cd_juro.ST_NotNull = true;
            this.cd_juro.ST_PrimaryKey = false;
            this.cd_juro.TabIndex = 8;
            this.cd_juro.TextOld = null;
            this.cd_juro.Leave += new System.EventHandler(this.cd_juro_Leave);
            // 
            // ds_juro
            // 
            this.ds_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEmprestimo, "Ds_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_juro.Enabled = false;
            this.ds_juro.Location = new System.Drawing.Point(169, 109);
            this.ds_juro.Name = "ds_juro";
            this.ds_juro.NM_Alias = "";
            this.ds_juro.NM_Campo = "ds_juro";
            this.ds_juro.NM_CampoBusca = "ds_juro";
            this.ds_juro.NM_Param = "@P_NM_CLIFOR";
            this.ds_juro.QTD_Zero = 0;
            this.ds_juro.Size = new System.Drawing.Size(292, 20);
            this.ds_juro.ST_AutoInc = false;
            this.ds_juro.ST_DisableAuto = false;
            this.ds_juro.ST_Float = false;
            this.ds_juro.ST_Gravar = false;
            this.ds_juro.ST_Int = false;
            this.ds_juro.ST_LimpaCampo = true;
            this.ds_juro.ST_NotNull = false;
            this.ds_juro.ST_PrimaryKey = false;
            this.ds_juro.TabIndex = 194;
            this.ds_juro.TextOld = null;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(467, 112);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(41, 13);
            label10.TabIndex = 196;
            label10.Text = "% Juro:";
            // 
            // pc_juro
            // 
            this.pc_juro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEmprestimo, "Pc_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_juro.DecimalPlaces = 2;
            this.pc_juro.Enabled = false;
            this.pc_juro.Location = new System.Drawing.Point(514, 109);
            this.pc_juro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.pc_juro.Name = "pc_juro";
            this.pc_juro.NM_Alias = "";
            this.pc_juro.NM_Campo = "pc_jurodiario_atrazo";
            this.pc_juro.NM_Param = "PC_JURODIARIO_ATRAZO";
            this.pc_juro.Operador = "";
            this.pc_juro.Size = new System.Drawing.Size(79, 20);
            this.pc_juro.ST_AutoInc = false;
            this.pc_juro.ST_DisableAuto = false;
            this.pc_juro.ST_Gravar = false;
            this.pc_juro.ST_LimparCampo = true;
            this.pc_juro.ST_NotNull = false;
            this.pc_juro.ST_PrimaryKey = false;
            this.pc_juro.TabIndex = 197;
            this.pc_juro.ThousandsSeparator = true;
            // 
            // TFEmprestimos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 398);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEmprestimos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emprestimos Recebidos/Concedidos";
            this.Load += new System.EventHandler(this.TFEmprestimos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEmprestimos_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEmprestimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_emprestimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_juro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_observacao;
        private Componentes.ComboBoxDefault tp_emprestimo;
        private Componentes.EditData dt_emprestimo;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.EditFloat vl_emprestimo;
        private System.Windows.Forms.BindingSource bsEmprestimo;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault nm_clifor;
        private System.Windows.Forms.Button bb_endereco;
        private Componentes.EditDefault CD_Endereco;
        private Componentes.EditDefault DS_Endereco;
        private Componentes.EditDefault cd_contager;
        private System.Windows.Forms.Button bb_contager;
        private Componentes.EditDefault ds_contager;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault ds_portador;
        private Componentes.EditDefault cd_portador;
        private System.Windows.Forms.Button bb_juro;
        private Componentes.EditDefault cd_juro;
        private Componentes.EditDefault ds_juro;
        private Componentes.EditFloat pc_juro;
    }
}