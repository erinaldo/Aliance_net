namespace Parametros.Config
{
    partial class TFCadConfigGer3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadConfigGer3));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label tp_dadoLabel;
            System.Windows.Forms.Label ds_finalidadeLabel;
            System.Windows.Forms.Label vl_dataLabel;
            System.Windows.Forms.Label vl_numericoLabel;
            System.Windows.Forms.Label vl_stringLabel;
            System.Windows.Forms.Label ds_parametroLabel;
            this.nConfigGer = new System.Windows.Forms.BindingNavigator(this.components);
            this.bsParamGer = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tList_RegParamGerDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ds_finalidade = new Componentes.EditDefault(this.components);
            this.ds_parametro = new Componentes.ComboBoxDefault(this.components);
            this.tp_dado = new Componentes.ComboBoxDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.vl_data = new Componentes.EditData(this.components);
            this.vl_numerico = new Componentes.EditFloat(this.components);
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.vl_string = new Componentes.EditDefault(this.components);
            this.vl_bool = new Componentes.CheckBoxDefault(this.components);
            tp_dadoLabel = new System.Windows.Forms.Label();
            ds_finalidadeLabel = new System.Windows.Forms.Label();
            vl_dataLabel = new System.Windows.Forms.Label();
            vl_numericoLabel = new System.Windows.Forms.Label();
            vl_stringLabel = new System.Windows.Forms.Label();
            ds_parametroLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nConfigGer)).BeginInit();
            this.nConfigGer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParamGer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegParamGerDataGridDefault)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_numerico)).BeginInit();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.radioGroup1);
            this.pDados.Controls.Add(this.ds_parametro);
            this.pDados.Controls.Add(this.tp_dado);
            this.pDados.Controls.Add(ds_finalidadeLabel);
            this.pDados.Controls.Add(this.ds_finalidade);
            this.pDados.Controls.Add(ds_parametroLabel);
            this.pDados.Controls.Add(tp_dadoLabel);
            this.pDados.Size = new System.Drawing.Size(659, 171);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(671, 365);
            // 
            // tpPadrao
            // 
            this.tpPadrao.AutoScroll = true;
            this.tpPadrao.Controls.Add(this.tList_RegParamGerDataGridDefault);
            this.tpPadrao.Size = new System.Drawing.Size(663, 339);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tList_RegParamGerDataGridDefault, 0);
            // 
            // nConfigGer
            // 
            this.nConfigGer.AddNewItem = null;
            this.nConfigGer.BindingSource = this.bsParamGer;
            this.nConfigGer.CountItem = this.bindingNavigatorCountItem;
            this.nConfigGer.CountItemFormat = "de {0}";
            this.nConfigGer.DeleteItem = null;
            this.nConfigGer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nConfigGer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.nConfigGer.Location = new System.Drawing.Point(0, 408);
            this.nConfigGer.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.nConfigGer.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.nConfigGer.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.nConfigGer.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.nConfigGer.Name = "nConfigGer";
            this.nConfigGer.PositionItem = this.bindingNavigatorPositionItem;
            this.nConfigGer.Size = new System.Drawing.Size(671, 25);
            this.nConfigGer.TabIndex = 2;
            this.nConfigGer.Text = "bindingNavigator1";
            // 
            // bsParamGer
            // 
            this.bsParamGer.DataSource = typeof(CamadaDados.ConfigGer.TRegistro_ParamGer);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registro";
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
            this.bindingNavigatorMoveNextItem.Text = "Próximo Registro";
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
            // tList_RegParamGerDataGridDefault
            // 
            this.tList_RegParamGerDataGridDefault.AllowUserToAddRows = false;
            this.tList_RegParamGerDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_RegParamGerDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.tList_RegParamGerDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tList_RegParamGerDataGridDefault.AutoGenerateColumns = false;
            this.tList_RegParamGerDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_RegParamGerDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_RegParamGerDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegParamGerDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tList_RegParamGerDataGridDefault.ColumnHeadersHeight = 18;
            this.tList_RegParamGerDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn1});
            this.tList_RegParamGerDataGridDefault.DataSource = this.bsParamGer;
            this.tList_RegParamGerDataGridDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tList_RegParamGerDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_RegParamGerDataGridDefault.Location = new System.Drawing.Point(0, 171);
            this.tList_RegParamGerDataGridDefault.Name = "tList_RegParamGerDataGridDefault";
            this.tList_RegParamGerDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_RegParamGerDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tList_RegParamGerDataGridDefault.RowHeadersWidth = 23;
            this.tList_RegParamGerDataGridDefault.Size = new System.Drawing.Size(659, 164);
            this.tList_RegParamGerDataGridDefault.TabIndex = 1;
            this.tList_RegParamGerDataGridDefault.TabStop = false;
            this.tList_RegParamGerDataGridDefault.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tList_RegParamGerDataGridDefault_CellContentClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Id_parametro";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cd. Parâmetro";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 99;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Ds_parametro";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descrição Parâmetro";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 131;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_finalidade";
            this.dataGridViewTextBoxColumn2.HeaderText = "Finalidade";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Tp_dado";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo Dado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 82;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Vl_string";
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor String";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 86;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Vl_numerico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Valor Numérico";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 104;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Vl_data";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor Data";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 82;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Vl_bool";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Valor Booleano";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 85;
            // 
            // tp_dadoLabel
            // 
            tp_dadoLabel.AutoSize = true;
            tp_dadoLabel.Location = new System.Drawing.Point(4, 63);
            tp_dadoLabel.Name = "tp_dadoLabel";
            tp_dadoLabel.Size = new System.Drawing.Size(60, 13);
            tp_dadoLabel.TabIndex = 6;
            tp_dadoLabel.Text = "Tipo Dado:";
            // 
            // ds_finalidade
            // 
            this.ds_finalidade.BackColor = System.Drawing.SystemColors.Window;
            this.ds_finalidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_finalidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamGer, "Ds_finalidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_finalidade.Enabled = false;
            this.ds_finalidade.Location = new System.Drawing.Point(69, 34);
            this.ds_finalidade.Name = "ds_finalidade";
            this.ds_finalidade.NM_Alias = "";
            this.ds_finalidade.NM_Campo = "";
            this.ds_finalidade.NM_CampoBusca = "";
            this.ds_finalidade.NM_Param = "";
            this.ds_finalidade.QTD_Zero = 0;
            this.ds_finalidade.Size = new System.Drawing.Size(582, 20);
            this.ds_finalidade.ST_AutoInc = false;
            this.ds_finalidade.ST_DisableAuto = false;
            this.ds_finalidade.ST_Float = false;
            this.ds_finalidade.ST_Gravar = true;
            this.ds_finalidade.ST_Int = false;
            this.ds_finalidade.ST_LimpaCampo = true;
            this.ds_finalidade.ST_NotNull = false;
            this.ds_finalidade.ST_PrimaryKey = false;
            this.ds_finalidade.TabIndex = 1;
            // 
            // ds_finalidadeLabel
            // 
            ds_finalidadeLabel.AutoSize = true;
            ds_finalidadeLabel.Location = new System.Drawing.Point(4, 37);
            ds_finalidadeLabel.Name = "ds_finalidadeLabel";
            ds_finalidadeLabel.Size = new System.Drawing.Size(58, 13);
            ds_finalidadeLabel.TabIndex = 0;
            ds_finalidadeLabel.Text = "Finalidade:";
            // 
            // ds_parametro
            // 
            this.ds_parametro.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsParamGer, "Ds_parametro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_parametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ds_parametro.Enabled = false;
            this.ds_parametro.FormattingEnabled = true;
            this.ds_parametro.Location = new System.Drawing.Point(68, 7);
            this.ds_parametro.Name = "ds_parametro";
            this.ds_parametro.NM_Alias = "";
            this.ds_parametro.NM_Campo = "";
            this.ds_parametro.NM_Param = "";
            this.ds_parametro.Size = new System.Drawing.Size(584, 21);
            this.ds_parametro.ST_Gravar = true;
            this.ds_parametro.ST_LimparCampo = true;
            this.ds_parametro.ST_NotNull = true;
            this.ds_parametro.TabIndex = 0;
            // 
            // tp_dado
            // 
            this.tp_dado.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsParamGer, "Tp_dado", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_dado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_dado.Enabled = false;
            this.tp_dado.FormattingEnabled = true;
            this.tp_dado.Location = new System.Drawing.Point(69, 60);
            this.tp_dado.Name = "tp_dado";
            this.tp_dado.NM_Alias = "";
            this.tp_dado.NM_Campo = "";
            this.tp_dado.NM_Param = "";
            this.tp_dado.Size = new System.Drawing.Size(121, 21);
            this.tp_dado.ST_Gravar = true;
            this.tp_dado.ST_LimparCampo = true;
            this.tp_dado.ST_NotNull = true;
            this.tp_dado.TabIndex = 2;
            this.tp_dado.SelectedIndexChanged += new System.EventHandler(this.tp_dado_SelectedIndexChanged);
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.vl_bool);
            this.panelDados1.Controls.Add(this.vl_string);
            this.panelDados1.Controls.Add(vl_stringLabel);
            this.panelDados1.Controls.Add(vl_numericoLabel);
            this.panelDados1.Controls.Add(this.vl_numerico);
            this.panelDados1.Controls.Add(this.vl_data);
            this.panelDados1.Controls.Add(vl_dataLabel);
            this.panelDados1.Location = new System.Drawing.Point(5, 13);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(572, 56);
            this.panelDados1.TabIndex = 0;
            // 
            // vl_dataLabel
            // 
            vl_dataLabel.AutoSize = true;
            vl_dataLabel.Location = new System.Drawing.Point(161, 31);
            vl_dataLabel.Name = "vl_dataLabel";
            vl_dataLabel.Size = new System.Drawing.Size(33, 13);
            vl_dataLabel.TabIndex = 10;
            vl_dataLabel.Text = "Data:";
            // 
            // vl_data
            // 
            this.vl_data.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamGer, "Vl_data", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "d"));
            this.vl_data.Enabled = false;
            this.vl_data.Location = new System.Drawing.Point(200, 29);
            this.vl_data.Mask = "00/00/0000";
            this.vl_data.Name = "vl_data";
            this.vl_data.NM_Alias = "";
            this.vl_data.NM_Campo = "";
            this.vl_data.NM_CampoBusca = "";
            this.vl_data.NM_Param = "";
            this.vl_data.Operador = "";
            this.vl_data.Size = new System.Drawing.Size(73, 20);
            this.vl_data.ST_Gravar = true;
            this.vl_data.ST_LimpaCampo = true;
            this.vl_data.ST_NotNull = false;
            this.vl_data.ST_PrimaryKey = false;
            this.vl_data.TabIndex = 2;
            this.vl_data.EnabledChanged += new System.EventHandler(this.vl_data_EnabledChanged);
            // 
            // vl_numerico
            // 
            this.vl_numerico.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsParamGer, "Vl_numerico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N0"));
            this.vl_numerico.Enabled = false;
            this.vl_numerico.Location = new System.Drawing.Point(54, 29);
            this.vl_numerico.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_numerico.Name = "vl_numerico";
            this.vl_numerico.NM_Alias = "";
            this.vl_numerico.NM_Campo = "";
            this.vl_numerico.NM_Param = "";
            this.vl_numerico.Operador = "";
            this.vl_numerico.Size = new System.Drawing.Size(102, 20);
            this.vl_numerico.ST_AutoInc = false;
            this.vl_numerico.ST_DisableAuto = false;
            this.vl_numerico.ST_Gravar = true;
            this.vl_numerico.ST_LimparCampo = true;
            this.vl_numerico.ST_NotNull = false;
            this.vl_numerico.ST_PrimaryKey = false;
            this.vl_numerico.TabIndex = 1;
            this.vl_numerico.EnabledChanged += new System.EventHandler(this.vl_numerico_EnabledChanged);
            // 
            // vl_numericoLabel
            // 
            vl_numericoLabel.AutoSize = true;
            vl_numericoLabel.Location = new System.Drawing.Point(-1, 31);
            vl_numericoLabel.Name = "vl_numericoLabel";
            vl_numericoLabel.Size = new System.Drawing.Size(55, 13);
            vl_numericoLabel.TabIndex = 12;
            vl_numericoLabel.Text = "Numérico:";
            // 
            // vl_stringLabel
            // 
            vl_stringLabel.AutoSize = true;
            vl_stringLabel.Location = new System.Drawing.Point(3, 6);
            vl_stringLabel.Name = "vl_stringLabel";
            vl_stringLabel.Size = new System.Drawing.Size(37, 13);
            vl_stringLabel.TabIndex = 14;
            vl_stringLabel.Text = "String:";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.panelDados1);
            this.radioGroup1.Location = new System.Drawing.Point(69, 87);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(583, 75);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Valores:";
            // 
            // vl_string
            // 
            this.vl_string.BackColor = System.Drawing.SystemColors.Window;
            this.vl_string.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.vl_string.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsParamGer, "Vl_string", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_string.Enabled = false;
            this.vl_string.Location = new System.Drawing.Point(54, 3);
            this.vl_string.Name = "vl_string";
            this.vl_string.NM_Alias = "";
            this.vl_string.NM_Campo = "";
            this.vl_string.NM_CampoBusca = "";
            this.vl_string.NM_Param = "";
            this.vl_string.QTD_Zero = 0;
            this.vl_string.Size = new System.Drawing.Size(512, 20);
            this.vl_string.ST_AutoInc = false;
            this.vl_string.ST_DisableAuto = false;
            this.vl_string.ST_Float = false;
            this.vl_string.ST_Gravar = true;
            this.vl_string.ST_Int = false;
            this.vl_string.ST_LimpaCampo = true;
            this.vl_string.ST_NotNull = false;
            this.vl_string.ST_PrimaryKey = false;
            this.vl_string.TabIndex = 0;
            this.vl_string.EnabledChanged += new System.EventHandler(this.vl_string_EnabledChanged);
            // 
            // ds_parametroLabel
            // 
            ds_parametroLabel.AutoSize = true;
            ds_parametroLabel.Location = new System.Drawing.Point(4, 10);
            ds_parametroLabel.Name = "ds_parametroLabel";
            ds_parametroLabel.Size = new System.Drawing.Size(58, 13);
            ds_parametroLabel.TabIndex = 2;
            ds_parametroLabel.Text = "Parâmetro:";
            // 
            // vl_bool
            // 
            this.vl_bool.AutoSize = true;
            this.vl_bool.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsParamGer, "Vl_bool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_bool.Location = new System.Drawing.Point(287, 31);
            this.vl_bool.Name = "vl_bool";
            this.vl_bool.NM_Alias = "";
            this.vl_bool.NM_Campo = "";
            this.vl_bool.NM_Param = "";
            this.vl_bool.Size = new System.Drawing.Size(71, 17);
            this.vl_bool.ST_Gravar = true;
            this.vl_bool.ST_LimparCampo = true;
            this.vl_bool.ST_NotNull = false;
            this.vl_bool.TabIndex = 3;
            this.vl_bool.Text = "Booleano";
            this.vl_bool.UseVisualStyleBackColor = true;
            this.vl_bool.Vl_False = "";
            this.vl_bool.Vl_True = "";
            this.vl_bool.EnabledChanged += new System.EventHandler(this.vl_bool_EnabledChanged);
            // 
            // TFCadConfigGer3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Controls.Add(this.nConfigGer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFCadConfigGer3";
            this.Text = "Cadastro de Configurações Gerenciais";
            this.Load += new System.EventHandler(this.TFCadConfigGer3_Load);
            this.Controls.SetChildIndex(this.nConfigGer, 0);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nConfigGer)).EndInit();
            this.nConfigGer.ResumeLayout(false);
            this.nConfigGer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsParamGer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList_RegParamGerDataGridDefault)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_numerico)).EndInit();
            this.radioGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault tList_RegParamGerDataGridDefault;
        private System.Windows.Forms.BindingSource bsParamGer;
        private System.Windows.Forms.BindingNavigator nConfigGer;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Componentes.RadioGroup radioGroup1;
        private Componentes.PanelDados panelDados1;
        private Componentes.CheckBoxDefault vl_bool;
        private Componentes.EditDefault vl_string;
        private Componentes.EditFloat vl_numerico;
        private Componentes.EditData vl_data;
        private Componentes.ComboBoxDefault ds_parametro;
        private Componentes.ComboBoxDefault tp_dado;
        private Componentes.EditDefault ds_finalidade;
    }
}
