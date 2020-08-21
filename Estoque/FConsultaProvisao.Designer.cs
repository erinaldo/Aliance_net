namespace Estoque
{
    partial class TFConsultaProvisao
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
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConsultaProvisao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.bb_baixar = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.dt_ini = new Componentes.EditData(this.components);
            this.st_provsaldo = new Componentes.CheckBoxDefault(this.components);
            this.BB_Produto = new System.Windows.Forms.Button();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.id_provisao = new Componentes.EditDefault(this.components);
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpProvisao = new System.Windows.Forms.TabPage();
            this.gProvisao = new Componentes.DataGridDefault(this.components);
            this.idprovisaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tot_Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tot_Saida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo_Provisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Medio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoprovDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprovisaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsProvisao = new System.Windows.Forms.BindingSource(this.components);
            this.bnProvisao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tpMovEstoque = new System.Windows.Forms.TabPage();
            this.gEstoque = new Componentes.DataGridDefault(this.components);
            this.idlanctoestoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdlocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dslocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctoSTRDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdentradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdsaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_registro_String = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEstoque = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpProvisao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProvisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnProvisao)).BeginInit();
            this.bnProvisao.SuspendLayout();
            this.tpMovEstoque.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEstoque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(340, 32);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(44, 13);
            label3.TabIndex = 141;
            label3.Text = "Dt. Fin.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(340, 6);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 13);
            label2.TabIndex = 139;
            label2.Text = "Dt. Ini.:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label25.Location = new System.Drawing.Point(185, 6);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(47, 13);
            label25.TabIndex = 136;
            label25.Text = "Produto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(6, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 13);
            label1.TabIndex = 65;
            label1.Text = "Id. Provisão:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.bb_baixar,
            this.BB_Buscar,
            this.BB_Imprimir,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1020, 43);
            this.barraMenu.TabIndex = 2;
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
            // bb_baixar
            // 
            this.bb_baixar.AutoSize = false;
            this.bb_baixar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_baixar.ForeColor = System.Drawing.Color.Green;
            this.bb_baixar.Image = ((System.Drawing.Image)(resources.GetObject("bb_baixar.Image")));
            this.bb_baixar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_baixar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_baixar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_baixar.Name = "bb_baixar";
            this.bb_baixar.Size = new System.Drawing.Size(85, 40);
            this.bb_baixar.Text = "(F3)\r\n Baixar";
            this.bb_baixar.ToolTipText = "Baixar Provisão";
            this.bb_baixar.Click += new System.EventHandler(this.bb_baixar_Click);
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
            // BB_Imprimir
            // 
            this.BB_Imprimir.AutoSize = false;
            this.BB_Imprimir.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Imprimir.Image")));
            this.BB_Imprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Size = new System.Drawing.Size(110, 40);
            this.BB_Imprimir.Text = "(F8)\r\n Imprimir";
            this.BB_Imprimir.ToolTipText = "Imprimir Registros";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
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
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Size = new System.Drawing.Size(1020, 549);
            this.tlpCentral.TabIndex = 3;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(label3);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(label2);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.st_provsaldo);
            this.pFiltro.Controls.Add(this.BB_Produto);
            this.pFiltro.Controls.Add(this.cd_produto);
            this.pFiltro.Controls.Add(label25);
            this.pFiltro.Controls.Add(this.BB_Empresa);
            this.pFiltro.Controls.Add(this.label13);
            this.pFiltro.Controls.Add(this.CD_Empresa);
            this.pFiltro.Controls.Add(label1);
            this.pFiltro.Controls.Add(this.id_provisao);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1010, 54);
            this.pFiltro.TabIndex = 0;
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(387, 29);
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
            this.dt_fin.TabIndex = 140;
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(387, 3);
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
            this.dt_ini.TabIndex = 138;
            // 
            // st_provsaldo
            // 
            this.st_provsaldo.AutoSize = true;
            this.st_provsaldo.Location = new System.Drawing.Point(184, 31);
            this.st_provsaldo.Name = "st_provsaldo";
            this.st_provsaldo.NM_Alias = "";
            this.st_provsaldo.NM_Campo = "";
            this.st_provsaldo.NM_Param = "";
            this.st_provsaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.st_provsaldo.Size = new System.Drawing.Size(153, 17);
            this.st_provsaldo.ST_Gravar = false;
            this.st_provsaldo.ST_LimparCampo = true;
            this.st_provsaldo.ST_NotNull = false;
            this.st_provsaldo.TabIndex = 137;
            this.st_provsaldo.Text = "Provisão Com Saldo Baixar";
            this.st_provsaldo.UseVisualStyleBackColor = true;
            this.st_provsaldo.Vl_False = "";
            this.st_provsaldo.Vl_True = "";
            // 
            // BB_Produto
            // 
            this.BB_Produto.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Produto.Image = ((System.Drawing.Image)(resources.GetObject("BB_Produto.Image")));
            this.BB_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Produto.Location = new System.Drawing.Point(306, 3);
            this.BB_Produto.Name = "BB_Produto";
            this.BB_Produto.Size = new System.Drawing.Size(28, 19);
            this.BB_Produto.TabIndex = 135;
            this.BB_Produto.UseVisualStyleBackColor = false;
            this.BB_Produto.Click += new System.EventHandler(this.BB_Produto_Click);
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_produto.Location = new System.Drawing.Point(238, 3);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_Produto";
            this.cd_produto.NM_CampoBusca = "cd_Produto";
            this.cd_produto.NM_Param = "@P_CD_";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(67, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = true;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 134;
            this.cd_produto.TextOld = null;
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(151, 29);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 19);
            this.BB_Empresa.TabIndex = 89;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(21, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 90;
            this.label13.Text = "Empresa:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(79, 29);
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
            this.CD_Empresa.ST_NotNull = false;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 88;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // id_provisao
            // 
            this.id_provisao.BackColor = System.Drawing.SystemColors.Window;
            this.id_provisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_provisao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_provisao.Location = new System.Drawing.Point(79, 3);
            this.id_provisao.Name = "id_provisao";
            this.id_provisao.NM_Alias = "";
            this.id_provisao.NM_Campo = "";
            this.id_provisao.NM_CampoBusca = "";
            this.id_provisao.NM_Param = "";
            this.id_provisao.QTD_Zero = 0;
            this.id_provisao.Size = new System.Drawing.Size(100, 20);
            this.id_provisao.ST_AutoInc = false;
            this.id_provisao.ST_DisableAuto = false;
            this.id_provisao.ST_Float = false;
            this.id_provisao.ST_Gravar = false;
            this.id_provisao.ST_Int = false;
            this.id_provisao.ST_LimpaCampo = true;
            this.id_provisao.ST_NotNull = false;
            this.id_provisao.ST_PrimaryKey = false;
            this.id_provisao.TabIndex = 0;
            this.id_provisao.TextOld = null;
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpProvisao);
            this.tcCentral.Controls.Add(this.tpMovEstoque);
            this.tcCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCentral.Location = new System.Drawing.Point(5, 67);
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.Size = new System.Drawing.Size(1010, 477);
            this.tcCentral.TabIndex = 3;
            // 
            // tpProvisao
            // 
            this.tpProvisao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpProvisao.Controls.Add(this.gProvisao);
            this.tpProvisao.Controls.Add(this.bnProvisao);
            this.tpProvisao.Location = new System.Drawing.Point(4, 22);
            this.tpProvisao.Name = "tpProvisao";
            this.tpProvisao.Padding = new System.Windows.Forms.Padding(3);
            this.tpProvisao.Size = new System.Drawing.Size(1002, 451);
            this.tpProvisao.TabIndex = 0;
            this.tpProvisao.Text = "PROVISÃO";
            this.tpProvisao.UseVisualStyleBackColor = true;
            // 
            // gProvisao
            // 
            this.gProvisao.AllowUserToAddRows = false;
            this.gProvisao.AllowUserToDeleteRows = false;
            this.gProvisao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProvisao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gProvisao.AutoGenerateColumns = false;
            this.gProvisao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProvisao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProvisao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProvisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gProvisao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProvisao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idprovisaoDataGridViewTextBoxColumn,
            this.dtlanctostrDataGridViewTextBoxColumn,
            this.Tot_Entrada,
            this.Tot_Saida,
            this.Saldo_Provisao,
            this.VL_Medio,
            this.cdempresaprovDataGridViewTextBoxColumn,
            this.nmempresaprovDataGridViewTextBoxColumn,
            this.cdprodutoprovDataGridViewTextBoxColumn,
            this.dsprodutoprovDataGridViewTextBoxColumn,
            this.dsprovisaoDataGridViewTextBoxColumn});
            this.gProvisao.DataSource = this.bsProvisao;
            this.gProvisao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gProvisao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProvisao.Location = new System.Drawing.Point(3, 3);
            this.gProvisao.Name = "gProvisao";
            this.gProvisao.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProvisao.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gProvisao.RowHeadersWidth = 23;
            this.gProvisao.Size = new System.Drawing.Size(994, 418);
            this.gProvisao.TabIndex = 0;
            this.gProvisao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gProvisao_ColumnHeaderMouseClick);
            this.gProvisao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gProvisao_CellFormatting);
            // 
            // idprovisaoDataGridViewTextBoxColumn
            // 
            this.idprovisaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idprovisaoDataGridViewTextBoxColumn.DataPropertyName = "Id_provisao";
            this.idprovisaoDataGridViewTextBoxColumn.HeaderText = "Id. Provisão";
            this.idprovisaoDataGridViewTextBoxColumn.Name = "idprovisaoDataGridViewTextBoxColumn";
            this.idprovisaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idprovisaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dtlanctostrDataGridViewTextBoxColumn
            // 
            this.dtlanctostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_lancto";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.dtlanctostrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtlanctostrDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dtlanctostrDataGridViewTextBoxColumn.Name = "dtlanctostrDataGridViewTextBoxColumn";
            this.dtlanctostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctostrDataGridViewTextBoxColumn.Width = 55;
            // 
            // Tot_Entrada
            // 
            this.Tot_Entrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tot_Entrada.DataPropertyName = "Tot_Entrada";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.Tot_Entrada.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tot_Entrada.HeaderText = "Qtd. Entrada";
            this.Tot_Entrada.Name = "Tot_Entrada";
            this.Tot_Entrada.ReadOnly = true;
            this.Tot_Entrada.Width = 92;
            // 
            // Tot_Saida
            // 
            this.Tot_Saida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tot_Saida.DataPropertyName = "Tot_Saida";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = "0";
            this.Tot_Saida.DefaultCellStyle = dataGridViewCellStyle5;
            this.Tot_Saida.HeaderText = "Qtd. Saida";
            this.Tot_Saida.Name = "Tot_Saida";
            this.Tot_Saida.ReadOnly = true;
            this.Tot_Saida.Width = 82;
            // 
            // Saldo_Provisao
            // 
            this.Saldo_Provisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Saldo_Provisao.DataPropertyName = "Saldo_Provisao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = "0";
            this.Saldo_Provisao.DefaultCellStyle = dataGridViewCellStyle6;
            this.Saldo_Provisao.HeaderText = "Saldo Provisão";
            this.Saldo_Provisao.Name = "Saldo_Provisao";
            this.Saldo_Provisao.ReadOnly = true;
            this.Saldo_Provisao.Width = 95;
            // 
            // VL_Medio
            // 
            this.VL_Medio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.VL_Medio.DataPropertyName = "VL_Medio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.VL_Medio.DefaultCellStyle = dataGridViewCellStyle7;
            this.VL_Medio.HeaderText = "Vl. Medio";
            this.VL_Medio.Name = "VL_Medio";
            this.VL_Medio.ReadOnly = true;
            this.VL_Medio.Width = 70;
            // 
            // cdempresaprovDataGridViewTextBoxColumn
            // 
            this.cdempresaprovDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaprovDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa_prov";
            this.cdempresaprovDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaprovDataGridViewTextBoxColumn.Name = "cdempresaprovDataGridViewTextBoxColumn";
            this.cdempresaprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaprovDataGridViewTextBoxColumn.Width = 85;
            // 
            // nmempresaprovDataGridViewTextBoxColumn
            // 
            this.nmempresaprovDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaprovDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa_prov";
            this.nmempresaprovDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaprovDataGridViewTextBoxColumn.Name = "nmempresaprovDataGridViewTextBoxColumn";
            this.nmempresaprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaprovDataGridViewTextBoxColumn.Width = 73;
            // 
            // cdprodutoprovDataGridViewTextBoxColumn
            // 
            this.cdprodutoprovDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoprovDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto_prov";
            this.cdprodutoprovDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cdprodutoprovDataGridViewTextBoxColumn.Name = "cdprodutoprovDataGridViewTextBoxColumn";
            this.cdprodutoprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoprovDataGridViewTextBoxColumn.Width = 81;
            // 
            // dsprodutoprovDataGridViewTextBoxColumn
            // 
            this.dsprodutoprovDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoprovDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto_prov";
            this.dsprodutoprovDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoprovDataGridViewTextBoxColumn.Name = "dsprodutoprovDataGridViewTextBoxColumn";
            this.dsprodutoprovDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoprovDataGridViewTextBoxColumn.Width = 69;
            // 
            // dsprovisaoDataGridViewTextBoxColumn
            // 
            this.dsprovisaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprovisaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_provisao";
            this.dsprovisaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.dsprovisaoDataGridViewTextBoxColumn.Name = "dsprovisaoDataGridViewTextBoxColumn";
            this.dsprovisaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprovisaoDataGridViewTextBoxColumn.Width = 80;
            // 
            // bsProvisao
            // 
            this.bsProvisao.DataSource = typeof(CamadaDados.Estoque.TList_Lan_Provisao_Estoque);
            this.bsProvisao.PositionChanged += new System.EventHandler(this.bsProvisao_PositionChanged);
            // 
            // bnProvisao
            // 
            this.bnProvisao.AddNewItem = null;
            this.bnProvisao.BindingSource = this.bsProvisao;
            this.bnProvisao.CountItem = this.bindingNavigatorCountItem;
            this.bnProvisao.CountItemFormat = "de {0}";
            this.bnProvisao.DeleteItem = null;
            this.bnProvisao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnProvisao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnProvisao.Location = new System.Drawing.Point(3, 421);
            this.bnProvisao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnProvisao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnProvisao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnProvisao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnProvisao.Name = "bnProvisao";
            this.bnProvisao.PositionItem = this.bindingNavigatorPositionItem;
            this.bnProvisao.Size = new System.Drawing.Size(994, 25);
            this.bnProvisao.TabIndex = 1;
            this.bnProvisao.Text = "bindingNavigator1";
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
            // tpMovEstoque
            // 
            this.tpMovEstoque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpMovEstoque.Controls.Add(this.gEstoque);
            this.tpMovEstoque.Controls.Add(this.bindingNavigator1);
            this.tpMovEstoque.Location = new System.Drawing.Point(4, 22);
            this.tpMovEstoque.Name = "tpMovEstoque";
            this.tpMovEstoque.Padding = new System.Windows.Forms.Padding(3);
            this.tpMovEstoque.Size = new System.Drawing.Size(1002, 451);
            this.tpMovEstoque.TabIndex = 1;
            this.tpMovEstoque.Text = "MOVIMENTAÇÃO ESTOQUE";
            this.tpMovEstoque.UseVisualStyleBackColor = true;
            // 
            // gEstoque
            // 
            this.gEstoque.AllowUserToAddRows = false;
            this.gEstoque.AllowUserToDeleteRows = false;
            this.gEstoque.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gEstoque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gEstoque.AutoGenerateColumns = false;
            this.gEstoque.BackgroundColor = System.Drawing.Color.LightGray;
            this.gEstoque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gEstoque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEstoque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlanctoestoqueDataGridViewTextBoxColumn,
            this.cdlocalDataGridViewTextBoxColumn,
            this.dslocalDataGridViewTextBoxColumn,
            this.dtlanctoSTRDataGridViewTextBoxColumn1,
            this.qtdentradaDataGridViewTextBoxColumn,
            this.qtdsaidaDataGridViewTextBoxColumn,
            this.vlunitarioDataGridViewTextBoxColumn,
            this.vlsubtotalDataGridViewTextBoxColumn,
            this.St_registro_String});
            this.gEstoque.DataSource = this.bsEstoque;
            this.gEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEstoque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gEstoque.Location = new System.Drawing.Point(3, 3);
            this.gEstoque.Name = "gEstoque";
            this.gEstoque.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gEstoque.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gEstoque.RowHeadersWidth = 23;
            this.gEstoque.Size = new System.Drawing.Size(994, 418);
            this.gEstoque.TabIndex = 0;
            this.gEstoque.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gEstoque_ColumnHeaderMouseClick);
            // 
            // idlanctoestoqueDataGridViewTextBoxColumn
            // 
            this.idlanctoestoqueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idlanctoestoqueDataGridViewTextBoxColumn.DataPropertyName = "Id_lanctoestoque";
            this.idlanctoestoqueDataGridViewTextBoxColumn.HeaderText = "Id. Estoque";
            this.idlanctoestoqueDataGridViewTextBoxColumn.Name = "idlanctoestoqueDataGridViewTextBoxColumn";
            this.idlanctoestoqueDataGridViewTextBoxColumn.ReadOnly = true;
            this.idlanctoestoqueDataGridViewTextBoxColumn.Width = 86;
            // 
            // cdlocalDataGridViewTextBoxColumn
            // 
            this.cdlocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdlocalDataGridViewTextBoxColumn.DataPropertyName = "Cd_local";
            this.cdlocalDataGridViewTextBoxColumn.HeaderText = "Cd. Local";
            this.cdlocalDataGridViewTextBoxColumn.Name = "cdlocalDataGridViewTextBoxColumn";
            this.cdlocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdlocalDataGridViewTextBoxColumn.Width = 77;
            // 
            // dslocalDataGridViewTextBoxColumn
            // 
            this.dslocalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dslocalDataGridViewTextBoxColumn.DataPropertyName = "Ds_local";
            this.dslocalDataGridViewTextBoxColumn.HeaderText = "Local Armazenagem";
            this.dslocalDataGridViewTextBoxColumn.Name = "dslocalDataGridViewTextBoxColumn";
            this.dslocalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dslocalDataGridViewTextBoxColumn.Width = 117;
            // 
            // dtlanctoSTRDataGridViewTextBoxColumn1
            // 
            this.dtlanctoSTRDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctoSTRDataGridViewTextBoxColumn1.DataPropertyName = "Dt_lancto_STR";
            this.dtlanctoSTRDataGridViewTextBoxColumn1.HeaderText = "Data";
            this.dtlanctoSTRDataGridViewTextBoxColumn1.Name = "dtlanctoSTRDataGridViewTextBoxColumn1";
            this.dtlanctoSTRDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dtlanctoSTRDataGridViewTextBoxColumn1.Width = 55;
            // 
            // qtdentradaDataGridViewTextBoxColumn
            // 
            this.qtdentradaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdentradaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_entrada";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = "0";
            this.qtdentradaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.qtdentradaDataGridViewTextBoxColumn.HeaderText = "Qtd. Entrada";
            this.qtdentradaDataGridViewTextBoxColumn.Name = "qtdentradaDataGridViewTextBoxColumn";
            this.qtdentradaDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdentradaDataGridViewTextBoxColumn.Width = 85;
            // 
            // qtdsaidaDataGridViewTextBoxColumn
            // 
            this.qtdsaidaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qtdsaidaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_saida";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N3";
            dataGridViewCellStyle12.NullValue = "0";
            this.qtdsaidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.qtdsaidaDataGridViewTextBoxColumn.HeaderText = "Qtd. Saida";
            this.qtdsaidaDataGridViewTextBoxColumn.Name = "qtdsaidaDataGridViewTextBoxColumn";
            this.qtdsaidaDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtdsaidaDataGridViewTextBoxColumn.Width = 76;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N5";
            dataGridViewCellStyle13.NullValue = "0";
            this.vlunitarioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl. Unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlunitarioDataGridViewTextBoxColumn.Width = 77;
            // 
            // vlsubtotalDataGridViewTextBoxColumn
            // 
            this.vlsubtotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotal";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = "0";
            this.vlsubtotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.vlsubtotalDataGridViewTextBoxColumn.HeaderText = "Vl. SubTotal";
            this.vlsubtotalDataGridViewTextBoxColumn.Name = "vlsubtotalDataGridViewTextBoxColumn";
            this.vlsubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlsubtotalDataGridViewTextBoxColumn.Width = 83;
            // 
            // St_registro_String
            // 
            this.St_registro_String.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_registro_String.DataPropertyName = "St_registro_String";
            this.St_registro_String.HeaderText = "Status";
            this.St_registro_String.Name = "St_registro_String";
            this.St_registro_String.ReadOnly = true;
            this.St_registro_String.Width = 62;
            // 
            // bsEstoque
            // 
            this.bsEstoque.DataMember = "Lan_Estoque";
            this.bsEstoque.DataSource = this.bsProvisao;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsEstoque;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigator1.CountItemFormat = "de {0}";
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
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 421);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigator1.Size = new System.Drawing.Size(994, 25);
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
            // TFConsultaProvisao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 592);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.KeyPreview = true;
            this.Name = "TFConsultaProvisao";
            this.ShowInTaskbar = false;
            this.Text = "Consulta Provisão Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFConsultaProvisao_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFConsultaProvisao_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConsultaProvisao_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpProvisao.ResumeLayout(false);
            this.tpProvisao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProvisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bnProvisao)).EndInit();
            this.bnProvisao.ResumeLayout(false);
            this.bnProvisao.PerformLayout();
            this.tpMovEstoque.ResumeLayout(false);
            this.tpMovEstoque.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEstoque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripButton BB_Imprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.TabControl tcCentral;
        private System.Windows.Forms.TabPage tpProvisao;
        private Componentes.DataGridDefault gProvisao;
        private System.Windows.Forms.BindingSource bsProvisao;
        private System.Windows.Forms.BindingNavigator bnProvisao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.TabPage tpMovEstoque;
        private Componentes.DataGridDefault gEstoque;
        private System.Windows.Forms.BindingSource bsEstoque;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private Componentes.EditDefault id_provisao;
        private System.Windows.Forms.Button BB_Empresa;
        private System.Windows.Forms.Label label13;
        private Componentes.EditDefault CD_Empresa;
        private Componentes.EditData dt_fin;
        private Componentes.EditData dt_ini;
        private Componentes.CheckBoxDefault st_provsaldo;
        private Componentes.EditDefault cd_produto;
        private System.Windows.Forms.Button BB_Produto;
        private System.Windows.Forms.ToolStripButton bb_baixar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlanctoestoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctoSTRDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdentradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdsaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn St_registro_String;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprovisaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tot_Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tot_Saida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo_Provisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn VL_Medio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoprovDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprovisaoDataGridViewTextBoxColumn;
    }
}