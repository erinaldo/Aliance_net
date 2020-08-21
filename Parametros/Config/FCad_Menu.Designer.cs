namespace Parametros.Config
{
    partial class TFCad_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFCad_Menu));
            this.tableLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.gb_Info = new System.Windows.Forms.GroupBox();
            this.treeMenuPreCad = new System.Windows.Forms.TreeView();
            this.gb_Menu = new System.Windows.Forms.GroupBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.tcCentral.SuspendLayout();
            this.tpPadrao.SuspendLayout();
            this.tableLayoutMenu.SuspendLayout();
            this.gb_Info.SuspendLayout();
            this.gb_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcCentral
            // 
            this.tcCentral.AccessibleDescription = null;
            this.tcCentral.AccessibleName = null;
            resources.ApplyResources(this.tcCentral, "tcCentral");
            this.tcCentral.BackgroundImage = null;
            this.tcCentral.Font = null;
            // 
            // tpPadrao
            // 
            this.tpPadrao.AccessibleDescription = null;
            this.tpPadrao.AccessibleName = null;
            resources.ApplyResources(this.tpPadrao, "tpPadrao");
            this.tpPadrao.BackgroundImage = null;
            this.tpPadrao.Controls.Add(this.tableLayoutMenu);
            this.tpPadrao.Font = null;
            // 
            // tableLayoutMenu
            // 
            this.tableLayoutMenu.AccessibleDescription = null;
            this.tableLayoutMenu.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutMenu, "tableLayoutMenu");
            this.tableLayoutMenu.BackgroundImage = null;
            this.tableLayoutMenu.Controls.Add(this.gb_Info, 1, 0);
            this.tableLayoutMenu.Controls.Add(this.gb_Menu, 0, 0);
            this.tableLayoutMenu.Font = null;
            this.tableLayoutMenu.Name = "tableLayoutMenu";
            // 
            // gb_Info
            // 
            this.gb_Info.AccessibleDescription = null;
            this.gb_Info.AccessibleName = null;
            resources.ApplyResources(this.gb_Info, "gb_Info");
            this.gb_Info.BackgroundImage = null;
            this.gb_Info.Controls.Add(this.treeMenuPreCad);
            this.gb_Info.Font = null;
            this.gb_Info.Name = "gb_Info";
            this.gb_Info.TabStop = false;
            // 
            // treeMenuPreCad
            // 
            this.treeMenuPreCad.AccessibleDescription = null;
            this.treeMenuPreCad.AccessibleName = null;
            this.treeMenuPreCad.AllowDrop = true;
            resources.ApplyResources(this.treeMenuPreCad, "treeMenuPreCad");
            this.treeMenuPreCad.BackgroundImage = null;
            this.treeMenuPreCad.Font = null;
            this.treeMenuPreCad.FullRowSelect = true;
            this.treeMenuPreCad.HideSelection = false;
            this.treeMenuPreCad.Name = "treeMenuPreCad";
            // 
            // gb_Menu
            // 
            this.gb_Menu.AccessibleDescription = null;
            this.gb_Menu.AccessibleName = null;
            resources.ApplyResources(this.gb_Menu, "gb_Menu");
            this.gb_Menu.BackgroundImage = null;
            this.gb_Menu.Controls.Add(this.treeMenu);
            this.gb_Menu.Font = null;
            this.gb_Menu.Name = "gb_Menu";
            this.gb_Menu.TabStop = false;
            // 
            // treeMenu
            // 
            this.treeMenu.AccessibleDescription = null;
            this.treeMenu.AccessibleName = null;
            this.treeMenu.AllowDrop = true;
            resources.ApplyResources(this.treeMenu, "treeMenu");
            this.treeMenu.BackgroundImage = null;
            this.treeMenu.Font = null;
            this.treeMenu.FullRowSelect = true;
            this.treeMenu.HideSelection = false;
            this.treeMenu.Name = "treeMenu";
            // 
            // TFCad_Menu
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Font = null;
            this.Name = "TFCad_Menu";
            this.Load += new System.EventHandler(this.TFCad_Menu_Load);
            this.tcCentral.ResumeLayout(false);
            this.tpPadrao.ResumeLayout(false);
            this.tableLayoutMenu.ResumeLayout(false);
            this.gb_Info.ResumeLayout(false);
            this.gb_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMenu;
        private System.Windows.Forms.GroupBox gb_Info;
        private System.Windows.Forms.TreeView treeMenuPreCad;
        private System.Windows.Forms.GroupBox gb_Menu;
        private System.Windows.Forms.TreeView treeMenu;
    }
}
