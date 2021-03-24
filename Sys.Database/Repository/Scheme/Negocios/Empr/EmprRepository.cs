using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Negocios.Empr
{
    public class EmprRepository : Configuration, IEmprRepository
    {
        public EmprRepository()
        {

        }

        #region List
        public List<Sys.Model.Database.Negocios.Empresa> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_EMPR_LIST]"));
        }

        public Sys.Model.Database.Negocios.Empresa ListById(Sys.Model.Database.Negocios.Empresa model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_EMPR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_EMPR_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Sys.Model.Database.Negocios.Empresa ListByCnpj(Sys.Model.Database.Negocios.Empresa model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@CNPJ", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CNPJ
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_EMPR_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region insert
        public Sys.Model.Database.Negocios.Empresa Insert(Sys.Model.Database.Negocios.Empresa model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@NOME_FATS", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.FantasyName
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@RAZ_SOC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CompanyName
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CNPJ", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CNPJ
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CCM", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CCM
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@OCUP_PRIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.MainOccupation
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@ATIV_PRIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.MainActivity
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_LOG", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.PublicPlace
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_NUM", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.HouseNumber
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_BAR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.County
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_MUN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.District
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_UF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.State
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_CEP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CEP
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_EMPR_INSERT]", listOfParameters)).LastOrDefault();
        }
        #endregion

        #region Update
        public void Update(Sys.Model.Database.Negocios.Empresa model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@NOME_FATS", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.FantasyName
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@RAZ_SOC", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CompanyName
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CNPJ", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CNPJ
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@CCM", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CCM
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@OCUP_PRIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.MainOccupation
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@ATIV_PRIN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.MainActivity
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_LOG", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.PublicPlace
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_NUM", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.HouseNumber
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_BAR", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.County
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_MUN", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.District
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_UF", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.State
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@END_CEP", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.CEP
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            ExecuteQuery("[Negocios].[Pr_EMPR_UPDATE]", listOfParameters);
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Negocios.Empresa> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Negocios.Empresa> listEmpresa = new List<Sys.Model.Database.Negocios.Empresa>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Negocios.Empresa()
                {
                    id = sqlDataReader.GetDecimal(0),
                    FantasyName = sqlDataReader.GetString(1),
                    CompanyName = sqlDataReader.GetString(2),
                    CNPJ = sqlDataReader.GetString(3),
                    CCM = sqlDataReader.GetString(4),
                    MainOccupation = sqlDataReader.GetString(5),
                    MainActivity = sqlDataReader.GetString(6),

                    PublicPlace = sqlDataReader.GetString(7),
                    HouseNumber = sqlDataReader.GetString(8),
                    County = sqlDataReader.GetString(9),
                    District = sqlDataReader.GetString(10),
                    State = sqlDataReader.GetString(11),
                    CEP = sqlDataReader.GetString(12)
                };

                if (!sqlDataReader.IsDBNull(13))
                    item.DataRegister = sqlDataReader.GetDateTime(13);

                listEmpresa.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return listEmpresa;
        }

        #endregion
    }


}
