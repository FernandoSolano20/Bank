using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using EntitiesPOJO;

namespace DataAccess.Mapper.Country
{
    class CountryMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_NAME = "NAME";
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
            var entity = new EntitiesPOJO.Country(true)
            {
                Value= GetStringValue(row, DB_COL_NAME)
            };

            return entity;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_COUNTRY_PR" };

            var c = (EntitiesPOJO.Country)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Value);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COUNTRY_PR" };

            var c = (EntitiesPOJO.Country)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Value);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COUNTRY_PR" };
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_COUNTRY_PR" };

            var c = (EntitiesPOJO.Country)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Value);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_COUNTRY_PR" };

            var c = (EntitiesPOJO.Country)entity;
            operation.AddVarcharParam(DB_COL_NAME, c.Value);

            return operation;
        }
    }
}
