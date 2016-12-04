using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;

namespace JinnSportsService
{
    [RunInstaller(true)]
    public partial class JinnSportsInstaller : Installer
    {
        public JinnSportsInstaller()
        {
            InitializeComponent();
            ServiceInstaller HTMLServiceInstaller = new ServiceInstaller();
            ServiceProcessInstaller HTMLProcessInstaller = new ServiceProcessInstaller();

            HTMLProcessInstaller.Account = ServiceAccount.LocalSystem;
            HTMLServiceInstaller.StartType = ServiceStartMode.Manual;
            HTMLServiceInstaller.ServiceName = "HTMLService";
            HTMLServiceInstaller.DisplayName = "HTMLService";
            Installers.Add(HTMLProcessInstaller);
            Installers.Add(HTMLServiceInstaller);

            //ServiceInstaller JSONServiceInstaller = new ServiceInstaller();
            //ServiceProcessInstaller JSONProcessInstaller = new ServiceProcessInstaller();

            //JSONProcessInstaller.Account = ServiceAccount.LocalSystem;
            //JSONServiceInstaller.StartType = ServiceStartMode.Manual;
            //JSONServiceInstaller.ServiceName = "JSONService";
            //JSONServiceInstaller.DisplayName = "JSONService";
            //Installers.Add(JSONProcessInstaller);
            //Installers.Add(JSONServiceInstaller);
        }
    }
}
