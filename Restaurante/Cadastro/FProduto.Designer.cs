namespace Restaurante.Cadastro
{
    partial class FProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProduto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Novo = new System.Windows.Forms.ToolStripButton();
            this.BB_Alterar = new System.Windows.Forms.ToolStripButton();
            this.BB_Excluir = new System.Windows.Forms.ToolStripButton();
            this.bbBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BB_Fechar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.panelDados3 = new Componentes.PanelDados(this.components);
            this.LB_CD_Produto = new System.Windows.Forms.Label();
            this.CD_Grupo = new Componentes.EditDefault(this.components);
            this.BB_TpProduto = new System.Windows.Forms.Button();
            this.LB_CD_Grupo = new System.Windows.Forms.Label();
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.LB_DS_Produto = new System.Windows.Forms.Label();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.LB_TP_Produto = new System.Windows.Forms.Label();
            this.BB_GrupoProduto = new System.Windows.Forms.Button();
            this.TP_Produto = new Componentes.EditDefault(this.components);
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.gProduto = new Componentes.DataGridDefault(this.components);
            this.bsProduto = new System.Windows.Forms.BindingSource(this.components);
            this.st_cancelado = new Componentes.CheckBoxDefault(this.components);
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.siglaunidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSTpProdutoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ncmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsncmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BB_Imprimir = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.panelDados3.SuspendLayout();
            this.panelDados2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).BeginInit();
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
            this.BB_Imprimir,
            this.toolStripSeparator1,
            this.BB_Fechar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(796, 43);
            this.barraMenu.TabIndex = 8;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 401);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.panelDados3);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 3);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(790, 59);
            this.panelDados1.TabIndex = 0;
            // 
            // panelDados3
            // 
            this.panelDados3.Controls.Add(this.st_cancelado);
            this.panelDados3.Controls.Add(this.LB_CD_Produto);
            this.panelDados3.Controls.Add(this.CD_Grupo);
            this.panelDados3.Controls.Add(this.BB_TpProduto);
            this.panelDados3.Controls.Add(this.LB_CD_Grupo);
            this.panelDados3.Controls.Add(this.DS_Produto);
            this.panelDados3.Controls.Add(this.LB_DS_Produto);
            this.panelDados3.Controls.Add(this.CD_Produto);
            this.panelDados3.Controls.Add(this.LB_TP_Produto);
            this.panelDados3.Controls.Add(this.BB_GrupoProduto);
            this.panelDados3.Controls.Add(this.TP_Produto);
            this.panelDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados3.Location = new System.Drawing.Point(0, 0);
            this.panelDados3.Name = "panelDados3";
            this.panelDados3.NM_ProcDeletar = "";
            this.panelDados3.NM_ProcGravar = "";
            this.panelDados3.Size = new System.Drawing.Size(790, 59);
            this.panelDados3.TabIndex = 0;
            // 
            // LB_CD_Produto
            // 
            this.LB_CD_Produto.AutoSize = true;
            this.LB_CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Produto.Location = new System.Drawing.Point(35, 7);
            this.LB_CD_Produto.Name = "LB_CD_Produto";
            this.LB_CD_Produto.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Produto.TabIndex = 898;
            this.LB_CD_Produto.Text = "Código:";
            this.LB_CD_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Grupo
            // 
            this.CD_Grupo.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Grupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Grupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Grupo.Location = new System.Drawing.Point(255, 4);
            this.CD_Grupo.Name = "CD_Grupo";
            this.CD_Grupo.NM_Alias = "a";
            this.CD_Grupo.NM_Campo = "CD_Grupo";
            this.CD_Grupo.NM_CampoBusca = "CD_Grupo";
            this.CD_Grupo.NM_Param = "@P_CD_GRUPO";
            this.CD_Grupo.QTD_Zero = 0;
            this.CD_Grupo.Size = new System.Drawing.Size(56, 20);
            this.CD_Grupo.ST_AutoInc = false;
            this.CD_Grupo.ST_DisableAuto = false;
            this.CD_Grupo.ST_Float = false;
            this.CD_Grupo.ST_Gravar = false;
            this.CD_Grupo.ST_Int = false;
            this.CD_Grupo.ST_LimpaCampo = true;
            this.CD_Grupo.ST_NotNull = false;
            this.CD_Grupo.ST_PrimaryKey = false;
            this.CD_Grupo.TabIndex = 901;
            this.CD_Grupo.TextOld = null;
            this.CD_Grupo.Leave += new System.EventHandler(this.CD_Grupo_Leave);
            // 
            // BB_TpProduto
            // 
            this.BB_TpProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_TpProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_TpProduto.Image")));
            this.BB_TpProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_TpProduto.Location = new System.Drawing.Point(491, 3);
            this.BB_TpProduto.Name = "BB_TpProduto";
            this.BB_TpProduto.Size = new System.Drawing.Size(30, 23);
            this.BB_TpProduto.TabIndex = 907;
            this.BB_TpProduto.UseVisualStyleBackColor = true;
            this.BB_TpProduto.Click += new System.EventHandler(this.BB_TpProduto_Click);
            // 
            // LB_CD_Grupo
            // 
            this.LB_CD_Grupo.AutoSize = true;
            this.LB_CD_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Grupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Grupo.Location = new System.Drawing.Point(182, 8);
            this.LB_CD_Grupo.Name = "LB_CD_Grupo";
            this.LB_CD_Grupo.Size = new System.Drawing.Size(67, 13);
            this.LB_CD_Grupo.TabIndex = 904;
            this.LB_CD_Grupo.Text = "Grupo Prod.:";
            this.LB_CD_Grupo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(84, 30);
            this.DS_Produto.MaxLength = 120;
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "a";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(529, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 900;
            this.DS_Produto.TextOld = null;
            // 
            // LB_DS_Produto
            // 
            this.LB_DS_Produto.AutoSize = true;
            this.LB_DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Produto.Location = new System.Drawing.Point(31, 33);
            this.LB_DS_Produto.Name = "LB_DS_Produto";
            this.LB_DS_Produto.Size = new System.Drawing.Size(47, 13);
            this.LB_DS_Produto.TabIndex = 902;
            this.LB_DS_Produto.Text = "Produto:";
            this.LB_DS_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.Color.White;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(84, 4);
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "a";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(92, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = true;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = false;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = false;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 899;
            this.CD_Produto.TextOld = null;
            // 
            // LB_TP_Produto
            // 
            this.LB_TP_Produto.AutoSize = true;
            this.LB_TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_TP_Produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_TP_Produto.Location = new System.Drawing.Point(354, 8);
            this.LB_TP_Produto.Name = "LB_TP_Produto";
            this.LB_TP_Produto.Size = new System.Drawing.Size(71, 13);
            this.LB_TP_Produto.TabIndex = 905;
            this.LB_TP_Produto.Text = "Tipo Produto:";
            this.LB_TP_Produto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BB_GrupoProduto
            // 
            this.BB_GrupoProduto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BB_GrupoProduto.Image = ((System.Drawing.Image)(resources.GetObject("BB_GrupoProduto.Image")));
            this.BB_GrupoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_GrupoProduto.Location = new System.Drawing.Point(315, 4);
            this.BB_GrupoProduto.Name = "BB_GrupoProduto";
            this.BB_GrupoProduto.Size = new System.Drawing.Size(30, 23);
            this.BB_GrupoProduto.TabIndex = 903;
            this.BB_GrupoProduto.UseVisualStyleBackColor = true;
            this.BB_GrupoProduto.Click += new System.EventHandler(this.BB_GrupoProduto_Click);
            // 
            // TP_Produto
            // 
            this.TP_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.TP_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TP_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TP_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TP_Produto.Location = new System.Drawing.Point(431, 5);
            this.TP_Produto.Name = "TP_Produto";
            this.TP_Produto.NM_Alias = "a";
            this.TP_Produto.NM_Campo = "TP_Produto";
            this.TP_Produto.NM_CampoBusca = "TP_Produto";
            this.TP_Produto.NM_Param = "@P_TP_PRODUTO";
            this.TP_Produto.QTD_Zero = 0;
            this.TP_Produto.Size = new System.Drawing.Size(56, 20);
            this.TP_Produto.ST_AutoInc = false;
            this.TP_Produto.ST_DisableAuto = false;
            this.TP_Produto.ST_Float = false;
            this.TP_Produto.ST_Gravar = false;
            this.TP_Produto.ST_Int = false;
            this.TP_Produto.ST_LimpaCampo = true;
            this.TP_Produto.ST_NotNull = false;
            this.TP_Produto.ST_PrimaryKey = false;
            this.TP_Produto.TabIndex = 906;
            this.TP_Produto.TextOld = null;
            this.TP_Produto.Leave += new System.EventHandler(this.TP_Produto_Leave);
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.gProduto);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 68);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(790, 330);
            this.panelDados2.TabIndex = 1;
            // 
            // gProduto
            // 
            this.gProduto.AllowUserToAddRows = false;
            this.gProduto.AllowUserToDeleteRows = false;
            this.gProduto.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gProduto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gProduto.AutoGenerateColumns = false;
            this.gProduto.BackgroundColor = System.Drawing.Color.LightGray;
            this.gProduto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.cDProdutoDataGridViewTextBoxColumn,
            this.dSProdutoDataGridViewTextBoxColumn,
            this.siglaunidadeDataGridViewTextBoxColumn,
            this.cDGrupoDataGridViewTextBoxColumn,
            this.dSGrupoDataGridViewTextBoxColumn,
            this.dSTpProdutoDataGridViewTextBoxColumn,
            this.ncmDataGridViewTextBoxColumn,
            this.dsncmDataGridViewTextBoxColumn});
            this.gProduto.DataSource = this.bsProduto;
            this.gProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gProduto.Location = new System.Drawing.Point(0, 0);
            this.gProduto.Name = "gProduto";
            this.gProduto.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gProduto.RowHeadersWidth = 23;
            this.gProduto.Size = new System.Drawing.Size(790, 330);
            this.gProduto.TabIndex = 0;
            this.gProduto.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gProduto_CellFormatting);
            // 
            // bsProduto
            // 
            this.bsProduto.DataSource = typeof(CamadaDados.Estoque.Cadastros.TList_CadProduto);
            // 
            // st_cancelado
            // 
            this.st_cancelado.AutoSize = true;
            this.st_cancelado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_cancelado.ForeColor = System.Drawing.Color.Red;
            this.st_cancelado.Location = new System.Drawing.Point(527, 7);
            this.st_cancelado.Name = "st_cancelado";
            this.st_cancelado.NM_Alias = "";
            this.st_cancelado.NM_Campo = "";
            this.st_cancelado.NM_Param = "";
            this.st_cancelado.Size = new System.Drawing.Size(86, 17);
            this.st_cancelado.ST_Gravar = false;
            this.st_cancelado.ST_LimparCampo = true;
            this.st_cancelado.ST_NotNull = false;
            this.st_cancelado.TabIndex = 908;
            this.st_cancelado.Text = "Cancelado";
            this.st_cancelado.UseVisualStyleBackColor = true;
            this.st_cancelado.Vl_False = "";
            this.st_cancelado.Vl_True = "";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Cancelado";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 64;
            // 
            // cDProdutoDataGridViewTextBoxColumn
            // 
            this.cDProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cDProdutoDataGridViewTextBoxColumn.DataPropertyName = "CD_Produto";
            this.cDProdutoDataGridViewTextBoxColumn.HeaderText = "Cd. Produto";
            this.cDProdutoDataGridViewTextBoxColumn.Name = "cDProdutoDataGridViewTextBoxColumn";
            this.cDProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cDProdutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // dSProdutoDataGridViewTextBoxColumn
            // 
            this.dSProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_Produto";
            this.dSProdutoDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.dSProdutoDataGridViewTextBoxColumn.Name = "dSProdutoDataGridViewTextBoxColumn";
            this.dSProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSProdutoDataGridViewTextBoxColumn.Width = 69;
            // 
            // siglaunidadeDataGridViewTextBoxColumn
            // 
            this.siglaunidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.siglaunidadeDataGridViewTextBoxColumn.DataPropertyName = "Sigla_unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.HeaderText = "Unidade";
            this.siglaunidadeDataGridViewTextBoxColumn.Name = "siglaunidadeDataGridViewTextBoxColumn";
            this.siglaunidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.siglaunidadeDataGridViewTextBoxColumn.Width = 72;
            // 
            // cDGrupoDataGridViewTextBoxColumn
            // 
            this.cDGrupoDataGridViewTextBoxColumn.DataPropertyName = "CD_Grupo";
            this.cDGrupoDataGridViewTextBoxColumn.HeaderText = "Cd. Grupo";
            this.cDGrupoDataGridViewTextBoxColumn.Name = "cDGrupoDataGridViewTextBoxColumn";
            this.cDGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSGrupoDataGridViewTextBoxColumn
            // 
            this.dSGrupoDataGridViewTextBoxColumn.DataPropertyName = "DS_Grupo";
            this.dSGrupoDataGridViewTextBoxColumn.HeaderText = "Ds. Grupo";
            this.dSGrupoDataGridViewTextBoxColumn.Name = "dSGrupoDataGridViewTextBoxColumn";
            this.dSGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSTpProdutoDataGridViewTextBoxColumn
            // 
            this.dSTpProdutoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dSTpProdutoDataGridViewTextBoxColumn.DataPropertyName = "DS_TpProduto";
            this.dSTpProdutoDataGridViewTextBoxColumn.HeaderText = "Tp. Produto";
            this.dSTpProdutoDataGridViewTextBoxColumn.Name = "dSTpProdutoDataGridViewTextBoxColumn";
            this.dSTpProdutoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dSTpProdutoDataGridViewTextBoxColumn.Width = 88;
            // 
            // ncmDataGridViewTextBoxColumn
            // 
            this.ncmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ncmDataGridViewTextBoxColumn.DataPropertyName = "Ncm";
            this.ncmDataGridViewTextBoxColumn.HeaderText = "Ncm";
            this.ncmDataGridViewTextBoxColumn.Name = "ncmDataGridViewTextBoxColumn";
            this.ncmDataGridViewTextBoxColumn.ReadOnly = true;
            this.ncmDataGridViewTextBoxColumn.Width = 54;
            // 
            // dsncmDataGridViewTextBoxColumn
            // 
            this.dsncmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsncmDataGridViewTextBoxColumn.DataPropertyName = "Ds_ncm";
            this.dsncmDataGridViewTextBoxColumn.HeaderText = "Ds. Ncm";
            this.dsncmDataGridViewTextBoxColumn.Name = "dsncmDataGridViewTextBoxColumn";
            this.dsncmDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsncmDataGridViewTextBoxColumn.Width = 73;
            // 
            // BB_Imprimir
            // 
            this.BB_Imprimir.AutoSize = false;
            this.BB_Imprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BB_Imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.BB_Imprimir.ForeColor = System.Drawing.Color.Green;
            this.BB_Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("BB_Imprimir.Image")));
            this.BB_Imprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Imprimir.Name = "BB_Imprimir";
            this.BB_Imprimir.Size = new System.Drawing.Size(95, 40);
            this.BB_Imprimir.Text = "(F8)\r\nVisualizar";
            this.BB_Imprimir.ToolTipText = "Imprimir Registros";
            this.BB_Imprimir.Click += new System.EventHandler(this.BB_Imprimir_Click);
            // 
            // FProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 444);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FProduto";
            this.ShowInTaskbar = false;
            this.Text = "Cadastro de produto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FProduto_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados3.ResumeLayout(false);
            this.panelDados3.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Novo;
        public System.Windows.Forms.ToolStripButton BB_Alterar;
        public System.Windows.Forms.ToolStripButton BB_Excluir;
        private System.Windows.Forms.ToolStripButton bbBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton BB_Fechar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private Componentes.PanelDados panelDados2;
        private Componentes.DataGridDefault gProduto;
        private System.Windows.Forms.BindingSource bsProduto;
        private Componentes.PanelDados panelDados3;
        private System.Windows.Forms.Label LB_CD_Produto;
        private Componentes.EditDefault CD_Grupo;
        public System.Windows.Forms.Button BB_TpProduto;
        private System.Windows.Forms.Label LB_CD_Grupo;
        private Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.Label LB_DS_Produto;
        private Componentes.EditDefault CD_Produto;
        private System.Windows.Forms.Label LB_TP_Produto;
        public System.Windows.Forms.Button BB_GrupoProduto;
        private Componentes.EditDefault TP_Produto;
        private Componentes.CheckBoxDefault st_cancelado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn siglaunidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dSTpProdutoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ncmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsncmDataGridViewTextBoxColumn;
        public System.Windows.Forms.ToolStripButton BB_Imprimir;
    }
}