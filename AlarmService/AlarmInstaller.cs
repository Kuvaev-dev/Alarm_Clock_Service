using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace AlarmService
{
    [RunInstaller(true)]
    public partial class AlarmInstaller : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller = new ServiceInstaller();
        ServiceProcessInstaller serviceProcess = new ServiceProcessInstaller();
        public AlarmInstaller()
        {
            InitializeComponent();
            
            serviceProcess.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "Alarm Clock Service";
            serviceInstaller.Description = "Сервис установки приложения Будильник.";

            serviceInstaller.AfterInstall += ServiceInstaller_AfterInstall;
            serviceInstaller.AfterRollback += ServiceInstaller_AfterRollback;

            Installers.Add(serviceProcess);
            Installers.Add(serviceInstaller);

        }

        private void ServiceInstaller_AfterRollback(object sender, InstallEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Install Rollback!");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Install Done!");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
