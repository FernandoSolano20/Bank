using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using DataAccess.Mapper.AppMessage;
using EntitiesPOJO;

namespace DataAccess.Crud.AppMessage
{
    public class AppMessagesCrudFactory : CrudFactory
    {
        AppMessageMapper mapper;

        public AppMessagesCrudFactory() : base()
        {
            mapper = new AppMessageMapper();
            dao = SqlDao.GetInstance();
        }

        public override BaseEntity Create(BaseEntity entity)
        {
            var message = (ApplicationMessage)entity;
            var sqlOperation = mapper.GetCreateStatement(message);
            dao.ExecuteProcedure(sqlOperation);
            return message;
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
            var message = (ApplicationMessage)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(message));
            return message;
        }

        public override BaseEntity Delete(BaseEntity entity)
        {
            var message = (ApplicationMessage)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(message));
            return message;
        }
    }
}
