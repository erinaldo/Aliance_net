namespace Producao.Cadastros
{
    partial class TFCad_PRD_Custos
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
            System.Windows.Forms.Label ds_custoLabel;
            System.Windows.Forms.Label id_custoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_PRD_Custos));
            this.bsCustos = new System.Windows.Forms.BindingSource(this.components);
            this.ds_custoEditDefault = new Componentes.EditDefault(this.components);
            this.tList_Cad_PRD_CustosDataGridDefault = new Componentes.DataGridDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_custo = new Componentes.EditDefault(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ds_custoLabel = new System.Windows.Forms.Label();
            id_custoLabel = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList_Cad_PRD_CustosDataGridDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.id_custo);
            this.pDados.Controls.Add(ds_custoLabel);
            this.pDados.Controls.Add(this.ds_custoEditDefault);
            this.pDados.Controls.Add(id_custoLabel);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.Add(this.tList_Cad_PRD_CustosDataGridDefault);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.tList_Cad_PRD_CustosDataGridDefault, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            // 
            // ds_custoLabel
            // 
            resources.ApplyResources(ds_custoLabel, "ds_custoLabel");
            ds_custoLabel.Name = "ds_custoLabel";
            // 
            // id_custoLabel
            // 
            resources.ApplyResources(id_custoLabel, "id_custoLabel");
            id_custoLabel.Name = "id_custoLabel";
            // 
            // bsCustos
            // 
            this.bsCustos.DataSource = typeof(CamadaDados.Producao.Cadastros.TRegistro_Cad_PRD_Custos);
            // 
            // ds_custoEditDefault
            // 
            this.ds_custoEditDefault.BackColor = System.Drawing.SystemColors.Window;
            this.ds_custoEditDefault.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_custoEditDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_custoEditDefault.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustos, "Ds_custo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.ds_custoEditDefault, "ds_custoEditDefault");
            this.ds_custoEditDefault.Name = "ds_custoEditDefault";
            this.ds_custoEditDefault.NM_Alias = "";
            this.ds_custoEditDefault.NM_Campo = "ds_custo";
            this.ds_custoEditDefault.NM_CampoBusca = "ds_custo";
            this.ds_custoEditDefault.NM_Param = "@P_DS_CUSTO";
            this.ds_custoEditDefault.QTD_Zero = 0;
            this.ds_custoEditDefault.ST_AutoInc = false;
            this.ds_custoEditDefault.ST_DisableAuto = false;
            this.ds_custoEditDefault.ST_Float = false;
            this.ds_custoEditDefault.ST_Gravar = true;
            this.ds_custoEditDefault.ST_Int = false;
            this.ds_custoEditDefault.ST_LimpaCampo = true;
            this.ds_custoEditDefault.ST_NotNull = true;
            this.ds_custoEditDefault.ST_PrimaryKey = false;
            this.ds_custoEditDefault.TextOld = null;
            // 
            // tList_Cad_PRD_CustosDataGridDefault
            // 
            this.tList_Cad_PRD_CustosDataGridDefault.AllowUserToAddRows = false;
            this.tList_Cad_PRD_CustosDataGridDefault.AllowUserToDeleteRows = false;
            this.tList_Cad_PRD_CustosDataGridDefault.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.tList_Cad_PRD_CustosDataGridDefault.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tList_Cad_PRD_CustosDataGridDefault.AutoGenerateColumns = false;
            this.tList_Cad_PRD_CustosDataGridDefault.BackgroundColor = System.Drawing.Color.LightGray;
            this.tList_Cad_PRD_CustosDataGridDefault.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tList_Cad_PRD_CustosDataGridDefault.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_Cad_PRD_CustosDataGridDefault.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tList_Cad_PRD_CustosDataGridDefault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tList_Cad_PRD_CustosDataGridDefault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.tList_Cad_PRD_CustosDataGridDefault.DataSource = this.bsCustos;
            resources.ApplyResources(this.tList_Cad_PRD_CustosDataGridDefault, "tList_Cad_PRD_CustosDataGridDefault");
            this.tList_Cad_PRD_CustosDataGridDefault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tList_Cad_PRD_CustosDataGridDefault.Name = "tList_Cad_PRD_CustosDataGridDefault";
            this.tList_Cad_PRD_CustosDataGridDefault.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tList_Cad_PRD_CustosDataGridDefault.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tList_Cad_PRD_CustosDataGridDefault.TabStop = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsCustos;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
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
            // id_custo
            // 
            this.id_custo.BackColor = System.Drawing.SystemColors.Window;
            this.id_custo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_custo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_custo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCustos, "Id_custostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.id_custo, "id_custo");
            this.id_custo.Name = "id_custo";
            this.id_custo.NM_Alias = "";
            this.id_custo.NM_Campo = "id_custo";
            this.id_custo.NM_CampoBusca = "id_custo";
            this.id_custo.NM_Param = "@P_ID_CUSTO";
            this.id_custo.QTD_Zero = 0;
            this.id_custo.ST_AutoInc = false;
            this.id_custo.ST_DisableAuto = true;
            this.id_custo.ST_Float = false;
            this.id_custo.ST_Gravar = true;
            this.id_custo.ST_Int = true;
            this.id_custo.ST_LimpaCampo = true;
            this.id_custo.ST_NotNull = true;
            this.id_custo.ST_PrimaryKey = true;
            this.id_custo.TextOld = null;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id_custostr";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Ds_custo";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TFCad_PRD_Custos
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCad_PRD_Custos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_PRD_Custos_FormClosing);
            this.Load += new System.EventHandler(this.TFCad_PRD_Custos_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tList_Cad_PRD_CustosDataGridDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bsCustos;
        private Componentes.EditDefault ds_custoEditDefault;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault tList_Cad_PRD_CustosDataGridDefault;
        private Componentes.EditDefault id_custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}
