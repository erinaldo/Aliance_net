namespace Consulta
{
    partial class TFCad_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Report));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDadosConsulta = new System.Windows.Forms.Panel();
            this.tableLayoutConsulta = new System.Windows.Forms.TableLayoutPanel();
            this.treeConsultaBusca = new System.Windows.Forms.TreeView();
            this.panelTit = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.treeConsulta = new System.Windows.Forms.TreeView();
            this.tl_BB = new System.Windows.Forms.TableLayoutPanel();
            this.BB_Add = new System.Windows.Forms.Label();
            this.BB_Remover = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.toolStripConsulta = new System.Windows.Forms.ToolStrip();
            this.tsBB_AddConsulta = new System.Windows.Forms.ToolStripButton();
            this.tsBB_EditarConsulta = new System.Windows.Forms.ToolStripButton();
            this.panelRel = new System.Windows.Forms.Panel();
            this.DS_Report = new Componentes.EditDefault(this.components);
            this.BS_Relatorio = new System.Windows.Forms.BindingSource(this.components);
            this.LB_DS_TabelaPreco = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbModulo = new Componentes.ComboBoxDefault(this.components);
            this.gb_DadosRel = new System.Windows.Forms.GroupBox();
            this.bbExcluir = new System.Windows.Forms.Button();
            this.bbEditReport = new System.Windows.Forms.Button();
            this.bb_Menu = new System.Windows.Forms.Button();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.pDadosConsulta.SuspendLayout();
            this.tableLayoutConsulta.SuspendLayout();
            this.panelTit.SuspendLayout();
            this.tl_BB.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.toolStripConsulta.SuspendLayout();
            this.panelRel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Relatorio)).BeginInit();
            this.gb_DadosRel.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(869, 43);
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.pDadosConsulta, 0, 0);
            this.tlpCentral.Controls.Add(this.panelRel, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(869, 314);
            this.tlpCentral.TabIndex = 13;
            // 
            // pDadosConsulta
            // 
            this.pDadosConsulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosConsulta.Controls.Add(this.tableLayoutConsulta);
            this.pDadosConsulta.Controls.Add(this.panelTitulo);
            this.pDadosConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDadosConsulta.Location = new System.Drawing.Point(438, 5);
            this.pDadosConsulta.Name = "pDadosConsulta";
            this.pDadosConsulta.Size = new System.Drawing.Size(426, 304);
            this.pDadosConsulta.TabIndex = 29;
            // 
            // tableLayoutConsulta
            // 
            this.tableLayoutConsulta.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutConsulta.ColumnCount = 3;
            this.tableLayoutConsulta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutConsulta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutConsulta.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutConsulta.Controls.Add(this.treeConsultaBusca, 0, 1);
            this.tableLayoutConsulta.Controls.Add(this.panelTit, 2, 0);
            this.tableLayoutConsulta.Controls.Add(this.treeConsulta, 2, 1);
            this.tableLayoutConsulta.Controls.Add(this.tl_BB, 1, 1);
            this.tableLayoutConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutConsulta.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutConsulta.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutConsulta.Name = "tableLayoutConsulta";
            this.tableLayoutConsulta.RowCount = 2;
            this.tableLayoutConsulta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutConsulta.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutConsulta.Size = new System.Drawing.Size(422, 275);
            this.tableLayoutConsulta.TabIndex = 1;
            // 
            // treeConsultaBusca
            // 
            this.treeConsultaBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeConsultaBusca.FullRowSelect = true;
            this.treeConsultaBusca.HideSelection = false;
            this.treeConsultaBusca.Location = new System.Drawing.Point(1, 22);
            this.treeConsultaBusca.Margin = new System.Windows.Forms.Padding(0);
            this.treeConsultaBusca.Name = "treeConsultaBusca";
            this.treeConsultaBusca.Size = new System.Drawing.Size(196, 252);
            this.treeConsultaBusca.TabIndex = 21;
            this.treeConsultaBusca.DoubleClick += new System.EventHandler(this.treeConsultaBusca_DoubleClick);
            // 
            // panelTit
            // 
            this.panelTit.Controls.Add(this.label3);
            this.panelTit.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTit.Location = new System.Drawing.Point(224, 1);
            this.panelTit.Margin = new System.Windows.Forms.Padding(0);
            this.panelTit.Name = "panelTit";
            this.panelTit.Size = new System.Drawing.Size(197, 20);
            this.panelTit.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Consultas selecionadas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeConsulta
            // 
            this.treeConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeConsulta.FullRowSelect = true;
            this.treeConsulta.HideSelection = false;
            this.treeConsulta.Location = new System.Drawing.Point(224, 22);
            this.treeConsulta.Margin = new System.Windows.Forms.Padding(0);
            this.treeConsulta.Name = "treeConsulta";
            this.treeConsulta.Size = new System.Drawing.Size(197, 252);
            this.treeConsulta.TabIndex = 22;
            // 
            // tl_BB
            // 
            this.tl_BB.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tl_BB.ColumnCount = 1;
            this.tl_BB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tl_BB.Controls.Add(this.BB_Add, 0, 1);
            this.tl_BB.Controls.Add(this.BB_Remover, 0, 2);
            this.tl_BB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tl_BB.Location = new System.Drawing.Point(198, 22);
            this.tl_BB.Margin = new System.Windows.Forms.Padding(0);
            this.tl_BB.Name = "tl_BB";
            this.tl_BB.RowCount = 4;
            this.tl_BB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tl_BB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl_BB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tl_BB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tl_BB.Size = new System.Drawing.Size(25, 252);
            this.tl_BB.TabIndex = 23;
            // 
            // BB_Add
            // 
            this.BB_Add.AutoSize = true;
            this.BB_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BB_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BB_Add.Image = ((System.Drawing.Image)(resources.GetObject("BB_Add.Image")));
            this.BB_Add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Add.Location = new System.Drawing.Point(2, 84);
            this.BB_Add.Margin = new System.Windows.Forms.Padding(0);
            this.BB_Add.Name = "BB_Add";
            this.BB_Add.Size = new System.Drawing.Size(21, 20);
            this.BB_Add.TabIndex = 0;
            this.BB_Add.Click += new System.EventHandler(this.BB_Add_Click);
            // 
            // BB_Remover
            // 
            this.BB_Remover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BB_Remover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BB_Remover.Image = ((System.Drawing.Image)(resources.GetObject("BB_Remover.Image")));
            this.BB_Remover.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Remover.Location = new System.Drawing.Point(2, 106);
            this.BB_Remover.Margin = new System.Windows.Forms.Padding(0);
            this.BB_Remover.Name = "BB_Remover";
            this.BB_Remover.Size = new System.Drawing.Size(21, 20);
            this.BB_Remover.TabIndex = 1;
            this.BB_Remover.Click += new System.EventHandler(this.BB_Remover_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.Controls.Add(this.toolStripConsulta);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(422, 25);
            this.panelTitulo.TabIndex = 0;
            // 
            // toolStripConsulta
            // 
            this.toolStripConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBB_AddConsulta,
            this.tsBB_EditarConsulta});
            this.toolStripConsulta.Location = new System.Drawing.Point(0, 0);
            this.toolStripConsulta.Name = "toolStripConsulta";
            this.toolStripConsulta.Size = new System.Drawing.Size(422, 25);
            this.toolStripConsulta.TabIndex = 1;
            this.toolStripConsulta.Text = "toolStrip1";
            // 
            // tsBB_AddConsulta
            // 
            this.tsBB_AddConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsBB_AddConsulta.Image")));
            this.tsBB_AddConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBB_AddConsulta.Name = "tsBB_AddConsulta";
            this.tsBB_AddConsulta.Size = new System.Drawing.Size(105, 22);
            this.tsBB_AddConsulta.Text = "Nova Consulta";
            this.tsBB_AddConsulta.ToolTipText = "Adicionar Nova consulta";
            this.tsBB_AddConsulta.Click += new System.EventHandler(this.tsBB_AddConsulta_Click);
            // 
            // tsBB_EditarConsulta
            // 
            this.tsBB_EditarConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsBB_EditarConsulta.Image")));
            this.tsBB_EditarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBB_EditarConsulta.Name = "tsBB_EditarConsulta";
            this.tsBB_EditarConsulta.Size = new System.Drawing.Size(107, 22);
            this.tsBB_EditarConsulta.Text = "Editar Consulta";
            this.tsBB_EditarConsulta.ToolTipText = "Editar Consulta";
            this.tsBB_EditarConsulta.Click += new System.EventHandler(this.tsBB_EditarConsulta_Click);
            // 
            // panelRel
            // 
            this.panelRel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRel.Controls.Add(this.DS_Report);
            this.panelRel.Controls.Add(this.LB_DS_TabelaPreco);
            this.panelRel.Controls.Add(this.label8);
            this.panelRel.Controls.Add(this.cbModulo);
            this.panelRel.Controls.Add(this.gb_DadosRel);
            this.panelRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRel.Location = new System.Drawing.Point(5, 5);
            this.panelRel.Name = "panelRel";
            this.panelRel.Size = new System.Drawing.Size(425, 304);
            this.panelRel.TabIndex = 28;
            // 
            // DS_Report
            // 
            this.DS_Report.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Report.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Report.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Report.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Relatorio, "DS_Report", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Report.Location = new System.Drawing.Point(61, 52);
            this.DS_Report.MaxLength = 255;
            this.DS_Report.Name = "DS_Report";
            this.DS_Report.NM_Alias = "";
            this.DS_Report.NM_Campo = "DS_Report";
            this.DS_Report.NM_CampoBusca = "DS_Report";
            this.DS_Report.NM_Param = "@P_DS_REPORT";
            this.DS_Report.QTD_Zero = 0;
            this.DS_Report.Size = new System.Drawing.Size(357, 20);
            this.DS_Report.ST_AutoInc = false;
            this.DS_Report.ST_DisableAuto = false;
            this.DS_Report.ST_Float = false;
            this.DS_Report.ST_Gravar = true;
            this.DS_Report.ST_Int = false;
            this.DS_Report.ST_LimpaCampo = true;
            this.DS_Report.ST_NotNull = true;
            this.DS_Report.ST_PrimaryKey = false;
            this.DS_Report.TabIndex = 17;
            this.DS_Report.TextOld = null;
            // 
            // BS_Relatorio
            // 
            this.BS_Relatorio.DataSource = typeof(CamadaDados.Consulta.Cadastro.TList_Cad_Report);
            // 
            // LB_DS_TabelaPreco
            // 
            this.LB_DS_TabelaPreco.AutoSize = true;
            this.LB_DS_TabelaPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.LB_DS_TabelaPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_TabelaPreco.Location = new System.Drawing.Point(17, 55);
            this.LB_DS_TabelaPreco.Name = "LB_DS_TabelaPreco";
            this.LB_DS_TabelaPreco.Size = new System.Drawing.Size(43, 13);
            this.LB_DS_TabelaPreco.TabIndex = 18;
            this.LB_DS_TabelaPreco.Text = "Nome:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(8, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Módulo:";
            // 
            // cbModulo
            // 
            this.cbModulo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.BS_Relatorio, "Modulo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModulo.FormattingEnabled = true;
            this.cbModulo.Location = new System.Drawing.Point(61, 28);
            this.cbModulo.Name = "cbModulo";
            this.cbModulo.NM_Alias = "";
            this.cbModulo.NM_Campo = "";
            this.cbModulo.NM_Param = "";
            this.cbModulo.Size = new System.Drawing.Size(173, 21);
            this.cbModulo.ST_Gravar = true;
            this.cbModulo.ST_LimparCampo = true;
            this.cbModulo.ST_NotNull = true;
            this.cbModulo.TabIndex = 16;
            // 
            // gb_DadosRel
            // 
            this.gb_DadosRel.Controls.Add(this.bbEditReport);
            this.gb_DadosRel.Controls.Add(this.bb_Menu);
            this.gb_DadosRel.Controls.Add(this.bbExcluir);
            this.gb_DadosRel.Location = new System.Drawing.Point(15, 85);
            this.gb_DadosRel.Name = "gb_DadosRel";
            this.gb_DadosRel.Size = new System.Drawing.Size(400, 89);
            this.gb_DadosRel.TabIndex = 26;
            this.gb_DadosRel.TabStop = false;
            this.gb_DadosRel.Text = "Relatórios";
            // 
            // bbExcluir
            // 
            this.bbExcluir.Image = ((System.Drawing.Image)(resources.GetObject("bbExcluir.Image")));
            this.bbExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bbExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbExcluir.Location = new System.Drawing.Point(57, 53);
            this.bbExcluir.Name = "bbExcluir";
            this.bbExcluir.Size = new System.Drawing.Size(286, 28);
            this.bbExcluir.TabIndex = 3;
            this.bbExcluir.Text = "Excluir Dados Relatórios";
            this.bbExcluir.UseVisualStyleBackColor = true;
            this.bbExcluir.Click += new System.EventHandler(this.bbExcluir_Click);
            // 
            // bbEditReport
            // 
            this.bbEditReport.Image = ((System.Drawing.Image)(resources.GetObject("bbEditReport.Image")));
            this.bbEditReport.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bbEditReport.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bbEditReport.Location = new System.Drawing.Point(57, 20);
            this.bbEditReport.Name = "bbEditReport";
            this.bbEditReport.Size = new System.Drawing.Size(130, 27);
            this.bbEditReport.TabIndex = 21;
            this.bbEditReport.Text = "Editar RDC (Ctrl+R)";
            this.bbEditReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bbEditReport.UseVisualStyleBackColor = true;
            this.bbEditReport.Click += new System.EventHandler(this.bbEditReport_Click);
            // 
            // bb_Menu
            // 
            this.bb_Menu.Image = ((System.Drawing.Image)(resources.GetObject("bb_Menu.Image")));
            this.bb_Menu.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bb_Menu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Menu.Location = new System.Drawing.Point(193, 20);
            this.bb_Menu.Name = "bb_Menu";
            this.bb_Menu.Size = new System.Drawing.Size(150, 27);
            this.bb_Menu.TabIndex = 24;
            this.bb_Menu.Text = "Adicionar Menu (Ctrl+M)";
            this.bb_Menu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bb_Menu.UseVisualStyleBackColor = true;
            this.bb_Menu.Click += new System.EventHandler(this.bb_Menu_Click);
            // 
            // TFCad_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 357);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCad_Report";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Relatorios";
            this.Load += new System.EventHandler(this.TFCad_Report_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCad_Report_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.pDadosConsulta.ResumeLayout(false);
            this.tableLayoutConsulta.ResumeLayout(false);
            this.panelTit.ResumeLayout(false);
            this.tl_BB.ResumeLayout(false);
            this.tl_BB.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.toolStripConsulta.ResumeLayout(false);
            this.toolStripConsulta.PerformLayout();
            this.panelRel.ResumeLayout(false);
            this.panelRel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Relatorio)).EndInit();
            this.gb_DadosRel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.Panel panelRel;
        private Componentes.EditDefault DS_Report;
        private System.Windows.Forms.Label LB_DS_TabelaPreco;
        private System.Windows.Forms.Label label8;
        private Componentes.ComboBoxDefault cbModulo;
        private System.Windows.Forms.GroupBox gb_DadosRel;
        private System.Windows.Forms.Button bbExcluir;
        private System.Windows.Forms.Button bbEditReport;
        private System.Windows.Forms.Button bb_Menu;
        private System.Windows.Forms.Panel pDadosConsulta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutConsulta;
        private System.Windows.Forms.TreeView treeConsultaBusca;
        private System.Windows.Forms.Panel panelTit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView treeConsulta;
        private System.Windows.Forms.TableLayoutPanel tl_BB;
        private System.Windows.Forms.Label BB_Add;
        private System.Windows.Forms.Label BB_Remover;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.BindingSource BS_Relatorio;
        private System.Windows.Forms.ToolStrip toolStripConsulta;
        private System.Windows.Forms.ToolStripButton tsBB_AddConsulta;
        private System.Windows.Forms.ToolStripButton tsBB_EditarConsulta;
    }
}