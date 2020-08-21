namespace Mudanca.Cadastros
{
    partial class TFCadItens
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadItens));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.id_itempai = new Componentes.EditDefault(this.components);
            this.bsCadItens = new System.Windows.Forms.BindingSource(this.components);
            this.BB_Grupo = new System.Windows.Forms.Button();
            this.ds_itemPai = new Componentes.EditDefault(this.components);
            this.LB_DS_Grupo = new System.Windows.Forms.Label();
            this.LB_CD_Grupo_Pai = new System.Windows.Forms.Label();
            this.DS_Item = new Componentes.EditDefault(this.components);
            this.st_sintetico = new Componentes.CheckBoxDefault(this.components);
            this.metragemCub = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.BN_CadGrupoProduto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_organizar = new System.Windows.Forms.ToolStripButton();
            this.tsOrganizar = new System.Windows.Forms.ToolStrip();
            this.bb_cima = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_baixo = new System.Windows.Forms.ToolStripButton();
            this.Classificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iditemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsitemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iditempaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsitempaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metragemCubDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsinteticoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metragemCub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadGrupoProduto)).BeginInit();
            this.BN_CadGrupoProduto.SuspendLayout();
            this.tsOrganizar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.metragemCub);
            this.pDados.Controls.Add(this.st_sintetico);
            this.pDados.Controls.Add(this.id_itempai);
            this.pDados.Controls.Add(this.BB_Grupo);
            this.pDados.Controls.Add(this.ds_itemPai);
            this.pDados.Controls.Add(this.LB_DS_Grupo);
            this.pDados.Controls.Add(this.LB_CD_Grupo_Pai);
            this.pDados.Controls.Add(this.DS_Item);
            this.pDados.Size = new System.Drawing.Size(783, 93);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(795, 348);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.tsOrganizar);
            this.tpPadrao.Controls.Add(this.BN_CadGrupoProduto);
            this.tpPadrao.Size = new System.Drawing.Size(787, 322);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadGrupoProduto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tsOrganizar, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // id_itempai
            // 
            this.id_itempai.BackColor = System.Drawing.SystemColors.Window;
            this.id_itempai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_itempai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_itempai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadItens, "Id_itempaistr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_itempai.Enabled = false;
            this.id_itempai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_itempai.Location = new System.Drawing.Point(114, 7);
            this.id_itempai.MaxLength = 8;
            this.id_itempai.Name = "id_itempai";
            this.id_itempai.NM_Alias = "a";
            this.id_itempai.NM_Campo = "id_itempai";
            this.id_itempai.NM_CampoBusca = "id_item";
            this.id_itempai.NM_Param = "@P_CD_GRUPO_PAI";
            this.id_itempai.QTD_Zero = 0;
            this.id_itempai.Size = new System.Drawing.Size(79, 20);
            this.id_itempai.ST_AutoInc = false;
            this.id_itempai.ST_DisableAuto = false;
            this.id_itempai.ST_Float = false;
            this.id_itempai.ST_Gravar = true;
            this.id_itempai.ST_Int = false;
            this.id_itempai.ST_LimpaCampo = true;
            this.id_itempai.ST_NotNull = false;
            this.id_itempai.ST_PrimaryKey = false;
            this.id_itempai.TabIndex = 12;
            this.id_itempai.TextOld = null;
            this.id_itempai.Leave += new System.EventHandler(this.id_itempai_Leave);
            // 
            // bsCadItens
            // 
            this.bsCadItens.DataSource = typeof(CamadaDados.Mudanca.Cadastros.TList_CadItens);
            // 
            // BB_Grupo
            // 
            this.BB_Grupo.Enabled = false;
            this.BB_Grupo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Grupo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Grupo.Image")));
            this.BB_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Grupo.Location = new System.Drawing.Point(199, 8);
            this.BB_Grupo.Name = "BB_Grupo";
            this.BB_Grupo.Size = new System.Drawing.Size(30, 20);
            this.BB_Grupo.TabIndex = 14;
            this.BB_Grupo.UseVisualStyleBackColor = true;
            this.BB_Grupo.Click += new System.EventHandler(this.BB_Grupo_Click);
            // 
            // ds_itemPai
            // 
            this.ds_itemPai.BackColor = System.Drawing.SystemColors.Window;
            this.ds_itemPai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_itemPai.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_itemPai.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadItens, "Ds_itempai", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_itemPai.Enabled = false;
            this.ds_itemPai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_itemPai.Location = new System.Drawing.Point(235, 8);
            this.ds_itemPai.Name = "ds_itemPai";
            this.ds_itemPai.NM_Alias = "";
            this.ds_itemPai.NM_Campo = "ds_itempai";
            this.ds_itemPai.NM_CampoBusca = "ds_item";
            this.ds_itemPai.NM_Param = "@P_DS_GRUPO_PAI";
            this.ds_itemPai.QTD_Zero = 0;
            this.ds_itemPai.Size = new System.Drawing.Size(325, 20);
            this.ds_itemPai.ST_AutoInc = false;
            this.ds_itemPai.ST_DisableAuto = true;
            this.ds_itemPai.ST_Float = false;
            this.ds_itemPai.ST_Gravar = false;
            this.ds_itemPai.ST_Int = false;
            this.ds_itemPai.ST_LimpaCampo = true;
            this.ds_itemPai.ST_NotNull = false;
            this.ds_itemPai.ST_PrimaryKey = false;
            this.ds_itemPai.TabIndex = 16;
            this.ds_itemPai.TextOld = null;
            // 
            // LB_DS_Grupo
            // 
            this.LB_DS_Grupo.AutoSize = true;
            this.LB_DS_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Grupo.Location = new System.Drawing.Point(27, 36);
            this.LB_DS_Grupo.Name = "LB_DS_Grupo";
            this.LB_DS_Grupo.Size = new System.Drawing.Size(81, 13);
            this.LB_DS_Grupo.TabIndex = 13;
            this.LB_DS_Grupo.Text = "Descrição Item:";
            // 
            // LB_CD_Grupo_Pai
            // 
            this.LB_CD_Grupo_Pai.AutoSize = true;
            this.LB_CD_Grupo_Pai.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo_Pai.Location = new System.Drawing.Point(60, 10);
            this.LB_CD_Grupo_Pai.Name = "LB_CD_Grupo_Pai";
            this.LB_CD_Grupo_Pai.Size = new System.Drawing.Size(48, 13);
            this.LB_CD_Grupo_Pai.TabIndex = 17;
            this.LB_CD_Grupo_Pai.Text = "Item Pai:";
            // 
            // DS_Item
            // 
            this.DS_Item.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Item.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCadItens, "Ds_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Item.Enabled = false;
            this.DS_Item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Item.Location = new System.Drawing.Point(114, 33);
            this.DS_Item.Name = "DS_Item";
            this.DS_Item.NM_Alias = "a";
            this.DS_Item.NM_Campo = "Grupo";
            this.DS_Item.NM_CampoBusca = "DS_Grupo";
            this.DS_Item.NM_Param = "@P_DS_GRUPO";
            this.DS_Item.QTD_Zero = 0;
            this.DS_Item.Size = new System.Drawing.Size(446, 20);
            this.DS_Item.ST_AutoInc = false;
            this.DS_Item.ST_DisableAuto = false;
            this.DS_Item.ST_Float = false;
            this.DS_Item.ST_Gravar = true;
            this.DS_Item.ST_Int = false;
            this.DS_Item.ST_LimpaCampo = true;
            this.DS_Item.ST_NotNull = true;
            this.DS_Item.ST_PrimaryKey = false;
            this.DS_Item.TabIndex = 15;
            this.DS_Item.TextOld = null;
            // 
            // st_sintetico
            // 
            this.st_sintetico.AutoSize = true;
            this.st_sintetico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCadItens, "St_sinteticobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_sintetico.Location = new System.Drawing.Point(578, 32);
            this.st_sintetico.Name = "st_sintetico";
            this.st_sintetico.NM_Alias = "";
            this.st_sintetico.NM_Campo = "";
            this.st_sintetico.NM_Param = "";
            this.st_sintetico.Size = new System.Drawing.Size(67, 17);
            this.st_sintetico.ST_Gravar = true;
            this.st_sintetico.ST_LimparCampo = true;
            this.st_sintetico.ST_NotNull = false;
            this.st_sintetico.TabIndex = 18;
            this.st_sintetico.Text = "Sintético";
            this.st_sintetico.UseVisualStyleBackColor = true;
            this.st_sintetico.Vl_False = "";
            this.st_sintetico.Vl_True = "";
            // 
            // metragemCub
            // 
            this.metragemCub.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCadItens, "MetragemCub", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.metragemCub.DecimalPlaces = 3;
            this.metragemCub.Location = new System.Drawing.Point(114, 59);
            this.metragemCub.Name = "metragemCub";
            this.metragemCub.NM_Alias = "";
            this.metragemCub.NM_Campo = "";
            this.metragemCub.NM_Param = "";
            this.metragemCub.Operador = "";
            this.metragemCub.Size = new System.Drawing.Size(120, 20);
            this.metragemCub.ST_AutoInc = false;
            this.metragemCub.ST_DisableAuto = false;
            this.metragemCub.ST_Gravar = true;
            this.metragemCub.ST_LimparCampo = true;
            this.metragemCub.ST_NotNull = false;
            this.metragemCub.ST_PrimaryKey = false;
            this.metragemCub.TabIndex = 19;
            this.metragemCub.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(86, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "M³:";
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
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
            this.Classificacao,
            this.iditemDataGridViewTextBoxColumn,
            this.dsitemDataGridViewTextBoxColumn,
            this.iditempaiDataGridViewTextBoxColumn,
            this.dsitempaiDataGridViewTextBoxColumn,
            this.metragemCubDataGridViewTextBoxColumn,
            this.stsinteticoboolDataGridViewCheckBoxColumn});
            this.gCadastro.DataSource = this.bsCadItens;
            this.gCadastro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Location = new System.Drawing.Point(0, 93);
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.RowHeadersWidth = 23;
            this.gCadastro.Size = new System.Drawing.Size(759, 200);
            this.gCadastro.TabIndex = 1;
            this.gCadastro.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gCadastro_CellFormatting);
            // 
            // BN_CadGrupoProduto
            // 
            this.BN_CadGrupoProduto.AddNewItem = null;
            this.BN_CadGrupoProduto.BindingSource = this.bsCadItens;
            this.BN_CadGrupoProduto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadGrupoProduto.CountItemFormat = "de {0}";
            this.BN_CadGrupoProduto.DeleteItem = null;
            this.BN_CadGrupoProduto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_CadGrupoProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bb_organizar});
            this.BN_CadGrupoProduto.Location = new System.Drawing.Point(0, 293);
            this.BN_CadGrupoProduto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadGrupoProduto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadGrupoProduto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadGrupoProduto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadGrupoProduto.Name = "BN_CadGrupoProduto";
            this.BN_CadGrupoProduto.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_CadGrupoProduto.Size = new System.Drawing.Size(783, 25);
            this.BN_CadGrupoProduto.TabIndex = 3;
            this.BN_CadGrupoProduto.Text = "bindingNavigator1";
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
            // bb_organizar
            // 
            this.bb_organizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_organizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_organizar.ForeColor = System.Drawing.Color.Blue;
            this.bb_organizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_organizar.Name = "bb_organizar";
            this.bb_organizar.Size = new System.Drawing.Size(23, 22);
            this.bb_organizar.Click += new System.EventHandler(this.bb_organizar_Click);
            // 
            // tsOrganizar
            // 
            this.tsOrganizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsOrganizar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_cima,
            this.toolStripSeparator12,
            this.bb_baixo});
            this.tsOrganizar.Location = new System.Drawing.Point(759, 93);
            this.tsOrganizar.Name = "tsOrganizar";
            this.tsOrganizar.Size = new System.Drawing.Size(24, 200);
            this.tsOrganizar.TabIndex = 33;
            // 
            // bb_cima
            // 
            this.bb_cima.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bb_cima.Image = ((System.Drawing.Image)(resources.GetObject("bb_cima.Image")));
            this.bb_cima.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cima.Name = "bb_cima";
            this.bb_cima.Size = new System.Drawing.Size(21, 20);
            this.bb_cima.Text = "toolStripButton18";
            this.bb_cima.ToolTipText = "Mover para Cima";
            this.bb_cima.Click += new System.EventHandler(this.bb_cima_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(21, 6);
            // 
            // bb_baixo
            // 
            this.bb_baixo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bb_baixo.Image = ((System.Drawing.Image)(resources.GetObject("bb_baixo.Image")));
            this.bb_baixo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_baixo.Name = "bb_baixo";
            this.bb_baixo.Size = new System.Drawing.Size(21, 20);
            this.bb_baixo.Text = "toolStripButton19";
            this.bb_baixo.ToolTipText = "Mover para  Baixo";
            this.bb_baixo.Click += new System.EventHandler(this.bb_baixo_Click);
            // 
            // Classificacao
            // 
            this.Classificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Classificacao.DataPropertyName = "Classificacao";
            this.Classificacao.HeaderText = "Classificação";
            this.Classificacao.Name = "Classificacao";
            this.Classificacao.ReadOnly = true;
            this.Classificacao.Width = 94;
            // 
            // iditemDataGridViewTextBoxColumn
            // 
            this.iditemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iditemDataGridViewTextBoxColumn.DataPropertyName = "Id_item";
            this.iditemDataGridViewTextBoxColumn.HeaderText = "Id.Item";
            this.iditemDataGridViewTextBoxColumn.Name = "iditemDataGridViewTextBoxColumn";
            this.iditemDataGridViewTextBoxColumn.ReadOnly = true;
            this.iditemDataGridViewTextBoxColumn.Width = 64;
            // 
            // dsitemDataGridViewTextBoxColumn
            // 
            this.dsitemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsitemDataGridViewTextBoxColumn.DataPropertyName = "Ds_item";
            this.dsitemDataGridViewTextBoxColumn.HeaderText = "Item";
            this.dsitemDataGridViewTextBoxColumn.Name = "dsitemDataGridViewTextBoxColumn";
            this.dsitemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsitemDataGridViewTextBoxColumn.Width = 52;
            // 
            // iditempaiDataGridViewTextBoxColumn
            // 
            this.iditempaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.iditempaiDataGridViewTextBoxColumn.DataPropertyName = "Id_itempai";
            this.iditempaiDataGridViewTextBoxColumn.HeaderText = "Id.Item Pai";
            this.iditempaiDataGridViewTextBoxColumn.Name = "iditempaiDataGridViewTextBoxColumn";
            this.iditempaiDataGridViewTextBoxColumn.ReadOnly = true;
            this.iditempaiDataGridViewTextBoxColumn.Width = 82;
            // 
            // dsitempaiDataGridViewTextBoxColumn
            // 
            this.dsitempaiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsitempaiDataGridViewTextBoxColumn.DataPropertyName = "Ds_itempai";
            this.dsitempaiDataGridViewTextBoxColumn.HeaderText = "Item Pai";
            this.dsitempaiDataGridViewTextBoxColumn.Name = "dsitempaiDataGridViewTextBoxColumn";
            this.dsitempaiDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsitempaiDataGridViewTextBoxColumn.Width = 70;
            // 
            // metragemCubDataGridViewTextBoxColumn
            // 
            this.metragemCubDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.metragemCubDataGridViewTextBoxColumn.DataPropertyName = "MetragemCub";
            this.metragemCubDataGridViewTextBoxColumn.HeaderText = "M³";
            this.metragemCubDataGridViewTextBoxColumn.Name = "metragemCubDataGridViewTextBoxColumn";
            this.metragemCubDataGridViewTextBoxColumn.ReadOnly = true;
            this.metragemCubDataGridViewTextBoxColumn.Width = 44;
            // 
            // stsinteticoboolDataGridViewCheckBoxColumn
            // 
            this.stsinteticoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stsinteticoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_sinteticobool";
            this.stsinteticoboolDataGridViewCheckBoxColumn.HeaderText = "Sintético";
            this.stsinteticoboolDataGridViewCheckBoxColumn.Name = "stsinteticoboolDataGridViewCheckBoxColumn";
            this.stsinteticoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stsinteticoboolDataGridViewCheckBoxColumn.Width = 54;
            // 
            // TFCadItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 391);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadItens";
            this.Text = "Cadastro - Itens";
            this.Load += new System.EventHandler(this.TFCadItens_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCadItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metragemCub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadGrupoProduto)).EndInit();
            this.BN_CadGrupoProduto.ResumeLayout(false);
            this.BN_CadGrupoProduto.PerformLayout();
            this.tsOrganizar.ResumeLayout(false);
            this.tsOrganizar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault id_itempai;
        public System.Windows.Forms.Button BB_Grupo;
        private Componentes.EditDefault ds_itemPai;
        private System.Windows.Forms.Label LB_DS_Grupo;
        private System.Windows.Forms.Label LB_CD_Grupo_Pai;
        private Componentes.EditDefault DS_Item;
        private Componentes.CheckBoxDefault st_sintetico;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat metragemCub;
        private System.Windows.Forms.BindingSource bsCadItens;
        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.BindingNavigator BN_CadGrupoProduto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStrip tsOrganizar;
        private System.Windows.Forms.ToolStripButton bb_cima;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton bb_baixo;
        private System.Windows.Forms.ToolStripButton bb_organizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn iditemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsitemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iditempaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsitempaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn metragemCubDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stsinteticoboolDataGridViewCheckBoxColumn;
    }
}