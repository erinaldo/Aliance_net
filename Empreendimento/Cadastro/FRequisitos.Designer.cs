namespace Empreendimento.Cadastro
{
    partial class FRequisitos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRequisitos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.stagregarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idrequisitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsrequisitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsRequisito = new System.Windows.Forms.BindingSource(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisito)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(501, 43);
            this.barraMenu.TabIndex = 15;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.Green;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(95, 40);
            this.toolStripButton1.Text = "(F4)\r\nConfirmar";
            this.toolStripButton1.ToolTipText = "Confirmar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stagregarDataGridViewCheckBoxColumn,
            this.idrequisitoDataGridViewTextBoxColumn,
            this.dsrequisitoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsRequisito;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 43);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(501, 343);
            this.dataGridDefault1.TabIndex = 14;
            this.dataGridDefault1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDefault1_CellClick);
            // 
            // stagregarDataGridViewCheckBoxColumn
            // 
            this.stagregarDataGridViewCheckBoxColumn.DataPropertyName = "st_agregar";
            this.stagregarDataGridViewCheckBoxColumn.HeaderText = "Importar";
            this.stagregarDataGridViewCheckBoxColumn.Name = "stagregarDataGridViewCheckBoxColumn";
            this.stagregarDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // idrequisitoDataGridViewTextBoxColumn
            // 
            this.idrequisitoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idrequisitoDataGridViewTextBoxColumn.DataPropertyName = "id_requisito";
            this.idrequisitoDataGridViewTextBoxColumn.HeaderText = "Id. Requisito";
            this.idrequisitoDataGridViewTextBoxColumn.Name = "idrequisitoDataGridViewTextBoxColumn";
            this.idrequisitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idrequisitoDataGridViewTextBoxColumn.Width = 91;
            // 
            // dsrequisitoDataGridViewTextBoxColumn
            // 
            this.dsrequisitoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsrequisitoDataGridViewTextBoxColumn.DataPropertyName = "ds_requisito";
            this.dsrequisitoDataGridViewTextBoxColumn.HeaderText = "Ds. Requisito";
            this.dsrequisitoDataGridViewTextBoxColumn.Name = "dsrequisitoDataGridViewTextBoxColumn";
            this.dsrequisitoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsrequisitoDataGridViewTextBoxColumn.Width = 95;
            // 
            // bsRequisito
            // 
            this.bsRequisito.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos);
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.Location = new System.Drawing.Point(5, 46);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDefault1.ST_Gravar = false;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 16;
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            this.checkBoxDefault1.CheckedChanged += new System.EventHandler(this.checkBoxDefault1_CheckedChanged);
            // 
            // FRequisitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 386);
            this.Controls.Add(this.checkBoxDefault1);
            this.Controls.Add(this.dataGridDefault1);
            this.Controls.Add(this.barraMenu);
            this.Name = "FRequisitos";
            this.Text = "Requisitos";
            this.Load += new System.EventHandler(this.FRequisitos_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsRequisito;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stagregarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrequisitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsrequisitoDataGridViewTextBoxColumn;
        private Componentes.CheckBoxDefault checkBoxDefault1;
    }
}