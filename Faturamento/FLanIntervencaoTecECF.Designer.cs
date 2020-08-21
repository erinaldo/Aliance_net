namespace Faturamento
{
    partial class TFLanIntervencaoTecECF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanIntervencaoTecECF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.BB_Buscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_intervencao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_equipamento = new System.Windows.Forms.Button();
            this.id_equipamento = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nr_ose = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.motivo_intervencao = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditData(this.components);
            this.dt_fin = new Componentes.EditData(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.idintervencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsequipamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlacumuladoGTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrcroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtintervencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stperdadadosboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.motivointervencaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoriafiscalantDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoriafiscalnovaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsIntervencao = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.BB_Buscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(752, 43);
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
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)\r\nAlterar";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(100, 40);
            this.BB_Excluir.Text = "(F5)\r\nExcluir";
            this.BB_Excluir.ToolTipText = "Cancelar Registro";
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
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(752, 451);
            this.tlpCentral.TabIndex = 4;
            // 
            // pFiltro
            // 
            this.pFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label6);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.motivo_intervencao);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.nr_ose);
            this.pFiltro.Controls.Add(this.bb_equipamento);
            this.pFiltro.Controls.Add(this.id_equipamento);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.id_intervencao);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(5, 5);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(742, 57);
            this.pFiltro.TabIndex = 0;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.dataGridDefault1);
            this.pDados.Controls.Add(this.bindingNavigator1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(5, 70);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(742, 376);
            this.pDados.TabIndex = 1;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idintervencaoDataGridViewTextBoxColumn,
            this.idequipamentoDataGridViewTextBoxColumn,
            this.dsequipamentoDataGridViewTextBoxColumn,
            this.nroseDataGridViewTextBoxColumn,
            this.vlacumuladoGTDataGridViewTextBoxColumn,
            this.nrcroDataGridViewTextBoxColumn,
            this.dtintervencaoDataGridViewTextBoxColumn,
            this.stperdadadosboolDataGridViewCheckBoxColumn,
            this.motivointervencaoDataGridViewTextBoxColumn,
            this.memoriafiscalantDataGridViewTextBoxColumn,
            this.memoriafiscalnovaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsIntervencao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(738, 347);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsIntervencao;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 347);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(738, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            // id_intervencao
            // 
            this.id_intervencao.BackColor = System.Drawing.SystemColors.Window;
            this.id_intervencao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_intervencao.Location = new System.Drawing.Point(94, 3);
            this.id_intervencao.Name = "id_intervencao";
            this.id_intervencao.NM_Alias = "";
            this.id_intervencao.NM_Campo = "";
            this.id_intervencao.NM_CampoBusca = "";
            this.id_intervencao.NM_Param = "";
            this.id_intervencao.QTD_Zero = 0;
            this.id_intervencao.Size = new System.Drawing.Size(53, 20);
            this.id_intervencao.ST_AutoInc = false;
            this.id_intervencao.ST_DisableAuto = false;
            this.id_intervencao.ST_Float = false;
            this.id_intervencao.ST_Gravar = false;
            this.id_intervencao.ST_Int = false;
            this.id_intervencao.ST_LimpaCampo = true;
            this.id_intervencao.ST_NotNull = false;
            this.id_intervencao.ST_PrimaryKey = false;
            this.id_intervencao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Intervenção:";
            // 
            // bb_equipamento
            // 
            this.bb_equipamento.Image = ((System.Drawing.Image)(resources.GetObject("bb_equipamento.Image")));
            this.bb_equipamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_equipamento.Location = new System.Drawing.Point(282, 3);
            this.bb_equipamento.Name = "bb_equipamento";
            this.bb_equipamento.Size = new System.Drawing.Size(28, 20);
            this.bb_equipamento.TabIndex = 2;
            this.bb_equipamento.UseVisualStyleBackColor = true;
            this.bb_equipamento.Click += new System.EventHandler(this.bb_equipamento_Click);
            // 
            // id_equipamento
            // 
            this.id_equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.id_equipamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_equipamento.Location = new System.Drawing.Point(231, 3);
            this.id_equipamento.Name = "id_equipamento";
            this.id_equipamento.NM_Alias = "";
            this.id_equipamento.NM_Campo = "id_equipamento";
            this.id_equipamento.NM_CampoBusca = "id_equipamento";
            this.id_equipamento.NM_Param = "@P_CD_EMPRESA";
            this.id_equipamento.QTD_Zero = 0;
            this.id_equipamento.Size = new System.Drawing.Size(48, 20);
            this.id_equipamento.ST_AutoInc = false;
            this.id_equipamento.ST_DisableAuto = false;
            this.id_equipamento.ST_Float = false;
            this.id_equipamento.ST_Gravar = true;
            this.id_equipamento.ST_Int = true;
            this.id_equipamento.ST_LimpaCampo = true;
            this.id_equipamento.ST_NotNull = false;
            this.id_equipamento.ST_PrimaryKey = false;
            this.id_equipamento.TabIndex = 1;
            this.id_equipamento.Leave += new System.EventHandler(this.id_equipamento_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Equipamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Nº OS:";
            // 
            // nr_ose
            // 
            this.nr_ose.BackColor = System.Drawing.SystemColors.Window;
            this.nr_ose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_ose.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_ose.Location = new System.Drawing.Point(362, 3);
            this.nr_ose.Name = "nr_ose";
            this.nr_ose.NM_Alias = "";
            this.nr_ose.NM_Campo = "";
            this.nr_ose.NM_CampoBusca = "";
            this.nr_ose.NM_Param = "";
            this.nr_ose.QTD_Zero = 0;
            this.nr_ose.Size = new System.Drawing.Size(105, 20);
            this.nr_ose.ST_AutoInc = false;
            this.nr_ose.ST_DisableAuto = false;
            this.nr_ose.ST_Float = false;
            this.nr_ose.ST_Gravar = false;
            this.nr_ose.ST_Int = false;
            this.nr_ose.ST_LimpaCampo = true;
            this.nr_ose.ST_NotNull = false;
            this.nr_ose.ST_PrimaryKey = false;
            this.nr_ose.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Motivo:";
            // 
            // motivo_intervencao
            // 
            this.motivo_intervencao.BackColor = System.Drawing.SystemColors.Window;
            this.motivo_intervencao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.motivo_intervencao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.motivo_intervencao.Location = new System.Drawing.Point(94, 32);
            this.motivo_intervencao.Name = "motivo_intervencao";
            this.motivo_intervencao.NM_Alias = "";
            this.motivo_intervencao.NM_Campo = "";
            this.motivo_intervencao.NM_CampoBusca = "";
            this.motivo_intervencao.NM_Param = "";
            this.motivo_intervencao.QTD_Zero = 0;
            this.motivo_intervencao.Size = new System.Drawing.Size(373, 20);
            this.motivo_intervencao.ST_AutoInc = false;
            this.motivo_intervencao.ST_DisableAuto = false;
            this.motivo_intervencao.ST_Float = false;
            this.motivo_intervencao.ST_Gravar = false;
            this.motivo_intervencao.ST_Int = false;
            this.motivo_intervencao.ST_LimpaCampo = true;
            this.motivo_intervencao.ST_NotNull = false;
            this.motivo_intervencao.ST_PrimaryKey = false;
            this.motivo_intervencao.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 62;
            this.label5.Text = "Dt. Ini.:";
            // 
            // dt_ini
            // 
            this.dt_ini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ini.Location = new System.Drawing.Point(519, 4);
            this.dt_ini.Mask = "00/00/0000";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Operador = "";
            this.dt_ini.Size = new System.Drawing.Size(74, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 5;
            // 
            // dt_fin
            // 
            this.dt_fin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_fin.Location = new System.Drawing.Point(519, 32);
            this.dt_fin.Mask = "00/00/0000";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Operador = "";
            this.dt_fin.Size = new System.Drawing.Size(74, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "Dt. Fin.:";
            // 
            // idintervencaoDataGridViewTextBoxColumn
            // 
            this.idintervencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idintervencaoDataGridViewTextBoxColumn.DataPropertyName = "Id_intervencao";
            this.idintervencaoDataGridViewTextBoxColumn.HeaderText = "Id. Intervenção";
            this.idintervencaoDataGridViewTextBoxColumn.Name = "idintervencaoDataGridViewTextBoxColumn";
            this.idintervencaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idintervencaoDataGridViewTextBoxColumn.Width = 96;
            // 
            // idequipamentoDataGridViewTextBoxColumn
            // 
            this.idequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Id_equipamento";
            this.idequipamentoDataGridViewTextBoxColumn.HeaderText = "Id. ECF";
            this.idequipamentoDataGridViewTextBoxColumn.Name = "idequipamentoDataGridViewTextBoxColumn";
            this.idequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idequipamentoDataGridViewTextBoxColumn.Width = 62;
            // 
            // dsequipamentoDataGridViewTextBoxColumn
            // 
            this.dsequipamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsequipamentoDataGridViewTextBoxColumn.DataPropertyName = "Ds_equipamento";
            this.dsequipamentoDataGridViewTextBoxColumn.HeaderText = "ECF";
            this.dsequipamentoDataGridViewTextBoxColumn.Name = "dsequipamentoDataGridViewTextBoxColumn";
            this.dsequipamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsequipamentoDataGridViewTextBoxColumn.Width = 52;
            // 
            // nroseDataGridViewTextBoxColumn
            // 
            this.nroseDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nroseDataGridViewTextBoxColumn.DataPropertyName = "Nr_ose";
            this.nroseDataGridViewTextBoxColumn.HeaderText = "Nº OS";
            this.nroseDataGridViewTextBoxColumn.Name = "nroseDataGridViewTextBoxColumn";
            this.nroseDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroseDataGridViewTextBoxColumn.Width = 58;
            // 
            // vlacumuladoGTDataGridViewTextBoxColumn
            // 
            this.vlacumuladoGTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlacumuladoGTDataGridViewTextBoxColumn.DataPropertyName = "Vl_acumulado_GT";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = "0";
            this.vlacumuladoGTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
            this.vlacumuladoGTDataGridViewTextBoxColumn.HeaderText = "Vl. Acumulado GT";
            this.vlacumuladoGTDataGridViewTextBoxColumn.Name = "vlacumuladoGTDataGridViewTextBoxColumn";
            this.vlacumuladoGTDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlacumuladoGTDataGridViewTextBoxColumn.Width = 108;
            // 
            // nrcroDataGridViewTextBoxColumn
            // 
            this.nrcroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrcroDataGridViewTextBoxColumn.DataPropertyName = "Nr_cro";
            this.nrcroDataGridViewTextBoxColumn.HeaderText = "Nº CRO";
            this.nrcroDataGridViewTextBoxColumn.Name = "nrcroDataGridViewTextBoxColumn";
            this.nrcroDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrcroDataGridViewTextBoxColumn.Width = 65;
            // 
            // dtintervencaoDataGridViewTextBoxColumn
            // 
            this.dtintervencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtintervencaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_intervencao";
            this.dtintervencaoDataGridViewTextBoxColumn.HeaderText = "Dt. Intervenção";
            this.dtintervencaoDataGridViewTextBoxColumn.Name = "dtintervencaoDataGridViewTextBoxColumn";
            this.dtintervencaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtintervencaoDataGridViewTextBoxColumn.Width = 97;
            // 
            // stperdadadosboolDataGridViewCheckBoxColumn
            // 
            this.stperdadadosboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stperdadadosboolDataGridViewCheckBoxColumn.DataPropertyName = "St_perdadadosbool";
            this.stperdadadosboolDataGridViewCheckBoxColumn.HeaderText = "Perda Dados";
            this.stperdadadosboolDataGridViewCheckBoxColumn.Name = "stperdadadosboolDataGridViewCheckBoxColumn";
            this.stperdadadosboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stperdadadosboolDataGridViewCheckBoxColumn.Width = 68;
            // 
            // motivointervencaoDataGridViewTextBoxColumn
            // 
            this.motivointervencaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.motivointervencaoDataGridViewTextBoxColumn.DataPropertyName = "Motivo_intervencao";
            this.motivointervencaoDataGridViewTextBoxColumn.HeaderText = "Motivo Intervenção";
            this.motivointervencaoDataGridViewTextBoxColumn.Name = "motivointervencaoDataGridViewTextBoxColumn";
            this.motivointervencaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.motivointervencaoDataGridViewTextBoxColumn.Width = 114;
            // 
            // memoriafiscalantDataGridViewTextBoxColumn
            // 
            this.memoriafiscalantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.memoriafiscalantDataGridViewTextBoxColumn.DataPropertyName = "Memoria_fiscal_ant";
            this.memoriafiscalantDataGridViewTextBoxColumn.HeaderText = "Memoria Fiscal Anterior";
            this.memoriafiscalantDataGridViewTextBoxColumn.Name = "memoriafiscalantDataGridViewTextBoxColumn";
            this.memoriafiscalantDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoriafiscalantDataGridViewTextBoxColumn.Width = 129;
            // 
            // memoriafiscalnovaDataGridViewTextBoxColumn
            // 
            this.memoriafiscalnovaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.memoriafiscalnovaDataGridViewTextBoxColumn.DataPropertyName = "Memoria_fiscal_nova";
            this.memoriafiscalnovaDataGridViewTextBoxColumn.HeaderText = "Memoria Fiscal Nova";
            this.memoriafiscalnovaDataGridViewTextBoxColumn.Name = "memoriafiscalnovaDataGridViewTextBoxColumn";
            this.memoriafiscalnovaDataGridViewTextBoxColumn.ReadOnly = true;
            this.memoriafiscalnovaDataGridViewTextBoxColumn.Width = 97;
            // 
            // bsIntervencao
            // 
            this.bsIntervencao.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_IntervencaoTec);
            // 
            // TFLanIntervencaoTecECF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 494);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFLanIntervencaoTecECF";
            this.ShowInTaskbar = false;
            this.Text = "Intervenção Tecnica ECF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFLanIntervencaoTecECF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanIntervencaoTecECF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsIntervencao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Novo;
        private System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton BB_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private Componentes.PanelDados pDados;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idintervencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsequipamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlacumuladoGTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrcroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtintervencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stperdadadosboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivointervencaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoriafiscalantDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoriafiscalnovaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsIntervencao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_intervencao;
        private System.Windows.Forms.Button bb_equipamento;
        private Componentes.EditDefault id_equipamento;
        private System.Windows.Forms.Label label2;
        private Componentes.EditData dt_fin;
        private System.Windows.Forms.Label label6;
        private Componentes.EditData dt_ini;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault motivo_intervencao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault nr_ose;
    }
}