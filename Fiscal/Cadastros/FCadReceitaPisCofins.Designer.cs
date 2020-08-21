namespace Fiscal.Cadastros
{
    partial class TFCadReceitaPisCofins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadReceitaPisCofins));
            this.gReceita = new Componentes.DataGridDefault(this.components);
            this.bsReceita = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_receita = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_receita = new Componentes.EditDefault(this.components);
            this.ds_imposto = new Componentes.EditDefault(this.components);
            this.bb_imposto = new System.Windows.Forms.Button();
            this.cd_imposto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.idreceitaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cd_impostostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsreceitaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gReceita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_imposto);
            this.pDados.Controls.Add(this.bb_imposto);
            this.pDados.Controls.Add(this.cd_imposto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_receita);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_receita);
            this.pDados.Size = new System.Drawing.Size(897, 89);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(909, 390);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gReceita);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(901, 364);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gReceita, 0);
            // 
            // gReceita
            // 
            this.gReceita.AllowUserToAddRows = false;
            this.gReceita.AllowUserToDeleteRows = false;
            this.gReceita.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gReceita.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gReceita.AutoGenerateColumns = false;
            this.gReceita.BackgroundColor = System.Drawing.Color.LightGray;
            this.gReceita.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gReceita.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gReceita.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gReceita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gReceita.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idreceitaDataGridViewTextBoxColumn,
            this.Cd_impostostr,
            this.dataGridViewTextBoxColumn1,
            this.dsreceitaDataGridViewTextBoxColumn});
            this.gReceita.DataSource = this.bsReceita;
            this.gReceita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gReceita.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gReceita.Location = new System.Drawing.Point(0, 89);
            this.gReceita.Name = "gReceita";
            this.gReceita.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gReceita.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gReceita.RowHeadersWidth = 23;
            this.gReceita.Size = new System.Drawing.Size(897, 246);
            this.gReceita.TabIndex = 1;
            this.gReceita.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gReceita_ColumnHeaderMouseClick);
            // 
            // bsReceita
            // 
            this.bsReceita.DataSource = typeof(CamadaDados.Fiscal.TList_ReceitaPisCofins);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsReceita;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.CountItemFormat = "de {0}";
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 335);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(897, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Registro Anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Proximo Registro";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Ultimo Registro";
            // 
            // id_receita
            // 
            this.id_receita.BackColor = System.Drawing.SystemColors.Window;
            this.id_receita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_receita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_receita.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Id_receitastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_receita.Enabled = false;
            this.id_receita.Location = new System.Drawing.Point(74, 4);
            this.id_receita.Name = "id_receita";
            this.id_receita.NM_Alias = "";
            this.id_receita.NM_Campo = "";
            this.id_receita.NM_CampoBusca = "";
            this.id_receita.NM_Param = "";
            this.id_receita.QTD_Zero = 0;
            this.id_receita.Size = new System.Drawing.Size(100, 20);
            this.id_receita.ST_AutoInc = false;
            this.id_receita.ST_DisableAuto = false;
            this.id_receita.ST_Float = false;
            this.id_receita.ST_Gravar = true;
            this.id_receita.ST_Int = true;
            this.id_receita.ST_LimpaCampo = true;
            this.id_receita.ST_NotNull = true;
            this.id_receita.ST_PrimaryKey = true;
            this.id_receita.TabIndex = 0;
            this.id_receita.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // ds_receita
            // 
            this.ds_receita.BackColor = System.Drawing.SystemColors.Window;
            this.ds_receita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_receita.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_receita.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Ds_receita", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_receita.Enabled = false;
            this.ds_receita.Location = new System.Drawing.Point(74, 56);
            this.ds_receita.Name = "ds_receita";
            this.ds_receita.NM_Alias = "";
            this.ds_receita.NM_Campo = "";
            this.ds_receita.NM_CampoBusca = "";
            this.ds_receita.NM_Param = "";
            this.ds_receita.QTD_Zero = 0;
            this.ds_receita.Size = new System.Drawing.Size(815, 20);
            this.ds_receita.ST_AutoInc = false;
            this.ds_receita.ST_DisableAuto = false;
            this.ds_receita.ST_Float = false;
            this.ds_receita.ST_Gravar = true;
            this.ds_receita.ST_Int = false;
            this.ds_receita.ST_LimpaCampo = true;
            this.ds_receita.ST_NotNull = true;
            this.ds_receita.ST_PrimaryKey = false;
            this.ds_receita.TabIndex = 3;
            this.ds_receita.TextOld = null;
            // 
            // ds_imposto
            // 
            this.ds_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imposto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Ds_imposto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imposto.Enabled = false;
            this.ds_imposto.Location = new System.Drawing.Point(172, 30);
            this.ds_imposto.MaxLength = 50;
            this.ds_imposto.Name = "ds_imposto";
            this.ds_imposto.NM_Alias = "";
            this.ds_imposto.NM_Campo = "ds_imposto";
            this.ds_imposto.NM_CampoBusca = "ds_imposto";
            this.ds_imposto.NM_Param = "@P_DS_SITTRIB";
            this.ds_imposto.QTD_Zero = 0;
            this.ds_imposto.Size = new System.Drawing.Size(717, 20);
            this.ds_imposto.ST_AutoInc = false;
            this.ds_imposto.ST_DisableAuto = false;
            this.ds_imposto.ST_Float = false;
            this.ds_imposto.ST_Gravar = false;
            this.ds_imposto.ST_Int = false;
            this.ds_imposto.ST_LimpaCampo = true;
            this.ds_imposto.ST_NotNull = false;
            this.ds_imposto.ST_PrimaryKey = false;
            this.ds_imposto.TabIndex = 6;
            this.ds_imposto.TextOld = null;
            // 
            // bb_imposto
            // 
            this.bb_imposto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_imposto.Enabled = false;
            this.bb_imposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_imposto.Image = ((System.Drawing.Image)(resources.GetObject("bb_imposto.Image")));
            this.bb_imposto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_imposto.Location = new System.Drawing.Point(136, 30);
            this.bb_imposto.Name = "bb_imposto";
            this.bb_imposto.Size = new System.Drawing.Size(30, 20);
            this.bb_imposto.TabIndex = 2;
            this.bb_imposto.UseVisualStyleBackColor = false;
            this.bb_imposto.Click += new System.EventHandler(this.bb_imposto_Click);
            // 
            // cd_imposto
            // 
            this.cd_imposto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_imposto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_imposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_imposto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsReceita, "Cd_impostostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_imposto.Enabled = false;
            this.cd_imposto.Location = new System.Drawing.Point(74, 30);
            this.cd_imposto.MaxLength = 2;
            this.cd_imposto.Name = "cd_imposto";
            this.cd_imposto.NM_Alias = "a";
            this.cd_imposto.NM_Campo = "cd_imposto";
            this.cd_imposto.NM_CampoBusca = "cd_imposto";
            this.cd_imposto.NM_Param = "@P_CD_SITTRIB";
            this.cd_imposto.QTD_Zero = 0;
            this.cd_imposto.Size = new System.Drawing.Size(61, 20);
            this.cd_imposto.ST_AutoInc = false;
            this.cd_imposto.ST_DisableAuto = false;
            this.cd_imposto.ST_Float = false;
            this.cd_imposto.ST_Gravar = true;
            this.cd_imposto.ST_Int = false;
            this.cd_imposto.ST_LimpaCampo = true;
            this.cd_imposto.ST_NotNull = true;
            this.cd_imposto.ST_PrimaryKey = true;
            this.cd_imposto.TabIndex = 1;
            this.cd_imposto.TextOld = null;
            this.cd_imposto.Leave += new System.EventHandler(this.cd_imposto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Imposto:";
            // 
            // idreceitaDataGridViewTextBoxColumn
            // 
            this.idreceitaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idreceitaDataGridViewTextBoxColumn.DataPropertyName = "Id_receita";
            this.idreceitaDataGridViewTextBoxColumn.HeaderText = "Codigo";
            this.idreceitaDataGridViewTextBoxColumn.Name = "idreceitaDataGridViewTextBoxColumn";
            this.idreceitaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idreceitaDataGridViewTextBoxColumn.Width = 65;
            // 
            // Cd_impostostr
            // 
            this.Cd_impostostr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Cd_impostostr.DataPropertyName = "Cd_impostostr";
            this.Cd_impostostr.HeaderText = "Cd. Imposto";
            this.Cd_impostostr.Name = "Cd_impostostr";
            this.Cd_impostostr.ReadOnly = true;
            this.Cd_impostostr.Width = 88;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_imposto";
            this.dataGridViewTextBoxColumn1.HeaderText = "Imposto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dsreceitaDataGridViewTextBoxColumn
            // 
            this.dsreceitaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsreceitaDataGridViewTextBoxColumn.DataPropertyName = "Ds_receita";
            this.dsreceitaDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.dsreceitaDataGridViewTextBoxColumn.Name = "dsreceitaDataGridViewTextBoxColumn";
            this.dsreceitaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsreceitaDataGridViewTextBoxColumn.Width = 80;
            // 
            // TFCadReceitaPisCofins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(909, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadReceitaPisCofins";
            this.Text = "Cadastro Receita Pis/Cofins";
            this.Load += new System.EventHandler(this.TFCadReceitaPisCofins_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadReceitaPisCofins_FormClosing);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gReceita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsReceita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gReceita;
        private System.Windows.Forms.BindingSource bsReceita;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_receita;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_receita;
        private Componentes.EditDefault ds_imposto;
        private System.Windows.Forms.Button bb_imposto;
        private Componentes.EditDefault cd_imposto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idreceitaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cd_impostostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsreceitaDataGridViewTextBoxColumn;
    }
}
