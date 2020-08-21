namespace Consulta
{
    partial class TFEscolha_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFEscolha_Menu));
            this.pDadosItemMenu = new Componentes.PanelDados(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.ItemMenu = new Componentes.EditDefault(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.Nr3 = new Componentes.EditDefault(this.components);
            this.balenr2 = new System.Windows.Forms.Label();
            this.Nr2 = new Componentes.ComboBoxDefault(this.components);
            this.radioGroupTPMenu = new Componentes.RadioGroup(this.components);
            this.rb_Sintetico = new Componentes.RadioButtonDefault(this.components);
            this.rb_Analitico = new Componentes.RadioButtonDefault(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Nivel = new Componentes.ComboBoxDefault(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Nr1 = new Componentes.EditDefault(this.components);
            this.DS_Menu = new Componentes.EditDefault(this.components);
            this.gb_Menu = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.ts_CadMenu = new System.Windows.Forms.ToolStrip();
            this.tsb_AddItem = new System.Windows.Forms.ToolStripButton();
            this.tsb_DelItem = new System.Windows.Forms.ToolStripButton();
            this.bb_Cancelar = new System.Windows.Forms.Button();
            this.bb_OK = new System.Windows.Forms.Button();
            this.pDadosItemMenu.SuspendLayout();
            this.radioGroupTPMenu.SuspendLayout();
            this.gb_Menu.SuspendLayout();
            this.ts_CadMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pDadosItemMenu
            // 
            this.pDadosItemMenu.AccessibleDescription = null;
            this.pDadosItemMenu.AccessibleName = null;
            resources.ApplyResources(this.pDadosItemMenu, "pDadosItemMenu");
            this.pDadosItemMenu.BackgroundImage = null;
            this.pDadosItemMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pDadosItemMenu.Controls.Add(this.label6);
            this.pDadosItemMenu.Controls.Add(this.ItemMenu);
            this.pDadosItemMenu.Controls.Add(this.label5);
            this.pDadosItemMenu.Controls.Add(this.Nr3);
            this.pDadosItemMenu.Controls.Add(this.balenr2);
            this.pDadosItemMenu.Controls.Add(this.Nr2);
            this.pDadosItemMenu.Controls.Add(this.radioGroupTPMenu);
            this.pDadosItemMenu.Controls.Add(this.label4);
            this.pDadosItemMenu.Controls.Add(this.cb_Nivel);
            this.pDadosItemMenu.Controls.Add(this.label2);
            this.pDadosItemMenu.Controls.Add(this.label3);
            this.pDadosItemMenu.Controls.Add(this.Nr1);
            this.pDadosItemMenu.Controls.Add(this.DS_Menu);
            this.pDadosItemMenu.Controls.Add(this.bb_Cancelar);
            this.pDadosItemMenu.Controls.Add(this.bb_OK);
            this.pDadosItemMenu.Font = null;
            this.pDadosItemMenu.Name = "pDadosItemMenu";
            this.pDadosItemMenu.NM_ProcDeletar = "";
            this.pDadosItemMenu.NM_ProcGravar = "";
            // 
            // label6
            // 
            this.label6.AccessibleDescription = null;
            this.label6.AccessibleName = null;
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // ItemMenu
            // 
            this.ItemMenu.AccessibleDescription = null;
            this.ItemMenu.AccessibleName = null;
            resources.ApplyResources(this.ItemMenu, "ItemMenu");
            this.ItemMenu.BackColor = System.Drawing.SystemColors.Window;
            this.ItemMenu.BackgroundImage = null;
            this.ItemMenu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ItemMenu.Font = null;
            this.ItemMenu.Name = "ItemMenu";
            this.ItemMenu.NM_Alias = "";
            this.ItemMenu.NM_Campo = "DS_Report";
            this.ItemMenu.NM_CampoBusca = "DS_Report";
            this.ItemMenu.NM_Param = "@P_DS_REPORT";
            this.ItemMenu.QTD_Zero = 0;
            this.ItemMenu.ST_AutoInc = false;
            this.ItemMenu.ST_DisableAuto = false;
            this.ItemMenu.ST_Float = false;
            this.ItemMenu.ST_Gravar = true;
            this.ItemMenu.ST_Int = false;
            this.ItemMenu.ST_LimpaCampo = true;
            this.ItemMenu.ST_NotNull = true;
            this.ItemMenu.ST_PrimaryKey = false;
            // 
            // label5
            // 
            this.label5.AccessibleDescription = null;
            this.label5.AccessibleName = null;
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // Nr3
            // 
            this.Nr3.AccessibleDescription = null;
            this.Nr3.AccessibleName = null;
            resources.ApplyResources(this.Nr3, "Nr3");
            this.Nr3.BackColor = System.Drawing.SystemColors.Window;
            this.Nr3.BackgroundImage = null;
            this.Nr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr3.Font = null;
            this.Nr3.Name = "Nr3";
            this.Nr3.NM_Alias = "";
            this.Nr3.NM_Campo = "ID_Report";
            this.Nr3.NM_CampoBusca = "ID_Report";
            this.Nr3.NM_Param = "@P_ID_REPORT";
            this.Nr3.QTD_Zero = 2;
            this.Nr3.ST_AutoInc = false;
            this.Nr3.ST_DisableAuto = true;
            this.Nr3.ST_Float = false;
            this.Nr3.ST_Gravar = true;
            this.Nr3.ST_Int = true;
            this.Nr3.ST_LimpaCampo = true;
            this.Nr3.ST_NotNull = true;
            this.Nr3.ST_PrimaryKey = true;
            // 
            // balenr2
            // 
            this.balenr2.AccessibleDescription = null;
            this.balenr2.AccessibleName = null;
            resources.ApplyResources(this.balenr2, "balenr2");
            this.balenr2.Name = "balenr2";
            // 
            // Nr2
            // 
            this.Nr2.AccessibleDescription = null;
            this.Nr2.AccessibleName = null;
            resources.ApplyResources(this.Nr2, "Nr2");
            this.Nr2.BackgroundImage = null;
            this.Nr2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Nr2.Font = null;
            this.Nr2.FormattingEnabled = true;
            this.Nr2.Items.AddRange(new object[] {
            resources.GetString("Nr2.Items"),
            resources.GetString("Nr2.Items1")});
            this.Nr2.Name = "Nr2";
            this.Nr2.NM_Alias = "";
            this.Nr2.NM_Campo = "";
            this.Nr2.NM_Param = "";
            this.Nr2.ST_Gravar = false;
            this.Nr2.ST_LimparCampo = true;
            this.Nr2.ST_NotNull = true;
            this.Nr2.SelectedIndexChanged += new System.EventHandler(this.Nr2_SelectedIndexChanged);
            // 
            // radioGroupTPMenu
            // 
            this.radioGroupTPMenu.AccessibleDescription = null;
            this.radioGroupTPMenu.AccessibleName = null;
            resources.ApplyResources(this.radioGroupTPMenu, "radioGroupTPMenu");
            this.radioGroupTPMenu.BackgroundImage = null;
            this.radioGroupTPMenu.Controls.Add(this.rb_Sintetico);
            this.radioGroupTPMenu.Controls.Add(this.rb_Analitico);
            this.radioGroupTPMenu.Font = null;
            this.radioGroupTPMenu.Name = "radioGroupTPMenu";
            this.radioGroupTPMenu.NM_Alias = "";
            this.radioGroupTPMenu.NM_Campo = "";
            this.radioGroupTPMenu.NM_Param = "";
            this.radioGroupTPMenu.NM_Valor = "S";
            this.radioGroupTPMenu.ST_Gravar = false;
            this.radioGroupTPMenu.ST_NotNull = false;
            this.radioGroupTPMenu.TabStop = false;
            // 
            // rb_Sintetico
            // 
            this.rb_Sintetico.AccessibleDescription = null;
            this.rb_Sintetico.AccessibleName = null;
            resources.ApplyResources(this.rb_Sintetico, "rb_Sintetico");
            this.rb_Sintetico.BackgroundImage = null;
            this.rb_Sintetico.Checked = true;
            this.rb_Sintetico.Font = null;
            this.rb_Sintetico.Name = "rb_Sintetico";
            this.rb_Sintetico.TabStop = true;
            this.rb_Sintetico.UseVisualStyleBackColor = true;
            this.rb_Sintetico.Valor = "S";
            this.rb_Sintetico.CheckedChanged += new System.EventHandler(this.rb_Sintetico_CheckedChanged);
            // 
            // rb_Analitico
            // 
            this.rb_Analitico.AccessibleDescription = null;
            this.rb_Analitico.AccessibleName = null;
            resources.ApplyResources(this.rb_Analitico, "rb_Analitico");
            this.rb_Analitico.BackgroundImage = null;
            this.rb_Analitico.Font = null;
            this.rb_Analitico.Name = "rb_Analitico";
            this.rb_Analitico.UseVisualStyleBackColor = true;
            this.rb_Analitico.Valor = "P";
            this.rb_Analitico.CheckedChanged += new System.EventHandler(this.rb_Analitico_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AccessibleDescription = null;
            this.label4.AccessibleName = null;
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cb_Nivel
            // 
            this.cb_Nivel.AccessibleDescription = null;
            this.cb_Nivel.AccessibleName = null;
            resources.ApplyResources(this.cb_Nivel, "cb_Nivel");
            this.cb_Nivel.BackgroundImage = null;
            this.cb_Nivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Nivel.Font = null;
            this.cb_Nivel.FormattingEnabled = true;
            this.cb_Nivel.Items.AddRange(new object[] {
            resources.GetString("cb_Nivel.Items"),
            resources.GetString("cb_Nivel.Items1"),
            resources.GetString("cb_Nivel.Items2"),
            resources.GetString("cb_Nivel.Items3")});
            this.cb_Nivel.Name = "cb_Nivel";
            this.cb_Nivel.NM_Alias = "";
            this.cb_Nivel.NM_Campo = "";
            this.cb_Nivel.NM_Param = "";
            this.cb_Nivel.ST_Gravar = false;
            this.cb_Nivel.ST_LimparCampo = true;
            this.cb_Nivel.ST_NotNull = false;
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            this.label3.AccessibleDescription = null;
            this.label3.AccessibleName = null;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Nr1
            // 
            this.Nr1.AccessibleDescription = null;
            this.Nr1.AccessibleName = null;
            resources.ApplyResources(this.Nr1, "Nr1");
            this.Nr1.BackColor = System.Drawing.SystemColors.Window;
            this.Nr1.BackgroundImage = null;
            this.Nr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Nr1.Font = null;
            this.Nr1.Name = "Nr1";
            this.Nr1.NM_Alias = "";
            this.Nr1.NM_Campo = "";
            this.Nr1.NM_CampoBusca = "";
            this.Nr1.NM_Param = "";
            this.Nr1.QTD_Zero = 2;
            this.Nr1.ST_AutoInc = false;
            this.Nr1.ST_DisableAuto = true;
            this.Nr1.ST_Float = false;
            this.Nr1.ST_Gravar = true;
            this.Nr1.ST_Int = false;
            this.Nr1.ST_LimpaCampo = true;
            this.Nr1.ST_NotNull = false;
            this.Nr1.ST_PrimaryKey = false;
            // 
            // DS_Menu
            // 
            this.DS_Menu.AccessibleDescription = null;
            this.DS_Menu.AccessibleName = null;
            resources.ApplyResources(this.DS_Menu, "DS_Menu");
            this.DS_Menu.BackColor = System.Drawing.SystemColors.Window;
            this.DS_Menu.BackgroundImage = null;
            this.DS_Menu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DS_Menu.Font = null;
            this.DS_Menu.Name = "DS_Menu";
            this.DS_Menu.NM_Alias = "";
            this.DS_Menu.NM_Campo = "DS_Report";
            this.DS_Menu.NM_CampoBusca = "DS_Report";
            this.DS_Menu.NM_Param = "@P_DS_REPORT";
            this.DS_Menu.QTD_Zero = 0;
            this.DS_Menu.ST_AutoInc = false;
            this.DS_Menu.ST_DisableAuto = false;
            this.DS_Menu.ST_Float = false;
            this.DS_Menu.ST_Gravar = true;
            this.DS_Menu.ST_Int = false;
            this.DS_Menu.ST_LimpaCampo = true;
            this.DS_Menu.ST_NotNull = true;
            this.DS_Menu.ST_PrimaryKey = false;
            // 
            // gb_Menu
            // 
            this.gb_Menu.AccessibleDescription = null;
            this.gb_Menu.AccessibleName = null;
            resources.ApplyResources(this.gb_Menu, "gb_Menu");
            this.gb_Menu.BackgroundImage = null;
            this.gb_Menu.Controls.Add(this.treeMenu);
            this.gb_Menu.Controls.Add(this.ts_CadMenu);
            this.gb_Menu.Name = "gb_Menu";
            this.gb_Menu.TabStop = false;
            // 
            // treeMenu
            // 
            this.treeMenu.AccessibleDescription = null;
            this.treeMenu.AccessibleName = null;
            resources.ApplyResources(this.treeMenu, "treeMenu");
            this.treeMenu.BackgroundImage = null;
            this.treeMenu.Font = null;
            this.treeMenu.FullRowSelect = true;
            this.treeMenu.HideSelection = false;
            this.treeMenu.Name = "treeMenu";
            // 
            // ts_CadMenu
            // 
            this.ts_CadMenu.AccessibleDescription = null;
            this.ts_CadMenu.AccessibleName = null;
            resources.ApplyResources(this.ts_CadMenu, "ts_CadMenu");
            this.ts_CadMenu.BackgroundImage = null;
            this.ts_CadMenu.Font = null;
            this.ts_CadMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_AddItem,
            this.tsb_DelItem});
            this.ts_CadMenu.Name = "ts_CadMenu";
            // 
            // tsb_AddItem
            // 
            this.tsb_AddItem.AccessibleDescription = null;
            this.tsb_AddItem.AccessibleName = null;
            resources.ApplyResources(this.tsb_AddItem, "tsb_AddItem");
            this.tsb_AddItem.BackgroundImage = null;
            this.tsb_AddItem.Name = "tsb_AddItem";
            this.tsb_AddItem.Click += new System.EventHandler(this.tsb_AddItem_Click);
            // 
            // tsb_DelItem
            // 
            this.tsb_DelItem.AccessibleDescription = null;
            this.tsb_DelItem.AccessibleName = null;
            resources.ApplyResources(this.tsb_DelItem, "tsb_DelItem");
            this.tsb_DelItem.BackgroundImage = null;
            this.tsb_DelItem.Name = "tsb_DelItem";
            this.tsb_DelItem.Click += new System.EventHandler(this.tsb_DelItem_Click);
            // 
            // bb_Cancelar
            // 
            this.bb_Cancelar.AccessibleDescription = null;
            this.bb_Cancelar.AccessibleName = null;
            resources.ApplyResources(this.bb_Cancelar, "bb_Cancelar");
            this.bb_Cancelar.BackgroundImage = null;
            this.bb_Cancelar.Font = null;
            this.bb_Cancelar.Name = "bb_Cancelar";
            this.bb_Cancelar.UseVisualStyleBackColor = true;
            this.bb_Cancelar.Click += new System.EventHandler(this.bb_CancelarMenu_Click);
            // 
            // bb_OK
            // 
            this.bb_OK.AccessibleDescription = null;
            this.bb_OK.AccessibleName = null;
            resources.ApplyResources(this.bb_OK, "bb_OK");
            this.bb_OK.BackgroundImage = null;
            this.bb_OK.Font = null;
            this.bb_OK.Name = "bb_OK";
            this.bb_OK.UseVisualStyleBackColor = true;
            this.bb_OK.Click += new System.EventHandler(this.bb_SalvarMenu_Click);
            // 
            // TFEscolha_Menu
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.gb_Menu);
            this.Controls.Add(this.pDadosItemMenu);
            this.Font = null;
            this.Icon = null;
            this.Name = "TFEscolha_Menu";
            this.Load += new System.EventHandler(this.TFEscolha_Menu_Load);
            this.pDadosItemMenu.ResumeLayout(false);
            this.pDadosItemMenu.PerformLayout();
            this.radioGroupTPMenu.ResumeLayout(false);
            this.radioGroupTPMenu.PerformLayout();
            this.gb_Menu.ResumeLayout(false);
            this.gb_Menu.PerformLayout();
            this.ts_CadMenu.ResumeLayout(false);
            this.ts_CadMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Componentes.PanelDados pDadosItemMenu;
        private System.Windows.Forms.Button bb_Cancelar;
        private System.Windows.Forms.Button bb_OK;
        private System.Windows.Forms.GroupBox gb_Menu;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.ToolStrip ts_CadMenu;
        private System.Windows.Forms.ToolStripButton tsb_AddItem;
        private System.Windows.Forms.ToolStripButton tsb_DelItem;
        private System.Windows.Forms.Label label6;
        private Componentes.EditDefault ItemMenu;
        private System.Windows.Forms.Label label5;
        private Componentes.EditDefault Nr3;
        private System.Windows.Forms.Label balenr2;
        private Componentes.ComboBoxDefault Nr2;
        private Componentes.RadioGroup radioGroupTPMenu;
        private System.Windows.Forms.Label label4;
        private Componentes.ComboBoxDefault cb_Nivel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Componentes.EditDefault Nr1;
        private Componentes.EditDefault DS_Menu;
        public Componentes.RadioButtonDefault rb_Sintetico;
        public Componentes.RadioButtonDefault rb_Analitico;
    }
}