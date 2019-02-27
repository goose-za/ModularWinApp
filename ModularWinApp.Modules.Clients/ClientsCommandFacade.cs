using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModularWinApp.Core.Interfaces;
using System.Data;

namespace ModularWinApp.Modules.Clients
{
    /// <summary>
    /// This is a static class that will handle all the methods 
    /// that are used by Menu and used by other modules;
    /// </summary>
    public static class ClientsCommandFacade
    {
        public static IModuleHandler ModuleHandler { get; set; }

        public static void MenuNovo(object sender, EventArgs e)
        {
            NewClient();
        }

        public static void MenuConsultar(object sender, EventArgs e)
        {
            ViewClient();
        }

        public static bool NewClient()
        {
            frmClient f = new frmClient();
            f.MdiParent = (Form)ModuleHandler.Host;
            f.Show();
            return true;
        }

        public static bool ViewClient()
        {
            frmClients f = new frmClients();
            f.MdiParent = (Form)ModuleHandler.Host;
            f.Show();
            return true;
        }

        public static DataSet SelectClients()
        {
            frmClients f = new frmClients();
            f.ShowDialog();
            DataSet l = f.SelectedClients;
            return l;
        }

        public static string GetClientName(int id_)
        {
            ClientsService _cs = new ClientsService();
            return _cs.GetClientName(id_);
        }

        public static DataTable GetClientList()
        {
            ClientsService _cs = new ClientsService();
            return _cs.GetClientsDataTable();
        }
    }
}
