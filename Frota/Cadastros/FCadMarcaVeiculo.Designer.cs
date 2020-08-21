namespace Frota.Cadastros
{
    partial class TFCadMarcaVeiculo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadMarcaVeiculo));
            this.id_marca = new Componentes.EditDefault(this.components);
            this.bsMarcaVeiculo = new System.Windows.Forms.BindingSource(this.components);
            this.ds_marca = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsmarcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcaVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.ds_marca);
            this.pDados.Controls.Add(this.id_marca);
            this.pDados.Size = new System.Drawing.Size(340, 64);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(352, 281);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.bindingNavigator2);
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(344, 255);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator2, 0);
            // 
            // id_marca
            // 
            this.id_marca.BackColor = System.Drawing.SystemColors.Window;
            this.id_marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_marca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcaVeiculo, "Id_marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_marca.Enabled = false;
            this.id_marca.Location = new System.Drawing.Point(77, 3);
            this.id_marca.Name = "id_marca";
            this.id_marca.NM_Alias = "";
            this.id_marca.NM_Campo = "";
            this.id_marca.NM_CampoBusca = "";
            this.id_marca.NM_Param = "";
            this.id_marca.QTD_Zero = 0;
            this.id_marca.Size = new System.Drawing.Size(100, 20);
            this.id_marca.ST_AutoInc = false;
            this.id_marca.ST_DisableAuto = true;
            this.id_marca.ST_Float = false;
            this.id_marca.ST_Gravar = true;
            this.id_marca.ST_Int = false;
            this.id_marca.ST_LimpaCampo = true;
            this.id_marca.ST_NotNull = true;
            this.id_marca.ST_PrimaryKey = true;
            this.id_marca.TabIndex = 0;
            // 
            // bsMarcaVeiculo
            // 
            this.bsMarcaVeiculo.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadMarcaVeiculo);
            // 
            // ds_marca
            // 
            this.ds_marca.BackColor = System.Drawing.SystemColors.Window;
            this.ds_marca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_marca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_marca.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMarcaVeiculo, "Ds_marca", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_marca.Enabled = false;
            this.ds_marca.Location = new System.Drawing.Point(77, 29);
            this.ds_marca.Name = "ds_marca";
            this.ds_marca.NM_Alias = "";
            this.ds_marca.NM_Campo = "";
            this.ds_marca.NM_CampoBusca = "";
            this.ds_marca.NM_Param = "";
            this.ds_marca.QTD_Zero = 0;
            this.ds_marca.Size = new System.Drawing.Size(249, 20);
            this.ds_marca.ST_AutoInc = false;
            this.ds_marca.ST_DisableAuto = false;
            this.ds_marca.ST_Float = false;
            this.ds_marca.ST_Gravar = true;
            this.ds_marca.ST_Int = false;
            this.ds_marca.ST_LimpaCampo = true;
            this.ds_marca.ST_NotNull = false;
            this.ds_marca.ST_PrimaryKey = false;
            this.ds_marca.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Marca:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Id.Marca:";
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idmarcaDataGridViewTextBoxColumn,
            this.dsmarcaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsMarcaVeiculo;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 64);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(340, 187);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // idmarcaDataGridViewTextBoxColumn
            // 
            this.idmarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idmarcaDataGridViewTextBoxColumn.DataPropertyName = "Id_marca";
            this.idmarcaDataGridViewTextBoxColumn.HeaderText = "Id.Marca";
            this.idmarcaDataGridViewTextBoxColumn.Name = "idmarcaDataGridViewTextBoxColumn";
            this.idmarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idmarcaDataGridViewTextBoxColumn.Width = 74;
            // 
            // dsmarcaDataGridViewTextBoxColumn
            // 
            this.dsmarcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsmarcaDataGridViewTextBoxColumn.DataPropertyName = "Ds_marca";
            this.dsmarcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.dsmarcaDataGridViewTextBoxColumn.Name = "dsmarcaDataGridViewTextBoxColumn";
            this.dsmarcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsmarcaDataGridViewTextBoxColumn.Width = 62;
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = null;
            this.bindingNavigator2.BindingSource = this.bsMarcaVeiculo;
            this.bindingNavigator2.CountItem = this.toolStripLabel1;
            this.bindingNavigator2.DeleteItem = null;
            this.bindingNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripButton4});
            this.bindingNavigator2.Location = new System.Drawing.Point(0, 226);
            this.bindingNavigator2.MoveFirstItem = this.toolStripButton1;
            this.bindingNavigator2.MoveLastItem = this.toolStripButton4;
            this.bindingNavigator2.MoveNextItem = this.toolStripButton3;
            this.bindingNavigator2.MovePreviousItem = this.toolStripButton2;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator2.Size = new System.Drawing.Size(340, 25);
            this.bindingNavigator2.TabIndex = 9;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "de {0}";
            this.toolStripLabel1.ToolTipText = "Total Registros";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Move first";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Move previous";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "Position";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 23);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "Registro Corrente";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Proximo Registro";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Ultimo Registro";
            // 
            // TFCadMarcaVeiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 324);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadMarcaVeiculo";
            this.Text = "Cadastros de Marca de Veiculos";
            this.Load += new System.EventHandler(this.TFCadMarcaVeiculo_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarcaVeiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault ds_marca;
        private Componentes.EditDefault id_marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsMarcaVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsmarcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}