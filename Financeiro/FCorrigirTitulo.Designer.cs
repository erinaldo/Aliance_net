namespace Financeiro
{
    partial class TFCorrigirTitulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCorrigirTitulo));
            System.Windows.Forms.Label nr_chequeLabel;
            System.Windows.Forms.Label vl_tituloLabel;
            System.Windows.Forms.Label nr_lanctochequeLabel;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.vl_titulo = new Componentes.EditFloat(this.components);
            this.DT_Pgto = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.DT_Vencto = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_clifor_nominal = new System.Windows.Forms.Button();
            this.nm_clifor_nominal = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nr_lanctocheque = new Componentes.EditFloat(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.ds_banco = new Componentes.EditDefault(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.Fone = new Componentes.EditMask(this.components);
            this.LB_Fone = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NR_CGCCPF = new Componentes.EditDefault(this.components);
            this.Compl_Historico = new Componentes.EditDefault(this.components);
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.DS_ContaGer = new Componentes.EditDefault(this.components);
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.CD_Conta = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.DS_Portador = new Componentes.EditDefault(this.components);
            this.CD_Portador = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.DEVCRE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bsTitulo = new System.Windows.Forms.BindingSource(this.components);
            this.tp_titulo = new Componentes.EditDefault(this.components);
            nr_chequeLabel = new System.Windows.Forms.Label();
            vl_tituloLabel = new System.Windows.Forms.Label();
            nr_lanctochequeLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_lanctocheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(586, 43);
            this.barraMenu.TabIndex = 534;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.SystemColors.Control;
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.tp_titulo);
            this.pDados.Controls.Add(this.pValores);
            this.pDados.Controls.Add(this.bb_clifor_nominal);
            this.pDados.Controls.Add(this.nm_clifor_nominal);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(nr_lanctochequeLabel);
            this.pDados.Controls.Add(this.nr_lanctocheque);
            this.pDados.Controls.Add(this.BB_Clifor);
            this.pDados.Controls.Add(this.ds_banco);
            this.pDados.Controls.Add(this.label10);
            this.pDados.Controls.Add(this.cd_banco);
            this.pDados.Controls.Add(this.Fone);
            this.pDados.Controls.Add(this.LB_Fone);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.NR_CGCCPF);
            this.pDados.Controls.Add(this.Compl_Historico);
            this.pDados.Controls.Add(this.DS_Historico);
            this.pDados.Controls.Add(this.DS_ContaGer);
            this.pDados.Controls.Add(this.CD_Historico);
            this.pDados.Controls.Add(this.CD_Conta);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.DS_Portador);
            this.pDados.Controls.Add(this.CD_Portador);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.DEVCRE);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(586, 300);
            this.pDados.TabIndex = 535;
            // 
            // pValores
            // 
            this.pValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pValores.Controls.Add(this.nr_cheque);
            this.pValores.Controls.Add(nr_chequeLabel);
            this.pValores.Controls.Add(this.vl_titulo);
            this.pValores.Controls.Add(vl_tituloLabel);
            this.pValores.Controls.Add(this.DT_Pgto);
            this.pValores.Controls.Add(this.label8);
            this.pValores.Controls.Add(this.DT_Vencto);
            this.pValores.Controls.Add(this.label3);
            this.pValores.Location = new System.Drawing.Point(99, 228);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            this.pValores.Size = new System.Drawing.Size(482, 65);
            this.pValores.TabIndex = 20;
            // 
            // nr_cheque
            // 
            this.nr_cheque.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cheque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Nr_cheque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_cheque.Enabled = false;
            this.nr_cheque.Location = new System.Drawing.Point(97, 6);
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Alias = "";
            this.nr_cheque.NM_Campo = "";
            this.nr_cheque.NM_CampoBusca = "";
            this.nr_cheque.NM_Param = "";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.Size = new System.Drawing.Size(165, 20);
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = false;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = false;
            this.nr_cheque.ST_Int = false;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = true;
            this.nr_cheque.ST_PrimaryKey = false;
            this.nr_cheque.TabIndex = 0;
            // 
            // nr_chequeLabel
            // 
            nr_chequeLabel.AutoSize = true;
            nr_chequeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            nr_chequeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            nr_chequeLabel.Location = new System.Drawing.Point(21, 9);
            nr_chequeLabel.Name = "nr_chequeLabel";
            nr_chequeLabel.Size = new System.Drawing.Size(70, 13);
            nr_chequeLabel.TabIndex = 528;
            nr_chequeLabel.Text = "Nr cheque:";
            // 
            // vl_titulo
            // 
            this.vl_titulo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTitulo, "Vl_titulo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_titulo.DecimalPlaces = 2;
            this.vl_titulo.Enabled = false;
            this.vl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vl_titulo.Location = new System.Drawing.Point(97, 32);
            this.vl_titulo.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_titulo.Name = "vl_titulo";
            this.vl_titulo.NM_Alias = "";
            this.vl_titulo.NM_Campo = "";
            this.vl_titulo.NM_Param = "";
            this.vl_titulo.Operador = "";
            this.vl_titulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_titulo.Size = new System.Drawing.Size(165, 26);
            this.vl_titulo.ST_AutoInc = false;
            this.vl_titulo.ST_DisableAuto = false;
            this.vl_titulo.ST_Gravar = true;
            this.vl_titulo.ST_LimparCampo = true;
            this.vl_titulo.ST_NotNull = true;
            this.vl_titulo.ST_PrimaryKey = false;
            this.vl_titulo.TabIndex = 2;
            this.vl_titulo.ThousandsSeparator = true;
            // 
            // vl_tituloLabel
            // 
            vl_tituloLabel.AutoSize = true;
            vl_tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            vl_tituloLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            vl_tituloLabel.Location = new System.Drawing.Point(4, 39);
            vl_tituloLabel.Name = "vl_tituloLabel";
            vl_tituloLabel.Size = new System.Drawing.Size(87, 13);
            vl_tituloLabel.TabIndex = 530;
            vl_tituloLabel.Text = "Valor Cheque:";
            // 
            // DT_Pgto
            // 
            this.DT_Pgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Dt_emissaostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Pgto.Location = new System.Drawing.Point(365, 6);
            this.DT_Pgto.Mask = "00/00/0000";
            this.DT_Pgto.Name = "DT_Pgto";
            this.DT_Pgto.NM_Alias = "";
            this.DT_Pgto.NM_Campo = "";
            this.DT_Pgto.NM_CampoBusca = "";
            this.DT_Pgto.NM_Param = "";
            this.DT_Pgto.Operador = "";
            this.DT_Pgto.Size = new System.Drawing.Size(78, 20);
            this.DT_Pgto.ST_Gravar = true;
            this.DT_Pgto.ST_LimpaCampo = true;
            this.DT_Pgto.ST_NotNull = true;
            this.DT_Pgto.ST_PrimaryKey = false;
            this.DT_Pgto.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(271, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Data Emissão:";
            // 
            // DT_Vencto
            // 
            this.DT_Vencto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Dt_venctostring", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Vencto.Location = new System.Drawing.Point(365, 32);
            this.DT_Vencto.Mask = "00/00/0000";
            this.DT_Vencto.Name = "DT_Vencto";
            this.DT_Vencto.NM_Alias = "";
            this.DT_Vencto.NM_Campo = "";
            this.DT_Vencto.NM_CampoBusca = "";
            this.DT_Vencto.NM_Param = "";
            this.DT_Vencto.Operador = "";
            this.DT_Vencto.Size = new System.Drawing.Size(78, 20);
            this.DT_Vencto.ST_Gravar = true;
            this.DT_Vencto.ST_LimpaCampo = true;
            this.DT_Vencto.ST_NotNull = true;
            this.DT_Vencto.ST_PrimaryKey = false;
            this.DT_Vencto.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(294, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Bom Para:";
            // 
            // bb_clifor_nominal
            // 
            this.bb_clifor_nominal.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor_nominal.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor_nominal.Image")));
            this.bb_clifor_nominal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor_nominal.Location = new System.Drawing.Point(553, 116);
            this.bb_clifor_nominal.Name = "bb_clifor_nominal";
            this.bb_clifor_nominal.Size = new System.Drawing.Size(28, 19);
            this.bb_clifor_nominal.TabIndex = 5;
            this.bb_clifor_nominal.UseVisualStyleBackColor = false;
            this.bb_clifor_nominal.Click += new System.EventHandler(this.bb_clifor_nominal_Click);
            // 
            // nm_clifor_nominal
            // 
            this.nm_clifor_nominal.BackColor = System.Drawing.SystemColors.Window;
            this.nm_clifor_nominal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_clifor_nominal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Nm_clifor_nominal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_clifor_nominal.Location = new System.Drawing.Point(99, 116);
            this.nm_clifor_nominal.Name = "nm_clifor_nominal";
            this.nm_clifor_nominal.NM_Alias = "d";
            this.nm_clifor_nominal.NM_Campo = "nm_clifor_nominal";
            this.nm_clifor_nominal.NM_CampoBusca = "NM_Clifor";
            this.nm_clifor_nominal.NM_Param = "@P_NM_CLIFOR";
            this.nm_clifor_nominal.QTD_Zero = 0;
            this.nm_clifor_nominal.Size = new System.Drawing.Size(452, 20);
            this.nm_clifor_nominal.ST_AutoInc = false;
            this.nm_clifor_nominal.ST_DisableAuto = false;
            this.nm_clifor_nominal.ST_Float = false;
            this.nm_clifor_nominal.ST_Gravar = false;
            this.nm_clifor_nominal.ST_Int = false;
            this.nm_clifor_nominal.ST_LimpaCampo = true;
            this.nm_clifor_nominal.ST_NotNull = false;
            this.nm_clifor_nominal.ST_PrimaryKey = false;
            this.nm_clifor_nominal.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(37, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 536;
            this.label2.Text = "Nominal:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(180, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 531;
            this.label11.Text = "Tipo Movimento:";
            // 
            // nr_lanctochequeLabel
            // 
            nr_lanctochequeLabel.AutoSize = true;
            nr_lanctochequeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            nr_lanctochequeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            nr_lanctochequeLabel.Location = new System.Drawing.Point(421, 1);
            nr_lanctochequeLabel.Name = "nr_lanctochequeLabel";
            nr_lanctochequeLabel.Size = new System.Drawing.Size(123, 17);
            nr_lanctochequeLabel.TabIndex = 529;
            nr_lanctochequeLabel.Text = "Nº Lançamento:";
            // 
            // nr_lanctocheque
            // 
            this.nr_lanctocheque.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.nr_lanctocheque.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTitulo, "Nr_lanctocheque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_lanctocheque.Enabled = false;
            this.nr_lanctocheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nr_lanctocheque.Location = new System.Drawing.Point(424, 21);
            this.nr_lanctocheque.Name = "nr_lanctocheque";
            this.nr_lanctocheque.NM_Alias = "";
            this.nr_lanctocheque.NM_Campo = "";
            this.nr_lanctocheque.NM_Param = "";
            this.nr_lanctocheque.Operador = "";
            this.nr_lanctocheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nr_lanctocheque.Size = new System.Drawing.Size(157, 26);
            this.nr_lanctocheque.ST_AutoInc = false;
            this.nr_lanctocheque.ST_DisableAuto = false;
            this.nr_lanctocheque.ST_Gravar = false;
            this.nr_lanctocheque.ST_LimparCampo = true;
            this.nr_lanctocheque.ST_NotNull = false;
            this.nr_lanctocheque.ST_PrimaryKey = false;
            this.nr_lanctocheque.TabIndex = 90;
            this.nr_lanctocheque.ThousandsSeparator = true;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(553, 71);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(28, 20);
            this.BB_Clifor.TabIndex = 1;
            this.BB_Clifor.UseVisualStyleBackColor = false;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // ds_banco
            // 
            this.ds_banco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Ds_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_banco.Enabled = false;
            this.ds_banco.Location = new System.Drawing.Point(183, 49);
            this.ds_banco.MaxLength = 32000;
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.NM_Alias = "";
            this.ds_banco.NM_Campo = "ds_banco";
            this.ds_banco.NM_CampoBusca = "ds_banco";
            this.ds_banco.NM_Param = "@P_DS_BANCO";
            this.ds_banco.QTD_Zero = 0;
            this.ds_banco.Size = new System.Drawing.Size(398, 20);
            this.ds_banco.ST_AutoInc = false;
            this.ds_banco.ST_DisableAuto = false;
            this.ds_banco.ST_Float = false;
            this.ds_banco.ST_Gravar = true;
            this.ds_banco.ST_Int = false;
            this.ds_banco.ST_LimpaCampo = true;
            this.ds_banco.ST_NotNull = true;
            this.ds_banco.ST_PrimaryKey = false;
            this.ds_banco.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(46, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 526;
            this.label10.Text = "Banco:";
            // 
            // cd_banco
            // 
            this.cd_banco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Cd_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_banco.Enabled = false;
            this.cd_banco.Location = new System.Drawing.Point(99, 49);
            this.cd_banco.MaxLength = 4;
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.NM_Alias = "";
            this.cd_banco.NM_Campo = "cd_banco";
            this.cd_banco.NM_CampoBusca = "cd_banco";
            this.cd_banco.NM_Param = "@P_CD_BANCO";
            this.cd_banco.QTD_Zero = 0;
            this.cd_banco.Size = new System.Drawing.Size(79, 20);
            this.cd_banco.ST_AutoInc = false;
            this.cd_banco.ST_DisableAuto = true;
            this.cd_banco.ST_Float = false;
            this.cd_banco.ST_Gravar = true;
            this.cd_banco.ST_Int = false;
            this.cd_banco.ST_LimpaCampo = true;
            this.cd_banco.ST_NotNull = true;
            this.cd_banco.ST_PrimaryKey = false;
            this.cd_banco.TabIndex = 3;
            // 
            // Fone
            // 
            this.Fone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Fone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone.Location = new System.Drawing.Point(313, 93);
            this.Fone.Mask = "(99) 0000-0000";
            this.Fone.Name = "Fone";
            this.Fone.NM_Alias = "a";
            this.Fone.NM_Campo = "Fone";
            this.Fone.NM_CampoBusca = "Fone";
            this.Fone.NM_Param = "@P_FONE";
            this.Fone.Size = new System.Drawing.Size(93, 20);
            this.Fone.ST_Gravar = true;
            this.Fone.ST_LimpaCampo = true;
            this.Fone.ST_NotNull = false;
            this.Fone.ST_PrimaryKey = false;
            this.Fone.TabIndex = 3;
            // 
            // LB_Fone
            // 
            this.LB_Fone.AutoSize = true;
            this.LB_Fone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LB_Fone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Fone.Location = new System.Drawing.Point(270, 96);
            this.LB_Fone.Name = "LB_Fone";
            this.LB_Fone.Size = new System.Drawing.Size(39, 13);
            this.LB_Fone.TabIndex = 522;
            this.LB_Fone.Text = "Fone:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(18, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 62;
            this.label9.Text = "CNPJ /CPF:";
            // 
            // NR_CGCCPF
            // 
            this.NR_CGCCPF.BackColor = System.Drawing.SystemColors.Window;
            this.NR_CGCCPF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_CGCCPF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Nr_cgccpf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NR_CGCCPF.Location = new System.Drawing.Point(99, 93);
            this.NR_CGCCPF.Name = "NR_CGCCPF";
            this.NR_CGCCPF.NM_Alias = "";
            this.NR_CGCCPF.NM_Campo = "NR_CGC_CPF";
            this.NR_CGCCPF.NM_CampoBusca = "NR_CGC_CPF";
            this.NR_CGCCPF.NM_Param = "@P_NR_CGC_CPF";
            this.NR_CGCCPF.QTD_Zero = 0;
            this.NR_CGCCPF.Size = new System.Drawing.Size(165, 20);
            this.NR_CGCCPF.ST_AutoInc = false;
            this.NR_CGCCPF.ST_DisableAuto = false;
            this.NR_CGCCPF.ST_Float = false;
            this.NR_CGCCPF.ST_Gravar = false;
            this.NR_CGCCPF.ST_Int = false;
            this.NR_CGCCPF.ST_LimpaCampo = true;
            this.NR_CGCCPF.ST_NotNull = false;
            this.NR_CGCCPF.ST_PrimaryKey = false;
            this.NR_CGCCPF.TabIndex = 2;
            // 
            // Compl_Historico
            // 
            this.Compl_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.Compl_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Compl_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Compl_Historico.Location = new System.Drawing.Point(99, 202);
            this.Compl_Historico.Name = "Compl_Historico";
            this.Compl_Historico.NM_Alias = "";
            this.Compl_Historico.NM_Campo = "";
            this.Compl_Historico.NM_CampoBusca = "";
            this.Compl_Historico.NM_Param = "";
            this.Compl_Historico.QTD_Zero = 0;
            this.Compl_Historico.Size = new System.Drawing.Size(482, 20);
            this.Compl_Historico.ST_AutoInc = false;
            this.Compl_Historico.ST_DisableAuto = false;
            this.Compl_Historico.ST_Float = false;
            this.Compl_Historico.ST_Gravar = true;
            this.Compl_Historico.ST_Int = false;
            this.Compl_Historico.ST_LimpaCampo = true;
            this.Compl_Historico.ST_NotNull = false;
            this.Compl_Historico.ST_PrimaryKey = false;
            this.Compl_Historico.TabIndex = 6;
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.Color.White;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Historico.Enabled = false;
            this.DS_Historico.Location = new System.Drawing.Point(183, 181);
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = " c";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.Size = new System.Drawing.Size(398, 20);
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = false;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = false;
            this.DS_Historico.ST_PrimaryKey = false;
            this.DS_Historico.TabIndex = 19;
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.BackColor = System.Drawing.Color.White;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Nm_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_ContaGer.Enabled = false;
            this.DS_ContaGer.Location = new System.Drawing.Point(183, 160);
            this.DS_ContaGer.Name = "DS_ContaGer";
            this.DS_ContaGer.NM_Alias = "";
            this.DS_ContaGer.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer.NM_Param = "@P_DS_CONTA";
            this.DS_ContaGer.QTD_Zero = 0;
            this.DS_ContaGer.Size = new System.Drawing.Size(398, 20);
            this.DS_ContaGer.ST_AutoInc = false;
            this.DS_ContaGer.ST_DisableAuto = false;
            this.DS_ContaGer.ST_Float = false;
            this.DS_ContaGer.ST_Gravar = false;
            this.DS_ContaGer.ST_Int = false;
            this.DS_ContaGer.ST_LimpaCampo = true;
            this.DS_ContaGer.ST_NotNull = false;
            this.DS_ContaGer.ST_PrimaryKey = false;
            this.DS_ContaGer.TabIndex = 16;
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Historico.Enabled = false;
            this.CD_Historico.Location = new System.Drawing.Point(99, 181);
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.Size = new System.Drawing.Size(78, 20);
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = true;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TabIndex = 17;
            // 
            // CD_Conta
            // 
            this.CD_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Conta.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Cd_contager", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Conta.Enabled = false;
            this.CD_Conta.Location = new System.Drawing.Point(99, 160);
            this.CD_Conta.Name = "CD_Conta";
            this.CD_Conta.NM_Alias = "";
            this.CD_Conta.NM_Campo = "CD_ContaGer";
            this.CD_Conta.NM_CampoBusca = "CD_ContaGer";
            this.CD_Conta.NM_Param = "@P_CD_CONTAGER";
            this.CD_Conta.QTD_Zero = 0;
            this.CD_Conta.Size = new System.Drawing.Size(78, 20);
            this.CD_Conta.ST_AutoInc = false;
            this.CD_Conta.ST_DisableAuto = false;
            this.CD_Conta.ST_Float = false;
            this.CD_Conta.ST_Gravar = true;
            this.CD_Conta.ST_Int = false;
            this.CD_Conta.ST_LimpaCampo = true;
            this.CD_Conta.ST_NotNull = true;
            this.CD_Conta.ST_PrimaryKey = false;
            this.CD_Conta.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(7, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Complemento:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(32, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Histórico:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(49, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Conta:";
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Location = new System.Drawing.Point(99, 23);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(79, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 0;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Nomeclifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Location = new System.Drawing.Point(99, 72);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "d";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(452, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 0;
            // 
            // DS_Portador
            // 
            this.DS_Portador.BackColor = System.Drawing.Color.White;
            this.DS_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Portador.Enabled = false;
            this.DS_Portador.Location = new System.Drawing.Point(183, 139);
            this.DS_Portador.Name = "DS_Portador";
            this.DS_Portador.NM_Alias = "";
            this.DS_Portador.NM_Campo = "DS_Portador";
            this.DS_Portador.NM_CampoBusca = "DS_Portador";
            this.DS_Portador.NM_Param = "@P_DS_PORTADOR";
            this.DS_Portador.QTD_Zero = 0;
            this.DS_Portador.Size = new System.Drawing.Size(398, 20);
            this.DS_Portador.ST_AutoInc = false;
            this.DS_Portador.ST_DisableAuto = false;
            this.DS_Portador.ST_Float = false;
            this.DS_Portador.ST_Gravar = false;
            this.DS_Portador.ST_Int = false;
            this.DS_Portador.ST_LimpaCampo = true;
            this.DS_Portador.ST_NotNull = false;
            this.DS_Portador.ST_PrimaryKey = false;
            this.DS_Portador.TabIndex = 13;
            // 
            // CD_Portador
            // 
            this.CD_Portador.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Portador.Enabled = false;
            this.CD_Portador.Location = new System.Drawing.Point(99, 139);
            this.CD_Portador.Name = "CD_Portador";
            this.CD_Portador.NM_Alias = "";
            this.CD_Portador.NM_Campo = "CD_Portador";
            this.CD_Portador.NM_CampoBusca = "CD_Portador";
            this.CD_Portador.NM_Param = "@P_CD_PORTADOR";
            this.CD_Portador.QTD_Zero = 0;
            this.CD_Portador.Size = new System.Drawing.Size(78, 20);
            this.CD_Portador.ST_AutoInc = false;
            this.CD_Portador.ST_DisableAuto = false;
            this.CD_Portador.ST_Float = false;
            this.CD_Portador.ST_Gravar = true;
            this.CD_Portador.ST_Int = false;
            this.CD_Portador.ST_LimpaCampo = true;
            this.CD_Portador.ST_NotNull = true;
            this.CD_Portador.ST_PrimaryKey = false;
            this.CD_Portador.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(34, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Portador:";
            // 
            // DEVCRE
            // 
            this.DEVCRE.AutoSize = true;
            this.DEVCRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.DEVCRE.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DEVCRE.Location = new System.Drawing.Point(26, 74);
            this.DEVCRE.Name = "DEVCRE";
            this.DEVCRE.Size = new System.Drawing.Size(67, 13);
            this.DEVCRE.TabIndex = 38;
            this.DEVCRE.Text = "DEV/CRE:";
            this.DEVCRE.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Empresa:";
            // 
            // bsTitulo
            // 
            this.bsTitulo.DataSource = typeof(CamadaDados.Financeiro.Titulo.TList_RegLanTitulo);
            // 
            // tp_titulo
            // 
            this.tp_titulo.BackColor = System.Drawing.SystemColors.Window;
            this.tp_titulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_titulo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTitulo, "Tipo_titulo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_titulo.Enabled = false;
            this.tp_titulo.Location = new System.Drawing.Point(287, 23);
            this.tp_titulo.Name = "tp_titulo";
            this.tp_titulo.NM_Alias = "";
            this.tp_titulo.NM_Campo = "CD_Empresa";
            this.tp_titulo.NM_CampoBusca = "CD_Empresa";
            this.tp_titulo.NM_Param = "@P_CD_EMPRESA";
            this.tp_titulo.QTD_Zero = 0;
            this.tp_titulo.Size = new System.Drawing.Size(131, 20);
            this.tp_titulo.ST_AutoInc = false;
            this.tp_titulo.ST_DisableAuto = false;
            this.tp_titulo.ST_Float = false;
            this.tp_titulo.ST_Gravar = true;
            this.tp_titulo.ST_Int = false;
            this.tp_titulo.ST_LimpaCampo = true;
            this.tp_titulo.ST_NotNull = true;
            this.tp_titulo.ST_PrimaryKey = false;
            this.tp_titulo.TabIndex = 537;
            // 
            // TFCorrigirTitulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 343);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCorrigirTitulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Corrigir Cheque";
            this.Load += new System.EventHandler(this.TFCorrigirTitulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCorrigirTitulo_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_lanctocheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.PanelDados pValores;
        public Componentes.EditDefault nr_cheque;
        public Componentes.EditFloat vl_titulo;
        public Componentes.EditData DT_Pgto;
        private System.Windows.Forms.Label label8;
        public Componentes.EditData DT_Vencto;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button bb_clifor_nominal;
        public Componentes.EditDefault nm_clifor_nominal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        public Componentes.EditFloat nr_lanctocheque;
        public System.Windows.Forms.Button BB_Clifor;
        public Componentes.EditDefault ds_banco;
        private System.Windows.Forms.Label label10;
        public Componentes.EditDefault cd_banco;
        private Componentes.EditMask Fone;
        private System.Windows.Forms.Label LB_Fone;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault NR_CGCCPF;
        public Componentes.EditDefault Compl_Historico;
        public Componentes.EditDefault DS_Historico;
        public Componentes.EditDefault DS_ContaGer;
        public Componentes.EditDefault CD_Historico;
        public Componentes.EditDefault CD_Conta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault CD_Empresa;
        public Componentes.EditDefault NM_Clifor;
        public Componentes.EditDefault DS_Portador;
        public Componentes.EditDefault CD_Portador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label DEVCRE;
        private System.Windows.Forms.Label label1;
        public Componentes.EditDefault tp_titulo;
        private System.Windows.Forms.BindingSource bsTitulo;
    }
}