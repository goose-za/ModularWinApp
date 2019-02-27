using ModularWinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularWinApp.Modules.Clients
{
    public class ClientsService
    {
        IDataModule _dataModule;

        public ClientsService()
        {
            _dataModule = ClientsCommandFacade.ModuleHandler.DataModule;
        }

        public DataRow GetClient(int id_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlDataAdapter _da = new SqlDataAdapter("Select * from tb_Clients Where ID = " + id_.ToString(), _conn);
                DataSet _ds = new DataSet();

                _dataModule.OpenSharedConnection();

                _da.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    return _ds.Tables[0].Rows[0];
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public string GetClientName(int id_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlDataAdapter _da = new SqlDataAdapter("Select * from tb_Clients Where ID = " + id_.ToString(), _conn);
                DataSet _ds = new DataSet();

                _dataModule.OpenSharedConnection();

                _da.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {
                    return _ds.Tables[0].Rows[0]["Name"].ToString();
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public DataTable GetClientsDataTable()
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlDataAdapter _da = new SqlDataAdapter("Select * from tb_Clients ", _conn);
                DataSet _ds = new DataSet();

                _dataModule.OpenSharedConnection();

                _da.Fill(_ds);
                if (_ds.Tables.Count > 0)
                    return _ds.Tables[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        public int Insert(string name_, DateTime dateOfBirth_, string fone_)
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "INSERT INTO tb_Clients (ID, Name, DateOfBirth, Fone) VALUES (@ID, @Name, @DateOfBirth, @Fone)";

                int newID = NewID();

                SqlParameter _paramID = new SqlParameter("@ID", newID);
                SqlParameter _paramName = new SqlParameter("@Name", name_);
                SqlParameter _paramDateOfBirth = new SqlParameter("@DateOfBirth", dateOfBirth_);
                SqlParameter _paramFone = new SqlParameter("@Fone", fone_);
                _cmd.Parameters.AddRange(new SqlParameter[] { _paramID, _paramName, _paramDateOfBirth, _paramFone });
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                _cmd.ExecuteNonQuery();

                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }
        }

        private int NewID()
        {
            try
            {
                SqlConnection _conn = (SqlConnection)_dataModule.GetSharedConnection();
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "SELECT IsNull(MAX(ID), 0) + 1 FROM tb_Clients";
                _cmd.Connection = _conn;

                _dataModule.OpenSharedConnection();

                return (int)_cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _dataModule.CloseSharedConnection();
            }

        }
    }
}
