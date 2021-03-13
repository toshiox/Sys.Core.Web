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
        public List<Sys.Model.Database.Aplicativos.GrantType> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Aplicativos].[Pr_GRANTYPE_LIST]"));
        }

        public Sys.Model.Database.Aplicativos.GrantType ListById(Sys.Model.Database.Aplicativos.GrantType model)
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


        public Sys.Model.Database.Aplicativos.GrantType ListByName(Sys.Model.Database.Aplicativos.GrantType model)
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
        public Sys.Model.Database.Aplicativos.GrantType Insert(Sys.Model.Database.Aplicativos.GrantType model)
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

        public async Task<Sys.Model.Database.Aplicativos.GrantType> InsertAsync(Sys.Model.Database.Aplicativos.GrantType model)
        {
            return await Task.FromResult<Sys.Model.Database.Aplicativos.GrantType>(Insert(model));
        }
        #endregion

        #region mapper
        private List<Sys.Model.Database.Aplicativos.GrantType> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Aplicativos.GrantType> listClient = new List<Sys.Model.Database.Aplicativos.GrantType>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Aplicativos.GrantType()
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
