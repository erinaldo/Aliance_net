namespace Servicos
{
    partial class TFAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAtividade));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.bsAtividade = new System.Windows.Forms.BindingSource(this.components);
            this.pDados = new Componentes.PanelDados(this.components);
            this.id_etapa = new Componentes.EditDefault(this.components);
            this.NM_Empresa = new Componentes.EditDefault(this.components);
            this.BB_Empresa = new System.Windows.Forms.Button();
            this.CD_Empresa = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bb_projeto = new System.Windows.Forms.Button();
            this.ds_projeto = new Componentes.EditDefault(this.components);
            this.id_projeto = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_etapa = new System.Windows.Forms.Button();
            this.ds_etapa = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Ds_observacao = new Componentes.EditDefault(this.components);
            this.DT_Prevista = new Componentes.EditData(this.components);
            this.DT_Atividade = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Ds_atividade = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.BB_Tecnico = new System.Windows.Forms.Button();
            this.DS_Funcao = new Componentes.EditDefault(this.components);
            this.ID_Tecnico = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).BeginInit();
            this.pDados.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(745, 43);
            this.barraMenu.TabIndex = 16;
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
            // bsAtividade
            // 
            this.bsAtividade.DataSource = typeof(CamadaDados.Servicos.TList_LanAtividades);
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDados.Controls.Add(this.id_etapa);
            this.pDados.Controls.Add(this.NM_Empresa);
            this.pDados.Controls.Add(this.BB_Empresa);
            this.pDados.Controls.Add(this.CD_Empresa);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.bb_projeto);
            this.pDados.Controls.Add(this.ds_projeto);
            this.pDados.Controls.Add(this.id_projeto);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.bb_etapa);
            this.pDados.Controls.Add(this.ds_etapa);
            this.pDados.Controls.Add(this.label5);
            this.pDados.Controls.Add(this.Ds_observacao);
            this.pDados.Controls.Add(this.DT_Prevista);
            this.pDados.Controls.Add(this.DT_Atividade);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.label6);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.Ds_atividade);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.BB_Tecnico);
            this.pDados.Controls.Add(this.DS_Funcao);
            this.pDados.Controls.Add(this.ID_Tecnico);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(745, 341);
            this.pDados.TabIndex = 17;
            // 
            // id_etapa
            // 
            this.id_etapa.BackColor = System.Drawing.Color.White;
            this.id_etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_etapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_etapa.Location = new System.Drawing.Point(91, 64);
            this.id_etapa.Name = "id_etapa";
            this.id_etapa.NM_Alias = "";
            this.id_etapa.NM_Campo = "id_evolucao";
            this.id_etapa.NM_CampoBusca = "id_evolucao";
            this.id_etapa.NM_Param = "@P_CD_CLIFOR";
            this.id_etapa.QTD_Zero = 0;
            this.id_etapa.Size = new System.Drawing.Size(65, 20);
            this.id_etapa.ST_AutoInc = false;
            this.id_etapa.ST_DisableAuto = false;
            this.id_etapa.ST_Float = false;
            this.id_etapa.ST_Gravar = true;
            this.id_etapa.ST_Int = false;
            this.id_etapa.ST_LimpaCampo = true;
            this.id_etapa.ST_NotNull = false;
            this.id_etapa.ST_PrimaryKey = false;
            this.id_etapa.TabIndex = 272;
            this.id_etapa.TextOld = null;
            this.id_etapa.Leave += new System.EventHandler(this.id_etapa_Leave);
            // 
            // NM_Empresa
            // 
            this.NM_Empresa.BackColor = System.Drawing.SystemColors.Window;
            this.NM_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NM_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NM_Empresa.Enabled = false;
            this.NM_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.NM_Empresa.Location = new System.Drawing.Point(190, 8);
            this.NM_Empresa.Name = "NM_Empresa";
            this.NM_Empresa.NM_Alias = "";
            this.NM_Empresa.NM_Campo = "NM_Empresa";
            this.NM_Empresa.NM_CampoBusca = "NM_Empresa";
            this.NM_Empresa.NM_Param = "";
            this.NM_Empresa.QTD_Zero = 0;
            this.NM_Empresa.ReadOnly = true;
            this.NM_Empresa.Size = new System.Drawing.Size(527, 20);
            this.NM_Empresa.ST_AutoInc = false;
            this.NM_Empresa.ST_DisableAuto = false;
            this.NM_Empresa.ST_Float = false;
            this.NM_Empresa.ST_Gravar = false;
            this.NM_Empresa.ST_Int = false;
            this.NM_Empresa.ST_LimpaCampo = true;
            this.NM_Empresa.ST_NotNull = false;
            this.NM_Empresa.ST_PrimaryKey = false;
            this.NM_Empresa.TabIndex = 270;
            this.NM_Empresa.TextOld = null;
            // 
            // BB_Empresa
            // 
            this.BB_Empresa.Image = ((System.Drawing.Image)(resources.GetObject("BB_Empresa.Image")));
            this.BB_Empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Empresa.Location = new System.Drawing.Point(157, 10);
            this.BB_Empresa.Name = "BB_Empresa";
            this.BB_Empresa.Size = new System.Drawing.Size(28, 20);
            this.BB_Empresa.TabIndex = 269;
            this.BB_Empresa.UseVisualStyleBackColor = true;
            this.BB_Empresa.Click += new System.EventHandler(this.BB_Empresa_Click);
            // 
            // CD_Empresa
            // 
            this.CD_Empresa.BackColor = System.Drawing.Color.White;
            this.CD_Empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CD_Empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CD_Empresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.CD_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.CD_Empresa.Location = new System.Drawing.Point(91, 9);
            this.CD_Empresa.Name = "CD_Empresa";
            this.CD_Empresa.NM_Alias = "";
            this.CD_Empresa.NM_Campo = "CD_Empresa";
            this.CD_Empresa.NM_CampoBusca = "CD_Empresa";
            this.CD_Empresa.NM_Param = "@P_CD_EMPRESA";
            this.CD_Empresa.QTD_Zero = 0;
            this.CD_Empresa.Size = new System.Drawing.Size(65, 20);
            this.CD_Empresa.ST_AutoInc = false;
            this.CD_Empresa.ST_DisableAuto = false;
            this.CD_Empresa.ST_Float = false;
            this.CD_Empresa.ST_Gravar = true;
            this.CD_Empresa.ST_Int = false;
            this.CD_Empresa.ST_LimpaCampo = true;
            this.CD_Empresa.ST_NotNull = true;
            this.CD_Empresa.ST_PrimaryKey = false;
            this.CD_Empresa.TabIndex = 268;
            this.CD_Empresa.TabStop = false;
            this.CD_Empresa.TextOld = null;
            this.CD_Empresa.Leave += new System.EventHandler(this.CD_Empresa_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(26, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 271;
            this.label7.Text = "Empresa:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(34, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 267;
            this.label3.Text = "Projeto:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_projeto
            // 
            this.bb_projeto.Image = ((System.Drawing.Image)(resources.GetObject("bb_projeto.Image")));
            this.bb_projeto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_projeto.Location = new System.Drawing.Point(157, 36);
            this.bb_projeto.Name = "bb_projeto";
            this.bb_projeto.Size = new System.Drawing.Size(28, 19);
            this.bb_projeto.TabIndex = 1;
            this.bb_projeto.UseVisualStyleBackColor = true;
            this.bb_projeto.Click += new System.EventHandler(this.bb_projeto_Click);
            // 
            // ds_projeto
            // 
            this.ds_projeto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_projeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_projeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_projeto.Enabled = false;
            this.ds_projeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_projeto.Location = new System.Drawing.Point(190, 35);
            this.ds_projeto.Name = "ds_projeto";
            this.ds_projeto.NM_Alias = "";
            this.ds_projeto.NM_Campo = "ds_servico";
            this.ds_projeto.NM_CampoBusca = "ds_servico";
            this.ds_projeto.NM_Param = "@P_NM_CLIFOR";
            this.ds_projeto.QTD_Zero = 0;
            this.ds_projeto.ReadOnly = true;
            this.ds_projeto.Size = new System.Drawing.Size(528, 20);
            this.ds_projeto.ST_AutoInc = false;
            this.ds_projeto.ST_DisableAuto = false;
            this.ds_projeto.ST_Float = false;
            this.ds_projeto.ST_Gravar = false;
            this.ds_projeto.ST_Int = false;
            this.ds_projeto.ST_LimpaCampo = true;
            this.ds_projeto.ST_NotNull = false;
            this.ds_projeto.ST_PrimaryKey = false;
            this.ds_projeto.TabIndex = 266;
            this.ds_projeto.TextOld = null;
            // 
            // id_projeto
            // 
            this.id_projeto.BackColor = System.Drawing.Color.White;
            this.id_projeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.id_projeto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.id_projeto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Id_os", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.id_projeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.id_projeto.Location = new System.Drawing.Point(91, 35);
            this.id_projeto.Name = "id_projeto";
            this.id_projeto.NM_Alias = "";
            this.id_projeto.NM_Campo = "id_os";
            this.id_projeto.NM_CampoBusca = "id_os";
            this.id_projeto.NM_Param = "@P_CD_CLIFOR";
            this.id_projeto.QTD_Zero = 0;
            this.id_projeto.Size = new System.Drawing.Size(65, 20);
            this.id_projeto.ST_AutoInc = false;
            this.id_projeto.ST_DisableAuto = false;
            this.id_projeto.ST_Float = false;
            this.id_projeto.ST_Gravar = true;
            this.id_projeto.ST_Int = false;
            this.id_projeto.ST_LimpaCampo = true;
            this.id_projeto.ST_NotNull = false;
            this.id_projeto.ST_PrimaryKey = false;
            this.id_projeto.TabIndex = 0;
            this.id_projeto.TabStop = false;
            this.id_projeto.TextOld = null;
            this.id_projeto.Leave += new System.EventHandler(this.id_projeto_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(41, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 263;
            this.label2.Text = "Etapa:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_etapa
            // 
            this.bb_etapa.Image = ((System.Drawing.Image)(resources.GetObject("bb_etapa.Image")));
            this.bb_etapa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_etapa.Location = new System.Drawing.Point(157, 64);
            this.bb_etapa.Name = "bb_etapa";
            this.bb_etapa.Size = new System.Drawing.Size(28, 19);
            this.bb_etapa.TabIndex = 3;
            this.bb_etapa.UseVisualStyleBackColor = true;
            this.bb_etapa.Click += new System.EventHandler(this.bb_etapa_Click);
            // 
            // ds_etapa
            // 
            this.ds_etapa.BackColor = System.Drawing.SystemColors.Window;
            this.ds_etapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_etapa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_etapa.Enabled = false;
            this.ds_etapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_etapa.Location = new System.Drawing.Point(190, 63);
            this.ds_etapa.Name = "ds_etapa";
            this.ds_etapa.NM_Alias = "";
            this.ds_etapa.NM_Campo = "ds_evolucao";
            this.ds_etapa.NM_CampoBusca = "ds_evolucao";
            this.ds_etapa.NM_Param = "@P_NM_CLIFOR";
            this.ds_etapa.QTD_Zero = 0;
            this.ds_etapa.ReadOnly = true;
            this.ds_etapa.Size = new System.Drawing.Size(528, 20);
            this.ds_etapa.ST_AutoInc = false;
            this.ds_etapa.ST_DisableAuto = false;
            this.ds_etapa.ST_Float = false;
            this.ds_etapa.ST_Gravar = false;
            this.ds_etapa.ST_Int = false;
            this.ds_etapa.ST_LimpaCampo = true;
            this.ds_etapa.ST_NotNull = false;
            this.ds_etapa.ST_PrimaryKey = false;
            this.ds_etapa.TabIndex = 262;
            this.ds_etapa.TextOld = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(52, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 259;
            this.label5.Text = "Obs:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ds_observacao
            // 
            this.Ds_observacao.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_observacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_observacao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_observacao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_observacao.Location = new System.Drawing.Point(91, 201);
            this.Ds_observacao.Multiline = true;
            this.Ds_observacao.Name = "Ds_observacao";
            this.Ds_observacao.NM_Alias = "";
            this.Ds_observacao.NM_Campo = "";
            this.Ds_observacao.NM_CampoBusca = "";
            this.Ds_observacao.NM_Param = "";
            this.Ds_observacao.QTD_Zero = 0;
            this.Ds_observacao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Ds_observacao.Size = new System.Drawing.Size(629, 124);
            this.Ds_observacao.ST_AutoInc = false;
            this.Ds_observacao.ST_DisableAuto = false;
            this.Ds_observacao.ST_Float = false;
            this.Ds_observacao.ST_Gravar = false;
            this.Ds_observacao.ST_Int = false;
            this.Ds_observacao.ST_LimpaCampo = true;
            this.Ds_observacao.ST_NotNull = false;
            this.Ds_observacao.ST_PrimaryKey = false;
            this.Ds_observacao.TabIndex = 2;
            this.Ds_observacao.TextOld = null;
            // 
            // DT_Prevista
            // 
            this.DT_Prevista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Prevista.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Prevista.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Dt_PrevConclusao", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Prevista.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Prevista.Location = new System.Drawing.Point(476, 175);
            this.DT_Prevista.Mask = "00/00/0000";
            this.DT_Prevista.Name = "DT_Prevista";
            this.DT_Prevista.NM_Alias = "";
            this.DT_Prevista.NM_Campo = "";
            this.DT_Prevista.NM_CampoBusca = "";
            this.DT_Prevista.NM_Param = "";
            this.DT_Prevista.Operador = "";
            this.DT_Prevista.Size = new System.Drawing.Size(83, 20);
            this.DT_Prevista.ST_Gravar = true;
            this.DT_Prevista.ST_LimpaCampo = true;
            this.DT_Prevista.ST_NotNull = false;
            this.DT_Prevista.ST_PrimaryKey = false;
            this.DT_Prevista.TabIndex = 1;
            // 
            // DT_Atividade
            // 
            this.DT_Atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DT_Atividade.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.DT_Atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Dt_atividadestr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DT_Atividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DT_Atividade.Location = new System.Drawing.Point(190, 175);
            this.DT_Atividade.Mask = "00/00/0000";
            this.DT_Atividade.Name = "DT_Atividade";
            this.DT_Atividade.NM_Alias = "";
            this.DT_Atividade.NM_Campo = "";
            this.DT_Atividade.NM_CampoBusca = "";
            this.DT_Atividade.NM_Param = "";
            this.DT_Atividade.Operador = "";
            this.DT_Atividade.Size = new System.Drawing.Size(94, 20);
            this.DT_Atividade.ST_Gravar = true;
            this.DT_Atividade.ST_LimpaCampo = true;
            this.DT_Atividade.ST_NotNull = false;
            this.DT_Atividade.ST_PrimaryKey = false;
            this.DT_Atividade.TabIndex = 254;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(347, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 257;
            this.label8.Text = "Previsão Conclusão:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(88, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 256;
            this.label6.Text = "Dt.Atividade:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(21, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 253;
            this.label1.Text = "Atividade:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ds_atividade
            // 
            this.Ds_atividade.BackColor = System.Drawing.SystemColors.Window;
            this.Ds_atividade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Ds_atividade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Ds_atividade.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_atividade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Ds_atividade.Location = new System.Drawing.Point(91, 117);
            this.Ds_atividade.Multiline = true;
            this.Ds_atividade.Name = "Ds_atividade";
            this.Ds_atividade.NM_Alias = "";
            this.Ds_atividade.NM_Campo = "";
            this.Ds_atividade.NM_CampoBusca = "";
            this.Ds_atividade.NM_Param = "";
            this.Ds_atividade.QTD_Zero = 0;
            this.Ds_atividade.Size = new System.Drawing.Size(627, 52);
            this.Ds_atividade.ST_AutoInc = false;
            this.Ds_atividade.ST_DisableAuto = false;
            this.Ds_atividade.ST_Float = false;
            this.Ds_atividade.ST_Gravar = false;
            this.Ds_atividade.ST_Int = false;
            this.Ds_atividade.ST_LimpaCampo = true;
            this.Ds_atividade.ST_NotNull = false;
            this.Ds_atividade.ST_PrimaryKey = false;
            this.Ds_atividade.TabIndex = 0;
            this.Ds_atividade.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(28, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 251;
            this.label4.Text = "Técnico:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BB_Tecnico
            // 
            this.BB_Tecnico.Image = ((System.Drawing.Image)(resources.GetObject("BB_Tecnico.Image")));
            this.BB_Tecnico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BB_Tecnico.Location = new System.Drawing.Point(157, 92);
            this.BB_Tecnico.Name = "BB_Tecnico";
            this.BB_Tecnico.Size = new System.Drawing.Size(28, 19);
            this.BB_Tecnico.TabIndex = 5;
            this.BB_Tecnico.UseVisualStyleBackColor = true;
            this.BB_Tecnico.Click += new System.EventHandler(this.BB_Tecnico_Click);
            // 
            // DS_Funcao
            // 
            this.DS_Funcao.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Funcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DS_Funcao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Funcao.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Ds_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DS_Funcao.Enabled = false;
            this.DS_Funcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.DS_Funcao.Location = new System.Drawing.Point(190, 91);
            this.DS_Funcao.Name = "DS_Funcao";
            this.DS_Funcao.NM_Alias = "";
            this.DS_Funcao.NM_Campo = "nm_clifor";
            this.DS_Funcao.NM_CampoBusca = "nm_clifor";
            this.DS_Funcao.NM_Param = "@P_NM_CLIFOR";
            this.DS_Funcao.QTD_Zero = 0;
            this.DS_Funcao.ReadOnly = true;
            this.DS_Funcao.Size = new System.Drawing.Size(528, 20);
            this.DS_Funcao.ST_AutoInc = false;
            this.DS_Funcao.ST_DisableAuto = false;
            this.DS_Funcao.ST_Float = false;
            this.DS_Funcao.ST_Gravar = false;
            this.DS_Funcao.ST_Int = false;
            this.DS_Funcao.ST_LimpaCampo = true;
            this.DS_Funcao.ST_NotNull = false;
            this.DS_Funcao.ST_PrimaryKey = false;
            this.DS_Funcao.TabIndex = 250;
            this.DS_Funcao.TextOld = null;
            // 
            // ID_Tecnico
            // 
            this.ID_Tecnico.BackColor = System.Drawing.Color.White;
            this.ID_Tecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_Tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ID_Tecnico.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsAtividade, "Cd_tecnico", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ID_Tecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ID_Tecnico.Location = new System.Drawing.Point(91, 91);
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
            this.ID_Tecnico.TabIndex = 4;
            this.ID_Tecnico.TextOld = null;
            this.ID_Tecnico.Leave += new System.EventHandler(this.ID_Tecnico_Leave);
            // 
            // TFAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 384);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "TFAtividade";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento de Atividades";
            this.Load += new System.EventHandler(this.TFAtividade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAtividade_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtividade)).EndInit();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private System.Windows.Forms.BindingSource bsAtividade;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button bb_etapa;
        public Componentes.EditDefault ds_etapa;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault Ds_observacao;
        private Componentes.EditData DT_Prevista;
        private Componentes.EditData DT_Atividade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault Ds_atividade;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button BB_Tecnico;
        public Componentes.EditDefault DS_Funcao;
        public Componentes.EditDefault ID_Tecnico;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button bb_projeto;
        public Componentes.EditDefault ds_projeto;
        public Componentes.EditDefault id_projeto;
        private Componentes.EditDefault NM_Empresa;
        private System.Windows.Forms.Button BB_Empresa;
        private Componentes.EditDefault CD_Empresa;
        private System.Windows.Forms.Label label7;
        public Componentes.EditDefault id_etapa;
    }
}