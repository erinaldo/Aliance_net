using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;



namespace srvNFE
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
           InitializeComponent();
           SPInstaller.Account = ServiceAccount.User;
           SPInstaller.Username = "agrosystems\\Administrador";
           SPInstaller.Password = "infosys@2009_";
        }
    }
}
