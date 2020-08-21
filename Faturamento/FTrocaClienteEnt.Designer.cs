namespace Faturamento
{
    partial class TFTrocaClienteEnt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTrocaClienteEnt));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pEntrega = new Componentes.PanelDados(this.components);
            this.Cd_ufent = new Componentes.EditDefault(this.components);
            this.Tp_pessoaent = new Componentes.EditDefault(this.components);
            this.Cd_enderecoent = new Componentes.EditDefault(this.components);
            this.nm_cliforEnt = new Componentes.EditDefault(this.components);
            this.bb_cliforEnt = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.Cd_cliforent = new Componentes.EditDefault(this.components);
            this.bb_endEntrega = new System.Windows.Forms.Button();
            this.uf_ent = new Componentes.EditDefault(this.components);
            this.ds_cidadeent = new Componentes.EditDefault(this.components);
            this.bb_cidade = new System.Windows.Forms.Button();
            this.cd_cidadent = new Componentes.EditDefault(this.components);
            this.label35 = new System.Windows.Forms.Label();
            this.bairroent = new Componentes.EditDefault(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.complementoent = new Componentes.EditDefault(this.components);
            this.label28 = new System.Windows.Forms.Label();
            this.numeroent = new Componentes.EditDefault(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.logradouroent = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Cd_CondFiscal_Clifor = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pEntrega.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.toolStripSeparator1});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(898, 43);
            this.barraMenu.TabIndex = 9;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // pEntrega
            // 
            this.pEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pEntrega.Controls.Add(this.Cd_CondFiscal_Clifor);
            this.pEntrega.Controls.Add(this.Cd_ufent);
            this.pEntrega.Controls.Add(this.Tp_pessoaent);
            this.pEntrega.Controls.Add(this.Cd_enderecoent);
            this.pEntrega.Controls.Add(this.nm_cliforEnt);
            this.pEntrega.Controls.Add(this.bb_cliforEnt);
            this.pEntrega.Controls.Add(this.label36);
            this.pEntrega.Controls.Add(this.Cd_cliforent);
            this.pEntrega.Controls.Add(this.bb_endEntrega);
            this.pEntrega.Controls.Add(this.uf_ent);
            this.pEntrega.Controls.Add(this.ds_cidadeent);
            this.pEntrega.Controls.Add(this.bb_cidade);
            this.pEntrega.Controls.Add(this.cd_cidadent);
            this.pEntrega.Controls.Add(this.label35);
            this.pEntrega.Controls.Add(this.bairroent);
            this.pEntrega.Controls.Add(this.label34);
            this.pEntrega.Controls.Add(this.complementoent);
            this.pEntrega.Controls.Add(this.label28);
            this.pEntrega.Controls.Add(this.numeroent);
            this.pEntrega.Controls.Add(this.label27);
            this.pEntrega.Controls.Add(this.logradouroent);
            this.pEntrega.Controls.Add(this.label5);
            this.pEntrega.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEntrega.Location = new System.Drawing.Point(0, 43);
            this.pEntrega.Name = "pEntrega";
            this.pEntrega.NM_ProcDeletar = "";
            this.pEntrega.NM_ProcGravar = "";
            this.pEntrega.Size = new System.Drawing.Size(898, 117);
            this.pEntrega.TabIndex = 10;
            // 
            // Cd_ufent
            // 
            this.Cd_ufent.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_ufent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_ufent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_ufent.Enabled = false;
            this.Cd_ufent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cd_ufent.Location = new System.Drawing.Point(818, 82);
            this.Cd_ufent.Name = "Cd_ufent";
            this.Cd_ufent.NM_Alias = "";
            this.Cd_ufent.NM_Campo = "cd_uf";
            this.Cd_ufent.NM_CampoBusca = "cd_uf";
            this.Cd_ufent.NM_Param = "@P_NOMEVENDEDOR";
            this.Cd_ufent.QTD_Zero = 0;
            this.Cd_ufent.ReadOnly = true;
            this.Cd_ufent.Size = new System.Drawing.Size(27, 20);
            this.Cd_ufent.ST_AutoInc = false;
            this.Cd_ufent.ST_DisableAuto = false;
            this.Cd_ufent.ST_Float = false;
            this.Cd_ufent.ST_Gravar = false;
            this.Cd_ufent.ST_Int = false;
            this.Cd_ufent.ST_LimpaCampo = true;
            this.Cd_ufent.ST_NotNull = false;
            this.Cd_ufent.ST_PrimaryKey = false;
            this.Cd_ufent.TabIndex = 418;
            this.Cd_ufent.TextOld = null;
            // 
            // Tp_pessoaent
            // 
            this.Tp_pessoaent.BackColor = System.Drawing.SystemColors.Window;
            this.Tp_pessoaent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tp_pessoaent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Tp_pessoaent.Enabled = false;
            this.Tp_pessoaent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Tp_pessoaent.Location = new System.Drawing.Point(850, 6);
            this.Tp_pessoaent.Name = "Tp_pessoaent";
            this.Tp_pessoaent.NM_Alias = "";
            this.Tp_pessoaent.NM_Campo = "tp_pessoa";
            this.Tp_pessoaent.NM_CampoBusca = "tp_pessoa";
            this.Tp_pessoaent.NM_Param = "@P_NOMEVENDEDOR";
            this.Tp_pessoaent.QTD_Zero = 0;
            this.Tp_pessoaent.ReadOnly = true;
            this.Tp_pessoaent.Size = new System.Drawing.Size(27, 20);
            this.Tp_pessoaent.ST_AutoInc = false;
            this.Tp_pessoaent.ST_DisableAuto = false;
            this.Tp_pessoaent.ST_Float = false;
            this.Tp_pessoaent.ST_Gravar = false;
            this.Tp_pessoaent.ST_Int = false;
            this.Tp_pessoaent.ST_LimpaCampo = true;
            this.Tp_pessoaent.ST_NotNull = false;
            this.Tp_pessoaent.ST_PrimaryKey = false;
            this.Tp_pessoaent.TabIndex = 417;
            this.Tp_pessoaent.TextOld = null;
            // 
            // Cd_enderecoent
            // 
            this.Cd_enderecoent.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_enderecoent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_enderecoent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_enderecoent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cd_enderecoent.Location = new System.Drawing.Point(87, 31);
            this.Cd_enderecoent.Name = "Cd_enderecoent";
            this.Cd_enderecoent.NM_Alias = "";
            this.Cd_enderecoent.NM_Campo = "Endereco";
            this.Cd_enderecoent.NM_CampoBusca = "CD_Endereco";
            this.Cd_enderecoent.NM_Param = "@P_CD_ENDERECO";
            this.Cd_enderecoent.QTD_Zero = 0;
            this.Cd_enderecoent.Size = new System.Drawing.Size(53, 20);
            this.Cd_enderecoent.ST_AutoInc = false;
            this.Cd_enderecoent.ST_DisableAuto = false;
            this.Cd_enderecoent.ST_Float = false;
            this.Cd_enderecoent.ST_Gravar = true;
            this.Cd_enderecoent.ST_Int = true;
            this.Cd_enderecoent.ST_LimpaCampo = true;
            this.Cd_enderecoent.ST_NotNull = true;
            this.Cd_enderecoent.ST_PrimaryKey = false;
            this.Cd_enderecoent.TabIndex = 416;
            this.Cd_enderecoent.TextOld = null;
            this.Cd_enderecoent.Leave += new System.EventHandler(this.Cd_enderecoent_Leave);
            // 
            // nm_cliforEnt
            // 
            this.nm_cliforEnt.BackColor = System.Drawing.SystemColors.Window;
            this.nm_cliforEnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_cliforEnt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_cliforEnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_cliforEnt.Location = new System.Drawing.Point(205, 6);
            this.nm_cliforEnt.Name = "nm_cliforEnt";
            this.nm_cliforEnt.NM_Alias = "";
            this.nm_cliforEnt.NM_Campo = "NM_Clifor";
            this.nm_cliforEnt.NM_CampoBusca = "NM_Clifor";
            this.nm_cliforEnt.NM_Param = "@P_NM_CLIFOR";
            this.nm_cliforEnt.QTD_Zero = 0;
            this.nm_cliforEnt.Size = new System.Drawing.Size(610, 20);
            this.nm_cliforEnt.ST_AutoInc = false;
            this.nm_cliforEnt.ST_DisableAuto = false;
            this.nm_cliforEnt.ST_Float = false;
            this.nm_cliforEnt.ST_Gravar = true;
            this.nm_cliforEnt.ST_Int = false;
            this.nm_cliforEnt.ST_LimpaCampo = true;
            this.nm_cliforEnt.ST_NotNull = true;
            this.nm_cliforEnt.ST_PrimaryKey = false;
            this.nm_cliforEnt.TabIndex = 414;
            this.nm_cliforEnt.TextOld = null;
            // 
            // bb_cliforEnt
            // 
            this.bb_cliforEnt.Image = ((System.Drawing.Image)(resources.GetObject("bb_cliforEnt.Image")));
            this.bb_cliforEnt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cliforEnt.Location = new System.Drawing.Point(171, 6);
            this.bb_cliforEnt.Name = "bb_cliforEnt";
            this.bb_cliforEnt.Size = new System.Drawing.Size(28, 19);
            this.bb_cliforEnt.TabIndex = 413;
            this.bb_cliforEnt.UseVisualStyleBackColor = true;
            this.bb_cliforEnt.Click += new System.EventHandler(this.bb_cliforEnt_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(34, 9);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 13);
            this.label36.TabIndex = 415;
            this.label36.Text = "Cliente:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cd_cliforent
            // 
            this.Cd_cliforent.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_cliforent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_cliforent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_cliforent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cd_cliforent.Location = new System.Drawing.Point(87, 6);
            this.Cd_cliforent.Name = "Cd_cliforent";
            this.Cd_cliforent.NM_Alias = "";
            this.Cd_cliforent.NM_Campo = "Cliente";
            this.Cd_cliforent.NM_CampoBusca = "CD_Clifor";
            this.Cd_cliforent.NM_Param = "@P_CD_CLIFOR";
            this.Cd_cliforent.QTD_Zero = 0;
            this.Cd_cliforent.Size = new System.Drawing.Size(82, 20);
            this.Cd_cliforent.ST_AutoInc = false;
            this.Cd_cliforent.ST_DisableAuto = false;
            this.Cd_cliforent.ST_Float = false;
            this.Cd_cliforent.ST_Gravar = true;
            this.Cd_cliforent.ST_Int = true;
            this.Cd_cliforent.ST_LimpaCampo = true;
            this.Cd_cliforent.ST_NotNull = true;
            this.Cd_cliforent.ST_PrimaryKey = false;
            this.Cd_cliforent.TabIndex = 412;
            this.Cd_cliforent.TextOld = null;
            this.Cd_cliforent.Leave += new System.EventHandler(this.Cd_cliforent_Leave);
            // 
            // bb_endEntrega
            // 
            this.bb_endEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_endEntrega.Image = ((System.Drawing.Image)(resources.GetObject("bb_endEntrega.Image")));
            this.bb_endEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_endEntrega.Location = new System.Drawing.Point(144, 29);
            this.bb_endEntrega.Name = "bb_endEntrega";
            this.bb_endEntrega.Size = new System.Drawing.Size(28, 20);
            this.bb_endEntrega.TabIndex = 393;
            this.bb_endEntrega.UseVisualStyleBackColor = true;
            this.bb_endEntrega.Click += new System.EventHandler(this.bb_endEntrega_Click);
            // 
            // uf_ent
            // 
            this.uf_ent.BackColor = System.Drawing.SystemColors.Window;
            this.uf_ent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uf_ent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.uf_ent.Enabled = false;
            this.uf_ent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.uf_ent.Location = new System.Drawing.Point(850, 82);
            this.uf_ent.Name = "uf_ent";
            this.uf_ent.NM_Alias = "";
            this.uf_ent.NM_Campo = "uf";
            this.uf_ent.NM_CampoBusca = "uf";
            this.uf_ent.NM_Param = "@P_NOMEVENDEDOR";
            this.uf_ent.QTD_Zero = 0;
            this.uf_ent.ReadOnly = true;
            this.uf_ent.Size = new System.Drawing.Size(27, 20);
            this.uf_ent.ST_AutoInc = false;
            this.uf_ent.ST_DisableAuto = false;
            this.uf_ent.ST_Float = false;
            this.uf_ent.ST_Gravar = false;
            this.uf_ent.ST_Int = false;
            this.uf_ent.ST_LimpaCampo = true;
            this.uf_ent.ST_NotNull = false;
            this.uf_ent.ST_PrimaryKey = false;
            this.uf_ent.TabIndex = 392;
            this.uf_ent.TextOld = null;
            // 
            // ds_cidadeent
            // 
            this.ds_cidadeent.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cidadeent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cidadeent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cidadeent.Enabled = false;
            this.ds_cidadeent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_cidadeent.Location = new System.Drawing.Point(208, 82);
            this.ds_cidadeent.Name = "ds_cidadeent";
            this.ds_cidadeent.NM_Alias = "";
            this.ds_cidadeent.NM_Campo = "ds_cidade";
            this.ds_cidadeent.NM_CampoBusca = "ds_cidade";
            this.ds_cidadeent.NM_Param = "@P_NOMEVENDEDOR";
            this.ds_cidadeent.QTD_Zero = 0;
            this.ds_cidadeent.ReadOnly = true;
            this.ds_cidadeent.Size = new System.Drawing.Size(607, 20);
            this.ds_cidadeent.ST_AutoInc = false;
            this.ds_cidadeent.ST_DisableAuto = false;
            this.ds_cidadeent.ST_Float = false;
            this.ds_cidadeent.ST_Gravar = false;
            this.ds_cidadeent.ST_Int = false;
            this.ds_cidadeent.ST_LimpaCampo = true;
            this.ds_cidadeent.ST_NotNull = false;
            this.ds_cidadeent.ST_PrimaryKey = false;
            this.ds_cidadeent.TabIndex = 391;
            this.ds_cidadeent.TextOld = null;
            // 
            // bb_cidade
            // 
            this.bb_cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_cidade.Image = ((System.Drawing.Image)(resources.GetObject("bb_cidade.Image")));
            this.bb_cidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_cidade.Location = new System.Drawing.Point(178, 82);
            this.bb_cidade.Name = "bb_cidade";
            this.bb_cidade.Size = new System.Drawing.Size(28, 20);
            this.bb_cidade.TabIndex = 5;
            this.bb_cidade.UseVisualStyleBackColor = true;
            this.bb_cidade.Click += new System.EventHandler(this.bb_cidade_Click);
            // 
            // cd_cidadent
            // 
            this.cd_cidadent.BackColor = System.Drawing.SystemColors.Window;
            this.cd_cidadent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_cidadent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_cidadent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_cidadent.Location = new System.Drawing.Point(87, 82);
            this.cd_cidadent.Name = "cd_cidadent";
            this.cd_cidadent.NM_Alias = "";
            this.cd_cidadent.NM_Campo = "cd_cidade";
            this.cd_cidadent.NM_CampoBusca = "cd_cidade";
            this.cd_cidadent.NM_Param = "@P_CD_CLIFOR";
            this.cd_cidadent.QTD_Zero = 0;
            this.cd_cidadent.Size = new System.Drawing.Size(87, 20);
            this.cd_cidadent.ST_AutoInc = false;
            this.cd_cidadent.ST_DisableAuto = false;
            this.cd_cidadent.ST_Float = false;
            this.cd_cidadent.ST_Gravar = true;
            this.cd_cidadent.ST_Int = true;
            this.cd_cidadent.ST_LimpaCampo = true;
            this.cd_cidadent.ST_NotNull = false;
            this.cd_cidadent.ST_PrimaryKey = false;
            this.cd_cidadent.TabIndex = 4;
            this.cd_cidadent.TextOld = null;
            this.cd_cidadent.Leave += new System.EventHandler(this.cd_cidadent_Leave);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label35.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label35.Location = new System.Drawing.Point(38, 84);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(43, 13);
            this.label35.TabIndex = 59;
            this.label35.Text = "Cidade:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bairroent
            // 
            this.bairroent.BackColor = System.Drawing.SystemColors.Window;
            this.bairroent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bairroent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bairroent.Location = new System.Drawing.Point(577, 56);
            this.bairroent.Name = "bairroent";
            this.bairroent.NM_Alias = "";
            this.bairroent.NM_Campo = "bairro";
            this.bairroent.NM_CampoBusca = "bairro";
            this.bairroent.NM_Param = "@P_BAIRRO";
            this.bairroent.QTD_Zero = 0;
            this.bairroent.Size = new System.Drawing.Size(300, 20);
            this.bairroent.ST_AutoInc = false;
            this.bairroent.ST_DisableAuto = false;
            this.bairroent.ST_Float = false;
            this.bairroent.ST_Gravar = false;
            this.bairroent.ST_Int = false;
            this.bairroent.ST_LimpaCampo = true;
            this.bairroent.ST_NotNull = false;
            this.bairroent.ST_PrimaryKey = false;
            this.bairroent.TabIndex = 3;
            this.bairroent.TextOld = null;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(536, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(37, 13);
            this.label34.TabIndex = 57;
            this.label34.Text = "Bairro:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // complementoent
            // 
            this.complementoent.BackColor = System.Drawing.SystemColors.Window;
            this.complementoent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.complementoent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.complementoent.Location = new System.Drawing.Point(87, 56);
            this.complementoent.Name = "complementoent";
            this.complementoent.NM_Alias = "";
            this.complementoent.NM_Campo = "ds_complemento";
            this.complementoent.NM_CampoBusca = "ds_complemento";
            this.complementoent.NM_Param = "@P_DS_COMPLEMENTO";
            this.complementoent.QTD_Zero = 0;
            this.complementoent.Size = new System.Drawing.Size(443, 20);
            this.complementoent.ST_AutoInc = false;
            this.complementoent.ST_DisableAuto = false;
            this.complementoent.ST_Float = false;
            this.complementoent.ST_Gravar = false;
            this.complementoent.ST_Int = false;
            this.complementoent.ST_LimpaCampo = true;
            this.complementoent.ST_NotNull = false;
            this.complementoent.ST_PrimaryKey = false;
            this.complementoent.TabIndex = 2;
            this.complementoent.TextOld = null;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(7, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 13);
            this.label28.TabIndex = 55;
            this.label28.Text = "Complemento:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numeroent
            // 
            this.numeroent.BackColor = System.Drawing.SystemColors.Window;
            this.numeroent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numeroent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.numeroent.Location = new System.Drawing.Point(772, 30);
            this.numeroent.Name = "numeroent";
            this.numeroent.NM_Alias = "";
            this.numeroent.NM_Campo = "numero";
            this.numeroent.NM_CampoBusca = "numero";
            this.numeroent.NM_Param = "@P_NUMERO";
            this.numeroent.QTD_Zero = 0;
            this.numeroent.Size = new System.Drawing.Size(105, 20);
            this.numeroent.ST_AutoInc = false;
            this.numeroent.ST_DisableAuto = false;
            this.numeroent.ST_Float = false;
            this.numeroent.ST_Gravar = false;
            this.numeroent.ST_Int = false;
            this.numeroent.ST_LimpaCampo = true;
            this.numeroent.ST_NotNull = false;
            this.numeroent.ST_PrimaryKey = false;
            this.numeroent.TabIndex = 1;
            this.numeroent.TextOld = null;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(719, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 13);
            this.label27.TabIndex = 53;
            this.label27.Text = "Numero:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // logradouroent
            // 
            this.logradouroent.BackColor = System.Drawing.SystemColors.Window;
            this.logradouroent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logradouroent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.logradouroent.Location = new System.Drawing.Point(174, 30);
            this.logradouroent.Name = "logradouroent";
            this.logradouroent.NM_Alias = "";
            this.logradouroent.NM_Campo = "ds_endereco";
            this.logradouroent.NM_CampoBusca = "ds_endereco";
            this.logradouroent.NM_Param = "@P_DS_ENDERECO";
            this.logradouroent.QTD_Zero = 0;
            this.logradouroent.Size = new System.Drawing.Size(539, 20);
            this.logradouroent.ST_AutoInc = false;
            this.logradouroent.ST_DisableAuto = false;
            this.logradouroent.ST_Float = false;
            this.logradouroent.ST_Gravar = false;
            this.logradouroent.ST_Int = false;
            this.logradouroent.ST_LimpaCampo = true;
            this.logradouroent.ST_NotNull = false;
            this.logradouroent.ST_PrimaryKey = false;
            this.logradouroent.TabIndex = 0;
            this.logradouroent.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(17, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 51;
            this.label5.Text = "Logradouro:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cd_CondFiscal_Clifor
            // 
            this.Cd_CondFiscal_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_CondFiscal_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_CondFiscal_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_CondFiscal_Clifor.Enabled = false;
            this.Cd_CondFiscal_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cd_CondFiscal_Clifor.Location = new System.Drawing.Point(820, 6);
            this.Cd_CondFiscal_Clifor.Name = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_Alias = "";
            this.Cd_CondFiscal_Clifor.NM_Campo = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_CampoBusca = "Cd_CondFiscal_Clifor";
            this.Cd_CondFiscal_Clifor.NM_Param = "@P_NOMEVENDEDOR";
            this.Cd_CondFiscal_Clifor.QTD_Zero = 0;
            this.Cd_CondFiscal_Clifor.ReadOnly = true;
            this.Cd_CondFiscal_Clifor.Size = new System.Drawing.Size(27, 20);
            this.Cd_CondFiscal_Clifor.ST_AutoInc = false;
            this.Cd_CondFiscal_Clifor.ST_DisableAuto = false;
            this.Cd_CondFiscal_Clifor.ST_Float = false;
            this.Cd_CondFiscal_Clifor.ST_Gravar = false;
            this.Cd_CondFiscal_Clifor.ST_Int = false;
            this.Cd_CondFiscal_Clifor.ST_LimpaCampo = true;
            this.Cd_CondFiscal_Clifor.ST_NotNull = false;
            this.Cd_CondFiscal_Clifor.ST_PrimaryKey = false;
            this.Cd_CondFiscal_Clifor.TabIndex = 419;
            this.Cd_CondFiscal_Clifor.TextOld = null;
            // 
            // TFTrocaClienteEnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 160);
            this.Controls.Add(this.pEntrega);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTrocaClienteEnt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trocar Cliente Entrega - REMESSA P/ TRANSPORTE";
            this.Load += new System.EventHandler(this.TFTrocaClienteEnt_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pEntrega.ResumeLayout(false);
            this.pEntrega.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Componentes.PanelDados pEntrega;
        private Componentes.EditDefault Tp_pessoaent;
        private Componentes.EditDefault Cd_enderecoent;
        private Componentes.EditDefault nm_cliforEnt;
        private System.Windows.Forms.Button bb_cliforEnt;
        private System.Windows.Forms.Label label36;
        private Componentes.EditDefault Cd_cliforent;
        private System.Windows.Forms.Button bb_endEntrega;
        private Componentes.EditDefault uf_ent;
        private Componentes.EditDefault ds_cidadeent;
        private System.Windows.Forms.Button bb_cidade;
        private Componentes.EditDefault cd_cidadent;
        private System.Windows.Forms.Label label35;
        private Componentes.EditDefault bairroent;
        private System.Windows.Forms.Label label34;
        private Componentes.EditDefault complementoent;
        private System.Windows.Forms.Label label28;
        private Componentes.EditDefault numeroent;
        private System.Windows.Forms.Label label27;
        private Componentes.EditDefault logradouroent;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault Cd_ufent;
        private Componentes.EditDefault Cd_CondFiscal_Clifor;
    }
}