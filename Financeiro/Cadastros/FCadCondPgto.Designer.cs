namespace Financeiro.Cadastros
{
    partial class TFCadCondPgto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCondPgto));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.LB_CD_CondPGTO = new System.Windows.Forms.Label();
            this.LB_DS_CondPagto = new System.Windows.Forms.Label();
            this.LB_CD_Portador = new System.Windows.Forms.Label();
            this.LB_CD_Moeda = new System.Windows.Forms.Label();
            this.LB_CD_Juro = new System.Windows.Forms.Label();
            this.LB_QT_Parcelas = new System.Windows.Forms.Label();
            this.LB_QT_DiasDesdobro = new System.Windows.Forms.Label();
            this.CD_CondPGTO = new Componentes.EditDefault(this.components);
            this.DS_CondPgto = new Componentes.EditDefault(this.components);
            this.CD_Portador = new Componentes.EditDefault(this.components);
            this.CD_Moeda = new Componentes.EditDefault(this.components);
            this.CD_Juro = new Componentes.EditDefault(this.components);
            this.bb_portador = new System.Windows.Forms.Button();
            this.bb_moeda = new System.Windows.Forms.Button();
            this.bb_juro = new System.Windows.Forms.Button();
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.ds_moeda = new Componentes.EditDefault(this.components);
            this.ds_juro = new Componentes.EditDefault(this.components);
            this.QT_Parcelas = new Componentes.EditFloat(this.components);
            this.QT_DIASDESDOBRO = new Componentes.EditFloat(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ST_SincronizarSite = new Componentes.CheckBoxDefault(this.components);
            this.ST_SolicitarDTVencto = new Componentes.CheckBoxDefault(this.components);
            this.ST_VenctoEmFeriado = new Componentes.CheckBoxDefault(this.components);
            this.ST_ComEntrada = new Componentes.CheckBoxDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.FCD_CondPGTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FDS_CondPagto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCD_Portador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCD_Moeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FST_ComEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCD_Juro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FQT_Parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FQT_DiasDesdobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FST_VenctoEmFeriado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FST_SolicitarDTVencto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FST_SincronizarSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_Parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_DIASDESDOBRO)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.QT_DIASDESDOBRO);
            this.pDados.Controls.Add(this.QT_Parcelas);
            this.pDados.Controls.Add(this.ds_juro);
            this.pDados.Controls.Add(this.ds_moeda);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(this.bb_juro);
            this.pDados.Controls.Add(this.bb_moeda);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.LB_CD_CondPGTO);
            this.pDados.Controls.Add(this.LB_DS_CondPagto);
            this.pDados.Controls.Add(this.LB_CD_Portador);
            this.pDados.Controls.Add(this.LB_CD_Moeda);
            this.pDados.Controls.Add(this.LB_CD_Juro);
            this.pDados.Controls.Add(this.LB_QT_Parcelas);
            this.pDados.Controls.Add(this.LB_QT_DiasDesdobro);
            this.pDados.Controls.Add(this.CD_CondPGTO);
            this.pDados.Controls.Add(this.DS_CondPgto);
            this.pDados.Controls.Add(this.CD_Portador);
            this.pDados.Controls.Add(this.CD_Moeda);
            this.pDados.Controls.Add(this.CD_Juro);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_CONDPGTO";
            this.pDados.NM_ProcGravar = "IA_FIN_CONDPGTO";
            this.pDados.Size = new System.Drawing.Size(804, 167);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(816, 455);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Size = new System.Drawing.Size(808, 429);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FCD_CondPGTO,
            this.FDS_CondPagto,
            this.FCD_Portador,
            this.FCD_Moeda,
            this.FST_ComEntrada,
            this.FCD_Juro,
            this.FQT_Parcelas,
            this.FQT_DiasDesdobro,
            this.FST_VenctoEmFeriado,
            this.FST_SolicitarDTVencto,
            this.FST_SincronizarSite});
            this.gCadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Location = new System.Drawing.Point(0, 167);
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.RowHeadersWidth = 23;
            this.gCadastro.Size = new System.Drawing.Size(804, 258);
            this.gCadastro.TabIndex = 1;
            this.gCadastro.TabStop = false;
            this.gCadastro.CurrentCellChanged += new System.EventHandler(this.gCadastro_CurrentCellChanged);
            // 
            // LB_CD_CondPGTO
            // 
            this.LB_CD_CondPGTO.AutoSize = true;
            this.LB_CD_CondPGTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CD_CondPGTO.Location = new System.Drawing.Point(99, 13);
            this.LB_CD_CondPGTO.Name = "LB_CD_CondPGTO";
            this.LB_CD_CondPGTO.Size = new System.Drawing.Size(50, 13);
            this.LB_CD_CondPGTO.TabIndex = 1;
            this.LB_CD_CondPGTO.Text = "Código:";
            // 
            // LB_DS_CondPagto
            // 
            this.LB_DS_CondPagto.AutoSize = true;
            this.LB_DS_CondPagto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_DS_CondPagto.Location = new System.Drawing.Point(77, 39);
            this.LB_DS_CondPagto.Name = "LB_DS_CondPagto";
            this.LB_DS_CondPagto.Size = new System.Drawing.Size(68, 13);
            this.LB_DS_CondPagto.TabIndex = 2;
            this.LB_DS_CondPagto.Text = "Descrição:";
            // 
            // LB_CD_Portador
            // 
            this.LB_CD_Portador.AutoSize = true;
            this.LB_CD_Portador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CD_Portador.Location = new System.Drawing.Point(86, 65);
            this.LB_CD_Portador.Name = "LB_CD_Portador";
            this.LB_CD_Portador.Size = new System.Drawing.Size(59, 13);
            this.LB_CD_Portador.TabIndex = 3;
            this.LB_CD_Portador.Text = "Portador:";
            // 
            // LB_CD_Moeda
            // 
            this.LB_CD_Moeda.AutoSize = true;
            this.LB_CD_Moeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CD_Moeda.Location = new System.Drawing.Point(96, 91);
            this.LB_CD_Moeda.Name = "LB_CD_Moeda";
            this.LB_CD_Moeda.Size = new System.Drawing.Size(49, 13);
            this.LB_CD_Moeda.TabIndex = 4;
            this.LB_CD_Moeda.Text = "Moeda:";
            // 
            // LB_CD_Juro
            // 
            this.LB_CD_Juro.AutoSize = true;
            this.LB_CD_Juro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CD_Juro.Location = new System.Drawing.Point(110, 117);
            this.LB_CD_Juro.Name = "LB_CD_Juro";
            this.LB_CD_Juro.Size = new System.Drawing.Size(35, 13);
            this.LB_CD_Juro.TabIndex = 6;
            this.LB_CD_Juro.Text = "Juro:";
            // 
            // LB_QT_Parcelas
            // 
            this.LB_QT_Parcelas.AutoSize = true;
            this.LB_QT_Parcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_QT_Parcelas.Location = new System.Drawing.Point(56, 143);
            this.LB_QT_Parcelas.Name = "LB_QT_Parcelas";
            this.LB_QT_Parcelas.Size = new System.Drawing.Size(88, 13);
            this.LB_QT_Parcelas.TabIndex = 7;
            this.LB_QT_Parcelas.Text = "Qtd. Parcelas:";
            // 
            // LB_QT_DiasDesdobro
            // 
            this.LB_QT_DiasDesdobro.AutoSize = true;
            this.LB_QT_DiasDesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_QT_DiasDesdobro.Location = new System.Drawing.Point(236, 143);
            this.LB_QT_DiasDesdobro.Name = "LB_QT_DiasDesdobro";
            this.LB_QT_DiasDesdobro.Size = new System.Drawing.Size(142, 13);
            this.LB_QT_DiasDesdobro.TabIndex = 8;
            this.LB_QT_DiasDesdobro.Text = "Desdobrar Parcelas em:";
            // 
            // CD_CondPGTO
            // 
            this.CD_CondPGTO.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondPGTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondPGTO.Enabled = false;
            this.CD_CondPGTO.Location = new System.Drawing.Point(150, 10);
            this.CD_CondPGTO.MaxLength = 3;
            this.CD_CondPGTO.Name = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Alias = "";
            this.CD_CondPGTO.NM_Campo = "CD_CondPGTO";
            this.CD_CondPGTO.NM_CampoBusca = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Param = "@P_CD_CONDPGTO";
            this.CD_CondPGTO.QTD_Zero = 0;
            this.CD_CondPGTO.Size = new System.Drawing.Size(67, 20);
            this.CD_CondPGTO.ST_AutoInc = false;
            this.CD_CondPGTO.ST_DisableAuto = true;
            this.CD_CondPGTO.ST_Float = false;
            this.CD_CondPGTO.ST_Gravar = true;
            this.CD_CondPGTO.ST_Int = false;
            this.CD_CondPGTO.ST_LimpaCampo = true;
            this.CD_CondPGTO.ST_NotNull = true;
            this.CD_CondPGTO.ST_PrimaryKey = true;
            this.CD_CondPGTO.TabIndex = 0;
            // 
            // DS_CondPgto
            // 
            this.DS_CondPgto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CondPgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CondPgto.Enabled = false;
            this.DS_CondPgto.Location = new System.Drawing.Point(150, 36);
            this.DS_CondPgto.Name = "DS_CondPgto";
            this.DS_CondPgto.NM_Alias = "";
            this.DS_CondPgto.NM_Campo = "DS_CondPgto";
            this.DS_CondPgto.NM_CampoBusca = "DS_CondPgto";
            this.DS_CondPgto.NM_Param = "@P_DS_CONDPGTO";
            this.DS_CondPgto.QTD_Zero = 0;
            this.DS_CondPgto.Size = new System.Drawing.Size(400, 20);
            this.DS_CondPgto.ST_AutoInc = false;
            this.DS_CondPgto.ST_DisableAuto = false;
            this.DS_CondPgto.ST_Float = false;
            this.DS_CondPgto.ST_Gravar = true;
            this.DS_CondPgto.ST_Int = false;
            this.DS_CondPgto.ST_LimpaCampo = true;
            this.DS_CondPgto.ST_NotNull = false;
            this.DS_CondPgto.ST_PrimaryKey = false;
            this.DS_CondPgto.TabIndex = 1;
            // 
            // CD_Portador
            // 
            this.CD_Portador.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Portador.Enabled = false;
            this.CD_Portador.Location = new System.Drawing.Point(150, 62);
            this.CD_Portador.Name = "CD_Portador";
            this.CD_Portador.NM_Alias = "a";
            this.CD_Portador.NM_Campo = "CD_Portador";
            this.CD_Portador.NM_CampoBusca = "CD_Portador";
            this.CD_Portador.NM_Param = "@P_CD_PORTADOR";
            this.CD_Portador.QTD_Zero = 0;
            this.CD_Portador.Size = new System.Drawing.Size(67, 20);
            this.CD_Portador.ST_AutoInc = false;
            this.CD_Portador.ST_DisableAuto = false;
            this.CD_Portador.ST_Float = false;
            this.CD_Portador.ST_Gravar = true;
            this.CD_Portador.ST_Int = false;
            this.CD_Portador.ST_LimpaCampo = true;
            this.CD_Portador.ST_NotNull = false;
            this.CD_Portador.ST_PrimaryKey = false;
            this.CD_Portador.TabIndex = 2;
            this.CD_Portador.Leave += new System.EventHandler(this.CD_Portador_Leave);
            // 
            // CD_Moeda
            // 
            this.CD_Moeda.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Moeda.Enabled = false;
            this.CD_Moeda.Location = new System.Drawing.Point(150, 88);
            this.CD_Moeda.Name = "CD_Moeda";
            this.CD_Moeda.NM_Alias = "a";
            this.CD_Moeda.NM_Campo = "CD_Moeda";
            this.CD_Moeda.NM_CampoBusca = "CD_Moeda";
            this.CD_Moeda.NM_Param = "@P_CD_MOEDA";
            this.CD_Moeda.QTD_Zero = 0;
            this.CD_Moeda.Size = new System.Drawing.Size(67, 20);
            this.CD_Moeda.ST_AutoInc = false;
            this.CD_Moeda.ST_DisableAuto = false;
            this.CD_Moeda.ST_Float = false;
            this.CD_Moeda.ST_Gravar = true;
            this.CD_Moeda.ST_Int = false;
            this.CD_Moeda.ST_LimpaCampo = true;
            this.CD_Moeda.ST_NotNull = false;
            this.CD_Moeda.ST_PrimaryKey = false;
            this.CD_Moeda.TabIndex = 4;
            this.CD_Moeda.Leave += new System.EventHandler(this.CD_Moeda_Leave);
            // 
            // CD_Juro
            // 
            this.CD_Juro.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Juro.Enabled = false;
            this.CD_Juro.Location = new System.Drawing.Point(150, 114);
            this.CD_Juro.Name = "CD_Juro";
            this.CD_Juro.NM_Alias = "a";
            this.CD_Juro.NM_Campo = "CD_Juro";
            this.CD_Juro.NM_CampoBusca = "CD_Juro";
            this.CD_Juro.NM_Param = "@P_CD_JURO";
            this.CD_Juro.QTD_Zero = 0;
            this.CD_Juro.Size = new System.Drawing.Size(67, 20);
            this.CD_Juro.ST_AutoInc = false;
            this.CD_Juro.ST_DisableAuto = false;
            this.CD_Juro.ST_Float = false;
            this.CD_Juro.ST_Gravar = true;
            this.CD_Juro.ST_Int = false;
            this.CD_Juro.ST_LimpaCampo = true;
            this.CD_Juro.ST_NotNull = false;
            this.CD_Juro.ST_PrimaryKey = false;
            this.CD_Juro.TabIndex = 6;
            this.CD_Juro.Leave += new System.EventHandler(this.CD_Juro_Leave);
            // 
            // bb_portador
            // 
            this.bb_portador.Enabled = false;
            this.bb_portador.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_portador.Image = ((System.Drawing.Image)(resources.GetObject("bb_portador.Image")));
            this.bb_portador.Location = new System.Drawing.Point(218, 62);
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.Size = new System.Drawing.Size(30, 20);
            this.bb_portador.TabIndex = 3;
            this.bb_portador.UseVisualStyleBackColor = true;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // bb_moeda
            // 
            this.bb_moeda.Enabled = false;
            this.bb_moeda.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_moeda.Image = ((System.Drawing.Image)(resources.GetObject("bb_moeda.Image")));
            this.bb_moeda.Location = new System.Drawing.Point(218, 88);
            this.bb_moeda.Name = "bb_moeda";
            this.bb_moeda.Size = new System.Drawing.Size(30, 20);
            this.bb_moeda.TabIndex = 5;
            this.bb_moeda.UseVisualStyleBackColor = true;
            this.bb_moeda.Click += new System.EventHandler(this.bb_moeda_Click);
            // 
            // bb_juro
            // 
            this.bb_juro.Enabled = false;
            this.bb_juro.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_juro.Image = ((System.Drawing.Image)(resources.GetObject("bb_juro.Image")));
            this.bb_juro.Location = new System.Drawing.Point(218, 114);
            this.bb_juro.Name = "bb_juro";
            this.bb_juro.Size = new System.Drawing.Size(30, 20);
            this.bb_juro.TabIndex = 7;
            this.bb_juro.UseVisualStyleBackColor = true;
            this.bb_juro.Click += new System.EventHandler(this.bb_juro_Click);
            // 
            // ds_portador
            // 
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.Enabled = false;
            this.ds_portador.Location = new System.Drawing.Point(249, 62);
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_DS_PORTADOR";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.Size = new System.Drawing.Size(301, 20);
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            this.ds_portador.TabIndex = 337;
            // 
            // ds_moeda
            // 
            this.ds_moeda.BackColor = System.Drawing.SystemColors.Window;
            this.ds_moeda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_moeda.Enabled = false;
            this.ds_moeda.Location = new System.Drawing.Point(249, 88);
            this.ds_moeda.Name = "ds_moeda";
            this.ds_moeda.NM_Alias = "";
            this.ds_moeda.NM_Campo = "ds_moeda_singular";
            this.ds_moeda.NM_CampoBusca = "ds_moeda_singular";
            this.ds_moeda.NM_Param = "@P_DS_MOEDA";
            this.ds_moeda.QTD_Zero = 0;
            this.ds_moeda.Size = new System.Drawing.Size(301, 20);
            this.ds_moeda.ST_AutoInc = false;
            this.ds_moeda.ST_DisableAuto = false;
            this.ds_moeda.ST_Float = false;
            this.ds_moeda.ST_Gravar = false;
            this.ds_moeda.ST_Int = false;
            this.ds_moeda.ST_LimpaCampo = true;
            this.ds_moeda.ST_NotNull = false;
            this.ds_moeda.ST_PrimaryKey = false;
            this.ds_moeda.TabIndex = 338;
            // 
            // ds_juro
            // 
            this.ds_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_juro.Enabled = false;
            this.ds_juro.Location = new System.Drawing.Point(249, 114);
            this.ds_juro.Name = "ds_juro";
            this.ds_juro.NM_Alias = "";
            this.ds_juro.NM_Campo = "ds_juro";
            this.ds_juro.NM_CampoBusca = "ds_juro";
            this.ds_juro.NM_Param = "@P_DS_JURO";
            this.ds_juro.QTD_Zero = 0;
            this.ds_juro.Size = new System.Drawing.Size(301, 20);
            this.ds_juro.ST_AutoInc = false;
            this.ds_juro.ST_DisableAuto = false;
            this.ds_juro.ST_Float = false;
            this.ds_juro.ST_Gravar = false;
            this.ds_juro.ST_Int = false;
            this.ds_juro.ST_LimpaCampo = true;
            this.ds_juro.ST_NotNull = false;
            this.ds_juro.ST_PrimaryKey = false;
            this.ds_juro.TabIndex = 339;
            // 
            // QT_Parcelas
            // 
            this.QT_Parcelas.Enabled = false;
            this.QT_Parcelas.Location = new System.Drawing.Point(150, 140);
            this.QT_Parcelas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.QT_Parcelas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QT_Parcelas.Name = "QT_Parcelas";
            this.QT_Parcelas.NM_Alias = "";
            this.QT_Parcelas.NM_Campo = "QT_Parcelas";
            this.QT_Parcelas.NM_Param = "@P_QT_PARCELAS";
            this.QT_Parcelas.Operador = "";
            this.QT_Parcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.QT_Parcelas.Size = new System.Drawing.Size(80, 20);
            this.QT_Parcelas.ST_AutoInc = false;
            this.QT_Parcelas.ST_DisableAuto = false;
            this.QT_Parcelas.ST_Gravar = true;
            this.QT_Parcelas.ST_LimparCampo = true;
            this.QT_Parcelas.ST_NotNull = false;
            this.QT_Parcelas.ST_PrimaryKey = false;
            this.QT_Parcelas.TabIndex = 8;
            this.QT_Parcelas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QT_Parcelas.ValueChanged += new System.EventHandler(this.QT_Parcelas_ValueChanged);
            // 
            // QT_DIASDESDOBRO
            // 
            this.QT_DIASDESDOBRO.Enabled = false;
            this.QT_DIASDESDOBRO.Location = new System.Drawing.Point(384, 140);
            this.QT_DIASDESDOBRO.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.QT_DIASDESDOBRO.Name = "QT_DIASDESDOBRO";
            this.QT_DIASDESDOBRO.NM_Alias = "";
            this.QT_DIASDESDOBRO.NM_Campo = "QT_DIASDESDOBRO";
            this.QT_DIASDESDOBRO.NM_Param = "@P_QT_DIASDESDOBRO";
            this.QT_DIASDESDOBRO.Operador = "";
            this.QT_DIASDESDOBRO.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.QT_DIASDESDOBRO.Size = new System.Drawing.Size(80, 20);
            this.QT_DIASDESDOBRO.ST_AutoInc = false;
            this.QT_DIASDESDOBRO.ST_DisableAuto = false;
            this.QT_DIASDESDOBRO.ST_Gravar = true;
            this.QT_DIASDESDOBRO.ST_LimparCampo = true;
            this.QT_DIASDESDOBRO.ST_NotNull = false;
            this.QT_DIASDESDOBRO.ST_PrimaryKey = false;
            this.QT_DIASDESDOBRO.TabIndex = 9;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.ST_SincronizarSite);
            this.panelDados1.Controls.Add(this.ST_SolicitarDTVencto);
            this.panelDados1.Controls.Add(this.ST_VenctoEmFeriado);
            this.panelDados1.Controls.Add(this.ST_ComEntrada);
            this.panelDados1.Location = new System.Drawing.Point(4, 14);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(236, 108);
            this.panelDados1.TabIndex = 0;
            this.panelDados1.TabStop = true;
            // 
            // ST_SincronizarSite
            // 
            this.ST_SincronizarSite.AutoSize = true;
            this.ST_SincronizarSite.Enabled = false;
            this.ST_SincronizarSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_SincronizarSite.Location = new System.Drawing.Point(3, 75);
            this.ST_SincronizarSite.Name = "ST_SincronizarSite";
            this.ST_SincronizarSite.NM_Alias = "";
            this.ST_SincronizarSite.NM_Campo = "ST_SincronizarSite";
            this.ST_SincronizarSite.NM_Param = "@P_ST_SINCRONIZARSITE";
            this.ST_SincronizarSite.Size = new System.Drawing.Size(153, 17);
            this.ST_SincronizarSite.ST_Gravar = true;
            this.ST_SincronizarSite.ST_LimparCampo = true;
            this.ST_SincronizarSite.ST_NotNull = false;
            this.ST_SincronizarSite.TabIndex = 3;
            this.ST_SincronizarSite.Text = "Sincronizar com o Site";
            this.ST_SincronizarSite.UseVisualStyleBackColor = true;
            this.ST_SincronizarSite.Vl_False = "N";
            this.ST_SincronizarSite.Vl_True = "S";
            this.ST_SincronizarSite.CheckedChanged += new System.EventHandler(this.ST_SincronizarSite_CheckedChanged);
            // 
            // ST_SolicitarDTVencto
            // 
            this.ST_SolicitarDTVencto.AutoSize = true;
            this.ST_SolicitarDTVencto.Enabled = false;
            this.ST_SolicitarDTVencto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_SolicitarDTVencto.Location = new System.Drawing.Point(3, 52);
            this.ST_SolicitarDTVencto.Name = "ST_SolicitarDTVencto";
            this.ST_SolicitarDTVencto.NM_Alias = "";
            this.ST_SolicitarDTVencto.NM_Campo = "ST_SolicitarDTVencto";
            this.ST_SolicitarDTVencto.NM_Param = "@P_ST_SOLICITARDTVENCTO";
            this.ST_SolicitarDTVencto.Size = new System.Drawing.Size(220, 17);
            this.ST_SolicitarDTVencto.ST_Gravar = true;
            this.ST_SolicitarDTVencto.ST_LimparCampo = true;
            this.ST_SolicitarDTVencto.ST_NotNull = false;
            this.ST_SolicitarDTVencto.TabIndex = 2;
            this.ST_SolicitarDTVencto.Text = "Solicitar Dt. de Vencto Específica";
            this.ST_SolicitarDTVencto.UseVisualStyleBackColor = true;
            this.ST_SolicitarDTVencto.Vl_False = "N";
            this.ST_SolicitarDTVencto.Vl_True = "S";
            // 
            // ST_VenctoEmFeriado
            // 
            this.ST_VenctoEmFeriado.AutoSize = true;
            this.ST_VenctoEmFeriado.Enabled = false;
            this.ST_VenctoEmFeriado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_VenctoEmFeriado.Location = new System.Drawing.Point(3, 29);
            this.ST_VenctoEmFeriado.Name = "ST_VenctoEmFeriado";
            this.ST_VenctoEmFeriado.NM_Alias = "";
            this.ST_VenctoEmFeriado.NM_Campo = "ST_VenctoEmFeriado";
            this.ST_VenctoEmFeriado.NM_Param = "@P_ST_VENCTOEMFERIADO";
            this.ST_VenctoEmFeriado.Size = new System.Drawing.Size(204, 17);
            this.ST_VenctoEmFeriado.ST_Gravar = true;
            this.ST_VenctoEmFeriado.ST_LimparCampo = true;
            this.ST_VenctoEmFeriado.ST_NotNull = false;
            this.ST_VenctoEmFeriado.TabIndex = 1;
            this.ST_VenctoEmFeriado.Text = "Permitir Vencimento em Feriado";
            this.ST_VenctoEmFeriado.UseVisualStyleBackColor = true;
            this.ST_VenctoEmFeriado.Vl_False = "N";
            this.ST_VenctoEmFeriado.Vl_True = "S";
            this.ST_VenctoEmFeriado.EnabledChanged += new System.EventHandler(this.ST_VenctoEmFeriado_EnabledChanged);
            // 
            // ST_ComEntrada
            // 
            this.ST_ComEntrada.AutoSize = true;
            this.ST_ComEntrada.Enabled = false;
            this.ST_ComEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_ComEntrada.Location = new System.Drawing.Point(3, 6);
            this.ST_ComEntrada.Name = "ST_ComEntrada";
            this.ST_ComEntrada.NM_Alias = "";
            this.ST_ComEntrada.NM_Campo = "ST_ComEntrada";
            this.ST_ComEntrada.NM_Param = "@P_ST_COMENTRADA";
            this.ST_ComEntrada.Size = new System.Drawing.Size(154, 17);
            this.ST_ComEntrada.ST_Gravar = true;
            this.ST_ComEntrada.ST_LimparCampo = true;
            this.ST_ComEntrada.ST_NotNull = false;
            this.ST_ComEntrada.TabIndex = 0;
            this.ST_ComEntrada.Text = "Condição com Entrada";
            this.ST_ComEntrada.UseVisualStyleBackColor = true;
            this.ST_ComEntrada.Vl_False = "N";
            this.ST_ComEntrada.Vl_True = "S";
            this.ST_ComEntrada.EnabledChanged += new System.EventHandler(this.ST_ComEntrada_EnabledChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(470, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 340;
            this.label1.Text = "dias.";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.panelDados1);
            this.radioGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroup1.Location = new System.Drawing.Point(556, 16);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(245, 128);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 10;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Outras Configurações:";
            // 
            // FCD_CondPGTO
            // 
            this.FCD_CondPGTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCD_CondPGTO.DataPropertyName = "CD_CondPGTO";
            this.FCD_CondPGTO.HeaderText = "Cód.Cond. Pagto.";
            this.FCD_CondPGTO.Name = "FCD_CondPGTO";
            this.FCD_CondPGTO.ReadOnly = true;
            this.FCD_CondPGTO.Width = 106;
            // 
            // FDS_CondPagto
            // 
            this.FDS_CondPagto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FDS_CondPagto.DataPropertyName = "DS_CondPgto";
            this.FDS_CondPagto.HeaderText = "Cond. Pagto.";
            this.FDS_CondPagto.Name = "FDS_CondPagto";
            this.FDS_CondPagto.ReadOnly = true;
            this.FDS_CondPagto.Width = 87;
            // 
            // FCD_Portador
            // 
            this.FCD_Portador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCD_Portador.DataPropertyName = "DS_Portador";
            this.FCD_Portador.HeaderText = "Portador";
            this.FCD_Portador.Name = "FCD_Portador";
            this.FCD_Portador.ReadOnly = true;
            this.FCD_Portador.Width = 72;
            // 
            // FCD_Moeda
            // 
            this.FCD_Moeda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCD_Moeda.DataPropertyName = "ds_Moeda_singular";
            this.FCD_Moeda.HeaderText = "Moeda";
            this.FCD_Moeda.Name = "FCD_Moeda";
            this.FCD_Moeda.ReadOnly = true;
            this.FCD_Moeda.Width = 65;
            // 
            // FST_ComEntrada
            // 
            this.FST_ComEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FST_ComEntrada.DataPropertyName = "ST_ComEntrada";
            this.FST_ComEntrada.HeaderText = "Com  Entrada";
            this.FST_ComEntrada.Name = "FST_ComEntrada";
            this.FST_ComEntrada.ReadOnly = true;
            this.FST_ComEntrada.Width = 88;
            // 
            // FCD_Juro
            // 
            this.FCD_Juro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FCD_Juro.DataPropertyName = "ds_Juro";
            this.FCD_Juro.HeaderText = "Juros";
            this.FCD_Juro.Name = "FCD_Juro";
            this.FCD_Juro.ReadOnly = true;
            this.FCD_Juro.Width = 57;
            // 
            // FQT_Parcelas
            // 
            this.FQT_Parcelas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FQT_Parcelas.DataPropertyName = "QT_Parcelas";
            this.FQT_Parcelas.HeaderText = "Qtd. Parcelas";
            this.FQT_Parcelas.Name = "FQT_Parcelas";
            this.FQT_Parcelas.ReadOnly = true;
            this.FQT_Parcelas.Width = 88;
            // 
            // FQT_DiasDesdobro
            // 
            this.FQT_DiasDesdobro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FQT_DiasDesdobro.DataPropertyName = "QT_DiasDesdobro";
            this.FQT_DiasDesdobro.HeaderText = "Qtd. Dias Desdobro";
            this.FQT_DiasDesdobro.Name = "FQT_DiasDesdobro";
            this.FQT_DiasDesdobro.ReadOnly = true;
            this.FQT_DiasDesdobro.Width = 115;
            // 
            // FST_VenctoEmFeriado
            // 
            this.FST_VenctoEmFeriado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FST_VenctoEmFeriado.DataPropertyName = "ST_VenctoEmFeriado";
            this.FST_VenctoEmFeriado.HeaderText = "Vencto. Feriado";
            this.FST_VenctoEmFeriado.Name = "FST_VenctoEmFeriado";
            this.FST_VenctoEmFeriado.ReadOnly = true;
            this.FST_VenctoEmFeriado.Width = 98;
            // 
            // FST_SolicitarDTVencto
            // 
            this.FST_SolicitarDTVencto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FST_SolicitarDTVencto.DataPropertyName = "ST_SolicitarDTVencto";
            this.FST_SolicitarDTVencto.HeaderText = "Solicitar Dta. Vencto.";
            this.FST_SolicitarDTVencto.Name = "FST_SolicitarDTVencto";
            this.FST_SolicitarDTVencto.ReadOnly = true;
            this.FST_SolicitarDTVencto.Width = 121;
            // 
            // FST_SincronizarSite
            // 
            this.FST_SincronizarSite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FST_SincronizarSite.DataPropertyName = "ST_SincronizarSite";
            this.FST_SincronizarSite.HeaderText = "Sincronizar com o site";
            this.FST_SincronizarSite.Name = "FST_SincronizarSite";
            this.FST_SincronizarSite.ReadOnly = true;
            this.FST_SincronizarSite.Width = 98;
            // 
            // TFCadCondPgto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(816, 498);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFCadCondPgto";
            this.Text = "Cadastro de Condições de Pagamentos";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_Parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_DIASDESDOBRO)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_CD_CondPGTO;
        private System.Windows.Forms.Label LB_DS_CondPagto;
        private System.Windows.Forms.Label LB_CD_Portador;
        private System.Windows.Forms.Label LB_CD_Moeda;
        private System.Windows.Forms.Label LB_CD_Juro;
        private System.Windows.Forms.Label LB_QT_Parcelas;
        private System.Windows.Forms.Label LB_QT_DiasDesdobro;
        private Componentes.EditDefault CD_CondPGTO;
        private Componentes.EditDefault DS_CondPgto;
        private Componentes.EditDefault CD_Portador;
        private Componentes.EditDefault CD_Moeda;
        private Componentes.EditDefault CD_Juro;
        public System.Windows.Forms.Button bb_juro;
        public System.Windows.Forms.Button bb_moeda;
        public System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault ds_juro;
        private Componentes.EditDefault ds_moeda;
        private Componentes.EditDefault ds_portador;
        private Componentes.EditFloat QT_Parcelas;
        private Componentes.EditFloat QT_DIASDESDOBRO;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault ST_SolicitarDTVencto;
        private Componentes.CheckBoxDefault ST_VenctoEmFeriado;
        private Componentes.CheckBoxDefault ST_ComEntrada;
        private System.Windows.Forms.Label label1;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.CheckBoxDefault ST_SincronizarSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCD_CondPGTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDS_CondPagto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCD_Portador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCD_Moeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn FST_ComEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCD_Juro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FQT_Parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn FQT_DiasDesdobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FST_VenctoEmFeriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FST_SolicitarDTVencto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FST_SincronizarSite;
    }
}
