namespace Commoditties.Cadastros
{
    partial class TFCad_Amostra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Amostra));
            this.g_cadTpAmostra = new Componentes.DataGridDefault(this.components);
            this.BS_Amostra = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Amostra = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Ds_Amostra = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Ordem = new Componentes.EditDefault(this.components);
            this.CD_TipoAmostra = new Componentes.EditDefault(this.components);
            this.ds_metodo = new Componentes.EditDefault(this.components);
            this.bb_metdo = new System.Windows.Forms.Button();
            this.LB_CD_TabelaDesconto = new System.Windows.Forms.Label();
            this.id_metodo = new Componentes.EditDefault(this.components);
            this.st_gerasubproduto = new Componentes.CheckBoxDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_metodostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_gerasubprodutobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_cadTpAmostra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Amostra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Amostra)).BeginInit();
            this.BN_Amostra.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_gerasubproduto);
            this.pDados.Controls.Add(this.ds_metodo);
            this.pDados.Controls.Add(this.bb_metdo);
            this.pDados.Controls.Add(this.LB_CD_TabelaDesconto);
            this.pDados.Controls.Add(this.id_metodo);
            this.pDados.Controls.Add(this.CD_TipoAmostra);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Ordem);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.Ds_Amostra);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.g_cadTpAmostra);
            this.tpPadrao.Controls.Add(this.BN_Amostra);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_Amostra, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_cadTpAmostra, 0);
            // 
            // g_cadTpAmostra
            // 
            this.g_cadTpAmostra.AllowUserToAddRows = false;
            this.g_cadTpAmostra.AllowUserToDeleteRows = false;
            this.g_cadTpAmostra.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_cadTpAmostra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_cadTpAmostra.AutoGenerateColumns = false;
            this.g_cadTpAmostra.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_cadTpAmostra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_cadTpAmostra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadTpAmostra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_cadTpAmostra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_cadTpAmostra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Id_metodostr,
            this.dataGridViewTextBoxColumn4,
            this.St_gerasubprodutobool});
            this.g_cadTpAmostra.DataSource = this.BS_Amostra;
            resources.ApplyResources(this.g_cadTpAmostra, "g_cadTpAmostra");
            this.g_cadTpAmostra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_cadTpAmostra.Name = "g_cadTpAmostra";
            this.g_cadTpAmostra.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_cadTpAmostra.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.g_cadTpAmostra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.g_cadTpAmostra.TabStop = false;
            // 
            // BS_Amostra
            // 
            this.BS_Amostra.DataSource = typeof(CamadaDados.Graos.TList_CadAmostra);
            // 
            // BN_Amostra
            // 
            this.BN_Amostra.AddNewItem = null;
            this.BN_Amostra.BindingSource = this.BS_Amostra;
            this.BN_Amostra.CountItem = this.bindingNavigatorCountItem;
            this.BN_Amostra.CountItemFormat = "de {0}";
            this.BN_Amostra.DeleteItem = null;
            resources.ApplyResources(this.BN_Amostra, "BN_Amostra");
            this.BN_Amostra.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Amostra.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Amostra.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Amostra.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Amostra.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Amostra.Name = "BN_Amostra";
            this.BN_Amostra.PositionItem = this.bindingNavigatorPositionItem;
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Ds_Amostra
            // 
            this.Ds_Amostra.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Amostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_Amostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Amostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Amostra, "Ds_Amostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_Amostra, "Ds_Amostra");
            this.Ds_Amostra.Name = "Ds_Amostra";
            this.Ds_Amostra.NM_Alias = "";
            this.Ds_Amostra.NM_Campo = "Cód. Local";
            this.Ds_Amostra.NM_CampoBusca = "CD_LOCAL";
            this.Ds_Amostra.NM_Param = "@P_CD_LOCAL";
            this.Ds_Amostra.QTD_Zero = 0;
            this.Ds_Amostra.ST_AutoInc = false;
            this.Ds_Amostra.ST_DisableAuto = true;
            this.Ds_Amostra.ST_Float = false;
            this.Ds_Amostra.ST_Gravar = true;
            this.Ds_Amostra.ST_Int = false;
            this.Ds_Amostra.ST_LimpaCampo = true;
            this.Ds_Amostra.ST_NotNull = false;
            this.Ds_Amostra.ST_PrimaryKey = false;
            this.Ds_Amostra.TextOld = null;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Ordem
            // 
            this.Ordem.BackColor = System.Drawing.SystemColors.Window;
            this.Ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Amostra, "Ordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ordem, "Ordem");
            this.Ordem.Name = "Ordem";
            this.Ordem.NM_Alias = "";
            this.Ordem.NM_Campo = "ordem";
            this.Ordem.NM_CampoBusca = "ordem";
            this.Ordem.NM_Param = "@P_ORDEM";
            this.Ordem.QTD_Zero = 0;
            this.Ordem.ST_AutoInc = false;
            this.Ordem.ST_DisableAuto = false;
            this.Ordem.ST_Float = false;
            this.Ordem.ST_Gravar = true;
            this.Ordem.ST_Int = true;
            this.Ordem.ST_LimpaCampo = true;
            this.Ordem.ST_NotNull = false;
            this.Ordem.ST_PrimaryKey = false;
            this.Ordem.TextOld = null;
            // 
            // CD_TipoAmostra
            // 
            this.CD_TipoAmostra.BackColor = System.Drawing.SystemColors.Window;
            this.CD_TipoAmostra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_TipoAmostra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_TipoAmostra.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Amostra, "CD_TipoAmostra", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_TipoAmostra, "CD_TipoAmostra");
            this.CD_TipoAmostra.Name = "CD_TipoAmostra";
            this.CD_TipoAmostra.NM_Alias = "";
            this.CD_TipoAmostra.NM_Campo = "CD_Amostra";
            this.CD_TipoAmostra.NM_CampoBusca = "CD_Amostra";
            this.CD_TipoAmostra.NM_Param = "@P_CD_AMOSTRA";
            this.CD_TipoAmostra.QTD_Zero = 3;
            this.CD_TipoAmostra.ST_AutoInc = false;
            this.CD_TipoAmostra.ST_DisableAuto = false;
            this.CD_TipoAmostra.ST_Float = false;
            this.CD_TipoAmostra.ST_Gravar = true;
            this.CD_TipoAmostra.ST_Int = true;
            this.CD_TipoAmostra.ST_LimpaCampo = true;
            this.CD_TipoAmostra.ST_NotNull = true;
            this.CD_TipoAmostra.ST_PrimaryKey = true;
            this.CD_TipoAmostra.TextOld = null;
            // 
            // ds_metodo
            // 
            this.ds_metodo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_metodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_metodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_metodo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Amostra, "Ds_metodo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_metodo, "ds_metodo");
            this.ds_metodo.Name = "ds_metodo";
            this.ds_metodo.NM_Alias = "";
            this.ds_metodo.NM_Campo = "ds_metodo";
            this.ds_metodo.NM_CampoBusca = "ds_metodo";
            this.ds_metodo.NM_Param = "@P_DS_METODO";
            this.ds_metodo.QTD_Zero = 0;
            this.ds_metodo.ReadOnly = true;
            this.ds_metodo.ST_AutoInc = false;
            this.ds_metodo.ST_DisableAuto = false;
            this.ds_metodo.ST_Float = false;
            this.ds_metodo.ST_Gravar = false;
            this.ds_metodo.ST_Int = false;
            this.ds_metodo.ST_LimpaCampo = true;
            this.ds_metodo.ST_NotNull = false;
            this.ds_metodo.ST_PrimaryKey = false;
            this.ds_metodo.TextOld = null;
            // 
            // bb_metdo
            // 
            resources.ApplyResources(this.bb_metdo, "bb_metdo");
            this.bb_metdo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_metdo.Name = "bb_metdo";
            this.bb_metdo.UseVisualStyleBackColor = true;
            this.bb_metdo.Click += new System.EventHandler(this.bb_metdo_Click);
            // 
            // LB_CD_TabelaDesconto
            // 
            resources.ApplyResources(this.LB_CD_TabelaDesconto, "LB_CD_TabelaDesconto");
            this.LB_CD_TabelaDesconto.Name = "LB_CD_TabelaDesconto";
            // 
            // id_metodo
            // 
            this.id_metodo.BackColor = System.Drawing.SystemColors.Window;
            this.id_metodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_metodo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_metodo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Amostra, "Id_metodostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_metodo, "id_metodo");
            this.id_metodo.Name = "id_metodo";
            this.id_metodo.NM_Alias = "a";
            this.id_metodo.NM_Campo = "id_metodo";
            this.id_metodo.NM_CampoBusca = "id_metodo";
            this.id_metodo.NM_Param = "@P_CD_TABELADESCONTO";
            this.id_metodo.QTD_Zero = 0;
            this.id_metodo.ST_AutoInc = false;
            this.id_metodo.ST_DisableAuto = false;
            this.id_metodo.ST_Float = false;
            this.id_metodo.ST_Gravar = true;
            this.id_metodo.ST_Int = true;
            this.id_metodo.ST_LimpaCampo = true;
            this.id_metodo.ST_NotNull = false;
            this.id_metodo.ST_PrimaryKey = false;
            this.id_metodo.TextOld = null;
            this.id_metodo.Leave += new System.EventHandler(this.id_metodo_Leave);
            // 
            // st_gerasubproduto
            // 
            resources.ApplyResources(this.st_gerasubproduto, "st_gerasubproduto");
            this.st_gerasubproduto.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_Amostra, "St_gerasubprodutobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_gerasubproduto.Name = "st_gerasubproduto";
            this.st_gerasubproduto.NM_Alias = "";
            this.st_gerasubproduto.NM_Campo = "";
            this.st_gerasubproduto.NM_Param = "";
            this.st_gerasubproduto.ST_Gravar = true;
            this.st_gerasubproduto.ST_LimparCampo = true;
            this.st_gerasubproduto.ST_NotNull = false;
            this.st_gerasubproduto.UseVisualStyleBackColor = true;
            this.st_gerasubproduto.Vl_False = "";
            this.st_gerasubproduto.Vl_True = "";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CD_TipoAmostra";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_Amostra";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ordem";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Id_metodostr
            // 
            this.Id_metodostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_metodostr.DataPropertyName = "Id_metodostr";
            resources.ApplyResources(this.Id_metodostr, "Id_metodostr");
            this.Id_metodostr.Name = "Id_metodostr";
            this.Id_metodostr.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Ds_metodo";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // St_gerasubprodutobool
            // 
            this.St_gerasubprodutobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_gerasubprodutobool.DataPropertyName = "St_gerasubprodutobool";
            resources.ApplyResources(this.St_gerasubprodutobool, "St_gerasubprodutobool");
            this.St_gerasubprodutobool.Name = "St_gerasubprodutobool";
            this.St_gerasubprodutobool.ReadOnly = true;
            // 
            // TFCad_Amostra
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCad_Amostra";
            this.Load += new System.EventHandler(this.TFCad_Amostra_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_Amostra_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.g_cadTpAmostra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Amostra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Amostra)).EndInit();
            this.BN_Amostra.ResumeLayout(false);
            this.BN_Amostra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_Amostra;
        private Componentes.DataGridDefault g_cadTpAmostra;
        private System.Windows.Forms.BindingNavigator BN_Amostra;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Ordem;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Ds_Amostra;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault CD_TipoAmostra;
        private Componentes.EditDefault ds_metodo;
        private System.Windows.Forms.Label LB_CD_TabelaDesconto;
        private Componentes.EditDefault id_metodo;
        private System.Windows.Forms.Button bb_metdo;
        private Componentes.CheckBoxDefault st_gerasubproduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_metodostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_gerasubprodutobool;
    }
}