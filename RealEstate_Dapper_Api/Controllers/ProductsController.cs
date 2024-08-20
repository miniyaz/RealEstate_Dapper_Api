using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
using CreateProductDetailDto = RealEstate_Dapper_Api.Dtos.ProductDtos.CreateProductDetailDto;


namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IHubContext<SignalRHub> _hubContext; //yeni eklendi
        private readonly IStatisticsRepository _statisticsRepository;

        public ProductsController(IProductRepository productRepository, IStatisticsRepository statisticsRepository, IHubContext<SignalRHub> hubContext)
        {
            _productRepository = productRepository;
            _hubContext = hubContext; //yeni eklendi
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByTrue(id);
            return Ok(values);
        }

        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeAsyncByFalse(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {//burayı dikkatli araştır.
            await _productRepository.CreateProduct(createProductDto);
            var result = _statisticsRepository.ApartmentCount();
            var result1 = _statisticsRepository.AverageProductPriceByRent();
            var result2 = _statisticsRepository.AverageProductPriceBySale();
            var result3 = _statisticsRepository.CategoryNameByMaxProductCount();
            var result4 = _statisticsRepository.CityNameByMaxProductCount();
            var result5 = _statisticsRepository.DifferentCityCount();
            var result6 = _statisticsRepository.EmployeeNameByMaxProductCount();
            var result7 = _statisticsRepository.LastProductPrice();
            var result8 = _statisticsRepository.ProductCount();
            _hubContext.Clients.All.SendAsync("ReceiveApartmentCount", result);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceByRent", result1);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceBySale", result2);
            _hubContext.Clients.All.SendAsync("ReceiveCategoryNameByMaxProductCount", result3);
            _hubContext.Clients.All.SendAsync("ReceiveCityNameByMaxProductCount", result4);
            _hubContext.Clients.All.SendAsync("ReceiveDifferentCityCount", result5);
            _hubContext.Clients.All.SendAsync("ReceiveEmployeeNameByMaxProductCount", result6);
            _hubContext.Clients.All.SendAsync("ReceiveLastProductPrice", result7);
            _hubContext.Clients.All.SendAsync("ReceiveProductCount", result8);
            return Ok("İlan Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
            var result = _statisticsRepository.ApartmentCount();
            var result1 = _statisticsRepository.AverageProductPriceByRent();
            var result2 = _statisticsRepository.AverageProductPriceBySale();
            var result3 = _statisticsRepository.CategoryNameByMaxProductCount();
            var result4 = _statisticsRepository.CityNameByMaxProductCount();
            var result5 = _statisticsRepository.DifferentCityCount();
            var result6 = _statisticsRepository.EmployeeNameByMaxProductCount();
            var result7 = _statisticsRepository.LastProductPrice();
            var result8 = _statisticsRepository.ProductCount();
            _hubContext.Clients.All.SendAsync("ReceiveApartmentCount", result);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceByRent", result1);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceBySale", result2);
            _hubContext.Clients.All.SendAsync("ReceiveCategoryNameByMaxProductCount", result3);
            _hubContext.Clients.All.SendAsync("ReceiveCityNameByMaxProductCount", result4);
            _hubContext.Clients.All.SendAsync("ReceiveDifferentCityCount", result5);
            _hubContext.Clients.All.SendAsync("ReceiveEmployeeNameByMaxProductCount", result6);
            _hubContext.Clients.All.SendAsync("ReceiveLastProductPrice", result7);
            _hubContext.Clients.All.SendAsync("ReceiveProductCount", result8);

            return Ok("İlan Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateProduct(updateProductDto);
            var result = _statisticsRepository.ApartmentCount();
            var result1 = _statisticsRepository.AverageProductPriceByRent();
            var result2 = _statisticsRepository.AverageProductPriceBySale();
            var result3 = _statisticsRepository.CategoryNameByMaxProductCount();
            var result4 = _statisticsRepository.CityNameByMaxProductCount();
            var result5 = _statisticsRepository.DifferentCityCount();
            var result6 = _statisticsRepository.EmployeeNameByMaxProductCount();
            var result7 = _statisticsRepository.LastProductPrice();
            var result8 = _statisticsRepository.ProductCount();
            _hubContext.Clients.All.SendAsync("ReceiveApartmentCount", result);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceByRent", result1);
            _hubContext.Clients.All.SendAsync("ReceiveAverageProductPriceBySale", result2);
            _hubContext.Clients.All.SendAsync("ReceiveCategoryNameByMaxProductCount", result3);
            _hubContext.Clients.All.SendAsync("ReceiveCityNameByMaxProductCount", result4);
            _hubContext.Clients.All.SendAsync("ReceiveDifferentCityCount", result5);
            _hubContext.Clients.All.SendAsync("ReceiveEmployeeNameByMaxProductCount", result6);
            _hubContext.Clients.All.SendAsync("ReceiveLastProductPrice", result7);
            _hubContext.Clients.All.SendAsync("ReceiveProductCount", result8);

            return Ok("İlan Başarıyla Güncellendi");
        }

        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var values = await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }

        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue, propertyCategoryId, city);
            return Ok(values);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("GetLast3Product")]
        public async Task<IActionResult> GetLast3Product()
        {
            var values = await _productRepository.GetLast3ProductAsync();
            return Ok(values);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        //{
        //    await _productRepository.CreateProductDetail(createProductDetailDto);
        //    return Ok("İlan Detaları Başarılı Bir Şekilde Eklendi");
        //}

        //[HttpDelete]
        //public async Task<IActionResult> DeleteProductDetail(int id)
        //{
        //    await _productRepository.DeleteProductDetail(id);
        //    return Ok("İlan Detayları Başarılı Bir Şekilde Silindi.");
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateProductDetail(Dtos.ProductDtos.UpdateProductDetailDto updateProductDetailDto)
        //{
        //    await _productRepository.UpdateProductDetail(updateProductDetailDto);
        //    return Ok("İlan Detayları Başarılı Bir Şekilde Silindi.");
        //}
    }
}
