namespace Contabil
{
    partial class TFProcessaCompFixar
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label30;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFProcessaCompFixar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.bsComp = new System.Windows.Forms.BindingSource(this.components);
            this.ds_contacred = new Componentes.EditDefault(this.components);
            this.cd_contadeb = new Componentes.EditDefault(this.components);
            this.ds_contadeb = new Componentes.EditDefault(this.components);
            this.cd_contacred = new Componentes.EditDefault(this.components);
            this.classificacaocred = new Componentes.EditDefault(this.components);
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.tp_movimento = new Componentes.ComboBoxDefault(this.components);
            this.tp_registro = new Componentes.ComboBoxDefault(this.components);
            this.vl_fin = new Componentes.EditFloat(this.components);
            this.vl_ini = new Componentes.EditFloat(this.components);
            this.bb_contacred = new System.Windows.Forms.Button();
            this.contacred = new Componentes.EditDefault(this.components);
            this.contadeb = new Componentes.EditDefault(this.components);
            this.bb_contadeb = new System.Windows.Forms.Button();
            this.st_reprocessar = new Componentes.CheckBoxDefault(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.cbMarcaFaturamento = new Componentes.CheckBoxDefault(this.components);
            this.gComp = new Componentes.DataGridDefault(this.components);
            this.bnComp = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDContaDebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDContaCreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContaDebitada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cContaCreditada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_movimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontadebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdclassificacaodebDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscontacredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdclassificacaocredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDLoteCTBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsComp)).BeginInit();
            this.pFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ini)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gComp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnComp)).BeginInit();
            this.bnComp.SuspendLayout();
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
            label5.Location = new System.Drawing.Point(552, 32);
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
            label4.Location = new System.Drawing.Point(547, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 13);
            label4.TabIndex = 124;
            label4.Text = "Dt. Inicial:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(40, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 120;
            label1.Text = "Produto:";
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
            label8.Location = new System.Drawing.Point(379, 31);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(66, 13);
            label8.TabIndex = 150;
            label8.Text = "Conta Cred.:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(382, 6);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(64, 13);
            label9.TabIndex = 149;
            label9.Text = "Conta Deb.:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(684, 33);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(42, 13);
            label6.TabIndex = 154;
            label6.Text = "Vl. Fin.:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(684, 7);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(39, 13);
            label7.TabIndex = 152;
            label7.Text = "Vl. Ini.:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(203, 6);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(49, 13);
            label10.TabIndex = 155;
            label10.Text = "Registro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(203, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 13);
            label2.TabIndex = 157;
            label2.Text = "Movimento:";
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
            this.barraMenu.Size = new System.Drawing.Size(1107, 43);
            this.barraMenu.TabIndex = 12;
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
            this.tlpCentral.Size = new System.Drawing.Size(1107, 518);
            this.tlpCentral.TabIndex = 13;
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
            this.panelDados2.Location = new System.Drawing.Point(3, 463);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1101, 52);
            this.panelDados2.TabIndex = 3;
            // 
            // classificacaodeb
            // 
            this.classificacaodeb.BackColor = System.Drawing.SystemColors.Window;
            this.classificacaodeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classificacaodeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.classificacaodeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Cd_classificacaodeb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            // bsComp
            // 
            this.bsComp.DataSource = typeof(CamadaDados.Contabil.TRegistro_ProcCompFixar);
            // 
            // ds_contacred
            // 
            this.ds_contacred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Ds_contacred", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.cd_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Cd_contadebstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.ds_contadeb.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Ds_contadeb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.cd_contacred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Cd_contacrestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.classificacaocred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsComp, "Cd_classificacaocred", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.pFiltro.Controls.Add(this.tp_movimento);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.tp_registro);
            this.pFiltro.Controls.Add(label10);
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
            this.pFiltro.Controls.Add(this.bb_produto);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(label30);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1101, 53);
            this.pFiltro.TabIndex = 0;
            // 
            // tp_movimento
            // 
            this.tp_movimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_movimento.FormattingEnabled = true;
            this.tp_movimento.Items.AddRange(new object[] {
            "COMPRA",
            "VENDA"});
            this.tp_movimento.Location = new System.Drawing.Point(271, 29);
            this.tp_movimento.Name = "tp_movimento";
            this.tp_movimento.NM_Alias = "";
            this.tp_movimento.NM_Campo = "";
            this.tp_movimento.NM_Param = "";
            this.tp_movimento.Size = new System.Drawing.Size(105, 21);
            this.tp_movimento.ST_Gravar = false;
            this.tp_movimento.ST_LimparCampo = true;
            this.tp_movimento.ST_NotNull = false;
            this.tp_movimento.TabIndex = 158;
            // 
            // tp_registro
            // 
            this.tp_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_registro.FormattingEnabled = true;
            this.tp_registro.Location = new System.Drawing.Point(258, 3);
            this.tp_registro.Name = "tp_registro";
            this.tp_registro.NM_Alias = "";
            this.tp_registro.NM_Campo = "";
            this.tp_registro.NM_Param = "";
            this.tp_registro.Size = new System.Drawing.Size(118, 21);
            this.tp_registro.ST_Gravar = false;
            this.tp_registro.ST_LimparCampo = true;
            this.tp_registro.ST_NotNull = false;
            this.tp_registro.TabIndex = 156;
            // 
            // vl_fin
            // 
            this.vl_fin.DecimalPlaces = 2;
            this.vl_fin.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_fin.Location = new System.Drawing.Point(729, 29);
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
            this.vl_fin.TabIndex = 153;
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
            this.vl_ini.Location = new System.Drawing.Point(729, 3);
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
            this.vl_ini.TabIndex = 151;
            this.vl_ini.ThousandsSeparator = true;
            // 
            // bb_contacred
            // 
            this.bb_contacred.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contacred.Image = ((System.Drawing.Image)(resources.GetObject("bb_contacred.Image")));
            this.bb_contacred.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contacred.Location = new System.Drawing.Point(511, 29);
            this.bb_contacred.Name = "bb_contacred";
            this.bb_contacred.Size = new System.Drawing.Size(30, 20);
            this.bb_contacred.TabIndex = 148;
            this.bb_contacred.UseVisualStyleBackColor = false;
            this.bb_contacred.Click += new System.EventHandler(this.bb_contacred_Click);
            // 
            // contacred
            // 
            this.contacred.BackColor = System.Drawing.SystemColors.Window;
            this.contacred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contacred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contacred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.contacred.Location = new System.Drawing.Point(452, 29);
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
            this.contacred.TabIndex = 147;
            this.contacred.TextOld = null;
            this.contacred.Leave += new System.EventHandler(this.contacred_Leave);
            // 
            // contadeb
            // 
            this.contadeb.BackColor = System.Drawing.SystemColors.Window;
            this.contadeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contadeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.contadeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.contadeb.Location = new System.Drawing.Point(452, 3);
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
            this.contadeb.TabIndex = 145;
            this.contadeb.TextOld = null;
            this.contadeb.Leave += new System.EventHandler(this.contadeb_Leave);
            // 
            // bb_contadeb
            // 
            this.bb_contadeb.BackColor = System.Drawing.SystemColors.Control;
            this.bb_contadeb.Image = ((System.Drawing.Image)(resources.GetObject("bb_contadeb.Image")));
            this.bb_contadeb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_contadeb.Location = new System.Drawing.Point(511, 3);
            this.bb_contadeb.Name = "bb_contadeb";
            this.bb_contadeb.Size = new System.Drawing.Size(30, 20);
            this.bb_contadeb.TabIndex = 146;
            this.bb_contadeb.UseVisualStyleBackColor = false;
            this.bb_contadeb.Click += new System.EventHandler(this.bb_contadeb_Click);
            // 
            // st_reprocessar
            // 
            this.st_reprocessar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.st_reprocessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_reprocessar.Location = new System.Drawing.Point(823, 5);
            this.st_reprocessar.Name = "st_reprocessar";
            this.st_reprocessar.NM_Alias = "";
            this.st_reprocessar.NM_Campo = "";
            this.st_reprocessar.NM_Param = "";
            this.st_reprocessar.Size = new System.Drawing.Size(101, 44);
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
            this.dt_fin.Location = new System.Drawing.Point(607, 29);
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
            this.dt_ini.Location = new System.Drawing.Point(607, 3);
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
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(167, 29);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(30, 20);
            this.bb_produto.TabIndex = 7;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(93, 29);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "a";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_MOVIMENTACAO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(73, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 6;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
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
            this.panelDados1.Controls.Add(this.cbMarcaFaturamento);
            this.panelDados1.Controls.Add(this.gComp);
            this.panelDados1.Controls.Add(this.bnComp);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 62);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1101, 395);
            this.panelDados1.TabIndex = 4;
            // 
            // cbMarcaFaturamento
            // 
            this.cbMarcaFaturamento.AutoSize = true;
            this.cbMarcaFaturamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbMarcaFaturamento.Location = new System.Drawing.Point(7, 11);
            this.cbMarcaFaturamento.Name = "cbMarcaFaturamento";
            this.cbMarcaFaturamento.NM_Alias = "";
            this.cbMarcaFaturamento.NM_Campo = "";
            this.cbMarcaFaturamento.NM_Param = "";
            this.cbMarcaFaturamento.Size = new System.Drawing.Size(15, 14);
            this.cbMarcaFaturamento.ST_Gravar = false;
            this.cbMarcaFaturamento.ST_LimparCampo = true;
            this.cbMarcaFaturamento.ST_NotNull = false;
            this.cbMarcaFaturamento.TabIndex = 214;
            this.cbMarcaFaturamento.UseVisualStyleBackColor = true;
            this.cbMarcaFaturamento.Vl_False = "";
            this.cbMarcaFaturamento.Vl_True = "";
            this.cbMarcaFaturamento.Click += new System.EventHandler(this.cbMarcaFaturamento_Click);
            // 
            // gComp
            // 
            this.gComp.AllowUserToAddRows = false;
            this.gComp.AllowUserToDeleteRows = false;
            this.gComp.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gComp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gComp.AutoGenerateColumns = false;
            this.gComp.BackgroundColor = System.Drawing.Color.LightGray;
            this.gComp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gComp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gComp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gComp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.dtlanctoDataGridViewTextBoxColumn,
            this.vllanctoDataGridViewTextBoxColumn,
            this.cDContaDebDataGridViewTextBoxColumn,
            this.cDContaCreDataGridViewTextBoxColumn,
            this.cContaDebitada,
            this.cContaCreditada,
            this.Tipo_registro,
            this.Tipo_movimento,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.dscontadebDataGridViewTextBoxColumn,
            this.cdclassificacaodebDataGridViewTextBoxColumn,
            this.dscontacredDataGridViewTextBoxColumn,
            this.cdclassificacaocredDataGridViewTextBoxColumn,
            this.cDLoteCTBDataGridViewTextBoxColumn});
            this.gComp.DataSource = this.bsComp;
            this.gComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gComp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gComp.Location = new System.Drawing.Point(0, 0);
            this.gComp.Name = "gComp";
            this.gComp.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gComp.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gComp.RowHeadersWidth = 23;
            this.gComp.Size = new System.Drawing.Size(1101, 370);
            this.gComp.TabIndex = 0;
            this.gComp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gComp_CellClick);
            this.gComp.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gComp_CellFormatting);
            this.gComp.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gComp_ColumnHeaderMouseClick);
            // 
            // bnComp
            // 
            this.bnComp.AddNewItem = null;
            this.bnComp.BindingSource = this.bsComp;
            this.bnComp.CountItem = this.bindingNavigatorCountItem;
            this.bnComp.CountItemFormat = "de {0}";
            this.bnComp.DeleteItem = null;
            this.bnComp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnComp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.lblInconsistente});
            this.bnComp.Location = new System.Drawing.Point(0, 370);
            this.bnComp.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnComp.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnComp.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnComp.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnComp.Name = "bnComp";
            this.bnComp.PositionItem = this.bindingNavigatorPositionItem;
            this.bnComp.Size = new System.Drawing.Size(1101, 25);
            this.bnComp.TabIndex = 1;
            this.bnComp.Text = "bindingNavigator1";
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
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Processar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 60;
            // 
            // dtlanctoDataGridViewTextBoxColumn
            // 
            this.dtlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_lancto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtlanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtlanctoDataGridViewTextBoxColumn.HeaderText = "Dt. Lançamento";
            this.dtlanctoDataGridViewTextBoxColumn.Name = "dtlanctoDataGridViewTextBoxColumn";
            this.dtlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctoDataGridViewTextBoxColumn.Width = 99;
            // 
            // vllanctoDataGridViewTextBoxColumn
            // 
            this.vllanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllanctoDataGridViewTextBoxColumn.DataPropertyName = "Vl_lancto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vllanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vllanctoDataGridViewTextBoxColumn.HeaderText = "Vl. Lançamento";
            this.vllanctoDataGridViewTextBoxColumn.Name = "vllanctoDataGridViewTextBoxColumn";
            this.vllanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllanctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // cDContaDebDataGridViewTextBoxColumn
            // 
            this.cDContaDebDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDContaDebDataGridViewTextBoxColumn.DataPropertyName = "CD_ContaDeb";
            this.cDContaDebDataGridViewTextBoxColumn.HeaderText = "Cd. Conta Deb.";
            this.cDContaDebDataGridViewTextBoxColumn.Name = "cDContaDebDataGridViewTextBoxColumn";
            this.cDContaDebDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDContaDebDataGridViewTextBoxColumn.Width = 96;
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
            // Tipo_registro
            // 
            this.Tipo_registro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_registro.DataPropertyName = "Tipo_registro";
            this.Tipo_registro.HeaderText = "TP. Registro";
            this.Tipo_registro.Name = "Tipo_registro";
            this.Tipo_registro.ReadOnly = true;
            this.Tipo_registro.Width = 84;
            // 
            // Tipo_movimento
            // 
            this.Tipo_movimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_movimento.DataPropertyName = "Tipo_movimento";
            this.Tipo_movimento.HeaderText = "Movimento";
            this.Tipo_movimento.Name = "Tipo_movimento";
            this.Tipo_movimento.ReadOnly = true;
            this.Tipo_movimento.Width = 84;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // dscontadebDataGridViewTextBoxColumn
            // 
            this.dscontadebDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontadebDataGridViewTextBoxColumn.DataPropertyName = "Ds_contadeb";
            this.dscontadebDataGridViewTextBoxColumn.HeaderText = "Conta Debito";
            this.dscontadebDataGridViewTextBoxColumn.Name = "dscontadebDataGridViewTextBoxColumn";
            this.dscontadebDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontadebDataGridViewTextBoxColumn.Width = 87;
            // 
            // cdclassificacaodebDataGridViewTextBoxColumn
            // 
            this.cdclassificacaodebDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdclassificacaodebDataGridViewTextBoxColumn.DataPropertyName = "Cd_classificacaodeb";
            this.cdclassificacaodebDataGridViewTextBoxColumn.HeaderText = "Classificação Deb.";
            this.cdclassificacaodebDataGridViewTextBoxColumn.Name = "cdclassificacaodebDataGridViewTextBoxColumn";
            this.cdclassificacaodebDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdclassificacaodebDataGridViewTextBoxColumn.Width = 110;
            // 
            // dscontacredDataGridViewTextBoxColumn
            // 
            this.dscontacredDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscontacredDataGridViewTextBoxColumn.DataPropertyName = "Ds_contacred";
            this.dscontacredDataGridViewTextBoxColumn.HeaderText = "Conta Credito";
            this.dscontacredDataGridViewTextBoxColumn.Name = "dscontacredDataGridViewTextBoxColumn";
            this.dscontacredDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscontacredDataGridViewTextBoxColumn.Width = 88;
            // 
            // cdclassificacaocredDataGridViewTextBoxColumn
            // 
            this.cdclassificacaocredDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdclassificacaocredDataGridViewTextBoxColumn.DataPropertyName = "Cd_classificacaocred";
            this.cdclassificacaocredDataGridViewTextBoxColumn.HeaderText = "Classificação Cred.";
            this.cdclassificacaocredDataGridViewTextBoxColumn.Name = "cdclassificacaocredDataGridViewTextBoxColumn";
            this.cdclassificacaocredDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdclassificacaocredDataGridViewTextBoxColumn.Width = 112;
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
            // TFProcessaCompFixar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 561);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "TFProcessaCompFixar";
            this.ShowInTaskbar = false;
            this.Text = "Processar Complemento Notas Fixar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFProcessaCompFixar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFProcessaCompFixar_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsComp)).EndInit();
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_fin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_ini)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gComp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnComp)).EndInit();
            this.bnComp.ResumeLayout(false);
            this.bnComp.PerformLayout();
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
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault cbMarcaFaturamento;
        private Componentes.DataGridDefault gComp;
        private System.Windows.Forms.BindingNavigator bnComp;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bsComp;
        private System.Windows.Forms.Button bb_contacred;
        private Componentes.EditDefault contacred;
        private Componentes.EditDefault contadeb;
        private System.Windows.Forms.Button bb_contadeb;
        private Componentes.EditFloat vl_fin;
        private Componentes.EditFloat vl_ini;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblSelecionados;
        private Componentes.ComboBoxDefault tp_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripLabel lblInconsistente;
        private System.Windows.Forms.Timer timer1;
        private Componentes.ComboBoxDefault tp_movimento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDContaDebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDContaCreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContaDebitada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cContaCreditada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_movimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontadebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdclassificacaodebDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscontacredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdclassificacaocredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLoteCTBDataGridViewTextBoxColumn;
    }
}