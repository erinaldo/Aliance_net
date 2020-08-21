namespace Proc_Commoditties
{
    partial class TFListaAniversariante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaAniversariante));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_gerararquivo = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            this.st_enviados = new Componentes.CheckBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTpData = new Componentes.ComboBoxDefault(this.components);
            this.btn_Clifor_Busca = new System.Windows.Forms.Button();
            this.NM_Clifor_Busca = new Componentes.EditDefault(this.components);
            this.label36 = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bsAniversariante = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.cbTodos = new Componentes.CheckBoxDefault(this.components);
            this.gAniversariante = new Componentes.DataGridDefault(this.components);
            this.stenviaremailDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pessoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_evento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiporegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmclienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_enviadobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAniversariante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAniversariante)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_gerararquivo,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(1025, 33);
            this.barraMenu.TabIndex = 9;
            // 
            // bb_gerararquivo
            // 
            this.bb_gerararquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gerararquivo.ForeColor = System.Drawing.Color.Green;
            this.bb_gerararquivo.Image = ((System.Drawing.Image)(resources.GetObject("bb_gerararquivo.Image")));
            this.bb_gerararquivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gerararquivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gerararquivo.Name = "bb_gerararquivo";
            this.bb_gerararquivo.Size = new System.Drawing.Size(63, 30);
            this.bb_gerararquivo.Text = "Enviar\r\nEmail";
            this.bb_gerararquivo.ToolTipText = "Enviar Email";
            this.bb_gerararquivo.Click += new System.EventHandler(this.bb_gerararquivo_Click);
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
            this.BB_Fechar.Size = new System.Drawing.Size(54, 30);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.47368F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.52631F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1025, 457);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.bb_buscar);
            this.panelDados1.Controls.Add(this.st_enviados);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.cbxTpData);
            this.panelDados1.Controls.Add(this.btn_Clifor_Busca);
            this.panelDados1.Controls.Add(this.NM_Clifor_Busca);
            this.panelDados1.Controls.Add(this.label36);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 4);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1017, 59);
            this.panelDados1.TabIndex = 0;
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(508, 3);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(126, 46);
            this.bb_buscar.TabIndex = 68;
            this.bb_buscar.Text = "(F7) Buscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // st_enviados
            // 
            this.st_enviados.AutoSize = true;
            this.st_enviados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_enviados.Location = new System.Drawing.Point(292, 32);
            this.st_enviados.Name = "st_enviados";
            this.st_enviados.NM_Alias = "";
            this.st_enviados.NM_Campo = "";
            this.st_enviados.NM_Param = "";
            this.st_enviados.Size = new System.Drawing.Size(210, 17);
            this.st_enviados.ST_Gravar = false;
            this.st_enviados.ST_LimparCampo = true;
            this.st_enviados.ST_NotNull = false;
            this.st_enviados.TabIndex = 67;
            this.st_enviados.Text = "Buscar somente emails enviados";
            this.st_enviados.UseVisualStyleBackColor = true;
            this.st_enviados.Vl_False = "";
            this.st_enviados.Vl_True = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Tipo de Data:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxTpData
            // 
            this.cbxTpData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTpData.FormattingEnabled = true;
            this.cbxTpData.Location = new System.Drawing.Point(90, 30);
            this.cbxTpData.Name = "cbxTpData";
            this.cbxTpData.NM_Alias = "";
            this.cbxTpData.NM_Campo = "";
            this.cbxTpData.NM_Param = "";
            this.cbxTpData.Size = new System.Drawing.Size(196, 21);
            this.cbxTpData.ST_Gravar = false;
            this.cbxTpData.ST_LimparCampo = true;
            this.cbxTpData.ST_NotNull = false;
            this.cbxTpData.TabIndex = 65;
            // 
            // btn_Clifor_Busca
            // 
            this.btn_Clifor_Busca.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clifor_Busca.Image")));
            this.btn_Clifor_Busca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Clifor_Busca.Location = new System.Drawing.Point(474, 5);
            this.btn_Clifor_Busca.Name = "btn_Clifor_Busca";
            this.btn_Clifor_Busca.Size = new System.Drawing.Size(28, 19);
            this.btn_Clifor_Busca.TabIndex = 61;
            this.btn_Clifor_Busca.UseVisualStyleBackColor = true;
            this.btn_Clifor_Busca.Click += new System.EventHandler(this.btn_Clifor_Busca_Click);
            // 
            // NM_Clifor_Busca
            // 
            this.NM_Clifor_Busca.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Clifor_Busca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Clifor_Busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Clifor_Busca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Clifor_Busca.Location = new System.Drawing.Point(90, 4);
            this.NM_Clifor_Busca.Name = "NM_Clifor_Busca";
            this.NM_Clifor_Busca.NM_Alias = "";
            this.NM_Clifor_Busca.NM_Campo = "NM_Clifor";
            this.NM_Clifor_Busca.NM_CampoBusca = "NM_Clifor";
            this.NM_Clifor_Busca.NM_Param = "";
            this.NM_Clifor_Busca.QTD_Zero = 0;
            this.NM_Clifor_Busca.Size = new System.Drawing.Size(378, 20);
            this.NM_Clifor_Busca.ST_AutoInc = false;
            this.NM_Clifor_Busca.ST_DisableAuto = false;
            this.NM_Clifor_Busca.ST_Float = false;
            this.NM_Clifor_Busca.ST_Gravar = true;
            this.NM_Clifor_Busca.ST_Int = true;
            this.NM_Clifor_Busca.ST_LimpaCampo = true;
            this.NM_Clifor_Busca.ST_NotNull = false;
            this.NM_Clifor_Busca.ST_PrimaryKey = false;
            this.NM_Clifor_Busca.TabIndex = 60;
            this.NM_Clifor_Busca.TextOld = null;
            this.NM_Clifor_Busca.Leave += new System.EventHandler(this.CD_Clifor_Busca_Leave);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(49, 7);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(42, 13);
            this.label36.TabIndex = 62;
            this.label36.Text = "Cliente:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Controls.Add(this.cbTodos);
            this.panelDados2.Controls.Add(this.gAniversariante);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(4, 70);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1017, 383);
            this.panelDados2.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsAniversariante;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 358);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1017, 25);
            this.bindingNavigator1.TabIndex = 11;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bsAniversariante
            // 
            this.bsAniversariante.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_Aniversariante);
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
            // cbTodos
            // 
            this.cbTodos.Location = new System.Drawing.Point(5, 4);
            this.cbTodos.Name = "cbTodos";
            this.cbTodos.NM_Alias = "";
            this.cbTodos.NM_Campo = "";
            this.cbTodos.NM_Param = "";
            this.cbTodos.Size = new System.Drawing.Size(15, 14);
            this.cbTodos.ST_Gravar = false;
            this.cbTodos.ST_LimparCampo = true;
            this.cbTodos.ST_NotNull = false;
            this.cbTodos.TabIndex = 13;
            this.cbTodos.UseVisualStyleBackColor = true;
            this.cbTodos.Vl_False = "";
            this.cbTodos.Vl_True = "";
            this.cbTodos.Click += new System.EventHandler(this.cbTodos_Click);
            // 
            // gAniversariante
            // 
            this.gAniversariante.AllowUserToAddRows = false;
            this.gAniversariante.AllowUserToDeleteRows = false;
            this.gAniversariante.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAniversariante.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gAniversariante.AutoGenerateColumns = false;
            this.gAniversariante.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAniversariante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAniversariante.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAniversariante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gAniversariante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAniversariante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stenviaremailDataGridViewCheckBoxColumn,
            this.Pessoa,
            this.Tipo_Data,
            this.emailDataGridViewTextBoxColumn,
            this.Dt_evento,
            this.tiporegistroDataGridViewTextBoxColumn,
            this.nmclienteDataGridViewTextBoxColumn,
            this.St_enviadobool});
            this.gAniversariante.DataSource = this.bsAniversariante;
            this.gAniversariante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAniversariante.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAniversariante.Location = new System.Drawing.Point(0, 0);
            this.gAniversariante.Name = "gAniversariante";
            this.gAniversariante.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAniversariante.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gAniversariante.RowHeadersWidth = 23;
            this.gAniversariante.Size = new System.Drawing.Size(1017, 383);
            this.gAniversariante.TabIndex = 0;
            this.gAniversariante.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gAniversariante_CellClick);
            // 
            // stenviaremailDataGridViewCheckBoxColumn
            // 
            this.stenviaremailDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stenviaremailDataGridViewCheckBoxColumn.DataPropertyName = "St_enviaremail";
            this.stenviaremailDataGridViewCheckBoxColumn.HeaderText = "Enviar Email";
            this.stenviaremailDataGridViewCheckBoxColumn.Name = "stenviaremailDataGridViewCheckBoxColumn";
            this.stenviaremailDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stenviaremailDataGridViewCheckBoxColumn.Width = 71;
            // 
            // Pessoa
            // 
            this.Pessoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pessoa.DataPropertyName = "Pessoa";
            this.Pessoa.HeaderText = "Pessoa";
            this.Pessoa.Name = "Pessoa";
            this.Pessoa.ReadOnly = true;
            this.Pessoa.Width = 67;
            // 
            // Tipo_Data
            // 
            this.Tipo_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_Data.DataPropertyName = "Tipo_Data";
            this.Tipo_Data.HeaderText = "Tipo Data";
            this.Tipo_Data.Name = "Tipo_Data";
            this.Tipo_Data.ReadOnly = true;
            this.Tipo_Data.Width = 79;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 57;
            // 
            // Dt_evento
            // 
            this.Dt_evento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_evento.DataPropertyName = "Dt_evento";
            this.Dt_evento.HeaderText = "Data";
            this.Dt_evento.Name = "Dt_evento";
            this.Dt_evento.ReadOnly = true;
            this.Dt_evento.Width = 55;
            // 
            // tiporegistroDataGridViewTextBoxColumn
            // 
            this.tiporegistroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tiporegistroDataGridViewTextBoxColumn.DataPropertyName = "Tipo_registro";
            this.tiporegistroDataGridViewTextBoxColumn.HeaderText = "Tipo Pessoa";
            this.tiporegistroDataGridViewTextBoxColumn.Name = "tiporegistroDataGridViewTextBoxColumn";
            this.tiporegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.tiporegistroDataGridViewTextBoxColumn.Width = 91;
            // 
            // nmclienteDataGridViewTextBoxColumn
            // 
            this.nmclienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmclienteDataGridViewTextBoxColumn.DataPropertyName = "Nm_cliente";
            this.nmclienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nmclienteDataGridViewTextBoxColumn.Name = "nmclienteDataGridViewTextBoxColumn";
            this.nmclienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmclienteDataGridViewTextBoxColumn.Width = 64;
            // 
            // St_enviadobool
            // 
            this.St_enviadobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_enviadobool.DataPropertyName = "St_enviadobool";
            this.St_enviadobool.HeaderText = "Enviado";
            this.St_enviadobool.Name = "St_enviadobool";
            this.St_enviadobool.ReadOnly = true;
            this.St_enviadobool.Width = 52;
            // 
            // TFListaAniversariante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 490);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaAniversariante";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Aniversariantes";
            this.Load += new System.EventHandler(this.TFListaAniversariante_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaAniversariante_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAniversariante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAniversariante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gAniversariante;
        private System.Windows.Forms.BindingSource bsAniversariante;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gerararquivo;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.CheckBoxDefault cbTodos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stenviaremailDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pessoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_evento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiporegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmclienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_enviadobool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button btn_Clifor_Busca;
        private Componentes.EditDefault NM_Clifor_Busca;
        private System.Windows.Forms.Label label36;
        private Componentes.ComboBoxDefault cbxTpData;
        private System.Windows.Forms.Label label2;
        private Componentes.CheckBoxDefault st_enviados;
        private System.Windows.Forms.Button bb_buscar;
    }
}