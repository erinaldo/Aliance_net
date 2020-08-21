namespace Locacao
{
    partial class TFAltEndEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAltEndEntrega));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsLocacao = new System.Windows.Forms.BindingSource(this.components);
            this.pEndereco = new Componentes.PanelDados(this.components);
            this.BB_Cidade = new System.Windows.Forms.Button();
            this.LB_CD_Cidade = new System.Windows.Forms.Label();
            this.LB_Proximo = new System.Windows.Forms.Label();
            this.LB_Bairro = new System.Windows.Forms.Label();
            this.LB_DS_Complemento = new System.Windows.Forms.Label();
            this.LB_DS_Endereco = new System.Windows.Forms.Label();
            this.LB_Numero = new System.Windows.Forms.Label();
            this.LB_Cep = new System.Windows.Forms.Label();
            this.UF = new Componentes.EditDefault(this.components);
            this.Ds_Cidade = new Componentes.EditDefault(this.components);
            this.CD_Cidade = new Componentes.EditDefault(this.components);
            this.Proximo = new Componentes.EditDefault(this.components);
            this.DS_Complemento = new Componentes.EditDefault(this.components);
            this.Bairro = new Componentes.EditDefault(this.components);
            this.Numero = new Componentes.EditDefault(this.components);
            this.Ds_end = new Componentes.EditDefault(this.components);
            this.Cep = new Componentes.EditMask(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocacao)).BeginInit();
            this.pEndereco.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(697, 43);
            this.barraMenu.TabIndex = 13;
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
            // bsLocacao
            // 
            this.bsLocacao.DataSource = typeof(CamadaDados.Locacao.TList_Locacao);
            // 
            // pEndereco
            // 
            this.pEndereco.Controls.Add(this.BB_Cidade);
            this.pEndereco.Controls.Add(this.LB_CD_Cidade);
            this.pEndereco.Controls.Add(this.LB_Proximo);
            this.pEndereco.Controls.Add(this.LB_Bairro);
            this.pEndereco.Controls.Add(this.LB_DS_Complemento);
            this.pEndereco.Controls.Add(this.LB_DS_Endereco);
            this.pEndereco.Controls.Add(this.LB_Numero);
            this.pEndereco.Controls.Add(this.LB_Cep);
            this.pEndereco.Controls.Add(this.UF);
            this.pEndereco.Controls.Add(this.Ds_Cidade);
            this.pEndereco.Controls.Add(this.CD_Cidade);
            this.pEndereco.Controls.Add(this.Proximo);
            this.pEndereco.Controls.Add(this.DS_Complemento);
            this.pEndereco.Controls.Add(this.Bairro);
            this.pEndereco.Controls.Add(this.Numero);
            this.pEndereco.Controls.Add(this.Ds_end);
            this.pEndereco.Controls.Add(this.Cep);
            this.pEndereco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEndereco.Location = new System.Drawing.Point(0, 43);
            this.pEndereco.Name = "pEndereco";
            this.pEndereco.NM_ProcDeletar = "";
            this.pEndereco.NM_ProcGravar = "";
            this.pEndereco.Size = new System.Drawing.Size(697, 119);
            this.pEndereco.TabIndex = 14;
            // 
            // BB_Cidade
            // 
            this.BB_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Ds_cidadeEnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.BB_Cidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cidade.Image")));
            this.BB_Cidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Cidade.Location = new System.Drawing.Point(154, 64);
            this.BB_Cidade.Name = "BB_Cidade";
            this.BB_Cidade.Size = new System.Drawing.Size(30, 20);
            this.BB_Cidade.TabIndex = 6;
            this.BB_Cidade.UseVisualStyleBackColor = true;
            this.BB_Cidade.Click += new System.EventHandler(this.BB_Cidade_Click);
            // 
            // LB_CD_Cidade
            // 
            this.LB_CD_Cidade.AutoSize = true;
            this.LB_CD_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Cidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Cidade.Location = new System.Drawing.Point(16, 68);
            this.LB_CD_Cidade.Name = "LB_CD_Cidade";
            this.LB_CD_Cidade.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Cidade.TabIndex = 572;
            this.LB_CD_Cidade.Text = "Cidade:";
            this.LB_CD_Cidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Proximo
            // 
            this.LB_Proximo.AutoSize = true;
            this.LB_Proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Proximo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Proximo.Location = new System.Drawing.Point(12, 93);
            this.LB_Proximo.Name = "LB_Proximo";
            this.LB_Proximo.Size = new System.Drawing.Size(47, 13);
            this.LB_Proximo.TabIndex = 569;
            this.LB_Proximo.Text = "Próximo:";
            this.LB_Proximo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Bairro
            // 
            this.LB_Bairro.AutoSize = true;
            this.LB_Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Bairro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Bairro.Location = new System.Drawing.Point(21, 41);
            this.LB_Bairro.Name = "LB_Bairro";
            this.LB_Bairro.Size = new System.Drawing.Size(37, 13);
            this.LB_Bairro.TabIndex = 566;
            this.LB_Bairro.Text = "Bairro:";
            this.LB_Bairro.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_DS_Complemento
            // 
            this.LB_DS_Complemento.AutoSize = true;
            this.LB_DS_Complemento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Complemento.Location = new System.Drawing.Point(360, 41);
            this.LB_DS_Complemento.Name = "LB_DS_Complemento";
            this.LB_DS_Complemento.Size = new System.Drawing.Size(42, 13);
            this.LB_DS_Complemento.TabIndex = 567;
            this.LB_DS_Complemento.Text = "Compl.:";
            this.LB_DS_Complemento.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_DS_Endereco
            // 
            this.LB_DS_Endereco.AutoSize = true;
            this.LB_DS_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Endereco.Location = new System.Drawing.Point(134, 15);
            this.LB_DS_Endereco.Name = "LB_DS_Endereco";
            this.LB_DS_Endereco.Size = new System.Drawing.Size(56, 13);
            this.LB_DS_Endereco.TabIndex = 562;
            this.LB_DS_Endereco.Text = "Endereço:";
            this.LB_DS_Endereco.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Numero
            // 
            this.LB_Numero.AutoSize = true;
            this.LB_Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Numero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Numero.Location = new System.Drawing.Point(596, 15);
            this.LB_Numero.Name = "LB_Numero";
            this.LB_Numero.Size = new System.Drawing.Size(22, 13);
            this.LB_Numero.TabIndex = 563;
            this.LB_Numero.Text = "Nº:";
            this.LB_Numero.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Cep
            // 
            this.LB_Cep.AutoSize = true;
            this.LB_Cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Cep.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Cep.Location = new System.Drawing.Point(27, 15);
            this.LB_Cep.Name = "LB_Cep";
            this.LB_Cep.Size = new System.Drawing.Size(31, 13);
            this.LB_Cep.TabIndex = 561;
            this.LB_Cep.Text = "CEP:";
            this.LB_Cep.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UF
            // 
            this.UF.BackColor = System.Drawing.SystemColors.Window;
            this.UF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "UFEnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UF.Enabled = false;
            this.UF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.UF.Location = new System.Drawing.Point(648, 65);
            this.UF.Name = "UF";
            this.UF.NM_Alias = "";
            this.UF.NM_Campo = "UF";
            this.UF.NM_CampoBusca = "UF";
            this.UF.NM_Param = "@P_UF";
            this.UF.QTD_Zero = 0;
            this.UF.Size = new System.Drawing.Size(41, 20);
            this.UF.ST_AutoInc = false;
            this.UF.ST_DisableAuto = false;
            this.UF.ST_Float = false;
            this.UF.ST_Gravar = false;
            this.UF.ST_Int = false;
            this.UF.ST_LimpaCampo = true;
            this.UF.ST_NotNull = false;
            this.UF.ST_PrimaryKey = false;
            this.UF.TabIndex = 574;
            this.UF.TextOld = null;
            // 
            // Ds_Cidade
            // 
            this.Ds_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Cidade.Enabled = false;
            this.Ds_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Ds_Cidade.Location = new System.Drawing.Point(187, 65);
            this.Ds_Cidade.Name = "Ds_Cidade";
            this.Ds_Cidade.NM_Alias = "";
            this.Ds_Cidade.NM_Campo = "Ds_Cidade";
            this.Ds_Cidade.NM_CampoBusca = "Ds_Cidade";
            this.Ds_Cidade.NM_Param = "@P_DS_CIDADE";
            this.Ds_Cidade.QTD_Zero = 0;
            this.Ds_Cidade.Size = new System.Drawing.Size(458, 20);
            this.Ds_Cidade.ST_AutoInc = false;
            this.Ds_Cidade.ST_DisableAuto = false;
            this.Ds_Cidade.ST_Float = false;
            this.Ds_Cidade.ST_Gravar = false;
            this.Ds_Cidade.ST_Int = false;
            this.Ds_Cidade.ST_LimpaCampo = true;
            this.Ds_Cidade.ST_NotNull = false;
            this.Ds_Cidade.ST_PrimaryKey = false;
            this.Ds_Cidade.TabIndex = 573;
            this.Ds_Cidade.TextOld = null;
            // 
            // CD_Cidade
            // 
            this.CD_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Cd_cidadeEnt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Cidade.Location = new System.Drawing.Point(64, 65);
            this.CD_Cidade.Name = "CD_Cidade";
            this.CD_Cidade.NM_Alias = "a";
            this.CD_Cidade.NM_Campo = "CD_Cidade";
            this.CD_Cidade.NM_CampoBusca = "CD_Cidade";
            this.CD_Cidade.NM_Param = "@P_CD_CIDADE";
            this.CD_Cidade.QTD_Zero = 0;
            this.CD_Cidade.Size = new System.Drawing.Size(88, 20);
            this.CD_Cidade.ST_AutoInc = false;
            this.CD_Cidade.ST_DisableAuto = false;
            this.CD_Cidade.ST_Float = false;
            this.CD_Cidade.ST_Gravar = true;
            this.CD_Cidade.ST_Int = false;
            this.CD_Cidade.ST_LimpaCampo = true;
            this.CD_Cidade.ST_NotNull = true;
            this.CD_Cidade.ST_PrimaryKey = false;
            this.CD_Cidade.TabIndex = 5;
            this.CD_Cidade.TextOld = null;
            this.CD_Cidade.Leave += new System.EventHandler(this.CD_Cidade_Leave);
            // 
            // Proximo
            // 
            this.Proximo.BackColor = System.Drawing.SystemColors.Window;
            this.Proximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Proximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Proximo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Proximo_Ent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Proximo.Location = new System.Drawing.Point(65, 91);
            this.Proximo.Name = "Proximo";
            this.Proximo.NM_Alias = "a";
            this.Proximo.NM_Campo = "Proximo";
            this.Proximo.NM_CampoBusca = "Proximo";
            this.Proximo.NM_Param = "@P_PROXIMO";
            this.Proximo.QTD_Zero = 0;
            this.Proximo.Size = new System.Drawing.Size(624, 20);
            this.Proximo.ST_AutoInc = false;
            this.Proximo.ST_DisableAuto = false;
            this.Proximo.ST_Float = false;
            this.Proximo.ST_Gravar = true;
            this.Proximo.ST_Int = false;
            this.Proximo.ST_LimpaCampo = true;
            this.Proximo.ST_NotNull = false;
            this.Proximo.ST_PrimaryKey = false;
            this.Proximo.TabIndex = 7;
            this.Proximo.TextOld = null;
            // 
            // DS_Complemento
            // 
            this.DS_Complemento.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Complemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Complemento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Complemento_Ent", true));
            this.DS_Complemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Complemento.Location = new System.Drawing.Point(408, 39);
            this.DS_Complemento.Name = "DS_Complemento";
            this.DS_Complemento.NM_Alias = "a";
            this.DS_Complemento.NM_Campo = "DS_Complemento";
            this.DS_Complemento.NM_CampoBusca = "DS_Complemento";
            this.DS_Complemento.NM_Param = "@P_DS_COMPLEMENTO";
            this.DS_Complemento.QTD_Zero = 0;
            this.DS_Complemento.Size = new System.Drawing.Size(281, 20);
            this.DS_Complemento.ST_AutoInc = false;
            this.DS_Complemento.ST_DisableAuto = false;
            this.DS_Complemento.ST_Float = false;
            this.DS_Complemento.ST_Gravar = true;
            this.DS_Complemento.ST_Int = false;
            this.DS_Complemento.ST_LimpaCampo = true;
            this.DS_Complemento.ST_NotNull = false;
            this.DS_Complemento.ST_PrimaryKey = false;
            this.DS_Complemento.TabIndex = 4;
            this.DS_Complemento.TextOld = null;
            // 
            // Bairro
            // 
            this.Bairro.BackColor = System.Drawing.SystemColors.Window;
            this.Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Bairro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Bairro_Ent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Bairro.Location = new System.Drawing.Point(64, 39);
            this.Bairro.Name = "Bairro";
            this.Bairro.NM_Alias = "a";
            this.Bairro.NM_Campo = "Bairro";
            this.Bairro.NM_CampoBusca = "Bairro";
            this.Bairro.NM_Param = "@P_BAIRRO";
            this.Bairro.QTD_Zero = 0;
            this.Bairro.Size = new System.Drawing.Size(284, 20);
            this.Bairro.ST_AutoInc = false;
            this.Bairro.ST_DisableAuto = false;
            this.Bairro.ST_Float = false;
            this.Bairro.ST_Gravar = true;
            this.Bairro.ST_Int = false;
            this.Bairro.ST_LimpaCampo = true;
            this.Bairro.ST_NotNull = true;
            this.Bairro.ST_PrimaryKey = false;
            this.Bairro.TabIndex = 3;
            this.Bairro.TextOld = null;
            // 
            // Numero
            // 
            this.Numero.BackColor = System.Drawing.SystemColors.Window;
            this.Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Numero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Numero_Ent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Numero.Location = new System.Drawing.Point(624, 12);
            this.Numero.Name = "Numero";
            this.Numero.NM_Alias = "a";
            this.Numero.NM_Campo = "Numero";
            this.Numero.NM_CampoBusca = "Numero";
            this.Numero.NM_Param = "@P_NUMERO";
            this.Numero.QTD_Zero = 0;
            this.Numero.Size = new System.Drawing.Size(65, 20);
            this.Numero.ST_AutoInc = false;
            this.Numero.ST_DisableAuto = false;
            this.Numero.ST_Float = false;
            this.Numero.ST_Gravar = true;
            this.Numero.ST_Int = false;
            this.Numero.ST_LimpaCampo = true;
            this.Numero.ST_NotNull = true;
            this.Numero.ST_PrimaryKey = false;
            this.Numero.TabIndex = 2;
            this.Numero.TextOld = null;
            // 
            // Ds_end
            // 
            this.Ds_end.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_end.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_end.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Logradouro_Ent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Ds_end.Location = new System.Drawing.Point(196, 12);
            this.Ds_end.Name = "Ds_end";
            this.Ds_end.NM_Alias = "a";
            this.Ds_end.NM_Campo = "DS_Endereco";
            this.Ds_end.NM_CampoBusca = "DS_Endereco";
            this.Ds_end.NM_Param = "@P_DS_ENDERECO";
            this.Ds_end.QTD_Zero = 0;
            this.Ds_end.Size = new System.Drawing.Size(394, 20);
            this.Ds_end.ST_AutoInc = false;
            this.Ds_end.ST_DisableAuto = false;
            this.Ds_end.ST_Float = false;
            this.Ds_end.ST_Gravar = true;
            this.Ds_end.ST_Int = false;
            this.Ds_end.ST_LimpaCampo = true;
            this.Ds_end.ST_NotNull = true;
            this.Ds_end.ST_PrimaryKey = false;
            this.Ds_end.TabIndex = 1;
            this.Ds_end.TextOld = null;
            // 
            // Cep
            // 
            this.Cep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(220)))), ((int)(((byte)(169)))));
            this.Cep.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLocacao, "Cep_Ent", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cep.Location = new System.Drawing.Point(64, 12);
            this.Cep.Mask = "00.000-000";
            this.Cep.Name = "Cep";
            this.Cep.NM_Alias = "a";
            this.Cep.NM_Campo = "Cep";
            this.Cep.NM_CampoBusca = "Cep";
            this.Cep.NM_Param = "@P_CEP";
            this.Cep.Size = new System.Drawing.Size(64, 20);
            this.Cep.ST_Gravar = true;
            this.Cep.ST_LimpaCampo = true;
            this.Cep.ST_NotNull = false;
            this.Cep.ST_PrimaryKey = false;
            this.Cep.TabIndex = 0;
            this.Cep.Leave += new System.EventHandler(this.Cep_Leave);
            // 
            // TFAltEndEntrega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 162);
            this.Controls.Add(this.pEndereco);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAltEndEntrega";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Endereço Entrega";
            this.Load += new System.EventHandler(this.TFAltEndEntrega_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAltEndEntrega_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocacao)).EndInit();
            this.pEndereco.ResumeLayout(false);
            this.pEndereco.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.BindingSource bsLocacao;
        private Componentes.PanelDados pEndereco;
        private System.Windows.Forms.Button BB_Cidade;
        private System.Windows.Forms.Label LB_CD_Cidade;
        private System.Windows.Forms.Label LB_Proximo;
        private System.Windows.Forms.Label LB_Bairro;
        private System.Windows.Forms.Label LB_DS_Complemento;
        private System.Windows.Forms.Label LB_DS_Endereco;
        private System.Windows.Forms.Label LB_Numero;
        private System.Windows.Forms.Label LB_Cep;
        private Componentes.EditDefault UF;
        private Componentes.EditDefault Ds_Cidade;
        private Componentes.EditDefault CD_Cidade;
        private Componentes.EditDefault Proximo;
        private Componentes.EditDefault DS_Complemento;
        private Componentes.EditDefault Bairro;
        private Componentes.EditDefault Numero;
        private Componentes.EditDefault Ds_end;
        private Componentes.EditMask Cep;
    }
}