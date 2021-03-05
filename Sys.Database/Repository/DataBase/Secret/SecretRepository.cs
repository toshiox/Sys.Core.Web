using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.DataBase.Secret
{
    public class SecretRepository : Configuration, ISecretRepository
    {
        public SecretRepository()
        {
        }


        #region List
        public List<Model.DataBase.Secret> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCRT_LIST]"));
        }

        public Model.DataBase.Secret ListById(Model.DataBase.Secret model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQ_KEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.FK_UniqueKeyApp
            };

            listOfParameters.Add(parameter);
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCRT_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region insert
        public Model.DataBase.Secret Insert(Model.DataBase.Secret model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQ_KEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.FK_UniqueKeyApp
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@SCRT", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.SecretValue
            };
            listOfParameters.Add(parameter);


            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            ExecuteQuery("[Aplicativos].[Pr_SCRT_INSERT]", listOfParameters);

            return model;
        }
        #endregion

        #region Mapper
        public List<Model.DataBase.Secret> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.Secret> listSecret = new List<Model.DataBase.Secret>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.Secret()
                {
                    id = sqlDataReader.GetDecimal(0),
                    FK_UniqueKeyApp = sqlDataReader.GetString(1),
                    SecretValue = sqlDataReader.GetString(2),
                };

                if (sqlDataReader.IsDBNull(3))
                    item.DataRegister = sqlDataReader.GetDateTime(3);

                listSecret.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listSecret;
        }
        #endregion
    }
}
