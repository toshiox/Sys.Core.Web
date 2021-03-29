using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Negocios.Finac
{
    public class FinacRepository : Configuration, IFinacRepository
    {
        public FinacRepository()
        {

        }

        #region List
        public List<Sys.Model.Database.Negocios.Finac> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_FINAC_LIST]"));
        }

        public Sys.Model.Database.Negocios.Finac ListById(Sys.Model.Database.Negocios.Finac model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_FINAC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_FINAC_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Sys.Model.Database.Negocios.Finac ListByCompany(Sys.Model.Database.Negocios.Finac model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_EMPR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdCompany
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_FINAC_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Sys.Model.Database.Negocios.Finac Insert(Sys.Model.Database.Negocios.Finac model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_EMPR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdCompany
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@FK_TYPFLX", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdFlowType
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DESC_VLR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Description
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@VLR", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.Value
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@MES_REF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.MonthReference
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_FINAC_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Delete
        public void Delete(Sys.Model.Database.Negocios.Finac model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_FINAC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            ExecuteQuery("[Negocios].[Pr_FINAC_DELETE]", listOfParameters);
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Negocios.Finac> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Negocios.Finac> listFINACesa = new List<Sys.Model.Database.Negocios.Finac>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Negocios.Finac()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    IdCompany = sqlDataReader.GetInt32(1),
                    IdFlowType = sqlDataReader.GetInt32(2),
                    Description = sqlDataReader.GetString(3),
                    Value = sqlDataReader.GetDouble(4),
                    MonthReference = sqlDataReader.GetString(5)
                };

                if (!sqlDataReader.IsDBNull(6))
                    item.DataRegister = sqlDataReader.GetDateTime(6);

                listFINACesa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listFINACesa;
        }
        #endregion
    }
}
