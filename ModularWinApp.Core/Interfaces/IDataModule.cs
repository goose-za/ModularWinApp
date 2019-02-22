using System.Data;

namespace ModularWinApp.Core.Interfaces
{
    public interface IDataModule
    {
        void CreateSharedConnection();
        IDbConnection GetSharedConnection();
        void OpenSharedConnection();
        void CloseSharedConnection();

        IDbTransaction GetSharedTransaction();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
