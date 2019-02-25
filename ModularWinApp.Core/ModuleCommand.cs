using ModularWinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularWinApp.Core
{
    /// <summary>
    /// A module command concrete class with parameter and output type
    /// </summary>
    public class ModuleCommand<InType, OutType> : ICommand
    {
        // This delegate will point to a function
        private Func<InType, OutType> _paramAction;

        // Constructor receiving the delegate as a parameter
        public ModuleCommand(Func<InType, OutType> paramAction_)
        {
            _paramAction = paramAction_;
        }

        // Execute the delegate
        public OutType Execute(InType param_)
        {
            if (_paramAction != null)
            {
                return _paramAction.Invoke(param_);
            }
            else
            {
                return default(OutType);
            }
        }
    }

    /// <summary>
    /// Module command concrete class with only output type
    /// </summary>
    /// <typeparam name="OutType"></typeparam>
    public class ModuleCommand<OutType> : ICommand
    {
        // This delegate will point to a function
        private Func<OutType> _action;

        //Constructor receiving the delegate as parameter
        public ModuleCommand(Func<OutType> action_)
        {
            _action = action_;
        }

        //Execute the delegate
        public OutType Execute()
        {
            if (_action != null)
                return _action.Invoke();
            else
                return default(OutType);
        }
    }
}
