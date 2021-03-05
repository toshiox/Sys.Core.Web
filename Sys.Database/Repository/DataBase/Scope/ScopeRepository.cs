using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.Scope
{
    public class ScopeRepository : Configuration, IScopeRepository
    {
        public ScopeRepository()
        {
        }


        #region List
        public List<Model.DataBase.Scope> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCOP_LIST]"));
        }

        public Model.DataBase.Scope ListById(Model.DataBase.Scope model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_SCOP", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCOP_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Model.DataBase.Scope ListByName(Model.DataBase.Scope model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@NOME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCOP_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Model.DataBase.Scope Insert(Model.DataBase.Scope model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new SqlParameter("@NOME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@DESC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Description
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };

            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCOP_INSERT]", listOfParameters)).LastOrDefault();
        }

        public async Task<Model.DataBase.Scope> InsertAsync(Model.DataBase.Scope model)
        {
            return await Task.FromResult<Model.DataBase.Scope>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Model.DataBase.Scope> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.Scope> listClient = new List<Model.DataBase.Scope>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.Scope()
                {
                    Id = Convert.ToInt32(sqlDataReader.GetDecimal(0)),
                    Name = sqlDataReader.GetString(1),
                    Description = sqlDataReader.GetString(2)
                };

                if (!sqlDataReader.IsDBNull(3))
                    item.DataRegister = sqlDataReader.GetDateTime(3);

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
