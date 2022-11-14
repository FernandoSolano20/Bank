using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using EntitiesPOJO;

namespace DataAccess.Crud.ExchangeRate
{
    public class ExchangeRateCrudFactory : CrudFactory
    {
        ExchangeRateMapper mapper;

        public ExchangeRateCrudFactory() : base()
        {
            mapper = new ExchangeRateMapper();
            dao = SqlDao.GetInstance();
        }

        public override BaseEntity Create(BaseEntity entity)
        {
            var exchangeRate = (ExchangeRateType)entity;
            var sqlOperation = mapper.GetCreateStatement(exchangeRate);
            dao.ExecuteProcedure(sqlOperation);
            return exchangeRate;
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public override BaseEntity Update(BaseEntity entity)
        {
            var exchangeRate = (ExchangeRateType)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(exchangeRate));
            return exchangeRate;
        }

        public override BaseEntity Delete(BaseEntity entity)
        {
            var exchangeRate = (ExchangeRateType)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(exchangeRate));
            return exchangeRate;
        }

        public List<T> GetDestCountryByOrigin<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveDestCountryStatementByOrigin(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public List<T> GetDatesByCountries<T>(BaseEntity entity)
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveDatesStatementByCountries(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }
    }
}
