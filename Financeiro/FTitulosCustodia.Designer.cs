namespace Financeiro
{
    partial class TFTitulosCustodia
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTitulosCustodia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicial = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nr_cheque = new Componentes.EditDefault(this.components);
            this.nomeclifor = new Componentes.EditDefault(this.components);
            this.bb_banco = new System.Windows.Forms.Button();
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.pTotais = new Componentes.PanelDados(this.components);
            this.vl_tot_custodiar = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.pDados = new Componentes.PanelDados(this.components);
            this.cbMarcarTodos = new Componentes.CheckBoxDefault(this.components);
            this.gTitulos = new Componentes.DataGridDefault(this.components);
            this.stconciliarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrlanctochequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrchequeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vltituloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomecliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcgccpfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTitulos = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pTotais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_tot_custodiar)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(6, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(51, 13);
            label1.TabIndex = 56;
            label1.Text = "Empresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(124, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 13);
            label2.TabIndex = 59;
            label2.Text = "Banco:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(24, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(33, 13);
            label3.TabIndex = 61;
            label3.Text = "Clifor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(261, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(62, 13);
            label4.TabIndex = 63;
            label4.Text = "Nº Cheque:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.BB_Buscar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(850, 43);
            this.barraMenu.TabIndex = 11;
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
            // BB_Buscar
            // 
            this.BB_Buscar.AutoSize = false;
            this.BB_Buscar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(90, 40);
            this.BB_Buscar.Text = "(F7)\r\n Buscar";
            this.BB_Buscar.ToolTipText = "Buscar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.pTotais, 0, 2);
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpCentral.Size = new System.Drawing.Size(850, 487);
            this.tlpCentral.TabIndex = 12;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.DT_Final);
            this.pFiltro.Controls.Add(this.DT_Inicial);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.nr_cheque);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.nomeclifor);
            this.pFiltro.Controls.Add(this.bb_banco);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.cd_banco);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.Size = new System.Drawing.Size(840, 55);
            this.pFiltro.TabIndex = 0;
            // 
            // DT_Final
            // 
            this.DT_Final.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Final.Location = new System.Drawing.Point(463, 29);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.Size = new System.Drawing.Size(71, 20);
            this.DT_Final.ST_Gravar = false;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 66;
            // 
            // DT_Inicial
            // 
            this.DT_Inicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Inicial.Location = new System.Drawing.Point(463, 4);
            this.DT_Inicial.Mask = "00/00/0000";
            this.DT_Inicial.Name = "DT_Inicial";
            this.DT_Inicial.Size = new System.Drawing.Size(71, 20);
            this.DT_Inicial.ST_Gravar = false;
            this.DT_Inicial.ST_LimpaCampo = true;
            this.DT_Inicial.ST_NotNull = false;
            this.DT_Inicial.ST_PrimaryKey = false;
            this.DT_Inicial.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(416, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Dt. Ini.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(408, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Dt. Final:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nr_cheque
            // 
            this.nr_cheque.BackColor = System.Drawing.Color.White;
            this.nr_cheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_cheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_cheque.Location = new System.Drawing.Point(326, 4);
            this.nr_cheque.Name = "nr_cheque";
            this.nr_cheque.NM_Campo = "cd_empresa";
            this.nr_cheque.NM_CampoBusca = "cd_empresa";
            this.nr_cheque.NM_Param = "@P_CD_EMPRESA";
            this.nr_cheque.QTD_Zero = 0;
            this.nr_cheque.Size = new System.Drawing.Size(76, 20);
            this.nr_cheque.ST_AutoInc = false;
            this.nr_cheque.ST_DisableAuto = false;
            this.nr_cheque.ST_Float = false;
            this.nr_cheque.ST_Gravar = true;
            this.nr_cheque.ST_Int = true;
            this.nr_cheque.ST_LimpaCampo = true;
            this.nr_cheque.ST_NotNull = false;
            this.nr_cheque.ST_PrimaryKey = false;
            this.nr_cheque.TabIndex = 62;
            this.nr_cheque.TextOld = null;
            // 
            // nomeclifor
            // 
            this.nomeclifor.BackColor = System.Drawing.Color.White;
            this.nomeclifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nomeclifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeclifor.Location = new System.Drawing.Point(63, 29);
            this.nomeclifor.Name = "nomeclifor";
            this.nomeclifor.NM_Campo = "cd_empresa";
            this.nomeclifor.NM_CampoBusca = "cd_empresa";
            this.nomeclifor.NM_Param = "@P_CD_EMPRESA";
            this.nomeclifor.QTD_Zero = 0;
            this.nomeclifor.Size = new System.Drawing.Size(339, 20);
            this.nomeclifor.ST_AutoInc = false;
            this.nomeclifor.ST_DisableAuto = false;
            this.nomeclifor.ST_Float = false;
            this.nomeclifor.ST_Gravar = true;
            this.nomeclifor.ST_Int = true;
            this.nomeclifor.ST_LimpaCampo = true;
            this.nomeclifor.ST_NotNull = false;
            this.nomeclifor.ST_PrimaryKey = false;
            this.nomeclifor.TabIndex = 60;
            this.nomeclifor.TextOld = null;
            // 
            // bb_banco
            // 
            this.bb_banco.BackColor = System.Drawing.SystemColors.Control;
            this.bb_banco.Image = ((System.Drawing.Image)(resources.GetObject("bb_banco.Image")));
            this.bb_banco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_banco.Location = new System.Drawing.Point(227, 4);
            this.bb_banco.Name = "bb_banco";
            this.bb_banco.Size = new System.Drawing.Size(28, 19);
            this.bb_banco.TabIndex = 58;
            this.bb_banco.UseVisualStyleBackColor = false;
            this.bb_banco.Click += new System.EventHandler(this.bb_banco_Click);
            // 
            // cd_banco
            // 
            this.cd_banco.BackColor = System.Drawing.Color.White;
            this.cd_banco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.Location = new System.Drawing.Point(171, 4);
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.NM_Campo = "cd_banco";
            this.cd_banco.NM_CampoBusca = "cd_banco";
            this.cd_banco.NM_Param = "@P_CD_EMPRESA";
            this.cd_banco.QTD_Zero = 0;
            this.cd_banco.Size = new System.Drawing.Size(55, 20);
            this.cd_banco.ST_AutoInc = false;
            this.cd_banco.ST_DisableAuto = false;
            this.cd_banco.ST_Float = false;
            this.cd_banco.ST_Gravar = false;
            this.cd_banco.ST_Int = true;
            this.cd_banco.ST_LimpaCampo = true;
            this.cd_banco.ST_NotNull = false;
            this.cd_banco.ST_PrimaryKey = false;
            this.cd_banco.TabIndex = 57;
            this.cd_banco.TextOld = null;
            this.cd_banco.Leave += new System.EventHandler(this.cd_banco_Leave);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(63, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(55, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 55;
            this.cd_empresa.TextOld = null;
            // 
            // pTotais
            // 
            this.pTotais.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pTotais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotais.Controls.Add(this.vl_tot_custodiar);
            this.pTotais.Controls.Add(this.label7);
            this.pTotais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotais.Location = new System.Drawing.Point(5, 444);
            this.pTotais.Name = "pTotais";
            this.pTotais.Size = new System.Drawing.Size(840, 38);
            this.pTotais.TabIndex = 1;
            // 
            // vl_tot_custodiar
            // 
            this.vl_tot_custodiar.DecimalPlaces = 2;
            this.vl_tot_custodiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vl_tot_custodiar.Location = new System.Drawing.Point(309, 4);
            this.vl_tot_custodiar.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_tot_custodiar.Name = "vl_tot_custodiar";
            this.vl_tot_custodiar.ReadOnly = true;
            this.vl_tot_custodiar.Size = new System.Drawing.Size(215, 26);
            this.vl_tot_custodiar.ST_AutoInc = false;
            this.vl_tot_custodiar.ST_DisableAuto = false;
            this.vl_tot_custodiar.ST_Gravar = false;
            this.vl_tot_custodiar.ST_LimparCampo = true;
            this.vl_tot_custodiar.ST_NotNull = false;
            this.vl_tot_custodiar.ST_PrimaryKey = false;
            this.vl_tot_custodiar.TabIndex = 69;
            this.vl_tot_custodiar.TabStop = false;
            this.vl_tot_custodiar.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(297, 16);
            this.label7.TabIndex = 68;
            this.label7.Text = "Valor Total Cheques Custodiar/Depositar:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.cbMarcarTodos);
            this.pDados.Controls.Add(this.gTitulos);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 68);
            this.pDados.Name = "pDados";
            this.pDados.Size = new System.Drawing.Size(840, 368);
            this.pDados.TabIndex = 2;
            // 
            // cbMarcarTodos
            // 
            this.cbMarcarTodos.AutoSize = true;
            this.cbMarcarTodos.Location = new System.Drawing.Point(8, 12);
            this.cbMarcarTodos.Name = "cbMarcarTodos";
            this.cbMarcarTodos.Size = new System.Drawing.Size(15, 14);
            this.cbMarcarTodos.ST_Gravar = false;
            this.cbMarcarTodos.ST_LimparCampo = true;
            this.cbMarcarTodos.ST_NotNull = false;
            this.cbMarcarTodos.TabIndex = 4;
            this.cbMarcarTodos.UseVisualStyleBackColor = true;
            this.cbMarcarTodos.Click += new System.EventHandler(this.cbMarcarTodos_Click);
            // 
            // gTitulos
            // 
            this.gTitulos.AllowUserToAddRows = false;
            this.gTitulos.AllowUserToDeleteRows = false;
            this.gTitulos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTitulos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gTitulos.AutoGenerateColumns = false;
            this.gTitulos.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTitulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTitulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gTitulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTitulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stconciliarDataGridViewCheckBoxColumn,
            this.nrlanctochequeDataGridViewTextBoxColumn,
            this.nrchequeDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.vltituloDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.nomecliforDataGridViewTextBoxColumn,
            this.nrcgccpfDataGridViewTextBoxColumn,
            this.foneDataGridViewTextBoxColumn,
            this.cdbancoDataGridViewTextBoxColumn,
            this.dsbancoDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn});
            this.gTitulos.DataSource = this.bsTitulos;
            this.gTitulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTitulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTitulos.Location = new System.Drawing.Point(0, 0);
            this.gTitulos.Name = "gTitulos";
            this.gTitulos.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTitulos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gTitulos.RowHeadersWidth = 23;
            this.gTitulos.Size = new System.Drawing.Size(836, 339);
            this.gTitulos.TabIndex = 2;
            this.gTitulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gTitulos_CellClick);
            // 
            // stconciliarDataGridViewCheckBoxColumn
            // 
            this.stconciliarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stconciliarDataGridViewCheckBoxColumn.DataPropertyName = "St_conciliar";
            this.stconciliarDataGridViewCheckBoxColumn.HeaderText = "Selecionar";
            this.stconciliarDataGridViewCheckBoxColumn.Name = "stconciliarDataGridViewCheckBoxColumn";
            this.stconciliarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stconciliarDataGridViewCheckBoxColumn.Width = 63;
            // 
            // nrlanctochequeDataGridViewTextBoxColumn
            // 
            this.nrlanctochequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctochequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_lanctocheque";
            this.nrlanctochequeDataGridViewTextBoxColumn.HeaderText = "Nº Lancamento";
            this.nrlanctochequeDataGridViewTextBoxColumn.Name = "nrlanctochequeDataGridViewTextBoxColumn";
            this.nrlanctochequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrlanctochequeDataGridViewTextBoxColumn.Width = 97;
            // 
            // nrchequeDataGridViewTextBoxColumn
            // 
            this.nrchequeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrchequeDataGridViewTextBoxColumn.DataPropertyName = "Nr_cheque";
            this.nrchequeDataGridViewTextBoxColumn.HeaderText = "Nº Cheque";
            this.nrchequeDataGridViewTextBoxColumn.Name = "nrchequeDataGridViewTextBoxColumn";
            this.nrchequeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrchequeDataGridViewTextBoxColumn.Width = 78;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.dtemissaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 81;
            // 
            // vltituloDataGridViewTextBoxColumn
            // 
            this.vltituloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vltituloDataGridViewTextBoxColumn.DataPropertyName = "Vl_titulo";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0";
            this.vltituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.vltituloDataGridViewTextBoxColumn.HeaderText = "Vl. Titulo";
            this.vltituloDataGridViewTextBoxColumn.Name = "vltituloDataGridViewTextBoxColumn";
            this.vltituloDataGridViewTextBoxColumn.ReadOnly = true;
            this.vltituloDataGridViewTextBoxColumn.Width = 68;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle11.Format = "d";
            dataGridViewCellStyle11.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Dt. Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // nomecliforDataGridViewTextBoxColumn
            // 
            this.nomecliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomecliforDataGridViewTextBoxColumn.DataPropertyName = "Nomeclifor";
            this.nomecliforDataGridViewTextBoxColumn.HeaderText = "Emitente";
            this.nomecliforDataGridViewTextBoxColumn.Name = "nomecliforDataGridViewTextBoxColumn";
            this.nomecliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomecliforDataGridViewTextBoxColumn.Width = 73;
            // 
            // nrcgccpfDataGridViewTextBoxColumn
            // 
            this.nrcgccpfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcgccpfDataGridViewTextBoxColumn.DataPropertyName = "Nr_cgccpf";
            this.nrcgccpfDataGridViewTextBoxColumn.HeaderText = "CNPJ/CPF";
            this.nrcgccpfDataGridViewTextBoxColumn.Name = "nrcgccpfDataGridViewTextBoxColumn";
            this.nrcgccpfDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcgccpfDataGridViewTextBoxColumn.Width = 84;
            // 
            // foneDataGridViewTextBoxColumn
            // 
            this.foneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.foneDataGridViewTextBoxColumn.DataPropertyName = "Fone";
            this.foneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            this.foneDataGridViewTextBoxColumn.Name = "foneDataGridViewTextBoxColumn";
            this.foneDataGridViewTextBoxColumn.ReadOnly = true;
            this.foneDataGridViewTextBoxColumn.Width = 74;
            // 
            // cdbancoDataGridViewTextBoxColumn
            // 
            this.cdbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn.DataPropertyName = "Cd_banco";
            this.cdbancoDataGridViewTextBoxColumn.HeaderText = "Cd. Banco";
            this.cdbancoDataGridViewTextBoxColumn.Name = "cdbancoDataGridViewTextBoxColumn";
            this.cdbancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdbancoDataGridViewTextBoxColumn.Width = 76;
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
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 85;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "Observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacaoDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsTitulos
            // 
            this.bsTitulos.DataSource = typeof(CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTitulos;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 339);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(836, 25);
            this.bindingNavigator1.TabIndex = 3;
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // TFTitulosCustodia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 530);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTitulosCustodia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Localizar Cheques a Custodiar/Depositar";
            this.Load += new System.EventHandler(this.TFTitulosCustodia_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFTitulosCustodia_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTitulosCustodia_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pTotais.ResumeLayout(false);
            this.pTotais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_tot_custodiar)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTitulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pTotais;
        private Componentes.PanelDados pDados;
        public System.Windows.Forms.BindingSource bsTitulos;
        private Componentes.DataGridDefault gTitulos;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_banco;
        private Componentes.EditDefault cd_banco;
        private Componentes.EditDefault nomeclifor;
        private Componentes.EditDefault nr_cheque;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat vl_tot_custodiar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private Componentes.CheckBoxDefault cbMarcarTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stconciliarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctochequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vltituloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomecliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcgccpfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
    }
}