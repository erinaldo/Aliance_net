namespace Commoditties
{
    partial class TFDesdobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDesdobro));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bsDesdobro = new System.Windows.Forms.BindingSource(this.components);
            this.pValor = new Componentes.PanelDados(this.components);
            this.valor_desdobro = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_tpdesdobro = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bb_tpdesdobro = new System.Windows.Forms.Button();
            this.id_tpdesdobro = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ds_produtodest = new Componentes.EditDefault(this.components);
            this.cd_produtodest = new Componentes.EditDefault(this.components);
            this.CD_Clifor = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_contratodest = new System.Windows.Forms.Button();
            this.nr_contratodest = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobro)).BeginInit();
            this.pValor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor_desdobro)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(705, 43);
            this.barraMenu.TabIndex = 14;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.pValor);
            this.pDados.Controls.Add(this.ds_tpdesdobro);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_tpdesdobro);
            this.pDados.Controls.Add(this.id_tpdesdobro);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_produtodest);
            this.pDados.Controls.Add(this.cd_produtodest);
            this.pDados.Controls.Add(this.CD_Clifor);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_contratodest);
            this.pDados.Controls.Add(this.nr_contratodest);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(705, 150);
            this.pDados.TabIndex = 15;
            // 
            // bsDesdobro
            // 
            this.bsDesdobro.DataSource = typeof(CamadaDados.Graos.TList_Contrato_X_DesdEspecial);
            // 
            // pValor
            // 
            this.pValor.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pValor.Controls.Add(this.valor_desdobro);
            this.pValor.Controls.Add(this.label7);
            this.pValor.Location = new System.Drawing.Point(99, 106);
            this.pValor.Name = "pValor";
            this.pValor.NM_ProcDeletar = "";
            this.pValor.NM_ProcGravar = "";
            this.pValor.Size = new System.Drawing.Size(597, 37);
            this.pValor.TabIndex = 4;
            // 
            // valor_desdobro
            // 
            this.valor_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDesdobro, "Valor_desdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.valor_desdobro.DecimalPlaces = 5;
            this.valor_desdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valor_desdobro.Location = new System.Drawing.Point(148, 4);
            this.valor_desdobro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.valor_desdobro.Name = "valor_desdobro";
            this.valor_desdobro.NM_Alias = "";
            this.valor_desdobro.NM_Campo = "";
            this.valor_desdobro.NM_Param = "";
            this.valor_desdobro.Operador = "";
            this.valor_desdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.valor_desdobro.Size = new System.Drawing.Size(153, 26);
            this.valor_desdobro.ST_AutoInc = false;
            this.valor_desdobro.ST_DisableAuto = false;
            this.valor_desdobro.ST_Gravar = true;
            this.valor_desdobro.ST_LimparCampo = true;
            this.valor_desdobro.ST_NotNull = true;
            this.valor_desdobro.ST_PrimaryKey = false;
            this.valor_desdobro.TabIndex = 0;
            this.valor_desdobro.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.TabIndex = 63;
            this.label7.Text = "Valor Desdobro:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_tpdesdobro
            // 
            this.ds_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdesdobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Ds_tpdesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdesdobro.Enabled = false;
            this.ds_tpdesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpdesdobro.Location = new System.Drawing.Point(209, 3);
            this.ds_tpdesdobro.Name = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Alias = "";
            this.ds_tpdesdobro.NM_Campo = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_CampoBusca = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Param = "@P_DS_TPDESDOBRO";
            this.ds_tpdesdobro.QTD_Zero = 0;
            this.ds_tpdesdobro.Size = new System.Drawing.Size(281, 20);
            this.ds_tpdesdobro.ST_AutoInc = false;
            this.ds_tpdesdobro.ST_DisableAuto = false;
            this.ds_tpdesdobro.ST_Float = true;
            this.ds_tpdesdobro.ST_Gravar = false;
            this.ds_tpdesdobro.ST_Int = false;
            this.ds_tpdesdobro.ST_LimpaCampo = true;
            this.ds_tpdesdobro.ST_NotNull = true;
            this.ds_tpdesdobro.ST_PrimaryKey = false;
            this.ds_tpdesdobro.TabIndex = 67;
            this.ds_tpdesdobro.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(13, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 66;
            this.label4.Text = "Tipo Desdobro:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_tpdesdobro
            // 
            this.bb_tpdesdobro.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpdesdobro.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdesdobro.Image")));
            this.bb_tpdesdobro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdesdobro.Location = new System.Drawing.Point(176, 3);
            this.bb_tpdesdobro.Name = "bb_tpdesdobro";
            this.bb_tpdesdobro.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdesdobro.TabIndex = 1;
            this.bb_tpdesdobro.UseVisualStyleBackColor = false;
            this.bb_tpdesdobro.Click += new System.EventHandler(this.bb_tpdesdobro_Click);
            // 
            // id_tpdesdobro
            // 
            this.id_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpdesdobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Id_tpdesdobrostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tpdesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_tpdesdobro.Location = new System.Drawing.Point(99, 3);
            this.id_tpdesdobro.Name = "id_tpdesdobro";
            this.id_tpdesdobro.NM_Alias = "";
            this.id_tpdesdobro.NM_Campo = "id_tpdesdobro";
            this.id_tpdesdobro.NM_CampoBusca = "id_tpdesdobro";
            this.id_tpdesdobro.NM_Param = "@P_ID_TPDESDOBRO";
            this.id_tpdesdobro.QTD_Zero = 0;
            this.id_tpdesdobro.Size = new System.Drawing.Size(74, 20);
            this.id_tpdesdobro.ST_AutoInc = false;
            this.id_tpdesdobro.ST_DisableAuto = false;
            this.id_tpdesdobro.ST_Float = true;
            this.id_tpdesdobro.ST_Gravar = true;
            this.id_tpdesdobro.ST_Int = true;
            this.id_tpdesdobro.ST_LimpaCampo = true;
            this.id_tpdesdobro.ST_NotNull = true;
            this.id_tpdesdobro.ST_PrimaryKey = false;
            this.id_tpdesdobro.TabIndex = 0;
            this.id_tpdesdobro.TextOld = null;
            this.id_tpdesdobro.Leave += new System.EventHandler(this.id_tpdesdobro_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Nm_empresa_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(178, 29);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(518, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 55;
            this.NM_Empresa.TextOld = null;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Cd_empresa_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(99, 29);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(74, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = true;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 54;
            this.CD_Empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(42, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(46, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Produto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_produtodest
            // 
            this.ds_produtodest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produtodest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produtodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produtodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Ds_produto_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produtodest.Enabled = false;
            this.ds_produtodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produtodest.Location = new System.Drawing.Point(178, 80);
            this.ds_produtodest.Name = "ds_produtodest";
            this.ds_produtodest.NM_Alias = "";
            this.ds_produtodest.NM_Campo = "DS_Produto";
            this.ds_produtodest.NM_CampoBusca = "DS_Produto";
            this.ds_produtodest.NM_Param = "@P_DS_PRODUTO";
            this.ds_produtodest.QTD_Zero = 0;
            this.ds_produtodest.ReadOnly = true;
            this.ds_produtodest.Size = new System.Drawing.Size(518, 20);
            this.ds_produtodest.ST_AutoInc = false;
            this.ds_produtodest.ST_DisableAuto = false;
            this.ds_produtodest.ST_Float = false;
            this.ds_produtodest.ST_Gravar = false;
            this.ds_produtodest.ST_Int = false;
            this.ds_produtodest.ST_LimpaCampo = true;
            this.ds_produtodest.ST_NotNull = false;
            this.ds_produtodest.ST_PrimaryKey = false;
            this.ds_produtodest.TabIndex = 61;
            this.ds_produtodest.TextOld = null;
            // 
            // cd_produtodest
            // 
            this.cd_produtodest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produtodest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produtodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produtodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Cd_produto_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produtodest.Enabled = false;
            this.cd_produtodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produtodest.Location = new System.Drawing.Point(99, 80);
            this.cd_produtodest.Name = "cd_produtodest";
            this.cd_produtodest.NM_Alias = "";
            this.cd_produtodest.NM_Campo = "CD_Produto";
            this.cd_produtodest.NM_CampoBusca = "CD_Produto";
            this.cd_produtodest.NM_Param = "@P_CD_PRODUTO";
            this.cd_produtodest.QTD_Zero = 0;
            this.cd_produtodest.Size = new System.Drawing.Size(74, 20);
            this.cd_produtodest.ST_AutoInc = false;
            this.cd_produtodest.ST_DisableAuto = false;
            this.cd_produtodest.ST_Float = false;
            this.cd_produtodest.ST_Gravar = true;
            this.cd_produtodest.ST_Int = true;
            this.cd_produtodest.ST_LimpaCampo = true;
            this.cd_produtodest.ST_NotNull = true;
            this.cd_produtodest.ST_PrimaryKey = false;
            this.cd_produtodest.TabIndex = 52;
            this.cd_produtodest.TextOld = null;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Cd_clifor_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Enabled = false;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(99, 54);
            this.CD_Clifor.Name = "CD_Clifor";
            this.CD_Clifor.NM_Alias = "";
            this.CD_Clifor.NM_Campo = "CD_Clifor";
            this.CD_Clifor.NM_CampoBusca = "CD_Clifor";
            this.CD_Clifor.NM_Param = "@P_CD_CLIFOR";
            this.CD_Clifor.QTD_Zero = 0;
            this.CD_Clifor.ReadOnly = true;
            this.CD_Clifor.Size = new System.Drawing.Size(74, 20);
            this.CD_Clifor.ST_AutoInc = false;
            this.CD_Clifor.ST_DisableAuto = false;
            this.CD_Clifor.ST_Float = false;
            this.CD_Clifor.ST_Gravar = false;
            this.CD_Clifor.ST_Int = false;
            this.CD_Clifor.ST_LimpaCampo = true;
            this.CD_Clifor.ST_NotNull = false;
            this.CD_Clifor.ST_PrimaryKey = false;
            this.CD_Clifor.TabIndex = 56;
            this.CD_Clifor.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Cliente/Fornec.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Nm_clifor_dest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(177, 54);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ReadOnly = true;
            this.NM_Clifor.Size = new System.Drawing.Size(519, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 57;
            this.NM_Clifor.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(496, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Contrato Destino:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_contratodest
            // 
            this.bb_contratodest.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contratodest.Image = ((System.Drawing.Image)(resources.GetObject("bb_contratodest.Image")));
            this.bb_contratodest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contratodest.Location = new System.Drawing.Point(668, 3);
            this.bb_contratodest.Name = "bb_contratodest";
            this.bb_contratodest.Size = new System.Drawing.Size(28, 19);
            this.bb_contratodest.TabIndex = 3;
            this.bb_contratodest.UseVisualStyleBackColor = false;
            this.bb_contratodest.Click += new System.EventHandler(this.bb_contratodest_Click);
            // 
            // nr_contratodest
            // 
            this.nr_contratodest.BackColor = System.Drawing.SystemColors.Window;
            this.nr_contratodest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_contratodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_contratodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobro, "Nr_contrato_deststr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_contratodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nr_contratodest.Location = new System.Drawing.Point(591, 3);
            this.nr_contratodest.Name = "nr_contratodest";
            this.nr_contratodest.NM_Alias = "";
            this.nr_contratodest.NM_Campo = "nr_contrato";
            this.nr_contratodest.NM_CampoBusca = "nr_contrato";
            this.nr_contratodest.NM_Param = "@P_NR_CONTRATO";
            this.nr_contratodest.QTD_Zero = 0;
            this.nr_contratodest.Size = new System.Drawing.Size(74, 20);
            this.nr_contratodest.ST_AutoInc = false;
            this.nr_contratodest.ST_DisableAuto = false;
            this.nr_contratodest.ST_Float = true;
            this.nr_contratodest.ST_Gravar = true;
            this.nr_contratodest.ST_Int = true;
            this.nr_contratodest.ST_LimpaCampo = true;
            this.nr_contratodest.ST_NotNull = true;
            this.nr_contratodest.ST_PrimaryKey = false;
            this.nr_contratodest.TabIndex = 2;
            this.nr_contratodest.TextOld = null;
            this.nr_contratodest.Leave += new System.EventHandler(this.nr_contratodest_Leave);
            // 
            // TFDesdobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 193);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDesdobro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desdobro Aplicação";
            this.Load += new System.EventHandler(this.FDesdobro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDesdobro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobro)).EndInit();
            this.pValor.ResumeLayout(false);
            this.pValor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.valor_desdobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_tpdesdobro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_tpdesdobro;
        private Componentes.EditDefault id_tpdesdobro;
        private Componentes.EditDefault NM_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ds_produtodest;
        private Componentes.EditDefault cd_produtodest;
        private Componentes.EditDefault CD_Clifor;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_contratodest;
        private Componentes.EditDefault nr_contratodest;
        private Componentes.PanelDados pValor;
        private Componentes.EditFloat valor_desdobro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bsDesdobro;
    }
}