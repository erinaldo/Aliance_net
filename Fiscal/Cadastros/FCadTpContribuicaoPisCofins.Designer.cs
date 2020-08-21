namespace Fiscal.Cadastros
{
    partial class TFCadTpContribuicaoPisCofins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadTpContribuicaoPisCofins));
            this.gTpContribuicao = new Componentes.DataGridDefault(this.components);
            this.bsTpContribuicao = new System.Windows.Forms.BindingSource(this.components);
            this.idtpcontribuicaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstpcontribuicaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.id_tpcontribuicao = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ds_tpcontribuicao = new Componentes.EditDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpContribuicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpContribuicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_tpcontribuicao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.id_tpcontribuicao);
            this.pDados.Size = new System.Drawing.Size(659, 58);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gTpContribuicao);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gTpContribuicao, 0);
            // 
            // gTpContribuicao
            // 
            this.gTpContribuicao.AllowUserToAddRows = false;
            this.gTpContribuicao.AllowUserToDeleteRows = false;
            this.gTpContribuicao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gTpContribuicao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gTpContribuicao.AutoGenerateColumns = false;
            this.gTpContribuicao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gTpContribuicao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gTpContribuicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpContribuicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gTpContribuicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gTpContribuicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtpcontribuicaostrDataGridViewTextBoxColumn,
            this.dstpcontribuicaoDataGridViewTextBoxColumn});
            this.gTpContribuicao.DataSource = this.bsTpContribuicao;
            this.gTpContribuicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gTpContribuicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gTpContribuicao.Location = new System.Drawing.Point(0, 58);
            this.gTpContribuicao.Name = "gTpContribuicao";
            this.gTpContribuicao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gTpContribuicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gTpContribuicao.RowHeadersWidth = 23;
            this.gTpContribuicao.Size = new System.Drawing.Size(659, 277);
            this.gTpContribuicao.TabIndex = 1;
            this.gTpContribuicao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gTpContribuicao_ColumnHeaderMouseClick);
            // 
            // bsTpContribuicao
            // 
            this.bsTpContribuicao.DataSource = typeof(CamadaDados.Fiscal.TList_TpContribuicaoPisCofins);
            // 
            // idtpcontribuicaostrDataGridViewTextBoxColumn
            // 
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_tpcontribuicaostr";
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.HeaderText = "Id. Contribuição";
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.Name = "idtpcontribuicaostrDataGridViewTextBoxColumn";
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idtpcontribuicaostrDataGridViewTextBoxColumn.Width = 97;
            // 
            // dstpcontribuicaoDataGridViewTextBoxColumn
            // 
            this.dstpcontribuicaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstpcontribuicaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_tpcontribuicao";
            this.dstpcontribuicaoDataGridViewTextBoxColumn.HeaderText = "Tipo Contribuição";
            this.dstpcontribuicaoDataGridViewTextBoxColumn.Name = "dstpcontribuicaoDataGridViewTextBoxColumn";
            this.dstpcontribuicaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstpcontribuicaoDataGridViewTextBoxColumn.Width = 106;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsTpContribuicao;
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
            // id_tpcontribuicao
            // 
            this.id_tpcontribuicao.BackColor = System.Drawing.SystemColors.Window;
            this.id_tpcontribuicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_tpcontribuicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpContribuicao, "Id_tpcontribuicaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_tpcontribuicao.Enabled = false;
            this.id_tpcontribuicao.Location = new System.Drawing.Point(68, 3);
            this.id_tpcontribuicao.Name = "id_tpcontribuicao";
            this.id_tpcontribuicao.NM_Alias = "";
            this.id_tpcontribuicao.NM_Campo = "";
            this.id_tpcontribuicao.NM_CampoBusca = "";
            this.id_tpcontribuicao.NM_Param = "";
            this.id_tpcontribuicao.QTD_Zero = 0;
            this.id_tpcontribuicao.Size = new System.Drawing.Size(100, 20);
            this.id_tpcontribuicao.ST_AutoInc = false;
            this.id_tpcontribuicao.ST_DisableAuto = true;
            this.id_tpcontribuicao.ST_Float = false;
            this.id_tpcontribuicao.ST_Gravar = true;
            this.id_tpcontribuicao.ST_Int = true;
            this.id_tpcontribuicao.ST_LimpaCampo = true;
            this.id_tpcontribuicao.ST_NotNull = true;
            this.id_tpcontribuicao.ST_PrimaryKey = true;
            this.id_tpcontribuicao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição:";
            // 
            // ds_tpcontribuicao
            // 
            this.ds_tpcontribuicao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpcontribuicao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpcontribuicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTpContribuicao, "Ds_tpcontribuicao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpcontribuicao.Location = new System.Drawing.Point(68, 29);
            this.ds_tpcontribuicao.Name = "ds_tpcontribuicao";
            this.ds_tpcontribuicao.NM_Alias = "";
            this.ds_tpcontribuicao.NM_Campo = "";
            this.ds_tpcontribuicao.NM_CampoBusca = "";
            this.ds_tpcontribuicao.NM_Param = "";
            this.ds_tpcontribuicao.QTD_Zero = 0;
            this.ds_tpcontribuicao.Size = new System.Drawing.Size(583, 20);
            this.ds_tpcontribuicao.ST_AutoInc = false;
            this.ds_tpcontribuicao.ST_DisableAuto = false;
            this.ds_tpcontribuicao.ST_Float = false;
            this.ds_tpcontribuicao.ST_Gravar = true;
            this.ds_tpcontribuicao.ST_Int = false;
            this.ds_tpcontribuicao.ST_LimpaCampo = true;
            this.ds_tpcontribuicao.ST_NotNull = true;
            this.ds_tpcontribuicao.ST_PrimaryKey = false;
            this.ds_tpcontribuicao.TabIndex = 1;
            // 
            // TFCadTpContribuicaoPisCofins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadTpContribuicaoPisCofins";
            this.Text = "Cadastro Tipo Contribuição PIS/COFINS";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gTpContribuicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTpContribuicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gTpContribuicao;
        private System.Windows.Forms.BindingSource bsTpContribuicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtpcontribuicaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstpcontribuicaoDataGridViewTextBoxColumn;
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
        private Componentes.EditDefault ds_tpcontribuicao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_tpcontribuicao;
    }
}
