namespace Frota
{
    partial class TFLanAbastFrota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanAbastFrota));
            this.listaImagem = new System.Windows.Forms.ImageList(this.components);
            this.tmpAbastecimento = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.empresa = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblConcentrador = new System.Windows.Forms.Label();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_abast = new System.Windows.Forms.Button();
            this.bb_fechar = new System.Windows.Forms.Button();
            this.bb_cancelar = new System.Windows.Forms.Button();
            this.bb_gravar = new System.Windows.Forms.Button();
            this.ds_observacao = new Componentes.EditDefault(this.components);
            this.bsAbastecimento = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.km_atual = new Componentes.EditFloat(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.volume_requisicao = new Componentes.EditFloat(this.components);
            this.dt_requisicao = new Componentes.EditData(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.ds_produto = new Componentes.EditDefault(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.cd_produto = new Componentes.EditDefault(this.components);
            this.ds_despesa = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.id_despesa = new Componentes.EditDefault(this.components);
            this.ds_viagem = new Componentes.EditDefault(this.components);
            this.id_viagem = new Componentes.EditDefault(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.ds_veiculo = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.id_veiculo = new Componentes.EditDefault(this.components);
            this.placa = new Componentes.EditMask(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).BeginInit();
            this.tlpCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaImagem
            // 
            this.listaImagem.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listaImagem.ImageStream")));
            this.listaImagem.TransparentColor = System.Drawing.Color.Transparent;
            this.listaImagem.Images.SetKeyName(0, "bolas_1801_6149_32x32.png");
            this.listaImagem.Images.SetKeyName(1, "bolas_1800_6150_32x32.png");
            // 
            // tmpAbastecimento
            // 
            this.tmpAbastecimento.Tick += new System.EventHandler(this.tmpAbastecimento_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 132);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 122);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panelDados1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(171, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(697, 122);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.empresa);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(4, 83);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(689, 35);
            this.panelDados1.TabIndex = 1;
            // 
            // empresa
            // 
            this.empresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empresa.FormattingEnabled = true;
            this.empresa.Location = new System.Drawing.Point(97, 3);
            this.empresa.Name = "empresa";
            this.empresa.NM_Alias = "";
            this.empresa.NM_Campo = "";
            this.empresa.NM_Param = "";
            this.empresa.Size = new System.Drawing.Size(589, 28);
            this.empresa.ST_Gravar = false;
            this.empresa.ST_LimparCampo = true;
            this.empresa.ST_NotNull = false;
            this.empresa.TabIndex = 1;
            this.empresa.SelectedIndexChanged += new System.EventHandler(this.empresa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Empresa:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(689, 72);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(209)))), ((int)(((byte)(190)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "ABASTECIMENTO FROTA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblStatus, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblConcentrador, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(548, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(136, 62);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(209)))), ((int)(((byte)(190)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(4, 31);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(128, 30);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConcentrador
            // 
            this.lblConcentrador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(209)))), ((int)(((byte)(190)))));
            this.lblConcentrador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConcentrador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcentrador.ForeColor = System.Drawing.Color.Green;
            this.lblConcentrador.Location = new System.Drawing.Point(4, 1);
            this.lblConcentrador.Name = "lblConcentrador";
            this.lblConcentrador.Size = new System.Drawing.Size(128, 29);
            this.lblConcentrador.TabIndex = 3;
            this.lblConcentrador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pDados
            // 
            this.pDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(206)))), ((int)(((byte)(196)))));
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bb_abast);
            this.pDados.Controls.Add(this.bb_fechar);
            this.pDados.Controls.Add(this.bb_cancelar);
            this.pDados.Controls.Add(this.bb_gravar);
            this.pDados.Controls.Add(this.ds_observacao);
            this.pDados.Controls.Add(this.label14);
            this.pDados.Controls.Add(this.label11);
            this.pDados.Controls.Add(this.km_atual);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.volume_requisicao);
            this.pDados.Controls.Add(this.dt_requisicao);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.ds_produto);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.cd_produto);
            this.pDados.Controls.Add(this.ds_despesa);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.id_despesa);
            this.pDados.Controls.Add(this.ds_viagem);
            this.pDados.Controls.Add(this.id_viagem);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.ds_veiculo);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.id_veiculo);
            this.pDados.Controls.Add(this.placa);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(6, 147);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(873, 354);
            this.pDados.TabIndex = 0;
            // 
            // bb_abast
            // 
            this.bb_abast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bb_abast.Enabled = false;
            this.bb_abast.Image = ((System.Drawing.Image)(resources.GetObject("bb_abast.Image")));
            this.bb_abast.Location = new System.Drawing.Point(288, 149);
            this.bb_abast.Name = "bb_abast";
            this.bb_abast.Size = new System.Drawing.Size(37, 31);
            this.bb_abast.TabIndex = 103;
            this.bb_abast.UseVisualStyleBackColor = true;
            this.bb_abast.Click += new System.EventHandler(this.bb_abast_Click);
            // 
            // bb_fechar
            // 
            this.bb_fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_fechar.Image = ((System.Drawing.Image)(resources.GetObject("bb_fechar.Image")));
            this.bb_fechar.Location = new System.Drawing.Point(504, 294);
            this.bb_fechar.Name = "bb_fechar";
            this.bb_fechar.Size = new System.Drawing.Size(97, 52);
            this.bb_fechar.TabIndex = 102;
            this.bb_fechar.UseVisualStyleBackColor = true;
            this.bb_fechar.Click += new System.EventHandler(this.bb_fechar_Click);
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.Enabled = false;
            this.bb_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_cancelar.ForeColor = System.Drawing.Color.Green;
            this.bb_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("bb_cancelar.Image")));
            this.bb_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_cancelar.Location = new System.Drawing.Point(379, 294);
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(119, 52);
            this.bb_cancelar.TabIndex = 100;
            this.bb_cancelar.Text = "Cancelar";
            this.bb_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_cancelar.UseVisualStyleBackColor = true;
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // bb_gravar
            // 
            this.bb_gravar.Enabled = false;
            this.bb_gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_gravar.ForeColor = System.Drawing.Color.Green;
            this.bb_gravar.Image = ((System.Drawing.Image)(resources.GetObject("bb_gravar.Image")));
            this.bb_gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_gravar.Location = new System.Drawing.Point(270, 294);
            this.bb_gravar.Name = "bb_gravar";
            this.bb_gravar.Size = new System.Drawing.Size(103, 52);
            this.bb_gravar.TabIndex = 99;
            this.bb_gravar.Text = "Gravar";
            this.bb_gravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_gravar.UseVisualStyleBackColor = true;
            this.bb_gravar.Click += new System.EventHandler(this.bb_gravar_Click);
            // 
            // ds_observacao
            // 
            this.ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_observacao.Enabled = false;
            this.ds_observacao.Location = new System.Drawing.Point(11, 199);
            this.ds_observacao.Multiline = true;
            this.ds_observacao.Name = "ds_observacao";
            this.ds_observacao.NM_Alias = "";
            this.ds_observacao.NM_Campo = "";
            this.ds_observacao.NM_CampoBusca = "";
            this.ds_observacao.NM_Param = "";
            this.ds_observacao.QTD_Zero = 0;
            this.ds_observacao.Size = new System.Drawing.Size(854, 89);
            this.ds_observacao.ST_AutoInc = false;
            this.ds_observacao.ST_DisableAuto = false;
            this.ds_observacao.ST_Float = false;
            this.ds_observacao.ST_Gravar = true;
            this.ds_observacao.ST_Int = false;
            this.ds_observacao.ST_LimpaCampo = true;
            this.ds_observacao.ST_NotNull = false;
            this.ds_observacao.ST_PrimaryKey = false;
            this.ds_observacao.TabIndex = 97;
            this.ds_observacao.TextOld = null;
            // 
            // bsAbastecimento
            // 
            this.bsAbastecimento.DataSource = typeof(CamadaDados.Frota.TList_AbastVeiculo);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 98;
            this.label14.Text = "Observação";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(328, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 96;
            this.label11.Text = "KM Atual";
            // 
            // km_atual
            // 
            this.km_atual.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Km_atual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.km_atual.Enabled = false;
            this.km_atual.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.km_atual.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km_atual.Location = new System.Drawing.Point(331, 149);
            this.km_atual.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.km_atual.Name = "km_atual";
            this.km_atual.NM_Alias = "";
            this.km_atual.NM_Campo = "";
            this.km_atual.NM_Param = "";
            this.km_atual.Operador = "";
            this.km_atual.Size = new System.Drawing.Size(142, 31);
            this.km_atual.ST_AutoInc = false;
            this.km_atual.ST_DisableAuto = false;
            this.km_atual.ST_Gravar = true;
            this.km_atual.ST_LimparCampo = true;
            this.km_atual.ST_NotNull = false;
            this.km_atual.ST_PrimaryKey = false;
            this.km_atual.TabIndex = 95;
            this.km_atual.ThousandsSeparator = true;
            this.km_atual.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.km_atual.Leave += new System.EventHandler(this.km_atual_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Volume";
            // 
            // volume_requisicao
            // 
            this.volume_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsAbastecimento, "Volume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.volume_requisicao.DecimalPlaces = 3;
            this.volume_requisicao.Enabled = false;
            this.volume_requisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume_requisicao.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.volume_requisicao.Location = new System.Drawing.Point(153, 149);
            this.volume_requisicao.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.volume_requisicao.Name = "volume_requisicao";
            this.volume_requisicao.NM_Alias = "";
            this.volume_requisicao.NM_Campo = "";
            this.volume_requisicao.NM_Param = "";
            this.volume_requisicao.Operador = "";
            this.volume_requisicao.Size = new System.Drawing.Size(134, 31);
            this.volume_requisicao.ST_AutoInc = false;
            this.volume_requisicao.ST_DisableAuto = false;
            this.volume_requisicao.ST_Gravar = true;
            this.volume_requisicao.ST_LimparCampo = true;
            this.volume_requisicao.ST_NotNull = true;
            this.volume_requisicao.ST_PrimaryKey = false;
            this.volume_requisicao.TabIndex = 92;
            this.volume_requisicao.ThousandsSeparator = true;
            this.volume_requisicao.ValueOld = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dt_requisicao
            // 
            this.dt_requisicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_requisicao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Dt_abastecimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_requisicao.Enabled = false;
            this.dt_requisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_requisicao.Location = new System.Drawing.Point(11, 149);
            this.dt_requisicao.Mask = "00/00/0000";
            this.dt_requisicao.Name = "dt_requisicao";
            this.dt_requisicao.NM_Alias = "";
            this.dt_requisicao.NM_Campo = "";
            this.dt_requisicao.NM_CampoBusca = "";
            this.dt_requisicao.NM_Param = "";
            this.dt_requisicao.Operador = "";
            this.dt_requisicao.Size = new System.Drawing.Size(136, 31);
            this.dt_requisicao.ST_Gravar = true;
            this.dt_requisicao.ST_LimpaCampo = true;
            this.dt_requisicao.ST_NotNull = true;
            this.dt_requisicao.ST_PrimaryKey = false;
            this.dt_requisicao.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 93;
            this.label9.Text = "Data";
            // 
            // ds_produto
            // 
            this.ds_produto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_produto.Enabled = false;
            this.ds_produto.Location = new System.Drawing.Point(516, 110);
            this.ds_produto.Name = "ds_produto";
            this.ds_produto.NM_Alias = "";
            this.ds_produto.NM_Campo = "ds_produto";
            this.ds_produto.NM_CampoBusca = "ds_produto";
            this.ds_produto.NM_Param = "@P_DS_DESPESA";
            this.ds_produto.QTD_Zero = 0;
            this.ds_produto.Size = new System.Drawing.Size(349, 20);
            this.ds_produto.ST_AutoInc = false;
            this.ds_produto.ST_DisableAuto = false;
            this.ds_produto.ST_Float = false;
            this.ds_produto.ST_Gravar = false;
            this.ds_produto.ST_Int = false;
            this.ds_produto.ST_LimpaCampo = true;
            this.ds_produto.ST_NotNull = false;
            this.ds_produto.ST_PrimaryKey = false;
            this.ds_produto.TabIndex = 90;
            this.ds_produto.TextOld = null;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(438, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 89;
            this.label15.Text = "Combustivel";
            // 
            // cd_produto
            // 
            this.cd_produto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_produto.Enabled = false;
            this.cd_produto.Location = new System.Drawing.Point(441, 110);
            this.cd_produto.Name = "cd_produto";
            this.cd_produto.NM_Alias = "";
            this.cd_produto.NM_Campo = "cd_produto";
            this.cd_produto.NM_CampoBusca = "cd_produto";
            this.cd_produto.NM_Param = "@P_CD_EMPRESA";
            this.cd_produto.QTD_Zero = 0;
            this.cd_produto.Size = new System.Drawing.Size(72, 20);
            this.cd_produto.ST_AutoInc = false;
            this.cd_produto.ST_DisableAuto = false;
            this.cd_produto.ST_Float = false;
            this.cd_produto.ST_Gravar = true;
            this.cd_produto.ST_Int = false;
            this.cd_produto.ST_LimpaCampo = true;
            this.cd_produto.ST_NotNull = true;
            this.cd_produto.ST_PrimaryKey = false;
            this.cd_produto.TabIndex = 88;
            this.cd_produto.TextOld = null;
            // 
            // ds_despesa
            // 
            this.ds_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_despesa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_despesa.Enabled = false;
            this.ds_despesa.Location = new System.Drawing.Point(86, 110);
            this.ds_despesa.Name = "ds_despesa";
            this.ds_despesa.NM_Alias = "";
            this.ds_despesa.NM_Campo = "ds_despesa";
            this.ds_despesa.NM_CampoBusca = "ds_despesa";
            this.ds_despesa.NM_Param = "@P_DS_DESPESA";
            this.ds_despesa.QTD_Zero = 0;
            this.ds_despesa.Size = new System.Drawing.Size(349, 20);
            this.ds_despesa.ST_AutoInc = false;
            this.ds_despesa.ST_DisableAuto = false;
            this.ds_despesa.ST_Float = false;
            this.ds_despesa.ST_Gravar = false;
            this.ds_despesa.ST_Int = false;
            this.ds_despesa.ST_LimpaCampo = true;
            this.ds_despesa.ST_NotNull = false;
            this.ds_despesa.ST_PrimaryKey = false;
            this.ds_despesa.TabIndex = 71;
            this.ds_despesa.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Despesa";
            // 
            // id_despesa
            // 
            this.id_despesa.BackColor = System.Drawing.SystemColors.Window;
            this.id_despesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_despesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_despesa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_despesastr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_despesa.Enabled = false;
            this.id_despesa.Location = new System.Drawing.Point(11, 110);
            this.id_despesa.Name = "id_despesa";
            this.id_despesa.NM_Alias = "";
            this.id_despesa.NM_Campo = "id_despesa";
            this.id_despesa.NM_CampoBusca = "id_despesa";
            this.id_despesa.NM_Param = "@P_CD_EMPRESA";
            this.id_despesa.QTD_Zero = 0;
            this.id_despesa.Size = new System.Drawing.Size(72, 20);
            this.id_despesa.ST_AutoInc = false;
            this.id_despesa.ST_DisableAuto = false;
            this.id_despesa.ST_Float = false;
            this.id_despesa.ST_Gravar = true;
            this.id_despesa.ST_Int = false;
            this.id_despesa.ST_LimpaCampo = true;
            this.id_despesa.ST_NotNull = true;
            this.id_despesa.ST_PrimaryKey = false;
            this.id_despesa.TabIndex = 69;
            this.id_despesa.TextOld = null;
            // 
            // ds_viagem
            // 
            this.ds_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_viagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_viagem.Enabled = false;
            this.ds_viagem.Location = new System.Drawing.Point(516, 71);
            this.ds_viagem.Name = "ds_viagem";
            this.ds_viagem.NM_Alias = "";
            this.ds_viagem.NM_Campo = "ds_viagem";
            this.ds_viagem.NM_CampoBusca = "ds_viagem";
            this.ds_viagem.NM_Param = "@P_NM_EMPRESA";
            this.ds_viagem.QTD_Zero = 0;
            this.ds_viagem.Size = new System.Drawing.Size(349, 20);
            this.ds_viagem.ST_AutoInc = false;
            this.ds_viagem.ST_DisableAuto = false;
            this.ds_viagem.ST_Float = false;
            this.ds_viagem.ST_Gravar = false;
            this.ds_viagem.ST_Int = false;
            this.ds_viagem.ST_LimpaCampo = true;
            this.ds_viagem.ST_NotNull = false;
            this.ds_viagem.ST_PrimaryKey = false;
            this.ds_viagem.TabIndex = 68;
            this.ds_viagem.TextOld = null;
            // 
            // id_viagem
            // 
            this.id_viagem.BackColor = System.Drawing.SystemColors.Window;
            this.id_viagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_viagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_viagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_viagemstr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_viagem.Enabled = false;
            this.id_viagem.Location = new System.Drawing.Point(441, 71);
            this.id_viagem.Name = "id_viagem";
            this.id_viagem.NM_Alias = "";
            this.id_viagem.NM_Campo = "id_viagem";
            this.id_viagem.NM_CampoBusca = "id_viagem";
            this.id_viagem.NM_Param = "@P_CD_EMPRESA";
            this.id_viagem.QTD_Zero = 0;
            this.id_viagem.Size = new System.Drawing.Size(72, 20);
            this.id_viagem.ST_AutoInc = false;
            this.id_viagem.ST_DisableAuto = false;
            this.id_viagem.ST_Float = false;
            this.id_viagem.ST_Gravar = true;
            this.id_viagem.ST_Int = false;
            this.id_viagem.ST_LimpaCampo = true;
            this.id_viagem.ST_NotNull = false;
            this.id_viagem.ST_PrimaryKey = false;
            this.id_viagem.TabIndex = 65;
            this.id_viagem.TextOld = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(438, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Viagem";
            // 
            // ds_veiculo
            // 
            this.ds_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.ds_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Ds_veiculo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_veiculo.Enabled = false;
            this.ds_veiculo.Location = new System.Drawing.Point(86, 71);
            this.ds_veiculo.Name = "ds_veiculo";
            this.ds_veiculo.NM_Alias = "";
            this.ds_veiculo.NM_Campo = "ds_veiculo";
            this.ds_veiculo.NM_CampoBusca = "ds_veiculo";
            this.ds_veiculo.NM_Param = "@P_DS_VEICULO";
            this.ds_veiculo.QTD_Zero = 0;
            this.ds_veiculo.Size = new System.Drawing.Size(349, 20);
            this.ds_veiculo.ST_AutoInc = false;
            this.ds_veiculo.ST_DisableAuto = false;
            this.ds_veiculo.ST_Float = false;
            this.ds_veiculo.ST_Gravar = false;
            this.ds_veiculo.ST_Int = false;
            this.ds_veiculo.ST_LimpaCampo = true;
            this.ds_veiculo.ST_NotNull = false;
            this.ds_veiculo.ST_PrimaryKey = false;
            this.ds_veiculo.TabIndex = 61;
            this.ds_veiculo.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 60;
            this.label5.Text = "Veiculo";
            // 
            // id_veiculo
            // 
            this.id_veiculo.BackColor = System.Drawing.SystemColors.Window;
            this.id_veiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_veiculo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_veiculo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAbastecimento, "Id_veiculostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_veiculo.Enabled = false;
            this.id_veiculo.Location = new System.Drawing.Point(11, 71);
            this.id_veiculo.Name = "id_veiculo";
            this.id_veiculo.NM_Alias = "";
            this.id_veiculo.NM_Campo = "id_veiculo";
            this.id_veiculo.NM_CampoBusca = "id_veiculo";
            this.id_veiculo.NM_Param = "@P_CD_EMPRESA";
            this.id_veiculo.QTD_Zero = 0;
            this.id_veiculo.Size = new System.Drawing.Size(72, 20);
            this.id_veiculo.ST_AutoInc = false;
            this.id_veiculo.ST_DisableAuto = false;
            this.id_veiculo.ST_Float = false;
            this.id_veiculo.ST_Gravar = true;
            this.id_veiculo.ST_Int = false;
            this.id_veiculo.ST_LimpaCampo = true;
            this.id_veiculo.ST_NotNull = true;
            this.id_veiculo.ST_PrimaryKey = false;
            this.id_veiculo.TabIndex = 59;
            this.id_veiculo.TextOld = null;
            // 
            // placa
            // 
            this.placa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.placa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placa.Location = new System.Drawing.Point(107, 3);
            this.placa.Mask = "AAA-AAAA";
            this.placa.Name = "placa";
            this.placa.NM_Alias = "";
            this.placa.NM_Campo = "";
            this.placa.NM_CampoBusca = "";
            this.placa.NM_Param = "";
            this.placa.Size = new System.Drawing.Size(146, 38);
            this.placa.ST_Gravar = true;
            this.placa.ST_LimpaCampo = true;
            this.placa.ST_NotNull = true;
            this.placa.ST_PrimaryKey = false;
            this.placa.TabIndex = 40;
            this.placa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.placa_KeyPress);
            this.placa.Leave += new System.EventHandler(this.placa_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Placa:";
            // 
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pDados, 0, 1);
            this.tlpCentral.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCentral.Size = new System.Drawing.Size(885, 507);
            this.tlpCentral.TabIndex = 0;
            // 
            // TFLanAbastFrota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 507);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFLanAbastFrota";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "N";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanAbastFrota_FormClosing);
            this.Load += new System.EventHandler(this.TFLanAbastFrota_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAbastecimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.km_atual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volume_requisicao)).EndInit();
            this.tlpCentral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsAbastecimento;
        private System.Windows.Forms.Timer tmpAbastecimento;
        private System.Windows.Forms.ImageList listaImagem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados panelDados1;
        private Componentes.ComboBoxDefault empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_fechar;
        private System.Windows.Forms.Button bb_cancelar;
        private System.Windows.Forms.Button bb_gravar;
        private Componentes.EditDefault ds_observacao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private Componentes.EditFloat km_atual;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat volume_requisicao;
        private Componentes.EditData dt_requisicao;
        private System.Windows.Forms.Label label9;
        private Componentes.EditDefault ds_produto;
        private System.Windows.Forms.Label label15;
        private Componentes.EditDefault cd_produto;
        private Componentes.EditDefault ds_despesa;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault id_despesa;
        private Componentes.EditDefault ds_viagem;
        private Componentes.EditDefault id_viagem;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault ds_veiculo;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault id_veiculo;
        private Componentes.EditMask placa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private System.Windows.Forms.Button bb_abast;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblConcentrador;
    }
}