namespace Fazenda
{
    partial class TFLanAtividadeItem
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLanAtividadeItem));
            System.Windows.Forms.Label label6;
            this.rd_lancar = new Componentes.RadioGroup(this.components);
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.Dt_Custo = new Componentes.EditData(this.components);
            this.BS_Item = new System.Windows.Forms.BindingSource(this.components);
            this.VL_Total = new Componentes.EditFloat(this.components);
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.VL_Unitario = new Componentes.EditFloat(this.components);
            this.Ds_CCusto = new Componentes.EditDefault(this.components);
            this.BB_CCusto = new System.Windows.Forms.Button();
            this.CD_CCusto = new Componentes.EditDefault(this.components);
            this.CD_Unidade = new Componentes.EditDefault(this.components);
            this.DS_Unidade = new Componentes.EditDefault(this.components);
            this.BB_Unidade = new System.Windows.Forms.Button();
            this.ID_Equip = new Componentes.EditDefault(this.components);
            this.DS_Equipamento = new Componentes.EditDefault(this.components);
            this.BB_Equipamento = new System.Windows.Forms.Button();
            this.ID_Atividade = new Componentes.EditDefault(this.components);
            this.DS_Atividade = new Componentes.EditDefault(this.components);
            this.BB_Atividade = new System.Windows.Forms.Button();
            this.pDados = new Componentes.PanelDados(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.editDefault4 = new Componentes.EditDefault(this.components);
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            this.rd_lancar.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).BeginInit();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(611, 301);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.pDados);
            this.tpPadrao.Size = new System.Drawing.Size(603, 275);
            this.tpPadrao.Text = "Lançamento de Itens de Atividade";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(26, 54);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(59, 13);
            label4.TabIndex = 10;
            label4.Text = "Vl. Total:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(9, 31);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 13);
            label3.TabIndex = 8;
            label3.Text = "Quantidade:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(11, 8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 13);
            label1.TabIndex = 0;
            label1.Text = "Data Custo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(151, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(74, 13);
            label2.TabIndex = 5;
            label2.Text = "Vl. Unitário:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label14.Location = new System.Drawing.Point(83, 76);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(35, 13);
            label14.TabIndex = 79;
            label14.Text = "Item:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label13.Location = new System.Drawing.Point(34, 100);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(88, 13);
            label13.TabIndex = 78;
            label13.Text = "Cód. Unidade:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Location = new System.Drawing.Point(45, 124);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 13);
            label10.TabIndex = 77;
            label10.Text = "Cód. Equip.:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label8.Location = new System.Drawing.Point(28, 9);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(94, 13);
            label8.TabIndex = 76;
            label8.Text = "Cód. Atividade:";
            // 
            // rd_lancar
            // 
            this.rd_lancar.Controls.Add(this.panelDados1);
            this.rd_lancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_lancar.Location = new System.Drawing.Point(38, 148);
            this.rd_lancar.Name = "rd_lancar";
            this.rd_lancar.NM_Alias = "";
            this.rd_lancar.NM_Campo = "";
            this.rd_lancar.NM_Param = "";
            this.rd_lancar.NM_Valor = "";
            this.rd_lancar.Size = new System.Drawing.Size(550, 100);
            this.rd_lancar.ST_Gravar = false;
            this.rd_lancar.ST_NotNull = false;
            this.rd_lancar.TabIndex = 81;
            this.rd_lancar.TabStop = false;
            this.rd_lancar.Text = "Lançar";
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(212)))), ((int)(((byte)(121)))));
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.Dt_Custo);
            this.panelDados1.Controls.Add(this.VL_Total);
            this.panelDados1.Controls.Add(label4);
            this.panelDados1.Controls.Add(this.Quantidade);
            this.panelDados1.Controls.Add(label3);
            this.panelDados1.Controls.Add(this.VL_Unitario);
            this.panelDados1.Controls.Add(label1);
            this.panelDados1.Controls.Add(label2);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 16);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(544, 81);
            this.panelDados1.TabIndex = 0;
            // 
            // Dt_Custo
            // 
            this.Dt_Custo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "Dt_Custo_string", true));
            this.Dt_Custo.Enabled = false;
            this.Dt_Custo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dt_Custo.Location = new System.Drawing.Point(86, 5);
            this.Dt_Custo.Mask = "00/00/0000";
            this.Dt_Custo.Name = "Dt_Custo";
            this.Dt_Custo.NM_Alias = "";
            this.Dt_Custo.NM_Campo = "Dt_Custo";
            this.Dt_Custo.NM_CampoBusca = "Dt_Custo";
            this.Dt_Custo.NM_Param = "@P_DT_CUSTO";
            this.Dt_Custo.Operador = "";
            this.Dt_Custo.Size = new System.Drawing.Size(65, 20);
            this.Dt_Custo.ST_Gravar = true;
            this.Dt_Custo.ST_LimpaCampo = true;
            this.Dt_Custo.ST_NotNull = true;
            this.Dt_Custo.ST_PrimaryKey = false;
            this.Dt_Custo.TabIndex = 0;
            this.Dt_Custo.ValidatingType = typeof(System.DateTime);
            // 
            // BS_Item
            // 
            this.BS_Item.DataSource = typeof(CamadaDados.Fazenda.Lancamento.TRegistro_LanAtividade_Item);
            // 
            // VL_Total
            // 
            this.VL_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Item, "VL_Total", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Total.DecimalPlaces = 2;
            this.VL_Total.Enabled = false;
            this.VL_Total.Location = new System.Drawing.Point(86, 51);
            this.VL_Total.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.VL_Total.Name = "VL_Total";
            this.VL_Total.NM_Alias = "";
            this.VL_Total.NM_Campo = "VL_Total";
            this.VL_Total.NM_Param = "@P_VL_TOTAL";
            this.VL_Total.Operador = "";
            this.VL_Total.Size = new System.Drawing.Size(200, 20);
            this.VL_Total.ST_AutoInc = false;
            this.VL_Total.ST_DisableAuto = false;
            this.VL_Total.ST_Gravar = true;
            this.VL_Total.ST_LimparCampo = true;
            this.VL_Total.ST_NotNull = true;
            this.VL_Total.ST_PrimaryKey = false;
            this.VL_Total.TabIndex = 3;
            this.VL_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Item, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Enabled = false;
            this.Quantidade.Location = new System.Drawing.Point(86, 28);
            this.Quantidade.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "Quantidade";
            this.Quantidade.NM_Param = "@P_QUANTIDADE";
            this.Quantidade.Operador = "";
            this.Quantidade.Size = new System.Drawing.Size(200, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 2;
            this.Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VL_Unitario
            // 
            this.VL_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Item, "VL_Unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Unitario.DecimalPlaces = 7;
            this.VL_Unitario.Enabled = false;
            this.VL_Unitario.Location = new System.Drawing.Point(226, 5);
            this.VL_Unitario.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.VL_Unitario.Name = "VL_Unitario";
            this.VL_Unitario.NM_Alias = "";
            this.VL_Unitario.NM_Campo = "VL_Unitario";
            this.VL_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.VL_Unitario.Operador = "";
            this.VL_Unitario.Size = new System.Drawing.Size(110, 20);
            this.VL_Unitario.ST_AutoInc = false;
            this.VL_Unitario.ST_DisableAuto = false;
            this.VL_Unitario.ST_Gravar = true;
            this.VL_Unitario.ST_LimparCampo = true;
            this.VL_Unitario.ST_NotNull = true;
            this.VL_Unitario.ST_PrimaryKey = false;
            this.VL_Unitario.TabIndex = 1;
            this.VL_Unitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ds_CCusto
            // 
            this.Ds_CCusto.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_CCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_CCusto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_CCusto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_CCusto.Enabled = false;
            this.Ds_CCusto.Location = new System.Drawing.Point(215, 75);
            this.Ds_CCusto.Name = "Ds_CCusto";
            this.Ds_CCusto.NM_Alias = "e";
            this.Ds_CCusto.NM_Campo = "DS_CCusto";
            this.Ds_CCusto.NM_CampoBusca = "DS_CCusto";
            this.Ds_CCusto.NM_Param = "@P_DS_CCUSTO";
            this.Ds_CCusto.QTD_Zero = 0;
            this.Ds_CCusto.ReadOnly = true;
            this.Ds_CCusto.Size = new System.Drawing.Size(369, 20);
            this.Ds_CCusto.ST_AutoInc = false;
            this.Ds_CCusto.ST_DisableAuto = false;
            this.Ds_CCusto.ST_Float = false;
            this.Ds_CCusto.ST_Gravar = false;
            this.Ds_CCusto.ST_Int = false;
            this.Ds_CCusto.ST_LimpaCampo = true;
            this.Ds_CCusto.ST_NotNull = false;
            this.Ds_CCusto.ST_PrimaryKey = false;
            this.Ds_CCusto.TabIndex = 80;
            this.Ds_CCusto.TabStop = false;
            // 
            // BB_CCusto
            // 
            this.BB_CCusto.Enabled = false;
            this.BB_CCusto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_CCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_CCusto.Image = ((System.Drawing.Image)(resources.GetObject("BB_CCusto.Image")));
            this.BB_CCusto.Location = new System.Drawing.Point(184, 75);
            this.BB_CCusto.Name = "BB_CCusto";
            this.BB_CCusto.Size = new System.Drawing.Size(28, 19);
            this.BB_CCusto.TabIndex = 72;
            this.BB_CCusto.UseVisualStyleBackColor = true;
            this.BB_CCusto.Click += new System.EventHandler(this.BB_CCusto_Click);
            // 
            // CD_CCusto
            // 
            this.CD_CCusto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_CCusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_CCusto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "CD_CCusto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_CCusto.Enabled = false;
            this.CD_CCusto.Location = new System.Drawing.Point(123, 74);
            this.CD_CCusto.MaxLength = 8;
            this.CD_CCusto.Name = "CD_CCusto";
            this.CD_CCusto.NM_Alias = "a";
            this.CD_CCusto.NM_Campo = "CD_CCusto";
            this.CD_CCusto.NM_CampoBusca = "CD_CCusto";
            this.CD_CCusto.NM_Param = "@P_CD_CCUSTO";
            this.CD_CCusto.QTD_Zero = 0;
            this.CD_CCusto.Size = new System.Drawing.Size(59, 20);
            this.CD_CCusto.ST_AutoInc = false;
            this.CD_CCusto.ST_DisableAuto = false;
            this.CD_CCusto.ST_Float = false;
            this.CD_CCusto.ST_Gravar = true;
            this.CD_CCusto.ST_Int = true;
            this.CD_CCusto.ST_LimpaCampo = true;
            this.CD_CCusto.ST_NotNull = true;
            this.CD_CCusto.ST_PrimaryKey = false;
            this.CD_CCusto.TabIndex = 71;
            this.CD_CCusto.Leave += new System.EventHandler(this.CD_CCusto_Leave);
            // 
            // CD_Unidade
            // 
            this.CD_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "CD_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Unidade.Enabled = false;
            this.CD_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_Unidade.Location = new System.Drawing.Point(123, 97);
            this.CD_Unidade.MaxLength = 3;
            this.CD_Unidade.Name = "CD_Unidade";
            this.CD_Unidade.NM_Alias = "";
            this.CD_Unidade.NM_Campo = "CD_Unidade";
            this.CD_Unidade.NM_CampoBusca = "CD_Unidade";
            this.CD_Unidade.NM_Param = "@P_CD_UNIDADE";
            this.CD_Unidade.QTD_Zero = 0;
            this.CD_Unidade.Size = new System.Drawing.Size(60, 20);
            this.CD_Unidade.ST_AutoInc = false;
            this.CD_Unidade.ST_DisableAuto = false;
            this.CD_Unidade.ST_Float = false;
            this.CD_Unidade.ST_Gravar = true;
            this.CD_Unidade.ST_Int = false;
            this.CD_Unidade.ST_LimpaCampo = true;
            this.CD_Unidade.ST_NotNull = true;
            this.CD_Unidade.ST_PrimaryKey = false;
            this.CD_Unidade.TabIndex = 69;
            this.CD_Unidade.Leave += new System.EventHandler(this.CD_Unidade_Leave);
            // 
            // DS_Unidade
            // 
            this.DS_Unidade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Unidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Unidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_Unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Unidade.Enabled = false;
            this.DS_Unidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Unidade.Location = new System.Drawing.Point(216, 97);
            this.DS_Unidade.Name = "DS_Unidade";
            this.DS_Unidade.NM_Alias = "";
            this.DS_Unidade.NM_Campo = "DS_Unidade";
            this.DS_Unidade.NM_CampoBusca = "DS_Unidade";
            this.DS_Unidade.NM_Param = "@P_DS_UNIDADE";
            this.DS_Unidade.QTD_Zero = 0;
            this.DS_Unidade.ReadOnly = true;
            this.DS_Unidade.Size = new System.Drawing.Size(370, 20);
            this.DS_Unidade.ST_AutoInc = false;
            this.DS_Unidade.ST_DisableAuto = false;
            this.DS_Unidade.ST_Float = false;
            this.DS_Unidade.ST_Gravar = false;
            this.DS_Unidade.ST_Int = false;
            this.DS_Unidade.ST_LimpaCampo = true;
            this.DS_Unidade.ST_NotNull = false;
            this.DS_Unidade.ST_PrimaryKey = false;
            this.DS_Unidade.TabIndex = 75;
            // 
            // BB_Unidade
            // 
            this.BB_Unidade.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Unidade.Enabled = false;
            this.BB_Unidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Unidade.Image")));
            this.BB_Unidade.Location = new System.Drawing.Point(186, 97);
            this.BB_Unidade.Name = "BB_Unidade";
            this.BB_Unidade.Size = new System.Drawing.Size(28, 19);
            this.BB_Unidade.TabIndex = 70;
            this.BB_Unidade.UseVisualStyleBackColor = false;
            this.BB_Unidade.Click += new System.EventHandler(this.BB_Unidade_Click);
            // 
            // ID_Equip
            // 
            this.ID_Equip.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Equip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Equip.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "ID_EquipString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Equip.Enabled = false;
            this.ID_Equip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Equip.Location = new System.Drawing.Point(123, 121);
            this.ID_Equip.MaxLength = 5;
            this.ID_Equip.Name = "ID_Equip";
            this.ID_Equip.NM_Alias = "";
            this.ID_Equip.NM_Campo = "ID_Equip";
            this.ID_Equip.NM_CampoBusca = "ID_Equip";
            this.ID_Equip.NM_Param = "@P_ID_EQUIP";
            this.ID_Equip.QTD_Zero = 0;
            this.ID_Equip.Size = new System.Drawing.Size(60, 20);
            this.ID_Equip.ST_AutoInc = false;
            this.ID_Equip.ST_DisableAuto = false;
            this.ID_Equip.ST_Float = false;
            this.ID_Equip.ST_Gravar = true;
            this.ID_Equip.ST_Int = false;
            this.ID_Equip.ST_LimpaCampo = true;
            this.ID_Equip.ST_NotNull = true;
            this.ID_Equip.ST_PrimaryKey = false;
            this.ID_Equip.TabIndex = 67;
            this.ID_Equip.Leave += new System.EventHandler(this.ID_Equip_Leave);
            // 
            // DS_Equipamento
            // 
            this.DS_Equipamento.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Equipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Equipamento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_Equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Equipamento.Enabled = false;
            this.DS_Equipamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Equipamento.Location = new System.Drawing.Point(216, 122);
            this.DS_Equipamento.Name = "DS_Equipamento";
            this.DS_Equipamento.NM_Alias = "";
            this.DS_Equipamento.NM_Campo = "DS_Equipamento";
            this.DS_Equipamento.NM_CampoBusca = "DS_Equipamento";
            this.DS_Equipamento.NM_Param = "@P_DS_EQUIPAMENTO";
            this.DS_Equipamento.QTD_Zero = 0;
            this.DS_Equipamento.ReadOnly = true;
            this.DS_Equipamento.Size = new System.Drawing.Size(370, 20);
            this.DS_Equipamento.ST_AutoInc = false;
            this.DS_Equipamento.ST_DisableAuto = false;
            this.DS_Equipamento.ST_Float = false;
            this.DS_Equipamento.ST_Gravar = false;
            this.DS_Equipamento.ST_Int = false;
            this.DS_Equipamento.ST_LimpaCampo = true;
            this.DS_Equipamento.ST_NotNull = false;
            this.DS_Equipamento.ST_PrimaryKey = false;
            this.DS_Equipamento.TabIndex = 74;
            // 
            // BB_Equipamento
            // 
            this.BB_Equipamento.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Equipamento.Enabled = false;
            this.BB_Equipamento.Image = ((System.Drawing.Image)(resources.GetObject("BB_Equipamento.Image")));
            this.BB_Equipamento.Location = new System.Drawing.Point(186, 122);
            this.BB_Equipamento.Name = "BB_Equipamento";
            this.BB_Equipamento.Size = new System.Drawing.Size(28, 19);
            this.BB_Equipamento.TabIndex = 68;
            this.BB_Equipamento.UseVisualStyleBackColor = false;
            this.BB_Equipamento.Click += new System.EventHandler(this.BB_Equipamento_Click);
            // 
            // ID_Atividade
            // 
            this.ID_Atividade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.ID_Atividade.BackColor = System.Drawing.SystemColors.Window;
            this.ID_Atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "ID_AtividadeString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Atividade.Enabled = false;
            this.ID_Atividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_Atividade.Location = new System.Drawing.Point(123, 6);
            this.ID_Atividade.MaxLength = 10;
            this.ID_Atividade.Name = "ID_Atividade";
            this.ID_Atividade.NM_Alias = "";
            this.ID_Atividade.NM_Campo = "ID_Atividade";
            this.ID_Atividade.NM_CampoBusca = "ID_Atividade";
            this.ID_Atividade.NM_Param = "@P_ID_ATIVIDADE";
            this.ID_Atividade.QTD_Zero = 0;
            this.ID_Atividade.Size = new System.Drawing.Size(60, 20);
            this.ID_Atividade.ST_AutoInc = false;
            this.ID_Atividade.ST_DisableAuto = false;
            this.ID_Atividade.ST_Float = false;
            this.ID_Atividade.ST_Gravar = true;
            this.ID_Atividade.ST_Int = false;
            this.ID_Atividade.ST_LimpaCampo = true;
            this.ID_Atividade.ST_NotNull = true;
            this.ID_Atividade.ST_PrimaryKey = false;
            this.ID_Atividade.TabIndex = 65;
            this.ID_Atividade.Leave += new System.EventHandler(this.ID_Atividade_Leave);
            // 
            // DS_Atividade
            // 
            this.DS_Atividade.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_Atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Atividade.Enabled = false;
            this.DS_Atividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DS_Atividade.Location = new System.Drawing.Point(216, 7);
            this.DS_Atividade.Name = "DS_Atividade";
            this.DS_Atividade.NM_Alias = "";
            this.DS_Atividade.NM_Campo = "DS_Atividade";
            this.DS_Atividade.NM_CampoBusca = "DS_Atividade";
            this.DS_Atividade.NM_Param = "@P_DS_ATIVIDADE";
            this.DS_Atividade.QTD_Zero = 0;
            this.DS_Atividade.ReadOnly = true;
            this.DS_Atividade.Size = new System.Drawing.Size(370, 20);
            this.DS_Atividade.ST_AutoInc = false;
            this.DS_Atividade.ST_DisableAuto = false;
            this.DS_Atividade.ST_Float = false;
            this.DS_Atividade.ST_Gravar = false;
            this.DS_Atividade.ST_Int = false;
            this.DS_Atividade.ST_LimpaCampo = true;
            this.DS_Atividade.ST_NotNull = false;
            this.DS_Atividade.ST_PrimaryKey = false;
            this.DS_Atividade.TabIndex = 73;
            // 
            // BB_Atividade
            // 
            this.BB_Atividade.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Atividade.Enabled = false;
            this.BB_Atividade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Atividade.Image")));
            this.BB_Atividade.Location = new System.Drawing.Point(186, 7);
            this.BB_Atividade.Name = "BB_Atividade";
            this.BB_Atividade.Size = new System.Drawing.Size(28, 19);
            this.BB_Atividade.TabIndex = 66;
            this.BB_Atividade.UseVisualStyleBackColor = false;
            this.BB_Atividade.Click += new System.EventHandler(this.BB_Atividade_Click);
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.button2);
            this.pDados.Controls.Add(this.editDefault3);
            this.pDados.Controls.Add(this.editDefault4);
            this.pDados.Controls.Add(label6);
            this.pDados.Controls.Add(this.button1);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(this.rd_lancar);
            this.pDados.Controls.Add(this.BB_Atividade);
            this.pDados.Controls.Add(this.Ds_CCusto);
            this.pDados.Controls.Add(this.DS_Atividade);
            this.pDados.Controls.Add(this.BB_CCusto);
            this.pDados.Controls.Add(this.ID_Atividade);
            this.pDados.Controls.Add(this.CD_CCusto);
            this.pDados.Controls.Add(this.BB_Equipamento);
            this.pDados.Controls.Add(label14);
            this.pDados.Controls.Add(this.DS_Equipamento);
            this.pDados.Controls.Add(label13);
            this.pDados.Controls.Add(this.ID_Equip);
            this.pDados.Controls.Add(this.CD_Unidade);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.DS_Unidade);
            this.pDados.Controls.Add(this.BB_Unidade);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(599, 271);
            this.pDados.TabIndex = 82;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Enabled = false;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(185, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 19);
            this.button1.TabIndex = 83;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_Equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDefault1.Location = new System.Drawing.Point(215, 53);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "DS_Equipamento";
            this.editDefault1.NM_CampoBusca = "DS_Equipamento";
            this.editDefault1.NM_Param = "@P_DS_EQUIPAMENTO";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.ReadOnly = true;
            this.editDefault1.Size = new System.Drawing.Size(370, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 84;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "ID_EquipString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDefault2.Location = new System.Drawing.Point(122, 52);
            this.editDefault2.MaxLength = 5;
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "ID_Equip";
            this.editDefault2.NM_CampoBusca = "ID_Equip";
            this.editDefault2.NM_Param = "@P_ID_EQUIP";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(60, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = true;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = true;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 82;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(40, 55);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(79, 13);
            label5.TabIndex = 85;
            label5.Text = "Propriedade:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(185, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 19);
            this.button2.TabIndex = 87;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "DS_Equipamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDefault3.Location = new System.Drawing.Point(215, 30);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "DS_Equipamento";
            this.editDefault3.NM_CampoBusca = "DS_Equipamento";
            this.editDefault3.NM_Param = "@P_DS_EQUIPAMENTO";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.ReadOnly = true;
            this.editDefault3.Size = new System.Drawing.Size(370, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = false;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 88;
            // 
            // editDefault4
            // 
            this.editDefault4.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Item, "ID_EquipString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault4.Enabled = false;
            this.editDefault4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDefault4.Location = new System.Drawing.Point(123, 29);
            this.editDefault4.MaxLength = 5;
            this.editDefault4.Name = "editDefault4";
            this.editDefault4.NM_Alias = "";
            this.editDefault4.NM_Campo = "ID_Equip";
            this.editDefault4.NM_CampoBusca = "ID_Equip";
            this.editDefault4.NM_Param = "@P_ID_EQUIP";
            this.editDefault4.QTD_Zero = 0;
            this.editDefault4.Size = new System.Drawing.Size(60, 20);
            this.editDefault4.ST_AutoInc = false;
            this.editDefault4.ST_DisableAuto = false;
            this.editDefault4.ST_Float = false;
            this.editDefault4.ST_Gravar = true;
            this.editDefault4.ST_Int = false;
            this.editDefault4.ST_LimpaCampo = true;
            this.editDefault4.ST_NotNull = true;
            this.editDefault4.ST_PrimaryKey = false;
            this.editDefault4.TabIndex = 86;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label6.Location = new System.Drawing.Point(69, 32);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(50, 13);
            label6.TabIndex = 89;
            label6.Text = "Talhão:";
            // 
            // TFLanAtividadeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(611, 344);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFLanAtividadeItem";
            this.Text = "Lançamento de Itens Atividade";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TFLanAtividadeItem_FormClosing);
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.rd_lancar.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Unitario)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.RadioGroup rd_lancar;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditData Dt_Custo;
        private Componentes.EditFloat VL_Total;
        private Componentes.EditFloat Quantidade;
        private Componentes.EditFloat VL_Unitario;
        private Componentes.EditDefault Ds_CCusto;
        public System.Windows.Forms.Button BB_CCusto;
        private Componentes.EditDefault CD_CCusto;
        private Componentes.EditDefault CD_Unidade;
        private Componentes.EditDefault DS_Unidade;
        private System.Windows.Forms.Button BB_Unidade;
        private Componentes.EditDefault ID_Equip;
        private Componentes.EditDefault DS_Equipamento;
        private System.Windows.Forms.Button BB_Equipamento;
        private Componentes.EditDefault ID_Atividade;
        private Componentes.EditDefault DS_Atividade;
        private System.Windows.Forms.Button BB_Atividade;
        private Componentes.PanelDados pDados;
        public System.Windows.Forms.BindingSource BS_Item;
        private System.Windows.Forms.Button button2;
        private Componentes.EditDefault editDefault3;
        private Componentes.EditDefault editDefault4;
        private System.Windows.Forms.Button button1;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault editDefault2;
    }
}
