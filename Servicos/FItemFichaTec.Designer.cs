namespace Servicos
{
    partial class TFItemFichaTec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFItemFichaTec));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.editFloat1 = new Componentes.EditFloat(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.vl_unitcusto = new Componentes.EditFloat(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.ds_local = new Componentes.EditDefault(this.components);
            this.bb_local = new System.Windows.Forms.Button();
            this.cd_local = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.quantidade = new Componentes.EditFloat(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ds_item = new Componentes.EditDefault(this.components);
            this.bb_item = new System.Windows.Forms.Button();
            this.cd_item = new Componentes.EditDefault(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.bsFichaTec = new System.Windows.Forms.BindingSource(this.components);
            this.sg_unid_item = new Componentes.EditDefault(this.components);
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitcusto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(443, 43);
            this.barraMenu.TabIndex = 17;
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
            this.pDados.Controls.Add(this.sg_unid_item);
            this.pDados.Controls.Add(this.editFloat1);
            this.pDados.Controls.Add(this.label4);
            this.pDados.Controls.Add(this.vl_unitcusto);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.ds_local);
            this.pDados.Controls.Add(this.bb_local);
            this.pDados.Controls.Add(this.cd_local);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.quantidade);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.ds_item);
            this.pDados.Controls.Add(this.bb_item);
            this.pDados.Controls.Add(this.cd_item);
            this.pDados.Controls.Add(this.label7);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(443, 126);
            this.pDados.TabIndex = 0;
            // 
            // editFloat1
            // 
            this.editFloat1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_TotCusto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N2"));
            this.editFloat1.DecimalPlaces = 2;
            this.editFloat1.Location = new System.Drawing.Point(297, 99);
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
            this.editFloat1.ReadOnly = true;
            this.editFloat1.Size = new System.Drawing.Size(120, 20);
            this.editFloat1.ST_AutoInc = false;
            this.editFloat1.ST_DisableAuto = false;
            this.editFloat1.ST_Gravar = false;
            this.editFloat1.ST_LimparCampo = true;
            this.editFloat1.ST_NotNull = false;
            this.editFloat1.ST_PrimaryKey = false;
            this.editFloat1.TabIndex = 284;
            this.editFloat1.TabStop = false;
            this.editFloat1.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(294, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 283;
            this.label4.Text = "Vl. Custo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vl_unitcusto
            // 
            this.vl_unitcusto.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Vl_UnitCusto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "0", "N5"));
            this.vl_unitcusto.DecimalPlaces = 5;
            this.vl_unitcusto.Location = new System.Drawing.Point(171, 99);
            this.vl_unitcusto.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.vl_unitcusto.Name = "vl_unitcusto";
            this.vl_unitcusto.NM_Alias = "";
            this.vl_unitcusto.NM_Campo = "";
            this.vl_unitcusto.NM_Param = "";
            this.vl_unitcusto.Operador = "";
            this.vl_unitcusto.Size = new System.Drawing.Size(120, 20);
            this.vl_unitcusto.ST_AutoInc = false;
            this.vl_unitcusto.ST_DisableAuto = false;
            this.vl_unitcusto.ST_Gravar = false;
            this.vl_unitcusto.ST_LimparCampo = true;
            this.vl_unitcusto.ST_NotNull = false;
            this.vl_unitcusto.ST_PrimaryKey = false;
            this.vl_unitcusto.TabIndex = 5;
            this.vl_unitcusto.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(168, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 281;
            this.label3.Text = "Vl. Unit. Custo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ds_local
            // 
            this.ds_local.BackColor = System.Drawing.SystemColors.Window;
            this.ds_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Ds_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_local.Enabled = false;
            this.ds_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_local.Location = new System.Drawing.Point(122, 60);
            this.ds_local.Name = "ds_local";
            this.ds_local.NM_Alias = "";
            this.ds_local.NM_Campo = "ds_local";
            this.ds_local.NM_CampoBusca = "ds_local";
            this.ds_local.NM_Param = "@P_DS_PRODUTO";
            this.ds_local.QTD_Zero = 0;
            this.ds_local.ReadOnly = true;
            this.ds_local.Size = new System.Drawing.Size(311, 20);
            this.ds_local.ST_AutoInc = false;
            this.ds_local.ST_DisableAuto = false;
            this.ds_local.ST_Float = false;
            this.ds_local.ST_Gravar = false;
            this.ds_local.ST_Int = false;
            this.ds_local.ST_LimpaCampo = true;
            this.ds_local.ST_NotNull = false;
            this.ds_local.ST_PrimaryKey = false;
            this.ds_local.TabIndex = 279;
            this.ds_local.TextOld = null;
            // 
            // bb_local
            // 
            this.bb_local.Image = ((System.Drawing.Image)(resources.GetObject("bb_local.Image")));
            this.bb_local.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_local.Location = new System.Drawing.Point(89, 60);
            this.bb_local.Name = "bb_local";
            this.bb_local.Size = new System.Drawing.Size(28, 20);
            this.bb_local.TabIndex = 3;
            this.bb_local.UseVisualStyleBackColor = true;
            this.bb_local.Click += new System.EventHandler(this.bb_local_Click);
            // 
            // cd_local
            // 
            this.cd_local.BackColor = System.Drawing.Color.White;
            this.cd_local.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_local.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_local.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_local", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_local.Location = new System.Drawing.Point(6, 60);
            this.cd_local.Name = "cd_local";
            this.cd_local.NM_Alias = "";
            this.cd_local.NM_Campo = "cd_local";
            this.cd_local.NM_CampoBusca = "cd_local";
            this.cd_local.NM_Param = "@P_CD_EMPRESA";
            this.cd_local.QTD_Zero = 0;
            this.cd_local.Size = new System.Drawing.Size(82, 20);
            this.cd_local.ST_AutoInc = false;
            this.cd_local.ST_DisableAuto = false;
            this.cd_local.ST_Float = false;
            this.cd_local.ST_Gravar = true;
            this.cd_local.ST_Int = false;
            this.cd_local.ST_LimpaCampo = true;
            this.cd_local.ST_NotNull = true;
            this.cd_local.ST_PrimaryKey = false;
            this.cd_local.TabIndex = 2;
            this.cd_local.TabStop = false;
            this.cd_local.TextOld = null;
            this.cd_local.Leave += new System.EventHandler(this.cd_local_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 280;
            this.label2.Text = "Local Arm.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // quantidade
            // 
            this.quantidade.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bsFichaTec, "Quantidade", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.quantidade.DecimalPlaces = 3;
            this.quantidade.Location = new System.Drawing.Point(6, 99);
            this.quantidade.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.quantidade.Name = "quantidade";
            this.quantidade.NM_Alias = "";
            this.quantidade.NM_Campo = "";
            this.quantidade.NM_Param = "";
            this.quantidade.Operador = "";
            this.quantidade.Size = new System.Drawing.Size(120, 20);
            this.quantidade.ST_AutoInc = false;
            this.quantidade.ST_DisableAuto = false;
            this.quantidade.ST_Gravar = false;
            this.quantidade.ST_LimparCampo = true;
            this.quantidade.ST_NotNull = false;
            this.quantidade.ST_PrimaryKey = false;
            this.quantidade.TabIndex = 4;
            this.quantidade.ThousandsSeparator = true;
            this.quantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 276;
            this.label1.Text = "Quantidade";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ds_item
            // 
            this.ds_item.BackColor = System.Drawing.SystemColors.Window;
            this.ds_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ds_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_item.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Ds_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_item.Enabled = false;
            this.ds_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ds_item.Location = new System.Drawing.Point(122, 21);
            this.ds_item.Name = "ds_item";
            this.ds_item.NM_Alias = "";
            this.ds_item.NM_Campo = "ds_produto";
            this.ds_item.NM_CampoBusca = "ds_produto";
            this.ds_item.NM_Param = "@P_DS_PRODUTO";
            this.ds_item.QTD_Zero = 0;
            this.ds_item.ReadOnly = true;
            this.ds_item.Size = new System.Drawing.Size(311, 20);
            this.ds_item.ST_AutoInc = false;
            this.ds_item.ST_DisableAuto = false;
            this.ds_item.ST_Float = false;
            this.ds_item.ST_Gravar = false;
            this.ds_item.ST_Int = false;
            this.ds_item.ST_LimpaCampo = true;
            this.ds_item.ST_NotNull = false;
            this.ds_item.ST_PrimaryKey = false;
            this.ds_item.TabIndex = 274;
            this.ds_item.TextOld = null;
            // 
            // bb_item
            // 
            this.bb_item.Image = ((System.Drawing.Image)(resources.GetObject("bb_item.Image")));
            this.bb_item.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bb_item.Location = new System.Drawing.Point(89, 21);
            this.bb_item.Name = "bb_item";
            this.bb_item.Size = new System.Drawing.Size(28, 20);
            this.bb_item.TabIndex = 1;
            this.bb_item.UseVisualStyleBackColor = true;
            this.bb_item.Click += new System.EventHandler(this.bb_item_Click);
            // 
            // cd_item
            // 
            this.cd_item.BackColor = System.Drawing.Color.White;
            this.cd_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cd_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_item.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Cd_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cd_item.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cd_item.Location = new System.Drawing.Point(6, 21);
            this.cd_item.Name = "cd_item";
            this.cd_item.NM_Alias = "";
            this.cd_item.NM_Campo = "cd_produto";
            this.cd_item.NM_CampoBusca = "cd_produto";
            this.cd_item.NM_Param = "@P_CD_EMPRESA";
            this.cd_item.QTD_Zero = 0;
            this.cd_item.Size = new System.Drawing.Size(82, 20);
            this.cd_item.ST_AutoInc = false;
            this.cd_item.ST_DisableAuto = false;
            this.cd_item.ST_Float = false;
            this.cd_item.ST_Gravar = true;
            this.cd_item.ST_Int = false;
            this.cd_item.ST_LimpaCampo = true;
            this.cd_item.ST_NotNull = true;
            this.cd_item.ST_PrimaryKey = false;
            this.cd_item.TabIndex = 0;
            this.cd_item.TabStop = false;
            this.cd_item.TextOld = null;
            this.cd_item.Leave += new System.EventHandler(this.cd_item_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 275;
            this.label7.Text = "Produto";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bsFichaTec
            // 
            this.bsFichaTec.DataSource = typeof(CamadaDados.Servicos.TList_FichaTecOS);
            // 
            // sg_unid_item
            // 
            this.sg_unid_item.BackColor = System.Drawing.SystemColors.Window;
            this.sg_unid_item.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sg_unid_item.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.sg_unid_item.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFichaTec, "Sg_unid_item", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.sg_unid_item.Enabled = false;
            this.sg_unid_item.Location = new System.Drawing.Point(128, 99);
            this.sg_unid_item.Name = "sg_unid_item";
            this.sg_unid_item.NM_Alias = "";
            this.sg_unid_item.NM_Campo = "sigla_unidade";
            this.sg_unid_item.NM_CampoBusca = "sigla_unidade";
            this.sg_unid_item.NM_Param = "@P_SIGLA_UNIDADE";
            this.sg_unid_item.QTD_Zero = 0;
            this.sg_unid_item.Size = new System.Drawing.Size(37, 20);
            this.sg_unid_item.ST_AutoInc = false;
            this.sg_unid_item.ST_DisableAuto = false;
            this.sg_unid_item.ST_Float = false;
            this.sg_unid_item.ST_Gravar = false;
            this.sg_unid_item.ST_Int = false;
            this.sg_unid_item.ST_LimpaCampo = true;
            this.sg_unid_item.ST_NotNull = false;
            this.sg_unid_item.ST_PrimaryKey = false;
            this.sg_unid_item.TabIndex = 285;
            this.sg_unid_item.TextOld = null;
            // 
            // TFItemFichaTec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 169);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFItemFichaTec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Ficha Tecnica OS";
            this.Load += new System.EventHandler(this.TFItemFichaTec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFItemFichaTec_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editFloat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vl_unitcusto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFichaTec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditFloat quantidade;
        private System.Windows.Forms.Label label1;
        private Componentes.EditDefault ds_item;
        private System.Windows.Forms.Button bb_item;
        private Componentes.EditDefault cd_item;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bsFichaTec;
        private Componentes.EditDefault ds_local;
        private System.Windows.Forms.Button bb_local;
        private Componentes.EditDefault cd_local;
        private System.Windows.Forms.Label label2;
        private Componentes.EditFloat editFloat1;
        private System.Windows.Forms.Label label4;
        private Componentes.EditFloat vl_unitcusto;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault sg_unid_item;
    }
}