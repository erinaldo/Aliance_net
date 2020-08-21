namespace Servicos
{
    partial class TFServicosSalao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFServicosSalao));
            this.BS_Pecas = new System.Windows.Forms.BindingSource(this.components);
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pnl_Pecas = new Componentes.PanelDados(this.components);
            this.BB_Tecnico = new System.Windows.Forms.Button();
            this.DS_Funcao = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ID_Tecnico = new Componentes.EditDefault(this.components);
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelDados6 = new Componentes.PanelDados(this.components);
            this.vl_acrescimo = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pc_acrescimo = new Componentes.EditFloat(this.components);
            this.VL_Desconto = new Componentes.EditFloat(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.Pc_DescontoItem = new Componentes.EditFloat(this.components);
            this.VL_Total = new Componentes.EditFloat(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.Vl_Unitario = new Componentes.EditFloat(this.components);
            this.label59 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.Lbl_Produto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BS_Pecas)).BeginInit();
            this.barraMenu.SuspendLayout();
            this.pnl_Pecas.SuspendLayout();
            this.panelDados6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_acrescimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_acrescimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Desconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_DescontoItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).BeginInit();
            this.SuspendLayout();
            // 
            // BS_Pecas
            // 
            this.BS_Pecas.DataSource = typeof(CamadaDados.Servicos.TList_LanServicosPecas);
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(601, 43);
            this.barraMenu.TabIndex = 1;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(85, 40);
            this.BB_Gravar.Text = "(F4)\r\nGravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(95, 40);
            this.BB_Cancelar.Text = "(F6)\r\nCancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // pnl_Pecas
            // 
            this.pnl_Pecas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Pecas.Controls.Add(this.BB_Tecnico);
            this.pnl_Pecas.Controls.Add(this.DS_Funcao);
            this.pnl_Pecas.Controls.Add(this.label4);
            this.pnl_Pecas.Controls.Add(this.ID_Tecnico);
            this.pnl_Pecas.Controls.Add(this.CD_Produto);
            this.pnl_Pecas.Controls.Add(this.label3);
            this.pnl_Pecas.Controls.Add(this.panelDados6);
            this.pnl_Pecas.Controls.Add(this.label2);
            this.pnl_Pecas.Controls.Add(this.DS_Observacao);
            this.pnl_Pecas.Controls.Add(this.DS_Produto);
            this.pnl_Pecas.Controls.Add(this.Lbl_Produto);
            this.pnl_Pecas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Pecas.Location = new System.Drawing.Point(0, 43);
            this.pnl_Pecas.Name = "pnl_Pecas";
            this.pnl_Pecas.NM_ProcDeletar = "";
            this.pnl_Pecas.NM_ProcGravar = "";
            this.pnl_Pecas.Size = new System.Drawing.Size(601, 251);
            this.pnl_Pecas.TabIndex = 0;
            // 
            // BB_Tecnico
            // 
            this.BB_Tecnico.Image = ((System.Drawing.Image)(resources.GetObject("BB_Tecnico.Image")));
            this.BB_Tecnico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Tecnico.Location = new System.Drawing.Point(152, 86);
            this.BB_Tecnico.Name = "BB_Tecnico";
            this.BB_Tecnico.Size = new System.Drawing.Size(28, 19);
            this.BB_Tecnico.TabIndex = 2;
            this.BB_Tecnico.UseVisualStyleBackColor = true;
            this.BB_Tecnico.Click += new System.EventHandler(this.BB_Tecnico_Click);
            // 
            // DS_Funcao
            // 
            this.DS_Funcao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Funcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Funcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Funcao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pecas, "Nm_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Funcao.Enabled = false;
            this.DS_Funcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Funcao.Location = new System.Drawing.Point(183, 86);
            this.DS_Funcao.Name = "DS_Funcao";
            this.DS_Funcao.NM_Alias = "";
            this.DS_Funcao.NM_Campo = "nm_clifor";
            this.DS_Funcao.NM_CampoBusca = "nm_clifor";
            this.DS_Funcao.NM_Param = "@P_NM_CLIFOR";
            this.DS_Funcao.QTD_Zero = 0;
            this.DS_Funcao.ReadOnly = true;
            this.DS_Funcao.Size = new System.Drawing.Size(405, 20);
            this.DS_Funcao.ST_AutoInc = false;
            this.DS_Funcao.ST_DisableAuto = false;
            this.DS_Funcao.ST_Float = false;
            this.DS_Funcao.ST_Gravar = false;
            this.DS_Funcao.ST_Int = false;
            this.DS_Funcao.ST_LimpaCampo = true;
            this.DS_Funcao.ST_NotNull = false;
            this.DS_Funcao.ST_PrimaryKey = false;
            this.DS_Funcao.TabIndex = 114;
            this.DS_Funcao.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(21, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 113;
            this.label4.Text = "Técnico:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ID_Tecnico
            // 
            this.ID_Tecnico.BackColor = System.Drawing.Color.White;
            this.ID_Tecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Tecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pecas, "Cd_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Tecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ID_Tecnico.Location = new System.Drawing.Point(84, 85);
            this.ID_Tecnico.Name = "ID_Tecnico";
            this.ID_Tecnico.NM_Alias = "";
            this.ID_Tecnico.NM_Campo = "cd_clifor";
            this.ID_Tecnico.NM_CampoBusca = "cd_clifor";
            this.ID_Tecnico.NM_Param = "@P_CD_CLIFOR";
            this.ID_Tecnico.QTD_Zero = 0;
            this.ID_Tecnico.Size = new System.Drawing.Size(65, 20);
            this.ID_Tecnico.ST_AutoInc = false;
            this.ID_Tecnico.ST_DisableAuto = false;
            this.ID_Tecnico.ST_Float = false;
            this.ID_Tecnico.ST_Gravar = true;
            this.ID_Tecnico.ST_Int = false;
            this.ID_Tecnico.ST_LimpaCampo = true;
            this.ID_Tecnico.ST_NotNull = false;
            this.ID_Tecnico.ST_PrimaryKey = false;
            this.ID_Tecnico.TabIndex = 1;
            this.ID_Tecnico.TextOld = null;
            this.ID_Tecnico.Leave += new System.EventHandler(this.ID_Tecnico_Leave);
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pecas, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CD_Produto.Location = new System.Drawing.Point(84, 22);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(504, 29);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 0;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CD_Produto_KeyDown);
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(81, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(450, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Localiza serviço por codigo interno, codigo de barras, codigo referencia ou parte" +
                " da descrição";
            // 
            // panelDados6
            // 
            this.panelDados6.BackColor = System.Drawing.Color.LightGray;
            this.panelDados6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados6.Controls.Add(this.vl_acrescimo);
            this.panelDados6.Controls.Add(this.label5);
            this.panelDados6.Controls.Add(this.label9);
            this.panelDados6.Controls.Add(this.pc_acrescimo);
            this.panelDados6.Controls.Add(this.VL_Desconto);
            this.panelDados6.Controls.Add(this.label6);
            this.panelDados6.Controls.Add(this.label60);
            this.panelDados6.Controls.Add(this.Pc_DescontoItem);
            this.panelDados6.Controls.Add(this.VL_Total);
            this.panelDados6.Controls.Add(this.label8);
            this.panelDados6.Controls.Add(this.Vl_Unitario);
            this.panelDados6.Controls.Add(this.label59);
            this.panelDados6.Location = new System.Drawing.Point(84, 112);
            this.panelDados6.Name = "panelDados6";
            this.panelDados6.NM_ProcDeletar = "";
            this.panelDados6.NM_ProcGravar = "";
            this.panelDados6.Size = new System.Drawing.Size(504, 66);
            this.panelDados6.TabIndex = 3;
            // 
            // vl_acrescimo
            // 
            this.vl_acrescimo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Vl_acrescimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_acrescimo.DecimalPlaces = 2;
            this.vl_acrescimo.Location = new System.Drawing.Point(416, 36);
            this.vl_acrescimo.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.vl_acrescimo.Name = "vl_acrescimo";
            this.vl_acrescimo.NM_Alias = "";
            this.vl_acrescimo.NM_Campo = "Vl_Unitario";
            this.vl_acrescimo.NM_Param = "@P_VL_UNITARIO";
            this.vl_acrescimo.Operador = "";
            this.vl_acrescimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.vl_acrescimo.Size = new System.Drawing.Size(76, 20);
            this.vl_acrescimo.ST_AutoInc = false;
            this.vl_acrescimo.ST_DisableAuto = false;
            this.vl_acrescimo.ST_Gravar = true;
            this.vl_acrescimo.ST_LimparCampo = true;
            this.vl_acrescimo.ST_NotNull = false;
            this.vl_acrescimo.ST_PrimaryKey = false;
            this.vl_acrescimo.TabIndex = 4;
            this.vl_acrescimo.ThousandsSeparator = true;
            this.vl_acrescimo.Leave += new System.EventHandler(this.vl_acrescimo_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(349, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "Vl. Acresc.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(194, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 129;
            this.label9.Text = "% Acresc.:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pc_acrescimo
            // 
            this.pc_acrescimo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Pc_acrescimo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pc_acrescimo.DecimalPlaces = 5;
            this.pc_acrescimo.Location = new System.Drawing.Point(257, 37);
            this.pc_acrescimo.Name = "pc_acrescimo";
            this.pc_acrescimo.NM_Alias = "";
            this.pc_acrescimo.NM_Campo = "Pc_Desc";
            this.pc_acrescimo.NM_Param = "@P_PC_DESC";
            this.pc_acrescimo.Operador = "";
            this.pc_acrescimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pc_acrescimo.Size = new System.Drawing.Size(76, 20);
            this.pc_acrescimo.ST_AutoInc = false;
            this.pc_acrescimo.ST_DisableAuto = false;
            this.pc_acrescimo.ST_Gravar = true;
            this.pc_acrescimo.ST_LimparCampo = true;
            this.pc_acrescimo.ST_NotNull = false;
            this.pc_acrescimo.ST_PrimaryKey = false;
            this.pc_acrescimo.TabIndex = 3;
            this.pc_acrescimo.ThousandsSeparator = true;
            this.pc_acrescimo.Leave += new System.EventHandler(this.pc_acrescimo_Leave);
            // 
            // VL_Desconto
            // 
            this.VL_Desconto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Vl_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Desconto.DecimalPlaces = 2;
            this.VL_Desconto.Location = new System.Drawing.Point(416, 9);
            this.VL_Desconto.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.VL_Desconto.Name = "VL_Desconto";
            this.VL_Desconto.NM_Alias = "";
            this.VL_Desconto.NM_Campo = "Vl_Unitario";
            this.VL_Desconto.NM_Param = "@P_VL_UNITARIO";
            this.VL_Desconto.Operador = "";
            this.VL_Desconto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Desconto.Size = new System.Drawing.Size(76, 20);
            this.VL_Desconto.ST_AutoInc = false;
            this.VL_Desconto.ST_DisableAuto = false;
            this.VL_Desconto.ST_Gravar = true;
            this.VL_Desconto.ST_LimparCampo = true;
            this.VL_Desconto.ST_NotNull = false;
            this.VL_Desconto.ST_PrimaryKey = false;
            this.VL_Desconto.TabIndex = 2;
            this.VL_Desconto.ThousandsSeparator = true;
            this.VL_Desconto.Leave += new System.EventHandler(this.VL_Desconto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(339, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 125;
            this.label6.Text = "Vl. Desconto:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label60.Location = new System.Drawing.Point(184, 12);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(67, 13);
            this.label60.TabIndex = 124;
            this.label60.Text = "% Desconto:";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Pc_DescontoItem
            // 
            this.Pc_DescontoItem.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Pc_desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Pc_DescontoItem.DecimalPlaces = 5;
            this.Pc_DescontoItem.Location = new System.Drawing.Point(257, 10);
            this.Pc_DescontoItem.Name = "Pc_DescontoItem";
            this.Pc_DescontoItem.NM_Alias = "";
            this.Pc_DescontoItem.NM_Campo = "Pc_Desc";
            this.Pc_DescontoItem.NM_Param = "@P_PC_DESC";
            this.Pc_DescontoItem.Operador = "";
            this.Pc_DescontoItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Pc_DescontoItem.Size = new System.Drawing.Size(76, 20);
            this.Pc_DescontoItem.ST_AutoInc = false;
            this.Pc_DescontoItem.ST_DisableAuto = false;
            this.Pc_DescontoItem.ST_Gravar = true;
            this.Pc_DescontoItem.ST_LimparCampo = true;
            this.Pc_DescontoItem.ST_NotNull = false;
            this.Pc_DescontoItem.ST_PrimaryKey = false;
            this.Pc_DescontoItem.TabIndex = 1;
            this.Pc_DescontoItem.ThousandsSeparator = true;
            this.Pc_DescontoItem.Leave += new System.EventHandler(this.Pc_DescontoItem_Leave);
            // 
            // VL_Total
            // 
            this.VL_Total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Vl_SubTotalLiq", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.VL_Total.DecimalPlaces = 2;
            this.VL_Total.Enabled = false;
            this.VL_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.VL_Total.Location = new System.Drawing.Point(84, 35);
            this.VL_Total.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.VL_Total.Name = "VL_Total";
            this.VL_Total.NM_Alias = "";
            this.VL_Total.NM_Campo = "Vl_Unitario";
            this.VL_Total.NM_Param = "@P_VL_UNITARIO";
            this.VL_Total.Operador = "";
            this.VL_Total.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.VL_Total.Size = new System.Drawing.Size(104, 20);
            this.VL_Total.ST_AutoInc = false;
            this.VL_Total.ST_DisableAuto = false;
            this.VL_Total.ST_Gravar = true;
            this.VL_Total.ST_LimparCampo = true;
            this.VL_Total.ST_NotNull = false;
            this.VL_Total.ST_PrimaryKey = false;
            this.VL_Total.TabIndex = 7;
            this.VL_Total.ThousandsSeparator = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(7, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 121;
            this.label8.Text = "Vl. Liquido:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Vl_Unitario
            // 
            this.Vl_Unitario.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BS_Pecas, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Vl_Unitario.DecimalPlaces = 2;
            this.Vl_Unitario.Location = new System.Drawing.Point(84, 9);
            this.Vl_Unitario.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.Vl_Unitario.Name = "Vl_Unitario";
            this.Vl_Unitario.NM_Alias = "";
            this.Vl_Unitario.NM_Campo = "Vl_Unitario";
            this.Vl_Unitario.NM_Param = "@P_VL_UNITARIO";
            this.Vl_Unitario.Operador = "";
            this.Vl_Unitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Vl_Unitario.Size = new System.Drawing.Size(94, 20);
            this.Vl_Unitario.ST_AutoInc = false;
            this.Vl_Unitario.ST_DisableAuto = false;
            this.Vl_Unitario.ST_Gravar = true;
            this.Vl_Unitario.ST_LimparCampo = true;
            this.Vl_Unitario.ST_NotNull = true;
            this.Vl_Unitario.ST_PrimaryKey = false;
            this.Vl_Unitario.TabIndex = 0;
            this.Vl_Unitario.ThousandsSeparator = true;
            this.Vl_Unitario.Leave += new System.EventHandler(this.Vl_Unitario_Leave);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label59.Location = new System.Drawing.Point(17, 12);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(61, 13);
            this.label59.TabIndex = 117;
            this.label59.Text = "Vl. Serviço:";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(2, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "Observação:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.Color.White;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pecas, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Observacao.Location = new System.Drawing.Point(84, 184);
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "";
            this.DS_Observacao.NM_Campo = "ID_Tecnico";
            this.DS_Observacao.NM_CampoBusca = "ID_Tecnico";
            this.DS_Observacao.NM_Param = "@P_CD_EMPRESA";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DS_Observacao.Size = new System.Drawing.Size(504, 50);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 4;
            this.DS_Observacao.TextOld = null;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BS_Pecas, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(84, 59);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_FUNCAO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(504, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = true;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 2;
            this.DS_Produto.TextOld = null;
            // 
            // Lbl_Produto
            // 
            this.Lbl_Produto.AutoSize = true;
            this.Lbl_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lbl_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Lbl_Produto.Location = new System.Drawing.Point(24, 28);
            this.Lbl_Produto.Name = "Lbl_Produto";
            this.Lbl_Produto.Size = new System.Drawing.Size(54, 13);
            this.Lbl_Produto.TabIndex = 86;
            this.Lbl_Produto.Text = "Serviço:";
            this.Lbl_Produto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TFServicosSalao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 294);
            this.Controls.Add(this.pnl_Pecas);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFServicosSalao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serviços";
            this.Load += new System.EventHandler(this.TFServicosSalao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFServicosSalao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.BS_Pecas)).EndInit();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pnl_Pecas.ResumeLayout(false);
            this.pnl_Pecas.PerformLayout();
            this.panelDados6.ResumeLayout(false);
            this.panelDados6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_acrescimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_acrescimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Desconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pc_DescontoItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VL_Total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vl_Unitario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.BindingSource BS_Pecas;
        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pnl_Pecas;
        public System.Windows.Forms.Button BB_Tecnico;
        public Componentes.EditDefault DS_Funcao;
        private System.Windows.Forms.Label label4;
        public Componentes.EditDefault ID_Tecnico;
        public Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label label3;
        private Componentes.PanelDados panelDados6;
        public Componentes.EditFloat vl_acrescimo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        public Componentes.EditFloat pc_acrescimo;
        public Componentes.EditFloat VL_Desconto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label60;
        public Componentes.EditFloat Pc_DescontoItem;
        public Componentes.EditFloat VL_Total;
        private System.Windows.Forms.Label label8;
        public Componentes.EditFloat Vl_Unitario;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label2;
        public Componentes.EditDefault DS_Observacao;
        public Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.Label Lbl_Produto;
    }
}