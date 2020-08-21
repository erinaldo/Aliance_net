namespace PostoCombustivel
{
    partial class TFEncerranteCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEncerranteCaixa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pBico = new Componentes.PanelDados(this.components);
            this.gBicoBomba = new Componentes.DataGridDefault(this.components);
            this.bsBicoBomba = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.st_gravarencerrante = new Componentes.CheckBoxDefault(this.components);
            this.bb_avancar = new System.Windows.Forms.Button();
            this.bb_voltar = new System.Windows.Forms.Button();
            this.diferenca_venda = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.volume_vendido = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vendas_calculada = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.encerrante_abertura = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.qtd_encerrante = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dslabelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume_afericao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afericao = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pBico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBicoBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBicoBomba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diferenca_venda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_vendido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendas_calculada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrante_abertura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_encerrante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afericao)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(974, 43);
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.36628F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.63372F));
            this.tlpCentral.Controls.Add(this.pBico, 0, 0);
            this.tlpCentral.Controls.Add(this.pDados, 1, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(974, 435);
            this.tlpCentral.TabIndex = 12;
            // 
            // pBico
            // 
            this.pBico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBico.Controls.Add(this.gBicoBomba);
            this.pBico.Controls.Add(this.bindingNavigator1);
            this.pBico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBico.Location = new System.Drawing.Point(4, 4);
            this.pBico.Name = "pBico";
            this.pBico.NM_ProcDeletar = "";
            this.pBico.NM_ProcGravar = "";
            this.pBico.Size = new System.Drawing.Size(686, 427);
            this.pBico.TabIndex = 0;
            // 
            // gBicoBomba
            // 
            this.gBicoBomba.AllowUserToAddRows = false;
            this.gBicoBomba.AllowUserToDeleteRows = false;
            this.gBicoBomba.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBicoBomba.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBicoBomba.AutoGenerateColumns = false;
            this.gBicoBomba.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBicoBomba.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBicoBomba.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBicoBomba.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBicoBomba.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBicoBomba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dslabelDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Volume_afericao,
            this.dataGridViewTextBoxColumn4,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn});
            this.gBicoBomba.DataSource = this.bsBicoBomba;
            this.gBicoBomba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBicoBomba.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBicoBomba.Location = new System.Drawing.Point(0, 0);
            this.gBicoBomba.MultiSelect = false;
            this.gBicoBomba.Name = "gBicoBomba";
            this.gBicoBomba.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBicoBomba.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gBicoBomba.RowHeadersWidth = 23;
            this.gBicoBomba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gBicoBomba.Size = new System.Drawing.Size(684, 400);
            this.gBicoBomba.TabIndex = 0;
            // 
            // bsBicoBomba
            // 
            this.bsBicoBomba.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_BicoBomba);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsBicoBomba;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 400);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(684, 25);
            this.bindingNavigator1.TabIndex = 1;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.afericao);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.st_gravarencerrante);
            this.pDados.Controls.Add(this.bb_avancar);
            this.pDados.Controls.Add(this.bb_voltar);
            this.pDados.Controls.Add(this.diferenca_venda);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.volume_vendido);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vendas_calculada);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.encerrante_abertura);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.qtd_encerrante);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(697, 4);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(273, 427);
            this.pDados.TabIndex = 1;
            // 
            // st_gravarencerrante
            // 
            this.st_gravarencerrante.AutoSize = true;
            this.st_gravarencerrante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_gravarencerrante.ForeColor = System.Drawing.Color.Blue;
            this.st_gravarencerrante.Location = new System.Drawing.Point(41, 375);
            this.st_gravarencerrante.Name = "st_gravarencerrante";
            this.st_gravarencerrante.NM_Alias = "";
            this.st_gravarencerrante.NM_Campo = "";
            this.st_gravarencerrante.NM_Param = "";
            this.st_gravarencerrante.Size = new System.Drawing.Size(165, 17);
            this.st_gravarencerrante.ST_Gravar = false;
            this.st_gravarencerrante.ST_LimparCampo = true;
            this.st_gravarencerrante.ST_NotNull = false;
            this.st_gravarencerrante.TabIndex = 12;
            this.st_gravarencerrante.Text = "Gravar Encerrantes LMC";
            this.st_gravarencerrante.UseVisualStyleBackColor = true;
            this.st_gravarencerrante.Vl_False = "";
            this.st_gravarencerrante.Vl_True = "";
            // 
            // bb_avancar
            // 
            this.bb_avancar.Location = new System.Drawing.Point(138, 346);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(75, 23);
            this.bb_avancar.TabIndex = 11;
            this.bb_avancar.Text = "Avançar >>";
            this.bb_avancar.UseVisualStyleBackColor = true;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // bb_voltar
            // 
            this.bb_voltar.Location = new System.Drawing.Point(41, 346);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(75, 23);
            this.bb_voltar.TabIndex = 10;
            this.bb_voltar.Text = "<< Voltar";
            this.bb_voltar.UseVisualStyleBackColor = true;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // diferenca_venda
            // 
            this.diferenca_venda.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Diferenca_venda", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.diferenca_venda.DecimalPlaces = 3;
            this.diferenca_venda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diferenca_venda.ForeColor = System.Drawing.Color.Red;
            this.diferenca_venda.Location = new System.Drawing.Point(41, 314);
            this.diferenca_venda.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.diferenca_venda.Minimum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            -2147483648});
            this.diferenca_venda.Name = "diferenca_venda";
            this.diferenca_venda.NM_Alias = "";
            this.diferenca_venda.NM_Campo = "";
            this.diferenca_venda.NM_Param = "";
            this.diferenca_venda.Operador = "";
            this.diferenca_venda.ReadOnly = true;
            this.diferenca_venda.Size = new System.Drawing.Size(172, 26);
            this.diferenca_venda.ST_AutoInc = false;
            this.diferenca_venda.ST_DisableAuto = false;
            this.diferenca_venda.ST_Gravar = false;
            this.diferenca_venda.ST_LimparCampo = true;
            this.diferenca_venda.ST_NotNull = false;
            this.diferenca_venda.ST_PrimaryKey = false;
            this.diferenca_venda.TabIndex = 9;
            this.diferenca_venda.TabStop = false;
            this.diferenca_venda.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(37, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Diferença Venda";
            // 
            // volume_vendido
            // 
            this.volume_vendido.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Volume_vendido", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volume_vendido.DecimalPlaces = 3;
            this.volume_vendido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume_vendido.Location = new System.Drawing.Point(41, 212);
            this.volume_vendido.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volume_vendido.Name = "volume_vendido";
            this.volume_vendido.NM_Alias = "";
            this.volume_vendido.NM_Campo = "";
            this.volume_vendido.NM_Param = "";
            this.volume_vendido.Operador = "";
            this.volume_vendido.ReadOnly = true;
            this.volume_vendido.Size = new System.Drawing.Size(172, 26);
            this.volume_vendido.ST_AutoInc = false;
            this.volume_vendido.ST_DisableAuto = false;
            this.volume_vendido.ST_Gravar = false;
            this.volume_vendido.ST_LimparCampo = true;
            this.volume_vendido.ST_NotNull = false;
            this.volume_vendido.ST_PrimaryKey = false;
            this.volume_vendido.TabIndex = 7;
            this.volume_vendido.TabStop = false;
            this.volume_vendido.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Volume Vendido";
            // 
            // vendas_calculada
            // 
            this.vendas_calculada.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Vendas_calculada", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vendas_calculada.DecimalPlaces = 3;
            this.vendas_calculada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendas_calculada.Location = new System.Drawing.Point(41, 160);
            this.vendas_calculada.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vendas_calculada.Name = "vendas_calculada";
            this.vendas_calculada.NM_Alias = "";
            this.vendas_calculada.NM_Campo = "";
            this.vendas_calculada.NM_Param = "";
            this.vendas_calculada.Operador = "";
            this.vendas_calculada.ReadOnly = true;
            this.vendas_calculada.Size = new System.Drawing.Size(172, 26);
            this.vendas_calculada.ST_AutoInc = false;
            this.vendas_calculada.ST_DisableAuto = false;
            this.vendas_calculada.ST_Gravar = false;
            this.vendas_calculada.ST_LimparCampo = true;
            this.vendas_calculada.ST_NotNull = false;
            this.vendas_calculada.ST_PrimaryKey = false;
            this.vendas_calculada.TabIndex = 5;
            this.vendas_calculada.TabStop = false;
            this.vendas_calculada.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vendas Calculada";
            // 
            // encerrante_abertura
            // 
            this.encerrante_abertura.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Encerrante_abertura", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.encerrante_abertura.DecimalPlaces = 3;
            this.encerrante_abertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encerrante_abertura.Location = new System.Drawing.Point(41, 108);
            this.encerrante_abertura.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.encerrante_abertura.Name = "encerrante_abertura";
            this.encerrante_abertura.NM_Alias = "";
            this.encerrante_abertura.NM_Campo = "";
            this.encerrante_abertura.NM_Param = "";
            this.encerrante_abertura.Operador = "";
            this.encerrante_abertura.ReadOnly = true;
            this.encerrante_abertura.Size = new System.Drawing.Size(172, 26);
            this.encerrante_abertura.ST_AutoInc = false;
            this.encerrante_abertura.ST_DisableAuto = false;
            this.encerrante_abertura.ST_Gravar = false;
            this.encerrante_abertura.ST_LimparCampo = true;
            this.encerrante_abertura.ST_NotNull = false;
            this.encerrante_abertura.ST_PrimaryKey = false;
            this.encerrante_abertura.TabIndex = 3;
            this.encerrante_abertura.TabStop = false;
            this.encerrante_abertura.ThousandsSeparator = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Encerrante Anterior";
            // 
            // qtd_encerrante
            // 
            this.qtd_encerrante.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Qtd_encerrante", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_encerrante.DecimalPlaces = 3;
            this.qtd_encerrante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtd_encerrante.Location = new System.Drawing.Point(41, 56);
            this.qtd_encerrante.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_encerrante.Name = "qtd_encerrante";
            this.qtd_encerrante.NM_Alias = "";
            this.qtd_encerrante.NM_Campo = "";
            this.qtd_encerrante.NM_Param = "";
            this.qtd_encerrante.Operador = "";
            this.qtd_encerrante.Size = new System.Drawing.Size(172, 26);
            this.qtd_encerrante.ST_AutoInc = false;
            this.qtd_encerrante.ST_DisableAuto = false;
            this.qtd_encerrante.ST_Gravar = false;
            this.qtd_encerrante.ST_LimparCampo = true;
            this.qtd_encerrante.ST_NotNull = false;
            this.qtd_encerrante.ST_PrimaryKey = false;
            this.qtd_encerrante.TabIndex = 1;
            this.qtd_encerrante.ThousandsSeparator = true;
            this.qtd_encerrante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.qtd_encerrante_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encerrante Atual";
            // 
            // dslabelDataGridViewTextBoxColumn
            // 
            this.dslabelDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dslabelDataGridViewTextBoxColumn.DataPropertyName = "Ds_label";
            this.dslabelDataGridViewTextBoxColumn.HeaderText = "Nº Bico";
            this.dslabelDataGridViewTextBoxColumn.Name = "dslabelDataGridViewTextBoxColumn";
            this.dslabelDataGridViewTextBoxColumn.ReadOnly = true;
            this.dslabelDataGridViewTextBoxColumn.Width = 68;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Combustivel";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 89;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Encerrante_abertura";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Abertura";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 72;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Qtd_encerrante";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Encerrante Atual";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 102;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Volume_vendido";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = "0";
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Volume Vendido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Volume_afericao
            // 
            this.Volume_afericao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Volume_afericao.DataPropertyName = "Volume_afericao";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = "0";
            this.Volume_afericao.DefaultCellStyle = dataGridViewCellStyle6;
            this.Volume_afericao.HeaderText = "Aferição";
            this.Volume_afericao.Name = "Volume_afericao";
            this.Volume_afericao.ReadOnly = true;
            this.Volume_afericao.Width = 71;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Diferenca_venda";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.Format = "N3";
            dataGridViewCellStyle7.NullValue = "0";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn4.HeaderText = "Diferença Venda";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 103;
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
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd. Combustivel";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 99;
            // 
            // afericao
            // 
            this.afericao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsBicoBomba, "Volume_afericao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.afericao.DecimalPlaces = 3;
            this.afericao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afericao.Location = new System.Drawing.Point(41, 262);
            this.afericao.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.afericao.Name = "afericao";
            this.afericao.NM_Alias = "";
            this.afericao.NM_Campo = "";
            this.afericao.NM_Param = "";
            this.afericao.Operador = "";
            this.afericao.ReadOnly = true;
            this.afericao.Size = new System.Drawing.Size(172, 26);
            this.afericao.ST_AutoInc = false;
            this.afericao.ST_DisableAuto = false;
            this.afericao.ST_Gravar = false;
            this.afericao.ST_LimparCampo = true;
            this.afericao.ST_NotNull = false;
            this.afericao.ST_PrimaryKey = false;
            this.afericao.TabIndex = 14;
            this.afericao.TabStop = false;
            this.afericao.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Volume Aferição";
            // 
            // TFEncerranteCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 478);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEncerranteCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encerrantes Caixa";
            this.Load += new System.EventHandler(this.TFEncerranteCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEncerranteCaixa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pBico.ResumeLayout(false);
            this.pBico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBicoBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBicoBomba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diferenca_venda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_vendido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendas_calculada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encerrante_abertura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_encerrante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afericao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pBico;
        private Componentes.DataGridDefault gBicoBomba;
        private System.Windows.Forms.BindingSource bsBicoBomba;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat encerrante_abertura;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat qtd_encerrante;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat vendas_calculada;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat diferenca_venda;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat volume_vendido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_avancar;
        private System.Windows.Forms.Button bb_voltar;
        private Componentes.CheckBoxDefault st_gravarencerrante;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslabelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume_afericao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private Componentes.EditFloat afericao;
        private System.Windows.Forms.Label label6;
    }
}