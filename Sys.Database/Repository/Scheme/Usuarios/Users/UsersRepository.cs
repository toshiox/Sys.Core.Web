using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Usuarios.Users
{
    public class UsersRepository : Configuration, IUsersRepository
    {
        public UsersRepository()
        {
        }

        #region List
        public List<Sys.Model.Database.Usuarios.User> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_LIST]"));
        }

        public Sys.Model.Database.Usuarios.User ListById(Sys.Model.Database.Usuarios.User model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Sys.Model.Database.Usuarios.User ListByCPF(Sys.Model.Database.Usuarios.User model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@CPF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CPF
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region Insert
        public Sys.Model.Database.Usuarios.User Insert(Sys.Model.Database.Usuarios.User model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQKEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UniqueKey
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CPF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CPF
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@GEN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Gen
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_NAS", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataBirth
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Update
        public Sys.Model.Database.Usuarios.User Update(Sys.Model.Database.Usuarios.User model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQKEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UniqueKey
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@NAME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CPF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CPF
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@GEN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Gen
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_NAS", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataBirth
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_UPDATE]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Delete
        public Sys.Model.Database.Usuarios.User Delete(Sys.Model.Database.Usuarios.User model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQKEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UniqueKey
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_USR_DELETE]", listOfParameters)).LastOrDefault();
        }

        #endregion

        #region Mapper
        public List<Sys.Model.Database.Usuarios.User> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Usuarios.User> listUSResa = new List<Sys.Model.Database.Usuarios.User>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Usuarios.User()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    UniqueKey = sqlDataReader.GetString(1),
                    Name = sqlDataReader.GetString(2),
                    CPF = sqlDataReader.GetString(3),
                    Gen = sqlDataReader.GetString(4)
                };

                if (!sqlDataReader.IsDBNull(5))
                    item.DataBirth = sqlDataReader.GetDateTime(5);

                if (!sqlDataReader.IsDBNull(6))
                    item.DataRegister = sqlDataReader.GetDateTime(6);

                listUSResa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listUSResa;
        }
        #endregion
    }
}
