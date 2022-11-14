using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.Country;
using EntitiesPOJO;
using Exeptions;

namespace BankCoreAPI
{
    public class CountryManager : BaseManager
    {
        private CountryCrudFactory crudFactory;

        public CountryManager()
        {
            crudFactory = new CountryCrudFactory();
        }

        public void Create(Country exchangeRate)
        {
            try
            {
                var entity = crudFactory.Retrieve<Country>(exchangeRate);
                if (entity != null)
                {
                    throw new BussinessException(2);
                }
                else
                {
                    crudFactory.Create(exchangeRate);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

        }

        public List<Country> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Country>();
        }

        public Country RetrieveById(Country exchangeRate)
        {
            return crudFactory.Retrieve<Country>(exchangeRate);
        }

        public void Update(Country exchangeRate)
        {
            crudFactory.Update(exchangeRate);
        }

        public void Delete(Country exchangeRate)
        {
            crudFactory.Delete(exchangeRate);
        }
    }
}
