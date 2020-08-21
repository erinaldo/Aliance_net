namespace Fiscal.Cadastros
{
    partial class TFCadCondFiscalClifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCondFiscalClifor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Ds_condFiscal = new Componentes.EditDefault(this.components);
            this.BS_FiscalClifor = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cd_condFiscal_clifor = new Componentes.EditDefault(this.components);
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.BN_FiscalClifor = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_FiscalClifor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_FiscalClifor)).BeginInit();
            this.BN_FiscalClifor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.Ds_condFiscal);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.Cd_condFiscal_clifor);
            this.pDados.NM_ProcDeletar = "EXCLUI_FIS_CONDFISCAL_CLIFOR";
            this.pDados.NM_ProcGravar = "IA_FIS_CONDFISCAL_CLIFOR";
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCadastro);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // Ds_condFiscal
            // 
            this.Ds_condFiscal.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_condFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_condFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_condFiscal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_FiscalClifor, "Ds_condfiscal", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_condFiscal, "Ds_condFiscal");
            this.Ds_condFiscal.Name = "Ds_condFiscal";
            this.Ds_condFiscal.NM_Alias = "";
            this.Ds_condFiscal.NM_Campo = "Ds_condFiscal";
            this.Ds_condFiscal.NM_CampoBusca = "Ds_condFiscal";
            this.Ds_condFiscal.NM_Param = "@P_DS_CONDFISCAL";
            this.Ds_condFiscal.QTD_Zero = 0;
            this.Ds_condFiscal.ST_AutoInc = false;
            this.Ds_condFiscal.ST_DisableAuto = false;
            this.Ds_condFiscal.ST_Float = false;
            this.Ds_condFiscal.ST_Gravar = true;
            this.Ds_condFiscal.ST_Int = false;
            this.Ds_condFiscal.ST_LimpaCampo = true;
            this.Ds_condFiscal.ST_NotNull = true;
            this.Ds_condFiscal.ST_PrimaryKey = false;
            this.Ds_condFiscal.TextOld = null;
            // 
            // BS_FiscalClifor
            // 
            this.BS_FiscalClifor.DataSource = typeof(CamadaDados.Fiscal.TList_CadConFiscalClifor);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Cd_condFiscal_clifor
            // 
            this.Cd_condFiscal_clifor.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_condFiscal_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_condFiscal_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_condFiscal_clifor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_FiscalClifor, "Cd_condfiscal_clifor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Cd_condFiscal_clifor, "Cd_condFiscal_clifor");
            this.Cd_condFiscal_clifor.Name = "Cd_condFiscal_clifor";
            this.Cd_condFiscal_clifor.NM_Alias = "";
            this.Cd_condFiscal_clifor.NM_Campo = "Cd_condFiscal_clifor";
            this.Cd_condFiscal_clifor.NM_CampoBusca = "Cd_condFiscal_clifor";
            this.Cd_condFiscal_clifor.NM_Param = "@P_CD_CONDFISCAL_CLIFOR";
            this.Cd_condFiscal_clifor.QTD_Zero = 0;
            this.Cd_condFiscal_clifor.ST_AutoInc = false;
            this.Cd_condFiscal_clifor.ST_DisableAuto = true;
            this.Cd_condFiscal_clifor.ST_Float = false;
            this.Cd_condFiscal_clifor.ST_Gravar = true;
            this.Cd_condFiscal_clifor.ST_Int = false;
            this.Cd_condFiscal_clifor.ST_LimpaCampo = true;
            this.Cd_condFiscal_clifor.ST_NotNull = true;
            this.Cd_condFiscal_clifor.ST_PrimaryKey = true;
            this.Cd_condFiscal_clifor.TextOld = null;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gCadastro.DataSource = this.BS_FiscalClifor;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCadastro.Name = "gCadastro";
            this.gCadastro.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCadastro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCadastro.TabStop = false;
            // 
            // BN_FiscalClifor
            // 
            this.BN_FiscalClifor.AddNewItem = null;
            this.BN_FiscalClifor.CountItem = this.bindingNavigatorCountItem;
            this.BN_FiscalClifor.CountItemFormat = "de {0}";
            this.BN_FiscalClifor.DeleteItem = null;
            resources.ApplyResources(this.BN_FiscalClifor, "BN_FiscalClifor");
            this.BN_FiscalClifor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_FiscalClifor.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_FiscalClifor.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_FiscalClifor.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_FiscalClifor.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_FiscalClifor.Name = "BN_FiscalClifor";
            this.BN_FiscalClifor.PositionItem = this.bindingNavigatorPositionItem;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cd_condFiscal_clifor";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_condFiscal";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TFCadCondFiscalClifor
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.BN_FiscalClifor);
            this.Name = "TFCadCondFiscalClifor";
            this.Load += new System.EventHandler(this.TFCadCondFiscalClifor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCondFiscalClifor_FormClosing);
            this.Controls.SetChildIndex(this.BN_FiscalClifor, 0);
            this.Controls.SetChildIndex(this.tcCentral, 0);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_FiscalClifor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_FiscalClifor)).EndInit();
            this.BN_FiscalClifor.ResumeLayout(false);
            this.BN_FiscalClifor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault Ds_condFiscal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Cd_condFiscal_clifor;
        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.BindingSource BS_FiscalClifor;
        private System.Windows.Forms.BindingNavigator BN_FiscalClifor;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
