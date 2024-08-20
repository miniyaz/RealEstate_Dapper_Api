using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
//BottomGrid veri transfer objelerini (DTO) içeren dosyaları kullanmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;
//BottomGrid ile ilgili veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.

namespace RealEstate_Dapper_Api.Controllers
{//design pattern ve algoritma arasındaki fark
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    //BottomGridsController adında bir sınıf tanımlar ve ControllerBase sınıfından türetir (kalıtım alır).
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        //Sınıfın yapıcı metodu, IBottomGridRepository türünde bir parametre alır ve
        //bu parametreyi sınıfın _bottomGridRepository değişkenine atar.Bu sayede IBottomGridRepository'nin yöntemlerini (methodlarını) kullanabiliriz.
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]//Tüm BottomGrid verilerini listeler.
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGrid();
            return Ok(values);
        }

        [HttpPost]//Yeni bir BottomGrid verisi oluşturur.
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Veri Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]//Belirtilen ID'ye sahip BottomGrid verisini siler.
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
            await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Veri Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]//Var olan bir BottomGrid verisini günceller.
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("Veri Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]//Belirtilen ID'ye sahip BottomGrid verisini getirir.
        public async Task<IActionResult> GetBottomGrid(int id)
        {
            var value = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
        }
    }
}
/*
  Design Pattern ve Algoritma Arasındaki Fark:
Design Pattern(Tasarım Deseni): Yazılım geliştirirken tekrar eden problemleri çözmek için kullanılan, 
kanıtlanmış çözüm yollarıdır. Örneğin, Repository tasarım deseni, veri erişim kodlarını soyutlamak ve merkezi bir yerden yönetmek için kullanılır.
Algoritma: Belirli bir problemi çözmek veya belirli bir görevi yerine getirmek için tasarlanmış adım adım talimatlar dizisidir. 
Örneğin, bir sıralama algoritması, bir dizi sayıyı belirli bir sıraya koymak için kullanılan talimatları içerir.   */

/*
 * Bu kontrolcüde, Repository deseni kullanılarak veri erişim işlemleri
 * (Create, Read, Update, Delete) soyutlanmış ve yönetilmiştir.
 * Algoritmalar ise genellikle bu tasarım desenlerinin içinde kullanılır, 
 * örneğin veritabanı işlemleri sırasında belirli bir veri kümesini işlemek için.
 */