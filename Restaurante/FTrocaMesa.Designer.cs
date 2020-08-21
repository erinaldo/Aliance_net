namespace Restaurante
{
    partial class FTrocaMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTrocaMesa));
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.barraMenu = new System.Windows.Forms.ToolStrip();
            this.bb_cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mesas_tab = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nr_mesa = new Componentes.EditDefault(this.components);
            this.na_cartao = new System.Windows.Forms.Label();
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.barraMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(407, 348);
            this.panelDados1.TabIndex = 878;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.barraMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mesas_tab, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 348);
            this.tableLayoutPanel1.TabIndex = 878;
            // 
            // barraMenu
            // 
            this.barraMenu.Font = new System.Drawing.Font("Tahoma", 6F);
            this.barraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bb_cancelar,
            this.toolStripSeparator1});
            this.barraMenu.Location = new System.Drawing.Point(1, 1);
            this.barraMenu.Name = "barraMenu";
            this.barraMenu.Size = new System.Drawing.Size(405, 43);
            this.barraMenu.TabIndex = 874;
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
            this.bb_cancelar.Text = "(F6/ESC)\r\nCancelar";
            this.bb_cancelar.ToolTipText = "Cancelar Procedimento";
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // mesas_tab
            // 
            this.mesas_tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mesas_tab.Location = new System.Drawing.Point(4, 50);
            this.mesas_tab.Name = "mesas_tab";
            this.mesas_tab.SelectedIndex = 0;
            this.mesas_tab.Size = new System.Drawing.Size(399, 233);
            this.mesas_tab.TabIndex = 875;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.nr_mesa);
            this.panel1.Controls.Add(this.na_cartao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 54);
            this.panel1.TabIndex = 876;
            // 
            // nr_mesa
            // 
            this.nr_mesa.BackColor = System.Drawing.Color.White;
            this.nr_mesa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nr_mesa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nr_mesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_mesa.Location = new System.Drawing.Point(175, 3);
            this.nr_mesa.Name = "nr_mesa";
            this.nr_mesa.NM_Alias = "";
            this.nr_mesa.NM_Campo = "";
            this.nr_mesa.NM_CampoBusca = "";
            this.nr_mesa.NM_Param = "";
            this.nr_mesa.QTD_Zero = 0;
            this.nr_mesa.Size = new System.Drawing.Size(168, 49);
            this.nr_mesa.ST_AutoInc = false;
            this.nr_mesa.ST_DisableAuto = false;
            this.nr_mesa.ST_Float = false;
            this.nr_mesa.ST_Gravar = false;
            this.nr_mesa.ST_Int = true;
            this.nr_mesa.ST_LimpaCampo = true;
            this.nr_mesa.ST_NotNull = true;
            this.nr_mesa.ST_PrimaryKey = false;
            this.nr_mesa.TabIndex = 875;
            this.nr_mesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nr_mesa.TextOld = null;
            this.nr_mesa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nr_mesa_KeyDown);
            // 
            // na_cartao
            // 
            this.na_cartao.AutoSize = true;
            this.na_cartao.BackColor = System.Drawing.Color.Transparent;
            this.na_cartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.na_cartao.ForeColor = System.Drawing.Color.Green;
            this.na_cartao.Location = new System.Drawing.Point(10, 13);
            this.na_cartao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.na_cartao.Name = "na_cartao";
            this.na_cartao.Size = new System.Drawing.Size(158, 24);
            this.na_cartao.TabIndex = 874;
            this.na_cartao.Text = "N° Mesa (Enter)";
            // 
            // FTrocaMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 348);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FTrocaMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trocar Mesa";
            this.Load += new System.EventHandler(this.FTrocaMesa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTrocaMesa_KeyDown);
            this.panelDados1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.barraMenu.ResumeLayout(false);
            this.barraMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ToolStrip barraMenu;
        private System.Windows.Forms.ToolStripButton bb_cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl mesas_tab;
        private System.Windows.Forms.Panel panel1;
        private Componentes.EditDefault nr_mesa;
        private System.Windows.Forms.Label na_cartao;
    }
}