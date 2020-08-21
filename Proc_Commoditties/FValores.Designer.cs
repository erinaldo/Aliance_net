namespace Proc_Commoditties
{
    partial class FValores
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
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BB_Enter = new System.Windows.Forms.Label();
            this.BB_Sair = new System.Windows.Forms.Label();
            this.panelDados2 = new Componentes.PanelDados(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioGroup1 = new Componentes.RadioGroup(this.components);
            this.rbPercentual = new Componentes.RadioButtonDefault(this.components);
            this.rbValor = new Componentes.RadioButtonDefault(this.components);
            this.Edt_quantidade = new Componentes.EditMask(this.components);
            this.Edt_desconto = new Componentes.EditMask(this.components);
            this.panelDados1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDados2.SuspendLayout();
            this.radioGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDados1
            // 
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDados1.Controls.Add(this.tableLayoutPanel1);
            this.panelDados1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados1.Location = new System.Drawing.Point(0, 0);
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            this.panelDados1.Size = new System.Drawing.Size(167, 252);
            this.panelDados1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BB_Enter, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BB_Sair, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelDados2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(165, 250);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BB_Enter
            // 
            this.BB_Enter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Enter.AutoSize = true;
            this.BB_Enter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Enter.Location = new System.Drawing.Point(3, 170);
            this.BB_Enter.Name = "BB_Enter";
            this.BB_Enter.Size = new System.Drawing.Size(159, 54);
            this.BB_Enter.TabIndex = 0;
            this.BB_Enter.Text = "ENTER";
            this.BB_Enter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BB_Enter.Click += new System.EventHandler(this.BB_Enter_Click);
            // 
            // BB_Sair
            // 
            this.BB_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BB_Sair.AutoSize = true;
            this.BB_Sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BB_Sair.Location = new System.Drawing.Point(3, 224);
            this.BB_Sair.Name = "BB_Sair";
            this.BB_Sair.Size = new System.Drawing.Size(159, 26);
            this.BB_Sair.TabIndex = 1;
            this.BB_Sair.Text = "Sair (ESC)";
            this.BB_Sair.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BB_Sair.Click += new System.EventHandler(this.BB_Sair_Click);
            // 
            // panelDados2
            // 
            this.panelDados2.Controls.Add(this.Edt_desconto);
            this.panelDados2.Controls.Add(this.Edt_quantidade);
            this.panelDados2.Controls.Add(this.radioGroup1);
            this.panelDados2.Controls.Add(this.label4);
            this.panelDados2.Controls.Add(this.label3);
            this.panelDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDados2.Location = new System.Drawing.Point(3, 3);
            this.panelDados2.Name = "panelDados2";
            this.panelDados2.NM_ProcDeletar = "";
            this.panelDados2.NM_ProcGravar = "";
            this.panelDados2.Size = new System.Drawing.Size(159, 164);
            this.panelDados2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Quantidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Desconto";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Controls.Add(this.rbValor);
            this.radioGroup1.Controls.Add(this.rbPercentual);
            this.radioGroup1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioGroup1.Location = new System.Drawing.Point(6, 105);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.NM_Alias = "";
            this.radioGroup1.NM_Campo = "";
            this.radioGroup1.NM_Param = "";
            this.radioGroup1.NM_Valor = "";
            this.radioGroup1.Size = new System.Drawing.Size(144, 42);
            this.radioGroup1.ST_Gravar = false;
            this.radioGroup1.ST_NotNull = false;
            this.radioGroup1.TabIndex = 4;
            this.radioGroup1.TabStop = false;
            this.radioGroup1.Text = "Forma";
            // 
            // rbPercentual
            // 
            this.rbPercentual.AutoSize = true;
            this.rbPercentual.Checked = true;
            this.rbPercentual.Location = new System.Drawing.Point(6, 19);
            this.rbPercentual.Name = "rbPercentual";
            this.rbPercentual.Size = new System.Drawing.Size(76, 17);
            this.rbPercentual.TabIndex = 0;
            this.rbPercentual.TabStop = true;
            this.rbPercentual.Text = "Percentual";
            this.rbPercentual.UseVisualStyleBackColor = true;
            this.rbPercentual.Valor = "";
            this.rbPercentual.CheckedChanged += new System.EventHandler(this.rbPercentual_CheckedChanged);
            // 
            // rbValor
            // 
            this.rbValor.AutoSize = true;
            this.rbValor.Location = new System.Drawing.Point(88, 19);
            this.rbValor.Name = "rbValor";
            this.rbValor.Size = new System.Drawing.Size(49, 17);
            this.rbValor.TabIndex = 1;
            this.rbValor.Text = "Valor";
            this.rbValor.UseVisualStyleBackColor = true;
            this.rbValor.Valor = "";
            // 
            // Edt_quantidade
            // 
            this.Edt_quantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edt_quantidade.Location = new System.Drawing.Point(5, 20);
            this.Edt_quantidade.Mask = "#.###";
            this.Edt_quantidade.Name = "Edt_quantidade";
            this.Edt_quantidade.NM_Alias = "";
            this.Edt_quantidade.NM_Campo = "";
            this.Edt_quantidade.NM_CampoBusca = "";
            this.Edt_quantidade.NM_Param = "";
            this.Edt_quantidade.Size = new System.Drawing.Size(144, 30);
            this.Edt_quantidade.ST_Gravar = false;
            this.Edt_quantidade.ST_LimpaCampo = true;
            this.Edt_quantidade.ST_NotNull = false;
            this.Edt_quantidade.ST_PrimaryKey = false;
            this.Edt_quantidade.TabIndex = 5;
            this.Edt_quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Edt_quantidade.TextChanged += new System.EventHandler(this.Edt_quantidade_TextChanged);
            // 
            // Edt_desconto
            // 
            this.Edt_desconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edt_desconto.Location = new System.Drawing.Point(7, 67);
            this.Edt_desconto.Mask = "###.##";
            this.Edt_desconto.Name = "Edt_desconto";
            this.Edt_desconto.NM_Alias = "";
            this.Edt_desconto.NM_Campo = "";
            this.Edt_desconto.NM_CampoBusca = "";
            this.Edt_desconto.NM_Param = "";
            this.Edt_desconto.Size = new System.Drawing.Size(144, 30);
            this.Edt_desconto.ST_Gravar = false;
            this.Edt_desconto.ST_LimpaCampo = true;
            this.Edt_desconto.ST_NotNull = false;
            this.Edt_desconto.ST_PrimaryKey = false;
            this.Edt_desconto.TabIndex = 6;
            this.Edt_desconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Edt_desconto.TextChanged += new System.EventHandler(this.Edt_desconto_TextChanged);
            // 
            // FValores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 252);
            this.Controls.Add(this.panelDados1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FValores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FValores";
            this.Load += new System.EventHandler(this.FValores_Load);
            this.panelDados1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelDados2.ResumeLayout(false);
            this.panelDados2.PerformLayout();
            this.radioGroup1.ResumeLayout(false);
            this.radioGroup1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label BB_Enter;
        private System.Windows.Forms.Label BB_Sair;
        private Componentes.PanelDados panelDados2;
        private Componentes.RadioGroup radioGroup1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Componentes.RadioButtonDefault rbValor;
        private Componentes.RadioButtonDefault rbPercentual;
        private Componentes.EditMask Edt_quantidade;
        private Componentes.EditMask Edt_desconto;
    }
}