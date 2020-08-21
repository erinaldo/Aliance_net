namespace Gerencia.Financeiro
{
    partial class TFDetalhesCResultado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDetalhesCResultado));
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pDetalhes = new Componentes.PanelDados(this.components);
            this.gDetalhe = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdcentroresultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dscentroresultadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipomovimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vllanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtlanctostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDetalhe = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_alterarccusto = new System.Windows.Forms.ToolStripButton();
            this.pTotal = new Componentes.PanelDados(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tot_valor = new Componentes.EditFloat(this.components);
            this.tlpCentral.SuspendLayout();
            this.pDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDetalhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.pTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_valor)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDetalhes, 0, 0);
            this.tlpCentral.Controls.Add(this.pTotal, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlpCentral.Size = new System.Drawing.Size(938, 612);
            this.tlpCentral.TabIndex = 4;
            // 
            // pDetalhes
            // 
            this.pDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDetalhes.Controls.Add(this.gDetalhe);
            this.pDetalhes.Controls.Add(this.bindingNavigator1);
            this.pDetalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDetalhes.Location = new System.Drawing.Point(5, 5);
            this.pDetalhes.Name = "pDetalhes";
            this.pDetalhes.Size = new System.Drawing.Size(928, 558);
            this.pDetalhes.TabIndex = 3;
            // 
            // gDetalhe
            // 
            this.gDetalhe.AllowUserToAddRows = false;
            this.gDetalhe.AllowUserToDeleteRows = false;
            this.gDetalhe.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gDetalhe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gDetalhe.AutoGenerateColumns = false;
            this.gDetalhe.BackgroundColor = System.Drawing.Color.LightGray;
            this.gDetalhe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gDetalhe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDetalhe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gDetalhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gDetalhe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.cdcentroresultDataGridViewTextBoxColumn,
            this.dscentroresultadoDataGridViewTextBoxColumn,
            this.tipomovimentoDataGridViewTextBoxColumn,
            this.vllanctoDataGridViewTextBoxColumn,
            this.dtlanctostrDataGridViewTextBoxColumn});
            this.gDetalhe.DataSource = this.bsDetalhe;
            this.gDetalhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gDetalhe.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gDetalhe.Location = new System.Drawing.Point(0, 0);
            this.gDetalhe.Name = "gDetalhe";
            this.gDetalhe.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gDetalhe.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gDetalhe.RowHeadersWidth = 23;
            this.gDetalhe.Size = new System.Drawing.Size(924, 529);
            this.gDetalhe.TabIndex = 0;
            this.gDetalhe.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gDetalhe_ColumnHeaderMouseClick);
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd. Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 92;
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
            // dscentroresultadoDataGridViewTextBoxColumn
            // 
            this.dscentroresultadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscentroresultadoDataGridViewTextBoxColumn.DataPropertyName = "Ds_centroresultado";
            this.dscentroresultadoDataGridViewTextBoxColumn.HeaderText = "Centro Resultado";
            this.dscentroresultadoDataGridViewTextBoxColumn.Name = "dscentroresultadoDataGridViewTextBoxColumn";
            this.dscentroresultadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dscentroresultadoDataGridViewTextBoxColumn.Width = 105;
            // 
            // tipomovimentoDataGridViewTextBoxColumn
            // 
            this.tipomovimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tipomovimentoDataGridViewTextBoxColumn.DataPropertyName = "Tipo_movimento";
            this.tipomovimentoDataGridViewTextBoxColumn.HeaderText = "Movimento";
            this.tipomovimentoDataGridViewTextBoxColumn.Name = "tipomovimentoDataGridViewTextBoxColumn";
            this.tipomovimentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipomovimentoDataGridViewTextBoxColumn.Width = 84;
            // 
            // vllanctoDataGridViewTextBoxColumn
            // 
            this.vllanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vllanctoDataGridViewTextBoxColumn.DataPropertyName = "Vl_lancto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vllanctoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vllanctoDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.vllanctoDataGridViewTextBoxColumn.Name = "vllanctoDataGridViewTextBoxColumn";
            this.vllanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.vllanctoDataGridViewTextBoxColumn.Width = 56;
            // 
            // dtlanctostrDataGridViewTextBoxColumn
            // 
            this.dtlanctostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtlanctostrDataGridViewTextBoxColumn.DataPropertyName = "Dt_lancto";
            this.dtlanctostrDataGridViewTextBoxColumn.HeaderText = "Dt. Lancto";
            this.dtlanctostrDataGridViewTextBoxColumn.Name = "dtlanctostrDataGridViewTextBoxColumn";
            this.dtlanctostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtlanctostrDataGridViewTextBoxColumn.Width = 76;
            // 
            // bsDetalhe
            // 
            this.bsDetalhe.DataSource = typeof(CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsDetalhe;
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
            this.bb_alterarccusto});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 529);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(924, 25);
            this.bindingNavigator1.TabIndex = 1;
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
            // bb_alterarccusto
            // 
            this.bb_alterarccusto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bb_alterarccusto.Image = ((System.Drawing.Image)(resources.GetObject("bb_alterarccusto.Image")));
            this.bb_alterarccusto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_alterarccusto.Name = "bb_alterarccusto";
            this.bb_alterarccusto.Size = new System.Drawing.Size(177, 22);
            this.bb_alterarccusto.Text = "ALTERAR CENTRO RESULTADO";
            this.bb_alterarccusto.ToolTipText = "Alterar Centro Resultado";
            this.bb_alterarccusto.Click += new System.EventHandler(this.bb_alterarccusto_Click);
            // 
            // pTotal
            // 
            this.pTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.pTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTotal.Controls.Add(this.label1);
            this.pTotal.Controls.Add(this.tot_valor);
            this.pTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTotal.Location = new System.Drawing.Point(5, 571);
            this.pTotal.Name = "pTotal";
            this.pTotal.Size = new System.Drawing.Size(928, 36);
            this.pTotal.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor Total:";
            // 
            // tot_valor
            // 
            this.tot_valor.DecimalPlaces = 2;
            this.tot_valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tot_valor.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tot_valor.Location = new System.Drawing.Point(113, 4);
            this.tot_valor.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.tot_valor.Name = "tot_valor";
            this.tot_valor.ReadOnly = true;
            this.tot_valor.Size = new System.Drawing.Size(167, 26);
            this.tot_valor.ST_AutoInc = false;
            this.tot_valor.ST_DisableAuto = false;
            this.tot_valor.ST_Gravar = false;
            this.tot_valor.ST_LimparCampo = true;
            this.tot_valor.ST_NotNull = false;
            this.tot_valor.ST_PrimaryKey = false;
            this.tot_valor.TabIndex = 0;
            this.tot_valor.TabStop = false;
            this.tot_valor.ThousandsSeparator = true;
            // 
            // TFDetalhesCResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 612);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TFDetalhesCResultado";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes Centro Resultado";
            this.Load += new System.EventHandler(this.TFDetalhesCResultado_Load);
            this.tlpCentral.ResumeLayout(false);
            this.pDetalhes.ResumeLayout(false);
            this.pDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gDetalhe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalhe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.pTotal.ResumeLayout(false);
            this.pTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tot_valor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDetalhe;
        private Componentes.PanelDados pDetalhes;
        private Componentes.DataGridDefault gDetalhe;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bb_alterarccusto;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.DataGridViewTextBoxColumn idccustolanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsgrupocfDataGridViewTextBoxColumn;
        private Componentes.PanelDados pTotal;
        private System.Windows.Forms.Label label1;
        private Componentes.EditFloat tot_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcentroresultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscentroresultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipomovimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vllanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtlanctostrDataGridViewTextBoxColumn;
    }
}