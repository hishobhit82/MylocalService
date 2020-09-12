using System.ServiceProcess;

namespace MyLocalServiceHost
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
            components = new System.ComponentModel.Container();
            AfterInstall += ProjectInstaller_AfterInstall;


            this.MyLocalServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MyServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MyLocalServiceProcessInstaller
            // 
            this.MyLocalServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MyLocalServiceProcessInstaller.Password = null;
            this.MyLocalServiceProcessInstaller.Username = null;
            // 
            // MyServiceInstaller
            // 
            this.MyServiceInstaller.ServiceName = "MyLocalService";
            this.MyServiceInstaller.Description = "Local WCF RestFul Service ";
            this.MyServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MyLocalServiceProcessInstaller,
            this.MyServiceInstaller});

        }

        private void ProjectInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(MyServiceInstaller.ServiceName))
            {
                sc.Start();
            }
        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller MyLocalServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller MyServiceInstaller;
    }
}