using ModularWinApp.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularWinApp
{
    static class Program
    {
        //Create a new instance of ModuleHandler. Only one must exist.
        public static ModuleHandler _modHandler = new ModuleHandler();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize the modules. Now the modules will be loaded.
            _modHandler.InitializeModules();
            //Create a new database connection that will be used by the modules.
            //The shared connection is a good way to provide transactions between modules operations
            _modHandler.DataModule.CreateSharedConnection(ConfigurationManager.ConnectionStrings["dbOrdersSampleConnectionString"].ConnectionString);

            //Start the Host Form
            Application.Run(_modHandler.Host as Form);
        }
    }
}
