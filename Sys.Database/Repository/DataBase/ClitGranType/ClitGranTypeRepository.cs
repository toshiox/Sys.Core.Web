using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.DataBase.ClitGranType
{
    public class ClitGranTypeRepository : Configuration, IClitGranTypeRepository
    {
        public ClitGranTypeRepository()
        {
        }

        #region Lists
        public List<Model.DataBase.ClitGrantType> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITGRANTYPE_LIST]"));
        }

        public Model.DataBase.ClitGrantType ListById(Model.DataBase.ClitGrantType model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_APP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ClientId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITGRANTYPE_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Model.DataBase.ClitGrantType Insert(Model.DataBase.ClitGrantType model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new SqlParameter("@FK_APP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.ClientId
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@FK_GRANTYPE", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.GrantTypeId
            };
            listOfParameters.Add(parameter);

            parameter = new SqlParameter("@DataRegister", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITGRANTYPE_INSERT]", listOfParameters)).LastOrDefault();
        }

        public async Task<Model.DataBase.ClitGrantType> InsertAsync(Model.DataBase.ClitGrantType model)
        {
            return await Task.FromResult<Model.DataBase.ClitGrantType>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Model.DataBase.ClitGrantType> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Model.DataBase.ClitGrantType> listClient = new List<Model.DataBase.ClitGrantType>();

            while (sqlDataReader.Read())
            {
                var item = new Model.DataBase.ClitGrantType()
                {
                    Id = Convert.ToInt32(sqlDataReader.GetDecimal(0)),
                    ClientId = sqlDataReader.GetString(1),
                    GrantTypeId = sqlDataReader.GetInt32(2),
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
