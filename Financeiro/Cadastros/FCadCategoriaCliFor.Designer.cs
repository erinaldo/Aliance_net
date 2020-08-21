namespace Financeiro.Cadastros
{
    partial class TFCadCategoriaCliFor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCategoriaCliFor));
            this.label2 = new System.Windows.Forms.Label();
            this.Ds_CategoriaCliFor = new Componentes.EditDefault(this.components);
            this.BS_CategoriaCliFor = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Id_CategoriaCliFor = new Componentes.EditDefault(this.components);
            this.g_Pais = new Componentes.DataGridDefault(this.components);
            this.pFlag = new Componentes.PanelDados(this.components);
            this.st_funcionarios = new Componentes.CheckBoxDefault(this.components);
            this.st_fornecedor = new Componentes.CheckBoxDefault(this.components);
            this.st_transportadora = new Componentes.CheckBoxDefault(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.idCategoriaCliForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsCategoriaCliForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_transportadorabool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_fornecedorbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_funcionariosbool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.St_representantebool = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.st_representante = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CategoriaCliFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Pais)).BeginInit();
            this.pFlag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.pFlag);
            this.pDados.Controls.Add(this.Ds_CategoriaCliFor);
            this.pDados.Controls.Add(this.Id_CategoriaCliFor);
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
            this.tpPadrao.Controls.Add(this.g_Pais);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.g_Pais, 0);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Ds_CategoriaCliFor
            // 
            this.Ds_CategoriaCliFor.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_CategoriaCliFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_CategoriaCliFor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_CategoriaCliFor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CategoriaCliFor, "Ds_CategoriaCliFor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.Ds_CategoriaCliFor, "Ds_CategoriaCliFor");
            this.Ds_CategoriaCliFor.Name = "Ds_CategoriaCliFor";
            this.Ds_CategoriaCliFor.NM_Alias = "";
            this.Ds_CategoriaCliFor.NM_Campo = "Ds_CategoriaCliFor";
            this.Ds_CategoriaCliFor.NM_CampoBusca = "Ds_CategoriaCliFor";
            this.Ds_CategoriaCliFor.NM_Param = "@P_DS_CATEGORIACLIFOR";
            this.Ds_CategoriaCliFor.QTD_Zero = 0;
            this.Ds_CategoriaCliFor.ST_AutoInc = false;
            this.Ds_CategoriaCliFor.ST_DisableAuto = false;
            this.Ds_CategoriaCliFor.ST_Float = false;
            this.Ds_CategoriaCliFor.ST_Gravar = true;
            this.Ds_CategoriaCliFor.ST_Int = false;
            this.Ds_CategoriaCliFor.ST_LimpaCampo = true;
            this.Ds_CategoriaCliFor.ST_NotNull = false;
            this.Ds_CategoriaCliFor.ST_PrimaryKey = false;
            this.Ds_CategoriaCliFor.TextOld = null;
            // 
            // BS_CategoriaCliFor
            // 
            this.BS_CategoriaCliFor.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadCategoriaCliFor);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Id_CategoriaCliFor
            // 
            this.Id_CategoriaCliFor.BackColor = System.Drawing.SystemColors.Window;
            this.Id_CategoriaCliFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Id_CategoriaCliFor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_CategoriaCliFor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_CategoriaCliFor, "Id_CategoriaCliFor", true));
            resources.ApplyResources(this.Id_CategoriaCliFor, "Id_CategoriaCliFor");
            this.Id_CategoriaCliFor.Name = "Id_CategoriaCliFor";
            this.Id_CategoriaCliFor.NM_Alias = "a";
            this.Id_CategoriaCliFor.NM_Campo = "Id_CategoriaCliFor";
            this.Id_CategoriaCliFor.NM_CampoBusca = "Id_CategoriaCliFor";
            this.Id_CategoriaCliFor.NM_Param = "@P_ID_CATEGORIACLIFOR";
            this.Id_CategoriaCliFor.QTD_Zero = 0;
            this.Id_CategoriaCliFor.ST_AutoInc = false;
            this.Id_CategoriaCliFor.ST_DisableAuto = true;
            this.Id_CategoriaCliFor.ST_Float = false;
            this.Id_CategoriaCliFor.ST_Gravar = true;
            this.Id_CategoriaCliFor.ST_Int = true;
            this.Id_CategoriaCliFor.ST_LimpaCampo = true;
            this.Id_CategoriaCliFor.ST_NotNull = true;
            this.Id_CategoriaCliFor.ST_PrimaryKey = true;
            this.Id_CategoriaCliFor.TextOld = null;
            // 
            // g_Pais
            // 
            this.g_Pais.AllowUserToAddRows = false;
            this.g_Pais.AllowUserToDeleteRows = false;
            this.g_Pais.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.g_Pais.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.g_Pais.AutoGenerateColumns = false;
            this.g_Pais.BackgroundColor = System.Drawing.Color.LightGray;
            this.g_Pais.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.g_Pais.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Pais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.g_Pais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.g_Pais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCategoriaCliForDataGridViewTextBoxColumn,
            this.dsCategoriaCliForDataGridViewTextBoxColumn,
            this.St_transportadorabool,
            this.St_fornecedorbool,
            this.St_funcionariosbool,
            this.St_representantebool});
            this.g_Pais.DataSource = this.BS_CategoriaCliFor;
            resources.ApplyResources(this.g_Pais, "g_Pais");
            this.g_Pais.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.g_Pais.Name = "g_Pais";
            this.g_Pais.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.g_Pais.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            // 
            // pFlag
            // 
            this.pFlag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.pFlag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFlag.Controls.Add(this.st_representante);
            this.pFlag.Controls.Add(this.st_funcionarios);
            this.pFlag.Controls.Add(this.st_fornecedor);
            this.pFlag.Controls.Add(this.st_transportadora);
            resources.ApplyResources(this.pFlag, "pFlag");
            this.pFlag.Name = "pFlag";
            this.pFlag.NM_ProcDeletar = "";
            this.pFlag.NM_ProcGravar = "";
            // 
            // st_funcionarios
            // 
            resources.ApplyResources(this.st_funcionarios, "st_funcionarios");
            this.st_funcionarios.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CategoriaCliFor, "St_funcionariosbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_funcionarios.Name = "st_funcionarios";
            this.st_funcionarios.NM_Alias = "";
            this.st_funcionarios.NM_Campo = "";
            this.st_funcionarios.NM_Param = "";
            this.st_funcionarios.ST_Gravar = true;
            this.st_funcionarios.ST_LimparCampo = true;
            this.st_funcionarios.ST_NotNull = false;
            this.st_funcionarios.UseVisualStyleBackColor = true;
            this.st_funcionarios.Vl_False = "";
            this.st_funcionarios.Vl_True = "";
            // 
            // st_fornecedor
            // 
            resources.ApplyResources(this.st_fornecedor, "st_fornecedor");
            this.st_fornecedor.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CategoriaCliFor, "St_fornecedorbool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_fornecedor.Name = "st_fornecedor";
            this.st_fornecedor.NM_Alias = "";
            this.st_fornecedor.NM_Campo = "";
            this.st_fornecedor.NM_Param = "";
            this.st_fornecedor.ST_Gravar = true;
            this.st_fornecedor.ST_LimparCampo = true;
            this.st_fornecedor.ST_NotNull = false;
            this.st_fornecedor.UseVisualStyleBackColor = true;
            this.st_fornecedor.Vl_False = "";
            this.st_fornecedor.Vl_True = "";
            // 
            // st_transportadora
            // 
            resources.ApplyResources(this.st_transportadora, "st_transportadora");
            this.st_transportadora.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CategoriaCliFor, "St_transportadorabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_transportadora.Name = "st_transportadora";
            this.st_transportadora.NM_Alias = "";
            this.st_transportadora.NM_Campo = "";
            this.st_transportadora.NM_Param = "";
            this.st_transportadora.ST_Gravar = true;
            this.st_transportadora.ST_LimparCampo = true;
            this.st_transportadora.ST_NotNull = false;
            this.st_transportadora.UseVisualStyleBackColor = true;
            this.st_transportadora.Vl_False = "";
            this.st_transportadora.Vl_True = "";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.BS_CategoriaCliFor;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
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
            // idCategoriaCliForDataGridViewTextBoxColumn
            // 
            this.idCategoriaCliForDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idCategoriaCliForDataGridViewTextBoxColumn.DataPropertyName = "Id_CategoriaCliFor";
            resources.ApplyResources(this.idCategoriaCliForDataGridViewTextBoxColumn, "idCategoriaCliForDataGridViewTextBoxColumn");
            this.idCategoriaCliForDataGridViewTextBoxColumn.Name = "idCategoriaCliForDataGridViewTextBoxColumn";
            this.idCategoriaCliForDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dsCategoriaCliForDataGridViewTextBoxColumn
            // 
            this.dsCategoriaCliForDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsCategoriaCliForDataGridViewTextBoxColumn.DataPropertyName = "Ds_CategoriaCliFor";
            resources.ApplyResources(this.dsCategoriaCliForDataGridViewTextBoxColumn, "dsCategoriaCliForDataGridViewTextBoxColumn");
            this.dsCategoriaCliForDataGridViewTextBoxColumn.Name = "dsCategoriaCliForDataGridViewTextBoxColumn";
            this.dsCategoriaCliForDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // St_transportadorabool
            // 
            this.St_transportadorabool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_transportadorabool.DataPropertyName = "St_transportadorabool";
            resources.ApplyResources(this.St_transportadorabool, "St_transportadorabool");
            this.St_transportadorabool.Name = "St_transportadorabool";
            this.St_transportadorabool.ReadOnly = true;
            // 
            // St_fornecedorbool
            // 
            this.St_fornecedorbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_fornecedorbool.DataPropertyName = "St_fornecedorbool";
            resources.ApplyResources(this.St_fornecedorbool, "St_fornecedorbool");
            this.St_fornecedorbool.Name = "St_fornecedorbool";
            this.St_fornecedorbool.ReadOnly = true;
            // 
            // St_funcionariosbool
            // 
            this.St_funcionariosbool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_funcionariosbool.DataPropertyName = "St_funcionariosbool";
            resources.ApplyResources(this.St_funcionariosbool, "St_funcionariosbool");
            this.St_funcionariosbool.Name = "St_funcionariosbool";
            this.St_funcionariosbool.ReadOnly = true;
            // 
            // St_representantebool
            // 
            this.St_representantebool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.St_representantebool.DataPropertyName = "St_representantebool";
            resources.ApplyResources(this.St_representantebool, "St_representantebool");
            this.St_representantebool.Name = "St_representantebool";
            this.St_representantebool.ReadOnly = true;
            // 
            // st_representante
            // 
            resources.ApplyResources(this.st_representante, "st_representante");
            this.st_representante.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.BS_CategoriaCliFor, "St_representantebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_representante.Name = "st_representante";
            this.st_representante.NM_Alias = "";
            this.st_representante.NM_Campo = "";
            this.st_representante.NM_Param = "";
            this.st_representante.ST_Gravar = true;
            this.st_representante.ST_LimparCampo = true;
            this.st_representante.ST_NotNull = false;
            this.st_representante.UseVisualStyleBackColor = true;
            this.st_representante.Vl_False = "";
            this.st_representante.Vl_True = "";
            // 
            // TFCadCategoriaCliFor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TFCadCategoriaCliFor";
            this.Load += new System.EventHandler(this.TFCadCategoriaCliFor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCategoriaCliFor_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_CategoriaCliFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.g_Pais)).EndInit();
            this.pFlag.ResumeLayout(false);
            this.pFlag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Ds_CategoriaCliFor;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Id_CategoriaCliFor;
        private Componentes.DataGridDefault g_Pais;
        private System.Windows.Forms.BindingSource BS_CategoriaCliFor;
        private Componentes.PanelDados pFlag;
        private Componentes.CheckBoxDefault st_fornecedor;
        private Componentes.CheckBoxDefault st_transportadora;
        private Componentes.CheckBoxDefault st_funcionarios;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.CheckBoxDefault st_representante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoriaCliForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsCategoriaCliForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_transportadorabool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_fornecedorbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_funcionariosbool;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_representantebool;
    }
}