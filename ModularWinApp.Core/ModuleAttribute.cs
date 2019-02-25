using ModularWinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularWinApp.Core
{
    /// <summary>
    /// <para>
    /// The custom attributes are used to help us provide metadata to our modules, 
    /// so after MEF loads them, we can identify our modules.
    /// </para>
    /// <para>
    /// Metadata is optional in MEF.Using metadata requires that the exporter defines 
    /// which metadata is available for importers to look at and the importer who is 
    /// able to access the metadata at the time of import.
    /// </para>
    /// <para>
    /// In our case, we want our modules to provide us a type of the module, as a 
    /// Clients Module, a Products Module, or on Orders Module.
    /// </para>
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleAttribute : ExportAttribute, IModuleAttribute
    {
        public string ModuleName { get; private set; }

        public ModuleAttribute(string moduleName_)
            : base(typeof(IModule))
        {
            ModuleName = moduleName_;
        }
    }
}
