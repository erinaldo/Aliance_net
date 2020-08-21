namespace Estoque.Cadastros
{
    partial class TFCad_TpProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_TpProduto));
            this.g_CadTpProduto = new Componentes.DataGridDefault(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTpProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_servicobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_industrializadobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_MPrimabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_embalagembool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_sementebool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_mprimasementebool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_consumointernobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_patrimoniobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_combustivelbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_lubrificantebool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_pneubool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_folharbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_tanquecombustivelbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_commoditiesbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BS_CadTpProduto = new System.Windows.Forms.BindingSource(this.components);
            this.TP_Produto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DS_TpProduto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.BN_CadTpProduto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.st_commodities = new Componentes.CheckBoxDefault(this.components);
            this.st_tanquecombustivel = new Componentes.CheckBoxDefault(this.components);
            this.cbFolhar = new Componentes.CheckBoxDefault(this.components);
            this.st_reganvisa = new Componentes.CheckBoxDefault(this.components);
            this.st_pneu = new Componentes.CheckBoxDefault(this.components);
            this.st_patrimonio = new Componentes.CheckBoxDefault(this.components);
            this.st_lubrificante = new Componentes.CheckBoxDefault(this.components);
            this.st_combustivel = new Componentes.CheckBoxDefault(this.components);
            this.st_consumoInterno = new Componentes.CheckBoxDefault(this.components);
            this.st_semente = new Componentes.CheckBoxDefault(this.components);
            this.st_industrializado = new Componentes.CheckBoxDefault(this.components);
            this.st_mprimasemente = new Componentes.CheckBoxDefault(this.components);
            this.st_embalagem = new Componentes.CheckBoxDefault(this.components);
            this.st_mprima = new Componentes.CheckBoxDefault(this.components);
            this.st_composto = new Componentes.CheckBoxDefault(this.components);
            this.st_servico = new Componentes.CheckBoxDefault(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadTpProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadTpProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTpProduto)).BeginInit();
            this.BN_CadTpProduto.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.pDetalhes);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.DS_TpProduto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.TP_Produto);
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.TabStop = true;
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_CadTpProduto);
            this.tpPadrao.Controls.Add(this.BN_CadTpProduto);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadTpProduto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_CadTpProduto, 0);
            // 
            // g_CadTpProduto
            // 
            this.g_CadTpProduto.AllowUserToAddRows = false;
            this.g_CadTpProduto.AllowUserToDeleteRows = false;
            this.g_CadTpProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_CadTpProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_CadTpProduto.AutoGenerateColumns = false;
            this.g_CadTpProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_CadTpProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_CadTpProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadTpProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_CadTpProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_CadTpProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dSTpProdutoDataGridViewTextBoxColumn,
            this.St_servicobool,
            this.St_industrializadobool,
            this.St_MPrimabool,
            this.St_embalagembool,
            this.St_sementebool,
            this.St_mprimasementebool,
            this.dataGridViewCheckBoxColumn1,
            this.St_consumointernobool,
            this.St_patrimoniobool,
            this.St_combustivelbool,
            this.St_lubrificantebool,
            this.St_pneubool,
            this.St_folharbool,
            this.St_tanquecombustivelbool,
            this.St_commoditiesbool});
            this.g_CadTpProduto.DataSource = this.BS_CadTpProduto;
            resources.ApplyResources(this.g_CadTpProduto, "g_CadTpProduto");
            this.g_CadTpProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_CadTpProduto.Name = "g_CadTpProduto";
            this.g_CadTpProduto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_CadTpProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_CadTpProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_CadTpProduto.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "TP_Produto";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dSTpProdutoDataGridViewTextBoxColumn
            // 
            this.dSTpProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTpProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_TpProduto";
            resources.ApplyResources(this.dSTpProdutoDataGridViewTextBoxColumn, "dSTpProdutoDataGridViewTextBoxColumn");
            this.dSTpProdutoDataGridViewTextBoxColumn.Name = "dSTpProdutoDataGridViewTextBoxColumn";
            this.dSTpProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // St_servicobool
            // 
            this.St_servicobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_servicobool.DataPropertyName = "St_servicobool";
            resources.ApplyResources(this.St_servicobool, "St_servicobool");
            this.St_servicobool.Name = "St_servicobool";
            this.St_servicobool.ReadOnly = true;
            // 
            // St_industrializadobool
            // 
            this.St_industrializadobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_industrializadobool.DataPropertyName = "St_compostobool";
            resources.ApplyResources(this.St_industrializadobool, "St_industrializadobool");
            this.St_industrializadobool.Name = "St_industrializadobool";
            this.St_industrializadobool.ReadOnly = true;
            // 
            // St_MPrimabool
            // 
            this.St_MPrimabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_MPrimabool.DataPropertyName = "St_MPrimabool";
            resources.ApplyResources(this.St_MPrimabool, "St_MPrimabool");
            this.St_MPrimabool.Name = "St_MPrimabool";
            this.St_MPrimabool.ReadOnly = true;
            // 
            // St_embalagembool
            // 
            this.St_embalagembool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_embalagembool.DataPropertyName = "St_embalagembool";
            resources.ApplyResources(this.St_embalagembool, "St_embalagembool");
            this.St_embalagembool.Name = "St_embalagembool";
            this.St_embalagembool.ReadOnly = true;
            // 
            // St_sementebool
            // 
            this.St_sementebool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_sementebool.DataPropertyName = "St_sementebool";
            resources.ApplyResources(this.St_sementebool, "St_sementebool");
            this.St_sementebool.Name = "St_sementebool";
            this.St_sementebool.ReadOnly = true;
            // 
            // St_mprimasementebool
            // 
            this.St_mprimasementebool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_mprimasementebool.DataPropertyName = "St_mprimasementebool";
            resources.ApplyResources(this.St_mprimasementebool, "St_mprimasementebool");
            this.St_mprimasementebool.Name = "St_mprimasementebool";
            this.St_mprimasementebool.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "St_industrializadobool";
            resources.ApplyResources(this.dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // St_consumointernobool
            // 
            this.St_consumointernobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_consumointernobool.DataPropertyName = "St_consumointernobool";
            resources.ApplyResources(this.St_consumointernobool, "St_consumointernobool");
            this.St_consumointernobool.Name = "St_consumointernobool";
            this.St_consumointernobool.ReadOnly = true;
            // 
            // St_patrimoniobool
            // 
            this.St_patrimoniobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_patrimoniobool.DataPropertyName = "St_patrimoniobool";
            resources.ApplyResources(this.St_patrimoniobool, "St_patrimoniobool");
            this.St_patrimoniobool.Name = "St_patrimoniobool";
            this.St_patrimoniobool.ReadOnly = true;
            // 
            // St_combustivelbool
            // 
            this.St_combustivelbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_combustivelbool.DataPropertyName = "St_combustivelbool";
            resources.ApplyResources(this.St_combustivelbool, "St_combustivelbool");
            this.St_combustivelbool.Name = "St_combustivelbool";
            this.St_combustivelbool.ReadOnly = true;
            // 
            // St_lubrificantebool
            // 
            this.St_lubrificantebool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_lubrificantebool.DataPropertyName = "St_lubrificantebool";
            resources.ApplyResources(this.St_lubrificantebool, "St_lubrificantebool");
            this.St_lubrificantebool.Name = "St_lubrificantebool";
            this.St_lubrificantebool.ReadOnly = true;
            // 
            // St_pneubool
            // 
            this.St_pneubool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_pneubool.DataPropertyName = "St_pneubool";
            resources.ApplyResources(this.St_pneubool, "St_pneubool");
            this.St_pneubool.Name = "St_pneubool";
            this.St_pneubool.ReadOnly = true;
            // 
            // St_folharbool
            // 
            this.St_folharbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_folharbool.DataPropertyName = "St_folharbool";
            resources.ApplyResources(this.St_folharbool, "St_folharbool");
            this.St_folharbool.Name = "St_folharbool";
            this.St_folharbool.ReadOnly = true;
            // 
            // St_tanquecombustivelbool
            // 
            this.St_tanquecombustivelbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_tanquecombustivelbool.DataPropertyName = "St_tanquecombustivelbool";
            resources.ApplyResources(this.St_tanquecombustivelbool, "St_tanquecombustivelbool");
            this.St_tanquecombustivelbool.Name = "St_tanquecombustivelbool";
            this.St_tanquecombustivelbool.ReadOnly = true;
            // 
            // St_commoditiesbool
            // 
            this.St_commoditiesbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_commoditiesbool.DataPropertyName = "St_commoditiesbool";
            resources.ApplyResources(this.St_commoditiesbool, "St_commoditiesbool");
            this.St_commoditiesbool.Name = "St_commoditiesbool";
            this.St_commoditiesbool.ReadOnly = true;
            // 
            // BS_CadTpProduto
            // 
            this.BS_CadTpProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadTpProduto);
            // 
            // TP_Produto
            // 
            this.TP_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto, "TP_Produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.TP_Produto, "TP_Produto");
            this.TP_Produto.Name = "TP_Produto";
            this.TP_Produto.NM_Alias = "a";
            this.TP_Produto.NM_Campo = "TP_Produto";
            this.TP_Produto.NM_CampoBusca = "TP_Produto";
            this.TP_Produto.NM_Param = "@P_TP_PRODUTO";
            this.TP_Produto.QTD_Zero = 0;
            this.TP_Produto.ST_AutoInc = false;
            this.TP_Produto.ST_DisableAuto = true;
            this.TP_Produto.ST_Float = false;
            this.TP_Produto.ST_Gravar = true;
            this.TP_Produto.ST_Int = true;
            this.TP_Produto.ST_LimpaCampo = true;
            this.TP_Produto.ST_NotNull = true;
            this.TP_Produto.ST_PrimaryKey = true;
            this.TP_Produto.TextOld = null;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DS_TpProduto
            // 
            this.DS_TpProduto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_TpProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_TpProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_TpProduto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadTpProduto, "DS_TpProduto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_TpProduto, "DS_TpProduto");
            this.DS_TpProduto.Name = "DS_TpProduto";
            this.DS_TpProduto.NM_Alias = "a";
            this.DS_TpProduto.NM_Campo = "Tipo Produto";
            this.DS_TpProduto.NM_CampoBusca = "DS_TpProduto";
            this.DS_TpProduto.NM_Param = "@P_DS_TPPRODUTO";
            this.DS_TpProduto.QTD_Zero = 0;
            this.DS_TpProduto.ST_AutoInc = false;
            this.DS_TpProduto.ST_DisableAuto = false;
            this.DS_TpProduto.ST_Float = false;
            this.DS_TpProduto.ST_Gravar = true;
            this.DS_TpProduto.ST_Int = false;
            this.DS_TpProduto.ST_LimpaCampo = true;
            this.DS_TpProduto.ST_NotNull = true;
            this.DS_TpProduto.ST_PrimaryKey = false;
            this.DS_TpProduto.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BN_CadTpProduto
            // 
            this.BN_CadTpProduto.AddNewItem = null;
            this.BN_CadTpProduto.BindingSource = this.BS_CadTpProduto;
            this.BN_CadTpProduto.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadTpProduto.CountItemFormat = "de {0}";
            this.BN_CadTpProduto.DeleteItem = null;
            resources.ApplyResources(this.BN_CadTpProduto, "BN_CadTpProduto");
            this.BN_CadTpProduto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadTpProduto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadTpProduto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadTpProduto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadTpProduto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadTpProduto.Name = "BN_CadTpProduto";
            this.BN_CadTpProduto.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // pDetalhes
            // 
            this.pDetalhes.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDetalhes.Controls.Add(this.st_commodities);
            this.pDetalhes.Controls.Add(this.st_tanquecombustivel);
            this.pDetalhes.Controls.Add(this.cbFolhar);
            this.pDetalhes.Controls.Add(this.st_reganvisa);
            this.pDetalhes.Controls.Add(this.st_pneu);
            this.pDetalhes.Controls.Add(this.st_patrimonio);
            this.pDetalhes.Controls.Add(this.st_lubrificante);
            this.pDetalhes.Controls.Add(this.st_combustivel);
            this.pDetalhes.Controls.Add(this.st_consumoInterno);
            this.pDetalhes.Controls.Add(this.st_semente);
            this.pDetalhes.Controls.Add(this.st_industrializado);
            this.pDetalhes.Controls.Add(this.st_mprimasemente);
            this.pDetalhes.Controls.Add(this.st_embalagem);
            this.pDetalhes.Controls.Add(this.st_mprima);
            this.pDetalhes.Controls.Add(this.st_composto);
            this.pDetalhes.Controls.Add(this.st_servico);
            resources.ApplyResources(this.pDetalhes, "pDetalhes");
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.NM_ProcDeletar = "";
            this.pDetalhes.NM_ProcGravar = "";
            // 
            // st_commodities
            // 
            resources.ApplyResources(this.st_commodities, "st_commodities");
            this.st_commodities.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_commoditiesbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_commodities.Name = "st_commodities";
            this.st_commodities.NM_Alias = "";
            this.st_commodities.NM_Campo = "";
            this.st_commodities.NM_Param = "";
            this.st_commodities.ST_Gravar = true;
            this.st_commodities.ST_LimparCampo = true;
            this.st_commodities.ST_NotNull = false;
            this.st_commodities.UseVisualStyleBackColor = true;
            this.st_commodities.Vl_False = "";
            this.st_commodities.Vl_True = "";
            // 
            // st_tanquecombustivel
            // 
            resources.ApplyResources(this.st_tanquecombustivel, "st_tanquecombustivel");
            this.st_tanquecombustivel.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_tanquecombustivelbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_tanquecombustivel.Name = "st_tanquecombustivel";
            this.st_tanquecombustivel.NM_Alias = "";
            this.st_tanquecombustivel.NM_Campo = "";
            this.st_tanquecombustivel.NM_Param = "";
            this.st_tanquecombustivel.ST_Gravar = true;
            this.st_tanquecombustivel.ST_LimparCampo = true;
            this.st_tanquecombustivel.ST_NotNull = false;
            this.st_tanquecombustivel.UseVisualStyleBackColor = true;
            this.st_tanquecombustivel.Vl_False = "";
            this.st_tanquecombustivel.Vl_True = "";
            // 
            // cbFolhar
            // 
            resources.ApplyResources(this.cbFolhar, "cbFolhar");
            this.cbFolhar.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_folharbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbFolhar.Name = "cbFolhar";
            this.cbFolhar.NM_Alias = "";
            this.cbFolhar.NM_Campo = "";
            this.cbFolhar.NM_Param = "";
            this.cbFolhar.ST_Gravar = true;
            this.cbFolhar.ST_LimparCampo = true;
            this.cbFolhar.ST_NotNull = false;
            this.cbFolhar.UseVisualStyleBackColor = true;
            this.cbFolhar.Vl_False = "";
            this.cbFolhar.Vl_True = "";
            // 
            // st_reganvisa
            // 
            resources.ApplyResources(this.st_reganvisa, "st_reganvisa");
            this.st_reganvisa.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_reganvisabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_reganvisa.Name = "st_reganvisa";
            this.st_reganvisa.NM_Alias = "";
            this.st_reganvisa.NM_Campo = "";
            this.st_reganvisa.NM_Param = "";
            this.st_reganvisa.ST_Gravar = true;
            this.st_reganvisa.ST_LimparCampo = true;
            this.st_reganvisa.ST_NotNull = false;
            this.st_reganvisa.UseVisualStyleBackColor = true;
            this.st_reganvisa.Vl_False = "";
            this.st_reganvisa.Vl_True = "";
            // 
            // st_pneu
            // 
            resources.ApplyResources(this.st_pneu, "st_pneu");
            this.st_pneu.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_pneubool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_pneu.Name = "st_pneu";
            this.st_pneu.NM_Alias = "";
            this.st_pneu.NM_Campo = "";
            this.st_pneu.NM_Param = "";
            this.st_pneu.ST_Gravar = true;
            this.st_pneu.ST_LimparCampo = true;
            this.st_pneu.ST_NotNull = false;
            this.st_pneu.UseVisualStyleBackColor = true;
            this.st_pneu.Vl_False = "";
            this.st_pneu.Vl_True = "";
            // 
            // st_patrimonio
            // 
            resources.ApplyResources(this.st_patrimonio, "st_patrimonio");
            this.st_patrimonio.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_patrimoniobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_patrimonio.Name = "st_patrimonio";
            this.st_patrimonio.NM_Alias = "";
            this.st_patrimonio.NM_Campo = "";
            this.st_patrimonio.NM_Param = "";
            this.st_patrimonio.ST_Gravar = true;
            this.st_patrimonio.ST_LimparCampo = true;
            this.st_patrimonio.ST_NotNull = false;
            this.st_patrimonio.UseVisualStyleBackColor = true;
            this.st_patrimonio.Vl_False = "";
            this.st_patrimonio.Vl_True = "";
            // 
            // st_lubrificante
            // 
            resources.ApplyResources(this.st_lubrificante, "st_lubrificante");
            this.st_lubrificante.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_lubrificantebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_lubrificante.Name = "st_lubrificante";
            this.st_lubrificante.NM_Alias = "";
            this.st_lubrificante.NM_Campo = "";
            this.st_lubrificante.NM_Param = "";
            this.st_lubrificante.ST_Gravar = true;
            this.st_lubrificante.ST_LimparCampo = true;
            this.st_lubrificante.ST_NotNull = false;
            this.st_lubrificante.UseVisualStyleBackColor = true;
            this.st_lubrificante.Vl_False = "";
            this.st_lubrificante.Vl_True = "";
            // 
            // st_combustivel
            // 
            resources.ApplyResources(this.st_combustivel, "st_combustivel");
            this.st_combustivel.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_combustivelbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_combustivel.Name = "st_combustivel";
            this.st_combustivel.NM_Alias = "";
            this.st_combustivel.NM_Campo = "";
            this.st_combustivel.NM_Param = "";
            this.st_combustivel.ST_Gravar = true;
            this.st_combustivel.ST_LimparCampo = true;
            this.st_combustivel.ST_NotNull = false;
            this.st_combustivel.UseVisualStyleBackColor = true;
            this.st_combustivel.Vl_False = "";
            this.st_combustivel.Vl_True = "";
            // 
            // st_consumoInterno
            // 
            resources.ApplyResources(this.st_consumoInterno, "st_consumoInterno");
            this.st_consumoInterno.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_consumointernobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_consumoInterno.Name = "st_consumoInterno";
            this.st_consumoInterno.NM_Alias = "";
            this.st_consumoInterno.NM_Campo = "";
            this.st_consumoInterno.NM_Param = "";
            this.st_consumoInterno.ST_Gravar = true;
            this.st_consumoInterno.ST_LimparCampo = true;
            this.st_consumoInterno.ST_NotNull = false;
            this.st_consumoInterno.UseVisualStyleBackColor = true;
            this.st_consumoInterno.Vl_False = "";
            this.st_consumoInterno.Vl_True = "";
            // 
            // st_semente
            // 
            resources.ApplyResources(this.st_semente, "st_semente");
            this.st_semente.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_sementebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_semente.Name = "st_semente";
            this.st_semente.NM_Alias = "";
            this.st_semente.NM_Campo = "";
            this.st_semente.NM_Param = "";
            this.st_semente.ST_Gravar = true;
            this.st_semente.ST_LimparCampo = true;
            this.st_semente.ST_NotNull = false;
            this.st_semente.UseVisualStyleBackColor = true;
            this.st_semente.Vl_False = "";
            this.st_semente.Vl_True = "";
            // 
            // st_industrializado
            // 
            resources.ApplyResources(this.st_industrializado, "st_industrializado");
            this.st_industrializado.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_industrializadobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_industrializado.Name = "st_industrializado";
            this.st_industrializado.NM_Alias = "";
            this.st_industrializado.NM_Campo = "";
            this.st_industrializado.NM_Param = "";
            this.st_industrializado.ST_Gravar = true;
            this.st_industrializado.ST_LimparCampo = true;
            this.st_industrializado.ST_NotNull = false;
            this.st_industrializado.UseVisualStyleBackColor = true;
            this.st_industrializado.Vl_False = "";
            this.st_industrializado.Vl_True = "";
            // 
            // st_mprimasemente
            // 
            resources.ApplyResources(this.st_mprimasemente, "st_mprimasemente");
            this.st_mprimasemente.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_mprimasementebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_mprimasemente.Name = "st_mprimasemente";
            this.st_mprimasemente.NM_Alias = "";
            this.st_mprimasemente.NM_Campo = "";
            this.st_mprimasemente.NM_Param = "";
            this.st_mprimasemente.ST_Gravar = true;
            this.st_mprimasemente.ST_LimparCampo = true;
            this.st_mprimasemente.ST_NotNull = false;
            this.toolTip1.SetToolTip(this.st_mprimasemente, resources.GetString("st_mprimasemente.ToolTip"));
            this.st_mprimasemente.UseVisualStyleBackColor = true;
            this.st_mprimasemente.Vl_False = "";
            this.st_mprimasemente.Vl_True = "";
            // 
            // st_embalagem
            // 
            resources.ApplyResources(this.st_embalagem, "st_embalagem");
            this.st_embalagem.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_embalagembool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_embalagem.Name = "st_embalagem";
            this.st_embalagem.NM_Alias = "";
            this.st_embalagem.NM_Campo = "";
            this.st_embalagem.NM_Param = "";
            this.st_embalagem.ST_Gravar = true;
            this.st_embalagem.ST_LimparCampo = true;
            this.st_embalagem.ST_NotNull = false;
            this.st_embalagem.UseVisualStyleBackColor = true;
            this.st_embalagem.Vl_False = "";
            this.st_embalagem.Vl_True = "";
            // 
            // st_mprima
            // 
            resources.ApplyResources(this.st_mprima, "st_mprima");
            this.st_mprima.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_MPrimabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_mprima.Name = "st_mprima";
            this.st_mprima.NM_Alias = "";
            this.st_mprima.NM_Campo = "";
            this.st_mprima.NM_Param = "";
            this.st_mprima.ST_Gravar = true;
            this.st_mprima.ST_LimparCampo = true;
            this.st_mprima.ST_NotNull = false;
            this.st_mprima.UseVisualStyleBackColor = true;
            this.st_mprima.Vl_False = "";
            this.st_mprima.Vl_True = "";
            // 
            // st_composto
            // 
            resources.ApplyResources(this.st_composto, "st_composto");
            this.st_composto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_compostobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_composto.Name = "st_composto";
            this.st_composto.NM_Alias = "";
            this.st_composto.NM_Campo = "";
            this.st_composto.NM_Param = "";
            this.st_composto.ST_Gravar = true;
            this.st_composto.ST_LimparCampo = true;
            this.st_composto.ST_NotNull = false;
            this.st_composto.UseVisualStyleBackColor = true;
            this.st_composto.Vl_False = "";
            this.st_composto.Vl_True = "";
            // 
            // st_servico
            // 
            resources.ApplyResources(this.st_servico, "st_servico");
            this.st_servico.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CadTpProduto, "St_servicobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_servico.Name = "st_servico";
            this.st_servico.NM_Alias = "";
            this.st_servico.NM_Campo = "";
            this.st_servico.NM_Param = "";
            this.st_servico.ST_Gravar = true;
            this.st_servico.ST_LimparCampo = true;
            this.st_servico.ST_NotNull = false;
            this.st_servico.Tag = "";
            this.st_servico.UseVisualStyleBackColor = true;
            this.st_servico.Vl_False = "";
            this.st_servico.Vl_True = "";
            // 
            // TFCad_TpProduto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_TpProduto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_TpProduto_FormClosing);
            this.Load += new System.EventHandler(this.TFCad_TpProduto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_CadTpProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadTpProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadTpProduto)).EndInit();
            this.BN_CadTpProduto.ResumeLayout(false);
            this.BN_CadTpProduto.PerformLayout();
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_CadTpProduto;
        private Componentes.DataGridDefault g_CadTpProduto;
        private Componentes.EditDefault TP_Produto;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault DS_TpProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator BN_CadTpProduto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.PanelDados pDetalhes;
        private Componentes.CheckBoxDefault st_mprima;
        private Componentes.CheckBoxDefault st_composto;
        private Componentes.CheckBoxDefault st_servico;
        private System.Windows.Forms.ToolTip toolTip1;
        private Componentes.CheckBoxDefault st_embalagem;
        private Componentes.CheckBoxDefault st_mprimasemente;
        private Componentes.CheckBoxDefault st_industrializado;
        private Componentes.CheckBoxDefault st_semente;
        private Componentes.CheckBoxDefault st_consumoInterno;
        private Componentes.CheckBoxDefault st_combustivel;
        private Componentes.CheckBoxDefault st_lubrificante;
        private Componentes.CheckBoxDefault st_patrimonio;
        private Componentes.CheckBoxDefault st_pneu;
        private Componentes.CheckBoxDefault st_reganvisa;
        private Componentes.CheckBoxDefault cbFolhar;
        private Componentes.CheckBoxDefault st_tanquecombustivel;
        private Componentes.CheckBoxDefault st_commodities;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTpProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_servicobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_industrializadobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_MPrimabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_embalagembool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_sementebool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_mprimasementebool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_consumointernobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_patrimoniobool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_combustivelbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_lubrificantebool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_pneubool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_folharbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_tanquecombustivelbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_commoditiesbool;
    }
}