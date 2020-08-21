namespace Faturamento
{
    partial class TFCargaAvulsa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCargaAvulsa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pDados = new Componentes.PanelDados(this.components);
            this.ds_rota = new Componentes.EditDefault(this.components);
            this.bsCarga = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.bb_rota = new System.Windows.Forms.Button();
            this.Id_rota = new Componentes.EditDefault(this.components);
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.placa = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_veiculo = new System.Windows.Forms.Button();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cd_motorista = new Componentes.EditDefault(this.components);
            this.nm_motorista = new Componentes.EditDefault(this.components);
            this.Dt_carga = new Componentes.EditData(this.components);
            this.bb_motorista = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.pProduto = new Componentes.PanelDados(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.dataGridDefault1 = new Componentes.DataGridDefault(this.components);
            this.cdprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsprodutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsItens = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bb_excluirItem = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarga)).BeginInit();
            this.pProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(825, 43);
            this.barraMenu.TabIndex = 10;
            // 
            // bb_inutilizar
            // 
            this.bb_inutilizar.AutoSize = false;
            this.bb_inutilizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_inutilizar.ForeColor = System.Drawing.Color.Green;
            this.bb_inutilizar.Image = ((System.Drawing.Image)(resources.GetObject("bb_inutilizar.Image")));
            this.bb_inutilizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_inutilizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_inutilizar.Name = "bb_inutilizar";
            this.bb_inutilizar.Size = new System.Drawing.Size(95, 40);
            this.bb_inutilizar.Text = "(F4)\r\nGravar";
            this.bb_inutilizar.ToolTipText = "Inutilizar NF-e";
            this.bb_inutilizar.Click += new System.EventHandler(this.bb_inutilizar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.AutoSize = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bb_cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(95, 40);
            this.bb_cancelar.Text = "(F6)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pDados, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pProduto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 472);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.ds_rota);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.bb_rota);
            this.pDados.Controls.Add(this.Id_rota);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_veiculo);
            this.pDados.Controls.Add(this.id_veiculo);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.cd_motorista);
            this.pDados.Controls.Add(this.nm_motorista);
            this.pDados.Controls.Add(this.Dt_carga);
            this.pDados.Controls.Add(this.bb_motorista);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(4, 4);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(817, 146);
            this.pDados.TabIndex = 0;
            // 
            // ds_rota
            // 
            this.ds_rota.BackColor = System.Drawing.SystemColors.Window;
            this.ds_rota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_rota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_rota.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Ds_rota", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_rota.Enabled = false;
            this.ds_rota.Location = new System.Drawing.Point(169, 81);
            this.ds_rota.Name = "ds_rota";
            this.ds_rota.NM_Alias = "";
            this.ds_rota.NM_Campo = "Rota";
            this.ds_rota.NM_CampoBusca = "ds_rota";
            this.ds_rota.NM_Param = "@P_DS_VEICULO";
            this.ds_rota.QTD_Zero = 0;
            this.ds_rota.Size = new System.Drawing.Size(634, 20);
            this.ds_rota.ST_AutoInc = false;
            this.ds_rota.ST_DisableAuto = false;
            this.ds_rota.ST_Float = false;
            this.ds_rota.ST_Gravar = false;
            this.ds_rota.ST_Int = false;
            this.ds_rota.ST_LimpaCampo = true;
            this.ds_rota.ST_NotNull = false;
            this.ds_rota.ST_PrimaryKey = false;
            this.ds_rota.TabIndex = 148;
            this.ds_rota.TextOld = null;
            // 
            // bsCarga
            // 
            this.bsCarga.DataSource = typeof(CamadaDados.Faturamento.Entrega.TList_CargaAvulsa);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 149;
            this.label6.Text = "Rota:";
            // 
            // bb_rota
            // 
            this.bb_rota.Image = ((System.Drawing.Image)(resources.GetObject("bb_rota.Image")));
            this.bb_rota.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_rota.Location = new System.Drawing.Point(140, 80);
            this.bb_rota.Name = "bb_rota";
            this.bb_rota.Size = new System.Drawing.Size(28, 20);
            this.bb_rota.TabIndex = 7;
            this.bb_rota.UseVisualStyleBackColor = true;
            this.bb_rota.Click += new System.EventHandler(this.bb_rota_Click);
            // 
            // Id_rota
            // 
            this.Id_rota.BackColor = System.Drawing.Color.White;
            this.Id_rota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Id_rota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Id_rota.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "ID_rotaString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Id_rota.Location = new System.Drawing.Point(67, 81);
            this.Id_rota.Name = "Id_rota";
            this.Id_rota.NM_Alias = "";
            this.Id_rota.NM_Campo = "Rota";
            this.Id_rota.NM_CampoBusca = "Id_rota";
            this.Id_rota.NM_Param = "@P_ID_VEICULO";
            this.Id_rota.QTD_Zero = 0;
            this.Id_rota.Size = new System.Drawing.Size(72, 20);
            this.Id_rota.ST_AutoInc = false;
            this.Id_rota.ST_DisableAuto = false;
            this.Id_rota.ST_Float = false;
            this.Id_rota.ST_Gravar = true;
            this.Id_rota.ST_Int = false;
            this.Id_rota.ST_LimpaCampo = true;
            this.Id_rota.ST_NotNull = false;
            this.Id_rota.ST_PrimaryKey = false;
            this.Id_rota.TabIndex = 6;
            this.Id_rota.TextOld = null;
            this.Id_rota.Leave += new System.EventHandler(this.Id_rota_Leave);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsCarga, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Nm_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(67, 3);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "Empresa";
            this.cbEmpresa.NM_Param = "@P_EMPRESA";
            this.cbEmpresa.Size = new System.Drawing.Size(736, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = true;
            this.cbEmpresa.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(10, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 145;
            this.label5.Text = "Empresa:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placa
            // 
            this.placa.BackColor = System.Drawing.SystemColors.Window;
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.placa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Placa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.placa.Enabled = false;
            this.placa.Location = new System.Drawing.Point(732, 58);
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "placa";
            this.placa.NM_CampoBusca = "placa";
            this.placa.NM_Param = "@P_DS_VEICULO";
            this.placa.QTD_Zero = 0;
            this.placa.Size = new System.Drawing.Size(71, 20);
            this.placa.ST_AutoInc = false;
            this.placa.ST_DisableAuto = false;
            this.placa.ST_Float = false;
            this.placa.ST_Gravar = false;
            this.placa.ST_Int = false;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = false;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 143;
            this.placa.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(689, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 142;
            this.label2.Text = "Placa:";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(169, 56);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "Ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "Ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_DS_VEICULO";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(498, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 140;
            this.ds_veiculo.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 141;
            this.label3.Text = "Veículo:";
            // 
            // bb_veiculo
            // 
            this.bb_veiculo.Image = ((System.Drawing.Image)(resources.GetObject("bb_veiculo.Image")));
            this.bb_veiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_veiculo.Location = new System.Drawing.Point(140, 55);
            this.bb_veiculo.Name = "bb_veiculo";
            this.bb_veiculo.Size = new System.Drawing.Size(28, 20);
            this.bb_veiculo.TabIndex = 5;
            this.bb_veiculo.UseVisualStyleBackColor = true;
            this.bb_veiculo.Click += new System.EventHandler(this.bb_veiculo_Click);
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.Color.White;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Location = new System.Drawing.Point(67, 56);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "Id_veiculo";
            this.id_veiculo.NM_CampoBusca = "Id_veiculo";
            this.id_veiculo.NM_Param = "@P_ID_VEICULO";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = false;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = false;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 4;
            this.id_veiculo.TextOld = null;
            this.id_veiculo.Leave += new System.EventHandler(this.id_veiculo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(673, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 137;
            this.label4.Text = "DT.Carga:";
            // 
            // cd_motorista
            // 
            this.cd_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.cd_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Cd_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_motorista.Location = new System.Drawing.Point(67, 30);
            this.cd_motorista.Name = "cd_motorista";
            this.cd_motorista.NM_Alias = "";
            this.cd_motorista.NM_Campo = "Motorista";
            this.cd_motorista.NM_CampoBusca = "cd_clifor";
            this.cd_motorista.NM_Param = "@P_DS_PDV";
            this.cd_motorista.QTD_Zero = 0;
            this.cd_motorista.Size = new System.Drawing.Size(72, 20);
            this.cd_motorista.ST_AutoInc = false;
            this.cd_motorista.ST_DisableAuto = false;
            this.cd_motorista.ST_Float = false;
            this.cd_motorista.ST_Gravar = false;
            this.cd_motorista.ST_Int = false;
            this.cd_motorista.ST_LimpaCampo = true;
            this.cd_motorista.ST_NotNull = false;
            this.cd_motorista.ST_PrimaryKey = false;
            this.cd_motorista.TabIndex = 1;
            this.cd_motorista.TextOld = null;
            this.cd_motorista.Leave += new System.EventHandler(this.cd_motorista_Leave);
            // 
            // nm_motorista
            // 
            this.nm_motorista.BackColor = System.Drawing.SystemColors.Window;
            this.nm_motorista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_motorista.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_motorista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Nm_motorista", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_motorista.Enabled = false;
            this.nm_motorista.Location = new System.Drawing.Point(169, 30);
            this.nm_motorista.Name = "nm_motorista";
            this.nm_motorista.NM_Alias = "";
            this.nm_motorista.NM_Campo = "nm_clifor";
            this.nm_motorista.NM_CampoBusca = "nm_clifor";
            this.nm_motorista.NM_Param = "@P_DS_PDV";
            this.nm_motorista.QTD_Zero = 0;
            this.nm_motorista.Size = new System.Drawing.Size(498, 20);
            this.nm_motorista.ST_AutoInc = false;
            this.nm_motorista.ST_DisableAuto = false;
            this.nm_motorista.ST_Float = false;
            this.nm_motorista.ST_Gravar = false;
            this.nm_motorista.ST_Int = false;
            this.nm_motorista.ST_LimpaCampo = true;
            this.nm_motorista.ST_NotNull = false;
            this.nm_motorista.ST_PrimaryKey = false;
            this.nm_motorista.TabIndex = 130;
            this.nm_motorista.TextOld = null;
            // 
            // Dt_carga
            // 
            this.Dt_carga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dt_carga.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Dt_cargastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Dt_carga.Location = new System.Drawing.Point(732, 30);
            this.Dt_carga.Mask = "00/00/0000";
            this.Dt_carga.Name = "Dt_carga";
            this.Dt_carga.NM_Alias = "";
            this.Dt_carga.NM_Campo = "DT.Carga";
            this.Dt_carga.NM_CampoBusca = "";
            this.Dt_carga.NM_Param = "";
            this.Dt_carga.Operador = "";
            this.Dt_carga.Size = new System.Drawing.Size(71, 20);
            this.Dt_carga.ST_Gravar = false;
            this.Dt_carga.ST_LimpaCampo = true;
            this.Dt_carga.ST_NotNull = true;
            this.Dt_carga.ST_PrimaryKey = false;
            this.Dt_carga.TabIndex = 3;
            // 
            // bb_motorista
            // 
            this.bb_motorista.Image = ((System.Drawing.Image)(resources.GetObject("bb_motorista.Image")));
            this.bb_motorista.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_motorista.Location = new System.Drawing.Point(140, 30);
            this.bb_motorista.Name = "bb_motorista";
            this.bb_motorista.Size = new System.Drawing.Size(28, 20);
            this.bb_motorista.TabIndex = 2;
            this.bb_motorista.UseVisualStyleBackColor = true;
            this.bb_motorista.Click += new System.EventHandler(this.bb_motorista_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 135;
            this.label1.Text = "Motorista:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 134;
            this.label11.Text = "Obs.:";
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsCarga, "Obs", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Location = new System.Drawing.Point(67, 106);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(736, 33);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = false;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 8;
            this.ds_observacao.TextOld = null;
            this.ds_observacao.Leave += new System.EventHandler(this.ds_observacao_Leave);
            // 
            // pProduto
            // 
            this.pProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pProduto.Controls.Add(this.Quantidade);
            this.pProduto.Controls.Add(this.label41);
            this.pProduto.Controls.Add(this.label40);
            this.pProduto.Controls.Add(this.cd_produto);
            this.pProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pProduto.Location = new System.Drawing.Point(4, 157);
            this.pProduto.Name = "pProduto";
            this.pProduto.NM_ProcDeletar = "";
            this.pProduto.NM_ProcGravar = "";
            this.pProduto.Size = new System.Drawing.Size(817, 34);
            this.pProduto.TabIndex = 1;
            // 
            // Quantidade
            // 
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantidade.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Quantidade.Location = new System.Drawing.Point(732, 5);
            this.Quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "";
            this.Quantidade.NM_Param = "";
            this.Quantidade.Operador = "";
            this.Quantidade.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Quantidade.Size = new System.Drawing.Size(71, 23);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = false;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = false;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 1;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quantidade_KeyDown);
            this.Quantidade.Leave += new System.EventHandler(this.Quantidade_Leave);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Cursor = System.Windows.Forms.Cursors.Default;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(650, 8);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(86, 17);
            this.label41.TabIndex = 67;
            this.label41.Text = "QTD. (F3) ";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(10, 6);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(113, 18);
            this.label40.TabIndex = 58;
            this.label40.Text = "Produto (F12)";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cd_produto.Location = new System.Drawing.Point(131, 3);
            this.cd_produto.Multiline = true;
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_PRODUTO";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(519, 25);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = false;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 0;
            this.cd_produto.TextOld = null;
            this.cd_produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cd_produto_KeyDown);
            this.cd_produto.Leave += new System.EventHandler(this.cd_produto_Leave);
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.dataGridDefault1);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 198);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(817, 270);
            this.panelDados1.TabIndex = 2;
            // 
            // dataGridDefault1
            // 
            this.dataGridDefault1.AllowUserToAddRows = false;
            this.dataGridDefault1.AllowUserToDeleteRows = false;
            this.dataGridDefault1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.dataGridDefault1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridDefault1.AutoGenerateColumns = false;
            this.dataGridDefault1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridDefault1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridDefault1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridDefault1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDefault1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cdprodutoDataGridViewTextBoxColumn,
            this.dsprodutoDataGridViewTextBoxColumn,
            this.quantidadeDataGridViewTextBoxColumn});
            this.dataGridDefault1.DataSource = this.bsItens;
            this.dataGridDefault1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDefault1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.dataGridDefault1.Location = new System.Drawing.Point(0, 0);
            this.dataGridDefault1.Name = "dataGridDefault1";
            this.dataGridDefault1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridDefault1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridDefault1.RowHeadersWidth = 23;
            this.dataGridDefault1.Size = new System.Drawing.Size(815, 243);
            this.dataGridDefault1.TabIndex = 0;
            // 
            // cdprodutoDataGridViewTextBoxColumn
            // 
            this.cdprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cdprodutoDataGridViewTextBoxColumn.DataPropertyName = "Cd_produto";
            this.cdprodutoDataGridViewTextBoxColumn.HeaderText = "Cd.Produto";
            this.cdprodutoDataGridViewTextBoxColumn.Name = "cdprodutoDataGridViewTextBoxColumn";
            this.cdprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cdprodutoDataGridViewTextBoxColumn.Width = 85;
            // 
            // dsprodutoDataGridViewTextBoxColumn
            // 
            this.dsprodutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsprodutoDataGridViewTextBoxColumn.DataPropertyName = "Ds_produto";
            this.dsprodutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dsprodutoDataGridViewTextBoxColumn.Name = "dsprodutoDataGridViewTextBoxColumn";
            this.dsprodutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsprodutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N3";
            dataGridViewCellStyle11.NullValue = "0";
            this.quantidadeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 87;
            // 
            // bsItens
            // 
            this.bsItens.DataMember = "lItens";
            this.bsItens.DataSource = this.bsCarga;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsItens;
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
            this.bindingNavigatorMoveLastItem,
            this.toolStripSeparator1,
            this.bb_excluirItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 243);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(815, 25);
            this.bindingNavigator1.TabIndex = 17;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bb_excluirItem
            // 
            this.bb_excluirItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bb_excluirItem.Image = ((System.Drawing.Image)(resources.GetObject("bb_excluirItem.Image")));
            this.bb_excluirItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_excluirItem.Name = "bb_excluirItem";
            this.bb_excluirItem.Size = new System.Drawing.Size(94, 22);
            this.bb_excluirItem.Text = "Excluir Item";
            this.bb_excluirItem.Click += new System.EventHandler(this.bb_excluirItem_Click);
            // 
            // TFCargaAvulsa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFCargaAvulsa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento de Carga";
            this.Load += new System.EventHandler(this.TFCargaAvulsa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFCargaAvulsa_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCarga)).EndInit();
            this.pProduto.ResumeLayout(false);
            this.pProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDefault1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault cd_motorista;
        private Componentes.EditDefault nm_motorista;
        private Componentes.EditData Dt_carga;
        private System.Windows.Forms.Button bb_motorista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private Componentes.EditDefault ds_observacao;
        private Componentes.EditDefault placa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_veiculo;
        private Componentes.EditDefault id_veiculo;
        private Componentes.PanelDados pProduto;
        private System.Windows.Forms.Label label40;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditFloat Quantidade;
        private System.Windows.Forms.Label label41;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bsCarga;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault dataGridDefault1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsItens;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bb_excluirItem;
        private Componentes.EditDefault ds_rota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bb_rota;
        private Componentes.EditDefault Id_rota;
    }
}