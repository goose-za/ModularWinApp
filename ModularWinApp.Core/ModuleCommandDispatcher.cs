using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModularWinApp.Core.Interfaces;

namespace ModularWinApp.Core
{
    public class ModuleCommandDispatcher : ICommandDispatcher
    {
        //A dictionary to store the module commands
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        //Register the command into the _commands dictionary
        public void Register(string key_, ICommand command_)
        {
            _commands.Add(key_, command_);
        }

        //Execute the command without parameters
        public OutType Execute<OutType>(string key_)
        {
            if (CanExecute(key_))
            {
                ModuleCommand<OutType> _cmd = (ModuleCommand<OutType>)_commands[key_];
                return _cmd.Execute();
            }
            else
                return default(OutType);
        }

        //Execute the command with parameters
        public OutType Execute<InType, OutType>(string key_, InType params_)
        {
            if (CanExecute(key_))
            {
                ModuleCommand<InType, OutType> _cmd = (ModuleCommand<InType, OutType>)_commands[key_];
                return _cmd.Execute(params_);
            }
            else
                return default(OutType);
        }

        //Verify if the command is registered
        public bool CanExecute(string key_)
        {
            return _commands.ContainsKey(key_);
        }






    }
}
