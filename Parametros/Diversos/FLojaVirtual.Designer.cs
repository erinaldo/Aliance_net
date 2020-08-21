namespace Parametros.Diversos
{
    partial class TFLojaVirtual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFLojaVirtual));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.pDados = new Componentes.PanelDados(this.components);
            this.apiKey = new Componentes.EditDefault(this.components);
            this.bsLojaVirtual = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.userName = new Componentes.EditDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.nm_loja = new Componentes.EditDefault(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbEmpresa = new Componentes.ComboBoxDefault(this.components);
            this.lbl = new System.Windows.Forms.Label();
            this.barraMenu.SuspendLayout();
            this.pDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLojaVirtual)).BeginInit();
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
            this.barraMenu.Size = new System.Drawing.Size(558, 43);
            this.barraMenu.TabIndex = 10;
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
            this.pDados.Controls.Add(this.apiKey);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.userName);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.nm_loja);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Controls.Add(this.cbEmpresa);
            this.pDados.Controls.Add(this.lbl);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 43);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(558, 130);
            this.pDados.TabIndex = 0;
            // 
            // apiKey
            // 
            this.apiKey.BackColor = System.Drawing.SystemColors.Window;
            this.apiKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apiKey.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apiKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLojaVirtual, "ApiKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.apiKey.Location = new System.Drawing.Point(383, 99);
            this.apiKey.Name = "apiKey";
            this.apiKey.NM_Alias = "";
            this.apiKey.NM_Campo = "";
            this.apiKey.NM_CampoBusca = "";
            this.apiKey.NM_Param = "";
            this.apiKey.QTD_Zero = 0;
            this.apiKey.Size = new System.Drawing.Size(163, 20);
            this.apiKey.ST_AutoInc = false;
            this.apiKey.ST_DisableAuto = false;
            this.apiKey.ST_Float = false;
            this.apiKey.ST_Gravar = false;
            this.apiKey.ST_Int = false;
            this.apiKey.ST_LimpaCampo = true;
            this.apiKey.ST_NotNull = false;
            this.apiKey.ST_PrimaryKey = false;
            this.apiKey.TabIndex = 97;
            this.apiKey.TextOld = null;
            // 
            // bsLojaVirtual
            // 
            this.bsLojaVirtual.DataSource = typeof(CamadaDados.Diversos.TList_LojaVirtual);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(380, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "ApiKey";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.SystemColors.Window;
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.userName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLojaVirtual, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.userName.Location = new System.Drawing.Point(15, 99);
            this.userName.Name = "userName";
            this.userName.NM_Alias = "";
            this.userName.NM_Campo = "";
            this.userName.NM_CampoBusca = "";
            this.userName.NM_Param = "";
            this.userName.QTD_Zero = 0;
            this.userName.Size = new System.Drawing.Size(196, 20);
            this.userName.ST_AutoInc = false;
            this.userName.ST_DisableAuto = false;
            this.userName.ST_Float = false;
            this.userName.ST_Gravar = false;
            this.userName.ST_Int = false;
            this.userName.ST_LimpaCampo = true;
            this.userName.ST_NotNull = false;
            this.userName.ST_PrimaryKey = false;
            this.userName.TabIndex = 2;
            this.userName.TextOld = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 94;
            this.label2.Text = "User Name(Web Service)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nm_loja
            // 
            this.nm_loja.BackColor = System.Drawing.SystemColors.Window;
            this.nm_loja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nm_loja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_loja.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsLojaVirtual, "Nm_loja", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nm_loja.Location = new System.Drawing.Point(15, 60);
            this.nm_loja.Name = "nm_loja";
            this.nm_loja.NM_Alias = "";
            this.nm_loja.NM_Campo = "";
            this.nm_loja.NM_CampoBusca = "";
            this.nm_loja.NM_Param = "";
            this.nm_loja.QTD_Zero = 0;
            this.nm_loja.Size = new System.Drawing.Size(531, 20);
            this.nm_loja.ST_AutoInc = false;
            this.nm_loja.ST_DisableAuto = false;
            this.nm_loja.ST_Float = false;
            this.nm_loja.ST_Gravar = false;
            this.nm_loja.ST_Int = false;
            this.nm_loja.ST_LimpaCampo = true;
            this.nm_loja.ST_NotNull = false;
            this.nm_loja.ST_PrimaryKey = false;
            this.nm_loja.TabIndex = 1;
            this.nm_loja.TextOld = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Nome Loja Virtual";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsLojaVirtual, "Cd_empresa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(12, 20);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.NM_Alias = "";
            this.cbEmpresa.NM_Campo = "";
            this.cbEmpresa.NM_Param = "";
            this.cbEmpresa.Size = new System.Drawing.Size(534, 21);
            this.cbEmpresa.ST_Gravar = false;
            this.cbEmpresa.ST_LimparCampo = true;
            this.cbEmpresa.ST_NotNull = false;
            this.cbEmpresa.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(9, 4);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(48, 13);
            this.lbl.TabIndex = 90;
            this.lbl.Text = "Empresa";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TFLojaVirtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 173);
            this.Controls.Add(this.pDados);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFLojaVirtual";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja Virtual";
            this.Load += new System.EventHandler(this.TFLojaVirtual_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFLojaVirtual_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsLojaVirtual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private Componentes.PanelDados pDados;
        private Componentes.EditDefault userName;
        private System.Windows.Forms.BindingSource bsLojaVirtual;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault nm_loja;
        private System.Windows.Forms.Label label1;
        private Componentes.ComboBoxDefault cbEmpresa;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault apiKey;
    }
}