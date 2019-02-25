using System;
using System.Data;
using System.ComponentModel.Composition;
using ModularWinApp.Core.Interfaces;

namespace ModularWinApp.Core
{
    public class SqlDataModule : IDataModule, IDisposable
    {
        // Singleton Connection. Must be only one
        private static IDbConnection _sharedConnection;
        // Singleton Transaction. Must be only one
        private static IDbTransaction _sharedTransaction;

        /// <summary>
        /// Begin a transaction on shared connection
        /// </summary>
        public void BeginTransaction()
        {
            if (_sharedTransaction == null)
                _sharedTransaction = _sharedConnection.BeginTransaction();
        }

        /// <summary>
        /// Close the shared connection
        /// </summary>
        public void CloseSharedConnection()
        {
            if (_sharedConnection.State == ConnectionState.Open)
                _sharedConnection.Close();
        }

        /// <summary>
        /// Commit a transaction on shared connection
        /// </summary>
        public void CommitTransaction()
        {
            if (_sharedTransaction != null)
                _sharedTransaction.Commit();

            _sharedTransaction = null;
        }

        /// <summary>
        /// Create the connection that will be shared across the modules
        /// </summary>
        public void CreateSharedConnection(string connectionString_)
        {
            //If the connection instance is not created, create the instance
            if (_sharedConnection == null)
            {
                _sharedConnection = new System.Data.SqlClient.SqlConnection(connectionString_);
            }
            else
            {
                throw new Exception("The connection is already created!");
            }
        }

        /// <summary>
        /// Retun the shared connection
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetSharedConnection()
        {
            if (_sharedConnection != null)
                return _sharedConnection;
            else
                throw new Exception("The connection is not created!");
        }

        /// <summary>
        /// Retun the shared connection
        /// </summary>
        /// <returns></returns>
        public IDbTransaction GetSharedTransaction()
        {
            if (_sharedTransaction != null)
                return _sharedTransaction;
            else
                throw new Exception("The transaction is not created!");
        }

        /// <summary>
        /// Open the shared connection
        /// </summary>
        public void OpenSharedConnection()
        {
            if (_sharedConnection.State == ConnectionState.Closed)
                _sharedConnection.Open()
        }

        /// <summary>
        /// Rollback a transaction on shared connection
        /// </summary>
        public void RollbackTransaction()
        {
            if (_sharedTransaction != null)
                _sharedTransaction.Rollback();

            _sharedTransaction = null;
        }

        public void Dispose()
        {
            if (_sharedTransaction != null)
            {
                _sharedTransaction.Dispose();
                _sharedTransaction = null;
            }
            if (_sharedConnection != null)
            {
                _sharedConnection.Dispose();
                _sharedConnection = null;
            }
        }
    }
}