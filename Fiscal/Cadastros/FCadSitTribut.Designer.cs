namespace Fiscal.Cadastros
{
    partial class TFCadSitTribut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadSitTribut));
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dssituacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_simplesnacionalbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_substtribbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bs_CadSitTrib = new System.Windows.Forms.BindingSource(this.components);
            this.LB_DS_Situacao = new System.Windows.Forms.Label();
            this.DS_Situacao = new Componentes.EditDefault(this.components);
            this.bn_CadSitTrib = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_st = new Componentes.EditDefault(this.components);
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.CD_Imposto = new Componentes.EditDefault(this.components);
            this.LB_CD_Imposto = new System.Windows.Forms.Label();
            this.bb_imposto = new System.Windows.Forms.Button();
            this.tp_situacao = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.st_simplesnacional = new Componentes.CheckBoxDefault(this.components);
            this.st_substtrib = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadSitTrib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadSitTrib)).BeginInit();
            this.bn_CadSitTrib.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.st_substtrib);
            this.pDados.Controls.Add(this.st_simplesnacional);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.tp_situacao);
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.CD_Imposto);
            this.pDados.Controls.Add(this.LB_CD_Imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_st);
            this.pDados.Controls.Add(this.LB_DS_Situacao);
            this.pDados.Controls.Add(this.DS_Situacao);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bn_CadSitTrib);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadSitTrib, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
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
            this.cdstDataGridViewTextBoxColumn,
            this.dssituacaoDataGridViewTextBoxColumn,
            this.Cd_impostostr,
            this.dataGridViewTextBoxColumn1,
            this.Tipo_situacao,
            this.St_simplesnacionalbool,
            this.St_substtribbool});
            this.gCadastro.DataSource = this.bs_CadSitTrib;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
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
            this.gCadastro.TabStop = false;
            // 
            // cdstDataGridViewTextBoxColumn
            // 
            this.cdstDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdstDataGridViewTextBoxColumn.DataPropertyName = "Cd_st";
            resources.ApplyResources(this.cdstDataGridViewTextBoxColumn, "cdstDataGridViewTextBoxColumn");
            this.cdstDataGridViewTextBoxColumn.Name = "cdstDataGridViewTextBoxColumn";
            this.cdstDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dssituacaoDataGridViewTextBoxColumn
            // 
            this.dssituacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dssituacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_situacao";
            resources.ApplyResources(this.dssituacaoDataGridViewTextBoxColumn, "dssituacaoDataGridViewTextBoxColumn");
            this.dssituacaoDataGridViewTextBoxColumn.Name = "dssituacaoDataGridViewTextBoxColumn";
            this.dssituacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            resources.ApplyResources(this.Cd_impostostr, "Cd_impostostr");
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_imposto";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Tipo_situacao
            // 
            this.Tipo_situacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_situacao.DataPropertyName = "Tipo_situacao";
            resources.ApplyResources(this.Tipo_situacao, "Tipo_situacao");
            this.Tipo_situacao.Name = "Tipo_situacao";
            this.Tipo_situacao.ReadOnly = true;
            // 
            // St_simplesnacionalbool
            // 
            this.St_simplesnacionalbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_simplesnacionalbool.DataPropertyName = "St_simplesnacionalbool";
            resources.ApplyResources(this.St_simplesnacionalbool, "St_simplesnacionalbool");
            this.St_simplesnacionalbool.Name = "St_simplesnacionalbool";
            this.St_simplesnacionalbool.ReadOnly = true;
            // 
            // St_substtribbool
            // 
            this.St_substtribbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_substtribbool.DataPropertyName = "St_substtribbool";
            resources.ApplyResources(this.St_substtribbool, "St_substtribbool");
            this.St_substtribbool.Name = "St_substtribbool";
            this.St_substtribbool.ReadOnly = true;
            // 
            // bs_CadSitTrib
            // 
            this.bs_CadSitTrib.DataSource = typeof(CamadaDados.Fiscal.TList_CadSitTribut);
            // 
            // LB_DS_Situacao
            // 
            resources.ApplyResources(this.LB_DS_Situacao, "LB_DS_Situacao");
            this.LB_DS_Situacao.Name = "LB_DS_Situacao";
            // 
            // DS_Situacao
            // 
            this.DS_Situacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Situacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Situacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadSitTrib, "ds_situacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.DS_Situacao, "DS_Situacao");
            this.DS_Situacao.Name = "DS_Situacao";
            this.DS_Situacao.NM_Alias = "";
            this.DS_Situacao.NM_Campo = "DS_Situacao";
            this.DS_Situacao.NM_CampoBusca = "DS_Situacao";
            this.DS_Situacao.NM_Param = "@P_DS_SITUACAO";
            this.DS_Situacao.QTD_Zero = 0;
            this.DS_Situacao.ST_AutoInc = false;
            this.DS_Situacao.ST_DisableAuto = false;
            this.DS_Situacao.ST_Float = false;
            this.DS_Situacao.ST_Gravar = true;
            this.DS_Situacao.ST_Int = false;
            this.DS_Situacao.ST_LimpaCampo = true;
            this.DS_Situacao.ST_NotNull = true;
            this.DS_Situacao.ST_PrimaryKey = false;
            // 
            // bn_CadSitTrib
            // 
            this.bn_CadSitTrib.AddNewItem = null;
            this.bn_CadSitTrib.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadSitTrib.DeleteItem = null;
            resources.ApplyResources(this.bn_CadSitTrib, "bn_CadSitTrib");
            this.bn_CadSitTrib.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadSitTrib.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadSitTrib.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadSitTrib.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadSitTrib.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadSitTrib.Name = "bn_CadSitTrib";
            this.bn_CadSitTrib.PositionItem = this.bindingNavigatorPositionItem;
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
            // cd_st
            // 
            this.cd_st.BackColor = System.Drawing.SystemColors.Window;
            this.cd_st.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_st.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadSitTrib, "cd_st", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_st, "cd_st");
            this.cd_st.Name = "cd_st";
            this.cd_st.NM_Alias = "";
            this.cd_st.NM_Campo = "CD_ST";
            this.cd_st.NM_CampoBusca = "CD_ST";
            this.cd_st.NM_Param = "@P_CD_ST";
            this.cd_st.QTD_Zero = 0;
            this.cd_st.ST_AutoInc = false;
            this.cd_st.ST_DisableAuto = false;
            this.cd_st.ST_Float = false;
            this.cd_st.ST_Gravar = true;
            this.cd_st.ST_Int = false;
            this.cd_st.ST_LimpaCampo = true;
            this.cd_st.ST_NotNull = true;
            this.cd_st.ST_PrimaryKey = true;
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadSitTrib, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_imposto, "ds_imposto");
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.ReadOnly = true;
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            // 
            // CD_Imposto
            // 
            this.CD_Imposto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadSitTrib, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CD_Imposto, "CD_Imposto");
            this.CD_Imposto.Name = "CD_Imposto";
            this.CD_Imposto.NM_Alias = "a";
            this.CD_Imposto.NM_Campo = "CD_Imposto";
            this.CD_Imposto.NM_CampoBusca = "CD_Imposto";
            this.CD_Imposto.NM_Param = "@P_CD_IMPOSTO";
            this.CD_Imposto.QTD_Zero = 0;
            this.CD_Imposto.ST_AutoInc = false;
            this.CD_Imposto.ST_DisableAuto = false;
            this.CD_Imposto.ST_Float = false;
            this.CD_Imposto.ST_Gravar = true;
            this.CD_Imposto.ST_Int = false;
            this.CD_Imposto.ST_LimpaCampo = true;
            this.CD_Imposto.ST_NotNull = true;
            this.CD_Imposto.ST_PrimaryKey = true;
            this.CD_Imposto.Leave += new System.EventHandler(this.CD_Imposto_Leave);
            // 
            // LB_CD_Imposto
            // 
            resources.ApplyResources(this.LB_CD_Imposto, "LB_CD_Imposto");
            this.LB_CD_Imposto.Name = "LB_CD_Imposto";
            // 
            // bb_imposto
            // 
            resources.ApplyResources(this.bb_imposto, "bb_imposto");
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.UseVisualStyleBackColor = true;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // tp_situacao
            // 
            this.tp_situacao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bs_CadSitTrib, "Tp_situacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.tp_situacao, "tp_situacao");
            this.tp_situacao.FormattingEnabled = true;
            this.tp_situacao.Name = "tp_situacao";
            this.tp_situacao.NM_Alias = "";
            this.tp_situacao.NM_Campo = "";
            this.tp_situacao.NM_Param = "";
            this.tp_situacao.ST_Gravar = true;
            this.tp_situacao.ST_LimparCampo = true;
            this.tp_situacao.ST_NotNull = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // st_simplesnacional
            // 
            resources.ApplyResources(this.st_simplesnacional, "st_simplesnacional");
            this.st_simplesnacional.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_CadSitTrib, "St_simplesnacionalbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_simplesnacional.Name = "st_simplesnacional";
            this.st_simplesnacional.NM_Alias = "";
            this.st_simplesnacional.NM_Campo = "";
            this.st_simplesnacional.NM_Param = "";
            this.st_simplesnacional.ST_Gravar = true;
            this.st_simplesnacional.ST_LimparCampo = true;
            this.st_simplesnacional.ST_NotNull = false;
            this.st_simplesnacional.UseVisualStyleBackColor = true;
            this.st_simplesnacional.Vl_False = "";
            this.st_simplesnacional.Vl_True = "";
            // 
            // st_substtrib
            // 
            resources.ApplyResources(this.st_substtrib, "st_substtrib");
            this.st_substtrib.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bs_CadSitTrib, "St_substtribbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_substtrib.Name = "st_substtrib";
            this.st_substtrib.NM_Alias = "";
            this.st_substtrib.NM_Campo = "";
            this.st_substtrib.NM_Param = "";
            this.st_substtrib.ST_Gravar = true;
            this.st_substtrib.ST_LimparCampo = true;
            this.st_substtrib.ST_NotNull = false;
            this.st_substtrib.UseVisualStyleBackColor = true;
            this.st_substtrib.Vl_False = "";
            this.st_substtrib.Vl_True = "";
            // 
            // TFCadSitTribut
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadSitTribut";
            this.Load += new System.EventHandler(this.TFCadSitTribut_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadSitTribut_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadSitTrib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadSitTrib)).EndInit();
            this.bn_CadSitTrib.ResumeLayout(false);
            this.bn_CadSitTrib.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label LB_DS_Situacao;
        private Componentes.EditDefault DS_Situacao;
        private System.Windows.Forms.BindingNavigator bn_CadSitTrib;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bs_CadSitTrib;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_st;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoimpostoDataGridViewTextBoxColumn;
        private Componentes.EditDefault ds_imposto;
        private Componentes.EditDefault CD_Imposto;
        private System.Windows.Forms.Label LB_CD_Imposto;
        public System.Windows.Forms.Button bb_imposto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idststrDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private Componentes.ComboBoxDefault tp_situacao;
        private Componentes.CheckBoxDefault st_simplesnacional;
        private Componentes.CheckBoxDefault st_substtrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dssituacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_situacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_simplesnacionalbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_substtribbool;
    }
}
