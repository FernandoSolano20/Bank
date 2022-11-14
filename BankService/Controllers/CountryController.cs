using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using BankCoreAPI;
using BankService.Models;
using EntitiesPOJO;
using Exeptions;

namespace BankService.Controllers
{
    [EnableCors(origins: "https://localhost:44347", headers: "*", methods: "*")]
    public class CountryController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public async Task<IHttpActionResult> Get()
        {
            var response = await Task.Run(() =>
            {
                apiResponse = new ApiResponse();
                var mng = new CountryManager();
                apiResponse.Data = mng.RetrieveAll();
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Post(Country exchangeRate)
        {
            try
            {
                var response = await Task.Run(() =>
                {
                    var mng = new CountryManager();
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

        public async Task<IHttpActionResult> Get(string name)
        {
            var exchangeRate = new Country()
            {
                Value = name
            };

            var response = await Task.Run(() =>
            {
                var mng = new CountryManager();
                exchangeRate = mng.RetrieveById(exchangeRate);
                apiResponse = new ApiResponse();
                apiResponse.Data = exchangeRate;
                return apiResponse;
            });
            return Ok(response);
        }

        public async Task<IHttpActionResult> Put(Country exchangeRate)
        {
            var response = await Task.Run(() =>
            {
                var mng = new CountryManager();
                mng.Update(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }

        public async Task<IHttpActionResult> Delete(string name)
        {
            var exchangeRate = new Country()
            {
                Value = name
            };
            var response = await Task.Run(() =>
            {
                var mng = new CountryManager();
                mng.Delete(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }

        public async Task<IHttpActionResult> Delete(Country exchangeRate)
        {
            var response = await Task.Run(() =>
            {
                var mng = new CountryManager();
                mng.Delete(exchangeRate);

                apiResponse = new ApiResponse();
                apiResponse.Message = "Action was executed.";
                return apiResponse;
            });
            return Content(HttpStatusCode.OK, response);
        }
    }
}
