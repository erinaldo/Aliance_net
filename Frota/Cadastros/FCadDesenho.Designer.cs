namespace Frota.Cadastros
{
    partial class TFCadDesenho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadDesenho));
            this.tpMaster = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.dataGridDefault2 = new Componentes.DataGridDefault(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.iddesenhostrDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdesenhoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddesenhostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdesenhoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iddespesastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodespesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.iddesenhostrDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsdesenhoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpMaster.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            this.SuspendLayout();
            // 
            // tpMaster
            // 
            this.tpMaster.ColumnCount = 1;
            this.tpMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpMaster.Controls.Add(this.panelDados1, 0, 0);
            this.tpMaster.Controls.Add(this.panelDados2, 0, 1);
            this.tpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpMaster.Location = new System.Drawing.Point(0, 0);
            this.tpMaster.Name = "tpMaster";
            this.tpMaster.RowCount = 2;
            this.tpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tpMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tpMaster.Size = new System.Drawing.Size(409, 278);
            this.tpMaster.TabIndex = 0;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.textBox1);
            this.panelDados1.Controls.Add(this.button2);
            this.panelDados1.Controls.Add(this.button1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(403, 40);
            this.panelDados1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(173, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "EXCLUIR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "GRAVAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.dataGridDefault2);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 49);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(403, 226);
            this.panelDados2.TabIndex = 1;
            // 
            // dataGridDefault2
            // 
            this.dataGridDefault2.AllowUserToAddRows = false;
            this.dataGridDefault2.AllowUserToDeleteRows = false;
            this.dataGridDefault2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault2.AutoGenerateColumns = false;
            this.dataGridDefault2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iddesenhostrDataGridViewTextBoxColumn2,
            this.dsdesenhoDataGridViewTextBoxColumn2});
            this.dataGridDefault2.DataSource = this.bindingSource1;
            this.dataGridDefault2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault2.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault2.Name = "dataGridDefault2";
            this.dataGridDefault2.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault2.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault2.RowHeadersWidth = 23;
            this.dataGridDefault2.Size = new System.Drawing.Size(403, 226);
            this.dataGridDefault2.TabIndex = 3;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CamadaDados.Frota.Cadastros.TList_CadDesenhoPneu);
            // 
            // iddesenhostrDataGridViewTextBoxColumn1
            // 
            this.iddesenhostrDataGridViewTextBoxColumn1.DataPropertyName = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn1.HeaderText = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn1.Name = "iddesenhostrDataGridViewTextBoxColumn1";
            this.iddesenhostrDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsdesenhoDataGridViewTextBoxColumn1
            // 
            this.dsdesenhoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_desenho";
            this.dsdesenhoDataGridViewTextBoxColumn1.HeaderText = "Ds_desenho";
            this.dsdesenhoDataGridViewTextBoxColumn1.Name = "dsdesenhoDataGridViewTextBoxColumn1";
            this.dsdesenhoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // iddesenhostrDataGridViewTextBoxColumn
            // 
            this.iddesenhostrDataGridViewTextBoxColumn.DataPropertyName = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn.HeaderText = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn.Name = "iddesenhostrDataGridViewTextBoxColumn";
            this.iddesenhostrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsdesenhoDataGridViewTextBoxColumn
            // 
            this.dsdesenhoDataGridViewTextBoxColumn.DataPropertyName = "Ds_desenho";
            this.dsdesenhoDataGridViewTextBoxColumn.HeaderText = "Ds_desenho";
            this.dsdesenhoDataGridViewTextBoxColumn.Name = "dsdesenhoDataGridViewTextBoxColumn";
            this.dsdesenhoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iddespesaDataGridViewTextBoxColumn
            // 
            this.iddespesaDataGridViewTextBoxColumn.DataPropertyName = "Id_despesa";
            this.iddespesaDataGridViewTextBoxColumn.HeaderText = "Id_despesa";
            this.iddespesaDataGridViewTextBoxColumn.Name = "iddespesaDataGridViewTextBoxColumn";
            this.iddespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddespesaDataGridViewTextBoxColumn.Visible = false;
            // 
            // iddespesastrDataGridViewTextBoxColumn
            // 
            this.iddespesastrDataGridViewTextBoxColumn.DataPropertyName = "Id_despesastr";
            this.iddespesastrDataGridViewTextBoxColumn.HeaderText = "Id_despesastr";
            this.iddespesastrDataGridViewTextBoxColumn.Name = "iddespesastrDataGridViewTextBoxColumn";
            this.iddespesastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.iddespesastrDataGridViewTextBoxColumn.Visible = false;
            // 
            // dsdespesaDataGridViewTextBoxColumn
            // 
            this.dsdespesaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dsdespesaDataGridViewTextBoxColumn.DataPropertyName = "Ds_despesa";
            this.dsdespesaDataGridViewTextBoxColumn.HeaderText = "Descrição do desenho";
            this.dsdespesaDataGridViewTextBoxColumn.Name = "dsdespesaDataGridViewTextBoxColumn";
            this.dsdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tpdespesaDataGridViewTextBoxColumn
            // 
            this.tpdespesaDataGridViewTextBoxColumn.DataPropertyName = "Tp_despesa";
            this.tpdespesaDataGridViewTextBoxColumn.HeaderText = "Tp_despesa";
            this.tpdespesaDataGridViewTextBoxColumn.Name = "tpdespesaDataGridViewTextBoxColumn";
            this.tpdespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpdespesaDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipodespesaDataGridViewTextBoxColumn
            // 
            this.tipodespesaDataGridViewTextBoxColumn.DataPropertyName = "Tipo_despesa";
            this.tipodespesaDataGridViewTextBoxColumn.HeaderText = "Tipo_despesa";
            this.tipodespesaDataGridViewTextBoxColumn.Name = "tipodespesaDataGridViewTextBoxColumn";
            this.tipodespesaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipodespesaDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
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
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(341, 226);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // iddesenhostrDataGridViewTextBoxColumn2
            // 
            this.iddesenhostrDataGridViewTextBoxColumn2.DataPropertyName = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn2.HeaderText = "Id_desenhostr";
            this.iddesenhostrDataGridViewTextBoxColumn2.Name = "iddesenhostrDataGridViewTextBoxColumn2";
            this.iddesenhostrDataGridViewTextBoxColumn2.ReadOnly = true;
            this.iddesenhostrDataGridViewTextBoxColumn2.Visible = false;
            // 
            // dsdesenhoDataGridViewTextBoxColumn2
            // 
            this.dsdesenhoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dsdesenhoDataGridViewTextBoxColumn2.DataPropertyName = "Ds_desenho";
            this.dsdesenhoDataGridViewTextBoxColumn2.HeaderText = "Descrição desenho";
            this.dsdesenhoDataGridViewTextBoxColumn2.Name = "dsdesenhoDataGridViewTextBoxColumn2";
            this.dsdesenhoDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TFCadDesenho
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(409, 278);
            this.Controls.Add(this.tpMaster);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadDesenho";
            this.Text = "Cadastro Desenho";
            this.Load += new System.EventHandler(this.FCadDesenho_Load);
            this.tpMaster.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddespesastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodespesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddesenhostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdesenhoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddesenhostrDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdesenhoDataGridViewTextBoxColumn1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault dataGridDefault2;
        private System.Windows.Forms.DataGridViewTextBoxColumn iddesenhostrDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsdesenhoDataGridViewTextBoxColumn2;
    }
}