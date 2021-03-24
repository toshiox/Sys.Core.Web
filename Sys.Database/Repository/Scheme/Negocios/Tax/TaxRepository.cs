using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Negocios.Tax
{
    public class TaxRepository : Configuration, ITaxRepository
    {
        public TaxRepository()
        {

        }
        #region List
        public List<Sys.Model.Database.Negocios.Tax> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TAX_LIST]"));
        }

        public Sys.Model.Database.Negocios.Tax ListByCompany(Sys.Model.Database.Negocios.Tax model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_EMPR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdCompany
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TAX_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Sys.Model.Database.Negocios.Tax Insert(Sys.Model.Database.Negocios.Tax model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@ISS", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.ISS
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@IRRF", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.IRRF
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@PIS", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.PIS
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@COFINS", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.COFINS
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CSLL", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.CSLL
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@INSS", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.INSS
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@ALIQSMP", SqlDbType.Float)
            {
                Direction = ParameterDirection.Input,
                Value = model.SimpleRate
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TAX_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Negocios.Tax> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Negocios.Tax> listTAXesa = new List<Sys.Model.Database.Negocios.Tax>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Negocios.Tax()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    IdCompany = sqlDataReader.GetInt32(1),
                    ISS = sqlDataReader.GetDouble(2),
                    IRRF = sqlDataReader.GetDouble(3),
                    PIS = sqlDataReader.GetDouble(4),
                    COFINS = sqlDataReader.GetDouble(5),
                    CSLL = sqlDataReader.GetDouble(6),
                    INSS = sqlDataReader.GetDouble(7),
                    SimpleRate = sqlDataReader.GetDouble(8)
                };

                if (!sqlDataReader.IsDBNull(9))
                    item.DataRegister = sqlDataReader.GetDateTime(9);

                listTAXesa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listTAXesa;
        }
        #endregion
    }
}
