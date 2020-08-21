namespace Locacao.Cadastros
{
    partial class TFCFGLocacao
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
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label cD_TabelaPrecoLabel;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label cFG_Pedido_ServicoLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCFGLocacao));
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.bsCFGLocacao = new System.Windows.Forms.BindingSource(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.tp_ordem = new Componentes.EditDefault(this.components);
            this.ds_tipoordem = new Componentes.EditDefault(this.components);
            this.bb_ordem = new System.Windows.Forms.Button();
            this.gCfg = new Componentes.DataGridDefault(this.components);
            this.cdempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpordemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dstipoordemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.St_HoraAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.Cd_PedidoServico = new Componentes.EditDefault(this.components);
            this.Ds_PedidoServico = new Componentes.EditDefault(this.components);
            this.bb_PedidoServico = new System.Windows.Forms.Button();
            this.ds_config = new Componentes.EditDefault(this.components);
            this.bb_config = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.id_config = new Componentes.EditDefault(this.components);
            this.ds_centroresultdia = new Componentes.EditDefault(this.components);
            this.bb_centroresultdia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cd_centroresultdia = new Componentes.EditDefault(this.components);
            this.ds_centroresultsem = new Componentes.EditDefault(this.components);
            this.bb_centroresultsem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cd_centroresultsem = new Componentes.EditDefault(this.components);
            this.ds_centroresultquinz = new Componentes.EditDefault(this.components);
            this.bb_centroresultquinz = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cd_centroresultquinz = new Componentes.EditDefault(this.components);
            this.ds_centroresultmes = new Componentes.EditDefault(this.components);
            this.bb_centroresultmes = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cd_centroresultmes = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nr_seqrecibo = new Componentes.EditFloat(this.components);
            this.ds_tpprodcombustivel = new Componentes.EditDefault(this.components);
            this.bb_tpprodcombustivel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tp_prodcombustivel = new Componentes.EditDefault(this.components);
            this.checkBoxDefault1 = new Componentes.CheckBoxDefault(this.components);
            this.tp_ordemp = new Componentes.EditDefault(this.components);
            this.ds_tipoordemp = new Componentes.EditDefault(this.components);
            this.BB_Tp_Ordemp = new System.Windows.Forms.Button();
            cd_empresaLabel = new System.Windows.Forms.Label();
            cD_TabelaPrecoLabel = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            cFG_Pedido_ServicoLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGLocacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCfg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_seqrecibo)).BeginInit();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.tp_ordemp);
            this.pDados.Controls.Add(this.ds_tipoordemp);
            this.pDados.Controls.Add(this.BB_Tp_Ordemp);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.checkBoxDefault1);
            this.pDados.Controls.Add(this.ds_tpprodcombustivel);
            this.pDados.Controls.Add(this.bb_tpprodcombustivel);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.tp_prodcombustivel);
            this.pDados.Controls.Add(this.nr_seqrecibo);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_centroresultmes);
            this.pDados.Controls.Add(this.bb_centroresultmes);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.cd_centroresultmes);
            this.pDados.Controls.Add(this.ds_centroresultquinz);
            this.pDados.Controls.Add(this.bb_centroresultquinz);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.cd_centroresultquinz);
            this.pDados.Controls.Add(this.ds_centroresultsem);
            this.pDados.Controls.Add(this.bb_centroresultsem);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cd_centroresultsem);
            this.pDados.Controls.Add(this.ds_centroresultdia);
            this.pDados.Controls.Add(this.bb_centroresultdia);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cd_centroresultdia);
            this.pDados.Controls.Add(this.ds_config);
            this.pDados.Controls.Add(this.bb_config);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.id_config);
            this.pDados.Controls.Add(this.Cd_PedidoServico);
            this.pDados.Controls.Add(this.Ds_PedidoServico);
            this.pDados.Controls.Add(this.bb_PedidoServico);
            this.pDados.Controls.Add(cFG_Pedido_ServicoLabel);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(label12);
            this.pDados.Controls.Add(this.tp_docto);
            this.pDados.Controls.Add(this.ds_tpdocto);
            this.pDados.Controls.Add(this.bb_tpdocto);
            this.pDados.Controls.Add(label11);
            this.pDados.Controls.Add(this.tp_duplicata);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.bb_tpduplicata);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.tp_ordem);
            this.pDados.Controls.Add(this.ds_tipoordem);
            this.pDados.Controls.Add(this.bb_ordem);
            this.pDados.Controls.Add(cD_TabelaPrecoLabel);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Size = new System.Drawing.Size(716, 367);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(728, 448);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.gCfg);
            this.tpPadrao.Size = new System.Drawing.Size(720, 422);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.gCfg, 0);
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(75, 14);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(51, 13);
            cd_empresaLabel.TabIndex = 44;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // cD_TabelaPrecoLabel
            // 
            cD_TabelaPrecoLabel.AutoSize = true;
            cD_TabelaPrecoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            cD_TabelaPrecoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cD_TabelaPrecoLabel.Location = new System.Drawing.Point(49, 40);
            cD_TabelaPrecoLabel.Name = "cD_TabelaPrecoLabel";
            cD_TabelaPrecoLabel.Size = new System.Drawing.Size(78, 13);
            cD_TabelaPrecoLabel.TabIndex = 48;
            cD_TabelaPrecoLabel.Text = "Tipo Ordem C.:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(48, 93);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(79, 13);
            label10.TabIndex = 59;
            label10.Text = "Tipo Duplicata:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label11.Location = new System.Drawing.Point(41, 117);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(85, 13);
            label11.TabIndex = 63;
            label11.Text = "TP. Documento:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label12.Location = new System.Drawing.Point(55, 142);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(71, 13);
            label12.TabIndex = 67;
            label12.Text = "Historico Fin.:";
            // 
            // cFG_Pedido_ServicoLabel
            // 
            cFG_Pedido_ServicoLabel.AutoSize = true;
            cFG_Pedido_ServicoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            cFG_Pedido_ServicoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cFG_Pedido_ServicoLabel.Location = new System.Drawing.Point(41, 170);
            cFG_Pedido_ServicoLabel.Name = "cFG_Pedido_ServicoLabel";
            cFG_Pedido_ServicoLabel.Size = new System.Drawing.Size(82, 13);
            cFG_Pedido_ServicoLabel.TabIndex = 69;
            cFG_Pedido_ServicoLabel.Text = "Pedido Servico:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(49, 67);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(78, 13);
            label8.TabIndex = 414;
            label8.Text = "Tipo Ordem P.:";
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresa.Enabled = false;
            this.cd_empresa.Location = new System.Drawing.Point(126, 12);
            this.cd_empresa.MaxLength = 4;
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(67, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // bsCFGLocacao
            // 
            this.bsCFGLocacao.DataSource = typeof(CamadaDados.Locacao.Cadastros.TList_CFGLocacao);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresa.Enabled = false;
            this.nm_empresa.Location = new System.Drawing.Point(229, 11);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "";
            this.nm_empresa.NM_Campo = "nm_empresa";
            this.nm_empresa.NM_CampoBusca = "nm_empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(442, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 45;
            this.nm_empresa.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Enabled = false;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(196, 11);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // tp_ordem
            // 
            this.tp_ordem.BackColor = System.Drawing.SystemColors.Window;
            this.tp_ordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_ordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_ordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Tp_ordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_ordem.Enabled = false;
            this.tp_ordem.Location = new System.Drawing.Point(126, 38);
            this.tp_ordem.Name = "tp_ordem";
            this.tp_ordem.NM_Alias = "a";
            this.tp_ordem.NM_Campo = "tp_ordem";
            this.tp_ordem.NM_CampoBusca = "tp_ordem";
            this.tp_ordem.NM_Param = "@P_CD_TABELAPRECO";
            this.tp_ordem.QTD_Zero = 0;
            this.tp_ordem.Size = new System.Drawing.Size(67, 20);
            this.tp_ordem.ST_AutoInc = false;
            this.tp_ordem.ST_DisableAuto = false;
            this.tp_ordem.ST_Float = false;
            this.tp_ordem.ST_Gravar = true;
            this.tp_ordem.ST_Int = true;
            this.tp_ordem.ST_LimpaCampo = true;
            this.tp_ordem.ST_NotNull = true;
            this.tp_ordem.ST_PrimaryKey = true;
            this.tp_ordem.TabIndex = 2;
            this.tp_ordem.TextOld = null;
            this.tp_ordem.Leave += new System.EventHandler(this.tp_ordem_Leave);
            // 
            // ds_tipoordem
            // 
            this.ds_tipoordem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoordem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipoordem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoordem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tipoordem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tipoordem.Enabled = false;
            this.ds_tipoordem.Location = new System.Drawing.Point(229, 39);
            this.ds_tipoordem.Name = "ds_tipoordem";
            this.ds_tipoordem.NM_Alias = "b";
            this.ds_tipoordem.NM_Campo = "ds_tipoordem";
            this.ds_tipoordem.NM_CampoBusca = "ds_tipoordem";
            this.ds_tipoordem.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tipoordem.QTD_Zero = 0;
            this.ds_tipoordem.Size = new System.Drawing.Size(441, 20);
            this.ds_tipoordem.ST_AutoInc = false;
            this.ds_tipoordem.ST_DisableAuto = false;
            this.ds_tipoordem.ST_Float = false;
            this.ds_tipoordem.ST_Gravar = false;
            this.ds_tipoordem.ST_Int = false;
            this.ds_tipoordem.ST_LimpaCampo = true;
            this.ds_tipoordem.ST_NotNull = false;
            this.ds_tipoordem.ST_PrimaryKey = false;
            this.ds_tipoordem.TabIndex = 49;
            this.ds_tipoordem.TextOld = null;
            // 
            // bb_ordem
            // 
            this.bb_ordem.Enabled = false;
            this.bb_ordem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_ordem.Image = ((System.Drawing.Image)(resources.GetObject("bb_ordem.Image")));
            this.bb_ordem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ordem.Location = new System.Drawing.Point(196, 39);
            this.bb_ordem.Name = "bb_ordem";
            this.bb_ordem.Size = new System.Drawing.Size(28, 19);
            this.bb_ordem.TabIndex = 3;
            this.bb_ordem.UseVisualStyleBackColor = true;
            this.bb_ordem.Click += new System.EventHandler(this.bb_ordem_Click);
            // 
            // gCfg
            // 
            this.gCfg.AllowUserToAddRows = false;
            this.gCfg.AllowUserToDeleteRows = false;
            this.gCfg.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gCfg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gCfg.AutoGenerateColumns = false;
            this.gCfg.BackgroundColor = System.Drawing.Color.LightGray;
            this.gCfg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gCfg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCfg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gCfg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gCfg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdempresaDataGridViewTextBoxColumn,
            this.nmempresaDataGridViewTextBoxColumn,
            this.tpordemDataGridViewTextBoxColumn,
            this.dstipoordemDataGridViewTextBoxColumn,
            this.St_HoraAuto});
            this.gCfg.DataSource = this.bsCFGLocacao;
            this.gCfg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCfg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gCfg.Location = new System.Drawing.Point(0, 367);
            this.gCfg.Name = "gCfg";
            this.gCfg.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gCfg.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gCfg.RowHeadersWidth = 23;
            this.gCfg.Size = new System.Drawing.Size(716, 51);
            this.gCfg.TabIndex = 1;
            // 
            // cdempresaDataGridViewTextBoxColumn
            // 
            this.cdempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdempresaDataGridViewTextBoxColumn.DataPropertyName = "Cd_empresa";
            this.cdempresaDataGridViewTextBoxColumn.HeaderText = "Cd.Empresa";
            this.cdempresaDataGridViewTextBoxColumn.Name = "cdempresaDataGridViewTextBoxColumn";
            this.cdempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdempresaDataGridViewTextBoxColumn.Width = 89;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // tpordemDataGridViewTextBoxColumn
            // 
            this.tpordemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tpordemDataGridViewTextBoxColumn.DataPropertyName = "Tp_ordem";
            this.tpordemDataGridViewTextBoxColumn.HeaderText = "TP.Ordem";
            this.tpordemDataGridViewTextBoxColumn.Name = "tpordemDataGridViewTextBoxColumn";
            this.tpordemDataGridViewTextBoxColumn.ReadOnly = true;
            this.tpordemDataGridViewTextBoxColumn.Width = 80;
            // 
            // dstipoordemDataGridViewTextBoxColumn
            // 
            this.dstipoordemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dstipoordemDataGridViewTextBoxColumn.DataPropertyName = "Ds_tipoordem";
            this.dstipoordemDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.dstipoordemDataGridViewTextBoxColumn.Name = "dstipoordemDataGridViewTextBoxColumn";
            this.dstipoordemDataGridViewTextBoxColumn.ReadOnly = true;
            this.dstipoordemDataGridViewTextBoxColumn.Width = 80;
            // 
            // St_HoraAuto
            // 
            this.St_HoraAuto.DataPropertyName = "St_HoraAuto";
            this.St_HoraAuto.HeaderText = "St.HoraAuto";
            this.St_HoraAuto.Name = "St_HoraAuto";
            this.St_HoraAuto.ReadOnly = true;
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Tp_duplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_duplicata.Enabled = false;
            this.tp_duplicata.Location = new System.Drawing.Point(126, 90);
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "a";
            this.tp_duplicata.NM_Campo = "tp_duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_CFG_PEDIDO";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(67, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = true;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = false;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 4;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tpduplicata", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Location = new System.Drawing.Point(229, 91);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_DS_TIPOPEDIDO";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.Size = new System.Drawing.Size(441, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 60;
            this.ds_tpduplicata.TextOld = null;
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.Enabled = false;
            this.bb_tpduplicata.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(196, 91);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpduplicata.TabIndex = 5;
            this.bb_tpduplicata.UseVisualStyleBackColor = true;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Tp_docto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_docto.Enabled = false;
            this.tp_docto.Location = new System.Drawing.Point(126, 116);
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "a";
            this.tp_docto.NM_Campo = "tp_docto";
            this.tp_docto.NM_CampoBusca = "tp_docto";
            this.tp_docto.NM_Param = "@P_CFG_PEDIDO";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(67, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = true;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = false;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 6;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tpdocto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Location = new System.Drawing.Point(229, 117);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_DS_TIPOPEDIDO";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.Size = new System.Drawing.Size(441, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 64;
            this.ds_tpdocto.TextOld = null;
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.Enabled = false;
            this.bb_tpdocto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(196, 116);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdocto.TabIndex = 7;
            this.bb_tpdocto.UseVisualStyleBackColor = true;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_historico.Enabled = false;
            this.cd_historico.Location = new System.Drawing.Point(126, 141);
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "a";
            this.cd_historico.NM_Campo = "cd_historico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CFG_PEDIDO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(67, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = true;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = false;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 8;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_historico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(229, 142);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_DS_TIPOPEDIDO";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(441, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 68;
            this.ds_historico.TextOld = null;
            // 
            // bb_historico
            // 
            this.bb_historico.Enabled = false;
            this.bb_historico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(196, 142);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(28, 19);
            this.bb_historico.TabIndex = 9;
            this.bb_historico.UseVisualStyleBackColor = true;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // Cd_PedidoServico
            // 
            this.Cd_PedidoServico.BackColor = System.Drawing.SystemColors.Window;
            this.Cd_PedidoServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Cd_PedidoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Cd_PedidoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cfg_pedido_servico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cd_PedidoServico.Enabled = false;
            this.Cd_PedidoServico.Location = new System.Drawing.Point(126, 167);
            this.Cd_PedidoServico.Name = "Cd_PedidoServico";
            this.Cd_PedidoServico.NM_Alias = "a";
            this.Cd_PedidoServico.NM_Campo = "CFG_Pedido";
            this.Cd_PedidoServico.NM_CampoBusca = "CFG_Pedido";
            this.Cd_PedidoServico.NM_Param = "@P_CFG_PEDIDO";
            this.Cd_PedidoServico.QTD_Zero = 0;
            this.Cd_PedidoServico.Size = new System.Drawing.Size(67, 20);
            this.Cd_PedidoServico.ST_AutoInc = false;
            this.Cd_PedidoServico.ST_DisableAuto = false;
            this.Cd_PedidoServico.ST_Float = false;
            this.Cd_PedidoServico.ST_Gravar = true;
            this.Cd_PedidoServico.ST_Int = true;
            this.Cd_PedidoServico.ST_LimpaCampo = true;
            this.Cd_PedidoServico.ST_NotNull = false;
            this.Cd_PedidoServico.ST_PrimaryKey = false;
            this.Cd_PedidoServico.TabIndex = 10;
            this.Cd_PedidoServico.TextOld = null;
            this.Cd_PedidoServico.Leave += new System.EventHandler(this.Cd_PedidoServico_Leave);
            // 
            // Ds_PedidoServico
            // 
            this.Ds_PedidoServico.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_PedidoServico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_PedidoServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_PedidoServico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tipopedido_servico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_PedidoServico.Enabled = false;
            this.Ds_PedidoServico.Location = new System.Drawing.Point(229, 167);
            this.Ds_PedidoServico.Name = "Ds_PedidoServico";
            this.Ds_PedidoServico.NM_Alias = "";
            this.Ds_PedidoServico.NM_Campo = "ds_tipopedido";
            this.Ds_PedidoServico.NM_CampoBusca = "ds_tipopedido";
            this.Ds_PedidoServico.NM_Param = "@P_DS_TIPOPEDIDO";
            this.Ds_PedidoServico.QTD_Zero = 0;
            this.Ds_PedidoServico.Size = new System.Drawing.Size(441, 20);
            this.Ds_PedidoServico.ST_AutoInc = false;
            this.Ds_PedidoServico.ST_DisableAuto = false;
            this.Ds_PedidoServico.ST_Float = false;
            this.Ds_PedidoServico.ST_Gravar = false;
            this.Ds_PedidoServico.ST_Int = false;
            this.Ds_PedidoServico.ST_LimpaCampo = true;
            this.Ds_PedidoServico.ST_NotNull = false;
            this.Ds_PedidoServico.ST_PrimaryKey = false;
            this.Ds_PedidoServico.TabIndex = 72;
            this.Ds_PedidoServico.TextOld = null;
            // 
            // bb_PedidoServico
            // 
            this.bb_PedidoServico.Enabled = false;
            this.bb_PedidoServico.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_PedidoServico.Image = ((System.Drawing.Image)(resources.GetObject("bb_PedidoServico.Image")));
            this.bb_PedidoServico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_PedidoServico.Location = new System.Drawing.Point(196, 167);
            this.bb_PedidoServico.Name = "bb_PedidoServico";
            this.bb_PedidoServico.Size = new System.Drawing.Size(28, 19);
            this.bb_PedidoServico.TabIndex = 11;
            this.bb_PedidoServico.UseVisualStyleBackColor = true;
            this.bb_PedidoServico.Click += new System.EventHandler(this.bb_PedidoServico_Click);
            // 
            // ds_config
            // 
            this.ds_config.BackColor = System.Drawing.SystemColors.Window;
            this.ds_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_config.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_config.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_configboleto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_config.Enabled = false;
            this.ds_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_config.Location = new System.Drawing.Point(229, 192);
            this.ds_config.Name = "ds_config";
            this.ds_config.NM_Alias = "a";
            this.ds_config.NM_Campo = "ds_config";
            this.ds_config.NM_CampoBusca = "ds_config";
            this.ds_config.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_config.QTD_Zero = 0;
            this.ds_config.ReadOnly = true;
            this.ds_config.Size = new System.Drawing.Size(441, 20);
            this.ds_config.ST_AutoInc = false;
            this.ds_config.ST_DisableAuto = false;
            this.ds_config.ST_Float = false;
            this.ds_config.ST_Gravar = false;
            this.ds_config.ST_Int = false;
            this.ds_config.ST_LimpaCampo = true;
            this.ds_config.ST_NotNull = false;
            this.ds_config.ST_PrimaryKey = false;
            this.ds_config.TabIndex = 384;
            this.ds_config.TextOld = null;
            // 
            // bb_config
            // 
            this.bb_config.Enabled = false;
            this.bb_config.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_config.Image = ((System.Drawing.Image)(resources.GetObject("bb_config.Image")));
            this.bb_config.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_config.Location = new System.Drawing.Point(196, 192);
            this.bb_config.Name = "bb_config";
            this.bb_config.Size = new System.Drawing.Size(28, 19);
            this.bb_config.TabIndex = 13;
            this.bb_config.UseVisualStyleBackColor = true;
            this.bb_config.Click += new System.EventHandler(this.bb_config_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(46, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 383;
            this.label3.Text = "Config. Boleto:";
            // 
            // id_config
            // 
            this.id_config.BackColor = System.Drawing.SystemColors.Window;
            this.id_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_config.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_config.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Id_configboleto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_config.Enabled = false;
            this.id_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_config.Location = new System.Drawing.Point(126, 192);
            this.id_config.Name = "id_config";
            this.id_config.NM_Alias = "a";
            this.id_config.NM_Campo = "id_config";
            this.id_config.NM_CampoBusca = "id_config";
            this.id_config.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.id_config.QTD_Zero = 0;
            this.id_config.Size = new System.Drawing.Size(67, 20);
            this.id_config.ST_AutoInc = false;
            this.id_config.ST_DisableAuto = false;
            this.id_config.ST_Float = false;
            this.id_config.ST_Gravar = true;
            this.id_config.ST_Int = true;
            this.id_config.ST_LimpaCampo = true;
            this.id_config.ST_NotNull = false;
            this.id_config.ST_PrimaryKey = false;
            this.id_config.TabIndex = 12;
            this.id_config.TextOld = null;
            this.id_config.Leave += new System.EventHandler(this.id_config_Leave);
            // 
            // ds_centroresultdia
            // 
            this.ds_centroresultdia.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultdia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultdia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultdia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_centroresultdia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultdia.Enabled = false;
            this.ds_centroresultdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_centroresultdia.Location = new System.Drawing.Point(229, 218);
            this.ds_centroresultdia.Name = "ds_centroresultdia";
            this.ds_centroresultdia.NM_Alias = "a";
            this.ds_centroresultdia.NM_Campo = "DS_CentroResultado";
            this.ds_centroresultdia.NM_CampoBusca = "DS_CentroResultado";
            this.ds_centroresultdia.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_centroresultdia.QTD_Zero = 0;
            this.ds_centroresultdia.ReadOnly = true;
            this.ds_centroresultdia.Size = new System.Drawing.Size(441, 20);
            this.ds_centroresultdia.ST_AutoInc = false;
            this.ds_centroresultdia.ST_DisableAuto = false;
            this.ds_centroresultdia.ST_Float = false;
            this.ds_centroresultdia.ST_Gravar = false;
            this.ds_centroresultdia.ST_Int = false;
            this.ds_centroresultdia.ST_LimpaCampo = true;
            this.ds_centroresultdia.ST_NotNull = false;
            this.ds_centroresultdia.ST_PrimaryKey = false;
            this.ds_centroresultdia.TabIndex = 392;
            this.ds_centroresultdia.TextOld = null;
            // 
            // bb_centroresultdia
            // 
            this.bb_centroresultdia.Enabled = false;
            this.bb_centroresultdia.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresultdia.Image = ((System.Drawing.Image)(resources.GetObject("bb_centroresultdia.Image")));
            this.bb_centroresultdia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_centroresultdia.Location = new System.Drawing.Point(196, 218);
            this.bb_centroresultdia.Name = "bb_centroresultdia";
            this.bb_centroresultdia.Size = new System.Drawing.Size(28, 19);
            this.bb_centroresultdia.TabIndex = 15;
            this.bb_centroresultdia.UseVisualStyleBackColor = true;
            this.bb_centroresultdia.Click += new System.EventHandler(this.bb_centroresultdia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(24, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 391;
            this.label2.Text = "Centro Result. Dia:";
            // 
            // cd_centroresultdia
            // 
            this.cd_centroresultdia.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresultdia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresultdia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresultdia.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_centroresultdia", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresultdia.Enabled = false;
            this.cd_centroresultdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_centroresultdia.Location = new System.Drawing.Point(126, 218);
            this.cd_centroresultdia.Name = "cd_centroresultdia";
            this.cd_centroresultdia.NM_Alias = "a";
            this.cd_centroresultdia.NM_Campo = "cd_centroresult";
            this.cd_centroresultdia.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresultdia.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.cd_centroresultdia.QTD_Zero = 0;
            this.cd_centroresultdia.Size = new System.Drawing.Size(67, 20);
            this.cd_centroresultdia.ST_AutoInc = false;
            this.cd_centroresultdia.ST_DisableAuto = false;
            this.cd_centroresultdia.ST_Float = false;
            this.cd_centroresultdia.ST_Gravar = true;
            this.cd_centroresultdia.ST_Int = true;
            this.cd_centroresultdia.ST_LimpaCampo = true;
            this.cd_centroresultdia.ST_NotNull = false;
            this.cd_centroresultdia.ST_PrimaryKey = false;
            this.cd_centroresultdia.TabIndex = 14;
            this.cd_centroresultdia.TextOld = null;
            this.cd_centroresultdia.Leave += new System.EventHandler(this.cd_centroresultdia_Leave);
            // 
            // ds_centroresultsem
            // 
            this.ds_centroresultsem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultsem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultsem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultsem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_centroresultsem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultsem.Enabled = false;
            this.ds_centroresultsem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_centroresultsem.Location = new System.Drawing.Point(229, 244);
            this.ds_centroresultsem.Name = "ds_centroresultsem";
            this.ds_centroresultsem.NM_Alias = "a";
            this.ds_centroresultsem.NM_Campo = "DS_CentroResultado";
            this.ds_centroresultsem.NM_CampoBusca = "DS_CentroResultado";
            this.ds_centroresultsem.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_centroresultsem.QTD_Zero = 0;
            this.ds_centroresultsem.ReadOnly = true;
            this.ds_centroresultsem.Size = new System.Drawing.Size(441, 20);
            this.ds_centroresultsem.ST_AutoInc = false;
            this.ds_centroresultsem.ST_DisableAuto = false;
            this.ds_centroresultsem.ST_Float = false;
            this.ds_centroresultsem.ST_Gravar = false;
            this.ds_centroresultsem.ST_Int = false;
            this.ds_centroresultsem.ST_LimpaCampo = true;
            this.ds_centroresultsem.ST_NotNull = false;
            this.ds_centroresultsem.ST_PrimaryKey = false;
            this.ds_centroresultsem.TabIndex = 396;
            this.ds_centroresultsem.TextOld = null;
            // 
            // bb_centroresultsem
            // 
            this.bb_centroresultsem.Enabled = false;
            this.bb_centroresultsem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresultsem.Image = ((System.Drawing.Image)(resources.GetObject("bb_centroresultsem.Image")));
            this.bb_centroresultsem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_centroresultsem.Location = new System.Drawing.Point(196, 244);
            this.bb_centroresultsem.Name = "bb_centroresultsem";
            this.bb_centroresultsem.Size = new System.Drawing.Size(28, 19);
            this.bb_centroresultsem.TabIndex = 17;
            this.bb_centroresultsem.UseVisualStyleBackColor = true;
            this.bb_centroresultsem.Click += new System.EventHandler(this.bb_centroresultsem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(16, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 395;
            this.label4.Text = "Centro Result. Sem.:";
            // 
            // cd_centroresultsem
            // 
            this.cd_centroresultsem.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresultsem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresultsem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresultsem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_centroresultsem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresultsem.Enabled = false;
            this.cd_centroresultsem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_centroresultsem.Location = new System.Drawing.Point(126, 244);
            this.cd_centroresultsem.Name = "cd_centroresultsem";
            this.cd_centroresultsem.NM_Alias = "a";
            this.cd_centroresultsem.NM_Campo = "cd_centroresult";
            this.cd_centroresultsem.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresultsem.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.cd_centroresultsem.QTD_Zero = 0;
            this.cd_centroresultsem.Size = new System.Drawing.Size(67, 20);
            this.cd_centroresultsem.ST_AutoInc = false;
            this.cd_centroresultsem.ST_DisableAuto = false;
            this.cd_centroresultsem.ST_Float = false;
            this.cd_centroresultsem.ST_Gravar = true;
            this.cd_centroresultsem.ST_Int = true;
            this.cd_centroresultsem.ST_LimpaCampo = true;
            this.cd_centroresultsem.ST_NotNull = false;
            this.cd_centroresultsem.ST_PrimaryKey = false;
            this.cd_centroresultsem.TabIndex = 16;
            this.cd_centroresultsem.TextOld = null;
            this.cd_centroresultsem.Leave += new System.EventHandler(this.cd_centroresultsem_Leave);
            // 
            // ds_centroresultquinz
            // 
            this.ds_centroresultquinz.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultquinz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultquinz.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultquinz.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_centroresultquinz", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultquinz.Enabled = false;
            this.ds_centroresultquinz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_centroresultquinz.Location = new System.Drawing.Point(229, 270);
            this.ds_centroresultquinz.Name = "ds_centroresultquinz";
            this.ds_centroresultquinz.NM_Alias = "a";
            this.ds_centroresultquinz.NM_Campo = "DS_CentroResultado";
            this.ds_centroresultquinz.NM_CampoBusca = "DS_CentroResultado";
            this.ds_centroresultquinz.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_centroresultquinz.QTD_Zero = 0;
            this.ds_centroresultquinz.ReadOnly = true;
            this.ds_centroresultquinz.Size = new System.Drawing.Size(441, 20);
            this.ds_centroresultquinz.ST_AutoInc = false;
            this.ds_centroresultquinz.ST_DisableAuto = false;
            this.ds_centroresultquinz.ST_Float = false;
            this.ds_centroresultquinz.ST_Gravar = false;
            this.ds_centroresultquinz.ST_Int = false;
            this.ds_centroresultquinz.ST_LimpaCampo = true;
            this.ds_centroresultquinz.ST_NotNull = false;
            this.ds_centroresultquinz.ST_PrimaryKey = false;
            this.ds_centroresultquinz.TabIndex = 400;
            this.ds_centroresultquinz.TextOld = null;
            // 
            // bb_centroresultquinz
            // 
            this.bb_centroresultquinz.Enabled = false;
            this.bb_centroresultquinz.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresultquinz.Image = ((System.Drawing.Image)(resources.GetObject("bb_centroresultquinz.Image")));
            this.bb_centroresultquinz.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_centroresultquinz.Location = new System.Drawing.Point(196, 270);
            this.bb_centroresultquinz.Name = "bb_centroresultquinz";
            this.bb_centroresultquinz.Size = new System.Drawing.Size(28, 19);
            this.bb_centroresultquinz.TabIndex = 19;
            this.bb_centroresultquinz.UseVisualStyleBackColor = true;
            this.bb_centroresultquinz.Click += new System.EventHandler(this.bb_centroresultquinz_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 399;
            this.label5.Text = "Centro Result. Quinz.:";
            // 
            // cd_centroresultquinz
            // 
            this.cd_centroresultquinz.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresultquinz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresultquinz.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresultquinz.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_centroresultquinz", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresultquinz.Enabled = false;
            this.cd_centroresultquinz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_centroresultquinz.Location = new System.Drawing.Point(126, 270);
            this.cd_centroresultquinz.Name = "cd_centroresultquinz";
            this.cd_centroresultquinz.NM_Alias = "a";
            this.cd_centroresultquinz.NM_Campo = "cd_centroresult";
            this.cd_centroresultquinz.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresultquinz.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.cd_centroresultquinz.QTD_Zero = 0;
            this.cd_centroresultquinz.Size = new System.Drawing.Size(67, 20);
            this.cd_centroresultquinz.ST_AutoInc = false;
            this.cd_centroresultquinz.ST_DisableAuto = false;
            this.cd_centroresultquinz.ST_Float = false;
            this.cd_centroresultquinz.ST_Gravar = true;
            this.cd_centroresultquinz.ST_Int = true;
            this.cd_centroresultquinz.ST_LimpaCampo = true;
            this.cd_centroresultquinz.ST_NotNull = false;
            this.cd_centroresultquinz.ST_PrimaryKey = false;
            this.cd_centroresultquinz.TabIndex = 18;
            this.cd_centroresultquinz.TextOld = null;
            this.cd_centroresultquinz.Leave += new System.EventHandler(this.cd_centroresultquinz_Leave);
            // 
            // ds_centroresultmes
            // 
            this.ds_centroresultmes.BackColor = System.Drawing.SystemColors.Window;
            this.ds_centroresultmes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_centroresultmes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_centroresultmes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_centroresultmes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_centroresultmes.Enabled = false;
            this.ds_centroresultmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_centroresultmes.Location = new System.Drawing.Point(229, 296);
            this.ds_centroresultmes.Name = "ds_centroresultmes";
            this.ds_centroresultmes.NM_Alias = "a";
            this.ds_centroresultmes.NM_Campo = "DS_CentroResultado";
            this.ds_centroresultmes.NM_CampoBusca = "DS_CentroResultado";
            this.ds_centroresultmes.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_centroresultmes.QTD_Zero = 0;
            this.ds_centroresultmes.ReadOnly = true;
            this.ds_centroresultmes.Size = new System.Drawing.Size(441, 20);
            this.ds_centroresultmes.ST_AutoInc = false;
            this.ds_centroresultmes.ST_DisableAuto = false;
            this.ds_centroresultmes.ST_Float = false;
            this.ds_centroresultmes.ST_Gravar = false;
            this.ds_centroresultmes.ST_Int = false;
            this.ds_centroresultmes.ST_LimpaCampo = true;
            this.ds_centroresultmes.ST_NotNull = false;
            this.ds_centroresultmes.ST_PrimaryKey = false;
            this.ds_centroresultmes.TabIndex = 404;
            this.ds_centroresultmes.TextOld = null;
            // 
            // bb_centroresultmes
            // 
            this.bb_centroresultmes.Enabled = false;
            this.bb_centroresultmes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_centroresultmes.Image = ((System.Drawing.Image)(resources.GetObject("bb_centroresultmes.Image")));
            this.bb_centroresultmes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_centroresultmes.Location = new System.Drawing.Point(196, 296);
            this.bb_centroresultmes.Name = "bb_centroresultmes";
            this.bb_centroresultmes.Size = new System.Drawing.Size(28, 19);
            this.bb_centroresultmes.TabIndex = 21;
            this.bb_centroresultmes.UseVisualStyleBackColor = true;
            this.bb_centroresultmes.Click += new System.EventHandler(this.bb_centroresultmes_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(20, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 403;
            this.label6.Text = "Centro Result. Mês:";
            // 
            // cd_centroresultmes
            // 
            this.cd_centroresultmes.BackColor = System.Drawing.SystemColors.Window;
            this.cd_centroresultmes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_centroresultmes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_centroresultmes.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Cd_centroresultmes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_centroresultmes.Enabled = false;
            this.cd_centroresultmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_centroresultmes.Location = new System.Drawing.Point(126, 296);
            this.cd_centroresultmes.Name = "cd_centroresultmes";
            this.cd_centroresultmes.NM_Alias = "a";
            this.cd_centroresultmes.NM_Campo = "cd_centroresult";
            this.cd_centroresultmes.NM_CampoBusca = "cd_centroresult";
            this.cd_centroresultmes.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.cd_centroresultmes.QTD_Zero = 0;
            this.cd_centroresultmes.Size = new System.Drawing.Size(67, 20);
            this.cd_centroresultmes.ST_AutoInc = false;
            this.cd_centroresultmes.ST_DisableAuto = false;
            this.cd_centroresultmes.ST_Float = false;
            this.cd_centroresultmes.ST_Gravar = true;
            this.cd_centroresultmes.ST_Int = true;
            this.cd_centroresultmes.ST_LimpaCampo = true;
            this.cd_centroresultmes.ST_NotNull = false;
            this.cd_centroresultmes.ST_PrimaryKey = false;
            this.cd_centroresultmes.TabIndex = 20;
            this.cd_centroresultmes.TextOld = null;
            this.cd_centroresultmes.Leave += new System.EventHandler(this.cd_centroresultmes_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(36, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 405;
            this.label1.Text = "Nº Seq. Recibo:";
            // 
            // nr_seqrecibo
            // 
            this.nr_seqrecibo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCFGLocacao, "Nr_seqrecibo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_seqrecibo.Enabled = false;
            this.nr_seqrecibo.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nr_seqrecibo.Location = new System.Drawing.Point(126, 322);
            this.nr_seqrecibo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nr_seqrecibo.Name = "nr_seqrecibo";
            this.nr_seqrecibo.NM_Alias = "";
            this.nr_seqrecibo.NM_Campo = "";
            this.nr_seqrecibo.NM_Param = "";
            this.nr_seqrecibo.Operador = "";
            this.nr_seqrecibo.Size = new System.Drawing.Size(98, 20);
            this.nr_seqrecibo.ST_AutoInc = false;
            this.nr_seqrecibo.ST_DisableAuto = false;
            this.nr_seqrecibo.ST_Gravar = true;
            this.nr_seqrecibo.ST_LimparCampo = true;
            this.nr_seqrecibo.ST_NotNull = false;
            this.nr_seqrecibo.ST_PrimaryKey = false;
            this.nr_seqrecibo.TabIndex = 22;
            this.nr_seqrecibo.ThousandsSeparator = true;
            this.nr_seqrecibo.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ds_tpprodcombustivel
            // 
            this.ds_tpprodcombustivel.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpprodcombustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpprodcombustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpprodcombustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tpprodcombustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tpprodcombustivel.Enabled = false;
            this.ds_tpprodcombustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_tpprodcombustivel.Location = new System.Drawing.Point(391, 322);
            this.ds_tpprodcombustivel.Name = "ds_tpprodcombustivel";
            this.ds_tpprodcombustivel.NM_Alias = "a";
            this.ds_tpprodcombustivel.NM_Campo = "ds_tpproduto";
            this.ds_tpprodcombustivel.NM_CampoBusca = "ds_tpproduto";
            this.ds_tpprodcombustivel.NM_Param = "@P_DS_CONTAGER_BOLETO_AUTO";
            this.ds_tpprodcombustivel.QTD_Zero = 0;
            this.ds_tpprodcombustivel.ReadOnly = true;
            this.ds_tpprodcombustivel.Size = new System.Drawing.Size(280, 20);
            this.ds_tpprodcombustivel.ST_AutoInc = false;
            this.ds_tpprodcombustivel.ST_DisableAuto = false;
            this.ds_tpprodcombustivel.ST_Float = false;
            this.ds_tpprodcombustivel.ST_Gravar = false;
            this.ds_tpprodcombustivel.ST_Int = false;
            this.ds_tpprodcombustivel.ST_LimpaCampo = true;
            this.ds_tpprodcombustivel.ST_NotNull = false;
            this.ds_tpprodcombustivel.ST_PrimaryKey = false;
            this.ds_tpprodcombustivel.TabIndex = 409;
            this.ds_tpprodcombustivel.TextOld = null;
            // 
            // bb_tpprodcombustivel
            // 
            this.bb_tpprodcombustivel.Enabled = false;
            this.bb_tpprodcombustivel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_tpprodcombustivel.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpprodcombustivel.Image")));
            this.bb_tpprodcombustivel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpprodcombustivel.Location = new System.Drawing.Point(358, 322);
            this.bb_tpprodcombustivel.Name = "bb_tpprodcombustivel";
            this.bb_tpprodcombustivel.Size = new System.Drawing.Size(28, 19);
            this.bb_tpprodcombustivel.TabIndex = 407;
            this.bb_tpprodcombustivel.UseVisualStyleBackColor = true;
            this.bb_tpprodcombustivel.Click += new System.EventHandler(this.bb_tpprodcombustivel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(230, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 408;
            this.label7.Text = "TP. Combustivel:";
            // 
            // tp_prodcombustivel
            // 
            this.tp_prodcombustivel.BackColor = System.Drawing.SystemColors.Window;
            this.tp_prodcombustivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_prodcombustivel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_prodcombustivel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Tp_prodcombustivel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_prodcombustivel.Enabled = false;
            this.tp_prodcombustivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tp_prodcombustivel.Location = new System.Drawing.Point(323, 322);
            this.tp_prodcombustivel.Name = "tp_prodcombustivel";
            this.tp_prodcombustivel.NM_Alias = "a";
            this.tp_prodcombustivel.NM_Campo = "tp_produto";
            this.tp_prodcombustivel.NM_CampoBusca = "tp_produto";
            this.tp_prodcombustivel.NM_Param = "@P_CD_CONTAGER_BOLETOAUTO";
            this.tp_prodcombustivel.QTD_Zero = 0;
            this.tp_prodcombustivel.Size = new System.Drawing.Size(33, 20);
            this.tp_prodcombustivel.ST_AutoInc = false;
            this.tp_prodcombustivel.ST_DisableAuto = false;
            this.tp_prodcombustivel.ST_Float = false;
            this.tp_prodcombustivel.ST_Gravar = true;
            this.tp_prodcombustivel.ST_Int = true;
            this.tp_prodcombustivel.ST_LimpaCampo = true;
            this.tp_prodcombustivel.ST_NotNull = false;
            this.tp_prodcombustivel.ST_PrimaryKey = false;
            this.tp_prodcombustivel.TabIndex = 406;
            this.tp_prodcombustivel.TextOld = null;
            this.tp_prodcombustivel.Leave += new System.EventHandler(this.tp_prodcombustivel_Leave);
            // 
            // checkBoxDefault1
            // 
            this.checkBoxDefault1.AutoSize = true;
            this.checkBoxDefault1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCFGLocacao, "St_HoraAuto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxDefault1.Enabled = false;
            this.checkBoxDefault1.Location = new System.Drawing.Point(126, 345);
            this.checkBoxDefault1.Name = "checkBoxDefault1";
            this.checkBoxDefault1.NM_Alias = "";
            this.checkBoxDefault1.NM_Campo = "";
            this.checkBoxDefault1.NM_Param = "";
            this.checkBoxDefault1.Size = new System.Drawing.Size(107, 17);
            this.checkBoxDefault1.ST_Gravar = true;
            this.checkBoxDefault1.ST_LimparCampo = true;
            this.checkBoxDefault1.ST_NotNull = false;
            this.checkBoxDefault1.TabIndex = 411;
            this.checkBoxDefault1.Text = "Status Hora Auto";
            this.checkBoxDefault1.UseVisualStyleBackColor = true;
            this.checkBoxDefault1.Vl_False = "";
            this.checkBoxDefault1.Vl_True = "";
            // 
            // tp_ordemp
            // 
            this.tp_ordemp.BackColor = System.Drawing.SystemColors.Window;
            this.tp_ordemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_ordemp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_ordemp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Tp_ordemp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_ordemp.Enabled = false;
            this.tp_ordemp.Location = new System.Drawing.Point(126, 64);
            this.tp_ordemp.Name = "tp_ordemp";
            this.tp_ordemp.NM_Alias = "a";
            this.tp_ordemp.NM_Campo = "tp_ordem";
            this.tp_ordemp.NM_CampoBusca = "tp_ordem";
            this.tp_ordemp.NM_Param = "@P_CD_TABELAPRECO";
            this.tp_ordemp.QTD_Zero = 0;
            this.tp_ordemp.Size = new System.Drawing.Size(67, 20);
            this.tp_ordemp.ST_AutoInc = false;
            this.tp_ordemp.ST_DisableAuto = false;
            this.tp_ordemp.ST_Float = false;
            this.tp_ordemp.ST_Gravar = true;
            this.tp_ordemp.ST_Int = true;
            this.tp_ordemp.ST_LimpaCampo = true;
            this.tp_ordemp.ST_NotNull = true;
            this.tp_ordemp.ST_PrimaryKey = true;
            this.tp_ordemp.TabIndex = 412;
            this.tp_ordemp.TextOld = null;
            // 
            // ds_tipoordemp
            // 
            this.ds_tipoordemp.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tipoordemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tipoordemp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tipoordemp.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCFGLocacao, "Ds_tipoordemP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_tipoordemp.Enabled = false;
            this.ds_tipoordemp.Location = new System.Drawing.Point(229, 65);
            this.ds_tipoordemp.Name = "ds_tipoordemp";
            this.ds_tipoordemp.NM_Alias = "b";
            this.ds_tipoordemp.NM_Campo = "ds_tipoordem";
            this.ds_tipoordemp.NM_CampoBusca = "ds_tipoordem";
            this.ds_tipoordemp.NM_Param = "@P_DS_TABELAPRECO";
            this.ds_tipoordemp.QTD_Zero = 0;
            this.ds_tipoordemp.Size = new System.Drawing.Size(441, 20);
            this.ds_tipoordemp.ST_AutoInc = false;
            this.ds_tipoordemp.ST_DisableAuto = false;
            this.ds_tipoordemp.ST_Float = false;
            this.ds_tipoordemp.ST_Gravar = false;
            this.ds_tipoordemp.ST_Int = false;
            this.ds_tipoordemp.ST_LimpaCampo = true;
            this.ds_tipoordemp.ST_NotNull = false;
            this.ds_tipoordemp.ST_PrimaryKey = false;
            this.ds_tipoordemp.TabIndex = 415;
            this.ds_tipoordemp.TextOld = null;
            // 
            // BB_Tp_Ordemp
            // 
            this.BB_Tp_Ordemp.Enabled = false;
            this.BB_Tp_Ordemp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_Tp_Ordemp.Image = ((System.Drawing.Image)(resources.GetObject("BB_Tp_Ordemp.Image")));
            this.BB_Tp_Ordemp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Tp_Ordemp.Location = new System.Drawing.Point(196, 65);
            this.BB_Tp_Ordemp.Name = "BB_Tp_Ordemp";
            this.BB_Tp_Ordemp.Size = new System.Drawing.Size(28, 19);
            this.BB_Tp_Ordemp.TabIndex = 413;
            this.BB_Tp_Ordemp.UseVisualStyleBackColor = true;
            this.BB_Tp_Ordemp.Click += new System.EventHandler(this.BB_Tp_Ordemp_Click);
            // 
            // TFCFGLocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 491);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCFGLocacao";
            this.Text = "Configuração - Locação";
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsCFGLocacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gCfg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_seqrecibo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault tp_ordem;
        private Componentes.EditDefault ds_tipoordem;
        public System.Windows.Forms.Button bb_ordem;
        private Componentes.DataGridDefault gCfg;
        private System.Windows.Forms.BindingSource bsCFGLocacao;
        private Componentes.EditDefault tp_duplicata;
        private Componentes.EditDefault ds_tpduplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        private Componentes.EditDefault tp_docto;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_tpdocto;
        private Componentes.EditDefault cd_historico;
        private Componentes.EditDefault ds_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault Cd_PedidoServico;
        private Componentes.EditDefault Ds_PedidoServico;
        public System.Windows.Forms.Button bb_PedidoServico;
        private Componentes.EditDefault ds_config;
        public System.Windows.Forms.Button bb_config;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault id_config;
        private Componentes.EditDefault ds_centroresultmes;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault cd_centroresultmes;
        private Componentes.EditDefault ds_centroresultquinz;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault cd_centroresultquinz;
        private Componentes.EditDefault ds_centroresultsem;
        public System.Windows.Forms.Button bb_centroresultsem;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_centroresultsem;
        private Componentes.EditDefault ds_centroresultdia;
        public System.Windows.Forms.Button bb_centroresultdia;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault cd_centroresultdia;
        private System.Windows.Forms.Button bb_centroresultquinz;
        private System.Windows.Forms.Button bb_centroresultmes;
        private Componentes.EditFloat nr_seqrecibo;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_tpprodcombustivel;
        private System.Windows.Forms.Button bb_tpprodcombustivel;
        private System.Windows.Forms.Label label7;
        private Componentes.EditDefault tp_prodcombustivel;
        private Componentes.CheckBoxDefault checkBoxDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dstipoordemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn St_HoraAuto;
        private Componentes.EditDefault tp_ordemp;
        private Componentes.EditDefault ds_tipoordemp;
        public System.Windows.Forms.Button BB_Tp_Ordemp;
    }
}