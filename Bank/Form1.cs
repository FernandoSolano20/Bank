using System;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using EntitiesPOJO;
using RestClient;

namespace Bank
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            var date = dateTime.Value.ToString("yyyy-MM-dd");
            var originCountryValue = this.originCountry.Text;
            var destinationCountryValue = this.destinationCountry.Text;
            var exchangeRate = Convert.ToDouble(inputExchange.Text);
            var url = "https://localhost:44322/api/ExchangeRate";
            var exchangeRateType = new ExchangeRateType();
            exchangeRateType.Day = DateTime.Parse(date);
            exchangeRateType.Value = exchangeRate;
            exchangeRateType.DestinationCountry = new Country(){Value = Base64Encode(destinationCountryValue).ToString() };
            exchangeRateType.OriginCountry = new Country() { Value = Base64Encode(originCountryValue).ToString() };

            var result = await HttpRestClient.PostAsyncMethod<ApiResponse, ExchangeRateType>(url, exchangeRateType);
            exchangeRateValue.Text = $@"{(result.Data == null && result.ExceptionMessage != null ? result.ExceptionMessage : result?.Message)}";
        }

        private async void getBtn_Click(object sender, EventArgs e)
        {
            //Obtener los datos el los inputs
            var dateRequest = dateTime.Value.ToString("yyyy-MM-dd");
            var originCountryRequest = this.originCountry.Text;
            var destinationCountryRequest = this.destinationCountry.Text;

            var url = "https://localhost:44322/api/ExchangeRate?dateRequest=" + dateRequest + "" +
                      "&originCountry="+ HttpUtility.UrlEncode(Base64Encode(originCountryRequest)) + "" +
                      "&destCountry="+ HttpUtility.UrlEncode(Base64Encode(destinationCountryRequest)) + "";

            var result = await HttpRestClient.GetAsyncMethod<ApiResponse>(url);
            if (result.Data != null)
            {
                var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateType>(result.Data.ToString());
                exchangeRateValue.Text = exchangeRate?.Value.ToString();
            }
            else
            {
                exchangeRateValue.Text = $@"{(result.Data == null && result.ExceptionMessage != null ? result.ExceptionMessage : result?.Message)}";
            }
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            var date = dateTime.Value.ToString("yyyy-MM-dd");
            var originCountryValue = this.originCountry.Text;
            var destinationCountryValue = this.destinationCountry.Text;
            var exchangeRate = Convert.ToDouble(inputExchange.Text);
            var url = "https://localhost:44322/api/ExchangeRate";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var exchangeRateType = new ExchangeRateType();
            exchangeRateType.Day = DateTime.Parse(date);
            exchangeRateType.Value = exchangeRate;
            exchangeRateType.DestinationCountry = new Country() { Value = Base64Encode(destinationCountryValue).ToString() };
            exchangeRateType.OriginCountry = new Country() { Value = Base64Encode(originCountryValue).ToString() };

            var result = await HttpRestClient.PutAsyncMethod<ApiResponse, ExchangeRateType>(url, exchangeRateType);
            exchangeRateValue.Text = $@"{(result.Data == null && result.ExceptionMessage != null ? result.ExceptionMessage : result?.Message)}";
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            var dateRequest = dateTime.Value.ToString("yyyy-MM-dd");
            var originCountryRequest = this.originCountry.Text;
            var destinationCountryRequest = this.destinationCountry.Text;

            var url = "https://localhost:44322/api/ExchangeRate?dateRequest=" + dateRequest + "" +
                      "&originCountry=" + HttpUtility.UrlEncode(Base64Encode(originCountryRequest)) + "" +
                      "&destCountry=" + HttpUtility.UrlEncode(Base64Encode(destinationCountryRequest)) + "";

            var result = await HttpRestClient.DeleteAsyncMethod<ApiResponse>(url);
            exchangeRateValue.Text = $@"{(result.Data == null && result.ExceptionMessage != null ? result.ExceptionMessage : result?.Message)}";
        }

        private async void btnConvertion_Click(object sender, EventArgs e)
        {
            var url = "https://localhost:44322/api/ExchangeRate?dateRequest=" 
                      + dateTime.Value.ToString("yyyy-MM-dd") + 
                      "&originCountry=" + HttpUtility.UrlEncode(Base64Encode(originCountry.Text)) + 
                      "&destCountry=" + HttpUtility.UrlEncode(Base64Encode(destinationCountry.Text)) + "" +
                      "&value=" + convertion.Text;
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var responseMessage = await client.GetAsync(url, HttpCompletionOption.ResponseContentRead);
            var resultAsync = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse>(resultAsync);
            if (result.Data != null)
            {
                var exchangeRate = JsonConvert.DeserializeObject<ExchangeRateType>(result.Data.ToString());
                exchangeRateValue.Text = exchangeRate?.Value.ToString();
            }
            else
            {
                exchangeRateValue.Text = $@"{(result.Data == null && result.ExceptionMessage != null ? result.ExceptionMessage : result?.Message)}";
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static T DeserializeJsonFromString<T>(string stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            var searchResult = JsonConvert.DeserializeObject<T>(stream);
            return searchResult;
        }

        private void countryCrud_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
    }
}
