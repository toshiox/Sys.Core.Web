using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Negocios.TypFlx
{
    public class TypFlxRepository : Configuration, ITypFlxRepository
    {
        public TypFlxRepository()
        {
        }

        #region List
        public List<Sys.Model.Database.Negocios.TypFlx> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TYPFLX_LIST]"));
        }

        public Sys.Model.Database.Negocios.TypFlx ListById(Sys.Model.Database.Negocios.TypFlx model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_TYPFLX", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TYPFLX_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }


        public Sys.Model.Database.Negocios.TypFlx ListByName(Sys.Model.Database.Negocios.TypFlx model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@TYPFLX", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.TypeFlow
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TYPFLX_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region Insert
        public Sys.Model.Database.Negocios.TypFlx Insert(Sys.Model.Database.Negocios.TypFlx model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@TYPFLX", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.TypeFlow
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_TYPFLX_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Negocios.TypFlx> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Negocios.TypFlx> listTYPFLXesa = new List<Sys.Model.Database.Negocios.TypFlx>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Negocios.TypFlx()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    TypeFlow = sqlDataReader.GetString(1)
                };

                if (!sqlDataReader.IsDBNull(2))
                    item.DataRegister = sqlDataReader.GetDateTime(2);

                listTYPFLXesa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listTYPFLXesa;
        }
        #endregion
    }
}
