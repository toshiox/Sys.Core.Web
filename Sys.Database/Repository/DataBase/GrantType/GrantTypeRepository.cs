using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.GrantType
{
    public class GrantTypeRepository : Configuration, IGrantTypeRepository
    {
        public GrantTypeRepository()
        {
        }


        #region List
        public List<Model.DataBase.GrantType> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_GRANTYPE_LIST]"));
        }

        public Model.DataBase.GrantType ListById(Model.DataBase.GrantType model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_GRANTYPE", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_GRANTYPE_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }


        public Model.DataBase.GrantType ListByName(Model.DataBase.GrantType model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@GRANTYPE", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Type
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_GRANTYPE_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Model.DataBase.GrantType Insert(Model.DataBase.GrantType model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new SqlParameter("@GRANTYPE", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Type
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@DataRegister", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_GRANTYPE_INSERT]", listOfParameters)).LastOrDefault();
        }

        public async Task<Model.DataBase.GrantType> InsertAsync(Model.DataBase.GrantType model)
        {
            return await Task.FromResult<Model.DataBase.GrantType>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Model.DataBase.GrantType> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.GrantType> listClient = new List<Model.DataBase.GrantType>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.GrantType()
                {
                    Id = Convert.ToInt32(sqlDataReader.GetDecimal(0)),
                    Type = sqlDataReader.GetString(1),
                };

                if (!sqlDataReader.IsDBNull(2))
                    item.DataRegister = sqlDataReader.GetDateTime(2);

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
