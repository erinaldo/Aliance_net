namespace Aliance.NET
{
    partial class TFAlterarSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFAlterarSenha));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pBotoes = new System.Windows.Forms.Panel();
            this.BTN_Sair = new System.Windows.Forms.Button();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.panelDados1 = new Componentes.PanelDados(this.components);
            this.confirma = new Componentes.EditDefault(this.components);
            this.novasenha = new Componentes.EditDefault(this.components);
            this.senhaatual = new Componentes.EditDefault(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pBotoes.SuspendLayout();
            this.panelDados1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pBotoes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelDados1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pBotoes
            // 
            this.pBotoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(182)))), ((int)(((byte)(181)))));
            this.pBotoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBotoes.Controls.Add(this.BTN_Sair);
            this.pBotoes.Controls.Add(this.BTN_OK);
            resources.ApplyResources(this.pBotoes, "pBotoes");
            this.pBotoes.Name = "pBotoes";
            // 
            // BTN_Sair
            // 
            this.BTN_Sair.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTN_Sair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.BTN_Sair, "BTN_Sair");
            this.BTN_Sair.Name = "BTN_Sair";
            this.BTN_Sair.UseVisualStyleBackColor = false;
            // 
            // BTN_OK
            // 
            this.BTN_OK.BackColor = System.Drawing.SystemColors.ActiveBorder;
            resources.ApplyResources(this.BTN_OK, "BTN_OK");
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.UseVisualStyleBackColor = false;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // panelDados1
            // 
            this.panelDados1.BackColor = System.Drawing.Color.White;
            this.panelDados1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDados1.Controls.Add(this.confirma);
            this.panelDados1.Controls.Add(this.novasenha);
            this.panelDados1.Controls.Add(this.senhaatual);
            this.panelDados1.Controls.Add(this.label3);
            this.panelDados1.Controls.Add(this.label1);
            this.panelDados1.Controls.Add(this.label2);
            resources.ApplyResources(this.panelDados1, "panelDados1");
            this.panelDados1.Name = "panelDados1";
            this.panelDados1.NM_ProcDeletar = "";
            this.panelDados1.NM_ProcGravar = "";
            // 
            // confirma
            // 
            this.confirma.BackColor = System.Drawing.SystemColors.Window;
            this.confirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirma.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.confirma, "confirma");
            this.confirma.Name = "confirma";
            this.confirma.NM_Alias = "";
            this.confirma.NM_Campo = "";
            this.confirma.NM_CampoBusca = "";
            this.confirma.NM_Param = "";
            this.confirma.QTD_Zero = 0;
            this.confirma.ST_AutoInc = false;
            this.confirma.ST_DisableAuto = false;
            this.confirma.ST_Float = false;
            this.confirma.ST_Gravar = true;
            this.confirma.ST_Int = false;
            this.confirma.ST_LimpaCampo = true;
            this.confirma.ST_NotNull = false;
            this.confirma.ST_PrimaryKey = false;
            this.confirma.Leave += new System.EventHandler(this.confirma_Leave);
            // 
            // novasenha
            // 
            this.novasenha.BackColor = System.Drawing.SystemColors.Window;
            this.novasenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.novasenha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.novasenha, "novasenha");
            this.novasenha.Name = "novasenha";
            this.novasenha.NM_Alias = "";
            this.novasenha.NM_Campo = "";
            this.novasenha.NM_CampoBusca = "";
            this.novasenha.NM_Param = "";
            this.novasenha.QTD_Zero = 0;
            this.novasenha.ST_AutoInc = false;
            this.novasenha.ST_DisableAuto = false;
            this.novasenha.ST_Float = false;
            this.novasenha.ST_Gravar = true;
            this.novasenha.ST_Int = false;
            this.novasenha.ST_LimpaCampo = true;
            this.novasenha.ST_NotNull = false;
            this.novasenha.ST_PrimaryKey = false;
            // 
            // senhaatual
            // 
            this.senhaatual.BackColor = System.Drawing.SystemColors.Window;
            this.senhaatual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.senhaatual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.senhaatual, "senhaatual");
            this.senhaatual.Name = "senhaatual";
            this.senhaatual.NM_Alias = "";
            this.senhaatual.NM_Campo = "";
            this.senhaatual.NM_CampoBusca = "";
            this.senhaatual.NM_Param = "";
            this.senhaatual.QTD_Zero = 0;
            this.senhaatual.ST_AutoInc = false;
            this.senhaatual.ST_DisableAuto = false;
            this.senhaatual.ST_Float = false;
            this.senhaatual.ST_Gravar = true;
            this.senhaatual.ST_Int = false;
            this.senhaatual.ST_LimpaCampo = true;
            this.senhaatual.ST_NotNull = false;
            this.senhaatual.ST_PrimaryKey = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TFAlterarSenha
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TFAlterarSenha";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.TFAlterarSenha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TFAlterarSenha_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pBotoes.ResumeLayout(false);
            this.panelDados1.ResumeLayout(false);
            this.panelDados1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Componentes.PanelDados panelDados1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Componentes.EditDefault senhaatual;
        private Componentes.EditDefault confirma;
        private Componentes.EditDefault novasenha;
        private System.Windows.Forms.Panel pBotoes;
        public System.Windows.Forms.Button BTN_OK;
        private System.Windows.Forms.Button BTN_Sair;
    }
}