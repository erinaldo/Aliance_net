namespace Parametros.Diversos
{
    partial class TFCadTerminal_X_Protocolo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTerminal_X_Protocolo));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdterminalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsterminalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprotocoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprotocoloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsTerminal_X_Protocolo = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.DS_Terminal = new Componentes.EditDefault(this.components);
            this.CD_Terminal = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.CD_Protocolo = new Componentes.EditDefault(this.components);
            this.DS_Protocolo = new Componentes.EditDefault(this.components);
            this.BB_Terminal = new System.Windows.Forms.Button();
            this.BB_Protocolo = new System.Windows.Forms.Button();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerminal_X_Protocolo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.BB_Protocolo);
            this.pDados.Controls.Add(this.BB_Terminal);
            this.pDados.Controls.Add(this.DS_Protocolo);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.CD_Protocolo);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.DS_Terminal);
            this.pDados.Controls.Add(this.CD_Terminal);
            this.pDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDados.NM_ProcDeletar = "EXCLUI_DIV_TERMINAL_X_PROTOCOLO";
            this.pDados.NM_ProcGravar = "IA_DIV_TERMINAL_X_PROTOCOLO";
            this.pDados.Size = new System.Drawing.Size(580, 73);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(592, 273);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(584, 247);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdterminalDataGridViewTextBoxColumn,
            this.dsterminalDataGridViewTextBoxColumn,
            this.cdprotocoloDataGridViewTextBoxColumn,
            this.dsprotocoloDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bsTerminal_X_Protocolo;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gCadastro.DefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Location = new System.Drawing.Point(0, 73);
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gCadastro.RowHeadersWidth = 23;
            this.gCadastro.Size = new System.Drawing.Size(580, 145);
            this.gCadastro.TabIndex = 0;
            this.gCadastro.TabStop = false;
            // 
            // cdterminalDataGridViewTextBoxColumn
            // 
            this.cdterminalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdterminalDataGridViewTextBoxColumn.DataPropertyName = "Cd_terminal";
            this.cdterminalDataGridViewTextBoxColumn.HeaderText = "Cd. Terminal";
            this.cdterminalDataGridViewTextBoxColumn.Name = "cdterminalDataGridViewTextBoxColumn";
            this.cdterminalDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdterminalDataGridViewTextBoxColumn.Width = 91;
            // 
            // dsterminalDataGridViewTextBoxColumn
            // 
            this.dsterminalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsterminalDataGridViewTextBoxColumn.DataPropertyName = "Ds_terminal";
            this.dsterminalDataGridViewTextBoxColumn.HeaderText = "Terminal";
            this.dsterminalDataGridViewTextBoxColumn.Name = "dsterminalDataGridViewTextBoxColumn";
            this.dsterminalDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsterminalDataGridViewTextBoxColumn.Width = 72;
            // 
            // cdprotocoloDataGridViewTextBoxColumn
            // 
            this.cdprotocoloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprotocoloDataGridViewTextBoxColumn.DataPropertyName = "Cd_protocolo";
            this.cdprotocoloDataGridViewTextBoxColumn.HeaderText = "Cd. Protocolo";
            this.cdprotocoloDataGridViewTextBoxColumn.Name = "cdprotocoloDataGridViewTextBoxColumn";
            this.cdprotocoloDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprotocoloDataGridViewTextBoxColumn.Width = 96;
            // 
            // dsprotocoloDataGridViewTextBoxColumn
            // 
            this.dsprotocoloDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprotocoloDataGridViewTextBoxColumn.DataPropertyName = "Ds_protocolo";
            this.dsprotocoloDataGridViewTextBoxColumn.HeaderText = "Protocolo";
            this.dsprotocoloDataGridViewTextBoxColumn.Name = "dsprotocoloDataGridViewTextBoxColumn";
            this.dsprotocoloDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprotocoloDataGridViewTextBoxColumn.Width = 77;
            // 
            // bsTerminal_X_Protocolo
            // 
            this.bsTerminal_X_Protocolo.DataSource = typeof(CamadaDados.Diversos.TList_Terminal_X_Protocolo);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Terminal:";
            // 
            // DS_Terminal
            // 
            this.DS_Terminal.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Terminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Terminal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Terminal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerminal_X_Protocolo, "Ds_terminal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Terminal.Enabled = false;
            this.DS_Terminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Terminal.Location = new System.Drawing.Point(211, 10);
            this.DS_Terminal.Name = "DS_Terminal";
            this.DS_Terminal.NM_Alias = "b";
            this.DS_Terminal.NM_Campo = "DS_Terminal";
            this.DS_Terminal.NM_CampoBusca = "DS_Terminal";
            this.DS_Terminal.NM_Param = "@P_DS_PROTOCOLO";
            this.DS_Terminal.QTD_Zero = 0;
            this.DS_Terminal.ReadOnly = true;
            this.DS_Terminal.Size = new System.Drawing.Size(352, 20);
            this.DS_Terminal.ST_AutoInc = false;
            this.DS_Terminal.ST_DisableAuto = false;
            this.DS_Terminal.ST_Float = false;
            this.DS_Terminal.ST_Gravar = false;
            this.DS_Terminal.ST_Int = false;
            this.DS_Terminal.ST_LimpaCampo = true;
            this.DS_Terminal.ST_NotNull = true;
            this.DS_Terminal.ST_PrimaryKey = false;
            this.DS_Terminal.TabIndex = 2;
            this.DS_Terminal.TextOld = null;
            // 
            // CD_Terminal
            // 
            this.CD_Terminal.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Terminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Terminal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Terminal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerminal_X_Protocolo, "Cd_terminal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Terminal.Enabled = false;
            this.CD_Terminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Terminal.Location = new System.Drawing.Point(88, 10);
            this.CD_Terminal.MaxLength = 3;
            this.CD_Terminal.Name = "CD_Terminal";
            this.CD_Terminal.NM_Alias = "a";
            this.CD_Terminal.NM_Campo = "CD_Terminal";
            this.CD_Terminal.NM_CampoBusca = "CD_Terminal";
            this.CD_Terminal.NM_Param = "@P_CD_TERMINAL";
            this.CD_Terminal.QTD_Zero = 0;
            this.CD_Terminal.Size = new System.Drawing.Size(71, 20);
            this.CD_Terminal.ST_AutoInc = false;
            this.CD_Terminal.ST_DisableAuto = false;
            this.CD_Terminal.ST_Float = false;
            this.CD_Terminal.ST_Gravar = true;
            this.CD_Terminal.ST_Int = true;
            this.CD_Terminal.ST_LimpaCampo = true;
            this.CD_Terminal.ST_NotNull = true;
            this.CD_Terminal.ST_PrimaryKey = true;
            this.CD_Terminal.TabIndex = 0;
            this.CD_Terminal.TextOld = null;
            this.CD_Terminal.Leave += new System.EventHandler(this.CD_Terminal_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Protocolo:";
            // 
            // CD_Protocolo
            // 
            this.CD_Protocolo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Protocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Protocolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Protocolo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerminal_X_Protocolo, "Cd_protocolo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Protocolo.Enabled = false;
            this.CD_Protocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Protocolo.Location = new System.Drawing.Point(88, 36);
            this.CD_Protocolo.MaxLength = 6;
            this.CD_Protocolo.Name = "CD_Protocolo";
            this.CD_Protocolo.NM_Alias = "a";
            this.CD_Protocolo.NM_Campo = "cd_protocolo";
            this.CD_Protocolo.NM_CampoBusca = "cd_protocolo";
            this.CD_Protocolo.NM_Param = "@P_CD_PROTOCOLO";
            this.CD_Protocolo.QTD_Zero = 0;
            this.CD_Protocolo.Size = new System.Drawing.Size(71, 20);
            this.CD_Protocolo.ST_AutoInc = false;
            this.CD_Protocolo.ST_DisableAuto = false;
            this.CD_Protocolo.ST_Float = false;
            this.CD_Protocolo.ST_Gravar = true;
            this.CD_Protocolo.ST_Int = true;
            this.CD_Protocolo.ST_LimpaCampo = true;
            this.CD_Protocolo.ST_NotNull = true;
            this.CD_Protocolo.ST_PrimaryKey = true;
            this.CD_Protocolo.TabIndex = 3;
            this.CD_Protocolo.TextOld = null;
            this.CD_Protocolo.Leave += new System.EventHandler(this.CD_Protocolo_Leave);
            // 
            // DS_Protocolo
            // 
            this.DS_Protocolo.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Protocolo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Protocolo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Protocolo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTerminal_X_Protocolo, "Ds_protocolo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Protocolo.Enabled = false;
            this.DS_Protocolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Protocolo.Location = new System.Drawing.Point(211, 36);
            this.DS_Protocolo.Name = "DS_Protocolo";
            this.DS_Protocolo.NM_Alias = "c";
            this.DS_Protocolo.NM_Campo = "DS_PROTOCOLO";
            this.DS_Protocolo.NM_CampoBusca = "DS_PROTOCOLO";
            this.DS_Protocolo.NM_Param = "";
            this.DS_Protocolo.QTD_Zero = 0;
            this.DS_Protocolo.ReadOnly = true;
            this.DS_Protocolo.Size = new System.Drawing.Size(352, 20);
            this.DS_Protocolo.ST_AutoInc = false;
            this.DS_Protocolo.ST_DisableAuto = false;
            this.DS_Protocolo.ST_Float = false;
            this.DS_Protocolo.ST_Gravar = false;
            this.DS_Protocolo.ST_Int = false;
            this.DS_Protocolo.ST_LimpaCampo = true;
            this.DS_Protocolo.ST_NotNull = true;
            this.DS_Protocolo.ST_PrimaryKey = false;
            this.DS_Protocolo.TabIndex = 5;
            this.DS_Protocolo.TextOld = null;
            // 
            // BB_Terminal
            // 
            this.BB_Terminal.Enabled = false;
            this.BB_Terminal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Terminal.Image = ((System.Drawing.Image)(resources.GetObject("BB_Terminal.Image")));
            this.BB_Terminal.Location = new System.Drawing.Point(165, 10);
            this.BB_Terminal.Name = "BB_Terminal";
            this.BB_Terminal.Size = new System.Drawing.Size(35, 20);
            this.BB_Terminal.TabIndex = 1;
            this.BB_Terminal.UseVisualStyleBackColor = true;
            this.BB_Terminal.Click += new System.EventHandler(this.BB_terminal_Click);
            // 
            // BB_Protocolo
            // 
            this.BB_Protocolo.Enabled = false;
            this.BB_Protocolo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Protocolo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Protocolo.Image")));
            this.BB_Protocolo.Location = new System.Drawing.Point(165, 36);
            this.BB_Protocolo.Name = "BB_Protocolo";
            this.BB_Protocolo.Size = new System.Drawing.Size(35, 20);
            this.BB_Protocolo.TabIndex = 4;
            this.BB_Protocolo.UseVisualStyleBackColor = true;
            this.BB_Protocolo.Click += new System.EventHandler(this.BB_protocolo_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTerminal_X_Protocolo;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 218);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(580, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // TFCadTerminal_X_Protocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(592, 316);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTerminal_X_Protocolo";
            this.Text = "Cadastro Terminal X Protocolo";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTerminal_X_Protocolo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault DS_Terminal;
        private Componentes.EditDefault CD_Terminal;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault CD_Protocolo;
        private Componentes.EditDefault DS_Protocolo;
        public System.Windows.Forms.Button BB_Terminal;
        public System.Windows.Forms.Button BB_Protocolo;
        private System.Windows.Forms.BindingSource bsTerminal_X_Protocolo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdterminalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsterminalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprotocoloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprotocoloDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;

    }
}
