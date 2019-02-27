using ModularWinApp.Core;
using ModularWinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularWinApp.Modules.Clients
{
    [ModuleAttribute("Clients")]
    public class ClientsModule : IModule
    {
        ICommandDispatcher _commands = new ModuleCommandDispatcher();

        public string Name
        {
            get { return "Clients"; }
        }

        public ICommandDispatcher Commands
        {
            get { return _commands; }
        }

        public IModuleHandler ModuleHandler
        {
            get { return ClientsCommandFacade.ModuleHandler; }
        }

        [ImportingConstructor()]
        public ClientsModule([Import(typeof(IModuleHandler))] IModuleHandler moduleHandler_)
        {
            ClientsCommandFacade.ModuleHandler = moduleHandler_;
            RegisterCommands();
        }

        public void RegisterCommands()
        {
            //_commands.Register("Pessoas.Novo", new ModuleCommand<bool>(PessoasFacade.Novo));
            _commands.Register("Clients.GetClientList", new ModuleCommand<DataTable>(ClientsCommandFacade.GetClientList));
            //_commands.Register("Pessoas.RecuperarPessoaNome", new ModuleCommand<string, string>(PessoasFacade.RecuperarPessoaNome));
        }
    }
}
