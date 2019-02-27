using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModularWinApp.Core.Interfaces;
using ModularWinApp.Core;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace ModularWinApp.Modules.Clients
{
    [MenuAttribute("Clients")]
    public class ClientsMenu : IMenu
    {
        private ToolStripMenuItem ClientsMainMenu;
        private ToolStripMenuItem ClientsConsultarMenu;
        private ToolStripMenuItem ClientsNovoMenu;

        private ToolStripMenuItem CreateMenu()
        {
            this.ClientsMainMenu = new ToolStripMenuItem();
            this.ClientsConsultarMenu = new ToolStripMenuItem();
            this.ClientsNovoMenu = new ToolStripMenuItem();

            // 
            // MenuClientsMain
            // 
            this.ClientsMainMenu.DropDownItems.AddRange(
                new System.Windows.Forms.ToolStripItem[] {
                    this.ClientsConsultarMenu,
                    this.ClientsNovoMenu});
            this.ClientsMainMenu.Name = "MenuClientsMain";
            this.ClientsMainMenu.Text = "Clients";
            // 
            // MenuClientsConsultar
            // 
            this.ClientsConsultarMenu.Name = "MenuClientsConsultar";
            this.ClientsConsultarMenu.Text = "Consultar";
            this.ClientsConsultarMenu.Click += new EventHandler(ClientsCommandFacade.MenuConsultar);
            // 
            // MenuClientsNovo
            // 
            this.ClientsNovoMenu.Name = "MenuClientsNovo";
            this.ClientsNovoMenu.Text = "Novo";
            this.ClientsNovoMenu.Click += new EventHandler(ClientsCommandFacade.MenuNovo);

            return ClientsMainMenu;
        }

        [ImportingConstructor()]
        public ClientsMenu([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            CreateMenu();
            ClientsCommandFacade.ModuleHandler = moduleHandler_;
        }

        public ToolStripMenuItem WinFormsMenu
        {
            get { return ClientsMainMenu; }
        }
    }
}
