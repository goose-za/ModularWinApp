using System;
using System.Collections.Generic;

namespace ModularWinApp.Core.Interfaces
{
    public interface IModuleHandler
    {
        // Lazy<T> is a new type in the .NET 4 BCL that allows you to delay 
        // the creation of an instance. As MEF supports Lazy, you can import 
        // classes, but instantiate them later.
        List<Lazy<IModule, IModuleAttribute>> ModuleList { get; set; }
        IHost Host { get; set; }
        void InitializeModules();
        IModule GetModuleInstance(string moduleName_);
        IDataModule DataModule { get; }
    }
}
