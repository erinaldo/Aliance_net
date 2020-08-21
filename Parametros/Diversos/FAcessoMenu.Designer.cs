namespace Parametros.Diversos
{
    partial class TFAcessoMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAcessoMenu));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.tList_CadAcessoDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsAcesso = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpDetalhe = new System.Windows.Forms.TableLayoutPanel();
            this.lblConciliacao = new System.Windows.Forms.Label();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.pDetalhe = new Componentes.PanelDados(this.components);
            this.cbExcluir = new Componentes.CheckBoxDefault(this.components);
            this.cbAlterar = new Componentes.CheckBoxDefault(this.components);
            this.cbIncluir = new Componentes.CheckBoxDefault(this.components);
            this.Incluibool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alterabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Excluibool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlpCentral.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_CadAcessoDataGridDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcesso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tlpDetalhe.SuspendLayout();
            this.pDetalhe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 2;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Controls.Add(this.panelDados2, 1, 0);
            this.tlpCentral.Controls.Add(this.tlpDetalhe, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCentral.Size = new System.Drawing.Size(850, 606);
            this.tlpCentral.TabIndex = 0;
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados2.Controls.Add(this.tList_CadAcessoDataGridDefault);
            this.panelDados2.Controls.Add(this.bindingNavigator1);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(429, 5);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(416, 596);
            this.panelDados2.TabIndex = 1;
            // 
            // tList_CadAcessoDataGridDefault
            // 
            this.tList_CadAcessoDataGridDefault.AllowUserToAddRows = false;
            this.tList_CadAcessoDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_CadAcessoDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.tList_CadAcessoDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tList_CadAcessoDataGridDefault.AutoGenerateColumns = false;
            this.tList_CadAcessoDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_CadAcessoDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_CadAcessoDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_CadAcessoDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tList_CadAcessoDataGridDefault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tList_CadAcessoDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewCheckBoxColumn3});
            this.tList_CadAcessoDataGridDefault.DataSource = this.bsAcesso;
            this.tList_CadAcessoDataGridDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tList_CadAcessoDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_CadAcessoDataGridDefault.Location = new System.Drawing.Point(0, 20);
            this.tList_CadAcessoDataGridDefault.MultiSelect = false;
            this.tList_CadAcessoDataGridDefault.Name = "tList_CadAcessoDataGridDefault";
            this.tList_CadAcessoDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_CadAcessoDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tList_CadAcessoDataGridDefault.RowHeadersWidth = 23;
            this.tList_CadAcessoDataGridDefault.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tList_CadAcessoDataGridDefault.Size = new System.Drawing.Size(412, 547);
            this.tList_CadAcessoDataGridDefault.TabIndex = 67;
            this.tList_CadAcessoDataGridDefault.DoubleClick += new System.EventHandler(this.tList_CadAcessoDataGridDefault_DoubleClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Id_menu";
            this.dataGridViewTextBoxColumn4.HeaderText = "Id. Menu";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 82;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Ds_menu";
            this.dataGridViewTextBoxColumn5.HeaderText = "Menu";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 63;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Incluibool";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Inclui";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 44;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "Alterabool";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Altera";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Width = 46;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "Excluibool";
            this.dataGridViewCheckBoxColumn3.HeaderText = "Exclui";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Width = 47;
            // 
            // bsAcesso
            // 
            this.bsAcesso.DataSource = typeof(CamadaDados.Diversos.TRegistro_CadAcesso);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsAcesso;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 567);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(412, 25);
            this.bindingNavigator1.TabIndex = 68;
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
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "ACESSO USUARIO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDetalhe
            // 
            this.tlpDetalhe.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tlpDetalhe.ColumnCount = 1;
            this.tlpDetalhe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhe.Controls.Add(this.lblConciliacao, 0, 0);
            this.tlpDetalhe.Controls.Add(this.tvMenu, 0, 1);
            this.tlpDetalhe.Controls.Add(this.pDetalhe, 0, 2);
            this.tlpDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDetalhe.Location = new System.Drawing.Point(5, 5);
            this.tlpDetalhe.Name = "tlpDetalhe";
            this.tlpDetalhe.RowCount = 3;
            this.tlpDetalhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDetalhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDetalhe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpDetalhe.Size = new System.Drawing.Size(416, 596);
            this.tlpDetalhe.TabIndex = 2;
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
            this.lblConciliacao.Location = new System.Drawing.Point(5, 2);
            this.lblConciliacao.Name = "lblConciliacao";
            this.lblConciliacao.Size = new System.Drawing.Size(406, 20);
            this.lblConciliacao.TabIndex = 65;
            this.lblConciliacao.Text = "LISTA MENUS DO SISTEMA";
            this.lblConciliacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvMenu
            // 
            this.tvMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tvMenu.FullRowSelect = true;
            this.tvMenu.LabelEdit = true;
            this.tvMenu.Location = new System.Drawing.Point(5, 27);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(406, 533);
            this.tvMenu.TabIndex = 66;
            this.tvMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMenu_NodeMouseDoubleClick);
            // 
            // pDetalhe
            // 
            this.pDetalhe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhe.Controls.Add(this.cbExcluir);
            this.pDetalhe.Controls.Add(this.cbAlterar);
            this.pDetalhe.Controls.Add(this.cbIncluir);
            this.pDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetalhe.Location = new System.Drawing.Point(5, 568);
            this.pDetalhe.Name = "pDetalhe";
            this.pDetalhe.NM_ProcDeletar = "";
            this.pDetalhe.NM_ProcGravar = "";
            this.pDetalhe.Size = new System.Drawing.Size(406, 23);
            this.pDetalhe.TabIndex = 67;
            // 
            // cbExcluir
            // 
            this.cbExcluir.AutoSize = true;
            this.cbExcluir.Checked = true;
            this.cbExcluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExcluir.Location = new System.Drawing.Point(337, 2);
            this.cbExcluir.Name = "cbExcluir";
            this.cbExcluir.NM_Alias = "";
            this.cbExcluir.NM_Campo = "";
            this.cbExcluir.NM_Param = "";
            this.cbExcluir.Size = new System.Drawing.Size(64, 17);
            this.cbExcluir.ST_Gravar = false;
            this.cbExcluir.ST_LimparCampo = true;
            this.cbExcluir.ST_NotNull = false;
            this.cbExcluir.TabIndex = 2;
            this.cbExcluir.Text = "Excluir";
            this.cbExcluir.UseVisualStyleBackColor = true;
            this.cbExcluir.Vl_False = "";
            this.cbExcluir.Vl_True = "";
            // 
            // cbAlterar
            // 
            this.cbAlterar.AutoSize = true;
            this.cbAlterar.Checked = true;
            this.cbAlterar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAlterar.Location = new System.Drawing.Point(169, 2);
            this.cbAlterar.Name = "cbAlterar";
            this.cbAlterar.NM_Alias = "";
            this.cbAlterar.NM_Campo = "";
            this.cbAlterar.NM_Param = "";
            this.cbAlterar.Size = new System.Drawing.Size(63, 17);
            this.cbAlterar.ST_Gravar = false;
            this.cbAlterar.ST_LimparCampo = true;
            this.cbAlterar.ST_NotNull = false;
            this.cbAlterar.TabIndex = 1;
            this.cbAlterar.Text = "Alterar";
            this.cbAlterar.UseVisualStyleBackColor = true;
            this.cbAlterar.Vl_False = "";
            this.cbAlterar.Vl_True = "";
            // 
            // cbIncluir
            // 
            this.cbIncluir.AutoSize = true;
            this.cbIncluir.Checked = true;
            this.cbIncluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIncluir.Location = new System.Drawing.Point(3, 1);
            this.cbIncluir.Name = "cbIncluir";
            this.cbIncluir.NM_Alias = "";
            this.cbIncluir.NM_Campo = "";
            this.cbIncluir.NM_Param = "";
            this.cbIncluir.Size = new System.Drawing.Size(61, 17);
            this.cbIncluir.ST_Gravar = false;
            this.cbIncluir.ST_LimparCampo = true;
            this.cbIncluir.ST_NotNull = false;
            this.cbIncluir.TabIndex = 0;
            this.cbIncluir.Text = "Incluir";
            this.cbIncluir.UseVisualStyleBackColor = true;
            this.cbIncluir.Vl_False = "";
            this.cbIncluir.Vl_True = "";
            // 
            // Incluibool
            // 
            this.Incluibool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Incluibool.DataPropertyName = "Incluibool";
            this.Incluibool.HeaderText = "Inclui";
            this.Incluibool.Name = "Incluibool";
            this.Incluibool.ReadOnly = true;
            // 
            // Alterabool
            // 
            this.Alterabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Alterabool.DataPropertyName = "Alterabool";
            this.Alterabool.HeaderText = "Altera";
            this.Alterabool.Name = "Alterabool";
            this.Alterabool.ReadOnly = true;
            // 
            // Excluibool
            // 
            this.Excluibool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Excluibool.DataPropertyName = "Excluibool";
            this.Excluibool.HeaderText = "Exclui";
            this.Excluibool.Name = "Excluibool";
            this.Excluibool.ReadOnly = true;
            // 
            // TFAcessoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 606);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAcessoMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acesso Menu Sistema";
            this.Load += new System.EventHandler(this.TFAcessoMenu_Load);
            this.tlpCentral.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList_CadAcessoDataGridDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAcesso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tlpDetalhe.ResumeLayout(false);
            this.pDetalhe.ResumeLayout(false);
            this.pDetalhe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados2;
        private System.Windows.Forms.TableLayoutPanel tlpDetalhe;
        private System.Windows.Forms.Label lblConciliacao;
        private System.Windows.Forms.TreeView tvMenu;
        private Componentes.PanelDados pDetalhe;
        private Componentes.CheckBoxDefault cbAlterar;
        private Componentes.CheckBoxDefault cbIncluir;
        private Componentes.CheckBoxDefault cbExcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Incluibool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alterabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Excluibool;
        private System.Windows.Forms.BindingSource bsAcesso;
        private Componentes.DataGridDefault tList_CadAcessoDataGridDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
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