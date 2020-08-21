namespace Proc_Commoditties
{
    partial class TFAbrirCaixaPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAbrirCaixaPDV));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.bb_login = new System.Windows.Forms.Button();
            this.login = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ds_complemento = new Componentes.EditDefault(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.ds_contadest = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_contadest = new Componentes.EditDefault(this.components);
            this.ds_contaorig = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_contaorig = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.vl_transf = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_transf)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(615, 43);
            this.barraMenu.TabIndex = 8;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Size = new System.Drawing.Size(615, 218);
            this.tlpCentral.TabIndex = 9;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.bb_login);
            this.pDados.Controls.Add(this.login);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.vl_transf);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_complemento);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.ds_contadest);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_contadest);
            this.pDados.Controls.Add(this.ds_contaorig);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_contaorig);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.lbl);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Location = new System.Drawing.Point(4, 4);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(607, 209);
            this.pDados.TabIndex = 0;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(141, 4);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // bb_login
            // 
            this.bb_login.Image = ((System.Drawing.Image)(resources.GetObject("bb_login.Image")));
            this.bb_login.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_login.Location = new System.Drawing.Point(571, 3);
            this.bb_login.Name = "bb_login";
            this.bb_login.Size = new System.Drawing.Size(28, 20);
            this.bb_login.TabIndex = 3;
            this.bb_login.UseVisualStyleBackColor = true;
            this.bb_login.Click += new System.EventHandler(this.bb_login_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Window;
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.login.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.login.Location = new System.Drawing.Point(458, 3);
            this.login.Name = "login";
            this.login.NM_Alias = "";
            this.login.NM_Campo = "login";
            this.login.NM_CampoBusca = "login";
            this.login.NM_Param = "@P_CD_EMPRESA";
            this.login.QTD_Zero = 0;
            this.login.Size = new System.Drawing.Size(112, 20);
            this.login.ST_AutoInc = false;
            this.login.ST_DisableAuto = false;
            this.login.ST_Float = false;
            this.login.ST_Gravar = true;
            this.login.ST_Int = false;
            this.login.ST_LimpaCampo = true;
            this.login.ST_NotNull = true;
            this.login.ST_PrimaryKey = false;
            this.login.TabIndex = 2;
            this.login.TextOld = null;
            this.login.Leave += new System.EventHandler(this.login_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(421, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 100;
            this.label6.Text = "Login:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 97;
            this.label4.Text = "Complemento:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_complemento
            // 
            this.ds_complemento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_complemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_complemento.Location = new System.Drawing.Point(86, 108);
            this.ds_complemento.Multiline = true;
            this.ds_complemento.Name = "ds_complemento";
            this.ds_complemento.NM_Alias = "";
            this.ds_complemento.NM_Campo = "";
            this.ds_complemento.NM_CampoBusca = "";
            this.ds_complemento.NM_Param = "";
            this.ds_complemento.QTD_Zero = 0;
            this.ds_complemento.Size = new System.Drawing.Size(513, 63);
            this.ds_complemento.ST_AutoInc = false;
            this.ds_complemento.ST_DisableAuto = false;
            this.ds_complemento.ST_Float = false;
            this.ds_complemento.ST_Gravar = false;
            this.ds_complemento.ST_Int = false;
            this.ds_complemento.ST_LimpaCampo = true;
            this.ds_complemento.ST_NotNull = false;
            this.ds_complemento.ST_PrimaryKey = false;
            this.ds_complemento.TabIndex = 4;
            this.ds_complemento.TextOld = null;
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(142, 56);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_pdv";
            this.ds_historico.NM_CampoBusca = "ds_pdv";
            this.ds_historico.NM_Param = "@P_DS_PDV";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(457, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 95;
            this.ds_historico.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(29, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Historico:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.Enabled = false;
            this.cd_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_historico.Location = new System.Drawing.Point(86, 56);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "id_pdv";
            this.cd_historico.NM_CampoBusca = "id_pdv";
            this.cd_historico.NM_Param = "@P_CD_EMPRESA";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(53, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = true;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 93;
            this.cd_historico.TextOld = null;
            // 
            // ds_contadest
            // 
            this.ds_contadest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contadest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contadest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contadest.Enabled = false;
            this.ds_contadest.Location = new System.Drawing.Point(142, 30);
            this.ds_contadest.Name = "ds_contadest";
            this.ds_contadest.NM_Alias = "";
            this.ds_contadest.NM_Campo = "ds_contager";
            this.ds_contadest.NM_CampoBusca = "ds_contager";
            this.ds_contadest.NM_Param = "@P_DS_PDV";
            this.ds_contadest.QTD_Zero = 0;
            this.ds_contadest.Size = new System.Drawing.Size(457, 20);
            this.ds_contadest.ST_AutoInc = false;
            this.ds_contadest.ST_DisableAuto = false;
            this.ds_contadest.ST_Float = false;
            this.ds_contadest.ST_Gravar = false;
            this.ds_contadest.ST_Int = false;
            this.ds_contadest.ST_LimpaCampo = true;
            this.ds_contadest.ST_NotNull = false;
            this.ds_contadest.ST_PrimaryKey = false;
            this.ds_contadest.TabIndex = 92;
            this.ds_contadest.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Conta Destino:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_contadest
            // 
            this.cd_contadest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contadest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contadest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contadest.Enabled = false;
            this.cd_contadest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contadest.Location = new System.Drawing.Point(86, 30);
            this.cd_contadest.Name = "cd_contadest";
            this.cd_contadest.NM_Alias = "";
            this.cd_contadest.NM_Campo = "cd_contager";
            this.cd_contadest.NM_CampoBusca = "cd_contager";
            this.cd_contadest.NM_Param = "@P_CD_EMPRESA";
            this.cd_contadest.QTD_Zero = 0;
            this.cd_contadest.Size = new System.Drawing.Size(53, 20);
            this.cd_contadest.ST_AutoInc = false;
            this.cd_contadest.ST_DisableAuto = false;
            this.cd_contadest.ST_Float = false;
            this.cd_contadest.ST_Gravar = true;
            this.cd_contadest.ST_Int = true;
            this.cd_contadest.ST_LimpaCampo = true;
            this.cd_contadest.ST_NotNull = true;
            this.cd_contadest.ST_PrimaryKey = false;
            this.cd_contadest.TabIndex = 90;
            this.cd_contadest.TextOld = null;
            // 
            // ds_contaorig
            // 
            this.ds_contaorig.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contaorig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contaorig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contaorig.Enabled = false;
            this.ds_contaorig.Location = new System.Drawing.Point(142, 82);
            this.ds_contaorig.Name = "ds_contaorig";
            this.ds_contaorig.NM_Alias = "";
            this.ds_contaorig.NM_Campo = "ds_pdv";
            this.ds_contaorig.NM_CampoBusca = "ds_pdv";
            this.ds_contaorig.NM_Param = "@P_DS_PDV";
            this.ds_contaorig.QTD_Zero = 0;
            this.ds_contaorig.Size = new System.Drawing.Size(457, 20);
            this.ds_contaorig.ST_AutoInc = false;
            this.ds_contaorig.ST_DisableAuto = false;
            this.ds_contaorig.ST_Float = false;
            this.ds_contaorig.ST_Gravar = false;
            this.ds_contaorig.ST_Int = false;
            this.ds_contaorig.ST_LimpaCampo = true;
            this.ds_contaorig.ST_NotNull = false;
            this.ds_contaorig.ST_PrimaryKey = false;
            this.ds_contaorig.TabIndex = 89;
            this.ds_contaorig.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "Conta Origem:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_contaorig
            // 
            this.cd_contaorig.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contaorig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contaorig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contaorig.Enabled = false;
            this.cd_contaorig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contaorig.Location = new System.Drawing.Point(86, 82);
            this.cd_contaorig.Name = "cd_contaorig";
            this.cd_contaorig.NM_Alias = "";
            this.cd_contaorig.NM_Campo = "id_pdv";
            this.cd_contaorig.NM_CampoBusca = "id_pdv";
            this.cd_contaorig.NM_Param = "@P_CD_EMPRESA";
            this.cd_contaorig.QTD_Zero = 0;
            this.cd_contaorig.Size = new System.Drawing.Size(53, 20);
            this.cd_contaorig.ST_AutoInc = false;
            this.cd_contaorig.ST_DisableAuto = false;
            this.cd_contaorig.ST_Float = false;
            this.cd_contaorig.ST_Gravar = true;
            this.cd_contaorig.ST_Int = true;
            this.cd_contaorig.ST_LimpaCampo = true;
            this.cd_contaorig.ST_NotNull = true;
            this.cd_contaorig.ST_PrimaryKey = false;
            this.cd_contaorig.TabIndex = 87;
            this.cd_contaorig.TextOld = null;
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(175, 4);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_DS_PDV";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(240, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 86;
            this.nm_empresa.TextOld = null;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(29, 7);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(51, 13);
            this.lbl.TabIndex = 85;
            this.lbl.Text = "Empresa:";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(86, 4);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(53, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // vl_transf
            // 
            this.vl_transf.DecimalPlaces = 2;
            this.vl_transf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_transf.Location = new System.Drawing.Point(86, 177);
            this.vl_transf.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_transf.Name = "vl_transf";
            this.vl_transf.NM_Alias = "";
            this.vl_transf.NM_Campo = "";
            this.vl_transf.NM_Param = "";
            this.vl_transf.Operador = "";
            this.vl_transf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_transf.Size = new System.Drawing.Size(147, 26);
            this.vl_transf.ST_AutoInc = false;
            this.vl_transf.ST_DisableAuto = false;
            this.vl_transf.ST_Gravar = false;
            this.vl_transf.ST_LimparCampo = true;
            this.vl_transf.ST_NotNull = false;
            this.vl_transf.ST_PrimaryKey = false;
            this.vl_transf.TabIndex = 5;
            this.vl_transf.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(46, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Valor:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFAbrirCaixaPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 261);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAbrirCaixaPDV";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrir Caixa PDV (Ponto Venda)";
            this.Load += new System.EventHandler(this.TFAbrirCaixaPDV_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAbrirCaixaPDV_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_transf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_contadest;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_contadest;
        private Componentes.EditDefault ds_contaorig;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_contaorig;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Label lbl;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_historico;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_complemento;
        private System.Windows.Forms.Button bb_login;
        private Componentes.EditDefault login;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat vl_transf;
    }
}