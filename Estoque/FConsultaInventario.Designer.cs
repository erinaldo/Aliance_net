namespace Estoque
{
    partial class TFConsultaInventario
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label qtd_saldoLabel;
            System.Windows.Forms.Label ds_produtoLabel;
            System.Windows.Forms.Label cd_localLabel;
            System.Windows.Forms.Label qtd_contadaLabel;
            System.Windows.Forms.Label vl_unitarioLabel;
            System.Windows.Forms.Label vl_subtotalLabel;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConsultaInventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.bb_alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.bb_processa = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.itensInventariarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldoItensInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.pStatus = new Componentes.PanelDados(this.components);
            this.st_processado = new Componentes.CheckBoxDefault(this.components);
            this.st_aberto = new Componentes.CheckBoxDefault(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.id_inventario = new Componentes.EditDefault(this.components);
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpInventario = new System.Windows.Forms.TabPage();
            this.gInventario = new Componentes.DataGridDefault(this.components);
            this.statusinventarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idinventarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtinventariostringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsInventario = new System.Windows.Forms.BindingSource(this.components);
            this.bnInventario = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tpItens = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gItensInventario = new Componentes.DataGridDefault(this.components);
            this.idinventarioDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdreferenciaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdmarcaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmarcaDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stconsumointernoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItensInventario = new System.Windows.Forms.BindingSource(this.components);
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.tcSaldo = new System.Windows.Forms.TabControl();
            this.tpSaldo = new System.Windows.Forms.TabPage();
            this.tlpSaldo = new System.Windows.Forms.TableLayoutPanel();
            this.pSaldo = new Componentes.PanelDados(this.components);
            this.gSaldoItem = new Componentes.DataGridDefault(this.components);
            this.idinventarioDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_contada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_saldoatual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qtd_saldoAmx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vl_medio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsSaldoItem = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem2 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem2 = new System.Windows.Forms.ToolStripButton();
            this.pDadosSaldo = new Componentes.PanelDados(this.components);
            this.bb_almox = new System.Windows.Forms.Button();
            this.id_almox = new Componentes.EditDefault(this.components);
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.editDefault4 = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.id_inventariosaldo = new Componentes.EditDefault(this.components);
            this.TS_Endereco = new System.Windows.Forms.ToolStrip();
            this.ts_btn_Inserir_Endereco = new System.Windows.Forms.ToolStripButton();
            this.ts_btn_Alterar_Endereco = new System.Windows.Forms.ToolStripButton();
            this.ts_btn_Deletar_Endereco = new System.Windows.Forms.ToolStripButton();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.sigla_unidadeEditDefault = new Componentes.EditDefault(this.components);
            this.vl_subtotalEditFloat = new Componentes.EditFloat(this.components);
            this.vl_unitarioEditFloat = new Componentes.EditFloat(this.components);
            this.qtd_contadaEditFloat = new Componentes.EditFloat(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.ds_local = new Componentes.EditDefault(this.components);
            this.cd_local = new Componentes.EditDefault(this.components);
            this.ds_produtoEditDefault = new Componentes.EditDefault(this.components);
            this.qtd_saldoEditFloat = new Componentes.EditFloat(this.components);
            this.tpEstoque = new System.Windows.Forms.TabPage();
            this.gEstoque = new Componentes.DataGridDefault(this.components);
            this.bsEstoque = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator3 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem3 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem3 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem3 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem3 = new System.Windows.Forms.ToolStripButton();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            qtd_saldoLabel = new System.Windows.Forms.Label();
            ds_produtoLabel = new System.Windows.Forms.Label();
            cd_localLabel = new System.Windows.Forms.Label();
            qtd_contadaLabel = new System.Windows.Forms.Label();
            vl_unitarioLabel = new System.Windows.Forms.Label();
            vl_subtotalLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pStatus.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnInventario)).BeginInit();
            this.bnInventario.SuspendLayout();
            this.tpItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gItensInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tcSaldo.SuspendLayout();
            this.tpSaldo.SuspendLayout();
            this.tlpSaldo.SuspendLayout();
            this.pSaldo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.pDadosSaldo.SuspendLayout();
            this.TS_Endereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotalEditFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitarioEditFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_contadaEditFloat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_saldoEditFloat)).BeginInit();
            this.tpEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).BeginInit();
            this.bindingNavigator3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(190, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 13);
            label3.TabIndex = 145;
            label3.Text = "Dt. Fin.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(190, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 13);
            label2.TabIndex = 143;
            label2.Text = "Dt. Ini.:";
            // 
            // qtd_saldoLabel
            // 
            qtd_saldoLabel.AutoSize = true;
            qtd_saldoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtd_saldoLabel.Location = new System.Drawing.Point(16, 139);
            qtd_saldoLabel.Name = "qtd_saldoLabel";
            qtd_saldoLabel.Size = new System.Drawing.Size(76, 13);
            qtd_saldoLabel.TabIndex = 17;
            qtd_saldoLabel.Text = "Saldo Atual:";
            // 
            // ds_produtoLabel
            // 
            ds_produtoLabel.AutoSize = true;
            ds_produtoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ds_produtoLabel.Location = new System.Drawing.Point(37, 59);
            ds_produtoLabel.Name = "ds_produtoLabel";
            ds_produtoLabel.Size = new System.Drawing.Size(55, 13);
            ds_produtoLabel.TabIndex = 21;
            ds_produtoLabel.Text = "Produto:";
            // 
            // cd_localLabel
            // 
            cd_localLabel.AutoSize = true;
            cd_localLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_localLabel.Location = new System.Drawing.Point(50, 84);
            cd_localLabel.Name = "cd_localLabel";
            cd_localLabel.Size = new System.Drawing.Size(42, 13);
            cd_localLabel.TabIndex = 24;
            cd_localLabel.Text = "Local:";
            // 
            // qtd_contadaLabel
            // 
            qtd_contadaLabel.AutoSize = true;
            qtd_contadaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qtd_contadaLabel.Location = new System.Drawing.Point(6, 110);
            qtd_contadaLabel.Name = "qtd_contadaLabel";
            qtd_contadaLabel.Size = new System.Drawing.Size(86, 13);
            qtd_contadaLabel.TabIndex = 27;
            qtd_contadaLabel.Text = "Qtd. Contada:";
            // 
            // vl_unitarioLabel
            // 
            vl_unitarioLabel.AutoSize = true;
            vl_unitarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            vl_unitarioLabel.Location = new System.Drawing.Point(236, 111);
            vl_unitarioLabel.Name = "vl_unitarioLabel";
            vl_unitarioLabel.Size = new System.Drawing.Size(68, 13);
            vl_unitarioLabel.TabIndex = 28;
            vl_unitarioLabel.Text = "Vl unitario:";
            // 
            // vl_subtotalLabel
            // 
            vl_subtotalLabel.AutoSize = true;
            vl_subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            vl_subtotalLabel.Location = new System.Drawing.Point(417, 111);
            vl_subtotalLabel.Name = "vl_subtotalLabel";
            vl_subtotalLabel.Size = new System.Drawing.Size(71, 13);
            vl_subtotalLabel.TabIndex = 29;
            vl_subtotalLabel.Text = "Vl subtotal:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(405, 84);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 13);
            label4.TabIndex = 98;
            label4.Text = "Almoxarifado:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.bb_alterar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.bb_processa,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1027, 43);
            this.barraMenu.TabIndex = 3;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(85, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Nova Provisão";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // bb_alterar
            // 
            this.bb_alterar.AutoSize = false;
            this.bb_alterar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_alterar.ForeColor = System.Drawing.Color.Green;
            this.bb_alterar.Image = ((System.Drawing.Image)(resources.GetObject("bb_alterar.Image")));
            this.bb_alterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_alterar.Name = "bb_alterar";
            this.bb_alterar.Size = new System.Drawing.Size(85, 40);
            this.bb_alterar.Text = "(F3)\r\n Alterar";
            this.bb_alterar.ToolTipText = "Alterar Registro";
            this.bb_alterar.Click += new System.EventHandler(this.bb_alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(90, 40);
            this.BB_Excluir.Text = " (F5)\r\n Excluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
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
            // bb_processa
            // 
            this.bb_processa.AutoSize = false;
            this.bb_processa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_processa.ForeColor = System.Drawing.Color.Green;
            this.bb_processa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_processa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_processa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_processa.Name = "bb_processa";
            this.bb_processa.Size = new System.Drawing.Size(80, 40);
            this.bb_processa.Text = "(F9)\r\n Processar";
            this.bb_processa.ToolTipText = "Processar Inventario";
            this.bb_processa.Click += new System.EventHandler(this.bb_processa_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itensInventariarToolStripMenuItem,
            this.saldoItensInventarioToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Green;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(94, 40);
            this.toolStripDropDownButton1.Text = "Relatorios";
            // 
            // itensInventariarToolStripMenuItem
            // 
            this.itensInventariarToolStripMenuItem.Name = "itensInventariarToolStripMenuItem";
            this.itensInventariarToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.itensInventariarToolStripMenuItem.Text = "Lista Itens Inventariar";
            this.itensInventariarToolStripMenuItem.Click += new System.EventHandler(this.itensInventariarToolStripMenuItem_Click);
            // 
            // saldoItensInventarioToolStripMenuItem
            // 
            this.saldoItensInventarioToolStripMenuItem.Name = "saldoItensInventarioToolStripMenuItem";
            this.saldoItensInventarioToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.saldoItensInventarioToolStripMenuItem.Text = "Saldo Itens Inventario";
            this.saldoItensInventarioToolStripMenuItem.Click += new System.EventHandler(this.saldoItensInventarioToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.tcCentral, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1027, 567);
            this.tlpCentral.TabIndex = 4;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.pStatus);
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(this.label13);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.id_inventario);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1017, 55);
            this.pFiltro.TabIndex = 0;
            // 
            // pStatus
            // 
            this.pStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pStatus.Controls.Add(this.st_processado);
            this.pStatus.Controls.Add(this.st_aberto);
            this.pStatus.Location = new System.Drawing.Point(313, 3);
            this.pStatus.Name = "pStatus";
            this.pStatus.NM_ProcDeletar = "";
            this.pStatus.NM_ProcGravar = "";
            this.pStatus.Size = new System.Drawing.Size(118, 46);
            this.pStatus.TabIndex = 5;
            // 
            // st_processado
            // 
            this.st_processado.AutoSize = true;
            this.st_processado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_processado.ForeColor = System.Drawing.Color.Blue;
            this.st_processado.Location = new System.Drawing.Point(3, 24);
            this.st_processado.Name = "st_processado";
            this.st_processado.NM_Alias = "";
            this.st_processado.NM_Campo = "";
            this.st_processado.NM_Param = "";
            this.st_processado.Size = new System.Drawing.Size(110, 17);
            this.st_processado.ST_Gravar = false;
            this.st_processado.ST_LimparCampo = true;
            this.st_processado.ST_NotNull = false;
            this.st_processado.TabIndex = 1;
            this.st_processado.Text = "PROCESSADO";
            this.st_processado.UseVisualStyleBackColor = true;
            this.st_processado.Vl_False = "";
            this.st_processado.Vl_True = "";
            // 
            // st_aberto
            // 
            this.st_aberto.AutoSize = true;
            this.st_aberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_aberto.Location = new System.Drawing.Point(3, 3);
            this.st_aberto.Name = "st_aberto";
            this.st_aberto.NM_Alias = "";
            this.st_aberto.NM_Campo = "";
            this.st_aberto.NM_Param = "";
            this.st_aberto.Size = new System.Drawing.Size(76, 17);
            this.st_aberto.ST_Gravar = false;
            this.st_aberto.ST_LimparCampo = true;
            this.st_aberto.ST_NotNull = false;
            this.st_aberto.TabIndex = 0;
            this.st_aberto.Text = "ABERTO";
            this.st_aberto.UseVisualStyleBackColor = true;
            this.st_aberto.Vl_False = "";
            this.st_aberto.Vl_True = "";
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(237, 29);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(70, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 4;
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(237, 3);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(70, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 3;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(156, 29);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 2;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(26, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 93;
            this.label13.Text = "Empresa:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(84, 29);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(69, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = true;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 1;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Inventario:";
            // 
            // id_inventario
            // 
            this.id_inventario.BackColor = System.Drawing.SystemColors.Window;
            this.id_inventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_inventario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_inventario.Location = new System.Drawing.Point(84, 3);
            this.id_inventario.Name = "id_inventario";
            this.id_inventario.NM_Alias = "";
            this.id_inventario.NM_Campo = "";
            this.id_inventario.NM_CampoBusca = "";
            this.id_inventario.NM_Param = "";
            this.id_inventario.QTD_Zero = 0;
            this.id_inventario.Size = new System.Drawing.Size(100, 20);
            this.id_inventario.ST_AutoInc = false;
            this.id_inventario.ST_DisableAuto = false;
            this.id_inventario.ST_Float = false;
            this.id_inventario.ST_Gravar = false;
            this.id_inventario.ST_Int = false;
            this.id_inventario.ST_LimpaCampo = true;
            this.id_inventario.ST_NotNull = false;
            this.id_inventario.ST_PrimaryKey = false;
            this.id_inventario.TabIndex = 0;
            this.id_inventario.TextOld = null;
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpInventario);
            this.tcCentral.Controls.Add(this.tpItens);
            this.tcCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCentral.Location = new System.Drawing.Point(5, 68);
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.Size = new System.Drawing.Size(1017, 494);
            this.tcCentral.TabIndex = 1;
            this.tcCentral.SelectedIndexChanged += new System.EventHandler(this.tcCentral_SelectedIndexChanged);
            // 
            // tpInventario
            // 
            this.tpInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpInventario.Controls.Add(this.gInventario);
            this.tpInventario.Controls.Add(this.bnInventario);
            this.tpInventario.Location = new System.Drawing.Point(4, 22);
            this.tpInventario.Name = "tpInventario";
            this.tpInventario.Padding = new System.Windows.Forms.Padding(3);
            this.tpInventario.Size = new System.Drawing.Size(1009, 468);
            this.tpInventario.TabIndex = 0;
            this.tpInventario.Text = "INVENTARIO";
            this.tpInventario.UseVisualStyleBackColor = true;
            // 
            // gInventario
            // 
            this.gInventario.AllowUserToAddRows = false;
            this.gInventario.AllowUserToDeleteRows = false;
            this.gInventario.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gInventario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gInventario.AutoGenerateColumns = false;
            this.gInventario.BackgroundColor = System.Drawing.Color.LightGray;
            this.gInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gInventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusinventarioDataGridViewTextBoxColumn,
            this.idinventarioDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.dtinventariostringDataGridViewTextBoxColumn,
            this.Ds_observacao});
            this.gInventario.DataSource = this.bsInventario;
            this.gInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gInventario.Location = new System.Drawing.Point(3, 3);
            this.gInventario.Name = "gInventario";
            this.gInventario.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gInventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gInventario.RowHeadersWidth = 23;
            this.gInventario.Size = new System.Drawing.Size(1001, 435);
            this.gInventario.TabIndex = 0;
            this.gInventario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gInventario_CellFormatting);
            this.gInventario.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gInventario_ColumnHeaderMouseClick);
            // 
            // statusinventarioDataGridViewTextBoxColumn
            // 
            this.statusinventarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusinventarioDataGridViewTextBoxColumn.DataPropertyName = "Status_inventario";
            this.statusinventarioDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusinventarioDataGridViewTextBoxColumn.Name = "statusinventarioDataGridViewTextBoxColumn";
            this.statusinventarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusinventarioDataGridViewTextBoxColumn.Width = 62;
            // 
            // idinventarioDataGridViewTextBoxColumn
            // 
            this.idinventarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idinventarioDataGridViewTextBoxColumn.DataPropertyName = "Id_inventario";
            this.idinventarioDataGridViewTextBoxColumn.HeaderText = "Id. Inventario";
            this.idinventarioDataGridViewTextBoxColumn.Name = "idinventarioDataGridViewTextBoxColumn";
            this.idinventarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idinventarioDataGridViewTextBoxColumn.Width = 94;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
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
            // dtinventariostringDataGridViewTextBoxColumn
            // 
            this.dtinventariostringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtinventariostringDataGridViewTextBoxColumn.DataPropertyName = "Dt_inventariostring";
            this.dtinventariostringDataGridViewTextBoxColumn.HeaderText = "Dt. Inventario";
            this.dtinventariostringDataGridViewTextBoxColumn.Name = "dtinventariostringDataGridViewTextBoxColumn";
            this.dtinventariostringDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtinventariostringDataGridViewTextBoxColumn.Width = 96;
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
            // bsInventario
            // 
            this.bsInventario.DataSource = typeof(CamadaDados.Estoque.Tlist_Inventario);
            this.bsInventario.PositionChanged += new System.EventHandler(this.bsInventario_PositionChanged);
            // 
            // bnInventario
            // 
            this.bnInventario.AddNewItem = null;
            this.bnInventario.CountItem = this.bindingNavigatorCountItem;
            this.bnInventario.DeleteItem = null;
            this.bnInventario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnInventario.Location = new System.Drawing.Point(3, 438);
            this.bnInventario.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnInventario.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnInventario.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnInventario.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnInventario.Name = "bnInventario";
            this.bnInventario.PositionItem = this.bindingNavigatorPositionItem;
            this.bnInventario.Size = new System.Drawing.Size(1001, 25);
            this.bnInventario.TabIndex = 1;
            this.bnInventario.Text = "bindingNavigator1";
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
            // tpItens
            // 
            this.tpItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpItens.Controls.Add(this.splitContainer1);
            this.tpItens.Location = new System.Drawing.Point(4, 22);
            this.tpItens.Name = "tpItens";
            this.tpItens.Padding = new System.Windows.Forms.Padding(3);
            this.tpItens.Size = new System.Drawing.Size(1009, 468);
            this.tpItens.TabIndex = 1;
            this.tpItens.Text = "ITENS INVENTARIO";
            this.tpItens.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gItensInventario);
            this.splitContainer1.Panel1.Controls.Add(this.lblConciliacao);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcSaldo);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 460);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // gItensInventario
            // 
            this.gItensInventario.AllowUserToAddRows = false;
            this.gItensInventario.AllowUserToDeleteRows = false;
            this.gItensInventario.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gItensInventario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gItensInventario.AutoGenerateColumns = false;
            this.gItensInventario.BackgroundColor = System.Drawing.Color.LightGray;
            this.gItensInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gItensInventario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItensInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gItensInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gItensInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idinventarioDataGridViewTextBoxColumn3,
            this.cdprodutoDataGridViewTextBoxColumn2,
            this.dsprodutoDataGridViewTextBoxColumn2,
            this.cdreferenciaDataGridViewTextBoxColumn2,
            this.cdmarcaDataGridViewTextBoxColumn2,
            this.dsmarcaDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.stconsumointernoDataGridViewTextBoxColumn2});
            this.gItensInventario.DataSource = this.bsItensInventario;
            this.gItensInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gItensInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gItensInventario.Location = new System.Drawing.Point(0, 18);
            this.gItensInventario.Name = "gItensInventario";
            this.gItensInventario.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gItensInventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gItensInventario.RowHeadersWidth = 23;
            this.gItensInventario.Size = new System.Drawing.Size(298, 415);
            this.gItensInventario.TabIndex = 0;
            this.gItensInventario.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gItensInventario_ColumnHeaderMouseClick);
            // 
            // idinventarioDataGridViewTextBoxColumn3
            // 
            this.idinventarioDataGridViewTextBoxColumn3.DataPropertyName = "Id_inventario";
            this.idinventarioDataGridViewTextBoxColumn3.HeaderText = "Id_inventario";
            this.idinventarioDataGridViewTextBoxColumn3.Name = "idinventarioDataGridViewTextBoxColumn3";
            this.idinventarioDataGridViewTextBoxColumn3.ReadOnly = true;
            this.idinventarioDataGridViewTextBoxColumn3.Visible = false;
            // 
            // cdprodutoDataGridViewTextBoxColumn2
            // 
            this.cdprodutoDataGridViewTextBoxColumn2.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn2.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn2.Name = "cdprodutoDataGridViewTextBoxColumn2";
            this.cdprodutoDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn2
            // 
            this.dsprodutoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dsprodutoDataGridViewTextBoxColumn2.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn2.HeaderText = "Ds. Produto";
            this.dsprodutoDataGridViewTextBoxColumn2.Name = "dsprodutoDataGridViewTextBoxColumn2";
            this.dsprodutoDataGridViewTextBoxColumn2.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn2.Width = 88;
            // 
            // cdreferenciaDataGridViewTextBoxColumn2
            // 
            this.cdreferenciaDataGridViewTextBoxColumn2.DataPropertyName = "Cd_referencia";
            this.cdreferenciaDataGridViewTextBoxColumn2.HeaderText = "Cd_referencia";
            this.cdreferenciaDataGridViewTextBoxColumn2.Name = "cdreferenciaDataGridViewTextBoxColumn2";
            this.cdreferenciaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.cdreferenciaDataGridViewTextBoxColumn2.Visible = false;
            // 
            // cdmarcaDataGridViewTextBoxColumn2
            // 
            this.cdmarcaDataGridViewTextBoxColumn2.DataPropertyName = "Cd_marca";
            this.cdmarcaDataGridViewTextBoxColumn2.HeaderText = "Cd_marca";
            this.cdmarcaDataGridViewTextBoxColumn2.Name = "cdmarcaDataGridViewTextBoxColumn2";
            this.cdmarcaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.cdmarcaDataGridViewTextBoxColumn2.Visible = false;
            // 
            // dsmarcaDataGridViewTextBoxColumn2
            // 
            this.dsmarcaDataGridViewTextBoxColumn2.DataPropertyName = "Ds_marca";
            this.dsmarcaDataGridViewTextBoxColumn2.HeaderText = "Ds_marca";
            this.dsmarcaDataGridViewTextBoxColumn2.Name = "dsmarcaDataGridViewTextBoxColumn2";
            this.dsmarcaDataGridViewTextBoxColumn2.ReadOnly = true;
            this.dsmarcaDataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Sigla_unidade";
            this.dataGridViewTextBoxColumn3.HeaderText = "Sigla_unidade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // stconsumointernoDataGridViewTextBoxColumn2
            // 
            this.stconsumointernoDataGridViewTextBoxColumn2.DataPropertyName = "St_consumointerno";
            this.stconsumointernoDataGridViewTextBoxColumn2.HeaderText = "St_consumointerno";
            this.stconsumointernoDataGridViewTextBoxColumn2.Name = "stconsumointernoDataGridViewTextBoxColumn2";
            this.stconsumointernoDataGridViewTextBoxColumn2.ReadOnly = true;
            this.stconsumointernoDataGridViewTextBoxColumn2.Visible = false;
            // 
            // bsItensInventario
            // 
            this.bsItensInventario.DataMember = "lItensInventario";
            this.bsItensInventario.DataSource = this.bsInventario;
            this.bsItensInventario.PositionChanged += new System.EventHandler(this.bsItensInventario_PositionChanged);
            // 
            // lblConciliacao
            // 
            this.lblConciliacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.lblConciliacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConciliacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConciliacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblConciliacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblConciliacao.ForeColor = System.Drawing.Color.White;
            this.lblConciliacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblConciliacao.Location = new System.Drawing.Point(0, 0);
            this.lblConciliacao.Name = "lblConciliacao";
            this.lblConciliacao.Size = new System.Drawing.Size(298, 18);
            this.lblConciliacao.TabIndex = 65;
            this.lblConciliacao.Text = "ITENS INVENTARIO";
            this.lblConciliacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsItensInventario;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 433);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigator1.Size = new System.Drawing.Size(298, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem1.Text = "de {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Ultimo Registro";
            // 
            // tcSaldo
            // 
            this.tcSaldo.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcSaldo.Controls.Add(this.tpSaldo);
            this.tcSaldo.Controls.Add(this.tpEstoque);
            this.tcSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSaldo.Location = new System.Drawing.Point(0, 0);
            this.tcSaldo.Name = "tcSaldo";
            this.tcSaldo.SelectedIndex = 0;
            this.tcSaldo.Size = new System.Drawing.Size(695, 458);
            this.tcSaldo.TabIndex = 67;
            // 
            // tpSaldo
            // 
            this.tpSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpSaldo.Controls.Add(this.tlpSaldo);
            this.tpSaldo.Location = new System.Drawing.Point(4, 25);
            this.tpSaldo.Name = "tpSaldo";
            this.tpSaldo.Padding = new System.Windows.Forms.Padding(3);
            this.tpSaldo.Size = new System.Drawing.Size(687, 429);
            this.tpSaldo.TabIndex = 0;
            this.tpSaldo.Text = "SALDO INVENTARIO";
            this.tpSaldo.UseVisualStyleBackColor = true;
            // 
            // tlpSaldo
            // 
            this.tlpSaldo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpSaldo.ColumnCount = 1;
            this.tlpSaldo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSaldo.Controls.Add(this.pSaldo, 0, 0);
            this.tlpSaldo.Controls.Add(this.pDadosSaldo, 0, 1);
            this.tlpSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSaldo.Location = new System.Drawing.Point(3, 3);
            this.tlpSaldo.Name = "tlpSaldo";
            this.tlpSaldo.RowCount = 2;
            this.tlpSaldo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSaldo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tlpSaldo.Size = new System.Drawing.Size(679, 421);
            this.tlpSaldo.TabIndex = 66;
            // 
            // pSaldo
            // 
            this.pSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pSaldo.Controls.Add(this.gSaldoItem);
            this.pSaldo.Controls.Add(this.bindingNavigator2);
            this.pSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSaldo.Location = new System.Drawing.Point(5, 5);
            this.pSaldo.Name = "pSaldo";
            this.pSaldo.NM_ProcDeletar = "";
            this.pSaldo.NM_ProcGravar = "";
            this.pSaldo.Size = new System.Drawing.Size(669, 242);
            this.pSaldo.TabIndex = 0;
            // 
            // gSaldoItem
            // 
            this.gSaldoItem.AllowUserToAddRows = false;
            this.gSaldoItem.AllowUserToDeleteRows = false;
            this.gSaldoItem.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gSaldoItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gSaldoItem.AutoGenerateColumns = false;
            this.gSaldoItem.BackgroundColor = System.Drawing.Color.LightGray;
            this.gSaldoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gSaldoItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gSaldoItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gSaldoItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idinventarioDataGridViewTextBoxColumn2,
            this.cdprodutoDataGridViewTextBoxColumn1,
            this.dsprodutoDataGridViewTextBoxColumn1,
            this.Qtd_contada,
            this.Qtd_saldo,
            this.Qtd_saldoatual,
            this.Qtd_saldoAmx,
            this.Vl_unitario,
            this.vl_medio,
            this.Vl_subtotal,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.gSaldoItem.DataSource = this.bsSaldoItem;
            this.gSaldoItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gSaldoItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gSaldoItem.Location = new System.Drawing.Point(0, 0);
            this.gSaldoItem.Name = "gSaldoItem";
            this.gSaldoItem.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gSaldoItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gSaldoItem.RowHeadersWidth = 23;
            this.gSaldoItem.Size = new System.Drawing.Size(665, 213);
            this.gSaldoItem.TabIndex = 0;
            this.gSaldoItem.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gSaldoItem_ColumnHeaderMouseClick);
            // 
            // idinventarioDataGridViewTextBoxColumn2
            // 
            this.idinventarioDataGridViewTextBoxColumn2.DataPropertyName = "Id_inventario";
            this.idinventarioDataGridViewTextBoxColumn2.HeaderText = "Id. Inventário";
            this.idinventarioDataGridViewTextBoxColumn2.Name = "idinventarioDataGridViewTextBoxColumn2";
            this.idinventarioDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn1
            // 
            this.cdprodutoDataGridViewTextBoxColumn1.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn1.HeaderText = "Cd. Produto";
            this.cdprodutoDataGridViewTextBoxColumn1.Name = "cdprodutoDataGridViewTextBoxColumn1";
            this.cdprodutoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn1
            // 
            this.dsprodutoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn1.HeaderText = "Ds. Produto";
            this.dsprodutoDataGridViewTextBoxColumn1.Name = "dsprodutoDataGridViewTextBoxColumn1";
            this.dsprodutoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Qtd_contada
            // 
            this.Qtd_contada.DataPropertyName = "Qtd_contada";
            this.Qtd_contada.HeaderText = "Qtd. Contada";
            this.Qtd_contada.Name = "Qtd_contada";
            this.Qtd_contada.ReadOnly = true;
            // 
            // Qtd_saldo
            // 
            this.Qtd_saldo.DataPropertyName = "Qtd_saldo";
            this.Qtd_saldo.HeaderText = "Qtd. Saldo";
            this.Qtd_saldo.Name = "Qtd_saldo";
            this.Qtd_saldo.ReadOnly = true;
            // 
            // Qtd_saldoatual
            // 
            this.Qtd_saldoatual.DataPropertyName = "Qtd_saldoatual";
            this.Qtd_saldoatual.HeaderText = "Qtd. Saldo Atual";
            this.Qtd_saldoatual.Name = "Qtd_saldoatual";
            this.Qtd_saldoatual.ReadOnly = true;
            // 
            // Qtd_saldoAmx
            // 
            this.Qtd_saldoAmx.DataPropertyName = "Qtd_saldoAmx";
            this.Qtd_saldoAmx.HeaderText = "Qtd. Saldo Amx";
            this.Qtd_saldoAmx.Name = "Qtd_saldoAmx";
            this.Qtd_saldoAmx.ReadOnly = true;
            // 
            // Vl_unitario
            // 
            this.Vl_unitario.DataPropertyName = "Vl_unitario";
            this.Vl_unitario.HeaderText = "Vl. Unitário";
            this.Vl_unitario.Name = "Vl_unitario";
            this.Vl_unitario.ReadOnly = true;
            // 
            // vl_medio
            // 
            this.vl_medio.DataPropertyName = "vl_medio";
            this.vl_medio.HeaderText = "Vl. Médio";
            this.vl_medio.Name = "vl_medio";
            this.vl_medio.ReadOnly = true;
            // 
            // Vl_subtotal
            // 
            this.Vl_subtotal.DataPropertyName = "Vl_subtotal";
            this.Vl_subtotal.HeaderText = "Vl. Subtotal";
            this.Vl_subtotal.Name = "Vl_subtotal";
            this.Vl_subtotal.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_local";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Local";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_local";
            this.dataGridViewTextBoxColumn2.HeaderText = "Ds. Local";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Id_Almox";
            this.dataGridViewTextBoxColumn4.HeaderText = "Id. Almoxarifado";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Sigla_unidade";
            this.dataGridViewTextBoxColumn5.HeaderText = "Sigla_unidade";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // bsSaldoItem
            // 
            this.bsSaldoItem.DataMember = "lSaldoItem";
            this.bsSaldoItem.DataSource = this.bsItensInventario;
            this.bsSaldoItem.PositionChanged += new System.EventHandler(this.bsSaldoItem_PositionChanged);
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.BindingSource = this.bsSaldoItem;
            this.bindingNavigator2.CountItem = this.bindingNavigatorCountItem2;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem2,
            this.bindingNavigatorMovePreviousItem2,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorPositionItem2,
            this.bindingNavigatorCountItem2,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorMoveNextItem2,
            this.bindingNavigatorMoveLastItem2});
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 213);
            this.bindingNavigator2.MoveFirstItem = this.bindingNavigatorMoveFirstItem2;
            this.bindingNavigator2.MoveLastItem = this.bindingNavigatorMoveLastItem2;
            this.bindingNavigator2.MoveNextItem = this.bindingNavigatorMoveNextItem2;
            this.bindingNavigator2.MovePreviousItem = this.bindingNavigatorMovePreviousItem2;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.bindingNavigatorPositionItem2;
            this.bindingNavigator2.Size = new System.Drawing.Size(665, 25);
            this.bindingNavigator2.TabIndex = 1;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // bindingNavigatorCountItem2
            // 
            this.bindingNavigatorCountItem2.Name = "bindingNavigatorCountItem2";
            this.bindingNavigatorCountItem2.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem2.Text = "de {0}";
            this.bindingNavigatorCountItem2.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem2
            // 
            this.bindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem2.Image")));
            this.bindingNavigatorMoveFirstItem2.Name = "bindingNavigatorMoveFirstItem2";
            this.bindingNavigatorMoveFirstItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem2.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem2
            // 
            this.bindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem2.Image")));
            this.bindingNavigatorMovePreviousItem2.Name = "bindingNavigatorMovePreviousItem2";
            this.bindingNavigatorMovePreviousItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem2.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem2
            // 
            this.bindingNavigatorPositionItem2.AccessibleName = "Position";
            this.bindingNavigatorPositionItem2.AutoSize = false;
            this.bindingNavigatorPositionItem2.Name = "bindingNavigatorPositionItem2";
            this.bindingNavigatorPositionItem2.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem2.Text = "0";
            this.bindingNavigatorPositionItem2.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem2
            // 
            this.bindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem2.Image")));
            this.bindingNavigatorMoveNextItem2.Name = "bindingNavigatorMoveNextItem2";
            this.bindingNavigatorMoveNextItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem2.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem2
            // 
            this.bindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem2.Image")));
            this.bindingNavigatorMoveLastItem2.Name = "bindingNavigatorMoveLastItem2";
            this.bindingNavigatorMoveLastItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem2.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem2.Text = "Ultimo Registro";
            // 
            // pDadosSaldo
            // 
            this.pDadosSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDadosSaldo.Controls.Add(this.bb_almox);
            this.pDadosSaldo.Controls.Add(this.id_almox);
            this.pDadosSaldo.Controls.Add(label4);
            this.pDadosSaldo.Controls.Add(this.cd_produto);
            this.pDadosSaldo.Controls.Add(this.editDefault4);
            this.pDadosSaldo.Controls.Add(this.label6);
            this.pDadosSaldo.Controls.Add(this.editDefault3);
            this.pDadosSaldo.Controls.Add(this.label5);
            this.pDadosSaldo.Controls.Add(this.id_inventariosaldo);
            this.pDadosSaldo.Controls.Add(this.TS_Endereco);
            this.pDadosSaldo.Controls.Add(this.editDefault1);
            this.pDadosSaldo.Controls.Add(this.sigla_unidadeEditDefault);
            this.pDadosSaldo.Controls.Add(vl_subtotalLabel);
            this.pDadosSaldo.Controls.Add(this.vl_subtotalEditFloat);
            this.pDadosSaldo.Controls.Add(vl_unitarioLabel);
            this.pDadosSaldo.Controls.Add(this.vl_unitarioEditFloat);
            this.pDadosSaldo.Controls.Add(qtd_contadaLabel);
            this.pDadosSaldo.Controls.Add(this.qtd_contadaEditFloat);
            this.pDadosSaldo.Controls.Add(this.bb_local);
            this.pDadosSaldo.Controls.Add(this.ds_local);
            this.pDadosSaldo.Controls.Add(cd_localLabel);
            this.pDadosSaldo.Controls.Add(this.cd_local);
            this.pDadosSaldo.Controls.Add(ds_produtoLabel);
            this.pDadosSaldo.Controls.Add(this.ds_produtoEditDefault);
            this.pDadosSaldo.Controls.Add(qtd_saldoLabel);
            this.pDadosSaldo.Controls.Add(this.qtd_saldoEditFloat);
            this.pDadosSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDadosSaldo.Location = new System.Drawing.Point(5, 255);
            this.pDadosSaldo.Name = "pDadosSaldo";
            this.pDadosSaldo.NM_ProcDeletar = "";
            this.pDadosSaldo.NM_ProcGravar = "";
            this.pDadosSaldo.Size = new System.Drawing.Size(669, 161);
            this.pDadosSaldo.TabIndex = 1;
            // 
            // bb_almox
            // 
            this.bb_almox.BackColor = System.Drawing.SystemColors.Control;
            this.bb_almox.Enabled = false;
            this.bb_almox.Image = ((System.Drawing.Image)(resources.GetObject("bb_almox.Image")));
            this.bb_almox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_almox.Location = new System.Drawing.Point(566, 82);
            this.bb_almox.Name = "bb_almox";
            this.bb_almox.Size = new System.Drawing.Size(28, 19);
            this.bb_almox.TabIndex = 100;
            this.bb_almox.UseVisualStyleBackColor = false;
            this.bb_almox.Click += new System.EventHandler(this.bb_almox_Click);
            // 
            // id_almox
            // 
            this.id_almox.BackColor = System.Drawing.Color.White;
            this.id_almox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_almox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_almox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSaldoItem, "Id_Almox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_almox.Enabled = false;
            this.id_almox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_almox.Location = new System.Drawing.Point(494, 81);
            this.id_almox.MaxLength = 4;
            this.id_almox.Name = "id_almox";
            this.id_almox.NM_Alias = "";
            this.id_almox.NM_Campo = "id_almox";
            this.id_almox.NM_CampoBusca = "id_almox";
            this.id_almox.NM_Param = "@P_CD_EMPRESA";
            this.id_almox.QTD_Zero = 0;
            this.id_almox.Size = new System.Drawing.Size(67, 20);
            this.id_almox.ST_AutoInc = false;
            this.id_almox.ST_DisableAuto = false;
            this.id_almox.ST_Float = false;
            this.id_almox.ST_Gravar = false;
            this.id_almox.ST_Int = true;
            this.id_almox.ST_LimpaCampo = false;
            this.id_almox.ST_NotNull = false;
            this.id_almox.ST_PrimaryKey = false;
            this.id_almox.TabIndex = 99;
            this.id_almox.TextOld = null;
            this.id_almox.Leave += new System.EventHandler(this.id_almox_Leave);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensInventario, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(98, 56);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "CD_Empresa";
            this.cd_produto.NM_CampoBusca = "CD_Empresa";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(94, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 97;
            this.cd_produto.TextOld = null;
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInventario, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Enabled = false;
            this.editDefault4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault4.Location = new System.Drawing.Point(342, 30);
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "CD_Empresa";
            this.editDefault4.NM_CampoBusca = "CD_Empresa";
            this.editDefault4.NM_Param = "@P_CD_EMPRESA";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(322, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = true;
            this.editDefault4.ST_Int = true;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = true;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 96;
            this.editDefault4.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(205, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Empresa:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInventario, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.editDefault3.Location = new System.Drawing.Point(270, 30);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "CD_Empresa";
            this.editDefault3.NM_CampoBusca = "CD_Empresa";
            this.editDefault3.NM_Param = "@P_CD_EMPRESA";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(69, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = true;
            this.editDefault3.ST_Int = true;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = true;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 94;
            this.editDefault3.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Id. Inventario:";
            // 
            // id_inventariosaldo
            // 
            this.id_inventariosaldo.BackColor = System.Drawing.SystemColors.Window;
            this.id_inventariosaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_inventariosaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_inventariosaldo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsInventario, "Id_inventario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_inventariosaldo.Enabled = false;
            this.id_inventariosaldo.Location = new System.Drawing.Point(98, 30);
            this.id_inventariosaldo.Name = "id_inventariosaldo";
            this.id_inventariosaldo.NM_Alias = "";
            this.id_inventariosaldo.NM_Campo = "";
            this.id_inventariosaldo.NM_CampoBusca = "";
            this.id_inventariosaldo.NM_Param = "";
            this.id_inventariosaldo.QTD_Zero = 0;
            this.id_inventariosaldo.Size = new System.Drawing.Size(100, 20);
            this.id_inventariosaldo.ST_AutoInc = false;
            this.id_inventariosaldo.ST_DisableAuto = false;
            this.id_inventariosaldo.ST_Float = false;
            this.id_inventariosaldo.ST_Gravar = false;
            this.id_inventariosaldo.ST_Int = false;
            this.id_inventariosaldo.ST_LimpaCampo = true;
            this.id_inventariosaldo.ST_NotNull = false;
            this.id_inventariosaldo.ST_PrimaryKey = false;
            this.id_inventariosaldo.TabIndex = 37;
            this.id_inventariosaldo.TextOld = null;
            // 
            // TS_Endereco
            // 
            this.TS_Endereco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_btn_Inserir_Endereco,
            this.ts_btn_Alterar_Endereco,
            this.ts_btn_Deletar_Endereco});
            this.TS_Endereco.Location = new System.Drawing.Point(0, 0);
            this.TS_Endereco.Name = "TS_Endereco";
            this.TS_Endereco.Size = new System.Drawing.Size(667, 25);
            this.TS_Endereco.TabIndex = 36;
            // 
            // ts_btn_Inserir_Endereco
            // 
            this.ts_btn_Inserir_Endereco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ts_btn_Inserir_Endereco.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Inserir_Endereco.Image")));
            this.ts_btn_Inserir_Endereco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Inserir_Endereco.Name = "ts_btn_Inserir_Endereco";
            this.ts_btn_Inserir_Endereco.Size = new System.Drawing.Size(131, 22);
            this.ts_btn_Inserir_Endereco.Text = "(CTRL + F10) Novo";
            this.ts_btn_Inserir_Endereco.ToolTipText = "Novo  Registro";
            this.ts_btn_Inserir_Endereco.Click += new System.EventHandler(this.ts_btn_Inserir_Endereco_Click);
            // 
            // ts_btn_Alterar_Endereco
            // 
            this.ts_btn_Alterar_Endereco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ts_btn_Alterar_Endereco.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Alterar_Endereco.Image")));
            this.ts_btn_Alterar_Endereco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Alterar_Endereco.Name = "ts_btn_Alterar_Endereco";
            this.ts_btn_Alterar_Endereco.Size = new System.Drawing.Size(142, 22);
            this.ts_btn_Alterar_Endereco.Text = "(CTRL + F11) Gravar";
            this.ts_btn_Alterar_Endereco.ToolTipText = "Gravar Registro";
            this.ts_btn_Alterar_Endereco.Click += new System.EventHandler(this.ts_btn_Alterar_Endereco_Click);
            // 
            // ts_btn_Deletar_Endereco
            // 
            this.ts_btn_Deletar_Endereco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ts_btn_Deletar_Endereco.Image = ((System.Drawing.Image)(resources.GetObject("ts_btn_Deletar_Endereco.Image")));
            this.ts_btn_Deletar_Endereco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btn_Deletar_Endereco.Name = "ts_btn_Deletar_Endereco";
            this.ts_btn_Deletar_Endereco.Size = new System.Drawing.Size(140, 22);
            this.ts_btn_Deletar_Endereco.Text = "(CTRL + F12) Excluir";
            this.ts_btn_Deletar_Endereco.ToolTipText = "Excluir Produto Inventario";
            this.ts_btn_Deletar_Endereco.Click += new System.EventHandler(this.ts_btn_Deletar_Endereco_Click);
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensInventario, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(198, 108);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(32, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 32;
            this.editDefault1.TextOld = null;
            // 
            // sigla_unidadeEditDefault
            // 
            this.sigla_unidadeEditDefault.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidadeEditDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidadeEditDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidadeEditDefault.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensInventario, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidadeEditDefault.Enabled = false;
            this.sigla_unidadeEditDefault.Location = new System.Drawing.Point(224, 134);
            this.sigla_unidadeEditDefault.Name = "sigla_unidadeEditDefault";
            this.sigla_unidadeEditDefault.NM_Alias = "";
            this.sigla_unidadeEditDefault.NM_Campo = "";
            this.sigla_unidadeEditDefault.NM_CampoBusca = "";
            this.sigla_unidadeEditDefault.NM_Param = "";
            this.sigla_unidadeEditDefault.QTD_Zero = 0;
            this.sigla_unidadeEditDefault.Size = new System.Drawing.Size(32, 20);
            this.sigla_unidadeEditDefault.ST_AutoInc = false;
            this.sigla_unidadeEditDefault.ST_DisableAuto = false;
            this.sigla_unidadeEditDefault.ST_Float = false;
            this.sigla_unidadeEditDefault.ST_Gravar = false;
            this.sigla_unidadeEditDefault.ST_Int = false;
            this.sigla_unidadeEditDefault.ST_LimpaCampo = true;
            this.sigla_unidadeEditDefault.ST_NotNull = false;
            this.sigla_unidadeEditDefault.ST_PrimaryKey = false;
            this.sigla_unidadeEditDefault.TabIndex = 31;
            this.sigla_unidadeEditDefault.TextOld = null;
            // 
            // vl_subtotalEditFloat
            // 
            this.vl_subtotalEditFloat.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSaldoItem, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotalEditFloat.DecimalPlaces = 2;
            this.vl_subtotalEditFloat.Enabled = false;
            this.vl_subtotalEditFloat.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotalEditFloat.Location = new System.Drawing.Point(494, 109);
            this.vl_subtotalEditFloat.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_subtotalEditFloat.Name = "vl_subtotalEditFloat";
            this.vl_subtotalEditFloat.NM_Alias = "";
            this.vl_subtotalEditFloat.NM_Campo = "";
            this.vl_subtotalEditFloat.NM_Param = "";
            this.vl_subtotalEditFloat.Operador = "";
            this.vl_subtotalEditFloat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_subtotalEditFloat.Size = new System.Drawing.Size(100, 20);
            this.vl_subtotalEditFloat.ST_AutoInc = false;
            this.vl_subtotalEditFloat.ST_DisableAuto = false;
            this.vl_subtotalEditFloat.ST_Gravar = false;
            this.vl_subtotalEditFloat.ST_LimparCampo = true;
            this.vl_subtotalEditFloat.ST_NotNull = false;
            this.vl_subtotalEditFloat.ST_PrimaryKey = false;
            this.vl_subtotalEditFloat.TabIndex = 30;
            this.vl_subtotalEditFloat.ThousandsSeparator = true;
            this.vl_subtotalEditFloat.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // vl_unitarioEditFloat
            // 
            this.vl_unitarioEditFloat.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSaldoItem, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitarioEditFloat.DecimalPlaces = 5;
            this.vl_unitarioEditFloat.Enabled = false;
            this.vl_unitarioEditFloat.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitarioEditFloat.Location = new System.Drawing.Point(310, 109);
            this.vl_unitarioEditFloat.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitarioEditFloat.Name = "vl_unitarioEditFloat";
            this.vl_unitarioEditFloat.NM_Alias = "";
            this.vl_unitarioEditFloat.NM_Campo = "";
            this.vl_unitarioEditFloat.NM_Param = "";
            this.vl_unitarioEditFloat.Operador = "";
            this.vl_unitarioEditFloat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_unitarioEditFloat.Size = new System.Drawing.Size(89, 20);
            this.vl_unitarioEditFloat.ST_AutoInc = false;
            this.vl_unitarioEditFloat.ST_DisableAuto = false;
            this.vl_unitarioEditFloat.ST_Gravar = false;
            this.vl_unitarioEditFloat.ST_LimparCampo = true;
            this.vl_unitarioEditFloat.ST_NotNull = false;
            this.vl_unitarioEditFloat.ST_PrimaryKey = false;
            this.vl_unitarioEditFloat.TabIndex = 5;
            this.vl_unitarioEditFloat.ThousandsSeparator = true;
            this.vl_unitarioEditFloat.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // qtd_contadaEditFloat
            // 
            this.qtd_contadaEditFloat.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSaldoItem, "Qtd_contada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_contadaEditFloat.DecimalPlaces = 3;
            this.qtd_contadaEditFloat.Enabled = false;
            this.qtd_contadaEditFloat.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_contadaEditFloat.Location = new System.Drawing.Point(98, 108);
            this.qtd_contadaEditFloat.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_contadaEditFloat.Name = "qtd_contadaEditFloat";
            this.qtd_contadaEditFloat.NM_Alias = "";
            this.qtd_contadaEditFloat.NM_Campo = "";
            this.qtd_contadaEditFloat.NM_Param = "";
            this.qtd_contadaEditFloat.Operador = "";
            this.qtd_contadaEditFloat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_contadaEditFloat.Size = new System.Drawing.Size(95, 20);
            this.qtd_contadaEditFloat.ST_AutoInc = false;
            this.qtd_contadaEditFloat.ST_DisableAuto = false;
            this.qtd_contadaEditFloat.ST_Gravar = false;
            this.qtd_contadaEditFloat.ST_LimparCampo = true;
            this.qtd_contadaEditFloat.ST_NotNull = false;
            this.qtd_contadaEditFloat.ST_PrimaryKey = false;
            this.qtd_contadaEditFloat.TabIndex = 4;
            this.qtd_contadaEditFloat.ThousandsSeparator = true;
            this.qtd_contadaEditFloat.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bb_local
            // 
            this.bb_local.BackColor = System.Drawing.SystemColors.Control;
            this.bb_local.Enabled = false;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.Location = new System.Drawing.Point(171, 82);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 1;
            this.bb_local.UseVisualStyleBackColor = false;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSaldoItem, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Location = new System.Drawing.Point(205, 82);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_LOCAL";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(194, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 26;
            this.ds_local.TextOld = null;
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.SystemColors.Window;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsSaldoItem, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Enabled = false;
            this.cd_local.Location = new System.Drawing.Point(98, 81);
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_LOCAL";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(69, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = false;
            this.cd_local.ST_Int = true;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = false;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 0;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // ds_produtoEditDefault
            // 
            this.ds_produtoEditDefault.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produtoEditDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produtoEditDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produtoEditDefault.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsItensInventario, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produtoEditDefault.Enabled = false;
            this.ds_produtoEditDefault.Location = new System.Drawing.Point(195, 56);
            this.ds_produtoEditDefault.Name = "ds_produtoEditDefault";
            this.ds_produtoEditDefault.NM_Alias = "";
            this.ds_produtoEditDefault.NM_Campo = "";
            this.ds_produtoEditDefault.NM_CampoBusca = "";
            this.ds_produtoEditDefault.NM_Param = "";
            this.ds_produtoEditDefault.QTD_Zero = 0;
            this.ds_produtoEditDefault.Size = new System.Drawing.Size(469, 20);
            this.ds_produtoEditDefault.ST_AutoInc = false;
            this.ds_produtoEditDefault.ST_DisableAuto = false;
            this.ds_produtoEditDefault.ST_Float = false;
            this.ds_produtoEditDefault.ST_Gravar = false;
            this.ds_produtoEditDefault.ST_Int = false;
            this.ds_produtoEditDefault.ST_LimpaCampo = true;
            this.ds_produtoEditDefault.ST_NotNull = false;
            this.ds_produtoEditDefault.ST_PrimaryKey = false;
            this.ds_produtoEditDefault.TabIndex = 23;
            this.ds_produtoEditDefault.TextOld = null;
            // 
            // qtd_saldoEditFloat
            // 
            this.qtd_saldoEditFloat.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsSaldoItem, "Qtd_saldo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_saldoEditFloat.DecimalPlaces = 3;
            this.qtd_saldoEditFloat.Enabled = false;
            this.qtd_saldoEditFloat.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd_saldoEditFloat.Location = new System.Drawing.Point(98, 134);
            this.qtd_saldoEditFloat.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_saldoEditFloat.Name = "qtd_saldoEditFloat";
            this.qtd_saldoEditFloat.NM_Alias = "";
            this.qtd_saldoEditFloat.NM_Campo = "";
            this.qtd_saldoEditFloat.NM_Param = "";
            this.qtd_saldoEditFloat.Operador = "";
            this.qtd_saldoEditFloat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.qtd_saldoEditFloat.Size = new System.Drawing.Size(120, 20);
            this.qtd_saldoEditFloat.ST_AutoInc = false;
            this.qtd_saldoEditFloat.ST_DisableAuto = false;
            this.qtd_saldoEditFloat.ST_Gravar = false;
            this.qtd_saldoEditFloat.ST_LimparCampo = true;
            this.qtd_saldoEditFloat.ST_NotNull = false;
            this.qtd_saldoEditFloat.ST_PrimaryKey = false;
            this.qtd_saldoEditFloat.TabIndex = 19;
            this.qtd_saldoEditFloat.ThousandsSeparator = true;
            this.qtd_saldoEditFloat.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // tpEstoque
            // 
            this.tpEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpEstoque.Controls.Add(this.gEstoque);
            this.tpEstoque.Controls.Add(this.bindingNavigator3);
            this.tpEstoque.Location = new System.Drawing.Point(4, 25);
            this.tpEstoque.Name = "tpEstoque";
            this.tpEstoque.Padding = new System.Windows.Forms.Padding(3);
            this.tpEstoque.Size = new System.Drawing.Size(687, 429);
            this.tpEstoque.TabIndex = 1;
            this.tpEstoque.Text = "ESTOQUE INVENTARIO";
            this.tpEstoque.UseVisualStyleBackColor = true;
            // 
            // gEstoque
            // 
            this.gEstoque.AllowUserToAddRows = false;
            this.gEstoque.AllowUserToDeleteRows = false;
            this.gEstoque.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEstoque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gEstoque.AutoGenerateColumns = false;
            this.gEstoque.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEstoque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEstoque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.Ds_produto});
            this.gEstoque.DataSource = this.bsEstoque;
            this.gEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEstoque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEstoque.Location = new System.Drawing.Point(3, 3);
            this.gEstoque.Name = "gEstoque";
            this.gEstoque.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEstoque.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gEstoque.RowHeadersWidth = 23;
            this.gEstoque.Size = new System.Drawing.Size(679, 396);
            this.gEstoque.TabIndex = 0;
            this.gEstoque.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEstoque_ColumnHeaderMouseClick);
            // 
            // bsEstoque
            // 
            this.bsEstoque.DataMember = "lEstoque";
            this.bsEstoque.DataSource = this.bsSaldoItem;
            // 
            // bindingNavigator3
            // 
            this.bindingNavigator3.AddNewItem = null;
            this.bindingNavigator3.BindingSource = this.bsEstoque;
            this.bindingNavigator3.CountItem = this.bindingNavigatorCountItem3;
            this.bindingNavigator3.DeleteItem = null;
            this.bindingNavigator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem3,
            this.bindingNavigatorMovePreviousItem3,
            this.bindingNavigatorSeparator6,
            this.bindingNavigatorPositionItem3,
            this.bindingNavigatorCountItem3,
            this.bindingNavigatorSeparator7,
            this.bindingNavigatorMoveNextItem3,
            this.bindingNavigatorMoveLastItem3});
            this.bindingNavigator3.Location = new System.Drawing.Point(3, 399);
            this.bindingNavigator3.MoveFirstItem = this.bindingNavigatorMoveFirstItem3;
            this.bindingNavigator3.MoveLastItem = this.bindingNavigatorMoveLastItem3;
            this.bindingNavigator3.MoveNextItem = this.bindingNavigatorMoveNextItem3;
            this.bindingNavigator3.MovePreviousItem = this.bindingNavigatorMovePreviousItem3;
            this.bindingNavigator3.Name = "bindingNavigator3";
            this.bindingNavigator3.PositionItem = this.bindingNavigatorPositionItem3;
            this.bindingNavigator3.Size = new System.Drawing.Size(679, 25);
            this.bindingNavigator3.TabIndex = 1;
            this.bindingNavigator3.Text = "bindingNavigator3";
            // 
            // bindingNavigatorCountItem3
            // 
            this.bindingNavigatorCountItem3.Name = "bindingNavigatorCountItem3";
            this.bindingNavigatorCountItem3.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem3.Text = "de {0}";
            this.bindingNavigatorCountItem3.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem3
            // 
            this.bindingNavigatorMoveFirstItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem3.Image")));
            this.bindingNavigatorMoveFirstItem3.Name = "bindingNavigatorMoveFirstItem3";
            this.bindingNavigatorMoveFirstItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem3.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem3
            // 
            this.bindingNavigatorMovePreviousItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem3.Image")));
            this.bindingNavigatorMovePreviousItem3.Name = "bindingNavigatorMovePreviousItem3";
            this.bindingNavigatorMovePreviousItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem3.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator6
            // 
            this.bindingNavigatorSeparator6.Name = "bindingNavigatorSeparator6";
            this.bindingNavigatorSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem3
            // 
            this.bindingNavigatorPositionItem3.AccessibleName = "Position";
            this.bindingNavigatorPositionItem3.AutoSize = false;
            this.bindingNavigatorPositionItem3.Name = "bindingNavigatorPositionItem3";
            this.bindingNavigatorPositionItem3.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem3.Text = "0";
            this.bindingNavigatorPositionItem3.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator7
            // 
            this.bindingNavigatorSeparator7.Name = "bindingNavigatorSeparator7";
            this.bindingNavigatorSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem3
            // 
            this.bindingNavigatorMoveNextItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem3.Image")));
            this.bindingNavigatorMoveNextItem3.Name = "bindingNavigatorMoveNextItem3";
            this.bindingNavigatorMoveNextItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem3.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem3
            // 
            this.bindingNavigatorMoveLastItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem3.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem3.Image")));
            this.bindingNavigatorMoveLastItem3.Name = "bindingNavigatorMoveLastItem3";
            this.bindingNavigatorMoveLastItem3.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem3.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem3.Text = "Ultimo Registro";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(422, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(667, 25);
            this.miniToolStrip.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Cd_produto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Cd. Produto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Ds_produto
            // 
            this.Ds_produto.DataPropertyName = "Ds_produto";
            this.Ds_produto.HeaderText = "Ds. Produto";
            this.Ds_produto.Name = "Ds_produto";
            this.Ds_produto.ReadOnly = true;
            // 
            // TFConsultaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 610);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFConsultaInventario";
            this.ShowInTaskbar = false;
            this.Text = "Consulta Inventario Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFConsultaInventario_FormClosing);
            this.Load += new System.EventHandler(this.TFConsultaInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConsultaInventario_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pStatus.ResumeLayout(false);
            this.pStatus.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpInventario.ResumeLayout(false);
            this.tpInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnInventario)).EndInit();
            this.bnInventario.ResumeLayout(false);
            this.bnInventario.PerformLayout();
            this.tpItens.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gItensInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItensInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tcSaldo.ResumeLayout(false);
            this.tpSaldo.ResumeLayout(false);
            this.tlpSaldo.ResumeLayout(false);
            this.pSaldo.ResumeLayout(false);
            this.pSaldo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gSaldoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSaldoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.pDadosSaldo.ResumeLayout(false);
            this.pDadosSaldo.PerformLayout();
            this.TS_Endereco.ResumeLayout(false);
            this.TS_Endereco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotalEditFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitarioEditFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_contadaEditFloat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_saldoEditFloat)).EndInit();
            this.tpEstoque.ResumeLayout(false);
            this.tpEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator3)).EndInit();
            this.bindingNavigator3.ResumeLayout(false);
            this.bindingNavigator3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton bb_alterar;
        public System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.TabControl tcCentral;
        private System.Windows.Forms.TabPage tpInventario;
        private System.Windows.Forms.TabPage tpItens;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Componentes.DataGridDefault gInventario;
        private System.Windows.Forms.BindingSource bsInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusinventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinventarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtinventariostringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_observacao;
        private System.Windows.Forms.BindingNavigator bnInventario;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gItensInventario;
        private System.Windows.Forms.BindingSource bsItensInventario;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private Componentes.DataGridDefault gSaldoItem;
        private System.Windows.Forms.BindingSource bsSaldoItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdcontadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdsaldoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdsaldoprocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_inventario;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditData dt_fin;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private Componentes.PanelDados pStatus;
        private Componentes.CheckBoxDefault st_aberto;
        private Componentes.CheckBoxDefault st_processado;
        private System.Windows.Forms.Label lblConciliacao;
        private System.Windows.Forms.ToolStripButton bb_processa;
        private System.Windows.Forms.TableLayoutPanel tlpSaldo;
        private Componentes.PanelDados pSaldo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem itensInventariarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldoItensInventarioToolStripMenuItem;
        private System.Windows.Forms.TabControl tcSaldo;
        private System.Windows.Forms.TabPage tpSaldo;
        private System.Windows.Forms.TabPage tpEstoque;
        private System.Windows.Forms.BindingNavigator bindingNavigator3;
        private System.Windows.Forms.BindingSource bsEstoque;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator6;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem3;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator7;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem3;
        private Componentes.DataGridDefault gEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlanctoestoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctoSTRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdentradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdsaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn stregistroStringDataGridViewTextBoxColumn;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinventarioDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdreferenciaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdmarcaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmarcaDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn stconsumointernoDataGridViewTextBoxColumn2;
        private Componentes.PanelDados pDadosSaldo;
        private System.Windows.Forms.Button bb_almox;
        private Componentes.EditDefault id_almox;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault editDefault3;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault id_inventariosaldo;
        private System.Windows.Forms.ToolStrip TS_Endereco;
        private System.Windows.Forms.ToolStripButton ts_btn_Inserir_Endereco;
        private System.Windows.Forms.ToolStripButton ts_btn_Alterar_Endereco;
        private System.Windows.Forms.ToolStripButton ts_btn_Deletar_Endereco;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault sigla_unidadeEditDefault;
        private Componentes.EditFloat vl_subtotalEditFloat;
        private Componentes.EditFloat vl_unitarioEditFloat;
        private Componentes.EditFloat qtd_contadaEditFloat;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault ds_local;
        private Componentes.EditDefault cd_local;
        private Componentes.EditDefault ds_produtoEditDefault;
        private Componentes.EditFloat qtd_saldoEditFloat;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinventarioDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_contada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_saldoatual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qtd_saldoAmx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn vl_medio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_produto;
    }
}