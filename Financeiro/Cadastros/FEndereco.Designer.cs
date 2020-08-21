namespace Financeiro.Cadastros
{
    partial class TFEndereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEndereco));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cd_endereco = new System.Windows.Forms.ToolStripTextBox();
            this.bsEndereco = new System.Windows.Forms.BindingSource(this.components);
            this.pnl_Endereco = new Componentes.PanelDados(this.components);
            this.st_naocontribuinte = new Componentes.CheckBoxDefault(this.components);
            this.celular = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Longitude = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Latitude = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Fone_comercial = new Componentes.EditDefault(this.components);
            this.Fone = new Componentes.EditDefault(this.components);
            this.st_endcobranca = new Componentes.CheckBoxDefault(this.components);
            this.ST_EnderecoEntrega = new Componentes.CheckBoxDefault(this.components);
            this.Insc_Estadual = new Componentes.EditDefault(this.components);
            this.DS_Complemento = new Componentes.EditDefault(this.components);
            this.LB_Fax = new System.Windows.Forms.Label();
            this.NM_Pais = new Componentes.EditDefault(this.components);
            this.BB_Pais = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CD_PAIS = new Componentes.EditDefault(this.components);
            this.UF = new Componentes.EditDefault(this.components);
            this.Ds_Cidade = new Componentes.EditDefault(this.components);
            this.BB_Cidade = new System.Windows.Forms.Button();
            this.CD_Cidade = new Componentes.EditDefault(this.components);
            this.LB_Bairro = new System.Windows.Forms.Label();
            this.Bairro = new Componentes.EditDefault(this.components);
            this.CP = new Componentes.EditDefault(this.components);
            this.LB_Proximo = new System.Windows.Forms.Label();
            this.Proximo = new Componentes.EditDefault(this.components);
            this.Numero = new Componentes.EditDefault(this.components);
            this.LB_DS_Endereco = new System.Windows.Forms.Label();
            this.DS_Endereco = new Componentes.EditDefault(this.components);
            this.Cep = new Componentes.EditMask(this.components);
            this.LB_Numero = new System.Windows.Forms.Label();
            this.LB_Fone = new System.Windows.Forms.Label();
            this.LB_CD_Cidade = new System.Windows.Forms.Label();
            this.LB_Cep = new System.Windows.Forms.Label();
            this.LB_CP = new System.Windows.Forms.Label();
            this.LB_DS_Complemento = new System.Windows.Forms.Label();
            this.LB_Insc_Estadual = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEndereco)).BeginInit();
            this.pnl_Endereco.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cd_endereco});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(704, 43);
            this.barraMenu.TabIndex = 536;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Gravar.ForeColor = System.Drawing.Color.Green;
            this.BB_Gravar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Gravar.Image")));
            this.BB_Gravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BB_Gravar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Gravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Gravar.Name = "BB_Gravar";
            this.BB_Gravar.Size = new System.Drawing.Size(90, 40);
            this.BB_Gravar.Text = " (F4)\r\n Gravar";
            this.BB_Gravar.ToolTipText = "Gravar Registro";
            this.BB_Gravar.Click += new System.EventHandler(this.BB_Gravar_Click);
            // 
            // BB_Cancelar
            // 
            this.BB_Cancelar.AutoSize = false;
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Cancelar.ForeColor = System.Drawing.Color.Green;
            this.BB_Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cancelar.Image")));
            this.BB_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BB_Cancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BB_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BB_Cancelar.Name = "BB_Cancelar";
            this.BB_Cancelar.Size = new System.Drawing.Size(110, 40);
            this.BB_Cancelar.Text = "(F6)\r\n Cancelar";
            this.BB_Cancelar.ToolTipText = "Cancelar Operação";
            this.BB_Cancelar.Click += new System.EventHandler(this.BB_Cancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(82, 40);
            this.toolStripLabel1.Text = "Codigo:";
            // 
            // cd_endereco
            // 
            this.cd_endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_endereco.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.cd_endereco.Name = "cd_endereco";
            this.cd_endereco.Size = new System.Drawing.Size(100, 43);
            // 
            // bsEndereco
            // 
            this.bsEndereco.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadEndereco);
            this.bsEndereco.PositionChanged += new System.EventHandler(this.bsEndereco_PositionChanged);
            // 
            // pnl_Endereco
            // 
            this.pnl_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Endereco.Controls.Add(this.st_naocontribuinte);
            this.pnl_Endereco.Controls.Add(this.celular);
            this.pnl_Endereco.Controls.Add(this.label3);
            this.pnl_Endereco.Controls.Add(this.Longitude);
            this.pnl_Endereco.Controls.Add(this.label2);
            this.pnl_Endereco.Controls.Add(this.Latitude);
            this.pnl_Endereco.Controls.Add(this.label1);
            this.pnl_Endereco.Controls.Add(this.Fone_comercial);
            this.pnl_Endereco.Controls.Add(this.Fone);
            this.pnl_Endereco.Controls.Add(this.st_endcobranca);
            this.pnl_Endereco.Controls.Add(this.ST_EnderecoEntrega);
            this.pnl_Endereco.Controls.Add(this.Insc_Estadual);
            this.pnl_Endereco.Controls.Add(this.DS_Complemento);
            this.pnl_Endereco.Controls.Add(this.LB_Fax);
            this.pnl_Endereco.Controls.Add(this.NM_Pais);
            this.pnl_Endereco.Controls.Add(this.BB_Pais);
            this.pnl_Endereco.Controls.Add(this.label4);
            this.pnl_Endereco.Controls.Add(this.CD_PAIS);
            this.pnl_Endereco.Controls.Add(this.UF);
            this.pnl_Endereco.Controls.Add(this.Ds_Cidade);
            this.pnl_Endereco.Controls.Add(this.BB_Cidade);
            this.pnl_Endereco.Controls.Add(this.CD_Cidade);
            this.pnl_Endereco.Controls.Add(this.LB_Bairro);
            this.pnl_Endereco.Controls.Add(this.Bairro);
            this.pnl_Endereco.Controls.Add(this.CP);
            this.pnl_Endereco.Controls.Add(this.LB_Proximo);
            this.pnl_Endereco.Controls.Add(this.Proximo);
            this.pnl_Endereco.Controls.Add(this.Numero);
            this.pnl_Endereco.Controls.Add(this.LB_DS_Endereco);
            this.pnl_Endereco.Controls.Add(this.DS_Endereco);
            this.pnl_Endereco.Controls.Add(this.Cep);
            this.pnl_Endereco.Controls.Add(this.LB_Numero);
            this.pnl_Endereco.Controls.Add(this.LB_Fone);
            this.pnl_Endereco.Controls.Add(this.LB_CD_Cidade);
            this.pnl_Endereco.Controls.Add(this.LB_Cep);
            this.pnl_Endereco.Controls.Add(this.LB_CP);
            this.pnl_Endereco.Controls.Add(this.LB_DS_Complemento);
            this.pnl_Endereco.Controls.Add(this.LB_Insc_Estadual);
            this.pnl_Endereco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Endereco.Location = new System.Drawing.Point(0, 43);
            this.pnl_Endereco.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_Endereco.Name = "pnl_Endereco";
            this.pnl_Endereco.NM_ProcDeletar = "";
            this.pnl_Endereco.NM_ProcGravar = "";
            this.pnl_Endereco.Size = new System.Drawing.Size(704, 260);
            this.pnl_Endereco.TabIndex = 537;
            // 
            // st_naocontribuinte
            // 
            this.st_naocontribuinte.AutoSize = true;
            this.st_naocontribuinte.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEndereco, "St_naocontribuintebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_naocontribuinte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_naocontribuinte.Location = new System.Drawing.Point(268, 195);
            this.st_naocontribuinte.Name = "st_naocontribuinte";
            this.st_naocontribuinte.NM_Alias = "";
            this.st_naocontribuinte.NM_Campo = "";
            this.st_naocontribuinte.NM_Param = "";
            this.st_naocontribuinte.Size = new System.Drawing.Size(105, 17);
            this.st_naocontribuinte.ST_Gravar = true;
            this.st_naocontribuinte.ST_LimparCampo = true;
            this.st_naocontribuinte.ST_NotNull = false;
            this.st_naocontribuinte.TabIndex = 549;
            this.st_naocontribuinte.Text = "Não Contribuinte";
            this.st_naocontribuinte.UseVisualStyleBackColor = true;
            this.st_naocontribuinte.Vl_False = "N";
            this.st_naocontribuinte.Vl_True = "S";
            // 
            // celular
            // 
            this.celular.BackColor = System.Drawing.SystemColors.Window;
            this.celular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.celular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.celular.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Celular", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.celular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.celular.Location = new System.Drawing.Point(438, 156);
            this.celular.Name = "celular";
            this.celular.NM_Alias = "a";
            this.celular.NM_Campo = "CP";
            this.celular.NM_CampoBusca = "CP";
            this.celular.NM_Param = "@P_CP";
            this.celular.QTD_Zero = 0;
            this.celular.Size = new System.Drawing.Size(108, 20);
            this.celular.ST_AutoInc = false;
            this.celular.ST_DisableAuto = false;
            this.celular.ST_Float = false;
            this.celular.ST_Gravar = true;
            this.celular.ST_Int = false;
            this.celular.ST_LimpaCampo = true;
            this.celular.ST_NotNull = false;
            this.celular.ST_PrimaryKey = false;
            this.celular.TabIndex = 13;
            this.celular.TextOld = null;
            this.celular.TextChanged += new System.EventHandler(this.celular_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(390, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 548;
            this.label3.Text = "Celular:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Longitude
            // 
            this.Longitude.BackColor = System.Drawing.SystemColors.Window;
            this.Longitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Longitude.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Longitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Longitude", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Longitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Longitude.Location = new System.Drawing.Point(379, 233);
            this.Longitude.Name = "Longitude";
            this.Longitude.NM_Alias = "a";
            this.Longitude.NM_Campo = "Insc_Estadual";
            this.Longitude.NM_CampoBusca = "Insc_Estadual";
            this.Longitude.NM_Param = "@P_INSC_ESTADUAL";
            this.Longitude.QTD_Zero = 0;
            this.Longitude.Size = new System.Drawing.Size(319, 20);
            this.Longitude.ST_AutoInc = false;
            this.Longitude.ST_DisableAuto = false;
            this.Longitude.ST_Float = false;
            this.Longitude.ST_Gravar = true;
            this.Longitude.ST_Int = false;
            this.Longitude.ST_LimpaCampo = true;
            this.Longitude.ST_NotNull = false;
            this.Longitude.ST_PrimaryKey = false;
            this.Longitude.TabIndex = 18;
            this.Longitude.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(376, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 546;
            this.label2.Text = "Longitude";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Latitude
            // 
            this.Latitude.BackColor = System.Drawing.SystemColors.Window;
            this.Latitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Latitude.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Latitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Latitude", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Latitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Latitude.Location = new System.Drawing.Point(379, 194);
            this.Latitude.Name = "Latitude";
            this.Latitude.NM_Alias = "a";
            this.Latitude.NM_Campo = "Insc_Estadual";
            this.Latitude.NM_CampoBusca = "Insc_Estadual";
            this.Latitude.NM_Param = "@P_INSC_ESTADUAL";
            this.Latitude.QTD_Zero = 0;
            this.Latitude.Size = new System.Drawing.Size(319, 20);
            this.Latitude.ST_AutoInc = false;
            this.Latitude.ST_DisableAuto = false;
            this.Latitude.ST_Float = false;
            this.Latitude.ST_Gravar = true;
            this.Latitude.ST_Int = false;
            this.Latitude.ST_LimpaCampo = true;
            this.Latitude.ST_NotNull = false;
            this.Latitude.ST_PrimaryKey = false;
            this.Latitude.TabIndex = 17;
            this.Latitude.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(376, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 544;
            this.label1.Text = "Latitude";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Fone_comercial
            // 
            this.Fone_comercial.BackColor = System.Drawing.SystemColors.Window;
            this.Fone_comercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fone_comercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Fone_comercial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Fone_comercial", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone_comercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Fone_comercial.Location = new System.Drawing.Point(276, 155);
            this.Fone_comercial.Name = "Fone_comercial";
            this.Fone_comercial.NM_Alias = "a";
            this.Fone_comercial.NM_Campo = "CP";
            this.Fone_comercial.NM_CampoBusca = "CP";
            this.Fone_comercial.NM_Param = "@P_CP";
            this.Fone_comercial.QTD_Zero = 0;
            this.Fone_comercial.Size = new System.Drawing.Size(108, 20);
            this.Fone_comercial.ST_AutoInc = false;
            this.Fone_comercial.ST_DisableAuto = false;
            this.Fone_comercial.ST_Float = false;
            this.Fone_comercial.ST_Gravar = true;
            this.Fone_comercial.ST_Int = false;
            this.Fone_comercial.ST_LimpaCampo = true;
            this.Fone_comercial.ST_NotNull = false;
            this.Fone_comercial.ST_PrimaryKey = false;
            this.Fone_comercial.TabIndex = 12;
            this.Fone_comercial.TextOld = null;
            this.Fone_comercial.TextChanged += new System.EventHandler(this.Fone_comercial_TextChanged);
            // 
            // Fone
            // 
            this.Fone.BackColor = System.Drawing.SystemColors.Window;
            this.Fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Fone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Fone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Fone.Location = new System.Drawing.Point(73, 155);
            this.Fone.Name = "Fone";
            this.Fone.NM_Alias = "a";
            this.Fone.NM_Campo = "CP";
            this.Fone.NM_CampoBusca = "CP";
            this.Fone.NM_Param = "@P_CP";
            this.Fone.QTD_Zero = 0;
            this.Fone.Size = new System.Drawing.Size(108, 20);
            this.Fone.ST_AutoInc = false;
            this.Fone.ST_DisableAuto = false;
            this.Fone.ST_Float = false;
            this.Fone.ST_Gravar = true;
            this.Fone.ST_Int = true;
            this.Fone.ST_LimpaCampo = true;
            this.Fone.ST_NotNull = false;
            this.Fone.ST_PrimaryKey = false;
            this.Fone.TabIndex = 11;
            this.Fone.TextOld = null;
            this.Fone.TextChanged += new System.EventHandler(this.Fone_TextChanged);
            // 
            // st_endcobranca
            // 
            this.st_endcobranca.AutoSize = true;
            this.st_endcobranca.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEndereco, "St_endcobrancabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_endcobranca.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.st_endcobranca.Location = new System.Drawing.Point(207, 221);
            this.st_endcobranca.Name = "st_endcobranca";
            this.st_endcobranca.NM_Alias = "";
            this.st_endcobranca.NM_Campo = "ST_EnderecoEntrega";
            this.st_endcobranca.NM_Param = "@P_ST_ENDERECOENTREGA";
            this.st_endcobranca.Size = new System.Drawing.Size(121, 17);
            this.st_endcobranca.ST_Gravar = true;
            this.st_endcobranca.ST_LimparCampo = true;
            this.st_endcobranca.ST_NotNull = false;
            this.st_endcobranca.TabIndex = 16;
            this.st_endcobranca.Text = "Endereço Cobrança";
            this.st_endcobranca.UseVisualStyleBackColor = true;
            this.st_endcobranca.Vl_False = "N";
            this.st_endcobranca.Vl_True = "S";
            // 
            // ST_EnderecoEntrega
            // 
            this.ST_EnderecoEntrega.AutoSize = true;
            this.ST_EnderecoEntrega.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsEndereco, "St_enderecoentregabool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ST_EnderecoEntrega.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ST_EnderecoEntrega.Location = new System.Drawing.Point(73, 221);
            this.ST_EnderecoEntrega.Name = "ST_EnderecoEntrega";
            this.ST_EnderecoEntrega.NM_Alias = "";
            this.ST_EnderecoEntrega.NM_Campo = "ST_EnderecoEntrega";
            this.ST_EnderecoEntrega.NM_Param = "@P_ST_ENDERECOENTREGA";
            this.ST_EnderecoEntrega.Size = new System.Drawing.Size(115, 17);
            this.ST_EnderecoEntrega.ST_Gravar = true;
            this.ST_EnderecoEntrega.ST_LimparCampo = true;
            this.ST_EnderecoEntrega.ST_NotNull = false;
            this.ST_EnderecoEntrega.TabIndex = 15;
            this.ST_EnderecoEntrega.Text = "Endereço Entrega ";
            this.ST_EnderecoEntrega.UseVisualStyleBackColor = true;
            this.ST_EnderecoEntrega.Vl_False = "N";
            this.ST_EnderecoEntrega.Vl_True = "S";
            // 
            // Insc_Estadual
            // 
            this.Insc_Estadual.BackColor = System.Drawing.SystemColors.Window;
            this.Insc_Estadual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Insc_Estadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Insc_Estadual.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Insc_estadual", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Insc_Estadual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Insc_Estadual.Location = new System.Drawing.Point(73, 194);
            this.Insc_Estadual.Name = "Insc_Estadual";
            this.Insc_Estadual.NM_Alias = "a";
            this.Insc_Estadual.NM_Campo = "Insc_Estadual";
            this.Insc_Estadual.NM_CampoBusca = "Insc_Estadual";
            this.Insc_Estadual.NM_Param = "@P_INSC_ESTADUAL";
            this.Insc_Estadual.QTD_Zero = 0;
            this.Insc_Estadual.Size = new System.Drawing.Size(189, 20);
            this.Insc_Estadual.ST_AutoInc = false;
            this.Insc_Estadual.ST_DisableAuto = false;
            this.Insc_Estadual.ST_Float = false;
            this.Insc_Estadual.ST_Gravar = true;
            this.Insc_Estadual.ST_Int = true;
            this.Insc_Estadual.ST_LimpaCampo = true;
            this.Insc_Estadual.ST_NotNull = false;
            this.Insc_Estadual.ST_PrimaryKey = false;
            this.Insc_Estadual.TabIndex = 14;
            this.Insc_Estadual.TextOld = null;
            this.Insc_Estadual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Insc_Estadual_KeyPress);
            this.Insc_Estadual.Leave += new System.EventHandler(this.Insc_Estadual_Leave);
            // 
            // DS_Complemento
            // 
            this.DS_Complemento.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Complemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Complemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Complemento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Ds_complemento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Complemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Complemento.Location = new System.Drawing.Point(73, 51);
            this.DS_Complemento.Name = "DS_Complemento";
            this.DS_Complemento.NM_Alias = "a";
            this.DS_Complemento.NM_Campo = "DS_Complemento";
            this.DS_Complemento.NM_CampoBusca = "DS_Complemento";
            this.DS_Complemento.NM_Param = "@P_DS_COMPLEMENTO";
            this.DS_Complemento.QTD_Zero = 0;
            this.DS_Complemento.Size = new System.Drawing.Size(625, 20);
            this.DS_Complemento.ST_AutoInc = false;
            this.DS_Complemento.ST_DisableAuto = false;
            this.DS_Complemento.ST_Float = false;
            this.DS_Complemento.ST_Gravar = true;
            this.DS_Complemento.ST_Int = false;
            this.DS_Complemento.ST_LimpaCampo = true;
            this.DS_Complemento.ST_NotNull = false;
            this.DS_Complemento.ST_PrimaryKey = false;
            this.DS_Complemento.TabIndex = 5;
            this.DS_Complemento.TextOld = null;
            // 
            // LB_Fax
            // 
            this.LB_Fax.AutoSize = true;
            this.LB_Fax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Fax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Fax.Location = new System.Drawing.Point(187, 158);
            this.LB_Fax.Name = "LB_Fax";
            this.LB_Fax.Size = new System.Drawing.Size(83, 13);
            this.LB_Fax.TabIndex = 536;
            this.LB_Fax.Text = "Fone Comercial:";
            this.LB_Fax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_Pais
            // 
            this.NM_Pais.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Pais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Pais.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "NM_Pais", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Pais.Enabled = false;
            this.NM_Pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Pais.Location = new System.Drawing.Point(160, 102);
            this.NM_Pais.Name = "NM_Pais";
            this.NM_Pais.NM_Alias = "";
            this.NM_Pais.NM_Campo = "NM_Pais";
            this.NM_Pais.NM_CampoBusca = "NM_Pais";
            this.NM_Pais.NM_Param = "";
            this.NM_Pais.QTD_Zero = 0;
            this.NM_Pais.Size = new System.Drawing.Size(538, 20);
            this.NM_Pais.ST_AutoInc = false;
            this.NM_Pais.ST_DisableAuto = false;
            this.NM_Pais.ST_Float = false;
            this.NM_Pais.ST_Gravar = false;
            this.NM_Pais.ST_Int = false;
            this.NM_Pais.ST_LimpaCampo = true;
            this.NM_Pais.ST_NotNull = false;
            this.NM_Pais.ST_PrimaryKey = false;
            this.NM_Pais.TabIndex = 532;
            this.NM_Pais.TextOld = null;
            // 
            // BB_Pais
            // 
            this.BB_Pais.Image = ((System.Drawing.Image)(resources.GetObject("BB_Pais.Image")));
            this.BB_Pais.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Pais.Location = new System.Drawing.Point(129, 102);
            this.BB_Pais.Name = "BB_Pais";
            this.BB_Pais.Size = new System.Drawing.Size(30, 20);
            this.BB_Pais.TabIndex = 9;
            this.BB_Pais.UseVisualStyleBackColor = true;
            this.BB_Pais.Click += new System.EventHandler(this.BB_Pais_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(33, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "País:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CD_PAIS
            // 
            this.CD_PAIS.BackColor = System.Drawing.SystemColors.Window;
            this.CD_PAIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_PAIS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_PAIS.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "CD_Pais", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_PAIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_PAIS.Location = new System.Drawing.Point(73, 103);
            this.CD_PAIS.Name = "CD_PAIS";
            this.CD_PAIS.NM_Alias = "a";
            this.CD_PAIS.NM_Campo = "CD_PAIS";
            this.CD_PAIS.NM_CampoBusca = "CD_PAIS";
            this.CD_PAIS.NM_Param = "@P_CD_PAIS";
            this.CD_PAIS.QTD_Zero = 0;
            this.CD_PAIS.Size = new System.Drawing.Size(53, 20);
            this.CD_PAIS.ST_AutoInc = false;
            this.CD_PAIS.ST_DisableAuto = false;
            this.CD_PAIS.ST_Float = false;
            this.CD_PAIS.ST_Gravar = true;
            this.CD_PAIS.ST_Int = false;
            this.CD_PAIS.ST_LimpaCampo = true;
            this.CD_PAIS.ST_NotNull = true;
            this.CD_PAIS.ST_PrimaryKey = false;
            this.CD_PAIS.TabIndex = 8;
            this.CD_PAIS.TextOld = null;
            this.CD_PAIS.Leave += new System.EventHandler(this.CD_PAIS_Leave);
            // 
            // UF
            // 
            this.UF.BackColor = System.Drawing.SystemColors.Window;
            this.UF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UF.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "UF", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.UF.Enabled = false;
            this.UF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.UF.Location = new System.Drawing.Point(657, 77);
            this.UF.Name = "UF";
            this.UF.NM_Alias = "";
            this.UF.NM_Campo = "UF";
            this.UF.NM_CampoBusca = "UF";
            this.UF.NM_Param = "@P_UF";
            this.UF.QTD_Zero = 0;
            this.UF.Size = new System.Drawing.Size(41, 20);
            this.UF.ST_AutoInc = false;
            this.UF.ST_DisableAuto = false;
            this.UF.ST_Float = false;
            this.UF.ST_Gravar = false;
            this.UF.ST_Int = false;
            this.UF.ST_LimpaCampo = true;
            this.UF.ST_NotNull = false;
            this.UF.ST_PrimaryKey = false;
            this.UF.TabIndex = 529;
            this.UF.TextOld = null;
            // 
            // Ds_Cidade
            // 
            this.Ds_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "DS_Cidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_Cidade.Enabled = false;
            this.Ds_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Ds_Cidade.Location = new System.Drawing.Point(196, 77);
            this.Ds_Cidade.Name = "Ds_Cidade";
            this.Ds_Cidade.NM_Alias = "";
            this.Ds_Cidade.NM_Campo = "Ds_Cidade";
            this.Ds_Cidade.NM_CampoBusca = "Ds_Cidade";
            this.Ds_Cidade.NM_Param = "@P_DS_CIDADE";
            this.Ds_Cidade.QTD_Zero = 0;
            this.Ds_Cidade.Size = new System.Drawing.Size(458, 20);
            this.Ds_Cidade.ST_AutoInc = false;
            this.Ds_Cidade.ST_DisableAuto = false;
            this.Ds_Cidade.ST_Float = false;
            this.Ds_Cidade.ST_Gravar = false;
            this.Ds_Cidade.ST_Int = false;
            this.Ds_Cidade.ST_LimpaCampo = true;
            this.Ds_Cidade.ST_NotNull = false;
            this.Ds_Cidade.ST_PrimaryKey = false;
            this.Ds_Cidade.TabIndex = 526;
            this.Ds_Cidade.TextOld = null;
            // 
            // BB_Cidade
            // 
            this.BB_Cidade.Image = ((System.Drawing.Image)(resources.GetObject("BB_Cidade.Image")));
            this.BB_Cidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Cidade.Location = new System.Drawing.Point(163, 76);
            this.BB_Cidade.Name = "BB_Cidade";
            this.BB_Cidade.Size = new System.Drawing.Size(30, 20);
            this.BB_Cidade.TabIndex = 7;
            this.BB_Cidade.UseVisualStyleBackColor = true;
            this.BB_Cidade.Click += new System.EventHandler(this.BB_Cidade_Click);
            // 
            // CD_Cidade
            // 
            this.CD_Cidade.BackColor = System.Drawing.SystemColors.Window;
            this.CD_Cidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Cidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Cidade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Cd_cidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Cidade.Location = new System.Drawing.Point(73, 77);
            this.CD_Cidade.Name = "CD_Cidade";
            this.CD_Cidade.NM_Alias = "a";
            this.CD_Cidade.NM_Campo = "CD_Cidade";
            this.CD_Cidade.NM_CampoBusca = "CD_Cidade";
            this.CD_Cidade.NM_Param = "@P_CD_CIDADE";
            this.CD_Cidade.QTD_Zero = 0;
            this.CD_Cidade.Size = new System.Drawing.Size(88, 20);
            this.CD_Cidade.ST_AutoInc = false;
            this.CD_Cidade.ST_DisableAuto = false;
            this.CD_Cidade.ST_Float = false;
            this.CD_Cidade.ST_Gravar = true;
            this.CD_Cidade.ST_Int = false;
            this.CD_Cidade.ST_LimpaCampo = true;
            this.CD_Cidade.ST_NotNull = true;
            this.CD_Cidade.ST_PrimaryKey = false;
            this.CD_Cidade.TabIndex = 6;
            this.CD_Cidade.TextOld = null;
            this.CD_Cidade.Leave += new System.EventHandler(this.CD_Cidade_Leave);
            // 
            // LB_Bairro
            // 
            this.LB_Bairro.AutoSize = true;
            this.LB_Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Bairro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Bairro.Location = new System.Drawing.Point(143, 28);
            this.LB_Bairro.Name = "LB_Bairro";
            this.LB_Bairro.Size = new System.Drawing.Size(37, 13);
            this.LB_Bairro.TabIndex = 40;
            this.LB_Bairro.Text = "Bairro:";
            this.LB_Bairro.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Bairro
            // 
            this.Bairro.BackColor = System.Drawing.SystemColors.Window;
            this.Bairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Bairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Bairro.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Bairro", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Bairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Bairro.Location = new System.Drawing.Point(186, 26);
            this.Bairro.Name = "Bairro";
            this.Bairro.NM_Alias = "a";
            this.Bairro.NM_Campo = "Bairro";
            this.Bairro.NM_CampoBusca = "Bairro";
            this.Bairro.NM_Param = "@P_BAIRRO";
            this.Bairro.QTD_Zero = 0;
            this.Bairro.Size = new System.Drawing.Size(512, 20);
            this.Bairro.ST_AutoInc = false;
            this.Bairro.ST_DisableAuto = false;
            this.Bairro.ST_Float = false;
            this.Bairro.ST_Gravar = true;
            this.Bairro.ST_Int = false;
            this.Bairro.ST_LimpaCampo = true;
            this.Bairro.ST_NotNull = true;
            this.Bairro.ST_PrimaryKey = false;
            this.Bairro.TabIndex = 4;
            this.Bairro.TextOld = null;
            // 
            // CP
            // 
            this.CP.BackColor = System.Drawing.SystemColors.Window;
            this.CP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Cp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CP.Location = new System.Drawing.Point(73, 26);
            this.CP.Name = "CP";
            this.CP.NM_Alias = "a";
            this.CP.NM_Campo = "CP";
            this.CP.NM_CampoBusca = "CP";
            this.CP.NM_Param = "@P_CP";
            this.CP.QTD_Zero = 0;
            this.CP.Size = new System.Drawing.Size(64, 20);
            this.CP.ST_AutoInc = false;
            this.CP.ST_DisableAuto = false;
            this.CP.ST_Float = false;
            this.CP.ST_Gravar = true;
            this.CP.ST_Int = false;
            this.CP.ST_LimpaCampo = true;
            this.CP.ST_NotNull = false;
            this.CP.ST_PrimaryKey = false;
            this.CP.TabIndex = 3;
            this.CP.TextOld = null;
            // 
            // LB_Proximo
            // 
            this.LB_Proximo.AutoSize = true;
            this.LB_Proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Proximo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Proximo.Location = new System.Drawing.Point(18, 132);
            this.LB_Proximo.Name = "LB_Proximo";
            this.LB_Proximo.Size = new System.Drawing.Size(47, 13);
            this.LB_Proximo.TabIndex = 37;
            this.LB_Proximo.Text = "Próximo:";
            this.LB_Proximo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Proximo
            // 
            this.Proximo.BackColor = System.Drawing.SystemColors.Window;
            this.Proximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Proximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Proximo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Proximo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Proximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Proximo.Location = new System.Drawing.Point(73, 129);
            this.Proximo.Name = "Proximo";
            this.Proximo.NM_Alias = "a";
            this.Proximo.NM_Campo = "Proximo";
            this.Proximo.NM_CampoBusca = "Proximo";
            this.Proximo.NM_Param = "@P_PROXIMO";
            this.Proximo.QTD_Zero = 0;
            this.Proximo.Size = new System.Drawing.Size(625, 20);
            this.Proximo.ST_AutoInc = false;
            this.Proximo.ST_DisableAuto = false;
            this.Proximo.ST_Float = false;
            this.Proximo.ST_Gravar = true;
            this.Proximo.ST_Int = false;
            this.Proximo.ST_LimpaCampo = true;
            this.Proximo.ST_NotNull = false;
            this.Proximo.ST_PrimaryKey = false;
            this.Proximo.TabIndex = 10;
            this.Proximo.TextOld = null;
            // 
            // Numero
            // 
            this.Numero.BackColor = System.Drawing.SystemColors.Window;
            this.Numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Numero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Numero.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Numero", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Numero.Location = new System.Drawing.Point(633, 3);
            this.Numero.Name = "Numero";
            this.Numero.NM_Alias = "a";
            this.Numero.NM_Campo = "Numero";
            this.Numero.NM_CampoBusca = "Numero";
            this.Numero.NM_Param = "@P_NUMERO";
            this.Numero.QTD_Zero = 0;
            this.Numero.Size = new System.Drawing.Size(65, 20);
            this.Numero.ST_AutoInc = false;
            this.Numero.ST_DisableAuto = false;
            this.Numero.ST_Float = false;
            this.Numero.ST_Gravar = true;
            this.Numero.ST_Int = false;
            this.Numero.ST_LimpaCampo = true;
            this.Numero.ST_NotNull = true;
            this.Numero.ST_PrimaryKey = false;
            this.Numero.TabIndex = 2;
            this.Numero.TextOld = null;
            // 
            // LB_DS_Endereco
            // 
            this.LB_DS_Endereco.AutoSize = true;
            this.LB_DS_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_DS_Endereco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Endereco.Location = new System.Drawing.Point(143, 6);
            this.LB_DS_Endereco.Name = "LB_DS_Endereco";
            this.LB_DS_Endereco.Size = new System.Drawing.Size(56, 13);
            this.LB_DS_Endereco.TabIndex = 33;
            this.LB_DS_Endereco.Text = "Endereço:";
            this.LB_DS_Endereco.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DS_Endereco
            // 
            this.DS_Endereco.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Endereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Endereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Endereco.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Ds_endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Endereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Endereco.Location = new System.Drawing.Point(205, 3);
            this.DS_Endereco.Name = "DS_Endereco";
            this.DS_Endereco.NM_Alias = "a";
            this.DS_Endereco.NM_Campo = "DS_Endereco";
            this.DS_Endereco.NM_CampoBusca = "DS_Endereco";
            this.DS_Endereco.NM_Param = "@P_DS_ENDERECO";
            this.DS_Endereco.QTD_Zero = 0;
            this.DS_Endereco.Size = new System.Drawing.Size(394, 20);
            this.DS_Endereco.ST_AutoInc = false;
            this.DS_Endereco.ST_DisableAuto = false;
            this.DS_Endereco.ST_Float = false;
            this.DS_Endereco.ST_Gravar = true;
            this.DS_Endereco.ST_Int = false;
            this.DS_Endereco.ST_LimpaCampo = true;
            this.DS_Endereco.ST_NotNull = true;
            this.DS_Endereco.ST_PrimaryKey = false;
            this.DS_Endereco.TabIndex = 1;
            this.DS_Endereco.TextOld = null;
            // 
            // Cep
            // 
            this.Cep.BackColor = System.Drawing.Color.White;
            this.Cep.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsEndereco, "Cep", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Cep.Location = new System.Drawing.Point(73, 3);
            this.Cep.Mask = "00.000-000";
            this.Cep.Name = "Cep";
            this.Cep.NM_Alias = "a";
            this.Cep.NM_Campo = "Cep";
            this.Cep.NM_CampoBusca = "Cep";
            this.Cep.NM_Param = "@P_CEP";
            this.Cep.Size = new System.Drawing.Size(64, 20);
            this.Cep.ST_Gravar = true;
            this.Cep.ST_LimpaCampo = true;
            this.Cep.ST_NotNull = false;
            this.Cep.ST_PrimaryKey = false;
            this.Cep.TabIndex = 0;
            this.Cep.Leave += new System.EventHandler(this.Cep_Leave);
            // 
            // LB_Numero
            // 
            this.LB_Numero.AutoSize = true;
            this.LB_Numero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Numero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Numero.Location = new System.Drawing.Point(605, 6);
            this.LB_Numero.Name = "LB_Numero";
            this.LB_Numero.Size = new System.Drawing.Size(22, 13);
            this.LB_Numero.TabIndex = 35;
            this.LB_Numero.Text = "Nº:";
            this.LB_Numero.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Fone
            // 
            this.LB_Fone.AutoSize = true;
            this.LB_Fone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Fone.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Fone.Location = new System.Drawing.Point(33, 158);
            this.LB_Fone.Name = "LB_Fone";
            this.LB_Fone.Size = new System.Drawing.Size(34, 13);
            this.LB_Fone.TabIndex = 535;
            this.LB_Fone.Text = "Fone:";
            this.LB_Fone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_CD_Cidade
            // 
            this.LB_CD_Cidade.AutoSize = true;
            this.LB_CD_Cidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CD_Cidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CD_Cidade.Location = new System.Drawing.Point(24, 80);
            this.LB_CD_Cidade.Name = "LB_CD_Cidade";
            this.LB_CD_Cidade.Size = new System.Drawing.Size(43, 13);
            this.LB_CD_Cidade.TabIndex = 523;
            this.LB_CD_Cidade.Text = "Cidade:";
            this.LB_CD_Cidade.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Cep
            // 
            this.LB_Cep.AutoSize = true;
            this.LB_Cep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Cep.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Cep.Location = new System.Drawing.Point(36, 6);
            this.LB_Cep.Name = "LB_Cep";
            this.LB_Cep.Size = new System.Drawing.Size(31, 13);
            this.LB_Cep.TabIndex = 30;
            this.LB_Cep.Text = "CEP:";
            this.LB_Cep.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_CP
            // 
            this.LB_CP.AutoSize = true;
            this.LB_CP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_CP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_CP.Location = new System.Drawing.Point(8, 28);
            this.LB_CP.Name = "LB_CP";
            this.LB_CP.Size = new System.Drawing.Size(59, 13);
            this.LB_CP.TabIndex = 39;
            this.LB_CP.Text = "CX. Postal:";
            this.LB_CP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_DS_Complemento
            // 
            this.LB_DS_Complemento.AutoSize = true;
            this.LB_DS_Complemento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_DS_Complemento.Location = new System.Drawing.Point(25, 53);
            this.LB_DS_Complemento.Name = "LB_DS_Complemento";
            this.LB_DS_Complemento.Size = new System.Drawing.Size(42, 13);
            this.LB_DS_Complemento.TabIndex = 540;
            this.LB_DS_Complemento.Text = "Compl.:";
            this.LB_DS_Complemento.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LB_Insc_Estadual
            // 
            this.LB_Insc_Estadual.AutoSize = true;
            this.LB_Insc_Estadual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.LB_Insc_Estadual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_Insc_Estadual.Location = new System.Drawing.Point(70, 178);
            this.LB_Insc_Estadual.Name = "LB_Insc_Estadual";
            this.LB_Insc_Estadual.Size = new System.Drawing.Size(94, 13);
            this.LB_Insc_Estadual.TabIndex = 542;
            this.LB_Insc_Estadual.Text = "Inscrição Estadual";
            this.LB_Insc_Estadual.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TFEndereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 303);
            this.Controls.Add(this.pnl_Endereco);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFEndereco";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Endereços";
            this.Load += new System.EventHandler(this.TFEndereco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFEndereco_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsEndereco)).EndInit();
            this.pnl_Endereco.ResumeLayout(false);
            this.pnl_Endereco.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private System.Windows.Forms.BindingSource bsEndereco;
        private Componentes.PanelDados pnl_Endereco;
        private Componentes.CheckBoxDefault ST_EnderecoEntrega;
        private Componentes.EditDefault Insc_Estadual;
        private Componentes.EditDefault DS_Complemento;
        private System.Windows.Forms.Label LB_Fax;
        private Componentes.EditDefault NM_Pais;
        private System.Windows.Forms.Button BB_Pais;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault CD_PAIS;
        private Componentes.EditDefault UF;
        private Componentes.EditDefault Ds_Cidade;
        private System.Windows.Forms.Button BB_Cidade;
        private Componentes.EditDefault CD_Cidade;
        private System.Windows.Forms.Label LB_Bairro;
        private Componentes.EditDefault Bairro;
        private Componentes.EditDefault CP;
        private System.Windows.Forms.Label LB_Proximo;
        private Componentes.EditDefault Proximo;
        private Componentes.EditDefault Numero;
        private System.Windows.Forms.Label LB_DS_Endereco;
        private Componentes.EditDefault DS_Endereco;
        private Componentes.EditMask Cep;
        private System.Windows.Forms.Label LB_Numero;
        private System.Windows.Forms.Label LB_Fone;
        private System.Windows.Forms.Label LB_CD_Cidade;
        private System.Windows.Forms.Label LB_Cep;
        private System.Windows.Forms.Label LB_CP;
        private System.Windows.Forms.Label LB_DS_Complemento;
        private System.Windows.Forms.Label LB_Insc_Estadual;
        private Componentes.CheckBoxDefault st_endcobranca;
        private Componentes.EditDefault Fone_comercial;
        private Componentes.EditDefault Fone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox cd_endereco;
        private Componentes.EditDefault Longitude;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault Latitude;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault celular;
        private System.Windows.Forms.Label label3;
        private Componentes.CheckBoxDefault st_naocontribuinte;
    }
}