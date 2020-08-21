namespace PostoCombustivel.Cadastros
{
    partial class TFCadTanque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTanque));
            this.gTanque = new Componentes.DataGridDefault(this.components);
            this.bsTanque = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_tanque = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.qtd_armazenagem = new Componentes.EditFloat(this.components);
            this.ds_prod = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cd_prod = new Componentes.EditDefault(this.components);
            this.sigla_unidade = new Componentes.EditDefault(this.components);
            this.st_registro = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblDtDesativacao = new System.Windows.Forms.Label();
            this.dt_desativacao = new Componentes.EditData(this.components);
            this.dt_ativacao = new Componentes.EditData(this.components);
            this.lblAtivacao = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtanquestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdlocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dslocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ds_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacidadetanque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sg_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDt_ativacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDt_desativacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTanque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_armazenagem)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.dt_ativacao);
            this.pDados.Controls.Add(this.lblAtivacao);
            this.pDados.Controls.Add(this.dt_desativacao);
            this.pDados.Controls.Add(this.lblDtDesativacao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.st_registro);
            this.pDados.Controls.Add(this.sigla_unidade);
            this.pDados.Controls.Add(this.ds_prod);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.cd_prod);
            this.pDados.Controls.Add(this.qtd_armazenagem);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_tanque);
            this.pDados.Size = new System.Drawing.Size(659, 134);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gTanque);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTanque, 0);
            // 
            // gTanque
            // 
            this.gTanque.AllowUserToAddRows = false;
            this.gTanque.AllowUserToDeleteRows = false;
            this.gTanque.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTanque.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTanque.AutoGenerateColumns = false;
            this.gTanque.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTanque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTanque.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTanque.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTanque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTanque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.idtanquestrDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.cdlocalDataGridViewTextBoxColumn,
            this.dslocalDataGridViewTextBoxColumn,
            this.Cd_produto,
            this.Ds_produto,
            this.Capacidadetanque,
            this.Sg_produto,
            this.pDt_ativacao,
            this.pDt_desativacao});
            this.gTanque.DataSource = this.bsTanque;
            this.gTanque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTanque.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTanque.Location = new System.Drawing.Point(0, 134);
            this.gTanque.Name = "gTanque";
            this.gTanque.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTanque.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gTanque.RowHeadersWidth = 23;
            this.gTanque.Size = new System.Drawing.Size(659, 201);
            this.gTanque.TabIndex = 1;
            this.gTanque.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTanque_ColumnHeaderMouseClick);
            this.gTanque.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gTanque_CellFormatting);
            // 
            // bsTanque
            // 
            this.bsTanque.DataSource = typeof(CamadaDados.PostoCombustivel.Cadastros.TList_TanqueCombustivel);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTanque;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
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
            // id_tanque
            // 
            this.id_tanque.BackColor = System.Drawing.SystemColors.Window;
            this.id_tanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_tanque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tanque.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Id_tanquestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tanque.Enabled = false;
            this.id_tanque.Location = new System.Drawing.Point(77, 3);
            this.id_tanque.Name = "id_tanque";
            this.id_tanque.NM_Alias = "";
            this.id_tanque.NM_Campo = "";
            this.id_tanque.NM_CampoBusca = "";
            this.id_tanque.NM_Param = "";
            this.id_tanque.QTD_Zero = 0;
            this.id_tanque.Size = new System.Drawing.Size(100, 20);
            this.id_tanque.ST_AutoInc = false;
            this.id_tanque.ST_DisableAuto = false;
            this.id_tanque.ST_Float = false;
            this.id_tanque.ST_Gravar = true;
            this.id_tanque.ST_Int = true;
            this.id_tanque.ST_LimpaCampo = true;
            this.id_tanque.ST_NotNull = true;
            this.id_tanque.ST_PrimaryKey = true;
            this.id_tanque.TabIndex = 0;
            this.id_tanque.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id. Tanque:";
            // 
            // bb_empresa
            // 
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(154, 29);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 3;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(20, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Empresa:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(77, 29);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "CD_Empresa";
            this.cd_empresa.NM_CampoBusca = "CD_Empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(75, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = true;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 2;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresa.Location = new System.Drawing.Point(188, 29);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_CD_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(419, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = true;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 41;
            this.nm_empresa.TextOld = null;
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_local.Location = new System.Drawing.Point(188, 81);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_CD_EMPRESA";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(419, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = true;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 45;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.Enabled = false;
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(154, 81);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 19);
            this.bb_local.TabIndex = 7;
            this.bb_local.UseVisualStyleBackColor = true;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(11, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Local Arm.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.SystemColors.Window;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Enabled = false;
            this.cd_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_local.Location = new System.Drawing.Point(77, 81);
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(75, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = true;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = true;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 6;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(4, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Capacidade:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // qtd_armazenagem
            // 
            this.qtd_armazenagem.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTanque, "Capacidadetanque", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd_armazenagem.DecimalPlaces = 3;
            this.qtd_armazenagem.Enabled = false;
            this.qtd_armazenagem.Location = new System.Drawing.Point(77, 107);
            this.qtd_armazenagem.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.qtd_armazenagem.Name = "qtd_armazenagem";
            this.qtd_armazenagem.NM_Alias = "";
            this.qtd_armazenagem.NM_Campo = "";
            this.qtd_armazenagem.NM_Param = "";
            this.qtd_armazenagem.Operador = "";
            this.qtd_armazenagem.Size = new System.Drawing.Size(120, 20);
            this.qtd_armazenagem.ST_AutoInc = false;
            this.qtd_armazenagem.ST_DisableAuto = false;
            this.qtd_armazenagem.ST_Gravar = true;
            this.qtd_armazenagem.ST_LimparCampo = true;
            this.qtd_armazenagem.ST_NotNull = true;
            this.qtd_armazenagem.ST_PrimaryKey = false;
            this.qtd_armazenagem.TabIndex = 10;
            this.qtd_armazenagem.ThousandsSeparator = true;
            // 
            // ds_prod
            // 
            this.ds_prod.BackColor = System.Drawing.SystemColors.Window;
            this.ds_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_prod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_prod.Enabled = false;
            this.ds_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_prod.Location = new System.Drawing.Point(188, 55);
            this.ds_prod.Name = "ds_prod";
            this.ds_prod.NM_Alias = "";
            this.ds_prod.NM_Campo = "ds_produto";
            this.ds_prod.NM_CampoBusca = "ds_produto";
            this.ds_prod.NM_Param = "@P_CD_EMPRESA";
            this.ds_prod.QTD_Zero = 0;
            this.ds_prod.Size = new System.Drawing.Size(419, 20);
            this.ds_prod.ST_AutoInc = false;
            this.ds_prod.ST_DisableAuto = false;
            this.ds_prod.ST_Float = false;
            this.ds_prod.ST_Gravar = false;
            this.ds_prod.ST_Int = true;
            this.ds_prod.ST_LimpaCampo = true;
            this.ds_prod.ST_NotNull = false;
            this.ds_prod.ST_PrimaryKey = false;
            this.ds_prod.TabIndex = 55;
            this.ds_prod.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.Enabled = false;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(154, 55);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 5;
            this.bb_produto.UseVisualStyleBackColor = true;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(4, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Combustivel:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cd_prod
            // 
            this.cd_prod.BackColor = System.Drawing.SystemColors.Window;
            this.cd_prod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_prod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_prod.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_prod.Enabled = false;
            this.cd_prod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_prod.Location = new System.Drawing.Point(77, 55);
            this.cd_prod.Name = "cd_prod";
            this.cd_prod.NM_Alias = "";
            this.cd_prod.NM_Campo = "cd_produto";
            this.cd_prod.NM_CampoBusca = "cd_produto";
            this.cd_prod.NM_Param = "@P_CD_EMPRESA";
            this.cd_prod.QTD_Zero = 0;
            this.cd_prod.Size = new System.Drawing.Size(75, 20);
            this.cd_prod.ST_AutoInc = false;
            this.cd_prod.ST_DisableAuto = false;
            this.cd_prod.ST_Float = false;
            this.cd_prod.ST_Gravar = true;
            this.cd_prod.ST_Int = true;
            this.cd_prod.ST_LimpaCampo = true;
            this.cd_prod.ST_NotNull = true;
            this.cd_prod.ST_PrimaryKey = false;
            this.cd_prod.TabIndex = 4;
            this.cd_prod.TextOld = null;
            this.cd_prod.Leave += new System.EventHandler(this.cd_prod_Leave);
            // 
            // sigla_unidade
            // 
            this.sigla_unidade.BackColor = System.Drawing.SystemColors.Window;
            this.sigla_unidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sigla_unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sigla_unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Sg_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sigla_unidade.Enabled = false;
            this.sigla_unidade.Location = new System.Drawing.Point(199, 107);
            this.sigla_unidade.Name = "sigla_unidade";
            this.sigla_unidade.NM_Alias = "";
            this.sigla_unidade.NM_Campo = "sigla_unidade";
            this.sigla_unidade.NM_CampoBusca = "sigla_unidade";
            this.sigla_unidade.NM_Param = "@P_SIGLA_UNIDADE";
            this.sigla_unidade.QTD_Zero = 0;
            this.sigla_unidade.Size = new System.Drawing.Size(28, 20);
            this.sigla_unidade.ST_AutoInc = false;
            this.sigla_unidade.ST_DisableAuto = false;
            this.sigla_unidade.ST_Float = false;
            this.sigla_unidade.ST_Gravar = false;
            this.sigla_unidade.ST_Int = false;
            this.sigla_unidade.ST_LimpaCampo = true;
            this.sigla_unidade.ST_NotNull = false;
            this.sigla_unidade.ST_PrimaryKey = false;
            this.sigla_unidade.TabIndex = 56;
            this.sigla_unidade.TextOld = null;
            // 
            // st_registro
            // 
            this.st_registro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsTanque, "St_registro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_registro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.st_registro.Enabled = false;
            this.st_registro.FormattingEnabled = true;
            this.st_registro.Location = new System.Drawing.Point(279, 107);
            this.st_registro.Name = "st_registro";
            this.st_registro.NM_Alias = "";
            this.st_registro.NM_Campo = "";
            this.st_registro.NM_Param = "";
            this.st_registro.Size = new System.Drawing.Size(160, 21);
            this.st_registro.ST_Gravar = true;
            this.st_registro.ST_LimparCampo = true;
            this.st_registro.ST_NotNull = false;
            this.st_registro.TabIndex = 57;
            this.st_registro.SelectedIndexChanged += new System.EventHandler(this.st_registro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(233, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Status:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDtDesativacao
            // 
            this.lblDtDesativacao.AutoSize = true;
            this.lblDtDesativacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDtDesativacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDtDesativacao.Location = new System.Drawing.Point(445, 110);
            this.lblDtDesativacao.Name = "lblDtDesativacao";
            this.lblDtDesativacao.Size = new System.Drawing.Size(87, 13);
            this.lblDtDesativacao.TabIndex = 59;
            this.lblDtDesativacao.Text = "Dt. Desativação:";
            this.lblDtDesativacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDtDesativacao.Visible = false;
            // 
            // dt_desativacao
            // 
            this.dt_desativacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_desativacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Dt_desativacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_desativacao.Enabled = false;
            this.dt_desativacao.Location = new System.Drawing.Point(538, 107);
            this.dt_desativacao.Mask = "00/00/0000";
            this.dt_desativacao.Name = "dt_desativacao";
            this.dt_desativacao.NM_Alias = "";
            this.dt_desativacao.NM_Campo = "";
            this.dt_desativacao.NM_CampoBusca = "";
            this.dt_desativacao.NM_Param = "";
            this.dt_desativacao.Operador = "";
            this.dt_desativacao.Size = new System.Drawing.Size(69, 20);
            this.dt_desativacao.ST_Gravar = true;
            this.dt_desativacao.ST_LimpaCampo = true;
            this.dt_desativacao.ST_NotNull = true;
            this.dt_desativacao.ST_PrimaryKey = false;
            this.dt_desativacao.TabIndex = 60;
            this.dt_desativacao.Visible = false;
            // 
            // dt_ativacao
            // 
            this.dt_ativacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_ativacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTanque, "Dt_ativacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_ativacao.Enabled = false;
            this.dt_ativacao.Location = new System.Drawing.Point(538, 107);
            this.dt_ativacao.Mask = "00/00/0000";
            this.dt_ativacao.Name = "dt_ativacao";
            this.dt_ativacao.NM_Alias = "";
            this.dt_ativacao.NM_Campo = "";
            this.dt_ativacao.NM_CampoBusca = "";
            this.dt_ativacao.NM_Param = "";
            this.dt_ativacao.Operador = "";
            this.dt_ativacao.Size = new System.Drawing.Size(69, 20);
            this.dt_ativacao.ST_Gravar = true;
            this.dt_ativacao.ST_LimpaCampo = true;
            this.dt_ativacao.ST_NotNull = true;
            this.dt_ativacao.ST_PrimaryKey = false;
            this.dt_ativacao.TabIndex = 62;
            // 
            // lblAtivacao
            // 
            this.lblAtivacao.AutoSize = true;
            this.lblAtivacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblAtivacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAtivacao.Location = new System.Drawing.Point(463, 110);
            this.lblAtivacao.Name = "lblAtivacao";
            this.lblAtivacao.Size = new System.Drawing.Size(69, 13);
            this.lblAtivacao.TabIndex = 61;
            this.lblAtivacao.Text = "Dt. Ativação:";
            this.lblAtivacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAtivacao.Visible = false;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // idtanquestrDataGridViewTextBoxColumn
            // 
            this.idtanquestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtanquestrDataGridViewTextBoxColumn.DataPropertyName = "Id_tanquestr";
            this.idtanquestrDataGridViewTextBoxColumn.HeaderText = "Id. Tanque";
            this.idtanquestrDataGridViewTextBoxColumn.Name = "idtanquestrDataGridViewTextBoxColumn";
            this.idtanquestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtanquestrDataGridViewTextBoxColumn.Width = 84;
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
            // Cd_produto
            // 
            this.Cd_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_produto.DataPropertyName = "Cd_produto";
            this.Cd_produto.HeaderText = "Cd. Produto";
            this.Cd_produto.Name = "Cd_produto";
            this.Cd_produto.ReadOnly = true;
            this.Cd_produto.Width = 81;
            // 
            // Ds_produto
            // 
            this.Ds_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Ds_produto.DataPropertyName = "Ds_produto";
            this.Ds_produto.HeaderText = "Produto";
            this.Ds_produto.Name = "Ds_produto";
            this.Ds_produto.ReadOnly = true;
            this.Ds_produto.Width = 69;
            // 
            // Capacidadetanque
            // 
            this.Capacidadetanque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Capacidadetanque.DataPropertyName = "Capacidadetanque";
            this.Capacidadetanque.HeaderText = "Capacidade Tanque";
            this.Capacidadetanque.Name = "Capacidadetanque";
            this.Capacidadetanque.ReadOnly = true;
            this.Capacidadetanque.Width = 118;
            // 
            // Sg_produto
            // 
            this.Sg_produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sg_produto.DataPropertyName = "Sg_produto";
            this.Sg_produto.HeaderText = "UND";
            this.Sg_produto.Name = "Sg_produto";
            this.Sg_produto.ReadOnly = true;
            this.Sg_produto.Width = 56;
            // 
            // pDt_ativacao
            // 
            this.pDt_ativacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pDt_ativacao.DataPropertyName = "Dt_ativacao";
            this.pDt_ativacao.HeaderText = "Dt. Ativação";
            this.pDt_ativacao.Name = "pDt_ativacao";
            this.pDt_ativacao.ReadOnly = true;
            this.pDt_ativacao.Width = 84;
            // 
            // pDt_desativacao
            // 
            this.pDt_desativacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pDt_desativacao.DataPropertyName = "Dt_desativacao";
            this.pDt_desativacao.HeaderText = "Dt. Desativação";
            this.pDt_desativacao.Name = "pDt_desativacao";
            this.pDt_desativacao.ReadOnly = true;
            // 
            // TFCadTanque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTanque";
            this.Text = "Cadastro Tanque Combustivel";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTanque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qtd_armazenagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gTanque;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_tanque;
        private System.Windows.Forms.BindingSource bsTanque;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_local;
        private Componentes.EditFloat qtd_armazenagem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdarmazenagemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstanqueDataGridViewTextBoxColumn;
        private Componentes.EditDefault ds_prod;
        private System.Windows.Forms.Button bb_produto;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault cd_prod;
        private Componentes.EditDefault sigla_unidade;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault st_registro;
        private Componentes.EditData dt_desativacao;
        private System.Windows.Forms.Label lblDtDesativacao;
        private Componentes.EditData dt_ativacao;
        private System.Windows.Forms.Label lblAtivacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtanquestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdlocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dslocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ds_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacidadetanque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sg_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDt_ativacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDt_desativacao;
    }
}
