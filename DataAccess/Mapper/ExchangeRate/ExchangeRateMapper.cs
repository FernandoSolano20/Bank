using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using EntitiesPOJO;

namespace DataAccess.Mapper
{
    public class ExchangeRateMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_DATE = "DATERATE";
        private const string DB_COL_ORIGIN = "ORIGIN_COUNTRY";
        private const string DB_COL_DESTINATION = "DESTINATION_COUNTRY";
        private const string DB_COL_EXCHANGE_RATE = "EXCHANGERATE";
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
            var exchangeRate = new ExchangeRateType
            {
                Id = GetIntValue(row, DB_COL_ID),
                Day = GetDateValue(row, DB_COL_DATE),
                Value = GetDoubleValue(row, DB_COL_EXCHANGE_RATE),
                OriginCountry = new EntitiesPOJO.Country(true) { Value = GetStringValue(row,DB_COL_ORIGIN)},
                DestinationCountry = new EntitiesPOJO.Country(true) { Value = GetStringValue(row, DB_COL_DESTINATION) }
            };

            return exchangeRate;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_EXCHANGE_RATE_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddDateParam(DB_COL_DATE, c.Day);
            operation.AddDoubleParam(DB_COL_EXCHANGE_RATE, c.Value);
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            operation.AddVarcharParam(DB_COL_DESTINATION, c.DestinationCountry.Value);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_EXCHANGE_RATE_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddDateParam(DB_COL_DATE, c.Day);
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            operation.AddVarcharParam(DB_COL_DESTINATION, c.DestinationCountry.Value);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EXCHANGE_RATE_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_EXCHANGE_RATE_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddDateParam(DB_COL_DATE, c.Day);
            operation.AddDoubleParam(DB_COL_EXCHANGE_RATE, c.Value);
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            operation.AddVarcharParam(DB_COL_DESTINATION, c.DestinationCountry.Value);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_EXCHANGE_RATE_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddDateParam(DB_COL_DATE, c.Day);
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            operation.AddVarcharParam(DB_COL_DESTINATION, c.DestinationCountry.Value);
            return operation;
        }

        public SqlOperation GetRetriveDestCountryStatementByOrigin(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DESTINATIONCOUNTRY_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            return operation;
        }

        public SqlOperation GetRetriveDatesStatementByCountries(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DATES_PR" };

            var c = (ExchangeRateType)entity;
            operation.AddVarcharParam(DB_COL_ORIGIN, c.OriginCountry.Value);
            operation.AddVarcharParam(DB_COL_DESTINATION, c.DestinationCountry.Value);
            return operation;
        }
    }
}
