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
        public List<Sys.Model.Database.Aplicativos.Scope> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_SCOP_LIST]"));
        }

        public Sys.Model.Database.Aplicativos.Scope ListById(Sys.Model.Database.Aplicativos.Scope model)
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

        public Sys.Model.Database.Aplicativos.Scope ListByName(Sys.Model.Database.Aplicativos.Scope model)
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
        public Sys.Model.Database.Aplicativos.Scope Insert(Sys.Model.Database.Aplicativos.Scope model)
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

        public async Task<Sys.Model.Database.Aplicativos.Scope> InsertAsync(Sys.Model.Database.Aplicativos.Scope model)
        {
            return await Task.FromResult<Sys.Model.Database.Aplicativos.Scope>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Sys.Model.Database.Aplicativos.Scope> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Aplicativos.Scope> listClient = new List<Sys.Model.Database.Aplicativos.Scope>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Aplicativos.Scope()
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
