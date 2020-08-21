namespace FormRelPadrao
{
    partial class TFPreviewDataCube
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFPreviewDataCube));
            PerpetuumSoft.Olap.StyleSheet styleSheet1 = new PerpetuumSoft.Olap.StyleSheet();
            PerpetuumSoft.Olap.CellStyle cellStyle1 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle2 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellBorder cellBorder1 = new PerpetuumSoft.Olap.CellBorder();
            PerpetuumSoft.Olap.CellStyle cellStyle3 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle4 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle5 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle6 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle7 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle8 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle9 = new PerpetuumSoft.Olap.CellStyle();
            PerpetuumSoft.Olap.CellStyle cellStyle10 = new PerpetuumSoft.Olap.CellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataCube = new PerpetuumSoft.Olap.DataCube();
            this.bsCubo = new System.Windows.Forms.BindingSource(this.components);
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pCubo = new Componentes.PanelDados(this.components);
            this.dcGrid = new PerpetuumSoft.Olap.Windows.Forms.DataCubeGrid();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsCubo)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.pCubo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataCube
            // 
            this.dataCube.DataSource = this.bsCubo;
            this.dataCube.Footer = null;
            this.dataCube.Header = null;
            this.dataCube.Layout = resources.GetString("dataCube.Layout");
            this.dataCube.PageFooter = null;
            this.dataCube.PageHeader = null;
            this.dataCube.StringRegKey = "{DIAAC3AAC1AADCAADDAACZAADAAAC7AACZAADCAAC1AAC3AAAKAACLAAB7AACKAACOAACBAAB6AACHAA" +
                "CKAA}";
            cellStyle1.BackColor = System.Drawing.Color.Black;
            cellStyle1.ForeColor = System.Drawing.Color.White;
            styleSheet1.ActiveCellStyle = cellStyle1;
            cellStyle2.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.EvenRowFactStyle = cellStyle2;
            styleSheet1.FactBorder = cellBorder1;
            cellStyle3.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.FieldCaptionStyle = cellStyle3;
            cellStyle4.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.GroupTotalStyle = cellStyle4;
            cellStyle5.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.MainTotalStyle = cellStyle5;
            styleSheet1.Name = global::FormRelPadrao.Resources.RDCPadrao.Code_DataCube;
            styleSheet1.OddRowFactStyle = cellStyle6;
            styleSheet1.TableCaptionStyle = cellStyle7;
            cellStyle8.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.TotalStyle = cellStyle8;
            cellStyle9.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.XDimensionStyle = cellStyle9;
            cellStyle10.Font = new System.Drawing.Font("Arial", 10F);
            styleSheet1.YDimensionStyle = cellStyle10;
            this.dataCube.StyleSheet = styleSheet1;
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pCubo, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 1;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 356F));
            this.tlpCentral.Size = new System.Drawing.Size(627, 358);
            this.tlpCentral.TabIndex = 1;
            // 
            // pCubo
            // 
            this.pCubo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCubo.Controls.Add(this.dcGrid);
            this.pCubo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCubo.Location = new System.Drawing.Point(5, 5);
            this.pCubo.Name = "pCubo";
            this.pCubo.NM_ProcDeletar = global::FormRelPadrao.Resources.RDCPadrao.Code_DataCube;
            this.pCubo.NM_ProcGravar = global::FormRelPadrao.Resources.RDCPadrao.Code_DataCube;
            this.pCubo.Size = new System.Drawing.Size(617, 348);
            this.pCubo.TabIndex = 0;
            // 
            // dcGrid
            // 
            this.dcGrid.AutoScroll = true;
            this.dcGrid.AutoSize = true;
            this.dcGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dcGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dcGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.dcGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dcGrid.Location = new System.Drawing.Point(0, 0);
            this.dcGrid.Name = "dcGrid";
            this.dcGrid.Painter = new PerpetuumSoft.Olap.Windows.Forms.ProfessionalPainter();
            this.dcGrid.Size = new System.Drawing.Size(613, 344);
            this.dcGrid.Source = this.dataCube;
            this.dcGrid.TabIndex = 0;
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
            this.dataGridDefault1.DataSource = this.bsCubo;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(613, 91);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // TFPreviewDataCube
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(627, 358);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "TFPreviewDataCube";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preview Data Cube";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPreviewDataCube_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCubo)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.pCubo.ResumeLayout(false);
            this.pCubo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public PerpetuumSoft.Olap.DataCube dataCube;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pCubo;
        private Componentes.DataGridDefault dataGridDefault1;
        public System.Windows.Forms.BindingSource bsCubo;
        public PerpetuumSoft.Olap.Windows.Forms.DataCubeGrid dcGrid;
    }
}