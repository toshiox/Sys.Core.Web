using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Database.Repository.Scheme.Aplicativos.ClitGranType
{
    public class ClitGranTypeRepository : Configuration, IClitGranTypeRepository
    {
        public ClitGranTypeRepository()
        {
        }

        #region Lists
        public List<Sys.Model.Database.Aplicativos.ClitGrantType> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_CLITGRANTYPE_LIST]"));
        }

        public Sys.Model.Database.Aplicativos.ClitGrantType ListById(Sys.Model.Database.Aplicativos.ClitGrantType model)
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
        public Sys.Model.Database.Aplicativos.ClitGrantType Insert(Sys.Model.Database.Aplicativos.ClitGrantType model)
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

        public async Task<Sys.Model.Database.Aplicativos.ClitGrantType> InsertAsync(Sys.Model.Database.Aplicativos.ClitGrantType model)
        {
            return await Task.FromResult<Sys.Model.Database.Aplicativos.ClitGrantType>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Sys.Model.Database.Aplicativos.ClitGrantType> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Aplicativos.ClitGrantType> listClient = new List<Sys.Model.Database.Aplicativos.ClitGrantType>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Aplicativos.ClitGrantType()
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
