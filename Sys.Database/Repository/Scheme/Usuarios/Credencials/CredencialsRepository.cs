using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Usuarios.Credencials
{
    public class CredencialsRepository : Configuration, ICredencialsRepository
    {
        public CredencialsRepository()
        {
        }


        #region List
        public List<Sys.Model.Database.Usuarios.Credencials> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_LIST]"));
        }

        public Sys.Model.Database.Usuarios.Credencials ListByUserId(Sys.Model.Database.Usuarios.Credencials model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.UserId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Sys.Model.Database.Usuarios.Credencials ListByLogin(Sys.Model.Database.Usuarios.Credencials model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@LOGIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Login
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region Insert
        public Sys.Model.Database.Usuarios.Credencials Insert(Sys.Model.Database.Usuarios.Credencials model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.UserId
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@LOGIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Login
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@PASSW", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.PassWord
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Update
        public Sys.Model.Database.Usuarios.Credencials Update(Sys.Model.Database.Usuarios.Credencials model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.UserId
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@LOGIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Login
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@PASSW", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.PassWord
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_UPDATE]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Delete
        public Sys.Model.Database.Usuarios.Credencials Delete(Sys.Model.Database.Usuarios.Credencials model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UserId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_CRED_DELETE]", listOfParameters)).LastOrDefault();
        }

        #endregion

        #region Mapper
        public List<Sys.Model.Database.Usuarios.Credencials> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Usuarios.Credencials> listCREDesa = new List<Sys.Model.Database.Usuarios.Credencials>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Usuarios.Credencials()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    UserId = sqlDataReader.GetInt32(1),
                    Login = sqlDataReader.GetString(2),
                    PassWord = sqlDataReader.GetString(3)
                };

                if (!sqlDataReader.IsDBNull(4))
                    item.DataRegister = sqlDataReader.GetDateTime(4);

                listCREDesa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listCREDesa;
        }
        #endregion
    }
}