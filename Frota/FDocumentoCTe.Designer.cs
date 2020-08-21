namespace Frota
{
    partial class TFDocumentoCTe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFDocumentoCTe));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.chave_acesso_nfe = new Componentes.EditDefault(this.components);
            this.bsDocTransp = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tcCentral = new System.Windows.Forms.TabControl();
            this.tpNfe = new System.Windows.Forms.TabPage();
            this.tpOutrosDoc = new System.Windows.Forms.TabPage();
            this.pOutrosDoc = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.vl_documento = new Componentes.EditFloat(this.components);
            this.dt_documento = new Componentes.EditData(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.nr_documento = new Componentes.EditDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.ds_documento = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tp_documento = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.editData1 = new Componentes.EditData(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.editDefault1 = new Componentes.EditDefault(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTransp)).BeginInit();
            this.tcCentral.SuspendLayout();
            this.tpNfe.SuspendLayout();
            this.tpOutrosDoc.SuspendLayout();
            this.pOutrosDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(597, 43);
            this.barraMenu.TabIndex = 20;
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
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.editData1);
            this.pDados.Controls.Add(this.label8);
            this.pDados.Controls.Add(this.editDefault1);
            this.pDados.Controls.Add(this.label9);
            this.pDados.Controls.Add(this.chave_acesso_nfe);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(3, 3);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(583, 123);
            this.pDados.TabIndex = 21;
            // 
            // chave_acesso_nfe
            // 
            this.chave_acesso_nfe.BackColor = System.Drawing.SystemColors.Window;
            this.chave_acesso_nfe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chave_acesso_nfe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.chave_acesso_nfe.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Chave_acesso_nfe", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chave_acesso_nfe.Location = new System.Drawing.Point(3, 19);
            this.chave_acesso_nfe.MaxLength = 44;
            this.chave_acesso_nfe.Name = "chave_acesso_nfe";
            this.chave_acesso_nfe.NM_Alias = "";
            this.chave_acesso_nfe.NM_Campo = "";
            this.chave_acesso_nfe.NM_CampoBusca = "";
            this.chave_acesso_nfe.NM_Param = "";
            this.chave_acesso_nfe.QTD_Zero = 0;
            this.chave_acesso_nfe.Size = new System.Drawing.Size(574, 20);
            this.chave_acesso_nfe.ST_AutoInc = false;
            this.chave_acesso_nfe.ST_DisableAuto = false;
            this.chave_acesso_nfe.ST_Float = false;
            this.chave_acesso_nfe.ST_Gravar = true;
            this.chave_acesso_nfe.ST_Int = true;
            this.chave_acesso_nfe.ST_LimpaCampo = true;
            this.chave_acesso_nfe.ST_NotNull = false;
            this.chave_acesso_nfe.ST_PrimaryKey = false;
            this.chave_acesso_nfe.TabIndex = 0;
            this.chave_acesso_nfe.TextOld = null;
            // 
            // bsDocTransp
            // 
            this.bsDocTransp.DataSource = typeof(CamadaDados.Faturamento.CTRC.TList_CTRNotaFiscal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chave Acesso NFe";
            // 
            // tcCentral
            // 
            this.tcCentral.Controls.Add(this.tpNfe);
            this.tcCentral.Controls.Add(this.tpOutrosDoc);
            this.tcCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCentral.Location = new System.Drawing.Point(0, 43);
            this.tcCentral.Name = "tcCentral";
            this.tcCentral.SelectedIndex = 0;
            this.tcCentral.Size = new System.Drawing.Size(597, 155);
            this.tcCentral.TabIndex = 22;
            // 
            // tpNfe
            // 
            this.tpNfe.Controls.Add(this.pDados);
            this.tpNfe.Location = new System.Drawing.Point(4, 22);
            this.tpNfe.Name = "tpNfe";
            this.tpNfe.Padding = new System.Windows.Forms.Padding(3);
            this.tpNfe.Size = new System.Drawing.Size(589, 129);
            this.tpNfe.TabIndex = 0;
            this.tpNfe.Text = "NFe";
            this.tpNfe.UseVisualStyleBackColor = true;
            // 
            // tpOutrosDoc
            // 
            this.tpOutrosDoc.Controls.Add(this.pOutrosDoc);
            this.tpOutrosDoc.Location = new System.Drawing.Point(4, 22);
            this.tpOutrosDoc.Name = "tpOutrosDoc";
            this.tpOutrosDoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutrosDoc.Size = new System.Drawing.Size(589, 129);
            this.tpOutrosDoc.TabIndex = 1;
            this.tpOutrosDoc.Text = "Outros Documentos";
            this.tpOutrosDoc.UseVisualStyleBackColor = true;
            // 
            // pOutrosDoc
            // 
            this.pOutrosDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pOutrosDoc.Controls.Add(this.label6);
            this.pOutrosDoc.Controls.Add(this.vl_documento);
            this.pOutrosDoc.Controls.Add(this.dt_documento);
            this.pOutrosDoc.Controls.Add(this.label5);
            this.pOutrosDoc.Controls.Add(this.nr_documento);
            this.pOutrosDoc.Controls.Add(this.label4);
            this.pOutrosDoc.Controls.Add(this.ds_documento);
            this.pOutrosDoc.Controls.Add(this.label3);
            this.pOutrosDoc.Controls.Add(this.tp_documento);
            this.pOutrosDoc.Controls.Add(this.label2);
            this.pOutrosDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pOutrosDoc.Location = new System.Drawing.Point(3, 3);
            this.pOutrosDoc.Name = "pOutrosDoc";
            this.pOutrosDoc.NM_ProcDeletar = "";
            this.pOutrosDoc.NM_ProcGravar = "";
            this.pOutrosDoc.Size = new System.Drawing.Size(583, 123);
            this.pOutrosDoc.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Vl. Documento";
            // 
            // vl_documento
            // 
            this.vl_documento.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDocTransp, "Vl_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_documento.DecimalPlaces = 2;
            this.vl_documento.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.vl_documento.Location = new System.Drawing.Point(249, 95);
            this.vl_documento.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_documento.Name = "vl_documento";
            this.vl_documento.NM_Alias = "";
            this.vl_documento.NM_Campo = "";
            this.vl_documento.NM_Param = "";
            this.vl_documento.Operador = "";
            this.vl_documento.Size = new System.Drawing.Size(120, 20);
            this.vl_documento.ST_AutoInc = false;
            this.vl_documento.ST_DisableAuto = false;
            this.vl_documento.ST_Gravar = false;
            this.vl_documento.ST_LimparCampo = true;
            this.vl_documento.ST_NotNull = false;
            this.vl_documento.ST_PrimaryKey = false;
            this.vl_documento.TabIndex = 4;
            this.vl_documento.ThousandsSeparator = true;
            // 
            // dt_documento
            // 
            this.dt_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dt_documento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Dt_documentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dt_documento.Location = new System.Drawing.Point(167, 95);
            this.dt_documento.Mask = "00/00/0000";
            this.dt_documento.Name = "dt_documento";
            this.dt_documento.NM_Alias = "";
            this.dt_documento.NM_Campo = "";
            this.dt_documento.NM_CampoBusca = "";
            this.dt_documento.NM_Param = "";
            this.dt_documento.Operador = "";
            this.dt_documento.Size = new System.Drawing.Size(76, 20);
            this.dt_documento.ST_Gravar = false;
            this.dt_documento.ST_LimpaCampo = true;
            this.dt_documento.ST_NotNull = false;
            this.dt_documento.ST_PrimaryKey = false;
            this.dt_documento.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dt. Documento";
            // 
            // nr_documento
            // 
            this.nr_documento.BackColor = System.Drawing.SystemColors.Window;
            this.nr_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nr_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_documento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Nr_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nr_documento.Location = new System.Drawing.Point(7, 95);
            this.nr_documento.Name = "nr_documento";
            this.nr_documento.NM_Alias = "";
            this.nr_documento.NM_Campo = "";
            this.nr_documento.NM_CampoBusca = "";
            this.nr_documento.NM_Param = "";
            this.nr_documento.QTD_Zero = 0;
            this.nr_documento.Size = new System.Drawing.Size(154, 20);
            this.nr_documento.ST_AutoInc = false;
            this.nr_documento.ST_DisableAuto = false;
            this.nr_documento.ST_Float = false;
            this.nr_documento.ST_Gravar = false;
            this.nr_documento.ST_Int = false;
            this.nr_documento.ST_LimpaCampo = true;
            this.nr_documento.ST_NotNull = false;
            this.nr_documento.ST_PrimaryKey = false;
            this.nr_documento.TabIndex = 2;
            this.nr_documento.TextOld = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nº Documento";
            // 
            // ds_documento
            // 
            this.ds_documento.BackColor = System.Drawing.SystemColors.Window;
            this.ds_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_documento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_documento.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Ds_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_documento.Location = new System.Drawing.Point(7, 56);
            this.ds_documento.Name = "ds_documento";
            this.ds_documento.NM_Alias = "";
            this.ds_documento.NM_Campo = "";
            this.ds_documento.NM_CampoBusca = "";
            this.ds_documento.NM_Param = "";
            this.ds_documento.QTD_Zero = 0;
            this.ds_documento.Size = new System.Drawing.Size(567, 20);
            this.ds_documento.ST_AutoInc = false;
            this.ds_documento.ST_DisableAuto = false;
            this.ds_documento.ST_Float = false;
            this.ds_documento.ST_Gravar = false;
            this.ds_documento.ST_Int = false;
            this.ds_documento.ST_LimpaCampo = true;
            this.ds_documento.ST_NotNull = false;
            this.ds_documento.ST_PrimaryKey = false;
            this.ds_documento.TabIndex = 1;
            this.ds_documento.TextOld = null;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descrição Documento";
            // 
            // tp_documento
            // 
            this.tp_documento.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsDocTransp, "Tp_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tp_documento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tp_documento.FormattingEnabled = true;
            this.tp_documento.Location = new System.Drawing.Point(7, 16);
            this.tp_documento.Name = "tp_documento";
            this.tp_documento.NM_Alias = "";
            this.tp_documento.NM_Campo = "";
            this.tp_documento.NM_Param = "";
            this.tp_documento.Size = new System.Drawing.Size(154, 21);
            this.tp_documento.ST_Gravar = false;
            this.tp_documento.ST_LimparCampo = true;
            this.tp_documento.ST_NotNull = false;
            this.tp_documento.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Documento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Vl. Documento";
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsDocTransp, "Vl_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.editFloat1.Location = new System.Drawing.Point(245, 64);
            this.editFloat1.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.editFloat1.Name = "editFloat1";
            this.editFloat1.NM_Alias = "";
            this.editFloat1.NM_Campo = "";
            this.editFloat1.NM_Param = "";
            this.editFloat1.Operador = "";
            this.editFloat1.Size = new System.Drawing.Size(120, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 3;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // editData1
            // 
            this.editData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editData1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Dt_documentostr", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editData1.Location = new System.Drawing.Point(163, 64);
            this.editData1.Mask = "00/00/0000";
            this.editData1.Name = "editData1";
            this.editData1.NM_Alias = "";
            this.editData1.NM_Campo = "";
            this.editData1.NM_CampoBusca = "";
            this.editData1.NM_Param = "";
            this.editData1.Operador = "";
            this.editData1.Size = new System.Drawing.Size(76, 20);
            this.editData1.ST_Gravar = false;
            this.editData1.ST_LimpaCampo = true;
            this.editData1.ST_NotNull = false;
            this.editData1.ST_PrimaryKey = false;
            this.editData1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Dt. Documento";
            // 
            // editDefault1
            // 
            this.editDefault1.BackColor = System.Drawing.SystemColors.Window;
            this.editDefault1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editDefault1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.editDefault1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsDocTransp, "Nr_documento", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.editDefault1.Location = new System.Drawing.Point(3, 64);
            this.editDefault1.Name = "editDefault1";
            this.editDefault1.NM_Alias = "";
            this.editDefault1.NM_Campo = "";
            this.editDefault1.NM_CampoBusca = "";
            this.editDefault1.NM_Param = "";
            this.editDefault1.QTD_Zero = 0;
            this.editDefault1.Size = new System.Drawing.Size(154, 20);
            this.editDefault1.ST_AutoInc = false;
            this.editDefault1.ST_DisableAuto = false;
            this.editDefault1.ST_Float = false;
            this.editDefault1.ST_Gravar = false;
            this.editDefault1.ST_Int = false;
            this.editDefault1.ST_LimpaCampo = true;
            this.editDefault1.ST_NotNull = false;
            this.editDefault1.ST_PrimaryKey = false;
            this.editDefault1.TabIndex = 1;
            this.editDefault1.TextOld = null;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Nº Documento";
            // 
            // TFDocumentoCTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 198);
            this.Controls.Add(this.tcCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFDocumentoCTe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos Transportados";
            this.Load += new System.EventHandler(this.TFDocumentoCTe_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFDocumentoCTe_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDocTransp)).EndInit();
            this.tcCentral.ResumeLayout(false);
            this.tpNfe.ResumeLayout(false);
            this.tpOutrosDoc.ResumeLayout(false);
            this.pOutrosDoc.ResumeLayout(false);
            this.pOutrosDoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vl_documento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault chave_acesso_nfe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcCentral;
        private System.Windows.Forms.TabPage tpNfe;
        private System.Windows.Forms.TabPage tpOutrosDoc;
        private Componentes.PanelDados pOutrosDoc;
        private Componentes.ComboBoxDefault tp_documento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bsDocTransp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private Componentes.EditFloat vl_documento;
        private Componentes.EditData dt_documento;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault nr_documento;
        private System.Windows.Forms.Label label4;
        private Componentes.EditDefault ds_documento;
        private System.Windows.Forms.Label label7;
        private Componentes.EditFloat editFloat1;
        private Componentes.EditData editData1;
        private System.Windows.Forms.Label label8;
        private Componentes.EditDefault editDefault1;
        private System.Windows.Forms.Label label9;
    }
}