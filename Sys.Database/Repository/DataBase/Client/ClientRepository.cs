﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Client
{
    public class ClientRepository : Configuration, IClientRepository
    {
        public ClientRepository()
        {
        }

        #region List
        public List<Model.DataBase.Client> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLIT_LIST]"));
        }

        public Model.DataBase.Client ListById(Model.DataBase.Client model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLIT_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        
        public Model.DataBase.Client ListByUniqueKey(Model.DataBase.Client model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQ_KEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UniqueKey
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLIT_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }


        #endregion

        #region Insert
        public Model.DataBase.Client Insert(Model.DataBase.Client model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@UNIQ_KEY", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.UniqueKey
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@NOME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DESC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Descrition
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@ATV", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Input,
                Value = model.Active
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DateRegister
            };

            listOfParameters.Add(parameter);

            ExecuteQuery("[Aplicativos].[Pr_CLIT_INSERT]", listOfParameters);

            model.UniqueKey = listOfParameters.Find(p => p.ParameterName.Equals("@UNIQ_KEY")).Value as string;

            return model;
        }

        public async Task<Model.DataBase.Client> InsertAsync(Model.DataBase.Client model)
        {
            return await Task.FromResult<Model.DataBase.Client>(Insert(model));
        }
        #endregion

        #region Mapper
        public List<Model.DataBase.Client> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.Client> listClient = new List<Model.DataBase.Client>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.Client()
                {
                    Id = Convert.ToInt32(sqlDataReader.GetDecimal(0)),
                    UniqueKey = sqlDataReader.GetString(1),
                    Name = sqlDataReader.GetString(2),
                    Descrition = sqlDataReader.GetString(3),
                    Active = sqlDataReader.GetBoolean(4)
                };

                if (!sqlDataReader.IsDBNull(5))
                    item.DateRegister = sqlDataReader.GetDateTime(5);

                if (!sqlDataReader.IsDBNull(6))
                    item.DateExclusion = sqlDataReader.GetDateTime(6);

                listClient.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listClient;
        }

        #endregion
    }
}
