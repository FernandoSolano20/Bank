using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.ExchangeRate;
using EntitiesPOJO;
using Exeptions;

namespace BankCoreAPI
{
    public class ExchangeRateManager : BaseManager
    {
        private ExchangeRateCrudFactory exchangeRateCrud;
        private string defaultValue = ConfigurationManager.AppSettings["DEFAULT_VALUE"];

        public ExchangeRateManager()
        {
            exchangeRateCrud = new ExchangeRateCrudFactory();
        }

        public void Create(ExchangeRateType exchangeRate)
        {
            try
            {
                var entity = exchangeRateCrud.Retrieve<ExchangeRateType>(exchangeRate);
                if (entity != null)
                {
                    throw  new BussinessException(1);
                }

                var holidayManger = new HolidayManager();
                var holiday = new Holiday()
                {
                    Day = exchangeRate.Day.Day,
                    Month = exchangeRate.Day.Month
                };

                var isHoliday = holidayManger.RetrieveById(holiday) == null;
                if (!isHoliday)
                {
                    throw new BussinessException(3);
                }

                exchangeRateCrud.Create(exchangeRate);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            
        }

        public List<ExchangeRateType> RetrieveAll()
        {
            return exchangeRateCrud.RetrieveAll<ExchangeRateType>();
        }

        public ExchangeRateType RetrieveById(ExchangeRateType exchangeRate, double value = 0)
        {
            ExchangeRateType e = null;
            try
            {
                var dolarValidation = new ExchangeRateType()
                {
                    Day = DateTime.Now.Date,
                    OriginCountry = exchangeRate.OriginCountry,
                    DestinationCountry = new Country() {Value = Base64Encode("🇺🇸")},
                };

                dolarValidation = exchangeRateCrud.Retrieve<ExchangeRateType>(dolarValidation);
                var dolarValue = dolarValidation != null ? dolarValidation.Value : Double.Parse(defaultValue);
                if (value / dolarValue > 10000)
                {
                    throw new BussinessException(4);
                }

                var holidayManger = new HolidayManager();
                var holiday = new Holiday()
                {
                    Day = exchangeRate.Day.Day,
                    Month = exchangeRate.Day.Month
                };

                var isHoliday = holidayManger.RetrieveById(holiday) == null;
                if (!isHoliday)
                {
                    throw new BussinessException(3);
                }

                e = exchangeRateCrud.Retrieve<ExchangeRateType>(exchangeRate);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return e;
        }

        public void Update(ExchangeRateType exchangeRate)
        {
            exchangeRateCrud.Update(exchangeRate);
        }

        public void Delete(ExchangeRateType exchangeRate)
        {
            exchangeRateCrud.Delete(exchangeRate);
        }
        public List<ExchangeRateType> RetrieveAllDestiantionCountry(ExchangeRateType exchangeRate)
        {
            return exchangeRateCrud.GetDestCountryByOrigin<ExchangeRateType>(exchangeRate);
        }
        public List<ExchangeRateType> RetrieveAllDatesOfCountries(ExchangeRateType exchangeRate)
        {
            return exchangeRateCrud.GetDatesByCountries<ExchangeRateType>(exchangeRate);
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
