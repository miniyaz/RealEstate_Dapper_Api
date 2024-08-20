using Microsoft.AspNetCore.Mvc;//ASP.NET Core MVC özelliklerini kullanmamızı sağlar.
using RealEstate_Dapper_Api.Hubs;//SignalR hub'larını kullanmamızı sağlar.
using RealEstate_Dapper_Api.Dtos.CategoryDtos;//Kategori veri transfer objelerini (DTO) kullanmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.CategoryRepository;//Kategori veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.
using Microsoft.AspNetCore.SignalR;//SignalR ile gerçek zamanlı iletişim kurmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
//İstatistik veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        //Kategori veritabanı işlemlerini yapacak sınıfı temsil eden bir değişken tanımlar.
        private readonly IHubContext<SignalRHub> _hubContext; //yeni eklendi
        //SignalR hub'ını temsil eden bir değişken tanımlar.
        private readonly IStatisticsRepository _statisticsRepository;
        //İstatistik veritabanı işlemlerini yapacak sınıfı temsil eden bir değişken tanımlar.
        public CategoriesController(ICategoryRepository categoryRepository, IStatisticsRepository statisticsRepository, IHubContext<SignalRHub> hubContext)
        //Sınıfın yapıcı metodu, bu sınıfın kullanılabilmesi için gerekli olan bağımlılıkları alır ve
        //sınıf içindeki değişkenlere atar.
        {
            _categoryRepository = categoryRepository;
            _hubContext = hubContext; //yeni eklendi
            _statisticsRepository = statisticsRepository;
        }
        [HttpGet]//Kategori Listeleme
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategory();
            return Ok(values);
        }
        [HttpPost]//Kategori Oluşturma
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.CreateCategory(createCategoryDto);
            var result = _statisticsRepository.ActiveCategoryCount();
            var result1 = _statisticsRepository.CategoryCount();
            var result2 = _statisticsRepository.PassiveCategoryCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceivePassiveCategoryCount", result2); // SignalR ile istemcilere güncelleme gönder
            return Ok("Kategori Başarılı Bir Şekilde Eklendi");
            //Yeni bir kategori ekler ve ardından istatistikleri günceller,
            //bu güncellemeleri SignalR kullanarak istemcilere gönderir.
        }
        [HttpDelete("{id}")]//Kategrori Silme
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
            var result = _statisticsRepository.ActiveCategoryCount();
            var result1 = _statisticsRepository.CategoryCount();
            var result2 = _statisticsRepository.PassiveCategoryCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", result1);
            _hubContext.Clients.All.SendAsync("ReceivePassiveCategoryCount", result2);
            return Ok("Kategori Başarılı Bir Şekilde Silindi");
            //Belirtilen ID'ye sahip kategoriyi siler ve ardından istatistikleri günceller,
            //bu güncellemeleri SignalR kullanarak istemcilere gönderir.
        }
        [HttpPut]//KAtegori Güncelleme
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.UpdateCategory(updateCategoryDto);
            var result = _statisticsRepository.ActiveCategoryCount();
            var result1 = _statisticsRepository.CategoryCount();
            var result2 = _statisticsRepository.PassiveCategoryCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", result1); 
            _hubContext.Clients.All.SendAsync("ReceivePassiveCategoryCount", result2); 
            return Ok("Kategori Başarıyla Güncellendi");
            //Var olan bir kategoriyi günceller ve ardından istatistikleri günceller,
            //bu güncellemeleri SignalR kullanarak istemcilere gönderir.
        }
        [HttpGet("{id}")]//Kategori Detay Görüntüleme
        public async Task<IActionResult> GetCategory(int id)
        {
            var value=await _categoryRepository.GetCategory(id);
            var result = _statisticsRepository.ActiveCategoryCount();
            var result1 = _statisticsRepository.CategoryCount();
            var result2 = _statisticsRepository.PassiveCategoryCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveCategoryCount", result); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceiveCategoryCount", result1); // SignalR ile istemcilere güncelleme gönder
            _hubContext.Clients.All.SendAsync("ReceivePassiveCategoryCount", result2); // SignalR ile istemcilere güncelleme gönder
            return Ok(value);
            //Belirtilen ID'ye sahip kategori detayını getirir ve ardından istatistikleri günceller,
            //bu güncellemeleri SignalR kullanarak istemcilere gönderir.
        }
    }
}
/*
 * Bu kod, kategori verilerini yönetmek için bir API sağlar ve bu işlemler sırasında gerçek zamanlı olarak istatistikleri günceller
 * ve SignalR kullanarak bu güncellemeleri istemcilere iletir. 
 * Bu, istemcilerin (örneğin web tarayıcıları) anında güncel verilere sahip olmasını sağlar.
 */