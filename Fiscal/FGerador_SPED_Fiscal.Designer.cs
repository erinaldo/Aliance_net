namespace Fiscal
{
    partial class TFGerador_SPED_Fiscal
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
            System.Windows.Forms.Label dt_saientLabel;
            System.Windows.Forms.Label cd_empresaLabel;
            System.Windows.Forms.Label dt_emissaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFGerador_SPED_Fiscal));
            this.pDados = new Componentes.PanelDados(this.components);
            this.rb_Atividade = new Componentes.RadioGroup(this.components);
            this.rb_Outros = new Componentes.RadioButtonDefault(this.components);
            this.rb_Industrial = new Componentes.RadioButtonDefault(this.components);
            this.rb_Perfil = new Componentes.RadioGroup(this.components);
            this.rb_PerfilC = new Componentes.RadioButtonDefault(this.components);
            this.rb_PerfilB = new Componentes.RadioButtonDefault(this.components);
            this.rb_PerfilA = new Componentes.RadioButtonDefault(this.components);
            this.rg_Finalidade = new Componentes.RadioGroup(this.components);
            this.rb_Substituto = new Componentes.RadioButtonDefault(this.components);
            this.rb_Original = new Componentes.RadioButtonDefault(this.components);
            this.bb_empresa_busca = new System.Windows.Forms.Button();
            this.DT_Final = new Componentes.EditData(this.components);
            this.DT_Inicio = new Componentes.EditData(this.components);
            this.cd_empresa = new Componentes.EditDefault(this.components);
            this.nm_empresa = new Componentes.EditDefault(this.components);
            dt_saientLabel = new System.Windows.Forms.Label();
            cd_empresaLabel = new System.Windows.Forms.Label();
            dt_emissaoLabel = new System.Windows.Forms.Label();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            this.pDados.SuspendLayout();
            this.rb_Atividade.SuspendLayout();
            this.rb_Perfil.SuspendLayout();
            this.rg_Finalidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.Size = new System.Drawing.Size(602, 166);
            // 
            // tpPadrao
            // 
            this.tpPadrao.Controls.Add(this.pDados);
            this.tpPadrao.Size = new System.Drawing.Size(594, 140);
            this.tpPadrao.Text = "Gerador SPED Fiscal";
            // 
            // dt_saientLabel
            // 
            dt_saientLabel.AutoSize = true;
            dt_saientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dt_saientLabel.Location = new System.Drawing.Point(177, 10);
            dt_saientLabel.Name = "dt_saientLabel";
            dt_saientLabel.Size = new System.Drawing.Size(69, 13);
            dt_saientLabel.TabIndex = 55;
            dt_saientLabel.Text = "Data Final:";
            // 
            // cd_empresaLabel
            // 
            cd_empresaLabel.AutoSize = true;
            cd_empresaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cd_empresaLabel.Location = new System.Drawing.Point(24, 34);
            cd_empresaLabel.Name = "cd_empresaLabel";
            cd_empresaLabel.Size = new System.Drawing.Size(59, 13);
            cd_empresaLabel.TabIndex = 52;
            cd_empresaLabel.Text = "Empresa:";
            // 
            // dt_emissaoLabel
            // 
            dt_emissaoLabel.AutoSize = true;
            dt_emissaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dt_emissaoLabel.Location = new System.Drawing.Point(8, 10);
            dt_emissaoLabel.Name = "dt_emissaoLabel";
            dt_emissaoLabel.Size = new System.Drawing.Size(75, 13);
            dt_emissaoLabel.TabIndex = 51;
            dt_emissaoLabel.Text = "Data Início:";
            // 
            // pDados
            // 
            this.pDados.Controls.Add(this.rb_Atividade);
            this.pDados.Controls.Add(this.rb_Perfil);
            this.pDados.Controls.Add(this.rg_Finalidade);
            this.pDados.Controls.Add(this.bb_empresa_busca);
            this.pDados.Controls.Add(dt_saientLabel);
            this.pDados.Controls.Add(this.DT_Final);
            this.pDados.Controls.Add(cd_empresaLabel);
            this.pDados.Controls.Add(this.DT_Inicio);
            this.pDados.Controls.Add(dt_emissaoLabel);
            this.pDados.Controls.Add(this.cd_empresa);
            this.pDados.Controls.Add(this.nm_empresa);
            this.pDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDados.Location = new System.Drawing.Point(0, 0);
            this.pDados.Name = "pDados";
            this.pDados.NM_ProcDeletar = "";
            this.pDados.NM_ProcGravar = "";
            this.pDados.Size = new System.Drawing.Size(590, 136);
            this.pDados.TabIndex = 0;
            // 
            // rb_Atividade
            // 
            this.rb_Atividade.Controls.Add(this.rb_Outros);
            this.rb_Atividade.Controls.Add(this.rb_Industrial);
            this.rb_Atividade.Location = new System.Drawing.Point(403, 55);
            this.rb_Atividade.Name = "rb_Atividade";
            this.rb_Atividade.NM_Alias = "";
            this.rb_Atividade.NM_Campo = "";
            this.rb_Atividade.NM_Param = "";
            this.rb_Atividade.NM_Valor = "";
            this.rb_Atividade.Size = new System.Drawing.Size(153, 70);
            this.rb_Atividade.ST_Gravar = false;
            this.rb_Atividade.ST_NotNull = false;
            this.rb_Atividade.TabIndex = 6;
            this.rb_Atividade.TabStop = false;
            this.rb_Atividade.Text = "Atividade";
            // 
            // rb_Outros
            // 
            this.rb_Outros.AutoSize = true;
            this.rb_Outros.Checked = true;
            this.rb_Outros.Location = new System.Drawing.Point(7, 43);
            this.rb_Outros.Name = "rb_Outros";
            this.rb_Outros.Size = new System.Drawing.Size(56, 17);
            this.rb_Outros.TabIndex = 1;
            this.rb_Outros.TabStop = true;
            this.rb_Outros.Text = "Outros";
            this.rb_Outros.UseVisualStyleBackColor = true;
            this.rb_Outros.Valor = "";
            // 
            // rb_Industrial
            // 
            this.rb_Industrial.AutoSize = true;
            this.rb_Industrial.Location = new System.Drawing.Point(7, 16);
            this.rb_Industrial.Name = "rb_Industrial";
            this.rb_Industrial.Size = new System.Drawing.Size(141, 30);
            this.rb_Industrial.TabIndex = 0;
            this.rb_Industrial.Text = "Industrial ou equiparado \r\na industrial";
            this.rb_Industrial.UseVisualStyleBackColor = true;
            this.rb_Industrial.Valor = "";
            // 
            // rb_Perfil
            // 
            this.rb_Perfil.Controls.Add(this.rb_PerfilC);
            this.rb_Perfil.Controls.Add(this.rb_PerfilB);
            this.rb_Perfil.Controls.Add(this.rb_PerfilA);
            this.rb_Perfil.Location = new System.Drawing.Point(269, 55);
            this.rb_Perfil.Name = "rb_Perfil";
            this.rb_Perfil.NM_Alias = "";
            this.rb_Perfil.NM_Campo = "";
            this.rb_Perfil.NM_Param = "";
            this.rb_Perfil.NM_Valor = "";
            this.rb_Perfil.Size = new System.Drawing.Size(130, 70);
            this.rb_Perfil.ST_Gravar = false;
            this.rb_Perfil.ST_NotNull = false;
            this.rb_Perfil.TabIndex = 5;
            this.rb_Perfil.TabStop = false;
            this.rb_Perfil.Text = "Perfil";
            // 
            // rb_PerfilC
            // 
            this.rb_PerfilC.AutoSize = true;
            this.rb_PerfilC.Checked = true;
            this.rb_PerfilC.Location = new System.Drawing.Point(7, 44);
            this.rb_PerfilC.Name = "rb_PerfilC";
            this.rb_PerfilC.Size = new System.Drawing.Size(58, 17);
            this.rb_PerfilC.TabIndex = 2;
            this.rb_PerfilC.TabStop = true;
            this.rb_PerfilC.Text = "Perfil C";
            this.rb_PerfilC.UseVisualStyleBackColor = true;
            this.rb_PerfilC.Valor = "";
            // 
            // rb_PerfilB
            // 
            this.rb_PerfilB.AutoSize = true;
            this.rb_PerfilB.Location = new System.Drawing.Point(7, 30);
            this.rb_PerfilB.Name = "rb_PerfilB";
            this.rb_PerfilB.Size = new System.Drawing.Size(58, 17);
            this.rb_PerfilB.TabIndex = 1;
            this.rb_PerfilB.Text = "Perfil B";
            this.rb_PerfilB.UseVisualStyleBackColor = true;
            this.rb_PerfilB.Valor = "";
            // 
            // rb_PerfilA
            // 
            this.rb_PerfilA.AutoSize = true;
            this.rb_PerfilA.Location = new System.Drawing.Point(7, 16);
            this.rb_PerfilA.Name = "rb_PerfilA";
            this.rb_PerfilA.Size = new System.Drawing.Size(58, 17);
            this.rb_PerfilA.TabIndex = 0;
            this.rb_PerfilA.Text = "Perfil A";
            this.rb_PerfilA.UseVisualStyleBackColor = true;
            this.rb_PerfilA.Valor = "";
            // 
            // rg_Finalidade
            // 
            this.rg_Finalidade.Controls.Add(this.rb_Substituto);
            this.rg_Finalidade.Controls.Add(this.rb_Original);
            this.rg_Finalidade.Location = new System.Drawing.Point(85, 55);
            this.rg_Finalidade.Name = "rg_Finalidade";
            this.rg_Finalidade.NM_Alias = "";
            this.rg_Finalidade.NM_Campo = "";
            this.rg_Finalidade.NM_Param = "";
            this.rg_Finalidade.NM_Valor = "";
            this.rg_Finalidade.Size = new System.Drawing.Size(180, 70);
            this.rg_Finalidade.ST_Gravar = false;
            this.rg_Finalidade.ST_NotNull = false;
            this.rg_Finalidade.TabIndex = 4;
            this.rg_Finalidade.TabStop = false;
            this.rg_Finalidade.Text = "Finalidade";
            // 
            // rb_Substituto
            // 
            this.rb_Substituto.AutoSize = true;
            this.rb_Substituto.Checked = true;
            this.rb_Substituto.Location = new System.Drawing.Point(7, 37);
            this.rb_Substituto.Name = "rb_Substituto";
            this.rb_Substituto.Size = new System.Drawing.Size(170, 17);
            this.rb_Substituto.TabIndex = 1;
            this.rb_Substituto.TabStop = true;
            this.rb_Substituto.Text = "Remessa do arquivo substituto";
            this.rb_Substituto.UseVisualStyleBackColor = true;
            this.rb_Substituto.Valor = "";
            // 
            // rb_Original
            // 
            this.rb_Original.AutoSize = true;
            this.rb_Original.Location = new System.Drawing.Point(7, 23);
            this.rb_Original.Name = "rb_Original";
            this.rb_Original.Size = new System.Drawing.Size(158, 17);
            this.rb_Original.TabIndex = 0;
            this.rb_Original.Text = "Remessa do arquivo original";
            this.rb_Original.UseVisualStyleBackColor = true;
            this.rb_Original.Valor = "";
            // 
            // bb_empresa_busca
            // 
            this.bb_empresa_busca.BackColor = System.Drawing.SystemColors.Control;
            this.bb_empresa_busca.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bb_empresa_busca.Image = ((System.Drawing.Image)(resources.GetObject("bb_empresa_busca.Image")));
            this.bb_empresa_busca.Location = new System.Drawing.Point(174, 31);
            this.bb_empresa_busca.Name = "bb_empresa_busca";
            this.bb_empresa_busca.Size = new System.Drawing.Size(30, 20);
            this.bb_empresa_busca.TabIndex = 3;
            this.bb_empresa_busca.UseVisualStyleBackColor = false;
            this.bb_empresa_busca.Click += new System.EventHandler(this.bb_empresa_busca_Click);
            // 
            // DT_Final
            // 
            this.DT_Final.Location = new System.Drawing.Point(247, 7);
            this.DT_Final.Mask = "00/00/0000";
            this.DT_Final.Name = "DT_Final";
            this.DT_Final.NM_Alias = "";
            this.DT_Final.NM_Campo = "";
            this.DT_Final.NM_CampoBusca = "";
            this.DT_Final.NM_Param = "";
            this.DT_Final.Operador = "";
            this.DT_Final.Size = new System.Drawing.Size(87, 20);
            this.DT_Final.ST_Gravar = true;
            this.DT_Final.ST_LimpaCampo = true;
            this.DT_Final.ST_NotNull = false;
            this.DT_Final.ST_PrimaryKey = false;
            this.DT_Final.TabIndex = 1;
            // 
            // DT_Inicio
            // 
            this.DT_Inicio.Location = new System.Drawing.Point(84, 7);
            this.DT_Inicio.Mask = "00/00/0000";
            this.DT_Inicio.Name = "DT_Inicio";
            this.DT_Inicio.NM_Alias = "";
            this.DT_Inicio.NM_Campo = "";
            this.DT_Inicio.NM_CampoBusca = "";
            this.DT_Inicio.NM_Param = "";
            this.DT_Inicio.Operador = "";
            this.DT_Inicio.Size = new System.Drawing.Size(87, 20);
            this.DT_Inicio.ST_Gravar = true;
            this.DT_Inicio.ST_LimpaCampo = true;
            this.DT_Inicio.ST_NotNull = false;
            this.DT_Inicio.ST_PrimaryKey = false;
            this.DT_Inicio.TabIndex = 0;
            // 
            // cd_empresa
            // 
            this.cd_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.cd_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cd_empresa.Location = new System.Drawing.Point(84, 31);
            this.cd_empresa.Name = "cd_empresa";
            this.cd_empresa.NM_Alias = "b";
            this.cd_empresa.NM_Campo = "cd_empresa";
            this.cd_empresa.NM_CampoBusca = "cd_empresa";
            this.cd_empresa.NM_Param = "@P_CD_EMPRESA";
            this.cd_empresa.QTD_Zero = 0;
            this.cd_empresa.Size = new System.Drawing.Size(87, 20);
            this.cd_empresa.ST_AutoInc = false;
            this.cd_empresa.ST_DisableAuto = false;
            this.cd_empresa.ST_Float = false;
            this.cd_empresa.ST_Gravar = true;
            this.cd_empresa.ST_Int = false;
            this.cd_empresa.ST_LimpaCampo = true;
            this.cd_empresa.ST_NotNull = true;
            this.cd_empresa.ST_PrimaryKey = true;
            this.cd_empresa.TabIndex = 2;
            this.cd_empresa.Leave += new System.EventHandler(this.cd_empresa_Leave);
            // 
            // nm_empresa
            // 
            this.nm_empresa.BackColor = System.Drawing.SystemColors.Window;
            this.nm_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nm_empresa.Location = new System.Drawing.Point(206, 31);
            this.nm_empresa.Name = "nm_empresa";
            this.nm_empresa.NM_Alias = "a";
            this.nm_empresa.NM_Campo = "NM_Empresa";
            this.nm_empresa.NM_CampoBusca = "NM_Empresa";
            this.nm_empresa.NM_Param = "@P_NM_EMPRESA";
            this.nm_empresa.QTD_Zero = 0;
            this.nm_empresa.Size = new System.Drawing.Size(350, 20);
            this.nm_empresa.ST_AutoInc = false;
            this.nm_empresa.ST_DisableAuto = false;
            this.nm_empresa.ST_Float = false;
            this.nm_empresa.ST_Gravar = false;
            this.nm_empresa.ST_Int = false;
            this.nm_empresa.ST_LimpaCampo = true;
            this.nm_empresa.ST_NotNull = false;
            this.nm_empresa.ST_PrimaryKey = false;
            this.nm_empresa.TabIndex = 50;
            // 
            // TFGerador_SPED_Fiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(602, 209);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TFGerador_SPED_Fiscal";
            this.Text = "Gerador SPED Fiscal";
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.pDados.ResumeLayout(false);
            this.pDados.PerformLayout();
            this.rb_Atividade.ResumeLayout(false);
            this.rb_Atividade.PerformLayout();
            this.rb_Perfil.ResumeLayout(false);
            this.rb_Perfil.PerformLayout();
            this.rg_Finalidade.ResumeLayout(false);
            this.rg_Finalidade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.PanelDados pDados;
        private System.Windows.Forms.Button bb_empresa_busca;
        private Componentes.EditData DT_Final;
        private Componentes.EditData DT_Inicio;
        private Componentes.EditDefault cd_empresa;
        private Componentes.EditDefault nm_empresa;
        private Componentes.RadioGroup rb_Perfil;
        private Componentes.RadioButtonDefault rb_PerfilB;
        private Componentes.RadioButtonDefault rb_PerfilA;
        private Componentes.RadioGroup rg_Finalidade;
        private Componentes.RadioButtonDefault rb_Substituto;
        private Componentes.RadioButtonDefault rb_Original;
        private Componentes.RadioButtonDefault rb_PerfilC;
        private Componentes.RadioGroup rb_Atividade;
        private Componentes.RadioButtonDefault rb_Outros;
        private Componentes.RadioButtonDefault rb_Industrial;
    }
}
