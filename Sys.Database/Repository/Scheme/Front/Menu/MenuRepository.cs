using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Sys.Database.Repository.Scheme.Front.Menu
{
    public class MenuRepository : Configuration, IMenuRepository
    {
        public MenuRepository()
        {
        }

        #region List
        public List<Sys.Model.Database.Front.Menu> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Front].[Pr_MENU_LIST]"));
        }

        public Sys.Model.Database.Front.Menu ListById(Sys.Model.Database.Front.Menu model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_MENU", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Front].[Pr_MENU_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }

        public Sys.Model.Database.Front.Menu ListByName(Sys.Model.Database.Front.Menu model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@DS_NAME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_MENU_LIST002]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Insert
        public Sys.Model.Database.Front.Menu Insert(Sys.Model.Database.Front.Menu model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@DS_NAME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DS_ICON", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Icon
            };
            listOfParameters.Add(parameter);
            
            parameter = new System.Data.SqlClient.SqlParameter("@DT_CAD", SqlDbType.DateTime)
            {
                Direction = ParameterDirection.Input,
                Value = model.DataRegister
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_MENU_INSERT]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Update
        public void Update(Sys.Model.Database.Front.Menu model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_MENU", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DS_NAME", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Name
            };
            listOfParameters.Add(parameter);

            parameter = new System.Data.SqlClient.SqlParameter("@DS_ICON", SqlDbType.VarChar)
            {
                Direction = ParameterDirection.Input,
                Value = model.Icon
            };
            listOfParameters.Add(parameter);

            ExecuteQuery("[Negocios].[Pr_MENU_UPDATE]", listOfParameters);
        }
        #endregion

        #region Delete
        public Sys.Model.Database.Front.Menu Delete(Sys.Model.Database.Front.Menu model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_MENU", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Negocios].[Pr_MENU_DELETE]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Front.Menu> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Front.Menu> list = new List<Sys.Model.Database.Front.Menu>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Front.Menu()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    GroupId = sqlDataReader.GetInt32(1),
                    Name = sqlDataReader.GetString(2),
                    Icon = sqlDataReader.GetString(3),
                    Route = sqlDataReader.GetString(4)
                };

                if (!sqlDataReader.IsDBNull(5))
                    item.DataRegister = sqlDataReader.GetDateTime(5);

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