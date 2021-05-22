using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sys.Database.Repository.Scheme.Front.Group
{
    public class GroupRepository : Configuration, IGroupRepository
    {
        public GroupRepository()
        {
        }

        #region List
        public List<Sys.Model.Database.Front.Group> List()
        {
            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Front].[Pr_GRP_LIST]"));
        }

        public Sys.Model.Database.Front.Group ListById(Sys.Model.Database.Front.Group model)
        {
            List<IDbDataParameter> listOfParameters = new System.Collections.Generic.List<IDbDataParameter>();
            SqlParameter parameter = null;

            parameter = new System.Data.SqlClient.SqlParameter("@PK_GRP", SqlDbType.Int)
            {
                Direction = ParameterDirection.Input,
                Value = model.Id
            };
            listOfParameters.Add(parameter);

            return LoopDataReaderRows((SqlDataReader)ExecuteQuery("[Front].[Pr_GRP_LIST001]", listOfParameters))?.ToList().FirstOrDefault();
        }
        #endregion

        #region Mapper
        public List<Sys.Model.Database.Front.Group> LoopDataReaderRows(SqlDataReader sqlDataReader)
        {
            List<Sys.Model.Database.Front.Group> list = new List<Sys.Model.Database.Front.Group>();

            while (sqlDataReader.Read())
            {
                var item = new Sys.Model.Database.Front.Group()
                {
                    Id = sqlDataReader.GetDecimal(0),
                    Name = sqlDataReader.GetString(1),
                    Icon = sqlDataReader.GetString(2),
                    Route = sqlDataReader.GetString(3),
                };

                if (!sqlDataReader.IsDBNull(4))
                    item.DataRegister = sqlDataReader.GetDateTime(4);

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
