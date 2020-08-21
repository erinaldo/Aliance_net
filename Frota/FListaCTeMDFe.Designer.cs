namespace Frota
{
    partial class TFListaCTeMDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaCTeMDFe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bb_destinatario = new System.Windows.Forms.Button();
            this.cd_destinatario = new Componentes.EditDefault(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditData(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditData(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_remetente = new System.Windows.Forms.Button();
            this.cd_remetente = new Componentes.EditDefault(this.components);
            this.nr_cte = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gCte = new Componentes.DataGridDefault(this.components);
            this.bsCTe = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrctrcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlfreteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlreceberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_cidade_fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdremetenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmremetenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpjremetenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cddestinatarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmdestinatarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpjdestinatarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCTe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(971, 43);
            this.barraMenu.TabIndex = 22;
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
            this.bb_inutilizar.Text = "(F4)\r\nConfirmar";
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
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(971, 453);
            this.tlpCentral.TabIndex = 23;
            // 
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.bb_destinatario);
            this.pFiltro.Controls.Add(this.cd_destinatario);
            this.pFiltro.Controls.Add(this.bb_buscar);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.bb_remetente);
            this.pFiltro.Controls.Add(this.cd_remetente);
            this.pFiltro.Controls.Add(this.nr_cte);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(965, 49);
            this.pFiltro.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Destinatario";
            // 
            // bb_destinatario
            // 
            this.bb_destinatario.Image = ((System.Drawing.Image)(resources.GetObject("bb_destinatario.Image")));
            this.bb_destinatario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_destinatario.Location = new System.Drawing.Point(391, 23);
            this.bb_destinatario.Name = "bb_destinatario";
            this.bb_destinatario.Size = new System.Drawing.Size(28, 19);
            this.bb_destinatario.TabIndex = 5;
            this.bb_destinatario.UseVisualStyleBackColor = true;
            this.bb_destinatario.Click += new System.EventHandler(this.bb_destinatario_Click);
            // 
            // cd_destinatario
            // 
            this.cd_destinatario.BackColor = System.Drawing.SystemColors.Window;
            this.cd_destinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_destinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_destinatario.Location = new System.Drawing.Point(300, 22);
            this.cd_destinatario.Name = "cd_destinatario";
            this.cd_destinatario.NM_Alias = "";
            this.cd_destinatario.NM_Campo = "cd_clifor";
            this.cd_destinatario.NM_CampoBusca = "cd_clifor";
            this.cd_destinatario.NM_Param = "@P_CD_CLIFOR";
            this.cd_destinatario.QTD_Zero = 0;
            this.cd_destinatario.Size = new System.Drawing.Size(88, 20);
            this.cd_destinatario.ST_AutoInc = false;
            this.cd_destinatario.ST_DisableAuto = false;
            this.cd_destinatario.ST_Float = false;
            this.cd_destinatario.ST_Gravar = false;
            this.cd_destinatario.ST_Int = true;
            this.cd_destinatario.ST_LimpaCampo = true;
            this.cd_destinatario.ST_NotNull = false;
            this.cd_destinatario.ST_PrimaryKey = false;
            this.cd_destinatario.TabIndex = 4;
            this.cd_destinatario.TextOld = null;
            this.cd_destinatario.Leave += new System.EventHandler(this.cd_destinatario_Leave);
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(573, 6);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(112, 36);
            this.bb_buscar.TabIndex = 8;
            this.bb_buscar.Text = "(F7) Buscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dt. Fin.";
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(499, 22);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(68, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dt. Ini.";
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(425, 22);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(68, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remetente";
            // 
            // bb_remetente
            // 
            this.bb_remetente.Image = ((System.Drawing.Image)(resources.GetObject("bb_remetente.Image")));
            this.bb_remetente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_remetente.Location = new System.Drawing.Point(266, 23);
            this.bb_remetente.Name = "bb_remetente";
            this.bb_remetente.Size = new System.Drawing.Size(28, 19);
            this.bb_remetente.TabIndex = 3;
            this.bb_remetente.UseVisualStyleBackColor = true;
            this.bb_remetente.Click += new System.EventHandler(this.bb_remetente_Click);
            // 
            // cd_remetente
            // 
            this.cd_remetente.BackColor = System.Drawing.SystemColors.Window;
            this.cd_remetente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_remetente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_remetente.Location = new System.Drawing.Point(175, 22);
            this.cd_remetente.Name = "cd_remetente";
            this.cd_remetente.NM_Alias = "";
            this.cd_remetente.NM_Campo = "cd_clifor";
            this.cd_remetente.NM_CampoBusca = "cd_clifor";
            this.cd_remetente.NM_Param = "@P_CD_CLIFOR";
            this.cd_remetente.QTD_Zero = 0;
            this.cd_remetente.Size = new System.Drawing.Size(88, 20);
            this.cd_remetente.ST_AutoInc = false;
            this.cd_remetente.ST_DisableAuto = false;
            this.cd_remetente.ST_Float = false;
            this.cd_remetente.ST_Gravar = false;
            this.cd_remetente.ST_Int = true;
            this.cd_remetente.ST_LimpaCampo = true;
            this.cd_remetente.ST_NotNull = false;
            this.cd_remetente.ST_PrimaryKey = false;
            this.cd_remetente.TabIndex = 2;
            this.cd_remetente.TextOld = null;
            this.cd_remetente.Leave += new System.EventHandler(this.cd_remetente_Leave);
            // 
            // nr_cte
            // 
            this.nr_cte.BackColor = System.Drawing.SystemColors.Window;
            this.nr_cte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cte.Location = new System.Drawing.Point(92, 22);
            this.nr_cte.Name = "nr_cte";
            this.nr_cte.NM_Alias = "";
            this.nr_cte.NM_Campo = "";
            this.nr_cte.NM_CampoBusca = "";
            this.nr_cte.NM_Param = "";
            this.nr_cte.QTD_Zero = 0;
            this.nr_cte.Size = new System.Drawing.Size(77, 20);
            this.nr_cte.ST_AutoInc = false;
            this.nr_cte.ST_DisableAuto = false;
            this.nr_cte.ST_Float = false;
            this.nr_cte.ST_Gravar = false;
            this.nr_cte.ST_Int = false;
            this.nr_cte.ST_LimpaCampo = true;
            this.nr_cte.ST_NotNull = false;
            this.nr_cte.ST_PrimaryKey = false;
            this.nr_cte.TabIndex = 1;
            this.nr_cte.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nº CT-e";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(9, 22);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "";
            this.cd_empresa.NM_CampoBusca = "";
            this.cd_empresa.NM_Param = "";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(77, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = false;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbTodos);
            this.panelDados1.Controls.Add(this.gCte);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 58);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(965, 392);
            this.panelDados1.TabIndex = 2;
            // 
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(7, 12);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 12;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // gCte
            // 
            this.gCte.AllowUserToAddRows = false;
            this.gCte.AllowUserToDeleteRows = false;
            this.gCte.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCte.AutoGenerateColumns = false;
            this.gCte.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCte.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.nrctrcDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.vlfreteDataGridViewTextBoxColumn,
            this.vlreceberDataGridViewTextBoxColumn,
            this.Ds_cidade_fin,
            this.cdremetenteDataGridViewTextBoxColumn,
            this.nmremetenteDataGridViewTextBoxColumn,
            this.cnpjremetenteDataGridViewTextBoxColumn,
            this.cddestinatarioDataGridViewTextBoxColumn,
            this.nmdestinatarioDataGridViewTextBoxColumn,
            this.cnpjdestinatarioDataGridViewTextBoxColumn});
            this.gCte.DataSource = this.bsCTe;
            this.gCte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCte.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCte.Location = new System.Drawing.Point(0, 0);
            this.gCte.Name = "gCte";
            this.gCte.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCte.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gCte.RowHeadersWidth = 23;
            this.gCte.Size = new System.Drawing.Size(965, 367);
            this.gCte.TabIndex = 0;
            this.gCte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gCte_CellClick);
            // 
            // bsCTe
            // 
            this.bsCTe.DataSource = typeof(CamadaDados.Faturamento.CTRC.TList_ConhecimentoFrete);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCTe;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 367);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(965, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Marcar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 46;
            // 
            // nrctrcDataGridViewTextBoxColumn
            // 
            this.nrctrcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrctrcDataGridViewTextBoxColumn.DataPropertyName = "Nr_ctrc";
            this.nrctrcDataGridViewTextBoxColumn.HeaderText = "Nº CT-e";
            this.nrctrcDataGridViewTextBoxColumn.Name = "nrctrcDataGridViewTextBoxColumn";
            this.nrctrcDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrctrcDataGridViewTextBoxColumn.Width = 70;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtemissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // vlfreteDataGridViewTextBoxColumn
            // 
            this.vlfreteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlfreteDataGridViewTextBoxColumn.DataPropertyName = "Vl_frete";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlfreteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vlfreteDataGridViewTextBoxColumn.HeaderText = "Vl. Frete";
            this.vlfreteDataGridViewTextBoxColumn.Name = "vlfreteDataGridViewTextBoxColumn";
            this.vlfreteDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlfreteDataGridViewTextBoxColumn.Width = 71;
            // 
            // vlreceberDataGridViewTextBoxColumn
            // 
            this.vlreceberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlreceberDataGridViewTextBoxColumn.DataPropertyName = "Vl_receber";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.vlreceberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.vlreceberDataGridViewTextBoxColumn.HeaderText = "Vl. Receber";
            this.vlreceberDataGridViewTextBoxColumn.Name = "vlreceberDataGridViewTextBoxColumn";
            this.vlreceberDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlreceberDataGridViewTextBoxColumn.Width = 88;
            // 
            // Ds_cidade_fin
            // 
            this.Ds_cidade_fin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_cidade_fin.DataPropertyName = "Ds_cidade_fin";
            this.Ds_cidade_fin.HeaderText = "Cidade Descarregar";
            this.Ds_cidade_fin.Name = "Ds_cidade_fin";
            this.Ds_cidade_fin.ReadOnly = true;
            this.Ds_cidade_fin.Width = 115;
            // 
            // cdremetenteDataGridViewTextBoxColumn
            // 
            this.cdremetenteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdremetenteDataGridViewTextBoxColumn.DataPropertyName = "Cd_remetente";
            this.cdremetenteDataGridViewTextBoxColumn.HeaderText = "Cd. Remetente";
            this.cdremetenteDataGridViewTextBoxColumn.Name = "cdremetenteDataGridViewTextBoxColumn";
            this.cdremetenteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdremetenteDataGridViewTextBoxColumn.Width = 95;
            // 
            // nmremetenteDataGridViewTextBoxColumn
            // 
            this.nmremetenteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmremetenteDataGridViewTextBoxColumn.DataPropertyName = "Nm_remetente";
            this.nmremetenteDataGridViewTextBoxColumn.HeaderText = "Remetente";
            this.nmremetenteDataGridViewTextBoxColumn.Name = "nmremetenteDataGridViewTextBoxColumn";
            this.nmremetenteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmremetenteDataGridViewTextBoxColumn.Width = 84;
            // 
            // cnpjremetenteDataGridViewTextBoxColumn
            // 
            this.cnpjremetenteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cnpjremetenteDataGridViewTextBoxColumn.DataPropertyName = "Cnpj_remetente";
            this.cnpjremetenteDataGridViewTextBoxColumn.HeaderText = "CNPJ Remetente";
            this.cnpjremetenteDataGridViewTextBoxColumn.Name = "cnpjremetenteDataGridViewTextBoxColumn";
            this.cnpjremetenteDataGridViewTextBoxColumn.ReadOnly = true;
            this.cnpjremetenteDataGridViewTextBoxColumn.Width = 105;
            // 
            // cddestinatarioDataGridViewTextBoxColumn
            // 
            this.cddestinatarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cddestinatarioDataGridViewTextBoxColumn.DataPropertyName = "Cd_destinatario";
            this.cddestinatarioDataGridViewTextBoxColumn.HeaderText = "Cd. Destinatario";
            this.cddestinatarioDataGridViewTextBoxColumn.Name = "cddestinatarioDataGridViewTextBoxColumn";
            this.cddestinatarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.cddestinatarioDataGridViewTextBoxColumn.Width = 98;
            // 
            // nmdestinatarioDataGridViewTextBoxColumn
            // 
            this.nmdestinatarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmdestinatarioDataGridViewTextBoxColumn.DataPropertyName = "Nm_destinatario";
            this.nmdestinatarioDataGridViewTextBoxColumn.HeaderText = "Destinatario";
            this.nmdestinatarioDataGridViewTextBoxColumn.Name = "nmdestinatarioDataGridViewTextBoxColumn";
            this.nmdestinatarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmdestinatarioDataGridViewTextBoxColumn.Width = 88;
            // 
            // cnpjdestinatarioDataGridViewTextBoxColumn
            // 
            this.cnpjdestinatarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cnpjdestinatarioDataGridViewTextBoxColumn.DataPropertyName = "Cnpj_destinatario";
            this.cnpjdestinatarioDataGridViewTextBoxColumn.HeaderText = "CNPJ Destinatario";
            this.cnpjdestinatarioDataGridViewTextBoxColumn.Name = "cnpjdestinatarioDataGridViewTextBoxColumn";
            this.cnpjdestinatarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.cnpjdestinatarioDataGridViewTextBoxColumn.Width = 108;
            // 
            // TFListaCTeMDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 496);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaCTeMDFe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista CT-e";
            this.Load += new System.EventHandler(this.TFListaCTeMDFe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaCTeMDFe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCTe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Button bb_buscar;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Label label4;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_remetente;
        private Componentes.EditDefault cd_remetente;
        private Componentes.EditDefault nr_cte;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gCte;
        private System.Windows.Forms.BindingSource bsCTe;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bb_destinatario;
        private Componentes.EditDefault cd_destinatario;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrctrcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlfreteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlreceberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_cidade_fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdremetenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmremetenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpjremetenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cddestinatarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmdestinatarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpjdestinatarioDataGridViewTextBoxColumn;
    }
}