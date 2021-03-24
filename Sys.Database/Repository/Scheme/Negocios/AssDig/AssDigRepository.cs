using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Negocios.AssDig
{
    public class AssDigRepository : Configuration, IAssDigRepository
    {
        public AssDigRepository()
        {
        }
        #region List
        public List<Sys.Model.Database.Negocios.AssDig> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_ASSDIG_LIST]"));
        }

        public Sys.Model.Database.Negocios.AssDig ListByCompany(Sys.Model.Database.Negocios.AssDig model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_EMPR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdCompany
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_ASSDIG_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Sys.Model.Database.Negocios.AssDig Insert(Sys.Model.Database.Negocios.AssDig model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_EMPR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.IdCompany
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@ASSDIG", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.DigitalAssignature
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_ASSDIG_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Negocios.AssDig> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Negocios.AssDig> listASSDIGesa = new List<Sys.Model.Database.Negocios.AssDig>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Negocios.AssDig()
                {
                    Id = sqlDataReader.GetInt32(0),
                    IdCompany = sqlDataReader.GetInt32(1),
                    DigitalAssignature = sqlDataReader.GetString(2)
                };

                if (!sqlDataReader.IsDBNull(3))
                    item.DataRegister = sqlDataReader.GetDateTime(3);

                listASSDIGesa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listASSDIGesa;
        }
        #endregion

    }
}
