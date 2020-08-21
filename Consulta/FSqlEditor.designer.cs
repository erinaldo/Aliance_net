namespace Consulta
{
    partial class TFSqlEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFSqlEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BS_Resultado = new System.Windows.Forms.BindingSource(this.components);
            this.pDadosSQL = new Componentes.PanelDados(this.components);
            this.splitSQL = new System.Windows.Forms.SplitContainer();
            this.groupBoxSQL = new System.Windows.Forms.GroupBox();
            this.DS_SQL = new System.Windows.Forms.RichTextBox();
            this.panelResultado = new Componentes.PanelDados(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.grid_Resultado = new Componentes.DataGridDefault(this.components);
            this.BN_Resultado = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSQL = new System.Windows.Forms.ToolStrip();
            this.tsBB_Executar = new System.Windows.Forms.ToolStripButton();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.pDadosParam = new Componentes.PanelDados(this.components);
            this.gb_Param = new System.Windows.Forms.GroupBox();
            this.bb_Cancelar = new System.Windows.Forms.Button();
            this.bb_Adicionar = new System.Windows.Forms.Button();
            this.NM_Classe = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.NM_CampoFormat = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.labelParam = new System.Windows.Forms.Label();
            this.NM_Param = new Componentes.EditDefault(this.components);
            this.BB_ParamClasse = new System.Windows.Forms.Button();
            this.ID_ParamClasse = new Componentes.EditDefault(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BS_Resultado)).BeginInit();
            this.pDadosSQL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSQL)).BeginInit();
            this.splitSQL.Panel1.SuspendLayout();
            this.splitSQL.Panel2.SuspendLayout();
            this.splitSQL.SuspendLayout();
            this.groupBoxSQL.SuspendLayout();
            this.panelResultado.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Resultado)).BeginInit();
            this.BN_Resultado.SuspendLayout();
            this.toolStripSQL.SuspendLayout();
            this.pDadosParam.SuspendLayout();
            this.gb_Param.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDadosSQL
            // 
            this.pDadosSQL.Controls.Add(this.splitSQL);
            this.pDadosSQL.Controls.Add(this.toolStripSQL);
            resources.ApplyResources(this.pDadosSQL, "pDadosSQL");
            this.pDadosSQL.Name = "pDadosSQL";
            this.pDadosSQL.NM_ProcDeletar = "";
            this.pDadosSQL.NM_ProcGravar = "";
            // 
            // splitSQL
            // 
            resources.ApplyResources(this.splitSQL, "splitSQL");
            this.splitSQL.Name = "splitSQL";
            // 
            // splitSQL.Panel1
            // 
            this.splitSQL.Panel1.Controls.Add(this.groupBoxSQL);
            // 
            // splitSQL.Panel2
            // 
            this.splitSQL.Panel2.Controls.Add(this.panelResultado);
            // 
            // groupBoxSQL
            // 
            this.groupBoxSQL.Controls.Add(this.DS_SQL);
            resources.ApplyResources(this.groupBoxSQL, "groupBoxSQL");
            this.groupBoxSQL.Name = "groupBoxSQL";
            this.groupBoxSQL.TabStop = false;
            // 
            // DS_SQL
            // 
            resources.ApplyResources(this.DS_SQL, "DS_SQL");
            this.DS_SQL.HideSelection = false;
            this.DS_SQL.Name = "DS_SQL";
            this.DS_SQL.TextChanged += new System.EventHandler(this.DS_SQL_TextChanged);
            this.DS_SQL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DS_SQL_KeyDown);
            this.DS_SQL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DS_SQL_KeyPress);
            // 
            // panelResultado
            // 
            this.panelResultado.Controls.Add(this.tabControl);
            resources.ApplyResources(this.panelResultado, "panelResultado");
            this.panelResultado.Name = "panelResultado";
            this.panelResultado.NM_ProcDeletar = "";
            this.panelResultado.NM_ProcGravar = "";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageResult);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageResult
            // 
            this.tabPageResult.Controls.Add(this.grid_Resultado);
            this.tabPageResult.Controls.Add(this.BN_Resultado);
            resources.ApplyResources(this.tabPageResult, "tabPageResult");
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.UseVisualStyleBackColor = true;
            // 
            // grid_Resultado
            // 
            this.grid_Resultado.AllowUserToAddRows = false;
            this.grid_Resultado.AllowUserToDeleteRows = false;
            this.grid_Resultado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.grid_Resultado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Resultado.AutoGenerateColumns = false;
            this.grid_Resultado.BackgroundColor = System.Drawing.Color.LightGray;
            this.grid_Resultado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_Resultado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Resultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Resultado.DataSource = this.BS_Resultado;
            resources.ApplyResources(this.grid_Resultado, "grid_Resultado");
            this.grid_Resultado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.grid_Resultado.Name = "grid_Resultado";
            this.grid_Resultado.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Resultado.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // BN_Resultado
            // 
            this.BN_Resultado.AddNewItem = null;
            this.BN_Resultado.BindingSource = this.BS_Resultado;
            this.BN_Resultado.CountItem = this.bindingNavigatorCountItem;
            this.BN_Resultado.DeleteItem = null;
            resources.ApplyResources(this.BN_Resultado, "BN_Resultado");
            this.BN_Resultado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.BN_Resultado.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BN_Resultado.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BN_Resultado.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BN_Resultado.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BN_Resultado.Name = "BN_Resultado";
            this.BN_Resultado.PositionItem = this.bindingNavigatorPositionItem;
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
            // toolStripSQL
            // 
            this.toolStripSQL.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBB_Executar,
            this.BB_Fechar});
            resources.ApplyResources(this.toolStripSQL, "toolStripSQL");
            this.toolStripSQL.Name = "toolStripSQL";
            // 
            // tsBB_Executar
            // 
            resources.ApplyResources(this.tsBB_Executar, "tsBB_Executar");
            this.tsBB_Executar.Name = "tsBB_Executar";
            this.tsBB_Executar.Click += new System.EventHandler(this.tsBB_Executar_Click);
            // 
            // BB_Fechar
            // 
            resources.ApplyResources(this.BB_Fechar, "BB_Fechar");
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // pDadosParam
            // 
            this.pDadosParam.Controls.Add(this.gb_Param);
            resources.ApplyResources(this.pDadosParam, "pDadosParam");
            this.pDadosParam.Name = "pDadosParam";
            this.pDadosParam.NM_ProcDeletar = "";
            this.pDadosParam.NM_ProcGravar = "";
            // 
            // gb_Param
            // 
            this.gb_Param.Controls.Add(this.bb_Cancelar);
            this.gb_Param.Controls.Add(this.bb_Adicionar);
            this.gb_Param.Controls.Add(this.NM_Classe);
            this.gb_Param.Controls.Add(this.label2);
            this.gb_Param.Controls.Add(this.NM_CampoFormat);
            this.gb_Param.Controls.Add(this.label7);
            this.gb_Param.Controls.Add(this.labelParam);
            this.gb_Param.Controls.Add(this.NM_Param);
            this.gb_Param.Controls.Add(this.BB_ParamClasse);
            this.gb_Param.Controls.Add(this.ID_ParamClasse);
            resources.ApplyResources(this.gb_Param, "gb_Param");
            this.gb_Param.Name = "gb_Param";
            this.gb_Param.TabStop = false;
            // 
            // bb_Cancelar
            // 
            resources.ApplyResources(this.bb_Cancelar, "bb_Cancelar");
            this.bb_Cancelar.Name = "bb_Cancelar";
            this.bb_Cancelar.UseVisualStyleBackColor = true;
            this.bb_Cancelar.Click += new System.EventHandler(this.bb_Cancelar_Click);
            // 
            // bb_Adicionar
            // 
            resources.ApplyResources(this.bb_Adicionar, "bb_Adicionar");
            this.bb_Adicionar.Name = "bb_Adicionar";
            this.bb_Adicionar.UseVisualStyleBackColor = true;
            this.bb_Adicionar.Click += new System.EventHandler(this.bb_Adicionar_Click);
            // 
            // NM_Classe
            // 
            this.NM_Classe.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Classe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Classe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.NM_Classe, "NM_Classe");
            this.NM_Classe.Name = "NM_Classe";
            this.NM_Classe.NM_Alias = "a";
            this.NM_Classe.NM_Campo = "NM_Classe";
            this.NM_Classe.NM_CampoBusca = "NM_Classe";
            this.NM_Classe.NM_Param = "@P_NM_CLASSE";
            this.NM_Classe.QTD_Zero = 0;
            this.NM_Classe.ST_AutoInc = false;
            this.NM_Classe.ST_DisableAuto = false;
            this.NM_Classe.ST_Float = false;
            this.NM_Classe.ST_Gravar = false;
            this.NM_Classe.ST_Int = false;
            this.NM_Classe.ST_LimpaCampo = true;
            this.NM_Classe.ST_NotNull = false;
            this.NM_Classe.ST_PrimaryKey = false;
            this.NM_Classe.TextOld = null;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NM_CampoFormat
            // 
            this.NM_CampoFormat.BackColor = System.Drawing.SystemColors.Window;
            this.NM_CampoFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_CampoFormat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.NM_CampoFormat, "NM_CampoFormat");
            this.NM_CampoFormat.Name = "NM_CampoFormat";
            this.NM_CampoFormat.NM_Alias = "a";
            this.NM_CampoFormat.NM_Campo = "NM_CampoFormat";
            this.NM_CampoFormat.NM_CampoBusca = "NM_CampoFormat";
            this.NM_CampoFormat.NM_Param = "@P_NM_CAMPOFORMAT";
            this.NM_CampoFormat.QTD_Zero = 0;
            this.NM_CampoFormat.ST_AutoInc = false;
            this.NM_CampoFormat.ST_DisableAuto = false;
            this.NM_CampoFormat.ST_Float = false;
            this.NM_CampoFormat.ST_Gravar = false;
            this.NM_CampoFormat.ST_Int = false;
            this.NM_CampoFormat.ST_LimpaCampo = true;
            this.NM_CampoFormat.ST_NotNull = false;
            this.NM_CampoFormat.ST_PrimaryKey = false;
            this.NM_CampoFormat.TextOld = null;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // labelParam
            // 
            resources.ApplyResources(this.labelParam, "labelParam");
            this.labelParam.Name = "labelParam";
            // 
            // NM_Param
            // 
            this.NM_Param.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Param.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Param.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.NM_Param, "NM_Param");
            this.NM_Param.Name = "NM_Param";
            this.NM_Param.NM_Alias = "a";
            this.NM_Param.NM_Campo = "NM_Param";
            this.NM_Param.NM_CampoBusca = "NM_Param";
            this.NM_Param.NM_Param = "";
            this.NM_Param.QTD_Zero = 0;
            this.NM_Param.ST_AutoInc = false;
            this.NM_Param.ST_DisableAuto = true;
            this.NM_Param.ST_Float = false;
            this.NM_Param.ST_Gravar = false;
            this.NM_Param.ST_Int = false;
            this.NM_Param.ST_LimpaCampo = true;
            this.NM_Param.ST_NotNull = false;
            this.NM_Param.ST_PrimaryKey = false;
            this.NM_Param.TextOld = null;
            // 
            // BB_ParamClasse
            // 
            resources.ApplyResources(this.BB_ParamClasse, "BB_ParamClasse");
            this.BB_ParamClasse.Name = "BB_ParamClasse";
            this.BB_ParamClasse.UseVisualStyleBackColor = true;
            this.BB_ParamClasse.Click += new System.EventHandler(this.BB_ParamClasse_Click);
            // 
            // ID_ParamClasse
            // 
            this.ID_ParamClasse.BackColor = System.Drawing.Color.White;
            this.ID_ParamClasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_ParamClasse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.ID_ParamClasse, "ID_ParamClasse");
            this.ID_ParamClasse.Name = "ID_ParamClasse";
            this.ID_ParamClasse.NM_Alias = "a";
            this.ID_ParamClasse.NM_Campo = "ID_ParamClasse";
            this.ID_ParamClasse.NM_CampoBusca = "ID_ParamClasse";
            this.ID_ParamClasse.NM_Param = "";
            this.ID_ParamClasse.QTD_Zero = 0;
            this.ID_ParamClasse.ST_AutoInc = false;
            this.ID_ParamClasse.ST_DisableAuto = false;
            this.ID_ParamClasse.ST_Float = false;
            this.ID_ParamClasse.ST_Gravar = true;
            this.ID_ParamClasse.ST_Int = true;
            this.ID_ParamClasse.ST_LimpaCampo = true;
            this.ID_ParamClasse.ST_NotNull = false;
            this.ID_ParamClasse.ST_PrimaryKey = false;
            this.ID_ParamClasse.TextOld = null;
            this.ID_ParamClasse.Leave += new System.EventHandler(this.ID_ParamClasse_Leave);
            // 
            // TFSqlEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pDadosSQL);
            this.Controls.Add(this.pDadosParam);
            this.KeyPreview = true;
            this.Name = "TFSqlEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFSqlEditor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFSqlEditor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BS_Resultado)).EndInit();
            this.pDadosSQL.ResumeLayout(false);
            this.pDadosSQL.PerformLayout();
            this.splitSQL.Panel1.ResumeLayout(false);
            this.splitSQL.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSQL)).EndInit();
            this.splitSQL.ResumeLayout(false);
            this.groupBoxSQL.ResumeLayout(false);
            this.panelResultado.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageResult.ResumeLayout(false);
            this.tabPageResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BN_Resultado)).EndInit();
            this.BN_Resultado.ResumeLayout(false);
            this.BN_Resultado.PerformLayout();
            this.toolStripSQL.ResumeLayout(false);
            this.toolStripSQL.PerformLayout();
            this.pDadosParam.ResumeLayout(false);
            this.gb_Param.ResumeLayout(false);
            this.gb_Param.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDadosSQL;
        private Componentes.PanelDados pDadosParam;
        private System.Windows.Forms.ToolStrip toolStripSQL;
        private System.Windows.Forms.GroupBox gb_Param;
        private Componentes.EditDefault NM_CampoFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelParam;
        private Componentes.EditDefault NM_Param;
        private System.Windows.Forms.Button BB_ParamClasse;
        private Componentes.EditDefault ID_ParamClasse;
        private System.Windows.Forms.Button bb_Cancelar;
        private System.Windows.Forms.Button bb_Adicionar;
        private Componentes.EditDefault NM_Classe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxSQL;
        private System.Windows.Forms.ToolStripButton tsBB_Executar;
        private System.Windows.Forms.SplitContainer splitSQL;
        private Componentes.PanelDados panelResultado;
        private Componentes.DataGridDefault grid_Resultado;
        private System.Windows.Forms.BindingSource BS_Resultado;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.BindingNavigator BN_Resultado;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public System.Windows.Forms.RichTextBox DS_SQL;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
    }
}