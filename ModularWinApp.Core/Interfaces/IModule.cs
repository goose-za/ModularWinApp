namespace ModularWinApp.Core.Interfaces
{
    public interface IModule
    {
        string Name { get; }
        ICommandDispatcher Commands { get; }
        IModuleHandler ModuleHandler { get; }
    }
}
