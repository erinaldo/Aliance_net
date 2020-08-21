namespace Servicos
{
    partial class TFFotosOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFFotosOS));
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_inutilizar = new System.Windows.Forms.ToolStripButton();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.tlpCentral = new System.Windows.Forms.TableLayoutPanel();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.ds_imagem = new Componentes.EditDefault(this.components);
            this.bsFotos = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pFoto = new Componentes.PanelDados(this.components);
            this.pImagem = new System.Windows.Forms.PictureBox();
            this.TS_ItensPedido = new System.Windows.Forms.ToolStrip();
            this.bb_localizarfoto = new System.Windows.Forms.ToolStripButton();
            this.barraMenu.SuspendLayout();
            this.tlpCentral.SuspendLayout();
            this.panelDados1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFotos)).BeginInit();
            this.pFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImagem)).BeginInit();
            this.TS_ItensPedido.SuspendLayout();
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
            this.barraMenu.Size = new System.Drawing.Size(431, 43);
            this.barraMenu.TabIndex = 14;
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
            // tlpCentral
            // 
            this.tlpCentral.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpCentral.ColumnCount = 1;
            this.tlpCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Controls.Add(this.panelDados1, 0, 0);
            this.tlpCentral.Controls.Add(this.pFoto, 0, 1);
            this.tlpCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCentral.Location = new System.Drawing.Point(0, 43);
            this.tlpCentral.Name = "tlpCentral";
            this.tlpCentral.RowCount = 2;
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCentral.Size = new System.Drawing.Size(431, 318);
            this.tlpCentral.TabIndex = 15;
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.ds_imagem);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(5, 5);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(421, 76);
            this.panelDados1.TabIndex = 0;
            // 
            // ds_imagem
            // 
            this.ds_imagem.BackColor = System.Drawing.SystemColors.Window;
            this.ds_imagem.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ds_imagem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsFotos, "Ds_imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ds_imagem.Location = new System.Drawing.Point(6, 19);
            this.ds_imagem.Multiline = true;
            this.ds_imagem.Name = "ds_imagem";
            this.ds_imagem.NM_Alias = "";
            this.ds_imagem.NM_Campo = "";
            this.ds_imagem.NM_CampoBusca = "";
            this.ds_imagem.NM_Param = "";
            this.ds_imagem.QTD_Zero = 0;
            this.ds_imagem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ds_imagem.Size = new System.Drawing.Size(407, 52);
            this.ds_imagem.ST_AutoInc = false;
            this.ds_imagem.ST_DisableAuto = false;
            this.ds_imagem.ST_Float = false;
            this.ds_imagem.ST_Gravar = false;
            this.ds_imagem.ST_Int = false;
            this.ds_imagem.ST_LimpaCampo = true;
            this.ds_imagem.ST_NotNull = false;
            this.ds_imagem.ST_PrimaryKey = false;
            this.ds_imagem.TabIndex = 0;
            // 
            // bsFotos
            // 
            this.bsFotos.DataSource = typeof(CamadaDados.Servicos.Cadastros.TList_Imagens);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição Foto";
            // 
            // pFoto
            // 
            this.pFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pFoto.Controls.Add(this.pImagem);
            this.pFoto.Controls.Add(this.TS_ItensPedido);
            this.pFoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFoto.Location = new System.Drawing.Point(5, 89);
            this.pFoto.Name = "pFoto";
            this.pFoto.NM_ProcDeletar = "";
            this.pFoto.NM_ProcGravar = "";
            this.pFoto.Size = new System.Drawing.Size(421, 224);
            this.pFoto.TabIndex = 1;
            // 
            // pImagem
            // 
            this.pImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pImagem.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsFotos, "Foto_imagem", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImagem.Location = new System.Drawing.Point(0, 25);
            this.pImagem.Name = "pImagem";
            this.pImagem.Size = new System.Drawing.Size(417, 195);
            this.pImagem.TabIndex = 3;
            this.pImagem.TabStop = false;
            // 
            // TS_ItensPedido
            // 
            this.TS_ItensPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_localizarfoto});
            this.TS_ItensPedido.Location = new System.Drawing.Point(0, 0);
            this.TS_ItensPedido.Name = "TS_ItensPedido";
            this.TS_ItensPedido.Size = new System.Drawing.Size(417, 25);
            this.TS_ItensPedido.TabIndex = 2;
            // 
            // bb_localizarfoto
            // 
            this.bb_localizarfoto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bb_localizarfoto.Image = ((System.Drawing.Image)(resources.GetObject("bb_localizarfoto.Image")));
            this.bb_localizarfoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bb_localizarfoto.Name = "bb_localizarfoto";
            this.bb_localizarfoto.Size = new System.Drawing.Size(171, 22);
            this.bb_localizarfoto.Text = "(CTRL + F7)Localizar Foto";
            this.bb_localizarfoto.ToolTipText = "Localizar Foto";
            this.bb_localizarfoto.Click += new System.EventHandler(this.bb_localizarfoto_Click);
            // 
            // TFFotosOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 361);
            this.Controls.Add(this.tlpCentral);
            this.Controls.Add(this.barraMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFFotosOS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fotos Ordem Serviço";
            this.Load += new System.EventHandler(this.TFFotosOS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFFotosOS_KeyDown);
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.tlpCentral.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsFotos)).EndInit();
            this.pFoto.ResumeLayout(false);
            this.pFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pImagem)).EndInit();
            this.TS_ItensPedido.ResumeLayout(false);
            this.TS_ItensPedido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_inutilizar;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.TableLayoutPanel tlpCentral;
        private Componentes.PanelDados panelDados1;
        private Componentes.EditDefault ds_imagem;
        private System.Windows.Forms.Label label1;
        private Componentes.PanelDados pFoto;
        private System.Windows.Forms.ToolStrip TS_ItensPedido;
        private System.Windows.Forms.ToolStripButton bb_localizarfoto;
        private System.Windows.Forms.BindingSource bsFotos;
        private System.Windows.Forms.PictureBox pImagem;

    }
}