namespace Empreendimento.Cadastro
{
    partial class FCadRequisito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadRequisito));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsRequisito = new System.Windows.Forms.BindingSource(this.components);
            this.id_requisito = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.idrequisitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsrequisitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisito)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_requisito);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Size = new System.Drawing.Size(745, 38);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(757, 338);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(749, 312);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
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
            this.idrequisitoDataGridViewTextBoxColumn,
            this.dsrequisitoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsRequisito;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 38);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(745, 270);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsRequisito
            // 
            this.bsRequisito.DataSource = typeof(CamadaDados.Empreendimento.Cadastro.TList_CadRequisitos);
            // 
            // id_requisito
            // 
            this.id_requisito.BackColor = System.Drawing.SystemColors.Window;
            this.id_requisito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_requisito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_requisito.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisito, "id_requisito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_requisito.Enabled = false;
            this.id_requisito.Location = new System.Drawing.Point(79, 3);
            this.id_requisito.Name = "id_requisito";
            this.id_requisito.NM_Alias = "";
            this.id_requisito.NM_Campo = "id_requisito";
            this.id_requisito.NM_CampoBusca = "id_requisito";
            this.id_requisito.NM_Param = "@P_ID_REQUISITO";
            this.id_requisito.QTD_Zero = 0;
            this.id_requisito.Size = new System.Drawing.Size(52, 20);
            this.id_requisito.ST_AutoInc = false;
            this.id_requisito.ST_DisableAuto = false;
            this.id_requisito.ST_Float = false;
            this.id_requisito.ST_Gravar = true;
            this.id_requisito.ST_Int = false;
            this.id_requisito.ST_LimpaCampo = true;
            this.id_requisito.ST_NotNull = true;
            this.id_requisito.ST_PrimaryKey = true;
            this.id_requisito.TabIndex = 10;
            this.id_requisito.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Id. Requisito";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsRequisito, "ds_requisito", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(192, 3);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "ds_requisito";
            this.editDefault1.NM_CampoBusca = "ds_requisito";
            this.editDefault1.NM_Param = "@P_DS_REQUISITO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(545, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = true;
            this.editDefault1.ST_PrimaryKey = true;
            this.editDefault1.TabIndex = 12;
            this.editDefault1.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Requisito";
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
            // FCadRequisito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 381);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadRequisito";
            this.Text = "FCadRequisito";
            this.Load += new System.EventHandler(this.FCadRequisito_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsRequisito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsRequisito;
        private Componentes.EditDefault id_requisito;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrequisitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsrequisitoDataGridViewTextBoxColumn;
    }
}