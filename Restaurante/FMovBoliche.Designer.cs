namespace Restaurante
{
    partial class TFMovBoliche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFMovBoliche));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnLogoMarca = new Componentes.PanelDados(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.BB_Sair = new System.Windows.Forms.Button();
            this.lvPistas = new System.Windows.Forms.ListView();
            this.imagePista = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnLogoMarca, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvPistas, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 516);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnLogoMarca
            // 
            this.pnLogoMarca.BackColor = System.Drawing.Color.Transparent;
            this.pnLogoMarca.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnLogoMarca.BackgroundImage")));
            this.pnLogoMarca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnLogoMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLogoMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLogoMarca.Location = new System.Drawing.Point(3, 349);
            this.pnLogoMarca.Name = "pnLogoMarca";
            this.pnLogoMarca.NM_ProcDeletar = "";
            this.pnLogoMarca.NM_ProcGravar = "";
            this.pnLogoMarca.Size = new System.Drawing.Size(777, 164);
            this.pnLogoMarca.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.BB_Sair);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 52);
            this.panel2.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(268, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(283, 25);
            this.label10.TabIndex = 46;
            this.label10.Text = "Movimentação Pista Boliche";
            // 
            // BB_Sair
            // 
            this.BB_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Sair.ForeColor = System.Drawing.Color.Green;
            this.BB_Sair.Image = ((System.Drawing.Image)(resources.GetObject("BB_Sair.Image")));
            this.BB_Sair.Location = new System.Drawing.Point(686, 3);
            this.BB_Sair.Name = "BB_Sair";
            this.BB_Sair.Size = new System.Drawing.Size(79, 45);
            this.BB_Sair.TabIndex = 0;
            this.BB_Sair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BB_Sair.UseVisualStyleBackColor = true;
            this.BB_Sair.Click += new System.EventHandler(this.BB_Sair_Click);
            // 
            // lvPistas
            // 
            this.lvPistas.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lvPistas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvPistas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPistas.FullRowSelect = true;
            this.lvPistas.LargeImageList = this.imagePista;
            this.lvPistas.Location = new System.Drawing.Point(5, 65);
            this.lvPistas.Margin = new System.Windows.Forms.Padding(5);
            this.lvPistas.Name = "lvPistas";
            this.lvPistas.Size = new System.Drawing.Size(773, 276);
            this.lvPistas.SmallImageList = this.imagePista;
            this.lvPistas.StateImageList = this.imagePista;
            this.lvPistas.TabIndex = 8;
            this.lvPistas.UseCompatibleStateImageBehavior = false;
            this.lvPistas.View = System.Windows.Forms.View.Details;
            this.lvPistas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPistas_ItemSelectionChanged);
            // 
            // imagePista
            // 
            this.imagePista.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagePista.ImageStream")));
            this.imagePista.TransparentColor = System.Drawing.Color.Transparent;
            this.imagePista.Images.SetKeyName(0, "PISTA ABERTA.png");
            this.imagePista.Images.SetKeyName(1, "PISTA FECHADA.png");
            this.imagePista.Images.SetKeyName(2, "SINUCA ABERTO.png");
            this.imagePista.Images.SetKeyName(3, "SINUCA FECHADO.png");
            // 
            // TFMovBoliche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "TFMovBoliche";
            this.ShowInTaskbar = false;
            this.Text = "Movimento Pista Boliche";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TFMovBoliche_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BB_Sair;
        private System.Windows.Forms.ListView lvPistas;
        public System.Windows.Forms.ImageList imagePista;
        private Componentes.PanelDados pnLogoMarca;
    }
}