namespace Empreendimento.Cadastro
{
    partial class FPCEncargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPCEncargo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bsEncargofolha = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cd_vendedor = new Componentes.EditDefault(this.components);
            this.bb_vendedor = new System.Windows.Forms.Button();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.idencargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsencargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcencargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEncargofolha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.cd_vendedor);
            this.pDados.Controls.Add(this.bb_vendedor);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Size = new System.Drawing.Size(426, 59);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(438, 219);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(430, 193);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // bsEncargofolha
            // 
            this.bsEncargofolha.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadEncargosFolha);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Percentual:";
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
            this.idencargoDataGridViewTextBoxColumn,
            this.dsencargoDataGridViewTextBoxColumn,
            this.pcencargoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsEncargofolha;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 59);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(426, 130);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cd_vendedor
            // 
            this.cd_vendedor.BackColor = System.Drawing.SystemColors.Window;
            this.cd_vendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_vendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_vendedor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncargofolha, "Id_encargostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_vendedor.Location = new System.Drawing.Point(57, 5);
            this.cd_vendedor.Name = "cd_vendedor";
            this.cd_vendedor.NM_Alias = "";
            this.cd_vendedor.NM_Campo = "id_encargo";
            this.cd_vendedor.NM_CampoBusca = "id_encargo";
            this.cd_vendedor.NM_Param = "@P_ID_ENCARGO";
            this.cd_vendedor.QTD_Zero = 0;
            this.cd_vendedor.Size = new System.Drawing.Size(93, 20);
            this.cd_vendedor.ST_AutoInc = false;
            this.cd_vendedor.ST_DisableAuto = false;
            this.cd_vendedor.ST_Float = false;
            this.cd_vendedor.ST_Gravar = true;
            this.cd_vendedor.ST_Int = false;
            this.cd_vendedor.ST_LimpaCampo = true;
            this.cd_vendedor.ST_NotNull = true;
            this.cd_vendedor.ST_PrimaryKey = false;
            this.cd_vendedor.TabIndex = 38;
            this.cd_vendedor.TextOld = null;
            this.cd_vendedor.TextChanged += new System.EventHandler(this.cd_vendedor_TextChanged);
            this.cd_vendedor.Leave += new System.EventHandler(this.cd_vendedor_Leave);
            // 
            // bb_vendedor
            // 
            this.bb_vendedor.Image = ((System.Drawing.Image)(resources.GetObject("bb_vendedor.Image")));
            this.bb_vendedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_vendedor.Location = new System.Drawing.Point(152, 5);
            this.bb_vendedor.Name = "bb_vendedor";
            this.bb_vendedor.Size = new System.Drawing.Size(28, 20);
            this.bb_vendedor.TabIndex = 39;
            this.bb_vendedor.UseVisualStyleBackColor = true;
            this.bb_vendedor.Click += new System.EventHandler(this.bb_vendedor_Click);
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEncargofolha, "Ds_encargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(186, 5);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "ds_encargo";
            this.editDefault1.NM_CampoBusca = "ds_encargo";
            this.editDefault1.NM_Param = "@P_DS_ENCARGO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(232, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 41;
            this.editDefault1.TextOld = null;
            this.editDefault1.TextChanged += new System.EventHandler(this.editDefault1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Encargo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsEncargofolha, "Pc_encargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(67, 31);
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(83, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = true;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = true;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 43;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // idencargoDataGridViewTextBoxColumn
            // 
            this.idencargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idencargoDataGridViewTextBoxColumn.DataPropertyName = "Id_encargo";
            this.idencargoDataGridViewTextBoxColumn.HeaderText = "Id. Encargo";
            this.idencargoDataGridViewTextBoxColumn.Name = "idencargoDataGridViewTextBoxColumn";
            this.idencargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.idencargoDataGridViewTextBoxColumn.Width = 87;
            // 
            // dsencargoDataGridViewTextBoxColumn
            // 
            this.dsencargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsencargoDataGridViewTextBoxColumn.DataPropertyName = "Ds_encargo";
            this.dsencargoDataGridViewTextBoxColumn.HeaderText = "Encargo";
            this.dsencargoDataGridViewTextBoxColumn.Name = "dsencargoDataGridViewTextBoxColumn";
            this.dsencargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsencargoDataGridViewTextBoxColumn.Width = 72;
            // 
            // pcencargoDataGridViewTextBoxColumn
            // 
            this.pcencargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pcencargoDataGridViewTextBoxColumn.DataPropertyName = "Pc_encargo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.pcencargoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.pcencargoDataGridViewTextBoxColumn.HeaderText = "Percentual";
            this.pcencargoDataGridViewTextBoxColumn.Name = "pcencargoDataGridViewTextBoxColumn";
            this.pcencargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.pcencargoDataGridViewTextBoxColumn.Width = 83;
            // 
            // FPCEncargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPCEncargo";
            this.Text = "Lançar Percentual encargo";
            this.Load += new System.EventHandler(this.FPCEncargo_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsEncargofolha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsEncargofolha;
        private System.Windows.Forms.Label label3;
        private Componentes.DataGridDefault dataGridDefault1;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault cd_vendedor;
        private System.Windows.Forms.Button bb_vendedor;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idencargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsencargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcencargoDataGridViewTextBoxColumn;
    }
}