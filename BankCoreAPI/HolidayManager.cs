using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.Holiday;
using EntitiesPOJO;

namespace BankCoreAPI
{
    public class HolidayManager : BaseManager
    {
        private HolidayCrudFactory crudFactory;

        public HolidayManager()
        {
            crudFactory = new HolidayCrudFactory();
        }

        public List<Holiday> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Holiday>();
        }

        public Holiday RetrieveById(Holiday exchangeRate)
        {
            return crudFactory.Retrieve<Holiday>(exchangeRate);
        }

        public void Update(Holiday exchangeRate)
        {
            crudFactory.Update(exchangeRate);
        }

        public void Delete(Holiday exchangeRate)
        {
            crudFactory.Delete(exchangeRate);
        }
    }
}
