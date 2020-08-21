namespace Financeiro.Cadastros
{
    partial class TFCadUF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadUF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.BS_CadUf = new System.Windows.Forms.BindingSource(this.components);
            this.cd_uf = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uf = new Componentes.EditDefault(this.components);
            this.ds_uf = new Componentes.EditDefault(this.components);
            this.BN_CadUF = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pc_aliquotaicms = new Componentes.EditFloat(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCD_UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fUF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDS_UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadUf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadUF)).BeginInit();
            this.BN_CadUF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquotaicms)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.pc_aliquotaicms);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.ds_uf);
            this.pDados.Controls.Add(this.uf);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cd_uf);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_UF";
            this.pDados.NM_ProcGravar = "IA_FIN_UF";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.BN_CadUF);
            this.tpPadrao.Controls.Add(this.gCadastro);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            this.tpPadrao.Controls.SetChildIndex(this.BN_CadUF, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCadastro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCadastro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCadastro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.fCD_UF,
            this.fUF,
            this.fDS_UF,
            this.dataGridViewTextBoxColumn1});
            this.gCadastro.DataSource = this.BS_CadUf;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gCadastro.TabStop = false;
            // 
            // BS_CadUf
            // 
            this.BS_CadUf.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadUf);
            // 
            // cd_uf
            // 
            this.cd_uf.BackColor = System.Drawing.SystemColors.Window;
            this.cd_uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUf, "Cd_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_uf, "cd_uf");
            this.cd_uf.Name = "cd_uf";
            this.cd_uf.NM_Alias = "";
            this.cd_uf.NM_Campo = "cd_uf";
            this.cd_uf.NM_CampoBusca = "cd_uf";
            this.cd_uf.NM_Param = "@P_CD_UF";
            this.cd_uf.QTD_Zero = 0;
            this.cd_uf.ST_AutoInc = false;
            this.cd_uf.ST_DisableAuto = false;
            this.cd_uf.ST_Float = false;
            this.cd_uf.ST_Gravar = true;
            this.cd_uf.ST_Int = false;
            this.cd_uf.ST_LimpaCampo = true;
            this.cd_uf.ST_NotNull = true;
            this.cd_uf.ST_PrimaryKey = true;
            this.cd_uf.TextOld = null;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // uf
            // 
            this.uf.BackColor = System.Drawing.SystemColors.Window;
            this.uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUf, "Uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.uf, "uf");
            this.uf.Name = "uf";
            this.uf.NM_Alias = "";
            this.uf.NM_Campo = "uf";
            this.uf.NM_CampoBusca = "uf";
            this.uf.NM_Param = "@P_UF";
            this.uf.QTD_Zero = 0;
            this.uf.ST_AutoInc = false;
            this.uf.ST_DisableAuto = false;
            this.uf.ST_Float = false;
            this.uf.ST_Gravar = true;
            this.uf.ST_Int = false;
            this.uf.ST_LimpaCampo = true;
            this.uf.ST_NotNull = true;
            this.uf.ST_PrimaryKey = false;
            this.uf.TextOld = null;
            // 
            // ds_uf
            // 
            this.ds_uf.BackColor = System.Drawing.SystemColors.Window;
            this.ds_uf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_uf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_uf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadUf, "Ds_uf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_uf, "ds_uf");
            this.ds_uf.Name = "ds_uf";
            this.ds_uf.NM_Alias = "";
            this.ds_uf.NM_Campo = "ds_uf";
            this.ds_uf.NM_CampoBusca = "ds_uf";
            this.ds_uf.NM_Param = "@P_DS_UF";
            this.ds_uf.QTD_Zero = 0;
            this.ds_uf.ST_AutoInc = false;
            this.ds_uf.ST_DisableAuto = false;
            this.ds_uf.ST_Float = false;
            this.ds_uf.ST_Gravar = true;
            this.ds_uf.ST_Int = false;
            this.ds_uf.ST_LimpaCampo = true;
            this.ds_uf.ST_NotNull = true;
            this.ds_uf.ST_PrimaryKey = false;
            this.ds_uf.TextOld = null;
            // 
            // BN_CadUF
            // 
            this.BN_CadUF.AddNewItem = null;
            this.BN_CadUF.BindingSource = this.BS_CadUf;
            this.BN_CadUF.CountItem = this.bindingNavigatorCountItem;
            this.BN_CadUF.CountItemFormat = "de {0}";
            this.BN_CadUF.DeleteItem = null;
            resources.ApplyResources(this.BN_CadUF, "BN_CadUF");
            this.BN_CadUF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_CadUF.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_CadUF.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_CadUF.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_CadUF.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_CadUF.Name = "BN_CadUF";
            this.BN_CadUF.PositionItem = this.bindingNavigatorPositionItem;
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // pc_aliquotaicms
            // 
            this.pc_aliquotaicms.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CadUf, "Pc_aliquotaicms", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_aliquotaicms.DecimalPlaces = 2;
            resources.ApplyResources(this.pc_aliquotaicms, "pc_aliquotaicms");
            this.pc_aliquotaicms.Name = "pc_aliquotaicms";
            this.pc_aliquotaicms.NM_Alias = "";
            this.pc_aliquotaicms.NM_Campo = "";
            this.pc_aliquotaicms.NM_Param = "";
            this.pc_aliquotaicms.Operador = "";
            this.pc_aliquotaicms.ST_AutoInc = false;
            this.pc_aliquotaicms.ST_DisableAuto = false;
            this.pc_aliquotaicms.ST_Gravar = true;
            this.pc_aliquotaicms.ST_LimparCampo = true;
            this.pc_aliquotaicms.ST_NotNull = false;
            this.pc_aliquotaicms.ST_PrimaryKey = false;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            resources.ApplyResources(this.statusDataGridViewTextBoxColumn, "statusDataGridViewTextBoxColumn");
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fCD_UF
            // 
            this.fCD_UF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fCD_UF.DataPropertyName = "Cd_uf";
            resources.ApplyResources(this.fCD_UF, "fCD_UF");
            this.fCD_UF.Name = "fCD_UF";
            this.fCD_UF.ReadOnly = true;
            // 
            // fUF
            // 
            this.fUF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fUF.DataPropertyName = "Uf";
            resources.ApplyResources(this.fUF, "fUF");
            this.fUF.Name = "fUF";
            this.fUF.ReadOnly = true;
            // 
            // fDS_UF
            // 
            this.fDS_UF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fDS_UF.DataPropertyName = "Ds_uf";
            resources.ApplyResources(this.fDS_UF, "fDS_UF");
            this.fDS_UF.Name = "fDS_UF";
            this.fDS_UF.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Pc_aliquotaicms";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TFCadUF
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadUF";
            this.Load += new System.EventHandler(this.TFCadUF_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadUF_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadUf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_CadUF)).EndInit();
            this.BN_CadUF.ResumeLayout(false);
            this.BN_CadUF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_aliquotaicms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault cd_uf;
        private Componentes.DataGridDefault gCadastro;
        private Componentes.EditDefault ds_uf;
        private Componentes.EditDefault uf;
        private System.Windows.Forms.BindingSource BS_CadUf;
        private System.Windows.Forms.BindingNavigator BN_CadUF;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditFloat pc_aliquotaicms;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCD_UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn fUF;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDS_UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
