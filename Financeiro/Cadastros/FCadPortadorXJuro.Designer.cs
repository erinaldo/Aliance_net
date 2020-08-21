namespace Financeiro.Cadastros
{
    partial class TFCadPortadorXJuro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadPortadorXJuro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gCadastro = new Componentes.DataGridDefault(this.components);
            this.cdjuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsjuroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsportadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsPortJuro = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bb_juro = new System.Windows.Forms.Button();
            this.bb_portador = new System.Windows.Forms.Button();
            this.ds_juro = new Componentes.EditDefault(this.components);
            this.cd_juro = new Componentes.EditDefault(this.components);
            this.ds_portador = new Componentes.EditDefault(this.components);
            this.cd_portador = new Componentes.EditDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortJuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.AccessibleDescription = null;
            this.pDados.AccessibleName = null;
            resources.ApplyResources(this.pDados, "pDados");
            this.pDados.BackgroundImage = null;
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.bb_juro);
            this.pDados.Controls.Add(this.bb_portador);
            this.pDados.Controls.Add(this.ds_juro);
            this.pDados.Controls.Add(this.cd_juro);
            this.pDados.Controls.Add(this.ds_portador);
            this.pDados.Controls.Add(this.cd_portador);
            this.pDados.Font = null;
            this.pDados.NM_ProcDeletar = "EXCLUI_FIN_JURO_X_PORTADOR";
            this.pDados.NM_ProcGravar = "IA_FIN_JURO_X_PORTADOR";
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.gCadastro);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Font = null;
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCadastro, 0);
            // 
            // gCadastro
            // 
            this.gCadastro.AccessibleDescription = null;
            this.gCadastro.AccessibleName = null;
            this.gCadastro.AllowUserToAddRows = false;
            this.gCadastro.AllowUserToDeleteRows = false;
            this.gCadastro.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender;
            this.gCadastro.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.gCadastro, "gCadastro");
            this.gCadastro.AutoGenerateColumns = false;
            this.gCadastro.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCadastro.BackgroundImage = null;
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
            this.cdjuroDataGridViewTextBoxColumn,
            this.dsjuroDataGridViewTextBoxColumn,
            this.cdportadorDataGridViewTextBoxColumn,
            this.dsportadorDataGridViewTextBoxColumn});
            this.gCadastro.DataSource = this.bsPortJuro;
            this.gCadastro.Font = null;
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
            // cdjuroDataGridViewTextBoxColumn
            // 
            this.cdjuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdjuroDataGridViewTextBoxColumn.DataPropertyName = "Cd_juro";
            resources.ApplyResources(this.cdjuroDataGridViewTextBoxColumn, "cdjuroDataGridViewTextBoxColumn");
            this.cdjuroDataGridViewTextBoxColumn.Name = "cdjuroDataGridViewTextBoxColumn";
            this.cdjuroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsjuroDataGridViewTextBoxColumn
            // 
            this.dsjuroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsjuroDataGridViewTextBoxColumn.DataPropertyName = "Ds_juro";
            resources.ApplyResources(this.dsjuroDataGridViewTextBoxColumn, "dsjuroDataGridViewTextBoxColumn");
            this.dsjuroDataGridViewTextBoxColumn.Name = "dsjuroDataGridViewTextBoxColumn";
            this.dsjuroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cdportadorDataGridViewTextBoxColumn
            // 
            this.cdportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdportadorDataGridViewTextBoxColumn.DataPropertyName = "Cd_portador";
            resources.ApplyResources(this.cdportadorDataGridViewTextBoxColumn, "cdportadorDataGridViewTextBoxColumn");
            this.cdportadorDataGridViewTextBoxColumn.Name = "cdportadorDataGridViewTextBoxColumn";
            this.cdportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsportadorDataGridViewTextBoxColumn
            // 
            this.dsportadorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsportadorDataGridViewTextBoxColumn.DataPropertyName = "Ds_portador";
            resources.ApplyResources(this.dsportadorDataGridViewTextBoxColumn, "dsportadorDataGridViewTextBoxColumn");
            this.dsportadorDataGridViewTextBoxColumn.Name = "dsportadorDataGridViewTextBoxColumn";
            this.dsportadorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsPortJuro
            // 
            this.bsPortJuro.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_Portador_X_Juros);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // bb_juro
            // 
            this.bb_juro.AccessibleDescription = null;
            this.bb_juro.AccessibleName = null;
            resources.ApplyResources(this.bb_juro, "bb_juro");
            this.bb_juro.BackgroundImage = null;
            this.bb_juro.Font = null;
            this.bb_juro.Name = "bb_juro";
            this.bb_juro.UseVisualStyleBackColor = true;
            this.bb_juro.Click += new System.EventHandler(this.bb_juro_Click);
            // 
            // bb_portador
            // 
            this.bb_portador.AccessibleDescription = null;
            this.bb_portador.AccessibleName = null;
            resources.ApplyResources(this.bb_portador, "bb_portador");
            this.bb_portador.BackgroundImage = null;
            this.bb_portador.Font = null;
            this.bb_portador.Name = "bb_portador";
            this.bb_portador.UseVisualStyleBackColor = true;
            this.bb_portador.Click += new System.EventHandler(this.bb_portador_Click);
            // 
            // ds_juro
            // 
            this.ds_juro.AccessibleDescription = null;
            this.ds_juro.AccessibleName = null;
            resources.ApplyResources(this.ds_juro, "ds_juro");
            this.ds_juro.BackColor = System.Drawing.SystemColors.Window;
            this.ds_juro.BackgroundImage = null;
            this.ds_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPortJuro, "Ds_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_juro.Name = "ds_juro";
            this.ds_juro.NM_Alias = "";
            this.ds_juro.NM_Campo = "ds_juro";
            this.ds_juro.NM_CampoBusca = "ds_juro";
            this.ds_juro.NM_Param = "@P_DS_JURO";
            this.ds_juro.QTD_Zero = 0;
            this.ds_juro.ST_AutoInc = false;
            this.ds_juro.ST_DisableAuto = false;
            this.ds_juro.ST_Float = false;
            this.ds_juro.ST_Gravar = false;
            this.ds_juro.ST_Int = false;
            this.ds_juro.ST_LimpaCampo = true;
            this.ds_juro.ST_NotNull = false;
            this.ds_juro.ST_PrimaryKey = false;
            // 
            // cd_juro
            // 
            this.cd_juro.AccessibleDescription = null;
            this.cd_juro.AccessibleName = null;
            resources.ApplyResources(this.cd_juro, "cd_juro");
            this.cd_juro.BackColor = System.Drawing.SystemColors.Window;
            this.cd_juro.BackgroundImage = null;
            this.cd_juro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_juro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPortJuro, "Cd_juro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_juro.Name = "cd_juro";
            this.cd_juro.NM_Alias = "a";
            this.cd_juro.NM_Campo = "cd_Juro";
            this.cd_juro.NM_CampoBusca = "cd_Juro";
            this.cd_juro.NM_Param = "@P_CD_JURO";
            this.cd_juro.QTD_Zero = 0;
            this.cd_juro.ST_AutoInc = false;
            this.cd_juro.ST_DisableAuto = false;
            this.cd_juro.ST_Float = false;
            this.cd_juro.ST_Gravar = true;
            this.cd_juro.ST_Int = false;
            this.cd_juro.ST_LimpaCampo = true;
            this.cd_juro.ST_NotNull = true;
            this.cd_juro.ST_PrimaryKey = true;
            this.cd_juro.Leave += new System.EventHandler(this.cd_juro_Leave);
            // 
            // ds_portador
            // 
            this.ds_portador.AccessibleDescription = null;
            this.ds_portador.AccessibleName = null;
            resources.ApplyResources(this.ds_portador, "ds_portador");
            this.ds_portador.BackColor = System.Drawing.SystemColors.Window;
            this.ds_portador.BackgroundImage = null;
            this.ds_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPortJuro, "Ds_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_portador.Name = "ds_portador";
            this.ds_portador.NM_Alias = "";
            this.ds_portador.NM_Campo = "ds_portador";
            this.ds_portador.NM_CampoBusca = "ds_portador";
            this.ds_portador.NM_Param = "@P_DS_PORTADOR";
            this.ds_portador.QTD_Zero = 0;
            this.ds_portador.ST_AutoInc = false;
            this.ds_portador.ST_DisableAuto = false;
            this.ds_portador.ST_Float = false;
            this.ds_portador.ST_Gravar = false;
            this.ds_portador.ST_Int = false;
            this.ds_portador.ST_LimpaCampo = true;
            this.ds_portador.ST_NotNull = false;
            this.ds_portador.ST_PrimaryKey = false;
            // 
            // cd_portador
            // 
            this.cd_portador.AccessibleDescription = null;
            this.cd_portador.AccessibleName = null;
            resources.ApplyResources(this.cd_portador, "cd_portador");
            this.cd_portador.BackColor = System.Drawing.SystemColors.Window;
            this.cd_portador.BackgroundImage = null;
            this.cd_portador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_portador.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPortJuro, "Cd_portador", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_portador.Name = "cd_portador";
            this.cd_portador.NM_Alias = "a";
            this.cd_portador.NM_Campo = "cd_portador";
            this.cd_portador.NM_CampoBusca = "cd_portador";
            this.cd_portador.NM_Param = "@P_CD_PORTADOR";
            this.cd_portador.QTD_Zero = 0;
            this.cd_portador.ST_AutoInc = false;
            this.cd_portador.ST_DisableAuto = false;
            this.cd_portador.ST_Float = false;
            this.cd_portador.ST_Gravar = true;
            this.cd_portador.ST_Int = false;
            this.cd_portador.ST_LimpaCampo = true;
            this.cd_portador.ST_NotNull = true;
            this.cd_portador.ST_PrimaryKey = true;
            this.cd_portador.Leave += new System.EventHandler(this.cd_portador_Leave);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AccessibleDescription = null;
            this.bindingNavigator1.AccessibleName = null;
            this.bindingNavigator1.AddNewItem = null;
            resources.ApplyResources(this.bindingNavigator1, "bindingNavigator1");
            this.bindingNavigator1.BackgroundImage = null;
            this.bindingNavigator1.BindingSource = this.bsPortJuro;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Font = null;
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
            this.bindingNavigatorCountItem.AccessibleDescription = null;
            this.bindingNavigatorCountItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorCountItem, "bindingNavigatorCountItem");
            this.bindingNavigatorCountItem.BackgroundImage = null;
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.AccessibleDescription = null;
            this.bindingNavigatorMoveFirstItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveFirstItem, "bindingNavigatorMoveFirstItem");
            this.bindingNavigatorMoveFirstItem.BackgroundImage = null;
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.AccessibleDescription = null;
            this.bindingNavigatorMovePreviousItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMovePreviousItem, "bindingNavigatorMovePreviousItem");
            this.bindingNavigatorMovePreviousItem.BackgroundImage = null;
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.AccessibleDescription = null;
            this.bindingNavigatorSeparator.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator, "bindingNavigatorSeparator");
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleDescription = null;
            resources.ApplyResources(this.bindingNavigatorPositionItem, "bindingNavigatorPositionItem");
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.AccessibleDescription = null;
            this.bindingNavigatorSeparator1.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorSeparator1, "bindingNavigatorSeparator1");
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.AccessibleDescription = null;
            this.bindingNavigatorMoveNextItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveNextItem, "bindingNavigatorMoveNextItem");
            this.bindingNavigatorMoveNextItem.BackgroundImage = null;
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.AccessibleDescription = null;
            this.bindingNavigatorMoveLastItem.AccessibleName = null;
            resources.ApplyResources(this.bindingNavigatorMoveLastItem, "bindingNavigatorMoveLastItem");
            this.bindingNavigatorMoveLastItem.BackgroundImage = null;
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            // 
            // TFCadPortadorXJuro
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCadPortadorXJuro";
            this.Load += new System.EventHandler(this.TFCadPortadorXJuro_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadPortadorXJuro_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCadastro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPortJuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gCadastro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bb_juro;
        private System.Windows.Forms.Button bb_portador;
        private Componentes.EditDefault ds_juro;
        private Componentes.EditDefault cd_juro;
        private Componentes.EditDefault ds_portador;
        private Componentes.EditDefault cd_portador;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.BindingSource bsPortJuro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdjuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsjuroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdportadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsportadorDataGridViewTextBoxColumn;
    }
}
