namespace Fiscal.Cadastros
{
    partial class TFCadImposto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadImposto));
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bs_CadImposto = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.gridImposto = new Componentes.DataGridDefault(this.components);
            this.rgImposto = new Componentes.RadioGroup(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.st_ii = new Componentes.RadioButtonDefault(this.components);
            this.st_ipi = new Componentes.RadioButtonDefault(this.components);
            this.rbInss = new Componentes.RadioButtonDefault(this.components);
            this.rbIrrf = new Componentes.RadioButtonDefault(this.components);
            this.rbCsll = new Componentes.RadioButtonDefault(this.components);
            this.rbIssqn = new Componentes.RadioButtonDefault(this.components);
            this.rbIcms = new Componentes.RadioButtonDefault(this.components);
            this.rbCofins = new Componentes.RadioButtonDefault(this.components);
            this.rbPis = new Componentes.RadioButtonDefault(this.components);
            this.bn_CadImposto = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.st_funrural = new Componentes.RadioButtonDefault(this.components);
            this.st_senar = new Componentes.RadioButtonDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsimpostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_pis = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_cofins = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_issqn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_csll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_irrf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_inss = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_icms = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_ipibool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_iibool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_outros = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadImposto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImposto)).BeginInit();
            this.rgImposto.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadImposto)).BeginInit();
            this.bn_CadImposto.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.rgImposto);
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_IMPOSTO";
            this.pDados.NM_ProcGravar = "IA_FIS_IMPOSTO";
            this.pDados.Size = new System.Drawing.Size(822, 166);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(834, 419);
            this.tcCentral.TabIndex = 0;
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gridImposto);
            this.tpPadrao.Controls.Add(this.bn_CadImposto);
            this.tpPadrao.Size = new System.Drawing.Size(826, 393);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bn_CadImposto, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gridImposto, 0);
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadImposto, "ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(73, 36);
            this.ds_imposto.MaxLength = 45;
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_DS_IMPOSTO";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.Size = new System.Drawing.Size(591, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = true;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = true;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 1;
            this.ds_imposto.TextOld = null;
            // 
            // bs_CadImposto
            // 
            this.bs_CadImposto.DataSource = typeof(CamadaDados.Fiscal.TList_CadImposto);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Imposto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Código:";
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadImposto, "Cd_impostoSt", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_imposto.Enabled = false;
            this.cd_imposto.Location = new System.Drawing.Point(73, 10);
            this.cd_imposto.MaxLength = 3;
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_IMPOSTO";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.Size = new System.Drawing.Size(66, 20);
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = true;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = true;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = true;
            this.cd_imposto.TabIndex = 0;
            this.cd_imposto.TextOld = null;
            // 
            // gridImposto
            // 
            this.gridImposto.AllowUserToAddRows = false;
            this.gridImposto.AllowUserToDeleteRows = false;
            this.gridImposto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gridImposto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridImposto.AutoGenerateColumns = false;
            this.gridImposto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridImposto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridImposto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridImposto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridImposto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImposto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dsimpostoDataGridViewTextBoxColumn,
            this.Sigla,
            this.st_pis,
            this.st_cofins,
            this.st_issqn,
            this.st_csll,
            this.st_irrf,
            this.st_inss,
            this.st_icms,
            this.St_ipibool,
            this.St_iibool,
            this.st_outros,
            this.dataGridViewCheckBoxColumn1});
            this.gridImposto.DataSource = this.bs_CadImposto;
            this.gridImposto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridImposto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridImposto.Location = new System.Drawing.Point(0, 166);
            this.gridImposto.Name = "gridImposto";
            this.gridImposto.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridImposto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridImposto.RowHeadersWidth = 23;
            this.gridImposto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridImposto.Size = new System.Drawing.Size(822, 198);
            this.gridImposto.TabIndex = 1;
            this.gridImposto.TabStop = false;
            // 
            // rgImposto
            // 
            this.rgImposto.Controls.Add(this.panel1);
            this.rgImposto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rgImposto.Location = new System.Drawing.Point(73, 88);
            this.rgImposto.Name = "rgImposto";
            this.rgImposto.NM_Alias = "";
            this.rgImposto.NM_Campo = "";
            this.rgImposto.NM_Param = "";
            this.rgImposto.NM_Valor = "";
            this.rgImposto.Size = new System.Drawing.Size(591, 70);
            this.rgImposto.ST_Gravar = false;
            this.rgImposto.ST_NotNull = false;
            this.rgImposto.TabIndex = 3;
            this.rgImposto.TabStop = false;
            this.rgImposto.Text = "Impostos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.st_senar);
            this.panel1.Controls.Add(this.st_funrural);
            this.panel1.Controls.Add(this.st_ii);
            this.panel1.Controls.Add(this.st_ipi);
            this.panel1.Controls.Add(this.rbInss);
            this.panel1.Controls.Add(this.rbIrrf);
            this.panel1.Controls.Add(this.rbCsll);
            this.panel1.Controls.Add(this.rbIssqn);
            this.panel1.Controls.Add(this.rbIcms);
            this.panel1.Controls.Add(this.rbCofins);
            this.panel1.Controls.Add(this.rbPis);
            this.panel1.Location = new System.Drawing.Point(6, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 51);
            this.panel1.TabIndex = 0;
            // 
            // st_ii
            // 
            this.st_ii.AutoSize = true;
            this.st_ii.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_II", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_ii.Location = new System.Drawing.Point(460, 6);
            this.st_ii.Name = "st_ii";
            this.st_ii.Size = new System.Drawing.Size(33, 17);
            this.st_ii.TabIndex = 9;
            this.st_ii.Text = "II";
            this.st_ii.UseVisualStyleBackColor = true;
            this.st_ii.Valor = "";
            // 
            // st_ipi
            // 
            this.st_ipi.AutoSize = true;
            this.st_ipi.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_IPI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_ipi.Location = new System.Drawing.Point(413, 6);
            this.st_ipi.Name = "st_ipi";
            this.st_ipi.Size = new System.Drawing.Size(41, 17);
            this.st_ipi.TabIndex = 8;
            this.st_ipi.Text = "IPI";
            this.st_ipi.UseVisualStyleBackColor = true;
            this.st_ipi.Valor = "";
            // 
            // rbInss
            // 
            this.rbInss.AutoSize = true;
            this.rbInss.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_INSS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbInss.Location = new System.Drawing.Point(353, 6);
            this.rbInss.Name = "rbInss";
            this.rbInss.Size = new System.Drawing.Size(54, 17);
            this.rbInss.TabIndex = 6;
            this.rbInss.Text = "INSS";
            this.rbInss.UseVisualStyleBackColor = true;
            this.rbInss.Valor = "";
            // 
            // rbIrrf
            // 
            this.rbIrrf.AutoSize = true;
            this.rbIrrf.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_IRRF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbIrrf.Location = new System.Drawing.Point(297, 6);
            this.rbIrrf.Name = "rbIrrf";
            this.rbIrrf.Size = new System.Drawing.Size(54, 17);
            this.rbIrrf.TabIndex = 5;
            this.rbIrrf.Text = "IRRF";
            this.rbIrrf.UseVisualStyleBackColor = true;
            this.rbIrrf.Valor = "";
            // 
            // rbCsll
            // 
            this.rbCsll.AutoSize = true;
            this.rbCsll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_CSLL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbCsll.Location = new System.Drawing.Point(240, 6);
            this.rbCsll.Name = "rbCsll";
            this.rbCsll.Size = new System.Drawing.Size(55, 17);
            this.rbCsll.TabIndex = 4;
            this.rbCsll.Text = "CSLL";
            this.rbCsll.UseVisualStyleBackColor = true;
            this.rbCsll.Valor = "";
            // 
            // rbIssqn
            // 
            this.rbIssqn.AutoSize = true;
            this.rbIssqn.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_ISSQN", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbIssqn.Location = new System.Drawing.Point(176, 6);
            this.rbIssqn.Name = "rbIssqn";
            this.rbIssqn.Size = new System.Drawing.Size(63, 17);
            this.rbIssqn.TabIndex = 3;
            this.rbIssqn.Text = "ISSQN";
            this.rbIssqn.UseVisualStyleBackColor = true;
            this.rbIssqn.Valor = "";
            // 
            // rbIcms
            // 
            this.rbIcms.AutoSize = true;
            this.rbIcms.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_ICMS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbIcms.Location = new System.Drawing.Point(119, 6);
            this.rbIcms.Name = "rbIcms";
            this.rbIcms.Size = new System.Drawing.Size(55, 17);
            this.rbIcms.TabIndex = 2;
            this.rbIcms.Text = "ICMS";
            this.rbIcms.UseVisualStyleBackColor = true;
            this.rbIcms.Valor = "";
            // 
            // rbCofins
            // 
            this.rbCofins.AutoSize = true;
            this.rbCofins.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_Cofins", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbCofins.Location = new System.Drawing.Point(49, 6);
            this.rbCofins.Name = "rbCofins";
            this.rbCofins.Size = new System.Drawing.Size(70, 17);
            this.rbCofins.TabIndex = 1;
            this.rbCofins.Text = "COFINS";
            this.rbCofins.UseVisualStyleBackColor = true;
            this.rbCofins.Valor = "";
            // 
            // rbPis
            // 
            this.rbPis.AutoSize = true;
            this.rbPis.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_PIS", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rbPis.Location = new System.Drawing.Point(1, 6);
            this.rbPis.Name = "rbPis";
            this.rbPis.Size = new System.Drawing.Size(45, 17);
            this.rbPis.TabIndex = 0;
            this.rbPis.Text = "PIS";
            this.rbPis.UseVisualStyleBackColor = true;
            this.rbPis.Valor = "S";
            // 
            // bn_CadImposto
            // 
            this.bn_CadImposto.AddNewItem = null;
            this.bn_CadImposto.BindingSource = this.bs_CadImposto;
            this.bn_CadImposto.CountItem = this.bindingNavigatorCountItem;
            this.bn_CadImposto.DeleteItem = null;
            this.bn_CadImposto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bn_CadImposto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bn_CadImposto.Location = new System.Drawing.Point(0, 364);
            this.bn_CadImposto.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn_CadImposto.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn_CadImposto.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn_CadImposto.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn_CadImposto.Name = "bn_CadImposto";
            this.bn_CadImposto.PositionItem = this.bindingNavigatorPositionItem;
            this.bn_CadImposto.Size = new System.Drawing.Size(822, 25);
            this.bn_CadImposto.TabIndex = 3;
            this.bn_CadImposto.Text = "bindingNavigator1";
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
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bs_CadImposto, "Sigla", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(73, 62);
            this.editDefault1.MaxLength = 10;
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "ds_imposto";
            this.editDefault1.NM_CampoBusca = "ds_imposto";
            this.editDefault1.NM_Param = "@P_DS_IMPOSTO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(126, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 2;
            this.editDefault1.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sigla:";
            // 
            // st_funrural
            // 
            this.st_funrural.AutoSize = true;
            this.st_funrural.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_Funrural", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_funrural.Location = new System.Drawing.Point(1, 29);
            this.st_funrural.Name = "st_funrural";
            this.st_funrural.Size = new System.Drawing.Size(92, 17);
            this.st_funrural.TabIndex = 10;
            this.st_funrural.Text = "FUNRURAL";
            this.st_funrural.UseVisualStyleBackColor = true;
            this.st_funrural.Valor = "";
            // 
            // st_senar
            // 
            this.st_senar.AutoSize = true;
            this.st_senar.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bs_CadImposto, "St_Senar", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_senar.Location = new System.Drawing.Point(99, 29);
            this.st_senar.Name = "st_senar";
            this.st_senar.Size = new System.Drawing.Size(67, 17);
            this.st_senar.TabIndex = 11;
            this.st_senar.Text = "SENAR";
            this.st_senar.UseVisualStyleBackColor = true;
            this.st_senar.Valor = "";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_imposto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cd. Imposto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 88;
            // 
            // dsimpostoDataGridViewTextBoxColumn
            // 
            this.dsimpostoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsimpostoDataGridViewTextBoxColumn.DataPropertyName = "ds_imposto";
            this.dsimpostoDataGridViewTextBoxColumn.HeaderText = "Descrição Imposto";
            this.dsimpostoDataGridViewTextBoxColumn.Name = "dsimpostoDataGridViewTextBoxColumn";
            this.dsimpostoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsimpostoDataGridViewTextBoxColumn.Width = 110;
            // 
            // Sigla
            // 
            this.Sigla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Sigla.DataPropertyName = "Sigla";
            this.Sigla.HeaderText = "Sigla";
            this.Sigla.Name = "Sigla";
            this.Sigla.ReadOnly = true;
            this.Sigla.Width = 55;
            // 
            // st_pis
            // 
            this.st_pis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_pis.DataPropertyName = "St_PIS";
            this.st_pis.HeaderText = "PIS";
            this.st_pis.Name = "st_pis";
            this.st_pis.ReadOnly = true;
            this.st_pis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_pis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_pis.Width = 49;
            // 
            // st_cofins
            // 
            this.st_cofins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_cofins.DataPropertyName = "St_Cofins";
            this.st_cofins.HeaderText = "COFINS";
            this.st_cofins.Name = "st_cofins";
            this.st_cofins.ReadOnly = true;
            this.st_cofins.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_cofins.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_cofins.Width = 71;
            // 
            // st_issqn
            // 
            this.st_issqn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_issqn.DataPropertyName = "St_ISSQN";
            this.st_issqn.HeaderText = "ISSQN";
            this.st_issqn.Name = "st_issqn";
            this.st_issqn.ReadOnly = true;
            this.st_issqn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_issqn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_issqn.Width = 65;
            // 
            // st_csll
            // 
            this.st_csll.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_csll.DataPropertyName = "St_CSLL";
            this.st_csll.HeaderText = "CSLL";
            this.st_csll.Name = "st_csll";
            this.st_csll.ReadOnly = true;
            this.st_csll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_csll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_csll.Width = 58;
            // 
            // st_irrf
            // 
            this.st_irrf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_irrf.DataPropertyName = "St_IRRF";
            this.st_irrf.HeaderText = "IRRF";
            this.st_irrf.Name = "st_irrf";
            this.st_irrf.ReadOnly = true;
            this.st_irrf.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_irrf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_irrf.Width = 57;
            // 
            // st_inss
            // 
            this.st_inss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_inss.DataPropertyName = "St_INSS";
            this.st_inss.HeaderText = "INSS";
            this.st_inss.Name = "st_inss";
            this.st_inss.ReadOnly = true;
            this.st_inss.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_inss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_inss.Width = 57;
            // 
            // st_icms
            // 
            this.st_icms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_icms.DataPropertyName = "St_ICMS";
            this.st_icms.HeaderText = "ICMS";
            this.st_icms.Name = "st_icms";
            this.st_icms.ReadOnly = true;
            this.st_icms.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_icms.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_icms.Width = 58;
            // 
            // St_ipibool
            // 
            this.St_ipibool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_ipibool.DataPropertyName = "St_IPI";
            this.St_ipibool.HeaderText = "IPI";
            this.St_ipibool.Name = "St_ipibool";
            this.St_ipibool.ReadOnly = true;
            this.St_ipibool.Width = 26;
            // 
            // St_iibool
            // 
            this.St_iibool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_iibool.DataPropertyName = "St_II";
            this.St_iibool.HeaderText = "II";
            this.St_iibool.Name = "St_iibool";
            this.St_iibool.ReadOnly = true;
            this.St_iibool.Width = 19;
            // 
            // st_outros
            // 
            this.st_outros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.st_outros.DataPropertyName = "St_Funrural";
            this.st_outros.HeaderText = "FUNRURAL";
            this.st_outros.Name = "st_outros";
            this.st_outros.ReadOnly = true;
            this.st_outros.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.st_outros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.st_outros.Width = 91;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "St_Senar";
            this.dataGridViewCheckBoxColumn1.HeaderText = "SENAR";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // TFCadImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadImposto";
            this.Text = "Cadastro de Impostos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadImposto_FormClosing);
            this.Load += new System.EventHandler(this.TFCadImposto_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_CadImposto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImposto)).EndInit();
            this.rgImposto.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn_CadImposto)).EndInit();
            this.bn_CadImposto.ResumeLayout(false);
            this.bn_CadImposto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_imposto;
        private Componentes.DataGridDefault gridImposto;
        private System.Windows.Forms.BindingSource bs_CadImposto;
        private Componentes.RadioGroup rgImposto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator bn_CadImposto;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.RadioButtonDefault rbInss;
        private Componentes.RadioButtonDefault rbIrrf;
        private Componentes.RadioButtonDefault rbCsll;
        private Componentes.RadioButtonDefault rbIssqn;
        private Componentes.RadioButtonDefault rbIcms;
        private Componentes.RadioButtonDefault rbCofins;
        private Componentes.RadioButtonDefault rbPis;
        private Componentes.RadioButtonDefault st_ipi;
        private Componentes.RadioButtonDefault st_ii;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label3;
        private Componentes.RadioButtonDefault st_senar;
        private Componentes.RadioButtonDefault st_funrural;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsimpostoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sigla;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_pis;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_cofins;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_issqn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_csll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_irrf;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_inss;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_icms;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_ipibool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_iibool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_outros;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}
