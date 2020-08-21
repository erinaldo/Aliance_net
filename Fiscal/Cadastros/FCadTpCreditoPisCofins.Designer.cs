namespace Fiscal.Cadastros
{
    partial class TFCadTpCreditoPisCofins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpCreditoPisCofins));
            this.gTpCredito = new Componentes.DataGridDefault(this.components);
            this.bsTpCredito = new System.Windows.Forms.BindingSource(this.components);
            this.idtpcredstrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpcredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id_tpcred = new Componentes.EditDefault(this.components);
            this.ds_tpcred = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_tpcred);
            this.pDados.Controls.Add(this.id_tpcred);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(659, 60);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gTpCredito);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTpCredito, 0);
            // 
            // gTpCredito
            // 
            this.gTpCredito.AllowUserToAddRows = false;
            this.gTpCredito.AllowUserToDeleteRows = false;
            this.gTpCredito.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTpCredito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTpCredito.AutoGenerateColumns = false;
            this.gTpCredito.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTpCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTpCredito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpCredito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTpCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTpCredito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtpcredstrDataGridViewTextBoxColumn,
            this.dstpcredDataGridViewTextBoxColumn});
            this.gTpCredito.DataSource = this.bsTpCredito;
            this.gTpCredito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTpCredito.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTpCredito.Location = new System.Drawing.Point(0, 60);
            this.gTpCredito.Name = "gTpCredito";
            this.gTpCredito.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpCredito.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gTpCredito.RowHeadersWidth = 23;
            this.gTpCredito.Size = new System.Drawing.Size(659, 275);
            this.gTpCredito.TabIndex = 1;
            this.gTpCredito.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTpCredito_ColumnHeaderMouseClick);
            // 
            // bsTpCredito
            // 
            this.bsTpCredito.DataSource = typeof(CamadaDados.Fiscal.TList_TpCreditoPisCofins);
            // 
            // idtpcredstrDataGridViewTextBoxColumn
            // 
            this.idtpcredstrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpcredstrDataGridViewTextBoxColumn.DataPropertyName = "Id_tpcredstr";
            this.idtpcredstrDataGridViewTextBoxColumn.HeaderText = "TP. Credito";
            this.idtpcredstrDataGridViewTextBoxColumn.Name = "idtpcredstrDataGridViewTextBoxColumn";
            this.idtpcredstrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtpcredstrDataGridViewTextBoxColumn.Width = 85;
            // 
            // dstpcredDataGridViewTextBoxColumn
            // 
            this.dstpcredDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpcredDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpcred";
            this.dstpcredDataGridViewTextBoxColumn.HeaderText = "Tipo Credito";
            this.dstpcredDataGridViewTextBoxColumn.Name = "dstpcredDataGridViewTextBoxColumn";
            this.dstpcredDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpcredDataGridViewTextBoxColumn.Width = 89;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTpCredito;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(659, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total Registros";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrição:";
            // 
            // id_tpcred
            // 
            this.id_tpcred.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpcred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpcred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpCredito, "Id_tpcredstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tpcred.Enabled = false;
            this.id_tpcred.Location = new System.Drawing.Point(69, 5);
            this.id_tpcred.Name = "id_tpcred";
            this.id_tpcred.NM_Alias = "";
            this.id_tpcred.NM_Campo = "";
            this.id_tpcred.NM_CampoBusca = "";
            this.id_tpcred.NM_Param = "";
            this.id_tpcred.QTD_Zero = 0;
            this.id_tpcred.Size = new System.Drawing.Size(100, 20);
            this.id_tpcred.ST_AutoInc = false;
            this.id_tpcred.ST_DisableAuto = true;
            this.id_tpcred.ST_Float = false;
            this.id_tpcred.ST_Gravar = true;
            this.id_tpcred.ST_Int = true;
            this.id_tpcred.ST_LimpaCampo = true;
            this.id_tpcred.ST_NotNull = true;
            this.id_tpcred.ST_PrimaryKey = true;
            this.id_tpcred.TabIndex = 0;
            // 
            // ds_tpcred
            // 
            this.ds_tpcred.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpcred.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpcred.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpCredito, "Ds_tpcred", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpcred.Enabled = false;
            this.ds_tpcred.Location = new System.Drawing.Point(69, 31);
            this.ds_tpcred.Name = "ds_tpcred";
            this.ds_tpcred.NM_Alias = "";
            this.ds_tpcred.NM_Campo = "";
            this.ds_tpcred.NM_CampoBusca = "";
            this.ds_tpcred.NM_Param = "";
            this.ds_tpcred.QTD_Zero = 0;
            this.ds_tpcred.Size = new System.Drawing.Size(582, 20);
            this.ds_tpcred.ST_AutoInc = false;
            this.ds_tpcred.ST_DisableAuto = false;
            this.ds_tpcred.ST_Float = false;
            this.ds_tpcred.ST_Gravar = true;
            this.ds_tpcred.ST_Int = false;
            this.ds_tpcred.ST_LimpaCampo = true;
            this.ds_tpcred.ST_NotNull = true;
            this.ds_tpcred.ST_PrimaryKey = false;
            this.ds_tpcred.TabIndex = 1;
            // 
            // TFCadTpCreditoPisCofins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTpCreditoPisCofins";
            this.Text = "Cadastro Tipo Credito PIS/COFINS";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gTpCredito;
        private System.Windows.Forms.BindingSource bsTpCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpcredstrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpcredDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.EditDefault ds_tpcred;
        private Componentes.EditDefault id_tpcred;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
