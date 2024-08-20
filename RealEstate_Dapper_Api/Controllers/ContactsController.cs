using Microsoft.AspNetCore.Mvc;//ASP.NET Core MVC özelliklerini kullanmamızı sağlar.
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
//İletişim veritabanı işlemlerini yapan sınıfları kullanmamızı sağlar.

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        //İletişim veritabanı işlemlerini yapacak sınıfı temsil eden bir değişken tanımlar.

        public ContactsController(IContactRepository contactRepository)
        //Sınıfın yapıcı metodu, bu sınıfın kullanılabilmesi için gerekli olan bağımlılığı alır
        //ve sınıf içindeki _contactRepository değişkenine atar.
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4Contact")]//GET - Son Dört İletişimi Getirme
        public async Task<IActionResult> GetLast4Contact()
        {
            var values = await _contactRepository.GetLast4Contact();
            return Ok(values);
        }
    }
}
//Bu kod, son dört iletişim kaydını almak için bir API sağlar. ContactsController sınıfı,
//IContactRepository bağımlılığına sahiptir ve bu bağımlılık, veritabanı işlemlerini gerçekleştirmek için kullanılır.
//GetLast4Contact metodu, veritabanından son dört iletişim kaydını alır ve bu verileri istemciye döner.
