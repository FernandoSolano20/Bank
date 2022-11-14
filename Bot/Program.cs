using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using EntitiesPOJO;
using MoreLinq;
using RestClient;

namespace Bot
{
    class Program
    {
        private static readonly TelegramBotClient botClient = new TelegramBotClient("1084470537:AAHNQibxcTeETpv5W5RL2H_lflNBtlS6Cds");
        private static int status = 0;
        private static int AdminId = 1089109605;
        private static string originCountry;
        private static string destCountry;
        private static string date;
        static void Main(string[] args)
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.OnCallbackQuery += BotOnCallbackQueryReceived;
            botClient.OnReceiveError += BotOnReceiveError;
            botClient.StartReceiving();
            Run().Wait();
            Console.ReadLine();
            botClient.StopReceiving();
        }

        static async Task Run()
        {
            originCountry = "";
            destCountry = "";
            date = "";
            status = 0;
            await botClient.SendChatActionAsync(AdminId, ChatAction.Typing);
            await Task.Delay(50);
            var me = await botClient.GetMeAsync();
            await botClient.SendTextMessageAsync(AdminId, "Hola " + me + " " + IsoCountryCodeToFlagEmoji("gb"));
            ShowOriginCountries();
        }

        private static async void ShowOriginCountries()
        {
            var lstBtn = new List<InlineKeyboardButton[]>();

            var url = "https://localhost:44322/api/ExchangeRate";
            var lstExchangesRates = await GetAllExchangeRate(url);
            var list = lstExchangesRates.Select(x => new Country() {Value = x.OriginCountry.Value}).Distinct().ToList();

            foreach (var exchange in list)
            {
                var btn = new[]
                {
                    InlineKeyboardButton.WithCallbackData(
                        text:Base64Decode(exchange.Value),
                        callbackData: exchange.Value)
                };
                lstBtn.Add(btn);
            }

            var keyboard_Uno = new InlineKeyboardMarkup(lstBtn);

            await botClient.SendTextMessageAsync(AdminId, "Elija un país de origen: ", replyMarkup: keyboard_Uno);
        }

        private static async void ShowDestCountries(string origin)
        {
            var lstBtn = new List<InlineKeyboardButton[]>();

            var url = "https://localhost:44322/api/ExchangeRate?originCountry=" + HttpUtility.UrlEncode(origin) +"";
            var lstExchangesRates = await GetAllExchangeRate(url);
            var list = lstExchangesRates.Select(x => new Country() { Value = x.DestinationCountry.Value }).Distinct().ToList();

            foreach (var exchange in list)
            {
                var btn = new[]
                {
                    InlineKeyboardButton.WithCallbackData(
                        text:Base64Decode(exchange.Value),
                        callbackData: exchange.Value)
                };
                lstBtn.Add(btn);
            }

            var keyboard_Uno = new InlineKeyboardMarkup(lstBtn);

            await botClient.SendTextMessageAsync(AdminId, "Elija un país de destino: ", replyMarkup: keyboard_Uno);
        }

        private static async void ShowDates(string origin, string dest)
        {
            var lstBtn = new List<InlineKeyboardButton[]>();

            var url = "https://localhost:44322/api/ExchangeRate?originCountry=" + HttpUtility.UrlEncode(origin) + "&destCountry="+ HttpUtility.UrlEncode(dest) + "";
            var lstExchangesRates = await GetAllExchangeRate(url);
            var list = lstExchangesRates.Select(x => new ExchangeRateType() { Value = x.Value,Day = x.Day}).Distinct().ToList();

            foreach (var exchange in list)
            {
                var btn = new[]
                {
                    InlineKeyboardButton.WithCallbackData(
                        text:exchange.Day.ToLongDateString(),
                        callbackData: exchange.Day.ToString("yyyy-MM-dd"))
                };
                lstBtn.Add(btn);
            }

            var keyboard_Uno = new InlineKeyboardMarkup(lstBtn);

            await botClient.SendTextMessageAsync(AdminId, "Elija un día: ", replyMarkup: keyboard_Uno);
        }

        private static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            await botClient.SendChatActionAsync(AdminId, ChatAction.Typing);

            await Task.Delay(50);

            if (!string.IsNullOrEmpty(originCountry) && !string.IsNullOrEmpty(destCountry) && !string.IsNullOrEmpty(date))
            {
                var result = await GetExchangeRate(date,originCountry,destCountry);
                await botClient.SendTextMessageAsync(AdminId, "La conversion es de: " + result.Value * Double.Parse(e.Message.Text));
                await Run();
            }

        }

        private static async Task<List<ExchangeRateType>> GetAllExchangeRate(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await HttpRestClient.GetAsyncMethod<ApiResponse>(url);
            var list = new List<ExchangeRateType>();
            if (result.Data != null)
            {
                list = JsonConvert.DeserializeObject<List<ExchangeRateType>>(result.Data.ToString());
            }
            return list;
        }

        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;
            switch (status)
            {
                case 0:
                    originCountry = callbackQuery.Data;
                    ShowDestCountries(originCountry);
                    status = 1;
                    break;

                case 1:
                    destCountry = callbackQuery.Data;
                    ShowDates(originCountry, destCountry);
                    status = 2;
                    break;

                case 2:
                    date = callbackQuery.Data;
                    status = 3;
                    await botClient.SendTextMessageAsync(AdminId, "Digite el monto");
                    break;
            }
        }

        private static async Task<ExchangeRateType> GetExchangeRate(string date, string origin, string dest)
        {
            var url = "https://localhost:44322/api/ExchangeRate?dateRequest=" + date + "&originCountry=" + HttpUtility.UrlEncode(origin) + "&destCountry=" + HttpUtility.UrlEncode(dest) + "";
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await HttpRestClient.GetAsyncMethod<ApiResponse>(url);
            var exchange = new ExchangeRateType();
            if (result.Data != null)
            {
                exchange = JsonConvert.DeserializeObject<ExchangeRateType>(result.Data.ToString());
            }
            return exchange;
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine("Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }

        public static string IsoCountryCodeToFlagEmoji(string country)
        {
            return string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
