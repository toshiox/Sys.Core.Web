using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Usuarios.Acesso
{
    public class AcessRepository : Configuration, IAcessRepository
    {
        public AcessRepository()
        {
        }
        #region List
        public List<Sys.Model.Database.Usuarios.Acesso> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_ACESS_LIST]"));
        }

        public List<Sys.Model.Database.Usuarios.Acesso> ListByUser(Sys.Model.Database.Usuarios.Acesso model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.UserId
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_ACESS_LIST001]", listOfParameters))?.ToList();
        }
        #endregion

        #region Insert
        public Sys.Model.Database.Usuarios.Acesso Insert(Sys.Model.Database.Usuarios.Acesso model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@FK_USR", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@FK_MENU", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);
            
            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Usuarios].[Pr_ACESS_INSERT]", listOfParameters))?.ToList().FirstOrDefault();
        }

        #endregion

        #region Mapper
        public List<Sys.Model.Database.Usuarios.Acesso> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Usuarios.Acesso> list = new List<Sys.Model.Database.Usuarios.Acesso>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Usuarios.Acesso()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    UserId = sqlDataReader.GetInt32(1),
                    MenuId = sqlDataReader.GetInt32(2)
                };

                if (!sqlDataReader.IsDBNull(3))
                    item.DataRegister = sqlDataReader.GetDateTime(3);

                list.Add(item);
            }

            if (sqlDataReader.IsClosed == false)
                sqlDataReader?.Close();

            sqlDataReader?.Dispose();

            return list;
        }
        #endregion
    }
}
