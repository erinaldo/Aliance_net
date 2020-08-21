namespace Proc_Commoditties
{
    partial class TFListaCheques
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaCheques));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inic = new Componentes.EditData(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.NM_Clifor = new Componentes.EditDefault(this.components);
            this.BB_Clifor = new System.Windows.Forms.Button();
            this.BB_Banco = new System.Windows.Forms.Button();
            this.CD_Banco = new Componentes.EditDefault(this.components);
            this.NR_Cheque = new Componentes.EditDefault(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.TP_Titulo = new Componentes.RadioGroup(this.components);
            this.RB_TpTitulo_Recebidos = new Componentes.RadioButtonDefault(this.components);
            this.RB_TpTitulo_Emitidos = new Componentes.RadioButtonDefault(this.components);
            this.pTotal = new Componentes.PanelDados(this.components);
            this.tot_processar = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tot_cheque = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gcheque = new Componentes.DataGridDefault(this.components);
            this.St_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statuscompensadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrlanctochequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCheque = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            label4 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados6.SuspendLayout();
            this.TP_Titulo.SuspendLayout();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_processar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_cheque)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(287, 13);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(72, 13);
            label4.TabIndex = 547;
            label4.Text = "Nº Cheque:";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(124, 12);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_empresaLabel.TabIndex = 540;
            cd_empresaLabel.Text = "Empresa:";
            cd_empresaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(111, 38);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(99, 13);
            label3.TabIndex = 550;
            label3.Text = "Cliente/Fornec.:";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(944, 43);
            this.barraMenu.TabIndex = 20;
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
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pTotal, 0, 2);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlpCentral.Size = new System.Drawing.Size(944, 554);
            this.tlpCentral.TabIndex = 21;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.bb_buscar);
            this.pFiltro.Controls.Add(this.panelDados6);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.NM_Clifor);
            this.pFiltro.Controls.Add(this.BB_Clifor);
            this.pFiltro.Controls.Add(this.BB_Banco);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.CD_Banco);
            this.pFiltro.Controls.Add(this.NR_Cheque);
            this.pFiltro.Controls.Add(this.label14);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(cd_empresaLabel);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.TP_Titulo);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(934, 68);
            this.pFiltro.TabIndex = 0;
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(774, 3);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(100, 53);
            this.bb_buscar.TabIndex = 553;
            this.bb_buscar.Text = "(F7)\r\nBuscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // panelDados6
            // 
            this.panelDados6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados6.Controls.Add(this.DT_Final);
            this.panelDados6.Controls.Add(this.DT_Inic);
            this.panelDados6.Controls.Add(this.label13);
            this.panelDados6.Controls.Add(this.label15);
            this.panelDados6.Location = new System.Drawing.Point(622, 6);
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            this.panelDados6.Size = new System.Drawing.Size(146, 50);
            this.panelDados6.TabIndex = 552;
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Location = new System.Drawing.Point(50, 24);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "DT_NascFirma";
            this.DT_Final.NM_CampoBusca = "DT_NascFirma";
            this.DT_Final.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(89, 20);
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 1;
            this.DT_Final.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DT_Inic
            // 
            this.DT_Inic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inic.Location = new System.Drawing.Point(50, 2);
            this.DT_Inic.Mask = "00/00/0000";
            this.DT_Inic.Name = "DT_Inic";
            this.DT_Inic.NM_Alias = "";
            this.DT_Inic.NM_Campo = "DT_NascFirma";
            this.DT_Inic.NM_CampoBusca = "DT_NascFirma";
            this.DT_Inic.NM_Param = "@P_DT_NASCIMENTO";
            this.DT_Inic.Operador = "";
            this.DT_Inic.Size = new System.Drawing.Size(89, 20);
            this.DT_Inic.ST_Gravar = true;
            this.DT_Inic.ST_LimpaCampo = true;
            this.DT_Inic.ST_NotNull = false;
            this.DT_Inic.ST_PrimaryKey = false;
            this.DT_Inic.TabIndex = 0;
            this.DT_Inic.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(0, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Dt. Fin:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(3, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Dt. Ini:";
            // 
            // NM_Clifor
            // 
            this.NM_Clifor.BackColor = System.Drawing.Color.White;
            this.NM_Clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor.Location = new System.Drawing.Point(216, 36);
            this.NM_Clifor.Name = "NM_Clifor";
            this.NM_Clifor.NM_Alias = "";
            this.NM_Clifor.NM_Campo = "nm_clifor";
            this.NM_Clifor.NM_CampoBusca = "nm_clifor";
            this.NM_Clifor.NM_Param = "@P_NM_CLIFOR";
            this.NM_Clifor.QTD_Zero = 0;
            this.NM_Clifor.Size = new System.Drawing.Size(369, 20);
            this.NM_Clifor.ST_AutoInc = false;
            this.NM_Clifor.ST_DisableAuto = false;
            this.NM_Clifor.ST_Float = false;
            this.NM_Clifor.ST_Gravar = false;
            this.NM_Clifor.ST_Int = false;
            this.NM_Clifor.ST_LimpaCampo = true;
            this.NM_Clifor.ST_NotNull = false;
            this.NM_Clifor.ST_PrimaryKey = false;
            this.NM_Clifor.TabIndex = 551;
            this.NM_Clifor.TextOld = null;
            // 
            // BB_Clifor
            // 
            this.BB_Clifor.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Clifor.Image = ((System.Drawing.Image)(resources.GetObject("BB_Clifor.Image")));
            this.BB_Clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Clifor.Location = new System.Drawing.Point(588, 36);
            this.BB_Clifor.Name = "BB_Clifor";
            this.BB_Clifor.Size = new System.Drawing.Size(30, 19);
            this.BB_Clifor.TabIndex = 549;
            this.BB_Clifor.UseVisualStyleBackColor = false;
            this.BB_Clifor.Click += new System.EventHandler(this.BB_Clifor_Click);
            // 
            // BB_Banco
            // 
            this.BB_Banco.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Banco.Image = ((System.Drawing.Image)(resources.GetObject("BB_Banco.Image")));
            this.BB_Banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Banco.Location = new System.Drawing.Point(588, 11);
            this.BB_Banco.Name = "BB_Banco";
            this.BB_Banco.Size = new System.Drawing.Size(28, 19);
            this.BB_Banco.TabIndex = 545;
            this.BB_Banco.UseVisualStyleBackColor = false;
            this.BB_Banco.Click += new System.EventHandler(this.BB_Banco_Click);
            // 
            // CD_Banco
            // 
            this.CD_Banco.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Banco.Location = new System.Drawing.Point(520, 10);
            this.CD_Banco.Name = "CD_Banco";
            this.CD_Banco.NM_Alias = "";
            this.CD_Banco.NM_Campo = "";
            this.CD_Banco.NM_CampoBusca = "cd_banco";
            this.CD_Banco.NM_Param = "";
            this.CD_Banco.QTD_Zero = 0;
            this.CD_Banco.Size = new System.Drawing.Size(65, 20);
            this.CD_Banco.ST_AutoInc = false;
            this.CD_Banco.ST_DisableAuto = false;
            this.CD_Banco.ST_Float = false;
            this.CD_Banco.ST_Gravar = true;
            this.CD_Banco.ST_Int = false;
            this.CD_Banco.ST_LimpaCampo = true;
            this.CD_Banco.ST_NotNull = false;
            this.CD_Banco.ST_PrimaryKey = false;
            this.CD_Banco.TabIndex = 544;
            this.CD_Banco.TextOld = null;
            this.CD_Banco.Leave += new System.EventHandler(this.CD_Banco_Leave);
            // 
            // NR_Cheque
            // 
            this.NR_Cheque.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NR_Cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Cheque.Location = new System.Drawing.Point(365, 10);
            this.NR_Cheque.Name = "NR_Cheque";
            this.NR_Cheque.NM_Alias = "";
            this.NR_Cheque.NM_Campo = "";
            this.NR_Cheque.NM_CampoBusca = "";
            this.NR_Cheque.NM_Param = "";
            this.NR_Cheque.QTD_Zero = 0;
            this.NR_Cheque.Size = new System.Drawing.Size(96, 20);
            this.NR_Cheque.ST_AutoInc = false;
            this.NR_Cheque.ST_DisableAuto = false;
            this.NR_Cheque.ST_Float = false;
            this.NR_Cheque.ST_Gravar = false;
            this.NR_Cheque.ST_Int = false;
            this.NR_Cheque.ST_LimpaCampo = true;
            this.NR_Cheque.ST_NotNull = false;
            this.NR_Cheque.ST_PrimaryKey = false;
            this.NR_Cheque.TabIndex = 543;
            this.NR_Cheque.TextOld = null;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(467, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 546;
            this.label14.Text = "Banco:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(253, 10);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 542;
            this.BB_Empresa.UseVisualStyleBackColor = false;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(185, 9);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_Empresa";
            this.cd_empresa.NM_CampoBusca = "CD_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(65, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 541;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // TP_Titulo
            // 
            this.TP_Titulo.BackColor = System.Drawing.SystemColors.Control;
            this.TP_Titulo.Controls.Add(this.RB_TpTitulo_Recebidos);
            this.TP_Titulo.Controls.Add(this.RB_TpTitulo_Emitidos);
            this.TP_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TP_Titulo.Location = new System.Drawing.Point(8, 3);
            this.TP_Titulo.Name = "TP_Titulo";
            this.TP_Titulo.NM_Alias = "a";
            this.TP_Titulo.NM_Campo = "TP_Titulo";
            this.TP_Titulo.NM_Param = "@TP_TITULO";
            this.TP_Titulo.NM_Valor = "P";
            this.TP_Titulo.Size = new System.Drawing.Size(93, 60);
            this.TP_Titulo.ST_Gravar = true;
            this.TP_Titulo.ST_NotNull = false;
            this.TP_Titulo.TabIndex = 539;
            this.TP_Titulo.TabStop = false;
            this.TP_Titulo.Text = "Movimento";
            // 
            // RB_TpTitulo_Recebidos
            // 
            this.RB_TpTitulo_Recebidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RB_TpTitulo_Recebidos.ForeColor = System.Drawing.Color.Green;
            this.RB_TpTitulo_Recebidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RB_TpTitulo_Recebidos.Location = new System.Drawing.Point(6, 39);
            this.RB_TpTitulo_Recebidos.Name = "RB_TpTitulo_Recebidos";
            this.RB_TpTitulo_Recebidos.Size = new System.Drawing.Size(83, 17);
            this.RB_TpTitulo_Recebidos.TabIndex = 1;
            this.RB_TpTitulo_Recebidos.Text = "RECEBER";
            this.RB_TpTitulo_Recebidos.UseVisualStyleBackColor = false;
            this.RB_TpTitulo_Recebidos.Valor = "R";
            // 
            // RB_TpTitulo_Emitidos
            // 
            this.RB_TpTitulo_Emitidos.BackColor = System.Drawing.SystemColors.Control;
            this.RB_TpTitulo_Emitidos.Checked = true;
            this.RB_TpTitulo_Emitidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RB_TpTitulo_Emitidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.RB_TpTitulo_Emitidos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RB_TpTitulo_Emitidos.Location = new System.Drawing.Point(6, 17);
            this.RB_TpTitulo_Emitidos.Name = "RB_TpTitulo_Emitidos";
            this.RB_TpTitulo_Emitidos.Size = new System.Drawing.Size(83, 17);
            this.RB_TpTitulo_Emitidos.TabIndex = 0;
            this.RB_TpTitulo_Emitidos.TabStop = true;
            this.RB_TpTitulo_Emitidos.Text = "PAGAR";
            this.RB_TpTitulo_Emitidos.UseVisualStyleBackColor = false;
            this.RB_TpTitulo_Emitidos.Valor = "P";
            // 
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pTotal.Controls.Add(this.tot_processar);
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Controls.Add(this.tot_cheque);
            this.pTotal.Controls.Add(this.label5);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(5, 517);
            this.pTotal.Name = "pTotal";
            this.pTotal.NM_ProcDeletar = "";
            this.pTotal.NM_ProcGravar = "";
            this.pTotal.Size = new System.Drawing.Size(934, 32);
            this.pTotal.TabIndex = 1;
            // 
            // tot_processar
            // 
            this.tot_processar.DecimalPlaces = 2;
            this.tot_processar.Enabled = false;
            this.tot_processar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_processar.Location = new System.Drawing.Point(367, 3);
            this.tot_processar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_processar.Name = "tot_processar";
            this.tot_processar.NM_Alias = "";
            this.tot_processar.NM_Campo = "";
            this.tot_processar.NM_Param = "";
            this.tot_processar.Operador = "";
            this.tot_processar.Size = new System.Drawing.Size(116, 22);
            this.tot_processar.ST_AutoInc = false;
            this.tot_processar.ST_DisableAuto = false;
            this.tot_processar.ST_Gravar = false;
            this.tot_processar.ST_LimparCampo = true;
            this.tot_processar.ST_NotNull = false;
            this.tot_processar.ST_PrimaryKey = false;
            this.tot_processar.TabIndex = 84;
            this.tot_processar.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(238, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 16);
            this.label1.TabIndex = 83;
            this.label1.Text = "Total Processar:";
            // 
            // tot_cheque
            // 
            this.tot_cheque.DecimalPlaces = 2;
            this.tot_cheque.Enabled = false;
            this.tot_cheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_cheque.Location = new System.Drawing.Point(116, 3);
            this.tot_cheque.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_cheque.Name = "tot_cheque";
            this.tot_cheque.NM_Alias = "";
            this.tot_cheque.NM_Campo = "";
            this.tot_cheque.NM_Param = "";
            this.tot_cheque.Operador = "";
            this.tot_cheque.Size = new System.Drawing.Size(116, 22);
            this.tot_cheque.ST_AutoInc = false;
            this.tot_cheque.ST_DisableAuto = false;
            this.tot_cheque.ST_Gravar = false;
            this.tot_cheque.ST_LimparCampo = true;
            this.tot_cheque.ST_NotNull = false;
            this.tot_cheque.ST_PrimaryKey = false;
            this.tot_cheque.TabIndex = 82;
            this.tot_cheque.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "Total Cheque:";
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cbTodos);
            this.pDados.Controls.Add(this.gcheque);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 81);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(934, 428);
            this.pDados.TabIndex = 2;
            // 
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(7, 5);
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
            this.cbTodos.CheckedChanged += new System.EventHandler(this.cbTodos_CheckedChanged);
            // 
            // gcheque
            // 
            this.gcheque.AllowUserToAddRows = false;
            this.gcheque.AllowUserToDeleteRows = false;
            this.gcheque.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gcheque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gcheque.AutoGenerateColumns = false;
            this.gcheque.BackgroundColor = System.Drawing.Color.LightGray;
            this.gcheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gcheque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gcheque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gcheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_processar,
            this.statuscompensadoDataGridViewTextBoxColumn,
            this.Tipo_titulo,
            this.dsbancoDataGridViewTextBoxColumn,
            this.nrchequeDataGridViewTextBoxColumn,
            this.vltituloDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn2,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.nomecliforDataGridViewTextBoxColumn,
            this.nrlanctochequeDataGridViewTextBoxColumn});
            this.gcheque.DataSource = this.bsCheque;
            this.gcheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcheque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gcheque.Location = new System.Drawing.Point(0, 0);
            this.gcheque.Name = "gcheque";
            this.gcheque.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gcheque.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gcheque.RowHeadersWidth = 23;
            this.gcheque.Size = new System.Drawing.Size(930, 399);
            this.gcheque.TabIndex = 8;
            this.gcheque.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcheque_CellClick);
            // 
            // St_processar
            // 
            this.St_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_processar.DataPropertyName = "St_processar";
            this.St_processar.HeaderText = "Processar";
            this.St_processar.Name = "St_processar";
            this.St_processar.ReadOnly = true;
            this.St_processar.Width = 60;
            // 
            // statuscompensadoDataGridViewTextBoxColumn
            // 
            this.statuscompensadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statuscompensadoDataGridViewTextBoxColumn.DataPropertyName = "Status_compensado";
            this.statuscompensadoDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statuscompensadoDataGridViewTextBoxColumn.Name = "statuscompensadoDataGridViewTextBoxColumn";
            this.statuscompensadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.statuscompensadoDataGridViewTextBoxColumn.Width = 62;
            // 
            // Tipo_titulo
            // 
            this.Tipo_titulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_titulo.DataPropertyName = "Tipo_titulo";
            this.Tipo_titulo.HeaderText = "Movimento";
            this.Tipo_titulo.Name = "Tipo_titulo";
            this.Tipo_titulo.ReadOnly = true;
            this.Tipo_titulo.Width = 84;
            // 
            // dsbancoDataGridViewTextBoxColumn
            // 
            this.dsbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn.DataPropertyName = "Ds_banco";
            this.dsbancoDataGridViewTextBoxColumn.HeaderText = "Banco";
            this.dsbancoDataGridViewTextBoxColumn.Name = "dsbancoDataGridViewTextBoxColumn";
            this.dsbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsbancoDataGridViewTextBoxColumn.Width = 63;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            this.nrchequeDataGridViewTextBoxColumn.HeaderText = "Nº Cheque";
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrchequeDataGridViewTextBoxColumn.Width = 84;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.vltituloDataGridViewTextBoxColumn.HeaderText = "Vl. Cheque";
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltituloDataGridViewTextBoxColumn.Width = 84;
            // 
            // dtemissaoDataGridViewTextBoxColumn2
            // 
            this.dtemissaoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn2.DataPropertyName = "Dt_emissao";
            this.dtemissaoDataGridViewTextBoxColumn2.HeaderText = "Emitido em...";
            this.dtemissaoDataGridViewTextBoxColumn2.Name = "dtemissaoDataGridViewTextBoxColumn2";
            this.dtemissaoDataGridViewTextBoxColumn2.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn2.Width = 92;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Bom Para...";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 87;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            this.nomecliforDataGridViewTextBoxColumn.HeaderText = "Cliente/Fornecedor";
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecliforDataGridViewTextBoxColumn.Width = 123;
            // 
            // nrlanctochequeDataGridViewTextBoxColumn
            // 
            this.nrlanctochequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctochequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_lanctocheque";
            this.nrlanctochequeDataGridViewTextBoxColumn.HeaderText = "Nº Lancto";
            this.nrlanctochequeDataGridViewTextBoxColumn.Name = "nrlanctochequeDataGridViewTextBoxColumn";
            this.nrlanctochequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrlanctochequeDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsCheque
            // 
            this.bsCheque.DataSource = typeof(CamadaDados.Financeiro.Titulo.TList_RegLanTitulo);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCheque;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 399);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(930, 25);
            this.bindingNavigator1.TabIndex = 9;
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
            // TFListaCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 597);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaCheques";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Cheques";
            this.Load += new System.EventHandler(this.TFListaCheques_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaCheques_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            this.TP_Titulo.ResumeLayout(false);
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_processar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tot_cheque)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcheque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCheque)).EndInit();
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
        private Componentes.PanelDados pTotal;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsCheque;
        private Componentes.DataGridDefault gcheque;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn statuscompensadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctochequeDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault cbTodos;
        private Componentes.EditFloat tot_processar;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat tot_cheque;
        private System.Windows.Forms.Label label5;
        private Componentes.RadioGroup TP_Titulo;
        private Componentes.RadioButtonDefault RB_TpTitulo_Recebidos;
        private Componentes.RadioButtonDefault RB_TpTitulo_Emitidos;
        private System.Windows.Forms.Button BB_Banco;
        private Componentes.EditDefault CD_Banco;
        private Componentes.EditDefault NR_Cheque;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault NM_Clifor;
        private System.Windows.Forms.Button BB_Clifor;
        private System.Windows.Forms.Button bb_buscar;
        private Componentes.PanelDados panelDados6;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
    }
}