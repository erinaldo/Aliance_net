using Componentes;

namespace FormBusca
{
    partial class TFBusca
    {
        /// <summary>
        /// Required designer variable.0 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being usedm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pDadosPesquisa = new System.Windows.Forms.Panel();
            this.nLinhas = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCampos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pBotoes = new System.Windows.Forms.TableLayoutPanel();
            this.BB_Cancelar = new System.Windows.Forms.Button();
            this.BB_OK = new System.Windows.Forms.Button();
            this.pCentral = new System.Windows.Forms.Panel();
            this.gBusca = new Componentes.DataGridDefault(this.components);
            this.navegador = new System.Windows.Forms.BindingNavigator(this.components);
            this.bSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tempo = new System.Windows.Forms.Timer(this.components);
            this.pDadosPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLinhas)).BeginInit();
            this.pBotoes.SuspendLayout();
            this.pCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBusca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navegador)).BeginInit();
            this.navegador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(182)))), ((int)(((byte)(181)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(584, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOCALIZAR REGISTROS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // pDadosPesquisa
            // 
            this.pDadosPesquisa.BackColor = System.Drawing.SystemColors.Control;
            this.pDadosPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosPesquisa.Controls.Add(this.nLinhas);
            this.pDadosPesquisa.Controls.Add(this.label4);
            this.pDadosPesquisa.Controls.Add(this.cbCampos);
            this.pDadosPesquisa.Controls.Add(this.label3);
            this.pDadosPesquisa.Controls.Add(this.txtBusca);
            this.pDadosPesquisa.Controls.Add(this.label2);
            this.pDadosPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pDadosPesquisa.Location = new System.Drawing.Point(0, 31);
            this.pDadosPesquisa.Name = "pDadosPesquisa";
            this.pDadosPesquisa.Size = new System.Drawing.Size(584, 64);
            this.pDadosPesquisa.TabIndex = 0;
            // 
            // nLinhas
            // 
            this.nLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nLinhas.Location = new System.Drawing.Point(509, 28);
            this.nLinhas.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nLinhas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nLinhas.Name = "nLinhas";
            this.nLinhas.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nLinhas.Size = new System.Drawing.Size(61, 20);
            this.nLinhas.TabIndex = 2;
            this.nLinhas.TabStop = false;
            this.toolTip1.SetToolTip(this.nLinhas, "Total de Linhas do Grid");
            this.nLinhas.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nLinhas.ValueChanged += new System.EventHandler(this.nLinhas_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(506, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nº Linhas:";
            // 
            // cbCampos
            // 
            this.cbCampos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampos.Location = new System.Drawing.Point(13, 27);
            this.cbCampos.Name = "cbCampos";
            this.cbCampos.Size = new System.Drawing.Size(162, 21);
            this.cbCampos.TabIndex = 0;
            this.cbCampos.TabStop = false;
            this.toolTip1.SetToolTip(this.cbCampos, "Clique <PG DOWN> ou <PG UP> para escolher a chave de busca");
            this.cbCampos.SelectedIndexChanged += new System.EventHandler(this.cbCampos_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar por...:";
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBusca.Location = new System.Drawing.Point(184, 27);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(306, 20);
            this.txtBusca.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtBusca, "Informe o valor a ser pesquisado.\r\nPara facilitar sua busca utilize o coringa (%)" +
                    "\r\nem qualquer lugar do texto a ser pesquisado.");
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            this.txtBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusca_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(181, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pesquisa:";
            // 
            // pBotoes
            // 
            this.pBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(182)))), ((int)(((byte)(181)))));
            this.pBotoes.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.pBotoes.ColumnCount = 2;
            this.pBotoes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pBotoes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pBotoes.Controls.Add(this.BB_Cancelar, 1, 0);
            this.pBotoes.Controls.Add(this.BB_OK, 0, 0);
            this.pBotoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBotoes.Location = new System.Drawing.Point(0, 322);
            this.pBotoes.Name = "pBotoes";
            this.pBotoes.RowCount = 1;
            this.pBotoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pBotoes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.pBotoes.Size = new System.Drawing.Size(584, 40);
            this.pBotoes.TabIndex = 3;
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BB_Cancelar.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BB_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(134)))));
            this.BB_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Location = new System.Drawing.Point(368, 5);
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(139, 30);
            this.BB_Cancelar.TabIndex = 1;
            this.BB_Cancelar.Text = "CANCELAR (ESC)";
            this.toolTip1.SetToolTip(this.BB_Cancelar, "Cancelar Pesquisa");
            this.BB_Cancelar.UseVisualStyleBackColor = false;
            // 
            // BB_OK
            // 
            this.BB_OK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BB_OK.BackColor = System.Drawing.SystemColors.Control;
            this.BB_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BB_OK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(188)))), ((int)(((byte)(134)))));
            this.BB_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BB_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_OK.ForeColor = System.Drawing.Color.Green;
            this.BB_OK.Location = new System.Drawing.Point(77, 5);
            this.BB_OK.Name = "BB_OK";
            this.BB_OK.Size = new System.Drawing.Size(139, 30);
            this.BB_OK.TabIndex = 0;
            this.BB_OK.Text = "OK (ENTER)";
            this.toolTip1.SetToolTip(this.BB_OK, "Confirmar Pesquisa");
            this.BB_OK.UseVisualStyleBackColor = false;
            // 
            // pCentral
            // 
            this.pCentral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pCentral.Controls.Add(this.gBusca);
            this.pCentral.Controls.Add(this.navegador);
            this.pCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCentral.Location = new System.Drawing.Point(0, 95);
            this.pCentral.Name = "pCentral";
            this.pCentral.Size = new System.Drawing.Size(584, 227);
            this.pCentral.TabIndex = 1;
            // 
            // gBusca
            // 
            this.gBusca.AllowUserToAddRows = false;
            this.gBusca.AllowUserToDeleteRows = false;
            this.gBusca.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gBusca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gBusca.BackgroundColor = System.Drawing.Color.LightGray;
            this.gBusca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gBusca.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBusca.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gBusca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gBusca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBusca.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gBusca.Location = new System.Drawing.Point(0, 0);
            this.gBusca.Name = "gBusca";
            this.gBusca.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gBusca.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gBusca.RowHeadersWidth = 23;
            this.gBusca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gBusca.Size = new System.Drawing.Size(580, 198);
            this.gBusca.TabIndex = 1;
            this.gBusca.DoubleClick += new System.EventHandler(this.gBusca_DoubleClick);
            // 
            // navegador
            // 
            this.navegador.AddNewItem = null;
            this.navegador.BindingSource = this.bSource;
            this.navegador.CountItem = this.bindingNavigatorCountItem;
            this.navegador.CountItemFormat = "de {0}";
            this.navegador.DeleteItem = null;
            this.navegador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.navegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.navegador.Location = new System.Drawing.Point(0, 198);
            this.navegador.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.navegador.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.navegador.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.navegador.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.navegador.Name = "navegador";
            this.navegador.PositionItem = this.bindingNavigatorPositionItem;
            this.navegador.Size = new System.Drawing.Size(580, 25);
            this.navegador.TabIndex = 1;
            this.navegador.Text = "Navegador";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Numero Total de Itens";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Primeiro Registro";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Registro Anterior";
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
            this.bindingNavigatorPositionItem.ToolTipText = "Posição Corrente";
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
            this.bindingNavigatorMoveNextItem.Text = "Próximo Registro";
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
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tempo
            // 
            this.tempo.Interval = 300;
            this.tempo.Tick += new System.EventHandler(this.tempo_Tick);
            // 
            // TFBusca
            // 
            this.AcceptButton = this.BB_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BB_Cancelar;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.pCentral);
            this.Controls.Add(this.pBotoes);
            this.Controls.Add(this.pDadosPesquisa);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(400, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFBusca";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pesquisa Rápida...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FBusca_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFBusca_KeyDown);
            this.pDadosPesquisa.ResumeLayout(false);
            this.pDadosPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nLinhas)).EndInit();
            this.pBotoes.ResumeLayout(false);
            this.pCentral.ResumeLayout(false);
            this.pCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gBusca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navegador)).EndInit();
            this.navegador.ResumeLayout(false);
            this.navegador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pDadosPesquisa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel pBotoes;
        private System.Windows.Forms.Button BB_OK;
        private System.Windows.Forms.Panel pCentral;
        private System.Windows.Forms.Button BB_Cancelar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer tempo;
        public System.Windows.Forms.NumericUpDown nLinhas;
        private System.Windows.Forms.BindingNavigator navegador;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        public System.Windows.Forms.BindingSource bSource;
        public DataGridDefault gBusca;
        public System.Windows.Forms.ComboBox cbCampos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label2;

    }
}