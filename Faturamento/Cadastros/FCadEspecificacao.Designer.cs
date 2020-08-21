namespace Faturamento.Cadastros
{
    partial class TFCadEspecificacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadEspecificacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bnEspecificacao = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.bsEspecificacao = new System.Windows.Forms.BindingSource(this.components);
            this.idespecificacaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsespecificacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.id_especificacao = new Componentes.EditDefault(this.components);
            this.ds_especificacao = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnEspecificacao)).BeginInit();
            this.bnEspecificacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEspecificacao)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ds_especificacao);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.id_especificacao);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(659, 59);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Controls.Add(this.bnEspecificacao);
            this.tpPadrao.Controls.SetChildIndex(this.bnEspecificacao, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // bnEspecificacao
            // 
            this.bnEspecificacao.AddNewItem = null;
            this.bnEspecificacao.BindingSource = this.bsEspecificacao;
            this.bnEspecificacao.CountItem = this.bindingNavigatorCountItem;
            this.bnEspecificacao.CountItemFormat = "de {0}";
            this.bnEspecificacao.DeleteItem = null;
            this.bnEspecificacao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bnEspecificacao.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bnEspecificacao.Location = new System.Drawing.Point(0, 335);
            this.bnEspecificacao.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bnEspecificacao.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bnEspecificacao.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bnEspecificacao.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bnEspecificacao.Name = "bnEspecificacao";
            this.bnEspecificacao.PositionItem = this.bindingNavigatorPositionItem;
            this.bnEspecificacao.Size = new System.Drawing.Size(659, 25);
            this.bnEspecificacao.TabIndex = 1;
            this.bnEspecificacao.Text = "bindingNavigator1";
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Registro Corrente";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idespecificacaostrDataGridViewTextBoxColumn,
            this.dsespecificacaoDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsEspecificacao;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 59);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(659, 276);
            this.dataGridDefault1.TabIndex = 2;
            // 
            // bsEspecificacao
            // 
            this.bsEspecificacao.DataSource = typeof(CamadaDados.Faturamento.Cadastros.TList_Especificacao);
            // 
            // idespecificacaostrDataGridViewTextBoxColumn
            // 
            this.idespecificacaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idespecificacaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_especificacaostr";
            this.idespecificacaostrDataGridViewTextBoxColumn.HeaderText = "Id. Especificação";
            this.idespecificacaostrDataGridViewTextBoxColumn.Name = "idespecificacaostrDataGridViewTextBoxColumn";
            this.idespecificacaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idespecificacaostrDataGridViewTextBoxColumn.Width = 105;
            // 
            // dsespecificacaoDataGridViewTextBoxColumn
            // 
            this.dsespecificacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsespecificacaoDataGridViewTextBoxColumn.DataPropertyName = "Ds_especificacao";
            this.dsespecificacaoDataGridViewTextBoxColumn.HeaderText = "Especificação";
            this.dsespecificacaoDataGridViewTextBoxColumn.Name = "dsespecificacaoDataGridViewTextBoxColumn";
            this.dsespecificacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsespecificacaoDataGridViewTextBoxColumn.Width = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id. Especificação:";
            // 
            // id_especificacao
            // 
            this.id_especificacao.BackColor = System.Drawing.SystemColors.Window;
            this.id_especificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_especificacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEspecificacao, "Id_especificacaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_especificacao.Enabled = false;
            this.id_especificacao.Location = new System.Drawing.Point(102, 3);
            this.id_especificacao.Name = "id_especificacao";
            this.id_especificacao.NM_Alias = "";
            this.id_especificacao.NM_Campo = "";
            this.id_especificacao.NM_CampoBusca = "";
            this.id_especificacao.NM_Param = "";
            this.id_especificacao.QTD_Zero = 0;
            this.id_especificacao.Size = new System.Drawing.Size(70, 20);
            this.id_especificacao.ST_AutoInc = false;
            this.id_especificacao.ST_DisableAuto = true;
            this.id_especificacao.ST_Float = false;
            this.id_especificacao.ST_Gravar = true;
            this.id_especificacao.ST_Int = true;
            this.id_especificacao.ST_LimpaCampo = true;
            this.id_especificacao.ST_NotNull = true;
            this.id_especificacao.ST_PrimaryKey = true;
            this.id_especificacao.TabIndex = 1;
            // 
            // ds_especificacao
            // 
            this.ds_especificacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_especificacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_especificacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEspecificacao, "Ds_especificacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_especificacao.Enabled = false;
            this.ds_especificacao.Location = new System.Drawing.Point(102, 29);
            this.ds_especificacao.Name = "ds_especificacao";
            this.ds_especificacao.NM_Alias = "";
            this.ds_especificacao.NM_Campo = "";
            this.ds_especificacao.NM_CampoBusca = "";
            this.ds_especificacao.NM_Param = "";
            this.ds_especificacao.QTD_Zero = 0;
            this.ds_especificacao.Size = new System.Drawing.Size(549, 20);
            this.ds_especificacao.ST_AutoInc = false;
            this.ds_especificacao.ST_DisableAuto = false;
            this.ds_especificacao.ST_Float = false;
            this.ds_especificacao.ST_Gravar = true;
            this.ds_especificacao.ST_Int = true;
            this.ds_especificacao.ST_LimpaCampo = true;
            this.ds_especificacao.ST_NotNull = true;
            this.ds_especificacao.ST_PrimaryKey = false;
            this.ds_especificacao.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Especificação:";
            // 
            // TFCadEspecificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(671, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadEspecificacao";
            this.Text = "Cadastro Especificação Carta Correção";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bnEspecificacao)).EndInit();
            this.bnEspecificacao.ResumeLayout(false);
            this.bnEspecificacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEspecificacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bnEspecificacao;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idespecificacaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsespecificacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsEspecificacao;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault id_especificacao;
        private Componentes.EditDefault ds_especificacao;
        private System.Windows.Forms.Label label2;
    }
}
