namespace Faturamento
{
    partial class TFListaGrupoProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFListaGrupoProd));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gGrupoProduto = new Componentes.DataGridDefault(this.components);
            this.bsGrupoProduto = new System.Windows.Forms.BindingSource(this.components);
            this.stprocessarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpGrupoExtendidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gGrupoProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoProduto)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(917, 43);
            this.barraMenu.TabIndex = 12;
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
            this.bb_inutilizar.Text = "(F4)\r\nConfirmar";
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
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.gGrupoProduto);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(917, 470);
            this.panelDados1.TabIndex = 13;
            // 
            // gGrupoProduto
            // 
            this.gGrupoProduto.AllowUserToAddRows = false;
            this.gGrupoProduto.AllowUserToDeleteRows = false;
            this.gGrupoProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gGrupoProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.gGrupoProduto.AutoGenerateColumns = false;
            this.gGrupoProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gGrupoProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gGrupoProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gGrupoProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gGrupoProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gGrupoProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stprocessarDataGridViewCheckBoxColumn,
            this.cDGrupoDataGridViewTextBoxColumn,
            this.dSGrupoDataGridViewTextBoxColumn,
            this.tpGrupoExtendidoDataGridViewTextBoxColumn});
            this.gGrupoProduto.DataSource = this.bsGrupoProduto;
            this.gGrupoProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gGrupoProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gGrupoProduto.Location = new System.Drawing.Point(0, 0);
            this.gGrupoProduto.Name = "gGrupoProduto";
            this.gGrupoProduto.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gGrupoProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gGrupoProduto.RowHeadersWidth = 23;
            this.gGrupoProduto.Size = new System.Drawing.Size(917, 470);
            this.gGrupoProduto.TabIndex = 0;
            this.gGrupoProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gGrupoProduto_CellClick);
            // 
            // bsGrupoProduto
            // 
            this.bsGrupoProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadGrupoProduto);
            // 
            // stprocessarDataGridViewCheckBoxColumn
            // 
            this.stprocessarDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.stprocessarDataGridViewCheckBoxColumn.DataPropertyName = "St_processar";
            this.stprocessarDataGridViewCheckBoxColumn.HeaderText = "Marcar";
            this.stprocessarDataGridViewCheckBoxColumn.Name = "stprocessarDataGridViewCheckBoxColumn";
            this.stprocessarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.stprocessarDataGridViewCheckBoxColumn.Width = 46;
            // 
            // cDGrupoDataGridViewTextBoxColumn
            // 
            this.cDGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDGrupoDataGridViewTextBoxColumn.DataPropertyName = "CD_Grupo";
            this.cDGrupoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.cDGrupoDataGridViewTextBoxColumn.Name = "cDGrupoDataGridViewTextBoxColumn";
            this.cDGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDGrupoDataGridViewTextBoxColumn.Width = 65;
            // 
            // dSGrupoDataGridViewTextBoxColumn
            // 
            this.dSGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSGrupoDataGridViewTextBoxColumn.DataPropertyName = "DS_Grupo";
            this.dSGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo Produto";
            this.dSGrupoDataGridViewTextBoxColumn.Name = "dSGrupoDataGridViewTextBoxColumn";
            this.dSGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSGrupoDataGridViewTextBoxColumn.Width = 101;
            // 
            // tpGrupoExtendidoDataGridViewTextBoxColumn
            // 
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.DataPropertyName = "Tp_Grupo_Extendido";
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.Name = "tpGrupoExtendidoDataGridViewTextBoxColumn";
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpGrupoExtendidoDataGridViewTextBoxColumn.Width = 53;
            // 
            // TFListaGrupoProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 513);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaGrupoProd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Produtos";
            this.Load += new System.EventHandler(this.TFListaGrupoProd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFListaGrupoProd_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gGrupoProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrupoProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gGrupoProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stprocessarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpGrupoExtendidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsGrupoProduto;
    }
}