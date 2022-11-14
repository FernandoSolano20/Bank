using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using EntitiesPOJO;
using Newtonsoft.Json;
using RestClient;

namespace Bank
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private async void create_Click(object sender, EventArgs e)
        {
            var countryFlag = country.Text;
            var url = "https://localhost:44322/api/Country";
            var countryObj = new Country();
            countryObj.Value = Base64Encode(countryFlag).ToString();
            var result = await HttpRestClient.PostAsyncMethod<ApiResponse, Country>(url, countryObj);
            value.Text = $@"{(result.Data == null && result.ExceptionMessage != null? result.ExceptionMessage : result?.Message)}";
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string plainText)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(plainText);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private async void get_Click(object sender, EventArgs e)
        {
            //Obtener los datos el los inputs
            var countryValue = country.Text;

            var url = "https://localhost:44322/api/Country?name="
                      + HttpUtility.UrlEncode(Base64Encode(countryValue)) + "";

            var result = await HttpRestClient.GetAsyncMethod<ApiResponse>(url);
            var countryResponse = JsonConvert.DeserializeObject<Country>(result.Data.ToString());
            value.Text = $@"{Base64Decode(countryResponse?.Value)}";
        }

        private async void delete_Click(object sender, EventArgs e)
        {
            var countryValue = country.Text;

            var url = "https://localhost:44322/api/Country?name="
                      + HttpUtility.UrlEncode(Base64Encode(countryValue)) + "";

            var result = await HttpRestClient.DeleteAsyncMethod<ApiResponse>(url);
            value.Text = $@" {result?.Message}";
        }
    }
}
