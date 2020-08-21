namespace Balanca
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
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.tp_landesdobro = new Componentes.EditDefault(this.components);
            this.id_pedidoitemdest = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
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
            this.NR_Contrato = new Componentes.EditDefault(this.components);
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bb_pedidodest = new System.Windows.Forms.Button();
            this.nr_pedidodest = new Componentes.EditDefault(this.components);
            this.tp_calcpeso = new Componentes.EditDefault(this.components);
            this.pValores = new Componentes.PanelDados(this.components);
            this.peso_desdobro = new Componentes.EditFloat(this.components);
            this.pc_desdobro = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.peso_basecalc = new Componentes.EditFloat(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.bsDesdobroEspecial = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.pValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peso_desdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peso_basecalc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobroEspecial)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(658, 43);
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
            this.pDados.Controls.Add(this.pValores);
            this.pDados.Controls.Add(this.tp_calcpeso);
            this.pDados.Controls.Add(this.tp_landesdobro);
            this.pDados.Controls.Add(this.id_pedidoitemdest);
            this.pDados.Controls.Add(this.label9);
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
            this.pDados.Controls.Add(this.NR_Contrato);
            this.pDados.Controls.Add(this.NM_Clifor);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_pedidodest);
            this.pDados.Controls.Add(this.nr_pedidodest);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(658, 205);
            this.pDados.TabIndex = 12;
            // 
            // tp_landesdobro
            // 
            this.tp_landesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.tp_landesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_landesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Tipo_landesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_landesdobro.Enabled = false;
            this.tp_landesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_landesdobro.Location = new System.Drawing.Point(451, 5);
            this.tp_landesdobro.Name = "tp_landesdobro";
            this.tp_landesdobro.NM_Alias = "";
            this.tp_landesdobro.NM_Campo = "tp_landesdobro";
            this.tp_landesdobro.NM_CampoBusca = "tp_landesdobro";
            this.tp_landesdobro.NM_Param = "@P_TP_LANDESDOBRO";
            this.tp_landesdobro.QTD_Zero = 0;
            this.tp_landesdobro.Size = new System.Drawing.Size(96, 20);
            this.tp_landesdobro.ST_AutoInc = false;
            this.tp_landesdobro.ST_DisableAuto = false;
            this.tp_landesdobro.ST_Float = true;
            this.tp_landesdobro.ST_Gravar = false;
            this.tp_landesdobro.ST_Int = false;
            this.tp_landesdobro.ST_LimpaCampo = true;
            this.tp_landesdobro.ST_NotNull = true;
            this.tp_landesdobro.ST_PrimaryKey = false;
            this.tp_landesdobro.TabIndex = 91;
            // 
            // id_pedidoitemdest
            // 
            this.id_pedidoitemdest.BackColor = System.Drawing.SystemColors.Window;
            this.id_pedidoitemdest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_pedidoitemdest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Id_pedidoitemdeststr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_pedidoitemdest.Enabled = false;
            this.id_pedidoitemdest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_pedidoitemdest.Location = new System.Drawing.Point(553, 32);
            this.id_pedidoitemdest.Name = "id_pedidoitemdest";
            this.id_pedidoitemdest.NM_Alias = "";
            this.id_pedidoitemdest.NM_Campo = "id_pedidoitem";
            this.id_pedidoitemdest.NM_CampoBusca = "id_pedidoitem";
            this.id_pedidoitemdest.NM_Param = "@P_NR_CONTRATOP";
            this.id_pedidoitemdest.QTD_Zero = 0;
            this.id_pedidoitemdest.ReadOnly = true;
            this.id_pedidoitemdest.Size = new System.Drawing.Size(96, 20);
            this.id_pedidoitemdest.ST_AutoInc = false;
            this.id_pedidoitemdest.ST_DisableAuto = false;
            this.id_pedidoitemdest.ST_Float = false;
            this.id_pedidoitemdest.ST_Gravar = false;
            this.id_pedidoitemdest.ST_Int = false;
            this.id_pedidoitemdest.ST_LimpaCampo = true;
            this.id_pedidoitemdest.ST_NotNull = false;
            this.id_pedidoitemdest.ST_PrimaryKey = false;
            this.id_pedidoitemdest.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(466, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "Id. Item Destino";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_tpdesdobro
            // 
            this.ds_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Ds_tpdesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdesdobro.Enabled = false;
            this.ds_tpdesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpdesdobro.Location = new System.Drawing.Point(205, 6);
            this.ds_tpdesdobro.Name = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Alias = "";
            this.ds_tpdesdobro.NM_Campo = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_CampoBusca = "ds_tpdesdobro";
            this.ds_tpdesdobro.NM_Param = "@P_DS_TPDESDOBRO";
            this.ds_tpdesdobro.QTD_Zero = 0;
            this.ds_tpdesdobro.Size = new System.Drawing.Size(240, 20);
            this.ds_tpdesdobro.ST_AutoInc = false;
            this.ds_tpdesdobro.ST_DisableAuto = false;
            this.ds_tpdesdobro.ST_Float = true;
            this.ds_tpdesdobro.ST_Gravar = false;
            this.ds_tpdesdobro.ST_Int = false;
            this.ds_tpdesdobro.ST_LimpaCampo = true;
            this.ds_tpdesdobro.ST_NotNull = true;
            this.ds_tpdesdobro.ST_PrimaryKey = false;
            this.ds_tpdesdobro.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 87;
            this.label4.Text = "Tipo Desdobro:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_tpdesdobro
            // 
            this.bb_tpdesdobro.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpdesdobro.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdesdobro.Image")));
            this.bb_tpdesdobro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdesdobro.Location = new System.Drawing.Point(172, 6);
            this.bb_tpdesdobro.Name = "bb_tpdesdobro";
            this.bb_tpdesdobro.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdesdobro.TabIndex = 72;
            this.bb_tpdesdobro.UseVisualStyleBackColor = false;
            this.bb_tpdesdobro.Click += new System.EventHandler(this.bb_tpdesdobro_Click);
            // 
            // id_tpdesdobro
            // 
            this.id_tpdesdobro.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpdesdobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpdesdobro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Id_tpdesdobrostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tpdesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_tpdesdobro.Location = new System.Drawing.Point(95, 6);
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
            this.id_tpdesdobro.TabIndex = 71;
            this.id_tpdesdobro.Leave += new System.EventHandler(this.id_tpdesdobro_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Nm_empresadest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(174, 56);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(475, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 78;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Cd_empresadest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Enabled = false;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(95, 56);
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
            this.CD_Empresa.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(38, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Empresa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(42, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Produto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_produtodest
            // 
            this.ds_produtodest.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produtodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produtodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Ds_produtodest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produtodest.Enabled = false;
            this.ds_produtodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_produtodest.Location = new System.Drawing.Point(174, 107);
            this.ds_produtodest.Name = "ds_produtodest";
            this.ds_produtodest.NM_Alias = "";
            this.ds_produtodest.NM_Campo = "DS_Produto";
            this.ds_produtodest.NM_CampoBusca = "DS_Produto";
            this.ds_produtodest.NM_Param = "@P_DS_PRODUTO";
            this.ds_produtodest.QTD_Zero = 0;
            this.ds_produtodest.ReadOnly = true;
            this.ds_produtodest.Size = new System.Drawing.Size(475, 20);
            this.ds_produtodest.ST_AutoInc = false;
            this.ds_produtodest.ST_DisableAuto = false;
            this.ds_produtodest.ST_Float = false;
            this.ds_produtodest.ST_Gravar = false;
            this.ds_produtodest.ST_Int = false;
            this.ds_produtodest.ST_LimpaCampo = true;
            this.ds_produtodest.ST_NotNull = false;
            this.ds_produtodest.ST_PrimaryKey = false;
            this.ds_produtodest.TabIndex = 84;
            // 
            // cd_produtodest
            // 
            this.cd_produtodest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produtodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produtodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Cd_produtodest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produtodest.Enabled = false;
            this.cd_produtodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produtodest.Location = new System.Drawing.Point(95, 107);
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
            this.cd_produtodest.TabIndex = 75;
            // 
            // CD_Clifor
            // 
            this.CD_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Cd_clifordest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Clifor.Enabled = false;
            this.CD_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Clifor.Location = new System.Drawing.Point(95, 81);
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
            this.CD_Clifor.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 83;
            this.label5.Text = "Cliente/Fornec.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NR_Contrato
            // 
            this.NR_Contrato.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Contrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Contrato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Nr_contratodest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NR_Contrato.Enabled = false;
            this.NR_Contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NR_Contrato.Location = new System.Drawing.Point(340, 31);
            this.NR_Contrato.Name = "NR_Contrato";
            this.NR_Contrato.NM_Alias = "";
            this.NR_Contrato.NM_Campo = "NR_Contrato";
            this.NR_Contrato.NM_CampoBusca = "NR_Contrato";
            this.NR_Contrato.NM_Param = "@P_NR_CONTRATOP";
            this.NR_Contrato.QTD_Zero = 0;
            this.NR_Contrato.ReadOnly = true;
            this.NR_Contrato.Size = new System.Drawing.Size(105, 20);
            this.NR_Contrato.ST_AutoInc = false;
            this.NR_Contrato.ST_DisableAuto = false;
            this.NR_Contrato.ST_Float = false;
            this.NR_Contrato.ST_Gravar = false;
            this.NR_Contrato.ST_Int = false;
            this.NR_Contrato.ST_LimpaCampo = true;
            this.NR_Contrato.ST_NotNull = false;
            this.NR_Contrato.ST_PrimaryKey = false;
            this.NR_Contrato.TabIndex = 76;
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Nm_clifordest", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Clifor.Enabled = false;
            this.NM_Clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor.Location = new System.Drawing.Point(173, 81);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "NM_Clifor";
            this.NM_Clifor.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.ReadOnly = true;
            this.NM_Clifor.Size = new System.Drawing.Size(476, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(245, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Contrato Destino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Pedido Destino:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_pedidodest
            // 
            this.bb_pedidodest.BackColor = System.Drawing.SystemColors.Control;
            this.bb_pedidodest.Image = ((System.Drawing.Image)(resources.GetObject("bb_pedidodest.Image")));
            this.bb_pedidodest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_pedidodest.Location = new System.Drawing.Point(172, 32);
            this.bb_pedidodest.Name = "bb_pedidodest";
            this.bb_pedidodest.Size = new System.Drawing.Size(28, 19);
            this.bb_pedidodest.TabIndex = 74;
            this.bb_pedidodest.UseVisualStyleBackColor = false;
            this.bb_pedidodest.Click += new System.EventHandler(this.bb_pedidodest_Click);
            // 
            // nr_pedidodest
            // 
            this.nr_pedidodest.BackColor = System.Drawing.SystemColors.Window;
            this.nr_pedidodest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_pedidodest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Nr_pedidodeststr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_pedidodest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nr_pedidodest.Location = new System.Drawing.Point(95, 32);
            this.nr_pedidodest.Name = "nr_pedidodest";
            this.nr_pedidodest.NM_Alias = "";
            this.nr_pedidodest.NM_Campo = "NR_Pedido";
            this.nr_pedidodest.NM_CampoBusca = "NR_Pedido";
            this.nr_pedidodest.NM_Param = "";
            this.nr_pedidodest.QTD_Zero = 0;
            this.nr_pedidodest.Size = new System.Drawing.Size(74, 20);
            this.nr_pedidodest.ST_AutoInc = false;
            this.nr_pedidodest.ST_DisableAuto = false;
            this.nr_pedidodest.ST_Float = true;
            this.nr_pedidodest.ST_Gravar = true;
            this.nr_pedidodest.ST_Int = true;
            this.nr_pedidodest.ST_LimpaCampo = true;
            this.nr_pedidodest.ST_NotNull = true;
            this.nr_pedidodest.ST_PrimaryKey = false;
            this.nr_pedidodest.TabIndex = 73;
            this.nr_pedidodest.Leave += new System.EventHandler(this.nr_pedidodest_Leave);
            // 
            // tp_calcpeso
            // 
            this.tp_calcpeso.BackColor = System.Drawing.SystemColors.Window;
            this.tp_calcpeso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_calcpeso.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDesdobroEspecial, "Tipo_calcpeso", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_calcpeso.Enabled = false;
            this.tp_calcpeso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_calcpeso.Location = new System.Drawing.Point(553, 5);
            this.tp_calcpeso.Name = "tp_calcpeso";
            this.tp_calcpeso.NM_Alias = "";
            this.tp_calcpeso.NM_Campo = "tp_calcpeso";
            this.tp_calcpeso.NM_CampoBusca = "tp_calcpeso";
            this.tp_calcpeso.NM_Param = "@P_TP_LANDESDOBRO";
            this.tp_calcpeso.QTD_Zero = 0;
            this.tp_calcpeso.Size = new System.Drawing.Size(96, 20);
            this.tp_calcpeso.ST_AutoInc = false;
            this.tp_calcpeso.ST_DisableAuto = false;
            this.tp_calcpeso.ST_Float = true;
            this.tp_calcpeso.ST_Gravar = false;
            this.tp_calcpeso.ST_Int = false;
            this.tp_calcpeso.ST_LimpaCampo = true;
            this.tp_calcpeso.ST_NotNull = true;
            this.tp_calcpeso.ST_PrimaryKey = false;
            this.tp_calcpeso.TabIndex = 92;
            // 
            // pValores
            // 
            this.pValores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pValores.Controls.Add(this.peso_basecalc);
            this.pValores.Controls.Add(this.label10);
            this.pValores.Controls.Add(this.peso_desdobro);
            this.pValores.Controls.Add(this.pc_desdobro);
            this.pValores.Controls.Add(this.label8);
            this.pValores.Controls.Add(this.label7);
            this.pValores.Location = new System.Drawing.Point(95, 133);
            this.pValores.Name = "pValores";
            this.pValores.NM_ProcDeletar = "";
            this.pValores.NM_ProcGravar = "";
            this.pValores.Size = new System.Drawing.Size(554, 63);
            this.pValores.TabIndex = 93;
            // 
            // peso_desdobro
            // 
            this.peso_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDesdobroEspecial, "Peso_desdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.peso_desdobro.DecimalPlaces = 3;
            this.peso_desdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peso_desdobro.Location = new System.Drawing.Point(268, 27);
            this.peso_desdobro.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.peso_desdobro.Name = "peso_desdobro";
            this.peso_desdobro.NM_Alias = "";
            this.peso_desdobro.NM_Campo = "";
            this.peso_desdobro.NM_Param = "";
            this.peso_desdobro.Operador = "";
            this.peso_desdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.peso_desdobro.Size = new System.Drawing.Size(128, 26);
            this.peso_desdobro.ST_AutoInc = false;
            this.peso_desdobro.ST_DisableAuto = false;
            this.peso_desdobro.ST_Gravar = true;
            this.peso_desdobro.ST_LimparCampo = true;
            this.peso_desdobro.ST_NotNull = true;
            this.peso_desdobro.ST_PrimaryKey = false;
            this.peso_desdobro.TabIndex = 66;
            this.peso_desdobro.ThousandsSeparator = true;
            this.peso_desdobro.Leave += new System.EventHandler(this.peso_desdobro_Leave);
            // 
            // pc_desdobro
            // 
            this.pc_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDesdobroEspecial, "Pc_desdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_desdobro.DecimalPlaces = 2;
            this.pc_desdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pc_desdobro.Location = new System.Drawing.Point(142, 27);
            this.pc_desdobro.Name = "pc_desdobro";
            this.pc_desdobro.NM_Alias = "";
            this.pc_desdobro.NM_Campo = "";
            this.pc_desdobro.NM_Param = "";
            this.pc_desdobro.Operador = "";
            this.pc_desdobro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_desdobro.Size = new System.Drawing.Size(120, 26);
            this.pc_desdobro.ST_AutoInc = false;
            this.pc_desdobro.ST_DisableAuto = false;
            this.pc_desdobro.ST_Gravar = true;
            this.pc_desdobro.ST_LimparCampo = true;
            this.pc_desdobro.ST_NotNull = true;
            this.pc_desdobro.ST_PrimaryKey = false;
            this.pc_desdobro.TabIndex = 65;
            this.pc_desdobro.ThousandsSeparator = true;
            this.pc_desdobro.Leave += new System.EventHandler(this.pc_desdobro_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(264, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "Peso Desdobro";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(139, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "% Desdobro";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // peso_basecalc
            // 
            this.peso_basecalc.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDesdobroEspecial, "Peso_basecalc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.peso_basecalc.DecimalPlaces = 3;
            this.peso_basecalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.peso_basecalc.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.peso_basecalc.Location = new System.Drawing.Point(8, 27);
            this.peso_basecalc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.peso_basecalc.Name = "peso_basecalc";
            this.peso_basecalc.NM_Alias = "";
            this.peso_basecalc.NM_Campo = "";
            this.peso_basecalc.NM_Param = "";
            this.peso_basecalc.Operador = "";
            this.peso_basecalc.ReadOnly = true;
            this.peso_basecalc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.peso_basecalc.Size = new System.Drawing.Size(128, 26);
            this.peso_basecalc.ST_AutoInc = false;
            this.peso_basecalc.ST_DisableAuto = false;
            this.peso_basecalc.ST_Gravar = false;
            this.peso_basecalc.ST_LimparCampo = true;
            this.peso_basecalc.ST_NotNull = false;
            this.peso_basecalc.ST_PrimaryKey = false;
            this.peso_basecalc.TabIndex = 69;
            this.peso_basecalc.TabStop = false;
            this.peso_basecalc.ThousandsSeparator = true;
            this.peso_basecalc.ValueChanged += new System.EventHandler(this.peso_basecalc_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 70;
            this.label10.Text = "Base Calculo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bsDesdobroEspecial
            // 
            this.bsDesdobroEspecial.DataSource = typeof(CamadaDados.Balanca.TList_DesdobroEspecial);
            // 
            // TFDesdobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 248);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDesdobro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desdobro Especial";
            this.Load += new System.EventHandler(this.TFDesdobro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDesdobro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pValores.ResumeLayout(false);
            this.pValores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peso_desdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_desdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peso_basecalc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDesdobroEspecial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault tp_calcpeso;
        private Componentes.EditDefault tp_landesdobro;
        private Componentes.EditDefault id_pedidoitemdest;
        private System.Windows.Forms.Label label9;
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
        private Componentes.EditDefault NR_Contrato;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_pedidodest;
        private Componentes.EditDefault nr_pedidodest;
        private Componentes.PanelDados pValores;
        private Componentes.EditFloat peso_basecalc;
        private System.Windows.Forms.Label label10;
        private Componentes.EditFloat peso_desdobro;
        private Componentes.EditFloat pc_desdobro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bsDesdobroEspecial;
    }
}