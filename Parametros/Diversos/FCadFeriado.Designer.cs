namespace Parametros.Diversos
{
    partial class TFCadFeriado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadFeriado));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Id_Feriado = new Componentes.EditDefault(this.components);
            this.BS_CadFeriado = new System.Windows.Forms.BindingSource(this.components);
            this.DS_Feriado = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DT_Feriado = new Componentes.EditData(this.components);
            this.ST_RepeteAnual = new Componentes.CheckBoxDefault(this.components);
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idFeriadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDFeriadoStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsFeriadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFeriadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtFeriadoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stRepeteAnualDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BS_Navigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadFeriado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).BeginInit();
            this.BS_Navigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.tableLayoutPanel1);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.DT_Feriado);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.DS_Feriado);
            this.pDados.Controls.Add(this.Id_Feriado);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_DIV_FERIADO";
            this.pDados.NM_ProcGravar = "IA_DIV_FERIADO";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.BS_Navigator);
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BS_Navigator, 0);
            // 
            // Id_Feriado
            // 
            this.Id_Feriado.AccessibleDescription = null;
            this.Id_Feriado.AccessibleName = null;
            resources.ApplyResources(this.Id_Feriado, "Id_Feriado");
            this.Id_Feriado.BackColor = System.Drawing.SystemColors.Window;
            this.Id_Feriado.BackgroundImage = null;
            this.Id_Feriado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_Feriado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadFeriado, "ID_Feriado_String", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_Feriado.Name = "Id_Feriado";
            this.Id_Feriado.NM_Alias = "";
            this.Id_Feriado.NM_Campo = "Id_Feriado";
            this.Id_Feriado.NM_CampoBusca = "Id_Feriado";
            this.Id_Feriado.NM_Param = "@P_ID_FERIADO";
            this.Id_Feriado.QTD_Zero = 0;
            this.Id_Feriado.ST_AutoInc = false;
            this.Id_Feriado.ST_DisableAuto = true;
            this.Id_Feriado.ST_Float = false;
            this.Id_Feriado.ST_Gravar = true;
            this.Id_Feriado.ST_Int = true;
            this.Id_Feriado.ST_LimpaCampo = true;
            this.Id_Feriado.ST_NotNull = true;
            this.Id_Feriado.ST_PrimaryKey = true;
            // 
            // BS_CadFeriado
            // 
            this.BS_CadFeriado.DataSource = typeof(CamadaDados.Diversos.TList_CadFeriado);
            // 
            // DS_Feriado
            // 
            this.DS_Feriado.AccessibleDescription = null;
            this.DS_Feriado.AccessibleName = null;
            resources.ApplyResources(this.DS_Feriado, "DS_Feriado");
            this.DS_Feriado.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Feriado.BackgroundImage = null;
            this.DS_Feriado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Feriado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadFeriado, "Ds_Feriado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Feriado.Name = "DS_Feriado";
            this.DS_Feriado.NM_Alias = "";
            this.DS_Feriado.NM_Campo = "DS_Feriado";
            this.DS_Feriado.NM_CampoBusca = "DS_Feriado";
            this.DS_Feriado.NM_Param = "@P_DS_FERIADO";
            this.DS_Feriado.QTD_Zero = 0;
            this.DS_Feriado.ST_AutoInc = false;
            this.DS_Feriado.ST_DisableAuto = false;
            this.DS_Feriado.ST_Float = false;
            this.DS_Feriado.ST_Gravar = true;
            this.DS_Feriado.ST_Int = false;
            this.DS_Feriado.ST_LimpaCampo = true;
            this.DS_Feriado.ST_NotNull = true;
            this.DS_Feriado.ST_PrimaryKey = false;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // DT_Feriado
            // 
            this.DT_Feriado.AccessibleDescription = null;
            this.DT_Feriado.AccessibleName = null;
            resources.ApplyResources(this.DT_Feriado, "DT_Feriado");
            this.DT_Feriado.BackgroundImage = null;
            this.DT_Feriado.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadFeriado, "DtFeriado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Feriado.Name = "DT_Feriado";
            this.DT_Feriado.NM_Alias = "";
            this.DT_Feriado.NM_Campo = "DT_Feriado";
            this.DT_Feriado.NM_CampoBusca = "DT_Feriado";
            this.DT_Feriado.NM_Param = "@P_DT_FERIADO";
            this.DT_Feriado.Operador = "";
            this.DT_Feriado.ST_Gravar = true;
            this.DT_Feriado.ST_LimpaCampo = true;
            this.DT_Feriado.ST_NotNull = true;
            this.DT_Feriado.ST_PrimaryKey = false;
            // 
            // ST_RepeteAnual
            // 
            this.ST_RepeteAnual.AccessibleDescription = null;
            this.ST_RepeteAnual.AccessibleName = null;
            resources.ApplyResources(this.ST_RepeteAnual, "ST_RepeteAnual");
            this.ST_RepeteAnual.BackgroundImage = null;
            this.ST_RepeteAnual.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BS_CadFeriado, "St_RepeteAnual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_RepeteAnual.Name = "ST_RepeteAnual";
            this.ST_RepeteAnual.NM_Alias = "";
            this.ST_RepeteAnual.NM_Campo = "ST_RepeteAnual";
            this.ST_RepeteAnual.NM_Param = "@P_ST_REPETEANUAL";
            this.ST_RepeteAnual.ST_Gravar = true;
            this.ST_RepeteAnual.ST_LimparCampo = true;
            this.ST_RepeteAnual.ST_NotNull = false;
            this.ST_RepeteAnual.UseVisualStyleBackColor = true;
            this.ST_RepeteAnual.Vl_False = "N";
            this.ST_RepeteAnual.Vl_True = "S";
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Descricao,
            this.Data,
            this.dataGridViewCheckBoxColumn1,
            this.idFeriadoDataGridViewTextBoxColumn,
            this.iDFeriadoStringDataGridViewTextBoxColumn,
            this.dsFeriadoDataGridViewTextBoxColumn,
            this.dtFeriadoDataGridViewTextBoxColumn,
            this.dtFeriadoDataGridViewTextBoxColumn1,
            this.stRepeteAnualDataGridViewCheckBoxColumn});
            this.gCadastro.DataSource = this.BS_CadFeriado;
            this.gCadastro.Font = null;
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            // 
            // Cod
            // 
            this.Cod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cod.DataPropertyName = "Id_Feriado";
            resources.ApplyResources(this.Cod, "Cod");
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descricao.DataPropertyName = "DS_Feriado";
            resources.ApplyResources(this.Descricao, "Descricao");
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Data.DataPropertyName = "DT_Feriado";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.Data, "Data");
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "St_RepeteAnual";
            resources.ApplyResources(this.dataGridViewCheckBoxColumn1, "dataGridViewCheckBoxColumn1");
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // idFeriadoDataGridViewTextBoxColumn
            // 
            this.idFeriadoDataGridViewTextBoxColumn.DataPropertyName = "Id_Feriado";
            resources.ApplyResources(this.idFeriadoDataGridViewTextBoxColumn, "idFeriadoDataGridViewTextBoxColumn");
            this.idFeriadoDataGridViewTextBoxColumn.Name = "idFeriadoDataGridViewTextBoxColumn";
            this.idFeriadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDFeriadoStringDataGridViewTextBoxColumn
            // 
            this.iDFeriadoStringDataGridViewTextBoxColumn.DataPropertyName = "ID_Feriado_String";
            resources.ApplyResources(this.iDFeriadoStringDataGridViewTextBoxColumn, "iDFeriadoStringDataGridViewTextBoxColumn");
            this.iDFeriadoStringDataGridViewTextBoxColumn.Name = "iDFeriadoStringDataGridViewTextBoxColumn";
            this.iDFeriadoStringDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsFeriadoDataGridViewTextBoxColumn
            // 
            this.dsFeriadoDataGridViewTextBoxColumn.DataPropertyName = "Ds_Feriado";
            resources.ApplyResources(this.dsFeriadoDataGridViewTextBoxColumn, "dsFeriadoDataGridViewTextBoxColumn");
            this.dsFeriadoDataGridViewTextBoxColumn.Name = "dsFeriadoDataGridViewTextBoxColumn";
            this.dsFeriadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtFeriadoDataGridViewTextBoxColumn
            // 
            this.dtFeriadoDataGridViewTextBoxColumn.DataPropertyName = "Dt_Feriado";
            resources.ApplyResources(this.dtFeriadoDataGridViewTextBoxColumn, "dtFeriadoDataGridViewTextBoxColumn");
            this.dtFeriadoDataGridViewTextBoxColumn.Name = "dtFeriadoDataGridViewTextBoxColumn";
            this.dtFeriadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dtFeriadoDataGridViewTextBoxColumn1
            // 
            this.dtFeriadoDataGridViewTextBoxColumn1.DataPropertyName = "DtFeriado";
            resources.ApplyResources(this.dtFeriadoDataGridViewTextBoxColumn1, "dtFeriadoDataGridViewTextBoxColumn1");
            this.dtFeriadoDataGridViewTextBoxColumn1.Name = "dtFeriadoDataGridViewTextBoxColumn1";
            this.dtFeriadoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // stRepeteAnualDataGridViewCheckBoxColumn
            // 
            this.stRepeteAnualDataGridViewCheckBoxColumn.DataPropertyName = "St_RepeteAnual";
            resources.ApplyResources(this.stRepeteAnualDataGridViewCheckBoxColumn, "stRepeteAnualDataGridViewCheckBoxColumn");
            this.stRepeteAnualDataGridViewCheckBoxColumn.Name = "stRepeteAnualDataGridViewCheckBoxColumn";
            this.stRepeteAnualDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.ST_RepeteAnual, 0, 0);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // BS_Navigator
            // 
            this.BS_Navigator.AccessibleDescription = null;
            this.BS_Navigator.AccessibleName = null;
            this.BS_Navigator.AddNewItem = null;
            resources.ApplyResources(this.BS_Navigator, "BS_Navigator");
            this.BS_Navigator.BackgroundImage = null;
            this.BS_Navigator.BindingSource = this.BS_CadFeriado;
            this.BS_Navigator.CountItem = this.bindingNavigatorCountItem;
            this.BS_Navigator.DeleteItem = null;
            this.BS_Navigator.Font = null;
            this.BS_Navigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.BS_Navigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BS_Navigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BS_Navigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BS_Navigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BS_Navigator.Name = "BS_Navigator";
            this.BS_Navigator.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.AccessibleDescription = null;
            this.bindingNavigatorSeparator2.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            // 
            // TFCadFeriado
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadFeriado";
            this.Load += new System.EventHandler(this.TFCadFeriado_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadFeriado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).EndInit();
            this.BS_Navigator.ResumeLayout(false);
            this.BS_Navigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault DS_Feriado;
        private Componentes.EditDefault Id_Feriado;
        private Componentes.EditData DT_Feriado;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault ST_RepeteAnual;
        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource BS_CadFeriado;
        private System.Windows.Forms.BindingNavigator BS_Navigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFeriadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDFeriadoStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsFeriadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFeriadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtFeriadoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stRepeteAnualDataGridViewCheckBoxColumn;


    }
}
