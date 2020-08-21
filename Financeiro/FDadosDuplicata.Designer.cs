namespace Financeiro
{
    partial class TFDadosDuplicata
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
            System.Windows.Forms.Label tp_duplicataLabel;
            System.Windows.Forms.Label cd_condpgtoLabel;
            System.Windows.Forms.Label cd_historicoLabel;
            System.Windows.Forms.Label tp_doctoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDadosDuplicata));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ds_ccusto = new Componentes.EditDefault(this.components);
            this.cd_ccusto = new Componentes.EditDefault(this.components);
            this.bb_ccusto = new System.Windows.Forms.Button();
            this.tp_docto = new Componentes.EditDefault(this.components);
            this.ds_tpdocto = new Componentes.EditDefault(this.components);
            this.bb_tpdocto = new System.Windows.Forms.Button();
            this.cd_historico = new Componentes.EditDefault(this.components);
            this.bb_historico = new System.Windows.Forms.Button();
            this.ds_historico = new Componentes.EditDefault(this.components);
            this.bb_condpgto = new System.Windows.Forms.Button();
            this.cd_condpgto = new Componentes.EditDefault(this.components);
            this.ds_condpagto = new Componentes.EditDefault(this.components);
            this.ds_tpduplicata = new Componentes.EditDefault(this.components);
            this.tp_mov = new Componentes.EditDefault(this.components);
            this.tp_duplicata = new Componentes.EditDefault(this.components);
            this.bb_tpduplicata = new System.Windows.Forms.Button();
            tp_duplicataLabel = new System.Windows.Forms.Label();
            cd_condpgtoLabel = new System.Windows.Forms.Label();
            cd_historicoLabel = new System.Windows.Forms.Label();
            tp_doctoLabel = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp_duplicataLabel
            // 
            tp_duplicataLabel.AutoSize = true;
            tp_duplicataLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tp_duplicataLabel.Location = new System.Drawing.Point(14, 15);
            tp_duplicataLabel.Name = "tp_duplicataLabel";
            tp_duplicataLabel.Size = new System.Drawing.Size(79, 13);
            tp_duplicataLabel.TabIndex = 32;
            tp_duplicataLabel.Text = "Tipo Duplicata:";
            // 
            // cd_condpgtoLabel
            // 
            cd_condpgtoLabel.AutoSize = true;
            cd_condpgtoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_condpgtoLabel.Location = new System.Drawing.Point(29, 42);
            cd_condpgtoLabel.Name = "cd_condpgtoLabel";
            cd_condpgtoLabel.Size = new System.Drawing.Size(63, 13);
            cd_condpgtoLabel.TabIndex = 39;
            cd_condpgtoLabel.Text = "Cond. Pgto:";
            // 
            // cd_historicoLabel
            // 
            cd_historicoLabel.AutoSize = true;
            cd_historicoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            cd_historicoLabel.Location = new System.Drawing.Point(39, 68);
            cd_historicoLabel.Name = "cd_historicoLabel";
            cd_historicoLabel.Size = new System.Drawing.Size(51, 13);
            cd_historicoLabel.TabIndex = 43;
            cd_historicoLabel.Text = "Histórico:";
            // 
            // tp_doctoLabel
            // 
            tp_doctoLabel.AutoSize = true;
            tp_doctoLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tp_doctoLabel.Location = new System.Drawing.Point(3, 93);
            tp_doctoLabel.Name = "tp_doctoLabel";
            tp_doctoLabel.Size = new System.Drawing.Size(89, 13);
            tp_doctoLabel.TabIndex = 46;
            tp_doctoLabel.Text = "Tipo Documento:";
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_inutilizar,
            this.bb_cancelar});
            this.barraMenu.Location = new System.Drawing.Point(0, 0);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(486, 43);
            this.barraMenu.TabIndex = 21;
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
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.label7);
            this.pDados.Controls.Add(this.ds_ccusto);
            this.pDados.Controls.Add(this.cd_ccusto);
            this.pDados.Controls.Add(this.bb_ccusto);
            this.pDados.Controls.Add(tp_doctoLabel);
            this.pDados.Controls.Add(this.tp_docto);
            this.pDados.Controls.Add(this.ds_tpdocto);
            this.pDados.Controls.Add(this.bb_tpdocto);
            this.pDados.Controls.Add(this.cd_historico);
            this.pDados.Controls.Add(cd_historicoLabel);
            this.pDados.Controls.Add(this.bb_historico);
            this.pDados.Controls.Add(this.ds_historico);
            this.pDados.Controls.Add(this.bb_condpgto);
            this.pDados.Controls.Add(cd_condpgtoLabel);
            this.pDados.Controls.Add(this.cd_condpgto);
            this.pDados.Controls.Add(this.ds_condpagto);
            this.pDados.Controls.Add(this.ds_tpduplicata);
            this.pDados.Controls.Add(this.tp_mov);
            this.pDados.Controls.Add(tp_duplicataLabel);
            this.pDados.Controls.Add(this.tp_duplicata);
            this.pDados.Controls.Add(this.bb_tpduplicata);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(486, 149);
            this.pDados.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(0, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Centro Resultado:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ds_ccusto
            // 
            this.ds_ccusto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_ccusto.Enabled = false;
            this.ds_ccusto.Location = new System.Drawing.Point(186, 116);
            this.ds_ccusto.Name = "ds_ccusto";
            this.ds_ccusto.NM_Alias = "";
            this.ds_ccusto.NM_Campo = "ds_centroresultado";
            this.ds_ccusto.NM_CampoBusca = "ds_centroresultado";
            this.ds_ccusto.NM_Param = "@P_NR_DOCTO";
            this.ds_ccusto.QTD_Zero = 0;
            this.ds_ccusto.Size = new System.Drawing.Size(286, 20);
            this.ds_ccusto.ST_AutoInc = false;
            this.ds_ccusto.ST_DisableAuto = false;
            this.ds_ccusto.ST_Float = false;
            this.ds_ccusto.ST_Gravar = false;
            this.ds_ccusto.ST_Int = false;
            this.ds_ccusto.ST_LimpaCampo = true;
            this.ds_ccusto.ST_NotNull = false;
            this.ds_ccusto.ST_PrimaryKey = false;
            this.ds_ccusto.TabIndex = 51;
            this.ds_ccusto.TextOld = null;
            // 
            // cd_ccusto
            // 
            this.cd_ccusto.BackColor = System.Drawing.Color.White;
            this.cd_ccusto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_ccusto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_ccusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_ccusto.Location = new System.Drawing.Point(93, 115);
            this.cd_ccusto.Name = "cd_ccusto";
            this.cd_ccusto.NM_Alias = "";
            this.cd_ccusto.NM_Campo = "cd_centroresult";
            this.cd_ccusto.NM_CampoBusca = "cd_centroresult";
            this.cd_ccusto.NM_Param = "@P_CD_EMPRESA";
            this.cd_ccusto.QTD_Zero = 0;
            this.cd_ccusto.Size = new System.Drawing.Size(61, 20);
            this.cd_ccusto.ST_AutoInc = false;
            this.cd_ccusto.ST_DisableAuto = false;
            this.cd_ccusto.ST_Float = false;
            this.cd_ccusto.ST_Gravar = true;
            this.cd_ccusto.ST_Int = false;
            this.cd_ccusto.ST_LimpaCampo = true;
            this.cd_ccusto.ST_NotNull = false;
            this.cd_ccusto.ST_PrimaryKey = false;
            this.cd_ccusto.TabIndex = 8;
            this.cd_ccusto.TextOld = null;
            this.cd_ccusto.Leave += new System.EventHandler(this.cd_ccusto_Leave);
            // 
            // bb_ccusto
            // 
            this.bb_ccusto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_ccusto.Image = ((System.Drawing.Image)(resources.GetObject("bb_ccusto.Image")));
            this.bb_ccusto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_ccusto.Location = new System.Drawing.Point(155, 115);
            this.bb_ccusto.Name = "bb_ccusto";
            this.bb_ccusto.Size = new System.Drawing.Size(30, 20);
            this.bb_ccusto.TabIndex = 9;
            this.bb_ccusto.UseVisualStyleBackColor = false;
            this.bb_ccusto.Click += new System.EventHandler(this.bb_ccusto_Click);
            // 
            // tp_docto
            // 
            this.tp_docto.BackColor = System.Drawing.SystemColors.Window;
            this.tp_docto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_docto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_docto.Location = new System.Drawing.Point(93, 90);
            this.tp_docto.MaxLength = 3;
            this.tp_docto.Name = "tp_docto";
            this.tp_docto.NM_Alias = "";
            this.tp_docto.NM_Campo = "Tipo Documento";
            this.tp_docto.NM_CampoBusca = "tp_docto";
            this.tp_docto.NM_Param = "@P_TP_DOCTO";
            this.tp_docto.QTD_Zero = 0;
            this.tp_docto.Size = new System.Drawing.Size(34, 20);
            this.tp_docto.ST_AutoInc = false;
            this.tp_docto.ST_DisableAuto = false;
            this.tp_docto.ST_Float = false;
            this.tp_docto.ST_Gravar = true;
            this.tp_docto.ST_Int = false;
            this.tp_docto.ST_LimpaCampo = true;
            this.tp_docto.ST_NotNull = false;
            this.tp_docto.ST_PrimaryKey = false;
            this.tp_docto.TabIndex = 6;
            this.tp_docto.TextOld = null;
            this.tp_docto.Leave += new System.EventHandler(this.tp_docto_Leave);
            // 
            // ds_tpdocto
            // 
            this.ds_tpdocto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpdocto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpdocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpdocto.Enabled = false;
            this.ds_tpdocto.Location = new System.Drawing.Point(162, 90);
            this.ds_tpdocto.Name = "ds_tpdocto";
            this.ds_tpdocto.NM_Alias = "";
            this.ds_tpdocto.NM_Campo = "ds_tpdocto";
            this.ds_tpdocto.NM_CampoBusca = "ds_tpdocto";
            this.ds_tpdocto.NM_Param = "@P_DS_TPDOCTO";
            this.ds_tpdocto.QTD_Zero = 0;
            this.ds_tpdocto.Size = new System.Drawing.Size(311, 20);
            this.ds_tpdocto.ST_AutoInc = false;
            this.ds_tpdocto.ST_DisableAuto = false;
            this.ds_tpdocto.ST_Float = false;
            this.ds_tpdocto.ST_Gravar = false;
            this.ds_tpdocto.ST_Int = false;
            this.ds_tpdocto.ST_LimpaCampo = true;
            this.ds_tpdocto.ST_NotNull = false;
            this.ds_tpdocto.ST_PrimaryKey = false;
            this.ds_tpdocto.TabIndex = 48;
            this.ds_tpdocto.TextOld = null;
            // 
            // bb_tpdocto
            // 
            this.bb_tpdocto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpdocto.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpdocto.Image")));
            this.bb_tpdocto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpdocto.Location = new System.Drawing.Point(128, 90);
            this.bb_tpdocto.Name = "bb_tpdocto";
            this.bb_tpdocto.Size = new System.Drawing.Size(28, 19);
            this.bb_tpdocto.TabIndex = 7;
            this.bb_tpdocto.UseVisualStyleBackColor = false;
            this.bb_tpdocto.Click += new System.EventHandler(this.bb_tpdocto_Click);
            // 
            // cd_historico
            // 
            this.cd_historico.BackColor = System.Drawing.SystemColors.Window;
            this.cd_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_historico.Location = new System.Drawing.Point(93, 65);
            this.cd_historico.MaxLength = 4;
            this.cd_historico.Name = "cd_historico";
            this.cd_historico.NM_Alias = "";
            this.cd_historico.NM_Campo = "Histórico";
            this.cd_historico.NM_CampoBusca = "cd_historico";
            this.cd_historico.NM_Param = "@P_CD_HISTORICO";
            this.cd_historico.QTD_Zero = 0;
            this.cd_historico.Size = new System.Drawing.Size(67, 20);
            this.cd_historico.ST_AutoInc = false;
            this.cd_historico.ST_DisableAuto = false;
            this.cd_historico.ST_Float = false;
            this.cd_historico.ST_Gravar = true;
            this.cd_historico.ST_Int = false;
            this.cd_historico.ST_LimpaCampo = true;
            this.cd_historico.ST_NotNull = true;
            this.cd_historico.ST_PrimaryKey = false;
            this.cd_historico.TabIndex = 4;
            this.cd_historico.TextOld = null;
            this.cd_historico.Leave += new System.EventHandler(this.cd_historico_Leave);
            // 
            // bb_historico
            // 
            this.bb_historico.BackColor = System.Drawing.SystemColors.Control;
            this.bb_historico.Image = ((System.Drawing.Image)(resources.GetObject("bb_historico.Image")));
            this.bb_historico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_historico.Location = new System.Drawing.Point(161, 65);
            this.bb_historico.Name = "bb_historico";
            this.bb_historico.Size = new System.Drawing.Size(28, 19);
            this.bb_historico.TabIndex = 5;
            this.bb_historico.UseVisualStyleBackColor = false;
            this.bb_historico.Click += new System.EventHandler(this.bb_historico_Click);
            // 
            // ds_historico
            // 
            this.ds_historico.BackColor = System.Drawing.SystemColors.Window;
            this.ds_historico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_historico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_historico.Enabled = false;
            this.ds_historico.Location = new System.Drawing.Point(195, 65);
            this.ds_historico.Name = "ds_historico";
            this.ds_historico.NM_Alias = "";
            this.ds_historico.NM_Campo = "ds_historico";
            this.ds_historico.NM_CampoBusca = "ds_historico";
            this.ds_historico.NM_Param = "@P_DS_HISTORICO";
            this.ds_historico.QTD_Zero = 0;
            this.ds_historico.Size = new System.Drawing.Size(278, 20);
            this.ds_historico.ST_AutoInc = false;
            this.ds_historico.ST_DisableAuto = false;
            this.ds_historico.ST_Float = false;
            this.ds_historico.ST_Gravar = false;
            this.ds_historico.ST_Int = false;
            this.ds_historico.ST_LimpaCampo = true;
            this.ds_historico.ST_NotNull = false;
            this.ds_historico.ST_PrimaryKey = false;
            this.ds_historico.TabIndex = 44;
            this.ds_historico.TextOld = null;
            // 
            // bb_condpgto
            // 
            this.bb_condpgto.BackColor = System.Drawing.SystemColors.Control;
            this.bb_condpgto.Image = ((System.Drawing.Image)(resources.GetObject("bb_condpgto.Image")));
            this.bb_condpgto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_condpgto.Location = new System.Drawing.Point(128, 39);
            this.bb_condpgto.Name = "bb_condpgto";
            this.bb_condpgto.Size = new System.Drawing.Size(28, 19);
            this.bb_condpgto.TabIndex = 3;
            this.bb_condpgto.UseVisualStyleBackColor = false;
            this.bb_condpgto.Click += new System.EventHandler(this.bb_condpgto_Click);
            // 
            // cd_condpgto
            // 
            this.cd_condpgto.BackColor = System.Drawing.SystemColors.Window;
            this.cd_condpgto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_condpgto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_condpgto.Location = new System.Drawing.Point(93, 39);
            this.cd_condpgto.MaxLength = 3;
            this.cd_condpgto.Name = "cd_condpgto";
            this.cd_condpgto.NM_Alias = "";
            this.cd_condpgto.NM_Campo = "Condição de Pagamento";
            this.cd_condpgto.NM_CampoBusca = "cd_condpgto";
            this.cd_condpgto.NM_Param = "@P_CD_CONDPGTO";
            this.cd_condpgto.QTD_Zero = 0;
            this.cd_condpgto.Size = new System.Drawing.Size(34, 20);
            this.cd_condpgto.ST_AutoInc = false;
            this.cd_condpgto.ST_DisableAuto = false;
            this.cd_condpgto.ST_Float = false;
            this.cd_condpgto.ST_Gravar = true;
            this.cd_condpgto.ST_Int = false;
            this.cd_condpgto.ST_LimpaCampo = true;
            this.cd_condpgto.ST_NotNull = true;
            this.cd_condpgto.ST_PrimaryKey = false;
            this.cd_condpgto.TabIndex = 2;
            this.cd_condpgto.TextOld = null;
            this.cd_condpgto.Leave += new System.EventHandler(this.cd_condpgto_Leave);
            // 
            // ds_condpagto
            // 
            this.ds_condpagto.BackColor = System.Drawing.SystemColors.Window;
            this.ds_condpagto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_condpagto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_condpagto.Enabled = false;
            this.ds_condpagto.Location = new System.Drawing.Point(162, 39);
            this.ds_condpagto.Name = "ds_condpagto";
            this.ds_condpagto.NM_Alias = "";
            this.ds_condpagto.NM_Campo = "ds_condpgto";
            this.ds_condpagto.NM_CampoBusca = "ds_condpgto";
            this.ds_condpagto.NM_Param = "@P_DS_CONDPAGTO";
            this.ds_condpagto.QTD_Zero = 0;
            this.ds_condpagto.Size = new System.Drawing.Size(311, 20);
            this.ds_condpagto.ST_AutoInc = false;
            this.ds_condpagto.ST_DisableAuto = false;
            this.ds_condpagto.ST_Float = false;
            this.ds_condpagto.ST_Gravar = false;
            this.ds_condpagto.ST_Int = false;
            this.ds_condpagto.ST_LimpaCampo = true;
            this.ds_condpagto.ST_NotNull = false;
            this.ds_condpagto.ST_PrimaryKey = false;
            this.ds_condpagto.TabIndex = 40;
            this.ds_condpagto.TextOld = null;
            // 
            // ds_tpduplicata
            // 
            this.ds_tpduplicata.BackColor = System.Drawing.SystemColors.Window;
            this.ds_tpduplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_tpduplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_tpduplicata.Enabled = false;
            this.ds_tpduplicata.Location = new System.Drawing.Point(162, 13);
            this.ds_tpduplicata.Name = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Alias = "";
            this.ds_tpduplicata.NM_Campo = "ds_tpduplicata";
            this.ds_tpduplicata.NM_CampoBusca = "ds_tpduplicata";
            this.ds_tpduplicata.NM_Param = "@P_DS_TPDUPLICATA";
            this.ds_tpduplicata.QTD_Zero = 0;
            this.ds_tpduplicata.Size = new System.Drawing.Size(284, 20);
            this.ds_tpduplicata.ST_AutoInc = false;
            this.ds_tpduplicata.ST_DisableAuto = false;
            this.ds_tpduplicata.ST_Float = false;
            this.ds_tpduplicata.ST_Gravar = false;
            this.ds_tpduplicata.ST_Int = false;
            this.ds_tpduplicata.ST_LimpaCampo = true;
            this.ds_tpduplicata.ST_NotNull = false;
            this.ds_tpduplicata.ST_PrimaryKey = false;
            this.ds_tpduplicata.TabIndex = 36;
            this.ds_tpduplicata.TextOld = null;
            // 
            // tp_mov
            // 
            this.tp_mov.BackColor = System.Drawing.SystemColors.Window;
            this.tp_mov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_mov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_mov.Enabled = false;
            this.tp_mov.Location = new System.Drawing.Point(452, 13);
            this.tp_mov.Name = "tp_mov";
            this.tp_mov.NM_Alias = "";
            this.tp_mov.NM_Campo = "tp_mov";
            this.tp_mov.NM_CampoBusca = "tp_mov";
            this.tp_mov.NM_Param = "@P_TP_MOV";
            this.tp_mov.QTD_Zero = 0;
            this.tp_mov.Size = new System.Drawing.Size(21, 20);
            this.tp_mov.ST_AutoInc = false;
            this.tp_mov.ST_DisableAuto = false;
            this.tp_mov.ST_Float = false;
            this.tp_mov.ST_Gravar = false;
            this.tp_mov.ST_Int = false;
            this.tp_mov.ST_LimpaCampo = true;
            this.tp_mov.ST_NotNull = false;
            this.tp_mov.ST_PrimaryKey = false;
            this.tp_mov.TabIndex = 35;
            this.tp_mov.TextOld = null;
            // 
            // tp_duplicata
            // 
            this.tp_duplicata.BackColor = System.Drawing.SystemColors.Window;
            this.tp_duplicata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_duplicata.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tp_duplicata.Location = new System.Drawing.Point(93, 13);
            this.tp_duplicata.MaxLength = 2;
            this.tp_duplicata.Name = "tp_duplicata";
            this.tp_duplicata.NM_Alias = "";
            this.tp_duplicata.NM_Campo = "Tipo Duplicata";
            this.tp_duplicata.NM_CampoBusca = "tp_duplicata";
            this.tp_duplicata.NM_Param = "@P_TP_DUPLICATA";
            this.tp_duplicata.QTD_Zero = 0;
            this.tp_duplicata.Size = new System.Drawing.Size(34, 20);
            this.tp_duplicata.ST_AutoInc = false;
            this.tp_duplicata.ST_DisableAuto = false;
            this.tp_duplicata.ST_Float = false;
            this.tp_duplicata.ST_Gravar = true;
            this.tp_duplicata.ST_Int = false;
            this.tp_duplicata.ST_LimpaCampo = true;
            this.tp_duplicata.ST_NotNull = true;
            this.tp_duplicata.ST_PrimaryKey = false;
            this.tp_duplicata.TabIndex = 0;
            this.tp_duplicata.TextOld = null;
            this.tp_duplicata.Leave += new System.EventHandler(this.tp_duplicata_Leave);
            // 
            // bb_tpduplicata
            // 
            this.bb_tpduplicata.BackColor = System.Drawing.SystemColors.Control;
            this.bb_tpduplicata.Image = ((System.Drawing.Image)(resources.GetObject("bb_tpduplicata.Image")));
            this.bb_tpduplicata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_tpduplicata.Location = new System.Drawing.Point(128, 13);
            this.bb_tpduplicata.Name = "bb_tpduplicata";
            this.bb_tpduplicata.Size = new System.Drawing.Size(28, 19);
            this.bb_tpduplicata.TabIndex = 1;
            this.bb_tpduplicata.UseVisualStyleBackColor = false;
            this.bb_tpduplicata.Click += new System.EventHandler(this.bb_tpduplicata_Click);
            // 
            // TFDadosDuplicata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 192);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDadosDuplicata";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dados Duplicata";
            this.Load += new System.EventHandler(this.TFDadosDuplicata_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDadosDuplicata_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
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
        private Componentes.EditDefault ds_tpduplicata;
        private Componentes.EditDefault tp_mov;
        private Componentes.EditDefault tp_duplicata;
        private System.Windows.Forms.Button bb_tpduplicata;
        public System.Windows.Forms.Button bb_condpgto;
        public Componentes.EditDefault cd_condpgto;
        private Componentes.EditDefault ds_condpagto;
        private Componentes.EditDefault cd_historico;
        private System.Windows.Forms.Button bb_historico;
        private Componentes.EditDefault ds_historico;
        private Componentes.EditDefault tp_docto;
        private Componentes.EditDefault ds_tpdocto;
        private System.Windows.Forms.Button bb_tpdocto;
        private Componentes.EditDefault ds_ccusto;
        private Componentes.EditDefault cd_ccusto;
        private System.Windows.Forms.Button bb_ccusto;
        private System.Windows.Forms.Label label7;
    }
}