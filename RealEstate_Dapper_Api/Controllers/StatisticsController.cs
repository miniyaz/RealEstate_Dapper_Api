using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IHubContext<SignalRHub> _hubContext;

        public StatisticsController(IStatisticsRepository statisticsRepository, IHubContext<SignalRHub> hubContext)
        {
            _statisticsRepository = statisticsRepository;
            _hubContext = hubContext;
        }

        [HttpGet("ActiveCategoryCount")]
        public async Task<IActionResult> ActiveCategoryCount()
        {
            var result = _statisticsRepository.ActiveCategoryCount();
            await _hubContext.Clients.All.SendAsync("ReceiveActiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }


        [HttpGet("ActiveEmployeeCount")]
        public async Task<IActionResult> ActiveEmployeeCount()
        {
            var result = _statisticsRepository.ActiveEmployeeCount();
            await _hubContext.Clients.All.SendAsync("ReceiveActiveEmployeeCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("ApartmentCount")]
        public async Task<IActionResult> ApartmentCount()
        {
            var result = _statisticsRepository.ApartmentCount();
            await _hubContext.Clients.All.SendAsync("ReceiveApartmentCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("AverageProductPriceByRent")]
        public async Task<IActionResult> AverageProductPriceByRent()
        {
            var result = _statisticsRepository.AverageProductPriceByRent();
            await _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceByRent", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("AverageProductPriceBySale")]
        public async Task<IActionResult> AverageProductPriceBySale()
        {
            var result = _statisticsRepository.AverageProductPriceBySale();
            await _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceBySale", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("AverageRoomCount")]
        public async Task<IActionResult> AverageRoomCount()
        {
            var result = _statisticsRepository.AverageRoomCount();
            await _hubContext.Clients.All.SendAsync("ReceiveAverageRoomCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            var result = _statisticsRepository.CategoryCount();
            await _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("CategoryNameByMaxProductCount")]
        public async Task<IActionResult> CategoryNameByMaxProductCount()
        {
            var result = _statisticsRepository.CategoryNameByMaxProductCount();
            await _hubContext.Clients.All.SendAsync("ReceiveCategoryNameByMaxProductCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("CityNameByMaxProductCount")]
        public async Task<IActionResult> CityNameByMaxProductCount()
        {
            var result = _statisticsRepository.CityNameByMaxProductCount();
            await _hubContext.Clients.All.SendAsync("ReceiveCityNameByMaxProductCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("DifferentCityCount")]
        public async Task<IActionResult> DifferentCityCount()
        {
            var result = _statisticsRepository.DifferentCityCount();
            await _hubContext.Clients.All.SendAsync("ReceiveDifferentCityCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("EmployeeNameByMaxProductCount")]
        public async Task<IActionResult> EmployeeNameByMaxProductCount()
        {
            var result = _statisticsRepository.EmployeeNameByMaxProductCount();
            await _hubContext.Clients.All.SendAsync("ReceiveEmployeeNameByMaxProductCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("LastProductPrice")]
        public async Task<IActionResult> LastProductPrice()
        {
            var result = _statisticsRepository.LastProductPrice();
            await _hubContext.Clients.All.SendAsync("ReceiveLastProductPrice", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("NewestBuildingYear")]
        public async Task<IActionResult> NewestBuildingYear()
        {
            var result = _statisticsRepository.NewestBuildingYear();
            await _hubContext.Clients.All.SendAsync("ReceiveNewestBuildingYear", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("OldestBuildingYear")]
        public async Task<IActionResult> OldestBuildingYear()
        {
            var result = _statisticsRepository.OldestBuildingYear();
            await _hubContext.Clients.All.SendAsync("ReceiveOldestBuildingYear", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("PassiveCategoryCount")]
        public async Task<IActionResult> PassiveCategoryCount()
        {
            var result = _statisticsRepository.PassiveCategoryCount();
            await _hubContext.Clients.All.SendAsync("ReceivePassiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }

        [HttpGet("ProductCount")]
        public async Task<IActionResult> ProductCount()
        {
            var result = _statisticsRepository.ProductCount();
            await _hubContext.Clients.All.SendAsync("ReceiveProductCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(result);
        }
    }
}
