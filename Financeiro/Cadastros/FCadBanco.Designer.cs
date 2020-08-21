namespace Financeiro.Cadastros
{
    partial class TFCadBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadBanco));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fCD_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDS_Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BS_CadBanco = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cd_banco = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_banco = new Componentes.EditDefault(this.components);
            this.BS_Navigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bb_layout = new System.Windows.Forms.Button();
            this.bordainferior = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cdbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bordainferiorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBanco = new Componentes.DataGridDefault(this.components);
            this.cdbancoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitoDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsbancoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bordainferiorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).BeginInit();
            this.BS_Navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bordainferior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBanco)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bordainferior);
            this.pDados.Controls.Add(this.bb_layout);
            this.pDados.Controls.Add(this.ds_banco);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_banco);
            this.pDados.Controls.Add(this.label1);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_BANCO";
            this.pDados.NM_ProcGravar = "IA_FIN_BANCO";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gBanco);
            this.tpPadrao.Controls.Add(this.BS_Navigator);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.BS_Navigator, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gBanco, 0);
            // 
            // fCD_Banco
            // 
            this.fCD_Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fCD_Banco.DataPropertyName = "cd_banco";
            resources.ApplyResources(this.fCD_Banco, "fCD_Banco");
            this.fCD_Banco.Name = "fCD_Banco";
            this.fCD_Banco.ReadOnly = true;
            // 
            // digitoDataGridViewTextBoxColumn
            // 
            this.digitoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.digitoDataGridViewTextBoxColumn.DataPropertyName = "Digito";
            resources.ApplyResources(this.digitoDataGridViewTextBoxColumn, "digitoDataGridViewTextBoxColumn");
            this.digitoDataGridViewTextBoxColumn.Name = "digitoDataGridViewTextBoxColumn";
            this.digitoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fDS_Banco
            // 
            this.fDS_Banco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fDS_Banco.DataPropertyName = "ds_banco";
            resources.ApplyResources(this.fDS_Banco, "fDS_Banco");
            this.fDS_Banco.Name = "fDS_Banco";
            this.fDS_Banco.ReadOnly = true;
            // 
            // BS_CadBanco
            // 
            this.BS_CadBanco.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadBanco);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cd_banco
            // 
            this.cd_banco.BackColor = System.Drawing.SystemColors.Window;
            this.cd_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadBanco, "Cd_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.cd_banco, "cd_banco");
            this.cd_banco.Name = "cd_banco";
            this.cd_banco.NM_Alias = "";
            this.cd_banco.NM_Campo = "cd_banco";
            this.cd_banco.NM_CampoBusca = "cd_banco";
            this.cd_banco.NM_Param = "@P_CD_BANCO";
            this.cd_banco.QTD_Zero = 0;
            this.cd_banco.ST_AutoInc = false;
            this.cd_banco.ST_DisableAuto = true;
            this.cd_banco.ST_Float = false;
            this.cd_banco.ST_Gravar = true;
            this.cd_banco.ST_Int = false;
            this.cd_banco.ST_LimpaCampo = true;
            this.cd_banco.ST_NotNull = true;
            this.cd_banco.ST_PrimaryKey = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ds_banco
            // 
            this.ds_banco.BackColor = System.Drawing.SystemColors.Window;
            this.ds_banco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_banco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CadBanco, "Ds_banco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_banco, "ds_banco");
            this.ds_banco.Name = "ds_banco";
            this.ds_banco.NM_Alias = "";
            this.ds_banco.NM_Campo = "ds_banco";
            this.ds_banco.NM_CampoBusca = "ds_banco";
            this.ds_banco.NM_Param = "@P_DS_BANCO";
            this.ds_banco.QTD_Zero = 0;
            this.ds_banco.ST_AutoInc = false;
            this.ds_banco.ST_DisableAuto = false;
            this.ds_banco.ST_Float = false;
            this.ds_banco.ST_Gravar = true;
            this.ds_banco.ST_Int = false;
            this.ds_banco.ST_LimpaCampo = true;
            this.ds_banco.ST_NotNull = true;
            this.ds_banco.ST_PrimaryKey = false;
            // 
            // BS_Navigator
            // 
            this.BS_Navigator.AddNewItem = null;
            this.BS_Navigator.BindingSource = this.BS_CadBanco;
            this.BS_Navigator.CountItem = this.bindingNavigatorCountItem;
            this.BS_Navigator.DeleteItem = null;
            resources.ApplyResources(this.BS_Navigator, "BS_Navigator");
            this.BS_Navigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BS_Navigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BS_Navigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BS_Navigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BS_Navigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BS_Navigator.Name = "BS_Navigator";
            this.BS_Navigator.PositionItem = this.bindingNavigatorPositionItem;
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
            // bb_layout
            // 
            resources.ApplyResources(this.bb_layout, "bb_layout");
            this.bb_layout.Name = "bb_layout";
            this.bb_layout.UseVisualStyleBackColor = true;
            this.bb_layout.Click += new System.EventHandler(this.bb_layout_Click);
            // 
            // bordainferior
            // 
            this.bordainferior.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_CadBanco, "Bordainferior", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.bordainferior, "bordainferior");
            this.bordainferior.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.bordainferior.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bordainferior.Name = "bordainferior";
            this.bordainferior.NM_Alias = "";
            this.bordainferior.NM_Campo = "";
            this.bordainferior.NM_Param = "";
            this.bordainferior.Operador = "";
            this.bordainferior.ST_AutoInc = false;
            this.bordainferior.ST_DisableAuto = false;
            this.bordainferior.ST_Gravar = true;
            this.bordainferior.ST_LimparCampo = true;
            this.bordainferior.ST_NotNull = false;
            this.bordainferior.ST_PrimaryKey = false;
            this.bordainferior.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cdbancoDataGridViewTextBoxColumn
            // 
            this.cdbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn.DataPropertyName = "Cd_banco";
            resources.ApplyResources(this.cdbancoDataGridViewTextBoxColumn, "cdbancoDataGridViewTextBoxColumn");
            this.cdbancoDataGridViewTextBoxColumn.Name = "cdbancoDataGridViewTextBoxColumn";
            this.cdbancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // digitoDataGridViewTextBoxColumn1
            // 
            this.digitoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.digitoDataGridViewTextBoxColumn1.DataPropertyName = "Digito";
            resources.ApplyResources(this.digitoDataGridViewTextBoxColumn1, "digitoDataGridViewTextBoxColumn1");
            this.digitoDataGridViewTextBoxColumn1.Name = "digitoDataGridViewTextBoxColumn1";
            this.digitoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dsbancoDataGridViewTextBoxColumn
            // 
            this.dsbancoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn.DataPropertyName = "Ds_banco";
            resources.ApplyResources(this.dsbancoDataGridViewTextBoxColumn, "dsbancoDataGridViewTextBoxColumn");
            this.dsbancoDataGridViewTextBoxColumn.Name = "dsbancoDataGridViewTextBoxColumn";
            this.dsbancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bordainferiorDataGridViewTextBoxColumn
            // 
            this.bordainferiorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bordainferiorDataGridViewTextBoxColumn.DataPropertyName = "Bordainferior";
            resources.ApplyResources(this.bordainferiorDataGridViewTextBoxColumn, "bordainferiorDataGridViewTextBoxColumn");
            this.bordainferiorDataGridViewTextBoxColumn.Name = "bordainferiorDataGridViewTextBoxColumn";
            this.bordainferiorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gBanco
            // 
            this.gBanco.AllowUserToAddRows = false;
            this.gBanco.AllowUserToDeleteRows = false;
            this.gBanco.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBanco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBanco.AutoGenerateColumns = false;
            this.gBanco.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBanco.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBanco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBanco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBanco.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdbancoDataGridViewTextBoxColumn1,
            this.digitoDataGridViewTextBoxColumn2,
            this.dsbancoDataGridViewTextBoxColumn1,
            this.bordainferiorDataGridViewTextBoxColumn1});
            this.gBanco.DataSource = this.BS_CadBanco;
            resources.ApplyResources(this.gBanco, "gBanco");
            this.gBanco.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBanco.Name = "gBanco";
            this.gBanco.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBanco.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gBanco.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gBanco_ColumnHeaderMouseClick);
            // 
            // cdbancoDataGridViewTextBoxColumn1
            // 
            this.cdbancoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdbancoDataGridViewTextBoxColumn1.DataPropertyName = "Cd_banco";
            resources.ApplyResources(this.cdbancoDataGridViewTextBoxColumn1, "cdbancoDataGridViewTextBoxColumn1");
            this.cdbancoDataGridViewTextBoxColumn1.Name = "cdbancoDataGridViewTextBoxColumn1";
            this.cdbancoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // digitoDataGridViewTextBoxColumn2
            // 
            this.digitoDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.digitoDataGridViewTextBoxColumn2.DataPropertyName = "Digito";
            resources.ApplyResources(this.digitoDataGridViewTextBoxColumn2, "digitoDataGridViewTextBoxColumn2");
            this.digitoDataGridViewTextBoxColumn2.Name = "digitoDataGridViewTextBoxColumn2";
            this.digitoDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dsbancoDataGridViewTextBoxColumn1
            // 
            this.dsbancoDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsbancoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_banco";
            resources.ApplyResources(this.dsbancoDataGridViewTextBoxColumn1, "dsbancoDataGridViewTextBoxColumn1");
            this.dsbancoDataGridViewTextBoxColumn1.Name = "dsbancoDataGridViewTextBoxColumn1";
            this.dsbancoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bordainferiorDataGridViewTextBoxColumn1
            // 
            this.bordainferiorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bordainferiorDataGridViewTextBoxColumn1.DataPropertyName = "Bordainferior";
            resources.ApplyResources(this.bordainferiorDataGridViewTextBoxColumn1, "bordainferiorDataGridViewTextBoxColumn1");
            this.bordainferiorDataGridViewTextBoxColumn1.Name = "bordainferiorDataGridViewTextBoxColumn1";
            this.bordainferiorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // TFCadBanco
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCadBanco";
            this.Load += new System.EventHandler(this.TFCadBanco_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadBanco_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CadBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Navigator)).EndInit();
            this.BS_Navigator.ResumeLayout(false);
            this.BS_Navigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bordainferior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBanco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_banco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_banco;
        private System.Windows.Forms.BindingSource BS_CadBanco;
        private System.Windows.Forms.BindingNavigator BS_Navigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrchequeseqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCD_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDS_Banco;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button bb_layout;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat bordainferior;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bordainferiorDataGridViewTextBoxColumn;
        private Componentes.DataGridDefault gBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdbancoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn digitoDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsbancoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bordainferiorDataGridViewTextBoxColumn1;
    }
}
