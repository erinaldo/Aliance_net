namespace Empreendimento
{
    partial class FCompraEmpreendimentoDireto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompraEmpreendimentoDireto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsFichaDir = new System.Windows.Forms.BindingSource(this.components);
            this.stagregarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dsatividadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idcontatoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idregistrostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idorcamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idorcamentostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrversaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrversaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idprojetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idprojetostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idfichaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idfichastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlunitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlsubtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlultimacompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stfatdiretoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stfatdiretoboolDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qtdfaturadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdfaturarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeagregarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stcompostoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaDir)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar,
            this.toolStripSeparator1});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(804, 43);
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
            this.bb_inutilizar.ToolTipText = "Gravar";
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(804, 368);
            this.panelDados1.TabIndex = 12;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stagregarDataGridViewCheckBoxColumn,
            this.dsatividadeDataGridViewTextBoxColumn,
            this.idregistroDataGridViewTextBoxColumn,
            this.idcontatoDataGridViewTextBoxColumn,
            this.idregistrostrDataGridViewTextBoxColumn,
            this.cdempresaDataGridViewTextBoxColumn,
            this.idorcamentoDataGridViewTextBoxColumn,
            this.idorcamentostrDataGridViewTextBoxColumn,
            this.nrversaoDataGridViewTextBoxColumn,
            this.nrversaostrDataGridViewTextBoxColumn,
            this.idprojetoDataGridViewTextBoxColumn,
            this.idprojetostrDataGridViewTextBoxColumn,
            this.idfichaDataGridViewTextBoxColumn,
            this.idfichastrDataGridViewTextBoxColumn,
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.sgunidadeDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn,
            this.vlunitarioDataGridViewTextBoxColumn,
            this.vlsubtotalDataGridViewTextBoxColumn,
            this.vlultimacompraDataGridViewTextBoxColumn,
            this.stfatdiretoDataGridViewTextBoxColumn,
            this.stfatdiretoboolDataGridViewCheckBoxColumn,
            this.qtdfaturadaDataGridViewTextBoxColumn,
            this.sdfaturarDataGridViewTextBoxColumn,
            this.quantidadeagregarDataGridViewTextBoxColumn,
            this.stcompostoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsFichaDir;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(804, 368);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsFichaDir
            // 
            this.bsFichaDir.DataSource = typeof(CamadaDados.Empreendimento.TList_FichaTec);
            // 
            // stagregarDataGridViewCheckBoxColumn
            // 
            this.stagregarDataGridViewCheckBoxColumn.DataPropertyName = "st_agregar";
            this.stagregarDataGridViewCheckBoxColumn.HeaderText = "st_agregar";
            this.stagregarDataGridViewCheckBoxColumn.Name = "stagregarDataGridViewCheckBoxColumn";
            this.stagregarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dsatividadeDataGridViewTextBoxColumn
            // 
            this.dsatividadeDataGridViewTextBoxColumn.DataPropertyName = "ds_atividade";
            this.dsatividadeDataGridViewTextBoxColumn.HeaderText = "ds_atividade";
            this.dsatividadeDataGridViewTextBoxColumn.Name = "dsatividadeDataGridViewTextBoxColumn";
            this.dsatividadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idregistroDataGridViewTextBoxColumn
            // 
            this.idregistroDataGridViewTextBoxColumn.DataPropertyName = "Id_registro";
            this.idregistroDataGridViewTextBoxColumn.HeaderText = "Id_registro";
            this.idregistroDataGridViewTextBoxColumn.Name = "idregistroDataGridViewTextBoxColumn";
            this.idregistroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idcontatoDataGridViewTextBoxColumn
            // 
            this.idcontatoDataGridViewTextBoxColumn.DataPropertyName = "id_contato";
            this.idcontatoDataGridViewTextBoxColumn.HeaderText = "id_contato";
            this.idcontatoDataGridViewTextBoxColumn.Name = "idcontatoDataGridViewTextBoxColumn";
            this.idcontatoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idregistrostrDataGridViewTextBoxColumn
            // 
            this.idregistrostrDataGridViewTextBoxColumn.DataPropertyName = "Id_registrostr";
            this.idregistrostrDataGridViewTextBoxColumn.HeaderText = "Id_registrostr";
            this.idregistrostrDataGridViewTextBoxColumn.Name = "idregistrostrDataGridViewTextBoxColumn";
            this.idregistrostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idorcamentoDataGridViewTextBoxColumn
            // 
            this.idorcamentoDataGridViewTextBoxColumn.DataPropertyName = "Id_orcamento";
            this.idorcamentoDataGridViewTextBoxColumn.HeaderText = "Id_orcamento";
            this.idorcamentoDataGridViewTextBoxColumn.Name = "idorcamentoDataGridViewTextBoxColumn";
            this.idorcamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idorcamentostrDataGridViewTextBoxColumn
            // 
            this.idorcamentostrDataGridViewTextBoxColumn.DataPropertyName = "Id_orcamentostr";
            this.idorcamentostrDataGridViewTextBoxColumn.HeaderText = "Id_orcamentostr";
            this.idorcamentostrDataGridViewTextBoxColumn.Name = "idorcamentostrDataGridViewTextBoxColumn";
            this.idorcamentostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrversaoDataGridViewTextBoxColumn
            // 
            this.nrversaoDataGridViewTextBoxColumn.DataPropertyName = "Nr_versao";
            this.nrversaoDataGridViewTextBoxColumn.HeaderText = "Nr_versao";
            this.nrversaoDataGridViewTextBoxColumn.Name = "nrversaoDataGridViewTextBoxColumn";
            this.nrversaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrversaostrDataGridViewTextBoxColumn
            // 
            this.nrversaostrDataGridViewTextBoxColumn.DataPropertyName = "Nr_versaostr";
            this.nrversaostrDataGridViewTextBoxColumn.HeaderText = "Nr_versaostr";
            this.nrversaostrDataGridViewTextBoxColumn.Name = "nrversaostrDataGridViewTextBoxColumn";
            this.nrversaostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idprojetoDataGridViewTextBoxColumn
            // 
            this.idprojetoDataGridViewTextBoxColumn.DataPropertyName = "Id_projeto";
            this.idprojetoDataGridViewTextBoxColumn.HeaderText = "Id_projeto";
            this.idprojetoDataGridViewTextBoxColumn.Name = "idprojetoDataGridViewTextBoxColumn";
            this.idprojetoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idprojetostrDataGridViewTextBoxColumn
            // 
            this.idprojetostrDataGridViewTextBoxColumn.DataPropertyName = "Id_projetostr";
            this.idprojetostrDataGridViewTextBoxColumn.HeaderText = "Id_projetostr";
            this.idprojetostrDataGridViewTextBoxColumn.Name = "idprojetostrDataGridViewTextBoxColumn";
            this.idprojetostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idfichaDataGridViewTextBoxColumn
            // 
            this.idfichaDataGridViewTextBoxColumn.DataPropertyName = "Id_ficha";
            this.idfichaDataGridViewTextBoxColumn.HeaderText = "Id_ficha";
            this.idfichaDataGridViewTextBoxColumn.Name = "idfichaDataGridViewTextBoxColumn";
            this.idfichaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idfichastrDataGridViewTextBoxColumn
            // 
            this.idfichastrDataGridViewTextBoxColumn.DataPropertyName = "Id_fichastr";
            this.idfichastrDataGridViewTextBoxColumn.HeaderText = "Id_fichastr";
            this.idfichastrDataGridViewTextBoxColumn.Name = "idfichastrDataGridViewTextBoxColumn";
            this.idfichastrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sgunidadeDataGridViewTextBoxColumn
            // 
            this.sgunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sg_unidade";
            this.sgunidadeDataGridViewTextBoxColumn.HeaderText = "Sg_unidade";
            this.sgunidadeDataGridViewTextBoxColumn.Name = "sgunidadeDataGridViewTextBoxColumn";
            this.sgunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlunitarioDataGridViewTextBoxColumn
            // 
            this.vlunitarioDataGridViewTextBoxColumn.DataPropertyName = "Vl_unitario";
            this.vlunitarioDataGridViewTextBoxColumn.HeaderText = "Vl_unitario";
            this.vlunitarioDataGridViewTextBoxColumn.Name = "vlunitarioDataGridViewTextBoxColumn";
            this.vlunitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlsubtotalDataGridViewTextBoxColumn
            // 
            this.vlsubtotalDataGridViewTextBoxColumn.DataPropertyName = "Vl_subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.HeaderText = "Vl_subtotal";
            this.vlsubtotalDataGridViewTextBoxColumn.Name = "vlsubtotalDataGridViewTextBoxColumn";
            this.vlsubtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlultimacompraDataGridViewTextBoxColumn
            // 
            this.vlultimacompraDataGridViewTextBoxColumn.DataPropertyName = "Vl_ultimacompra";
            this.vlultimacompraDataGridViewTextBoxColumn.HeaderText = "Vl_ultimacompra";
            this.vlultimacompraDataGridViewTextBoxColumn.Name = "vlultimacompraDataGridViewTextBoxColumn";
            this.vlultimacompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stfatdiretoDataGridViewTextBoxColumn
            // 
            this.stfatdiretoDataGridViewTextBoxColumn.DataPropertyName = "St_fatdireto";
            this.stfatdiretoDataGridViewTextBoxColumn.HeaderText = "St_fatdireto";
            this.stfatdiretoDataGridViewTextBoxColumn.Name = "stfatdiretoDataGridViewTextBoxColumn";
            this.stfatdiretoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stfatdiretoboolDataGridViewCheckBoxColumn
            // 
            this.stfatdiretoboolDataGridViewCheckBoxColumn.DataPropertyName = "St_fatdiretobool";
            this.stfatdiretoboolDataGridViewCheckBoxColumn.HeaderText = "St_fatdiretobool";
            this.stfatdiretoboolDataGridViewCheckBoxColumn.Name = "stfatdiretoboolDataGridViewCheckBoxColumn";
            this.stfatdiretoboolDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // qtdfaturadaDataGridViewTextBoxColumn
            // 
            this.qtdfaturadaDataGridViewTextBoxColumn.DataPropertyName = "Qtd_faturada";
            this.qtdfaturadaDataGridViewTextBoxColumn.HeaderText = "Qtd_faturada";
            this.qtdfaturadaDataGridViewTextBoxColumn.Name = "qtdfaturadaDataGridViewTextBoxColumn";
            this.qtdfaturadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sdfaturarDataGridViewTextBoxColumn
            // 
            this.sdfaturarDataGridViewTextBoxColumn.DataPropertyName = "Sd_faturar";
            this.sdfaturarDataGridViewTextBoxColumn.HeaderText = "Sd_faturar";
            this.sdfaturarDataGridViewTextBoxColumn.Name = "sdfaturarDataGridViewTextBoxColumn";
            this.sdfaturarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeagregarDataGridViewTextBoxColumn
            // 
            this.quantidadeagregarDataGridViewTextBoxColumn.DataPropertyName = "quantidade_agregar";
            this.quantidadeagregarDataGridViewTextBoxColumn.HeaderText = "quantidade_agregar";
            this.quantidadeagregarDataGridViewTextBoxColumn.Name = "quantidadeagregarDataGridViewTextBoxColumn";
            this.quantidadeagregarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stcompostoDataGridViewTextBoxColumn
            // 
            this.stcompostoDataGridViewTextBoxColumn.DataPropertyName = "st_composto";
            this.stcompostoDataGridViewTextBoxColumn.HeaderText = "st_composto";
            this.stcompostoDataGridViewTextBoxColumn.Name = "stcompostoDataGridViewTextBoxColumn";
            this.stcompostoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FCompraEmpreendimentoDireto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 411);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FCompraEmpreendimentoDireto";
            this.Text = "Faturamento Direto (COMPRA)";
            this.Load += new System.EventHandler(this.FCompraEmpreendimentoDireto_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaDir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsFichaDir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stagregarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsatividadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcontatoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idregistrostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorcamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idorcamentostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrversaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrversaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprojetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idprojetostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfichaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfichastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlunitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlsubtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlultimacompraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stfatdiretoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stfatdiretoboolDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdfaturadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdfaturarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeagregarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stcompostoDataGridViewTextBoxColumn;
    }
}