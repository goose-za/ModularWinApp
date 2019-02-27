using ModularWinApp.Core.Interfaces;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularWinApp.Core
{
    /// <summary>
    /// <para>
    /// The ModuleHandler class is the main class of the core. 
    /// It is responsible for loading modules, exposing the list 
    /// of loaded modules, exposing the list of loaded menus, 
    /// and exposing the host to the modules. 
    /// </para>
    /// <para>
    /// This class also provides methods to check and retrieve 
    /// the instance of each loaded module.
    /// </para>
    /// </summary>
    [Export(typeof(IModuleHandler))]
    public class ModuleHandler : IDisposable, IModuleHandler
    {
        private static IDataModule _dataModule;
        
        /// <summary>
        /// The ImportMany attribute allow us to import the classes that implement 
        /// the same interface. The ModuleList will be filled with the imported modules
        /// </summary>
        [ImportMany(typeof(IModule), AllowRecomposition = true)]
        public List<Lazy<IModule, IModuleAttribute>> ModuleList { get; set; }

        /// <summary>
        /// The MenuList will be filled with the imported Menus
        /// </summary>
        [ImportMany(typeof(IMenu), AllowRecomposition = true)]
        public List<Lazy<IMenu, IModuleAttribute>> MenuList { get; set; }

        /// <summary>
        /// The imported host form
        /// </summary>
        [Import(typeof(IHost))]
        public IHost Host { get; set; }

        /// <summary>
        /// The DataModule exposes the database module.
        /// </summary>
        public IDataModule DataModule
        {
            get
            {
                if (_dataModule == null)
                    _dataModule = new SqlDataModule();
                return _dataModule;
            }
        }

        AggregateCatalog catalog = new AggregateCatalog();

        /// <summary>
        /// Initialize the modules that are found by MEF
        /// </summary>
        public void InitializeModules()
        {
            // Create a new instance of ModuleList
            ModuleList = new List<Lazy<IModule, IModuleAttribute>>();

            // Create a new instance of MenuList
            MenuList = new List<Lazy<IMenu, IModuleAttribute>>();

            // Foreach path in the main app App.Config
            foreach (var s in ConfigurationManager.AppSettings.AllKeys)
            {
                if (s.StartsWith("Path"))
                {
                    // Create a new DirectoryCatalog with the path loaded from the App.Config
                    catalog.Catalogs.Add(new DirectoryCatalog(ConfigurationManager.AppSettings[s], "*.dll"));
                }
            };

            // Create a new catalog from the main app, to get the Host
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetCallingAssembly()));

            // Create a new catalog from the ModularWinApp.Core
            catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*.dll"));

            // Create the CompositionContainer
            CompositionContainer cc = new CompositionContainer(catalog);

            // Do the MEF Magic
            cc.ComposeParts(this);
        }

        /// <summary>
        /// Verify if some module is imported
        /// </summary>
        /// <param name="moduleName_">The name of the module that we are trying to verify.</param>
        /// <returns>True or False, depending on whether the module was found</returns>
        public bool ContainsModule(string moduleName_)
        {
            bool ret = false;

            foreach (var l in ModuleList)
            {
                if (l.Metadata.ModuleName == moduleName_)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// Return a module instance based on it's name
        /// </summary>
        /// <param name="moduleName_">Nae of module to look for</param>
        /// <returns>A module instance</returns>
        public IModule GetModuleInstance(string moduleName_)
        {
            IModule instance = null;

            foreach (var l in ModuleList)
            {
                if (l.Metadata.ModuleName == moduleName_)
                {
                    instance = l.Value;
                    break;
                }
            }
            return instance;
        }

        /// <summary>
        /// Disposes of the ModuleHandler
        /// </summary>
        public void Dispose()
        {
            _dataModule = null;
            catalog.Dispose();
            catalog = null;
            ModuleList.Clear();
            ModuleList = null;
        }
    }
}
