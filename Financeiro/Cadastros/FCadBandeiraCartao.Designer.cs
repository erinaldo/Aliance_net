namespace Financeiro.Cadastros
{
    partial class TFCadBandeiraCartao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadBandeiraCartao));
            this.gBandeiraCartao = new Componentes.DataGridDefault(this.components);
            this.bsBandeiraCartao = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ID_Bandeira = new Componentes.EditDefault(this.components);
            this.DS_Bandeira = new Componentes.EditDefault(this.components);
            this.bb_logo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tp_cartao = new Componentes.ComboBoxDefault(this.components);
            this.idbandeirastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSBandeiraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_cartao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagemDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBandeiraCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandeiraCartao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_cartao);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.pictureBox1);
            this.pDados.Controls.Add(this.bb_logo);
            this.pDados.Controls.Add(this.DS_Bandeira);
            this.pDados.Controls.Add(this.ID_Bandeira);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Size = new System.Drawing.Size(879, 90);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(891, 390);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gBandeiraCartao);
            this.tpPadrao.Controls.Add(this.bindingNavigator1);
            this.tpPadrao.Size = new System.Drawing.Size(883, 364);
            this.tpPadrao.Controls.SetChildIndex(this.bindingNavigator1, 0);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gBandeiraCartao, 0);
            // 
            // gBandeiraCartao
            // 
            this.gBandeiraCartao.AllowUserToAddRows = false;
            this.gBandeiraCartao.AllowUserToDeleteRows = false;
            this.gBandeiraCartao.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBandeiraCartao.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBandeiraCartao.AutoGenerateColumns = false;
            this.gBandeiraCartao.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBandeiraCartao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBandeiraCartao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBandeiraCartao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBandeiraCartao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBandeiraCartao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idbandeirastrDataGridViewTextBoxColumn,
            this.dSBandeiraDataGridViewTextBoxColumn,
            this.Tipo_cartao,
            this.imagemDataGridViewImageColumn});
            this.gBandeiraCartao.DataSource = this.bsBandeiraCartao;
            this.gBandeiraCartao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBandeiraCartao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBandeiraCartao.Location = new System.Drawing.Point(0, 90);
            this.gBandeiraCartao.Name = "gBandeiraCartao";
            this.gBandeiraCartao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBandeiraCartao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gBandeiraCartao.RowHeadersWidth = 23;
            this.gBandeiraCartao.Size = new System.Drawing.Size(879, 245);
            this.gBandeiraCartao.TabIndex = 1;
            this.gBandeiraCartao.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gBandeiraCartao_ColumnHeaderMouseClick);
            // 
            // bsBandeiraCartao
            // 
            this.bsBandeiraCartao.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_Cad_BandeiraCartao);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsBandeiraCartao;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(879, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total de Registros";
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
            this.bindingNavigatorMoveNextItem.Text = "Próximo";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Último";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Bandeira:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bandeira Cartão:";
            // 
            // ID_Bandeira
            // 
            this.ID_Bandeira.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Bandeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Bandeira.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Bandeira.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBandeiraCartao, "Id_bandeirastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Bandeira.Enabled = false;
            this.ID_Bandeira.Location = new System.Drawing.Point(125, 5);
            this.ID_Bandeira.Name = "ID_Bandeira";
            this.ID_Bandeira.NM_Alias = "";
            this.ID_Bandeira.NM_Campo = "";
            this.ID_Bandeira.NM_CampoBusca = "";
            this.ID_Bandeira.NM_Param = "";
            this.ID_Bandeira.QTD_Zero = 0;
            this.ID_Bandeira.Size = new System.Drawing.Size(49, 20);
            this.ID_Bandeira.ST_AutoInc = true;
            this.ID_Bandeira.ST_DisableAuto = true;
            this.ID_Bandeira.ST_Float = false;
            this.ID_Bandeira.ST_Gravar = true;
            this.ID_Bandeira.ST_Int = true;
            this.ID_Bandeira.ST_LimpaCampo = true;
            this.ID_Bandeira.ST_NotNull = true;
            this.ID_Bandeira.ST_PrimaryKey = true;
            this.ID_Bandeira.TabIndex = 0;
            this.ID_Bandeira.TextOld = null;
            // 
            // DS_Bandeira
            // 
            this.DS_Bandeira.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Bandeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Bandeira.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Bandeira.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsBandeiraCartao, "DS_Bandeira", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Bandeira.Enabled = false;
            this.DS_Bandeira.Location = new System.Drawing.Point(125, 36);
            this.DS_Bandeira.Name = "DS_Bandeira";
            this.DS_Bandeira.NM_Alias = "";
            this.DS_Bandeira.NM_Campo = "";
            this.DS_Bandeira.NM_CampoBusca = "";
            this.DS_Bandeira.NM_Param = "";
            this.DS_Bandeira.QTD_Zero = 0;
            this.DS_Bandeira.Size = new System.Drawing.Size(355, 20);
            this.DS_Bandeira.ST_AutoInc = false;
            this.DS_Bandeira.ST_DisableAuto = false;
            this.DS_Bandeira.ST_Float = false;
            this.DS_Bandeira.ST_Gravar = true;
            this.DS_Bandeira.ST_Int = false;
            this.DS_Bandeira.ST_LimpaCampo = true;
            this.DS_Bandeira.ST_NotNull = true;
            this.DS_Bandeira.ST_PrimaryKey = false;
            this.DS_Bandeira.TabIndex = 1;
            this.DS_Bandeira.TextOld = null;
            // 
            // bb_logo
            // 
            this.bb_logo.Enabled = false;
            this.bb_logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_logo.Location = new System.Drawing.Point(612, 3);
            this.bb_logo.Name = "bb_logo";
            this.bb_logo.Size = new System.Drawing.Size(83, 77);
            this.bb_logo.TabIndex = 5;
            this.bb_logo.Text = "Buscar Logo";
            this.bb_logo.UseVisualStyleBackColor = true;
            this.bb_logo.Click += new System.EventHandler(this.bb_logo_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsBandeiraCartao, "Imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureBox1.Location = new System.Drawing.Point(486, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo Cartão:";
            // 
            // tp_cartao
            // 
            this.tp_cartao.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsBandeiraCartao, "Tp_cartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_cartao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_cartao.Enabled = false;
            this.tp_cartao.FormattingEnabled = true;
            this.tp_cartao.Location = new System.Drawing.Point(125, 62);
            this.tp_cartao.Name = "tp_cartao";
            this.tp_cartao.NM_Alias = "";
            this.tp_cartao.NM_Campo = "";
            this.tp_cartao.NM_Param = "";
            this.tp_cartao.Size = new System.Drawing.Size(210, 21);
            this.tp_cartao.ST_Gravar = true;
            this.tp_cartao.ST_LimparCampo = true;
            this.tp_cartao.ST_NotNull = true;
            this.tp_cartao.TabIndex = 4;
            // 
            // idbandeirastrDataGridViewTextBoxColumn
            // 
            this.idbandeirastrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idbandeirastrDataGridViewTextBoxColumn.DataPropertyName = "Id_bandeirastr";
            this.idbandeirastrDataGridViewTextBoxColumn.HeaderText = "Código Bandeira";
            this.idbandeirastrDataGridViewTextBoxColumn.Name = "idbandeirastrDataGridViewTextBoxColumn";
            this.idbandeirastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idbandeirastrDataGridViewTextBoxColumn.Width = 101;
            // 
            // dSBandeiraDataGridViewTextBoxColumn
            // 
            this.dSBandeiraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSBandeiraDataGridViewTextBoxColumn.DataPropertyName = "DS_Bandeira";
            this.dSBandeiraDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.dSBandeiraDataGridViewTextBoxColumn.Name = "dSBandeiraDataGridViewTextBoxColumn";
            this.dSBandeiraDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSBandeiraDataGridViewTextBoxColumn.Width = 80;
            // 
            // Tipo_cartao
            // 
            this.Tipo_cartao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tipo_cartao.DataPropertyName = "Tipo_cartao";
            this.Tipo_cartao.HeaderText = "Tipo Cartão";
            this.Tipo_cartao.Name = "Tipo_cartao";
            this.Tipo_cartao.ReadOnly = true;
            this.Tipo_cartao.Width = 80;
            // 
            // imagemDataGridViewImageColumn
            // 
            this.imagemDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.imagemDataGridViewImageColumn.DataPropertyName = "Imagem";
            this.imagemDataGridViewImageColumn.HeaderText = "Imagem";
            this.imagemDataGridViewImageColumn.Name = "imagemDataGridViewImageColumn";
            this.imagemDataGridViewImageColumn.ReadOnly = true;
            this.imagemDataGridViewImageColumn.Width = 50;
            // 
            // TFCadBandeiraCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(891, 433);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadBandeiraCartao";
            this.Text = "Cadastro de Bandeira Cartão";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadBandeiraCartao_FormClosing);
            this.Load += new System.EventHandler(this.TFCadBandeiraCartao_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tpPadrao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBandeiraCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBandeiraCartao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault gBandeiraCartao;
        private System.Windows.Forms.BindingSource bsBandeiraCartao;
        private Componentes.EditDefault ID_Bandeira;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.Button bb_logo;
        private Componentes.EditDefault DS_Bandeira;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Componentes.ComboBoxDefault tp_cartao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idbandeirastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSBandeiraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_cartao;
        private System.Windows.Forms.DataGridViewImageColumn imagemDataGridViewImageColumn;
    }
}
