using System;
using System.Collections.Generic;

namespace ModularWinApp.Core.Interfaces
{
    public interface IModuleHandler
    {
        List<Lazy<IModule, IModuleAttribute>> ModuleList { get; set; }
        IHost Host { get; set; }
        void InitializeModules();
        IModule GetModuleInstance(string moduleName_);
        IDataModule DataModule { get; }
    }
}
