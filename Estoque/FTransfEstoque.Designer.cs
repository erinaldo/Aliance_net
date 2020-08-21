namespace Estoque
{
    partial class TFTransfEstoque
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label cd_empresaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFTransfEstoque));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsTransf = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.editDefault2 = new Componentes.EditDefault(this.components);
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.bb_empresadest = new System.Windows.Forms.Button();
            this.nm_empresadest = new Componentes.EditDefault(this.components);
            this.cd_empresadest = new Componentes.EditDefault(this.components);
            this.ds_transf = new Componentes.EditDefault(this.components);
            this.DT_Lancto = new Componentes.EditData(this.components);
            this.pd_lancar = new Componentes.PanelDados(this.components);
            this.editDefault3 = new Componentes.EditDefault(this.components);
            this.DS_Observacao = new System.Windows.Forms.TextBox();
            this.Quantidade = new Componentes.EditFloat(this.components);
            this.Qtde_localOrigem = new Componentes.EditFloat(this.components);
            this.Qtde_localDestino = new Componentes.EditFloat(this.components);
            this.BB_LocalDest = new System.Windows.Forms.Button();
            this.NM_Local_Dest = new Componentes.EditDefault(this.components);
            this.CD_Local_Dest = new Componentes.EditDefault(this.components);
            this.BB_Local_Origem = new System.Windows.Forms.Button();
            this.NM_Local_Origem = new Componentes.EditDefault(this.components);
            this.CD_Local_Orig = new Componentes.EditDefault(this.components);
            this.DS_Produto = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.bb_produto = new System.Windows.Forms.Button();
            this.CD_Produto = new Componentes.EditDefault(this.components);
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransf)).BeginInit();
            this.pDados.SuspendLayout();
            this.pd_lancar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtde_localOrigem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtde_localDestino)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(13, 106);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(93, 13);
            label10.TabIndex = 136;
            label10.Text = "Empresa Dest.:";
            label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(38, 8);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(68, 13);
            label8.TabIndex = 131;
            label8.Text = "Descrição:";
            label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label9.Location = new System.Drawing.Point(497, 9);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(38, 13);
            label9.TabIndex = 130;
            label9.Text = "Data:";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(21, 32);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(79, 13);
            label6.TabIndex = 106;
            label6.Text = "Observação:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(23, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(76, 13);
            label4.TabIndex = 104;
            label4.Text = "Quantidade:";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(434, 80);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(43, 13);
            label7.TabIndex = 128;
            label7.Text = "Saldo:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(434, 132);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 13);
            label5.TabIndex = 127;
            label5.Text = "Saldo:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(4, 132);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(106, 13);
            label3.TabIndex = 126;
            label3.Text = "Cód. Local Dest.:";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(33, 79);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 13);
            label1.TabIndex = 125;
            label1.Text = "Local Orig.:";
            label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(51, 33);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 123;
            label2.Text = "Produto:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            cd_empresaLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_empresaLabel.Location = new System.Drawing.Point(16, 55);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(90, 13);
            cd_empresaLabel.TabIndex = 124;
            cd_empresaLabel.Text = "Empresa Orig.:";
            cd_empresaLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(622, 43);
            this.barraMenu.TabIndex = 4;
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
            // bsTransf
            // 
            this.bsTransf.DataSource = typeof(CamadaDados.Estoque.TList_TransfLocal);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.editDefault2);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.bb_empresadest);
            this.pDados.Controls.Add(this.nm_empresadest);
            this.pDados.Controls.Add(label10);
            this.pDados.Controls.Add(this.cd_empresadest);
            this.pDados.Controls.Add(this.ds_transf);
            this.pDados.Controls.Add(label8);
            this.pDados.Controls.Add(label9);
            this.pDados.Controls.Add(this.DT_Lancto);
            this.pDados.Controls.Add(this.pd_lancar);
            this.pDados.Controls.Add(this.Qtde_localOrigem);
            this.pDados.Controls.Add(label7);
            this.pDados.Controls.Add(this.Qtde_localDestino);
            this.pDados.Controls.Add(label5);
            this.pDados.Controls.Add(this.BB_LocalDest);
            this.pDados.Controls.Add(this.NM_Local_Dest);
            this.pDados.Controls.Add(this.CD_Local_Dest);
            this.pDados.Controls.Add(label3);
            this.pDados.Controls.Add(this.BB_Local_Origem);
            this.pDados.Controls.Add(this.NM_Local_Origem);
            this.pDados.Controls.Add(label1);
            this.pDados.Controls.Add(this.CD_Local_Orig);
            this.pDados.Controls.Add(this.DS_Produto);
            this.pDados.Controls.Add(this.bb_empresa);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(label2);
            this.pDados.Controls.Add(this.bb_produto);
            this.pDados.Controls.Add(this.CD_Produto);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(622, 275);
            this.pDados.TabIndex = 5;
            // 
            // editDefault2
            // 
            this.editDefault2.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault2.Enabled = false;
            this.editDefault2.Location = new System.Drawing.Point(585, 128);
            this.editDefault2.Name = "editDefault2";
            this.editDefault2.NM_Alias = "";
            this.editDefault2.NM_Campo = "";
            this.editDefault2.NM_CampoBusca = "";
            this.editDefault2.NM_Param = "";
            this.editDefault2.QTD_Zero = 0;
            this.editDefault2.Size = new System.Drawing.Size(27, 20);
            this.editDefault2.ST_AutoInc = false;
            this.editDefault2.ST_DisableAuto = false;
            this.editDefault2.ST_Float = false;
            this.editDefault2.ST_Gravar = false;
            this.editDefault2.ST_Int = false;
            this.editDefault2.ST_LimpaCampo = true;
            this.editDefault2.ST_NotNull = false;
            this.editDefault2.ST_PrimaryKey = false;
            this.editDefault2.TabIndex = 138;
            this.editDefault2.TextOld = null;
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Enabled = false;
            this.editDefault1.Location = new System.Drawing.Point(585, 77);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(27, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 137;
            this.editDefault1.TextOld = null;
            // 
            // bb_empresadest
            // 
            this.bb_empresadest.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresadest.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresadest.Image")));
            this.bb_empresadest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresadest.Location = new System.Drawing.Point(182, 103);
            this.bb_empresadest.Name = "bb_empresadest";
            this.bb_empresadest.Size = new System.Drawing.Size(28, 19);
            this.bb_empresadest.TabIndex = 9;
            this.bb_empresadest.UseVisualStyleBackColor = false;
            this.bb_empresadest.Click += new System.EventHandler(this.bb_empresadest_Click);
            // 
            // nm_empresadest
            // 
            this.nm_empresadest.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresadest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_empresadest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresadest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Nm_empresadestino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_empresadest.Enabled = false;
            this.nm_empresadest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nm_empresadest.Location = new System.Drawing.Point(212, 103);
            this.nm_empresadest.Name = "nm_empresadest";
            this.nm_empresadest.NM_Alias = "";
            this.nm_empresadest.NM_Campo = "NM_Empresa";
            this.nm_empresadest.NM_CampoBusca = "NM_Empresa";
            this.nm_empresadest.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresadest.QTD_Zero = 0;
            this.nm_empresadest.Size = new System.Drawing.Size(400, 20);
            this.nm_empresadest.ST_AutoInc = false;
            this.nm_empresadest.ST_DisableAuto = false;
            this.nm_empresadest.ST_Float = false;
            this.nm_empresadest.ST_Gravar = false;
            this.nm_empresadest.ST_Int = false;
            this.nm_empresadest.ST_LimpaCampo = true;
            this.nm_empresadest.ST_NotNull = false;
            this.nm_empresadest.ST_PrimaryKey = false;
            this.nm_empresadest.TabIndex = 135;
            this.nm_empresadest.TextOld = null;
            // 
            // cd_empresadest
            // 
            this.cd_empresadest.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresadest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresadest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresadest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Cd_empresadestino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_empresadest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresadest.Location = new System.Drawing.Point(112, 103);
            this.cd_empresadest.MaxLength = 4;
            this.cd_empresadest.Name = "cd_empresadest";
            this.cd_empresadest.NM_Alias = "";
            this.cd_empresadest.NM_Campo = "CD_Empresa";
            this.cd_empresadest.NM_CampoBusca = "CD_Empresa";
            this.cd_empresadest.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresadest.QTD_Zero = 0;
            this.cd_empresadest.Size = new System.Drawing.Size(69, 20);
            this.cd_empresadest.ST_AutoInc = false;
            this.cd_empresadest.ST_DisableAuto = false;
            this.cd_empresadest.ST_Float = false;
            this.cd_empresadest.ST_Gravar = true;
            this.cd_empresadest.ST_Int = false;
            this.cd_empresadest.ST_LimpaCampo = true;
            this.cd_empresadest.ST_NotNull = true;
            this.cd_empresadest.ST_PrimaryKey = false;
            this.cd_empresadest.TabIndex = 8;
            this.cd_empresadest.TextOld = null;
            this.cd_empresadest.Leave += new System.EventHandler(this.cd_empresadest_Leave);
            // 
            // ds_transf
            // 
            this.ds_transf.BackColor = System.Drawing.SystemColors.Window;
            this.ds_transf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_transf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_transf.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Ds_transf", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_transf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_transf.Location = new System.Drawing.Point(112, 5);
            this.ds_transf.Name = "ds_transf";
            this.ds_transf.NM_Alias = "";
            this.ds_transf.NM_Campo = "CD_Produto";
            this.ds_transf.NM_CampoBusca = "CD_Produto";
            this.ds_transf.NM_Param = "@P_CD_PRODUTO";
            this.ds_transf.QTD_Zero = 0;
            this.ds_transf.Size = new System.Drawing.Size(379, 20);
            this.ds_transf.ST_AutoInc = false;
            this.ds_transf.ST_DisableAuto = false;
            this.ds_transf.ST_Float = false;
            this.ds_transf.ST_Gravar = true;
            this.ds_transf.ST_Int = false;
            this.ds_transf.ST_LimpaCampo = true;
            this.ds_transf.ST_NotNull = false;
            this.ds_transf.ST_PrimaryKey = false;
            this.ds_transf.TabIndex = 0;
            this.ds_transf.TextOld = null;
            // 
            // DT_Lancto
            // 
            this.DT_Lancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Lancto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Dt_lanctostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Lancto.Location = new System.Drawing.Point(541, 5);
            this.DT_Lancto.Mask = "00/00/0000";
            this.DT_Lancto.Name = "DT_Lancto";
            this.DT_Lancto.NM_Alias = "";
            this.DT_Lancto.NM_Campo = "DT_Lancto";
            this.DT_Lancto.NM_CampoBusca = "DT_Lancto";
            this.DT_Lancto.NM_Param = "@P_DT_LANCTO";
            this.DT_Lancto.Operador = "";
            this.DT_Lancto.Size = new System.Drawing.Size(71, 20);
            this.DT_Lancto.ST_Gravar = false;
            this.DT_Lancto.ST_LimpaCampo = true;
            this.DT_Lancto.ST_NotNull = true;
            this.DT_Lancto.ST_PrimaryKey = false;
            this.DT_Lancto.TabIndex = 1;
            // 
            // pd_lancar
            // 
            this.pd_lancar.BackColor = System.Drawing.SystemColors.Control;
            this.pd_lancar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pd_lancar.Controls.Add(this.editDefault3);
            this.pd_lancar.Controls.Add(label6);
            this.pd_lancar.Controls.Add(this.DS_Observacao);
            this.pd_lancar.Controls.Add(this.Quantidade);
            this.pd_lancar.Controls.Add(label4);
            this.pd_lancar.Location = new System.Drawing.Point(112, 155);
            this.pd_lancar.Name = "pd_lancar";
            this.pd_lancar.NM_ProcDeletar = "";
            this.pd_lancar.NM_ProcGravar = "";
            this.pd_lancar.Size = new System.Drawing.Size(500, 110);
            this.pd_lancar.TabIndex = 12;
            // 
            // editDefault3
            // 
            this.editDefault3.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Sigla_unidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault3.Enabled = false;
            this.editDefault3.Location = new System.Drawing.Point(235, 3);
            this.editDefault3.Name = "editDefault3";
            this.editDefault3.NM_Alias = "";
            this.editDefault3.NM_Campo = "";
            this.editDefault3.NM_CampoBusca = "";
            this.editDefault3.NM_Param = "";
            this.editDefault3.QTD_Zero = 0;
            this.editDefault3.Size = new System.Drawing.Size(27, 20);
            this.editDefault3.ST_AutoInc = false;
            this.editDefault3.ST_DisableAuto = false;
            this.editDefault3.ST_Float = false;
            this.editDefault3.ST_Gravar = false;
            this.editDefault3.ST_Int = false;
            this.editDefault3.ST_LimpaCampo = true;
            this.editDefault3.ST_NotNull = false;
            this.editDefault3.ST_PrimaryKey = false;
            this.editDefault3.TabIndex = 138;
            this.editDefault3.TextOld = null;
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Location = new System.Drawing.Point(104, 29);
            this.DS_Observacao.MaxLength = 1024;
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.Size = new System.Drawing.Size(389, 65);
            this.DS_Observacao.TabIndex = 1;
            // 
            // Quantidade
            // 
            this.Quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsTransf, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Quantidade.DecimalPlaces = 3;
            this.Quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Quantidade.Location = new System.Drawing.Point(104, 3);
            this.Quantidade.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.NM_Alias = "";
            this.Quantidade.NM_Campo = "";
            this.Quantidade.NM_Param = "";
            this.Quantidade.Operador = "";
            this.Quantidade.Size = new System.Drawing.Size(132, 20);
            this.Quantidade.ST_AutoInc = false;
            this.Quantidade.ST_DisableAuto = false;
            this.Quantidade.ST_Gravar = true;
            this.Quantidade.ST_LimparCampo = true;
            this.Quantidade.ST_NotNull = true;
            this.Quantidade.ST_PrimaryKey = false;
            this.Quantidade.TabIndex = 0;
            this.Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Quantidade.ThousandsSeparator = true;
            this.Quantidade.Leave += new System.EventHandler(this.Quantidade_Leave);
            // 
            // Qtde_localOrigem
            // 
            this.Qtde_localOrigem.DecimalPlaces = 3;
            this.Qtde_localOrigem.Enabled = false;
            this.Qtde_localOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Qtde_localOrigem.Location = new System.Drawing.Point(475, 77);
            this.Qtde_localOrigem.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.Qtde_localOrigem.Name = "Qtde_localOrigem";
            this.Qtde_localOrigem.NM_Alias = "";
            this.Qtde_localOrigem.NM_Campo = "";
            this.Qtde_localOrigem.NM_Param = "";
            this.Qtde_localOrigem.Operador = "";
            this.Qtde_localOrigem.Size = new System.Drawing.Size(111, 20);
            this.Qtde_localOrigem.ST_AutoInc = false;
            this.Qtde_localOrigem.ST_DisableAuto = true;
            this.Qtde_localOrigem.ST_Gravar = false;
            this.Qtde_localOrigem.ST_LimparCampo = true;
            this.Qtde_localOrigem.ST_NotNull = false;
            this.Qtde_localOrigem.ST_PrimaryKey = false;
            this.Qtde_localOrigem.TabIndex = 117;
            this.Qtde_localOrigem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Qtde_localOrigem.ThousandsSeparator = true;
            // 
            // Qtde_localDestino
            // 
            this.Qtde_localDestino.DecimalPlaces = 3;
            this.Qtde_localDestino.Enabled = false;
            this.Qtde_localDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Qtde_localDestino.Location = new System.Drawing.Point(475, 129);
            this.Qtde_localDestino.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.Qtde_localDestino.Name = "Qtde_localDestino";
            this.Qtde_localDestino.NM_Alias = "";
            this.Qtde_localDestino.NM_Campo = "";
            this.Qtde_localDestino.NM_Param = "";
            this.Qtde_localDestino.Operador = "";
            this.Qtde_localDestino.Size = new System.Drawing.Size(111, 20);
            this.Qtde_localDestino.ST_AutoInc = false;
            this.Qtde_localDestino.ST_DisableAuto = true;
            this.Qtde_localDestino.ST_Gravar = false;
            this.Qtde_localDestino.ST_LimparCampo = true;
            this.Qtde_localDestino.ST_NotNull = false;
            this.Qtde_localDestino.ST_PrimaryKey = false;
            this.Qtde_localDestino.TabIndex = 121;
            this.Qtde_localDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Qtde_localDestino.ThousandsSeparator = true;
            // 
            // BB_LocalDest
            // 
            this.BB_LocalDest.BackColor = System.Drawing.SystemColors.Control;
            this.BB_LocalDest.Image = ((System.Drawing.Image)(resources.GetObject("BB_LocalDest.Image")));
            this.BB_LocalDest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_LocalDest.Location = new System.Drawing.Point(182, 129);
            this.BB_LocalDest.Name = "BB_LocalDest";
            this.BB_LocalDest.Size = new System.Drawing.Size(28, 19);
            this.BB_LocalDest.TabIndex = 11;
            this.BB_LocalDest.UseVisualStyleBackColor = false;
            this.BB_LocalDest.Click += new System.EventHandler(this.BB_LocalDest_Click);
            // 
            // NM_Local_Dest
            // 
            this.NM_Local_Dest.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Local_Dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Local_Dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Local_Dest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Ds_localdestino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Local_Dest.Enabled = false;
            this.NM_Local_Dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Local_Dest.Location = new System.Drawing.Point(212, 129);
            this.NM_Local_Dest.Name = "NM_Local_Dest";
            this.NM_Local_Dest.NM_Alias = "";
            this.NM_Local_Dest.NM_Campo = "NM_Local_Dest";
            this.NM_Local_Dest.NM_CampoBusca = "DS_Local";
            this.NM_Local_Dest.NM_Param = "@P_DS_LOCAL";
            this.NM_Local_Dest.QTD_Zero = 0;
            this.NM_Local_Dest.Size = new System.Drawing.Size(216, 20);
            this.NM_Local_Dest.ST_AutoInc = false;
            this.NM_Local_Dest.ST_DisableAuto = false;
            this.NM_Local_Dest.ST_Float = false;
            this.NM_Local_Dest.ST_Gravar = false;
            this.NM_Local_Dest.ST_Int = false;
            this.NM_Local_Dest.ST_LimpaCampo = true;
            this.NM_Local_Dest.ST_NotNull = false;
            this.NM_Local_Dest.ST_PrimaryKey = false;
            this.NM_Local_Dest.TabIndex = 120;
            this.NM_Local_Dest.TextOld = null;
            // 
            // CD_Local_Dest
            // 
            this.CD_Local_Dest.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local_Dest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local_Dest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local_Dest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Cd_localdestino", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local_Dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Local_Dest.Location = new System.Drawing.Point(112, 129);
            this.CD_Local_Dest.MaxLength = 7;
            this.CD_Local_Dest.Name = "CD_Local_Dest";
            this.CD_Local_Dest.NM_Alias = "";
            this.CD_Local_Dest.NM_Campo = "CD_Local_Dest";
            this.CD_Local_Dest.NM_CampoBusca = "CD_Local";
            this.CD_Local_Dest.NM_Param = "@P_CD_LOCAL";
            this.CD_Local_Dest.QTD_Zero = 0;
            this.CD_Local_Dest.Size = new System.Drawing.Size(69, 20);
            this.CD_Local_Dest.ST_AutoInc = false;
            this.CD_Local_Dest.ST_DisableAuto = false;
            this.CD_Local_Dest.ST_Float = false;
            this.CD_Local_Dest.ST_Gravar = true;
            this.CD_Local_Dest.ST_Int = false;
            this.CD_Local_Dest.ST_LimpaCampo = true;
            this.CD_Local_Dest.ST_NotNull = true;
            this.CD_Local_Dest.ST_PrimaryKey = false;
            this.CD_Local_Dest.TabIndex = 10;
            this.CD_Local_Dest.TextOld = null;
            this.CD_Local_Dest.Leave += new System.EventHandler(this.CD_Local_Dest_Leave);
            // 
            // BB_Local_Origem
            // 
            this.BB_Local_Origem.BackColor = System.Drawing.SystemColors.Control;
            this.BB_Local_Origem.Image = ((System.Drawing.Image)(resources.GetObject("BB_Local_Origem.Image")));
            this.BB_Local_Origem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Local_Origem.Location = new System.Drawing.Point(182, 77);
            this.BB_Local_Origem.Name = "BB_Local_Origem";
            this.BB_Local_Origem.Size = new System.Drawing.Size(28, 19);
            this.BB_Local_Origem.TabIndex = 7;
            this.BB_Local_Origem.UseVisualStyleBackColor = false;
            this.BB_Local_Origem.Click += new System.EventHandler(this.BB_Local_Origem_Click);
            // 
            // NM_Local_Origem
            // 
            this.NM_Local_Origem.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Local_Origem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Local_Origem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Local_Origem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Ds_localorigem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Local_Origem.Enabled = false;
            this.NM_Local_Origem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Local_Origem.Location = new System.Drawing.Point(212, 77);
            this.NM_Local_Origem.Name = "NM_Local_Origem";
            this.NM_Local_Origem.NM_Alias = "";
            this.NM_Local_Origem.NM_Campo = "NM_Local_Origem";
            this.NM_Local_Origem.NM_CampoBusca = "DS_Local";
            this.NM_Local_Origem.NM_Param = "@P_DS_LOCAL";
            this.NM_Local_Origem.QTD_Zero = 0;
            this.NM_Local_Origem.Size = new System.Drawing.Size(216, 20);
            this.NM_Local_Origem.ST_AutoInc = false;
            this.NM_Local_Origem.ST_DisableAuto = false;
            this.NM_Local_Origem.ST_Float = false;
            this.NM_Local_Origem.ST_Gravar = false;
            this.NM_Local_Origem.ST_Int = false;
            this.NM_Local_Origem.ST_LimpaCampo = true;
            this.NM_Local_Origem.ST_NotNull = false;
            this.NM_Local_Origem.ST_PrimaryKey = false;
            this.NM_Local_Origem.TabIndex = 116;
            this.NM_Local_Origem.TextOld = null;
            // 
            // CD_Local_Orig
            // 
            this.CD_Local_Orig.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Local_Orig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Local_Orig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Local_Orig.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Cd_localorigem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Local_Orig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Local_Orig.Location = new System.Drawing.Point(112, 77);
            this.CD_Local_Orig.MaxLength = 7;
            this.CD_Local_Orig.Name = "CD_Local_Orig";
            this.CD_Local_Orig.NM_Alias = "";
            this.CD_Local_Orig.NM_Campo = "CD_Local_Orig";
            this.CD_Local_Orig.NM_CampoBusca = "CD_Local";
            this.CD_Local_Orig.NM_Param = "@P_CD_LOCAL";
            this.CD_Local_Orig.QTD_Zero = 0;
            this.CD_Local_Orig.Size = new System.Drawing.Size(69, 20);
            this.CD_Local_Orig.ST_AutoInc = false;
            this.CD_Local_Orig.ST_DisableAuto = false;
            this.CD_Local_Orig.ST_Float = false;
            this.CD_Local_Orig.ST_Gravar = true;
            this.CD_Local_Orig.ST_Int = false;
            this.CD_Local_Orig.ST_LimpaCampo = true;
            this.CD_Local_Orig.ST_NotNull = true;
            this.CD_Local_Orig.ST_PrimaryKey = false;
            this.CD_Local_Orig.TabIndex = 6;
            this.CD_Local_Orig.TextOld = null;
            this.CD_Local_Orig.Leave += new System.EventHandler(this.CD_Local_Orig_Leave);
            // 
            // DS_Produto
            // 
            this.DS_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Ds_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Produto.Enabled = false;
            this.DS_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Produto.Location = new System.Drawing.Point(212, 30);
            this.DS_Produto.Name = "DS_Produto";
            this.DS_Produto.NM_Alias = "";
            this.DS_Produto.NM_Campo = "DS_Produto";
            this.DS_Produto.NM_CampoBusca = "DS_Produto";
            this.DS_Produto.NM_Param = "@P_DS_PRODUTO";
            this.DS_Produto.QTD_Zero = 0;
            this.DS_Produto.Size = new System.Drawing.Size(400, 20);
            this.DS_Produto.ST_AutoInc = false;
            this.DS_Produto.ST_DisableAuto = false;
            this.DS_Produto.ST_Float = false;
            this.DS_Produto.ST_Gravar = false;
            this.DS_Produto.ST_Int = false;
            this.DS_Produto.ST_LimpaCampo = true;
            this.DS_Produto.ST_NotNull = false;
            this.DS_Produto.ST_PrimaryKey = false;
            this.DS_Produto.TabIndex = 110;
            this.DS_Produto.TextOld = null;
            // 
            // bb_empresa
            // 
            this.bb_empresa.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(182, 52);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 19);
            this.bb_empresa.TabIndex = 5;
            this.bb_empresa.UseVisualStyleBackColor = false;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Nm_empresaorigem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(212, 52);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "@P_NM_EMPRESA";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.Size = new System.Drawing.Size(400, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 113;
            this.NM_Empresa.TextOld = null;
            // 
            // bb_produto
            // 
            this.bb_produto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_produto.Image = ((System.Drawing.Image)(resources.GetObject("bb_produto.Image")));
            this.bb_produto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_produto.Location = new System.Drawing.Point(182, 30);
            this.bb_produto.Name = "bb_produto";
            this.bb_produto.Size = new System.Drawing.Size(28, 19);
            this.bb_produto.TabIndex = 3;
            this.bb_produto.UseVisualStyleBackColor = false;
            this.bb_produto.Click += new System.EventHandler(this.bb_produto_Click);
            // 
            // CD_Produto
            // 
            this.CD_Produto.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Produto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Produto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Cd_produto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Produto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Produto.Location = new System.Drawing.Point(112, 30);
            this.CD_Produto.MaxLength = 7;
            this.CD_Produto.Name = "CD_Produto";
            this.CD_Produto.NM_Alias = "";
            this.CD_Produto.NM_Campo = "CD_Produto";
            this.CD_Produto.NM_CampoBusca = "CD_Produto";
            this.CD_Produto.NM_Param = "@P_CD_PRODUTO";
            this.CD_Produto.QTD_Zero = 0;
            this.CD_Produto.Size = new System.Drawing.Size(69, 20);
            this.CD_Produto.ST_AutoInc = false;
            this.CD_Produto.ST_DisableAuto = false;
            this.CD_Produto.ST_Float = false;
            this.CD_Produto.ST_Gravar = true;
            this.CD_Produto.ST_Int = false;
            this.CD_Produto.ST_LimpaCampo = true;
            this.CD_Produto.ST_NotNull = true;
            this.CD_Produto.ST_PrimaryKey = false;
            this.CD_Produto.TabIndex = 2;
            this.CD_Produto.TextOld = null;
            this.CD_Produto.Leave += new System.EventHandler(this.CD_Produto_Leave);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTransf, "Cd_empresaorigem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(112, 52);
            this.CD_Empresa.MaxLength = 7;
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(69, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 4;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // TFTransfEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 318);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFTransfEstoque";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferencia Saldo Estoque";
            this.Load += new System.EventHandler(this.TFTransfEstoque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFTransfEstoque_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransf)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.pd_lancar.ResumeLayout(false);
            this.pd_lancar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtde_localOrigem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Qtde_localDestino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        public System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsTransf;
        private Componentes.EditData DT_Lancto;
        private Componentes.PanelDados pd_lancar;
        private System.Windows.Forms.TextBox DS_Observacao;
        private Componentes.EditFloat Quantidade;
        private Componentes.EditFloat Qtde_localOrigem;
        private Componentes.EditFloat Qtde_localDestino;
        private System.Windows.Forms.Button BB_LocalDest;
        private Componentes.EditDefault NM_Local_Dest;
        private Componentes.EditDefault CD_Local_Dest;
        private System.Windows.Forms.Button BB_Local_Origem;
        private Componentes.EditDefault NM_Local_Origem;
        private Componentes.EditDefault CD_Local_Orig;
        private Componentes.EditDefault DS_Produto;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button bb_produto;
        private Componentes.EditDefault CD_Produto;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Button bb_empresadest;
        private Componentes.EditDefault nm_empresadest;
        private Componentes.EditDefault cd_empresadest;
        private Componentes.EditDefault ds_transf;
        private Componentes.EditDefault editDefault1;
        private Componentes.EditDefault editDefault2;
        private Componentes.EditDefault editDefault3;
    }
}