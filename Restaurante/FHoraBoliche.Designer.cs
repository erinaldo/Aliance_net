namespace Restaurante
{
    partial class TFHoraBoliche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFHoraBoliche));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnListagem = new Componentes.PanelDados(this.components);
            this.rgServico = new Componentes.RadioGroup(this.components);
            this.radioButtonDefault1 = new Componentes.RadioButtonDefault(this.components);
            this.rbBoliche = new Componentes.RadioButtonDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbDias = new Componentes.ComboBoxDefault(this.components);
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.editHora1 = new Componentes.EditHora(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.bb_novo_abastecimento = new System.Windows.Forms.ToolStripButton();
            this.bb_alterar_abastecimento = new System.Windows.Forms.ToolStripButton();
            this.bb_excluir_abastecimento = new System.Windows.Forms.ToolStripButton();
            this.bb_gravar_abastecimento = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.tpservicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vlhoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horastrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpdiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsHoraBoliche = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.BB_Sair = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnListagem.SuspendLayout();
            this.rgServico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHoraBoliche)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnListagem, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 446);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // pnListagem
            // 
            this.pnListagem.Controls.Add(this.rgServico);
            this.pnListagem.Controls.Add(this.label4);
            this.pnListagem.Controls.Add(this.cbDias);
            this.pnListagem.Controls.Add(this.editFloat1);
            this.pnListagem.Controls.Add(this.editHora1);
            this.pnListagem.Controls.Add(this.label5);
            this.pnListagem.Controls.Add(this.label6);
            this.pnListagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnListagem.Location = new System.Drawing.Point(1, 405);
            this.pnListagem.Margin = new System.Windows.Forms.Padding(0);
            this.pnListagem.Name = "pnListagem";
            this.pnListagem.NM_ProcDeletar = "";
            this.pnListagem.NM_ProcGravar = "";
            this.pnListagem.Size = new System.Drawing.Size(561, 40);
            this.pnListagem.TabIndex = 112;
            // 
            // rgServico
            // 
            this.rgServico.Controls.Add(this.radioButtonDefault1);
            this.rgServico.Controls.Add(this.rbBoliche);
            this.rgServico.Location = new System.Drawing.Point(405, 2);
            this.rgServico.Name = "rgServico";
            this.rgServico.NM_Alias = "";
            this.rgServico.NM_Campo = "";
            this.rgServico.NM_Param = "";
            this.rgServico.NM_Valor = "";
            this.rgServico.Size = new System.Drawing.Size(140, 34);
            this.rgServico.ST_Gravar = false;
            this.rgServico.ST_NotNull = false;
            this.rgServico.TabIndex = 6;
            this.rgServico.TabStop = false;
            this.rgServico.Text = "Tp. Serviço";
            // 
            // radioButtonDefault1
            // 
            this.radioButtonDefault1.AutoSize = true;
            this.radioButtonDefault1.Checked = true;
            this.radioButtonDefault1.Location = new System.Drawing.Point(73, 13);
            this.radioButtonDefault1.Name = "radioButtonDefault1";
            this.radioButtonDefault1.Size = new System.Drawing.Size(58, 17);
            this.radioButtonDefault1.TabIndex = 1;
            this.radioButtonDefault1.TabStop = true;
            this.radioButtonDefault1.Text = "Sinuca";
            this.radioButtonDefault1.UseVisualStyleBackColor = true;
            this.radioButtonDefault1.Valor = "";
            // 
            // rbBoliche
            // 
            this.rbBoliche.AutoSize = true;
            this.rbBoliche.Location = new System.Drawing.Point(3, 13);
            this.rbBoliche.Name = "rbBoliche";
            this.rbBoliche.Size = new System.Drawing.Size(60, 17);
            this.rbBoliche.TabIndex = 0;
            this.rbBoliche.Text = "Boliche";
            this.rbBoliche.UseVisualStyleBackColor = true;
            this.rbBoliche.Valor = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dia:";
            // 
            // cbDias
            // 
            this.cbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDias.FormattingEnabled = true;
            this.cbDias.Location = new System.Drawing.Point(278, 9);
            this.cbDias.Name = "cbDias";
            this.cbDias.NM_Alias = "";
            this.cbDias.NM_Campo = "";
            this.cbDias.NM_Param = "";
            this.cbDias.Size = new System.Drawing.Size(121, 21);
            this.cbDias.ST_Gravar = true;
            this.cbDias.ST_LimparCampo = true;
            this.cbDias.ST_NotNull = true;
            this.cbDias.TabIndex = 4;
            // 
            // editFloat1
            // 
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(121, 9);
            this.editFloat1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(120, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = true;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = true;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 3;
            this.editFloat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.editFloat1.ThousandsSeparator = true;
            this.editFloat1.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // editHora1
            // 
            this.editHora1.Location = new System.Drawing.Point(40, 8);
            this.editHora1.Mask = "00:00";
            this.editHora1.Name = "editHora1";
            this.editHora1.NM_Alias = "";
            this.editHora1.NM_Campo = "";
            this.editHora1.NM_CampoBusca = "";
            this.editHora1.NM_Param = "";
            this.editHora1.Size = new System.Drawing.Size(36, 20);
            this.editHora1.ST_Gravar = true;
            this.editHora1.ST_LimpaCampo = true;
            this.editHora1.ST_NotNull = true;
            this.editHora1.ST_PrimaryKey = false;
            this.editHora1.TabIndex = 2;
            this.editHora1.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Valor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Hora:";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_novo_abastecimento,
            this.bb_alterar_abastecimento,
            this.bb_excluir_abastecimento,
            this.bb_gravar_abastecimento});
            this.toolStrip3.Location = new System.Drawing.Point(1, 364);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(561, 40);
            this.toolStrip3.TabIndex = 111;
            // 
            // bb_novo_abastecimento
            // 
            this.bb_novo_abastecimento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_novo_abastecimento.Image = ((System.Drawing.Image)(resources.GetObject("bb_novo_abastecimento.Image")));
            this.bb_novo_abastecimento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_novo_abastecimento.Name = "bb_novo_abastecimento";
            this.bb_novo_abastecimento.Size = new System.Drawing.Size(55, 37);
            this.bb_novo_abastecimento.Text = "Novo";
            this.bb_novo_abastecimento.ToolTipText = "Novo Abastecimento";
            this.bb_novo_abastecimento.Click += new System.EventHandler(this.bb_novo_abastecimento_Click);
            // 
            // bb_alterar_abastecimento
            // 
            this.bb_alterar_abastecimento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_alterar_abastecimento.Image = ((System.Drawing.Image)(resources.GetObject("bb_alterar_abastecimento.Image")));
            this.bb_alterar_abastecimento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_alterar_abastecimento.Name = "bb_alterar_abastecimento";
            this.bb_alterar_abastecimento.Size = new System.Drawing.Size(67, 37);
            this.bb_alterar_abastecimento.Text = "Alterar";
            this.bb_alterar_abastecimento.ToolTipText = "Alterar Abastecimento";
            this.bb_alterar_abastecimento.Click += new System.EventHandler(this.bb_alterar_abastecimento_Click);
            // 
            // bb_excluir_abastecimento
            // 
            this.bb_excluir_abastecimento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_excluir_abastecimento.Image = ((System.Drawing.Image)(resources.GetObject("bb_excluir_abastecimento.Image")));
            this.bb_excluir_abastecimento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_excluir_abastecimento.Name = "bb_excluir_abastecimento";
            this.bb_excluir_abastecimento.Size = new System.Drawing.Size(64, 37);
            this.bb_excluir_abastecimento.Text = "Excluir";
            this.bb_excluir_abastecimento.ToolTipText = "Excluir Abastecimento";
            this.bb_excluir_abastecimento.Click += new System.EventHandler(this.bb_excluir_abastecimento_Click);
            // 
            // bb_gravar_abastecimento
            // 
            this.bb_gravar_abastecimento.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_gravar_abastecimento.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar_abastecimento.Image")));
            this.bb_gravar_abastecimento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_gravar_abastecimento.Name = "bb_gravar_abastecimento";
            this.bb_gravar_abastecimento.Size = new System.Drawing.Size(66, 37);
            this.bb_gravar_abastecimento.Text = "Gravar";
            this.bb_gravar_abastecimento.ToolTipText = "Gravar Abastecimento";
            this.bb_gravar_abastecimento.Click += new System.EventHandler(this.bb_gravar_abastecimento_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 60);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(555, 300);
            this.panelDados1.TabIndex = 110;
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
            this.tpservicoDataGridViewTextBoxColumn,
            this.diaDataGridViewTextBoxColumn,
            this.horaDataGridViewTextBoxColumn,
            this.vlhoraDataGridViewTextBoxColumn,
            this.idHoraDataGridViewTextBoxColumn,
            this.horastrDataGridViewTextBoxColumn,
            this.tpdiaDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsHoraBoliche;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridDefault1.Size = new System.Drawing.Size(555, 300);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // tpservicoDataGridViewTextBoxColumn
            // 
            this.tpservicoDataGridViewTextBoxColumn.DataPropertyName = "Tp_servico";
            this.tpservicoDataGridViewTextBoxColumn.HeaderText = "Tp. Serviço";
            this.tpservicoDataGridViewTextBoxColumn.Name = "tpservicoDataGridViewTextBoxColumn";
            this.tpservicoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diaDataGridViewTextBoxColumn
            // 
            this.diaDataGridViewTextBoxColumn.DataPropertyName = "Dia";
            this.diaDataGridViewTextBoxColumn.HeaderText = "Dia";
            this.diaDataGridViewTextBoxColumn.Name = "diaDataGridViewTextBoxColumn";
            this.diaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // horaDataGridViewTextBoxColumn
            // 
            this.horaDataGridViewTextBoxColumn.DataPropertyName = "Hora";
            this.horaDataGridViewTextBoxColumn.HeaderText = "Hora";
            this.horaDataGridViewTextBoxColumn.Name = "horaDataGridViewTextBoxColumn";
            this.horaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vlhoraDataGridViewTextBoxColumn
            // 
            this.vlhoraDataGridViewTextBoxColumn.DataPropertyName = "Vl_hora";
            this.vlhoraDataGridViewTextBoxColumn.HeaderText = "Vl. Hora";
            this.vlhoraDataGridViewTextBoxColumn.Name = "vlhoraDataGridViewTextBoxColumn";
            this.vlhoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idHoraDataGridViewTextBoxColumn
            // 
            this.idHoraDataGridViewTextBoxColumn.DataPropertyName = "Id_Hora";
            this.idHoraDataGridViewTextBoxColumn.HeaderText = "Id_Hora";
            this.idHoraDataGridViewTextBoxColumn.Name = "idHoraDataGridViewTextBoxColumn";
            this.idHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.idHoraDataGridViewTextBoxColumn.Visible = false;
            // 
            // horastrDataGridViewTextBoxColumn
            // 
            this.horastrDataGridViewTextBoxColumn.DataPropertyName = "Horastr";
            this.horastrDataGridViewTextBoxColumn.HeaderText = "Horastr";
            this.horastrDataGridViewTextBoxColumn.Name = "horastrDataGridViewTextBoxColumn";
            this.horastrDataGridViewTextBoxColumn.ReadOnly = true;
            this.horastrDataGridViewTextBoxColumn.Visible = false;
            // 
            // tpdiaDataGridViewTextBoxColumn
            // 
            this.tpdiaDataGridViewTextBoxColumn.DataPropertyName = "Tp_dia";
            this.tpdiaDataGridViewTextBoxColumn.HeaderText = "Tp_dia";
            this.tpdiaDataGridViewTextBoxColumn.Name = "tpdiaDataGridViewTextBoxColumn";
            this.tpdiaDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpdiaDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsHoraBoliche
            // 
            this.bsHoraBoliche.DataSource = typeof(CamadaDados.Restaurante.TList_HoraBoliche);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.BB_Sair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 47);
            this.panel2.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(194, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(279, 25);
            this.label10.TabIndex = 46;
            this.label10.Text = "Tabela de preço por horário";
            // 
            // BB_Sair
            // 
            this.BB_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Sair.ForeColor = System.Drawing.Color.Green;
            this.BB_Sair.Image = ((System.Drawing.Image)(resources.GetObject("BB_Sair.Image")));
            this.BB_Sair.Location = new System.Drawing.Point(476, 3);
            this.BB_Sair.Name = "BB_Sair";
            this.BB_Sair.Size = new System.Drawing.Size(74, 41);
            this.BB_Sair.TabIndex = 0;
            this.BB_Sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BB_Sair.UseVisualStyleBackColor = true;
            this.BB_Sair.Click += new System.EventHandler(this.BB_Sair_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Hora";
            this.dataGridViewTextBoxColumn2.HeaderText = "Hora";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Dia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Dia";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Vl_hora";
            this.dataGridViewTextBoxColumn5.HeaderText = "Vl. Hora";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tp_servico";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tp. Serviço";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Tp_dia";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tp. Dia";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Id_Hora";
            this.dataGridViewTextBoxColumn6.HeaderText = "Id. Hora";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Horastr";
            this.dataGridViewTextBoxColumn7.HeaderText = "Horastr";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // TFHoraBoliche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TFHoraBoliche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabela de preço por horário";
            this.Load += new System.EventHandler(this.TFHoraBoliche_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnListagem.ResumeLayout(false);
            this.pnListagem.PerformLayout();
            this.rgServico.ResumeLayout(false);
            this.rgServico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsHoraBoliche)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsHoraBoliche;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BB_Sair;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton bb_novo_abastecimento;
        private System.Windows.Forms.ToolStripButton bb_alterar_abastecimento;
        private System.Windows.Forms.ToolStripButton bb_excluir_abastecimento;
        private System.Windows.Forms.ToolStripButton bb_gravar_abastecimento;
        private Componentes.PanelDados pnListagem;
        private Componentes.RadioGroup rgServico;
        private Componentes.RadioButtonDefault radioButtonDefault1;
        private Componentes.RadioButtonDefault rbBoliche;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault cbDias;
        private Componentes.EditFloat editFloat1;
        private Componentes.EditHora editHora1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpservicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vlhoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horastrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpdiaDataGridViewTextBoxColumn;
    }
}