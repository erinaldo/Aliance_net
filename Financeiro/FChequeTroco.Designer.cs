namespace Financeiro
{
    partial class TFChequeTroco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFChequeTroco));
            System.Windows.Forms.Label nr_chequeLabel;
            System.Windows.Forms.Label vl_tituloLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.BB_Banco = new System.Windows.Forms.Button();
            this.ds_banco = new Componentes.EditDefault(this.components);
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DS_ContaGer = new Componentes.EditDefault(this.components);
            this.BB_Conta = new System.Windows.Forms.Button();
            this.CD_Conta = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.DS_Portador = new Componentes.EditDefault(this.components);
            this.BB_Portador = new System.Windows.Forms.Button();
            this.CD_Portador = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.DS_Historico = new Componentes.EditDefault(this.components);
            this.BB_Historico = new System.Windows.Forms.Button();
            this.CD_Historico = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pValores = new Componentes.PanelDados(this.components);
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.vl_titulo = new Componentes.EditFloat(this.components);
            this.DT_Pgto = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.vl_multchtroco = new Componentes.EditFloat(this.components);
            this.vl_multiplo = new Componentes.EditFloat(this.components);
            this.qtd_cheque = new Componentes.EditFloat(this.components);
            nr_chequeLabel = new System.Windows.Forms.Label();
            vl_tituloLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multchtroco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multiplo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_cheque)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(608, 39);
            this.barraMenu.TabIndex = 534;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(131, 36);
            this.BB_Gravar.Text = " (F4)\r\n Gerar Cheques";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.pValores);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.DS_Historico);
            this.pDados.Controls.Add(this.BB_Historico);
            this.pDados.Controls.Add(this.CD_Historico);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.DS_Portador);
            this.pDados.Controls.Add(this.BB_Portador);
            this.pDados.Controls.Add(this.CD_Portador);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.DS_ContaGer);
            this.pDados.Controls.Add(this.BB_Conta);
            this.pDados.Controls.Add(this.CD_Conta);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.BB_Banco);
            this.pDados.Controls.Add(this.ds_banco);
            this.pDados.Controls.Add(this.cd_banco);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 39);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(608, 209);
            this.pDados.TabIndex = 535;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(148, 5);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 39;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(68, 5);
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
            this.cd_empresa.TabIndex = 38;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Empresa:";
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(177, 5);
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
            this.nm_empresa.TabIndex = 41;
            this.nm_empresa.TextOld = null;
            // 
            // BB_Banco
            // 
            this.BB_Banco.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Banco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Banco.Image")));
            this.BB_Banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Banco.Location = new System.Drawing.Point(148, 31);
            this.BB_Banco.Name = "BB_Banco";
            this.BB_Banco.Size = new System.Drawing.Size(28, 20);
            this.BB_Banco.TabIndex = 43;
            this.BB_Banco.UseVisualStyleBackColor = false;
            this.BB_Banco.Click += new System.EventHandler(this.BB_Banco_Click);
            // 
            // ds_banco
            // 
            this.ds_banco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_banco.Enabled = false;
            this.ds_banco.Location = new System.Drawing.Point(177, 31);
            this.ds_banco.MaxLength = 32000;
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.NM_Alias = "";
            this.ds_banco.NM_Campo = "ds_banco";
            this.ds_banco.NM_CampoBusca = "ds_banco";
            this.ds_banco.NM_Param = "@P_DS_BANCO";
            this.ds_banco.QTD_Zero = 0;
            this.ds_banco.Size = new System.Drawing.Size(426, 20);
            this.ds_banco.ST_AutoInc = false;
            this.ds_banco.ST_DisableAuto = false;
            this.ds_banco.ST_Float = false;
            this.ds_banco.ST_Gravar = true;
            this.ds_banco.ST_Int = false;
            this.ds_banco.ST_LimpaCampo = true;
            this.ds_banco.ST_NotNull = true;
            this.ds_banco.ST_PrimaryKey = false;
            this.ds_banco.TabIndex = 44;
            this.ds_banco.TextOld = null;
            // 
            // cd_banco
            // 
            this.cd_banco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.Location = new System.Drawing.Point(68, 31);
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
            this.cd_banco.TabIndex = 42;
            this.cd_banco.TextOld = null;
            this.cd_banco.Leave += new System.EventHandler(this.cd_banco_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(21, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Banco:";
            // 
            // DS_ContaGer
            // 
            this.DS_ContaGer.BackColor = System.Drawing.Color.White;
            this.DS_ContaGer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_ContaGer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_ContaGer.Enabled = false;
            this.DS_ContaGer.Location = new System.Drawing.Point(177, 57);
            this.DS_ContaGer.Name = "DS_ContaGer";
            this.DS_ContaGer.NM_Alias = "";
            this.DS_ContaGer.NM_Campo = "DS_ContaGer";
            this.DS_ContaGer.NM_CampoBusca = "DS_ContaGer";
            this.DS_ContaGer.NM_Param = "@P_DS_CONTA";
            this.DS_ContaGer.QTD_Zero = 0;
            this.DS_ContaGer.Size = new System.Drawing.Size(426, 20);
            this.DS_ContaGer.ST_AutoInc = false;
            this.DS_ContaGer.ST_DisableAuto = false;
            this.DS_ContaGer.ST_Float = false;
            this.DS_ContaGer.ST_Gravar = false;
            this.DS_ContaGer.ST_Int = false;
            this.DS_ContaGer.ST_LimpaCampo = true;
            this.DS_ContaGer.ST_NotNull = false;
            this.DS_ContaGer.ST_PrimaryKey = false;
            this.DS_ContaGer.TabIndex = 47;
            this.DS_ContaGer.TextOld = null;
            // 
            // BB_Conta
            // 
            this.BB_Conta.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Conta.Image = ((System.Drawing.Image)(resources.GetObject("BB_Conta.Image")));
            this.BB_Conta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Conta.Location = new System.Drawing.Point(148, 57);
            this.BB_Conta.Name = "BB_Conta";
            this.BB_Conta.Size = new System.Drawing.Size(28, 20);
            this.BB_Conta.TabIndex = 48;
            this.BB_Conta.UseVisualStyleBackColor = false;
            this.BB_Conta.Click += new System.EventHandler(this.BB_Conta_Click);
            // 
            // CD_Conta
            // 
            this.CD_Conta.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Conta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Conta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Conta.Location = new System.Drawing.Point(68, 57);
            this.CD_Conta.Name = "CD_Conta";
            this.CD_Conta.NM_Alias = "";
            this.CD_Conta.NM_Campo = "CD_ContaGer";
            this.CD_Conta.NM_CampoBusca = "CD_ContaGer";
            this.CD_Conta.NM_Param = "@P_CD_CONTAGER";
            this.CD_Conta.QTD_Zero = 0;
            this.CD_Conta.Size = new System.Drawing.Size(79, 20);
            this.CD_Conta.ST_AutoInc = false;
            this.CD_Conta.ST_DisableAuto = false;
            this.CD_Conta.ST_Float = false;
            this.CD_Conta.ST_Gravar = true;
            this.CD_Conta.ST_Int = false;
            this.CD_Conta.ST_LimpaCampo = true;
            this.CD_Conta.ST_NotNull = true;
            this.CD_Conta.ST_PrimaryKey = false;
            this.CD_Conta.TabIndex = 46;
            this.CD_Conta.TextOld = null;
            this.CD_Conta.Leave += new System.EventHandler(this.CD_Conta_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Conta:";
            // 
            // DS_Portador
            // 
            this.DS_Portador.BackColor = System.Drawing.Color.White;
            this.DS_Portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Portador.Enabled = false;
            this.DS_Portador.Location = new System.Drawing.Point(177, 83);
            this.DS_Portador.Name = "DS_Portador";
            this.DS_Portador.NM_Alias = "";
            this.DS_Portador.NM_Campo = "DS_Portador";
            this.DS_Portador.NM_CampoBusca = "DS_Portador";
            this.DS_Portador.NM_Param = "@P_DS_PORTADOR";
            this.DS_Portador.QTD_Zero = 0;
            this.DS_Portador.Size = new System.Drawing.Size(426, 20);
            this.DS_Portador.ST_AutoInc = false;
            this.DS_Portador.ST_DisableAuto = false;
            this.DS_Portador.ST_Float = false;
            this.DS_Portador.ST_Gravar = false;
            this.DS_Portador.ST_Int = false;
            this.DS_Portador.ST_LimpaCampo = true;
            this.DS_Portador.ST_NotNull = false;
            this.DS_Portador.ST_PrimaryKey = false;
            this.DS_Portador.TabIndex = 51;
            this.DS_Portador.TextOld = null;
            // 
            // BB_Portador
            // 
            this.BB_Portador.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Portador.Image = ((System.Drawing.Image)(resources.GetObject("BB_Portador.Image")));
            this.BB_Portador.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Portador.Location = new System.Drawing.Point(148, 83);
            this.BB_Portador.Name = "BB_Portador";
            this.BB_Portador.Size = new System.Drawing.Size(28, 20);
            this.BB_Portador.TabIndex = 52;
            this.BB_Portador.UseVisualStyleBackColor = false;
            this.BB_Portador.Click += new System.EventHandler(this.BB_Portador_Click);
            // 
            // CD_Portador
            // 
            this.CD_Portador.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Portador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Portador.Location = new System.Drawing.Point(68, 83);
            this.CD_Portador.Name = "CD_Portador";
            this.CD_Portador.NM_Alias = "";
            this.CD_Portador.NM_Campo = "CD_Portador";
            this.CD_Portador.NM_CampoBusca = "CD_Portador";
            this.CD_Portador.NM_Param = "@P_CD_PORTADOR";
            this.CD_Portador.QTD_Zero = 0;
            this.CD_Portador.Size = new System.Drawing.Size(79, 20);
            this.CD_Portador.ST_AutoInc = false;
            this.CD_Portador.ST_DisableAuto = false;
            this.CD_Portador.ST_Float = false;
            this.CD_Portador.ST_Gravar = true;
            this.CD_Portador.ST_Int = false;
            this.CD_Portador.ST_LimpaCampo = true;
            this.CD_Portador.ST_NotNull = true;
            this.CD_Portador.ST_PrimaryKey = false;
            this.CD_Portador.TabIndex = 50;
            this.CD_Portador.TextOld = null;
            this.CD_Portador.Leave += new System.EventHandler(this.CD_Portador_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Portador:";
            // 
            // DS_Historico
            // 
            this.DS_Historico.BackColor = System.Drawing.Color.White;
            this.DS_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Historico.Enabled = false;
            this.DS_Historico.Location = new System.Drawing.Point(177, 109);
            this.DS_Historico.Name = "DS_Historico";
            this.DS_Historico.NM_Alias = " c";
            this.DS_Historico.NM_Campo = "DS_Historico";
            this.DS_Historico.NM_CampoBusca = "DS_Historico";
            this.DS_Historico.NM_Param = "@P_DS_HISTORICO";
            this.DS_Historico.QTD_Zero = 0;
            this.DS_Historico.Size = new System.Drawing.Size(426, 20);
            this.DS_Historico.ST_AutoInc = false;
            this.DS_Historico.ST_DisableAuto = false;
            this.DS_Historico.ST_Float = false;
            this.DS_Historico.ST_Gravar = false;
            this.DS_Historico.ST_Int = false;
            this.DS_Historico.ST_LimpaCampo = true;
            this.DS_Historico.ST_NotNull = false;
            this.DS_Historico.ST_PrimaryKey = false;
            this.DS_Historico.TabIndex = 56;
            this.DS_Historico.TextOld = null;
            // 
            // BB_Historico
            // 
            this.BB_Historico.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Historico.Image = ((System.Drawing.Image)(resources.GetObject("BB_Historico.Image")));
            this.BB_Historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Historico.Location = new System.Drawing.Point(148, 109);
            this.BB_Historico.Name = "BB_Historico";
            this.BB_Historico.Size = new System.Drawing.Size(28, 20);
            this.BB_Historico.TabIndex = 55;
            this.BB_Historico.UseVisualStyleBackColor = false;
            this.BB_Historico.Click += new System.EventHandler(this.BB_Historico_Click);
            // 
            // CD_Historico
            // 
            this.CD_Historico.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Historico.Location = new System.Drawing.Point(68, 109);
            this.CD_Historico.Name = "CD_Historico";
            this.CD_Historico.NM_Alias = "";
            this.CD_Historico.NM_Campo = "CD_Historico";
            this.CD_Historico.NM_CampoBusca = "CD_Historico";
            this.CD_Historico.NM_Param = "@P_CD_HISTORICO";
            this.CD_Historico.QTD_Zero = 0;
            this.CD_Historico.Size = new System.Drawing.Size(79, 20);
            this.CD_Historico.ST_AutoInc = false;
            this.CD_Historico.ST_DisableAuto = false;
            this.CD_Historico.ST_Float = false;
            this.CD_Historico.ST_Gravar = true;
            this.CD_Historico.ST_Int = false;
            this.CD_Historico.ST_LimpaCampo = true;
            this.CD_Historico.ST_NotNull = true;
            this.CD_Historico.ST_PrimaryKey = false;
            this.CD_Historico.TabIndex = 54;
            this.CD_Historico.TextOld = null;
            this.CD_Historico.Leave += new System.EventHandler(this.CD_Historico_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(11, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 57;
            this.label5.Text = "Historico:";
            // 
            // pValores
            // 
            this.pValores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pValores.Controls.Add(this.qtd_cheque);
            this.pValores.Controls.Add(label6);
            this.pValores.Controls.Add(this.vl_multiplo);
            this.pValores.Controls.Add(label9);
            this.pValores.Controls.Add(this.vl_multchtroco);
            this.pValores.Controls.Add(label7);
            this.pValores.Controls.Add(this.nr_cheque);
            this.pValores.Controls.Add(nr_chequeLabel);
            this.pValores.Controls.Add(this.vl_titulo);
            this.pValores.Controls.Add(vl_tituloLabel);
            this.pValores.Controls.Add(this.DT_Pgto);
            this.pValores.Controls.Add(this.label8);
            this.pValores.Location = new System.Drawing.Point(68, 135);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            this.pValores.Size = new System.Drawing.Size(535, 65);
            this.pValores.TabIndex = 58;
            // 
            // nr_cheque
            // 
            this.nr_cheque.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cheque.Location = new System.Drawing.Point(97, 6);
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Alias = "";
            this.nr_cheque.NM_Campo = "";
            this.nr_cheque.NM_CampoBusca = "";
            this.nr_cheque.NM_Param = "";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.Size = new System.Drawing.Size(94, 20);
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = false;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = true;
            this.nr_cheque.ST_Int = true;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = true;
            this.nr_cheque.ST_PrimaryKey = false;
            this.nr_cheque.TabIndex = 0;
            this.nr_cheque.TextOld = null;
            this.nr_cheque.Leave += new System.EventHandler(this.nr_cheque_Leave);
            this.nr_cheque.Enter += new System.EventHandler(this.nr_cheque_Enter);
            // 
            // nr_chequeLabel
            // 
            nr_chequeLabel.AutoSize = true;
            nr_chequeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            nr_chequeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            nr_chequeLabel.Location = new System.Drawing.Point(-1, 9);
            nr_chequeLabel.Name = "nr_chequeLabel";
            nr_chequeLabel.Size = new System.Drawing.Size(92, 13);
            nr_chequeLabel.TabIndex = 528;
            nr_chequeLabel.Text = "Cheque Inicial:";
            // 
            // vl_titulo
            // 
            this.vl_titulo.DecimalPlaces = 2;
            this.vl_titulo.Enabled = false;
            this.vl_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.vl_titulo.Location = new System.Drawing.Point(395, 32);
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
            this.vl_titulo.Size = new System.Drawing.Size(133, 26);
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
            vl_tituloLabel.Location = new System.Drawing.Point(302, 39);
            vl_tituloLabel.Name = "vl_tituloLabel";
            vl_tituloLabel.Size = new System.Drawing.Size(87, 13);
            vl_tituloLabel.TabIndex = 530;
            vl_tituloLabel.Text = "Valor Cheque:";
            // 
            // DT_Pgto
            // 
            this.DT_Pgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Pgto.Location = new System.Drawing.Point(450, 6);
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
            this.DT_Pgto.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(372, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Emitido em:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(17, 39);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 13);
            label7.TabIndex = 531;
            label7.Text = "Vl. Multiplo:";
            // 
            // vl_multchtroco
            // 
            this.vl_multchtroco.Enabled = false;
            this.vl_multchtroco.Location = new System.Drawing.Point(97, 37);
            this.vl_multchtroco.Name = "vl_multchtroco";
            this.vl_multchtroco.NM_Alias = "";
            this.vl_multchtroco.NM_Campo = "";
            this.vl_multchtroco.NM_Param = "";
            this.vl_multchtroco.Operador = "";
            this.vl_multchtroco.Size = new System.Drawing.Size(94, 20);
            this.vl_multchtroco.ST_AutoInc = false;
            this.vl_multchtroco.ST_DisableAuto = false;
            this.vl_multchtroco.ST_Gravar = false;
            this.vl_multchtroco.ST_LimparCampo = true;
            this.vl_multchtroco.ST_NotNull = false;
            this.vl_multchtroco.ST_PrimaryKey = false;
            this.vl_multchtroco.TabIndex = 532;
            this.vl_multchtroco.ThousandsSeparator = true;
            this.vl_multchtroco.ValueChanged += new System.EventHandler(this.vl_multchtroco_ValueChanged);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(197, 39);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(15, 13);
            label9.TabIndex = 533;
            label9.Text = "X";
            // 
            // vl_multiplo
            // 
            this.vl_multiplo.Location = new System.Drawing.Point(218, 37);
            this.vl_multiplo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.vl_multiplo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vl_multiplo.Name = "vl_multiplo";
            this.vl_multiplo.NM_Alias = "";
            this.vl_multiplo.NM_Campo = "";
            this.vl_multiplo.NM_Param = "";
            this.vl_multiplo.Operador = "";
            this.vl_multiplo.Size = new System.Drawing.Size(68, 20);
            this.vl_multiplo.ST_AutoInc = false;
            this.vl_multiplo.ST_DisableAuto = false;
            this.vl_multiplo.ST_Gravar = false;
            this.vl_multiplo.ST_LimparCampo = true;
            this.vl_multiplo.ST_NotNull = false;
            this.vl_multiplo.ST_PrimaryKey = false;
            this.vl_multiplo.TabIndex = 534;
            this.vl_multiplo.ThousandsSeparator = true;
            this.vl_multiplo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.vl_multiplo.ValueChanged += new System.EventHandler(this.vl_multiplo_ValueChanged);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(197, 8);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(82, 13);
            label6.TabIndex = 535;
            label6.Text = "Qtd. Cheque:";
            // 
            // qtd_cheque
            // 
            this.qtd_cheque.Location = new System.Drawing.Point(285, 6);
            this.qtd_cheque.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.qtd_cheque.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.qtd_cheque.Name = "qtd_cheque";
            this.qtd_cheque.NM_Alias = "";
            this.qtd_cheque.NM_Campo = "";
            this.qtd_cheque.NM_Param = "";
            this.qtd_cheque.Operador = "";
            this.qtd_cheque.Size = new System.Drawing.Size(68, 20);
            this.qtd_cheque.ST_AutoInc = false;
            this.qtd_cheque.ST_DisableAuto = false;
            this.qtd_cheque.ST_Gravar = false;
            this.qtd_cheque.ST_LimparCampo = true;
            this.qtd_cheque.ST_NotNull = false;
            this.qtd_cheque.ST_PrimaryKey = false;
            this.qtd_cheque.TabIndex = 536;
            this.qtd_cheque.ThousandsSeparator = true;
            this.qtd_cheque.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TFChequeTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 248);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFChequeTroco";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Cheque Troco";
            this.Load += new System.EventHandler(this.TFChequeTroco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFChequeTroco_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_titulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multchtroco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_multiplo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_cheque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BB_Banco;
        public Componentes.EditDefault ds_banco;
        private System.Windows.Forms.Label label3;
        public Componentes.EditDefault DS_ContaGer;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault DS_Portador;
        private System.Windows.Forms.Label label5;
        public Componentes.EditDefault DS_Historico;
        private Componentes.PanelDados pValores;
        private System.Windows.Forms.Label label8;
        private Componentes.EditFloat vl_multchtroco;
        private Componentes.EditFloat vl_multiplo;
        private Componentes.EditFloat qtd_cheque;
        private Componentes.EditDefault cd_banco;
        private System.Windows.Forms.Button BB_Conta;
        private Componentes.EditDefault CD_Conta;
        private System.Windows.Forms.Button BB_Portador;
        private Componentes.EditDefault CD_Portador;
        private System.Windows.Forms.Button BB_Historico;
        private Componentes.EditDefault CD_Historico;
        private Componentes.EditDefault nr_cheque;
        private Componentes.EditData DT_Pgto;
        private Componentes.EditFloat vl_titulo;
    }
}