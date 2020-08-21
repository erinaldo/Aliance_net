namespace srvNFE
{
    partial class TFConsultaCadCliforNFe
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
            this.pDados = new Componentes.PanelDados(this.components);
            this.bb_cancelar = new System.Windows.Forms.Button();
            this.bb_consultar = new System.Windows.Forms.Button();
            this.uf = new Componentes.ComboBoxDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cpf = new Componentes.EditMask(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cnpj = new Componentes.EditMask(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDados
            // 
            this.pDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDados.Controls.Add(this.bb_cancelar);
            this.pDados.Controls.Add(this.bb_consultar);
            this.pDados.Controls.Add(this.uf);
            this.pDados.Controls.Add(this.label3);
            this.pDados.Controls.Add(this.cpf);
            this.pDados.Controls.Add(this.label2);
            this.pDados.Controls.Add(this.cnpj);
            this.pDados.Controls.Add(this.label1);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(260, 131);
            this.pDados.TabIndex = 0;
            // 
            // bb_cancelar
            // 
            this.bb_cancelar.Location = new System.Drawing.Point(132, 97);
            this.bb_cancelar.Name = "bb_cancelar";
            this.bb_cancelar.Size = new System.Drawing.Size(75, 23);
            this.bb_cancelar.TabIndex = 4;
            this.bb_cancelar.Text = "Cancelar";
            this.bb_cancelar.UseVisualStyleBackColor = true;
            this.bb_cancelar.Click += new System.EventHandler(this.bb_cancelar_Click);
            // 
            // bb_consultar
            // 
            this.bb_consultar.Location = new System.Drawing.Point(51, 97);
            this.bb_consultar.Name = "bb_consultar";
            this.bb_consultar.Size = new System.Drawing.Size(75, 23);
            this.bb_consultar.TabIndex = 3;
            this.bb_consultar.Text = "Consultar";
            this.bb_consultar.UseVisualStyleBackColor = true;
            this.bb_consultar.Click += new System.EventHandler(this.bb_consultar_Click);
            // 
            // uf
            // 
            this.uf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uf.FormattingEnabled = true;
            this.uf.Location = new System.Drawing.Point(14, 63);
            this.uf.Name = "uf";
            this.uf.NM_Alias = "";
            this.uf.NM_Campo = "";
            this.uf.NM_Param = "";
            this.uf.Size = new System.Drawing.Size(44, 21);
            this.uf.ST_Gravar = false;
            this.uf.ST_LimparCampo = true;
            this.uf.ST_NotNull = false;
            this.uf.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "UF";
            // 
            // cpf
            // 
            this.cpf.Location = new System.Drawing.Point(133, 24);
            this.cpf.Mask = "999.999.999-99";
            this.cpf.Name = "cpf";
            this.cpf.NM_Alias = "";
            this.cpf.NM_Campo = "";
            this.cpf.NM_CampoBusca = "";
            this.cpf.NM_Param = "";
            this.cpf.Size = new System.Drawing.Size(113, 20);
            this.cpf.ST_Gravar = false;
            this.cpf.ST_LimpaCampo = true;
            this.cpf.ST_NotNull = false;
            this.cpf.ST_PrimaryKey = false;
            this.cpf.TabIndex = 1;
            this.cpf.Leave += new System.EventHandler(this.cpf_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF";
            // 
            // cnpj
            // 
            this.cnpj.Location = new System.Drawing.Point(14, 24);
            this.cnpj.Mask = "99.999.999/9999-99";
            this.cnpj.Name = "cnpj";
            this.cnpj.NM_Alias = "";
            this.cnpj.NM_Campo = "";
            this.cnpj.NM_CampoBusca = "";
            this.cnpj.NM_Param = "";
            this.cnpj.Size = new System.Drawing.Size(113, 20);
            this.cnpj.ST_Gravar = false;
            this.cnpj.ST_LimpaCampo = true;
            this.cnpj.ST_NotNull = false;
            this.cnpj.ST_PrimaryKey = false;
            this.cnpj.TabIndex = 0;
            this.cnpj.Leave += new System.EventHandler(this.cnpj_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CNPJ";
            // 
            // TFConsultaCadCliforNFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 131);
            this.ControlBox = false;
            this.Controls.Add(this.pDados);
            this.KeyPreview = true;
            this.Name = "TFConsultaCadCliforNFe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Cadastro Cliente NFe";
            this.Load += new System.EventHandler(this.TFConsultaCadCliforNFe_Load);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_cancelar;
        private System.Windows.Forms.Button bb_consultar;
        private Componentes.ComboBoxDefault uf;
        private System.Windows.Forms.Label label3;
        private Componentes.EditMask cpf;
        private System.Windows.Forms.Label label2;
        private Componentes.EditMask cnpj;
        private System.Windows.Forms.Label label1;
    }
}