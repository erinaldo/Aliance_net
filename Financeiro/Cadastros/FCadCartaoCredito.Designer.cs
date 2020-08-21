namespace Financeiro.Cadastros
{
    partial class TFCadCartaoCredito
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCadCartaoCredito));
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.idcartaostrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nRCartaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCJuroComprasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCJuroSaquesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtvalidadestrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTRegistroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsCartaoCredito = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ID_Cartao = new Componentes.EditDefault(this.components);
            this.ID_Bandeira = new Componentes.EditDefault(this.components);
            this.NR_Cartao = new Componentes.EditDefault(this.components);
            this.DS_Bandeira = new Componentes.EditDefault(this.components);
            this.bb_bandeira = new System.Windows.Forms.Button();
            this.DT_Validade = new Componentes.EditData(this.components);
            this.PC_JuroCompras = new Componentes.EditFloat(this.components);
            this.PC_JuroSaques = new Componentes.EditFloat(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ST_Registrobool = new Componentes.CheckBoxDefault(this.components);
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.bb_Usuario = new System.Windows.Forms.Button();
            this.NomeUsuario = new Componentes.EditDefault(this.components);
            this.ds_cartao = new Componentes.EditDefault(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.ST_PrePago = new Componentes.CheckBoxDefault(this.components);
            this.pDados.SuspendLayout();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaoCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroSaques)).BeginInit();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.ST_PrePago);
            this.pDados.Controls.Add(this.ds_cartao);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.NomeUsuario);
            this.pDados.Controls.Add(this.bb_Usuario);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.DS_Observacao);
            this.pDados.Controls.Add(this.panelDados1);
            this.pDados.Controls.Add(this.PC_JuroSaques);
            this.pDados.Controls.Add(this.PC_JuroCompras);
            this.pDados.Controls.Add(this.DT_Validade);
            this.pDados.Controls.Add(this.bb_bandeira);
            this.pDados.Controls.Add(this.DS_Bandeira);
            this.pDados.Controls.Add(this.NR_Cartao);
            this.pDados.Controls.Add(this.ID_Bandeira);
            this.pDados.Controls.Add(this.ID_Cartao);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pDados.Size = new System.Drawing.Size(562, 240);
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(574, 444);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.dataGridDefault1);
            this.tpPadrao.Size = new System.Drawing.Size(566, 418);
            this.tpPadrao.Controls.SetChildIndex(this.pDados, 0);
            this.tpPadrao.Controls.SetChildIndex(this.dataGridDefault1, 0);
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcartaostrDataGridViewTextBoxColumn,
            this.nRCartaoDataGridViewTextBoxColumn,
            this.nomeUsuarioDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.pCJuroComprasDataGridViewTextBoxColumn,
            this.pCJuroSaquesDataGridViewTextBoxColumn,
            this.dtvalidadestrDataGridViewTextBoxColumn,
            this.sTRegistroDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2});
            this.dataGridDefault1.DataSource = this.bsCartaoCredito;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridDefault1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 240);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(562, 174);
            this.dataGridDefault1.TabIndex = 1;
            // 
            // idcartaostrDataGridViewTextBoxColumn
            // 
            this.idcartaostrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.idcartaostrDataGridViewTextBoxColumn.DataPropertyName = "Id_cartaostr";
            this.idcartaostrDataGridViewTextBoxColumn.HeaderText = "Cód. Cartão";
            this.idcartaostrDataGridViewTextBoxColumn.Name = "idcartaostrDataGridViewTextBoxColumn";
            this.idcartaostrDataGridViewTextBoxColumn.ReadOnly = true;
            this.idcartaostrDataGridViewTextBoxColumn.Width = 81;
            // 
            // nRCartaoDataGridViewTextBoxColumn
            // 
            this.nRCartaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nRCartaoDataGridViewTextBoxColumn.DataPropertyName = "NR_Cartao";
            this.nRCartaoDataGridViewTextBoxColumn.HeaderText = "Número Cartão";
            this.nRCartaoDataGridViewTextBoxColumn.Name = "nRCartaoDataGridViewTextBoxColumn";
            this.nRCartaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nRCartaoDataGridViewTextBoxColumn.Width = 95;
            // 
            // nomeUsuarioDataGridViewTextBoxColumn
            // 
            this.nomeUsuarioDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomeUsuarioDataGridViewTextBoxColumn.DataPropertyName = "NomeUsuario";
            this.nomeUsuarioDataGridViewTextBoxColumn.HeaderText = "Nome Usuário";
            this.nomeUsuarioDataGridViewTextBoxColumn.Name = "nomeUsuarioDataGridViewTextBoxColumn";
            this.nomeUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeUsuarioDataGridViewTextBoxColumn.Width = 91;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Ds_bandeira";
            this.dataGridViewTextBoxColumn1.HeaderText = "Bandeira";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 74;
            // 
            // pCJuroComprasDataGridViewTextBoxColumn
            // 
            this.pCJuroComprasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pCJuroComprasDataGridViewTextBoxColumn.DataPropertyName = "PC_JuroCompras";
            this.pCJuroComprasDataGridViewTextBoxColumn.HeaderText = "% Juro Compra";
            this.pCJuroComprasDataGridViewTextBoxColumn.Name = "pCJuroComprasDataGridViewTextBoxColumn";
            this.pCJuroComprasDataGridViewTextBoxColumn.ReadOnly = true;
            this.pCJuroComprasDataGridViewTextBoxColumn.Width = 94;
            // 
            // pCJuroSaquesDataGridViewTextBoxColumn
            // 
            this.pCJuroSaquesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.pCJuroSaquesDataGridViewTextBoxColumn.DataPropertyName = "PC_JuroSaques";
            this.pCJuroSaquesDataGridViewTextBoxColumn.HeaderText = "% Juro Saque";
            this.pCJuroSaquesDataGridViewTextBoxColumn.Name = "pCJuroSaquesDataGridViewTextBoxColumn";
            this.pCJuroSaquesDataGridViewTextBoxColumn.ReadOnly = true;
            this.pCJuroSaquesDataGridViewTextBoxColumn.Width = 89;
            // 
            // dtvalidadestrDataGridViewTextBoxColumn
            // 
            this.dtvalidadestrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dtvalidadestrDataGridViewTextBoxColumn.DataPropertyName = "Dt_validadestr";
            this.dtvalidadestrDataGridViewTextBoxColumn.HeaderText = "Data Validade";
            this.dtvalidadestrDataGridViewTextBoxColumn.Name = "dtvalidadestrDataGridViewTextBoxColumn";
            this.dtvalidadestrDataGridViewTextBoxColumn.ReadOnly = true;
            this.dtvalidadestrDataGridViewTextBoxColumn.Width = 91;
            // 
            // sTRegistroDataGridViewTextBoxColumn
            // 
            this.sTRegistroDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sTRegistroDataGridViewTextBoxColumn.DataPropertyName = "ST_Registro";
            this.sTRegistroDataGridViewTextBoxColumn.HeaderText = "Status";
            this.sTRegistroDataGridViewTextBoxColumn.Name = "sTRegistroDataGridViewTextBoxColumn";
            this.sTRegistroDataGridViewTextBoxColumn.ReadOnly = true;
            this.sTRegistroDataGridViewTextBoxColumn.Width = 62;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DS_Observacao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Observação";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // bsCartaoCredito
            // 
            this.bsCartaoCredito.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadCartaoCredito);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cód. Cartão:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bandeira:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Núm. Cartão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Validade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "% Juro Compras:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(189, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "% Juro Saques:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Observação:";
            // 
            // ID_Cartao
            // 
            this.ID_Cartao.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Cartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Cartao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "Id_cartaostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Cartao.Enabled = false;
            this.ID_Cartao.Location = new System.Drawing.Point(106, 15);
            this.ID_Cartao.Name = "ID_Cartao";
            this.ID_Cartao.NM_Alias = "";
            this.ID_Cartao.NM_Campo = "";
            this.ID_Cartao.NM_CampoBusca = "";
            this.ID_Cartao.NM_Param = "";
            this.ID_Cartao.QTD_Zero = 0;
            this.ID_Cartao.Size = new System.Drawing.Size(61, 20);
            this.ID_Cartao.ST_AutoInc = true;
            this.ID_Cartao.ST_DisableAuto = true;
            this.ID_Cartao.ST_Float = false;
            this.ID_Cartao.ST_Gravar = true;
            this.ID_Cartao.ST_Int = true;
            this.ID_Cartao.ST_LimpaCampo = false;
            this.ID_Cartao.ST_NotNull = true;
            this.ID_Cartao.ST_PrimaryKey = true;
            this.ID_Cartao.TabIndex = 0;
            this.ID_Cartao.TextOld = null;
            // 
            // ID_Bandeira
            // 
            this.ID_Bandeira.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Bandeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Bandeira.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Bandeira.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "Id_bandeirastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Bandeira.Enabled = false;
            this.ID_Bandeira.Location = new System.Drawing.Point(106, 40);
            this.ID_Bandeira.Name = "ID_Bandeira";
            this.ID_Bandeira.NM_Alias = "";
            this.ID_Bandeira.NM_Campo = "ID_Bandeira";
            this.ID_Bandeira.NM_CampoBusca = "ID_Bandeira";
            this.ID_Bandeira.NM_Param = "@P_ID_BANDEIRA";
            this.ID_Bandeira.QTD_Zero = 0;
            this.ID_Bandeira.Size = new System.Drawing.Size(62, 20);
            this.ID_Bandeira.ST_AutoInc = false;
            this.ID_Bandeira.ST_DisableAuto = true;
            this.ID_Bandeira.ST_Float = false;
            this.ID_Bandeira.ST_Gravar = true;
            this.ID_Bandeira.ST_Int = true;
            this.ID_Bandeira.ST_LimpaCampo = true;
            this.ID_Bandeira.ST_NotNull = true;
            this.ID_Bandeira.ST_PrimaryKey = false;
            this.ID_Bandeira.TabIndex = 2;
            this.ID_Bandeira.TextOld = null;
            this.ID_Bandeira.Leave += new System.EventHandler(this.ID_Bandeira_Leave);
            // 
            // NR_Cartao
            // 
            this.NR_Cartao.BackColor = System.Drawing.SystemColors.Window;
            this.NR_Cartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NR_Cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NR_Cartao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "NR_Cartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NR_Cartao.Enabled = false;
            this.NR_Cartao.Location = new System.Drawing.Point(106, 92);
            this.NR_Cartao.Name = "NR_Cartao";
            this.NR_Cartao.NM_Alias = "";
            this.NR_Cartao.NM_Campo = "";
            this.NR_Cartao.NM_CampoBusca = "";
            this.NR_Cartao.NM_Param = "";
            this.NR_Cartao.QTD_Zero = 0;
            this.NR_Cartao.Size = new System.Drawing.Size(176, 20);
            this.NR_Cartao.ST_AutoInc = false;
            this.NR_Cartao.ST_DisableAuto = true;
            this.NR_Cartao.ST_Float = false;
            this.NR_Cartao.ST_Gravar = true;
            this.NR_Cartao.ST_Int = false;
            this.NR_Cartao.ST_LimpaCampo = true;
            this.NR_Cartao.ST_NotNull = false;
            this.NR_Cartao.ST_PrimaryKey = false;
            this.NR_Cartao.TabIndex = 5;
            this.NR_Cartao.TextOld = null;
            // 
            // DS_Bandeira
            // 
            this.DS_Bandeira.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Bandeira.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Bandeira.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Bandeira.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "Ds_bandeira", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Bandeira.Enabled = false;
            this.DS_Bandeira.Location = new System.Drawing.Point(201, 40);
            this.DS_Bandeira.Name = "DS_Bandeira";
            this.DS_Bandeira.NM_Alias = "";
            this.DS_Bandeira.NM_Campo = "DS_Bandeira";
            this.DS_Bandeira.NM_CampoBusca = "DS_Bandeira";
            this.DS_Bandeira.NM_Param = "@P_DS_BANDEIRA";
            this.DS_Bandeira.QTD_Zero = 0;
            this.DS_Bandeira.Size = new System.Drawing.Size(343, 20);
            this.DS_Bandeira.ST_AutoInc = false;
            this.DS_Bandeira.ST_DisableAuto = false;
            this.DS_Bandeira.ST_Float = false;
            this.DS_Bandeira.ST_Gravar = false;
            this.DS_Bandeira.ST_Int = false;
            this.DS_Bandeira.ST_LimpaCampo = true;
            this.DS_Bandeira.ST_NotNull = false;
            this.DS_Bandeira.ST_PrimaryKey = false;
            this.DS_Bandeira.TabIndex = 11;
            this.DS_Bandeira.TextOld = null;
            // 
            // bb_bandeira
            // 
            this.bb_bandeira.Enabled = false;
            this.bb_bandeira.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_bandeira.Image = ((System.Drawing.Image)(resources.GetObject("bb_bandeira.Image")));
            this.bb_bandeira.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_bandeira.Location = new System.Drawing.Point(170, 40);
            this.bb_bandeira.Name = "bb_bandeira";
            this.bb_bandeira.Size = new System.Drawing.Size(30, 20);
            this.bb_bandeira.TabIndex = 3;
            this.bb_bandeira.UseVisualStyleBackColor = true;
            this.bb_bandeira.Click += new System.EventHandler(this.bb_bandeira_Click);
            // 
            // DT_Validade
            // 
            this.DT_Validade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Validade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "Dt_validadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Validade.Enabled = false;
            this.DT_Validade.Location = new System.Drawing.Point(354, 92);
            this.DT_Validade.Mask = "00/00/0000";
            this.DT_Validade.Name = "DT_Validade";
            this.DT_Validade.NM_Alias = "";
            this.DT_Validade.NM_Campo = "";
            this.DT_Validade.NM_CampoBusca = "";
            this.DT_Validade.NM_Param = "";
            this.DT_Validade.Operador = "";
            this.DT_Validade.Size = new System.Drawing.Size(84, 20);
            this.DT_Validade.ST_Gravar = true;
            this.DT_Validade.ST_LimpaCampo = true;
            this.DT_Validade.ST_NotNull = false;
            this.DT_Validade.ST_PrimaryKey = false;
            this.DT_Validade.TabIndex = 6;
            // 
            // PC_JuroCompras
            // 
            this.PC_JuroCompras.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartaoCredito, "PC_JuroCompras", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_JuroCompras.DecimalPlaces = 2;
            this.PC_JuroCompras.Enabled = false;
            this.PC_JuroCompras.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PC_JuroCompras.Location = new System.Drawing.Point(106, 144);
            this.PC_JuroCompras.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.PC_JuroCompras.Name = "PC_JuroCompras";
            this.PC_JuroCompras.NM_Alias = "";
            this.PC_JuroCompras.NM_Campo = "";
            this.PC_JuroCompras.NM_Param = "";
            this.PC_JuroCompras.Operador = "";
            this.PC_JuroCompras.Size = new System.Drawing.Size(81, 20);
            this.PC_JuroCompras.ST_AutoInc = false;
            this.PC_JuroCompras.ST_DisableAuto = true;
            this.PC_JuroCompras.ST_Gravar = true;
            this.PC_JuroCompras.ST_LimparCampo = true;
            this.PC_JuroCompras.ST_NotNull = false;
            this.PC_JuroCompras.ST_PrimaryKey = false;
            this.PC_JuroCompras.TabIndex = 9;
            this.PC_JuroCompras.ThousandsSeparator = true;
            // 
            // PC_JuroSaques
            // 
            this.PC_JuroSaques.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsCartaoCredito, "PC_JuroSaques", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PC_JuroSaques.DecimalPlaces = 2;
            this.PC_JuroSaques.Enabled = false;
            this.PC_JuroSaques.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PC_JuroSaques.Location = new System.Drawing.Point(284, 144);
            this.PC_JuroSaques.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.PC_JuroSaques.Name = "PC_JuroSaques";
            this.PC_JuroSaques.NM_Alias = "";
            this.PC_JuroSaques.NM_Campo = "";
            this.PC_JuroSaques.NM_Param = "";
            this.PC_JuroSaques.Operador = "";
            this.PC_JuroSaques.Size = new System.Drawing.Size(84, 20);
            this.PC_JuroSaques.ST_AutoInc = false;
            this.PC_JuroSaques.ST_DisableAuto = true;
            this.PC_JuroSaques.ST_Gravar = true;
            this.PC_JuroSaques.ST_LimparCampo = true;
            this.PC_JuroSaques.ST_NotNull = false;
            this.PC_JuroSaques.ST_PrimaryKey = false;
            this.PC_JuroSaques.TabIndex = 10;
            this.PC_JuroSaques.ThousandsSeparator = true;
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(199)))), ((int)(((byte)(212)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.ST_Registrobool);
            this.panelDados1.Location = new System.Drawing.Point(454, 92);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(89, 22);
            this.panelDados1.TabIndex = 7;
            // 
            // ST_Registrobool
            // 
            this.ST_Registrobool.AutoSize = true;
            this.ST_Registrobool.Checked = true;
            this.ST_Registrobool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ST_Registrobool.Cursor = System.Windows.Forms.Cursors.Default;
            this.ST_Registrobool.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCartaoCredito, "ST_Registrobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_Registrobool.Enabled = false;
            this.ST_Registrobool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_Registrobool.Location = new System.Drawing.Point(5, 2);
            this.ST_Registrobool.Name = "ST_Registrobool";
            this.ST_Registrobool.NM_Alias = "";
            this.ST_Registrobool.NM_Campo = "";
            this.ST_Registrobool.NM_Param = "";
            this.ST_Registrobool.Size = new System.Drawing.Size(55, 17);
            this.ST_Registrobool.ST_Gravar = true;
            this.ST_Registrobool.ST_LimparCampo = false;
            this.ST_Registrobool.ST_NotNull = false;
            this.ST_Registrobool.TabIndex = 0;
            this.ST_Registrobool.Text = "Ativo";
            this.ST_Registrobool.UseVisualStyleBackColor = false;
            this.ST_Registrobool.Vl_False = "";
            this.ST_Registrobool.Vl_True = "";
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Enabled = false;
            this.DS_Observacao.Location = new System.Drawing.Point(106, 171);
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "";
            this.DS_Observacao.NM_Campo = "";
            this.DS_Observacao.NM_CampoBusca = "";
            this.DS_Observacao.NM_Param = "";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DS_Observacao.Size = new System.Drawing.Size(438, 60);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = true;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 12;
            this.DS_Observacao.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Titulo Cartão:";
            // 
            // bb_Usuario
            // 
            this.bb_Usuario.Enabled = false;
            this.bb_Usuario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bb_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("bb_Usuario.Image")));
            this.bb_Usuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_Usuario.Location = new System.Drawing.Point(513, 118);
            this.bb_Usuario.Name = "bb_Usuario";
            this.bb_Usuario.Size = new System.Drawing.Size(30, 20);
            this.bb_Usuario.TabIndex = 6;
            this.bb_Usuario.UseVisualStyleBackColor = true;
            this.bb_Usuario.Click += new System.EventHandler(this.bb_Usuario_Click);
            // 
            // NomeUsuario
            // 
            this.NomeUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.NomeUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NomeUsuario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "NomeUsuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NomeUsuario.Enabled = false;
            this.NomeUsuario.Location = new System.Drawing.Point(106, 118);
            this.NomeUsuario.Name = "NomeUsuario";
            this.NomeUsuario.NM_Alias = "";
            this.NomeUsuario.NM_Campo = "NM_Clifor";
            this.NomeUsuario.NM_CampoBusca = "NM_Clifor";
            this.NomeUsuario.NM_Param = "@P_NOMEUSUARIO";
            this.NomeUsuario.QTD_Zero = 0;
            this.NomeUsuario.Size = new System.Drawing.Size(406, 20);
            this.NomeUsuario.ST_AutoInc = false;
            this.NomeUsuario.ST_DisableAuto = true;
            this.NomeUsuario.ST_Float = false;
            this.NomeUsuario.ST_Gravar = true;
            this.NomeUsuario.ST_Int = false;
            this.NomeUsuario.ST_LimpaCampo = true;
            this.NomeUsuario.ST_NotNull = false;
            this.NomeUsuario.ST_PrimaryKey = false;
            this.NomeUsuario.TabIndex = 8;
            this.NomeUsuario.TextOld = null;
            // 
            // ds_cartao
            // 
            this.ds_cartao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_cartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_cartao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_cartao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCartaoCredito, "Ds_cartao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_cartao.Enabled = false;
            this.ds_cartao.Location = new System.Drawing.Point(106, 66);
            this.ds_cartao.Name = "ds_cartao";
            this.ds_cartao.NM_Alias = "";
            this.ds_cartao.NM_Campo = "";
            this.ds_cartao.NM_CampoBusca = "";
            this.ds_cartao.NM_Param = "";
            this.ds_cartao.QTD_Zero = 0;
            this.ds_cartao.Size = new System.Drawing.Size(438, 20);
            this.ds_cartao.ST_AutoInc = false;
            this.ds_cartao.ST_DisableAuto = true;
            this.ds_cartao.ST_Float = false;
            this.ds_cartao.ST_Gravar = true;
            this.ds_cartao.ST_Int = false;
            this.ds_cartao.ST_LimpaCampo = true;
            this.ds_cartao.ST_NotNull = false;
            this.ds_cartao.ST_PrimaryKey = false;
            this.ds_cartao.TabIndex = 4;
            this.ds_cartao.TextOld = null;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Descrição:";
            // 
            // ST_PrePago
            // 
            this.ST_PrePago.AutoSize = true;
            this.ST_PrePago.Cursor = System.Windows.Forms.Cursors.Default;
            this.ST_PrePago.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsCartaoCredito, "ST_prepagobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_PrePago.Enabled = false;
            this.ST_PrePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ST_PrePago.Location = new System.Drawing.Point(388, 148);
            this.ST_PrePago.Name = "ST_PrePago";
            this.ST_PrePago.NM_Alias = "";
            this.ST_PrePago.NM_Campo = "";
            this.ST_PrePago.NM_Param = "";
            this.ST_PrePago.Size = new System.Drawing.Size(78, 17);
            this.ST_PrePago.ST_Gravar = true;
            this.ST_PrePago.ST_LimparCampo = false;
            this.ST_PrePago.ST_NotNull = false;
            this.ST_PrePago.TabIndex = 1;
            this.ST_PrePago.Text = "Pré-Pago";
            this.ST_PrePago.UseVisualStyleBackColor = false;
            this.ST_PrePago.Vl_False = "";
            this.ST_PrePago.Vl_True = "";
            // 
            // TFCadCartaoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(574, 487);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TFCadCartaoCredito";
            this.Text = "Cadastro de Cartão de Crédito";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFCadCartaoCredito_FormClosing);
            this.Load += new System.EventHandler(this.TFCadCartaoCredito_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCartaoCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_JuroSaques)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.BindingSource bsCartaoCredito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault NR_Cartao;
        private Componentes.EditDefault ID_Cartao;
        private Componentes.EditData DT_Validade;
        private System.Windows.Forms.Button bb_bandeira;
        private Componentes.EditFloat PC_JuroSaques;
        private Componentes.EditFloat PC_JuroCompras;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault DS_Observacao;
        private Componentes.CheckBoxDefault ST_Registrobool;
        private Componentes.EditDefault DS_Bandeira;
        private Componentes.EditDefault ID_Bandeira;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault NomeUsuario;
        private System.Windows.Forms.Button bb_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcartaostrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nRCartaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCJuroComprasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pCJuroSaquesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaVenctoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtvalidadestrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTRegistroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Componentes.EditDefault ds_cartao;
        private System.Windows.Forms.Label label11;
        private Componentes.CheckBoxDefault ST_PrePago;
    }
}
