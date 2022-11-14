using EntitiesPOJO;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BankCoreAPI;
using BankService.Models;
using Exeptions;

namespace BankService.Controllers
{
    [EnableCors(origins: "https://localhost:44347", headers: "*", methods: "*")]
    public class ExchangeRateController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public async Task<IHttpActionResult> Get()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new ExchangeRateManager();
                apiResponse.Data = mng.RetrieveAll();
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Post(ExchangeRateType exchangeRate)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new ExchangeRateManager();
                        mng.Create(exchangeRate);

                    apiResponse = new ApiResponse();
                    apiResponse.Message = "Action was executed.";
                    return apiResponse;
                });
                return Content(HttpStatusCode.OK, response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                                                                         + bex.AppMessage.Message));
            }
        }

        public async Task<IHttpActionResult> Get(string dateRequest, string originCountry, string destCountry, double value)
        {
            try
            {
                var exchangeRate = new ExchangeRateType
                {
                    Day = DateTime.Parse(dateRequest),
                    OriginCountry = new Country() { Value = originCountry },
                    DestinationCountry = new Country() { Value = destCountry }
                };

                var response = await Task.Run(() =>
                {
                    var mng = new ExchangeRateManager();
                    exchangeRate = mng.RetrieveById(exchangeRate, value);
                    apiResponse = new ApiResponse();
                    apiResponse.Data = exchangeRate;
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                                                                         + bex.AppMessage.Message));
            }
        }

        public async Task<IHttpActionResult> Get(string dateRequest, string originCountry, string destCountry)
        {
            try
            {
                var exchangeRate = new ExchangeRateType
                {
                    Day = DateTime.Parse(dateRequest),
                    OriginCountry = new Country() { Value = originCountry },
                    DestinationCountry = new Country() { Value = destCountry }
                };

                var response = await Task.Run(() =>
                {
                    var mng = new ExchangeRateManager();
                    exchangeRate = mng.RetrieveById(exchangeRate);
                    apiResponse = new ApiResponse();
                    apiResponse.Data = exchangeRate;
                    return apiResponse;
                });
                return Ok(response);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                                                                         + bex.AppMessage.Message));
            }
        }

        public async Task<IHttpActionResult> Put(ExchangeRateType exchangeRate)
        {
            var response = await Task.Run(() =>
            {
                var mng = new ExchangeRateManager();
                mng.Update(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }

        public async Task<IHttpActionResult> Delete(string dateRequest, string originCountry, string destCountry)
        {
            var exchangeRate = new ExchangeRateType()
            {
                Day = DateTime.Parse(dateRequest),
                OriginCountry = new Country() { Value = originCountry },
                DestinationCountry = new Country() { Value = destCountry }
            };
            var response = await Task.Run(() =>
            {
                var mng = new ExchangeRateManager();
                mng.Delete(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }

        public async Task<IHttpActionResult> Delete(ExchangeRateType exchangeRate)
        {
            var response = await Task.Run(() =>
            {
                var mng = new ExchangeRateManager();
                mng.Delete(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }

        public async Task<IHttpActionResult> Get(string originCountry)
        {
            var exchangeRate = new ExchangeRateType
            {
                OriginCountry = new Country() { Value = originCountry}
            };

            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new ExchangeRateManager();
                apiResponse.Data = mng.RetrieveAllDestiantionCountry(exchangeRate);
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Get(string originCountry, string destCountry)
        {
            var exchangeRate = new ExchangeRateType
            {
                OriginCountry = new Country() { Value = originCountry },
                DestinationCountry = new Country() { Value = destCountry }
            };

            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new ExchangeRateManager();
                apiResponse.Data = mng.RetrieveAllDatesOfCountries(exchangeRate);
                return apiResponse;
            });
            return Ok(response);
        }
    }
}
