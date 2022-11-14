using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using EntitiesPOJO;

namespace DataAccess.Mapper.Holiday
{
    class HolidayMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_DAY = "DAY";
        private const string DB_COL_MONTH = "MONTH";
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
            var entity = new EntitiesPOJO.Holiday
            {
                ID = GetIntValue(row, DB_COL_ID),
                Day = GetIntValue(row, DB_COL_DAY),
                Month = GetIntValue(row, DB_COL_MONTH)
            };

            return entity;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_HOLIDAY_PR" };

            var c = (EntitiesPOJO.Holiday)entity;
            operation.AddIntParam(DB_COL_DAY, c.Day);
            operation.AddIntParam(DB_COL_MONTH, c.Month);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_HOLIDAY_PR" };

            var c = (EntitiesPOJO.Holiday)entity;
            operation.AddIntParam(DB_COL_DAY, c.Day);
            operation.AddIntParam(DB_COL_MONTH, c.Month);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_HOLIDAY_PR" };
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_HOLIDAY_PR" };

            var c = (EntitiesPOJO.Holiday)entity;
            operation.AddIntParam(DB_COL_ID,c.ID);
            operation.AddIntParam(DB_COL_DAY, c.Day);
            operation.AddIntParam(DB_COL_MONTH, c.Month);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_HOLIDAY_PR" };

            var c = (EntitiesPOJO.Holiday)entity;
            operation.AddIntParam(DB_COL_ID, c.ID);

            return operation;
        }
    }
}
