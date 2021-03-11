using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.ClitScopes
{
    public class ClitScopesRepository : Configuration, IClitScopesRepository
    {
        public ClitScopesRepository()
        {

        }

        #region List
        public List<Model.DataBase.ClitScopes> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITSCOP_LIST]"));
        }

        public List<Model.DataBase.ClitScopes> ListById(Model.DataBase.ClitScopes model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_APP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ClientId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITSCOP_LIST001]", listOfParameters))?.ToList();
        }

        public List<Model.DataBase.ClitScopes> ListByScopeId(Model.DataBase.ClitScopes model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_APP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ClientId
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@SCOP_ID", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ScopeId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITSCOP_LIST002]", listOfParameters))?.ToList();
        }
        #endregion

        #region Insert
        public Model.DataBase.ClitScopes Insert(Model.DataBase.ClitScopes model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new SqlParameter("@FK_APP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ClientId
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@FK_SCOP", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.ScopeId
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@DataRegister", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITSCOPES_INSERT]", listOfParameters)).LastOrDefault();
        }

        public async Task<Model.DataBase.ClitScopes> InsertAsync(Model.DataBase.ClitScopes model)
        {
            return await Task.FromResult<Model.DataBase.ClitScopes>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Model.DataBase.ClitScopes> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.ClitScopes> listClient = new List<Model.DataBase.ClitScopes>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.ClitScopes()
                {
                    Id = Convert.ToInt32(sqlDataReader.GetDecimal(0)),
                    ClientId = sqlDataReader.GetString(1),
                    ScopeId = sqlDataReader.GetInt32(2)
                };

                if (!sqlDataReader.IsDBNull(2))
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
