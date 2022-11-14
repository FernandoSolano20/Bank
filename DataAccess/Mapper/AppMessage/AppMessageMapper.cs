using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using EntitiesPOJO;

namespace DataAccess.Mapper.AppMessage
{
    class AppMessageMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MESSAGE = "MESSAGE";
        //dcordoba@coffebitcr.com

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var entity = BuildObject(row);
                lstResults.Add(entity);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var entity = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_COL_ID),
                Message = GetStringValue(row, DB_COL_MESSAGE)
            };

            return entity;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MESSAGE_PR" };

            var c = (ApplicationMessage)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_MESSAGE, c.Message);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MESSAGE_PR" };

            var c = (ApplicationMessage)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MESSAGE_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MESSAGE_PR" };

            var c = (ApplicationMessage)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_MESSAGE, c.Message);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MESSAGE_PR" };

            var c = (ApplicationMessage)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }
    }
}
