namespace Fiscal.Cadastros
{
    partial class TFCadNCM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadNCM));
            this.Ds_NCM = new Componentes.EditDefault(this.components);
            this.BS_NCM = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NCM = new Componentes.EditDefault(this.components);
            this.BN_NCM = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bbCorrigirProjeto = new System.Windows.Forms.ToolStripButton();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PC_AliquotaString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.Pc_Aliquota = new Componentes.EditFloat(this.components);
            this.lblNcm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CEST = new Componentes.EditDefault(this.components);
            this.bbSincronizar = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_NCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_NCM)).BeginInit();
            this.BN_NCM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_Aliquota)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.CEST);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.lblNcm);
            this.pDados.Controls.Add(this.Pc_Aliquota);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Ds_NCM);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.NCM);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.BN_NCM);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_NCM, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // Ds_NCM
            // 
            this.Ds_NCM.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_NCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_NCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_NCM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_NCM, "Ds_NCM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_NCM, "Ds_NCM");
            this.Ds_NCM.Name = "Ds_NCM";
            this.Ds_NCM.NM_Alias = "a";
            this.Ds_NCM.NM_Campo = "Ds_NCM";
            this.Ds_NCM.NM_CampoBusca = "Ds_NCM";
            this.Ds_NCM.NM_Param = "@P_DS_NCM";
            this.Ds_NCM.QTD_Zero = 0;
            this.Ds_NCM.ST_AutoInc = false;
            this.Ds_NCM.ST_DisableAuto = false;
            this.Ds_NCM.ST_Float = false;
            this.Ds_NCM.ST_Gravar = true;
            this.Ds_NCM.ST_Int = false;
            this.Ds_NCM.ST_LimpaCampo = true;
            this.Ds_NCM.ST_NotNull = true;
            this.Ds_NCM.ST_PrimaryKey = false;
            this.Ds_NCM.TextOld = null;
            // 
            // BS_NCM
            // 
            this.BS_NCM.DataSource = typeof(CamadaDados.Fiscal.TList_CadNCM);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NCM
            // 
            this.NCM.BackColor = System.Drawing.SystemColors.Window;
            this.NCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NCM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NCM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_NCM, "NCM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.NCM, "NCM");
            this.NCM.Name = "NCM";
            this.NCM.NM_Alias = "a";
            this.NCM.NM_Campo = "NCM";
            this.NCM.NM_CampoBusca = "NCM";
            this.NCM.NM_Param = "@P_NCM";
            this.NCM.QTD_Zero = 0;
            this.NCM.ST_AutoInc = false;
            this.NCM.ST_DisableAuto = false;
            this.NCM.ST_Float = false;
            this.NCM.ST_Gravar = true;
            this.NCM.ST_Int = false;
            this.NCM.ST_LimpaCampo = true;
            this.NCM.ST_NotNull = true;
            this.NCM.ST_PrimaryKey = true;
            this.NCM.TextOld = null;
            this.NCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NCM_KeyPress);
            // 
            // BN_NCM
            // 
            this.BN_NCM.AddNewItem = null;
            this.BN_NCM.BindingSource = this.BS_NCM;
            this.BN_NCM.CountItem = this.bindingNavigatorCountItem;
            this.BN_NCM.CountItemFormat = "de {0}";
            this.BN_NCM.DeleteItem = null;
            resources.ApplyResources(this.BN_NCM, "BN_NCM");
            this.BN_NCM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bbCorrigirProjeto,
            this.bbSincronizar});
            this.BN_NCM.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_NCM.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_NCM.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_NCM.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_NCM.Name = "BN_NCM";
            this.BN_NCM.PositionItem = this.bindingNavigatorPositionItem;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            // 
            // bindingNavigatorPositionItem
            // 
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // bbCorrigirProjeto
            // 
            resources.ApplyResources(this.bbCorrigirProjeto, "bbCorrigirProjeto");
            this.bbCorrigirProjeto.Name = "bbCorrigirProjeto";
            this.bbCorrigirProjeto.Click += new System.EventHandler(this.bbCorrigirProjeto_Click);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn3,
            this.PC_AliquotaString,
            this.dataGridViewTextBoxColumn2,
            this.cFDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.BS_NCM;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gCadastro.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "NCM";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Ds_NCM";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // PC_AliquotaString
            // 
            this.PC_AliquotaString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PC_AliquotaString.DataPropertyName = "PC_AliquotaString";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = "0";
            this.PC_AliquotaString.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.PC_AliquotaString, "PC_AliquotaString");
            this.PC_AliquotaString.Name = "PC_AliquotaString";
            this.PC_AliquotaString.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CEST";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // cFDataGridViewTextBoxColumn
            // 
            this.cFDataGridViewTextBoxColumn.DataPropertyName = "CF";
            resources.ApplyResources(this.cFDataGridViewTextBoxColumn, "cFDataGridViewTextBoxColumn");
            this.cFDataGridViewTextBoxColumn.Name = "cFDataGridViewTextBoxColumn";
            this.cFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Pc_Aliquota
            // 
            this.Pc_Aliquota.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_NCM, "PC_Aliquota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Pc_Aliquota.DecimalPlaces = 2;
            resources.ApplyResources(this.Pc_Aliquota, "Pc_Aliquota");
            this.Pc_Aliquota.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Pc_Aliquota.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.Pc_Aliquota.Name = "Pc_Aliquota";
            this.Pc_Aliquota.NM_Alias = "a";
            this.Pc_Aliquota.NM_Campo = "PC_Aliquota";
            this.Pc_Aliquota.NM_Param = "@P_PC_ALIQUOTA";
            this.Pc_Aliquota.Operador = "";
            this.Pc_Aliquota.ST_AutoInc = false;
            this.Pc_Aliquota.ST_DisableAuto = false;
            this.Pc_Aliquota.ST_Gravar = true;
            this.Pc_Aliquota.ST_LimparCampo = true;
            this.Pc_Aliquota.ST_NotNull = false;
            this.Pc_Aliquota.ST_PrimaryKey = false;
            // 
            // lblNcm
            // 
            resources.ApplyResources(this.lblNcm, "lblNcm");
            this.lblNcm.Name = "lblNcm";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // CEST
            // 
            this.CEST.BackColor = System.Drawing.SystemColors.Window;
            this.CEST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CEST.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CEST.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_NCM, "CEST", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.CEST, "CEST");
            this.CEST.Name = "CEST";
            this.CEST.NM_Alias = "";
            this.CEST.NM_Campo = "";
            this.CEST.NM_CampoBusca = "";
            this.CEST.NM_Param = "";
            this.CEST.QTD_Zero = 0;
            this.CEST.ST_AutoInc = false;
            this.CEST.ST_DisableAuto = false;
            this.CEST.ST_Float = false;
            this.CEST.ST_Gravar = true;
            this.CEST.ST_Int = true;
            this.CEST.ST_LimpaCampo = true;
            this.CEST.ST_NotNull = false;
            this.CEST.ST_PrimaryKey = false;
            this.CEST.TextOld = null;
            // 
            // bbSincronizar
            // 
            resources.ApplyResources(this.bbSincronizar, "bbSincronizar");
            this.bbSincronizar.Name = "bbSincronizar";
            this.bbSincronizar.Click += new System.EventHandler(this.bbSincronizar_Click);
            // 
            // TFCadNCM
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCadNCM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadNCM_FormClosing);
            this.Load += new System.EventHandler(this.TFCadNCM_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_NCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_NCM)).EndInit();
            this.BN_NCM.ResumeLayout(false);
            this.BN_NCM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_Aliquota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_NCM;
        private Componentes.EditDefault Ds_NCM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault NCM;
        private System.Windows.Forms.BindingNavigator BN_NCM;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat Pc_Aliquota;
        private System.Windows.Forms.Label lblNcm;
        private Componentes.EditDefault CEST;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCMPaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn PC_AliquotaString;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton bbCorrigirProjeto;
        private System.Windows.Forms.ToolStripButton bbSincronizar;
    }
}