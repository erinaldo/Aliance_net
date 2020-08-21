namespace Restaurante.Cadastro
{
    partial class FClifor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FClifor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.bbBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.fone = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cd_cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ds_cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enderecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cepDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsClifor = new System.Windows.Forms.BindingSource(this.components);
            this.Dt_nascimentostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vl_renda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Novo,
            this.BB_Alterar,
            this.BB_Excluir,
            this.bbBuscar,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(658, 43);
            this.barraMenu.TabIndex = 9;
            // 
            // BB_Novo
            // 
            this.BB_Novo.AutoSize = false;
            this.BB_Novo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BB_Novo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Novo.ForeColor = System.Drawing.Color.Green;
            this.BB_Novo.Image = ((System.Drawing.Image)(resources.GetObject("BB_Novo.Image")));
            this.BB_Novo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Novo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Novo.Name = "BB_Novo";
            this.BB_Novo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BB_Novo.Size = new System.Drawing.Size(75, 40);
            this.BB_Novo.Text = "(F2)\r\nNovo";
            this.BB_Novo.ToolTipText = "Novo Registro";
            this.BB_Novo.Click += new System.EventHandler(this.BB_Novo_Click);
            // 
            // BB_Alterar
            // 
            this.BB_Alterar.AutoSize = false;
            this.BB_Alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Alterar.ForeColor = System.Drawing.Color.Green;
            this.BB_Alterar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Alterar.Image")));
            this.BB_Alterar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Alterar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Alterar.Name = "BB_Alterar";
            this.BB_Alterar.Size = new System.Drawing.Size(75, 40);
            this.BB_Alterar.Text = "(F3)\r\nAlterar";
            this.BB_Alterar.ToolTipText = "Alterar Registro";
            this.BB_Alterar.Click += new System.EventHandler(this.BB_Alterar_Click);
            // 
            // BB_Excluir
            // 
            this.BB_Excluir.AutoSize = false;
            this.BB_Excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Excluir.ForeColor = System.Drawing.Color.Green;
            this.BB_Excluir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Excluir.Image")));
            this.BB_Excluir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Excluir.Name = "BB_Excluir";
            this.BB_Excluir.Size = new System.Drawing.Size(100, 40);
            this.BB_Excluir.Text = "(F5)\r\nExcluir";
            this.BB_Excluir.ToolTipText = "Excluir Registro";
            this.BB_Excluir.Click += new System.EventHandler(this.BB_Excluir_Click);
            // 
            // bbBuscar
            // 
            this.bbBuscar.AutoSize = false;
            this.bbBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.bbBuscar.ForeColor = System.Drawing.Color.Green;
            this.bbBuscar.Image = ((System.Drawing.Image)(resources.GetObject("bbBuscar.Image")));
            this.bbBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bbBuscar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bbBuscar.Name = "bbBuscar";
            this.bbBuscar.Size = new System.Drawing.Size(80, 40);
            this.bbBuscar.Text = "(F7)\r\nBuscar";
            this.bbBuscar.ToolTipText = "Localizar Registros";
            this.bbBuscar.Click += new System.EventHandler(this.bbBuscar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // BB_Fechar
            // 
            this.BB_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BB_Fechar.ForeColor = System.Drawing.Color.Green;
            this.BB_Fechar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Fechar.Image")));
            this.BB_Fechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Fechar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Fechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Fechar.Name = "BB_Fechar";
            this.BB_Fechar.Size = new System.Drawing.Size(54, 40);
            this.BB_Fechar.ToolTipText = "Sair da Tela";
            this.BB_Fechar.Click += new System.EventHandler(this.BB_Fechar_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(658, 348);
            this.panelDados1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridDefault1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 348);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.editDefault1);
            this.panelDados2.Controls.Add(this.label2);
            this.panelDados2.Controls.Add(this.fone);
            this.panelDados2.Controls.Add(this.label1);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(652, 34);
            this.panelDados2.TabIndex = 0;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.Location = new System.Drawing.Point(184, 7);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(283, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 3;
            this.editDefault1.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // fone
            // 
            this.fone.BackColor = System.Drawing.SystemColors.Window;
            this.fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fone.Location = new System.Drawing.Point(42, 7);
            this.fone.Name = "fone";
            this.fone.NM_Alias = "";
            this.fone.NM_Campo = "";
            this.fone.NM_CampoBusca = "";
            this.fone.NM_Param = "";
            this.fone.QTD_Zero = 0;
            this.fone.Size = new System.Drawing.Size(100, 20);
            this.fone.ST_AutoInc = false;
            this.fone.ST_DisableAuto = false;
            this.fone.ST_Float = false;
            this.fone.ST_Gravar = false;
            this.fone.ST_Int = false;
            this.fone.ST_LimpaCampo = true;
            this.fone.ST_NotNull = false;
            this.fone.ST_PrimaryKey = false;
            this.fone.TabIndex = 1;
            this.fone.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fone:";
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
            this.cdcliforDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.celularDataGridViewTextBoxColumn,
            this.cd_cidade,
            this.ds_cidade,
            this.enderecoDataGridViewTextBoxColumn,
            this.bairroDataGridViewTextBoxColumn,
            this.cepDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.obsDataGridViewTextBoxColumn,
            this.Dt_nascimentostr,
            this.Vl_renda,
            this.Tipo_sexo});
            this.dataGridDefault1.DataSource = this.bsClifor;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(3, 43);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(652, 302);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // cdcliforDataGridViewTextBoxColumn
            // 
            this.cdcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdcliforDataGridViewTextBoxColumn.DataPropertyName = "Cd_clifor";
            this.cdcliforDataGridViewTextBoxColumn.HeaderText = "Cd. Clifor";
            this.cdcliforDataGridViewTextBoxColumn.Name = "cdcliforDataGridViewTextBoxColumn";
            this.cdcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdcliforDataGridViewTextBoxColumn.Width = 74;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Nm. Cliente";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 86;
            // 
            // celularDataGridViewTextBoxColumn
            // 
            this.celularDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.celularDataGridViewTextBoxColumn.DataPropertyName = "celular";
            this.celularDataGridViewTextBoxColumn.HeaderText = "Celular";
            this.celularDataGridViewTextBoxColumn.Name = "celularDataGridViewTextBoxColumn";
            this.celularDataGridViewTextBoxColumn.ReadOnly = true;
            this.celularDataGridViewTextBoxColumn.Width = 64;
            // 
            // cd_cidade
            // 
            this.cd_cidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cd_cidade.DataPropertyName = "cd_cidade";
            this.cd_cidade.HeaderText = "Cd. Cidade";
            this.cd_cidade.Name = "cd_cidade";
            this.cd_cidade.ReadOnly = true;
            this.cd_cidade.Width = 84;
            // 
            // ds_cidade
            // 
            this.ds_cidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ds_cidade.DataPropertyName = "ds_cidade";
            this.ds_cidade.HeaderText = "Cidade";
            this.ds_cidade.Name = "ds_cidade";
            this.ds_cidade.ReadOnly = true;
            this.ds_cidade.Width = 65;
            // 
            // enderecoDataGridViewTextBoxColumn
            // 
            this.enderecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.enderecoDataGridViewTextBoxColumn.DataPropertyName = "endereco";
            this.enderecoDataGridViewTextBoxColumn.HeaderText = "Endereço";
            this.enderecoDataGridViewTextBoxColumn.Name = "enderecoDataGridViewTextBoxColumn";
            this.enderecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.enderecoDataGridViewTextBoxColumn.Width = 78;
            // 
            // bairroDataGridViewTextBoxColumn
            // 
            this.bairroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bairroDataGridViewTextBoxColumn.DataPropertyName = "bairro";
            this.bairroDataGridViewTextBoxColumn.HeaderText = "Bairro";
            this.bairroDataGridViewTextBoxColumn.Name = "bairroDataGridViewTextBoxColumn";
            this.bairroDataGridViewTextBoxColumn.ReadOnly = true;
            this.bairroDataGridViewTextBoxColumn.Width = 59;
            // 
            // cepDataGridViewTextBoxColumn
            // 
            this.cepDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cepDataGridViewTextBoxColumn.DataPropertyName = "cep";
            this.cepDataGridViewTextBoxColumn.HeaderText = "CEP";
            this.cepDataGridViewTextBoxColumn.Name = "cepDataGridViewTextBoxColumn";
            this.cepDataGridViewTextBoxColumn.ReadOnly = true;
            this.cepDataGridViewTextBoxColumn.Width = 53;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Número";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroDataGridViewTextBoxColumn.Width = 69;
            // 
            // obsDataGridViewTextBoxColumn
            // 
            this.obsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.obsDataGridViewTextBoxColumn.DataPropertyName = "obs";
            this.obsDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.obsDataGridViewTextBoxColumn.Name = "obsDataGridViewTextBoxColumn";
            this.obsDataGridViewTextBoxColumn.ReadOnly = true;
            this.obsDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsClifor
            // 
            this.bsClifor.DataSource = typeof(CamadaDados.Restaurante.Cadastro.TList_Clifor);
            // 
            // Dt_nascimentostr
            // 
            this.Dt_nascimentostr.DataPropertyName = "Dt_nascimentostr";
            this.Dt_nascimentostr.HeaderText = "Dt. Nascimento";
            this.Dt_nascimentostr.Name = "Dt_nascimentostr";
            this.Dt_nascimentostr.ReadOnly = true;
            // 
            // Vl_renda
            // 
            this.Vl_renda.DataPropertyName = "Vl_renda";
            this.Vl_renda.HeaderText = "Vl. Renda";
            this.Vl_renda.Name = "Vl_renda";
            this.Vl_renda.ReadOnly = true;
            // 
            // Tipo_sexo
            // 
            this.Tipo_sexo.DataPropertyName = "Tipo_sexo";
            this.Tipo_sexo.HeaderText = "Tipo Sexo";
            this.Tipo_sexo.Name = "Tipo_sexo";
            this.Tipo_sexo.ReadOnly = true;
            // 
            // FClifor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 391);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FClifor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de clientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FClifor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FClifor_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsClifor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Alterar;
        private System.Windows.Forms.ToolStripButton bbBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados2;
        private Componentes.EditDefault fone;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label2;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsClifor;
        public System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn celularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cd_cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ds_cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn enderecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cepDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn obsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_nascimentostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vl_renda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_sexo;
    }
}