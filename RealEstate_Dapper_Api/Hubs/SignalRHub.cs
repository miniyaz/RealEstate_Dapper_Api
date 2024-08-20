using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //public async Task SendActiveCategoryCount()
        //{
        //    //try
        //    //{
        //    //    var client = _httpClientFactory.CreateClient();
        //    //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/ActiveCategoryCount");
        //    //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    //    await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine(ex.Message);
        //    //}

        //}
        //public async Task SendActiveEmployeeCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/ActiveEmployeeCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveActiveEmployeeCount", value);
        //}
        //public async Task SendApartmentCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/ApartmentCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveApartmentCount", value);
        //}
        //public async Task SendAverageProductPriceByRent()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/AverageProductPriceByRent");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveAverageProductPriceByRent", value);
        //}

        //public async Task SendAverageProductPriceBySale()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/AverageProductPriceBySale");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveAverageProductPriceBySale", value);
        //}

        //public async Task SendAverageRoomCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/AverageRoomCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveAverageRoomCount", value);
        //}

        //public async Task SendCategoryCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/CategoryCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveCategoryCount", value);
        //}

        //public async Task SendCategoryNameByMaxProductCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/CategoryNameByMaxProductCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveCategoryNameByMaxProductCount", value);
        //}

        //public async Task SendCityNameByMaxProductCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/CityNameByMaxProductCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveCityNameByMaxProductCount", value);
        //}

        //public async Task SendDifferentCityCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/DifferentCityCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveDifferentCityCount", value);
        //}

        //public async Task SendEmployeeNameByMaxProductCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/EmployeeNameByMaxProductCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveEmployeeNameByMaxProductCount", value);
        //}

        //public async Task SendLastProductPrice()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/LastProductPrice");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveLastProductPrice", value);
        //}

        //public async Task SendNewestBuildingYear()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/NewestBuildingYear");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveNewestBuildingYear", value);
        //}

        //public async Task SendOldestBuildingYear()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/OldestBuildingYear");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveOldestBuildingYear", value);
        //}

        //public async Task SendPassiveCategoryCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/PassiveCategoryCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceivePassiveCategoryCount", value);
        //}

        //public async Task SendProductCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:44324/api/Statistics/ProductCount");
        //    var value = await responseMessage.Content.ReadAsStringAsync();
        //    await Clients.All.SendAsync("ReceiveProductCount", value);
        //}
    }
}
