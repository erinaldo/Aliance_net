namespace Financeiro.Cadastros
{
    partial class TFCadCondPGTO_X_Parcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCondPGTO_X_Parcelas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_gravar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.BS_CondPgtoXParcelas = new System.Windows.Forms.BindingSource(this.components);
            this.BS_CondPGTO = new System.Windows.Forms.BindingSource(this.components);
            this.pDadosGrid = new Componentes.PanelDados(this.components);
            this.gCondicaoXparcelas = new Componentes.DataGridDefault(this.components);
            this.cdcondpgtoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qt_dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pc_rateio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados = new Componentes.PanelDados(this.components);
            this.parcela = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.rateio = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dias_desdobro = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.num_parcelas = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_condpgto = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPgtoXParcelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPGTO)).BeginInit();
            this.pDadosGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCondicaoXparcelas)).BeginInit();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dias_desdobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_parcelas)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_gravar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(537, 43);
            this.barraMenu.TabIndex = 22;
            // 
            // bb_gravar
            // 
            this.bb_gravar.AutoSize = false;
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(95, 40);
            this.bb_gravar.Text = "(F4)\r\nGravar";
            this.bb_gravar.ToolTipText = "Inutilizar NF-e";
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
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
            // BS_CondPgtoXParcelas
            // 
            this.BS_CondPgtoXParcelas.DataMember = "lCondPgto_X_Parcelas";
            this.BS_CondPgtoXParcelas.DataSource = this.BS_CondPGTO;
            // 
            // BS_CondPGTO
            // 
            this.BS_CondPGTO.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadCondPgto);
            // 
            // pDadosGrid
            // 
            this.pDadosGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosGrid.Controls.Add(this.gCondicaoXparcelas);
            this.pDadosGrid.Location = new System.Drawing.Point(0, 112);
            this.pDadosGrid.Name = "pDadosGrid";
            this.pDadosGrid.NM_ProcDeletar = "";
            this.pDadosGrid.NM_ProcGravar = "";
            this.pDadosGrid.Size = new System.Drawing.Size(535, 186);
            this.pDadosGrid.TabIndex = 24;
            // 
            // gCondicaoXparcelas
            // 
            this.gCondicaoXparcelas.AllowUserToAddRows = false;
            this.gCondicaoXparcelas.AllowUserToDeleteRows = false;
            this.gCondicaoXparcelas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCondicaoXparcelas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCondicaoXparcelas.AutoGenerateColumns = false;
            this.gCondicaoXparcelas.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCondicaoXparcelas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCondicaoXparcelas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCondicaoXparcelas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCondicaoXparcelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCondicaoXparcelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdcondpgtoDataGridViewTextBoxColumn,
            this.Id_parcela,
            this.Qt_dias,
            this.Pc_rateio});
            this.gCondicaoXparcelas.DataSource = this.BS_CondPgtoXParcelas;
            this.gCondicaoXparcelas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCondicaoXparcelas.Location = new System.Drawing.Point(-2, -2);
            this.gCondicaoXparcelas.Name = "gCondicaoXparcelas";
            this.gCondicaoXparcelas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCondicaoXparcelas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCondicaoXparcelas.RowHeadersWidth = 23;
            this.gCondicaoXparcelas.Size = new System.Drawing.Size(537, 186);
            this.gCondicaoXparcelas.TabIndex = 2;
            // 
            // cdcondpgtoDataGridViewTextBoxColumn
            // 
            this.cdcondpgtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcondpgtoDataGridViewTextBoxColumn.DataPropertyName = "Cd_condpgto";
            this.cdcondpgtoDataGridViewTextBoxColumn.HeaderText = "Cond. Pgto";
            this.cdcondpgtoDataGridViewTextBoxColumn.Name = "cdcondpgtoDataGridViewTextBoxColumn";
            this.cdcondpgtoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcondpgtoDataGridViewTextBoxColumn.Width = 85;
            // 
            // Id_parcela
            // 
            this.Id_parcela.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Id_parcela.DataPropertyName = "Id_parcela";
            this.Id_parcela.HeaderText = "Parcela";
            this.Id_parcela.Name = "Id_parcela";
            this.Id_parcela.ReadOnly = true;
            this.Id_parcela.Width = 68;
            // 
            // Qt_dias
            // 
            this.Qt_dias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Qt_dias.DataPropertyName = "Qt_dias";
            this.Qt_dias.HeaderText = "Dias";
            this.Qt_dias.Name = "Qt_dias";
            this.Qt_dias.ReadOnly = true;
            this.Qt_dias.Width = 53;
            // 
            // Pc_rateio
            // 
            this.Pc_rateio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Pc_rateio.DataPropertyName = "Pc_rateio";
            this.Pc_rateio.HeaderText = "% Rateio";
            this.Pc_rateio.Name = "Pc_rateio";
            this.Pc_rateio.ReadOnly = true;
            this.Pc_rateio.Width = 74;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.parcela);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.rateio);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.dias_desdobro);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.num_parcelas);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_condpgto);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Location = new System.Drawing.Point(0, 44);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(535, 62);
            this.pDados.TabIndex = 23;
            // 
            // parcela
            // 
            this.parcela.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CondPgtoXParcelas, "Id_parcela", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.parcela.Enabled = false;
            this.parcela.Location = new System.Drawing.Point(236, 30);
            this.parcela.Name = "parcela";
            this.parcela.NM_Alias = "";
            this.parcela.NM_Campo = "";
            this.parcela.NM_Param = "";
            this.parcela.Operador = "";
            this.parcela.Size = new System.Drawing.Size(60, 20);
            this.parcela.ST_AutoInc = false;
            this.parcela.ST_DisableAuto = false;
            this.parcela.ST_Gravar = false;
            this.parcela.ST_LimparCampo = true;
            this.parcela.ST_NotNull = false;
            this.parcela.ST_PrimaryKey = false;
            this.parcela.TabIndex = 11;
            this.parcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.parcela.ThousandsSeparator = true;
            this.parcela.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(181, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Parcela:";
            // 
            // rateio
            // 
            this.rateio.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CondPgtoXParcelas, "Pc_rateio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rateio.DecimalPlaces = 2;
            this.rateio.Location = new System.Drawing.Point(467, 30);
            this.rateio.Name = "rateio";
            this.rateio.NM_Alias = "";
            this.rateio.NM_Campo = "";
            this.rateio.NM_Param = "";
            this.rateio.Operador = "";
            this.rateio.Size = new System.Drawing.Size(60, 20);
            this.rateio.ST_AutoInc = false;
            this.rateio.ST_DisableAuto = false;
            this.rateio.ST_Gravar = false;
            this.rateio.ST_LimparCampo = true;
            this.rateio.ST_NotNull = false;
            this.rateio.ST_PrimaryKey = false;
            this.rateio.TabIndex = 9;
            this.rateio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rateio.ThousandsSeparator = true;
            this.rateio.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.rateio.Leave += new System.EventHandler(this.rateio_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "% Rateio:";
            // 
            // dias_desdobro
            // 
            this.dias_desdobro.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CondPgtoXParcelas, "Qt_dias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dias_desdobro.Location = new System.Drawing.Point(339, 30);
            this.dias_desdobro.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.dias_desdobro.Name = "dias_desdobro";
            this.dias_desdobro.NM_Alias = "";
            this.dias_desdobro.NM_Campo = "";
            this.dias_desdobro.NM_Param = "";
            this.dias_desdobro.Operador = "";
            this.dias_desdobro.Size = new System.Drawing.Size(60, 20);
            this.dias_desdobro.ST_AutoInc = false;
            this.dias_desdobro.ST_DisableAuto = false;
            this.dias_desdobro.ST_Gravar = false;
            this.dias_desdobro.ST_LimparCampo = true;
            this.dias_desdobro.ST_NotNull = false;
            this.dias_desdobro.ST_PrimaryKey = false;
            this.dias_desdobro.TabIndex = 7;
            this.dias_desdobro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dias_desdobro.ThousandsSeparator = true;
            this.dias_desdobro.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(302, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dias:";
            // 
            // num_parcelas
            // 
            this.num_parcelas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CondPGTO, "Qt_parcelas", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.num_parcelas.Enabled = false;
            this.num_parcelas.Location = new System.Drawing.Point(117, 30);
            this.num_parcelas.Name = "num_parcelas";
            this.num_parcelas.NM_Alias = "";
            this.num_parcelas.NM_Campo = "";
            this.num_parcelas.NM_Param = "";
            this.num_parcelas.Operador = "";
            this.num_parcelas.Size = new System.Drawing.Size(60, 20);
            this.num_parcelas.ST_AutoInc = false;
            this.num_parcelas.ST_DisableAuto = false;
            this.num_parcelas.ST_Gravar = false;
            this.num_parcelas.ST_LimparCampo = true;
            this.num_parcelas.ST_NotNull = false;
            this.num_parcelas.ST_PrimaryKey = false;
            this.num_parcelas.TabIndex = 5;
            this.num_parcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_parcelas.ThousandsSeparator = true;
            this.num_parcelas.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Núm. Parcelas:";
            // 
            // ds_condpgto
            // 
            this.ds_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpgto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CondPGTO, "Ds_condpgto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_condpgto.Enabled = false;
            this.ds_condpgto.Location = new System.Drawing.Point(117, 8);
            this.ds_condpgto.Name = "ds_condpgto";
            this.ds_condpgto.NM_Alias = "";
            this.ds_condpgto.NM_Campo = "";
            this.ds_condpgto.NM_CampoBusca = "";
            this.ds_condpgto.NM_Param = "";
            this.ds_condpgto.QTD_Zero = 0;
            this.ds_condpgto.Size = new System.Drawing.Size(410, 20);
            this.ds_condpgto.ST_AutoInc = false;
            this.ds_condpgto.ST_DisableAuto = false;
            this.ds_condpgto.ST_Float = false;
            this.ds_condpgto.ST_Gravar = false;
            this.ds_condpgto.ST_Int = false;
            this.ds_condpgto.ST_LimpaCampo = true;
            this.ds_condpgto.ST_NotNull = false;
            this.ds_condpgto.ST_PrimaryKey = false;
            this.ds_condpgto.TabIndex = 3;
            this.ds_condpgto.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cond. Pagamento:";
            // 
            // TFCadCondPGTO_X_Parcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 302);
            this.Controls.Add(this.pDadosGrid);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.Name = "TFCadCondPGTO_X_Parcelas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condição de Pagamento X Parcelas";
            this.Load += new System.EventHandler(this.TFCadCondPGTO_X_Parcelas_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCondPGTO_X_Parcelas_FormClosing);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPgtoXParcelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CondPGTO)).EndInit();
            this.pDadosGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCondicaoXparcelas)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parcela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dias_desdobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_parcelas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_gravar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault ds_condpgto;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pDadosGrid;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat rateio;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat dias_desdobro;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat num_parcelas;
        private Componentes.DataGridDefault gCondicaoXparcelas;
        private System.Windows.Forms.BindingSource BS_CondPgtoXParcelas;
        private System.Windows.Forms.BindingSource BS_CondPGTO;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.EditFloat parcela;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcondpgtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qt_dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pc_rateio;


    }
}