using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IHubContext<SignalRHub> _hubContext; //yeni eklendi
        private readonly IStatisticsRepository _statisticsRepository;

        public ProductDetailsController(IProductRepository productRepository, IStatisticsRepository statisticsRepository, IHubContext<SignalRHub> hubContext)
        {
            _productRepository = productRepository;
            _hubContext = hubContext; //yeni eklendi
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(int id)
        {
            var values = await _productRepository.GetProductDetailByProductId(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(Dtos.ProductDtos.CreateProductDetailDto createProductDetailDto)
        {
            await _productRepository.CreateProductDetail(createProductDetailDto);
            var result = _statisticsRepository.AverageRoomCount();
            var result1 = _statisticsRepository.NewestBuildingYear();
            var result2 = _statisticsRepository.OldestBuildingYear();
            _hubContext.Clients.All.SendAsync("ReceiveAverageRoomCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveNewestBuildingYear", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveOldestBuildingYear", result2); // SignalR ile istemcilere güncelleme gönder
            return Ok("İlan Detaları Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(int id)
        {
            await _productRepository.DeleteProductDetail(id);
            var result = _statisticsRepository.AverageRoomCount();
            var result1 = _statisticsRepository.NewestBuildingYear();
            var result2 = _statisticsRepository.OldestBuildingYear();
            _hubContext.Clients.All.SendAsync("ReceiveAverageRoomCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveNewestBuildingYear", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveOldestBuildingYear", result2); // SignalR ile istemcilere güncelleme gönder
            return Ok("İlan Detayları Başarılı Bir Şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(Dtos.ProductDtos.UpdateProductDetailDto updateProductDetailDto)
        {
            await _productRepository.UpdateProductDetail(updateProductDetailDto);
            var result = _statisticsRepository.AverageRoomCount();
            var result1 = _statisticsRepository.NewestBuildingYear();
            var result2 = _statisticsRepository.OldestBuildingYear();
            _hubContext.Clients.All.SendAsync("ReceiveAverageRoomCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveNewestBuildingYear", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveOldestBuildingYear", result2); // SignalR ile istemcilere güncelleme gönder
            return Ok("İlan Detayları Başarılı Bir Şekilde Güncellendi.");
        }
    }
}
