namespace Locacao
{
    partial class TFParcelas
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFParcelas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gParcelas = new Componentes.DataGridDefault(this.components);
            this.BS_Parcelas = new System.Windows.Forms.BindingSource(this.components);
            this.bsLocacao = new System.Windows.Forms.BindingSource(this.components);
            this.BN_Parcelas = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.Parcelas_Entrada = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.st_ratearDespesas = new Componentes.CheckBoxDefault(this.components);
            this.vl_despesas = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Parcelas = new Componentes.EditFloat(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.bb_voltar = new System.Windows.Forms.Button();
            this.bb_avancar = new System.Windows.Forms.Button();
            this.dt_vencto = new Componentes.EditData(this.components);
            this.vl_total = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.St_faturadobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Parcelas)).BeginInit();
            this.BN_Parcelas.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_despesas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(15, -1);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 16);
            label1.TabIndex = 69;
            label1.Text = "Vencimento";
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(15, 50);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(88, 16);
            label4.TabIndex = 378;
            label4.Text = "Obs Cliente";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(682, 43);
            this.barraMenu.TabIndex = 10;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 414);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(674, 406);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(666, 398);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.gParcelas);
            this.panelDados2.Controls.Add(this.BN_Parcelas);
            this.panelDados2.Controls.Add(this.Parcelas_Entrada);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(4, 4);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(658, 239);
            this.panelDados2.TabIndex = 0;
            // 
            // gParcelas
            // 
            this.gParcelas.AllowUserToAddRows = false;
            this.gParcelas.AllowUserToDeleteRows = false;
            this.gParcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gParcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gParcelas.AutoGenerateColumns = false;
            this.gParcelas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gParcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gParcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gParcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gParcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.St_faturadobool,
            this.idparcelaDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.vlparcelaDataGridViewTextBoxColumn});
            this.gParcelas.DataSource = this.BS_Parcelas;
            this.gParcelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gParcelas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gParcelas.Location = new System.Drawing.Point(0, 0);
            this.gParcelas.MultiSelect = false;
            this.gParcelas.Name = "gParcelas";
            this.gParcelas.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gParcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gParcelas.RowHeadersWidth = 23;
            this.gParcelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gParcelas.Size = new System.Drawing.Size(658, 214);
            this.gParcelas.TabIndex = 2;
            this.gParcelas.TabStop = false;
            // 
            // BS_Parcelas
            // 
            this.BS_Parcelas.DataMember = "lParc";
            this.BS_Parcelas.DataSource = this.bsLocacao;
            // 
            // bsLocacao
            // 
            this.bsLocacao.DataSource = typeof(CamadaDados.Locacao.TList_Locacao);
            // 
            // BN_Parcelas
            // 
            this.BN_Parcelas.AddNewItem = null;
            this.BN_Parcelas.BindingSource = this.BS_Parcelas;
            this.BN_Parcelas.CountItem = this.bindingNavigatorCountItem;
            this.BN_Parcelas.CountItemFormat = "de {0}";
            this.BN_Parcelas.DeleteItem = null;
            this.BN_Parcelas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BN_Parcelas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Parcelas.Location = new System.Drawing.Point(0, 214);
            this.BN_Parcelas.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Parcelas.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Parcelas.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Parcelas.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Parcelas.Name = "BN_Parcelas";
            this.BN_Parcelas.PositionItem = this.bindingNavigatorPositionItem;
            this.BN_Parcelas.Size = new System.Drawing.Size(658, 25);
            this.BN_Parcelas.TabIndex = 4;
            this.BN_Parcelas.Text = "bindingNavigator1";
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
            // Parcelas_Entrada
            // 
            this.Parcelas_Entrada.BackColor = System.Drawing.SystemColors.Window;
            this.Parcelas_Entrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Parcelas_Entrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Parcelas_Entrada.Enabled = false;
            this.Parcelas_Entrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Parcelas_Entrada.Location = new System.Drawing.Point(115, 66);
            this.Parcelas_Entrada.Name = "Parcelas_Entrada";
            this.Parcelas_Entrada.NM_Alias = "";
            this.Parcelas_Entrada.NM_Campo = "ST_ComEntrada";
            this.Parcelas_Entrada.NM_CampoBusca = "ST_ComEntrada";
            this.Parcelas_Entrada.NM_Param = "@P_ST_COMENTRADA";
            this.Parcelas_Entrada.QTD_Zero = 0;
            this.Parcelas_Entrada.ReadOnly = true;
            this.Parcelas_Entrada.Size = new System.Drawing.Size(37, 20);
            this.Parcelas_Entrada.ST_AutoInc = false;
            this.Parcelas_Entrada.ST_DisableAuto = false;
            this.Parcelas_Entrada.ST_Float = false;
            this.Parcelas_Entrada.ST_Gravar = false;
            this.Parcelas_Entrada.ST_Int = false;
            this.Parcelas_Entrada.ST_LimpaCampo = true;
            this.Parcelas_Entrada.ST_NotNull = false;
            this.Parcelas_Entrada.ST_PrimaryKey = false;
            this.Parcelas_Entrada.TabIndex = 0;
            this.Parcelas_Entrada.TextOld = null;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.Silver;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(label4);
            this.panelDados1.Controls.Add(this.ds_observacao);
            this.panelDados1.Controls.Add(this.st_ratearDespesas);
            this.panelDados1.Controls.Add(this.vl_despesas);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.Parcelas);
            this.panelDados1.Controls.Add(this.label23);
            this.panelDados1.Controls.Add(this.bb_voltar);
            this.panelDados1.Controls.Add(this.bb_avancar);
            this.panelDados1.Controls.Add(label1);
            this.panelDados1.Controls.Add(this.dt_vencto);
            this.panelDados1.Controls.Add(this.vl_total);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 250);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(658, 144);
            this.panelDados1.TabIndex = 1;
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_observacao.Location = new System.Drawing.Point(13, 69);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "a";
            this.ds_observacao.NM_Campo = "ID_Regiao";
            this.ds_observacao.NM_CampoBusca = "ID_Regiao";
            this.ds_observacao.NM_Param = "@P_ID_REGIAO";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.ReadOnly = true;
            this.ds_observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ds_observacao.Size = new System.Drawing.Size(638, 70);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 377;
            this.ds_observacao.TextOld = null;
            // 
            // st_ratearDespesas
            // 
            this.st_ratearDespesas.AutoSize = true;
            this.st_ratearDespesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_ratearDespesas.Location = new System.Drawing.Point(305, 19);
            this.st_ratearDespesas.Name = "st_ratearDespesas";
            this.st_ratearDespesas.NM_Alias = "";
            this.st_ratearDespesas.NM_Campo = "";
            this.st_ratearDespesas.NM_Param = "";
            this.st_ratearDespesas.Size = new System.Drawing.Size(138, 17);
            this.st_ratearDespesas.ST_Gravar = false;
            this.st_ratearDespesas.ST_LimparCampo = true;
            this.st_ratearDespesas.ST_NotNull = false;
            this.st_ratearDespesas.TabIndex = 376;
            this.st_ratearDespesas.Text = "Ratear Vl.Despesas";
            this.st_ratearDespesas.UseVisualStyleBackColor = true;
            this.st_ratearDespesas.Vl_False = "";
            this.st_ratearDespesas.Vl_True = "";
            this.st_ratearDespesas.CheckedChanged += new System.EventHandler(this.st_ratearDespesas_CheckedChanged);
            // 
            // vl_despesas
            // 
            this.vl_despesas.DecimalPlaces = 2;
            this.vl_despesas.Enabled = false;
            this.vl_despesas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_despesas.Location = new System.Drawing.Point(217, 18);
            this.vl_despesas.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_despesas.Name = "vl_despesas";
            this.vl_despesas.NM_Alias = "";
            this.vl_despesas.NM_Campo = "";
            this.vl_despesas.NM_Param = "";
            this.vl_despesas.Operador = "";
            this.vl_despesas.Size = new System.Drawing.Size(85, 20);
            this.vl_despesas.ST_AutoInc = false;
            this.vl_despesas.ST_DisableAuto = false;
            this.vl_despesas.ST_Gravar = false;
            this.vl_despesas.ST_LimparCampo = true;
            this.vl_despesas.ST_NotNull = false;
            this.vl_despesas.ST_PrimaryKey = false;
            this.vl_despesas.TabIndex = 375;
            this.vl_despesas.TabStop = false;
            this.vl_despesas.ThousandsSeparator = true;
            this.vl_despesas.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(214, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 374;
            this.label3.Text = "Vl.Despesas";
            // 
            // Parcelas
            // 
            this.Parcelas.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Parcelas.Location = new System.Drawing.Point(451, 18);
            this.Parcelas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Parcelas.Name = "Parcelas";
            this.Parcelas.NM_Alias = "";
            this.Parcelas.NM_Campo = "QT_Parcelas";
            this.Parcelas.NM_Param = "@P_QT_PARCELAS";
            this.Parcelas.Operador = "";
            this.Parcelas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Parcelas.Size = new System.Drawing.Size(65, 20);
            this.Parcelas.ST_AutoInc = false;
            this.Parcelas.ST_DisableAuto = false;
            this.Parcelas.ST_Gravar = false;
            this.Parcelas.ST_LimparCampo = true;
            this.Parcelas.ST_NotNull = false;
            this.Parcelas.ST_PrimaryKey = false;
            this.Parcelas.TabIndex = 373;
            this.Parcelas.TabStop = false;
            this.Parcelas.ThousandsSeparator = true;
            this.Parcelas.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Parcelas.Leave += new System.EventHandler(this.Parcelas_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(448, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 372;
            this.label23.Text = "Nº Parcelas";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bb_voltar
            // 
            this.bb_voltar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_voltar.Location = new System.Drawing.Point(133, 25);
            this.bb_voltar.Name = "bb_voltar";
            this.bb_voltar.Size = new System.Drawing.Size(76, 26);
            this.bb_voltar.TabIndex = 77;
            this.bb_voltar.Text = "<<< Voltar";
            this.bb_voltar.UseVisualStyleBackColor = true;
            this.bb_voltar.Click += new System.EventHandler(this.bb_voltar_Click);
            // 
            // bb_avancar
            // 
            this.bb_avancar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_avancar.Location = new System.Drawing.Point(133, -2);
            this.bb_avancar.Name = "bb_avancar";
            this.bb_avancar.Size = new System.Drawing.Size(76, 26);
            this.bb_avancar.TabIndex = 76;
            this.bb_avancar.Text = "Avançar >>>";
            this.bb_avancar.UseVisualStyleBackColor = true;
            this.bb_avancar.Click += new System.EventHandler(this.bb_avancar_Click);
            // 
            // dt_vencto
            // 
            this.dt_vencto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_vencto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Parcelas, "Dt_vencto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_vencto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.dt_vencto.Location = new System.Drawing.Point(13, 18);
            this.dt_vencto.Mask = "00/00/0000";
            this.dt_vencto.Name = "dt_vencto";
            this.dt_vencto.NM_Alias = "";
            this.dt_vencto.NM_Campo = "";
            this.dt_vencto.NM_CampoBusca = "";
            this.dt_vencto.NM_Param = "";
            this.dt_vencto.Operador = "";
            this.dt_vencto.Size = new System.Drawing.Size(108, 26);
            this.dt_vencto.ST_Gravar = false;
            this.dt_vencto.ST_LimpaCampo = true;
            this.dt_vencto.ST_NotNull = false;
            this.dt_vencto.ST_PrimaryKey = false;
            this.dt_vencto.TabIndex = 0;
            this.dt_vencto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dt_vencto_KeyDown);
            this.dt_vencto.Leave += new System.EventHandler(this.dt_vencto_Leave);
            // 
            // vl_total
            // 
            this.vl_total.DecimalPlaces = 2;
            this.vl_total.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total.Location = new System.Drawing.Point(531, 18);
            this.vl_total.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_total.Name = "vl_total";
            this.vl_total.NM_Alias = "";
            this.vl_total.NM_Campo = "";
            this.vl_total.NM_Param = "";
            this.vl_total.Operador = "";
            this.vl_total.Size = new System.Drawing.Size(120, 20);
            this.vl_total.ST_AutoInc = false;
            this.vl_total.ST_DisableAuto = false;
            this.vl_total.ST_Gravar = false;
            this.vl_total.ST_LimparCampo = true;
            this.vl_total.ST_NotNull = false;
            this.vl_total.ST_PrimaryKey = false;
            this.vl_total.TabIndex = 3;
            this.vl_total.TabStop = false;
            this.vl_total.ThousandsSeparator = true;
            this.vl_total.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_total.Leave += new System.EventHandler(this.vl_total_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(528, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor Total";
            // 
            // St_faturadobool
            // 
            this.St_faturadobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_faturadobool.DataPropertyName = "St_faturadobool";
            this.St_faturadobool.HeaderText = "Faturado";
            this.St_faturadobool.Name = "St_faturadobool";
            this.St_faturadobool.ReadOnly = true;
            this.St_faturadobool.Width = 55;
            // 
            // idparcelaDataGridViewTextBoxColumn
            // 
            this.idparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idparcelaDataGridViewTextBoxColumn.DataPropertyName = "id_parcela";
            this.idparcelaDataGridViewTextBoxColumn.HeaderText = "Parcela";
            this.idparcelaDataGridViewTextBoxColumn.Name = "idparcelaDataGridViewTextBoxColumn";
            this.idparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idparcelaDataGridViewTextBoxColumn.Width = 68;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dtvenctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Dt.Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 102;
            // 
            // vlparcelaDataGridViewTextBoxColumn
            // 
            this.vlparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlparcelaDataGridViewTextBoxColumn.DataPropertyName = "Vl_parcela";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.vlparcelaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.vlparcelaDataGridViewTextBoxColumn.HeaderText = "Vl.Parcela";
            this.vlparcelaDataGridViewTextBoxColumn.Name = "vlparcelaDataGridViewTextBoxColumn";
            this.vlparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlparcelaDataGridViewTextBoxColumn.Width = 80;
            // 
            // TFParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 457);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TFParcelas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parcelas - Locação Mensal";
            this.Load += new System.EventHandler(this.TFParcelas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDT_Vencto_PreVenda_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLocacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Parcelas)).EndInit();
            this.BN_Parcelas.ResumeLayout(false);
            this.BN_Parcelas.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_despesas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Parcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_total)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Componentes.EditData dt_vencto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault gParcelas;
        private System.Windows.Forms.BindingNavigator BN_Parcelas;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault Parcelas_Entrada;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditFloat vl_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsLocacao;
        private System.Windows.Forms.BindingSource BS_Parcelas;
        private System.Windows.Forms.Button bb_avancar;
        private System.Windows.Forms.Button bb_voltar;
        private Componentes.EditFloat Parcelas;
        private System.Windows.Forms.Label label23;
        private Componentes.EditFloat vl_despesas;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_ratearDespesas;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_faturadobool;
        private System.Windows.Forms.DataGridViewTextBoxColumn idparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlparcelaDataGridViewTextBoxColumn;
    }
}