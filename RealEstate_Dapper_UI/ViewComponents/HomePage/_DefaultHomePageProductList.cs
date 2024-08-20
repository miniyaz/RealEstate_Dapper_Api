using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<_DefaultHomePageProductList> _logger;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory, ILogger<_DefaultHomePageProductList> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:44324/api/Products/GetProductByDealOfTheDayTrueWithCategory");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                    if (values != null)
                    {
                        return View(values);
                    }
                }
                else
                {
                    _logger.LogError("API call failed with status code: " + responseMessage.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calling the API.");
            }

            return View(new List<ResultProductDto>()); // Boş bir liste döndür
        }
    }
}
//44324 asıl yazan localhost=swigger
//44359 uygulama çalışınca gelen=ui kodu