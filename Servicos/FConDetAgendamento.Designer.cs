namespace Servicos
{
    partial class TFConDetAgendamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFConDetAgendamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.pFiltro = new Componentes.PanelDados(this.components);
            this.bb_buscar = new System.Windows.Forms.Button();
            this.cbNaoCompareceu = new Componentes.CheckBoxDefault(this.components);
            this.cbDesmarcado = new Componentes.CheckBoxDefault(this.components);
            this.cbExecutado = new Componentes.CheckBoxDefault(this.components);
            this.cbAtivo = new Componentes.CheckBoxDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dt_fin = new Componentes.EditMask(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dt_ini = new Componentes.EditMask(this.components);
            this.bb_servico = new System.Windows.Forms.Button();
            this.cd_servico = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.bb_tecnico = new System.Windows.Forms.Button();
            this.cd_tecnico = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bb_clifor = new System.Windows.Forms.Button();
            this.cd_clifor = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.bb_empresa = new System.Windows.Forms.Button();
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.gAgendamento = new Componentes.DataGridDefault(this.components);
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dt_agendamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmempresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtecnicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmcliforDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsenderecoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsservicoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.motivodesmarcarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsobsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAgendamento = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral.SuspendLayout();
            this.pFiltro.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAgendamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgendamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCentral
            // 
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.pFiltro, 0, 0);
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 0);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(1110, 607);
            this.tlpCentral.TabIndex = 0;
            // 
            // pFiltro
            // 
            this.pFiltro.Controls.Add(this.bb_buscar);
            this.pFiltro.Controls.Add(this.cbNaoCompareceu);
            this.pFiltro.Controls.Add(this.cbDesmarcado);
            this.pFiltro.Controls.Add(this.cbExecutado);
            this.pFiltro.Controls.Add(this.cbAtivo);
            this.pFiltro.Controls.Add(this.label5);
            this.pFiltro.Controls.Add(this.dt_fin);
            this.pFiltro.Controls.Add(this.label4);
            this.pFiltro.Controls.Add(this.dt_ini);
            this.pFiltro.Controls.Add(this.bb_servico);
            this.pFiltro.Controls.Add(this.cd_servico);
            this.pFiltro.Controls.Add(this.label2);
            this.pFiltro.Controls.Add(this.bb_tecnico);
            this.pFiltro.Controls.Add(this.cd_tecnico);
            this.pFiltro.Controls.Add(this.label3);
            this.pFiltro.Controls.Add(this.bb_clifor);
            this.pFiltro.Controls.Add(this.cd_clifor);
            this.pFiltro.Controls.Add(this.label1);
            this.pFiltro.Controls.Add(this.bb_empresa);
            this.pFiltro.Controls.Add(this.cd_empresa);
            this.pFiltro.Controls.Add(this.label7);
            this.pFiltro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFiltro.Location = new System.Drawing.Point(3, 3);
            this.pFiltro.Name = "pFiltro";
            this.pFiltro.NM_ProcDeletar = "";
            this.pFiltro.NM_ProcGravar = "";
            this.pFiltro.Size = new System.Drawing.Size(1104, 59);
            this.pFiltro.TabIndex = 0;
            // 
            // bb_buscar
            // 
            this.bb_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bb_buscar.ForeColor = System.Drawing.Color.Green;
            this.bb_buscar.Image = ((System.Drawing.Image)(resources.GetObject("bb_buscar.Image")));
            this.bb_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bb_buscar.Location = new System.Drawing.Point(742, 8);
            this.bb_buscar.Name = "bb_buscar";
            this.bb_buscar.Size = new System.Drawing.Size(117, 39);
            this.bb_buscar.TabIndex = 292;
            this.bb_buscar.Text = "(F7) Buscar";
            this.bb_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bb_buscar.UseVisualStyleBackColor = true;
            this.bb_buscar.Click += new System.EventHandler(this.bb_buscar_Click);
            // 
            // cbNaoCompareceu
            // 
            this.cbNaoCompareceu.AutoSize = true;
            this.cbNaoCompareceu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNaoCompareceu.ForeColor = System.Drawing.Color.Peru;
            this.cbNaoCompareceu.Location = new System.Drawing.Point(613, 33);
            this.cbNaoCompareceu.Name = "cbNaoCompareceu";
            this.cbNaoCompareceu.NM_Alias = "";
            this.cbNaoCompareceu.NM_Campo = "";
            this.cbNaoCompareceu.NM_Param = "";
            this.cbNaoCompareceu.Size = new System.Drawing.Size(123, 17);
            this.cbNaoCompareceu.ST_Gravar = false;
            this.cbNaoCompareceu.ST_LimparCampo = true;
            this.cbNaoCompareceu.ST_NotNull = false;
            this.cbNaoCompareceu.TabIndex = 13;
            this.cbNaoCompareceu.Text = "Não Compareceu";
            this.cbNaoCompareceu.UseVisualStyleBackColor = true;
            this.cbNaoCompareceu.Vl_False = "";
            this.cbNaoCompareceu.Vl_True = "";
            // 
            // cbDesmarcado
            // 
            this.cbDesmarcado.AutoSize = true;
            this.cbDesmarcado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDesmarcado.ForeColor = System.Drawing.Color.Maroon;
            this.cbDesmarcado.Location = new System.Drawing.Point(613, 7);
            this.cbDesmarcado.Name = "cbDesmarcado";
            this.cbDesmarcado.NM_Alias = "";
            this.cbDesmarcado.NM_Campo = "";
            this.cbDesmarcado.NM_Param = "";
            this.cbDesmarcado.Size = new System.Drawing.Size(96, 17);
            this.cbDesmarcado.ST_Gravar = false;
            this.cbDesmarcado.ST_LimparCampo = true;
            this.cbDesmarcado.ST_NotNull = false;
            this.cbDesmarcado.TabIndex = 12;
            this.cbDesmarcado.Text = "Desmarcado";
            this.cbDesmarcado.UseVisualStyleBackColor = true;
            this.cbDesmarcado.Vl_False = "";
            this.cbDesmarcado.Vl_True = "";
            // 
            // cbExecutado
            // 
            this.cbExecutado.AutoSize = true;
            this.cbExecutado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExecutado.ForeColor = System.Drawing.Color.Green;
            this.cbExecutado.Location = new System.Drawing.Point(521, 33);
            this.cbExecutado.Name = "cbExecutado";
            this.cbExecutado.NM_Alias = "";
            this.cbExecutado.NM_Campo = "";
            this.cbExecutado.NM_Param = "";
            this.cbExecutado.Size = new System.Drawing.Size(86, 17);
            this.cbExecutado.ST_Gravar = false;
            this.cbExecutado.ST_LimparCampo = true;
            this.cbExecutado.ST_NotNull = false;
            this.cbExecutado.TabIndex = 11;
            this.cbExecutado.Text = "Executado";
            this.cbExecutado.UseVisualStyleBackColor = true;
            this.cbExecutado.Vl_False = "";
            this.cbExecutado.Vl_True = "";
            // 
            // cbAtivo
            // 
            this.cbAtivo.AutoSize = true;
            this.cbAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAtivo.Location = new System.Drawing.Point(521, 7);
            this.cbAtivo.Name = "cbAtivo";
            this.cbAtivo.NM_Alias = "";
            this.cbAtivo.NM_Campo = "";
            this.cbAtivo.NM_Param = "";
            this.cbAtivo.Size = new System.Drawing.Size(55, 17);
            this.cbAtivo.ST_Gravar = false;
            this.cbAtivo.ST_LimparCampo = true;
            this.cbAtivo.ST_NotNull = false;
            this.cbAtivo.TabIndex = 10;
            this.cbAtivo.Text = "Ativo";
            this.cbAtivo.UseVisualStyleBackColor = true;
            this.cbAtivo.Vl_False = "";
            this.cbAtivo.Vl_True = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(357, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 291;
            this.label5.Text = "Dt. Fin.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dt_fin
            // 
            this.dt_fin.Location = new System.Drawing.Point(404, 32);
            this.dt_fin.Mask = "00/00/0000 90:00";
            this.dt_fin.Name = "dt_fin";
            this.dt_fin.NM_Alias = "";
            this.dt_fin.NM_Campo = "";
            this.dt_fin.NM_CampoBusca = "";
            this.dt_fin.NM_Param = "";
            this.dt_fin.Size = new System.Drawing.Size(100, 20);
            this.dt_fin.ST_Gravar = false;
            this.dt_fin.ST_LimpaCampo = true;
            this.dt_fin.ST_NotNull = false;
            this.dt_fin.ST_PrimaryKey = false;
            this.dt_fin.TabIndex = 9;
            this.dt_fin.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(357, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 289;
            this.label4.Text = "Dt. Ini.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dt_ini
            // 
            this.dt_ini.Location = new System.Drawing.Point(404, 4);
            this.dt_ini.Mask = "00/00/0000 90:00";
            this.dt_ini.Name = "dt_ini";
            this.dt_ini.NM_Alias = "";
            this.dt_ini.NM_Campo = "";
            this.dt_ini.NM_CampoBusca = "";
            this.dt_ini.NM_Param = "";
            this.dt_ini.Size = new System.Drawing.Size(100, 20);
            this.dt_ini.ST_Gravar = false;
            this.dt_ini.ST_LimpaCampo = true;
            this.dt_ini.ST_NotNull = false;
            this.dt_ini.ST_PrimaryKey = false;
            this.dt_ini.TabIndex = 8;
            this.dt_ini.ValidatingType = typeof(System.DateTime);
            // 
            // bb_servico
            // 
            this.bb_servico.Image = ((System.Drawing.Image)(resources.GetObject("bb_servico.Image")));
            this.bb_servico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_servico.Location = new System.Drawing.Point(323, 32);
            this.bb_servico.Name = "bb_servico";
            this.bb_servico.Size = new System.Drawing.Size(28, 20);
            this.bb_servico.TabIndex = 7;
            this.bb_servico.UseVisualStyleBackColor = true;
            this.bb_servico.Click += new System.EventHandler(this.bb_servico_Click);
            // 
            // cd_servico
            // 
            this.cd_servico.BackColor = System.Drawing.Color.White;
            this.cd_servico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_servico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_servico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_servico.Location = new System.Drawing.Point(240, 32);
            this.cd_servico.Name = "cd_servico";
            this.cd_servico.NM_Alias = "";
            this.cd_servico.NM_Campo = "cd_produto";
            this.cd_servico.NM_CampoBusca = "cd_produto";
            this.cd_servico.NM_Param = "@P_CD_EMPRESA";
            this.cd_servico.QTD_Zero = 0;
            this.cd_servico.Size = new System.Drawing.Size(82, 20);
            this.cd_servico.ST_AutoInc = false;
            this.cd_servico.ST_DisableAuto = false;
            this.cd_servico.ST_Float = false;
            this.cd_servico.ST_Gravar = true;
            this.cd_servico.ST_Int = false;
            this.cd_servico.ST_LimpaCampo = true;
            this.cd_servico.ST_NotNull = true;
            this.cd_servico.ST_PrimaryKey = false;
            this.cd_servico.TabIndex = 6;
            this.cd_servico.TabStop = false;
            this.cd_servico.TextOld = null;
            this.cd_servico.Leave += new System.EventHandler(this.cd_servico_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(186, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 287;
            this.label2.Text = "Serviço:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_tecnico
            // 
            this.bb_tecnico.Image = ((System.Drawing.Image)(resources.GetObject("bb_tecnico.Image")));
            this.bb_tecnico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tecnico.Location = new System.Drawing.Point(323, 4);
            this.bb_tecnico.Name = "bb_tecnico";
            this.bb_tecnico.Size = new System.Drawing.Size(28, 20);
            this.bb_tecnico.TabIndex = 5;
            this.bb_tecnico.UseVisualStyleBackColor = true;
            this.bb_tecnico.Click += new System.EventHandler(this.bb_tecnico_Click);
            // 
            // cd_tecnico
            // 
            this.cd_tecnico.BackColor = System.Drawing.Color.White;
            this.cd_tecnico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_tecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_tecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_tecnico.Location = new System.Drawing.Point(240, 4);
            this.cd_tecnico.Name = "cd_tecnico";
            this.cd_tecnico.NM_Alias = "";
            this.cd_tecnico.NM_Campo = "cd_clifor";
            this.cd_tecnico.NM_CampoBusca = "cd_clifor";
            this.cd_tecnico.NM_Param = "@P_CD_EMPRESA";
            this.cd_tecnico.QTD_Zero = 0;
            this.cd_tecnico.Size = new System.Drawing.Size(82, 20);
            this.cd_tecnico.ST_AutoInc = false;
            this.cd_tecnico.ST_DisableAuto = false;
            this.cd_tecnico.ST_Float = false;
            this.cd_tecnico.ST_Gravar = true;
            this.cd_tecnico.ST_Int = false;
            this.cd_tecnico.ST_LimpaCampo = true;
            this.cd_tecnico.ST_NotNull = true;
            this.cd_tecnico.ST_PrimaryKey = false;
            this.cd_tecnico.TabIndex = 4;
            this.cd_tecnico.TabStop = false;
            this.cd_tecnico.TextOld = null;
            this.cd_tecnico.Leave += new System.EventHandler(this.cd_tecnico_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(183, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 284;
            this.label3.Text = "Tecnico:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_clifor
            // 
            this.bb_clifor.Image = ((System.Drawing.Image)(resources.GetObject("bb_clifor.Image")));
            this.bb_clifor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_clifor.Location = new System.Drawing.Point(149, 32);
            this.bb_clifor.Name = "bb_clifor";
            this.bb_clifor.Size = new System.Drawing.Size(28, 20);
            this.bb_clifor.TabIndex = 3;
            this.bb_clifor.UseVisualStyleBackColor = true;
            this.bb_clifor.Click += new System.EventHandler(this.bb_clifor_Click);
            // 
            // cd_clifor
            // 
            this.cd_clifor.BackColor = System.Drawing.Color.White;
            this.cd_clifor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_clifor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_clifor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_clifor.Location = new System.Drawing.Point(66, 32);
            this.cd_clifor.Name = "cd_clifor";
            this.cd_clifor.NM_Alias = "";
            this.cd_clifor.NM_Campo = "cd_clifor";
            this.cd_clifor.NM_CampoBusca = "cd_clifor";
            this.cd_clifor.NM_Param = "@P_CD_EMPRESA";
            this.cd_clifor.QTD_Zero = 0;
            this.cd_clifor.Size = new System.Drawing.Size(82, 20);
            this.cd_clifor.ST_AutoInc = false;
            this.cd_clifor.ST_DisableAuto = false;
            this.cd_clifor.ST_Float = false;
            this.cd_clifor.ST_Gravar = true;
            this.cd_clifor.ST_Int = false;
            this.cd_clifor.ST_LimpaCampo = true;
            this.cd_clifor.ST_NotNull = true;
            this.cd_clifor.ST_PrimaryKey = false;
            this.cd_clifor.TabIndex = 2;
            this.cd_clifor.TabStop = false;
            this.cd_clifor.TextOld = null;
            this.cd_clifor.Leave += new System.EventHandler(this.cd_clifor_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 281;
            this.label1.Text = "Cliente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(149, 6);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 1;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.Color.White;
            this.cd_empresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_empresa.Location = new System.Drawing.Point(66, 6);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(82, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = false;
            this.cd_empresa.TabIndex = 0;
            this.cd_empresa.TabStop = false;
            this.cd_empresa.TextOld = null;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(9, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 278;
            this.label7.Text = "Empresa:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.gAgendamento);
            this.panelDados1.Controls.Add(this.bindingNavigator1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(3, 68);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(1104, 536);
            this.panelDados1.TabIndex = 1;
            // 
            // gAgendamento
            // 
            this.gAgendamento.AllowUserToAddRows = false;
            this.gAgendamento.AllowUserToDeleteRows = false;
            this.gAgendamento.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(231)))), ((int)(((byte)(189)))));
            this.gAgendamento.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gAgendamento.AutoGenerateColumns = false;
            this.gAgendamento.BackgroundColor = System.Drawing.Color.LightGray;
            this.gAgendamento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gAgendamento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAgendamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gAgendamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gAgendamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.Dt_agendamento,
            this.nmempresaDataGridViewTextBoxColumn,
            this.nmtecnicoDataGridViewTextBoxColumn,
            this.nmcliforDataGridViewTextBoxColumn,
            this.dsenderecoDataGridViewTextBoxColumn,
            this.dsservicoDataGridViewTextBoxColumn,
            this.motivodesmarcarDataGridViewTextBoxColumn,
            this.dsobsDataGridViewTextBoxColumn});
            this.gAgendamento.DataSource = this.bsAgendamento;
            this.gAgendamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gAgendamento.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gAgendamento.Location = new System.Drawing.Point(0, 0);
            this.gAgendamento.Name = "gAgendamento";
            this.gAgendamento.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(223)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gAgendamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gAgendamento.RowHeadersWidth = 23;
            this.gAgendamento.Size = new System.Drawing.Size(1104, 511);
            this.gAgendamento.TabIndex = 1;
            this.gAgendamento.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gAgendamento_ColumnHeaderMouseClick);
            this.gAgendamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gAgendamento_CellFormatting);
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // Dt_agendamento
            // 
            this.Dt_agendamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Dt_agendamento.DataPropertyName = "Dt_agendamento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.Dt_agendamento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dt_agendamento.HeaderText = "Dt. Agendamento";
            this.Dt_agendamento.Name = "Dt_agendamento";
            this.Dt_agendamento.ReadOnly = true;
            this.Dt_agendamento.Width = 106;
            // 
            // nmempresaDataGridViewTextBoxColumn
            // 
            this.nmempresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmempresaDataGridViewTextBoxColumn.DataPropertyName = "Nm_empresa";
            this.nmempresaDataGridViewTextBoxColumn.HeaderText = "Empresa";
            this.nmempresaDataGridViewTextBoxColumn.Name = "nmempresaDataGridViewTextBoxColumn";
            this.nmempresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmempresaDataGridViewTextBoxColumn.Width = 73;
            // 
            // nmtecnicoDataGridViewTextBoxColumn
            // 
            this.nmtecnicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmtecnicoDataGridViewTextBoxColumn.DataPropertyName = "Nm_tecnico";
            this.nmtecnicoDataGridViewTextBoxColumn.HeaderText = "Tecnico";
            this.nmtecnicoDataGridViewTextBoxColumn.Name = "nmtecnicoDataGridViewTextBoxColumn";
            this.nmtecnicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmtecnicoDataGridViewTextBoxColumn.Width = 71;
            // 
            // nmcliforDataGridViewTextBoxColumn
            // 
            this.nmcliforDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nmcliforDataGridViewTextBoxColumn.DataPropertyName = "Nm_clifor";
            this.nmcliforDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nmcliforDataGridViewTextBoxColumn.Name = "nmcliforDataGridViewTextBoxColumn";
            this.nmcliforDataGridViewTextBoxColumn.ReadOnly = true;
            this.nmcliforDataGridViewTextBoxColumn.Width = 64;
            // 
            // dsenderecoDataGridViewTextBoxColumn
            // 
            this.dsenderecoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsenderecoDataGridViewTextBoxColumn.DataPropertyName = "Ds_endereco";
            this.dsenderecoDataGridViewTextBoxColumn.HeaderText = "Endereço";
            this.dsenderecoDataGridViewTextBoxColumn.Name = "dsenderecoDataGridViewTextBoxColumn";
            this.dsenderecoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsenderecoDataGridViewTextBoxColumn.Width = 78;
            // 
            // dsservicoDataGridViewTextBoxColumn
            // 
            this.dsservicoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsservicoDataGridViewTextBoxColumn.DataPropertyName = "Ds_servico";
            this.dsservicoDataGridViewTextBoxColumn.HeaderText = "Serviço";
            this.dsservicoDataGridViewTextBoxColumn.Name = "dsservicoDataGridViewTextBoxColumn";
            this.dsservicoDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsservicoDataGridViewTextBoxColumn.Width = 68;
            // 
            // motivodesmarcarDataGridViewTextBoxColumn
            // 
            this.motivodesmarcarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.motivodesmarcarDataGridViewTextBoxColumn.DataPropertyName = "Motivodesmarcar";
            this.motivodesmarcarDataGridViewTextBoxColumn.HeaderText = "Motivo Desmarcar";
            this.motivodesmarcarDataGridViewTextBoxColumn.Name = "motivodesmarcarDataGridViewTextBoxColumn";
            this.motivodesmarcarDataGridViewTextBoxColumn.ReadOnly = true;
            this.motivodesmarcarDataGridViewTextBoxColumn.Width = 108;
            // 
            // dsobsDataGridViewTextBoxColumn
            // 
            this.dsobsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dsobsDataGridViewTextBoxColumn.DataPropertyName = "Ds_obs";
            this.dsobsDataGridViewTextBoxColumn.HeaderText = "Observação";
            this.dsobsDataGridViewTextBoxColumn.Name = "dsobsDataGridViewTextBoxColumn";
            this.dsobsDataGridViewTextBoxColumn.ReadOnly = true;
            this.dsobsDataGridViewTextBoxColumn.Width = 90;
            // 
            // bsAgendamento
            // 
            this.bsAgendamento.DataSource = typeof(CamadaDados.Servicos.TList_Agendamento);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bsAgendamento;
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
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 511);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1104, 25);
            this.bindingNavigator1.TabIndex = 2;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
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
            // TFConDetAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 607);
            this.Controls.Add(this.tlpCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFConDetAgendamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Detalhada Agendamento";
            this.Load += new System.EventHandler(this.TFConDetAgendamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFConDetAgendamento_KeyDown);
            this.tlpCentral.ResumeLayout(false);
            this.pFiltro.ResumeLayout(false);
            this.pFiltro.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gAgendamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAgendamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados pFiltro;
        private System.Windows.Forms.Button bb_servico;
        private Componentes.EditDefault cd_servico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bb_tecnico;
        private Componentes.EditDefault cd_tecnico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bb_clifor;
        private Componentes.EditDefault cd_clifor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bb_empresa;
        private Componentes.EditDefault cd_empresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private Componentes.EditMask dt_fin;
        private System.Windows.Forms.Label label4;
        private Componentes.EditMask dt_ini;
        private Componentes.CheckBoxDefault cbNaoCompareceu;
        private Componentes.CheckBoxDefault cbDesmarcado;
        private Componentes.CheckBoxDefault cbExecutado;
        private Componentes.CheckBoxDefault cbAtivo;
        private Componentes.PanelDados panelDados1;
        private Componentes.DataGridDefault gAgendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dt_agendamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmempresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtecnicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmcliforDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsenderecoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsservicoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn motivodesmarcarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsobsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsAgendamento;
        private System.Windows.Forms.Button bb_buscar;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
    }
}