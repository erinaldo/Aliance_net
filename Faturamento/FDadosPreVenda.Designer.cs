namespace Faturamento
{
    partial class TFDadosPreVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDadosPreVenda));
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_cancela = new System.Windows.Forms.Button();
            this.ds_tabelapreco = new Componentes.EditDefault(this.components);
            this.bsPreVenda = new System.Windows.Forms.BindingSource(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            this.label66 = new System.Windows.Forms.Label();
            this.CD_TabelaPreco = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.bb_confirma = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.proximo = new Componentes.EditDefault(this.components);
            this.lbprox = new System.Windows.Forms.Label();
            this.fone = new Componentes.EditDefault(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.Bairro = new Componentes.EditDefault(this.components);
            this.numero = new Componentes.EditDefault(this.components);
            this.bb_cadEndereco = new System.Windows.Forms.Button();
            this.ds_endereco = new Componentes.EditDefault(this.components);
            this.bb_endereco = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cd_endereco = new Componentes.EditDefault(this.components);
            this.bb_cadclifor = new System.Windows.Forms.Button();
            this.NM_CompVend = new Componentes.EditDefault(this.components);
            this.BB_CompVend = new System.Windows.Forms.Button();
            this.CD_CompVend = new Componentes.EditDefault(this.components);
            this.lblAgente = new System.Windows.Forms.Label();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.lblClifor = new System.Windows.Forms.Label();
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.bb_cancela);
            this.pDados.Controls.Add(this.ds_tabelapreco);
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(this.label66);
            this.pDados.Controls.Add(this.CD_TabelaPreco);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.bb_confirma);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.proximo);
            this.pDados.Controls.Add(this.lbprox);
            this.pDados.Controls.Add(this.fone);
            this.pDados.Controls.Add(this.label22);
            this.pDados.Controls.Add(this.Bairro);
            this.pDados.Controls.Add(this.numero);
            this.pDados.Controls.Add(this.bb_cadEndereco);
            this.pDados.Controls.Add(this.ds_endereco);
            this.pDados.Controls.Add(this.bb_endereco);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Controls.Add(this.cd_endereco);
            this.pDados.Controls.Add(this.bb_cadclifor);
            this.pDados.Controls.Add(this.NM_CompVend);
            this.pDados.Controls.Add(this.BB_CompVend);
            this.pDados.Controls.Add(this.CD_CompVend);
            this.pDados.Controls.Add(this.lblAgente);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.BB_Clifor);
            this.pDados.Controls.Add(this.lblClifor);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(781, 208);
            this.pDados.TabIndex = 0;
            // 
            // bb_cancela
            // 
            this.bb_cancela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancela.ForeColor = System.Drawing.Color.Green;
            this.bb_cancela.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancela.Image")));
            this.bb_cancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cancela.Location = new System.Drawing.Point(393, 161);
            this.bb_cancela.Name = "bb_cancela";
            this.bb_cancela.Size = new System.Drawing.Size(138, 41);
            this.bb_cancela.TabIndex = 19;
            this.bb_cancela.Text = "<ESC>\r\nCancelar";
            this.bb_cancela.UseVisualStyleBackColor = true;
            this.bb_cancela.Click += new System.EventHandler(this.bb_cancela_Click);
            // 
            // ds_tabelapreco
            // 
            this.ds_tabelapreco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tabelapreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tabelapreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tabelapreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Ds_tabelaPreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tabelapreco.Enabled = false;
            this.ds_tabelapreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tabelapreco.Location = new System.Drawing.Point(185, 135);
            this.ds_tabelapreco.Name = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Alias = "";
            this.ds_tabelapreco.NM_Campo = "ds_tabelapreco";
            this.ds_tabelapreco.NM_CampoBusca = "ds_tabelapreco";
            this.ds_tabelapreco.NM_Param = "@P_NM_EMPRESA";
            this.ds_tabelapreco.QTD_Zero = 0;
            this.ds_tabelapreco.ReadOnly = true;
            this.ds_tabelapreco.Size = new System.Drawing.Size(591, 20);
            this.ds_tabelapreco.ST_AutoInc = false;
            this.ds_tabelapreco.ST_DisableAuto = false;
            this.ds_tabelapreco.ST_Float = false;
            this.ds_tabelapreco.ST_Gravar = false;
            this.ds_tabelapreco.ST_Int = false;
            this.ds_tabelapreco.ST_LimpaCampo = true;
            this.ds_tabelapreco.ST_NotNull = false;
            this.ds_tabelapreco.ST_PrimaryKey = false;
            this.ds_tabelapreco.TabIndex = 453;
            this.ds_tabelapreco.TextOld = null;
            // 
            // bsPreVenda
            // 
            this.bsPreVenda.DataSource = typeof(CamadaDados.Faturamento.PDV.TList_PreVenda);
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelapreco.Image")));
            this.bb_tabelapreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelapreco.Location = new System.Drawing.Point(151, 135);
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.Size = new System.Drawing.Size(28, 19);
            this.bb_tabelapreco.TabIndex = 17;
            this.bb_tabelapreco.UseVisualStyleBackColor = true;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label66.Location = new System.Drawing.Point(3, 138);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(70, 13);
            this.label66.TabIndex = 452;
            this.label66.Text = "Tab Preço:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_TabelaPreco
            // 
            this.CD_TabelaPreco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TabelaPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TabelaPreco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TabelaPreco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Cd_tabelaPreco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_TabelaPreco.Location = new System.Drawing.Point(74, 135);
            this.CD_TabelaPreco.Name = "CD_TabelaPreco";
            this.CD_TabelaPreco.NM_Alias = "";
            this.CD_TabelaPreco.NM_Campo = "Cd_tabelaPreco";
            this.CD_TabelaPreco.NM_CampoBusca = "Cd_tabelaPreco";
            this.CD_TabelaPreco.NM_Param = "@P_CD_TABELAPRECO";
            this.CD_TabelaPreco.QTD_Zero = 0;
            this.CD_TabelaPreco.Size = new System.Drawing.Size(75, 20);
            this.CD_TabelaPreco.ST_AutoInc = false;
            this.CD_TabelaPreco.ST_DisableAuto = false;
            this.CD_TabelaPreco.ST_Float = false;
            this.CD_TabelaPreco.ST_Gravar = true;
            this.CD_TabelaPreco.ST_Int = true;
            this.CD_TabelaPreco.ST_LimpaCampo = true;
            this.CD_TabelaPreco.ST_NotNull = false;
            this.CD_TabelaPreco.ST_PrimaryKey = false;
            this.CD_TabelaPreco.TabIndex = 16;
            this.CD_TabelaPreco.TextOld = null;
            this.CD_TabelaPreco.Leave += new System.EventHandler(this.CD_TabelaPreco_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(182, 5);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(594, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 451;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(151, 5);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 1;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(14, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 450;
            this.label3.Text = "Empresa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(74, 5);
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
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // bb_confirma
            // 
            this.bb_confirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_confirma.ForeColor = System.Drawing.Color.Green;
            this.bb_confirma.Image = ((System.Drawing.Image)(resources.GetObject("bb_confirma.Image")));
            this.bb_confirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_confirma.Location = new System.Drawing.Point(249, 161);
            this.bb_confirma.Name = "bb_confirma";
            this.bb_confirma.Size = new System.Drawing.Size(138, 41);
            this.bb_confirma.TabIndex = 18;
            this.bb_confirma.Text = "<ENTER>\r\nConfirmar";
            this.bb_confirma.UseVisualStyleBackColor = true;
            this.bb_confirma.Click += new System.EventHandler(this.bb_confirma_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 444;
            this.label2.Text = "Bairro:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(654, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 443;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // proximo
            // 
            this.proximo.BackColor = System.Drawing.SystemColors.Window;
            this.proximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.proximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.proximo.Location = new System.Drawing.Point(341, 83);
            this.proximo.Name = "proximo";
            this.proximo.NM_Alias = "";
            this.proximo.NM_Campo = "proximo";
            this.proximo.NM_CampoBusca = "proximo";
            this.proximo.NM_Param = "";
            this.proximo.QTD_Zero = 0;
            this.proximo.ReadOnly = true;
            this.proximo.Size = new System.Drawing.Size(271, 20);
            this.proximo.ST_AutoInc = false;
            this.proximo.ST_DisableAuto = false;
            this.proximo.ST_Float = false;
            this.proximo.ST_Gravar = false;
            this.proximo.ST_Int = false;
            this.proximo.ST_LimpaCampo = true;
            this.proximo.ST_NotNull = false;
            this.proximo.ST_PrimaryKey = false;
            this.proximo.TabIndex = 12;
            this.proximo.TextOld = null;
            // 
            // lbprox
            // 
            this.lbprox.AutoSize = true;
            this.lbprox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.lbprox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbprox.Location = new System.Drawing.Point(299, 85);
            this.lbprox.Name = "lbprox";
            this.lbprox.Size = new System.Drawing.Size(36, 13);
            this.lbprox.TabIndex = 441;
            this.lbprox.Text = "Prox:";
            this.lbprox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fone
            // 
            this.fone.BackColor = System.Drawing.SystemColors.Window;
            this.fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.fone.Location = new System.Drawing.Point(663, 83);
            this.fone.Name = "fone";
            this.fone.NM_Alias = "";
            this.fone.NM_Campo = "fone";
            this.fone.NM_CampoBusca = "fone";
            this.fone.NM_Param = "";
            this.fone.QTD_Zero = 0;
            this.fone.Size = new System.Drawing.Size(113, 20);
            this.fone.ST_AutoInc = false;
            this.fone.ST_DisableAuto = false;
            this.fone.ST_Float = false;
            this.fone.ST_Gravar = true;
            this.fone.ST_Int = true;
            this.fone.ST_LimpaCampo = true;
            this.fone.ST_NotNull = false;
            this.fone.ST_PrimaryKey = false;
            this.fone.TabIndex = 13;
            this.fone.TextOld = null;
            this.fone.TextChanged += new System.EventHandler(this.fone_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(618, 87);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 13);
            this.label22.TabIndex = 440;
            this.label22.Text = "Fone:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Bairro
            // 
            this.Bairro.BackColor = System.Drawing.SystemColors.Window;
            this.Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Bairro.Location = new System.Drawing.Point(74, 83);
            this.Bairro.Name = "Bairro";
            this.Bairro.NM_Alias = "";
            this.Bairro.NM_Campo = "bairro";
            this.Bairro.NM_CampoBusca = "bairro";
            this.Bairro.NM_Param = "@P_BAIRRO";
            this.Bairro.QTD_Zero = 0;
            this.Bairro.Size = new System.Drawing.Size(219, 20);
            this.Bairro.ST_AutoInc = false;
            this.Bairro.ST_DisableAuto = false;
            this.Bairro.ST_Float = false;
            this.Bairro.ST_Gravar = false;
            this.Bairro.ST_Int = false;
            this.Bairro.ST_LimpaCampo = true;
            this.Bairro.ST_NotNull = false;
            this.Bairro.ST_PrimaryKey = false;
            this.Bairro.TabIndex = 11;
            this.Bairro.TextOld = null;
            // 
            // numero
            // 
            this.numero.BackColor = System.Drawing.SystemColors.Window;
            this.numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numero.Location = new System.Drawing.Point(714, 57);
            this.numero.Name = "numero";
            this.numero.NM_Alias = "";
            this.numero.NM_Campo = "numero";
            this.numero.NM_CampoBusca = "numero";
            this.numero.NM_Param = "@P_NUMERO";
            this.numero.QTD_Zero = 0;
            this.numero.Size = new System.Drawing.Size(62, 20);
            this.numero.ST_AutoInc = false;
            this.numero.ST_DisableAuto = false;
            this.numero.ST_Float = false;
            this.numero.ST_Gravar = false;
            this.numero.ST_Int = false;
            this.numero.ST_LimpaCampo = true;
            this.numero.ST_NotNull = false;
            this.numero.ST_PrimaryKey = false;
            this.numero.TabIndex = 10;
            this.numero.TextOld = null;
            // 
            // bb_cadEndereco
            // 
            this.bb_cadEndereco.Image = ((System.Drawing.Image)(resources.GetObject("bb_cadEndereco.Image")));
            this.bb_cadEndereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cadEndereco.Location = new System.Drawing.Point(180, 57);
            this.bb_cadEndereco.Name = "bb_cadEndereco";
            this.bb_cadEndereco.Size = new System.Drawing.Size(28, 20);
            this.bb_cadEndereco.TabIndex = 8;
            this.bb_cadEndereco.UseVisualStyleBackColor = true;
            this.bb_cadEndereco.Click += new System.EventHandler(this.bb_cadEndereco_Click);
            // 
            // ds_endereco
            // 
            this.ds_endereco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Ds_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_endereco.Location = new System.Drawing.Point(209, 57);
            this.ds_endereco.Name = "ds_endereco";
            this.ds_endereco.NM_Alias = "";
            this.ds_endereco.NM_Campo = "ds_endereco";
            this.ds_endereco.NM_CampoBusca = "ds_endereco";
            this.ds_endereco.NM_Param = "@P_NM_CLIFOR";
            this.ds_endereco.QTD_Zero = 0;
            this.ds_endereco.Size = new System.Drawing.Size(439, 20);
            this.ds_endereco.ST_AutoInc = false;
            this.ds_endereco.ST_DisableAuto = false;
            this.ds_endereco.ST_Float = false;
            this.ds_endereco.ST_Gravar = true;
            this.ds_endereco.ST_Int = false;
            this.ds_endereco.ST_LimpaCampo = true;
            this.ds_endereco.ST_NotNull = false;
            this.ds_endereco.ST_PrimaryKey = false;
            this.ds_endereco.TabIndex = 9;
            this.ds_endereco.TextOld = null;
            // 
            // bb_endereco
            // 
            this.bb_endereco.Image = ((System.Drawing.Image)(resources.GetObject("bb_endereco.Image")));
            this.bb_endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endereco.Location = new System.Drawing.Point(151, 58);
            this.bb_endereco.Name = "bb_endereco";
            this.bb_endereco.Size = new System.Drawing.Size(28, 19);
            this.bb_endereco.TabIndex = 7;
            this.bb_endereco.UseVisualStyleBackColor = true;
            this.bb_endereco.Click += new System.EventHandler(this.bb_endereco_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(3, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 436;
            this.label12.Text = "Endereço:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_endereco
            // 
            this.cd_endereco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Cd_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_endereco.Location = new System.Drawing.Point(74, 57);
            this.cd_endereco.Name = "cd_endereco";
            this.cd_endereco.NM_Alias = "";
            this.cd_endereco.NM_Campo = "cd_endereco";
            this.cd_endereco.NM_CampoBusca = "cd_endereco";
            this.cd_endereco.NM_Param = "@P_CD_CLIFOR";
            this.cd_endereco.QTD_Zero = 0;
            this.cd_endereco.Size = new System.Drawing.Size(75, 20);
            this.cd_endereco.ST_AutoInc = false;
            this.cd_endereco.ST_DisableAuto = false;
            this.cd_endereco.ST_Float = false;
            this.cd_endereco.ST_Gravar = true;
            this.cd_endereco.ST_Int = true;
            this.cd_endereco.ST_LimpaCampo = true;
            this.cd_endereco.ST_NotNull = false;
            this.cd_endereco.ST_PrimaryKey = false;
            this.cd_endereco.TabIndex = 6;
            this.cd_endereco.TextOld = null;
            this.cd_endereco.TextChanged += new System.EventHandler(this.cd_endereco_TextChanged);
            this.cd_endereco.Leave += new System.EventHandler(this.cd_endereco_Leave);
            // 
            // bb_cadclifor
            // 
            this.bb_cadclifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_cadclifor.Image")));
            this.bb_cadclifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cadclifor.Location = new System.Drawing.Point(180, 31);
            this.bb_cadclifor.Name = "bb_cadclifor";
            this.bb_cadclifor.Size = new System.Drawing.Size(28, 20);
            this.bb_cadclifor.TabIndex = 4;
            this.bb_cadclifor.UseVisualStyleBackColor = true;
            this.bb_cadclifor.Click += new System.EventHandler(this.bb_cadclifor_Click);
            // 
            // NM_CompVend
            // 
            this.NM_CompVend.BackColor = System.Drawing.SystemColors.Window;
            this.NM_CompVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_CompVend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_CompVend.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Nm_vendedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_CompVend.Enabled = false;
            this.NM_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_CompVend.Location = new System.Drawing.Point(199, 109);
            this.NM_CompVend.Name = "NM_CompVend";
            this.NM_CompVend.NM_Alias = "";
            this.NM_CompVend.NM_Campo = "nm_clifor";
            this.NM_CompVend.NM_CampoBusca = "nm_clifor";
            this.NM_CompVend.NM_Param = "@P_NOMEVENDEDOR";
            this.NM_CompVend.QTD_Zero = 0;
            this.NM_CompVend.ReadOnly = true;
            this.NM_CompVend.Size = new System.Drawing.Size(577, 20);
            this.NM_CompVend.ST_AutoInc = false;
            this.NM_CompVend.ST_DisableAuto = false;
            this.NM_CompVend.ST_Float = false;
            this.NM_CompVend.ST_Gravar = false;
            this.NM_CompVend.ST_Int = false;
            this.NM_CompVend.ST_LimpaCampo = true;
            this.NM_CompVend.ST_NotNull = false;
            this.NM_CompVend.ST_PrimaryKey = false;
            this.NM_CompVend.TabIndex = 435;
            this.NM_CompVend.TextOld = null;
            // 
            // BB_CompVend
            // 
            this.BB_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_CompVend.Image = ((System.Drawing.Image)(resources.GetObject("BB_CompVend.Image")));
            this.BB_CompVend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CompVend.Location = new System.Drawing.Point(165, 109);
            this.BB_CompVend.Name = "BB_CompVend";
            this.BB_CompVend.Size = new System.Drawing.Size(28, 19);
            this.BB_CompVend.TabIndex = 15;
            this.BB_CompVend.UseVisualStyleBackColor = true;
            this.BB_CompVend.Click += new System.EventHandler(this.BB_CompVend_Click);
            // 
            // CD_CompVend
            // 
            this.CD_CompVend.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CompVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CompVend.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CompVend.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Cd_vendedor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CompVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CompVend.Location = new System.Drawing.Point(74, 109);
            this.CD_CompVend.Name = "CD_CompVend";
            this.CD_CompVend.NM_Alias = "";
            this.CD_CompVend.NM_Campo = "cd_clifor";
            this.CD_CompVend.NM_CampoBusca = "cd_clifor";
            this.CD_CompVend.NM_Param = "@P_CD_CLIFOR";
            this.CD_CompVend.QTD_Zero = 0;
            this.CD_CompVend.Size = new System.Drawing.Size(87, 20);
            this.CD_CompVend.ST_AutoInc = false;
            this.CD_CompVend.ST_DisableAuto = false;
            this.CD_CompVend.ST_Float = false;
            this.CD_CompVend.ST_Gravar = true;
            this.CD_CompVend.ST_Int = true;
            this.CD_CompVend.ST_LimpaCampo = true;
            this.CD_CompVend.ST_NotNull = true;
            this.CD_CompVend.ST_PrimaryKey = false;
            this.CD_CompVend.TabIndex = 14;
            this.CD_CompVend.TextOld = null;
            this.CD_CompVend.Leave += new System.EventHandler(this.CD_CompVend_Leave);
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSize = true;
            this.lblAgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblAgente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAgente.Location = new System.Drawing.Point(3, 113);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(65, 13);
            this.lblAgente.TabIndex = 434;
            this.lblAgente.Text = "Vendedor:";
            this.lblAgente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Nm_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(209, 31);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(567, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = true;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 5;
            this.NM_Clifor.TextOld = null;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(151, 32);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(28, 19);
            this.BB_Clifor.TabIndex = 3;
            this.BB_Clifor.UseVisualStyleBackColor = true;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // lblClifor
            // 
            this.lblClifor.AutoSize = true;
            this.lblClifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblClifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClifor.Location = new System.Drawing.Point(18, 35);
            this.lblClifor.Name = "lblClifor";
            this.lblClifor.Size = new System.Drawing.Size(50, 13);
            this.lblClifor.TabIndex = 433;
            this.lblClifor.Text = "Cliente:";
            this.lblClifor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPreVenda, "Cd_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(74, 31);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.Size = new System.Drawing.Size(75, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = true;
            this.CD_Clifor.ST_Int = true;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 2;
            this.CD_Clifor.TextOld = null;
            this.CD_Clifor.TextChanged += new System.EventHandler(this.CD_Clifor_TextChanged);
            this.CD_Clifor.Leave += new System.EventHandler(this.CD_Clifor_Leave);
            // 
            // TFDadosPreVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(781, 208);
            this.Controls.Add(this.pDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDadosPreVenda";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TFDadosPreVenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDadosPreVenda_KeyDown);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPreVenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsPreVenda;
        private System.Windows.Forms.Button bb_confirma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault proximo;
        private System.Windows.Forms.Label lbprox;
        private Componentes.EditDefault fone;
        private System.Windows.Forms.Label label22;
        private Componentes.EditDefault Bairro;
        private Componentes.EditDefault numero;
        private System.Windows.Forms.Button bb_cadEndereco;
        private Componentes.EditDefault ds_endereco;
        private System.Windows.Forms.Button bb_endereco;
        private System.Windows.Forms.Label label12;
        private Componentes.EditDefault cd_endereco;
        private System.Windows.Forms.Button bb_cadclifor;
        private Componentes.EditDefault NM_CompVend;
        private System.Windows.Forms.Button BB_CompVend;
        private Componentes.EditDefault CD_CompVend;
        private System.Windows.Forms.Label lblAgente;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Label lblClifor;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Button bb_tabelapreco;
        private System.Windows.Forms.Label label66;
        private Componentes.EditDefault CD_TabelaPreco;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditDefault ds_tabelapreco;
        private System.Windows.Forms.Button bb_cancela;
    }
}