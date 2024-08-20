using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RealEstate_Dapper_UI.Controllers
{
    public class TemperaturesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TemperaturesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult CreateTemperature()
        {
            return View();
        }
        public async Task <IActionResult> Index()
        {
            //var temperaturesList = await _httpClientFactory.GetStringAsync("api/Temperatures");
            //ViewBag.Temperatures = temperaturesList;
            try
            {
                #region 1ActiveTemperatureCount
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44324/api/Temperatures/ActiveTemperatureCount");
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.activeTemperatureCount = jsonData;
                #endregion

                #region 2PassiveTemperatureCount
                var client2 = _httpClientFactory.CreateClient();
                var responseMessage2 = await client2.GetAsync("https://localhost:44324/api/Temperatures/PassiveTemperatureCount");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.passiveTemperatureCount = jsonData2;
                #endregion

                #region 3AverageTemperatureCount
                var client3 = _httpClientFactory.CreateClient();
                var responseMessage3 = await client3.GetAsync("https://localhost:44324/api/Temperatures/AverageTemperatureCount");
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.averageTemperatureCount = jsonData3;
                #endregion

                #region 4HighTemperature
                var client4 = _httpClientFactory.CreateClient();
                var responseMessage4 = await client4.GetAsync("https://localhost:44324/api/Temperatures/HighTemperature");
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.highTemperature = jsonData4;
                #endregion

                #region 5LowTemperature
                var client5 = _httpClientFactory.CreateClient();
                var responseMessage5 = await client5.GetAsync("https://localhost:44324/api/Temperatures/LowTemperature");
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                ViewBag.lowTemperature = jsonData5;
                #endregion

                #region 6NewTemperature
                var client6 = _httpClientFactory.CreateClient();
                var responseMessage6 = await client6.GetAsync("https://localhost:44324/api/Temperatures/NewTemperature");
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                ViewBag.newTemperature = jsonData6;
                #endregion

                #region 7LastTemperature
                var client7 = _httpClientFactory.CreateClient();
                var responseMessage7 = await client7.GetAsync("https://localhost:44324/api/Temperatures/LastTemperature");
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                ViewBag.lastTemperature = jsonData7;
                #endregion

                #region 8TemperatureDifference
                var client8 = _httpClientFactory.CreateClient();
                var responseMessage8 = await client8.GetAsync("https://localhost:44324/api/Temperatures/TemperatureNameMax");
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                ViewBag.temperatureNameMax = jsonData8;
                #endregion

                #region 9TemperatureNameMax
                var client9 = _httpClientFactory.CreateClient();
                var responseMessage9 = await client9.GetAsync("https://localhost:44324/api/Temperatures/TemperatureNameMin");
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                ViewBag.temperatureNameMin = jsonData9;
                #endregion

                #region 10TemperatureNameMin
                var client10 = _httpClientFactory.CreateClient();
                var responseMessage10 = await client10.GetAsync("https://localhost:44324/api/Temperatures/TemperatureDifference");
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                ViewBag.temperatureDifference = jsonData10;
                #endregion

                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
