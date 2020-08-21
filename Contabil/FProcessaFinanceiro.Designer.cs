namespace Contabil
{
    partial class TFProcessaFinanceiro
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
            System.Windows.Forms.Label label26;
            System.Windows.Forms.Label label27;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label28;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProcessaFinanceiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_config = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.classificacaodeb = new Componentes.EditDefault(this.components);
            this.bsFinanceiro = new System.Windows.Forms.BindingSource(this.components);
            this.ds_contacred = new Componentes.EditDefault(this.components);
            this.cd_contadeb = new Componentes.EditDefault(this.components);
            this.ds_contadeb = new Componentes.EditDefault(this.components);
            this.cd_contacred = new Componentes.EditDefault(this.components);
            this.classificacaocred = new Componentes.EditDefault(this.components);
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.vl_fin = new Componentes.EditFloat(this.components);
            this.vl_ini = new Componentes.EditFloat(this.components);
            this.bb_contacred = new System.Windows.Forms.Button();
            this.contacred = new Componentes.EditDefault(this.components);
            this.contadeb = new Componentes.EditDefault(this.components);
            this.bb_contadeb = new System.Windows.Forms.Button();
            this.st_reprocessar = new Componentes.CheckBoxDefault(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.nr_documento = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.bb_clifor = new System.Windows.Forms.Button();
            this.bb_movimentacao = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbMarcaFin = new Componentes.CheckBoxDefault(this.components);
            this.gFinanceiro = new Componentes.DataGridDefault(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nrDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dTLanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vLLanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tPMovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nMCliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpduplicataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSHistoricoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDContaDebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDContaCreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContaDebitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContaCreditada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDLoteCTBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsFin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alterarHistoricoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bnImpostos = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblSelecionados = new System.Windows.Forms.ToolStripLabel();
            this.lblInconsistente = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tot_receber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tot_pagar = new System.Windows.Forms.ToolStripTextBox();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinanceiro)).BeginInit();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ini)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFinanceiro)).BeginInit();
            this.cmsFin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnImpostos)).BeginInit();
            this.bnImpostos.SuspendLayout();
            this.SuspendLayout();
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label26.Location = new System.Drawing.Point(6, 32);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(88, 13);
            label26.TabIndex = 102;
            label26.Text = "Conta Crédito:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label27.Location = new System.Drawing.Point(9, 6);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(85, 13);
            label27.TabIndex = 103;
            label27.Text = "Conta Débito:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(759, 32);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(49, 13);
            label5.TabIndex = 126;
            label5.Text = "Dt. Final:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(754, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 13);
            label4.TabIndex = 124;
            label4.Text = "Dt. Inicial:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(394, 6);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(80, 13);
            label3.TabIndex = 121;
            label3.Text = "Nº Documento:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(203, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 13);
            label1.TabIndex = 120;
            label1.Text = "TP. Duplicata:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(245, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 13);
            label2.TabIndex = 117;
            label2.Text = "Clifor:";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label28.Location = new System.Drawing.Point(36, 31);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(51, 13);
            label28.TabIndex = 114;
            label28.Text = "Historico:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label30.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label30.Location = new System.Drawing.Point(36, 6);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(51, 13);
            label30.TabIndex = 111;
            label30.Text = "Empresa:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(586, 31);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(66, 13);
            label8.TabIndex = 162;
            label8.Text = "Conta Cred.:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(589, 6);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(64, 13);
            label9.TabIndex = 161;
            label9.Text = "Conta Deb.:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(891, 33);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(42, 13);
            label6.TabIndex = 166;
            label6.Text = "Vl. Fin.:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(891, 7);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(39, 13);
            label7.TabIndex = 164;
            label7.Text = "Vl. Ini.:";
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.bb_config});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(981, 43);
            this.barraMenu.TabIndex = 13;
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
            this.BB_Buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Buscar.ForeColor = System.Drawing.Color.Green;
            this.BB_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Buscar.Image")));
            this.BB_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Buscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Buscar.Name = "BB_Buscar";
            this.BB_Buscar.Size = new System.Drawing.Size(80, 40);
            this.BB_Buscar.Text = "(F7)\r\nBuscar";
            this.BB_Buscar.ToolTipText = "Localizar Registros";
            this.BB_Buscar.Click += new System.EventHandler(this.BB_Buscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // bb_config
            // 
            this.bb_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bb_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.bb_config.ForeColor = System.Drawing.Color.Green;
            this.bb_config.Image = ((System.Drawing.Image)(resources.GetObject("bb_config.Image")));
            this.bb_config.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bb_config.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_config.Name = "bb_config";
            this.bb_config.Size = new System.Drawing.Size(117, 40);
            this.bb_config.Text = "(F9)\r\nConfiguração";
            this.bb_config.ToolTipText = "Configuração";
            this.bb_config.Click += new System.EventHandler(this.bb_config_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados2, 0, 2);
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 3;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tlpCentral.Size = new System.Drawing.Size(981, 456);
            this.tlpCentral.TabIndex = 14;
            // 
            // panelDados2
            // 
            this.panelDados2.BackColor = System.Drawing.Color.Silver;
            this.panelDados2.Controls.Add(this.classificacaodeb);
            this.panelDados2.Controls.Add(this.ds_contacred);
            this.panelDados2.Controls.Add(this.cd_contadeb);
            this.panelDados2.Controls.Add(this.ds_contadeb);
            this.panelDados2.Controls.Add(this.cd_contacred);
            this.panelDados2.Controls.Add(label26);
            this.panelDados2.Controls.Add(label27);
            this.panelDados2.Controls.Add(this.classificacaocred);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 401);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(975, 52);
            this.panelDados2.TabIndex = 3;
            // 
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "Cd_classificacaodeb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaodeb.Enabled = false;
            this.classificacaodeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaodeb.Location = new System.Drawing.Point(566, 3);
            this.classificacaodeb.Name = "classificacaodeb";
            this.classificacaodeb.NM_Alias = "";
            this.classificacaodeb.NM_Campo = "CD_Classificacao";
            this.classificacaodeb.NM_CampoBusca = "CD_Classificacao";
            this.classificacaodeb.NM_Param = "@P_CD_CLASSIFICACAO";
            this.classificacaodeb.QTD_Zero = 0;
            this.classificacaodeb.Size = new System.Drawing.Size(123, 20);
            this.classificacaodeb.ST_AutoInc = false;
            this.classificacaodeb.ST_DisableAuto = false;
            this.classificacaodeb.ST_Float = false;
            this.classificacaodeb.ST_Gravar = false;
            this.classificacaodeb.ST_Int = false;
            this.classificacaodeb.ST_LimpaCampo = true;
            this.classificacaodeb.ST_NotNull = false;
            this.classificacaodeb.ST_PrimaryKey = false;
            this.classificacaodeb.TabIndex = 104;
            this.classificacaodeb.TextOld = null;
            // 
            // bsFinanceiro
            // 
            this.bsFinanceiro.DataSource = typeof(CamadaDados.Contabil.TRegistro_Lan_ProcFinanceiro);
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "Ds_contacre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contacred.Enabled = false;
            this.ds_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contacred.Location = new System.Drawing.Point(174, 29);
            this.ds_contacred.Name = "ds_contacred";
            this.ds_contacred.NM_Alias = "";
            this.ds_contacred.NM_Campo = "ds_contaCTB";
            this.ds_contacred.NM_CampoBusca = "ds_contaCTB";
            this.ds_contacred.NM_Param = "";
            this.ds_contacred.QTD_Zero = 0;
            this.ds_contacred.Size = new System.Drawing.Size(391, 20);
            this.ds_contacred.ST_AutoInc = false;
            this.ds_contacred.ST_DisableAuto = false;
            this.ds_contacred.ST_Float = false;
            this.ds_contacred.ST_Gravar = false;
            this.ds_contacred.ST_Int = false;
            this.ds_contacred.ST_LimpaCampo = true;
            this.ds_contacred.ST_NotNull = false;
            this.ds_contacred.ST_PrimaryKey = false;
            this.ds_contacred.TabIndex = 101;
            this.ds_contacred.TextOld = null;
            // 
            // cd_contadeb
            // 
            this.cd_contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "CD_ContaDeb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contadeb.Enabled = false;
            this.cd_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contadeb.Location = new System.Drawing.Point(100, 3);
            this.cd_contadeb.Name = "cd_contadeb";
            this.cd_contadeb.NM_Alias = "a";
            this.cd_contadeb.NM_Campo = "cd_conta_CTB";
            this.cd_contadeb.NM_CampoBusca = "cd_conta_CTB";
            this.cd_contadeb.NM_Param = "@P_CD_CONTA_CTB";
            this.cd_contadeb.QTD_Zero = 0;
            this.cd_contadeb.Size = new System.Drawing.Size(73, 20);
            this.cd_contadeb.ST_AutoInc = false;
            this.cd_contadeb.ST_DisableAuto = false;
            this.cd_contadeb.ST_Float = false;
            this.cd_contadeb.ST_Gravar = true;
            this.cd_contadeb.ST_Int = false;
            this.cd_contadeb.ST_LimpaCampo = true;
            this.cd_contadeb.ST_NotNull = true;
            this.cd_contadeb.ST_PrimaryKey = false;
            this.cd_contadeb.TabIndex = 98;
            this.cd_contadeb.TextOld = null;
            // 
            // ds_contadeb
            // 
            this.ds_contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "Ds_contadeb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_contadeb.Enabled = false;
            this.ds_contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_contadeb.Location = new System.Drawing.Point(174, 3);
            this.ds_contadeb.Name = "ds_contadeb";
            this.ds_contadeb.NM_Alias = "";
            this.ds_contadeb.NM_Campo = "ds_contaCTB";
            this.ds_contadeb.NM_CampoBusca = "ds_contaCTB";
            this.ds_contadeb.NM_Param = "";
            this.ds_contadeb.QTD_Zero = 0;
            this.ds_contadeb.Size = new System.Drawing.Size(391, 20);
            this.ds_contadeb.ST_AutoInc = false;
            this.ds_contadeb.ST_DisableAuto = false;
            this.ds_contadeb.ST_Float = false;
            this.ds_contadeb.ST_Gravar = false;
            this.ds_contadeb.ST_Int = false;
            this.ds_contadeb.ST_LimpaCampo = true;
            this.ds_contadeb.ST_NotNull = false;
            this.ds_contadeb.ST_PrimaryKey = false;
            this.ds_contadeb.TabIndex = 99;
            this.ds_contadeb.TextOld = null;
            // 
            // cd_contacred
            // 
            this.cd_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.cd_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "CD_ContaCre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_contacred.Enabled = false;
            this.cd_contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_contacred.Location = new System.Drawing.Point(100, 29);
            this.cd_contacred.Name = "cd_contacred";
            this.cd_contacred.NM_Alias = "a";
            this.cd_contacred.NM_Campo = "cd_conta_CTB";
            this.cd_contacred.NM_CampoBusca = "cd_conta_CTB";
            this.cd_contacred.NM_Param = "";
            this.cd_contacred.QTD_Zero = 0;
            this.cd_contacred.Size = new System.Drawing.Size(73, 20);
            this.cd_contacred.ST_AutoInc = false;
            this.cd_contacred.ST_DisableAuto = false;
            this.cd_contacred.ST_Float = false;
            this.cd_contacred.ST_Gravar = true;
            this.cd_contacred.ST_Int = false;
            this.cd_contacred.ST_LimpaCampo = true;
            this.cd_contacred.ST_NotNull = true;
            this.cd_contacred.ST_PrimaryKey = false;
            this.cd_contacred.TabIndex = 100;
            this.cd_contacred.TextOld = null;
            // 
            // classificacaocred
            // 
            this.classificacaocred.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaocred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaocred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaocred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFinanceiro, "Cd_classificacaocre", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.classificacaocred.Enabled = false;
            this.classificacaocred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.classificacaocred.Location = new System.Drawing.Point(566, 29);
            this.classificacaocred.Name = "classificacaocred";
            this.classificacaocred.NM_Alias = "";
            this.classificacaocred.NM_Campo = "CD_Classificacao";
            this.classificacaocred.NM_CampoBusca = "CD_Classificacao";
            this.classificacaocred.NM_Param = "@P_CD_CLASSIFICACAO";
            this.classificacaocred.QTD_Zero = 0;
            this.classificacaocred.Size = new System.Drawing.Size(123, 20);
            this.classificacaocred.ST_AutoInc = false;
            this.classificacaocred.ST_DisableAuto = false;
            this.classificacaocred.ST_Float = false;
            this.classificacaocred.ST_Gravar = false;
            this.classificacaocred.ST_Int = false;
            this.classificacaocred.ST_LimpaCampo = true;
            this.classificacaocred.ST_NotNull = false;
            this.classificacaocred.ST_PrimaryKey = false;
            this.classificacaocred.TabIndex = 105;
            this.classificacaocred.TextOld = null;
            // 
            // pFiltro
            // 
            this.pFiltro.BackColor = System.Drawing.Color.Silver;
            this.pFiltro.Controls.Add(label6);
            this.pFiltro.Controls.Add(this.vl_fin);
            this.pFiltro.Controls.Add(label7);
            this.pFiltro.Controls.Add(this.vl_ini);
            this.pFiltro.Controls.Add(this.bb_contacred);
            this.pFiltro.Controls.Add(label8);
            this.pFiltro.Controls.Add(this.contacred);
            this.pFiltro.Controls.Add(this.contadeb);
            this.pFiltro.Controls.Add(this.bb_contadeb);
            this.pFiltro.Controls.Add(label9);
            this.pFiltro.Controls.Add(this.st_reprocessar);
            this.pFiltro.Controls.Add(label5);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(label4);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.nr_documento);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.tp_duplicata);
            this.pFiltro.Controls.Add(this.cd_clifor);
            this.pFiltro.Controls.Add(this.bb_clifor);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.bb_movimentacao);
            this.pFiltro.Controls.Add(label28);
            this.pFiltro.Controls.Add(this.cd_historico);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(label30);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(975, 53);
            this.pFiltro.TabIndex = 0;
            // 
            // vl_fin
            // 
            this.vl_fin.DecimalPlaces = 2;
            this.vl_fin.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_fin.Location = new System.Drawing.Point(936, 29);
            this.vl_fin.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_fin.Name = "vl_fin";
            this.vl_fin.NM_Alias = "";
            this.vl_fin.NM_Campo = "";
            this.vl_fin.NM_Param = "";
            this.vl_fin.Operador = "";
            this.vl_fin.Size = new System.Drawing.Size(88, 20);
            this.vl_fin.ST_AutoInc = false;
            this.vl_fin.ST_DisableAuto = false;
            this.vl_fin.ST_Gravar = false;
            this.vl_fin.ST_LimparCampo = true;
            this.vl_fin.ST_NotNull = false;
            this.vl_fin.ST_PrimaryKey = false;
            this.vl_fin.TabIndex = 165;
            this.vl_fin.ThousandsSeparator = true;
            // 
            // vl_ini
            // 
            this.vl_ini.DecimalPlaces = 2;
            this.vl_ini.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_ini.Location = new System.Drawing.Point(936, 3);
            this.vl_ini.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_ini.Name = "vl_ini";
            this.vl_ini.NM_Alias = "";
            this.vl_ini.NM_Campo = "";
            this.vl_ini.NM_Param = "";
            this.vl_ini.Operador = "";
            this.vl_ini.Size = new System.Drawing.Size(88, 20);
            this.vl_ini.ST_AutoInc = false;
            this.vl_ini.ST_DisableAuto = false;
            this.vl_ini.ST_Gravar = false;
            this.vl_ini.ST_LimparCampo = true;
            this.vl_ini.ST_NotNull = false;
            this.vl_ini.ST_PrimaryKey = false;
            this.vl_ini.TabIndex = 163;
            this.vl_ini.ThousandsSeparator = true;
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(718, 29);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(30, 20);
            this.bb_contacred.TabIndex = 160;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // contacred
            // 
            this.contacred.BackColor = System.Drawing.SystemColors.Window;
            this.contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.contacred.Location = new System.Drawing.Point(659, 29);
            this.contacred.Name = "contacred";
            this.contacred.NM_Alias = "a";
            this.contacred.NM_Campo = "cd_conta_ctb";
            this.contacred.NM_CampoBusca = "cd_conta_ctb";
            this.contacred.NM_Param = "@P_CD_MOVIMENTACAO";
            this.contacred.QTD_Zero = 0;
            this.contacred.Size = new System.Drawing.Size(56, 20);
            this.contacred.ST_AutoInc = false;
            this.contacred.ST_DisableAuto = false;
            this.contacred.ST_Float = false;
            this.contacred.ST_Gravar = true;
            this.contacred.ST_Int = true;
            this.contacred.ST_LimpaCampo = true;
            this.contacred.ST_NotNull = false;
            this.contacred.ST_PrimaryKey = false;
            this.contacred.TabIndex = 159;
            this.contacred.TextOld = null;
            this.contacred.Leave += new System.EventHandler(this.contacred_Leave);
            // 
            // contadeb
            // 
            this.contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.contadeb.Location = new System.Drawing.Point(659, 3);
            this.contadeb.Name = "contadeb";
            this.contadeb.NM_Alias = "a";
            this.contadeb.NM_Campo = "cd_conta_ctb";
            this.contadeb.NM_CampoBusca = "cd_conta_ctb";
            this.contadeb.NM_Param = "@P_CD_EMPRESA";
            this.contadeb.QTD_Zero = 0;
            this.contadeb.Size = new System.Drawing.Size(56, 20);
            this.contadeb.ST_AutoInc = false;
            this.contadeb.ST_DisableAuto = false;
            this.contadeb.ST_Float = false;
            this.contadeb.ST_Gravar = true;
            this.contadeb.ST_Int = false;
            this.contadeb.ST_LimpaCampo = true;
            this.contadeb.ST_NotNull = false;
            this.contadeb.ST_PrimaryKey = false;
            this.contadeb.TabIndex = 157;
            this.contadeb.TextOld = null;
            this.contadeb.Leave += new System.EventHandler(this.contadeb_Leave);
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(718, 3);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(30, 20);
            this.bb_contadeb.TabIndex = 158;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // st_reprocessar
            // 
            this.st_reprocessar.AutoSize = true;
            this.st_reprocessar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_reprocessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_reprocessar.Location = new System.Drawing.Point(418, 31);
            this.st_reprocessar.Name = "st_reprocessar";
            this.st_reprocessar.NM_Alias = "";
            this.st_reprocessar.NM_Campo = "";
            this.st_reprocessar.NM_Param = "";
            this.st_reprocessar.Size = new System.Drawing.Size(162, 17);
            this.st_reprocessar.ST_Gravar = false;
            this.st_reprocessar.ST_LimparCampo = true;
            this.st_reprocessar.ST_NotNull = false;
            this.st_reprocessar.TabIndex = 9;
            this.st_reprocessar.Text = "Reprocessar Movimento";
            this.st_reprocessar.UseVisualStyleBackColor = true;
            this.st_reprocessar.Vl_False = "";
            this.st_reprocessar.Vl_True = "";
            this.st_reprocessar.CheckedChanged += new System.EventHandler(this.st_reprocessar_CheckedChanged);
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(814, 29);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(71, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 11;
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(814, 3);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(71, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 10;
            // 
            // nr_documento
            // 
            this.nr_documento.BackColor = System.Drawing.SystemColors.Window;
            this.nr_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_documento.Location = new System.Drawing.Point(480, 3);
            this.nr_documento.Name = "nr_documento";
            this.nr_documento.NM_Alias = "";
            this.nr_documento.NM_Campo = "";
            this.nr_documento.NM_CampoBusca = "";
            this.nr_documento.NM_Param = "";
            this.nr_documento.QTD_Zero = 0;
            this.nr_documento.Size = new System.Drawing.Size(100, 20);
            this.nr_documento.ST_AutoInc = false;
            this.nr_documento.ST_DisableAuto = false;
            this.nr_documento.ST_Float = false;
            this.nr_documento.ST_Gravar = false;
            this.nr_documento.ST_Int = false;
            this.nr_documento.ST_LimpaCampo = true;
            this.nr_documento.ST_NotNull = false;
            this.nr_documento.ST_PrimaryKey = false;
            this.nr_documento.TabIndex = 8;
            this.nr_documento.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(358, 29);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(30, 20);
            this.bb_produto.TabIndex = 7;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_duplicata.Location = new System.Drawing.Point(284, 29);
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "a";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CD_MOVIMENTACAO";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(73, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = true;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = false;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 6;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(284, 3);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "a";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(73, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = false;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 4;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // bb_clifor
            // 
            this.bb_clifor.BackColor = System.Drawing.SystemColors.Control;
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(358, 3);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(30, 20);
            this.bb_clifor.TabIndex = 5;
            this.bb_clifor.UseVisualStyleBackColor = false;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // bb_movimentacao
            // 
            this.bb_movimentacao.BackColor = System.Drawing.SystemColors.Control;
            this.bb_movimentacao.Image = ((System.Drawing.Image)(resources.GetObject("bb_movimentacao.Image")));
            this.bb_movimentacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_movimentacao.Location = new System.Drawing.Point(167, 29);
            this.bb_movimentacao.Name = "bb_movimentacao";
            this.bb_movimentacao.Size = new System.Drawing.Size(30, 20);
            this.bb_movimentacao.TabIndex = 3;
            this.bb_movimentacao.UseVisualStyleBackColor = false;
            this.bb_movimentacao.Click += new System.EventHandler(this.bb_movimentacao_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_historico.Location = new System.Drawing.Point(93, 29);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "a";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(73, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = true;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = false;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 2;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(93, 3);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "a";
            this.cd_empresa.NM_Campo = "Cd_Empresa";
            this.cd_empresa.NM_CampoBusca = "Cd_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(73, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = false;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(167, 3);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(30, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.cbMarcaFin);
            this.panelDados1.Controls.Add(this.gFinanceiro);
            this.panelDados1.Controls.Add(this.bnImpostos);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 62);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(975, 333);
            this.panelDados1.TabIndex = 4;
            // 
            // cbMarcaFin
            // 
            this.cbMarcaFin.AutoSize = true;
            this.cbMarcaFin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbMarcaFin.Location = new System.Drawing.Point(7, 11);
            this.cbMarcaFin.Name = "cbMarcaFin";
            this.cbMarcaFin.NM_Alias = "";
            this.cbMarcaFin.NM_Campo = "";
            this.cbMarcaFin.NM_Param = "";
            this.cbMarcaFin.Size = new System.Drawing.Size(15, 14);
            this.cbMarcaFin.ST_Gravar = false;
            this.cbMarcaFin.ST_LimparCampo = true;
            this.cbMarcaFin.ST_NotNull = false;
            this.cbMarcaFin.TabIndex = 214;
            this.cbMarcaFin.UseVisualStyleBackColor = true;
            this.cbMarcaFin.Vl_False = "";
            this.cbMarcaFin.Vl_True = "";
            this.cbMarcaFin.Click += new System.EventHandler(this.cbMarcaFin_Click);
            // 
            // gFinanceiro
            // 
            this.gFinanceiro.AllowUserToAddRows = false;
            this.gFinanceiro.AllowUserToDeleteRows = false;
            this.gFinanceiro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gFinanceiro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gFinanceiro.AutoGenerateColumns = false;
            this.gFinanceiro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gFinanceiro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gFinanceiro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gFinanceiro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gFinanceiro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gFinanceiro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.nrDocumentoDataGridViewTextBoxColumn,
            this.dTLanctoDataGridViewTextBoxColumn,
            this.vLLanctoDataGridViewTextBoxColumn,
            this.tPMovimentoDataGridViewTextBoxColumn,
            this.nMCliforDataGridViewTextBoxColumn,
            this.dstpduplicataDataGridViewTextBoxColumn,
            this.dSHistoricoDataGridViewTextBoxColumn,
            this.cDContaDebDataGridViewTextBoxColumn,
            this.cDContaCreDataGridViewTextBoxColumn,
            this.cContaDebitada,
            this.cContaCreditada,
            this.cDLoteCTBDataGridViewTextBoxColumn,
            this.Ds_observacao});
            this.gFinanceiro.ContextMenuStrip = this.cmsFin;
            this.gFinanceiro.DataSource = this.bsFinanceiro;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gFinanceiro.DefaultCellStyle = dataGridViewCellStyle5;
            this.gFinanceiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gFinanceiro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gFinanceiro.Location = new System.Drawing.Point(0, 0);
            this.gFinanceiro.Name = "gFinanceiro";
            this.gFinanceiro.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gFinanceiro.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gFinanceiro.RowHeadersWidth = 23;
            this.gFinanceiro.Size = new System.Drawing.Size(975, 308);
            this.gFinanceiro.TabIndex = 0;
            this.gFinanceiro.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gFinanceiro_ColumnHeaderMouseClick);
            this.gFinanceiro.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gFinanceiro_CellFormatting);
            this.gFinanceiro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gFinanceiro_CellClick);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Processar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 60;
            // 
            // nrDocumentoDataGridViewTextBoxColumn
            // 
            this.nrDocumentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrDocumentoDataGridViewTextBoxColumn.DataPropertyName = "Nr_Documento";
            this.nrDocumentoDataGridViewTextBoxColumn.HeaderText = "Nº Documento";
            this.nrDocumentoDataGridViewTextBoxColumn.Name = "nrDocumentoDataGridViewTextBoxColumn";
            this.nrDocumentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrDocumentoDataGridViewTextBoxColumn.Width = 94;
            // 
            // dTLanctoDataGridViewTextBoxColumn
            // 
            this.dTLanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dTLanctoDataGridViewTextBoxColumn.DataPropertyName = "DT_Lancto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dTLanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dTLanctoDataGridViewTextBoxColumn.HeaderText = "Dt. Documento";
            this.dTLanctoDataGridViewTextBoxColumn.Name = "dTLanctoDataGridViewTextBoxColumn";
            this.dTLanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dTLanctoDataGridViewTextBoxColumn.Width = 96;
            // 
            // vLLanctoDataGridViewTextBoxColumn
            // 
            this.vLLanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vLLanctoDataGridViewTextBoxColumn.DataPropertyName = "VL_Lancto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vLLanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vLLanctoDataGridViewTextBoxColumn.HeaderText = "Vl. Documento";
            this.vLLanctoDataGridViewTextBoxColumn.Name = "vLLanctoDataGridViewTextBoxColumn";
            this.vLLanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vLLanctoDataGridViewTextBoxColumn.Width = 94;
            // 
            // tPMovimentoDataGridViewTextBoxColumn
            // 
            this.tPMovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tPMovimentoDataGridViewTextBoxColumn.DataPropertyName = "TP_Movimento";
            this.tPMovimentoDataGridViewTextBoxColumn.HeaderText = "Movimento";
            this.tPMovimentoDataGridViewTextBoxColumn.Name = "tPMovimentoDataGridViewTextBoxColumn";
            this.tPMovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tPMovimentoDataGridViewTextBoxColumn.Width = 84;
            // 
            // nMCliforDataGridViewTextBoxColumn
            // 
            this.nMCliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nMCliforDataGridViewTextBoxColumn.DataPropertyName = "NM_Clifor";
            this.nMCliforDataGridViewTextBoxColumn.HeaderText = "Cliente/Fornecedor";
            this.nMCliforDataGridViewTextBoxColumn.Name = "nMCliforDataGridViewTextBoxColumn";
            this.nMCliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nMCliforDataGridViewTextBoxColumn.Width = 123;
            // 
            // dstpduplicataDataGridViewTextBoxColumn
            // 
            this.dstpduplicataDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpduplicataDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpduplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.HeaderText = "Tipo Duplicata";
            this.dstpduplicataDataGridViewTextBoxColumn.Name = "dstpduplicataDataGridViewTextBoxColumn";
            this.dstpduplicataDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpduplicataDataGridViewTextBoxColumn.Width = 93;
            // 
            // dSHistoricoDataGridViewTextBoxColumn
            // 
            this.dSHistoricoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSHistoricoDataGridViewTextBoxColumn.DataPropertyName = "DS_Historico";
            this.dSHistoricoDataGridViewTextBoxColumn.HeaderText = "Historico";
            this.dSHistoricoDataGridViewTextBoxColumn.Name = "dSHistoricoDataGridViewTextBoxColumn";
            this.dSHistoricoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSHistoricoDataGridViewTextBoxColumn.Width = 73;
            // 
            // cDContaDebDataGridViewTextBoxColumn
            // 
            this.cDContaDebDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDContaDebDataGridViewTextBoxColumn.DataPropertyName = "CD_ContaDeb";
            this.cDContaDebDataGridViewTextBoxColumn.HeaderText = "Cd. Conta Deb.";
            this.cDContaDebDataGridViewTextBoxColumn.Name = "cDContaDebDataGridViewTextBoxColumn";
            this.cDContaDebDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDContaDebDataGridViewTextBoxColumn.Width = 97;
            // 
            // cDContaCreDataGridViewTextBoxColumn
            // 
            this.cDContaCreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDContaCreDataGridViewTextBoxColumn.DataPropertyName = "CD_ContaCre";
            this.cDContaCreDataGridViewTextBoxColumn.HeaderText = "Cd. Conta Cred.";
            this.cDContaCreDataGridViewTextBoxColumn.Name = "cDContaCreDataGridViewTextBoxColumn";
            this.cDContaCreDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDContaCreDataGridViewTextBoxColumn.Width = 98;
            // 
            // cContaDebitada
            // 
            this.cContaDebitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cContaDebitada.DataPropertyName = "Cd_contactb_Dstr";
            this.cContaDebitada.HeaderText = "Conta Debitada";
            this.cContaDebitada.Name = "cContaDebitada";
            this.cContaDebitada.ReadOnly = true;
            this.cContaDebitada.Visible = false;
            this.cContaDebitada.Width = 97;
            // 
            // cContaCreditada
            // 
            this.cContaCreditada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cContaCreditada.DataPropertyName = "Cd_contactb_Cstr";
            this.cContaCreditada.HeaderText = "Conta Creditada";
            this.cContaCreditada.Name = "cContaCreditada";
            this.cContaCreditada.ReadOnly = true;
            this.cContaCreditada.Visible = false;
            this.cContaCreditada.Width = 99;
            // 
            // cDLoteCTBDataGridViewTextBoxColumn
            // 
            this.cDLoteCTBDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDLoteCTBDataGridViewTextBoxColumn.DataPropertyName = "CD_LoteCTB";
            this.cDLoteCTBDataGridViewTextBoxColumn.HeaderText = "Nº Lote CTB";
            this.cDLoteCTBDataGridViewTextBoxColumn.Name = "cDLoteCTBDataGridViewTextBoxColumn";
            this.cDLoteCTBDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDLoteCTBDataGridViewTextBoxColumn.Width = 85;
            // 
            // Ds_observacao
            // 
            this.Ds_observacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_observacao.DataPropertyName = "Ds_observacao";
            this.Ds_observacao.HeaderText = "Observação";
            this.Ds_observacao.Name = "Ds_observacao";
            this.Ds_observacao.ReadOnly = true;
            this.Ds_observacao.Width = 90;
            // 
            // cmsFin
            // 
            this.cmsFin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alterarHistoricoToolStripMenuItem});
            this.cmsFin.Name = "cmsFin";
            this.cmsFin.Size = new System.Drawing.Size(161, 26);
            // 
            // alterarHistoricoToolStripMenuItem
            // 
            this.alterarHistoricoToolStripMenuItem.Name = "alterarHistoricoToolStripMenuItem";
            this.alterarHistoricoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.alterarHistoricoToolStripMenuItem.Text = "Alterar Historico";
            this.alterarHistoricoToolStripMenuItem.Click += new System.EventHandler(this.alterarHistoricoToolStripMenuItem_Click);
            // 
            // bnImpostos
            // 
            this.bnImpostos.AddNewItem = null;
            this.bnImpostos.BindingSource = this.bsFinanceiro;
            this.bnImpostos.CountItem = this.bindingNavigatorCountItem;
            this.bnImpostos.CountItemFormat = "de {0}";
            this.bnImpostos.DeleteItem = null;
            this.bnImpostos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnImpostos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator2,
            this.lblSelecionados,
            this.lblInconsistente,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tot_receber,
            this.toolStripLabel2,
            this.tot_pagar});
            this.bnImpostos.Location = new System.Drawing.Point(0, 308);
            this.bnImpostos.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnImpostos.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnImpostos.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnImpostos.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnImpostos.Name = "bnImpostos";
            this.bnImpostos.PositionItem = this.bindingNavigatorPositionItem;
            this.bnImpostos.Size = new System.Drawing.Size(975, 25);
            this.bnImpostos.TabIndex = 1;
            this.bnImpostos.Text = "bindingNavigator1";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lblSelecionados
            // 
            this.lblSelecionados.Name = "lblSelecionados";
            this.lblSelecionados.Size = new System.Drawing.Size(144, 22);
            this.lblSelecionados.Text = "{0} Registros Selecionados";
            // 
            // lblInconsistente
            // 
            this.lblInconsistente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInconsistente.ForeColor = System.Drawing.Color.Red;
            this.lblInconsistente.IsLink = true;
            this.lblInconsistente.LinkColor = System.Drawing.Color.Red;
            this.lblInconsistente.Name = "lblInconsistente";
            this.lblInconsistente.Size = new System.Drawing.Size(160, 22);
            this.lblInconsistente.Text = "{0} Registros Inconsistentes";
            this.lblInconsistente.Click += new System.EventHandler(this.lblInconsistente_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel1.Text = "Total Receber:";
            // 
            // tot_receber
            // 
            this.tot_receber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tot_receber.Name = "tot_receber";
            this.tot_receber.ReadOnly = true;
            this.tot_receber.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(71, 22);
            this.toolStripLabel2.Text = "Total Pagar:";
            // 
            // tot_pagar
            // 
            this.tot_pagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tot_pagar.Name = "tot_pagar";
            this.tot_pagar.ReadOnly = true;
            this.tot_pagar.Size = new System.Drawing.Size(100, 25);
            // 
            // TFProcessaFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 499);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "TFProcessaFinanceiro";
            this.ShowInTaskbar = false;
            this.Text = "Processar Financeiro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFProcessaFinanceiro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProcessaFinanceiro_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinanceiro)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ini)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFinanceiro)).EndInit();
            this.cmsFin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bnImpostos)).EndInit();
            this.bnImpostos.ResumeLayout(false);
            this.bnImpostos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bb_config;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault classificacaodeb;
        private Componentes.EditDefault ds_contacred;
        private Componentes.EditDefault cd_contadeb;
        private Componentes.EditDefault ds_contadeb;
        private Componentes.EditDefault cd_contacred;
        private Componentes.EditDefault classificacaocred;
        private Componentes.PanelDados pFiltro;
        private Componentes.CheckBoxDefault st_reprocessar;
        private Componentes.EditData dt_fin;
        private Componentes.EditData dt_ini;
        private Componentes.EditDefault nr_documento;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault tp_duplicata;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Button bb_clifor;
        private System.Windows.Forms.Button bb_movimentacao;
        private Componentes.EditDefault cd_historico;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault cbMarcaFin;
        private Componentes.DataGridDefault gFinanceiro;
        private System.Windows.Forms.BindingNavigator bnImpostos;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bsFinanceiro;
        private System.Windows.Forms.Button bb_contacred;
        private Componentes.EditDefault contacred;
        private Componentes.EditDefault contadeb;
        private System.Windows.Forms.Button bb_contadeb;
        private Componentes.EditFloat vl_fin;
        private Componentes.EditFloat vl_ini;
        private System.Windows.Forms.ContextMenuStrip cmsFin;
        private System.Windows.Forms.ToolStripMenuItem alterarHistoricoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblSelecionados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tot_receber;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tot_pagar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dTLanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vLLanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tPMovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nMCliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpduplicataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSHistoricoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDContaDebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDContaCreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContaDebitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContaCreditada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLoteCTBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_observacao;
        private System.Windows.Forms.ToolStripLabel lblInconsistente;
    }
}