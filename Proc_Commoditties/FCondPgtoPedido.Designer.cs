namespace Proc_Commoditties
{
    partial class TFCondPgtoPedido
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
            System.Windows.Forms.Label label13;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCondPgtoPedido));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsPedido = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCondPgto = new Componentes.PanelDados(this.components);
            this.tp_juro = new Componentes.EditDefault(this.components);
            this.label71 = new System.Windows.Forms.Label();
            this.PC_JuroDiario_Atrazo = new Componentes.EditFloat(this.components);
            this.ST_ComEntrada = new Componentes.CheckBoxDefault(this.components);
            this.QT_DIASDESDOBRO = new Componentes.EditFloat(this.components);
            this.LB_QT_DiasDesdobro = new System.Windows.Forms.Label();
            this.Parcelas = new Componentes.EditFloat(this.components);
            this.CD_CondPGTO = new Componentes.EditDefault(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.BB_CondPGTO = new System.Windows.Forms.Button();
            this.ds_juro_fin = new Componentes.EditDefault(this.components);
            this.DS_CondPGTO = new Componentes.EditDefault(this.components);
            this.cd_juro_fin = new Componentes.EditDefault(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.tlpParcelas = new System.Windows.Forms.TableLayoutPanel();
            this.pGrid = new Componentes.PanelDados(this.components);
            this.dataGridDefault2 = new Componentes.DataGridDefault(this.components);
            this.BS_Parcelas = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Parcelas = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.Lbl_Entrada = new System.Windows.Forms.Label();
            this.VL_Entrada = new Componentes.EditFloat(this.components);
            this.VL_Parcela = new Componentes.EditFloat(this.components);
            this.Dt_vencto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edtDt_Vencto = new Componentes.EditData(this.components);
            this.label18 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pCondPgto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroDiario_Atrazo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_DIASDESDOBRO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parcelas)).BeginInit();
            this.tlpParcelas.SuspendLayout();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Parcelas)).BeginInit();
            this.BN_Parcelas.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Entrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Parcela)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label13.Location = new System.Drawing.Point(32, 113);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(49, 16);
            label13.TabIndex = 79;
            label13.Text = "Valor:";
            // 
            // bsPedido
            // 
            this.bsPedido.DataSource = typeof(CamadaDados.Faturamento.Pedido.TList_Pedido);
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(639, 43);
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
            this.bb_inutilizar.Text = "(F4)\r\nConfirmar";
            this.bb_inutilizar.ToolTipText = "Confirmar valores";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pCondPgto, 0, 0);
            this.tlpCentral.Controls.Add(this.tlpParcelas, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(639, 319);
            this.tlpCentral.TabIndex = 10;
            // 
            // pCondPgto
            // 
            this.pCondPgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCondPgto.Controls.Add(this.tp_juro);
            this.pCondPgto.Controls.Add(this.label71);
            this.pCondPgto.Controls.Add(this.PC_JuroDiario_Atrazo);
            this.pCondPgto.Controls.Add(this.ST_ComEntrada);
            this.pCondPgto.Controls.Add(this.QT_DIASDESDOBRO);
            this.pCondPgto.Controls.Add(this.LB_QT_DiasDesdobro);
            this.pCondPgto.Controls.Add(this.Parcelas);
            this.pCondPgto.Controls.Add(this.CD_CondPGTO);
            this.pCondPgto.Controls.Add(this.label12);
            this.pCondPgto.Controls.Add(this.label63);
            this.pCondPgto.Controls.Add(this.BB_CondPGTO);
            this.pCondPgto.Controls.Add(this.ds_juro_fin);
            this.pCondPgto.Controls.Add(this.DS_CondPGTO);
            this.pCondPgto.Controls.Add(this.cd_juro_fin);
            this.pCondPgto.Controls.Add(this.label23);
            this.pCondPgto.Controls.Add(this.label62);
            this.pCondPgto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCondPgto.Location = new System.Drawing.Point(5, 5);
            this.pCondPgto.Name = "pCondPgto";
            this.pCondPgto.NM_ProcDeletar = "";
            this.pCondPgto.NM_ProcGravar = "";
            this.pCondPgto.Size = new System.Drawing.Size(629, 110);
            this.pCondPgto.TabIndex = 0;
            // 
            // tp_juro
            // 
            this.tp_juro.BackColor = System.Drawing.SystemColors.Window;
            this.tp_juro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Tp_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_juro.Enabled = false;
            this.tp_juro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_juro.Location = new System.Drawing.Point(143, 82);
            this.tp_juro.Name = "tp_juro";
            this.tp_juro.NM_Alias = "";
            this.tp_juro.NM_Campo = "QT_Parcelas";
            this.tp_juro.NM_CampoBusca = "QT_Parcelas";
            this.tp_juro.NM_Param = "@P_QTD_PARCELAS";
            this.tp_juro.QTD_Zero = 0;
            this.tp_juro.Size = new System.Drawing.Size(59, 20);
            this.tp_juro.ST_AutoInc = false;
            this.tp_juro.ST_DisableAuto = false;
            this.tp_juro.ST_Float = false;
            this.tp_juro.ST_Gravar = false;
            this.tp_juro.ST_Int = false;
            this.tp_juro.ST_LimpaCampo = true;
            this.tp_juro.ST_NotNull = true;
            this.tp_juro.ST_PrimaryKey = false;
            this.tp_juro.TabIndex = 381;
            this.tp_juro.TextOld = null;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label71.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label71.Location = new System.Drawing.Point(73, 85);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(64, 13);
            this.label71.TabIndex = 382;
            this.label71.Text = "Tipo Juro:";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PC_JuroDiario_Atrazo
            // 
            this.PC_JuroDiario_Atrazo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPedido, "Pc_jurodiario_atrazo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_JuroDiario_Atrazo.DecimalPlaces = 7;
            this.PC_JuroDiario_Atrazo.Enabled = false;
            this.PC_JuroDiario_Atrazo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PC_JuroDiario_Atrazo.Location = new System.Drawing.Point(304, 83);
            this.PC_JuroDiario_Atrazo.Maximum = new decimal(new int[] {
            -1304428545,
            434162106,
            542,
            0});
            this.PC_JuroDiario_Atrazo.Name = "PC_JuroDiario_Atrazo";
            this.PC_JuroDiario_Atrazo.NM_Alias = "";
            this.PC_JuroDiario_Atrazo.NM_Campo = "PC_JuroDiario_Atrazo";
            this.PC_JuroDiario_Atrazo.NM_Param = "@P_PC_JURODIARIO_ATRAZO";
            this.PC_JuroDiario_Atrazo.Operador = "";
            this.PC_JuroDiario_Atrazo.Size = new System.Drawing.Size(88, 20);
            this.PC_JuroDiario_Atrazo.ST_AutoInc = false;
            this.PC_JuroDiario_Atrazo.ST_DisableAuto = false;
            this.PC_JuroDiario_Atrazo.ST_Gravar = false;
            this.PC_JuroDiario_Atrazo.ST_LimparCampo = true;
            this.PC_JuroDiario_Atrazo.ST_NotNull = false;
            this.PC_JuroDiario_Atrazo.ST_PrimaryKey = false;
            this.PC_JuroDiario_Atrazo.TabIndex = 380;
            this.PC_JuroDiario_Atrazo.ThousandsSeparator = true;
            // 
            // ST_ComEntrada
            // 
            this.ST_ComEntrada.AutoSize = true;
            this.ST_ComEntrada.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsPedido, "St_cometrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_ComEntrada.Enabled = false;
            this.ST_ComEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ST_ComEntrada.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_ComEntrada.Location = new System.Drawing.Point(387, 32);
            this.ST_ComEntrada.Name = "ST_ComEntrada";
            this.ST_ComEntrada.NM_Alias = "";
            this.ST_ComEntrada.NM_Campo = "ST_ComEntrada";
            this.ST_ComEntrada.NM_Param = "@P_ST_COMENTRADA";
            this.ST_ComEntrada.Size = new System.Drawing.Size(98, 17);
            this.ST_ComEntrada.ST_Gravar = false;
            this.ST_ComEntrada.ST_LimparCampo = true;
            this.ST_ComEntrada.ST_NotNull = false;
            this.ST_ComEntrada.TabIndex = 379;
            this.ST_ComEntrada.Text = "Com Entrada";
            this.ST_ComEntrada.UseVisualStyleBackColor = true;
            this.ST_ComEntrada.Vl_False = "N";
            this.ST_ComEntrada.Vl_True = "S";
            // 
            // QT_DIASDESDOBRO
            // 
            this.QT_DIASDESDOBRO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPedido, "Qt_diasdesdobro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.QT_DIASDESDOBRO.Enabled = false;
            this.QT_DIASDESDOBRO.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.QT_DIASDESDOBRO.Location = new System.Drawing.Point(314, 31);
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
            this.QT_DIASDESDOBRO.Size = new System.Drawing.Size(60, 20);
            this.QT_DIASDESDOBRO.ST_AutoInc = false;
            this.QT_DIASDESDOBRO.ST_DisableAuto = false;
            this.QT_DIASDESDOBRO.ST_Gravar = false;
            this.QT_DIASDESDOBRO.ST_LimparCampo = true;
            this.QT_DIASDESDOBRO.ST_NotNull = false;
            this.QT_DIASDESDOBRO.ST_PrimaryKey = false;
            this.QT_DIASDESDOBRO.TabIndex = 378;
            this.QT_DIASDESDOBRO.ThousandsSeparator = true;
            // 
            // LB_QT_DiasDesdobro
            // 
            this.LB_QT_DiasDesdobro.AutoSize = true;
            this.LB_QT_DiasDesdobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LB_QT_DiasDesdobro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_QT_DiasDesdobro.Location = new System.Drawing.Point(214, 34);
            this.LB_QT_DiasDesdobro.Name = "LB_QT_DiasDesdobro";
            this.LB_QT_DiasDesdobro.Size = new System.Drawing.Size(94, 13);
            this.LB_QT_DiasDesdobro.TabIndex = 377;
            this.LB_QT_DiasDesdobro.Text = "Dias Desdobro:";
            // 
            // Parcelas
            // 
            this.Parcelas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPedido, "QTD_Parcelas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Parcelas.Enabled = false;
            this.Parcelas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Parcelas.Location = new System.Drawing.Point(143, 31);
            this.Parcelas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Parcelas.Name = "Parcelas";
            this.Parcelas.NM_Alias = "";
            this.Parcelas.NM_Campo = "QT_Parcelas";
            this.Parcelas.NM_Param = "@P_QT_PARCELAS";
            this.Parcelas.Operador = "";
            this.Parcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Parcelas.Size = new System.Drawing.Size(65, 20);
            this.Parcelas.ST_AutoInc = false;
            this.Parcelas.ST_DisableAuto = false;
            this.Parcelas.ST_Gravar = false;
            this.Parcelas.ST_LimparCampo = true;
            this.Parcelas.ST_NotNull = false;
            this.Parcelas.ST_PrimaryKey = false;
            this.Parcelas.TabIndex = 376;
            this.Parcelas.ThousandsSeparator = true;
            // 
            // CD_CondPGTO
            // 
            this.CD_CondPGTO.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CondPGTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_CondPGTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CondPGTO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "CD_CondPGTO", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CondPGTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_CondPGTO.Location = new System.Drawing.Point(143, 5);
            this.CD_CondPGTO.Name = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Alias = "";
            this.CD_CondPGTO.NM_Campo = "CD_CondPGTO";
            this.CD_CondPGTO.NM_CampoBusca = "CD_CondPGTO";
            this.CD_CondPGTO.NM_Param = "";
            this.CD_CondPGTO.QTD_Zero = 0;
            this.CD_CondPGTO.Size = new System.Drawing.Size(88, 20);
            this.CD_CondPGTO.ST_AutoInc = false;
            this.CD_CondPGTO.ST_DisableAuto = false;
            this.CD_CondPGTO.ST_Float = false;
            this.CD_CondPGTO.ST_Gravar = true;
            this.CD_CondPGTO.ST_Int = false;
            this.CD_CondPGTO.ST_LimpaCampo = true;
            this.CD_CondPGTO.ST_NotNull = true;
            this.CD_CondPGTO.ST_PrimaryKey = false;
            this.CD_CondPGTO.TabIndex = 0;
            this.CD_CondPGTO.TextOld = null;
            this.CD_CondPGTO.Leave += new System.EventHandler(this.CD_CondPGTO_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(6, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 13);
            this.label12.TabIndex = 369;
            this.label12.Text = "Condição Pagamento:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label63.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label63.Location = new System.Drawing.Point(213, 85);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(85, 13);
            this.label63.TabIndex = 375;
            this.label63.Text = "% Juro Diario:";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BB_CondPGTO
            // 
            this.BB_CondPGTO.Image = ((System.Drawing.Image)(resources.GetObject("BB_CondPGTO.Image")));
            this.BB_CondPGTO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_CondPGTO.Location = new System.Drawing.Point(233, 5);
            this.BB_CondPGTO.Name = "BB_CondPGTO";
            this.BB_CondPGTO.Size = new System.Drawing.Size(28, 19);
            this.BB_CondPGTO.TabIndex = 1;
            this.BB_CondPGTO.UseVisualStyleBackColor = true;
            this.BB_CondPGTO.Click += new System.EventHandler(this.BB_CondPGTO_Click);
            // 
            // ds_juro_fin
            // 
            this.ds_juro_fin.BackColor = System.Drawing.SystemColors.Window;
            this.ds_juro_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_juro_fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_juro_fin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Ds_juro_fin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_juro_fin.Enabled = false;
            this.ds_juro_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_juro_fin.Location = new System.Drawing.Point(185, 57);
            this.ds_juro_fin.Name = "ds_juro_fin";
            this.ds_juro_fin.NM_Alias = "";
            this.ds_juro_fin.NM_Campo = "QT_Parcelas";
            this.ds_juro_fin.NM_CampoBusca = "QT_Parcelas";
            this.ds_juro_fin.NM_Param = "@P_QTD_PARCELAS";
            this.ds_juro_fin.QTD_Zero = 0;
            this.ds_juro_fin.Size = new System.Drawing.Size(436, 20);
            this.ds_juro_fin.ST_AutoInc = false;
            this.ds_juro_fin.ST_DisableAuto = false;
            this.ds_juro_fin.ST_Float = false;
            this.ds_juro_fin.ST_Gravar = false;
            this.ds_juro_fin.ST_Int = false;
            this.ds_juro_fin.ST_LimpaCampo = true;
            this.ds_juro_fin.ST_NotNull = true;
            this.ds_juro_fin.ST_PrimaryKey = false;
            this.ds_juro_fin.TabIndex = 374;
            this.ds_juro_fin.TextOld = null;
            // 
            // DS_CondPGTO
            // 
            this.DS_CondPGTO.BackColor = System.Drawing.SystemColors.Window;
            this.DS_CondPGTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_CondPGTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_CondPGTO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "DS_CondPgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_CondPGTO.Enabled = false;
            this.DS_CondPGTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_CondPGTO.Location = new System.Drawing.Point(265, 5);
            this.DS_CondPGTO.Name = "DS_CondPGTO";
            this.DS_CondPGTO.NM_Alias = "";
            this.DS_CondPGTO.NM_Campo = "DS_CondPGTO";
            this.DS_CondPGTO.NM_CampoBusca = "DS_CondPGTO";
            this.DS_CondPGTO.NM_Param = "";
            this.DS_CondPGTO.QTD_Zero = 0;
            this.DS_CondPGTO.ReadOnly = true;
            this.DS_CondPGTO.Size = new System.Drawing.Size(356, 20);
            this.DS_CondPGTO.ST_AutoInc = false;
            this.DS_CondPGTO.ST_DisableAuto = false;
            this.DS_CondPGTO.ST_Float = false;
            this.DS_CondPGTO.ST_Gravar = false;
            this.DS_CondPGTO.ST_Int = false;
            this.DS_CondPGTO.ST_LimpaCampo = true;
            this.DS_CondPGTO.ST_NotNull = false;
            this.DS_CondPGTO.ST_PrimaryKey = false;
            this.DS_CondPGTO.TabIndex = 370;
            this.DS_CondPGTO.TextOld = null;
            // 
            // cd_juro_fin
            // 
            this.cd_juro_fin.BackColor = System.Drawing.SystemColors.Window;
            this.cd_juro_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_juro_fin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_juro_fin.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPedido, "Cd_juro_fin", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_juro_fin.Enabled = false;
            this.cd_juro_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_juro_fin.Location = new System.Drawing.Point(143, 57);
            this.cd_juro_fin.Name = "cd_juro_fin";
            this.cd_juro_fin.NM_Alias = "";
            this.cd_juro_fin.NM_Campo = "QT_Parcelas";
            this.cd_juro_fin.NM_CampoBusca = "QT_Parcelas";
            this.cd_juro_fin.NM_Param = "@P_QTD_PARCELAS";
            this.cd_juro_fin.QTD_Zero = 0;
            this.cd_juro_fin.Size = new System.Drawing.Size(40, 20);
            this.cd_juro_fin.ST_AutoInc = false;
            this.cd_juro_fin.ST_DisableAuto = false;
            this.cd_juro_fin.ST_Float = false;
            this.cd_juro_fin.ST_Gravar = false;
            this.cd_juro_fin.ST_Int = false;
            this.cd_juro_fin.ST_LimpaCampo = true;
            this.cd_juro_fin.ST_NotNull = true;
            this.cd_juro_fin.ST_PrimaryKey = false;
            this.cd_juro_fin.TabIndex = 372;
            this.cd_juro_fin.TextOld = null;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(8, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(129, 13);
            this.label23.TabIndex = 371;
            this.label23.Text = "Quantidade Parcelas:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label62.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label62.Location = new System.Drawing.Point(39, 60);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(98, 13);
            this.label62.TabIndex = 373;
            this.label62.Text = "Juro Financeiro:";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpParcelas
            // 
            this.tlpParcelas.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpParcelas.ColumnCount = 2;
            this.tlpParcelas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParcelas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tlpParcelas.Controls.Add(this.pGrid, 0, 0);
            this.tlpParcelas.Controls.Add(this.panelDados1, 1, 0);
            this.tlpParcelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParcelas.Location = new System.Drawing.Point(5, 123);
            this.tlpParcelas.Name = "tlpParcelas";
            this.tlpParcelas.RowCount = 1;
            this.tlpParcelas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParcelas.Size = new System.Drawing.Size(629, 191);
            this.tlpParcelas.TabIndex = 1;
            // 
            // pGrid
            // 
            this.pGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pGrid.Controls.Add(this.dataGridDefault2);
            this.pGrid.Controls.Add(this.BN_Parcelas);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.Location = new System.Drawing.Point(5, 5);
            this.pGrid.Name = "pGrid";
            this.pGrid.NM_ProcDeletar = "";
            this.pGrid.NM_ProcGravar = "";
            this.pGrid.Size = new System.Drawing.Size(396, 181);
            this.pGrid.TabIndex = 0;
            // 
            // dataGridDefault2
            // 
            this.dataGridDefault2.AllowUserToAddRows = false;
            this.dataGridDefault2.AllowUserToDeleteRows = false;
            this.dataGridDefault2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridDefault2.AutoGenerateColumns = false;
            this.dataGridDefault2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridDefault2.ColumnHeadersHeight = 22;
            this.dataGridDefault2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dt_vencto,
            this.dataGridViewTextBoxColumn53});
            this.dataGridDefault2.DataSource = this.BS_Parcelas;
            this.dataGridDefault2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault2.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault2.Name = "dataGridDefault2";
            this.dataGridDefault2.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridDefault2.RowHeadersWidth = 23;
            this.dataGridDefault2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridDefault2.Size = new System.Drawing.Size(392, 152);
            this.dataGridDefault2.TabIndex = 83;
            this.dataGridDefault2.TabStop = false;
            // 
            // BS_Parcelas
            // 
            this.BS_Parcelas.DataMember = "Pedidos_DT_Vencto";
            this.BS_Parcelas.DataSource = this.bsPedido;
            this.BS_Parcelas.PositionChanged += new System.EventHandler(this.BS_Parcelas_PositionChanged);
            // 
            // BN_Parcelas
            // 
            this.BN_Parcelas.AddNewItem = null;
            this.BN_Parcelas.BindingSource = this.BS_Parcelas;
            this.BN_Parcelas.CountItem = this.bindingNavigatorCountItem;
            this.BN_Parcelas.CountItemFormat = "de {0}";
            this.BN_Parcelas.DeleteItem = null;
            this.BN_Parcelas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_Parcelas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Parcelas.Location = new System.Drawing.Point(0, 152);
            this.BN_Parcelas.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Parcelas.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Parcelas.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Parcelas.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Parcelas.Name = "BN_Parcelas";
            this.BN_Parcelas.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_Parcelas.Size = new System.Drawing.Size(392, 25);
            this.BN_Parcelas.TabIndex = 82;
            this.BN_Parcelas.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registros";
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
            this.bindingNavigatorMoveNextItem.Text = "Próximo Registro";
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
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.edtDt_Vencto);
            this.panelDados1.Controls.Add(this.label18);
            this.panelDados1.Controls.Add(this.Lbl_Entrada);
            this.panelDados1.Controls.Add(this.VL_Entrada);
            this.panelDados1.Controls.Add(label13);
            this.panelDados1.Controls.Add(this.VL_Parcela);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(409, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(215, 181);
            this.panelDados1.TabIndex = 0;
            // 
            // Lbl_Entrada
            // 
            this.Lbl_Entrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Entrada.AutoSize = true;
            this.Lbl_Entrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.Lbl_Entrada.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_Entrada.Location = new System.Drawing.Point(32, 25);
            this.Lbl_Entrada.Name = "Lbl_Entrada";
            this.Lbl_Entrada.Size = new System.Drawing.Size(66, 16);
            this.Lbl_Entrada.TabIndex = 80;
            this.Lbl_Entrada.Text = "Entrada:";
            this.Lbl_Entrada.Visible = false;
            // 
            // VL_Entrada
            // 
            this.VL_Entrada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VL_Entrada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsPedido, "Vl_entrada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Entrada.DecimalPlaces = 2;
            this.VL_Entrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.VL_Entrada.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VL_Entrada.Location = new System.Drawing.Point(31, 44);
            this.VL_Entrada.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.VL_Entrada.Name = "VL_Entrada";
            this.VL_Entrada.NM_Alias = "";
            this.VL_Entrada.NM_Campo = "";
            this.VL_Entrada.NM_Param = "";
            this.VL_Entrada.Operador = "";
            this.VL_Entrada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Entrada.Size = new System.Drawing.Size(150, 22);
            this.VL_Entrada.ST_AutoInc = false;
            this.VL_Entrada.ST_DisableAuto = false;
            this.VL_Entrada.ST_Gravar = false;
            this.VL_Entrada.ST_LimparCampo = true;
            this.VL_Entrada.ST_NotNull = false;
            this.VL_Entrada.ST_PrimaryKey = false;
            this.VL_Entrada.TabIndex = 0;
            this.VL_Entrada.ThousandsSeparator = true;
            this.VL_Entrada.Visible = false;
            this.VL_Entrada.Leave += new System.EventHandler(this.VL_Entrada_Leave);
            // 
            // VL_Parcela
            // 
            this.VL_Parcela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VL_Parcela.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Parcelas, "VL_Parcela", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Parcela.DecimalPlaces = 2;
            this.VL_Parcela.Enabled = false;
            this.VL_Parcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.VL_Parcela.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.VL_Parcela.Location = new System.Drawing.Point(31, 132);
            this.VL_Parcela.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.VL_Parcela.Name = "VL_Parcela";
            this.VL_Parcela.NM_Alias = "";
            this.VL_Parcela.NM_Campo = "";
            this.VL_Parcela.NM_Param = "";
            this.VL_Parcela.Operador = "";
            this.VL_Parcela.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Parcela.Size = new System.Drawing.Size(150, 22);
            this.VL_Parcela.ST_AutoInc = false;
            this.VL_Parcela.ST_DisableAuto = false;
            this.VL_Parcela.ST_Gravar = false;
            this.VL_Parcela.ST_LimparCampo = true;
            this.VL_Parcela.ST_NotNull = false;
            this.VL_Parcela.ST_PrimaryKey = false;
            this.VL_Parcela.TabIndex = 2;
            this.VL_Parcela.ThousandsSeparator = true;
            this.VL_Parcela.Leave += new System.EventHandler(this.VL_Parcela_Leave);
            // 
            // Dt_vencto
            // 
            this.Dt_vencto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_vencto.DataPropertyName = "Dt_vencto";
            this.Dt_vencto.HeaderText = "Dt.Vencto";
            this.Dt_vencto.Name = "Dt_vencto";
            this.Dt_vencto.ReadOnly = true;
            this.Dt_vencto.Width = 80;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn53.DataPropertyName = "VL_Parcela";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = "0";
            this.dataGridViewTextBoxColumn53.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn53.HeaderText = "Vl. Parcela";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Width = 83;
            // 
            // edtDt_Vencto
            // 
            this.edtDt_Vencto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.edtDt_Vencto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Parcelas, "Dt_venctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.edtDt_Vencto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDt_Vencto.Location = new System.Drawing.Point(35, 88);
            this.edtDt_Vencto.Mask = "00/00/0000";
            this.edtDt_Vencto.Name = "edtDt_Vencto";
            this.edtDt_Vencto.NM_Alias = "";
            this.edtDt_Vencto.NM_Campo = "";
            this.edtDt_Vencto.NM_CampoBusca = "";
            this.edtDt_Vencto.NM_Param = "";
            this.edtDt_Vencto.Operador = "";
            this.edtDt_Vencto.Size = new System.Drawing.Size(86, 22);
            this.edtDt_Vencto.ST_Gravar = false;
            this.edtDt_Vencto.ST_LimpaCampo = true;
            this.edtDt_Vencto.ST_NotNull = false;
            this.edtDt_Vencto.ST_PrimaryKey = false;
            this.edtDt_Vencto.TabIndex = 81;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(32, 69);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 16);
            this.label18.TabIndex = 82;
            this.label18.Text = "Vencimento";
            // 
            // TFCondPgtoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 362);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCondPgtoPedido";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro Pedido";
            this.Load += new System.EventHandler(this.TFCondPgtoPedido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCondPgtoPedido_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsPedido)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pCondPgto.ResumeLayout(false);
            this.pCondPgto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroDiario_Atrazo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QT_DIASDESDOBRO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parcelas)).EndInit();
            this.tlpParcelas.ResumeLayout(false);
            this.pGrid.ResumeLayout(false);
            this.pGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Parcelas)).EndInit();
            this.BN_Parcelas.ResumeLayout(false);
            this.BN_Parcelas.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Entrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Parcela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsPedido;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCondPgto;
        private Componentes.EditDefault tp_juro;
        private System.Windows.Forms.Label label71;
        private Componentes.EditFloat PC_JuroDiario_Atrazo;
        private Componentes.CheckBoxDefault ST_ComEntrada;
        private Componentes.EditFloat QT_DIASDESDOBRO;
        private System.Windows.Forms.Label LB_QT_DiasDesdobro;
        private Componentes.EditFloat Parcelas;
        private Componentes.EditDefault CD_CondPGTO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Button BB_CondPGTO;
        private Componentes.EditDefault ds_juro_fin;
        private Componentes.EditDefault DS_CondPGTO;
        private Componentes.EditDefault cd_juro_fin;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.BindingSource BS_Parcelas;
        private System.Windows.Forms.TableLayoutPanel tlpParcelas;
        private Componentes.PanelDados pGrid;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault2;
        private System.Windows.Forms.BindingNavigator BN_Parcelas;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public System.Windows.Forms.Label Lbl_Entrada;
        public Componentes.EditFloat VL_Entrada;
        private Componentes.EditFloat VL_Parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_vencto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private Componentes.EditData edtDt_Vencto;
        public System.Windows.Forms.Label label18;
    }
}