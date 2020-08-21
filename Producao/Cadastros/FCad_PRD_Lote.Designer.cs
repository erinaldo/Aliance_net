namespace Producao.Cadastros
{
    partial class TFCad_PRD_Lote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_PRD_Lote));
            this.BS_Lote = new System.Windows.Forms.BindingSource(this.components);
            this.Cd_loteID = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.Ds_loteproducao = new Componentes.EditDefault(this.components);
            this.Nr_loteproducao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gLote_Producao = new Componentes.DataGridDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dt_inivigencia = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_finvigencia = new Componentes.EditData(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_inivigenciastr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_finvigenciastr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLote_Producao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.dt_finvigencia);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.dt_inivigencia);
            this.pDados.Controls.Add(this.Cd_loteID);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.Ds_loteproducao);
            this.pDados.Controls.Add(this.Nr_loteproducao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            resources.ApplyResources(this.pDados, "pDados");
            // 
            // tcCentral
            // 
            resources.ApplyResources(this.tcCentral, "tcCentral");
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gLote_Producao);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gLote_Producao, 0);
            // 
            // BS_Lote
            // 
            this.BS_Lote.DataSource = typeof(CamadaDados.Producao.Cadastros.TList_CadLote);
            // 
            // Cd_loteID
            // 
            this.Cd_loteID.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_loteID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_loteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_loteID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lote, "Cd_loteID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Cd_loteID, "Cd_loteID");
            this.Cd_loteID.Name = "Cd_loteID";
            this.Cd_loteID.NM_Alias = "a";
            this.Cd_loteID.NM_Campo = "id_ice";
            this.Cd_loteID.NM_CampoBusca = "id_ice";
            this.Cd_loteID.NM_Param = "@P_ID_ICE";
            this.Cd_loteID.QTD_Zero = 0;
            this.Cd_loteID.ST_AutoInc = false;
            this.Cd_loteID.ST_DisableAuto = true;
            this.Cd_loteID.ST_Float = false;
            this.Cd_loteID.ST_Gravar = true;
            this.Cd_loteID.ST_Int = false;
            this.Cd_loteID.ST_LimpaCampo = true;
            this.Cd_loteID.ST_NotNull = false;
            this.Cd_loteID.ST_PrimaryKey = false;
            this.Cd_loteID.TextOld = null;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // Ds_loteproducao
            // 
            this.Ds_loteproducao.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_loteproducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_loteproducao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_loteproducao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lote, "Ds_loteproducao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_loteproducao, "Ds_loteproducao");
            this.Ds_loteproducao.Name = "Ds_loteproducao";
            this.Ds_loteproducao.NM_Alias = "a";
            this.Ds_loteproducao.NM_Campo = "DS_ItemCustoEsforco";
            this.Ds_loteproducao.NM_CampoBusca = "DS_ItemCustoEsforco";
            this.Ds_loteproducao.NM_Param = "@P_DS_ITEMCUSTOESFORCO";
            this.Ds_loteproducao.QTD_Zero = 0;
            this.Ds_loteproducao.ST_AutoInc = false;
            this.Ds_loteproducao.ST_DisableAuto = true;
            this.Ds_loteproducao.ST_Float = false;
            this.Ds_loteproducao.ST_Gravar = true;
            this.Ds_loteproducao.ST_Int = false;
            this.Ds_loteproducao.ST_LimpaCampo = true;
            this.Ds_loteproducao.ST_NotNull = true;
            this.Ds_loteproducao.ST_PrimaryKey = false;
            this.Ds_loteproducao.TextOld = null;
            // 
            // Nr_loteproducao
            // 
            this.Nr_loteproducao.BackColor = System.Drawing.SystemColors.Window;
            this.Nr_loteproducao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Nr_loteproducao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr_loteproducao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lote, "Nr_loteproducao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Nr_loteproducao, "Nr_loteproducao");
            this.Nr_loteproducao.Name = "Nr_loteproducao";
            this.Nr_loteproducao.NM_Alias = "";
            this.Nr_loteproducao.NM_Campo = "";
            this.Nr_loteproducao.NM_CampoBusca = "";
            this.Nr_loteproducao.NM_Param = "";
            this.Nr_loteproducao.QTD_Zero = 0;
            this.Nr_loteproducao.ST_AutoInc = true;
            this.Nr_loteproducao.ST_DisableAuto = true;
            this.Nr_loteproducao.ST_Float = true;
            this.Nr_loteproducao.ST_Gravar = true;
            this.Nr_loteproducao.ST_Int = true;
            this.Nr_loteproducao.ST_LimpaCampo = true;
            this.Nr_loteproducao.ST_NotNull = true;
            this.Nr_loteproducao.ST_PrimaryKey = true;
            this.Nr_loteproducao.TextOld = null;
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
            // gLote_Producao
            // 
            this.gLote_Producao.AllowUserToAddRows = false;
            this.gLote_Producao.AllowUserToDeleteRows = false;
            this.gLote_Producao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gLote_Producao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gLote_Producao.AutoGenerateColumns = false;
            this.gLote_Producao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gLote_Producao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gLote_Producao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLote_Producao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gLote_Producao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gLote_Producao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Dt_inivigenciastr,
            this.Dt_finvigenciastr});
            this.gLote_Producao.DataSource = this.BS_Lote;
            resources.ApplyResources(this.gLote_Producao, "gLote_Producao");
            this.gLote_Producao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gLote_Producao.Name = "gLote_Producao";
            this.gLote_Producao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gLote_Producao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.BS_Lote;
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
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
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
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            resources.ApplyResources(this.bindingNavigatorSeparator2, "bindingNavigatorSeparator2");
            // 
            // dt_inivigencia
            // 
            this.dt_inivigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_inivigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lote, "Dt_inivigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_inivigencia, "dt_inivigencia");
            this.dt_inivigencia.Name = "dt_inivigencia";
            this.dt_inivigencia.NM_Alias = "";
            this.dt_inivigencia.NM_Campo = "";
            this.dt_inivigencia.NM_CampoBusca = "";
            this.dt_inivigencia.NM_Param = "";
            this.dt_inivigencia.Operador = "";
            this.dt_inivigencia.ST_Gravar = true;
            this.dt_inivigencia.ST_LimpaCampo = true;
            this.dt_inivigencia.ST_NotNull = true;
            this.dt_inivigencia.ST_PrimaryKey = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // dt_finvigencia
            // 
            this.dt_finvigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_finvigencia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Lote, "Dt_finvigenciastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.dt_finvigencia, "dt_finvigencia");
            this.dt_finvigencia.Name = "dt_finvigencia";
            this.dt_finvigencia.NM_Alias = "";
            this.dt_finvigencia.NM_Campo = "";
            this.dt_finvigencia.NM_CampoBusca = "";
            this.dt_finvigencia.NM_Param = "";
            this.dt_finvigencia.Operador = "";
            this.dt_finvigencia.ST_Gravar = true;
            this.dt_finvigencia.ST_LimpaCampo = true;
            this.dt_finvigencia.ST_NotNull = true;
            this.dt_finvigencia.ST_PrimaryKey = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "Nr_loteproducao";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "Ds_loteproducao";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "Cd_loteID";
            resources.ApplyResources(this.Column4, "Column4");
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Dt_inivigenciastr
            // 
            this.Dt_inivigenciastr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_inivigenciastr.DataPropertyName = "Dt_inivigenciastr";
            resources.ApplyResources(this.Dt_inivigenciastr, "Dt_inivigenciastr");
            this.Dt_inivigenciastr.Name = "Dt_inivigenciastr";
            this.Dt_inivigenciastr.ReadOnly = true;
            // 
            // Dt_finvigenciastr
            // 
            this.Dt_finvigenciastr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_finvigenciastr.DataPropertyName = "Dt_finvigenciastr";
            resources.ApplyResources(this.Dt_finvigenciastr, "Dt_finvigenciastr");
            this.Dt_finvigenciastr.Name = "Dt_finvigenciastr";
            this.Dt_finvigenciastr.ReadOnly = true;
            // 
            // TFCad_PRD_Lote
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "TFCad_PRD_Lote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCad_PRD_Lote_FormClosing);
            this.Load += new System.EventHandler(this.TFCad_PRD_Lote_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Lote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gLote_Producao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource BS_Lote;
        private Componentes.EditDefault Cd_loteID;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault Ds_loteproducao;
        private Componentes.EditDefault Nr_loteproducao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Componentes.DataGridDefault gLote_Producao;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Label label6;
        private Componentes.EditData dt_finvigencia;
        private System.Windows.Forms.Label label5;
        private Componentes.EditData dt_inivigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_inivigenciastr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_finvigenciastr;
    }
}
