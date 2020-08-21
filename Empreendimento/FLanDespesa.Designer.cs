namespace Empreendimento
{
    partial class TFLanDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanDespesa));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.vl_subtotal = new Componentes.EditFloat(this.components);
            this.bsDespesa = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.qtd = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_unitario = new Componentes.EditFloat(this.components);
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dscargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmpdiasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(603, 43);
            this.barraMenu.TabIndex = 11;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.vl_subtotal);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.qtd);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vl_unitario);
            this.pDados.Controls.Add(this.ds_despesa);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(603, 60);
            this.pDados.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Vl.SubTotal";
            // 
            // vl_subtotal
            // 
            this.vl_subtotal.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesa, "Vl_subtotal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_subtotal.DecimalPlaces = 2;
            this.vl_subtotal.Enabled = false;
            this.vl_subtotal.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_subtotal.Location = new System.Drawing.Point(402, 31);
            this.vl_subtotal.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.vl_subtotal.Name = "vl_subtotal";
            this.vl_subtotal.NM_Alias = "";
            this.vl_subtotal.NM_Campo = "";
            this.vl_subtotal.NM_Param = "";
            this.vl_subtotal.Operador = "";
            this.vl_subtotal.Size = new System.Drawing.Size(88, 20);
            this.vl_subtotal.ST_AutoInc = false;
            this.vl_subtotal.ST_DisableAuto = false;
            this.vl_subtotal.ST_Gravar = true;
            this.vl_subtotal.ST_LimparCampo = true;
            this.vl_subtotal.ST_NotNull = false;
            this.vl_subtotal.ST_PrimaryKey = false;
            this.vl_subtotal.TabIndex = 5;
            this.vl_subtotal.ThousandsSeparator = true;
            this.vl_subtotal.Leave += new System.EventHandler(this.vl_subtotal_Leave);
            // 
            // bsDespesa
            // 
            this.bsDespesa.DataSource = typeof(CamadaDados.Empreendimento.TList_Despesas);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Quantidade:";
            // 
            // qtd
            // 
            this.qtd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesa, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd.DecimalPlaces = 3;
            this.qtd.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.qtd.Location = new System.Drawing.Point(72, 31);
            this.qtd.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.qtd.Name = "qtd";
            this.qtd.NM_Alias = "";
            this.qtd.NM_Campo = "";
            this.qtd.NM_Param = "";
            this.qtd.Operador = "";
            this.qtd.Size = new System.Drawing.Size(91, 20);
            this.qtd.ST_AutoInc = false;
            this.qtd.ST_DisableAuto = false;
            this.qtd.ST_Gravar = true;
            this.qtd.ST_LimparCampo = true;
            this.qtd.ST_NotNull = false;
            this.qtd.ST_PrimaryKey = false;
            this.qtd.TabIndex = 3;
            this.qtd.ThousandsSeparator = true;
            this.qtd.Leave += new System.EventHandler(this.qtd_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Valor Unitario";
            // 
            // vl_unitario
            // 
            this.vl_unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDespesa, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_unitario.DecimalPlaces = 2;
            this.vl_unitario.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_unitario.Location = new System.Drawing.Point(243, 31);
            this.vl_unitario.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.vl_unitario.Name = "vl_unitario";
            this.vl_unitario.NM_Alias = "";
            this.vl_unitario.NM_Campo = "";
            this.vl_unitario.NM_Param = "";
            this.vl_unitario.Operador = "";
            this.vl_unitario.Size = new System.Drawing.Size(85, 20);
            this.vl_unitario.ST_AutoInc = false;
            this.vl_unitario.ST_DisableAuto = false;
            this.vl_unitario.ST_Gravar = true;
            this.vl_unitario.ST_LimparCampo = true;
            this.vl_unitario.ST_NotNull = false;
            this.vl_unitario.ST_PrimaryKey = false;
            this.vl_unitario.TabIndex = 4;
            this.vl_unitario.ThousandsSeparator = true;
            this.vl_unitario.Leave += new System.EventHandler(this.vl_unitario_Leave);
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDespesa, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(71, 3);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "";
            this.ds_despesa.NM_CampoBusca = "";
            this.ds_despesa.NM_Param = "";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(524, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = true;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = true;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 0;
            this.ds_despesa.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Despesa:";
            // 
            // dscargoDataGridViewTextBoxColumn
            // 
            this.dscargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dscargoDataGridViewTextBoxColumn.DataPropertyName = "Ds_cargo";
            this.dscargoDataGridViewTextBoxColumn.HeaderText = "Cargo";
            this.dscargoDataGridViewTextBoxColumn.Name = "dscargoDataGridViewTextBoxColumn";
            this.dscargoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tmpdiasDataGridViewTextBoxColumn
            // 
            this.tmpdiasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tmpdiasDataGridViewTextBoxColumn.DataPropertyName = "Tmp_dias";
            this.tmpdiasDataGridViewTextBoxColumn.HeaderText = "Tempo em dias";
            this.tmpdiasDataGridViewTextBoxColumn.Name = "tmpdiasDataGridViewTextBoxColumn";
            this.tmpdiasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl. Unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlsubtotalDataGridViewTextBoxColumn
            // 
            this.vlsubtotalDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlsubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.HeaderText = "Vl. Subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.Name = "vlsubtotalDataGridViewTextBoxColumn";
            this.vlsubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TFLanDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 103);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLanDespesa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Despesas";
            this.Load += new System.EventHandler(this.FLanDespesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLanDespesa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_subtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDespesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.BindingSource bsDespesa;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat vl_subtotal;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat qtd;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_unitario;
        private Componentes.EditDefault ds_despesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dscargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmpdiasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
    }
}