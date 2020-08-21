namespace Empreendimento
{
    partial class FLanFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLanFuncionario));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.sub_total = new Componentes.EditFloat(this.components);
            this.bsFuncionario = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Horas = new Componentes.EditFloat(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.vl_base = new Componentes.EditFloat(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.qtd = new Componentes.EditFloat(this.components);
            this.dscargo = new Componentes.EditDefault(this.components);
            this.idcargo = new Componentes.EditDefault(this.components);
            this.bb_empresa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sub_total)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFuncionario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Horas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_base)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(572, 43);
            this.barraMenu.TabIndex = 12;
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
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.label4);
            this.panelDados1.Controls.Add(this.sub_total);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.Horas);
            this.panelDados1.Controls.Add(this.label5);
            this.panelDados1.Controls.Add(this.vl_base);
            this.panelDados1.Controls.Add(this.label2);
            this.panelDados1.Controls.Add(this.qtd);
            this.panelDados1.Controls.Add(this.dscargo);
            this.panelDados1.Controls.Add(this.idcargo);
            this.panelDados1.Controls.Add(this.bb_empresa);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 43);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(572, 69);
            this.panelDados1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "SubTotal";
            // 
            // sub_total
            // 
            this.sub_total.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Vl_subtotal", true));
            this.sub_total.DecimalPlaces = 2;
            this.sub_total.Enabled = false;
            this.sub_total.Location = new System.Drawing.Point(478, 36);
            this.sub_total.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.sub_total.Name = "sub_total";
            this.sub_total.NM_Alias = "";
            this.sub_total.NM_Campo = "";
            this.sub_total.NM_Param = "";
            this.sub_total.Operador = "";
            this.sub_total.Size = new System.Drawing.Size(78, 20);
            this.sub_total.ST_AutoInc = false;
            this.sub_total.ST_DisableAuto = false;
            this.sub_total.ST_Gravar = true;
            this.sub_total.ST_LimparCampo = true;
            this.sub_total.ST_NotNull = false;
            this.sub_total.ST_PrimaryKey = false;
            this.sub_total.TabIndex = 27;
            this.sub_total.ThousandsSeparator = true;
            // 
            // bsFuncionario
            // 
            this.bsFuncionario.DataSource = typeof(CamadaDados.Empreendimento.TList_Funcionarios);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Horas";
            // 
            // Horas
            // 
            this.Horas.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Tmp_dias", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Horas.Location = new System.Drawing.Point(338, 36);
            this.Horas.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.Horas.Name = "Horas";
            this.Horas.NM_Alias = "";
            this.Horas.NM_Campo = "";
            this.Horas.NM_Param = "";
            this.Horas.Operador = "";
            this.Horas.Size = new System.Drawing.Size(78, 20);
            this.Horas.ST_AutoInc = false;
            this.Horas.ST_DisableAuto = false;
            this.Horas.ST_Gravar = true;
            this.Horas.ST_LimparCampo = true;
            this.Horas.ST_NotNull = false;
            this.Horas.ST_PrimaryKey = false;
            this.Horas.TabIndex = 25;
            this.Horas.ThousandsSeparator = true;
            this.Horas.Leave += new System.EventHandler(this.eddias_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Valor Base";
            // 
            // vl_base
            // 
            this.vl_base.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Vl_unitario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.vl_base.DecimalPlaces = 2;
            this.vl_base.Location = new System.Drawing.Point(217, 36);
            this.vl_base.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.vl_base.Name = "vl_base";
            this.vl_base.NM_Alias = "";
            this.vl_base.NM_Campo = "";
            this.vl_base.NM_Param = "";
            this.vl_base.Operador = "";
            this.vl_base.Size = new System.Drawing.Size(78, 20);
            this.vl_base.ST_AutoInc = false;
            this.vl_base.ST_DisableAuto = false;
            this.vl_base.ST_Gravar = true;
            this.vl_base.ST_LimparCampo = true;
            this.vl_base.ST_NotNull = false;
            this.vl_base.ST_PrimaryKey = false;
            this.vl_base.TabIndex = 23;
            this.vl_base.ThousandsSeparator = true;
            this.vl_base.Leave += new System.EventHandler(this.edbase_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Quantidade";
            // 
            // qtd
            // 
            this.qtd.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFuncionario, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.qtd.Location = new System.Drawing.Point(74, 36);
            this.qtd.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.qtd.Name = "qtd";
            this.qtd.NM_Alias = "";
            this.qtd.NM_Campo = "";
            this.qtd.NM_Param = "";
            this.qtd.Operador = "";
            this.qtd.Size = new System.Drawing.Size(78, 20);
            this.qtd.ST_AutoInc = false;
            this.qtd.ST_DisableAuto = false;
            this.qtd.ST_Gravar = true;
            this.qtd.ST_LimparCampo = true;
            this.qtd.ST_NotNull = false;
            this.qtd.ST_PrimaryKey = false;
            this.qtd.TabIndex = 16;
            this.qtd.ThousandsSeparator = true;
            this.qtd.Leave += new System.EventHandler(this.qtd_Leave);
            // 
            // dscargo
            // 
            this.dscargo.BackColor = System.Drawing.SystemColors.Window;
            this.dscargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dscargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dscargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFuncionario, "Ds_cargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dscargo.Enabled = false;
            this.dscargo.Location = new System.Drawing.Point(125, 8);
            this.dscargo.Name = "dscargo";
            this.dscargo.NM_Alias = "";
            this.dscargo.NM_Campo = "ds_cargo";
            this.dscargo.NM_CampoBusca = "ds_cargo";
            this.dscargo.NM_Param = "@P_DS_CARGO";
            this.dscargo.QTD_Zero = 0;
            this.dscargo.Size = new System.Drawing.Size(404, 20);
            this.dscargo.ST_AutoInc = false;
            this.dscargo.ST_DisableAuto = false;
            this.dscargo.ST_Float = false;
            this.dscargo.ST_Gravar = false;
            this.dscargo.ST_Int = false;
            this.dscargo.ST_LimpaCampo = true;
            this.dscargo.ST_NotNull = false;
            this.dscargo.ST_PrimaryKey = false;
            this.dscargo.TabIndex = 15;
            this.dscargo.TextOld = null;
            // 
            // idcargo
            // 
            this.idcargo.BackColor = System.Drawing.SystemColors.Window;
            this.idcargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idcargo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.idcargo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFuncionario, "Id_cargo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.idcargo.Location = new System.Drawing.Point(49, 8);
            this.idcargo.Name = "idcargo";
            this.idcargo.NM_Alias = "";
            this.idcargo.NM_Campo = "id_cargo";
            this.idcargo.NM_CampoBusca = "id_cargo";
            this.idcargo.NM_Param = "@P_ID_CARGO";
            this.idcargo.QTD_Zero = 0;
            this.idcargo.Size = new System.Drawing.Size(45, 20);
            this.idcargo.ST_AutoInc = false;
            this.idcargo.ST_DisableAuto = false;
            this.idcargo.ST_Float = false;
            this.idcargo.ST_Gravar = true;
            this.idcargo.ST_Int = false;
            this.idcargo.ST_LimpaCampo = true;
            this.idcargo.ST_NotNull = false;
            this.idcargo.ST_PrimaryKey = false;
            this.idcargo.TabIndex = 13;
            this.idcargo.TextOld = null;
            this.idcargo.Leave += new System.EventHandler(this.idcargo_Leave);
            // 
            // bb_empresa
            // 
            this.bb_empresa.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa.Image")));
            this.bb_empresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_empresa.Location = new System.Drawing.Point(95, 8);
            this.bb_empresa.Name = "bb_empresa";
            this.bb_empresa.Size = new System.Drawing.Size(28, 20);
            this.bb_empresa.TabIndex = 14;
            this.bb_empresa.UseVisualStyleBackColor = true;
            this.bb_empresa.Click += new System.EventHandler(this.bb_empresa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargo";
            // 
            // FLanFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 112);
            this.Controls.Add(this.panelDados1);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FLanFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Funcionario";
            this.Load += new System.EventHandler(this.FLanFuncionario_Load);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sub_total)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFuncionario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Horas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_base)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qtd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault dscargo;
        private Componentes.EditDefault idcargo;
        private System.Windows.Forms.Button bb_empresa;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat qtd;
        private System.Windows.Forms.BindingSource bsFuncionario;
        private System.Windows.Forms.Label label5;
        private Componentes.EditFloat vl_base;
        private System.Windows.Forms.Label label3;
        private Componentes.EditFloat Horas;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat sub_total;
    }
}