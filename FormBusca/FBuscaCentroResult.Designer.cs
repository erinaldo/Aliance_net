namespace FormBusca
{
    partial class TFBuscaCentroResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBuscaCentroResult));
            System.Windows.Forms.Label label2;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Nat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCentroResult = new System.Windows.Forms.BindingSource(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gBusca = new Componentes.DataGridDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbResultado = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbSequencia = new System.Windows.Forms.ToolStripLabel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.cbFiltro = new Componentes.CheckBoxDefault(this.components);
            this.ds_centro = new Componentes.EditDefault(this.components);
            this.pSt_processar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pPathCentroresult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcentroresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDs_centroresultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiporegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stsinteticoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_deducaobool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBusca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1091, 552);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Nat
            // 
            this.Nat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nat.DataPropertyName = "Nat";
            this.Nat.HeaderText = "Natureza";
            this.Nat.Name = "Nat";
            this.Nat.ReadOnly = true;
            // 
            // bsCentroResult
            // 
            this.bsCentroResult.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CentroResultado);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.gBusca);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 42);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1085, 507);
            this.panelDados1.TabIndex = 0;
            // 
            // gBusca
            // 
            this.gBusca.AllowUserToAddRows = false;
            this.gBusca.AllowUserToDeleteRows = false;
            this.gBusca.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBusca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBusca.AutoGenerateColumns = false;
            this.gBusca.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBusca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBusca.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBusca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBusca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBusca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pSt_processar,
            this.pPathCentroresult,
            this.cdcentroresultDataGridViewTextBoxColumn,
            this.pDs_centroresultado,
            this.tiporegistroDataGridViewTextBoxColumn,
            this.stsinteticoboolDataGridViewCheckBoxColumn,
            this.St_deducaobool});
            this.gBusca.DataSource = this.bsCentroResult;
            this.gBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBusca.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBusca.Location = new System.Drawing.Point(0, 0);
            this.gBusca.Name = "gBusca";
            this.gBusca.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBusca.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gBusca.RowHeadersWidth = 23;
            this.gBusca.Size = new System.Drawing.Size(1083, 480);
            this.gBusca.TabIndex = 4;
            this.gBusca.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gBusca_CellClick);
            this.gBusca.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gBusca_CellFormatting);
            this.gBusca.DoubleClick += new System.EventHandler(this.gBusca_DoubleClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCentroResult;
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.lbResultado,
            this.toolStripSeparator2,
            this.lbSequencia});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 480);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1083, 25);
            this.bindingNavigator1.TabIndex = 3;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lbResultado
            // 
            this.lbResultado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbResultado.ForeColor = System.Drawing.Color.Blue;
            this.lbResultado.Name = "lbResultado";
            this.lbResultado.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbSequencia
            // 
            this.lbSequencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbSequencia.ForeColor = System.Drawing.Color.Blue;
            this.lbSequencia.Name = "lbSequencia";
            this.lbSequencia.Size = new System.Drawing.Size(0, 22);
            // 
            // panelDados2
            // 
            this.panelDados2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados2.Controls.Add(this.cbFiltro);
            this.panelDados2.Controls.Add(label2);
            this.panelDados2.Controls.Add(this.ds_centro);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(1085, 33);
            this.panelDados2.TabIndex = 1;
            // 
            // cbFiltro
            // 
            this.cbFiltro.AutoSize = true;
            this.cbFiltro.Location = new System.Drawing.Point(800, 7);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.NM_Alias = "";
            this.cbFiltro.NM_Campo = "";
            this.cbFiltro.NM_Param = "";
            this.cbFiltro.Size = new System.Drawing.Size(154, 17);
            this.cbFiltro.ST_Gravar = false;
            this.cbFiltro.ST_LimparCampo = true;
            this.cbFiltro.ST_NotNull = false;
            this.cbFiltro.TabIndex = 64;
            this.cbFiltro.Text = "Filtrar por Centro Resultado";
            this.cbFiltro.UseVisualStyleBackColor = true;
            this.cbFiltro.Vl_False = "";
            this.cbFiltro.Vl_True = "";
            this.cbFiltro.CheckedChanged += new System.EventHandler(this.cbFiltro_CheckedChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(23, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92, 13);
            label2.TabIndex = 63;
            label2.Text = "Centro Resultado:";
            // 
            // ds_centro
            // 
            this.ds_centro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centro.Location = new System.Drawing.Point(121, 6);
            this.ds_centro.Name = "ds_centro";
            this.ds_centro.NM_Alias = "";
            this.ds_centro.NM_Campo = "";
            this.ds_centro.NM_CampoBusca = "";
            this.ds_centro.NM_Param = "";
            this.ds_centro.QTD_Zero = 0;
            this.ds_centro.Size = new System.Drawing.Size(673, 20);
            this.ds_centro.ST_AutoInc = false;
            this.ds_centro.ST_DisableAuto = false;
            this.ds_centro.ST_Float = false;
            this.ds_centro.ST_Gravar = false;
            this.ds_centro.ST_Int = false;
            this.ds_centro.ST_LimpaCampo = true;
            this.ds_centro.ST_NotNull = false;
            this.ds_centro.ST_PrimaryKey = false;
            this.ds_centro.TabIndex = 0;
            this.ds_centro.TextOld = null;
            this.ds_centro.TextChanged += new System.EventHandler(this.ds_centro_TextChanged);
            // 
            // pSt_processar
            // 
            this.pSt_processar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pSt_processar.DataPropertyName = "St_processar";
            this.pSt_processar.HeaderText = "Add";
            this.pSt_processar.Name = "pSt_processar";
            this.pSt_processar.ReadOnly = true;
            this.pSt_processar.Visible = false;
            this.pSt_processar.Width = 32;
            // 
            // pPathCentroresult
            // 
            this.pPathCentroresult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pPathCentroresult.DataPropertyName = "PathCentroresult";
            this.pPathCentroresult.HeaderText = "Origem";
            this.pPathCentroresult.Name = "pPathCentroresult";
            this.pPathCentroresult.ReadOnly = true;
            this.pPathCentroresult.Visible = false;
            this.pPathCentroresult.Width = 65;
            // 
            // cdcentroresultDataGridViewTextBoxColumn
            // 
            this.cdcentroresultDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcentroresultDataGridViewTextBoxColumn.DataPropertyName = "Cd_centroresult";
            this.cdcentroresultDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.cdcentroresultDataGridViewTextBoxColumn.Name = "cdcentroresultDataGridViewTextBoxColumn";
            this.cdcentroresultDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcentroresultDataGridViewTextBoxColumn.Width = 65;
            // 
            // pDs_centroresultado
            // 
            this.pDs_centroresultado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pDs_centroresultado.DataPropertyName = "Ds_centroresultado";
            this.pDs_centroresultado.HeaderText = "Centro Resultado";
            this.pDs_centroresultado.Name = "pDs_centroresultado";
            this.pDs_centroresultado.ReadOnly = true;
            this.pDs_centroresultado.Width = 105;
            // 
            // tiporegistroDataGridViewTextBoxColumn
            // 
            this.tiporegistroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tiporegistroDataGridViewTextBoxColumn.DataPropertyName = "Tipo_registro";
            this.tiporegistroDataGridViewTextBoxColumn.HeaderText = "Movimento";
            this.tiporegistroDataGridViewTextBoxColumn.Name = "tiporegistroDataGridViewTextBoxColumn";
            this.tiporegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.tiporegistroDataGridViewTextBoxColumn.Width = 84;
            // 
            // stsinteticoboolDataGridViewCheckBoxColumn
            // 
            this.stsinteticoboolDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stsinteticoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_sinteticobool";
            this.stsinteticoboolDataGridViewCheckBoxColumn.HeaderText = "Sintetico";
            this.stsinteticoboolDataGridViewCheckBoxColumn.Name = "stsinteticoboolDataGridViewCheckBoxColumn";
            this.stsinteticoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stsinteticoboolDataGridViewCheckBoxColumn.Width = 54;
            // 
            // St_deducaobool
            // 
            this.St_deducaobool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_deducaobool.DataPropertyName = "St_deducaobool";
            this.St_deducaobool.HeaderText = "Conta Dedução";
            this.St_deducaobool.Name = "St_deducaobool";
            this.St_deducaobool.ReadOnly = true;
            this.St_deducaobool.Width = 79;
            // 
            // TFBuscaCentroResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TFBuscaCentroResult";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busca - Centro Resultado";
            this.Load += new System.EventHandler(this.TFBuscaCentroResult_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBuscaCentroResult_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCentroResult)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBusca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nat;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault ds_centro;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.BindingSource bsCentroResult;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gBusca;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbResultado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbSequencia;
        private Componentes.CheckBoxDefault cbFiltro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pSt_processar;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPathCentroresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcentroresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDs_centroresultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiporegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stsinteticoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_deducaobool;
    }
}