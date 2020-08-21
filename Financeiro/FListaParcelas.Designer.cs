namespace Financeiro
{
    partial class TFListaParcelas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsParcelas = new System.Windows.Forms.BindingSource(this.components);
            this.Cd_empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrdoctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrlanctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtemissaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvenctoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlparcelaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_JuroLiquid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_DescLiquid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_liquidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlatualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcelas)).BeginInit();
            this.SuspendLayout();
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
            this.Cd_empresa,
            this.nrdoctoDataGridViewTextBoxColumn,
            this.nrlanctoDataGridViewTextBoxColumn,
            this.cdparcelaDataGridViewTextBoxColumn,
            this.dtemissaoDataGridViewTextBoxColumn,
            this.dtvenctoDataGridViewTextBoxColumn,
            this.vlparcelaDataGridViewTextBoxColumn,
            this.Vl_JuroLiquid,
            this.Vl_DescLiquid,
            this.Vl_liquidado,
            this.vlatualDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsParcelas;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(929, 475);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // bsParcelas
            // 
            this.bsParcelas.DataSource = typeof(CamadaDados.Financeiro.Duplicata.TList_RegLanParcela);
            // 
            // Cd_empresa
            // 
            this.Cd_empresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_empresa.DataPropertyName = "Cd_empresa";
            this.Cd_empresa.HeaderText = "Cd. Empresa";
            this.Cd_empresa.Name = "Cd_empresa";
            this.Cd_empresa.ReadOnly = true;
            this.Cd_empresa.Width = 92;
            // 
            // nrdoctoDataGridViewTextBoxColumn
            // 
            this.nrdoctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrdoctoDataGridViewTextBoxColumn.DataPropertyName = "Nr_docto";
            this.nrdoctoDataGridViewTextBoxColumn.HeaderText = "Nº Documento";
            this.nrdoctoDataGridViewTextBoxColumn.Name = "nrdoctoDataGridViewTextBoxColumn";
            this.nrdoctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrdoctoDataGridViewTextBoxColumn.Width = 102;
            // 
            // nrlanctoDataGridViewTextBoxColumn
            // 
            this.nrlanctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nrlanctoDataGridViewTextBoxColumn.DataPropertyName = "Nr_lancto";
            this.nrlanctoDataGridViewTextBoxColumn.HeaderText = "Nº Duplicata";
            this.nrlanctoDataGridViewTextBoxColumn.Name = "nrlanctoDataGridViewTextBoxColumn";
            this.nrlanctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nrlanctoDataGridViewTextBoxColumn.Width = 92;
            // 
            // cdparcelaDataGridViewTextBoxColumn
            // 
            this.cdparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdparcelaDataGridViewTextBoxColumn.DataPropertyName = "Cd_parcela";
            this.cdparcelaDataGridViewTextBoxColumn.HeaderText = "Cd. Parcela";
            this.cdparcelaDataGridViewTextBoxColumn.Name = "cdparcelaDataGridViewTextBoxColumn";
            this.cdparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdparcelaDataGridViewTextBoxColumn.Width = 87;
            // 
            // dtemissaoDataGridViewTextBoxColumn
            // 
            this.dtemissaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtemissaoDataGridViewTextBoxColumn.DataPropertyName = "Dt_emissao";
            this.dtemissaoDataGridViewTextBoxColumn.HeaderText = "Dt. Emissão";
            this.dtemissaoDataGridViewTextBoxColumn.Name = "dtemissaoDataGridViewTextBoxColumn";
            this.dtemissaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtemissaoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dtvenctoDataGridViewTextBoxColumn
            // 
            this.dtvenctoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvenctoDataGridViewTextBoxColumn.DataPropertyName = "Dt_vencto";
            this.dtvenctoDataGridViewTextBoxColumn.HeaderText = "Dt. Vencimento";
            this.dtvenctoDataGridViewTextBoxColumn.Name = "dtvenctoDataGridViewTextBoxColumn";
            this.dtvenctoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvenctoDataGridViewTextBoxColumn.Width = 97;
            // 
            // vlparcelaDataGridViewTextBoxColumn
            // 
            this.vlparcelaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlparcelaDataGridViewTextBoxColumn.DataPropertyName = "Vl_parcela";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.vlparcelaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.vlparcelaDataGridViewTextBoxColumn.HeaderText = "Vl. Parcela";
            this.vlparcelaDataGridViewTextBoxColumn.Name = "vlparcelaDataGridViewTextBoxColumn";
            this.vlparcelaDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlparcelaDataGridViewTextBoxColumn.Width = 77;
            // 
            // Vl_JuroLiquid
            // 
            this.Vl_JuroLiquid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_JuroLiquid.DataPropertyName = "Vl_JuroLiquid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.Vl_JuroLiquid.DefaultCellStyle = dataGridViewCellStyle4;
            this.Vl_JuroLiquid.HeaderText = "Vl. Juro";
            this.Vl_JuroLiquid.Name = "Vl_JuroLiquid";
            this.Vl_JuroLiquid.ReadOnly = true;
            this.Vl_JuroLiquid.Width = 62;
            // 
            // Vl_DescLiquid
            // 
            this.Vl_DescLiquid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_DescLiquid.DataPropertyName = "Vl_DescLiquid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = "0";
            this.Vl_DescLiquid.DefaultCellStyle = dataGridViewCellStyle5;
            this.Vl_DescLiquid.HeaderText = "Vl. Desconto";
            this.Vl_DescLiquid.Name = "Vl_DescLiquid";
            this.Vl_DescLiquid.ReadOnly = true;
            this.Vl_DescLiquid.Width = 86;
            // 
            // Vl_liquidado
            // 
            this.Vl_liquidado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vl_liquidado.DataPropertyName = "Vl_liquidado";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = "0";
            this.Vl_liquidado.DefaultCellStyle = dataGridViewCellStyle6;
            this.Vl_liquidado.HeaderText = "Vl. Liquidado";
            this.Vl_liquidado.Name = "Vl_liquidado";
            this.Vl_liquidado.ReadOnly = true;
            this.Vl_liquidado.Width = 86;
            // 
            // vlatualDataGridViewTextBoxColumn
            // 
            this.vlatualDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.vlatualDataGridViewTextBoxColumn.DataPropertyName = "Vl_atual";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.vlatualDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.vlatualDataGridViewTextBoxColumn.HeaderText = "Vl. Atual";
            this.vlatualDataGridViewTextBoxColumn.Name = "vlatualDataGridViewTextBoxColumn";
            this.vlatualDataGridViewTextBoxColumn.ReadOnly = true;
            this.vlatualDataGridViewTextBoxColumn.Width = 66;
            // 
            // TFListaParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 475);
            this.Controls.Add(this.dataGridDefault1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFListaParcelas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duplicatas em Aberto";
            this.Load += new System.EventHandler(this.TFListaParcelas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsParcelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrdoctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrlanctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtemissaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlparcelaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_JuroLiquid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_DescLiquid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_liquidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlatualDataGridViewTextBoxColumn;
    }
}