namespace Financeiro.Cadastros
{
    partial class TFContatoPF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFContatoPF));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.BB_Gravar = new System.Windows.Forms.ToolStripButton();
            this.BB_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_data = new System.Windows.Forms.Button();
            this.st_envemailaniversario = new Componentes.CheckBoxDefault(this.components);
            this.bsContato = new System.Windows.Forms.BindingSource(this.components);
            this.dt_nascimento = new Componentes.EditData(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tp_relacionamento = new Componentes.ComboBoxDefault(this.components);
            this.FoneMovel = new Componentes.EditDefault(this.components);
            this.Fone = new Componentes.EditDefault(this.components);
            this.DS_Observacao = new Componentes.EditDefault(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.NM_Contato = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Email_Contato = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.st_receberxmlnfe = new Componentes.CheckBoxDefault(this.components);
            this.st_receberdanfe = new Componentes.CheckBoxDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsContato)).BeginInit();
            this.SuspendLayout();
            // 
            // barraMenu
            // 
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BB_Gravar,
            this.BB_Cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(734, 43);
            this.barraMenu.TabIndex = 538;
            // 
            // BB_Gravar
            // 
            this.BB_Gravar.AutoSize = false;
            this.BB_Gravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
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
            this.BB_Cancelar.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.st_receberxmlnfe);
            this.pDados.Controls.Add(this.st_receberdanfe);
            this.pDados.Controls.Add(this.bb_data);
            this.pDados.Controls.Add(this.st_envemailaniversario);
            this.pDados.Controls.Add(this.dt_nascimento);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.label13);
            this.pDados.Controls.Add(this.tp_relacionamento);
            this.pDados.Controls.Add(this.FoneMovel);
            this.pDados.Controls.Add(this.Fone);
            this.pDados.Controls.Add(this.DS_Observacao);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.NM_Contato);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.Email_Contato);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.label15);
            this.pDados.Controls.Add(this.label12);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(734, 200);
            this.pDados.TabIndex = 539;
            // 
            // bb_data
            // 
            this.bb_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_data.Location = new System.Drawing.Point(159, 74);
            this.bb_data.Name = "bb_data";
            this.bb_data.Size = new System.Drawing.Size(110, 23);
            this.bb_data.TabIndex = 6;
            this.bb_data.Text = "Datas Adicionais";
            this.bb_data.UseVisualStyleBackColor = true;
            this.bb_data.Click += new System.EventHandler(this.bb_data_Click);
            // 
            // st_envemailaniversario
            // 
            this.st_envemailaniversario.AutoSize = true;
            this.st_envemailaniversario.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_envemailaniversariobool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_envemailaniversario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_envemailaniversario.Location = new System.Drawing.Point(275, 78);
            this.st_envemailaniversario.Name = "st_envemailaniversario";
            this.st_envemailaniversario.NM_Alias = "";
            this.st_envemailaniversario.NM_Campo = "";
            this.st_envemailaniversario.NM_Param = "";
            this.st_envemailaniversario.Size = new System.Drawing.Size(173, 17);
            this.st_envemailaniversario.ST_Gravar = false;
            this.st_envemailaniversario.ST_LimparCampo = true;
            this.st_envemailaniversario.ST_NotNull = false;
            this.st_envemailaniversario.TabIndex = 7;
            this.st_envemailaniversario.Text = "Permitir Envio Mala Direta";
            this.st_envemailaniversario.UseVisualStyleBackColor = true;
            this.st_envemailaniversario.Vl_False = "";
            this.st_envemailaniversario.Vl_True = "";
            // 
            // bsContato
            // 
            this.bsContato.DataSource = typeof(CamadaDados.Financeiro.Cadastros.TList_CadContatoCliFor);
            // 
            // dt_nascimento
            // 
            this.dt_nascimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_nascimento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Dt_nascimentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_nascimento.Location = new System.Drawing.Point(83, 77);
            this.dt_nascimento.Mask = "00/00/0000";
            this.dt_nascimento.Name = "dt_nascimento";
            this.dt_nascimento.NM_Alias = "";
            this.dt_nascimento.NM_Campo = "";
            this.dt_nascimento.NM_CampoBusca = "";
            this.dt_nascimento.NM_Param = "";
            this.dt_nascimento.Operador = "";
            this.dt_nascimento.Size = new System.Drawing.Size(70, 20);
            this.dt_nascimento.ST_Gravar = false;
            this.dt_nascimento.ST_LimpaCampo = true;
            this.dt_nascimento.ST_NotNull = false;
            this.dt_nascimento.ST_PrimaryKey = false;
            this.dt_nascimento.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 558;
            this.label1.Text = "Nascimento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(457, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 557;
            this.label13.Text = "Tipo Relacionamento:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tp_relacionamento
            // 
            this.tp_relacionamento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsContato, "Tp_relacionamento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_relacionamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_relacionamento.FormattingEnabled = true;
            this.tp_relacionamento.Location = new System.Drawing.Point(574, 50);
            this.tp_relacionamento.Name = "tp_relacionamento";
            this.tp_relacionamento.NM_Alias = "";
            this.tp_relacionamento.NM_Campo = "";
            this.tp_relacionamento.NM_Param = "";
            this.tp_relacionamento.Size = new System.Drawing.Size(152, 21);
            this.tp_relacionamento.ST_Gravar = true;
            this.tp_relacionamento.ST_LimparCampo = true;
            this.tp_relacionamento.ST_NotNull = true;
            this.tp_relacionamento.TabIndex = 4;
            // 
            // FoneMovel
            // 
            this.FoneMovel.BackColor = System.Drawing.SystemColors.Window;
            this.FoneMovel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FoneMovel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FoneMovel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "FoneMovel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FoneMovel.Location = new System.Drawing.Point(306, 51);
            this.FoneMovel.Name = "FoneMovel";
            this.FoneMovel.NM_Alias = "";
            this.FoneMovel.NM_Campo = "";
            this.FoneMovel.NM_CampoBusca = "";
            this.FoneMovel.NM_Param = "";
            this.FoneMovel.QTD_Zero = 0;
            this.FoneMovel.Size = new System.Drawing.Size(145, 20);
            this.FoneMovel.ST_AutoInc = false;
            this.FoneMovel.ST_DisableAuto = false;
            this.FoneMovel.ST_Float = false;
            this.FoneMovel.ST_Gravar = false;
            this.FoneMovel.ST_Int = false;
            this.FoneMovel.ST_LimpaCampo = true;
            this.FoneMovel.ST_NotNull = false;
            this.FoneMovel.ST_PrimaryKey = false;
            this.FoneMovel.TabIndex = 3;
            this.FoneMovel.TextOld = null;
            this.FoneMovel.TextChanged += new System.EventHandler(this.FoneMovel_TextChanged);
            // 
            // Fone
            // 
            this.Fone.BackColor = System.Drawing.SystemColors.Window;
            this.Fone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Fone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Fone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Fone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Fone.Location = new System.Drawing.Point(83, 51);
            this.Fone.Name = "Fone";
            this.Fone.NM_Alias = "";
            this.Fone.NM_Campo = "";
            this.Fone.NM_CampoBusca = "";
            this.Fone.NM_Param = "";
            this.Fone.QTD_Zero = 0;
            this.Fone.Size = new System.Drawing.Size(145, 20);
            this.Fone.ST_AutoInc = false;
            this.Fone.ST_DisableAuto = false;
            this.Fone.ST_Float = false;
            this.Fone.ST_Gravar = false;
            this.Fone.ST_Int = false;
            this.Fone.ST_LimpaCampo = true;
            this.Fone.ST_NotNull = false;
            this.Fone.ST_PrimaryKey = false;
            this.Fone.TabIndex = 2;
            this.Fone.TextOld = null;
            this.Fone.TextChanged += new System.EventHandler(this.Fone_TextChanged);
            // 
            // DS_Observacao
            // 
            this.DS_Observacao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.DS_Observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "DS_Observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Observacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Observacao.Location = new System.Drawing.Point(83, 103);
            this.DS_Observacao.MaxLength = 4096;
            this.DS_Observacao.Multiline = true;
            this.DS_Observacao.Name = "DS_Observacao";
            this.DS_Observacao.NM_Alias = "e";
            this.DS_Observacao.NM_Campo = "DS_Observacao";
            this.DS_Observacao.NM_CampoBusca = "DS_Observacao";
            this.DS_Observacao.NM_Param = "@P_EMAIL";
            this.DS_Observacao.QTD_Zero = 0;
            this.DS_Observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DS_Observacao.Size = new System.Drawing.Size(643, 89);
            this.DS_Observacao.ST_AutoInc = false;
            this.DS_Observacao.ST_DisableAuto = false;
            this.DS_Observacao.ST_Float = false;
            this.DS_Observacao.ST_Gravar = true;
            this.DS_Observacao.ST_Int = false;
            this.DS_Observacao.ST_LimpaCampo = true;
            this.DS_Observacao.ST_NotNull = false;
            this.DS_Observacao.ST_PrimaryKey = false;
            this.DS_Observacao.TabIndex = 10;
            this.DS_Observacao.TextOld = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(30, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 554;
            this.label6.Text = "Contato:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NM_Contato
            // 
            this.NM_Contato.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Contato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Nm_Contato", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NM_Contato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Contato.Location = new System.Drawing.Point(83, 6);
            this.NM_Contato.Name = "NM_Contato";
            this.NM_Contato.NM_Alias = "e";
            this.NM_Contato.NM_Campo = "EMail";
            this.NM_Contato.NM_CampoBusca = "EMail";
            this.NM_Contato.NM_Param = "@P_EMAIL";
            this.NM_Contato.QTD_Zero = 0;
            this.NM_Contato.Size = new System.Drawing.Size(643, 20);
            this.NM_Contato.ST_AutoInc = false;
            this.NM_Contato.ST_DisableAuto = false;
            this.NM_Contato.ST_Float = false;
            this.NM_Contato.ST_Gravar = true;
            this.NM_Contato.ST_Int = false;
            this.NM_Contato.ST_LimpaCampo = true;
            this.NM_Contato.ST_NotNull = true;
            this.NM_Contato.ST_PrimaryKey = false;
            this.NM_Contato.TabIndex = 0;
            this.NM_Contato.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(38, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 553;
            this.label3.Text = "E-Mail:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Email_Contato
            // 
            this.Email_Contato.BackColor = System.Drawing.SystemColors.Window;
            this.Email_Contato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email_Contato.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.Email_Contato.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsContato, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Email_Contato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Email_Contato.Location = new System.Drawing.Point(83, 28);
            this.Email_Contato.Name = "Email_Contato";
            this.Email_Contato.NM_Alias = "e";
            this.Email_Contato.NM_Campo = "EMail";
            this.Email_Contato.NM_CampoBusca = "EMail";
            this.Email_Contato.NM_Param = "@P_EMAIL";
            this.Email_Contato.QTD_Zero = 0;
            this.Email_Contato.Size = new System.Drawing.Size(643, 20);
            this.Email_Contato.ST_AutoInc = false;
            this.Email_Contato.ST_DisableAuto = false;
            this.Email_Contato.ST_Float = false;
            this.Email_Contato.ST_Gravar = true;
            this.Email_Contato.ST_Int = false;
            this.Email_Contato.ST_LimpaCampo = true;
            this.Email_Contato.ST_NotNull = false;
            this.Email_Contato.ST_PrimaryKey = false;
            this.Email_Contato.TabIndex = 1;
            this.Email_Contato.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(234, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 552;
            this.label9.Text = "Fone Móvel:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(43, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 551;
            this.label15.Text = "Fone:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(12, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 555;
            this.label12.Text = "Observação:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // st_receberxmlnfe
            // 
            this.st_receberxmlnfe.AutoSize = true;
            this.st_receberxmlnfe.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_receberxmlnfebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_receberxmlnfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_receberxmlnfe.Location = new System.Drawing.Point(596, 78);
            this.st_receberxmlnfe.Name = "st_receberxmlnfe";
            this.st_receberxmlnfe.NM_Alias = "";
            this.st_receberxmlnfe.NM_Campo = "";
            this.st_receberxmlnfe.NM_Param = "";
            this.st_receberxmlnfe.Size = new System.Drawing.Size(130, 17);
            this.st_receberxmlnfe.ST_Gravar = true;
            this.st_receberxmlnfe.ST_LimparCampo = true;
            this.st_receberxmlnfe.ST_NotNull = false;
            this.st_receberxmlnfe.TabIndex = 9;
            this.st_receberxmlnfe.Text = "Receber XML NFe";
            this.st_receberxmlnfe.UseVisualStyleBackColor = true;
            this.st_receberxmlnfe.Vl_False = "";
            this.st_receberxmlnfe.Vl_True = "";
            // 
            // st_receberdanfe
            // 
            this.st_receberdanfe.AutoSize = true;
            this.st_receberdanfe.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bsContato, "St_receberdanfebool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.st_receberdanfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st_receberdanfe.Location = new System.Drawing.Point(451, 78);
            this.st_receberdanfe.Name = "st_receberdanfe";
            this.st_receberdanfe.NM_Alias = "";
            this.st_receberdanfe.NM_Campo = "";
            this.st_receberdanfe.NM_Param = "";
            this.st_receberdanfe.Size = new System.Drawing.Size(139, 17);
            this.st_receberdanfe.ST_Gravar = true;
            this.st_receberdanfe.ST_LimparCampo = true;
            this.st_receberdanfe.ST_NotNull = false;
            this.st_receberdanfe.TabIndex = 8;
            this.st_receberdanfe.Text = "Receber Danfe NFe";
            this.st_receberdanfe.UseVisualStyleBackColor = true;
            this.st_receberdanfe.Vl_False = "";
            this.st_receberdanfe.Vl_True = "";
            // 
            // TFContatoPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 243);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFContatoPF";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contatos Cliente";
            this.Load += new System.EventHandler(this.TFContatoPF_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFContatoPF_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsContato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        public System.Windows.Forms.ToolStripButton BB_Gravar;
        private System.Windows.Forms.ToolStripButton BB_Cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault FoneMovel;
        private Componentes.EditDefault Fone;
        private Componentes.EditDefault DS_Observacao;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault NM_Contato;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Email_Contato;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Componentes.ComboBoxDefault tp_relacionamento;
        private Componentes.EditData dt_nascimento;
        private System.Windows.Forms.Label label1;
        private Componentes.CheckBoxDefault st_envemailaniversario;
        private System.Windows.Forms.BindingSource bsContato;
        private System.Windows.Forms.Button bb_data;
        private Componentes.CheckBoxDefault st_receberxmlnfe;
        private Componentes.CheckBoxDefault st_receberdanfe;
    }
}