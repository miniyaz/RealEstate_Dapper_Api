using Microsoft.AspNetCore.Mvc;//ASP.NET Core MVC özelliklerini kullanmamızı sağlar.
using Microsoft.AspNetCore.SignalR;//SignalR ile gerçek zamanlı iletişim kurmamızı sağlar.
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;//Çalışan veri transfer objelerini (DTO) kullanmamızı sağlar.
using RealEstate_Dapper_Api.Hubs;//SignalR hub'larını kullanmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
//Çalışan veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;
//İstatistik veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    /*
     * Kodun Genel Yapısı ve Amacı 
     * Bu kod, "EmployeesController" adlı bir sınıfı tanımlar. Bu sınıf, çalışan verilerini
     * eklemek, silmek, güncellemek ve listelemek gibi işlemleri yapar.
     * Ayrıca, bu işlemler sırasında bazı istatistikleri hesaplar ve 
     * bu istatistikleri SignalR kullanarak istemcilere gönderir.
     */
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        // Çalışan veritabanı işlemlerini yapacak sınıfı temsil eden bir değişken tanımlar.
        private readonly IHubContext<SignalRHub> _hubContext; //yeni eklendi
        // SignalR hub'ını temsil eden bir değişken tanımlar.
        private readonly IStatisticsRepository _statisticsRepository;
        //İstatistik veritabanı işlemlerini yapacak sınıfı temsil eden bir değişken tanımlar.
        public EmployeesController(IEmployeeRepository employeeRepository, IStatisticsRepository statisticsRepository, IHubContext<SignalRHub> hubContext)
        // Sınıfın yapıcı metodu, bu sınıfın kullanılabilmesi için gerekli olan bağımlılıkları alır
        // ve sınıf içindeki değişkenlere atar.
        {
            _employeeRepository = employeeRepository;
            _hubContext = hubContext; //yeni eklendi
            _statisticsRepository = statisticsRepository;
        }

        [HttpGet]//Tüm çalışanları listeler.
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployee();
            return Ok(values);
        }
        [HttpPost]//Çalışan Oluşturma
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeRepository.CreateEmployee(createEmployeeDto);
            var result = _statisticsRepository.ActiveEmployeeCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveEmployeeCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok("Personel Başarılı Bir Şekilde Eklendi");
            //Yeni bir çalışan ekler ve ardından aktif çalışan sayısını günceller,
            //bu güncellemeyi SignalR kullanarak istemcilere gönderir.
        }

        [HttpDelete("{id}")]//Çalışan Silme
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id); 
            var result = _statisticsRepository.ActiveEmployeeCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveEmployeeCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok("Personel Başarılı Bir Şekilde Silindi");
            //Belirtilen ID'ye sahip çalışanı siler ve ardından aktif çalışan sayısını günceller,
            //bu güncellemeyi SignalR kullanarak istemcilere gönderir.
        }

        [HttpPut]//Çalışan Güncelleme
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            var result = _statisticsRepository.ActiveEmployeeCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveEmployeeCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok("Personel Başarıyla Güncellendi");
            //Var olan bir çalışanı günceller ve ardından aktif çalışan sayısını günceller,
            //bu güncellemeyi SignalR kullanarak istemcilere gönderir.
        }

        [HttpGet("{id}")]// Çalışan Detay Görüntüleme
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            var result = _statisticsRepository.ActiveEmployeeCount();
            _hubContext.Clients.All.SendAsync("ReceiveActiveEmployeeCount", result); // SignalR ile istemcilere güncelleme gönder
            return Ok(value);
            //Belirtilen ID'ye sahip çalışan detayını getirir ve ardından aktif çalışan sayısını günceller,
            //bu güncellemeyi SignalR kullanarak istemcilere gönderir.
        }
    }
}
/*
 * Bu kod, çalışan verilerini yönetmek için bir API sağlar ve bu işlemler sırasında 
 * gerçek zamanlı olarak aktif çalışan sayısını günceller ve SignalR kullanarak 
 * bu güncellemeyi istemcilere iletir. Bu, istemcilerin (örneğin web tarayıcıları) 
 * anında güncel verilere sahip olmasını sağlar.
 */