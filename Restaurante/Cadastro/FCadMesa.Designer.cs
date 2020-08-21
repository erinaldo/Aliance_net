namespace Restaurante.Cadastro
{
    partial class FCadMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCadMesa));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsMesa = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_local = new Componentes.EditDefault(this.components);
            this.id_local = new Componentes.EditDefault(this.components);
            this.bb_tabelapreco = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.idMesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLocalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsMesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrMesaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stregistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.st_balcao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMesa)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.checkBoxDefault1);
            this.pDados.Controls.Add(this.editDefault3);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.bb_tabelapreco);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.id_local);
            this.pDados.Size = new System.Drawing.Size(874, 84);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(886, 400);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(878, 374);
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
            this.idMesaDataGridViewTextBoxColumn,
            this.idLocalDataGridViewTextBoxColumn,
            this.dsMesaDataGridViewTextBoxColumn,
            this.nrMesaDataGridViewTextBoxColumn,
            this.stregistroDataGridViewTextBoxColumn,
            this.st_balcao});
            this.dataGridDefault1.DataSource = this.bsMesa;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 84);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(874, 286);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // bsMesa
            // 
            this.bsMesa.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Mesa);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Local:";
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.Location = new System.Drawing.Point(201, 30);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "ds_local";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_LOCAL";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.Size = new System.Drawing.Size(474, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 5;
            this.ds_local.TextOld = null;
            // 
            // id_local
            // 
            this.id_local.BackColor = System.Drawing.SystemColors.Window;
            this.id_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMesa, "Id_Local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_local.Enabled = false;
            this.id_local.Location = new System.Drawing.Point(61, 30);
            this.id_local.Name = "id_local";
            this.id_local.NM_Alias = "id_local";
            this.id_local.NM_Campo = "id_local";
            this.id_local.NM_CampoBusca = "id_local";
            this.id_local.NM_Param = "@P_ID_LOCAL";
            this.id_local.QTD_Zero = 0;
            this.id_local.Size = new System.Drawing.Size(100, 20);
            this.id_local.ST_AutoInc = false;
            this.id_local.ST_DisableAuto = false;
            this.id_local.ST_Float = false;
            this.id_local.ST_Gravar = true;
            this.id_local.ST_Int = false;
            this.id_local.ST_LimpaCampo = true;
            this.id_local.ST_NotNull = true;
            this.id_local.ST_PrimaryKey = false;
            this.id_local.TabIndex = 2;
            this.id_local.TextOld = null;
            this.id_local.Leave += new System.EventHandler(this.id_local_Leave);
            // 
            // bb_tabelapreco
            // 
            this.bb_tabelapreco.Enabled = false;
            this.bb_tabelapreco.Image = ((System.Drawing.Image)(resources.GetObject("bb_tabelapreco.Image")));
            this.bb_tabelapreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tabelapreco.Location = new System.Drawing.Point(167, 29);
            this.bb_tabelapreco.Name = "bb_tabelapreco";
            this.bb_tabelapreco.Size = new System.Drawing.Size(28, 21);
            this.bb_tabelapreco.TabIndex = 3;
            this.bb_tabelapreco.UseVisualStyleBackColor = true;
            this.bb_tabelapreco.Click += new System.EventHandler(this.bb_tabelapreco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Id. Mesa:";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMesa, "Id_Mesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(61, 4);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "id_mesa";
            this.editDefault1.NM_Campo = "id_mesa";
            this.editDefault1.NM_CampoBusca = "id_mesa";
            this.editDefault1.NM_Param = "@P_ID_MESA";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(100, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = true;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = true;
            this.editDefault1.ST_PrimaryKey = true;
            this.editDefault1.TabIndex = 0;
            this.editDefault1.TextOld = null;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMesa, "Ds_Mesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Location = new System.Drawing.Point(167, 4);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "ds_mesa";
            this.editDefault2.NM_Campo = "ds_mesa";
            this.editDefault2.NM_CampoBusca = "ds_mesa";
            this.editDefault2.NM_Param = "@P_DS_MESA";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(508, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = true;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = true;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 1;
            this.editDefault2.TextOld = null;
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsMesa, "Nr_Mesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Location = new System.Drawing.Point(61, 56);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "nr_mesa";
            this.editDefault3.NM_Campo = "nr_mesa";
            this.editDefault3.NM_CampoBusca = "nr_mesa";
            this.editDefault3.NM_Param = "@P_NR_MESA";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(100, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = true;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = true;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 4;
            this.editDefault3.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Nr. Mesa:";
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsMesa, "st_balcao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Location = new System.Drawing.Point(167, 57);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(59, 17);
            this.checkBoxDefault1.ST_Gravar = true;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 5;
            this.checkBoxDefault1.Text = "Balcão";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // idMesaDataGridViewTextBoxColumn
            // 
            this.idMesaDataGridViewTextBoxColumn.DataPropertyName = "Id_Mesa";
            this.idMesaDataGridViewTextBoxColumn.HeaderText = "Id. Mesa";
            this.idMesaDataGridViewTextBoxColumn.Name = "idMesaDataGridViewTextBoxColumn";
            this.idMesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idLocalDataGridViewTextBoxColumn
            // 
            this.idLocalDataGridViewTextBoxColumn.DataPropertyName = "Id_Local";
            this.idLocalDataGridViewTextBoxColumn.HeaderText = "Id. Local";
            this.idLocalDataGridViewTextBoxColumn.Name = "idLocalDataGridViewTextBoxColumn";
            this.idLocalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsMesaDataGridViewTextBoxColumn
            // 
            this.dsMesaDataGridViewTextBoxColumn.DataPropertyName = "Ds_Mesa";
            this.dsMesaDataGridViewTextBoxColumn.HeaderText = "Ds. Mesa";
            this.dsMesaDataGridViewTextBoxColumn.Name = "dsMesaDataGridViewTextBoxColumn";
            this.dsMesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nrMesaDataGridViewTextBoxColumn
            // 
            this.nrMesaDataGridViewTextBoxColumn.DataPropertyName = "Nr_Mesa";
            this.nrMesaDataGridViewTextBoxColumn.HeaderText = "Nr. Mesa";
            this.nrMesaDataGridViewTextBoxColumn.Name = "nrMesaDataGridViewTextBoxColumn";
            this.nrMesaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stregistroDataGridViewTextBoxColumn
            // 
            this.stregistroDataGridViewTextBoxColumn.DataPropertyName = "st_registro";
            this.stregistroDataGridViewTextBoxColumn.HeaderText = "St. Registro";
            this.stregistroDataGridViewTextBoxColumn.Name = "stregistroDataGridViewTextBoxColumn";
            this.stregistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.stregistroDataGridViewTextBoxColumn.Visible = false;
            // 
            // st_balcao
            // 
            this.st_balcao.DataPropertyName = "st_balcao";
            this.st_balcao.HeaderText = "St. Balcão";
            this.st_balcao.Name = "st_balcao";
            this.st_balcao.ReadOnly = true;
            // 
            // FCadMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 443);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCadMesa";
            this.Text = "Cadastro de mesa";
            this.Load += new System.EventHandler(this.FCadMesa_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMesa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsMesa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_local;
        private Componentes.EditDefault id_local;
        private System.Windows.Forms.Button bb_tabelapreco;
        private Componentes.EditDefault editDefault2;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault3;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLocalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsMesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrMesaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stregistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn st_balcao;
    }
}