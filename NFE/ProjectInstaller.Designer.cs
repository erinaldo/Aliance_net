namespace srvNFE
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SPInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // SPInstaller
            // 
            this.SPInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.SPInstaller.Password = null;
            this.SPInstaller.Username = null;
            // 
            // SInstaller
            // 
            this.SInstaller.DisplayName = "NFE - Nota Fiscal Eletronica";
            this.SInstaller.ServiceName = "ServicoNFE";
            this.SInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SPInstaller,
            this.SInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SPInstaller;
        private System.ServiceProcess.ServiceInstaller SInstaller;
    }
}